//using MetaDslx.BuildTasks;
using MetaDslx.BuildTasks;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.Bootstrap
{
    class Antlr4RoslynBootstrap
    {
        private string _mgenFileName;
        private string _defaultNamespace;

        public Antlr4RoslynBootstrap(string mgenFileName, string defaultNamespace)
        {
            _mgenFileName = mgenFileName;
            _defaultNamespace = defaultNamespace;
        }

        public void Compile()
        {
            if (!File.Exists(_mgenFileName))
            {
                Console.WriteLine("File does not exist: {0}", _mgenFileName);
                return;
            }
            try
            {
                //throw new NotImplementedException();
                Antlr4BuildTool antlr4BuildTool = new Antlr4BuildTool();
                antlr4BuildTool.UseCSharpGenerator = true;
                antlr4BuildTool.ToolPath = @"c:\Users\Balazs\.nuget\packages\metadslx.buildtasks\0.10.211\tools\netstandard2.0";
                Antlr4RoslynCompiler compiler = new Antlr4RoslynCompiler(_mgenFileName, Path.GetDirectoryName(_mgenFileName), Path.GetDirectoryName(_mgenFileName), _defaultNamespace, antlr4BuildTool);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
