using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public enum OutputLocation
    {
        IntermediateDirectory,
        CurrentDirectory,
        CustomDirectory
    }

    public abstract class Antlr4CompilerTask : Task
    {
        private string _compilerName;
        private string _absoluteIntermediatePath;
        private List<ITaskItem> _generatedCodeFiles = new List<ITaskItem>();
        private List<ITaskItem> _generatedIntermediateCodeFiles = new List<ITaskItem>();

        public Antlr4CompilerTask(string compilerName)
        {
            _compilerName = compilerName;
        }

        public string Name => _compilerName;

        public string AutomaticOutputLocation { get; set; }
        
        public string AutomaticOutputPath { get; set; }

        public string ManualOutputPath { get; set; }

        public string IntermediateOutputPath { get; set; }

        public string Encoding { get; set; }

        public ITaskItem[] SourceCodeFiles { get; set; }

        [Output]
        public ITaskItem[] GeneratedCodeFiles => this._generatedCodeFiles.ToArray();

        [Output]
        public ITaskItem[] GeneratedIntermediateCodeFiles => this._generatedIntermediateCodeFiles.ToArray();

        public override bool Execute()
        {
            AssemblyResolver.Enable();
            bool result = true;
            _absoluteIntermediatePath = Path.GetFullPath(this.IntermediateOutputPath);
            foreach (var item in SourceCodeFiles)
            {
                if (!this.Compile(item)) result = false;
            }
            return result;
        }

        private bool Compile(ITaskItem taskItem)
        {
            string filePath = taskItem.ItemSpec;
            Log.LogMessage(MessageImportance.Low, "{0}: generating code for '{1}'", this.Name, filePath);
            if (!File.Exists(filePath))
            {
                Log.LogError("{0}: FAILED to generate code for '{1}': the file does not exits.", this.Name, filePath);
                return false;
            }
            string automaticOutputPath = this.AutomaticOutputPath;
            if (string.IsNullOrEmpty(automaticOutputPath))
            {
                switch (this.AutomaticOutputLocation)
                {
                    case "CurrentDirectory":
                        automaticOutputPath = null;
                        break;
                    case "IntermediateDirectory":
                    default:
                        automaticOutputPath = this.IntermediateOutputPath;
                        break;
                }
            }
            if (string.IsNullOrEmpty(automaticOutputPath))
            {
                automaticOutputPath = Path.GetDirectoryName(filePath);
            }
            string outputPath = this.ManualOutputPath;
            if (string.IsNullOrEmpty(outputPath))
            {
                outputPath = Path.GetDirectoryName(filePath);
            }
            var compiler = this.CreateCompiler(filePath, outputPath, automaticOutputPath);
            try
            {
                bool hasIntermediateOutputPath = !string.IsNullOrWhiteSpace(this.IntermediateOutputPath);
                compiler.Compile();
                compiler.Generate(hasIntermediateOutputPath);
                this.LogDiagnostics(compiler.GetDiagnostics());
                if (!compiler.HasErrors)
                {
                    foreach (var file in compiler.GetGeneratedFileList())
                    {
                        _generatedCodeFiles.Add((ITaskItem)new TaskItem(file));
                        if (hasIntermediateOutputPath && IsIntermediateFile(file))
                        {
                            _generatedIntermediateCodeFiles.Add((ITaskItem)new TaskItem(file));
                        }
                        Log.LogMessage(MessageImportance.Low, "{0}: generated file: '{1}'.", this.Name, file);
                    }
                    Log.LogMessage(MessageImportance.Low, "{0}: SUCCESSFULLY generated code for '{1}'.", this.Name, filePath);
                    return true;
                }
                else
                {
                    Log.LogMessage(MessageImportance.High, "{0}: FAILED to generate code for '{1}'.", this.Name, filePath);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.LogError("{0}: FAILED to generate code for '{1}': {2}", this.Name, filePath, ex.ToString().Replace("\r\n", "|"));
                return false;
            }
        }

        private bool IsIntermediateFile(string filePath)
        {
            return Path.GetFullPath(filePath).StartsWith(_absoluteIntermediatePath);
        }

        protected abstract ICompilerForBuildTask CreateCompiler(string filePath, string outputPath, string hiddenOutputPath);

        private void LogDiagnostics(ImmutableArray<Diagnostic> diagnostics)
        {
            foreach (var message in diagnostics)
            {
                var position = message.Location.GetMappedLineSpan();
                string fileName = position.Path;
                switch (message.Severity)
                {
                    case Microsoft.CodeAnalysis.DiagnosticSeverity.Hidden:
                        Log.LogMessage(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line + 1, position.StartLinePosition.Character + 1, position.EndLinePosition.Line + 1, position.EndLinePosition.Character + 1, MessageImportance.Low, message.GetMessage());
                        break;
                    case Microsoft.CodeAnalysis.DiagnosticSeverity.Info:
                        Log.LogMessage(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line + 1, position.StartLinePosition.Character + 1, position.EndLinePosition.Line + 1, position.EndLinePosition.Character + 1, message.GetMessage());
                        break;
                    case Microsoft.CodeAnalysis.DiagnosticSeverity.Warning:
                        Log.LogWarning(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line + 1, position.StartLinePosition.Character + 1, position.EndLinePosition.Line + 1, position.EndLinePosition.Character + 1, message.GetMessage());
                        break;
                    case Microsoft.CodeAnalysis.DiagnosticSeverity.Error:
                        Log.LogError(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line + 1, position.StartLinePosition.Character + 1, position.EndLinePosition.Line + 1, position.EndLinePosition.Character + 1, message.GetMessage());
                        break;
                    default:
                        Log.LogError(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line + 1, position.StartLinePosition.Character + 1, position.EndLinePosition.Line + 1, position.EndLinePosition.Character + 1, message.GetMessage());
                        break;
                }
            }
        }

    }
}

