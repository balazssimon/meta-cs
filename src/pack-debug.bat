cd Main\MetaDslx.BuildTasks
dotnet pack --no-build -c Debug
cd ..\MetaDslx.CodeAnalysis
dotnet pack --no-build -c Debug
cd ..\..
