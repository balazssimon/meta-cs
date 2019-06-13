using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbol : BoundNode
    {
        private readonly Symbol _symbol;

        protected BoundSymbol(BoundKind kind, BoundTree boundTree, BoundNodeFlags nodeFlags, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, nodeFlags, syntax, hasErrors)
        {
        }

        public Symbol Symbol => _symbol;

        protected override void ForceCompleteNode(CancellationToken cancellationToken)
        {
            _symbol.ForceComplete(null, cancellationToken);
        }

    }
}
