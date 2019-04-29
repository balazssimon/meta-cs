using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class ModuleSymbol : Symbol, IModuleSymbol
    {
        public abstract INamespaceSymbol GlobalNamespace { get; }
        public abstract ImmutableArray<AssemblyIdentity> ReferencedAssemblies { get; }
        public abstract ImmutableArray<IAssemblySymbol> ReferencedAssemblySymbols { get; }

        public abstract ModuleMetadata GetMetadata();
        public abstract INamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol);

        /// <summary>
        /// Returns the containing assembly. Modules are always directly contained by an assembly,
        /// so this property always returns the same as ContainingSymbol.
        /// </summary>
        public override AssemblySymbol ContainingAssembly
        {
            get
            {
                return (AssemblySymbol)ContainingSymbol;
            }
        }

        public override ModuleSymbol ContainingModule => null;

        /// <summary>
        /// Returns value 'NetModule' of the <see cref="SymbolKind"/>
        /// </summary>
        public override SymbolKind Kind => SymbolKind.NetModule;

        public override ModelSymbolInfo ModelSymbolInfo => null;

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override Accessibility DeclaredAccessibility => Accessibility.NotApplicable;

        public override bool IsStatic => false;

        public override bool IsVirtual => false;

        public override bool IsOverride => false;

        public override bool IsAbstract => false;

        public override bool IsSealed => false;

        public override bool IsExtern => false;

        public override ObsoleteAttributeData ObsoleteAttributeData => null;

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
