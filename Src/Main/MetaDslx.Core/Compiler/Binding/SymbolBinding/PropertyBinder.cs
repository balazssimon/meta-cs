using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public struct Property
    {
        private Func<LookupResult<object>, bool> _value;

        public Property(string name, Func<LookupResult<object>, bool> value)
        {
            this.Name = name;
            _value = value;
        }

        public string Name { get; }

        public void GetValue(LookupResult<object> result)
        {
            _value(result);
        }
    }

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

        public Optional<object> PropertyValue
        {
            get { return _propertyValue; }
        }

        public override bool GetProperty(LookupResult<Property> result)
        {
            Property property = new Property(_propertyName, this.GetPropertyValue);
            result.MergeEqual(LookupResult<Property>.Good(property));
            return false;
        }

        public override bool GetValue(LookupResult<object> result)
        {
            return _propertyValue.HasValue;
        }

        protected virtual bool GetPropertyValue(LookupResult<object> result)
        {
            if (_propertyValue.HasValue)
            {
                result.MergeEqual(LookupResult<object>.Good(_propertyValue.Value));
                return true;
            }
            else
            {
                return this.ExecuteSynthesized(binder => binder.GetValue(result));
            }
        }
    }
}
