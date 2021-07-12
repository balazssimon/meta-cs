using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Model
{
    public partial class ModelNamespaceSymbol
    {
        public override NamespaceExtent Extent
        {
            get
            {
                if (_container is ModelNamespaceSymbol containingNamespace) return containingNamespace.Extent;
                if (_container is ModuleSymbol containingModule) return new NamespaceExtent(containingModule);
                return new NamespaceExtent(_container.ContainingModule);
            }
        }

    }
}
