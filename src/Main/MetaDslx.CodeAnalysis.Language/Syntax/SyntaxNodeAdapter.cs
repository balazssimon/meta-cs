using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public abstract class SyntaxNodeAdapter : SyntaxNode
    {
        protected SyntaxNodeAdapter(GreenNode green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        /// <summary>
        /// Used by structured trivia which has "parent == null", and therefore must know its
        /// SyntaxTree explicitly when created.
        /// </summary>
        protected SyntaxNodeAdapter(GreenNode green, int position, SyntaxTree syntaxTree)
            : base(green, position, syntaxTree)
        {
        }

        public sealed override string Language
        {
            get { return this.LanguageCore.Name; }
        }

        protected abstract Language LanguageCore { get; }
    }
}
