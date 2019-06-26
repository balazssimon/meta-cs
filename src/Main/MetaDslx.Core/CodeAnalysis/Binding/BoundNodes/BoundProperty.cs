using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundProperty : BoundValues
    {
        private string _name;
        private bool _hasFixedValue;
        private ImmutableArray<object> _values;
        private ImmutableArray<BoundValues> _boundValues;

        public BoundProperty(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, string name, Optional<object> valueOpt, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _name = name;
            _hasFixedValue = valueOpt.HasValue;
            _values = valueOpt.HasValue ? ImmutableArray.Create(valueOpt.Value) : default;
        }

        public string Name => _name;

        public override ImmutableArray<object> Values
        {
            get
            {
                if (_values.IsDefault)
                {
                    var valueNodes = this.BoundValues;
                    ImmutableInterlocked.InterlockedInitialize(ref _values, valueNodes.SelectMany(node => node.Values).ToImmutableArray());
                }
                return _values;
            }
        }

        public ImmutableArray<BoundValues> BoundValues
        {
            get
            {
                if (_boundValues.IsDefault)
                {
                    var valueNodes = this.GetValues(_name, _name);
                    ImmutableInterlocked.InterlockedInitialize(ref _boundValues, valueNodes);
                }
                return _boundValues;
            }
        }

        public override void AddProperties(ArrayBuilder<BoundProperty> properties, string property = null)
        {
            if (property == null || property == _name)
            {
                properties.Add(this);
            }
            foreach (var child in ChildBoundNodes)
            {
                child.AddProperties(properties, property);
            }
        }

        public override void AddValues(ArrayBuilder<BoundValues> values, string currentProperty = null, string rootProperty = null)
        {
            if (_hasFixedValue && rootProperty == _name)
            {
                values.Add(this);
            }
            foreach (var child in ChildBoundNodes)
            {
                child.AddValues(values, _name, rootProperty);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name + " = [");
            var values = this.Values;
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
