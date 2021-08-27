using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BinderCache
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
        private readonly LanguageSyntaxTree _syntaxTree;
        private readonly BuckStopsHereBinder _buckStopsHereBinder;

        protected BinderCache(LanguageCompilation compilation, LanguageSyntaxTree syntaxTree)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;

            _buckStopsHereBinder = new BuckStopsHereBinder(compilation);
        }

        public Language Language => _compilation.Language;

        public LanguageCompilation Compilation => _compilation;

        public LanguageSyntaxTree SyntaxTree => _syntaxTree;

        public bool InScript => _syntaxTree.Options.Kind == SourceCodeKind.Script;

        public BuckStopsHereBinder BuckStopsHereBinder => _buckStopsHereBinder;

        public abstract bool TryGetBinder(LanguageSyntaxNode node, object usage, out Binder binder);
        public abstract bool TryAddBinder(LanguageSyntaxNode node, object usage, ref Binder binder);


    }
}
