﻿# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Negative test. Get gateway from an non-existing empty group.
#>
function Test-GetNonExistingDataFactoryGateway
{	
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force
    New-AzDataFactory -Name $dfname -Location $rglocation -ResourceGroup $rgname  -Force
    
    # Test
    Assert-ThrowsContains { Get-AzDataFactoryGateway -ResourceGroupName $rgname -DataFactoryName $dfname -Name "gwname"  } "GatewayNotFound"    
}

<#
.SYNOPSIS
Create a gateway and then do a Get to compare the result are identical.
Delete the created gateway after test finishes.
#>
function Test-DataFactoryGateway
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        New-AzDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $gwname = "foo"
        $description = "description"
   
        $actual = New-AzDataFactoryGateway -ResourceGroupName $rgname -DataFactoryName $dfname -Name $gwname
        $expected = Get-AzDataFactoryGateway -ResourceGroupName $rgname -DataFactoryName $dfname -Name $gwname
        Assert-AreEqual $actual.Name $expected.Name
        Assert-NotNull $actual.Key

        $key = New-AzDataFactoryGatewayKey -ResourceGroupName $rgname -DataFactoryName $dfname -GatewayName $gwname
        Assert-NotNull $key
        Assert-NotNull $key.Gatewaykey

        $result = Set-AzDataFactoryGateway -ResourceGroupName $rgname -DataFactoryName $dfname -Name $gwname -Description $description
        Assert-AreEqual $result.Description $description

        Remove-AzDataFactoryGateway -ResourceGroupName $rgname -DataFactoryName $dfname -Name $gwname -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Create a gateway and then try to get auth keys and new auth keys.
Delete the created gateway after test finishes.
#>
function Test-DataFactoryGatewayAuthKey
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        New-AzDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $gwname = "foo"
        $description = "description"
   
        $actual = New-AzDataFactoryGateway -ResourceGroupName $rgname -DataFactoryName $dfname -Name $gwname
        $expected = Get-AzDataFactoryGateway -ResourceGroupName $rgname -DataFactoryName $dfname -Name $gwname
        Assert-AreEqual $actual.Name $expected.Name
        Assert-NotNull $actual.Key

        $key = Get-AzDataFactoryGatewayAuthKey -ResourceGroupName $rgname -DataFactoryName $dfname -GatewayName $gwname
        Assert-NotNull $key
        Assert-NotNull $key.Key1
        Assert-NotNull $key.Key2

        $keyName = 'key2'
        $newKey = New-AzDataFactoryGatewayAuthKey -ResourceGroupName $rgname -DataFactoryName $dfname -GatewayName $gwname -KeyName $keyName
        Assert-NotNull $key.Key2
        Assert-AreNotEqual $key.Key2 $newKey.Key2

        Remove-AzDataFactoryGateway -ResourceGroupName $rgname -DataFactoryName $dfname -Name $gwname -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Use the datafactory parameter to create a gateway and then do a Get to compare the result are identical.
Delete the created gateway after test finishes.
#>
function Test-DataFactoryGatewayWithDataFactoryParameter
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $datafactory = New-AzDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $gwname = "foo"
        $description = "description"
   
        $actual = New-AzDataFactoryGateway -DataFactory $datafactory -Name $gwname
        $expected = Get-AzDataFactoryGateway -DataFactory $datafactory -Name $gwname
        Assert-AreEqual $actual.Name $expected.Name

        $key = New-AzDataFactoryGatewayKey -DataFactory $datafactory -GatewayName $gwname
        Assert-NotNull $key
        Assert-NotNull $key.Gatewaykey

        $result = Set-AzDataFactoryGateway -DataFactory $datafactory -Name $gwname -Description $description
        Assert-AreEqual $result.Description $description

        Remove-AzDataFactoryGateway -DataFactory $datafactory -Name $gwname -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}