dotnet build-server shutdown
dotnet clean -c Debug
dotnet pack -c Debug
dotnet build-server shutdown
