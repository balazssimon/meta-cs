﻿using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta.Binding
{
    public class ExpressionSymbolBinder : UseBinder
    {
        public ExpressionSymbolBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion)
            : base(next, syntax, ImmutableArray.Create(typeof(ExpressionSymbol)), false, null, "ExpressionSymbol", forCompletion)
        {
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return base.BindNode(diagnostics, cancellationToken);
        }
    }
}