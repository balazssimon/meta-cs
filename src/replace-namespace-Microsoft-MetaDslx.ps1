$configFiles = Get-ChildItem . *.cs -rec
foreach ($file in $configFiles)
{
  if (Get-Content $file.PSPath | Select-String -Pattern "Microsoft\.CodeAnalysis")
  {
    (Get-Content $file.PSPath) |
    Foreach-Object { $_ -replace "Microsoft\.CodeAnalysis", "MetaDslx.CodeAnalysis" } |
    Set-Content $file.PSPath
  }
  if (Get-Content $file.PSPath | Select-String -Pattern "Microsoft\.Cci")
  {
    (Get-Content $file.PSPath) |
    Foreach-Object { $_ -replace "Microsoft\.Cci", "MetaDslx.Cci" } |
    Set-Content $file.PSPath
  }  
}

