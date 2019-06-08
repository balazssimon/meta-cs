using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class PropertyBinder : Binder
    {
        private readonly string _propertyName;
        private readonly Optional<object> _propertyValueOpt;
        private ImmutableArray<object> _lazyValues;

        public PropertyBinder(Binder next, SyntaxNodeOrToken syntax, string propertyName, Optional<object> propertyValueOpt)
            : base(next, syntax)
        {
            _propertyName = propertyName;
            _propertyValueOpt = propertyValueOpt;
            if (_propertyValueOpt.HasValue)
            {
                _lazyValues = ImmutableArray.Create(_propertyValueOpt.Value);
            }
            else
            {
                _lazyValues = default(ImmutableArray<object>);
            }
        }
    }
}
