using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public abstract class SyntaxNodeAdapter : SyntaxNode
    {
        internal SyntaxNodeAdapter(GreenNode green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        /// <summary>
        /// Used by structured trivia which has "parent == null", and therefore must know its
        /// SyntaxTree explicitly when created.
        /// </summary>
        internal SyntaxNodeAdapter(GreenNode green, int position, SyntaxTree syntaxTree)
            : base(green, position, syntaxTree)
        {
        }

        public sealed override string Language
        {
            get { return this.LanguageCore.Name; }
        }

        protected abstract Language LanguageCore { get; }

        public SyntaxKind Kind => this.KindCore;

        protected abstract SyntaxKind KindCore { get; }

        protected GreenNode GreenCore => this.Green;

        internal sealed override SyntaxNode GetCachedSlot(int index)
        {
            return this.GetCachedSlotCore(index);
        }

        protected abstract SyntaxNode GetCachedSlotCore(int index);

        internal sealed override SyntaxNode GetNodeSlot(int slot)
        {
            return this.GetNodeSlotCore(slot);
        }

        protected abstract SyntaxNode GetNodeSlotCore(int slot);

        protected new int GetChildPosition(int index)
        {
            return base.GetChildPosition(index);
        }

        protected new int GetChildIndex(int slot)
        {
            return base.GetChildIndex(slot);
        }

        protected new SyntaxAnnotation[] GetAnnotations()
        {
            return base.GetAnnotations();
        }
    }
}
