using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public abstract class BinderFactory
    {
        private readonly Compilation _compilation;
        private readonly SyntaxTree _syntaxTree;

        // In a typing scenario, Bind is regularly called with a non-zero position.
        // This results in a lot of allocations of BinderFactoryVisitors. Pooling them
        // reduces this churn to almost nothing.
        private readonly ObjectPool<BinderFactoryVisitor> _binderFactoryVisitorPool;
        private readonly ObjectPool<ArrayBuilder<Binder>> _binderArrayBuilderPool;

        internal BinderFactory(CompilationBase compilation, SyntaxTree syntaxTree)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;

            _binderFactoryVisitorPool = new ObjectPool<BinderFactoryVisitor>(() => compilation.Language.CompilationFactory.CreateBinderFactoryVisitor(this), 64);
            _binderArrayBuilderPool = ArrayBuilder<Binder>.CreatePool();
        }

        public CompilationBase Compilation
        {
            get { return (CompilationBase)_compilation; }
        }

        public Binder DefaultBinder
        {
            get { return this.Compilation.DefaultBinder; }
        }

        public SyntaxTree SyntaxTree
        {
            get
            {
                return _syntaxTree;
            }
        }

        public bool InScript
        {
            get
            {
                return _syntaxTree.Options.Kind == SourceCodeKind.Script;
            }
        }

        public Binder GetBinder(RedNode node)
        {
            RedNode current = node;
            while (current != null)
            {
                BoundNode boundNode = this.Bind(current);
                if (boundNode.Binders.Length> 0)
                {
                    return boundNode.Binders[boundNode.Binders.Length - 1];
                }
                current = current.Parent;
            }
            return this.Compilation.DefaultBinder;
        }

        public TBinder GetBinder<TBinder>(RedNode node)
            where TBinder: class
        {
            return this.GetBinder(node).AsBinder<TBinder>();
        }

        public BoundNode Bind(RedNode node)
        {
            if (node == null) return null;
            int position = node.SpanStart;
            if (node is SyntaxNode)
            {
                return Bind((SyntaxNode)node, position, false);
            }
            else
            {
                return Bind(node.Parent, position, true);
            }
        }

        private BoundNode Bind(SyntaxNode node, int position, bool bindToken)
        {
            Debug.Assert(node != null);
            BoundNode result = null;
            BinderFactoryVisitor visitor = _binderFactoryVisitorPool.Allocate();
            ArrayBuilder<Binder> binders = _binderArrayBuilderPool.Allocate();
            try
            {
                visitor.Reset(position, bindToken, binders);
                result = node.Accept(visitor);
            }
            finally
            {
                _binderFactoryVisitorPool.Free(visitor);
                _binderArrayBuilderPool.Free(binders);
            }
            return result;
        }

        public virtual bool TryGetBoundNode(RedNode node, out BoundNode boundNode)
        {
            boundNode = null;
            return false;
        }

        public virtual bool TryAddBoundNode(RedNode node, ref BoundNode boundNode)
        {
            return false;
        }
    }
}
