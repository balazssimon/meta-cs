using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaNamespaceSymbol : ModelNamespaceSymbol
    {
        private IModelObject _modelObject;

        public MetaNamespaceSymbol(IModelObject metaObject, Symbol container)
            : base(container)
        {
            if (metaObject == null) throw new ArgumentNullException(nameof(metaObject));
            _modelObject = metaObject;
        }

        public override IModelObject ModelObject => _modelObject;
    }
}
