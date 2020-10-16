dotnet build-server shutdown
dotnet clean -c Debug
dotnet pack Main\MetaDslx.CodeAnalysis -c Debug
dotnet pack Main\MetaDslx.BuildTools -c Debug
dotnet pack Main\MetaDslx.BuildTasks -c Debug
dotnet build Main\MetaDslx.VisualStudio -c Debug
dotnet pack Languages\MetaDslx.Languages.Ecore -c Debug
dotnet pack Languages\MetaDslx.Languages.Mof -c Debug
dotnet pack Languages\MetaDslx.Languages.Uml-v2.5.1 -c Debug
dotnet build-server shutdown
