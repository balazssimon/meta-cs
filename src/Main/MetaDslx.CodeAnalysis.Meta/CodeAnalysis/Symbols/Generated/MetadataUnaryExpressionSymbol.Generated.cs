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

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
	public partial class MetadataUnaryExpressionSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionUnaryExpressionSymbol
	{
        public MetadataUnaryExpressionSymbol(Symbol container, object modelObject)
            : base(container, modelObject)
        {
        }

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;
        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);
        }

        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> CompleteSymbolProperty_Attributes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.Symbol>(this, nameof(Attributes), diagnostics, cancellationToken);
        }

        protected override global::MetaDslx.CodeAnalysis.Symbols.UnaryOperatorKind CompleteSymbolProperty_OperatorKind(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.UnaryOperatorKind>(this, nameof(OperatorKind), diagnostics, cancellationToken);
        }

        protected override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol CompleteSymbolProperty_Operand(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol>(this, nameof(Operand), diagnostics, cancellationToken);
        }

        protected override bool CompleteSymbolProperty_IsChecked(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsChecked), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }
    }
}