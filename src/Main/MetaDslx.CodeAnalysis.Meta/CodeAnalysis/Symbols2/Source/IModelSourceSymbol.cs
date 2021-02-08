using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public interface IModelSourceSymbol : IModelSymbol
    {
        ImmutableArray<Diagnostic> Diagnostics { get; }
        BinderPosition<SymbolDefBinder> GetBinder(SyntaxReference syntax);
        Symbol GetChildSymbol(SyntaxReference syntax);
    }
}
