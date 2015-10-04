set GAC_DIR=c:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools
set OSLO_DIR=c:\Program Files (x86)\Microsoft Oslo\1.0\bin

reg import Uninstall64.reg

"%GAC_DIR%\gacutil.exe" /u "MetaDslx.Core"
"%GAC_DIR%\gacutil.exe" /u "MetaDslx.Compiler"
"%GAC_DIR%\gacutil.exe" /u "MetaDslx.VisualStudio"
