using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class AssemblySymbol : Symbol, IAssemblySymbol
    {
        public abstract bool IsInteractive { get; }
        public abstract AssemblyIdentity Identity { get; }
        public abstract INamespaceSymbol GlobalNamespace { get; }
        public abstract ImmutableArray<ModuleSymbol> Modules { get; }

        /// <summary>
        /// Gets the set of type identifiers from this assembly.
        /// </summary>
        /// <remarks>
        /// These names are the simple identifiers for the type, and do not include namespaces,
        /// outer type names, or type parameters.
        /// 
        /// This functionality can be used for features that want to quickly know if a name could be
        /// a type for performance reasons.  For example, classification does not want to incur an
        /// expensive binding call cost if it knows that there is no type with the name that they
        /// are looking at.
        /// </remarks>
        public abstract ICollection<string> TypeNames { get; }

        /// <summary>
        /// Gets the set of namespace names from this assembly.
        /// </summary>
        public abstract ICollection<string> NamespaceNames { get; }

        /// <summary>
        /// Returns true if this assembly might contain extension methods. If this property
        /// returns false, there are no extension methods in this assembly.
        /// </summary>
        /// <remarks>
        /// This property allows the search for extension methods to be narrowed quickly.
        /// </remarks>
        public abstract bool MightContainExtensionMethods { get; }

        /// <summary>
        /// If this symbol represents a metadata assembly returns the underlying <see cref="AssemblyMetadata"/>.
        /// 
        /// Otherwise, this returns <see langword="null"/>.
        /// </summary>
        public abstract AssemblyMetadata GetMetadata();

        public abstract INamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName);
        public abstract bool GivesAccessTo(IAssemblySymbol toAssembly);
        public abstract INamedTypeSymbol ResolveForwardedType(string fullyQualifiedMetadataName);

        #region Symbol

        public override SymbolKind Kind => SymbolKind.Assembly;

        public override ModelSymbolInfo ModelSymbolInfo => null;

        public override Symbol ContainingSymbol => null;

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

        IEnumerable<IModuleSymbol> IAssemblySymbol.Modules => this.Modules;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitAssembly(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitAssembly(this);
        }

        #endregion
    }
}
