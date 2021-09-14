using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpSymbol = Microsoft.CodeAnalysis.CSharp.Symbol;
    using Roslyn.Utilities;
    using Microsoft.CodeAnalysis.PooledObjects;

    public class CSharpAttributeSymbol : AttributeSymbol
    {
        private CSharpModuleSymbol _module;
        private Symbol _container;
        private CSharpAttributeData _attributeData;
        private CSharpNamedTypeSymbol _csharpSymbol;
        private ImmutableArray<NamedTypeSymbol> _lazyBaseTypes;

        internal CSharpAttributeSymbol(Symbol container, CSharpModuleSymbol module, CSharpSymbols.CSharpAttributeData attributeData)
        {
            _container = container;
            _module = module;
            _attributeData = new CSharpAttributeData(this, attributeData);
            _csharpSymbol = _attributeData.AttributeClass;
        }

        public override Language Language => CSharpLanguage.Instance;

        internal CSharpSymbolMap CSharpSymbolMap => _module.CSharpSymbolMap;

        public override string Name => _csharpSymbol.Name;

        public override string MetadataName => _csharpSymbol.MetadataName;

        public override bool MangleName => _csharpSymbol.MangleName;

        public override Symbol ContainingSymbol => _container;

        public override ImmutableArray<Location> Locations => _csharpSymbol.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpSymbol.DeclaringSyntaxReferences;

        public override TypeSymbol AttributeType => _attributeData.AttributeClass;

        public override ImmutableArray<ArgumentSymbol> Arguments => ImmutableArray<ArgumentSymbol>.Empty;

        public override ImmutableArray<ExpressionSymbol> Initializers => ImmutableArray<ExpressionSymbol>.Empty;

        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        private class CSharpAttributeData : AttributeData
        {
            private CSharpAttributeSymbol _symbol;
            private CSharpSymbols.CSharpAttributeData _csharpAttributeData;

            public CSharpAttributeData(CSharpAttributeSymbol symbol, CSharpSymbols.CSharpAttributeData attributeData)
            {
                _symbol = symbol;
                _csharpAttributeData = attributeData;
            }

            public CSharpNamedTypeSymbol AttributeClass => (CSharpNamedTypeSymbol)_symbol.CSharpSymbolMap.GetNamedTypeSymbol(_csharpAttributeData.AttributeClass);

            protected override INamedTypeSymbol? CommonAttributeClass => (INamedTypeSymbol)_csharpAttributeData.AttributeClass.ISymbol;

            protected override IMethodSymbol? CommonAttributeConstructor => throw new NotImplementedException();

            protected override SyntaxReference? CommonApplicationSyntaxReference => throw new NotImplementedException();

            protected internal override ImmutableArray<TypedConstant> CommonConstructorArguments => throw new NotImplementedException();

            protected internal override ImmutableArray<KeyValuePair<string, TypedConstant>> CommonNamedArguments => throw new NotImplementedException();
        }
    }
}
