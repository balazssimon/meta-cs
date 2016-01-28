# meta-cs
MetaDslx is a user friendly metamodeling framework for .NET.

MetaDslx supports the following features:
* implementing domain specific languages
* extending ANTLR4 grammars with annotations
* creating compilers with semantic analysis for domain specific languages
* creating user friendly template-based code generators
* generating syntax highlighters for Visual Studio

# Installation instructions for v0.2-alpha

The MetaDslx framework requires Visual Studio 2015 and .NET Framework 4.5.2.

Installation steps:

1. Extract the **MetaDslx-v0.2-alpha.zip** file and make sure that the **GAC_DIR** environment variable in the install batch files point to the correct location of the .NET tools directory.
2. Download the **antlr-csharp-runtime-4.5.1.zip** from the [ANTLR4 web site](http://www.antlr.org/download.html).
3. Extract the ZIP and copy the **Antlr4.Runtime.dll** into the same directory where MetaDslx install batch files are.
4. Run **install64.bat** on 64-bit systems, or **install32.bat** on 32-bit systems to install the MetaDslx DLLs to the GAC.
5. Run the **MetaDslx.VisualStudio.vsix** to install the Visual Studio 2015 plugin.

