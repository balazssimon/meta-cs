param([Parameter(Mandatory=$true)][string]$version,[Parameter(Mandatory=$true)][string]$bootstrapVersion,[Parameter(Mandatory=$true)][string]$langVersion)
(Get-Content "Versions.props-template").replace('<VERSION>', $version).replace('<BOOTSTRAP_VERSION>', $bootstrapVersion).replace('<LANG_VERSION>', $langVersion) | Set-Content "Versions.props"
(Get-Content "Main\MetaDslx.VisualStudio\source.extension.vsixmanifest-template").replace('<VERSION>', $version) | Set-Content "Main\MetaDslx.VisualStudio\source.extension.vsixmanifest"
