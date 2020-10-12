using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.PooledObjects;
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
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
        private ArrayBuilder<Antlr4Message> _diagnostics = new ArrayBuilder<Antlr4Message>();

        public Antlr4Tool()
        {
            this.TimeoutInSeconds = 30;
            this.Encoding = "UTF-8";
            this.TargetLanguage = "CSharp";
            this.LanguageSourceExtensions = new string[] { ".cs", ".tokens", ".interp" };
            this.Diagnostics = ImmutableArray<Antlr4Message>.Empty;
        }

        public IList<string> GeneratedCodeFiles
        {
            get
            {
                return this._generatedCodeFiles;
            }
        }

        public int TimeoutInSeconds { get; set; }
        public string JavaExe { get; set; }
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

        public IList<string> SourceCodeFiles
        {
            get
            {
                return this._sourceCodeFiles;
            }
        }

        public ImmutableArray<Antlr4Message> Diagnostics { get; private set; }

        public bool Execute()
        {
            bool result = this.DoExecute();
            this.Diagnostics = _diagnostics.ToImmutable();
            return result;
        }

        protected abstract bool DoExecute();

        protected void AddDiagnostic(DiagnosticSeverity severity, int errorCode, string filePath, int line, int column, string message)
        {
            var diag = new Antlr4Message(severity, errorCode, filePath, line, column, message);
            _diagnostics.Add(diag);
        }

        public class Antlr4Message
        {
            public readonly DiagnosticSeverity Severity;
            public readonly int ErrorCode;
            public readonly string FilePath;
            public readonly int Line;
            public readonly int Column;
            public readonly string Message;

            public Antlr4Message(DiagnosticSeverity severity, int errorCode, string filePath, int line, int column, string message)
            {
                Severity = severity;
                ErrorCode = errorCode;
                FilePath = filePath;
                Line = line;
                Column = column;
                Message = message;
            }
        }
    }

}
