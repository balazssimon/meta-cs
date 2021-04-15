using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ModelObjectSymbolPropertyAttribute : Attribute
    {
        private string _propertyName;

        public ModelObjectSymbolPropertyAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }

        public string PropertyName => _propertyName;
    }
}
