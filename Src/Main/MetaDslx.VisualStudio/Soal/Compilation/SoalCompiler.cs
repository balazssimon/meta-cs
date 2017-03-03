using MetaDslx.Compiler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Soal.Compilation
{
    public class SoalCompiler
    {
        public SoalCompiler(string source, string defaultNamespace, string inputDirectory, string outputDirectory, string fileName)
        {
        }

        public void Compile()
        {

        }

        public ImmutableArray<Diagnostic> GetDiagnostics()
        {
            return ImmutableArray<Diagnostic>.Empty;
        }
    }
}
