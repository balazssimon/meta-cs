using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using Roslyn.Utilities;
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;

    public class CSharpAssemblySymbol : MetadataOrSourceAssemblySymbol
    {
        private CSharpSymbols.AssemblySymbol _csharpAssembly;
        private ImmutableArray<ModuleSymbol> _lazyModules;

        /// <summary>
        /// An array of cached Cor types defined in this assembly.
        /// Lazily filled by GetSpecialType method.
        /// </summary>
        /// <remarks></remarks>
        private NamedTypeSymbol[] _lazySpecialTypes;

        /// <summary>
        /// How many Cor types have we cached so far.
        /// </summary>
        private int _cachedSpecialTypes;

        private CSharpAssemblySymbol(CSharpSymbols.AssemblySymbol csharpAssembly)
        {
            _csharpAssembly = csharpAssembly;
        }

        internal static CSharpAssemblySymbol FromCSharp(CSharpSymbols.AssemblySymbol csharpAssembly)
        {
            return new CSharpAssemblySymbol(csharpAssembly);
        }

        internal CSharpSymbols.AssemblySymbol CSharpAssembly => _csharpAssembly;

        public override AssemblySymbol ContainingAssembly => null;

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => null;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public override ImmutableArray<ModuleSymbol> Modules
        {
            get
            {
                if (_lazyModules.IsDefault)
                {
                    var modules = CSharpSymbolMap.GetModuleSymbols(_csharpAssembly.Modules);
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyModules, modules);
                }
                return _lazyModules;
            }
        }

        public override NamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            return CSharpSymbolMap.GetNamedTypeSymbol(_csharpAssembly.GetTypeByMetadataName(fullyQualifiedMetadataName));
        }

        public override bool IsInteractive => _csharpAssembly.IsInteractive;

        public override AssemblyIdentity Identity => _csharpAssembly.Identity;

        public override ICollection<string> TypeNames => _csharpAssembly.TypeNames;

        public override ICollection<string> NamespaceNames => _csharpAssembly.NamespaceNames;

        public override bool MightContainExtensionMethods => _csharpAssembly.MightContainExtensionMethods;

        public override AssemblyMetadata GetMetadata()
        {
            return _csharpAssembly.GetMetadata();
        }

        public override bool GivesAccessTo(IAssemblySymbol toAssembly)
        {
            if (toAssembly is CSharpAssemblySymbol assembly) return ((IAssemblySymbol)_csharpAssembly).GivesAccessTo(assembly._csharpAssembly);
            else return ((IAssemblySymbol)_csharpAssembly).GivesAccessTo(toAssembly);
        }

        public override bool IsStatic => false;

        public override ImmutableArray<Location> Locations => _csharpAssembly.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpAssembly.DeclaringSyntaxReferences;

        /// <summary>
        /// Continue looking for declaration of predefined CorLib type in this Assembly
        /// while symbols for new type declarations are constructed.
        /// </summary>
        public override bool KeepLookingForDeclaredSpecialTypes => _csharpAssembly.KeepLookingForDeclaredSpecialTypes;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitAssembly(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitAssembly(this);
        }

        /// <summary>
        /// Register declaration of predefined CorLib type in this Assembly.
        /// </summary>
        /// <param name="corType"></param>
        internal override sealed void RegisterDeclaredSpecialType(NamedTypeSymbol corType)
        {
            SpecialType typeId = corType.SpecialType;
            Debug.Assert(typeId != SpecialType.None);
            Debug.Assert(ReferenceEquals(corType.ContainingAssembly, this));
            Debug.Assert(corType.ContainingModule.Ordinal == 0);
            Debug.Assert(ReferenceEquals(this.CorLibrary, this));

            if (_lazySpecialTypes == null)
            {
                Interlocked.CompareExchange(ref _lazySpecialTypes,
                    new NamedTypeSymbol[(int)SpecialType.Count + 1], null);
            }

            if ((object)Interlocked.CompareExchange(ref _lazySpecialTypes[(int)typeId], corType, null) != null)
            {
                Debug.Assert(ReferenceEquals(corType, _lazySpecialTypes[(int)typeId]) ||
                                        (corType.Kind == SymbolKind.ErrorType &&
                                        _lazySpecialTypes[(int)typeId].Kind == SymbolKind.ErrorType));
            }
            else
            {
                Interlocked.Increment(ref _cachedSpecialTypes);
                Debug.Assert(_cachedSpecialTypes > 0 && _cachedSpecialTypes <= (int)SpecialType.Count);
            }
        }

        /// <summary>
        /// Lookup declaration for predefined CorLib type in this Assembly.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override NamedTypeSymbol GetDeclaredSpecialType(SpecialType type)
        {
#if DEBUG
            foreach (var module in this.Modules)
            {
                Debug.Assert(module.ReferencedAssemblies.Length == 0);
            }
#endif

            if (_lazySpecialTypes == null || (object)_lazySpecialTypes[(int)type] == null)
            {
                MetadataTypeName emittedName = MetadataTypeName.FromFullName(type.GetMetadataName(), useCLSCompliantNameArityEncoding: true);
                ModuleSymbol module = this.Modules[0];
                NamedTypeSymbol result = CSharpSymbolMap.GetNamedTypeSymbol(_csharpAssembly.LookupTopLevelMetadataType(ref emittedName, true));
                if (result.Kind != SymbolKind.ErrorType && result.DeclaredAccessibility != Accessibility.Public)
                {
                    result = new MissingMetadataTypeSymbol.TopLevel(module, ref emittedName, type);
                }
                RegisterDeclaredSpecialType(result);
            }

            return _lazySpecialTypes[(int)type];
        }

        internal override NamedTypeSymbol TryLookupForwardedMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }
    }
}
