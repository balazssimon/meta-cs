using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using System.Threading;
using System.Collections;
using MetaDslx.Compiler.Utilities;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using MetaDslx.Compiler.Text;

namespace MetaDslx.Compiler.Syntax
{
    public abstract class SyntaxList : RedNode
    {
        private int index;

        internal SyntaxList(InternalSyntaxList green, SyntaxNode parent, int position, int index)
            : base(green, parent, position)
        {
            this.index = index;
        }

        internal SyntaxList(GreenNode green, SyntaxNode parent, int position, int index)
            : base(green, parent, position)
        {
            this.index = index;
        }

        internal int Index
        {
            get { return this.index; }
        }

        /// <summary>
        /// Returns the number of items in the list.
        /// </summary>
        public int Count => Green.IsList ? Green.SlotCount : 1;

        public override SyntaxNode GetNodeSlot(int slot)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override SyntaxNode GetCachedSlot(int index)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }

    public sealed class ChildSyntaxList : IEquatable<ChildSyntaxList>, IReadOnlyList<RedNode>
    {
        private readonly SyntaxNode _node;
        private readonly int _count;

        internal ChildSyntaxList(SyntaxNode node)
        {
            _node = node;
            _count = CountNodes(node.Green);
        }

        /// <summary>
        /// Gets the number of children contained in the <see cref="ChildSyntaxList"/>.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        internal static int CountNodes(GreenNode green)
        {
            int n = 0;

            for (int i = 0, s = green.SlotCount; i < s; i++)
            {
                var child = green.GetSlot(i);
                if (child != null)
                {
                    if (!child.IsList)
                    {
                        n++;
                    }
                    else
                    {
                        n += child.SlotCount;
                    }
                }
            }

            return n;
        }

