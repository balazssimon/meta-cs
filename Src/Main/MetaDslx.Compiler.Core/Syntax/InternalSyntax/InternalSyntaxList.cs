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


    public abstract class InternalSyntaxNodeListBase : InternalSyntaxNode
    {
        private readonly int[] _childOffsets;
        private readonly GreenNode[] children;

        internal InternalSyntaxNodeListBase(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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

    public abstract class InternalSyntaxNodeList : InternalSyntaxNodeListBase, IReadOnlyList<InternalSyntaxNode>
    {
        internal InternalSyntaxNodeList(InternalSyntaxNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations) 
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

        internal abstract InternalSyntaxNodeList CreateList(InternalSyntaxNode[] items);

        public static InternalSyntaxNodeList Create(InternalSyntaxNode[] items, bool weak = false)
        {
            if (weak) return new InternalWeakSyntaxNodeList(items, null, null);
            else return new InternalStrongSyntaxNodeList(items, null, null);
        }
    }

    public abstract class InternalSeparatedSyntaxNodeList : InternalSyntaxNodeListBase, IReadOnlyList<GreenNode>
    {
        internal InternalSeparatedSyntaxNodeList(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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

        internal abstract InternalSeparatedSyntaxNodeList CreateList(GreenNode[] items);

        public static InternalSeparatedSyntaxNodeList Create(GreenNode[] items, bool weak = false)
        {
            if (weak) return new InternalWeakSeparatedSyntaxNodeList(items, null, null);
            else return new InternalStrongSeparatedSyntaxNodeList(items, null, null);
        }
    }

    internal sealed class InternalStrongSyntaxNodeList : InternalSyntaxNodeList
    {
        internal InternalStrongSyntaxNodeList(InternalSyntaxNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        internal override bool IsWeak
        {
            get { return false; }
        }

        public override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return new StrongSyntaxNodeList(this, parent, position);
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalStrongSyntaxNodeList((InternalSyntaxNode[])this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalStrongSyntaxNodeList((InternalSyntaxNode[])this.Children, diagnostics, this.GetAnnotations());
        }

        internal override InternalSyntaxNodeList CreateList(InternalSyntaxNode[] items)
        {
            return new InternalStrongSyntaxNodeList(items, null, null);
        }
    }

    internal sealed class InternalStrongSeparatedSyntaxNodeList : InternalSeparatedSyntaxNodeList
    {
        internal InternalStrongSeparatedSyntaxNodeList(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        internal override bool IsWeak
        {
            get { return false; }
        }

        public override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return new StrongSeparatedSyntaxNodeList(this, parent, position, 0);
        }

        public override RedNode CreateRed(RedNode parent, int position, int index)
        {
            return new StrongSeparatedSyntaxNodeList(this, parent as SyntaxNode, position, index);
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalStrongSeparatedSyntaxNodeList(this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalStrongSeparatedSyntaxNodeList(this.Children, diagnostics, this.GetAnnotations());
        }

        internal override InternalSeparatedSyntaxNodeList CreateList(GreenNode[] items)
        {
            return new InternalStrongSeparatedSyntaxNodeList(items, null, null);
        }
    }

    internal sealed class InternalWeakSyntaxNodeList : InternalSyntaxNodeList
    {
        internal InternalWeakSyntaxNodeList(InternalSyntaxNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        internal override bool IsWeak
        {
            get { return true; }
        }

        public override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return new WeakSyntaxNodeList(this, parent, position);
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalWeakSyntaxNodeList((InternalSyntaxNode[])this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalWeakSyntaxNodeList((InternalSyntaxNode[])this.Children, diagnostics, this.GetAnnotations());
        }

        internal override InternalSyntaxNodeList CreateList(InternalSyntaxNode[] items)
        {
            return new InternalWeakSyntaxNodeList(items, null, null);
        }
    }

    internal sealed class InternalWeakSeparatedSyntaxNodeList : InternalSeparatedSyntaxNodeList
    {
        internal InternalWeakSeparatedSyntaxNodeList(GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(children, diagnostics, annotations)
        {
        }

        internal override bool IsWeak
        {
            get { return true; }
        }

        public override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return new WeakSeparatedSyntaxNodeList(this, parent, position, 0);
        }

        public override RedNode CreateRed(RedNode parent, int position, int index)
        {
            return new WeakSeparatedSyntaxNodeList(this, parent as SyntaxNode, position, index);
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalWeakSeparatedSyntaxNodeList(this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalWeakSeparatedSyntaxNodeList(this.Children, diagnostics, this.GetAnnotations());
        }

        internal override InternalSeparatedSyntaxNodeList CreateList(GreenNode[] items)
        {
            return new InternalWeakSeparatedSyntaxNodeList(items, null, null);
        }
    }


    public sealed class InternalSyntaxTokenList : InternalSyntaxList, IReadOnlyList<InternalSyntaxToken>
    {
        public InternalSyntaxTokenList(InternalSyntaxToken[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
            return new SyntaxTokenList(this, parent as SyntaxNode, position, index);
        }

        public IEnumerator<InternalSyntaxToken> GetEnumerator()
        {
            return (IEnumerator<InternalSyntaxToken>)this.Children.GetEnumerator();
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalSyntaxTokenList((InternalSyntaxToken[])this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalSyntaxTokenList((InternalSyntaxToken[])this.Children, diagnostics, this.GetAnnotations());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }
    }

    public sealed class InternalSyntaxTriviaList : InternalSyntaxList, IReadOnlyList<InternalSyntaxTrivia>
    {
        public InternalSyntaxTriviaList(InternalSyntaxTrivia[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
            return new SyntaxTriviaList(this, parent as SyntaxToken, position, index);
        }

        public IEnumerator<InternalSyntaxTrivia> GetEnumerator()
        {
            return (IEnumerator<InternalSyntaxTrivia>)this.Children.GetEnumerator();
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new InternalSyntaxTriviaList((InternalSyntaxTrivia[])this.Children, this.GetDiagnostics(), annotations);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new InternalSyntaxTriviaList((InternalSyntaxTrivia[])this.Children, diagnostics, this.GetAnnotations());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Children.GetEnumerator(); 
        }
    }

}
