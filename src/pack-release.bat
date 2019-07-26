dotnet build-server shutdown
dotnet clean -c Release
dotnet pack -c Release
dotnet build-server shutdown
