set GAC_DIR=c:\Program Files\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools

"%GAC_DIR%\gacutil.exe" /i "Antlr4.Runtime.Standard.dll"
"%GAC_DIR%\gacutil.exe" /i "MetaDslx.Core.dll"
"%GAC_DIR%\gacutil.exe" /i "MetaDslx.Compiler.Antlr4.dll"
"%GAC_DIR%\gacutil.exe" /i "MetaDslx.VisualStudio.dll"
