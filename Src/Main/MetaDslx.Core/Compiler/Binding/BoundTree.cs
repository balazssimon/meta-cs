using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler.Binding
{
    public class BoundTree
    {
        private readonly CompilationBase _compilation;
        private readonly SyntaxTree _syntaxTree;
        private readonly BinderFactory _binderFactory;
        private readonly DiagnosticBag _diagnosticBag;
        private BoundNode _boundRoot;

        private ConditionalWeakTable<RedNode, BoundNode> _boundNodeMap;

        private readonly ObjectPool<BoundNodeFactoryVisitor> _boundNodeFactoryVisitorPool;

        internal BoundTree(CompilationBase compilation, SyntaxTree syntaxTree)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;
            if (!compilation.SyntaxTrees.Contains(syntaxTree))
            {
                throw new ArgumentOutOfRangeException(nameof(syntaxTree), "tree not part of compilation");
            }
            _binderFactory = _compilation.GetBinderFactory(syntaxTree);
            _boundNodeFactoryVisitorPool = new ObjectPool<BoundNodeFactoryVisitor>(() => compilation.Language.CompilationFactory.CreateBoundNodeFactoryVisitor(this), 64);
            _diagnosticBag = new DiagnosticBag();
            _boundNodeMap = new ConditionalWeakTable<RedNode, BoundNode>();
        }

        internal BoundTree(CompilationBase parentCompilation, SyntaxTree parentSyntaxTree, SyntaxTree speculatedSyntaxTree)
        {
            _compilation = parentCompilation;
            _syntaxTree = speculatedSyntaxTree;
            _binderFactory = _compilation.GetBinderFactory(parentSyntaxTree);
            _boundNodeFactoryVisitorPool = new ObjectPool<BoundNodeFactoryVisitor>(() => _compilation.Language.CompilationFactory.CreateBoundNodeFactoryVisitor(this), 64);
            _diagnosticBag = new DiagnosticBag();
            _boundNodeMap = new ConditionalWeakTable<RedNode, BoundNode>();
        }

        /// <summary>
        /// Gets the source language ("C#" or "Visual Basic").
        /// </summary>
        public virtual Language Language
        {
            get { return this.Compilation.Language; }
        }

        /// <summary>
        /// The root node of the syntax tree that this binding is based on.
        /// </summary>
        public SyntaxNode Root
        {
            get { return _syntaxTree.GetRoot(); }
        }

        public BoundNode BoundRoot
        {
            get
            {
                if (_boundRoot == null)
                {
                    Interlocked.CompareExchange(ref _boundRoot, this.GetBoundNode(this.Root), null);
                }
                return _boundRoot;
            }
        }

        public BoundNode GetBoundNode(RedNode node)
        {
            BoundNode result = _boundNodeMap.GetValue(node, n => this.Bind(n));
            return result;
        }

        private BoundNode Bind(RedNode node)
        {
            int position = node.SpanStart;
            var syntaxNode = node as SyntaxNode;
            if (syntaxNode != null)
            {
                return this.Bind(syntaxNode, position, false);
            }
            else
            {
                return this.Bind(node.Parent, position, true);
            }
        }

        private BoundNode Bind(SyntaxNode node, int position, bool bindChild)
        {
            Debug.Assert(node != null);
            BoundNodeFactoryVisitor visitor = _boundNodeFactoryVisitorPool.Allocate();
            try
            {
                visitor.Reset(position, bindChild);
                return node.Accept(visitor);
            }
            finally
            {
                _boundNodeFactoryVisitorPool.Free(visitor);
            }
        }

        /// <summary>
        /// The compilation this model was obtained from.
        /// </summary>
        public CompilationBase Compilation
        {
            get { return _compilation; }
        }

        /// <summary>
        /// The syntax tree this model was obtained from.
        /// </summary>
        public SyntaxTree SyntaxTree
        {
            get { return _syntaxTree; }
        }

        public BinderFactory BinderFactory
        {
            get { return _binderFactory; }
        }

        public DiagnosticBag DiagnosticBag
        {
            get { return _diagnosticBag; }
        }

        internal void Complete(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cancellationToken.IsCancellationRequested) return;
            foreach (var node in _syntaxTree.GetRoot().DescendantNodesAndTokensAndSelf())
            {
                if (cancellationToken.IsCancellationRequested) return;
                this.GetBoundNode(node);
            }
        }
    }
}
