using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaModuleSymbol : ModelModuleSymbol
    {
        public MetaModuleSymbol(AssemblySymbol owningAssembly, ImmutableArray<IModel> models, int ordinal)
            : base(owningAssembly, models, ordinal)
        {
        }

        public MetaModuleSymbol(AssemblySymbol owningAssembly, IModelGroup modelGroup, int ordinal)
            : base(owningAssembly, modelGroup, ordinal)
        {
        }

    }
}
