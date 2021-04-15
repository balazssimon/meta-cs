using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class PropertyBinder : ValueBinder
    {
        private readonly string _propertyName;
        private readonly Optional<object> _propertyValueOpt;
        private SymbolPropertyOwner _owner;
        private Type _ownerType;

        public PropertyBinder(Binder next, SyntaxNodeOrToken syntax, string propertyName, Optional<object> propertyValueOpt, SymbolPropertyOwner owner, Type ownerType)
            : base(next, syntax)
        {
            _propertyName = propertyName;
            _propertyValueOpt = propertyValueOpt;
            _owner = owner;
            _ownerType = ownerType;
        }

        public string PropertyName => _propertyName;

        public Optional<object> PropertyValueOpt => _propertyValueOpt;

        protected override object ComputeValue()
        {
            return _propertyValueOpt.Value;
        }

        public override string ToString()
        {
            return $"PropertyBinder: {PropertyName}";
        }
    }
}
