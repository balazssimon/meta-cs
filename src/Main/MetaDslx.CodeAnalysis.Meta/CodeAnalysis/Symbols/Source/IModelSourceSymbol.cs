using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public interface IModelSourceSymbol : IModelSymbol
    {
        ImmutableArray<Diagnostic> Diagnostics { get; }
        BinderPosition<SymbolBinder> GetBinder(SyntaxReference syntax);
        Symbol GetChildSymbol(SyntaxReference syntax);
    }
}
