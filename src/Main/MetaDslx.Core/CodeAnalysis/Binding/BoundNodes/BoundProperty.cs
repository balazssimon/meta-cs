using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundProperty : BoundValues
    {
        private string _name;
        private bool _hasFixedValue;
        private object _value;
        private SymbolPropertyOwner _owner;
        private Type _ownerType;
        private ImmutableArray<BoundValues> _boundValues;

        public BoundProperty(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, string name, Optional<object> valueOpt, SymbolPropertyOwner owner, Type ownerType, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _name = name;
            _hasFixedValue = valueOpt.HasValue;
            _value = valueOpt.HasValue ? valueOpt.Value : default;
            _owner = owner;
            _ownerType = ownerType;
        }

        public string Name => _name;

        public object Value => _value;

        public SymbolPropertyOwner Owner => _owner;

        public Type OwnerType => _ownerType;

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
                    var valueNodes = this.GetValues(null, this);
                    ImmutableInterlocked.InterlockedInitialize(ref _boundValues, valueNodes);
                }
                return _boundValues;
            }
        }

        /*public override void AddProperties(ArrayBuilder<BoundProperty> properties, string property = null)
        {
            if (_owner == SymbolPropertyOwner.CurrentSymbol)
            {
                if (property == null || property == _name)
                {
                    properties.Add(this);
                }
            }
            foreach (var child in ChildBoundNodes)
            {
                child.AddProperties(properties, property);
            }
        }*/

        public override void AddValues(ArrayBuilder<BoundValues> values, BoundProperty currentProperty = null, BoundProperty rootProperty = null, CancellationToken cancellationToken = default)
        {
            if (_hasFixedValue && rootProperty == this)
            {
                values.Add(this);
                return;
            }
            if (currentProperty == rootProperty || currentProperty == null)
            {
                var nextProperty = currentProperty;
                if (!_hasFixedValue && (currentProperty == null || (this.Owner == currentProperty.Owner && this.OwnerType == currentProperty.OwnerType)))
                {
                    nextProperty = this;
                }
                foreach (var child in ChildBoundNodes)
                {
                    child.AddValues(values, nextProperty, rootProperty);
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
