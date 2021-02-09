using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public abstract class CustomBinder : PhaseBinder
    {
        public CustomBinder(SyntaxNodeOrToken syntax, Binder next) 
            : base(syntax, next, CompletionPart.StartCustomBinders, CompletionPart.FinishCustomBinders)
        {
        }

        public abstract void Execute(DiagnosticBag diagnostics, CancellationToken cancellationToken);
    }
}
