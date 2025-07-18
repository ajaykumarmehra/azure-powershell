// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace ADT.Models
{
    using static ADT.Runtime.Extensions;

    /// <summary>Operation status associated with the last patch request</summary>
    public partial class ReadOperationStatusProperties :
        ADT.Models.IReadOperationStatusProperties,
        ADT.Models.IReadOperationStatusPropertiesInternal
    {

        /// <summary>Internal Acessors for Status</summary>
        string ADT.Models.IReadOperationStatusPropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Operation status ID of the last patch request for this connection.</summary>
        [ADT.Origin(ADT.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Message for the operation for the last patch request for this connection.</summary>
        [ADT.Origin(ADT.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Operation status for the last patch request for this connection.</summary>
        [ADT.Origin(ADT.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Creates an new <see cref="ReadOperationStatusProperties" /> instance.</summary>
        public ReadOperationStatusProperties()
        {

        }
    }
    /// Operation status associated with the last patch request
    public partial interface IReadOperationStatusProperties :
        ADT.Runtime.IJsonSerializable
    {
        /// <summary>Operation status ID of the last patch request for this connection.</summary>
        [ADT.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Operation status ID of the last patch request for this connection.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Message for the operation for the last patch request for this connection.</summary>
        [ADT.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Message for the operation for the last patch request for this connection.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Operation status for the last patch request for this connection.</summary>
        [ADT.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Operation status for the last patch request for this connection.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::ADT.PSArgumentCompleterAttribute("Failed", "Succeeded")]
        string Status { get;  }

    }
    /// Operation status associated with the last patch request
    internal partial interface IReadOperationStatusPropertiesInternal

    {
        /// <summary>Operation status ID of the last patch request for this connection.</summary>
        string Id { get; set; }
        /// <summary>Message for the operation for the last patch request for this connection.</summary>
        string Message { get; set; }
        /// <summary>Operation status for the last patch request for this connection.</summary>
        [global::ADT.PSArgumentCompleterAttribute("Failed", "Succeeded")]
        string Status { get; set; }

    }
}