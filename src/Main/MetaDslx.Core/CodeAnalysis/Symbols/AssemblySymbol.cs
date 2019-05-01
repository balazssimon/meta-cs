using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpAssemblySymbol = Microsoft.CodeAnalysis.CSharp.Symbols.AssemblySymbol;

    public class AssemblySymbol : Symbol, IAssemblySymbol
    {
        private CSharpAssemblySymbol _csharpAssembly;
        private CSharpSymbolMap _symbolMap;
        private ImmutableArray<ModuleSymbol> _lazyModules;

        protected AssemblySymbol(IAssemblySymbol assembly)
        {
            if (assembly is CSharpAssemblySymbol csharpAssembly) _csharpAssembly = csharpAssembly;
            else throw new ArgumentException("The assembly must be a Microsoft.CodeAnalysis.CSharp.Symbols.AssemblySymbol.", nameof(assembly));
            _symbolMap = new CSharpSymbolMap();
        }

        internal static AssemblySymbol FromCSharp(CSharpAssemblySymbol csharpAssembly)
        {
            return new AssemblySymbol(csharpAssembly);
        }

        internal CSharpSymbolMap CSharpSymbolMap => _symbolMap;

        public override AssemblySymbol ContainingAssembly => null;

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => null;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public virtual NamespaceSymbol GlobalNamespace => _symbolMap.GetNamespaceSymbol(_csharpAssembly.GlobalNamespace);

        public ImmutableArray<ModuleSymbol> Modules
        {
            get
            {
                if (_lazyModules.IsDefault)
                {
                    var modules = _csharpAssembly.Modules.Select(csharpModule => _symbolMap.GetModuleSymbol(csharpModule)).ToImmutableArray();
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyModules, modules);
                }
                return _lazyModules;
            }
        }

        public NamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            return _symbolMap.GetNamedTypeSymbol(_csharpAssembly.GetTypeByMetadataName(fullyQualifiedMetadataName));
        }

        public NamedTypeSymbol ResolveForwardedType(string fullyQualifiedMetadataName)
        {
            return _symbolMap.GetNamedTypeSymbol(_csharpAssembly.ResolveForwardedType(fullyQualifiedMetadataName));
        }

        public bool IsInteractive => _csharpAssembly.IsInteractive;

        public AssemblyIdentity Identity => _csharpAssembly.Identity;

        INamespaceSymbol IAssemblySymbol.GlobalNamespace => this.GlobalNamespace;

        IEnumerable<IModuleSymbol> IAssemblySymbol.Modules => this.Modules;

        public ICollection<string> TypeNames => _csharpAssembly.TypeNames;

        public ICollection<string> NamespaceNames => _csharpAssembly.NamespaceNames;

        public bool MightContainExtensionMethods => _csharpAssembly.MightContainExtensionMethods;

        public AssemblyMetadata GetMetadata()
        {
            return _csharpAssembly.GetMetadata();
        }

        INamedTypeSymbol IAssemblySymbol.GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            return this.GetTypeByMetadataName(fullyQualifiedMetadataName);
        }

        public bool GivesAccessTo(IAssemblySymbol toAssembly)
        {
            if (toAssembly is AssemblySymbol assembly) return ((IAssemblySymbol)_csharpAssembly).GivesAccessTo(assembly._csharpAssembly);
            else return ((IAssemblySymbol)_csharpAssembly).GivesAccessTo(toAssembly);
        }

        INamedTypeSymbol IAssemblySymbol.ResolveForwardedType(string fullyQualifiedMetadataName)
        {
            return this.ResolveForwardedType(fullyQualifiedMetadataName);
        }
    }
}
