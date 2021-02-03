using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public partial class Binder
    {
        public virtual SymbolDefBinder FindSymbolDefBinder(SyntaxNodeOrToken syntax, Symbol symbol)
        {
            return Next.FindSymbolDefBinder(syntax, symbol);
        }
    }
}
