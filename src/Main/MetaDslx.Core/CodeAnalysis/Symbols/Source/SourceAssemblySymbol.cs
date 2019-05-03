using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class SourceAssemblySymbol : AssemblySymbol
    {
        /// <summary>
        /// A Compilation the assembly is created for.
        /// </summary>
        private readonly LanguageCompilation _compilation;

        private readonly string _assemblySimpleName;

        /// <summary>
        /// A list of modules the assembly consists of. 
        /// The first (index=0) module is a SourceModuleSymbol, which is a primary module, the rest are net-modules.
        /// </summary>
        private readonly ImmutableArray<ModuleSymbol> _modules;

        internal SourceAssemblySymbol(
            LanguageCompilation compilation,
            string assemblySimpleName,
            string moduleName,
            ImmutableArray<ModuleSymbol> netModules)
        {
            Debug.Assert(compilation != null);
            Debug.Assert(assemblySimpleName != null);
            Debug.Assert(!String.IsNullOrWhiteSpace(moduleName));
            Debug.Assert(!netModules.IsDefault);

            _compilation = compilation;
            _assemblySimpleName = assemblySimpleName;

            ArrayBuilder<ModuleSymbol> moduleBuilder = new ArrayBuilder<ModuleSymbol>(1 + netModules.Length);
            moduleBuilder.Add(new SourceModuleSymbol(this, compilation.Declarations, moduleName));
            moduleBuilder.AddRange(netModules);
            _modules = moduleBuilder.ToImmutableAndFree();
        }
    }
}
