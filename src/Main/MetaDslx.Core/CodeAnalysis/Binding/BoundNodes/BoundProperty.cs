using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundProperty : BoundNode
    {
        private string _name;
        private Optional<object> _valueOpt;

        public BoundProperty(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, string name, Optional<object> valueOpt, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _name = name;
            _valueOpt = valueOpt;
        }
    }

}
