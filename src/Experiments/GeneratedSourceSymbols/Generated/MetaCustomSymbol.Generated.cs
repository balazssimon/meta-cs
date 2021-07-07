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

namespace GeneratedSourceSymbols.Metadata
{
	public partial class MetaCustomSymbol : GeneratedSourceSymbols.Model.ModelCustomSymbol
	{
        public MetaCustomSymbol(Symbol container, object modelObject)
            : base(container, modelObject)
        {
        }

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolFactory.GetChildSymbols(this.ModelObject);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override global::GeneratedSourceSymbols.CustomSymbol CompleteSymbolProperty_Left(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolFactory.GetSymbolPropertyValue<global::GeneratedSourceSymbols.CustomSymbol>(this, nameof(Left), this.ModelObject);
        }
        protected override global::GeneratedSourceSymbols.CustomSymbol CompleteSymbolProperty_Right(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolFactory.GetSymbolPropertyValue<global::GeneratedSourceSymbols.CustomSymbol>(this, nameof(Right), this.ModelObject);
        }
        protected override global::System.Collections.Immutable.ImmutableArray<global::GeneratedSourceSymbols.CustomSymbol> CompleteSymbolProperty_CustomArray(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolFactory.GetSymbolPropertyValues<global::GeneratedSourceSymbols.CustomSymbol>(this, nameof(CustomArray), this.ModelObject);
        }
        protected override global::System.Collections.Immutable.ImmutableArray<int> CompleteSymbolProperty_IntArray(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolFactory.GetSymbolPropertyValues<int>(this, nameof(IntArray), this.ModelObject);
        }
        protected override int CompleteSymbolProperty_Int(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolFactory.GetSymbolPropertyValue<int>(this, nameof(Int), this.ModelObject);
        }
    }
}
