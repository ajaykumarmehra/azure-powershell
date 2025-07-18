// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Extensions;

    /// <summary>Product details of a type of resource.</summary>
    public partial class Catalog :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalog,
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal
    {

        /// <summary>Backing field for <see cref="BillingPlan" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogBillingPlans _billingPlan;

        /// <summary>The billing plan options available for this sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogBillingPlans BillingPlan { get => (this._billingPlan = this._billingPlan ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.CatalogBillingPlans()); set => this._billingPlan = value; }

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuCapability> _capability;

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuCapability> Capability { get => this._capability; }

        /// <summary>Backing field for <see cref="Locations" /> property.</summary>
        private System.Collections.Generic.List<string> _locations;

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 3)]
        public System.Collections.Generic.List<string> Locations { get => this._locations; }

        /// <summary>Internal Acessors for Capability</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuCapability> Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.Capability { get => this._capability; set { {_capability = value;} } }

        /// <summary>Internal Acessors for Locations</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.Locations { get => this._locations; set { {_locations = value;} } }

        /// <summary>Internal Acessors for Msrp</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrp Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.Msrp { get => (this._msrp = this._msrp ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.CatalogMsrp()); set { {_msrp = value;} } }

        /// <summary>Internal Acessors for MsrpP1Y</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.MsrpP1Y { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P1Y; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P1Y = value ?? null /* model class */; }

        /// <summary>Internal Acessors for MsrpP3Y</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.MsrpP3Y { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P3Y; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P3Y = value ?? null /* model class */; }

        /// <summary>Internal Acessors for MsrpP5Y</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.MsrpP5Y { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P5Y; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P5Y = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for ResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.ResourceType { get => this._resourceType; set { {_resourceType = value;} } }

        /// <summary>Internal Acessors for Restrictions</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuRestriction> Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.Restrictions { get => this._restrictions; set { {_restrictions = value;} } }

        /// <summary>Internal Acessors for Size</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.Size { get => this._size; set { {_size = value;} } }

        /// <summary>Internal Acessors for SkuProperties</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuProperty> Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.SkuProperties { get => this._skuProperties; set { {_skuProperties = value;} } }

        /// <summary>Internal Acessors for Terms</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.Terms { get => this._terms; set { {_terms = value;} } }

        /// <summary>Internal Acessors for Tier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogInternal.Tier { get => this._tier; set { {_tier = value;} } }

        /// <summary>Backing field for <see cref="Msrp" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrp _msrp;

        /// <summary>Pricing information about the sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrp Msrp { get => (this._msrp = this._msrp ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.CatalogMsrp()); }

        /// <summary>Amount in pricing currency. Tax not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP1Y { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P1Y; }

        /// <summary>Amount in pricing currency. Tax not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP3Y { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P3Y; }

        /// <summary>Amount in pricing currency. Tax not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP5Y { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrpInternal)Msrp).P5Y; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 2)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>The type of resource the sku applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 0)]
        public string ResourceType { get => this._resourceType; }

        /// <summary>Backing field for <see cref="Restrictions" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuRestriction> _restrictions;

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuRestriction> Restrictions { get => this._restrictions; }

        /// <summary>Backing field for <see cref="Size" /> property.</summary>
        private string _size;

        /// <summary>The size of this sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public string Size { get => this._size; }

        /// <summary>Backing field for <see cref="SkuProperties" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuProperty> _skuProperties;

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuProperty> SkuProperties { get => this._skuProperties; }

        /// <summary>Backing field for <see cref="Terms" /> property.</summary>
        private System.Collections.Generic.List<string> _terms;

        /// <summary>Available reservation terms for this resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 1)]
        public System.Collections.Generic.List<string> Terms { get => this._terms; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>The tier of this sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public string Tier { get => this._tier; }

        /// <summary>Creates an new <see cref="Catalog" /> instance.</summary>
        public Catalog()
        {

        }
    }
    /// Product details of a type of resource.
    public partial interface ICatalog :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.IJsonSerializable
    {
        /// <summary>The billing plan options available for this sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The billing plan options available for this sku.",
        SerializedName = @"billingPlans",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogBillingPlans) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogBillingPlans BillingPlan { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuCapability) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuCapability> Capability { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Locations { get;  }
        /// <summary>Amount in pricing currency. Tax not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Amount in pricing currency. Tax not included.",
        SerializedName = @"p1Y",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP1Y { get;  }
        /// <summary>Amount in pricing currency. Tax not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Amount in pricing currency. Tax not included.",
        SerializedName = @"p3Y",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP3Y { get;  }
        /// <summary>Amount in pricing currency. Tax not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Amount in pricing currency. Tax not included.",
        SerializedName = @"p5Y",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP5Y { get;  }
        /// <summary>The name of sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The name of sku",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The type of resource the sku applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The type of resource the sku applies to.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"restrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuRestriction) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuRestriction> Restrictions { get;  }
        /// <summary>The size of this sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The size of this sku",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(string) })]
        string Size { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"skuProperties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuProperty) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuProperty> SkuProperties { get;  }
        /// <summary>Available reservation terms for this resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Available reservation terms for this resource",
        SerializedName = @"terms",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Reservations.PSArgumentCompleterAttribute("P1Y", "P3Y", "P5Y")]
        System.Collections.Generic.List<string> Terms { get;  }
        /// <summary>The tier of this sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The tier of this sku",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get;  }

    }
    /// Product details of a type of resource.
    internal partial interface ICatalogInternal

    {
        /// <summary>The billing plan options available for this sku.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogBillingPlans BillingPlan { get; set; }

        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuCapability> Capability { get; set; }

        System.Collections.Generic.List<string> Locations { get; set; }
        /// <summary>Pricing information about the sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ICatalogMsrp Msrp { get; set; }
        /// <summary>Amount in pricing currency. Tax not included.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP1Y { get; set; }
        /// <summary>Amount in pricing currency. Tax not included.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP3Y { get; set; }
        /// <summary>Amount in pricing currency. Tax not included.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MsrpP5Y { get; set; }
        /// <summary>The name of sku</summary>
        string Name { get; set; }
        /// <summary>The type of resource the sku applies to.</summary>
        string ResourceType { get; set; }

        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuRestriction> Restrictions { get; set; }
        /// <summary>The size of this sku</summary>
        string Size { get; set; }

        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.ISkuProperty> SkuProperties { get; set; }
        /// <summary>Available reservation terms for this resource</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Reservations.PSArgumentCompleterAttribute("P1Y", "P3Y", "P5Y")]
        System.Collections.Generic.List<string> Terms { get; set; }
        /// <summary>The tier of this sku</summary>
        string Tier { get; set; }

    }
}