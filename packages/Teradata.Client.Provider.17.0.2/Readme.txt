Copyright (c) 2005-2019 Teradata Corporation. All rights reserved.

--------------------------------------------------------------------------------
                     .NET Data Provider for Teradata               
                              Version 17.0.2
--------------------------------------------------------------------------------

********************************************************************************
****  NOTE: The Data Provider requires .NET FRAMEWORK 4.5.2 or higher,      ****
****        or .NET CORE 2.0 or higher.                                     ****
****        It does not support .NET Framework 3.5, 4.0, 4.5 or 4.5.1       ****
********************************************************************************

********************************************************************************
****  NOTE: The connection string attribute UseEnhancedSchemaTable has      ****
****        been deprecated. It may be removed in a future release.         ****
********************************************************************************


RELEASE NOTES


Content:

1.0 Overview
1.1   New Features
1.2   Problems Fixed
2.0 Teradata Product Dependencies
3.0 Operating Environments
4.0 Installation
4.1   Installation Procedure
4.2   Installation Options
5.0 Uninstall
6.0 Restrictions and Known Issues


1.0 Overview
============
The .NET Data Provider for Teradata is an implementation of the Microsoft 
ADO.NET specification. It provides direct access to the Teradata Vantage 
and integrates with the DataSet. .NET Applications use the Data Provider
to load data into or retrieve data from the Advanced SQL Engine.

The .NET Data Provider for Teradata is available for download as a NuGet 
package (from https://www.nuget.org/packages/Teradata.Client.Provider) and a
MSI package (from https://downloads.teradata.com).

The MSI package installs the .NET Data Provider for Teradata (ADO.NET) and 
the Entity Framework Provider for Teradata with support for the Entity Data 
Model (EDM), LINQ-to-Entities and Entity-SQL. The Entity Framework Provider 
for Teradata supports ADO.NET Entity Framework 3.5 SP1 features. It does not
support ADO.NET Entity Framework 4.0 (or higher) features and it is not 
compatible with Entity Framework 6.x or Entity Framework Core. The assemblies
included in the MSI package are .NET Framework assemblies. The package does 
not include the assemblies for .NET Core.

The NuGet package contains the Data Provider for .NET Framework and .NET Core.
This package does not include the Entity Framework Provider or the Entity 
Framework Core Provider. 

The Entity Framework Core Provider for Teradata is available as a NuGet package
(from https://www.nuget.org/packages/Teradata.EntityFrameworkCore).

See following links for additional information:
 a) ADO.NET Overview: 
      https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-overview

 b) Entity Framework:
      https://docs.microsoft.com/en-us/ef/


1.1 New Features
================
  a) Entity Framework Core support: The Entity Framework Core Provider
     NuGet package is available for download from 
     https://www.nuget.org/packages/Teradata.EntityFrameworkCore .

  b) The Data Provider closes idle connections, across all pools, before the
     process exits on .NET Core. .NET Core, unlike .NET Framework, does not 
     invoke Finalizers during Process-Exit. Therefore a new scheme had to be 
     introduced to close the connections to the Advanced SQL Engine on .NET 
     Core.


1.2 Problems Fixed
==================


2.0 Teradata Product Dependencies
=================================
The Data Provider communicates directly to the Advanced SQL Engine. There are no
dependencies on any of the Teradata Tools and Utilities products.


3.0 Operating Environments
===========================
The following operating environments are supported:

Client Operating Systems:
    Microsoft Windows 8.1             x86 & x64 Editions
    Microsoft Windows 10              x86 & x64 Editions
    Microsoft Windows Server 2012 
    Microsoft Windows Server 2012 R2 
    Microsoft Windows Server 2016
    Microsoft Windows Server 2019

Client Operating Environment:
    Microsoft .NET Framework 4.5.2    x86 & x64 (CLR 4.0)
    Microsoft .NET Framework 4.6.x    x86 & x64 (CLR 4.0)
    Microsoft .NET Framework 4.7.x    x86 & x64 (CLR 4.0)
    Microsoft .NET Framework 4.8.x    x86 & x64 (CLR 4.0)
    Microsoft .NET Core 2.1           Windows, Linux, macOS
    Microsoft .NET Core 2.2           Windows, Linux, macOS
    Microsoft .NET Core 3.0           Windows, Linux, macOS
    Microsoft .NET Core 3.1           Windows, Linux, macOS

                    
Microsoft Visual Studio:
    2015 Professional Edition or higher edition
    2017 Professional Edition or higher edition
    2019 Professional Edition or higher edition

