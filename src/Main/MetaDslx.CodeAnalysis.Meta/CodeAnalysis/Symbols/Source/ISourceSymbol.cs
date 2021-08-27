using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public interface ISourceSymbol
    {
        SymbolFactory SymbolFactory { get; }
        MergedDeclaration MergedDeclaration { get; }
        ImmutableArray<Diagnostic> Diagnostics { get; }
        BinderPosition<SymbolBinder> GetBinder(SyntaxReference syntax);
        Symbol GetChildSymbol(SyntaxReference syntax);
    }
}
