using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class PropertyBinder : SymbolBinder
    {
        private string _propertyName;
        private Optional<object> _propertyValue;

        public PropertyBinder(Binder next, string propertyName, Optional<object> propertyValue) : base(next)
        {
            _propertyName = propertyName;
            _propertyValue = propertyValue;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object PropertyValue
        {
            get
            {
                if (_propertyValue.HasValue)
                {
                    return _propertyValue.Value;
                }
                else
                {

                }
            }
        }

        public override bool AddPropertyBinder(ArrayBuilder<ISymbolBinder> result)
        {
            result.Add(this);
            return true;
        }

        public override bool AddValueBinder(ArrayBuilder<ISymbolBinder> result)
        {
            return true;
        }
    }
}
