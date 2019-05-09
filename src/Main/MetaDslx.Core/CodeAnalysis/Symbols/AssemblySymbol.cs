using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
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
        protected AssemblySymbol()
        {
        }

        /// <summary>
        /// The system assembly, which provides primitive types like Object, String, etc., e.g. mscorlib.dll. 
        /// The value is provided by ReferenceManager and must not be modified. For SourceAssemblySymbol, non-missing 
        /// coreLibrary must match one of the referenced assemblies returned by GetReferencedAssemblySymbols() method of 
        /// the main module. If there is no existing assembly that can be used as a source for the primitive types, 
        /// the value is a Compilation.MissingCorLibrary. 
        /// </summary>
        private AssemblySymbol _corLibrary;

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

        public virtual bool IsMissing => false;

        /// <summary>
        /// Lookup declaration for predefined CorLib type in this Assembly.
        /// </summary>
        /// <returns>The symbol for the pre-defined type or an error type if the type is not defined in the core library.</returns>
        public abstract NamedTypeSymbol GetDeclaredSpecialType(SpecialType type);

        /// <summary>
        /// Register declaration of predefined CorLib type in this Assembly.
        /// </summary>
        /// <param name="corType"></param>
        internal virtual void RegisterDeclaredSpecialType(NamedTypeSymbol corType)
        {
            throw ExceptionUtilities.Unreachable;
        }

        /// <summary>
        /// Lookup a top level type referenced from metadata, names should be
        /// compared case-sensitively.
        /// </summary>
        /// <param name="emittedName">
        /// Full type name with generic name mangling.
        /// </param>
        /// <param name="digThroughForwardedTypes">
        /// Take forwarded types into account.
        /// </param>
        /// <remarks></remarks>
        public NamedTypeSymbol LookupTopLevelMetadataType(ref MetadataTypeName emittedName, bool digThroughForwardedTypes)
        {
            return LookupTopLevelMetadataTypeWithCycleDetection(ref emittedName, visitedAssemblies: null, digThroughForwardedTypes: digThroughForwardedTypes);
        }

        /// <summary>
        /// Lookup a top level type referenced from metadata, names should be
        /// compared case-sensitively.  Detect cycles during lookup.
        /// </summary>
        /// <param name="emittedName">
        /// Full type name, possibly with generic name mangling.
        /// </param>
        /// <param name="visitedAssemblies">
        /// List of assemblies lookup has already visited (since type forwarding can introduce cycles).
        /// </param>
        /// <param name="digThroughForwardedTypes">
        /// Take forwarded types into account.
        /// </param>
        internal abstract NamedTypeSymbol LookupTopLevelMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies, bool digThroughForwardedTypes);

        /// <summary>
        /// Returns the type symbol for a forwarded type based its canonical CLR metadata name.
        /// The name should refer to a non-nested type. If type with this name is not forwarded,
        /// null is returned.
        /// </summary>
        public NamedTypeSymbol ResolveForwardedType(string fullyQualifiedMetadataName)
        {
            if (fullyQualifiedMetadataName == null)
            {
                throw new ArgumentNullException(nameof(fullyQualifiedMetadataName));
            }

            var emittedName = MetadataTypeName.FromFullName(fullyQualifiedMetadataName);
            return TryLookupForwardedMetadataType(ref emittedName);
        }

        /// <summary>
        /// Look up the given metadata type, if it is forwarded.
        /// </summary>
        public NamedTypeSymbol TryLookupForwardedMetadataType(ref MetadataTypeName emittedName)
        {
            return TryLookupForwardedMetadataTypeWithCycleDetection(ref emittedName, visitedAssemblies: null);
        }

        /// <summary>
        /// Look up the given metadata type, if it is forwarded.
        /// </summary>
        internal virtual NamedTypeSymbol TryLookupForwardedMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies)
        {
            return null;
        }

        internal ErrorTypeSymbol CreateCycleInTypeForwarderErrorTypeSymbol(ref MetadataTypeName emittedName)
        {
            DiagnosticInfo diagnosticInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_CycleInTypeForwarder, emittedName.FullName, this.Name);
            return new MissingMetadataTypeSymbol.TopLevelWithCustomErrorInfo(this.Modules[0], ref emittedName, diagnosticInfo);
        }

        internal ErrorTypeSymbol CreateMultipleForwardingErrorTypeSymbol(ref MetadataTypeName emittedName, ModuleSymbol forwardingModule, AssemblySymbol destination1, AssemblySymbol destination2)
        {
            var diagnosticInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_TypeForwardedToMultipleAssemblies, forwardingModule, this, emittedName.FullName, destination1, destination2);
            return new MissingMetadataTypeSymbol.TopLevelWithCustomErrorInfo(forwardingModule, ref emittedName, diagnosticInfo);
        }

        /// <summary>
        /// Continue looking for declaration of predefined CorLib type in this Assembly
        /// while symbols for new type declarations are constructed.
        /// </summary>
        public virtual bool KeepLookingForDeclaredSpecialTypes => throw ExceptionUtilities.Unreachable;

        /// <summary>
        /// Given a namespace symbol, returns the corresponding assembly specific namespace symbol
        /// </summary>
        internal NamespaceSymbol GetAssemblyNamespace(NamespaceSymbol namespaceSymbol)
        {
            if (namespaceSymbol.IsGlobalNamespace)
            {
                return this.GlobalNamespace;
            }

            NamespaceSymbol container = namespaceSymbol.ContainingNamespace;

            if ((object)container == null)
            {
                return this.GlobalNamespace;
            }

            if (namespaceSymbol.NamespaceKind == NamespaceKind.Assembly && namespaceSymbol.ContainingAssembly == this)
            {
                // this is already the correct assembly namespace
                return namespaceSymbol;
            }

            NamespaceSymbol assemblyContainer = GetAssemblyNamespace(container);

            if ((object)assemblyContainer == (object)container)
            {
                // Trivial case, container isn't merged.
                return namespaceSymbol;
            }

            if ((object)assemblyContainer == null)
            {
                return null;
            }

            return assemblyContainer.GetNestedNamespace(namespaceSymbol.Name);
        }

        public override AssemblySymbol ContainingAssembly => null;

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => null;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public abstract NamespaceSymbol GlobalNamespace { get; }

        public abstract ImmutableArray<ModuleSymbol> Modules { get; }

        public abstract NamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName);

        public virtual bool IsInteractive => false;

        public abstract AssemblyIdentity Identity { get; }

        INamespaceSymbol IAssemblySymbol.GlobalNamespace => this.GlobalNamespace;

        IEnumerable<IModuleSymbol> IAssemblySymbol.Modules => this.Modules;

        public abstract ICollection<string> TypeNames { get; }

        public abstract ICollection<string> NamespaceNames { get; }

        public virtual bool MightContainExtensionMethods => false;

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

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

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
