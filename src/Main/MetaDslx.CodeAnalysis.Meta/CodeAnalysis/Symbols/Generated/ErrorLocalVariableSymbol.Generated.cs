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
	public abstract partial class ErrorLocalVariableSymbol : MetaDslx.CodeAnalysis.Symbols.LocalVariableSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        private readonly Symbol _container;
        private readonly object? _modelObject;

        public ErrorLocalVariableSymbol(Symbol container, object? modelObject)
        {
            if (container is null) throw new ArgumentNullException(nameof(container));
            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));
            _container = container;
            _modelObject = modelObject;
        }

        public sealed override Language Language => ContainingModule.Language;

        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;

        public object ModelObject => _modelObject;

        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;

        public sealed override Symbol ContainingSymbol => _container;

        public sealed override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        public sealed override string Name => string.Empty;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> Attributes => default;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> TypeParameters => default;

        public override global::Microsoft.CodeAnalysis.Accessibility DeclaredAccessibility => default;

        public override bool IsExtern => default;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> Members => default;

        public override bool IsConst => default;

        public override global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol Type => default;

        public override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol DefaultValue => default;

    }
}
