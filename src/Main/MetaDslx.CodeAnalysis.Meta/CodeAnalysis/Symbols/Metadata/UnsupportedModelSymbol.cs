using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public sealed class UnsupportedModelSymbol : ErrorTypeSymbol
    {
        private Symbol _container;
        private object _modelObject;

        internal UnsupportedModelSymbol(Symbol container, object modelObject)
        {
            _container = container;
            _modelObject = modelObject;
        }

        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        public object ModelObject => _modelObject;

        public override Symbol ContainingSymbol => _container;

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override DiagnosticInfo ErrorInfo => LanguageDiagnosticInfo.EmptyErrorInfo;

        public override void Accept(SymbolVisitor visitor)
        {
            // nop
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return default;
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return default;
        }

    }
}