The .NET Data Provider for Teradata and the Entity Framework Provider 
support the following Teradata Database/Advanced SQL Engine Releases:
    15.10
    16.10
    16.20
    17.00
        
The Entity Framework Provider for Teradata supports ADO.NET Entity 
Framework 3.5 SP1 features. It does not support ADO.NET Entity Framework 4.0 
(or higher) features. The Entity Framework Provider is not compatible with 
the Entity Framework 6.x or Entity Framework Core. 

The .NET Data Provider for Teradata architecture is MSIL. Therefore a 
single installation supports 32-bit and 64-bit applications.


4.0 Installation
================
For step-by-step Installation Instructions refer to "Teradata Tools and 
Utilities Installation Guide for Microsoft Windows" document on 
http://www.info.teradata.com. Navigate to General Search and use 
Publication Product ID 2407 to locate the document.


4.1 Installation Procedure
==========================
The .NET Data Provider for Teradata is dependent on the Microsoft .NET Framework
version 4.5.2 which can be downloaded from: 
    https://www.microsoft.com/net/download

Alternatively you may use the .NET Core implementation of the provider. This is
dependent of Microsoft .NET Core version 2.0 which can be downloaded from:
    https://www.microsoft.com/net/download

*** RECOMMENDATION: Uninstall previous version(s) of the .NET Data Provider
for Teradata if there is no application dependency.

In the following instructions, the "installation executable" refers to the 
the file:

     tdnetdp__windows_indep.17.00.02.00.exe

NOTE:
      The name of the installation package obtained when performing 
      a Network Install from the TTU media is setup.exe.   


Any reference to the .NET Data Provider for Teradata or the Teradata Provider
refers to

     .NET Data Provider for Teradata 17.00.02.00

Follow this procedure to install the Data Provider:

   1- Run installation executable.   (See NOTE below.)
   
   2- In the Choose Setup Language dialog, select the Language you want to use
      and click OK.
      
   3- When the Welcome screen appears, click Next>.
   
   4- In the Choose Destination folder dialog, choose a destination folder 
      and click Next>.

   5- In the Setup Type dialog, choose either complete or custom setup type
      and click Next>. Choosing 'complete' setup type would select all the 
      features for installation whereas choosing 'custom' setup type allows 
      the user to select features for installation.

   6- In the Custom setup dialog, click Next> to accept the defaults. 
      The "Integrate the Data Provider with Microsoft Visual Studio(s)" feature 
      is visible when any of the Microsoft Visual Studio versions supported by
      this version of the .NET Data Provider for Teradata is installed. 
      
   7- In the Ready to install dialog, click on 'Install' to start the package 
      installation. If Visual studio features are selected then this step will 
      take several minutes to complete.      
 
   8- In the InstallShield Wizard Complete screen, click Finish.   
   

4.2 Installation options
=========================
Interactive install:
   Double click installation executable to start the installation or Run 
   the installation executable from command prompt and go through the dialog 
   sequence.

Silent install:
  From command prompt:   
    To install the full package specify the installation executable with the
    following default default options:

       /s /v"/qn"   

    To install to a user defined location run specify the following options:

       /s /v"/qn INSTALLDIR=c:\test"

    To install the package without Visual Studio features use the options:

       /s /v"/qn VSFEATURE=0"    

NOTE:
   The self-extracting installation package, downloaded from the web
   (downloads.teradata.com), is not compatible with the SYSTEM account.
   The SETUP.EXE installation package, available on the Teradata Tools and
   Utilities media, must be used to deploy the Data Provider with the SYSTEM
   account.

Installation through SMS

   Extract the msi file from the installation executable by running the 
   following command at commmand prompt
   
        "installation executable" /a

   Using the extracted '.NET Data Provider for Teradata.msi' file the package 
   can be pushed from SMS server to SMS clients using the following commands:

   To install full package with defaults use
   msiexec /i ".NET Data Provider for Teradata.msi" /qn        

   To install to a user defined location use
   msiexec /i ".NET Data Provider for Teradata.msi" INSTALLDIR=c:\test /qn

   To install the package without Visual Studio features use
   msiexec /i ".NET Data Provider for Teradata.msi" VSFEATURE=0 /qn


5.0 Uninstall
=============
Follow this procedure to uninstall the .NET Data Provider for Teradata: 

  1- Open "Control Panel".

  2- Start "Add or Remove Programs".

  3- Find ".NET Data Provider for Teradata" and click Remove.
     This will uninstall the package.


6.0 Restrictions and Known Issues
=================================
a) The .NET Data Provider for Teradata requires Full-Trust permission-set to 
   run. 
