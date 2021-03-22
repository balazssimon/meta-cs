using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundImport : BoundNode
    {
        private Imports _imports;

        public BoundImport(BoundNode parent, SyntaxNodeOrToken syntax)
            : base(parent, syntax)
        {
            _imports = Imports.Empty;
        }

        public Imports Imports => _imports;
    }
}
