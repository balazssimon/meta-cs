using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundEnumValue : BoundValue
    {
        private string _name;
        private Type _enumType;

        public BoundEnumValue(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, string name, Type enumType, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, null, hasErrors)
        {
            _name = name;
            _enumType = enumType;
        }
    }
}
