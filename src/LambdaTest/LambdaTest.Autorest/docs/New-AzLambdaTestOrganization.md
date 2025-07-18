---
external help file:
Module Name: Az.LambdaTest
online version: https://learn.microsoft.com/powershell/module/az.lambdatest/new-azlambdatestorganization
schema: 2.0.0
---

# New-AzLambdaTestOrganization

## SYNOPSIS
Create a OrganizationResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzLambdaTestOrganization -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-EnableSystemAssignedIdentity] [-MarketplaceSubscriptionId <String>]
 [-OfferDetailOfferId <String>] [-OfferDetailPlanId <String>] [-OfferDetailPlanName <String>]
 [-OfferDetailPublisherId <String>] [-OfferDetailTermId <String>] [-OfferDetailTermUnit <String>]
 [-PartnerPropertyLicensesSubscribed <Int32>] [-SingleSignOnPropertyAadDomain <String[]>]
 [-SingleSignOnPropertyEnterpriseAppId <String>] [-SingleSignOnPropertyState <String>]
 [-SingleSignOnPropertyType <String>] [-SingleSignOnPropertyUrl <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-UserEmailAddress <String>] [-UserFirstName <String>]
 [-UserLastName <String>] [-UserPhoneNumber <String>] [-UserUpn <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzLambdaTestOrganization -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzLambdaTestOrganization -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a OrganizationResource

## EXAMPLES

### Example 1:  Create a new Organization in a Resource Group with SSO
```powershell
New-AzLambdaTestOrganization -Name "test-cli-instance-3" -Location "Central US EUAP" -ResourceGroupName "abdul-test" -PartnerPropertyLicensesSubscribed 3 -SubscriptionId "fc35d936-3b89-41f8-8110-a24b56826c37" -MarketplaceSubscriptionId  "fc35d936-3b89-41f8-8110-a24b56826c37" -OfferDetailOfferId "lambdatest_liftr_testing" -OfferDetailPlanId "testing" -OfferDetailPlanName "testing_liftr" -OfferDetailTermUnit "P1Y" -OfferDetailPublisherId "lambdatestinc1584019832435" -OfferDetailTermId "o73usof6rkyy"  -SingleSignOnPropertyEnterpriseAppId "0b9873df-1629-4036-9360-5f2f65c0a0d3" -SingleSignOnPropertyAadDomain @("MicrosoftCustomerLed.onmicrosoft.com") -SingleSignOnPropertyType "Saml" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "aggarwalsw@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "aggarwalsw@microsoft.com"
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/abdul-test/providers/LambdaTest.HyperExecute/organizations/test-cli-instance-3
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : Central US EUAP
MarketplaceSubscriptionId           : 53c4986d-938d-432a-d5cb-292607600bf9
MarketplaceSubscriptionStatus       : Subscribed
Name                                : test-cli-instance-3
OfferDetailOfferId                  : lambdatest_liftr_testing
OfferDetailPlanId                   : testing
OfferDetailPlanName                 : testing_liftr
OfferDetailPublisherId              : lambdatestinc1584019832435
OfferDetailTermId                   : o73usof6rkyy
OfferDetailTermUnit                 : P1Y
PartnerPropertyLicensesSubscribed   : 3
ProvisioningState                   : Succeeded
ResourceGroupName                   : abdul-test
SingleSignOnPropertyAadDomain       : {MicrosoftCustomerLed.onmicrosoft.com}
SingleSignOnPropertyEnterpriseAppId : 0b9873df-1629-4036-9360-5f2f65c0a0d3
SingleSignOnPropertyState           :
SingleSignOnPropertyType            : Saml
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 4/11/2025 11:18:50 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 4/11/2025 11:18:50 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : lambdatest.hyperexecute/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command will create a new LambdaTest Resource

### Example 1:  Create a new Organization in a Resource Group without SSO
```powershell
New-AzLambdaTestOrganization -Name "test-cli-instance-2" -PartnerPropertyLicensesSubscribed 3 -Location "Central US EUAP" -ResourceGroupName "abdul-test" -SubscriptionId "fc35d936-3b89-41f8-8110-a24b56826c37" -MarketplaceSubscriptionId  "fc35d936-3b89-41f8-8110-a24b56826c37" -OfferDetailOfferId "lambdatest_liftr_testing" -OfferDetailPlanId "testing" -OfferDetailPlanName "testing_liftr" -OfferDetailTermUnit "P1Y" -OfferDetailPublisherId "lambdatestinc1584019832435" -OfferDetailTermId "o73usof6rkyy" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "aggarwalsw@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "aggarwalsw@microsoft.com"
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/abdul-test/providers/LambdaTest.HyperExecute/organizations/test-cli-instance-2
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : Central US EUAP
MarketplaceSubscriptionId           : eb739d37-fe4c-4b00-cbd2-0f18663d624b
MarketplaceSubscriptionStatus       : Subscribed
Name                                : test-cli-instance-2
OfferDetailOfferId                  : lambdatest_liftr_testing
OfferDetailPlanId                   : testing
OfferDetailPlanName                 : testing_liftr
OfferDetailPublisherId              : lambdatestinc1584019832435
OfferDetailTermId                   : o73usof6rkyy
OfferDetailTermUnit                 : P1Y
PartnerPropertyLicensesSubscribed   : 3
ProvisioningState                   : Succeeded
ResourceGroupName                   : abdul-test
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 4/11/2025 11:03:53 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 4/11/2025 11:03:53 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : lambdatest.hyperexecute/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command will create a new LambdaTest Resource without SSO

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceSubscriptionId
Azure subscription id for the the marketplace offer is purchased from

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Organization resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Organizationname

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailOfferId
Offer Id for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPlanId
Plan Id for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPlanName
Plan Name for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPublisherId
Publisher Id for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailTermId
Plan Display Name for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailTermUnit
Plan Display Name for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerPropertyLicensesSubscribed
The number of licenses subscribed

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertyAadDomain
List of AAD domains fetched from Microsoft Graph for user.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertyEnterpriseAppId
AAD enterprise application Id used to setup SSO

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertyState
State of the Single Sign On for the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertyType
Type of Single Sign-On mechanism being used

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertyUrl
URL for SSO to be used by the partner to redirect the user to their system

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEmailAddress
Email address of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserFirstName
First name of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserLastName
Last name of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPhoneNumber
User's phone number

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserUpn
User's principal name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LambdaTest.Models.IOrganizationResource

## NOTES

## RELATED LINKS

