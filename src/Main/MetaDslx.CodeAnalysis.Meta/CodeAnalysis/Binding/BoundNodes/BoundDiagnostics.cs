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

        public BoundDiagnostics(SyntaxNodeOrToken syntax, BoundNode parent, ImmutableArray<Diagnostic> diagnostics) 
            : base(syntax, parent)
        {
            _diagnostics = diagnostics;
        }

        public override ImmutableArray<Diagnostic> Diagnostics => _diagnostics;
    }
}
