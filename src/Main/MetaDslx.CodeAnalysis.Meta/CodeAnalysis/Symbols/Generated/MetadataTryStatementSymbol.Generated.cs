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
	public partial class MetadataTryStatementSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionTryStatementSymbol
	{
        public MetadataTryStatementSymbol(Symbol container, object modelObject)
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

        protected override global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol CompleteSymbolProperty_Body(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol>(this, nameof(Body), diagnostics, cancellationToken);
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.CatchClauseSymbol> CompleteSymbolProperty_Catches(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.CatchClauseSymbol>(this, nameof(Catches), diagnostics, cancellationToken);
        }

        protected override global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol CompleteSymbolProperty_Finally(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol>(this, nameof(Finally), diagnostics, cancellationToken);
        }

        protected override global::MetaDslx.CodeAnalysis.Symbols.LabelSymbol CompleteSymbolProperty_ExitLabel(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.LabelSymbol>(this, nameof(ExitLabel), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }
    }
}
