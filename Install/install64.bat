set GAC_DIR=c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7 Tools

"%GAC_DIR%\gacutil.exe" /i "Antlr4.Runtime.Standard.dll"
"%GAC_DIR%\gacutil.exe" /i "MetaDslx.Core.dll"
"%GAC_DIR%\gacutil.exe" /i "MetaDslx.Compiler.Antlr4.dll"
"%GAC_DIR%\gacutil.exe" /i "MetaDslx.VisualStudio.dll"
