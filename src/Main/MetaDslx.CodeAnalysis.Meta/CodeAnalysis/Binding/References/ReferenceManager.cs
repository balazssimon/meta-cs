// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Retargeting;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    using MetadataOrDiagnostic = System.Object;
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpCompilation = Microsoft.CodeAnalysis.CSharp.CSharpCompilation;
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    public partial class LanguageCompilation
    {
        /// <summary>
        /// ReferenceManager encapsulates functionality to create an underlying SourceAssemblySymbol 
        /// (with underlying ModuleSymbols) for Compilation and AssemblySymbols for referenced
        /// assemblies (with underlying ModuleSymbols) all properly linked together based on
        /// reference resolution between them.
        /// 
        /// ReferenceManager is also responsible for reuse of metadata readers for imported modules
        /// and assemblies as well as existing AssemblySymbols for referenced assemblies. In order
        /// to do that, it maintains global cache for metadata readers and AssemblySymbols
        /// associated with them. The cache uses WeakReferences to refer to the metadata readers and
        /// AssemblySymbols to allow memory and resources being reclaimed once they are no longer
        /// used. The tricky part about reusing existing AssemblySymbols is to find a set of
        /// AssemblySymbols that are created for the referenced assemblies, which (the
        /// AssemblySymbols from the set) are linked in a way, consistent with the reference
        /// resolution between the referenced assemblies.
        /// 
        /// When existing Compilation is used as a metadata reference, there are scenarios when its
        /// underlying SourceAssemblySymbol cannot be used to provide symbols in context of the new
        /// Compilation. Consider classic multi-targeting scenario: compilation C1 references v1 of
        /// Lib.dll and compilation C2 references C1 and v2 of Lib.dll. In this case,
        /// SourceAssemblySymbol for C1 is linked to AssemblySymbol for v1 of Lib.dll. However,
        /// given the set of references for C2, the same reference for C1 should be resolved against
        /// v2 of Lib.dll. In other words, in context of C2, all types from v1 of Lib.dll leaking
        /// through C1 (through method signatures, etc.) must be retargeted to the types from v2 of
        /// Lib.dll. In this case, ReferenceManager creates a special RetargetingAssemblySymbol for
        /// C1, which is responsible for the type retargeting. The RetargetingAssemblySymbols could
        /// also be reused for different Compilations, ReferenceManager maintains a cache of
        /// RetargetingAssemblySymbols (WeakReferences) for each Compilation.
        /// 
        /// The only public entry point of this class is CreateSourceAssembly() method.
        /// </summary>
        public sealed class ReferenceManager 
        {
            /// <summary>
            /// Must be acquired whenever the following data are about to be modified:
            /// - Compilation.lazyAssemblySymbol
            /// - Compilation.referenceManager
            /// - ReferenceManager state
            /// - <see cref="AssemblyMetadata.CachedSymbols"/>
            /// - <see cref="Compilation.RetargetingAssemblySymbols"/>
            /// 
            /// All the above data should be updated at once while holding this lock.
            /// Once lazyAssemblySymbol is set the Compilation.referenceManager field and ReferenceManager
            /// state should not change.
            /// </summary>
            internal static object SymbolCacheAndReferenceManagerStateGuard = new object();

            private static readonly ModuleReferences<AssemblySymbol> EmptyModuleReferences = new ModuleReferences<AssemblySymbol>(ImmutableArray<AssemblyIdentity>.Empty, ImmutableArray<AssemblySymbol>.Empty, ImmutableArray<UnifiedAssembly<AssemblySymbol>>.Empty);

            /// <summary>
            /// A reference manager from the C# implementation. All assembly resolutions are forwarded to this reference manager.
            /// </summary>
            private CommonReferenceManager<CSharpCompilation, CSharpSymbols.AssemblySymbol> _lazyCSharpReferenceManager;

            /// <summary>
            /// Maps C# symbols to MetaDslx symbols
            /// </summary>
            private CSharpSymbolMap _csharpSymbolMap;

            /// <summary>
            /// If the compilation being built represents an assembly its assembly name.
            /// If the compilation being built represents a module, the name of the 
            /// containing assembly or <see cref="Compilation.UnspecifiedModuleAssemblyName"/>
            /// if not specified (/moduleassemblyname command line option).
            /// </summary>
            internal readonly string SimpleAssemblyName;

            /// <summary>
            /// Once this is non-zero the state of the manager is fully initialized and immutable.
            /// </summary>
            private int _isBound;

            /// <summary>
            /// COR library symbol, or null if the compilation itself is the COR library.
            /// </summary>
            /// <remarks>
            /// If the compilation being built is the COR library we don't want to store its source assembly symbol 
            /// here since we wouldn't be able to share the state among subsequent compilations that are derived from it
            /// (each of them has its own source assembly symbol).
            /// </remarks>
            private AssemblySymbol _lazyCorLibraryOpt;

            /// <summary>
            /// References of standalone modules referenced by the compilation (doesn't include the manifest module of the compilation).
            /// </summary>
            /// <remarks>
            /// <see cref="_lazyReferencedModules"/>[i] corresponds to <see cref="_lazyReferencedModulesReferences"/>[i].
            /// </remarks>
            private ImmutableArray<ModuleReferences<AssemblySymbol>> _lazyReferencedModulesReferences;

            /// <summary>
            /// Assemblies referenced directly by the source module of the compilation.
            /// </summary>
            private ImmutableArray<AssemblySymbol> _lazyReferencedAssemblies;


            /// <summary>
            /// Unified assemblies referenced directly by the source module of the compilation.
            /// </summary>
            private ImmutableArray<UnifiedAssembly<AssemblySymbol>> _lazyUnifiedAssemblies;


            internal ReferenceManager(string simpleAssemblyName)
            {
                this.SimpleAssemblyName = simpleAssemblyName;
                _csharpSymbolMap = new CSharpSymbolMap();
            }

            internal ImmutableArray<Diagnostic> Diagnostics
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.Diagnostics;
                }
            }

            internal bool HasCircularReference
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.HasCircularReference;
                }
            }

            internal Dictionary<MetadataReference, int> ReferencedAssembliesMap
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.ReferencedAssembliesMap;
                }
            }

            internal Dictionary<MetadataReference, int> ReferencedModuleIndexMap
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.ReferencedModuleIndexMap;
                }
            }

            internal IDictionary<(string, string), MetadataReference> ReferenceDirectiveMap
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.ReferenceDirectiveMap;
                }
            }

            internal ImmutableArray<MetadataReference> DirectiveReferences
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.DirectiveReferences;
                }
            }

            internal ImmutableArray<MetadataReference> ImplicitReferences
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.ImplicitReferences;
                }
            }

            internal ImmutableArray<MetadataReference> ExplicitReferences
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.ExplicitReferences;
                }
            }

            internal AssemblySymbol CorLibraryOpt
            {
                get
                {
                    AssertBound();
                    return _lazyCorLibraryOpt;
                }
            }

            internal ImmutableArray<PEModule> ReferencedModules
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.ReferencedModules;
                }
            }

            internal ImmutableArray<ModuleReferences<AssemblySymbol>> ReferencedModulesReferences
            {
                get
                {
                    AssertBound();
                    return _lazyReferencedModulesReferences;
                }
            }

            internal ImmutableArray<AssemblySymbol> ReferencedAssemblies
            {
                get
                {
                    AssertBound();
                    return _lazyReferencedAssemblies;
                }
            }

            internal ImmutableArray<ImmutableArray<string>> AliasesOfReferencedAssemblies
            {
                get
                {
                    AssertBound();
                    return _lazyCSharpReferenceManager.AliasesOfReferencedAssemblies;
                }
            }

            internal ImmutableArray<UnifiedAssembly<AssemblySymbol>> UnifiedAssemblies
            {
                get
                {
                    AssertBound();
                    return _lazyUnifiedAssemblies;
                }
            }


            public void CreateSourceAssemblyForCompilation(LanguageCompilation compilation)
            {
                // We are reading the Reference Manager state outside of a lock by accessing 
                // IsBound and HasCircularReference properties.
                // Once isBound flag is flipped the state of the manager is available and doesn't change.
                // 
                // If two threads are building SourceAssemblySymbol and the first just updated 
                // set isBound flag to 1 but not yet set lazySourceAssemblySymbol,
                // the second thread may end up reusing the Reference Manager data the first thread calculated. 
                // That's ok since 
                // 1) the second thread would produce the same data,
                // 2) all results calculated by the second thread will be thrown away since the first thread 
                //    already acquired SymbolCacheAndReferenceManagerStateGuard that is needed to publish the data.

                // The given compilation is the first compilation that shares this manager and its symbols are requested.
                // Perform full reference resolution and binding.
                if (!IsBound && CreateAndSetSourceAssemblyFullBind(compilation))
                {
                    // we have successfully bound the references for the compilation
                }
                else if (!HasCircularReference)
                {
                    // Another compilation that shares the manager with the given compilation
                    // already bound its references and produced tables that we can use to construct 
                    // source assembly symbol faster. Unless we encountered a circular reference.
                    CreateAndSetSourceAssemblyReuseData(compilation);
                }
                else
                {
                    // We encountered a circular reference while binding the previous compilation.
                    // This compilation can't share bound references with other compilations. Create a new manager.

                    // NOTE: The CreateSourceAssemblyFullBind is going to replace compilation's reference manager with newManager.

                    var newManager = new ReferenceManager(this.SimpleAssemblyName);
                    var successful = newManager.CreateAndSetSourceAssemblyFullBind(compilation);

                    // The new manager isn't shared with any other compilation so there is no other 
                    // thread but the current one could have initialized it.
                    Debug.Assert(successful);

                    newManager.AssertBound();
                }

                AssertBound();
                Debug.Assert((object)compilation._lazyAssemblySymbol != null);
            }

            /// <summary>
            /// Call only while holding <see cref="CommonReferenceManager.SymbolCacheAndReferenceManagerStateGuard"/>.
            /// </summary>
            [Conditional("DEBUG")]
            internal void AssertUnbound()
            {
                Debug.Assert(_isBound == 0);
                Debug.Assert(_lazyCSharpReferenceManager == null);
                Debug.Assert(_lazyReferencedAssemblies.IsDefault);
                Debug.Assert(_lazyUnifiedAssemblies.IsDefault);
                Debug.Assert(_lazyReferencedModulesReferences.IsDefault);
                Debug.Assert(_lazyCorLibraryOpt == null);
            }

            [Conditional("DEBUG")]
            internal void AssertBound()
            {
                Debug.Assert(_isBound != 0);
                Debug.Assert(_lazyCSharpReferenceManager != null);
                Debug.Assert(!_lazyReferencedAssemblies.IsDefault);
                Debug.Assert(!_lazyUnifiedAssemblies.IsDefault);
                Debug.Assert(!_lazyReferencedModulesReferences.IsDefault);

                // lazyCorLibrary is null if the compilation is corlib
                Debug.Assert(_lazyReferencedAssemblies.Length == 0 || _lazyCorLibraryOpt != null);
            }

            // for testing purposes
            internal IEnumerable<string> ExternAliases => AliasesOfReferencedAssemblies.SelectMany(aliases => aliases);

            [Conditional("DEBUG")]
            internal void AssertCanReuseForCompilation(LanguageCompilation compilation)
            {
                Debug.Assert(compilation.MakeSourceAssemblySimpleName() == this.SimpleAssemblyName);
            }

            internal bool IsBound
            {
                get
                {
                    return _isBound != 0;
                }
            }

            /// <summary>
            /// Call only while holding <see cref="CommonReferenceManager.SymbolCacheAndReferenceManagerStateGuard"/>.
            /// </summary>
            internal void InitializeNoLock(CommonReferenceManager<CSharpCompilation, CSharpSymbols.AssemblySymbol> csharpReferenceManager)
            {
                AssertUnbound();

                _lazyCSharpReferenceManager = csharpReferenceManager;
                _lazyReferencedAssemblies = CSharpSymbolMap.GetAssemblySymbols(csharpReferenceManager.ReferencedAssemblies);
                _lazyUnifiedAssemblies = CSharpSymbolMap.GetAssemblySymbols(csharpReferenceManager.UnifiedAssemblies);
                _lazyReferencedModulesReferences = csharpReferenceManager.ReferencedModulesReferences.Select(mr => FromCSharp(mr)).ToImmutableArray();
                _lazyCorLibraryOpt = CSharpSymbolMap.GetAssemblySymbol(csharpReferenceManager.CorLibraryOpt);

                // once we flip this bit the state of the manager is immutable and available to any readers:
                Interlocked.Exchange(ref _isBound, 1);
            }

            internal IEnumerable<KeyValuePair<MetadataReference, AssemblySymbol>> GetReferencedAssemblies()
            {
                return ReferencedAssembliesMap.Select(ra => KeyValuePairUtil.Create(ra.Key, ReferencedAssemblies[ra.Value]));
            }

            internal AssemblySymbol GetReferencedAssemblySymbol(MetadataReference reference)
            {
                int index;
                return ReferencedAssembliesMap.TryGetValue(reference, out index) ? ReferencedAssemblies[index] : null;
            }

            internal int GetReferencedModuleIndex(MetadataReference reference)
            {
                int index;
                return ReferencedModuleIndexMap.TryGetValue(reference, out index) ? index : -1;
            }

            /// <summary>
            /// Gets the <see cref="MetadataReference"/> that corresponds to the assembly symbol. 
            /// </summary>
            internal MetadataReference GetMetadataReference(IAssemblySymbol assemblySymbol)
            {
                foreach (var entry in ReferencedAssembliesMap)
                {
                    if ((object)ReferencedAssemblies[entry.Value] == assemblySymbol)
                    {
                        return entry.Key;
                    }
                }

                return null;
            }

            internal IEnumerable<(AssemblySymbol, ImmutableArray<string>)> GetReferencedAssemblyAliases()
            {
                for (int i = 0; i < ReferencedAssemblies.Length; i++)
                {
                    yield return (ReferencedAssemblies[i], AliasesOfReferencedAssemblies[i]);
                }
            }

            public bool DeclarationsAccessibleWithoutAlias(int referencedAssemblyIndex)
            {
                var aliases = AliasesOfReferencedAssemblies[referencedAssemblyIndex];
                return aliases.Length == 0 || aliases.IndexOf(MetadataReferenceProperties.GlobalAlias, StringComparer.Ordinal) >= 0;
            }

            internal IEnumerable<KeyValuePair<AssemblyIdentity, PortableExecutableReference>> GetImplicitlyResolvedAssemblyReferences()
            {
                foreach (PortableExecutableReference reference in ImplicitReferences)
                {
                    yield return KeyValuePairUtil.Create(ReferencedAssemblies[ReferencedAssembliesMap[reference]].Identity, reference);
                }
            }


            private ModuleReferences<AssemblySymbol> FromCSharp(ModuleReferences<CSharpSymbols.AssemblySymbol> csharpModuleReferences)
            {
                return new ModuleReferences<AssemblySymbol>(
                    csharpModuleReferences.Identities,
                    CSharpSymbolMap.GetAssemblySymbols(csharpModuleReferences.Symbols),
                    CSharpSymbolMap.GetAssemblySymbols(csharpModuleReferences.UnifiedAssemblies));
            }

            private void CreateAndSetSourceAssemblyReuseData(LanguageCompilation compilation)
            {
                AssertBound();

                // If the compilation has a reference from metadata to source assembly we can't share the referenced PE symbols.
                Debug.Assert(!HasCircularReference);

                string moduleName = compilation.MakeSourceModuleName();
                var assemblySymbol = new SourceAssemblySymbol(compilation, this.SimpleAssemblyName, moduleName, _csharpSymbolMap, this.ReferencedModules, CustomReferences(compilation.ExternalReferences));

                InitializeAssemblyReuseData(assemblySymbol, this.ReferencedAssemblies, this.UnifiedAssemblies);

                if ((object)compilation._lazyAssemblySymbol == null)
                {
                    lock (SymbolCacheAndReferenceManagerStateGuard)
                    {
                        if ((object)compilation._lazyAssemblySymbol == null)
                        {
                            compilation._lazyAssemblySymbol = assemblySymbol;
                            Debug.Assert(ReferenceEquals(compilation._referenceManager, this));
                        }
                    }
                }
            }

            private void InitializeAssemblyReuseData(SourceAssemblySymbol assemblySymbol, ImmutableArray<AssemblySymbol> referencedAssemblies, ImmutableArray<UnifiedAssembly<AssemblySymbol>> unifiedAssemblies)
            {
                AssertBound();

                assemblySymbol.SetCorLibrary(this.CorLibraryOpt ?? assemblySymbol);

                var sourceModuleReferences = new ModuleReferences<AssemblySymbol>(referencedAssemblies.SelectAsArray(a => a.Identity), referencedAssemblies, unifiedAssemblies);
                assemblySymbol.Modules[0].SetReferences(sourceModuleReferences);

                var peModules = assemblySymbol.PEModules;
                var referencedModulesReferences = this.ReferencedModulesReferences;
                Debug.Assert(peModules.Length == referencedModulesReferences.Length + 1);

                for (int i = 1; i < peModules.Length; i++)
                {
                    peModules[i].SetReferences(referencedModulesReferences[i - 1]);
                }

                var assemblyModules = assemblySymbol.Modules;
                for (int i = peModules.Length; i < assemblyModules.Length; i++)
                {
                    assemblyModules[i].SetReferences(EmptyModuleReferences);
                }
            }

            // Returns false if another compilation sharing this manager finished binding earlier and we should reuse its results.
            private bool CreateAndSetSourceAssemblyFullBind(LanguageCompilation compilation)
            {
                var csharpCompilation = compilation.CSharpCompilationForReferenceManager;
                var csharpReferenceManager = csharpCompilation.GetBoundReferenceManager();
                var assemblySymbol = new SourceAssemblySymbol(compilation, SimpleAssemblyName, compilation.MakeSourceModuleName(), _csharpSymbolMap, netModules: csharpReferenceManager.ReferencedModules, CustomReferences(compilation.ExternalReferences));
                if ((object)compilation._lazyAssemblySymbol == null)
                {
                    lock (SymbolCacheAndReferenceManagerStateGuard)
                    {
                        if ((object)compilation._lazyAssemblySymbol == null)
                        {
                            if (IsBound)
                            {
                                // Another thread has finished constructing AssemblySymbol for another compilation that shares this manager.
                                // Drop the results and reuse the symbols that were created for the other compilation.
                                return false;
                            }

                            InitializeNoLock(csharpReferenceManager);

                            // Make sure that the given compilation holds on this instance of reference manager.
                            Debug.Assert(ReferenceEquals(compilation._referenceManager, this) || HasCircularReference);
                            compilation._referenceManager = this;

                            // Finally, publish the source symbol after all data have been written.
                            // Once lazyAssemblySymbol is non-null other readers might start reading the data written above.
                            compilation._lazyAssemblySymbol = assemblySymbol;
                        }
                    }
                }
                InitializeAssemblyReuseData(compilation._lazyAssemblySymbol, this.ReferencedAssemblies, this.UnifiedAssemblies);
                return true;
            }

            public static ImmutableArray<MetadataReference> CSharpReferences(IEnumerable<MetadataReference> references)
            {
                var result = references?.Where(r => !(r is CustomReference))?.AsImmutable() ?? ImmutableArray<MetadataReference>.Empty;
                return result;
            }

            public static ImmutableArray<ModelReference> ModelReferences(IEnumerable<MetadataReference> references)
            {
                var result = references?.OfType<ModelReference>()?.AsImmutable() ?? ImmutableArray<ModelReference>.Empty;
                return result;
            }

            public static ImmutableArray<CustomReference> CustomReferences(IEnumerable<MetadataReference> references)
            {
                var result = references?.OfType<CustomReference>()?.AsImmutable() ?? ImmutableArray<CustomReference>.Empty;
                return result;
            }
        }
    }
}
