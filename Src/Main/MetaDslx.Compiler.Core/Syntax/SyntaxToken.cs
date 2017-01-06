using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Syntax
{
    public abstract class SyntaxToken : RedNode
    {
        private int index;

        protected SyntaxToken(InternalSyntaxToken green, SyntaxNode parent, int position, int index)
            : base(green, parent, position) 
        {
            this.index = index;
        }

        public int Index
        {
            get { return this.index; }
        }

        internal protected InternalSyntaxToken GreenToken
        {
            get { return (InternalSyntaxToken)this.Green; }
        }

        /// <summary>
        /// Returns the child non-terminal node representing the syntax tree structure under this structured token.
        /// </summary>
        /// <returns>The child non-terminal node representing the syntax tree structure under this structured
        /// token.</returns>
        public override SyntaxNode GetStructure()
        {
            return HasStructure ? Green.GetStructure(this) : null;
        }

        /// <summary>
        /// Returns the value of the token. For example, if the token represents an integer literal, then this property
        /// would return the actual integer.
        /// </summary>
        public object Value => GreenToken.Value;

        /// <summary>
        /// Returns the text representation of the value of the token. For example, if the token represents an integer
        /// literal, then this property would return a string representing the integer.
        /// </summary>
        public string ValueText => GreenToken.ValueText;

        /// <summary>
        /// The list of trivia that appear before this token in the source code.
        /// </summary>
        public TriviaList LeadingTrivia
        {
            get
            {
                return new TriviaList(GreenToken.GetLeadingTrivia(), this, this.Position, 0);
            }
        }

        /// <summary>
        /// The list of trivia that appear after this token in the source code and are attached to this token or any of
        /// its descendants.
        /// </summary>
        public TriviaList TrailingTrivia
        {
            get
            {
                var leading = GreenToken.GetLeadingTrivia();
                int index = 0;
                if (leading != null)
                {
                    index = leading.IsList ? leading.SlotCount : 1;
                }

                var trailingGreen = GreenToken.GetTrailingTrivia();
                int trailingPosition = Position + this.FullWidth;
                if (trailingGreen != null)
                {
                    trailingPosition -= trailingGreen.FullWidth;
                }

                return new TriviaList(trailingGreen, this, trailingPosition, index);
            }
        }

        /// <summary>
        /// Creates a new token from this token with the leading and trailing trivia from the specified token.
        /// </summary>
        public SyntaxToken WithTriviaFrom(SyntaxToken token)
        {
            return this.WithLeadingTrivia(token.LeadingTrivia).WithTrailingTrivia(token.TrailingTrivia);
        }

        /// <summary>
        /// Creates a new token from this token with the leading trivia specified.
        /// </summary>
        public SyntaxToken WithLeadingTrivia(TriviaList trivia)
        {
            return this.WithLeadingTrivia((IEnumerable<SyntaxTrivia>)trivia);
        }

        /// <summary>
        /// Creates a new token from this token with the leading trivia specified..
        /// </summary>
        public SyntaxToken WithLeadingTrivia(params SyntaxTrivia[] trivia)
        {
            return this.WithLeadingTrivia((IEnumerable<SyntaxTrivia>)trivia);
        }

        /// <summary>
        /// Creates a new token from this token with the leading trivia specified..
        /// </summary>
        public SyntaxToken WithLeadingTrivia(IEnumerable<SyntaxTrivia> trivia)
        {
            var greenList = trivia?.Select(t => t.GreenTrivia).ToArray();
            return this.WithLeadingTriviaCore(greenList);
        }

        /// <summary>
        /// Creates a new token from this token with the trailing trivia specified.
        /// </summary>
        public SyntaxToken WithTrailingTrivia(TriviaList trivia)
        {
            return this.WithTrailingTrivia((IEnumerable<SyntaxTrivia>)trivia);
        }

        /// <summary>
        /// Creates a new token from this token with the trailing trivia specified.
        /// </summary>
        public SyntaxToken WithTrailingTrivia(params SyntaxTrivia[] trivia)
        {
            return this.WithTrailingTrivia((IEnumerable<SyntaxTrivia>)trivia);
        }

        /// <summary>
        /// Creates a new token from this token with the trailing trivia specified.
        /// </summary>
        public SyntaxToken WithTrailingTrivia(IEnumerable<SyntaxTrivia> trivia)
        {
            var greenList = trivia?.Select(t => t.GreenTrivia).ToArray();
            return this.WithTrailingTriviaCore(greenList);
        }

        protected abstract SyntaxToken WithLeadingTriviaCore(InternalSyntaxTrivia[] leading);
        protected abstract SyntaxToken WithTrailingTriviaCore(InternalSyntaxTrivia[] trailing);


        /// <summary>
        /// Determines whether the supplied <see cref="SyntaxToken"/> is equal to this
        /// <see cref="SyntaxToken"/>.
        /// </summary>
        public bool Equals(SyntaxToken other)
        {
            return Parent == other.Parent &&
                   Green == other.Green &&
                   Position == other.Position &&
                   Index == other.Index;
        }

        /// <summary>
        /// Determines whether the supplied <see cref="SyntaxToken"/> is equal to this
        /// <see cref="SyntaxToken"/>.
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is SyntaxToken && Equals((SyntaxToken)obj);
        }

        /// <summary>
        /// Serves as hash function for <see cref="SyntaxToken"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return Hash.Combine(Parent, Hash.Combine(Green, Hash.Combine(Position, Index)));
        }

        public override SyntaxNode GetNodeSlot(int slot)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override SyntaxNode GetCachedSlot(int index)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}
