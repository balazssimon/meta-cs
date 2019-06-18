using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
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

        public string Name => _name;

        public override void AddProperties(ArrayBuilder<string> properties)
        {
            properties.Add(_name);
            if (_valueOpt.HasValue)
            {
                foreach (var child in ChildBoundNodes)
                {
                    child.AddProperties(properties);
                }
            }
        }

        public override void AddValues(string property, ArrayBuilder<object> values)
        {
            if (_valueOpt.HasValue)
            {
                if (property == _name)
                {
                    values.Add(_valueOpt.Value);
                }
            }
            foreach (var child in ChildBoundNodes)
            {
                child.AddValues(property, values);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name + " = [");
            var values = this.GetValues(this.Name);
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(values[i]);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }

}
