using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public abstract class Antlr4CompilerTask : Task
    {
        private string _compilerName;
        private List<ITaskItem> _generatedCodeFiles = new List<ITaskItem>();

        public Antlr4CompilerTask(string compilerName)
        {
            _compilerName = compilerName;
        }

        public string Name => _compilerName;        

        [Required]
        public string OutputPath { get; set; }

        public string Encoding { get; set; }

        public ITaskItem[] SourceCodeFiles { get; set; }

        [Output]
        public ITaskItem[] GeneratedCodeFiles => this._generatedCodeFiles.ToArray();

        public override bool Execute()
        {
            AssemblyResolver.Enable();
            bool result = true;
            foreach (var item in SourceCodeFiles)
            {
                if (!this.Compile(item)) result = false;
            }
            return result;
        }

        private bool Compile(ITaskItem taskItem)
        {
            string filePath = taskItem.ItemSpec;
            Log.LogMessage(MessageImportance.High, "{0}: generating code for '{1}'", this.Name, filePath);
            if (!File.Exists(filePath))
            {
                Log.LogError("{0}: FAILED to generate code for '{1}': the file does not exits.", this.Name, filePath);
                return false;
            }
            var compiler = this.CreateCompiler(filePath, this.OutputPath);
            try
            {
                compiler.Compile();
                foreach (var message in compiler.GetDiagnostics())
                {
                    var position = message.Location.GetMappedLineSpan();
                    string fileName = position.Path;
                    switch (message.Severity)
                    {
                        case Microsoft.CodeAnalysis.DiagnosticSeverity.Hidden:
                            Log.LogMessage(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line, position.StartLinePosition.Character, position.EndLinePosition.Line, position.EndLinePosition.Character, MessageImportance.Low, message.GetMessage());
                            break;
                        case Microsoft.CodeAnalysis.DiagnosticSeverity.Info:
                            Log.LogMessage(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line, position.StartLinePosition.Character, position.EndLinePosition.Line, position.EndLinePosition.Character, MessageImportance.High, message.GetMessage());
                            break;
                        case Microsoft.CodeAnalysis.DiagnosticSeverity.Warning:
                            Log.LogWarning(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line, position.StartLinePosition.Character, position.EndLinePosition.Line, position.EndLinePosition.Character, MessageImportance.High, message.GetMessage());
                            break;
                        case Microsoft.CodeAnalysis.DiagnosticSeverity.Error:
                            Log.LogError(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line, position.StartLinePosition.Character, position.EndLinePosition.Line, position.EndLinePosition.Character, MessageImportance.High, message.GetMessage());
                            break;
                        default:
                            break;
                    }
                }
                if (!compiler.HasErrors)
                {
                    foreach (var file in compiler.GetGeneratedFileList())
                    {
                        _generatedCodeFiles.Add((ITaskItem)new TaskItem(file));
                        Log.LogMessage(MessageImportance.High, "{0}: generated file: '{1}'.", this.Name, file);
                    }
                    Log.LogMessage(MessageImportance.High, "{0}: SUCCESSFULLY generated code for '{1}'.", this.Name, filePath);
                    return true;
                }
                else
                {
                    Log.LogError("{0}: FAILED to generate code for '{1}'", this.Name, filePath);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.LogError("{0}: FAILED to generate code for '{1}': {2}", this.Name, filePath, ex.Message);
                return false;
            }
        }

        protected abstract ICompilerForBuildTask CreateCompiler(string filePath, string outputPath);

    }
}
