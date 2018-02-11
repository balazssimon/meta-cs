﻿using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Compiler.Diagnostics;
using System.Diagnostics;

namespace MetaDslx.Compiler.References
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
        /// - Compilation._lazyModel...
        /// - Compilation.referenceManager
        /// - ReferenceManager state
        /// 
        /// All the above data should be updated at once while holding this lock.
        /// Once lazyAssemblySymbol is set the Compilation.referenceManager field and ReferenceManager
        /// state should not change.
        /// </summary>
        internal static object SymbolCacheAndReferenceManagerStateGuard = new object();

        private readonly string _compilationName;
        private readonly ImmutableArray<ImmutableModel> _referencedModels;

        internal ReferenceManager(string compilationName, ImmutableArray<MetadataReference> references)
        {
            _compilationName = compilationName;
            ArrayBuilder<ImmutableModel> models = ArrayBuilder<ImmutableModel>.GetInstance();
            foreach (var reference in references)
            {
                ModelReference modelRef = reference as ModelReference;
                if (modelRef != null)
                {
                    models.Add(modelRef.Model);
                }
                ModelGroupReference modelGroupRef = reference as ModelGroupReference;
                if (modelGroupRef != null)
                {
                    models.AddRange(modelGroupRef.ModelGroup.Models);
                    models.AddRange(modelGroupRef.ModelGroup.References);
                }
            }
            _referencedModels = models.ToImmutableAndFree();
        }

        public ImmutableArray<ImmutableModel> ReferencedModels
        {
            get { return _referencedModels; }
        }

        public ImmutableArray<ImmutableArray<string>> AliasesOfReferencedModels
        {
            get { return ImmutableArray<ImmutableArray<string>>.Empty; }
        }

        internal bool DeclarationsAccessibleWithoutAlias(int i)
        {
            return true;
        }

        internal void CreateModelBuilderForCompilation(CompilationBase compilation)
        {
            MutableModelGroup modelGroup = new MutableModelGroup();
            MutableModel model = modelGroup.CreateModel(compilation.CompilationName);
            if ((object)compilation._lazyModelGroupBuilder == null)
            {
                lock (SymbolCacheAndReferenceManagerStateGuard)
                {
                    if ((object)compilation._lazyModelGroupBuilder == null)
                    {
                        foreach (var modelRef in _referencedModels)
                        {
                            modelGroup.AddReference(modelRef);
                        }
                        compilation._lazyModelGroupBuilder = modelGroup;
                        compilation._lazyModelBuilder = model;
                        compilation._lazyModelId = model.Id;
                        compilation._lazyGlobalNamespace = compilation.SymbolBuilder.BuildRootDeclarationSymbol(null, compilation.Declarations.MergedRoot);
                        //compilation._lazyGlobalNamespace 
                        Debug.Assert(ReferenceEquals(compilation._referenceManager, this));
                    }
                }
            }
        }

        public ImmutableArray<ISymbol> GetRootNamespaces(int i)
        {
            return ImmutableArray<ISymbol>.Empty;
        }

        public ImmutableArray<Diagnostic> Diagnostics
        {
            get { return ImmutableArray<Diagnostic>.Empty; }
        }

        public ImmutableArray<MetadataReference> DirectiveReferences
        {
            get { return ImmutableArray<MetadataReference>.Empty; }
        }

        public IDictionary<Tuple<string, string>, MetadataReference> ReferenceDirectiveMap
        {
            get { return null; }
        }

        public IEnumerable<string> ExternAliases
        {
            get { return EmptyCollections.Enumerable<string>(); }
        }

        internal ImmutableModel GetReferencedModel(MetadataReference reference)
        {
            return null;
        }

        internal IEnumerable<ModelIdentity> GetReferencedModelNames()
        {
            return EmptyCollections.Enumerable<ModelIdentity>();
        }

        internal MetadataReference GetMetadataReference(ImmutableModel model)
        {
            return null;
        }

        internal void AssertCanReuseForCompilation(CompilationBase compilationBase)
        {
            
        }
    }
}