using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaMemberSymbol : ModelMemberSymbol
    {
        private IModelObject _modelObject;

        public MetaMemberSymbol(IModelObject metaObject, Symbol container)
            : base(container)
        {
            if (metaObject == null) throw new ArgumentNullException(nameof(metaObject));
            _modelObject = metaObject;
        }

        public override IModelObject ModelObject => _modelObject;

    }
}
