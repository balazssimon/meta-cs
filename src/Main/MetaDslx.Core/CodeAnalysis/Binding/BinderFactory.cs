using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BinderFactory
    {
        // key in the binder cache.
        // PERF: we are not using ValueTuple because its Equals is relatively slow.
        protected struct BinderCacheKey : IEquatable<BinderCacheKey>
        {
            private static object GeneralUsage = new object();

            public readonly LanguageSyntaxNode syntaxNode;
            public readonly object usage;

            public BinderCacheKey(LanguageSyntaxNode syntaxNode, object usage)
            {
                this.syntaxNode = syntaxNode;
                this.usage = usage ?? GeneralUsage;
            }

            bool IEquatable<BinderCacheKey>.Equals(BinderCacheKey other)
            {
                return syntaxNode == other.syntaxNode && this.usage == other.usage;
            }

            public override int GetHashCode()
            {
                return Hash.Combine(syntaxNode.GetHashCode(), usage.GetHashCode());
            }

            public override bool Equals(object obj)
            {
                throw new NotSupportedException();
            }
        }

        private readonly LanguageCompilation _compilation;
        private readonly SyntaxTree _syntaxTree;
        private readonly BuckStopsHereBinder _buckStopsHereBinder;

        // In a typing scenario, GetBinder is regularly called with a non-zero position.
        // This results in a lot of allocations of BinderFactoryVisitors. Pooling them
        // reduces this churn to almost nothing.
        private readonly ObjectPool<BinderFactoryVisitor> _binderFactoryVisitorPool;

        protected BinderFactory(LanguageCompilation compilation, SyntaxTree syntaxTree)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;

            _binderFactoryVisitorPool = new ObjectPool<BinderFactoryVisitor>(() => Language.CompilationFactory.CreateBinderFactoryVisitor(this), 64);

            _buckStopsHereBinder = new BuckStopsHereBinder(compilation);
        }

        public Language Language => _compilation.Language;

        public LanguageCompilation Compilation => _compilation;

        public SyntaxTree SyntaxTree => _syntaxTree;

        public bool InScript => _syntaxTree.Options.Kind == SourceCodeKind.Script;

        public BuckStopsHereBinder BuckStopsHereBinder => _buckStopsHereBinder;

        /// <summary>
        /// Return binder for binding at node.
        /// <paramref name="memberDeclarationOpt"/> and <paramref name="memberOpt"/>
        /// are optional syntax and symbol for the member containing <paramref name="node"/>.
        /// If provided, the <see cref="BinderFactoryVisitor"/> will use the member symbol rather
        /// than looking up the member in the containing type, allowing this method to be called
        /// while calculating the member list.
        /// </summary>
        /// <remarks>
        /// Note, there is no guarantee that the factory always gives back the same binder instance for the same node.
        /// </remarks>
        public Binder GetBinder(SyntaxNode node, LanguageSyntaxNode memberDeclarationOpt = null, Symbol memberOpt = null)
        {
            int position = node.SpanStart;

            // Unless this is interactive retrieving a binder for global statements
            // at the very top-level (i.e. in a completely empty file) use
            // node.Parent to maintain existing behavior.
            if ((!InScript || node.GetKind() != Language.SyntaxFacts.CompilationUnitKind) && node.Parent != null)
            {
                node = node.Parent;
            }

            return GetBinder(node, position, memberDeclarationOpt, memberOpt);
        }

        public Binder GetBinder(SyntaxNode node, int position, LanguageSyntaxNode memberDeclarationOpt = null, Symbol memberOpt = null)
        {
            Debug.Assert(node != null);

            BinderFactoryVisitor visitor = _binderFactoryVisitorPool.Allocate();
            visitor.Initialize(position, memberDeclarationOpt, memberOpt);
            Binder result = visitor.Visit(node);
            _binderFactoryVisitorPool.Free(visitor);

            return result;
        }

        /// <summary>
        /// Returns binder that binds usings and aliases 
        /// </summary>
        /// <param name="unit">
        /// Specify <see cref="NamespaceDeclarationSyntax"/> imports in the corresponding namespace, or
        /// <see cref="CompilationUnitSyntax"/> for top-level imports.
        /// </param>
        /// <param name="inUsing">True if the binder will be used to bind a using directive.</param>
        public virtual Binder GetImportsBinder(LanguageSyntaxNode unit, bool inUsing = false)
        {
            BinderFactoryVisitor visitor = _binderFactoryVisitorPool.Allocate();
            visitor.Initialize(0, null, null);
            Binder result = visitor.GetImportsBinder(unit, inUsing: inUsing);
            _binderFactoryVisitorPool.Free(visitor);
            return result;
        }

        public abstract bool TryGetBinder(LanguageSyntaxNode node, object usage, out Binder binder);
        public abstract bool TryAddBinder(LanguageSyntaxNode node, object usage, ref Binder binder);


    }
}
