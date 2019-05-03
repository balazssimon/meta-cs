using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{

    public abstract class ModuleSymbol : Symbol, IModuleSymbol
    {
        protected ModuleSymbol()
        {
        }

        public abstract int Ordinal { get; }

        /// <summary>
        /// True if this module has any unified references.
        /// </summary>
        public abstract bool HasUnifiedReferences { get; }

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

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => this.ContainingAssembly;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public abstract NamespaceSymbol GlobalNamespace { get; }

        public abstract ImmutableArray<AssemblyIdentity> ReferencedAssemblies { get; }

        public abstract ImmutableArray<AssemblySymbol> ReferencedAssemblySymbols { get; }

        public abstract ModuleMetadata GetMetadata();

        public abstract NamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol);

        INamespaceSymbol IModuleSymbol.GlobalNamespace => this.GlobalNamespace;

        ImmutableArray<IAssemblySymbol> IModuleSymbol.ReferencedAssemblySymbols => StaticCast<IAssemblySymbol>.From(this.ReferencedAssemblySymbols);

        INamespaceSymbol IModuleSymbol.GetModuleNamespace(INamespaceSymbol namespaceSymbol)
        {
            return this.GetModuleNamespace(namespaceSymbol);
        }

        public sealed override SymbolKind Kind => SymbolKind.NetModule;

        public override bool IsStatic => false;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitModule(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitModule(this);
        }
    }
}
