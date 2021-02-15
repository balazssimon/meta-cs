using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;

namespace MetaDslx.CodeGeneration
{
    public class CodeGenerator
    {
        private ArrayBuilder<string> _generatedFiles;

        public CodeGenerator(string manualOutputDirectory, string automaticOutputDirectory)
        {
            ManualOutputDirectory = manualOutputDirectory ?? string.Empty;
            AutomaticOutputDirectory = automaticOutputDirectory ?? string.Empty;
            _generatedFiles = new ArrayBuilder<string>();
        }

        public string ManualOutputDirectory { get; protected set; }
        public string AutomaticOutputDirectory { get; protected set; }
        public ImmutableArray<string> GetGeneratedFileList() => _generatedFiles.ToImmutable();

        public void WriteOutputFile(string filePath, string fileContent, bool automatic = true, bool omitCodeGenerationWarning = false)
        {
            if (automatic || !File.Exists(filePath))
            {
                string path;
                string[] content;
                if (automatic) path = Path.Combine(AutomaticOutputDirectory, filePath);
                else path = Path.Combine(ManualOutputDirectory, filePath);
                if (omitCodeGenerationWarning)
                {
                    content = new string[] { fileContent };
                }
                else
                {
                    if (automatic)
                    {
                        content = new string[] {
                            "// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
                            "// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.",
                            "// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
                            fileContent
                        };
                    }
                    else
                    {
                        content = new string[] {
                            "// NOTE: This is an auto-generated file. However, it will not be changed or regenerated unless you delete it.",
                            fileContent
                        };
                    }
                }
                var dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrWhiteSpace(dir)) Directory.CreateDirectory(dir);
                File.WriteAllLines(path, content);
                this.RegisterGeneratedFile(path);
            }
        }

        protected void RegisterGeneratedFile(string filePath)
        {
            this._generatedFiles.Add(filePath);
        }
    }
}
