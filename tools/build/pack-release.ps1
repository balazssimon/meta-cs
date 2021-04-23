Push-Location ..\..\src
dotnet build-server shutdown
dotnet clean -c Release
dotnet pack Main\MetaDslx.CodeAnalysis -c Release
dotnet pack Main\MetaDslx.BuildTools -c Release
dotnet pack Main\MetaDslx.BuildTasks -c Release
dotnet pack Main\MetaDslx.CodeAnalysis.Analyzers -c Release
# dotnet build Main\MetaDslx.VisualStudio -c Release
dotnet pack Languages\MetaDslx.Languages.Ecore -c Release
dotnet pack Languages\MetaDslx.Languages.Mof -c Release
dotnet pack Languages\MetaDslx.Languages.Uml-v2.5.1 -c Release
dotnet build-server shutdown
Pop-Location
