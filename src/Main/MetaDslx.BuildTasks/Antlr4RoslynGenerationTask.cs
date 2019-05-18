using Antlr4.Build.Tasks;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class Antlr4RoslynGenerationTask : Task
    {
        private const string DefaultGeneratedSourceExtension = "g4";
        private List<ITaskItem> _generatedCodeFiles = new List<ITaskItem>();

        public Antlr4RoslynGenerationTask()
        {
            this.GeneratedSourceExtension = DefaultGeneratedSourceExtension;
        }

        [Required]
        public string ToolPath
        {
            get;
            set;
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

        public string TargetLanguage
        {
            get;
            set;
        }

        public string TargetFrameworkVersion
        {
            get;
            set;
        }

        public string BuildTaskPath
        {
            get;
            set;
        }

        public ITaskItem[] SourceCodeFiles
        {
            get;
            set;
        }

        public ITaskItem[] TokensFiles
        {
            get;
            set;
        }

        public ITaskItem[] AbstractGrammarFiles
        {
            get;
            set;
        }

        public string GeneratedSourceExtension
        {
            get;
            set;
        }

        public string TargetNamespace
        {
            get;
            set;
        }

        public string[] LanguageSourceExtensions
        {
            get;
            set;
        }

        public bool GenerateListener
        {
            get;
            set;
        }

        public bool GenerateVisitor
        {
            get;
            set;
        }

        public bool ForceAtn
        {
            get;
            set;
        }

        public bool AbstractGrammar
        {
            get;
            set;
        }

        [Required]
        public string JavaVendor
        {
            get;
            set;
        }

        [Required]
        public string JavaInstallation
        {
            get;
            set;
        }

        public string JavaExecutable
        {
            get;
            set;
        }

        public bool UseCSharpGenerator
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
            Antlr4ClassGenerationTask antlr4Task = new Antlr4ClassGenerationTask();
            antlr4Task.ToolPath = ToolPath;
            antlr4Task.OutputPath = OutputPath;
            antlr4Task.Encoding = Encoding;
            antlr4Task.TargetLanguage = TargetLanguage;
            antlr4Task.TargetFrameworkVersion = TargetFrameworkVersion;
            antlr4Task.BuildTaskPath = BuildTaskPath;
            antlr4Task.SourceCodeFiles = SourceCodeFiles;
            antlr4Task.TokensFiles = TokensFiles;
            antlr4Task.AbstractGrammarFiles = AbstractGrammarFiles;
            antlr4Task.GeneratedSourceExtension = GeneratedSourceExtension;
            antlr4Task.TargetNamespace = TargetNamespace;
            antlr4Task.LanguageSourceExtensions = LanguageSourceExtensions;
            antlr4Task.GenerateListener = GenerateListener;
            antlr4Task.GenerateVisitor = GenerateVisitor;
            antlr4Task.ForceAtn = ForceAtn;
            antlr4Task.AbstractGrammar = AbstractGrammar;
            antlr4Task.JavaVendor = JavaVendor;
            antlr4Task.JavaInstallation = JavaInstallation;
            antlr4Task.JavaExecutable = JavaExecutable;
            //antlr4Task.UseCSharpGenerator = UseCSharpGenerator;
            return antlr4Task.Execute();
        }
    }
}
