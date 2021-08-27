using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta.Binding
{
    public class SymbolSymbolBinder : UseBinder
    {
        public SymbolSymbolBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion) 
            : base(next, syntax, ImmutableArray.Create(typeof(Symbol)), null, "Symbol", forCompletion)
        {
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return base.BindNode(diagnostics, cancellationToken);
        }
    }
}
