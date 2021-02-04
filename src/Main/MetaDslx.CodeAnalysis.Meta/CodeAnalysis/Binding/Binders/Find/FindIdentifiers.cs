using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders.Find
{
    public class FindIdentifiers : FindBinderDescendants<IdentifierBinder>
    {
        public FindIdentifiers(BinderPosition origin) 
            : base(origin)
        {
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            return binder is IdentifierBinder;
        }
    }
}
