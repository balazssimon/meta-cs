using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public partial class MetadataModuleSymbol
    {
        public MetadataModuleSymbol(AssemblySymbol owningAssembly, object model, int ordinal)
            : base(owningAssembly, model, ordinal)
        {
        }
    }
}