        /// <summary>Gets the child at the specified index.</summary>
        /// <param name="index">The zero-based index of the child to get.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///   <paramref name="index"/> is less than 0.-or-<paramref name="index" /> is equal to or greater than <see cref="ChildSyntaxList.Count"/>. </exception>
        public RedNode this[int index]
        {
            get
            {
                if (unchecked((uint)index < (uint)_count))
                {
                    return ItemInternal(_node, index);
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        internal SyntaxNode Node
        {
            get { return _node; }
        }

        private static int Occupancy(GreenNode green)
        {
            return green.IsList ? green.SlotCount : 1;
        }

        /// <summary>
        /// internal indexer that does not verify index.
        /// Used when caller has already ensured that index is within bounds.
        /// </summary>
        internal static RedNode ItemInternal(SyntaxNode node, int index)
        {
            GreenNode greenChild;
            var green = node.Green;
            var idx = index;
            var slotIndex = 0;
            var position = node.Position;

            // find a slot that contains the node or its parent list (if node is in a list)
            // we will be skipping whole slots here so we will not loop for long
            // the max possible number of slots is 11 (TypeDeclarationSyntax)
            // and typically much less than that
            //
            // at the end of this loop we will have
            // 1) slot index - slotIdx
            // 2) if the slot is a list, node index in the list - idx
            // 3) slot position - position
            while (true)
            {
                greenChild = green.GetSlot(slotIndex);
                if (greenChild != null)
                {
                    int currentOccupancy = Occupancy(greenChild);
                    if (idx < currentOccupancy)
                    {
                        break;
                    }

                    idx -= currentOccupancy;
                    position += greenChild.FullWidth;
                }

                slotIndex++;
            }

            // get node that represents this slot
            var red = node.GetNodeSlot(slotIndex);
            if (!greenChild.IsList)
            {
                // this is a single node or token
                // if it is a node, we are done
                // otherwise will have to make a token with current gChild and position
                if (red != null)
                {
                    return red;
                }
            }
            else if (red != null)
            {
                // it is a red list of nodes (separated or not), most common case
                var redChild = red.GetNodeSlot(idx);
                if (redChild != null)
                {
                    // this is our node
                    return redChild;
                }

                // must be a separator
                // update gChild and position and let it be handled as a token
                greenChild = greenChild.GetSlot(idx);
                position = red.GetChildPosition(idx);
            }
            else
            {
                // it is a token from a token list, uncommon case
                // update gChild and position and let it be handled as a token
                position += greenChild.GetSlotOffset(idx);
                greenChild = greenChild.GetSlot(idx);
            }

            return greenChild.CreateRed(node, position, index);
        }

        /// <summary>
        /// Locate the node or token that is a child of the given <see cref="SyntaxNode"/> and contains the given position.
        /// </summary>
        /// <param name="node">The <see cref="SyntaxNode"/> to search.</param>
        /// <param name="targetPosition">The position.</param>
        /// <returns>The node or token that spans the given position.</returns>
        /// <remarks>
        /// Assumes that <paramref name="targetPosition"/> is within the span of <paramref name="node"/>.
        /// </remarks>
        internal static RedNode ChildThatContainsPosition(SyntaxNode node, int targetPosition)
        {
            // The targetPosition must already be within this node
            Debug.Assert(node.FullSpan.Contains(targetPosition));

            var green = node.Green;
            var position = node.Position;
            var index = 0;

            Debug.Assert(!green.IsList);

            // Find the green node that spans the target position.
            // We will be skipping whole slots here so we will not loop for long
            // The max possible number of slots is 11 (TypeDeclarationSyntax)
            // and typically much less than that
            int slot;
            for (slot = 0; ; slot++)
            {
                GreenNode greenChild = green.GetSlot(slot);
                if (greenChild != null)
                {
                    var endPosition = position + greenChild.FullWidth;
                    if (targetPosition < endPosition)
                    {
                        // Descend into the child element
                        green = greenChild;
                        break;
                    }

                    position = endPosition;
                    index += Occupancy(greenChild);
                }
            }

            // Realize the red node (if any)
            var red = node.GetNodeSlot(slot);
            if (!green.IsList)
            {
                // This is a single node or token.
                // If it is a node, we are done.
                if (red != null)
                {
                    return red;
                }

                // Otherwise will have to make a token with current green and position
            }
            else
            {
                slot = green.FindSlotIndexContainingOffset(targetPosition - position);

                // Realize the red node (if any)
                if (red != null)
                {
                    // It is a red list of nodes (separated or not)
                    red = red.GetNodeSlot(slot);
                    if (red != null)
                    {
                        return red;
                    }

                    // Must be a separator
                }

                // Otherwise we have a token.
                position += green.GetSlotOffset(slot);
                green = green.GetSlot(slot);

                // Since we can't have "lists of lists", the Occupancy calculation for
                // child elements in a list is simple.
                index += slot;
            }

            // Make a token with current child and position.
            return green.CreateRed(node, position, index);
        }

        /// <summary>
        /// internal indexer that does not verify index.
        /// Used when caller has already ensured that index is within bounds.
        /// </summary>
        internal static SyntaxNode ItemInternalAsNode(SyntaxNode node, int index)
        {
            GreenNode greenChild;
            var green = node.Green;
            var idx = index;
            var slotIndex = 0;

            // find a slot that contains the node or its parent list (if node is in a list)
            // we will be skipping whole slots here so we will not loop for long
            // the max possible number of slots is 11 (TypeDeclarationSyntax)
            // and typically much less than that
            //
            // at the end of this loop we will have
            // 1) slot index - slotIdx
            // 2) if the slot is a list, node index in the list - idx
            while (true)
            {
                greenChild = green.GetSlot(slotIndex);
                if (greenChild != null)
                {
                    int currentOccupancy = Occupancy(greenChild);
                    if (idx < currentOccupancy)
                    {
                        break;
                    }

                    idx -= currentOccupancy;
                }

                slotIndex++;
            }

            // get node that represents this slot
            var red = node.GetNodeSlot(slotIndex);
            if (greenChild.IsList && red != null)
            {
                // it is a red list of nodes (separated or not), most common case
                return red.GetNodeSlot(idx);
            }

            // this is a single node or token
            return red;
        }

        // for debugging
        private RedNode[] Nodes
        {
            get
            {
                return this.ToArray();
            }
        }

        public bool Any()
        {
            return _count != 0;
        }

        /// <summary>
        /// Returns the first child in the list.
        /// </summary>
        /// <returns>The first child in the list.</returns>
        /// <exception cref="System.InvalidOperationException">The list is empty.</exception>    
        public RedNode First()
        {
            if (Any())
            {
                return this[0];
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the last child in the list.
        /// </summary>
        /// <returns>The last child in the list.</returns>
        /// <exception cref="System.InvalidOperationException">The list is empty.</exception>    
        public RedNode Last()
        {
            if (Any())
            {
                return this[_count - 1];
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a list which contains all children of <see cref="ChildSyntaxList"/> in reversed order.
        /// </summary>
        /// <returns><see cref="Reversed"/> which contains all children of <see cref="ChildSyntaxList"/> in reversed order</returns>
        public Reversed Reverse()
        {
            return new Reversed(_node, _count);
        }

        /// <summary>Returns an enumerator that iterates through the <see cref="ChildSyntaxList"/>.</summary>
        /// <returns>A <see cref="Enumerator"/> for the <see cref="ChildSyntaxList"/>.</returns>
        public Enumerator GetEnumerator()
        {
            if (_node == null)
            {
                return default(Enumerator);
            }

            return new Enumerator(_node, _count);
        }

        IEnumerator<RedNode> IEnumerable<RedNode>.GetEnumerator()
        {
            if (_node == null)
            {
                return EmptyCollections.Enumerator<RedNode>();
            }

            return new EnumeratorImpl(_node, _count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (_node == null)
            {
                return EmptyCollections.Enumerator<RedNode>();
            }

            return new EnumeratorImpl(_node, _count);
        }

        /// <summary>Determines whether the specified object is equal to the current instance.</summary>
        /// <returns>true if the specified object is a <see cref="ChildSyntaxList" /> structure and is equal to the current instance; otherwise, false.</returns>
        /// <param name="obj">The object to be compared with the current instance.</param>
        public override bool Equals(object obj)
        {
            return obj is ChildSyntaxList && Equals((ChildSyntaxList)obj);
        }

        /// <summary>Determines whether the specified <see cref="ChildSyntaxList" /> structure is equal to the current instance.</summary>
        /// <returns>true if the specified <see cref="ChildSyntaxList" /> structure is equal to the current instance; otherwise, false.</returns>
        /// <param name="other">The <see cref="ChildSyntaxList" /> structure to be compared with the current instance.</param>
        public bool Equals(ChildSyntaxList other)
        {
            return _node == other._node;
        }

        /// <summary>Returns the hash code for the current instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return _node?.GetHashCode() ?? 0;
        }

        /// <summary>Enumerates the elements of a <see cref="ChildSyntaxList" />.</summary>
        public struct Enumerator
        {
            private SyntaxNode _node;
            private int _count;
            private int _childIndex;
            private RedNode _current;

            internal Enumerator(SyntaxNode node, int count)
            {
                _node = node;
                _count = count;
                _childIndex = -1;
                _current = null;
            }

            // PERF: Initialize an Enumerator directly from a SyntaxNode without going
            // via ChildNodesAndTokens. This saves constructing an intermediate ChildSyntaxList
            internal void InitializeFrom(SyntaxNode node)
            {
                _node = node;
                _count = CountNodes(node.Green);
                _childIndex = -1;
                _current = null;
            }

            /// <summary>Advances the enumerator to the next element of the <see cref="ChildSyntaxList" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                _current = null;
                var newIndex = _childIndex + 1;
                if (newIndex < _count)
                {
                    _childIndex = newIndex;
                    return true;
                }

                return false;
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the <see cref="ChildSyntaxList" /> at the current position of the enumerator.</returns>
            public RedNode Current
            {
                get
                {
                    if (_current == null)
                    {
                        _current = ItemInternal(_node, _childIndex);
                    }
                    return _current;
                }
            }

            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
            public void Reset()
            {
                _childIndex = -1;
                _current = null;
            }

            internal bool MoveToNextNode()
            {
                while (MoveNext())
                {
                    var nodeValue = ItemInternalAsNode(_node, _childIndex);
                    if (nodeValue != null)
                    {
                        _current = nodeValue;
                        return true;
                    }
                }

                return false;
            }
        }

        private class EnumeratorImpl : IEnumerator<RedNode>
        {
            private Enumerator _enumerator;

            internal EnumeratorImpl(SyntaxNode node, int count)
            {
                _enumerator = new Enumerator(node, count);
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <returns>
            /// The element in the collection at the current position of the enumerator.
            ///   </returns>
            public RedNode Current
            {
                get { return _enumerator.Current; }
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <returns>
            /// The element in the collection at the current position of the enumerator.
            ///   </returns>
            object IEnumerator.Current
            {
                get { return _enumerator.Current; }
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                _enumerator.Reset();
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            { }
        }

        public struct Reversed : IEnumerable<RedNode>, IEquatable<Reversed>
        {
            private readonly SyntaxNode _node;
            private readonly int _count;

            internal Reversed(SyntaxNode node, int count)
            {
                _node = node;
                _count = count;
            }

            public Enumerator GetEnumerator()
            {
                return new Enumerator(_node, _count);
            }

            IEnumerator<RedNode> IEnumerable<RedNode>.GetEnumerator()
            {
                if (_node == null)
                {
                    return EmptyCollections.Enumerator<RedNode>();
                }

                return new EnumeratorImpl(_node, _count);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                if (_node == null)
                {
                    return EmptyCollections.Enumerator<RedNode>();
                }

                return new EnumeratorImpl(_node, _count);
            }

            public override int GetHashCode()
            {
                return _node != null ? Hash.Combine(_node.GetHashCode(), _count) : 0;
            }

            public override bool Equals(object obj)
            {
                return (obj is Reversed) && Equals((Reversed)obj);
            }

            public bool Equals(Reversed other)
            {
                return _node == other._node
                    && _count == other._count;
            }

            public struct Enumerator
            {
                private readonly SyntaxNode _node;
                private readonly int _count;
                private int _childIndex;

                internal Enumerator(SyntaxNode node, int count)
                {
                    _node = node;
                    _count = count;
                    _childIndex = count;
                }

                public bool MoveNext()
                {
                    return --_childIndex >= 0;
                }

                public RedNode Current
                {
                    get
                    {
                        return ItemInternal(_node, _childIndex);
                    }
                }

                public void Reset()
                {
                    _childIndex = _count;
                }
            }

            private class EnumeratorImpl : IEnumerator<RedNode>
            {
                private Enumerator _enumerator;

                internal EnumeratorImpl(SyntaxNode node, int count)
                {
                    _enumerator = new Enumerator(node, count);
                }

                /// <summary>
                /// Gets the element in the collection at the current position of the enumerator.
                /// </summary>
                /// <returns>
                /// The element in the collection at the current position of the enumerator.
                ///   </returns>
                public RedNode Current
                {
                    get { return _enumerator.Current; }
                }

                /// <summary>
                /// Gets the element in the collection at the current position of the enumerator.
                /// </summary>
                /// <returns>
                /// The element in the collection at the current position of the enumerator.
                ///   </returns>
                object IEnumerator.Current
                {
                    get { return _enumerator.Current; }
                }

                /// <summary>
                /// Advances the enumerator to the next element of the collection.
                /// </summary>
                /// <returns>
                /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
                /// </returns>
                /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                public bool MoveNext()
                {
                    return _enumerator.MoveNext();
                }

                /// <summary>
                /// Sets the enumerator to its initial position, which is before the first element in the collection.
                /// </summary>
                /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                public void Reset()
                {
                    _enumerator.Reset();
                }

                /// <summary>
                /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
                /// </summary>
                public void Dispose()
                { }
            }
        }

    }

    public abstract class SyntaxNodeListBase : SyntaxNode
    {
        private readonly RedNode[] _children;

        internal SyntaxNodeListBase(InternalSyntaxNodeListBase green, SyntaxNode parent, int position)
            : base(green, parent, position) 
        {
            _children = new RedNode[green.SlotCount];
        }

        internal InternalSyntaxNodeListBase GreenList
        {
            get { return (InternalSyntaxNodeListBase)this.Green; }
        }

        internal bool IsWeak
        {
            get { return this.GreenList.IsWeak; }
        }

        public abstract bool IsSeparated { get; }

        public override SyntaxNode GetNodeSlot(int index)
        {
            return this.GetRedElement(ref _children[index], index) as SyntaxNode;
        }

        public override SyntaxNode GetCachedSlot(int index)
        {
            return _children[index] as SyntaxNode;
        }

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override void Accept(SyntaxVisitor visitor)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }

    public abstract class SyntaxNodeList : SyntaxNodeListBase
    {
        internal SyntaxNodeList(InternalSyntaxNodeList green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new InternalSyntaxNodeList GreenList
        {
            get { return (InternalSyntaxNodeList)this.Green; }
        }

        public override bool IsSeparated
        {
            get { return false; }
        }
    }

    public abstract class SeparatedSyntaxNodeList : SyntaxNodeListBase
    {
        private int index;

        internal SeparatedSyntaxNodeList(InternalSeparatedSyntaxNodeList green, SyntaxNode parent, int position, int index)
            : base(green, parent, position)
        {
            this.index = index;
        }

        public new InternalSeparatedSyntaxNodeList GreenList
        {
            get { return (InternalSeparatedSyntaxNodeList)this.Green; }
        }

        public override bool IsSeparated
        {
            get { return true; }
        }

        internal int Index
        {
            get { return this.index; }
        }

        public int SeparatorCount
        {
            get { return this.SlotCount >> 1; }
        }

        public abstract SyntaxToken GetSeparator(int index);
    }

    internal sealed class StrongSyntaxNodeList : SyntaxNodeList
    {
        private readonly RedNode[] _children;

        internal StrongSyntaxNodeList(InternalSyntaxNodeList green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
            _children = new RedNode[green.SlotCount];
        }

        public override SyntaxNode GetNodeSlot(int index)
        {
            return this.GetRedElement(ref _children[index], index) as SyntaxNode;
        }

        public override SyntaxNode GetCachedSlot(int index)
        {
            return _children[index] as SyntaxNode;
        }
    }

    internal sealed class StrongSeparatedSyntaxNodeList : SeparatedSyntaxNodeList
    {
        private readonly RedNode[] _children;

        internal StrongSeparatedSyntaxNodeList(InternalSeparatedSyntaxNodeList green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
            _children = new RedNode[(green.SlotCount + 1) >> 1];
        }

        public override SyntaxNode GetNodeSlot(int index)
        {
            if ((index & 1) != 0)
            {
                //separator
                return null;
            }

            return this.GetRedElement(ref _children[index >> 1], index) as SyntaxNode;

        }

        public override SyntaxNode GetCachedSlot(int index)
        {
            if ((index & 1) != 0)
            {
                //separator
                return null;
            }

            return _children[index >> 1] as SyntaxNode;
        }

        public override SyntaxToken GetSeparator(int index)
        {
            if ((index & 1) == 0)
            {
                //node
                return null;
            }

            return this.GetRedElement(ref _children[(index >> 1)|1], index) as SyntaxToken;

        }
    }

    internal sealed class WeakSyntaxNodeList : SyntaxNodeList
    {
        private readonly WeakReference<RedNode>[] _children;

        // We calculate and store the positions of all children here. This way, getting the position
        // of all children is O(N) [N being the list size], otherwise it is O(N^2) because getting
        // the position of a child later requires traversing all previous siblings.
        private readonly int[] _childPositions;

        internal WeakSyntaxNodeList(InternalWeakSyntaxNodeList green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
            int count = green.SlotCount;
            _children = new WeakReference<RedNode>[count];

            var childOffsets = new int[count];

            int childPosition = position;
            var greenChildren = green.Children;
            for (int i = 0; i < childOffsets.Length; ++i)
            {
                childOffsets[i] = childPosition;
                childPosition += greenChildren[i].FullWidth;
            }

            _childPositions = childOffsets;
        }

        public override int GetChildPosition(int index)
        {
            return _childPositions[index];
        }

        public override SyntaxNode GetNodeSlot(int index)
        {
            return this.GetWeakRedElement(ref _children[index], index) as SyntaxNode;
        }

        public override SyntaxNode GetCachedSlot(int index)
        {
            RedNode value = null;
            _children[index]?.TryGetTarget(out value);
            return value as SyntaxNode;
        }
    }

    internal sealed class WeakSeparatedSyntaxNodeList : SeparatedSyntaxNodeList
    {
        private readonly WeakReference<RedNode>[] _children;

        // We calculate and store the positions of all children here. This way, getting the position
        // of all children is O(N) [N being the list size], otherwise it is O(N^2) because getting
        // the position of a child later requires traversing all previous siblings.
        private readonly int[] _childPositions;

        internal WeakSeparatedSyntaxNodeList(InternalWeakSeparatedSyntaxNodeList green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
            int count = (green.SlotCount + 1) >> 1;
            _children = new WeakReference<RedNode>[count];

            int childPosition = position;
            var greenChildren = green.Children;
            var childOffsets = new int[greenChildren.Length];
            for (int i = 0; i < greenChildren.Length; ++i)
            {
                childOffsets[i] = childPosition;
                childPosition += greenChildren[i].FullWidth;
            }

            _childPositions = childOffsets;
        }

        public override int GetChildPosition(int index)
        {
            return _childPositions[index];
        }

        public override SyntaxNode GetNodeSlot(int index)
        {
            if ((index & 1) != 0)
            {
                //separator
                return null;
            }

            return this.GetWeakRedElement(ref _children[index >> 1], index) as SyntaxNode;
        }

        public override SyntaxNode GetCachedSlot(int index)
        {
            if ((index & 1) != 0)
            {
                //separator
                return null;
            }

            RedNode value = null;
            _children[index >> 1]?.TryGetTarget(out value);
            return value as SyntaxNode;
        }

        public override SyntaxToken GetSeparator(int index)
        {
            if ((index & 1) == 0)
            {
                //node
                return null;
            }

            return this.GetWeakRedElement(ref _children[(index >> 1) | 1], index) as SyntaxToken;

        }
    }
    
    public sealed class SyntaxTokenList : SyntaxList, IReadOnlyList<SyntaxToken>
    {
        internal SyntaxTokenList(InternalSyntaxTokenList green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
        }

        internal SyntaxTokenList(InternalSyntaxToken green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
        }

        /// <summary>
        /// Gets the token at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the token to get.</param>
        /// <returns>The token at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than 0.-or-<paramref name="index" /> is equal to or greater than <see cref="Count" />. </exception>
        public SyntaxToken this[int index]
        {
            get
            {
                if (Green.IsList)
                {
                    if (unchecked((uint)index < (uint)Green.SlotCount))
                    {
                        return (SyntaxToken)this.Green.GetSlot(index).CreateRed(this.Parent, this.Position + this.Green.GetSlotOffset(index), this.Index + index);
                    }
                }
                else if (index == 0)
                {
                    return (SyntaxToken)this.Green.CreateRed(this.Parent, this.Position + this.Green.GetSlotOffset(index), this.Index + index);
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Returns the first token in the list.
        /// </summary>
        /// <returns>The first token in the list.</returns>
        /// <exception cref="InvalidOperationException">The list is empty.</exception>        
        public SyntaxToken First()
        {
            if (Any())
            {
                return this[0];
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the last token in the list.
        /// </summary>
        /// <returns> The last token in the list.</returns>
        /// <exception cref="InvalidOperationException">The list is empty.</exception>        
        public SyntaxToken Last()
        {
            if (Any())
            {
                return this[this.Count - 1];
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Tests whether the list is non-empty.
        /// </summary>
        /// <returns>True if the list contains any tokens.</returns>
        public bool Any()
        {
            return Green != null;
        }

        public int IndexOf(SyntaxToken tokenInList)
        {
            for (int i = 0, n = this.Count; i < n; i++)
            {
                var token = this[i];
                if (token == tokenInList)
                {
                    return i;
                }
            }

            return -1;
        }

        internal int IndexOf(int rawKind)
        {
            for (int i = 0, n = this.Count; i < n; i++)
            {
                if (this[i].RawKind == rawKind)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified token added to the end.
        /// </summary>
        /// <param name="token">The token to add.</param>
        public SyntaxTokenList Add(SyntaxToken token)
        {
            return Insert(this.Count, token);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified tokens added to the end.
        /// </summary>
        /// <param name="tokens">The tokens to add.</param>
        public SyntaxTokenList AddRange(IEnumerable<SyntaxToken> tokens)
        {
            return InsertRange(this.Count, tokens);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified token insert at the index.
        /// </summary>
        /// <param name="index">The index to insert the new token.</param>
        /// <param name="token">The token to insert.</param>
        public SyntaxTokenList Insert(int index, SyntaxToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            return InsertRange(index, new[] { token });
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified tokens insert at the index.
        /// </summary>
        /// <param name="index">The index to insert the new tokens.</param>
        /// <param name="tokens">The tokens to insert.</param>
        public SyntaxTokenList InsertRange(int index, IEnumerable<SyntaxToken> tokens)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (tokens == null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }

            var items = tokens.ToList();
            if (items.Count == 0)
            {
                return this;
            }

            var list = this.ToList();
            list.InsertRange(index, tokens);

            if (list.Count == 0)
            {
                return this;
            }

            return new SyntaxTokenList(new InternalSyntaxTokenList(list.Select(n => n.GreenToken).ToArray(), null, null), null, 0, 0);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the token at the specified index removed.
        /// </summary>
        /// <param name="index">The index of the token to remove.</param>
        public SyntaxTokenList RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var list = this.ToList();
            list.RemoveAt(index);
            return new SyntaxTokenList(new InternalSyntaxTokenList(list.Select(n => n.GreenToken).ToArray(), null, null), null, 0, 0);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified token removed.
        /// </summary>
        /// <param name="tokenInList">The token to remove.</param>
        public SyntaxTokenList Remove(SyntaxToken tokenInList)
        {
            var index = this.IndexOf(tokenInList);
            if (index >= 0 && index <= this.Count)
            {
                return RemoveAt(index);
            }

            return this;
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified token replaced with a new token.
        /// </summary>
        /// <param name="tokenInList">The token to replace.</param>
        /// <param name="newToken">The new token.</param>
        public SyntaxTokenList Replace(SyntaxToken tokenInList, SyntaxToken newToken)
        {
            if (newToken == null)
            {
                throw new ArgumentNullException(nameof(newToken));
            }

            return ReplaceRange(tokenInList, new[] { newToken });
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified token replaced with new tokens.
        /// </summary>
        /// <param name="tokenInList">The token to replace.</param>
        /// <param name="newTokens">The new tokens.</param>
        public SyntaxTokenList ReplaceRange(SyntaxToken tokenInList, IEnumerable<SyntaxToken> newTokens)
        {
            var index = this.IndexOf(tokenInList);
            if (index >= 0 && index <= this.Count)
            {
                var list = this.ToList();
                list.RemoveAt(index);
                list.InsertRange(index, newTokens);
                return new SyntaxTokenList(new InternalSyntaxTokenList(list.Select(n => n.GreenToken).ToArray(), null, null), null, 0, 0);
            }

            throw new ArgumentOutOfRangeException(nameof(tokenInList));
        }

        internal void CopyTo(int offset, GreenNode[] array, int arrayOffset, int count)
        {
            Debug.Assert(this.Count >= offset + count);

            for (int i = 0; i < count; i++)
            {
                array[arrayOffset + i] = GetGreenNodeAt(offset + i);
            }
        }

        /// <summary>
        /// get the green node at the given slot
        /// </summary>
        private GreenNode GetGreenNodeAt(int i)
        {
            return GetGreenNodeAt(this.Green, i);
        }

        /// <summary>
        /// get the green node at the given slot
        /// </summary>
        private static GreenNode GetGreenNodeAt(GreenNode node, int i)
        {
            Debug.Assert(node.IsList || (i == 0 && !node.IsList));
            return node.IsList ? node.GetSlot(i) : node;
        }

        public bool Equals(SyntaxTokenList other)
        {
            return Green == other.Green && Parent == other.Parent && Index == other.Index;
        }

        /// <summary>
        /// Compares this <see cref=" SyntaxTokenList"/> with the <paramref name="obj"/> for equality.
        /// </summary>
        /// <returns>True if the two objects are equal.</returns>
        public override bool Equals(object obj)
        {
            return obj is SyntaxTokenList && Equals((SyntaxTokenList)obj);
        }

        /// <summary>
        /// Serves as a hash function for the <see cref="SyntaxTokenList"/>
        /// </summary>
        public override int GetHashCode()
        {
            // Not call GHC on parent as it's expensive
            return Hash.Combine(Green, Index);
        }

        /// <summary>
        /// Returns an enumerator for the tokens in the <see cref="SyntaxTokenList"/>
        /// </summary>
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<SyntaxToken> IEnumerable<SyntaxToken>.GetEnumerator()
        {
            return new EnumeratorImpl(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EnumeratorImpl(this);
        }

        /// <summary>
        /// A structure for enumerating a <see cref="SyntaxTokenList"/>
        /// </summary>
        [SuppressMessage("Performance", "RS0008", Justification = "Equality not actually implemented")]
        [StructLayout(LayoutKind.Auto)]
        public struct Enumerator
        {
            // This enumerator allows us to enumerate through two types of lists.
            // either it looks like:
            //
            //   Parent
            //   |
            //   List
            //   |   \
            //   c1  c2
            //
            // or
            //
            //   Parent
            //   |
            //   c1
            //
            // I.e. in the single child case, we optimize and store the child
            // directly (without any list parent).
            //
            // Enumerating over the single child case is simple.  We just 
            // return it and we're done.
            //
            // In the multi child case, things are a bit more difficult.  We need
            // to return the children in order, while also keeping their offset
            // correct.

            private readonly SyntaxNode _parent;
            private readonly GreenNode _singleNodeOrList;
            private readonly int _baseIndex;
            private readonly int _count;

            private int _index;
            private GreenNode _current;
            private int _position;

            internal Enumerator(SyntaxTokenList list)
            {
                _parent = list.Parent;
                _singleNodeOrList = list.Green;
                _baseIndex = list.Index;
                _count = list.Count;

                _index = -1;
                _current = null;
                _position = list.Position;
            }

            /// <summary>
            /// Advances the enumerator to the next token in the collection.
            /// </summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator
            /// has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                if (_count == 0 || _count <= _index + 1)
                {
                    // invalidate iterator
                    _current = null;
                    return false;
                }

                _index++;

                // Add the length of the previous node to the offset so that
                // the next node's offset is reported correctly.
                if (_current != null)
                {
                    _position += _current.FullWidth;
                }

                _current = GetGreenNodeAt(_singleNodeOrList, _index);
                System.Diagnostics.Debug.Assert(_current != null);
                return true;
            }

            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            public SyntaxToken Current
            {
                get
                {
                    if (_current == null)
                    {
                        throw new InvalidOperationException();
                    }

                    // In both the list and the single node case we want to 
                    // return the original root parent as the parent of this
                    // token.
                    return (SyntaxToken)_current.CreateRed(_parent, _position, _baseIndex + _index);
                }
            }

            public override bool Equals(object obj)
            {
                throw new NotSupportedException();
            }

            public override int GetHashCode()
            {
                throw new NotSupportedException();
            }
        }

        private class EnumeratorImpl : IEnumerator<SyntaxToken>
        {
            private Enumerator _enumerator;

            // SyntaxTriviaList is a relatively big struct so is passed by ref
            internal EnumeratorImpl(SyntaxTokenList list)
            {
                _enumerator = new Enumerator(list);
            }

            public SyntaxToken Current => _enumerator.Current;

            object IEnumerator.Current => _enumerator.Current;

            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public void Dispose()
            {
            }
        }
    }

    public sealed class SyntaxTriviaList : SyntaxList, IReadOnlyList<SyntaxTrivia>
    {
        private SyntaxToken token;

        internal SyntaxTriviaList(GreenNode node, SyntaxToken token, int position, int index)
            : base(node, token.Parent, position, index)
        {
            this.token = token;
        }

        internal SyntaxTriviaList(InternalSyntaxTriviaList node, SyntaxToken token, int position, int index)
            : base(node, token.Parent, position, index)
        {
            this.token = token;
        }

        internal SyntaxTriviaList(InternalSyntaxTrivia node, SyntaxToken token, int position, int index)
            : base(node, token.Parent, position, index)
        {
            this.token = token;
        }

        public SyntaxToken Token
        {
            get { return this.token; }
        }
        /// <summary>
        /// Gets the token at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the token to get.</param>
        /// <returns>The token at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than 0.-or-<paramref name="index" /> is equal to or greater than <see cref="Count" />. </exception>
        public SyntaxTrivia this[int index]
        {
            get
            {
                if (Green.IsList)
                {
                    if (unchecked((uint)index < (uint)Green.SlotCount))
                    {
                        return (SyntaxTrivia)this.Green.GetSlot(index).CreateRed(this.Parent, this.Position + this.Green.GetSlotOffset(index), this.Index + index);
                    }
                }
                else if (index == 0)
                {
                    return (SyntaxTrivia)this.Green.CreateRed(this.Parent, this.Position + this.Green.GetSlotOffset(index), this.Index + index);
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Returns the first trivia in the list.
        /// </summary>
        /// <returns>The first trivia in the list.</returns>
        /// <exception cref="InvalidOperationException">The list is empty.</exception>        
        public SyntaxTrivia First()
        {
            if (Any())
            {
                return this[0];
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the last trivia in the list.
        /// </summary>
        /// <returns>The last trivia in the list.</returns>
        /// <exception cref="InvalidOperationException">The list is empty.</exception>        
        public SyntaxTrivia Last()
        {
            if (Any())
            {
                return this[this.Count - 1];
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Does this list have any items.
        /// </summary>
        public bool Any()
        {
            return Green != null;
        }

        public int IndexOf(SyntaxTrivia triviaInList)
        {
            for (int i = 0, n = this.Count; i < n; i++)
            {
                var trivia = this[i];
                if (trivia == triviaInList)
                {
                    return i;
                }
            }

            return -1;
        }

        internal int IndexOf(int rawKind)
        {
            for (int i = 0, n = this.Count; i < n; i++)
            {
                if (this[i].RawKind == rawKind)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified trivia added to the end.
        /// </summary>
        /// <param name="trivia">The trivia to add.</param>
        public SyntaxTriviaList Add(SyntaxTrivia trivia)
        {
            return Insert(this.Count, trivia);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified trivia added to the end.
        /// </summary>
        /// <param name="trivia">The trivia to add.</param>
        public SyntaxTriviaList AddRange(IEnumerable<SyntaxTrivia> trivia)
        {
            return InsertRange(this.Count, trivia);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified trivia inserted at the index.
        /// </summary>
        /// <param name="index">The index in the list to insert the trivia at.</param>
        /// <param name="trivia">The trivia to insert.</param>
        public SyntaxTriviaList Insert(int index, SyntaxTrivia trivia)
        {
            if (trivia == null)
            {
                throw new ArgumentNullException(nameof(trivia));
            }
            return InsertRange(index, new[] { trivia });
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified trivia inserted at the index.
        /// </summary>
        /// <param name="index">The index in the list to insert the trivia at.</param>
        /// <param name="trivia">The trivia to insert.</param>
        public SyntaxTriviaList InsertRange(int index, IEnumerable<SyntaxTrivia> trivia)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var items = trivia.ToList();
            if (items.Count == 0)
            {
                return this;
            }

            var list = this.ToList();
            list.InsertRange(index, items);

            if (list.Count == 0)
            {
                return this;
            }

            return new SyntaxTriviaList(new InternalSyntaxTriviaList(list.Select(n => n.GreenTrivia).ToArray(), null, null), null, 0, 0);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the element at the specified index removed.
        /// </summary>
        /// <param name="index">The index identifying the element to remove.</param>
        public SyntaxTriviaList RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var list = this.ToList();
            list.RemoveAt(index);
            return new SyntaxTriviaList(new InternalSyntaxTriviaList(list.Select(n => n.GreenTrivia).ToArray(), null, null), null, 0, 0);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified element removed.
        /// </summary>
        /// <param name="triviaInList">The trivia element to remove.</param>
        public SyntaxTriviaList Remove(SyntaxTrivia triviaInList)
        {
            var index = this.IndexOf(triviaInList);
            if (index >= 0 && index < this.Count)
            {
                return this.RemoveAt(index);
            }

            return this;
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified element replaced with new trivia.
        /// </summary>
        /// <param name="triviaInList">The trivia element to replace.</param>
        /// <param name="newTrivia">The trivia to replace the element with.</param>
        public SyntaxTriviaList Replace(SyntaxTrivia triviaInList, SyntaxTrivia newTrivia)
        {
            if (newTrivia == null)
            {
                throw new ArgumentNullException(nameof(newTrivia));
            }

            return ReplaceRange(triviaInList, new[] { newTrivia });
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified element replaced with new trivia.
        /// </summary>
        /// <param name="triviaInList">The trivia element to replace.</param>
        /// <param name="newTrivia">The trivia to replace the element with.</param>
        public SyntaxTriviaList ReplaceRange(SyntaxTrivia triviaInList, IEnumerable<SyntaxTrivia> newTrivia)
        {
            var index = this.IndexOf(triviaInList);
            if (index >= 0 && index < this.Count)
            {
                var list = this.ToList();
                list.RemoveAt(index);
                list.InsertRange(index, newTrivia);
                return new SyntaxTriviaList(new InternalSyntaxTriviaList(list.Select(n => n.GreenTrivia).ToArray(), null, null), null, 0, 0);
            }

            throw new ArgumentOutOfRangeException(nameof(triviaInList));
        }

        /// <summary>
        /// Copy <paramref name="count"/> number of items starting at <paramref name="offset"/> from this list into <paramref name="array"/> starting at <paramref name="arrayOffset"/>.
        /// </summary>
        internal void CopyTo(int offset, SyntaxTrivia[] array, int arrayOffset, int count)
        {
            if (offset < 0 || count < 0 || this.Count < offset + count)
            {
                throw new IndexOutOfRangeException();
            }

            if (count == 0)
            {
                return;
            }

            // get first one without creating any red node
            var first = this[offset];
            array[arrayOffset] = first;

            // calculate trivia position from the first ourselves from now on
            var position = first.Position;
            var current = first;

            for (int i = 1; i < count; i++)
            {
                position += current.FullWidth;
                var greenTrivia = GetGreenNodeAt(offset + i);
                current = (SyntaxTrivia)greenTrivia.CreateRed(Token, position, Index + i);
                array[arrayOffset + i] = current;
            }
        }

        /// <summary>
        /// get the green node at the specific slot
        /// </summary>
        private GreenNode GetGreenNodeAt(int i)
        {
            return GetGreenNodeAt(Green, i);
        }

        private static GreenNode GetGreenNodeAt(GreenNode node, int i)
        {
            Debug.Assert(node.IsList || (i == 0 && !node.IsList));
            return node.IsList ? node.GetSlot(i) : node;
        }

        public bool Equals(SyntaxTriviaList other)
        {
            return Green == other.Green && Index == other.Index && Token.Equals(other.Token);
        }

        public override bool Equals(object obj)
        {
            return (obj is SyntaxTriviaList) && Equals((SyntaxTriviaList)obj);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(Token.GetHashCode(), Hash.Combine(Green, Index));
        }

        IEnumerator<SyntaxTrivia> IEnumerable<SyntaxTrivia>.GetEnumerator()
        {
            return new EnumeratorImpl(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EnumeratorImpl(this);
        }

        [StructLayout(LayoutKind.Auto)]
        public struct Enumerator
        {
            private SyntaxToken _token;
            private GreenNode _singleNodeOrList;
            private int _baseIndex;
            private int _count;

            private int _index;
            private GreenNode _current;
            private int _position;

            internal Enumerator(SyntaxTriviaList list)
            {
                _token = list.Token;
                _singleNodeOrList = list.Green;
                _baseIndex = list.Index;
                _count = list.Count;

                _index = -1;
                _current = null;
                _position = list.Position;
            }

            // PERF: Passing SyntaxToken by ref since it's a non-trivial struct
            private void InitializeFrom(SyntaxToken token, GreenNode greenNode, int index, int position)
            {
                _token = token;
                _singleNodeOrList = greenNode;
                _baseIndex = index;
                _count = greenNode.IsList ? greenNode.SlotCount : 1;

                _index = -1;
                _current = null;
                _position = position;
            }

            // PERF: Used to initialize an enumerator for leading trivia directly from a token.
            // This saves constructing an intermediate SyntaxTriviaList. Also, passing token
            // by ref since it's a non-trivial struct
            internal void InitializeFromLeadingTrivia(SyntaxToken token)
            {
                InitializeFrom(token, token.GreenToken.GetLeadingTrivia(), 0, token.Position);
            }

            // PERF: Used to initialize an enumerator for trailing trivia directly from a token.
            // This saves constructing an intermediate SyntaxTriviaList. Also, passing token
            // by ref since it's a non-trivial struct
            internal void InitializeFromTrailingTrivia(SyntaxToken token)
            {
                var leading = token.GreenToken.GetLeadingTrivia();
                int index = 0;
                if (leading != null)
                {
                    index = leading.IsList ? leading.SlotCount : 1;
                }

                var trailingGreen = token.GreenToken.GetTrailingTrivia();
                int trailingPosition = token.Position + token.FullWidth;
                if (trailingGreen != null)
                {
                    trailingPosition -= trailingGreen.FullWidth;
                }

                InitializeFrom(token, trailingGreen, index, trailingPosition);
            }

            public bool MoveNext()
            {
                int newIndex = _index + 1;
                if (newIndex >= _count)
                {
                    // invalidate iterator
                    _current = null;
                    return false;
                }

                _index = newIndex;

                if (_current != null)
                {
                    _position += _current.FullWidth;
                }

                _current = GetGreenNodeAt(_singleNodeOrList, newIndex);
                return true;
            }

            public SyntaxTrivia Current
            {
                get
                {
                    if (_current == null)
                    {
                        throw new InvalidOperationException();
                    }

                    return (SyntaxTrivia)_current.CreateRed(_token, _position, _baseIndex + _index);
                }
            }
        }

        private class EnumeratorImpl : IEnumerator<SyntaxTrivia>
        {
            private Enumerator _enumerator;

            // SyntaxTriviaList is a relatively big struct so is passed as ref
            internal EnumeratorImpl(SyntaxTriviaList list)
            {
                _enumerator = new Enumerator(list);
            }

            public SyntaxTrivia Current => _enumerator.Current;

            object IEnumerator.Current => _enumerator.Current;

            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public void Dispose()
            {
            }
        }

    }

    public sealed class SyntaxNodeList<TNode> : IReadOnlyList<TNode>
        where TNode: SyntaxNode
    {
        private static readonly SyntaxNodeList<TNode> Empty = new SyntaxNodeList<TNode>(null);

        private readonly SyntaxNode _node;

        public SyntaxNodeList(SyntaxNode node)
        {
            _node = node;
        }

        public SyntaxNode Node
        {
            get { return _node; }
        }

        public InternalSyntaxNodeList Green
        {
            get
            {
                return _node?.GreenNode as InternalSyntaxNodeList;
            }
        }

        /// <summary>
        /// The number of nodes in the list.
        /// </summary>
        public int Count
        {
            get
            {
                return _node == null ? 0 : (_node.IsList ? _node.SlotCount : 1);
            }
        }

        /// <summary>
        /// Gets the node at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the node to get or set.</param>
        /// <returns>The node at the specified index.</returns>
        public TNode this[int index]
        {
            get
            {
                if (_node != null)
                {
                    if (_node.IsList)
                    {
                        if (unchecked((uint)index < (uint)_node.SlotCount))
                        {
                            return (TNode)_node.GetNodeSlot(index);
                        }
                    }
                    else if (index == 0)
                    {
                        return (TNode)_node;
                    }
                }
                throw new ArgumentOutOfRangeException();
            }
        }

        internal SyntaxNode ItemInternal(int index)
        {
            if (_node.IsList)
            {
                return _node.GetNodeSlot(index);
            }

            Debug.Assert(index == 0);
            return _node;
        }

        /// <summary>
        /// The absolute span of the list elements in characters, including the leading and trailing trivia of the first and last elements.
        /// </summary>
        public TextSpan FullSpan
        {
            get
            {
                if (this.Count == 0)
                {
                    return TextSpan.Default;
                }
                else
                {
                    return TextSpan.FromBounds(this[0].FullSpan.Start, this[this.Count - 1].FullSpan.End);
                }
            }
        }

        /// <summary>
        /// The absolute span of the list elements in characters, not including the leading and trailing trivia of the first and last elements.
        /// </summary>
        public TextSpan Span
        {
            get
            {
                if (this.Count == 0)
                {
                    return TextSpan.Default;
                }
                else
                {
                    return TextSpan.FromBounds(this[0].Span.Start, this[this.Count - 1].Span.End);
                }
            }
        }

        /// <summary>
        /// Returns the string representation of the nodes in this list, not including 
        /// the first node's leading trivia and the last node's trailing trivia.
        /// </summary>
        /// <returns>
        /// The string representation of the nodes in this list, not including 
        /// the first node's leading trivia and the last node's trailing trivia.
        /// </returns>
        public override string ToString()
        {
            return _node != null ? _node.ToString() : string.Empty;
        }

        /// <summary>
        /// Returns the full string representation of the nodes in this list including 
        /// the first node's leading trivia and the last node's trailing trivia.
        /// </summary>
        /// <returns>
        /// The full string representation of the nodes in this list including 
        /// the first node's leading trivia and the last node's trailing trivia.
        /// </returns>
        public string ToFullString()
        {
            return _node != null ? _node.ToFullString() : string.Empty;
        }

        /// <summary>
        /// Creates a new list with the specified node added at the end.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public SyntaxNodeList<TNode> Add(TNode node)
        {
            return this.Insert(this.Count, node);
        }

        /// <summary>
        /// Creates a new list with the specified nodes added at the end.
        /// </summary>
        /// <param name="nodes">The nodes to add.</param>
        public SyntaxNodeList<TNode> AddRange(IEnumerable<TNode> nodes)
        {
            return this.InsertRange(this.Count, nodes);
        }

        /// <summary>
        /// Creates a new list with the specified node inserted at the index.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="node">The node to insert.</param>
        public SyntaxNodeList<TNode> Insert(int index, TNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            return InsertRange(index, new[] { node });
        }

        /// <summary>
        /// Creates a new list with the specified nodes inserted at the index.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="nodes">The nodes to insert.</param>
        public SyntaxNodeList<TNode> InsertRange(int index, IEnumerable<TNode> nodes)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (nodes == null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            var list = this.ToList();
            list.InsertRange(index, nodes);

            if (list.Count == 0)
            {
                return this;
            }
            else 
            {
                return CreateList(this.Green, list);
            }
        }

        /// <summary>
        /// Creates a new list with the element at specified index removed.
        /// </summary>
        /// <param name="index">The index of the element to remove.</param>
        public SyntaxNodeList<TNode> RemoveAt(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return this.Remove(this[index]);
        }

        /// <summary>
        /// Creates a new list with the element removed.
        /// </summary>
        /// <param name="node">The element to remove.</param>
        public SyntaxNodeList<TNode> Remove(TNode node)
        {
            return CreateList(this.Green, this.Where(x => x != node).ToList());
        }

        /// <summary>
        /// Creates a new list with the specified element replaced with the new node.
        /// </summary>
        /// <param name="nodeInList">The element to replace.</param>
        /// <param name="newNode">The new node.</param>
        public SyntaxNodeList<TNode> Replace(TNode nodeInList, TNode newNode)
        {
            return ReplaceRange(nodeInList, new[] { newNode });
        }

        /// <summary>
        /// Creates a new list with the specified element replaced with new nodes.
        /// </summary>
        /// <param name="nodeInList">The element to replace.</param>
        /// <param name="newNodes">The new nodes.</param>
        public SyntaxNodeList<TNode> ReplaceRange(TNode nodeInList, IEnumerable<TNode> newNodes)
        {
            if (nodeInList == null)
            {
                throw new ArgumentNullException(nameof(nodeInList));
            }

            if (newNodes == null)
            {
                throw new ArgumentNullException(nameof(newNodes));
            }

            var index = this.IndexOf(nodeInList);
            if (index >= 0 && index < this.Count)
            {
                var list = this.ToList();
                list.RemoveAt(index);
                list.InsertRange(index, newNodes);
                return CreateList(this.Green, list);
            }
            else
            {
                throw new ArgumentException("nodeInList");
            }
        }

        private static SyntaxNodeList<TNode> CreateList(InternalSyntaxNodeList creator, List<TNode> items)
        {
            if (items.Count == 0)
            {
                return SyntaxNodeList<TNode>.Empty;
            }

            InternalSyntaxNodeList newGreen;
            if (creator == null)
            {
                newGreen = new InternalStrongSyntaxNodeList(items.Select(n => n.GreenNode).ToArray(), null, null);
            }
            else
            {
                newGreen = creator.CreateList(items.Select(n => n.GreenNode).ToArray());
            }
            return new SyntaxNodeList<TNode>((SyntaxNodeList)newGreen.CreateRed());
        }

        /// <summary>
        /// The first node in the list.
        /// </summary>
        public TNode First()
        {
            return this[0];
        }

        /// <summary>
        /// The first node in the list or default if the list is empty.
        /// </summary>
        public TNode FirstOrDefault()
        {
            if (this.Any())
            {
                return this[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The last node in the list.
        /// </summary>
        public TNode Last()
        {
            return this[this.Count - 1];
        }

        /// <summary>
        /// The last node in the list or default if the list is empty.
        /// </summary>
        public TNode LastOrDefault()
        {
            if (this.Any())
            {
                return this[this.Count - 1];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// True if the list has at least one node.
        /// </summary>
        public bool Any()
        {
            Debug.Assert(_node == null || Count != 0);
            return _node != null;
        }

        // for debugging
        private TNode[] Nodes
        {
            get { return this.ToArray(); }
        }

        /// <summary>
        /// Get's the enumerator for this list.
        /// </summary>
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<TNode> IEnumerable<TNode>.GetEnumerator()
        {
            if (this.Any())
            {
                return new EnumeratorImpl(this);
            }

            return EmptyCollections.Enumerator<TNode>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (this.Any())
            {
                return new EnumeratorImpl(this);
            }

            return EmptyCollections.Enumerator<TNode>();
        }

        public bool Equals(SyntaxNodeList<TNode> other)
        {
            return _node == other._node;
        }

        public override bool Equals(object obj)
        {
            return obj is SyntaxNodeList<TNode> && Equals((SyntaxNodeList<TNode>)obj);
        }

        public override int GetHashCode()
        {
            return _node?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// The index of the node in this list, or -1 if the node is not in the list.
        /// </summary>
        public int IndexOf(TNode node)
        {
            var index = 0;
            foreach (var child in this)
            {
                if (object.Equals(child, node))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public int IndexOf(Func<TNode, bool> predicate)
        {
            var index = 0;
            foreach (var child in this)
            {
                if (predicate(child))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        internal int IndexOf(int rawKind)
        {
            var index = 0;
            foreach (var child in this)
            {
                if (child.RawKind == rawKind)
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public int LastIndexOf(TNode node)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (object.Equals(this[i], node))
                {
                    return i;
                }
            }

            return -1;
        }

        public int LastIndexOf(Func<TNode, bool> predicate)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (predicate(this[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        [SuppressMessage("Performance", "RS0008", Justification = "Equality not actually implemented")]
        public struct Enumerator
        {
            private SyntaxNodeList<TNode> _list;
            private int _index;

            internal Enumerator(SyntaxNodeList<TNode> list)
            {
                _list = list;
                _index = -1;
            }

            public bool MoveNext()
            {
                int newIndex = _index + 1;
                if (newIndex < _list.Count)
                {
                    _index = newIndex;
                    return true;
                }

                return false;
            }

            public TNode Current
            {
                get
                {
                    return (TNode)_list.ItemInternal(_index);
                }
            }

            public void Reset()
            {
                _index = -1;
            }

            public override bool Equals(object obj)
            {
                throw new NotSupportedException();
            }

            public override int GetHashCode()
            {
                throw new NotSupportedException();
            }
        }

        private class EnumeratorImpl : IEnumerator<TNode>
        {
            private Enumerator _e;

            internal EnumeratorImpl(SyntaxNodeList<TNode> list)
            {
                _e = new Enumerator(list);
            }

            public bool MoveNext()
            {
                return _e.MoveNext();
            }

            public TNode Current
            {
                get
                {
                    return _e.Current;
                }
            }

            void IDisposable.Dispose()
            {
            }

            object IEnumerator.Current
            {
                get
                {
                    return _e.Current;
                }
            }

            void IEnumerator.Reset()
            {
                _e.Reset();
            }
        }

    }

    public sealed class SeparatedSyntaxNodeList<TNode> : IReadOnlyList<TNode>
        where TNode : SyntaxNode
    {
        private readonly SeparatedSyntaxNodeList _list;
        private readonly int _count;
        private readonly int _separatorCount;

        public SeparatedSyntaxNodeList(SeparatedSyntaxNodeList list)
        {
            Validate(list.GreenList);

            // calculating counts is very cheap when list interleaves nodes and tokens
            // so lets just do it here.

            int allCount = list.GreenList.Count;
            _count = (allCount + 1) >> 1;
            _separatorCount = allCount >> 1;

            _list = list;
        }

        [Conditional("DEBUG")]
        private static void Validate(InternalSeparatedSyntaxNodeList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if ((i & 1) == 0)
                {
                    Debug.Assert(item.IsNode, "Node missing in separated list.");
                }
                else
                {
                    Debug.Assert(item.IsToken, "Separator token missing in separated list.");
                }
            }
        }

        public SyntaxNode Node
        {
            get { return _list; }
        }

        public InternalSeparatedSyntaxNodeList Green
        {
            get
            {
                return _list.GreenList;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public int SeparatorCount
        {
            get
            {
                return _separatorCount;
            }
        }

        public TNode this[int index]
        {
            get
            {
                if (_list != null)
                {
                    if (unchecked((uint)index < (uint)_count))
                    {
                        return (TNode)_list.GetNodeSlot(index << 1);
                    }
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Gets the separator at the given index in this list.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public SyntaxToken GetSeparator(int index)
        {
            if (_list != null)
            {
                if (unchecked((uint)index < (uint)_separatorCount))
                {
                    index = (index << 1) + 1;
                    var green = _list.Green.GetSlot(index);
                    Debug.Assert(green.IsToken);
                    return ((InternalSyntaxToken)green).CreateRed(_list.Parent, _list.GetChildPosition(index), _list.Index + index);
                }
            }

            throw new ArgumentOutOfRangeException(nameof(index));
        }

        /// <summary>
        /// Returns the sequence of just the separator tokens.
        /// </summary>
        public IEnumerable<SyntaxToken> GetSeparators()
        {
            SyntaxToken[] result = new SyntaxToken[_separatorCount];
            for (int i = 0; i < _separatorCount; i++)
            {
                int index = (i << 1) + 1;
                var green = _list.Green.GetSlot(index);
                Debug.Assert(green.IsToken);
                result[i] = ((InternalSyntaxToken)green).CreateRed(_list.Parent, _list.GetChildPosition(index), _list.Index + index);
            }
            return result;
        }

        /// <summary>
        /// The absolute span of the list elements in characters, including the leading and trailing trivia of the first and last elements.
        /// </summary>
        public TextSpan FullSpan
        {
            get { return _list.FullSpan; }
        }

        /// <summary>
        /// The absolute span of the list elements in characters, not including the leading and trailing trivia of the first and last elements.
        /// </summary>
        public TextSpan Span
        {
            get { return _list.Span; }
        }

        /// <summary>
        /// Returns the string representation of the nodes in this list including separators but not including 
        /// the first node's leading trivia and the last node or token's trailing trivia.
        /// </summary>
        /// <returns>
        /// The string representation of the nodes in this list including separators but not including 
        /// the first node's leading trivia and the last node or token's trailing trivia.
        /// </returns>
        public override string ToString()
        {
            return _list.ToString();
        }

        /// <summary>
        /// Returns the full string representation of the nodes in this list including separators, 
        /// the first node's leading trivia, and the last node or token's trailing trivia.
        /// </summary>
        /// <returns>
        /// The full string representation of the nodes in this list including separators including separators,
        /// the first node's leading trivia, and the last node or token's trailing trivia.
        /// </returns>
        public string ToFullString()
        {
            return _list.ToFullString();
        }

        public TNode First()
        {
            return this[0];
        }

        public TNode FirstOrDefault()
        {
            if (this.Any())
            {
                return this[0];
            }

            return null;
        }

        public TNode Last()
        {
            return this[this.Count - 1];
        }

        public TNode LastOrDefault()
        {
            if (this.Any())
            {
                return this[this.Count - 1];
            }

            return null;
        }

        public bool Contains(TNode node)
        {
            return this.IndexOf(node) >= 0;
        }

        public int IndexOf(TNode node)
        {
            for (int i = 0, n = this.Count; i < n; i++)
            {
                if (object.Equals(this[i], node))
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(Func<TNode, bool> predicate)
        {
            for (int i = 0, n = this.Count; i < n; i++)
            {
                if (predicate(this[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        internal int IndexOf(int rawKind)
        {
            for (int i = 0, n = this.Count; i < n; i++)
            {
                if (this[i].RawKind == rawKind)
                {
                    return i;
                }
            }

            return -1;
        }

        public int LastIndexOf(TNode node)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (object.Equals(this[i], node))
                {
                    return i;
                }
            }

            return -1;
        }

        public int LastIndexOf(Func<TNode, bool> predicate)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (predicate(this[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Any()
        {
            return _list != null;
        }

        public bool Equals(SeparatedSyntaxNodeList<TNode> other)
        {
            return _list == other._list;
        }

        public override bool Equals(object obj)
        {
            return (obj is SeparatedSyntaxNodeList<TNode>) && Equals((SeparatedSyntaxNodeList<TNode>)obj);
        }

        public override int GetHashCode()
        {
            return _list.GetHashCode();
        }

        /// <summary>
        /// Creates a new list with the specified node added to the end.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public SeparatedSyntaxNodeList<TNode> Add(TNode node)
        {
            return Insert(this.Count, node);
        }

        /// <summary>
        /// Creates a new list with the specified nodes added to the end.
        /// </summary>
        /// <param name="nodes">The nodes to add.</param>
        public SeparatedSyntaxNodeList<TNode> AddRange(IEnumerable<TNode> nodes)
        {
            return InsertRange(this.Count, nodes);
        }

        /// <summary>
        /// Creates a new list with the specified node inserted at the index.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="node">The node to insert.</param>
        public SeparatedSyntaxNodeList<TNode> Insert(int index, TNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            return InsertRange(index, new[] { node });
        }

        /// <summary>
        /// Creates a new list with the specified nodes inserted at the index.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="nodes">The nodes to insert.</param>
        public SeparatedSyntaxNodeList<TNode> InsertRange(int index, IEnumerable<TNode> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var nodesWithSeps = this.NodesWithSeparators;
            int insertionIndex = index < this.Count ? nodesWithSeps.IndexOf(this[index]) : nodesWithSeps.Count;

            // determine how to deal with separators (commas)
            if (insertionIndex > 0 && insertionIndex < nodesWithSeps.Count)
            {
                var previous = (SyntaxToken)nodesWithSeps[insertionIndex - 1];
                if (previous.IsToken && !KeepSeparatorWithPreviousNode(previous))
                {
                    // pull back so item in inserted before separator
                    insertionIndex--;
                }
            }

            var nodesToInsertWithSeparators = new List<RedNode>();
            foreach (var item in nodes)
            {
                if (item != null)
                {
                    // if item before insertion point is a node, add a separator
                    if (nodesToInsertWithSeparators.Count > 0 || (insertionIndex > 0 && nodesWithSeps[insertionIndex - 1].IsNode))
                    {
                        nodesToInsertWithSeparators.Add(item.Language.SyntaxFactory.Separator<TNode>(item));
                    }

                    nodesToInsertWithSeparators.Add(item);
                }
            }

            // if item after last inserted node is a node, add separator
            if (insertionIndex < nodesWithSeps.Count && nodesWithSeps[insertionIndex].IsNode)
            {
                var node = (TNode)nodesWithSeps[insertionIndex];
                nodesToInsertWithSeparators.Add(node.Language.SyntaxFactory.Separator<TNode>(node)); // separator
            }

            nodesWithSeps.InsertRange(insertionIndex, nodesToInsertWithSeparators);
            return this.CreateList(nodesWithSeps);
        }

        private static bool KeepSeparatorWithPreviousNode(SyntaxToken separator)
        {
            // if the trivia after the separator contains an explicit end of line or a single line comment
            // then it should stay associated with previous node
            foreach (var tr in separator.TrailingTrivia)
            {
                if (tr.Language.SyntaxFacts.IsTriviaWithEndOfLine(tr.RawKind))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Creates a new list with the element at the specified index removed.
        /// </summary>
        /// <param name="index">The index of the element to remove.</param>
        public SeparatedSyntaxNodeList<TNode> RemoveAt(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return this.Remove(this[index]);
        }

        /// <summary>
        /// Creates a new list with specified element removed.
        /// </summary>
        /// <param name="node">The element to remove.</param>
        public SeparatedSyntaxNodeList<TNode> Remove(TNode node)
        {
            var nodesWithSeps = this.NodesWithSeparators;
            int index = nodesWithSeps.IndexOf(node);

            if (index >= 0 && index <= nodesWithSeps.Count)
            {
                nodesWithSeps.RemoveAt(index);

                // remove separator too
                if (index < nodesWithSeps.Count && nodesWithSeps[index].IsToken)
                {
                    nodesWithSeps.RemoveAt(index);
                }
                else if (index > 0 && nodesWithSeps[index - 1].IsToken)
                {
                    nodesWithSeps.RemoveAt(index - 1);
                }

                return this.CreateList(nodesWithSeps);
            }

            return this;
        }

        /// <summary>
        /// Creates a new list with the specified element replaced by the new node.
        /// </summary>
        /// <param name="nodeInList">The element to replace.</param>
        /// <param name="newNode">The new node.</param>
        public SeparatedSyntaxNodeList<TNode> Replace(TNode nodeInList, TNode newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            var index = this.IndexOf(nodeInList);
            if (index >= 0 && index < this.Count)
            {
                var nodesWithSeps = this.NodesWithSeparators;
                nodesWithSeps[index] = newNode;
                return this.CreateList(nodesWithSeps);
            }

            throw new ArgumentOutOfRangeException(nameof(nodeInList));
        }

        /// <summary>
        /// Creates a new list with the specified element replaced by the new nodes.
        /// </summary>
        /// <param name="nodeInList">The element to replace.</param>
        /// <param name="newNodes">The new nodes.</param>
        public SeparatedSyntaxNodeList<TNode> ReplaceRange(TNode nodeInList, IEnumerable<TNode> newNodes)
        {
            if (newNodes == null)
            {
                throw new ArgumentNullException(nameof(newNodes));
            }

            var index = this.IndexOf(nodeInList);
            if (index >= 0 && index < this.Count)
            {
                var newNodeList = newNodes.ToList();
                if (newNodeList.Count == 0)
                {
                    return this.Remove(nodeInList);
                }

                var listWithFirstReplaced = this.Replace(nodeInList, newNodeList[0]);

                if (newNodeList.Count > 1)
                {
                    newNodeList.RemoveAt(0);
                    return listWithFirstReplaced.InsertRange(index + 1, newNodeList);
                }

                return listWithFirstReplaced;
            }

            throw new ArgumentOutOfRangeException(nameof(nodeInList));
        }

        /// <summary>
        /// Creates a new list with the specified separator token replaced with the new separator.
        /// </summary>
        /// <param name="separatorToken">The separator token to be replaced.</param>
        /// <param name="newSeparator">The new separator token.</param>
        public SeparatedSyntaxNodeList<TNode> ReplaceSeparator(SyntaxToken separatorToken, SyntaxToken newSeparator)
        {
            var nodesWithSeps = this.NodesWithSeparators;
            var index = nodesWithSeps.IndexOf(separatorToken);
            if (index < 0)
            {
                throw new ArgumentException("separatorToken");
            }

            if (newSeparator.RawKind != nodesWithSeps[index].RawKind ||
                newSeparator.Language != nodesWithSeps[index].Language)
            {
                throw new ArgumentException("newSeparator");
            }

            nodesWithSeps[index] = newSeparator;
            return this.CreateList(nodesWithSeps);
        }

        // for debugging
        private TNode[] Nodes
        {
            get { return this.ToArray(); }
        }

        private List<RedNode> NodesWithSeparators
        {
            get
            {
                List<RedNode> result = new List<RedNode>(_list.SlotCount);
                for (int i = 0, count = _list.SlotCount; i < count; i++)
                {
                    if ((i & 1) == 0)
                    {
                        var red = _list.GetNodeSlot(i >> 1);
                        result.Add(red);
                    }
                    else
                    {
                        var green = _list.Green.GetSlot(i);
                        result.Add(green.CreateRed(_list.Parent, _list.GetChildPosition(i), _list.Index + i));
                    }
                }
                return result;
            }
        }

        private SeparatedSyntaxNodeList<TNode> CreateList(List<RedNode> nodesWithSeps)
        {
            return new SeparatedSyntaxNodeList<TNode>((SeparatedSyntaxNodeList)this._list.GreenList.CreateList(nodesWithSeps.Select(n => n.Green).ToArray()).CreateRed());
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<TNode> IEnumerable<TNode>.GetEnumerator()
        {
            if (this.Any())
            {
                return new EnumeratorImpl(this);
            }

            return EmptyCollections.Enumerator<TNode>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (this.Any())
            {
                return new EnumeratorImpl(this);
            }

            return EmptyCollections.Enumerator<TNode>();
        }

        // Public struct enumerator
        // Only implements enumerator pattern as used by foreach
        // Does not implement IEnumerator. Doing so would require the struct to implement IDisposable too.
        [SuppressMessage("Performance", "RS0008", Justification = "Equality not actually implemented")]
        public struct Enumerator
        {
            private readonly SeparatedSyntaxNodeList<TNode> _list;
            private int _index;

            internal Enumerator(SeparatedSyntaxNodeList<TNode> list)
            {
                _list = list;
                _index = -1;
            }

            public bool MoveNext()
            {
                int newIndex = _index + 1;
                if (newIndex < _list.Count)
                {
                    _index = newIndex;
                    return true;
                }

                return false;
            }

            public TNode Current
            {
                get
                {
                    return _list[_index];
                }
            }

            public void Reset()
            {
                _index = -1;
            }

            public override bool Equals(object obj)
            {
                throw new NotSupportedException();
            }

            public override int GetHashCode()
            {
                throw new NotSupportedException();
            }
        }

        // IEnumerator wrapper for Enumerator.
        private class EnumeratorImpl : IEnumerator<TNode>
        {
            private Enumerator _e;

            internal EnumeratorImpl(SeparatedSyntaxNodeList<TNode> list)
            {
                _e = new Enumerator(list);
            }

            public TNode Current
            {
                get
                {
                    return _e.Current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return _e.Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return _e.MoveNext();
            }

            public void Reset()
            {
                _e.Reset();
            }
        }

    }
}
