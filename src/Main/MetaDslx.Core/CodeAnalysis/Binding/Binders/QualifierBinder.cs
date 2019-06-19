using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class QualifierBinder : Binder
    {
        private LanguageSyntaxNode _syntax;
        private BoundQualifierOrIdentifier _lazyBoundNode;

        public QualifierBinder(Binder next, LanguageSyntaxNode syntax) 
            : base(next)
        {
            _syntax = syntax;
        }

        public BoundQualifierOrIdentifier BoundNode
        {
            get
            {
                if (_lazyBoundNode == null)
                {
                    var boundNodes = this.Compilation.GetBoundNodes(_syntax).OfType<BoundQualifierOrIdentifier>();
                    Interlocked.CompareExchange(ref _lazyBoundNode, boundNodes.FirstOrDefault(), null);
                }
                return _lazyBoundNode;
            }
        }

        public override NamespaceOrTypeSymbol GetQualifierOpt(SyntaxNodeOrToken syntax)
        {
            var identifiers = this.BoundNode.Identifiers;
            Symbol symbol = null;
            foreach (var identifier in identifiers)
            {
                var previousSymbol = symbol as NamespaceOrTypeSymbol;
                if (identifier.Syntax == syntax) return previousSymbol;
                symbol = identifier.Symbol;
            }
            return null;
        }
    }
}
