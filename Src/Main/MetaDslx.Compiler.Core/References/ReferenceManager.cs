using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Compiler.Diagnostics;

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
    public class ReferenceManager
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

        public ImmutableArray<ImmutableModel> ReferencedModels { get; }

        public ImmutableArray<ImmutableArray<string>> AliasesOfReferencedModels { get; }

        internal bool DeclarationsAccessibleWithoutAlias(int i)
        {
            return true;
        }

        internal void CreateModelBuilderForCompilation(CompilationBase compilationBase)
        {
            throw new NotImplementedException();
        }

        internal ArrayBuilder<IMetaSymbol> GetRootNamespaces(int i)
        {
            throw new NotImplementedException();
        }

        public ImmutableArray<Diagnostic> Diagnostics
        {
            get;
        }

        public ImmutableArray<MetadataReference> DirectiveReferences
        {
            get;
        }

        public IDictionary<Tuple<string, string>, MetadataReference> ReferenceDirectiveMap
        {
            get;
        }

        public IEnumerable<string> ExternAliases
        {
            get;
        }

        internal ImmutableModel GetReferencedModel(MetadataReference reference)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<ModelIdentity> GetReferencedModelNames()
        {
            throw new NotImplementedException();
        }
    }
}
