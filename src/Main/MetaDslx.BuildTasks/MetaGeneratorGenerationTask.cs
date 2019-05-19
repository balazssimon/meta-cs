using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class MetaGeneratorGenerationTask : Task
    {
        private List<ITaskItem> _generatedCodeFiles = new List<ITaskItem>();

        public MetaGeneratorGenerationTask()
        {
        }

        [Required]
        public string OutputPath
        {
            get;
            set;
        }

        public string Encoding
        {
            get;
            set;
        }

        public ITaskItem[] SourceCodeFiles
        {
            get;
            set;
        }

        [Output]
        public ITaskItem[] GeneratedCodeFiles
        {
            get
            {
                return this._generatedCodeFiles.ToArray();
            }
            set
            {
                this._generatedCodeFiles = new List<ITaskItem>(value);
            }
        }

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
            Log.LogMessage("MetaGenerator: generating C# code for '{0}'", filePath);
            if (!File.Exists(filePath))
            {
                Log.LogError("The tokens file '{0}' does not exist.", filePath);
                return false;
            }
            var compiler = new MetaGeneratorCompiler(filePath, this.OutputPath);
            try
            {
                compiler.Compile();
                if (compiler.HasErrors)
                {
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
                                Log.LogMessage(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line, position.StartLinePosition.Character, position.EndLinePosition.Line, position.EndLinePosition.Character, MessageImportance.Normal, message.GetMessage());
                                break;
                            case Microsoft.CodeAnalysis.DiagnosticSeverity.Warning:
                                Log.LogWarning(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line, position.StartLinePosition.Character, position.EndLinePosition.Line, position.EndLinePosition.Character, MessageImportance.Normal, message.GetMessage());
                                break;
                            case Microsoft.CodeAnalysis.DiagnosticSeverity.Error:
                                Log.LogError(message.Descriptor.Category, message.Descriptor.Id, message.Descriptor.HelpLinkUri, fileName, position.StartLinePosition.Line, position.StartLinePosition.Character, position.EndLinePosition.Line, position.EndLinePosition.Character, MessageImportance.High, message.GetMessage());
                                break;
                            default:
                                break;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.LogError("Error compiling file '{0}': {1}", filePath, ex.Message);
                return false;
            }
            Log.LogMessage("MetaGenerator: successfully generated C# code for '{0}'.", filePath);
            return true;
        }
    }
}
