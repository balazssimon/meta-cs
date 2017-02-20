using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public abstract class SyntaxFactory
    {
        internal static SyntaxFactory Default = new DefaultSyntaxFactory();

        internal protected abstract SyntaxToken DefaultToken { get; }
        internal protected abstract SyntaxTrivia DefaultTrivia { get; }
        internal protected abstract SyntaxToken DefaultSeparator { get; }
        internal protected virtual SyntaxToken Separator<TNode>(TNode item) where TNode : SyntaxNode
        {
            return this.DefaultSeparator;
        }
        internal protected abstract SyntaxToken Token(SyntaxNode tokenStructure);
        internal protected abstract SyntaxTrivia Trivia(SyntaxNode triviaStructure);
        internal protected abstract SyntaxNode StructuredToken(SyntaxToken token);
        internal protected abstract SyntaxNode StructuredTrivia(SyntaxTrivia trivia);

        protected abstract SyntaxTree ParseSyntaxTreeCore(SourceText text, ParseOptions options = null, string path = "", CancellationToken cancellationToken = default(CancellationToken));
        public abstract SyntaxParser MakeParser(SourceText text, ParseOptions options, SyntaxNode oldTree, IReadOnlyList<TextChangeRange> changes);
        public abstract SyntaxParser MakeParser(string text);
    }

    internal class DefaultSyntaxFactory : SyntaxFactory
    {
        internal protected override SyntaxToken DefaultToken
        {
            get { throw ExceptionUtilities.Unreachable; }
        }

        internal protected override SyntaxTrivia DefaultTrivia
        {
            get { throw ExceptionUtilities.Unreachable; }
        }

        internal protected override SyntaxToken DefaultSeparator
        {
            get { throw ExceptionUtilities.Unreachable; }
        }

        internal protected override SyntaxNode StructuredToken(SyntaxToken token)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal protected override SyntaxNode StructuredTrivia(SyntaxTrivia trivia)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal protected override SyntaxToken Token(SyntaxNode tokenStructure)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal protected override SyntaxTrivia Trivia(SyntaxNode triviaStructure)
        {
            throw ExceptionUtilities.Unreachable;
        }

        protected override SyntaxTree ParseSyntaxTreeCore(SourceText text, ParseOptions options = null, string path = "", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override SyntaxParser MakeParser(SourceText text, ParseOptions options, SyntaxNode oldTree, IReadOnlyList<TextChangeRange> changes)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override SyntaxParser MakeParser(string text)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}
