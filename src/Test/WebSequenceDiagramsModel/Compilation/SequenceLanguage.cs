// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using WebSequenceDiagramsModel.Symbols;
using WebSequenceDiagramsModel.Syntax;
using WebSequenceDiagramsModel.Syntax.InternalSyntax;

namespace WebSequenceDiagramsModel
{
    public sealed class SequenceLanguage : Language
    {
        public static readonly SequenceLanguage Instance = new SequenceLanguage();

		private SequenceSyntaxFacts _syntaxFacts;
		private SequenceSymbolFacts _symbolFacts;
		private SequenceInternalSyntaxFactory _internalSyntaxFactory;
		private SequenceSyntaxFactory _syntaxFactory;
		private SequenceCompilationFactory _compilationFactory;

		private SequenceLanguage()
		{
			_syntaxFacts = new SequenceSyntaxFacts();
			_internalSyntaxFactory = new SequenceInternalSyntaxFactory(_syntaxFacts);
			_syntaxFactory = new SequenceSyntaxFactory(_internalSyntaxFactory);
			_symbolFacts = new SequenceSymbolFacts();
			_compilationFactory = new SequenceCompilationFactory();
		}

        public override string Name => "Sequence";

        public new SequenceSyntaxFacts SyntaxFacts => _syntaxFacts;
        protected override SyntaxFacts SyntaxFactsCore => this.SyntaxFacts;

        public new SequenceSymbolFacts SymbolFacts => _symbolFacts;
        protected override SymbolFacts SymbolFactsCore => this.SymbolFacts;

        internal new SequenceInternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => this.InternalSyntaxFactory;

        public new SequenceSyntaxFactory SyntaxFactory => _syntaxFactory;
        protected override SyntaxFactory SyntaxFactoryCore => this.SyntaxFactory;

        public new SequenceCompilationFactory CompilationFactory => _compilationFactory;
        protected override CompilationFactory CompilationFactoryCore => this.CompilationFactory;
    }
}

