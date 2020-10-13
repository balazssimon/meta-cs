using MetaDslx.BuildTasks;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.DragonFruit;
using System.CommandLine.Invocation;
using System.IO;
using System.Text;

namespace MetaDslx.BuildTools
{
    public enum OutputLocation
    {
        CustomDirectory,
        IntermediateDirectory,
        CurrentDirectory
    }

    public class MetaDslxBuildTool
    {
        public static void Main(string[] args)
        {
            Command mgenCommand = new Command("mgen", "Compile a generator template (.mgen) to C#");
            var method = typeof(MetaDslxBuildTool).GetMethod("MetaGeneratorTool");
            foreach (var option in method.BuildOptions())
            {
                mgenCommand.AddOption(option);
            }
            mgenCommand.Handler = CommandHandler.Create(method);

            Command mmCommand = new Command("mm", "Compile a meta model (.mm) description to C#");
            method = typeof(MetaDslxBuildTool).GetMethod("MetaModelTool");
            foreach (var option in method.BuildOptions())
            {
                mmCommand.AddOption(option);
            }
            mmCommand.Handler = CommandHandler.Create(method);

            Command ag4Command = new Command("ag4", "Compile an annotated ANTLR4 grammar (.ag4) to C#");
            method = typeof(MetaDslxBuildTool).GetMethod("Antlr4RoslynTool");
            foreach (var option in method.BuildOptions())
            {
                ag4Command.AddOption(option);
            }
            ag4Command.Handler = CommandHandler.Create(method);

            RootCommand rootCommand = new RootCommand(description: "Tools for the MetaDslx metamodeling platform");
            rootCommand.Add(mgenCommand);
            rootCommand.Add(mmCommand);
            rootCommand.Add(ag4Command);

            rootCommand.Invoke(args);
        }

        public static void MetaGeneratorTool(FileInfo[] input, DirectoryInfo intermediateDirectory, DirectoryInfo outputDirectory = null, OutputLocation outputLocation = OutputLocation.IntermediateDirectory)
        {
            if (input == null)
            {
                Console.Error.WriteLine("error: input file is missing");
                return;
            }
            try
            {
                string outputPath = null;
                if (outputDirectory != null || outputLocation == OutputLocation.CustomDirectory)
                {
                    outputPath = outputDirectory?.FullName;
                }
                else if (outputLocation == OutputLocation.IntermediateDirectory)
                {
                    outputPath = intermediateDirectory?.FullName;
                }
                foreach (var inputFile in input)
                {
                    if (!inputFile.Exists)
                    {
                        Console.Error.WriteLine("{0}: error: file not found", inputFile.FullName);
                        continue;
                    }
                    try
                    {
                        var currentOutputPath = outputPath ?? inputFile.DirectoryName;
                        var compiler = new MetaGeneratorCompiler(inputFile.FullName, currentOutputPath);
                        compiler.Compile();
                        if (compiler.HasErrors)
                        {
                            DiagnosticFormatter formatter = new DiagnosticFormatter();
                            foreach (var message in compiler.GetDiagnostics())
                            {
                                Console.Error.WriteLine(formatter.Format(message));
                            }
                        }
                        else
                        {
                            foreach (var file in compiler.GetGeneratedFileList())
                            {
                                Console.WriteLine("generated file: {0}", file);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("{0}: error: {1}", inputFile.FullName, ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        public static void MetaModelTool(FileInfo[] input, DirectoryInfo intermediateDirectory, bool isCoreModel, string coreNamespace, DirectoryInfo outputDirectory = null, OutputLocation outputLocation = OutputLocation.IntermediateDirectory)
        {
            if (input == null)
            {
                Console.Error.WriteLine("error: input file is missing");
                return;
            }
            try
            {
                string outputPath = null;
                if (outputDirectory != null || outputLocation == OutputLocation.CustomDirectory)
                {
                    outputPath = outputDirectory?.FullName;
                }
                else if (outputLocation == OutputLocation.IntermediateDirectory)
                {
                    outputPath = intermediateDirectory?.FullName;
                }
                foreach (var inputFile in input)
                {
                    if (!inputFile.Exists)
                    {
                        Console.Error.WriteLine("{0}: error: file not found", inputFile.FullName);
                        continue;
                    }
                    try {
                        var currentOutputPath = outputPath ?? inputFile.DirectoryName;
                        var compiler = new MetaCompilerForBuildTask(inputFile.FullName, currentOutputPath, isCoreModel, coreNamespace);
                        compiler.Compile();
                        if (compiler.HasErrors)
                        {
                            DiagnosticFormatter formatter = new DiagnosticFormatter();
                            foreach (var message in compiler.GetDiagnostics())
                            {
                                Console.Error.WriteLine(formatter.Format(message));
                            }
                        }
                        else
                        {
                            compiler.Generate();
                            foreach (var file in compiler.GetGeneratedFileList())
                            {
                                Console.WriteLine("generated file: {0}", file);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("{0}: error: {1}", inputFile.FullName, ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        public static void Antlr4RoslynTool(FileInfo javaExe, FileInfo toolPath, FileInfo[] input, DirectoryInfo intermediateDirectory, string targetNamespace, DirectoryInfo manualOutputDirectory, DirectoryInfo automaticOutputDirectory = null, OutputLocation automaticOutputLocation = OutputLocation.IntermediateDirectory)
        {
            if (input == null)
            {
                Console.Error.WriteLine("error: input file is missing");
                return;
            }
            try
            {
                foreach (var inputFile in input)
                {
                    if (!inputFile.Exists)
                    {
                        Console.Error.WriteLine("{0}: error: file not found", inputFile.FullName);
                        continue;
                    }
                    try
                    {
                        string automaticOutputPath = null;
                        if (automaticOutputDirectory != null || automaticOutputLocation == OutputLocation.CustomDirectory)
                        {
                            automaticOutputPath = automaticOutputDirectory?.FullName;
                        }
                        else if (automaticOutputLocation == OutputLocation.IntermediateDirectory)
                        {
                            automaticOutputPath = intermediateDirectory?.FullName;
                        }
                        if (automaticOutputPath == null) automaticOutputPath = inputFile.DirectoryName;
                        string manualOutputPath = manualOutputDirectory?.FullName ?? inputFile.DirectoryName;
                        var antlr4BuildTool = new Antlr4BuildTool();
                        if (javaExe != null) antlr4BuildTool.JavaExe = javaExe.FullName;
                        if (toolPath != null) antlr4BuildTool.ToolPath = toolPath.FullName;
                        else
                        {
                            string assemblyPath = Path.GetDirectoryName(typeof(Antlr4BuildTool).Assembly.Location);
                            antlr4BuildTool.ToolPath = Path.Combine(assemblyPath, "..", "..", "antlr-4.8-complete.jar");
                        }
                        var compiler = new Antlr4RoslynCompiler(inputFile.FullName, manualOutputPath, automaticOutputPath, targetNamespace, antlr4BuildTool);
                        compiler.Compile();
                        if (!compiler.HasErrors)
                        {
                            compiler.Generate();
                        }
                        DiagnosticFormatter formatter = new DiagnosticFormatter();
                        foreach (var message in compiler.GetDiagnostics())
                        {
                            Console.Error.WriteLine(formatter.Format(message));
                        }
                        foreach (var file in compiler.GetGeneratedFileList())
                        {
                            Console.WriteLine("Generated file: {0}", file);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("{0}: error: {1}", inputFile.FullName, ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}
