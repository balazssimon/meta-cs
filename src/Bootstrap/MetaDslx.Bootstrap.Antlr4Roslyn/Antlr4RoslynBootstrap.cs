using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;

namespace MetaDslx.Bootstrap.Antlr4Roslyn
{ 
    public class Antlr4RoslynBootstrap
    {
        private string _grammarFileName;
        private string _namespaceName;

        public Antlr4RoslynBootstrap(string grammarFileName, string namespaceName)
        {
            _grammarFileName = grammarFileName;
            _namespaceName = namespaceName;
        }

        public void Compile()
        {
            if (!File.Exists(_grammarFileName))
            {
                Console.WriteLine("File does not exist: {0}", _grammarFileName);
                return;
            }
            try
            {
                Antlr4RoslynCompiler compiler = new Antlr4RoslynCompiler(Path.GetDirectoryName(_grammarFileName), null, _grammarFileName, _namespaceName, new Antlr4BuildTool());
                compiler.Compile();
                if (compiler.HasErrors)
                {
                    DiagnosticFormatter formatter = new DiagnosticFormatter();
                    foreach (var message in compiler.GetDiagnostics())
                    {
                        Console.WriteLine(formatter.Format(message));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
