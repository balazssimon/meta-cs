using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundDiagnostics : BoundNode
    {
        private ImmutableArray<Diagnostic> _diagnostics;

        public BoundDiagnostics(BoundNode parent, SyntaxNodeOrToken syntax, ImmutableArray<Diagnostic> diagnostics) 
            : base(parent, syntax)
        {
            _diagnostics = diagnostics;
        }

        public override ImmutableArray<Diagnostic> Diagnostics => _diagnostics;
    }
}
