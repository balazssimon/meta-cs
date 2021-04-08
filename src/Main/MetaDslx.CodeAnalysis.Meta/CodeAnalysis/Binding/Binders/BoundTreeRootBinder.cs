using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class BoundTreeRootBinder : Binder
    {
        private BoundNode _boundRoot;

        public BoundTreeRootBinder(Binder next, SyntaxNodeOrToken syntax, BoundNode boundRoot) 
            : base(next, syntax)
        {
            Debug.Assert(boundRoot != null);
            _boundRoot = boundRoot;
        }

        protected override BoundNode BindNode(CancellationToken cancellationToken)
        {
            return _boundRoot;
        }
    }
}
