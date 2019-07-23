// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Soal.Symbols;
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Soal
{
    public sealed class SoalLanguage : Language
    {
        public static readonly SoalLanguage Instance = new SoalLanguage();

		private SoalSyntaxFacts _syntaxFacts;
		private SoalSymbolFacts _symbolFacts;
		private SoalInternalSyntaxFactory _internalSyntaxFactory;
		private SoalSyntaxFactory _syntaxFactory;
		private SoalCompilationFactory _compilationFactory;

		private SoalLanguage()
		{
			_syntaxFacts = new SoalSyntaxFacts();
			_internalSyntaxFactory = new SoalInternalSyntaxFactory(_syntaxFacts);
			_syntaxFactory = new SoalSyntaxFactory(_internalSyntaxFactory);
			_symbolFacts = new SoalSymbolFacts();
			_compilationFactory = new SoalCompilationFactory();
		}

        public override string Name => "Soal";

        public new SoalSyntaxFacts SyntaxFacts => _syntaxFacts;
        protected override SyntaxFacts SyntaxFactsCore => this.SyntaxFacts;

        public new SoalSymbolFacts SymbolFacts => _symbolFacts;
        protected override SymbolFacts SymbolFactsCore => this.SymbolFacts;

        internal new SoalInternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => this.InternalSyntaxFactory;

        public new SoalSyntaxFactory SyntaxFactory => _syntaxFactory;
        protected override SyntaxFactory SyntaxFactoryCore => this.SyntaxFactory;

        public new SoalCompilationFactory CompilationFactory => _compilationFactory;
        protected override CompilationFactory CompilationFactoryCore => this.CompilationFactory;
    }
}

