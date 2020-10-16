dotnet build-server shutdown
dotnet clean -c Release
dotnet pack Main\MetaDslx.CodeAnalysis -c Release
dotnet pack Main\MetaDslx.BuildTools -c Release
dotnet pack Main\MetaDslx.BuildTasks -c Release
dotnet build-server shutdown
