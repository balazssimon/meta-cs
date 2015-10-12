# meta-cs
MetaDslx is a user friendly metamodeling framework for .NET.

MetaDslx supports the following features:
* implementing domain specific languages
* extending ANTLR4 grammars with annotations
* creating compilers with semantic analysis for domain specific languages
* creating user friendly template-based code generators
* generating syntax highlighters for Visual Studio

# Installation instructions for v0.1-alpha

The MetaDslx framework requires Visual Studio 2015 and .NET Framework 4.5.2.

Installation steps:
1. Extract the MetaDslx-v0.1-alpha.zip file and make sure that the GAC_DIR environment variable in the *.bat files point to the correct location of the .NET tools directory.
2. Run install64.bat on 64-bit systems, or install32.bat on 32-bit systems.
3. Download the **antlr-csharp-runtime-4.5.1.zip** from the [http://www.antlr.org/download.html](ANTLR4 web site).
4. Extract the ZIP and install the Antlr4.Runtime.dll to the GAC, as the batch files do for the MetaDslx libraries.
5. Run the MetaDslx.VisualStudio.vsix to install the Visual Studio 2015 plugin.

