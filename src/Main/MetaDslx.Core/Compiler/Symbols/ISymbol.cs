using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Symbols
{
    public interface ISymbol0 : IMetaSymbol
    {
        string Name { get; }
        string GetKindText();

        /// <summary>
        /// Gets the <see cref="IAssemblySymbol"/> for the containing assembly. Returns null if the
        /// symbol is shared across multiple assemblies.
        /// </summary>
        IAssemblySymbol ContainingAssembly { get; }

    }
}
