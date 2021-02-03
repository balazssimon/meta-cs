using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public struct BoundNode
    {
        private Symbol _symbol;
        private SyntaxNodeOrToken _syntax;

        public BoundNode(Symbol symbol, SyntaxNodeOrToken syntax)
        {
            _symbol = symbol;
            _syntax = syntax;
        }

        public Symbol Symbol => _symbol;
        public SyntaxNodeOrToken Syntax => _syntax;
    }
}
