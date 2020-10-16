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

        public static void MetaGeneratorTool(FileInfo[] input, DirectoryInfo manualOutputDirectory = null, DirectoryInfo automaticOutputDirectory = null)
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
                        string automaticOutputPath = automaticOutputDirectory?.ToString() ?? string.Empty;
                        string manualOutputPath = manualOutputDirectory?.ToString() ?? string.Empty;
                        var compiler = new MetaGeneratorCompiler(manualOutputPath, automaticOutputPath, inputFile.ToString());
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

        public static void MetaModelTool(FileInfo[] input, bool isCoreModel, string coreNamespace, DirectoryInfo manualOutputDirectory = null, DirectoryInfo automaticOutputDirectory = null)
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
                    try {
                        string automaticOutputPath = automaticOutputDirectory?.ToString() ?? string.Empty;
                        string manualOutputPath = manualOutputDirectory?.ToString() ?? string.Empty;
                        var compiler = new MetaCompilerForBuildTask(manualOutputPath, automaticOutputPath, inputFile.ToString(), isCoreModel, coreNamespace);
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

        public static void Antlr4RoslynTool(FileInfo javaExe, FileInfo toolPath, FileInfo[] input, string targetNamespace, DirectoryInfo manualOutputDirectory = null, DirectoryInfo automaticOutputDirectory = null)
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
                        string automaticOutputPath = automaticOutputDirectory?.ToString() ?? string.Empty;
                        string manualOutputPath = manualOutputDirectory?.ToString() ?? string.Empty;
                        var antlr4BuildTool = new Antlr4BuildTool();
                        if (javaExe != null) antlr4BuildTool.JavaExe = javaExe.FullName;
                        if (toolPath != null) antlr4BuildTool.ToolPath = toolPath.FullName;
                        else
                        {
                            string assemblyPath = Path.GetDirectoryName(typeof(Antlr4BuildTool).Assembly.Location);
                            antlr4BuildTool.ToolPath = Path.Combine(assemblyPath, "..", "..", "antlr-4.8-complete.jar");
                        }
                        var compiler = new Antlr4RoslynCompiler(manualOutputPath, automaticOutputPath, inputFile.ToString(), targetNamespace, antlr4BuildTool);
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
