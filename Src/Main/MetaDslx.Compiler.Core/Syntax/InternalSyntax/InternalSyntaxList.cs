using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxList : GreenNode
    {
        private readonly int[] _childOffsets;
        private readonly GreenNode[] children;

        internal InternalSyntaxList(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(SyntaxKind.List, 0, diagnostics, annotations)
        {
            Debug.Assert(children.Length > 0, "Chilren array must not be empty.");
            this.children = children;
            this.InitializeChildren();
            _childOffsets = CalculateOffsets(children);
        }

        public override Language Language
        {
            get { return this.children[0].Language; }
        }

        public override bool IsList
        {
            get { return true; }
        }

        private void InitializeChildren()
        {
            int n = children.Length;
            for (int i = 0; i < children.Length; i++)
            {
                this.AdjustFlagsAndWidth(children[i]);
            }
        }

        internal protected GreenNode[] Children
        {
            get { return this.children; }
        }

        public int Count
        {
            get { return this.children.Length; }
        }

        public override int SlotCount
        {
            get { return this.children.Length; }
        }

        public override GreenNode GetSlot(int index)
        {
            return this.children[index];
        }

        public override int GetSlotOffset(int index)
        {
            return _childOffsets[index];
        }

        /// <summary>
        /// Find the slot that contains the given offset.
        /// </summary>
        /// <param name="offset">The target offset. Must be between 0 and <see cref="GreenNodeBase.FullWidth"/>.</param>
        /// <returns>The slot index of the slot containing the given offset.</returns>
        /// <remarks>
        /// This implementation uses a binary search to find the first slot that contains
        /// the given offset.
        /// </remarks>
        public override int FindSlotIndexContainingOffset(int offset)
        {
            Debug.Assert(offset >= 0 && offset < FullWidth);
            return CollectionUtilities.BinarySearchUpperBound(_childOffsets, offset) - 1;
        }

        private static int[] CalculateOffsets(GreenNode[] children)
        {
            int n = children.Length;
            var childOffsets = new int[n];
            int offset = 0;
            for (int i = 0; i < n; i++)
            {
                childOffsets[i] = offset;
                offset += children[i].FullWidth;
            }
            return childOffsets;
        }
    }


    public abstract class InternalNodeListBase : InternalSyntaxNode
    {
        private readonly int[] _childOffsets;
        private readonly GreenNode[] children;

        internal InternalNodeListBase(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(SyntaxKind.List, 0, diagnostics, annotations)
        {
            Debug.Assert(children != null && children.Length > 0, "Chilren array must not be empty.");
            this.children = children;
            this.InitializeChildren();
            _childOffsets = CalculateOffsets(children);
        }

        public override Language Language
        {
            get { return this.children[0].Language; }
        }

        public override bool IsNode
        {
            get { return false; }
        }

        public override bool IsList
        {
            get { return true; }
        }

        internal abstract bool IsWeak { get; }

        private void InitializeChildren()
        {
            int n = children.Length;
            for (int i = 0; i < children.Length; i++)
            {
                this.AdjustFlagsAndWidth(children[i]);
            }
        }

        internal protected GreenNode[] Children
        {
            get { return this.children; }
        }

        public int Count
        {
            get { return this.children.Length; }
        }

        public override int SlotCount
        {
            get { return this.children.Length; }
        }

        public override GreenNode GetSlot(int index)
        {
            return this.children[index];
        }

        public override int GetSlotOffset(int index)
        {
            return _childOffsets[index];
        }

        /// <summary>
        /// Find the slot that contains the given offset.
        /// </summary>
        /// <param name="offset">The target offset. Must be between 0 and <see cref="GreenNodeBase.FullWidth"/>.</param>
        /// <returns>The slot index of the slot containing the given offset.</returns>
        /// <remarks>
        /// This implementation uses a binary search to find the first slot that contains
        /// the given offset.
        /// </remarks>
        public override int FindSlotIndexContainingOffset(int offset)
        {
            Debug.Assert(offset >= 0 && offset < FullWidth);
            return CollectionUtilities.BinarySearchUpperBound(_childOffsets, offset) - 1;
        }

        private static int[] CalculateOffsets(GreenNode[] children)
        {
            int n = children.Length;
            var childOffsets = new int[n];
            int offset = 0;
            for (int i = 0; i < n; i++)
            {
                childOffsets[i] = offset;
                offset += children[i].FullWidth;
            }
            return childOffsets;
        }

    }

    public abstract class InternalNodeList : InternalNodeListBase, IReadOnlyList<InternalSyntaxNode>
    {
        internal InternalNodeList(InternalSyntaxNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations) 
            : base(children, diagnostics, annotations)
        {
        }

        public InternalSyntaxNode this[int index]
        {
            get { return (InternalSyntaxNode)this.Children[index]; }
        }

        public IEnumerator<InternalSyntaxNode> GetEnumerator()
        {
            return (IEnumerator<InternalSyntaxNode>)this.Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }

        internal abstract InternalNodeList CreateList(InternalSyntaxNode[] items);
    }

    public abstract class InternalSeparatedNodeList : InternalNodeListBase, IReadOnlyList<GreenNode>
    {
        internal InternalSeparatedNodeList(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        public GreenNode this[int index]
        {
            get { return this.Children[index]; }
        }

        /// <summary>
        /// Gets the first SyntaxNodeOrToken structure from this list.
        /// </summary>
        public GreenNode First()
        {
            return this[0];
        }

        /// <summary>
        /// Gets the first SyntaxNodeOrToken structure from this list if present, else default(SyntaxNodeOrToken).
        /// </summary>
        public GreenNode FirstOrDefault()
        {
            return this[0];
        }

        /// <summary>
        /// Gets the last SyntaxNodeOrToken structure from this list.
        /// </summary>
        public GreenNode Last()
        {
            return this[this.Count - 1];
        }

        /// <summary>
        /// Gets the last SyntaxNodeOrToken structure from this list if present, else default(SyntaxNodeOrToken).
        /// </summary>
        public GreenNode LastOrDefault()
        {
            return this[this.Count - 1];
        }

        /// <summary>
        /// Returns the index from the list for the given <see cref="SyntaxNodeOrToken"/>.
        /// </summary>
        /// <param name="nodeOrToken">The node or token to search for in the list.</param>
        /// <returns>The index of the found nodeOrToken, or -1 if it wasn't found</returns>
        public int IndexOf(GreenNode nodeOrToken)
        {
            var i = 0;
            foreach (var child in this)
            {
                if (child == nodeOrToken)
                {
                    return i;
                }

                i++;
            }

            return -1;
        }

        /// <summary>
        /// Indicates whether there is any element in the list.
        /// </summary>
        /// <returns><c>true</c> if there are any elements in the list, else <c>false</c>.</returns>
        public bool Any()
        {
            return true;
        }

        /// <summary>
        /// Copies a given count of elements into the given array at specified offsets.
        /// </summary>
        /// <param name="offset">The offset to start copying from.</param>
        /// <param name="array">The array to copy the elements into.</param>
        /// <param name="arrayOffset">The array offset to start writing to.</param>
        /// <param name="count">The count of elements to copy.</param>
        internal void CopyTo(int offset, GreenNode[] array, int arrayOffset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                array[arrayOffset + i] = this[i + offset];
            }
        }

        // for debugging
        private GreenNode[] Nodes
        {
            get { return this.ToArray(); }
        }

        public IEnumerator<GreenNode> GetEnumerator()
        {
            return (IEnumerator<GreenNode>)this.Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }

        internal abstract InternalSeparatedNodeList CreateList(GreenNode[] items);
    }

    internal sealed class InternalStrongNodeList : InternalNodeList
    {
        internal InternalStrongNodeList(InternalSyntaxNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        internal override bool IsWeak
        {
            get { return false; }
        }

        public override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return new StrongNodeList(this, parent, position);
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalStrongNodeList((InternalSyntaxNode[])this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalStrongNodeList((InternalSyntaxNode[])this.Children, diagnostics, this.GetAnnotations());
        }

        internal override InternalNodeList CreateList(InternalSyntaxNode[] items)
        {
            return new InternalStrongNodeList(items, null, null);
        }
    }

    internal sealed class InternalStrongSeparatedNodeList : InternalSeparatedNodeList
    {
        internal InternalStrongSeparatedNodeList(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        internal override bool IsWeak
        {
            get { return false; }
        }

        public override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return new StrongSeparatedNodeList(this, parent, position, 0);
        }

        public override RedNode CreateRed(RedNode parent, int position, int index)
        {
            return new StrongSeparatedNodeList(this, parent as SyntaxNode, position, index);
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalStrongSeparatedNodeList(this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalStrongSeparatedNodeList(this.Children, diagnostics, this.GetAnnotations());
        }

        internal override InternalSeparatedNodeList CreateList(GreenNode[] items)
        {
            return new InternalStrongSeparatedNodeList(items, null, null);
        }
    }

    internal sealed class InternalWeakNodeList : InternalNodeList
    {
        internal InternalWeakNodeList(InternalSyntaxNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        internal override bool IsWeak
        {
            get { return true; }
        }

        public override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return new WeakNodeList(this, parent, position);
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalWeakNodeList((InternalSyntaxNode[])this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalWeakNodeList((InternalSyntaxNode[])this.Children, diagnostics, this.GetAnnotations());
        }

        internal override InternalNodeList CreateList(InternalSyntaxNode[] items)
        {
            return new InternalWeakNodeList(items, null, null);
        }
    }

    internal sealed class InternalWeakSeparatedNodeList : InternalSeparatedNodeList
    {
        internal InternalWeakSeparatedNodeList(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        internal override bool IsWeak
        {
            get { return true; }
        }

        public override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return new WeakSeparatedNodeList(this, parent, position, 0);
        }

        public override RedNode CreateRed(RedNode parent, int position, int index)
        {
            return new WeakSeparatedNodeList(this, parent as SyntaxNode, position, index);
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalWeakSeparatedNodeList(this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalWeakSeparatedNodeList(this.Children, diagnostics, this.GetAnnotations());
        }

        internal override InternalSeparatedNodeList CreateList(GreenNode[] items)
        {
            return new InternalWeakSeparatedNodeList(items, null, null);
        }
    }


    public sealed class InternalTokenList : InternalSyntaxList, IReadOnlyList<InternalSyntaxToken>
    {
        public InternalTokenList(InternalSyntaxToken[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        public InternalSyntaxToken this[int index]
        {
            get { return (InternalSyntaxToken)this.Children[index]; }
        }

        public override RedNode CreateRed(RedNode parent, int position, int index)
        {
            Debug.Assert(parent is SyntaxNode);
            return new TokenList(this, parent as SyntaxNode, position, index);
        }

        public IEnumerator<InternalSyntaxToken> GetEnumerator()
        {
            return (IEnumerator<InternalSyntaxToken>)this.Children.GetEnumerator();
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalTokenList((InternalSyntaxToken[])this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalTokenList((InternalSyntaxToken[])this.Children, diagnostics, this.GetAnnotations());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }
    }

    public sealed class InternalTriviaList : InternalSyntaxList, IReadOnlyList<InternalSyntaxTrivia>
    {
        public InternalTriviaList(InternalSyntaxTrivia[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        public InternalSyntaxTrivia this[int index]
        {
            get { return (InternalSyntaxTrivia)this.Children[index]; }
        }

        public override RedNode CreateRed(RedNode parent, int position, int index)
        {
            Debug.Assert(parent is SyntaxToken);
            return new TriviaList(this, parent as SyntaxToken, position, index);
        }

        public IEnumerator<InternalSyntaxTrivia> GetEnumerator()
        {
            return (IEnumerator<InternalSyntaxTrivia>)this.Children.GetEnumerator();
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalTriviaList((InternalSyntaxTrivia[])this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalTriviaList((InternalSyntaxTrivia[])this.Children, diagnostics, this.GetAnnotations());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Children.GetEnumerator(); 
        }
    }

}
