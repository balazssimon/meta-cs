using MetaDslx.CodeAnalysis.Binding.Binders;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public struct SourceSymbol
    {
        private Symbol _symbol;

        public SourceSymbol(Symbol symbol)
        {
            _symbol = symbol;
        }

        public SymbolDefBinder GetBinder(SyntaxReference reference)
        {
            Debug.Assert(_symbol.DeclaringSyntaxReferences.Contains(reference));
            var syntax = ResolveSyntaxReference(reference);
            var nodeBinder = _symbol.DeclaringCompilation.GetBinder(syntax);
            return nodeBinder.FindSymbolDefBinder(syntax, _symbol);
        }

        private SyntaxNodeOrToken ResolveSyntaxReference(SyntaxReference reference)
        {
            var node = reference.GetSyntax();
            if (node.Span == reference.Span) return node;
            else return node.FindToken(node.SpanStart);
        }

    }
}
