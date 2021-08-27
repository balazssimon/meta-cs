using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal class FindProperties : FindBinderDescendants<PropertyBinder>
    {
        public FindProperties(BinderPosition origin) 
            : base(origin)
        {
        }

        public override bool IsValidBinder(PropertyBinder binder)
        {
            return true;
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            return binder is ISymbolBoundary;
        }
    }
}
