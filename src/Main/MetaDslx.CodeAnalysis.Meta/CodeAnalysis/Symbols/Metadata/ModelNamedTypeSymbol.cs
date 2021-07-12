using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Model
{
    public partial class ModelNamedTypeSymbol
    {
        private ImmutableArray<string> _lazyMemberNames;

        public override IEnumerable<string> MemberNames
        {
            get
            {
                if (_lazyMemberNames.IsDefault)
                {
                    var sf = this.SymbolFactory;
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyMemberNames, Language.SymbolFacts.GetChildren(_modelObject).Select(child => Language.SymbolFacts.GetName(child)).ToImmutableArray());
                }
                return _lazyMemberNames;
            }
        }

        public sealed override NamedTypeSymbol ContainingType => _container as NamedTypeSymbol;

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            return this.GetDeclaredBaseTypes(basesBeingResolved);
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            var result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            var symbolFacts = Language.SymbolFacts;
            foreach (var prop in symbolFacts.GetPropertiesForSymbol(this.ModelObject, SymbolConstants.DeclaredBaseTypesProperty))
            {
                var baseTypeObjects = symbolFacts.GetPropertyValues(this.ModelObject, prop);
                var baseTypeSymbols = SymbolFactory.ResolveSymbols(baseTypeObjects).OfType<NamedTypeSymbol>();
                result.AddRange(baseTypeSymbols);
            }
            return result.ToImmutableAndFree();
        }

    }
}
