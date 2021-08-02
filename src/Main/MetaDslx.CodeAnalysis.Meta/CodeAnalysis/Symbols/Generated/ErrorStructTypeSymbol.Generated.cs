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
	public partial class ErrorStructTypeSymbol : MetaDslx.CodeAnalysis.Symbols.StructTypeSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol, MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol
	{
        private readonly Symbol _container;
        private readonly MergedDeclaration? _declaration;
        private readonly object? _modelObject;

        public ErrorStructTypeSymbol(Symbol container, object? modelObject = null, MergedDeclaration? declaration = null)
        {
            if (container is null) throw new ArgumentNullException(nameof(container));
            _container = container;
            _modelObject = modelObject;
        }

        public sealed override Language Language => ContainingModule.Language;

        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;

        public object ModelObject => _modelObject;

        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;

        public MergedDeclaration MergedDeclaration => _declaration;
        public MetaDslx.CodeAnalysis.Binding.BinderPosition<MetaDslx.CodeAnalysis.Binding.Binders.SymbolBinder> GetBinder(SyntaxReference syntax) => default;
        public Symbol GetChildSymbol(SyntaxReference syntax) => null;

        public override ImmutableArray<Location> Locations => _declaration?.NameLocations ?? ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration?.SyntaxReferences ?? ImmutableArray<SyntaxReference>.Empty;

        public sealed override Symbol ContainingSymbol => _container;

        public sealed override bool IsError => true;

        public sealed override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        public sealed override string Name => _modelObject is not null ? Language.SymbolFacts.GetName(_modelObject) : string.Empty;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> Attributes => default;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> TypeParameters => default;

        public override global::Microsoft.CodeAnalysis.Accessibility DeclaredAccessibility => default;

        public override bool IsExtern => default;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> Members => default;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol> BaseTypes => default;

        public override bool IsAbstract => default;

        public override bool IsSealed => default;

    }
}
