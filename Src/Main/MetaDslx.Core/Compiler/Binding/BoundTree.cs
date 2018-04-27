using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
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

        internal BoundTree(CompilationBase compilation, SyntaxTree syntaxTree)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;
            if (!compilation.SyntaxTrees.Contains(syntaxTree))
            {
                throw new ArgumentOutOfRangeException(nameof(syntaxTree), "tree not part of compilation");
            }
            _binderFactory = compilation.GetBinderFactory(syntaxTree);
            _diagnosticBag = new DiagnosticBag();
        }

        internal BoundTree(CompilationBase parentCompilation, SyntaxTree parentSyntaxTree, SyntaxTree speculatedSyntaxTree)
        {
            _compilation = parentCompilation;
            _syntaxTree = speculatedSyntaxTree;
            _binderFactory = parentCompilation.GetBinderFactory(parentSyntaxTree);
            _diagnosticBag = new DiagnosticBag();
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
                    Interlocked.CompareExchange(ref _boundRoot, _binderFactory.Bind(this.Root), null);
                }
                return _boundRoot;
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
    }
}
