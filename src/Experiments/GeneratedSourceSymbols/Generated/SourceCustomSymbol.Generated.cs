using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace GeneratedSourceSymbols.Source
{
	public partial class SourceCustomSymbol : GeneratedSourceSymbols.Model.ModelCustomSymbol, MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol
	{
        private readonly MergedDeclaration _declaration;
		public SourceCustomSymbol(Symbol containingSymbol, object modelObject, MergedDeclaration declaration)
            : base(containingSymbol, modelObject)
        {
            Debug.Assert(declaration != null);
            _declaration = declaration;
		}

        public MergedDeclaration MergedDeclaration => _declaration;

        public override ImmutableArray<Location> Locations => _declaration.NameLocations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;

        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)
        {
            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));
            return FindBinders.FindSymbolBinder(this, reference);
        }

        public Symbol GetChildSymbol(SyntaxReference syntax)
        {
            foreach (var child in this.ChildSymbols)
            {
                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))
                {
                    return child;
                }
            }
            return null;
        }

        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return default;
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override global::GeneratedSourceSymbols.CustomSymbol CompleteSymbolProperty_Left(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return default;
        }
        protected override global::GeneratedSourceSymbols.CustomSymbol CompleteSymbolProperty_Right(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return default;
        }
        protected override global::System.Collections.Immutable.ImmutableArray<global::GeneratedSourceSymbols.CustomSymbol> CompleteSymbolProperty_CustomArray(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return default;
        }
        protected override global::System.Collections.Immutable.ImmutableArray<int> CompleteSymbolProperty_IntArray(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return default;
        }
        protected override int CompleteSymbolProperty_Int(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return default;
        }

	}
}
