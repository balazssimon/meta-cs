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

    public abstract class NodeListBase : SyntaxNode
    {
        private readonly RedNode[] _children;

        internal NodeListBase(InternalNodeListBase green, SyntaxNode parent, int position)
            : base(green, parent, position) 
        {
            _children = new RedNode[green.SlotCount];
        }

        internal InternalNodeListBase GreenList
        {
            get { return (InternalNodeListBase)this.Green; }
        }

        internal bool IsWeak
        {
            get { return this.GreenList.IsWeak; }
        }

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

    public abstract class NodeList : NodeListBase
    {
        internal NodeList(InternalNodeList green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new InternalNodeList GreenList
        {
            get { return (InternalNodeList)this.Green; }
        }
    }

    public abstract class SeparatedNodeList : NodeListBase
    {
        private int index;

        internal SeparatedNodeList(InternalSeparatedNodeList green, SyntaxNode parent, int position, int index)
            : base(green, parent, position)
        {
            this.index = index;
        }

        public new InternalSeparatedNodeList GreenList
        {
            get { return (InternalSeparatedNodeList)this.Green; }
        }

        internal int Index
        {
            get { return this.index; }
        }
    }

    internal sealed class StrongNodeList : NodeList
    {
        private readonly RedNode[] _children;

        internal StrongNodeList(InternalNodeList green, SyntaxNode parent, int position)
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

    internal sealed class StrongSeparatedNodeList : SeparatedNodeList
    {
        private readonly RedNode[] _children;

        internal StrongSeparatedNodeList(InternalSeparatedNodeList green, SyntaxNode parent, int position, int index)
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
    }

    internal sealed class WeakNodeList : NodeList
    {
        private readonly WeakReference<RedNode>[] _children;

        // We calculate and store the positions of all children here. This way, getting the position
        // of all children is O(N) [N being the list size], otherwise it is O(N^2) because getting
        // the position of a child later requires traversing all previous siblings.
        private readonly int[] _childPositions;

        internal WeakNodeList(InternalWeakNodeList green, SyntaxNode parent, int position)
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

    internal sealed class WeakSeparatedNodeList : SeparatedNodeList
    {
        private readonly WeakReference<RedNode>[] _children;

        // We calculate and store the positions of all children here. This way, getting the position
        // of all children is O(N) [N being the list size], otherwise it is O(N^2) because getting
        // the position of a child later requires traversing all previous siblings.
        private readonly int[] _childPositions;

        internal WeakSeparatedNodeList(InternalWeakSeparatedNodeList green, SyntaxNode parent, int position, int index)
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
    }
    
    public sealed class TokenList : SyntaxList, IReadOnlyList<SyntaxToken>
    {
        internal TokenList(InternalTokenList green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
        }

        internal TokenList(InternalSyntaxToken green, SyntaxNode parent, int position, int index)
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
        public TokenList Add(SyntaxToken token)
        {
            return Insert(this.Count, token);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified tokens added to the end.
        /// </summary>
        /// <param name="tokens">The tokens to add.</param>
        public TokenList AddRange(IEnumerable<SyntaxToken> tokens)
        {
            return InsertRange(this.Count, tokens);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified token insert at the index.
        /// </summary>
        /// <param name="index">The index to insert the new token.</param>
        /// <param name="token">The token to insert.</param>
        public TokenList Insert(int index, SyntaxToken token)
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
        public TokenList InsertRange(int index, IEnumerable<SyntaxToken> tokens)
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

            return new TokenList(new InternalTokenList(list.Select(n => n.GreenToken).ToArray(), null, null), null, 0, 0);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the token at the specified index removed.
        /// </summary>
        /// <param name="index">The index of the token to remove.</param>
        public TokenList RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var list = this.ToList();
            list.RemoveAt(index);
            return new TokenList(new InternalTokenList(list.Select(n => n.GreenToken).ToArray(), null, null), null, 0, 0);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTokenList"/> with the specified token removed.
        /// </summary>
        /// <param name="tokenInList">The token to remove.</param>
        public TokenList Remove(SyntaxToken tokenInList)
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
        public TokenList Replace(SyntaxToken tokenInList, SyntaxToken newToken)
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
        public TokenList ReplaceRange(SyntaxToken tokenInList, IEnumerable<SyntaxToken> newTokens)
        {
            var index = this.IndexOf(tokenInList);
            if (index >= 0 && index <= this.Count)
            {
                var list = this.ToList();
                list.RemoveAt(index);
                list.InsertRange(index, newTokens);
                return new TokenList(new InternalTokenList(list.Select(n => n.GreenToken).ToArray(), null, null), null, 0, 0);
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

        public bool Equals(TokenList other)
        {
            return Green == other.Green && Parent == other.Parent && Index == other.Index;
        }

        /// <summary>
        /// Compares this <see cref=" SyntaxTokenList"/> with the <paramref name="obj"/> for equality.
        /// </summary>
        /// <returns>True if the two objects are equal.</returns>
        public override bool Equals(object obj)
        {
            return obj is TokenList && Equals((TokenList)obj);
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

            internal Enumerator(TokenList list)
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
            internal EnumeratorImpl(TokenList list)
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

    public sealed class TriviaList : SyntaxList, IReadOnlyList<SyntaxTrivia>
    {
        private SyntaxToken token;

        internal TriviaList(GreenNode node, SyntaxToken token, int position, int index)
            : base(node, token.Parent, position, index)
        {
            this.token = token;
        }

        internal TriviaList(InternalTriviaList node, SyntaxToken token, int position, int index)
            : base(node, token.Parent, position, index)
        {
            this.token = token;
        }

        internal TriviaList(InternalSyntaxTrivia node, SyntaxToken token, int position, int index)
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
        public TriviaList Add(SyntaxTrivia trivia)
        {
            return Insert(this.Count, trivia);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified trivia added to the end.
        /// </summary>
        /// <param name="trivia">The trivia to add.</param>
        public TriviaList AddRange(IEnumerable<SyntaxTrivia> trivia)
        {
            return InsertRange(this.Count, trivia);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified trivia inserted at the index.
        /// </summary>
        /// <param name="index">The index in the list to insert the trivia at.</param>
        /// <param name="trivia">The trivia to insert.</param>
        public TriviaList Insert(int index, SyntaxTrivia trivia)
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
        public TriviaList InsertRange(int index, IEnumerable<SyntaxTrivia> trivia)
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

            return new TriviaList(new InternalTriviaList(list.Select(n => n.GreenTrivia).ToArray(), null, null), null, 0, 0);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the element at the specified index removed.
        /// </summary>
        /// <param name="index">The index identifying the element to remove.</param>
        public TriviaList RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var list = this.ToList();
            list.RemoveAt(index);
            return new TriviaList(new InternalTriviaList(list.Select(n => n.GreenTrivia).ToArray(), null, null), null, 0, 0);
        }

        /// <summary>
        /// Creates a new <see cref="SyntaxTriviaList"/> with the specified element removed.
        /// </summary>
        /// <param name="triviaInList">The trivia element to remove.</param>
        public TriviaList Remove(SyntaxTrivia triviaInList)
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
        public TriviaList Replace(SyntaxTrivia triviaInList, SyntaxTrivia newTrivia)
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
        public TriviaList ReplaceRange(SyntaxTrivia triviaInList, IEnumerable<SyntaxTrivia> newTrivia)
        {
            var index = this.IndexOf(triviaInList);
            if (index >= 0 && index < this.Count)
            {
                var list = this.ToList();
                list.RemoveAt(index);
                list.InsertRange(index, newTrivia);
                return new TriviaList(new InternalTriviaList(list.Select(n => n.GreenTrivia).ToArray(), null, null), null, 0, 0);
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

        public bool Equals(TriviaList other)
        {
            return Green == other.Green && Index == other.Index && Token.Equals(other.Token);
        }

        public override bool Equals(object obj)
        {
            return (obj is TriviaList) && Equals((TriviaList)obj);
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

            internal Enumerator(TriviaList list)
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
            internal void InitializeFromTrailingTrivia(ref SyntaxToken token)
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

            internal bool TryMoveNextAndGetCurrent(SyntaxTrivia current)
            {
                if (!MoveNext())
                {
                    return false;
                }

                current = (SyntaxTrivia)_current.CreateRed(_token, _position, _baseIndex + _index);
                return true;
            }
        }

        private class EnumeratorImpl : IEnumerator<SyntaxTrivia>
        {
            private Enumerator _enumerator;

            // SyntaxTriviaList is a relatively big struct so is passed as ref
            internal EnumeratorImpl(TriviaList list)
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

    public sealed class NodeList<TNode> : IReadOnlyList<TNode>
        where TNode: SyntaxNode
    {
        private static readonly NodeList<TNode> Empty = new NodeList<TNode>(null);

        private readonly SyntaxNode _node;

        public NodeList(SyntaxNode node)
        {
            _node = node;
        }

        public SyntaxNode Node
        {
            get { return _node; }
        }

        public InternalNodeList Green
        {
            get
            {
                return _node?.GreenNode as InternalNodeList;
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
        public NodeList<TNode> Add(TNode node)
        {
            return this.Insert(this.Count, node);
        }

        /// <summary>
        /// Creates a new list with the specified nodes added at the end.
        /// </summary>
        /// <param name="nodes">The nodes to add.</param>
        public NodeList<TNode> AddRange(IEnumerable<TNode> nodes)
        {
            return this.InsertRange(this.Count, nodes);
        }

        /// <summary>
        /// Creates a new list with the specified node inserted at the index.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="node">The node to insert.</param>
        public NodeList<TNode> Insert(int index, TNode node)
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
        public NodeList<TNode> InsertRange(int index, IEnumerable<TNode> nodes)
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
        public NodeList<TNode> RemoveAt(int index)
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
        public NodeList<TNode> Remove(TNode node)
        {
            return CreateList(this.Green, this.Where(x => x != node).ToList());
        }

        /// <summary>
        /// Creates a new list with the specified element replaced with the new node.
        /// </summary>
        /// <param name="nodeInList">The element to replace.</param>
        /// <param name="newNode">The new node.</param>
        public NodeList<TNode> Replace(TNode nodeInList, TNode newNode)
        {
            return ReplaceRange(nodeInList, new[] { newNode });
        }

        /// <summary>
        /// Creates a new list with the specified element replaced with new nodes.
        /// </summary>
        /// <param name="nodeInList">The element to replace.</param>
        /// <param name="newNodes">The new nodes.</param>
        public NodeList<TNode> ReplaceRange(TNode nodeInList, IEnumerable<TNode> newNodes)
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

        private static NodeList<TNode> CreateList(InternalNodeList creator, List<TNode> items)
        {
            if (items.Count == 0)
            {
                return NodeList<TNode>.Empty;
            }

            InternalNodeList newGreen;
            if (creator == null)
            {
                newGreen = new InternalStrongNodeList(items.Select(n => n.GreenNode).ToArray(), null, null);
            }
            else
            {
                newGreen = creator.CreateList(items.Select(n => n.GreenNode).ToArray());
            }
            return new NodeList<TNode>((NodeList)newGreen.CreateRed());
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

            return EmptyCollections.EmptyEnumerator<TNode>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (this.Any())
            {
                return new EnumeratorImpl(this);
            }

            return EmptyCollections.EmptyEnumerator<TNode>();
        }

        public bool Equals(NodeList<TNode> other)
        {
            return _node == other._node;
        }

        public override bool Equals(object obj)
        {
            return obj is NodeList<TNode> && Equals((NodeList<TNode>)obj);
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
            private NodeList<TNode> _list;
            private int _index;

            internal Enumerator(NodeList<TNode> list)
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

            internal EnumeratorImpl(NodeList<TNode> list)
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

    public sealed class SeparatedNodeList<TNode> : IReadOnlyList<TNode>
        where TNode : SyntaxNode
    {
        private readonly SeparatedNodeList _list;
        private readonly int _count;
        private readonly int _separatorCount;

        public SeparatedNodeList(SeparatedNodeList list)
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
        private static void Validate(InternalSeparatedNodeList list)
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

        public InternalSeparatedNodeList Green
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

        public bool Equals(SeparatedNodeList<TNode> other)
        {
            return _list == other._list;
        }

        public override bool Equals(object obj)
        {
            return (obj is SeparatedNodeList<TNode>) && Equals((SeparatedNodeList<TNode>)obj);
        }

        public override int GetHashCode()
        {
            return _list.GetHashCode();
        }

        /// <summary>
        /// Creates a new list with the specified node added to the end.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public SeparatedNodeList<TNode> Add(TNode node)
        {
            return Insert(this.Count, node);
        }

        /// <summary>
        /// Creates a new list with the specified nodes added to the end.
        /// </summary>
        /// <param name="nodes">The nodes to add.</param>
        public SeparatedNodeList<TNode> AddRange(IEnumerable<TNode> nodes)
        {
            return InsertRange(this.Count, nodes);
        }

        /// <summary>
        /// Creates a new list with the specified node inserted at the index.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="node">The node to insert.</param>
        public SeparatedNodeList<TNode> Insert(int index, TNode node)
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
        public SeparatedNodeList<TNode> InsertRange(int index, IEnumerable<TNode> nodes)
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
        public SeparatedNodeList<TNode> RemoveAt(int index)
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
        public SeparatedNodeList<TNode> Remove(TNode node)
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
        public SeparatedNodeList<TNode> Replace(TNode nodeInList, TNode newNode)
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
        public SeparatedNodeList<TNode> ReplaceRange(TNode nodeInList, IEnumerable<TNode> newNodes)
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
        public SeparatedNodeList<TNode> ReplaceSeparator(SyntaxToken separatorToken, SyntaxToken newSeparator)
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

        private SeparatedNodeList<TNode> CreateList(List<RedNode> nodesWithSeps)
        {
            return new SeparatedNodeList<TNode>((SeparatedNodeList)this._list.GreenList.CreateList(nodesWithSeps.Select(n => n.Green).ToArray()).CreateRed());
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

            return EmptyCollections.EmptyEnumerator<TNode>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (this.Any())
            {
                return new EnumeratorImpl(this);
            }

            return EmptyCollections.EmptyEnumerator<TNode>();
        }

        // Public struct enumerator
        // Only implements enumerator pattern as used by foreach
        // Does not implement IEnumerator. Doing so would require the struct to implement IDisposable too.
        [SuppressMessage("Performance", "RS0008", Justification = "Equality not actually implemented")]
        public struct Enumerator
        {
            private readonly SeparatedNodeList<TNode> _list;
            private int _index;

            internal Enumerator(SeparatedNodeList<TNode> list)
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

            internal EnumeratorImpl(SeparatedNodeList<TNode> list)
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
