using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class CustomBinder : PhaseBinder
    {
        public CustomBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion) 
            : base(next, syntax, CompletionGraph.StartCustomBinders, CompletionGraph.FinishCustomBinders, forCompletion)
        {
        }

    }
}
