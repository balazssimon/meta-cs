using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public abstract class CustomBinder : PhaseBinder
    {
        public CustomBinder(Binder next, SyntaxNodeOrToken syntax) 
            : base(next, syntax, CompletionGraph.StartCustomBinders, CompletionGraph.FinishCustomBinders)
        {
        }

    }
}
