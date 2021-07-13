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

    }
}
