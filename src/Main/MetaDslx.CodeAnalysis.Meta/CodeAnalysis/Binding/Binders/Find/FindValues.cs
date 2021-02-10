using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders.Find
{
    public class FindValues : FindBinderDescendants<ValueBinder>
    {
        public FindValues(BinderPosition origin) 
            : base(origin)
        {
        }

        public override bool IsValidBinder(ValueBinder binder)
        {
            if (binder is PropertyBinder propertyBinder)
            {
                if (propertyBinder.PropertyValueOpt.HasValue) return propertyBinder == this.Origin.Binder;
                else return false;
            }
            return true;
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            if (binder is PropertyBinder propertyBinder)
            {
                if (propertyBinder.PropertyValueOpt.HasValue) return propertyBinder == this.Origin.Binder;
                else return propertyBinder != this.Origin.Binder;
            }
            return binder is IValueBoundary || binder is ISymbolBoundary;
        }
    }
}
