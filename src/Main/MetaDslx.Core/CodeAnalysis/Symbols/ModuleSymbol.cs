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

        public abstract int Ordinal { get; }
        public abstract ModuleMetadata GetMetadata();

        /// <summary>
        /// Given a namespace symbol, returns the corresponding module specific namespace symbol
        /// </summary>
        public INamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol)
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
