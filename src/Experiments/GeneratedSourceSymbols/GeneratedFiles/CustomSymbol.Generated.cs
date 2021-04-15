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
namespace MetaDslx.Bootstrap.SourceGenerators
{
	public partial class CustomSymbol
	{
        private readonly Symbol _containingSymbol;
        private readonly MergedDeclaration _declaration;
        private readonly CompletionState _state;
        private DiagnosticBag _diagnostics;
		public CustomSymbol(Symbol containingSymbol, MergedDeclaration declaration)
		{
            Debug.Assert(declaration != null);
            _containingSymbol = containingSymbol;
            _declaration = declaration;
            _state = CompletionState.Create(Language);
		}
        public override Symbol ContainingSymbol => _containingSymbol;
        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;
        public MergedDeclaration MergedDeclaration => _declaration;
        public override ImmutableArray<Location> Locations => _declaration.NameLocations;
        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;
        public ImmutableArray<Diagnostic> Diagnostics => _diagnostics != null ? _diagnostics.ToReadOnly() : ImmutableArray<Diagnostic>.Empty;
        private void AddSymbolDiagnostics(DiagnosticBag diagnostics)
        {
            if (!diagnostics.IsEmptyWithoutResolution)
            {
                LanguageCompilation compilation = this.DeclaringCompilation;
                Debug.Assert(compilation != null);
                if (_diagnostics == null) _diagnostics = new DiagnosticBag();
                _diagnostics.AddRange(diagnostics);
            }
        }
        public override void Accept(CodeAnalysis.SymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }
        public override TResult Accept<TResult>(CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }
        public override void Accept(CodeAnalysis.Symbols.SymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }
        public override TResult Accept<TResult>(CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }
        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            throw new NotImplementedException();
        }
	}
}
