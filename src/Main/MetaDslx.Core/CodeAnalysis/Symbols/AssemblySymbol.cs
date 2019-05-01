using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;

    public abstract class AssemblySymbol : Symbol, IAssemblySymbol
    {
        protected AssemblySymbol()
        {
        }

        public override AssemblySymbol ContainingAssembly => null;

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => null;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public abstract NamespaceSymbol GlobalNamespace { get; }

        public abstract ImmutableArray<ModuleSymbol> Modules { get; }

        public abstract NamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName);

        public abstract NamedTypeSymbol ResolveForwardedType(string fullyQualifiedMetadataName);

        public abstract bool IsInteractive { get; }

        public abstract AssemblyIdentity Identity { get; }

        INamespaceSymbol IAssemblySymbol.GlobalNamespace => this.GlobalNamespace;

        IEnumerable<IModuleSymbol> IAssemblySymbol.Modules => this.Modules;

        public abstract ICollection<string> TypeNames { get; }

        public abstract ICollection<string> NamespaceNames { get; }

        public abstract bool MightContainExtensionMethods { get; }

        public abstract AssemblyMetadata GetMetadata();

        public abstract bool GivesAccessTo(IAssemblySymbol toAssembly);

        INamedTypeSymbol IAssemblySymbol.GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            return this.GetTypeByMetadataName(fullyQualifiedMetadataName);
        }

        INamedTypeSymbol IAssemblySymbol.ResolveForwardedType(string fullyQualifiedMetadataName)
        {
            return this.ResolveForwardedType(fullyQualifiedMetadataName);
        }

        public sealed override SymbolKind Kind => SymbolKind.Assembly;

        public override bool IsStatic => false;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitAssembly(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitAssembly(this);
        }
    }
}
