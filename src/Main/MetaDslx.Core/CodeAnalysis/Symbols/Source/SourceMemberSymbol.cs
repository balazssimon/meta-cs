using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class SourceMemberSymbol : MemberSymbol, ISourceSymbol
    {
        private readonly Symbol _container;
        private readonly MergedDeclaration _mergedDeclaration;

        private SymbolCompletionState _state;
        private ImmutableArray<Location> _locations;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

        public SourceMemberSymbol(
            Symbol container,
            MergedDeclaration mergedDeclaration,
            DiagnosticBag diagnostics)
        {
            Debug.Assert(mergedDeclaration != null);
            _container = container;
            _mergedDeclaration = mergedDeclaration;

            foreach (var singleDeclaration in mergedDeclaration.Declarations)
            {
                diagnostics.AddRange(singleDeclaration.Diagnostics);
            }
        }

        public override SymbolKind Kind => SymbolKind.Unknown;

        public MergedDeclaration MergedDeclaration => _mergedDeclaration;

        public override Symbol ContainingSymbol => _container;

        public override string Name => _mergedDeclaration.Name;

        public override LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(_mergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));
            }
            return _lazyLexicalSortKey;
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                if (_locations.IsDefault)
                {
                    ImmutableInterlocked.InterlockedCompareExchange(ref _locations, _mergedDeclaration.NameLocations, default);
                }
                return _locations;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _mergedDeclaration.SyntaxReferences;

        public override Accessibility DeclaredAccessibility => throw new NotImplementedException();

        public override bool IsStatic => throw new NotImplementedException();

        public override bool IsVirtual => throw new NotImplementedException();

        public override bool IsOverride => throw new NotImplementedException();

        public override bool IsAbstract => throw new NotImplementedException();

        public override bool IsSealed => throw new NotImplementedException();

        public override bool IsExtern => throw new NotImplementedException();

        public override ObsoleteAttributeData ObsoleteAttributeData => throw new NotImplementedException();

        public override ModelSymbolInfo ModelSymbolInfo => this._mergedDeclaration.Kind;
    }
}
