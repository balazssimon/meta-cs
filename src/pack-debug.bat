dotnet build-server shutdown
dotnet clean -c Debug
dotnet pack Main\MetaDslx.CodeAnalysis -c Debug
dotnet pack Main\MetaDslx.BuildTools -c Debug
dotnet pack Main\MetaDslx.BuildTasks -c Debug
dotnet build-server shutdown
