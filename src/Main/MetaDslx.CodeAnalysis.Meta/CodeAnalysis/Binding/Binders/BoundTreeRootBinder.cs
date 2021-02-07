using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class BoundTreeRootBinder : Binder
    {
        private BoundNode _boundRoot;

        public BoundTreeRootBinder(SyntaxNodeOrToken syntax, Binder next, BoundNode boundRoot) 
            : base(syntax, next, null)
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
