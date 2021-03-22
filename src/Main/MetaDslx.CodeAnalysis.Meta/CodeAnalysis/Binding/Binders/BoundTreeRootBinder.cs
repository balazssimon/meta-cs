using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class BoundTreeRootBinder : Binder
    {
        private BoundNode _boundRoot;

        public BoundTreeRootBinder(Binder next, SyntaxNodeOrToken syntax, BoundNode boundRoot) 
            : base(next, syntax, null)
        {
            Debug.Assert(boundRoot != null);
            _boundRoot = boundRoot;
        }

        protected override BoundNode CreateBoundNode()
        {
            return _boundRoot;
        }
    }
}
