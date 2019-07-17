using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public interface ISourceDeclarationSymbol
    {
        MergedDeclaration MergedDeclaration { get; }
        ImmutableArray<Symbol> GetDeclaredChildren();
        Symbol GetSourceMember(SyntaxNodeOrToken syntax);
    }
}
