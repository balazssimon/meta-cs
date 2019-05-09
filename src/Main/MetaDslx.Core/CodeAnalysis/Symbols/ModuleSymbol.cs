using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.Source;

namespace MetaDslx.CodeAnalysis.Symbols
{

    public abstract class ModuleSymbol : Symbol, IModuleSymbol
    {
        protected ModuleSymbol()
        {
        }

        public abstract int Ordinal { get; }

        public virtual bool IsMissing => false;

        /// <summary>
        /// True if this module has any unified references.
        /// </summary>
        public abstract bool HasUnifiedReferences { get; }

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => this.ContainingAssembly;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public abstract NamespaceSymbol GlobalNamespace { get; }

        public abstract ImmutableArray<AssemblyIdentity> ReferencedAssemblies { get; }

        public abstract ImmutableArray<AssemblySymbol> ReferencedAssemblySymbols { get; }

        public abstract ModuleMetadata GetMetadata();

        /// <summary>
        /// Given a namespace symbol, returns the corresponding module specific namespace symbol
        /// </summary>
        public NamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol)
        {
            if (namespaceSymbol == null)
            {
                throw new ArgumentNullException(nameof(namespaceSymbol));
            }

            var moduleNs = namespaceSymbol as NamespaceSymbol;
            if ((object)moduleNs != null && moduleNs.Extent.Kind == NamespaceKind.Module && moduleNs.ContainingModule == this)
            {
                // this is already the correct module namespace
                return moduleNs;
            }

            if (namespaceSymbol.IsGlobalNamespace || (object)namespaceSymbol.ContainingNamespace == null)
            {
                return this.GlobalNamespace;
            }
            else
            {
                var cns = GetModuleNamespace(namespaceSymbol.ContainingNamespace);
                if ((object)cns != null)
                {
                    return cns.GetNestedNamespace(namespaceSymbol.Name);
                }
                return null;
            }
        }

        INamespaceSymbol IModuleSymbol.GlobalNamespace => this.GlobalNamespace;

        ImmutableArray<IAssemblySymbol> IModuleSymbol.ReferencedAssemblySymbols => StaticCast<IAssemblySymbol>.From(this.ReferencedAssemblySymbols);

        INamespaceSymbol IModuleSymbol.GetModuleNamespace(INamespaceSymbol namespaceSymbol)
        {
            return this.GetModuleNamespace(namespaceSymbol);
        }

        public sealed override SymbolKind Kind => SymbolKind.NetModule;

        public override bool IsStatic => false;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitModule(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitModule(this);
        }

        internal AssemblySymbol GetReferencedAssemblySymbol(int referencedAssemblyIndex)
        {
            var referencedAssemblies = ReferencedAssemblySymbols;
            if (referencedAssemblyIndex < referencedAssemblies.Length)
            {
                return referencedAssemblies[referencedAssemblyIndex];
            }

            // This module must be a corlib where the original metadata contains assembly
            // references (see https://github.com/dotnet/roslyn/issues/13275).
            var assembly = ContainingAssembly;
            if ((object)assembly != assembly.CorLibrary)
            {
                throw new ArgumentOutOfRangeException(nameof(referencedAssemblyIndex));
            }

            return null;
        }

        /// <summary>
        /// A helper method for ReferenceManager to set assembly identities for assemblies 
        /// referenced by this module and corresponding AssemblySymbols.
        /// </summary>
        /// <param name="moduleReferences">A description of the assemblies referenced by this module.</param>
        /// <param name="originatingSourceAssemblyDebugOnly">
        /// Source assembly that triggered creation of this module symbol.
        /// For debug purposes only, this assembly symbol should not be persisted within
        /// this module symbol because the module can be shared across multiple source 
        /// assemblies. This method will only be called for the first one.
        /// </param>
        internal abstract void SetReferences(ModuleReferences<AssemblySymbol> moduleReferences, SourceAssemblySymbol originatingSourceAssemblyDebugOnly = null);

        /// <summary> 
        /// Returns a unification use-site error (if any) for a symbol contained in this module 
        /// that is referring to a specified <paramref name="dependentType"/>.
        /// </summary> 
        /// <remarks> 
        /// If an assembly referenced by this module isn't exactly matching any reference given to compilation 
        /// the Assembly Manager might decide to use another reference if it matches except for version 
        /// (it unifies the version with the existing reference).  
        /// </remarks>
        public abstract bool GetUnificationUseSiteDiagnostic(ref DiagnosticInfo result, Symbol dependentType);

        /// <summary>
        /// Lookup a top level type referenced from metadata, names should be
        /// compared case-sensitively.
        /// </summary>
        /// <param name="emittedName">
        /// Full type name, possibly with generic name mangling.
        /// </param>
        /// <returns>
        /// Symbol for the type, or MissingMetadataSymbol if the type isn't found.
        /// </returns>
        /// <remarks></remarks>
        public abstract NamedTypeSymbol LookupTopLevelMetadataType(ref MetadataTypeName emittedName);

        public abstract ImmutableArray<string> TypeNames { get; }

        public abstract ImmutableArray<string> NamespaceNames { get; }

    }
}
