set GAC_DIR=c:\Program Files\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7 Tools

"%GAC_DIR%\gacutil.exe" /u "Antlr4.Runtime.Standard"
"%GAC_DIR%\gacutil.exe" /u "MetaDslx.Core"
"%GAC_DIR%\gacutil.exe" /u "MetaDslx.Compiler.Antlr4"
"%GAC_DIR%\gacutil.exe" /u "MetaDslx.VisualStudio"
