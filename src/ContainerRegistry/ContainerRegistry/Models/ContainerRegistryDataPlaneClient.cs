﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ContainerRegistry.Models;
using Microsoft.Azure.Commands.ContainerRegistry.DataPlaneOperations;
using Microsoft.Azure.ContainerRegistry;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Exceptions;
using Track2 = Azure.Containers.ContainerRegistry;
using Azure.Containers.ContainerRegistry;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ContainerRegistry.Track2Models;
using Azure;
using Azure.Core.Serialization;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class ContainerRegistryDataPlaneClient
    {
        private const string _defaultGrantType = "access_token";
        private const string _defaultScope = "registry:catalog:*";
        private const string _https = "https://";
        private const string _refreshTokenKey = "AcrRefreshToken";

        private AzureContainerRegistryClient _client;
        private Track2.ContainerRegistryClient _track2Client;
        private Track2TokenCredential _credential;
        private string _accessToken = default(string);
        private string _endPoint;
        private readonly string _suffix;
        private IAzureContext _context;

        private readonly string _acrTokenCacheKey;

        private const int _minutesBeforeExpiration = 5;


        public Action<string> VerboseLogger { get; set; }
        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }

        public ContainerRegistryDataPlaneClient(IAzureContext context, string acrTokenCacheKey)
        {
            _context = context;
            _suffix = _context.Environment.ContainerRegistryEndpointSuffix;
            ServiceClientCredentials clientCredential = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(_accessToken, () => _accessToken);
            _client = AzureSession.Instance.ClientFactory.CreateCustomArmClient<AzureContainerRegistryClient>(clientCredential);
            _acrTokenCacheKey = acrTokenCacheKey;
        }

        public AzureContainerRegistryClient GetClient()
        {
            return _client;
        }

        public string Authenticate(string scope = _defaultScope)
        {
            _accessToken = GetToken(scope);
            return _accessToken;
        }

        private string GetToken(string scope)
        {
            string key = string.Format("{0}:{1}", GetEndPoint(), scope);

            AcrTokenCache cache;
            if (!AzureSession.Instance.TryGetComponent<AcrTokenCache>(_acrTokenCacheKey, out cache))
            {
                AzureSession.Instance.RegisterComponent<AcrTokenCache>(_acrTokenCacheKey, () => new AcrTokenCache());
                AzureSession.Instance.TryGetComponent<AcrTokenCache>(_acrTokenCacheKey, out cache);
            }

            AcrToken value;
            if (!cache.TryGetToken(key, out value) || value.IsExpired(_minutesBeforeExpiration))
            {
                string token = scope.Equals(_refreshTokenKey) ? GetRefreshToken() : GetAccessToken(scope);
                try
                {
                    value = new AcrToken(token);
                }
                catch
                {
                    throw new AzPSInvalidOperationException(string.Format("Invalid token for {0}", scope));
                }

                cache.Set(key, value);
            }
            return value.GetToken();
        }

        public void SetEndPoint(string RegistryName)
        {
            _endPoint = RegistryName.ToLower() + '.' + _suffix;
            _client.LoginUri = _https + _endPoint;
            _credential = new Track2TokenCredential(new DataServiceCredential(AzureSession.Instance.AuthenticationFactory,
                        _context, AzureEnvironment.ExtendedEndpoint.ContainerRegistryEndpointResourceId));
            _track2Client = new Track2.ContainerRegistryClient(new Uri(_https + _endPoint), _credential, new Track2.ContainerRegistryClientOptions()
            {
                Audience = _context.Environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.ContainerRegistryEndpointResourceId]
            });
        }

        public string GetEndPoint()
        {
            return _endPoint;
        }
        
        private string GetArmAccessToken()
        {
            return AzureSession
                   .Instance.AuthenticationFactory
                   .Authenticate(_context.Account, _context.Environment, _context.Tenant.Id, null, ShowDialog.Never, null, _context.Environment.GetTokenAudience(AzureEnvironment.Endpoint.ResourceManager))
                   .AccessToken;
        }

        public string GetRefreshToken()
        {
            return GetClient()
                    .RefreshTokens
                    .GetFromExchangeAsync(grantType: _defaultGrantType, service: _endPoint, accessToken: GetArmAccessToken())
                    .GetAwaiter()
                    .GetResult()
                    .RefreshTokenProperty;
        }

        private string GetAccessToken(string scope)
        {
            return GetClient()
                    .AccessTokens
                    .GetAsync(service: _endPoint, scope: scope, refreshToken: GetToken(_refreshTokenKey))
                    .GetAwaiter()
                    .GetResult()
                    .AccessTokenProperty;
        }

        public PSRepositoryAttribute GetRepository(string repository)
        {
            return new ContainerRegistryRepositoryGetOperation(this, repository).ProcessRequest();
        }

        public IList<string> ListRepository(int? first)
        {
            return new ContainerRegistryRepositoryListOperation(this, first).ProcessRequest();
        }

        public PSDeletedRepository RemoveRepository(string repository)
        {
            return new ContainerRegistryRepositoryRemoveOperation(this, repository).ProcessRequest();
        }

        public PSRepositoryAttribute UpdateRepository(string repository, PSChangeableAttribute attribute)
        {
            new ContainerRegistryRepositoryUpdateOperation(this, repository, attribute).ProcessRequest();
            return GetRepository(repository);
        }

        public PSAcrManifest ListManifest(string repositoryName)
        {
            ContainerRepository repository = _track2Client.GetRepository(repositoryName);
            Pageable<ArtifactManifestProperties> properties = repository.GetAllManifestProperties();
            PSAcrManifest result = new PSAcrManifest();
            IEnumerable<Page<ArtifactManifestProperties>> pages = properties.AsPages();
            result.ManifestsAttributes = new List<PSManifestAttributeBase>();
            foreach (Page<ArtifactManifestProperties> page in pages)
            {
                Response httpPageResponse = page.GetRawResponse();
                dynamic pageContent = httpPageResponse.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
                result.ImageName = pageContent.ImageName;
                result.Registry = pageContent.registry;
                // Iterate over items in Manifests collection
                foreach (dynamic property in pageContent.Manifests)
                {
                    List<string> tagList = new List<string>();
                    if (property.Tags != null)
                    {
                        tagList.AddRange((List<string>)property.Tags);
                    }
                    result.ManifestsAttributes.Add(new PSManifestAttributeBase(property.Digest, property.ImageSize, property.CreatedTime, property.LastUpdateTime, 
                    property.Architecture, property.Os,property.MediaType, property.ConfigMediaType, tagList, 
                    new PSChangeableAttribute(property.ChangeableAttributes.DeleteEnabled, property.ChangeableAttributes.WriteEnabled, property.ChangeableAttributes.ListEnabled, property.ChangeableAttributes.ReadEnabled)));
                }
            }

            
            return result;
        }

        public PSManifestAttribute GetManifest(string repository, string manifest)
        {
            return new ContainerRegistryManifestGetOperation(this, repository, manifest).ProcessRequest();
        }

        public PSManifestAttribute UpdateManifest(string repository, string manifest, PSChangeableAttribute attribute)
        {
            new ContainerRegistryManifestUpdateOperation(this, repository, manifest, attribute).ProcessRequest();
            return GetManifest(repository, manifest);
        }

        public PSManifestAttribute UpdateManifestByTag(string repository, string tag, PSChangeableAttribute attribute)
        {
            PSTagAttribute tagAttribute = GetTag(repository, tag);
            return UpdateManifest(repository, tagAttribute.Attributes.Digest, attribute);
        }

        public bool RemoveManifest(string repository, string manifest)
        {
            return new ContainerRegistryManifestRemoveOperation(this, repository, manifest).ProcessRequest();
        }

        public bool RemoveManifestByTag(string repository, string tag)
        {
            PSTagAttribute tagAttribute = GetTag(repository, tag);
            return RemoveManifest(repository, tagAttribute.Attributes.Digest);
        }

        public PSTagAttribute GetTag(string repository, string tag)
        {
            return new ContainerRegistryTagGetOperation(this, repository, tag).ProcessRequest();
        }

        public PSTagList ListTag(string repository)
        {
            ContainerRepository image = _track2Client.GetRepository(repository);

            Pageable<ArtifactManifestProperties> properties = image.GetAllManifestProperties();

            return new PSTagList(properties);
        }

        public bool RemoveTag(string repository, string tag)
        {
            return new ContainerRegistryTagRemoveOperation(this, repository, tag).ProcessRequest();
        }

        public PSTagAttribute UpdateTag(string repository, string tag, PSChangeableAttribute attribute)
        {
            new ContainerRegistryTagUpdateOperation(this, repository, tag, attribute).ProcessRequest();
            return GetTag(repository, tag);
        }
    }
}