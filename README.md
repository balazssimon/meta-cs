# meta-cs
MetaDslx is a user friendly metamodeling framework for .NET.

MetaDslx supports the following features:
* implementing domain specific languages
* extending ANTLR4 grammars with annotations
* creating compilers with semantic analysis for domain specific languages
* creating user friendly template-based code generators
* generating syntax highlighters for Visual Studio

# Installation instructions for users

These are the installation instructions if you would like to use the MetaDslx framework for creating your own DSLs. For an example DSL see the [SOAL language](https://github.com/balazssimon/soal-cs).

The MetaDslx framework requires Visual Studio 2015 and .NET Framework 4.5.2.

Installation steps:

1. Extract the **MetaDslx-v0.4-alpha.zip** file and make sure that the **GAC_DIR** environment variable in the install batch files point to the correct location of the .NET tools directory.
2. Run **install64.bat** on 64-bit systems, or **install32.bat** on 32-bit systems to install the MetaDslx DLLs to the GAC.
3. Run the **MetaDslx.VisualStudio.vsix** to install the Visual Studio 2015 plugin.

# Installation instructions for developers

These are the installation instructions if you would like to build the MetaDslx framework from source.

Building the MetaDslx framework requires Visual Studio 2015 and the Visual Studio 2015 SDK (Visual Studio Extensibility Tools).

Installation steps:

1. Extract the **MetaDslx-v0.4-alpha.zip** file and make sure that the **GAC_DIR** environment variable in the install batch files point to the correct location of the .NET tools directory.
2. Run **install64antlr.bat** on 64-bit systems, or **install32antlr.bat** on 32-bit systems to install the ANTLR4 runtime DLL to the GAC.
3. Run the **MetaDslx.VisualStudio.vsix** to install the Visual Studio 2015 plugin.
4. Check out the source from GitHub.
5. Open the **Src\MetaDslx.sln** in Visual Studio.
6. Right click the **MetaDslx.VisualStudio** project, and under the **Debug** tab set the following:
 * Start Action / Start external program: **C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe**
 * Start Options / Command line arguments: **/rootsuffix Exp**
7. Right click on the MetaDslx solution and choose Build Solution.
