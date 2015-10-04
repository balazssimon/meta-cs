set GAC_DIR=c:\Program Files\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools
set OSLO_DIR=c:\Program Files\Microsoft Oslo\1.0\bin

"%GAC_DIR%\gacutil.exe" /i "MetaDslx.Core.dll"
"%GAC_DIR%\gacutil.exe" /i "MetaDslx.Compiler.dll"
"%GAC_DIR%\gacutil.exe" /i "MetaDslx.VisualStudio.dll"

reg import Install32.reg
