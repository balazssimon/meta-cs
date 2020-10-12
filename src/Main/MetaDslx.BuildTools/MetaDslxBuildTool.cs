using MetaDslx.BuildTasks;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
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

        public static void MetaGeneratorTool(FileInfo input, DirectoryInfo intermediateDirectory, DirectoryInfo outputDirectory = null, OutputLocation outputLocation = OutputLocation.IntermediateDirectory)
        {
            if (input == null)
            {
                Console.Error.WriteLine("error: input file is missing");
                return;
            }
            if (!input.Exists)
            {
                Console.Error.WriteLine("{0}: error: file not found", input.FullName);
                return;
            }
            try
            {
                string outputPath = null;
                switch (outputLocation)
                {
                    case OutputLocation.CustomDirectory:
                        outputPath = outputDirectory?.FullName;
                        break;
                    case OutputLocation.IntermediateDirectory:
                        outputPath = intermediateDirectory?.FullName;
                        break;
                }
                if (outputPath == null) outputPath = input.DirectoryName;
                var compiler = new MetaGeneratorCompiler(input.FullName, outputPath);
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
                        Console.WriteLine("generated file: {1}", file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void MetaModelTool(FileInfo input, DirectoryInfo intermediateDirectory, bool isCoreModel, string coreNamespace, DirectoryInfo outputDirectory = null, OutputLocation outputLocation = OutputLocation.IntermediateDirectory)
        {
            if (input == null)
            {
                Console.Error.WriteLine("error: input file is missing");
                return;
            }
            if (!input.Exists)
            {
                Console.Error.WriteLine("{0}: error: file not found", input.FullName);
                return;
            }
            try
            {
                string outputPath = null;
                switch (outputLocation)
                {
                    case OutputLocation.CustomDirectory:
                        outputPath = outputDirectory?.FullName;
                        break;
                    case OutputLocation.IntermediateDirectory:
                        outputPath = intermediateDirectory?.FullName;
                        break;
                }
                if (outputPath == null) outputPath = input.DirectoryName;
                var compiler = new MetaCompilerForBuildTask(input.FullName, outputPath, isCoreModel, coreNamespace);
                compiler.Compile();
                if (compiler.HasErrors)
                {
                    DiagnosticFormatter formatter = new DiagnosticFormatter();
                    foreach (var message in compiler.GetDiagnostics())
                    {
                        Console.Error.WriteLine(formatter.Format(message));
                    }
                } else
                {
                    compiler.Generate();
                    foreach (var file in compiler.GetGeneratedFileList())
                    {
                        Console.WriteLine("generated file: {1}", file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void Antlr4RoslynTool(FileInfo javaExe, FileInfo toolPath, FileInfo input, DirectoryInfo intermediateDirectory, string targetNamespace, DirectoryInfo manualOutputDirectory, DirectoryInfo automaticOutputDirectory = null, OutputLocation automaticOutputLocation = OutputLocation.IntermediateDirectory)
        {
            if (input == null)
            {
                Console.Error.WriteLine("error: input file is missing");
                return;
            }
            if (!input.Exists)
            {
                Console.Error.WriteLine("{0}: error: file not found", input.FullName);
                return;
            }
            try
            {
                string automaticOutputPath = null;
                switch (automaticOutputLocation)
                {
                    case OutputLocation.CustomDirectory:
                        automaticOutputPath = automaticOutputDirectory?.FullName;
                        break;
                    case OutputLocation.IntermediateDirectory:
                        automaticOutputPath = intermediateDirectory?.FullName;
                        break;
                }
                if (automaticOutputPath == null) automaticOutputPath = input.DirectoryName;
                string manualOutputPath = manualOutputDirectory?.FullName ?? input.DirectoryName;
                var antlr4BuildTool = new Antlr4BuildTool();
                if (javaExe != null) antlr4BuildTool.JavaExe = javaExe.FullName;
                if (toolPath != null) antlr4BuildTool.ToolPath = toolPath.FullName;
                else antlr4BuildTool.ToolPath = Path.GetFullPath(@"tools\antlr-4.8-complete.jar");
                var compiler = new Antlr4RoslynCompiler(input.FullName, manualOutputPath, automaticOutputPath, targetNamespace, antlr4BuildTool);
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
                Console.WriteLine(ex);
            }
        }
    }
}
