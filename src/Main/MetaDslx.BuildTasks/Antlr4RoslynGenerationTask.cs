using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class Antlr4RoslynGenerationTask : MetaDslxBuildTask
    {
        public Antlr4RoslynGenerationTask()
            : base("ag4")
        {
        }

        public string JavaExecutable { get; set; }
        public string Antlr4ToolPath { get; set; }
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


        protected override void AddSubArguments(List<string> arguments)
        {
            if (!string.IsNullOrWhiteSpace(JavaExecutable))
            {
                arguments.Add("--java-exe");
                arguments.Add(JavaExecutable);
            }
            if (!string.IsNullOrWhiteSpace(Antlr4ToolPath))
            {
                arguments.Add("--tool-path");
                arguments.Add(Antlr4ToolPath);
            }
            if (!string.IsNullOrWhiteSpace(TargetNamespace))
            {
                arguments.Add("--target-namespace");
                arguments.Add(TargetNamespace);
            }
        }
    }

}
