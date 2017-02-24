using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IPropertyBinder
    {
        string PropertyName { get; }
        Optional<object> PropertyValueOpt { get; }
        object Value { get; }
        ImmutableArray<object> GetValues();
        ImmutableArray<Diagnostic> GetErrors();
    }

    public sealed class PropertyBinder : Binder, IPropertyBinder
    {
        private readonly string _propertyName;
        private readonly Optional<object> _propertyValueOpt;
        private ImmutableArray<object> _lazyValues;

        public PropertyBinder(Binder next, RedNode node, string propertyName, Optional<object> propertyValueOpt) 
            : base(next, node)
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

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public Optional<object> PropertyValueOpt
        {
            get { return _propertyValueOpt; }
        }

        public object Value
        {
            get
            {
                return this.GetValues().FirstOrDefault();
            }
        }

        public ImmutableArray<object> GetValues()
        {
            if (_lazyValues.IsDefault)
            {
                var valueBinders = this.FindDescendantBinders<IValueBinder>(vb => true, b => b is IPropertyBinder);
                var values = valueBinders.SelectMany(v => v.GetValues()).ToImmutableArray();
                ImmutableInterlocked.InterlockedExchange(ref _lazyValues, values);
            }
            return _lazyValues;
        }

        public ImmutableArray<Diagnostic> GetErrors()
        {
            var valueBinders = this.FindDescendantBinders<IValueBinder>(vb => true, b => b is IPropertyBinder);
            var errors = valueBinders.SelectMany(v => v.GetErrors()).ToImmutableArray();
            return errors;
        }
    }
}
