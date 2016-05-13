set GAC_DIR=c:\Program Files\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools

"%GAC_DIR%\gacutil.exe" /u "Antlr4.Runtime"
"%GAC_DIR%\gacutil.exe" /u "MetaDslx.Core"
"%GAC_DIR%\gacutil.exe" /u "MetaDslx.Compiler"
"%GAC_DIR%\gacutil.exe" /u "MetaDslx.VisualStudio"
