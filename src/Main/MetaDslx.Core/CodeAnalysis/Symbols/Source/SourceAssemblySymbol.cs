using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an assembly built by compiler.
    /// </summary>
    internal sealed partial class SourceAssemblySymbol : AssemblySymbol, IAttributeTargetSymbol
    {
        /// <summary>
        /// A Compilation the assembly is created for.
        /// </summary>
        private readonly LanguageCompilation _compilation;

        private SymbolCompletionState _state;

        /// <summary>
        /// Assembly's identity.
        /// </summary>
        internal AssemblyIdentity lazyAssemblyIdentity;
        private readonly Microsoft.CodeAnalysis.CSharp.Symbols.SourceAssemblySymbol _csharpAssemblySymbol;

        /// <summary>
        /// A list of modules the assembly consists of. 
        /// The first (index=0) module is a SourceModuleSymbol, which is a primary module, the rest are net-modules.
        /// </summary>
        private readonly ImmutableArray<ModuleSymbol> _modules;

        private IDictionary<string, NamedTypeSymbol> _lazyForwardedTypesFromSource;

        /// <summary>
        /// The warnings for unused fields.
        /// </summary>
        private ImmutableArray<Diagnostic> _unusedFieldWarnings;

        internal SourceAssemblySymbol(
            LanguageCompilation compilation,
            Microsoft.CodeAnalysis.CSharp.Symbols.SourceAssemblySymbol csharpAssemblySymbol)
        {
            Debug.Assert(compilation != null);
            _compilation = compilation;
            _csharpAssemblySymbol = csharpAssemblySymbol;

            ArrayBuilder<ModuleSymbol> moduleBuilder = new ArrayBuilder<ModuleSymbol>(_csharpAssemblySymbol.Modules.Length);

            moduleBuilder.Add(new SourceModuleSymbol(this, compilation.Declarations, _csharpAssemblySymbol.Modules[0].Name));
            for (int i = 1; i < _csharpAssemblySymbol.Modules.Length; i++)
            {
                moduleBuilder.Add(WrappedCSharpModuleSymbol.Create(this, _csharpAssemblySymbol.Modules[i], i));
            }

            _modules = moduleBuilder.ToImmutableAndFree();
        }

        public override string Name
        {
            get
            {
                return _csharpAssemblySymbol.Name;
            }
        }

        /// <remarks>
        /// This override is essential - it's a base case of the recursive definition.
        /// </remarks>
        internal sealed override LanguageCompilation DeclaringCompilation
        {
            get
            {
                return _compilation;
            }
        }

        public override bool IsInteractive
        {
            get
            {
                return _compilation.IsSubmission;
            }
        }

        public override AssemblyIdentity Identity
        {
            get
            {
                if (lazyAssemblyIdentity == null)
                    Interlocked.CompareExchange(ref lazyAssemblyIdentity, ComputeIdentity(), null);

                return lazyAssemblyIdentity;
            }
        }

        private AssemblyIdentity ComputeIdentity()
        {
            return new AssemblyIdentity(_csharpAssemblySymbol.Name);
        }

    }
}
