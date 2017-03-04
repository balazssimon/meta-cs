using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    public abstract class BinderFactory
    {
        private readonly Compilation _compilation;
        private readonly SyntaxTree _syntaxTree;
        private readonly BuckStopsHereBinder _buckStopsHereBinder;

        // In a typing scenario, GetBinder is regularly called with a non-zero position.
        // This results in a lot of allocations of BinderFactoryVisitors. Pooling them
        // reduces this churn to almost nothing.
        private readonly ObjectPool<BinderFactoryVisitor> _binderFactoryVisitorPool;

        internal BinderFactory(CompilationBase compilation, SyntaxTree syntaxTree)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;

            _binderFactoryVisitorPool = new ObjectPool<BinderFactoryVisitor>(() => compilation.Language.CompilationFactory.CreateBinderFactoryVisitor(this), 64);

            _buckStopsHereBinder = new BuckStopsHereBinder(compilation);
        }

        public CompilationBase Compilation
        {
            get { return (CompilationBase)_compilation; }
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

        public BuckStopsHereBinder BuckStopsHereBinder
        {
            get
            {
                return _buckStopsHereBinder;
            }
        }

        /// <summary>
        /// Note, there is no guarantee that the factory always gives back the same binder instance for the same <param name="node"/>.
        /// </summary>
        public Binder GetBinder(RedNode node)
        {
            if (node == null) return null;
            int position = node.SpanStart;
            if (node is SyntaxNode)
            {
                return GetBinder((SyntaxNode)node, position, false);
            }
            else
            {
                return GetBinder(node.Parent, position, true);
            }
        }

        public Binder GetBinder(RedNode node, int position)
        {
            if (node == null) return null;
            if (node is SyntaxNode)
            {
                return this.GetBinder((SyntaxNode)node, position, true);
            }
            else
            {
                return this.GetBinder(node.Parent, position, true);
            }
        }

        private Binder GetBinder(SyntaxNode node, int position, bool forChild)
        {
            Debug.Assert(node != null);
            Binder result = null;
            BinderFactoryVisitor visitor = _binderFactoryVisitorPool.Allocate();
            try
            {
                visitor.Reset(position, forChild);
                result = node.Accept(visitor);
            }
            finally
            {
                _binderFactoryVisitorPool.Free(visitor);
            }
            return result;
        }

        public virtual bool TryGetBinder(RedNode node, object usage, out Binder binder)
        {
            binder = null;
            return false;
        }

        public virtual bool TryAddBinder(RedNode node, object usage, ref Binder binder)
        {
            return false;
        }
    }
}
