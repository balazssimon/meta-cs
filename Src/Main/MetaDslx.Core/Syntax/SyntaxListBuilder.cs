using MetaDslx.Compiler.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public class NodeListBuilder<TNode>
        where TNode : SyntaxNode
    {
        private InternalSyntaxNode[] _nodes;
        public int Count { get; private set; }

        public NodeListBuilder(int size)
        {
            _nodes = new InternalSyntaxNode[size];
            this.Count = 0;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Add(TNode item)
        {
            AddInternal((InternalSyntaxNode)item.Green);
        }

        internal void AddInternal(InternalSyntaxNode item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if (_nodes == null || Count >= _nodes.Length)
            {
                this.Grow(Count == 0 ? 8 : _nodes.Length * 2);
            }

            _nodes[Count++] = item;
        }

        public void AddRange(TNode[] items)
        {
            this.AddRange(items, 0, items.Length);
        }

        public void AddRange(TNode[] items, int offset, int length)
        {
            if (_nodes == null || Count + length > _nodes.Length)
            {
                this.Grow(Count + length);
            }

            for (int i = offset, j = Count; i < offset + length; ++i, ++j)
            {
                _nodes[j] = items[i].GreenNode;
            }

            int start = Count;
            Count += length;
            Validate(start, Count);
        }

        private void Validate(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (_nodes[i] == null)
                {
                    throw new ArgumentException("Cannot add a null SyntaxNode.");
                }
            }
        }

        public void AddRange(SyntaxNodeList<TNode> list) 
        {
            this.AddRange(list, 0, list.Count);
        }

        public void AddRange(SyntaxNodeList<TNode> list, int offset, int count) 
        {
            this.AddRange(list.Green, offset, count);
        }

        private void AddRange(InternalSyntaxNodeList list, int offset, int count)
        {
            if (_nodes == null || this.Count + count > _nodes.Length)
            {
                this.Grow(Count + count);
            }

            var dst = this.Count;
            for (int i = offset, limit = offset + count; i < limit; i++)
            {
                _nodes[dst] = list[i];
                dst++;
            }

            int start = Count;
            Count += count;
            Validate(start, Count);
        }

        private void Grow(int size)
        {
            var tmp = new InternalSyntaxNode[size];
            Array.Copy(_nodes, tmp, _nodes.Length);
            _nodes = tmp;
        }

        public bool Any(int kind)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_nodes[i].RawKind == kind)
                {
                    return true;
                }
            }

            return false;
        }

        public SyntaxNodeList<TNode> ToList(bool weak = false)
        {
            return new SyntaxNodeList<TNode>(
                weak 
                ? (SyntaxNodeList)new WeakSyntaxNodeList(new InternalWeakSyntaxNodeList(this._nodes, null, null), null, 0) 
                : (SyntaxNodeList)new StrongSyntaxNodeList(new InternalStrongSyntaxNodeList(this._nodes, null, null), null, 0));
        }
    }

    public class SeparatedNodeListBuilder<TNode>
        where TNode : SyntaxNode
    {
        private GreenNode[] _items;
        private int _count;
        private bool _expectedSeparator;

        public SeparatedNodeListBuilder(int size)
        {
            _items = new GreenNode[size];
            _count = 0;
            _expectedSeparator = false;
        }

        public SeparatedNodeListBuilder(SeparatedSyntaxNodeList list)
        {
            _items = list.GreenList.ToArray();
            _count = _items.Length;
            _expectedSeparator = ((_count & 1) != 0);
        }

        public int Count
        {
            get { return (this._count + 1) >> 1; }
        }

        public int SeparatorCount
        {
            get { return this._count >> 1; }
        }

        public void Clear()
        {
            _count = 0;
            _expectedSeparator = false;
        }

        private void CheckExpectedElement()
        {
            if (_expectedSeparator)
            {
                throw new InvalidOperationException("Separator token is expected.");
            }
        }

        private void CheckExpectedSeparator()
        {
            if (!_expectedSeparator)
            {
                throw new InvalidOperationException("Syntax node is expected.");
            }
        }

        private void AddInternal(GreenNode item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if (_items == null || _count >= _items.Length)
            {
                this.Grow(_count == 0 ? 8 : _items.Length * 2);
            }

            _items[_count++] = item;
        }

        public void Add(TNode node)
        {
            CheckExpectedElement();
            _expectedSeparator = true;
            this.AddInternal(node.Green);
        }

        public void AddSeparator(SyntaxToken separatorToken)
        {
            CheckExpectedSeparator();
            _expectedSeparator = false;
            this.AddInternal(separatorToken.Green);
        }

        public void AddRange(SeparatedSyntaxNodeList<TNode> nodes)
        {
            CheckExpectedElement();
            var list = nodes.Green.Children;
            this.AddRange(list, 0, list.Length);
            _expectedSeparator = ((_count & 1) != 0);
        }

        public void AddRange(SeparatedSyntaxNodeList<TNode> nodes, int count)
        {
            CheckExpectedElement();
            var list = nodes.Green.Children;
            this.AddRange(list, 0, Math.Min(count << 1, list.Length));
            _expectedSeparator = ((_count & 1) != 0);
        }

        private void AddRange(GreenNode[] list, int offset, int count)
        {
            if (_items == null || this.Count + count > _items.Length)
            {
                this.Grow(Count + count);
            }

            var dst = this.Count;
            for (int i = offset, limit = offset + count; i < limit; i++)
            {
                _items[dst] = list[i];
                dst++;
            }

            int start = _count;
            _count += count;
            Validate(start, _count);
        }

        private void Grow(int size)
        {
            var tmp = new GreenNode[size];
            Array.Copy(_items, tmp, _items.Length);
            _items = tmp;
        }

        private void Validate(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (_items[i] == null)
                {
                    throw new ArgumentException("Cannot add a null SyntaxNode.");
                }
            }
        }

        public bool Any(int kind)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].RawKind == kind)
                {
                    return true;
                }
            }

            return false;
        }

        public SeparatedSyntaxNodeList<TNode> ToList(bool weak = false)
        {
            return new SeparatedSyntaxNodeList<TNode>(
                weak
                ? (SeparatedSyntaxNodeList)new WeakSeparatedSyntaxNodeList(new InternalWeakSeparatedSyntaxNodeList(this._items, null, null), null, 0, 0)
                : (SeparatedSyntaxNodeList)new StrongSeparatedSyntaxNodeList(new InternalStrongSeparatedSyntaxNodeList(this._items, null, null), null, 0, 0));
        }
    }

    public class TokenListBuilder
    {
        private InternalSyntaxToken[] tokens;
        public int Count { get; private set; }

        public TokenListBuilder(int size)
        {
            tokens = new InternalSyntaxToken[size];
            this.Count = 0;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Add(SyntaxToken item)
        {
            AddInternal(item.GreenToken);
        }

        internal void AddInternal(InternalSyntaxToken item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if (tokens == null || Count >= tokens.Length)
            {
                this.Grow(Count == 0 ? 8 : tokens.Length * 2);
            }

            tokens[Count++] = item;
        }

        public void AddRange(SyntaxToken[] items)
        {
            this.AddRange(items, 0, items.Length);
        }

        public void AddRange(SyntaxToken[] items, int offset, int length)
        {
            if (tokens == null || Count + length > tokens.Length)
            {
                this.Grow(Count + length);
            }

            for (int i = offset, j = Count; i < offset + length; ++i, ++j)
            {
                tokens[j] = items[i].GreenToken;
            }

            int start = Count;
            Count += length;
            Validate(start, Count);
        }

        private void Validate(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (tokens[i] == null)
                {
                    throw new ArgumentException("Cannot add a null SyntaxNode.");
                }
            }
        }

        public void AddRange(SyntaxTokenList list)
        {
            this.AddRange(list, 0, list.Count);
        }

        public void AddRange(SyntaxTokenList list, int offset, int count)
        {
            if (list.IsList) this.AddRange((InternalSyntaxTokenList)list.Green, offset, count);
            else if (offset == 0 && count > 0) this.AddInternal((InternalSyntaxToken)list.Green);
        }

        private void AddRange(InternalSyntaxTokenList list)
        {
            this.AddRange(list, 0, list.Count);
        }

        private void AddRange(InternalSyntaxTokenList list, int offset, int count)
        {
            if (tokens == null || this.Count + count > tokens.Length)
            {
                this.Grow(Count + count);
            }

            var dst = this.Count;
            for (int i = offset, limit = offset + count; i < limit; i++)
            {
                tokens[dst] = list[i];
                dst++;
            }

            int start = Count;
            Count += count;
            Validate(start, Count);
        }

        private void Grow(int size)
        {
            var tmp = new InternalSyntaxToken[size];
            Array.Copy(tokens, tmp, tokens.Length);
            tokens = tmp;
        }

        public bool Any(int kind)
        {
            for (int i = 0; i < Count; i++)
            {
                if (tokens[i].RawKind == kind)
                {
                    return true;
                }
            }

            return false;
        }

        public SyntaxTokenList ToList()
        {
            switch (this.tokens.Length)
            {
                case 0:
                    return null;
                case 1:
                    return new SyntaxTokenList(this.tokens[0], null, 0, 0);
                default:
                    return new SyntaxTokenList(new InternalSyntaxTokenList(this.tokens, null, null), null, 0, 0);
            }
        }
    }

    public class TriviaListBuilder
    {
        private InternalSyntaxTrivia[] trivia;
        public int Count { get; private set; }

        public TriviaListBuilder(int size)
        {
            trivia = new InternalSyntaxTrivia[size];
            this.Count = 0;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Add(SyntaxTrivia item)
        {
            AddInternal(item.GreenTrivia);
        }

        internal void AddInternal(InternalSyntaxTrivia item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if (trivia == null || Count >= trivia.Length)
            {
                this.Grow(Count == 0 ? 8 : trivia.Length * 2);
            }

            trivia[Count++] = item;
        }

        public void AddRange(SyntaxTrivia[] items)
        {
            this.AddRange(items, 0, items.Length);
        }

        public void AddRange(SyntaxTrivia[] items, int offset, int length)
        {
            if (trivia == null || Count + length > trivia.Length)
            {
                this.Grow(Count + length);
            }

            for (int i = offset, j = Count; i < offset + length; ++i, ++j)
            {
                trivia[j] = items[i].GreenTrivia;
            }

            int start = Count;
            Count += length;
            Validate(start, Count);
        }

        private void Validate(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (trivia[i] == null)
                {
                    throw new ArgumentException("Cannot add a null SyntaxTrivia.");
                }
            }
        }

        public void AddRange(SyntaxTriviaList list)
        {
            this.AddRange(list, 0, list.Count);
        }

        public void AddRange(SyntaxTriviaList list, int offset, int count)
        {
            if (list.IsList) this.AddRange((InternalSyntaxTriviaList)list.Green, offset, count);
            else if (offset == 0 && count > 0) this.AddInternal((InternalSyntaxTrivia)list.Green);
        }

        private void AddRange(InternalSyntaxTriviaList list)
        {
            this.AddRange(list, 0, list.Count);
        }

        private void AddRange(InternalSyntaxTriviaList list, int offset, int count)
        {
            if (trivia == null || this.Count + count > trivia.Length)
            {
                this.Grow(Count + count);
            }

            var dst = this.Count;
            for (int i = offset, limit = offset + count; i < limit; i++)
            {
                trivia[dst] = list[i];
                dst++;
            }

            int start = Count;
            Count += count;
            Validate(start, Count);
        }

        private void Grow(int size)
        {
            var tmp = new InternalSyntaxTrivia[size];
            Array.Copy(trivia, tmp, trivia.Length);
            trivia = tmp;
        }

        public bool Any(int kind)
        {
            for (int i = 0; i < Count; i++)
            {
                if (trivia[i].RawKind == kind)
                {
                    return true;
                }
            }

            return false;
        }

        public SyntaxTriviaList ToList()
        {
            switch (this.trivia.Length)
            {
                case 0:
                    return null;
                case 1:
                    return new SyntaxTriviaList(this.trivia[0], null, 0, 0);
                default:
                    return new SyntaxTriviaList(new InternalSyntaxTriviaList(this.trivia, null, null), null, 0, 0);
            }
        }
    }

}
