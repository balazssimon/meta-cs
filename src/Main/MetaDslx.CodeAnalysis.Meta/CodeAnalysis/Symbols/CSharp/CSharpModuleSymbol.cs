using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using MetaDslx.CodeAnalysis.Symbols.Retargeting;
    using MetaDslx.CodeAnalysis.Symbols.Source;
    using System.Collections.Concurrent;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using System.Runtime.InteropServices;
    using System.Threading;
    using CSharpSymbols = MetaDslx.CodeAnalysis.CSharp.Symbols;

    public class CSharpModuleSymbol : NonMissingModuleSymbol
    {
        private CSharpSymbolMap _csharpSymbolMap;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="assembly">
        /// Owning assembly.
        /// </param>
        /// <param name="underlyingModule">
        /// The underlying ModuleSymbol, cannot be another CSharpModuleSymbol.
        /// </param>
        /// <param name="ordinal">
        /// The index of the ModuleSymbol within the owning assembly.
        /// </param>
        internal CSharpModuleSymbol(AssemblySymbol assembly, CSharpSymbols.ModuleSymbol underlyingModule, int ordinal)
        {
            Debug.Assert((object)assembly != null);
            Debug.Assert((object)underlyingModule != null);

            _csharpAssembly = assembly;
            _underlyingModule = underlyingModule;
            _ordinal = ordinal;
            _csharpSymbolMap = new CSharpSymbolMap(this);
        }

        public override Language Language => CSharpLanguage.Instance;

        internal CSharpSymbols.ModuleSymbol CSharpModule => _underlyingModule;

        internal CSharpSymbolMap CSharpSymbolMap => _csharpSymbolMap;

        /// <summary>
        /// Owning <see cref="AssemblySymbol"/>.
        /// </summary>
        private AssemblySymbol _csharpAssembly;

        /// <summary>
        /// The underlying <see cref="ModuleSymbol"/>, cannot be another <see cref="CSharpModuleSymbol"/>.
        /// </summary>
        private readonly CSharpSymbols.ModuleSymbol _underlyingModule;

        /// <summary>
        /// The map that captures information about what assembly should be retargeted 
        /// to what assembly. Key is the <see cref="AssemblySymbol"/> referenced by the underlying module,
        /// value is the corresponding <see cref="AssemblySymbol"/> referenced by this module, and corresponding
        /// retargeting map for symbols.
        /// </summary>
        private readonly Dictionary<AssemblySymbol, DestinationData> _retargetingAssemblyMap =
            new Dictionary<AssemblySymbol, DestinationData>();

        private struct DestinationData
        {
            public AssemblySymbol To;
            private ConcurrentDictionary<NamedTypeSymbol, NamedTypeSymbol> _symbolMap;

            public ConcurrentDictionary<NamedTypeSymbol, NamedTypeSymbol> SymbolMap => LazyInitializer.EnsureInitialized(ref _symbolMap);
        }

        /// <summary>
        /// Retargeted custom attributes
        /// </summary>
        private ImmutableArray<AttributeData> _lazyCustomAttributes;

        private int _ordinal;

        public PEModule Module => (_underlyingModule as CSharpSymbols.Metadata.PE.PEModuleSymbol)?.Module;

        public override int Ordinal
        {
            get
            {
                return _ordinal;
            }
        }

        public override Machine Machine
        {
            get
            {
                return _underlyingModule.Machine;
            }
        }

        public override bool Bit32Required
        {
            get
            {
                return _underlyingModule.Bit32Required;
            }
        }

        /// <summary>
        /// The underlying ModuleSymbol, cannot be another CSharpModuleSymbol.
        /// </summary>
        internal CSharpSymbols.ModuleSymbol UnderlyingModule
        {
            get
            {
                return _underlyingModule;
            }
        }

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                return CSharpSymbolMap.GetNamespaceSymbol(_underlyingModule.GlobalNamespace);
            }
        }

        public string Name
        {
            get
            {
                return _underlyingModule.Name;
            }
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                return _csharpAssembly;
            }
        }

        public override AssemblySymbol ContainingAssembly
        {
            get
            {
                return _csharpAssembly;
            }
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return _underlyingModule.Locations;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _underlyingModule.DeclaringSyntaxReferences;

        /// <summary>
        /// A helper method for ReferenceManager to set AssemblySymbols for assemblies 
        /// referenced by this module.
        /// </summary>
        internal override void SetReferences(ModuleReferences<AssemblySymbol> moduleReferences, SourceAssemblySymbol originatingSourceAssemblyDebugOnly)
        {
            base.SetReferences(moduleReferences, originatingSourceAssemblyDebugOnly);

            // Build the retargeting map
            _retargetingAssemblyMap.Clear();

            ImmutableArray<AssemblySymbol> underlyingBoundReferences = CSharpSymbolMap.GetAssemblySymbols(_underlyingModule.ReferencedAssemblySymbols);
            ImmutableArray<AssemblySymbol> referencedAssemblySymbols = moduleReferences.Symbols;

            Debug.Assert(referencedAssemblySymbols.Length == moduleReferences.Identities.Length);
            Debug.Assert(referencedAssemblySymbols.Length <= underlyingBoundReferences.Length); // Linked references are filtered out.

            int i, j;
            for (i = 0, j = 0; i < referencedAssemblySymbols.Length; i++, j++)
            {
                // Skip linked assemblies for source module
                while (underlyingBoundReferences[j].IsLinked)
                {
                    j++;
                }

#if DEBUG
                var identityComparer = _underlyingModule.DeclaringCompilation.Options.AssemblyIdentityComparer;
                var definitionIdentity = ReferenceEquals(referencedAssemblySymbols[i], originatingSourceAssemblyDebugOnly) ?
                        new AssemblyIdentity(name: originatingSourceAssemblyDebugOnly.Name) :
                        referencedAssemblySymbols[i].Identity;

                Debug.Assert(identityComparer.Compare(moduleReferences.Identities[i], definitionIdentity) != AssemblyIdentityComparer.ComparisonResult.NotEquivalent);
                Debug.Assert(identityComparer.Compare(moduleReferences.Identities[i], underlyingBoundReferences[j].Identity) != AssemblyIdentityComparer.ComparisonResult.NotEquivalent);
#endif

                if (!ReferenceEquals(referencedAssemblySymbols[i], underlyingBoundReferences[j]))
                {
                    DestinationData destinationData;

                    if (!_retargetingAssemblyMap.TryGetValue(underlyingBoundReferences[j], out destinationData))
                    {
                        _retargetingAssemblyMap.Add(underlyingBoundReferences[j],
                            new DestinationData { To = referencedAssemblySymbols[i] });
                    }
                    else
                    {
                        Debug.Assert(ReferenceEquals(destinationData.To, referencedAssemblySymbols[i]));
                    }
                }
            }

#if DEBUG
            while (j < underlyingBoundReferences.Length && underlyingBoundReferences[j].IsLinked)
            {
                j++;
            }

            Debug.Assert(j == underlyingBoundReferences.Length);
#endif
        }

        public override ICollection<string> TypeNames
        {
            get
            {
                return _underlyingModule.TypeNames;
            }
        }

        public override ICollection<string> NamespaceNames
        {
            get
            {
                return _underlyingModule.NamespaceNames;
            }
        }

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            return CSharpSymbolMap.GetAttributes(_underlyingModule.GetAttributes(), ref _lazyCustomAttributes);
        }

        internal override bool HasAssemblyCompilationRelaxationsAttribute
        {
            get
            {
                return _underlyingModule.HasAssemblyCompilationRelaxationsAttribute;
            }
        }

        internal override bool HasAssemblyRuntimeCompatibilityAttribute
        {
            get
            {
                return _underlyingModule.HasAssemblyRuntimeCompatibilityAttribute;
            }
        }

        internal override CharSet? DefaultMarshallingCharSet
        {
            get
            {
                return _underlyingModule.DefaultMarshallingCharSet;
            }
        }

        public sealed override LanguageCompilation DeclaringCompilation // perf, not correctness
        {
            get { return null; }
        }

        public override ModuleMetadata GetMetadata() => _underlyingModule.GetMetadata();

        /// <summary>
        /// Returns a tuple of the assemblies this module forwards the given type to.
        /// </summary>
        /// <param name="fullName">Type to look up.</param>
        /// <returns>A tuple of the forwarded to assemblies.</returns>
        /// <remarks>
        /// The returned assemblies may also forward the type.
        /// </remarks>
        internal (AssemblySymbol FirstSymbol, AssemblySymbol SecondSymbol) GetAssembliesForForwardedType(ref MetadataTypeName fullName)
        {
            string matchedName;
            var peModuleSymbol = this.UnderlyingModule as CSharpSymbols.Metadata.PE.PEModuleSymbol;
            if (peModuleSymbol == null) return (null, null);
            (int firstIndex, int secondIndex) = peModuleSymbol.Module.GetAssemblyRefsForForwardedType(fullName.FullName, ignoreCase: false, matchedName: out matchedName);

            if (firstIndex < 0)
            {
                return (null, null);
            }

            AssemblySymbol firstSymbol = GetReferencedAssemblySymbol(firstIndex);

            if (secondIndex < 0)
            {
                return (firstSymbol, null);
            }

            AssemblySymbol secondSymbol = GetReferencedAssemblySymbol(secondIndex);
            return (firstSymbol, secondSymbol);
        }

        internal IEnumerable<NamedTypeSymbol> GetForwardedTypes()
        {
            foreach (KeyValuePair<string, (int FirstIndex, int SecondIndex)> forwarder in ((CSharpSymbols.Metadata.PE.PEModuleSymbol)this.UnderlyingModule).Module.GetForwardedTypes())
            {
                var name = MetadataTypeName.FromFullName(forwarder.Key);

                Debug.Assert(forwarder.Value.FirstIndex >= 0, "First index should never be negative");
                AssemblySymbol firstSymbol = this.GetReferencedAssemblySymbol(forwarder.Value.FirstIndex);
                Debug.Assert((object)firstSymbol != null, "Invalid indexes (out of bound) are discarded during reading metadata in PEModule.EnsureForwardTypeToAssemblyMap()");

                if (forwarder.Value.SecondIndex >= 0)
                {
                    var secondSymbol = this.GetReferencedAssemblySymbol(forwarder.Value.SecondIndex);
                    Debug.Assert((object)secondSymbol != null, "Invalid indexes (out of bound) are discarded during reading metadata in PEModule.EnsureForwardTypeToAssemblyMap()");

                    yield return ContainingAssembly.CreateMultipleForwardingErrorTypeSymbol(ref name, this, firstSymbol, secondSymbol);
                }
                else
                {
                    yield return firstSymbol.LookupTopLevelMetadataType(ref name, digThroughForwardedTypes: true);
                }
            }
        }
    }
}
