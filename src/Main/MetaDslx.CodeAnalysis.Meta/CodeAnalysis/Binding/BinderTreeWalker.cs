using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class BinderTreeWalker
    {
        private Binder _originalBinder;
        private SyntaxNodeOrToken _originalSyntax;
        private Binder _binder;
        private Binder _lowestBinder;
        private Cursor _cursor;
        private Dictionary<SyntaxNodeOrToken, Binder> _lowestBinders;

        public BinderTreeWalker(BinderPosition position)
        {
            _originalBinder = position.Binder;
            _originalSyntax = position.Syntax;
            _binder = position.Binder;
            _cursor = Cursor.FromRoot(position.Syntax);
            _lowestBinder = position.LowestBinderInSyntax;
            _lowestBinders = new Dictionary<SyntaxNodeOrToken, Binder>();
            _lowestBinders.Add(position.Syntax, position.LowestBinderInSyntax);
        }

        public bool IsAtOriginalBinder => _binder == _originalBinder;

        public bool HasParent => _binder.Next != null;

        public Binder Binder => _binder;

        public Binder LowestBinder => _lowestBinder;

        public SyntaxNodeOrToken Syntax => _cursor.CurrentNodeOrToken;

        public BinderPosition CurrentNode => new BinderPosition(_binder, _lowestBinder, _cursor.CurrentNodeOrToken);

        public bool MoveToNextAncestor()
        {
            if (_binder == null || _cursor.CurrentNodeOrToken == null) return false;
            _binder = _binder.Next;
            if (_binder != null && _cursor.CurrentNodeOrToken != _binder.Syntax)
            {
                _cursor = Cursor.FromRoot(_binder.Syntax);
                _lowestBinder = GetLowestBinder(_cursor.CurrentNodeOrToken);
            }
            return _binder != null;
        }

        public bool MoveToNextDescendant()
        {
            if (_binder == null || _cursor.CurrentNodeOrToken == null) return false;
            if (_binder != _lowestBinder)
            {
                MoveToPreviousBinder();
                return true;
            }
            while (true)
            {
                if (_cursor.CurrentNodeOrToken == null || !_originalSyntax.Span.Contains(_cursor.CurrentNodeOrToken.Span)) return false;
                if (_cursor.HasChildren) _cursor = _cursor.MoveToFirstChild();
                else _cursor = _cursor.MoveToNextSibling();
                var lowestBinder = GetLowestBinder(_cursor.CurrentNodeOrToken);
                if (lowestBinder != null && lowestBinder != _lowestBinder)
                {
                    _lowestBinder = lowestBinder;
                    MoveToPreviousBinder();
                    return true;
                }
            }
        }

        public bool MoveToNextSibling()
        {
            if (_binder == null || _cursor.CurrentNodeOrToken == null) return false;
            if (_binder != _lowestBinder)
            {
                MoveToPreviousBinder();
                return true;
            }
            var first = true;
            while (true)
            {
                if (_cursor.CurrentNodeOrToken == null || !_originalSyntax.Span.Contains(_cursor.CurrentNodeOrToken.Span)) return false;
                if (!first && _cursor.HasChildren) _cursor = _cursor.MoveToFirstChild();
                else _cursor = _cursor.MoveToNextSibling();
                var lowestBinder = GetLowestBinder(_cursor.CurrentNodeOrToken);
                if (lowestBinder != null && lowestBinder != _lowestBinder)
                {
                    _lowestBinder = lowestBinder;
                    MoveToPreviousBinder();
                    return true;
                }
                first = false;
            }
        }

        private void MoveToPreviousBinder()
        {
            Debug.Assert(_binder != _lowestBinder);
            var binder = _lowestBinder;
            while (binder != null && binder.Next != _binder) binder = binder.Next;
            _binder = binder;
        }

        private Binder GetLowestBinder(SyntaxNodeOrToken syntax)
        {
            if (syntax.NodeOrParent == null) return null;
            if (!_lowestBinders.TryGetValue(syntax, out var binder))
            {
                var parentLowestBinder = GetLowestBinder(syntax.Parent);
                if (parentLowestBinder == null) binder = _originalBinder.Compilation.GetBinder(syntax);
                else binder = parentLowestBinder.GetBinder(syntax);
                _lowestBinders.Add(syntax, binder);
            }
            return binder;
        }

        /// <summary>
        /// The cursor represents a location in the tree that we can move around to indicate where
        /// we are in the tree.  When it is at a node or token, it can either move forward to that
        /// entity's next sibling.  It can also move down to a node's first child or first token.
        /// 
        /// Once the cursor hits the end of file, it's done.
        /// </summary>
        private struct Cursor
        {
            public readonly SyntaxNodeOrToken CurrentNodeOrToken;
            private readonly int _indexInParent;

            private Cursor(SyntaxNodeOrToken node, int indexInParent)
            {
                this.CurrentNodeOrToken = node;
                _indexInParent = indexInParent;
            }

            public static Cursor FromRoot(SyntaxNodeOrToken node)
            {
                return new Cursor(node, indexInParent: 0);
            }

            public bool HasParent => CurrentNodeOrToken.Parent != null;

            public bool HasChildren => CurrentNodeOrToken.IsNode && CurrentNodeOrToken.AsNode().SlotCount > 0;

            public Cursor MoveToNextSibling()
            {
                if (this.CurrentNodeOrToken.Parent != null)
                {
                    // First, look to the nodes to the right of this one in our parent's child list
                    // to get the next sibling.
                    var siblings = this.CurrentNodeOrToken.Parent.ChildNodesAndTokens();
                    var index = _indexInParent + 1;
                    if (index < siblings.Count)
                    {
                        var sibling = siblings[index];
                        return new Cursor(sibling, index);
                    }
                    // We're at the end of this sibling chain.
                    // Walk up to the parent and see who is the next sibling of that.
                    return MoveToParent().MoveToNextSibling();
                }
                return default(Cursor);
            }

            public Cursor MoveToParent()
            {
                var parent = this.CurrentNodeOrToken.Parent;
                var index = IndexOfNodeInParent(parent);
                return new Cursor(parent, index);
            }

            private static int IndexOfNodeInParent(SyntaxNode node)
            {
                if (node.Parent == null)
                {
                    return 0;
                }
                var children = node.Parent.ChildNodesAndTokens();
                var index = SyntaxNodeOrToken.GetFirstChildIndexSpanningPosition(children, ((LanguageSyntaxNode)node).Position);
                for (int i = index, n = children.Count; i < n; i++)
                {
                    var child = children[i];
                    if (child == node)
                    {
                        return i;
                    }
                }
                throw ExceptionUtilities.Unreachable;
            }

            public Cursor MoveToFirstChild()
            {
                Debug.Assert(this.CurrentNodeOrToken.IsNode);
                // Just try to get the first node directly.  This is faster than getting the list of
                // child nodes and tokens (which forces all children to be enumerated for the sake
                // of counting.  It should always be safe to index the 0th element of a node.  But
                // just to make sure that this is not a problem, we verify that the slot count of the
                // node is greater than 0.
                var node = CurrentNodeOrToken.AsNode();
                if (node.SlotCount > 0)
                {
                    var child = ChildSyntaxList.ItemInternal(node, 0);
                    return new Cursor(child, 0);
                }
                throw ExceptionUtilities.Unreachable;
            }

        }
    }
}
