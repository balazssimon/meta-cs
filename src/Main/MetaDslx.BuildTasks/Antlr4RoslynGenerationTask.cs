using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
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
        public string[] LanguageSourceExtensions { get; set; }
        public bool GenerateListener { get; set; }
        public bool GenerateVisitor { get; set; }
        public bool ForceAtn { get; set; }
        public bool AbstractGrammar { get; set; }
        public string JavaVendor { get; set; }
        public string JavaInstallation { get; set; }
        public string JavaExecutable { get; set; }
        public bool UseCSharpGenerator { get; set; }

        protected override ICompilerForBuildTask CreateCompiler(string filePath, string outputPath)
        {
            var antlr4Tool = new Antlr4BuildTool();
            antlr4Tool.TimeoutInSeconds = this.TimeoutInSeconds;
            antlr4Tool.ToolPath = this.ToolPath;
            antlr4Tool.TargetLanguage = this.TargetLanguage;
            antlr4Tool.TargetFrameworkVersion = this.TargetFrameworkVersion;
            antlr4Tool.OutputPath = this.OutputPath;
            antlr4Tool.Encoding = this.Encoding;
            antlr4Tool.TargetNamespace = this.TargetNamespace;
            antlr4Tool.LanguageSourceExtensions = this.LanguageSourceExtensions;
            antlr4Tool.GenerateListener = this.GenerateListener;
            antlr4Tool.GenerateVisitor = this.GenerateVisitor;
            antlr4Tool.ForceAtn = this.ForceAtn;
            antlr4Tool.AbstractGrammar = this.AbstractGrammar;
            antlr4Tool.JavaVendor = this.JavaVendor;
            antlr4Tool.JavaInstallation = this.JavaInstallation;
            antlr4Tool.JavaExecutable = this.JavaExecutable;
            antlr4Tool.UseCSharpGenerator = this.UseCSharpGenerator;
            if (this.TimeoutInSeconds == 0) antlr4Tool.TimeoutInSeconds = 30;
            if (string.IsNullOrWhiteSpace(this.Encoding)) antlr4Tool.Encoding = "UTF-8";
            if (string.IsNullOrWhiteSpace(this.TargetLanguage)) antlr4Tool.TargetLanguage = "CSharp";
            if (this.LanguageSourceExtensions == null) antlr4Tool.LanguageSourceExtensions = new string[] { ".cs", ".tokens" };
            return new Antlr4RoslynCompiler(filePath, outputPath, this.TargetNamespace, antlr4Tool);
        }

    }
}
