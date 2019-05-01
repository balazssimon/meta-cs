﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading;
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;

    public class CSharpModuleSymbol : ModuleSymbol
    {
        private AssemblySymbol _lazyAssemblySymbol;
        private CSharpSymbols.ModuleSymbol _csharpModule;
        private ImmutableArray<AssemblySymbol> _lazyReferencedAssemblySymbols;

        private CSharpModuleSymbol(CSharpSymbols.ModuleSymbol csharpModule)
        {
            _csharpModule = csharpModule;
        }

        internal static CSharpModuleSymbol FromCSharp(CSharpSymbols.ModuleSymbol csharpModule)
        {
            return new CSharpModuleSymbol(csharpModule);
        }

        public override AssemblySymbol ContainingAssembly
        {
            get
            {
                if (_csharpModule.ContainingAssembly == null) return null;
                if (_lazyAssemblySymbol == null)
                {
                    Interlocked.CompareExchange(ref _lazyAssemblySymbol, CSharpSymbolMap.GetAssemblySymbol(_csharpModule.ContainingAssembly), null);
                }
                return _lazyAssemblySymbol;
            }
        }

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => this.ContainingAssembly;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public override NamespaceSymbol GlobalNamespace => CSharpSymbolMap.GetNamespaceSymbol(_csharpModule.GlobalNamespace);

        public override ImmutableArray<AssemblyIdentity> ReferencedAssemblies => _csharpModule.ReferencedAssemblies;

        public override ImmutableArray<AssemblySymbol> ReferencedAssemblySymbols
        {
            get
            {
                if (_lazyReferencedAssemblySymbols.IsDefault)
                {
                    var assemblies = _csharpModule.ReferencedAssemblySymbols.Select(csharpAssembly => (AssemblySymbol)CSharpSymbolMap.GetAssemblySymbol(csharpAssembly)).ToImmutableArray();
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyReferencedAssemblySymbols, assemblies);
                }
                return _lazyReferencedAssemblySymbols;
            }
        }

        public override ModuleMetadata GetMetadata()
        {
            return _csharpModule.GetMetadata();
        }

        public override NamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol)
        {
            return CSharpSymbolMap.GetNamespaceSymbol(_csharpModule.GetModuleNamespace(namespaceSymbol));
        }

        public override ImmutableArray<Location> Locations => _csharpModule.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpModule.DeclaringSyntaxReferences;
    }
}
