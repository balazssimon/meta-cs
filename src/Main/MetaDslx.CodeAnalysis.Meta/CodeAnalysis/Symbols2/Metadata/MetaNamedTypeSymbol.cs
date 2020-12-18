using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaNamedTypeSymbol : ModelNamedTypeSymbol
    {
        private IModelObject _modelObject;

        public MetaNamedTypeSymbol(IModelObject metaObject, Symbol container)
            : base(container)
        {
            Debug.Assert(metaObject != null);
            _modelObject = metaObject;
        }

        public override IModelObject ModelObject => _modelObject;

    }
}
