﻿using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta.Binding
{
    public class StatementSymbolBinder : UseBinder
    {
        public StatementSymbolBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax, ImmutableArray.Create(typeof(StatementSymbol)), null, "StatementSymbol")
        {
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return base.BindNode(diagnostics, cancellationToken);
        }
    }
}