$source = "..\..\..\roslyn"
$target = "..\..\src\Roslyn"

$versionsProps = [xml](Get-Content "$source\eng\Versions.props")

Remove-Item "$target" -Recurse -Force
New-Item -Name "$target" -ItemType "directory"
New-Item -Path "$target" -Name "MetaDslx.CodeAnalysis.Common" -ItemType "directory"
New-Item -Path "$target" -Name "MetaDslx.CodeAnalysis.CSharp" -ItemType "directory"

$genCode = "$source\eng\generate-compiler-code.ps1"
(Get-Content $genCode) | Foreach-Object { $_ -replace "language \-ne ""CSharp""", "true" } | Set-Content $genCode

. $genCode

Copy-Item -Path "$source\License.txt" -Destination "$target"

Copy-Item -Path "$source\eng\Versions.props" -Destination "$target"

Copy-Item -Path "$source\src\Compilers\Core\Portable\*" -Destination "$target\MetaDslx.CodeAnalysis.Common" -Recurse
Rename-Item -Path "$target\MetaDslx.CodeAnalysis.Common\Microsoft.CodeAnalysis.csproj" -NewName "MetaDslx.CodeAnalysis.Common.csproj"

Copy-Item -Path "$source\src\Compilers\Core\CodeAnalysisRules.ruleset" -Destination "$target" -Recurse

Copy-Item -Path "$source\src\Compilers\Core\AnalyzerDriver" -Destination "$target" -Recurse

Copy-Item -Path "$source\src\Dependencies\CodeAnalysis.Debugging" -Destination "$target" -Recurse

Copy-Item -Path "$source\src\Dependencies\PooledObjects" -Destination "$target" -Recurse

Copy-Item -Path "$source\src\Dependencies\Collections" -Destination "$target" -Recurse

Copy-Item -Path "$source\src\Dependencies\Collections\Internal\Strings.resx" -Destination "$target\MetaDslx.CodeAnalysis.Common"
Rename-Item -Path "$target\MetaDslx.CodeAnalysis.Common\Strings.resx" -NewName "SR.resx"

Copy-Item -Path "$source\src\Compilers\CSharp\Portable\*" -Destination "$target\MetaDslx.CodeAnalysis.CSharp" -Recurse
Rename-Item -Path "$target\MetaDslx.CodeAnalysis.CSharp\Microsoft.CodeAnalysis.CSharp.csproj" -NewName "MetaDslx.CodeAnalysis.CSharp.csproj"

Copy-Item -Path "$source\src\Compilers\CSharp\CSharpAnalyzerDriver" -Destination "$target" -Recurse

Copy-Item -Path "$source\src\Compilers\CSharp\CSharpCodeAnalysisRules.ruleset" -Destination "$target" -Recurse


$commonProj = "$target\MetaDslx.CodeAnalysis.Common\MetaDslx.CodeAnalysis.Common.csproj"

(Get-Content $commonProj) | Foreach-Object { $_ -replace "<Project Sdk=""Microsoft\.NET\.Sdk"">", "<Project Sdk=""Microsoft.NET.Sdk"">`n  <Import Project=""..\Versions.props"" />`n  <Import Project=""..\..\Versions.props"" />" } | Set-Content $commonProj

(Get-Content $commonProj) | Foreach-Object { $_ -replace "<TargetFrameworks>netcoreapp3\.1;netstandard2\.0</TargetFrameworks>", "<TargetFramework>netstandard2.0</TargetFramework>" } | Set-Content $commonProj

(Get-Content $commonProj) | Foreach-Object { $_ -replace "\.\.\\\.\.\\\.\.\\Dependencies", ".." } | Set-Content $commonProj

(Get-Content $commonProj) | Foreach-Object { $_ -replace "<InternalsVisibleTo Include=""Microsoft.CodeAnalysis.CSharp"" />", "<InternalsVisibleTo Include=""MetaDslx.CodeAnalysis.CSharp"" />`n    <InternalsVisibleTo Include=""MetaDslx.CodeAnalysis.Meta"" />`n    <InternalsVisibleTo Include=""MetaDslx.CodeAnalysis.Antlr4"" />" } | Set-Content $commonProj

(Get-Content $commonProj) | Foreach-Object { $_ -replace "<OutputType>Library</OutputType>", "<OutputType>Library</OutputType>`n    <Nullable>enable</Nullable>`n    <LangVersion>preview</LangVersion>" } | Set-Content $commonProj

(Get-Content $commonProj) | Foreach-Object { $_ -replace "<EmbeddedResource Update=""CodeAnalysisResources.resx"" GenerateSource=""true"" />", "<EmbeddedResource Update=""CodeAnalysisResources.resx"" GenerateSource=""true""><Generator>PublicResXFileCodeGenerator</Generator><SubType>Designer</SubType></EmbeddedResource><EmbeddedResource Update=""SR.resx"" GenerateSource=""true"" ClassName=""Microsoft.CodeAnalysis.Collections.Internal.SR""><Generator>PublicResXFileCodeGenerator</Generator><SubType>Designer</SubType><CustomToolNamespace>Microsoft.CodeAnalysis.Collections.Internal</CustomToolNamespace></EmbeddedResource>" } | Set-Content $commonProj



$csharpProj = "$target\MetaDslx.CodeAnalysis.CSharp\MetaDslx.CodeAnalysis.CSharp.csproj"

(Get-Content $csharpProj) | Foreach-Object { $_ -replace "<Project Sdk=""Microsoft\.NET\.Sdk"">", "<Project Sdk=""Microsoft.NET.Sdk"">`n  <Import Project=""..\Versions.props"" />`n  <Import Project=""..\..\Versions.props"" />" } | Set-Content $csharpProj

(Get-Content $csharpProj) | Foreach-Object { $_ -replace "<TargetFrameworks>netcoreapp3\.1;netstandard2\.0</TargetFrameworks>", "<TargetFramework>netstandard2.0</TargetFramework>" } | Set-Content $csharpProj

(Get-Content $csharpProj) | Foreach-Object { $_ -replace "\.\.\\\.\.\\Core\\Portable\\Microsoft.CodeAnalysis.csproj", "..\MetaDslx.CodeAnalysis.Common\MetaDslx.CodeAnalysis.Common.csproj" } | Set-Content $csharpProj

(Get-Content $csharpProj) | Foreach-Object { $_ -replace "<InternalsVisibleTo Include=""csc"" />", "<InternalsVisibleTo Include=""csc"" />`n    <InternalsVisibleTo Include=""MetaDslx.CodeAnalysis.Meta"" />" } | Set-Content $csharpProj

(Get-Content $csharpProj) | Foreach-Object { $_ -replace "\.\.\\\.\.\\\.\.\\Tools\\Source\\CompilerGeneratorTools", "..\CompilerGeneratorTools" } | Set-Content $csharpProj

(Get-Content $csharpProj) | Foreach-Object { $_ -replace "<OutputType>Library</OutputType>", "<OutputType>Library</OutputType>`n    <Nullable>enable</Nullable>`n    <LangVersion>preview</LangVersion>" } | Set-Content $csharpProj

(Get-Content $csharpProj) | Foreach-Object { $_ -replace "<EmbeddedResource Update=""CSharpResources.resx"" GenerateSource=""true"" />", "<EmbeddedResource Update=""CSharpResources.resx"" GenerateSource=""true""><Generator>PublicResXFileCodeGenerator</Generator><SubType>Designer</SubType></EmbeddedResource>" } | Set-Content $csharpProj
