using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    using Microsoft.CodeAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
#if !NETSTANDARD
    using RegistryKey = Microsoft.Win32.RegistryKey;
    using RegistryHive = Microsoft.Win32.RegistryHive;
    using RegistryView = Microsoft.Win32.RegistryView;
#endif
    using StringBuilder = System.Text.StringBuilder;

    public abstract class Antlr4Tool
    {
        private List<string> _generatedCodeFiles = new List<string>();
        private IList<string> _sourceCodeFiles = new List<string>();

        public Antlr4Tool()
        {
            this.TimeoutInSeconds = 30;
            this.UseCSharpGenerator = true;
            this.Encoding = "UTF-8";
            this.TargetLanguage = "CSharp";
            this.LanguageSourceExtensions = new string[] { ".cs", ".tokens" };
        }

        public IList<string> GeneratedCodeFiles
        {
            get
            {
                return this._generatedCodeFiles;
            }
        }

        public int TimeoutInSeconds { get; set; }
        public string ToolPath { get; set; }
        public string TargetLanguage { get; set; }
        public string TargetFrameworkVersion { get; set; }
        public string OutputPath { get; set; }
        public string Encoding { get; set; }
        public string TargetNamespace { get; set; }
        public string[] LanguageSourceExtensions { get; set; }
        public bool GenerateListener { get; set; }
        public bool GenerateVisitor { get; set; }
        public bool ForceAtn { get; set; }
        public bool AbstractGrammar { get; set; }
        public string JavaVendor { get; set; }
        public string JavaInstallation { get; set; }
        public string JavaExecutable { get; set; }
        public bool UseCSharpGenerator { get; set; }

        public IList<string> SourceCodeFiles
        {
            get
            {
                return this._sourceCodeFiles;
            }
        }

        public DiagnosticBag Diagnostics { get; set; }

        public abstract bool Execute();
    }

}
