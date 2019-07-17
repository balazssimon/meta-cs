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
        private object _value;
        private ImmutableArray<BoundValues> _boundValues;

        public BoundProperty(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, string name, Optional<object> valueOpt, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _name = name;
            _hasFixedValue = valueOpt.HasValue;
            _value = valueOpt.HasValue ? valueOpt.Value : default;
        }

        public string Name => _name;

        public object Value => _value;

        public bool HasFixedValue => _hasFixedValue;

        public override ImmutableArray<object> Values
        {
            get
            {
                return _hasFixedValue ? ImmutableArray.Create(_value) : ImmutableArray<object>.Empty;
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
            if (_hasFixedValue || property == _name)
            {
                foreach (var child in ChildBoundNodes)
                {
                    child.AddProperties(properties, property);
                }
            }
        }

        public override void AddValues(ArrayBuilder<BoundValues> values, string currentProperty = null, string rootProperty = null)
        {
            if (_hasFixedValue && rootProperty == _name)
            {
                values.Add(this);
            }
            if (_hasFixedValue || currentProperty == rootProperty)
            {
                foreach (var child in ChildBoundNodes)
                {
                    child.AddValues(values, _name, rootProperty);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name + " = [");
            var values = this.BoundValues.SelectMany(bv => bv.Values).ToArray();
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
