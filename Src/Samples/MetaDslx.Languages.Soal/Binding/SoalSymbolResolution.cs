using MetaDslx.Compiler.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Core;
using MetaDslx.Languages.Soal.Symbols;
using System.Collections.Immutable;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Languages.Soal.Binding
{
    public class SoalSymbolResolution : SymbolResolution
    {
        public SoalSymbolResolution(SoalCompilation compilation) : base(compilation)
        {
        }



        public override IMetaSymbol GetWellKnownSymbol(string name)
        {
            foreach (var symbol in SoalSymbolFacts.WellKnownTypes)
            {
                if (symbol.MName == name) return symbol;
            }
            return null;
        }
    }
}
