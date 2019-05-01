using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading;
    using CSharpAssemblySymbol = Microsoft.CodeAnalysis.CSharp.Symbols.AssemblySymbol;
    using CSharpModuleSymbol = Microsoft.CodeAnalysis.CSharp.Symbols.ModuleSymbol;

    public class ModuleSymbol : Symbol, IModuleSymbol
    {
        private CSharpSymbolMap _symbolMap;
        private AssemblySymbol _lazyAssemblySymbol;
        private CSharpModuleSymbol _csharpModule;
        private ImmutableArray<AssemblySymbol> _lazyReferencedAssemblySymbols;

        protected ModuleSymbol(IModuleSymbol module)
        {
            if (module is CSharpModuleSymbol csharpModule) _csharpModule = csharpModule;
            else throw new ArgumentException("The assembly must be a Microsoft.CodeAnalysis.CSharp.Symbols.ModuleSymbol.", nameof(module));
            _symbolMap = new CSharpSymbolMap();
        }

        internal static ModuleSymbol FromCSharp(CSharpModuleSymbol csharpModule)
        {
            return new ModuleSymbol(csharpModule);
        }

        internal CSharpSymbolMap CSharpSymbolMap => _symbolMap;

        public override AssemblySymbol ContainingAssembly
        {
            get
            {
                if (_csharpModule.ContainingAssembly == null) return null;
                if (_lazyAssemblySymbol == null)
                {
                    Interlocked.CompareExchange(ref _lazyAssemblySymbol, _symbolMap.GetAssemblySymbol(_csharpModule.ContainingAssembly), null);
                }
                return _lazyAssemblySymbol;
            }
        }

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => this.ContainingAssembly;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public NamespaceSymbol GlobalNamespace => CSharpSymbolMap.GetNamespaceSymbol(_csharpModule.GlobalNamespace);

        INamespaceSymbol IModuleSymbol.GlobalNamespace => this.GlobalNamespace;

        public ImmutableArray<AssemblyIdentity> ReferencedAssemblies => _csharpModule.ReferencedAssemblies;

        public ImmutableArray<AssemblySymbol> ReferencedAssemblySymbols
        {
            get
            {
                if (_lazyReferencedAssemblySymbols.IsDefault)
                {
                    var assemblies = _csharpModule.ReferencedAssemblySymbols.Select(csharpAssembly => _symbolMap.GetAssemblySymbol(csharpAssembly)).ToImmutableArray();
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyReferencedAssemblySymbols, assemblies);
                }
                return _lazyReferencedAssemblySymbols;
            }
        }

        ImmutableArray<IAssemblySymbol> IModuleSymbol.ReferencedAssemblySymbols => StaticCast<IAssemblySymbol>.From(this.ReferencedAssemblySymbols);

        public ModuleMetadata GetMetadata()
        {
            return _csharpModule.GetMetadata();
        }

        public NamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol)
        {
            return _symbolMap.GetNamespaceSymbol(_csharpModule.GetModuleNamespace(namespaceSymbol));
        }

        INamespaceSymbol IModuleSymbol.GetModuleNamespace(INamespaceSymbol namespaceSymbol)
        {
            return this.GetModuleNamespace(namespaceSymbol);
        }
    }
}
