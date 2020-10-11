using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Symbols
{
    public class CustomMetaSymbolFacts : MetaSymbolFacts
    {
        public override IEnumerable<IModelObject> GetBuiltInObjects()
        {
            return MetaConstants.Types;
        }
    }
}
