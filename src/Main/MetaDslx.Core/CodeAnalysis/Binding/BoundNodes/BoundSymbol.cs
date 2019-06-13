using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbol : BoundNode
    {
        private readonly Symbol _symbol;

        protected BoundSymbol(BoundKind kind, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, syntax)
        {
        }

        public Symbol Symbol => _symbol;


    }
}
