using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders.Find
{
    public class FindCompilationUnitRoot : FindBinderAncestors<Binder>
    {
        public FindCompilationUnitRoot(BinderPosition origin)
            : base(origin)
        {
        }

        public override bool IsValidBinder(Binder binder)
        {
            return !binder.Syntax.IsNull;
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            return binder.Syntax.IsNull;
        }
    }
}
