using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal class FindNames : FindBinderDescendants<NameBinder>
    {
        public FindNames(BinderPosition origin)
            : base(origin)
        {
        }

        public override bool IsValidBinder(NameBinder binder)
        {
            return true;
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            return binder is IValueBoundary;
        }
    }
}
