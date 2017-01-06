using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Utilities;
using System.Diagnostics;

namespace MetaDslx.Compiler.Syntax
{
    /// <summary>
    /// Represents a trivia in the syntax tree.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract class SyntaxTrivia : RedNode
    {
        private SyntaxToken token;
        private int index;

        protected SyntaxTrivia(InternalSyntaxTrivia green, SyntaxToken token, int position, int index) 
            : base(green, token.Parent, position)
        {
            this.token = token;
            this.index = index;
        }

        private string GetDebuggerDisplay()
        {
            return GetType().Name + " " + (Green.KindText ?? "None") + " " + ToString();
        }

        public SyntaxToken Token
        {
            get { return this.token; }
        }

        public int Index
        {
            get { return this.index; }
        }


        internal InternalSyntaxTrivia GreenTrivia
        {
            get { return (InternalSyntaxTrivia)this.Green; }
        }
        
        /// <summary>
        /// Returns the child non-terminal node representing the syntax tree structure under this structured trivia.
        /// </summary>
        /// <returns>The child non-terminal node representing the syntax tree structure under this structured
        /// trivia.</returns>
        public override SyntaxNode GetStructure()
        {
            return HasStructure ? Green.GetStructure(this) : null;
        }

        /// <summary>
        /// Determines whether the supplied <see cref="SyntaxTrivia"/> is equal to this
        /// <see cref="SyntaxTrivia"/>.
        /// </summary>
        public bool Equals(SyntaxTrivia other)
        {
            return Token == other.Token && Green == other.Green && Position == other.Position && Index == other.Index;
        }

        /// <summary>
        /// Determines whether the supplied <see cref="SyntaxTrivia"/> is equal to this
        /// <see cref="SyntaxTrivia"/>.
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is SyntaxTrivia && Equals((SyntaxTrivia)obj);
        }

        /// <summary>
        /// Serves as hash function for <see cref="SyntaxTrivia"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return Hash.Combine(Token.GetHashCode(), Hash.Combine(Green, Hash.Combine(Position, Index)));
        }

        /// <summary> 
        /// Returns the string representation of this trivia. If this trivia is structured trivia then the returned string
        /// will not include any leading or trailing trivia present on the StructuredTriviaSyntax node of this trivia.
        /// </summary>
        /// <returns>The string representation of this trivia.</returns>
        /// <remarks>The length of the returned string is always the same as Span.Length</remarks>
        public override string ToString()
        {
            return Green != null ? Green.ToString() : string.Empty;
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
