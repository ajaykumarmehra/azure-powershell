if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageActionTasksReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageActionTasksReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageActionTasksReport' {
    It 'List' {
        {
            $report = Get-AzStorageActionTasksReport -ResourceGroupName $env.resourceGroup -StorageTaskName $env.assignmentTask
            $report.count | Should -BeGreaterOrEqual 0 # for the assignment which just created , there will be no report.
        } | Should -Not -Throw
    }
}
