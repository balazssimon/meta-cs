using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.Bootstrap
{
    public class MetaGeneratorBootstrap
    {
        private string _mgenFileName;

        public MetaGeneratorBootstrap(string mgenFileName)
        {
            _mgenFileName = mgenFileName;
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
                MetaGeneratorCompiler compiler = new MetaGeneratorCompiler(Path.GetDirectoryName(_mgenFileName), null, _mgenFileName);
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
