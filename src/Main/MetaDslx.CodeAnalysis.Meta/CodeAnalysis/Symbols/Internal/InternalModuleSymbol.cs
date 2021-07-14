using Microsoft.Cci;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Internal
{
    internal class InternalModuleSymbol : IModuleSymbolInternal
    {
        private readonly IModuleSymbol _module;

        public InternalModuleSymbol(IModuleSymbol module)
        {
            _module = module;
        }

        public Microsoft.CodeAnalysis.SymbolKind Kind => _module.Kind;

        public string Name => _module.Name;

        public string MetadataName => _module.MetadataName;

        public Compilation DeclaringCompilation => throw new NotImplementedException();

        public ISymbolInternal ContainingSymbol => throw new NotImplementedException();

        public IAssemblySymbolInternal ContainingAssembly => throw new NotImplementedException();

        public IModuleSymbolInternal ContainingModule => throw new NotImplementedException();

        public INamedTypeSymbolInternal ContainingType => throw new NotImplementedException();

        public INamespaceSymbolInternal ContainingNamespace => throw new NotImplementedException();

        public bool IsDefinition => throw new NotImplementedException();

        public ImmutableArray<Location> Locations => throw new NotImplementedException();

        public bool IsImplicitlyDeclared => throw new NotImplementedException();

        public Accessibility DeclaredAccessibility => throw new NotImplementedException();

        public bool IsStatic => throw new NotImplementedException();

        public bool IsVirtual => throw new NotImplementedException();

        public bool IsOverride => throw new NotImplementedException();

        public bool IsAbstract => throw new NotImplementedException();

        public bool Equals(ISymbolInternal? other, TypeCompareKind compareKind)
        {
            throw new NotImplementedException();
        }

        public IReference GetCciAdapter()
        {
            throw new NotImplementedException();
        }

        public ISymbol GetISymbol()
        {
            return _module;
        }
    }

}
