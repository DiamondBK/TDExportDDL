# TDExportDDL
Export DDL of Teradata tables, views, procedures & functions to text file. 

App used Teradata Client C# https://www.nuget.org/packages/Teradata.Client.Provider/

## Settings:
* Encoding - by default used UTF8
* AuthenticationMechanism - by default used LDAP or TD2 
* FileName - export filename, file export to app directory with this name
* ConnTimeout - Teradata connetcion timeout
* DataSource - Teradata IP or DNS-name
* Login - Teradata login
* Password - Teradata password
* SelectObjSQL - selected database objects to export. Selected fields doesn't change

**All setting saved in XML-file TDExportDDL.exe.config**

Execute app:
1. Config TDExportDDL.exe.config with your credentials
2. Run TDExportDDL\bin\Debug
