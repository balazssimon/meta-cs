using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using Microsoft.CodeAnalysis.CSharp.Symbols.Metadata.PE;
    using Roslyn.Utilities;
    using System.Collections.Concurrent;
    using System.Globalization;
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;

    public class CSharpAssemblySymbol : NonMissingAssemblySymbol
    {
        /// <summary>
        /// The underlying AssemblySymbol, it leaks symbols that should be retargeted.
        /// This cannot be an instance of RetargetingAssemblySymbol.
        /// </summary>
        private readonly CSharpSymbols.AssemblySymbol _underlyingAssembly;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="underlyingAssembly">
        /// The underlying AssemblySymbol, cannot be an instance of CSharpAssemblySymbol.
        /// </param>
        internal CSharpAssemblySymbol(CSharpSymbols.AssemblySymbol underlyingAssembly)
        {
            Debug.Assert((object)underlyingAssembly != null);

            _underlyingAssembly = underlyingAssembly;

            ModuleSymbol[] modules = new ModuleSymbol[underlyingAssembly.Modules.Length];

            modules[0] = new CSharpModuleSymbol(this, underlyingAssembly.Modules[0], 0);

            for (int i = 1; i < underlyingAssembly.Modules.Length; i++)
            {
                PEModuleSymbol under = (PEModuleSymbol)underlyingAssembly.Modules[i];
                modules[i] = new CSharpModuleSymbol(this, new PEModuleSymbol((PEAssemblySymbol)this._underlyingAssembly, under.Module, under.ImportOptions, i), i);
            }

            _modules = modules.AsImmutableOrNull();
        }

        private CSharpSymbolMap CSharpSymbolMap
        {
            get
            {
                return ((CSharpModuleSymbol)_modules[0]).CSharpSymbolMap;
            }
        }

        /// <summary>
        /// The underlying AssemblySymbol.
        /// This cannot be an instance of CSharpAssemblySymbol.
        /// </summary>
        internal CSharpSymbols.AssemblySymbol CSharpAssembly => _underlyingAssembly;

        /// <summary>
        /// The list of contained ModuleSymbol objects. First item in the list
        /// is RetargetingModuleSymbol that wraps corresponding SourceModuleSymbol 
        /// from underlyingAssembly.Modules list, the rest are PEModuleSymbols for 
        /// added modules.
        /// </summary>
        private readonly ImmutableArray<ModuleSymbol> _modules;

        /// <summary>
        /// An array of assemblies involved in canonical type resolution of
        /// NoPia local types defined within this assembly. In other words, all 
        /// references used by a compilation referencing this assembly.
        /// The array and its content is provided by ReferenceManager and must not be modified.
        /// </summary>
        private ImmutableArray<AssemblySymbol> _noPiaResolutionAssemblies;

        /// <summary>
        /// An array of assemblies referenced by this assembly, which are linked (/l-ed) by 
        /// each compilation that is using this AssemblySymbol as a reference. 
        /// If this AssemblySymbol is linked too, it will be in this array too.
        /// The array and its content is provided by ReferenceManager and must not be modified.
        /// </summary>
        private ImmutableArray<AssemblySymbol> _linkedReferencedAssemblies;

        /// <summary>
        /// Backing field for the map from a local NoPia type to corresponding canonical type.
        /// </summary>
        private ConcurrentDictionary<NamedTypeSymbol, NamedTypeSymbol> _noPiaUnificationMap;

        /// <summary>
        /// A map from a local NoPia type to corresponding canonical type.
        /// </summary>
        internal ConcurrentDictionary<NamedTypeSymbol, NamedTypeSymbol> NoPiaUnificationMap =>
            LazyInitializer.EnsureInitialized(ref _noPiaUnificationMap, () => new ConcurrentDictionary<NamedTypeSymbol, NamedTypeSymbol>(concurrencyLevel: 2, capacity: 0));

        /// <summary>
        /// Retargeted custom attributes
        /// </summary>
        private ImmutableArray<AttributeData> _lazyCustomAttributes;

        public override bool IsImplicitlyDeclared
        {
            get { return _underlyingAssembly.IsImplicitlyDeclared; }
        }

        public override AssemblyIdentity Identity
        {
            get
            {
                return _underlyingAssembly.Identity;
            }
        }

        public override Version AssemblyVersionPattern => _underlyingAssembly.AssemblyVersionPattern;

        internal override ImmutableArray<byte> PublicKey
        {
            get { return _underlyingAssembly.PublicKey; }
        }

        public override string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _underlyingAssembly.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);
        }

        public override ImmutableArray<ModuleSymbol> Modules
        {
            get
            {
                return _modules;
            }
        }

        internal override bool KeepLookingForDeclaredSpecialTypes
        {
            get
            {
                // RetargetingAssemblySymbol never represents Core library. 
                return false;
            }
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return _underlyingAssembly.Locations;
            }
        }

        internal override IEnumerable<ImmutableArray<byte>> GetInternalsVisibleToPublicKeys(string simpleName)
        {
            return _underlyingAssembly.GetInternalsVisibleToPublicKeys(simpleName);
        }

        internal override bool AreInternalsVisibleToThisAssembly(AssemblySymbol other)
        {
            if (other is CSharpAssemblySymbol csharpAssembly) return _underlyingAssembly.AreInternalsVisibleToThisAssembly(csharpAssembly.CSharpAssembly);
            else return false; // TODO:MetaDslx?
        }

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            return CSharpSymbolMap.GetAttributes(_underlyingAssembly.GetAttributes(), ref _lazyCustomAttributes);
        }

        /// <summary>
        /// Lookup declaration for FX type in this Assembly.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        internal override NamedTypeSymbol GetDeclaredSpecialType(SpecialType type)
        {
            // Cor library should not have any references and, therefore, should never be
            // wrapped by a RetargetingAssemblySymbol.
            throw ExceptionUtilities.Unreachable;
        }

        internal override ImmutableArray<AssemblySymbol> GetNoPiaResolutionAssemblies()
        {
            return _noPiaResolutionAssemblies;
        }

        internal override void SetNoPiaResolutionAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            _noPiaResolutionAssemblies = assemblies;
        }

        internal override void SetLinkedReferencedAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            _linkedReferencedAssemblies = assemblies;
        }

        internal override ImmutableArray<AssemblySymbol> GetLinkedReferencedAssemblies()
        {
            return _linkedReferencedAssemblies;
        }

        public override bool IsLinked
        {
            get
            {
                return _underlyingAssembly.IsLinked;
            }
        }

        public override ICollection<string> TypeNames
        {
            get
            {
                return _underlyingAssembly.TypeNames;
            }
        }

        public override ICollection<string> NamespaceNames
        {
            get
            {
                return _underlyingAssembly.NamespaceNames;
            }
        }

        public override bool MightContainExtensionMethods
        {
            get
            {
                return _underlyingAssembly.MightContainExtensionMethods;
            }
        }

        internal sealed override LanguageCompilation DeclaringCompilation // perf, not correctness
        {
            get { return null; }
        }

        internal override bool GetGuidString(out string guidString)
        {
            return _underlyingAssembly.GetGuidString(out guidString);
        }

        internal override NamedTypeSymbol TryLookupForwardedMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies)
        {
            return CSharpSymbolMap.GetNamedTypeSymbol(_underlyingAssembly.TryLookupForwardedMetadataType(ref emittedName));
        }

        public override AssemblyMetadata GetMetadata() => _underlyingAssembly.GetMetadata();
    }
}
