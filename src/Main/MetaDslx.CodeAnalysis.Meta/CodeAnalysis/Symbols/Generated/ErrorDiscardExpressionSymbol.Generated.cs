using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Error
{
	public partial class ErrorDiscardExpressionSymbol : MetaDslx.CodeAnalysis.Symbols.DiscardExpressionSymbol, MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol
	{
        private readonly Symbol _container;
        private readonly MergedDeclaration? _declaration;

        public ErrorDiscardExpressionSymbol(Symbol container, MergedDeclaration? declaration = null)
        {
            if (container is null) throw new ArgumentNullException(nameof(container));
            _container = container;
        }

        public sealed override Language Language => ContainingModule.Language;

        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;

        public MergedDeclaration MergedDeclaration => _declaration;
        public MetaDslx.CodeAnalysis.Binding.BinderPosition<MetaDslx.CodeAnalysis.Binding.Binders.SymbolBinder> GetBinder(SyntaxReference syntax) => default;
        public Symbol GetChildSymbol(SyntaxReference syntax) => null;

        public override ImmutableArray<Location> Locations => _declaration?.NameLocations ?? ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration?.SyntaxReferences ?? ImmutableArray<SyntaxReference>.Empty;

        public sealed override Symbol ContainingSymbol => _container;

        public sealed override bool IsError => true;

        public sealed override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        public sealed override string Name => string.Empty;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> Attributes => default;

    }
}
