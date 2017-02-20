using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IPropertyBinder
    {
        string PropertyName { get; }
        Optional<object> PropertyValueOpt { get; }
    }

    public sealed class PropertyBinder : Binder, IPropertyBinder
    {
        private readonly string _propertyName;
        private readonly Optional<object> _propertyValueOpt;
        private object _lazyValue;

        public PropertyBinder(Binder next, RedNode node, string propertyName, Optional<object> propertyValueOpt) 
            : base(next, node)
        {
            _propertyName = propertyName;
            _propertyValueOpt = propertyValueOpt;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public Optional<object> PropertyValueOpt
        {
            get { return _propertyValueOpt; }
        }

    }
}
