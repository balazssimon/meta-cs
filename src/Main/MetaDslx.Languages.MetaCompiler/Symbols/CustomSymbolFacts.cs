using MetaDslx.Languages.MetaCompiler.Model;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.MetaCompiler.Symbols
{
    public class CustomSymbolFacts : MetaCompilerSymbolFacts
    {
        public override IEnumerable<IModelObject> GetBuiltInObjects()
        {
            yield return MetaCompilerInstance.None;
            yield return MetaCompilerInstance.All;
        }
    }
}
