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
        private BoundQualifier _lazyBoundNode;

        public QualifierBinder(Binder next, LanguageSyntaxNode syntax) 
            : base(next)
        {
            _syntax = syntax;
        }

        public BoundQualifier BoundNode
        {
            get
            {
                if (_lazyBoundNode == null)
                {
                    var boundNode = this.Compilation.GetBoundNode<BoundQualifier>(_syntax);
                    Interlocked.CompareExchange(ref _lazyBoundNode, boundNode, null);
                }
                return _lazyBoundNode;
            }
        }

    }
}
