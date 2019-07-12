using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class Antlr4RoslynGenerationTask : Antlr4CompilerTask
    {
        public Antlr4RoslynGenerationTask()
            : base("Antlr4RoslynGenerator")
        {
            this.TimeoutInSeconds = 30;
            this.UseCSharpGenerator = true;
            this.Encoding = "UTF-8";
            this.TargetLanguage = "CSharp";
            this.LanguageSourceExtensions = new string[] { ".cs", ".tokens" };
        }

        public int TimeoutInSeconds { get; set; }
        public string ToolPath { get; set; }
        public string TargetLanguage { get; set; }
        public string TargetNamespace { get; set; }
        public string TargetFrameworkVersion { get; set; }
        public string BuildTaskPath { get; set; }
        public ITaskItem[] TokensFiles { get; set; }
        public ITaskItem[] AbstractGrammarFiles { get; set; }
        public string[] LanguageSourceExtensions { get; set; }
        public bool GenerateListener { get; set; }
        public bool GenerateVisitor { get; set; }
        public bool ForceAtn { get; set; }
        public bool AbstractGrammar { get; set; }
        public string JavaVendor { get; set; }
        public string JavaInstallation { get; set; }
        public string JavaExecutable { get; set; }
        public bool UseCSharpGenerator { get; set; }
        public bool ContinueOnError { get; set; }

        protected override ICompilerForBuildTask CreateCompiler(string filePath, string outputPath)
        {
            var antlr4Tool = this.CreateAntlr4BuildTool();
            return new Antlr4RoslynCompiler(filePath, outputPath, this.TargetNamespace, antlr4Tool);
        }

        private Antlr4BuildTool CreateAntlr4BuildTool()
        {
            if (!Path.IsPathRooted(ToolPath))
                ToolPath = Path.Combine(Path.GetDirectoryName(BuildEngine.ProjectFileOfTaskNode), ToolPath);

            if (!Path.IsPathRooted(BuildTaskPath))
                BuildTaskPath = Path.Combine(Path.GetDirectoryName(BuildEngine.ProjectFileOfTaskNode), BuildTaskPath);

            Antlr4BuildTool antlr4 = new Antlr4BuildTool();

            if (this.TokensFiles != null && this.TokensFiles.Length > 0)
            {
                Directory.CreateDirectory(OutputPath);

                HashSet<string> copied = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (ITaskItem taskItem in TokensFiles)
                {
                    string fileName = taskItem.ItemSpec;
                    if (!File.Exists(fileName))
                    {
                        Log.LogError("The tokens file '{0}' does not exist.", fileName);
                        continue;
                    }

                    string vocabName = Path.GetFileNameWithoutExtension(fileName);
                    if (!copied.Add(vocabName))
                    {
                        Log.LogWarning("The tokens file '{0}' conflicts with another tokens file in the same project.", fileName);
                        continue;
                    }

                    string target = Path.Combine(OutputPath, Path.GetFileName(fileName));
                    if (!Path.GetExtension(target).Equals(".tokens", StringComparison.OrdinalIgnoreCase))
                    {
                        Log.LogError("The destination for the tokens file '{0}' did not have the correct extension '.tokens'.", target);
                        continue;
                    }

                    File.Copy(fileName, target, true);
                    File.SetAttributes(target, File.GetAttributes(target) & ~FileAttributes.ReadOnly);
                }
            }

            antlr4.ToolPath = ToolPath;
            antlr4.TargetLanguage = TargetLanguage;
            antlr4.TargetFrameworkVersion = TargetFrameworkVersion;
            antlr4.OutputPath = OutputPath;
            antlr4.Encoding = Encoding;
            antlr4.LanguageSourceExtensions = LanguageSourceExtensions;
            antlr4.TargetNamespace = TargetNamespace;
            antlr4.GenerateListener = GenerateListener;
            antlr4.GenerateVisitor = GenerateVisitor;
            antlr4.ForceAtn = ForceAtn;
            antlr4.AbstractGrammar = AbstractGrammar;
            antlr4.JavaVendor = JavaVendor;
            antlr4.JavaInstallation = JavaInstallation;
            antlr4.JavaExecutable = JavaExecutable;
            antlr4.UseCSharpGenerator = UseCSharpGenerator;

            if (this.TimeoutInSeconds == 0) antlr4.TimeoutInSeconds = 30;
            if (string.IsNullOrWhiteSpace(this.Encoding)) antlr4.Encoding = "UTF-8";
            if (string.IsNullOrWhiteSpace(this.TargetLanguage)) antlr4.TargetLanguage = "CSharp";
            if (this.LanguageSourceExtensions == null) antlr4.LanguageSourceExtensions = new string[] { ".cs", ".tokens" };

            return antlr4;
        }
    }
}
