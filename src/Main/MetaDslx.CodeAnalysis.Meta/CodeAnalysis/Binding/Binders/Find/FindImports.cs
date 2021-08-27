using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal class FindImports : FindBinderDescendants<ImportBinder>
    {
        public FindImports(BinderPosition origin)
            : base(origin)
        {
        }

        public override bool IsValidBinder(ImportBinder binder)
        {
            return true;
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            return binder is ISymbolBoundary;
        }
    }
}
