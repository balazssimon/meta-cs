using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxFactory
    {
        internal static readonly InternalSyntaxFactory Default = new DefaultInternalSyntaxFactory();

        public InternalSyntaxFactory()
        {
            string CrLf = "\r\n";
            CarriageReturnLineFeed = EndOfLine(CrLf);
            LineFeed = EndOfLine("\n");
            CarriageReturn = EndOfLine("\r");
            Space = Whitespace(" ");
            Tab = Whitespace("\t");

            ElasticCarriageReturnLineFeed = EndOfLine(CrLf, elastic: true);
            ElasticLineFeed = EndOfLine("\n", elastic: true);
            ElasticCarriageReturn = EndOfLine("\r", elastic: true);
            ElasticSpace = Whitespace(" ", elastic: true);
            ElasticTab = Whitespace("\t", elastic: true);

            ElasticZeroSpace = Whitespace(string.Empty, elastic: true);
        }

        public InternalSyntaxTrivia CarriageReturnLineFeed { get; }
        public InternalSyntaxTrivia LineFeed { get; }
        public InternalSyntaxTrivia CarriageReturn { get; }
        public InternalSyntaxTrivia Space { get; }
        public InternalSyntaxTrivia Tab { get; }
        public InternalSyntaxTrivia ElasticCarriageReturnLineFeed { get; }
        public InternalSyntaxTrivia ElasticLineFeed { get; }
        public InternalSyntaxTrivia ElasticCarriageReturn { get; }
        public InternalSyntaxTrivia ElasticSpace { get; }
        public InternalSyntaxTrivia ElasticTab { get; }
        public InternalSyntaxTrivia ElasticZeroSpace { get; }

        protected InternalSyntaxTrivia GetWellKnownTrivia(string text, bool elastic = false)
        {
            switch (text)
            {
                case " ":
                    return elastic ? this.ElasticSpace : this.Space;
                case "\t":
                    return elastic ? this.ElasticTab : this.Tab;
                case "\r":
                    return elastic ? this.ElasticCarriageReturn : this.CarriageReturn;
                case "\n":
                    return elastic ? this.ElasticLineFeed : this.LineFeed;
                case "\r\n":
                    return elastic ? this.ElasticCarriageReturnLineFeed : this.CarriageReturnLineFeed;
                default:
                    return null;
            }
        }

        private InternalSyntaxTrivia EndOfLine(string text, bool elastic = false)
        {
            InternalSyntaxTrivia trivia = null;

            // use predefined trivia
            switch (text)
            {
                case "\r":
                    trivia = elastic ? this.ElasticCarriageReturn : this.CarriageReturn;
                    break;
                case "\n":
                    trivia = elastic ? this.ElasticLineFeed : this.LineFeed;
                    break;
                case "\r\n":
                    trivia = elastic ? this.ElasticCarriageReturnLineFeed : this.CarriageReturnLineFeed;
                    break;
            }

            // note: predefined trivia might not yet be defined during initialization
            if (trivia != null)
            {
                return trivia;
            }

            trivia = this.Trivia(SyntaxKind.EndOfLineTrivia, text);
            if (!elastic)
            {
                return trivia;
            }

            return (InternalSyntaxTrivia)trivia.WithAnnotations(new[] { SyntaxAnnotation.ElasticAnnotation });
        }

        private InternalSyntaxTrivia Whitespace(string text, bool elastic = false)
        {
            var trivia = this.Trivia(SyntaxKind.WhitespaceTrivia, text);
            if (!elastic)
            {
                return trivia;
            }

            return (InternalSyntaxTrivia)trivia.WithAnnotations(new[] { SyntaxAnnotation.ElasticAnnotation });
        }


        public abstract InternalSyntaxToken Token(int kind);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing);
        public abstract InternalSyntaxToken MissingToken(int kind);
        public abstract InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing);
        public abstract InternalSyntaxTrivia Trivia(int kind, string text);
    }

    internal class DefaultInternalSyntaxFactory : InternalSyntaxFactory
    {
        public override InternalSyntaxToken MissingToken(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override InternalSyntaxToken Token(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override InternalSyntaxTrivia Trivia(int kind, string text)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}
