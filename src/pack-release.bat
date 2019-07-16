cd Main\MetaDslx.BuildTasks
dotnet pack --no-build -c Release
cd ..\MetaDslx.CodeAnalysis
dotnet pack --no-build -c Release
cd ..\..
