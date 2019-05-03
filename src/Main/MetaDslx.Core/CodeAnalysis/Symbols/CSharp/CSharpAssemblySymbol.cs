using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;

    public class CSharpAssemblySymbol : AssemblySymbol
    {
        private CSharpSymbols.AssemblySymbol _csharpAssembly;
        private ImmutableArray<ModuleSymbol> _lazyModules;

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

        public override NamespaceSymbol GlobalNamespace => CSharpSymbolMap.GetNamespaceSymbol(_csharpAssembly.GlobalNamespace);

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

        public override NamedTypeSymbol ResolveForwardedType(string fullyQualifiedMetadataName)
        {
            return CSharpSymbolMap.GetNamedTypeSymbol(_csharpAssembly.ResolveForwardedType(fullyQualifiedMetadataName));
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
