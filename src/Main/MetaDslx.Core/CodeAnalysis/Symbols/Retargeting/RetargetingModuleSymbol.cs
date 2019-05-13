// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Retargeting
{
    /// <summary>
    /// Represents a primary module of a <see cref="RetargetingAssemblySymbol"/>. Essentially this is a wrapper around 
    /// another <see cref="SourceModuleSymbol"/> that is responsible for retargeting symbols from one assembly to another. 
    /// It can retarget symbols for multiple assemblies at the same time.
    /// 
    /// Here is how retargeting is implemented in general:
    /// - Symbols from underlying module are substituted with retargeting symbols.
    /// - Symbols from referenced assemblies that can be reused as is (i.e. don't have to be retargeted) are
    ///   used as is.
    /// - Symbols from referenced assemblies that must be retargeted are substituted with result of retargeting.
    /// </summary>
    public sealed partial class RetargetingModuleSymbol : NonMissingModuleSymbol
    {
        /// <summary>
        /// Owning <see cref="RetargetingAssemblySymbol"/>.
        /// </summary>
        private readonly RetargetingAssemblySymbol _retargetingAssembly;

        /// <summary>
        /// The underlying <see cref="ModuleSymbol"/>, cannot be another <see cref="RetargetingModuleSymbol"/>.
        /// </summary>
        private readonly SourceModuleSymbol _underlyingModule;

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

        internal readonly RetargetingSymbolMap RetargetingSymbolMap;

        /// <summary>
        /// Retargeted custom attributes
        /// </summary>
        private ImmutableArray<AttributeData> _lazyCustomAttributes;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="retargetingAssembly">
        /// Owning assembly.
        /// </param>
        /// <param name="underlyingModule">
        /// The underlying ModuleSymbol, cannot be another RetargetingModuleSymbol.
        /// </param>
        public RetargetingModuleSymbol(RetargetingAssemblySymbol retargetingAssembly, SourceModuleSymbol underlyingModule)
        {
            Debug.Assert((object)retargetingAssembly != null);
            Debug.Assert((object)underlyingModule != null);

            _retargetingAssembly = retargetingAssembly;
            _underlyingModule = underlyingModule;
            this.RetargetingSymbolMap = new RetargetingSymbolMap(this);
        }

        public override int Ordinal
        {
            get
            {
                Debug.Assert(_underlyingModule.Ordinal == 0); // Always a source module
                return 0;
            }
        }

        /// <summary>
        /// The underlying ModuleSymbol, cannot be another RetargetingModuleSymbol.
        /// </summary>
        public SourceModuleSymbol UnderlyingModule
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
                return RetargetingSymbolMap.GetNamespaceSymbol(_underlyingModule.GlobalNamespace);
            }
        }

        public override bool IsImplicitlyDeclared
        {
            get { return _underlyingModule.IsImplicitlyDeclared; }
        }

        public override string Name
        {
            get
            {
                return _underlyingModule.Name;
            }
        }

        public override string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _underlyingModule.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                return _retargetingAssembly;
            }
        }

        public override AssemblySymbol ContainingAssembly
        {
            get
            {
                return _retargetingAssembly;
            }
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return _underlyingModule.Locations;
            }
        }

        /// <summary>
        /// A helper method for ReferenceManager to set AssemblySymbols for assemblies 
        /// referenced by this module.
        /// </summary>
        internal override void SetReferences(ModuleReferences<AssemblySymbol> moduleReferences, SourceAssemblySymbol originatingSourceAssemblyDebugOnly)
        {
            base.SetReferences(moduleReferences, originatingSourceAssemblyDebugOnly);

            // Build the retargeting map
            _retargetingAssemblyMap.Clear();

            ImmutableArray<AssemblySymbol> underlyingBoundReferences = _underlyingModule.ReferencedAssemblySymbols;
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

        public override ImmutableArray<string> TypeNames
        {
            get
            {
                return _underlyingModule.TypeNames;
            }
        }

        public override ImmutableArray<string> NamespaceNames
        {
            get
            {
                return _underlyingModule.NamespaceNames;
            }
        }

        internal sealed override LanguageCompilation DeclaringCompilation // perf, not correctness
        {
            get { return null; }
        }

        public override ModuleMetadata GetMetadata() => _underlyingModule.GetMetadata();
    }
}
