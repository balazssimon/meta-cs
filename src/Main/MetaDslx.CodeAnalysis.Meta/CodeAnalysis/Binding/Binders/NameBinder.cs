using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class NameBinder : Binder
    {
        /*private LanguageSyntaxNode _syntax;
        private BoundName _lazyBoundNode;*/

        public NameBinder(Binder next/*, LanguageSyntaxNode syntax*/) 
            : base(next)
        {
            //_syntax = syntax;
        }
        /*
        public BoundName BoundNode
        {
            get
            {
                if (_lazyBoundNode == null)
                {
                    var boundNodes = this.Compilation.GetBoundNodes(_syntax).OfType<BoundName>();
                    Interlocked.CompareExchange(ref _lazyBoundNode, boundNodes.FirstOrDefault(), null);
                }
                return _lazyBoundNode;
            }
        }

        public override NamespaceOrTypeSymbol GetQualifierOpt(SyntaxNodeOrToken syntax)
        {
            return base.GetQualifierOpt(syntax);
        }*/
    }
}
