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
	public partial class MetaLabelSymbol : MetaDslx.CodeAnalysis.Symbols.Model.ModelLabelSymbol
	{
        public MetaLabelSymbol(Symbol container, object modelObject)
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
            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override string CompleteSymbolProperty_Name(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> CompleteSymbolProperty_Attributes(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.Symbol>(this, nameof(Attributes), diagnostics, cancellationToken);
        }
        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> CompleteSymbolProperty_Members(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Members), diagnostics, cancellationToken);
        }
        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol> CompleteSymbolProperty_TypeMembers(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol>(this, nameof(TypeMembers), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }
    }
}
