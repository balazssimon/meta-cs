# meta-cs
MetaDslx is a user friendly metamodeling framework for .NET.

MetaDslx supports the following features:
* implementing domain specific languages (DSLs)
* lock-free thread-safe immutable semantic object models
* auto generated syntactic and semantic compilation of DSLs to object models
* compilers with a Roslyn-style public API, based on ANTLR4 grammars extended with semantic annotations
* creating user friendly template-based code generators
* generating syntax highlighters for Visual Studio

# Documentation

The documentation of the MetaDslx framework can be accessed here: [The MetaDslx Framework](https://github.com/balazssimon/meta-cs/wiki/The-MetaDslx-Framework)

# Installation instructions

## Instructions for developing your own DSL using the MetaDslx plugin

### Installation

These are the installation instructions if you would like to use the MetaDslx framework for creating your own DSLs. For an example DSL see the [SOAL language](https://github.com/balazssimon/soal-cs).

The MetaDslx plugin requires the following prerequisites:
* Visual Studio 2015 and .NET Framework 4.6.1
* Java 8 for running ANTLR4 (make sure the **java** command is on the PATH environment variable)

Installation steps:

1. Extract the **MetaDslx-v*.zip** file and make sure that the **GAC_DIR** environment variable in the install batch files point to the correct location of the .NET tools directory.
2. Run **install64.bat** on 64-bit systems, or **install32.bat** on 32-bit systems from an **admin** command prompt to install the MetaDslx DLLs to the GAC.
3. Run the **MetaDslx.VisualStudio.vsix** to install the Visual Studio 2015 plugin.

### Uninstallation

1. In Visual Studio open the **Tools / Extensions and Updates...** menu, look for the **MetaDslx Extension for Visual Studio** and click on **Uninstall**.
2. Run **uninstall64.bat** on 64-bit systems, or **uninstall32.bat** on 32-bit systems from an **admin** command prompt to remove the MetaDslx DLLs from the GAC.

## Instructions for running an application with your own DSL depending on the MetaDslx framework

The MetaDslx core runtime (MetaDslx.Core.dll) requires the following prerequisites:
* .NET Framework 4.6.1

The MetaDslx compiler runtime (MetaDslx.Compiler.Antlr4.dll) requires the following prerequisites:
* .NET Framework 4.6.1
* Antlr4.Runtime.Standard.dll
* MetaDslx.Core.dll

## Instructions for developing the MetaDslx framework

### Installation

These are the installation instructions if you would like to build the MetaDslx framework from source.

Building the MetaDslx framework requires Visual Studio 2015 and the Visual Studio 2015 SDK (Visual Studio Extensibility Tools).

Installation steps:

1. Extract the **MetaDslx-v*.zip** file and make sure that the **GAC_DIR** environment variable in the install batch files point to the correct location of the .NET tools directory.
2. Run **install64antlr.bat** on 64-bit systems, or **install32antlr.bat** on 32-bit systems from an **admin** command prompt to install the ANTLR4 runtime DLL to the GAC.
3. Run the **MetaDslx.VisualStudio.vsix** to install the Visual Studio 2015 plugin.
4. Check out the source from GitHub.
5. Open the **Src\MetaDslx.sln** in Visual Studio.
6. Right click the **MetaDslx.VisualStudio** project, and under the **Debug** tab set the following:
 * Start Action / Start external program: **C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe**
 * Start Options / Command line arguments: **/rootsuffix Exp**
7. Right click on the **MetaDslx** solution and choose **Build Solution**.

### Uninstallation

1. In Visual Studio open the **Tools / Extensions and Updates...** menu, look for the **MetaDslx Extension for Visual Studio** and click on **Uninstall**.
2. Run **uninstall64antlr.bat** on 64-bit systems, or **uninstall32antlr.bat** on 32-bit systems from an **admin** command prompt to remove the ANTLR4 runtime DLL from the GAC.
