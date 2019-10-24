# MetaDslx framework

MetaDslx is a user friendly metamodeling framework based on .NET Standard 2.0.

MetaDslx supports the following features:
* implementing domain specific languages (DSLs)
* lock-free thread-safe immutable semantic object models
* auto generated syntactic and semantic compilation of DSLs to object models
* compilers with a Roslyn-style public API, based on ANTLR4 grammars extended with semantic annotations
* creating user friendly template-based code generators
* generating syntax highlighters for Visual Studio
* complete implementation of the OMG metamodel standards: [MOF](https://www.omg.org/spec/MOF/), [UML](https://www.omg.org/spec/UML/)
* model serialization and deserialization through the [XMI](https://www.omg.org/spec/XMI/) standard
* implementation of the Eclipse EMF [ecore](https://wiki.eclipse.org/Ecore) metamodel

# Documentation

The documentation of the MetaDslx framework can be accessed here: [The MetaDslx Framework](https://github.com/balazssimon/meta-cs/wiki/The-MetaDslx-Framework)

# Instructions for developing your own DSL using the MetaDslx framework

These are the installation instructions if you would like to use the MetaDslx framework for creating your own DSLs. For an example DSL see the [SOAL language](https://github.com/balazssimon/soal-cs).

## NuGet dependencies for development

Add the following NuGet dependencies to your .NET Standard or .NET Core project:
* **MetaDslx.CodeAnalysis**: these are the MetaDslx libraries required for developing and running your application
* **MetaDslx.BuildTasks**: after this package is added, MSBuild automatically compiles .mgen, .mm and .ag4 files

## Installation of the Visual Studio extension

The MetaDslx extension provides syntax highlighting and error reporting for .mgen, .mm and .ag4 files. It requires the following prerequisites: Visual Studio 2019 and .NET Standard 2.0.

Installation steps:
1. In Visual Studio open the **Extensions / Manage Extensions** menu.
2. Install the **MetaDslx Extension for Visual Studio** from the Visual Studio Marketplace.

## Uninstallation of the Visual Studio extension

Uninstallation steps:
1. In Visual Studio open the **Extensions / Manage Extensions** menu.
2. Look for the **MetaDslx Extension for Visual Studio** and click on **Uninstall**.
In Visual Studio open the **Extensions / Manage Extensions** menu, look for the **MetaDslx Extension for Visual Studio** and click on **Uninstall**.

# Instructions for compiling MetaDslx framework from source

These are the instructions if you would like to build the MetaDslx framework from source.

Building the MetaDslx framework requires Visual Studio 2019 and the Visual Studio 2019 SDK (Visual Studio Extensibility Tools).

Steps:
1. Check out the source from GitHub.
2. Open the **src\MetaDslx.sln** in Visual Studio.
3. Right click on the **MetaDslx** solution and choose **Build Solution**.

Note that the MetaDslx framework is required to compile itself. The **BootstrapVersion** property in the **src\Versions.prop** file specifies which version of the framework is used to compile the checked out version of the framework. The **BootstrapVersion** is usually the latest published version, but temporarily it can be an unpublished version.
