using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;

    public abstract class AssemblySymbol : Symbol, IAssemblySymbol
    {
        /// <summary>
        /// The system assembly, which provides primitive types like Object, String, etc., e.g. mscorlib.dll. 
        /// The value is provided by ReferenceManager and must not be modified. For SourceAssemblySymbol, non-missing 
        /// coreLibrary must match one of the referenced assemblies returned by GetReferencedAssemblySymbols() method of 
        /// the main module. If there is no existing assembly that can be used as a source for the primitive types, 
        /// the value is a Compilation.MissingCorLibrary. 
        /// </summary>
        private AssemblySymbol _corLibrary;

        protected AssemblySymbol()
        {
        }

        /// <summary>
        /// The system assembly, which provides primitive types like Object, String, etc., e.g. mscorlib.dll. 
        /// The value is MissingAssemblySymbol if none of the referenced assemblies can be used as a source for the 
        /// primitive types and the owning assembly cannot be used as the source too. Otherwise, it is one of 
        /// the referenced assemblies returned by GetReferencedAssemblySymbols() method or the owning assembly.
        /// </summary>
        internal AssemblySymbol CorLibrary
        {
            get
            {
                return _corLibrary;
            }
        }

        /// <summary>
        /// A helper method for ReferenceManager to set the system assembly, which provides primitive 
        /// types like Object, String, etc., e.g. mscorlib.dll. 
        /// </summary>
        internal void SetCorLibrary(AssemblySymbol corLibrary)
        {
            Debug.Assert((object)_corLibrary == null);
            _corLibrary = corLibrary;
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

        public abstract bool KeepLookingForDeclaredSpecialTypes { get; }

        public abstract NamedTypeSymbol GetDeclaredSpecialType(SpecialType type);

        public abstract void RegisterDeclaredSpecialType(NamedTypeSymbol corType);

        public abstract Symbol GetDeclaredSpecialTypeMember(SpecialMember member);

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
