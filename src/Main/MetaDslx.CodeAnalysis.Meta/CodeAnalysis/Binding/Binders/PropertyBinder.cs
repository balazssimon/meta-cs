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
        private ImmutableArray<object> _lazyValues;
        private SymbolPropertyOwner _owner;
        private Type _ownerType;

        public PropertyBinder(SyntaxNodeOrToken syntax, Binder next, string propertyName, Optional<object> propertyValueOpt, SymbolPropertyOwner owner, Type ownerType)
            : base(syntax, next)
        {
            _propertyName = propertyName;
            _propertyValueOpt = propertyValueOpt;
            _owner = owner;
            _ownerType = ownerType;
            if (_propertyValueOpt.HasValue)
            {
                _lazyValues = ImmutableArray.Create(_propertyValueOpt.Value);
            }
            else
            {
                _lazyValues = default(ImmutableArray<object>);
            }
        }

        public string PropertyName => _propertyName;

        public Optional<object> PropertyValueOpt => _propertyValueOpt;
    }
}
