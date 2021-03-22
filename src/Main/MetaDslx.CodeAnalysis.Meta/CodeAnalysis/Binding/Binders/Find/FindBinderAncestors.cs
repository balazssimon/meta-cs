using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class FindBinderAncestors<T> : IBinderSearch<T>
        where T : Binder
    {
        private BinderPosition _origin;
        private ArrayBuilder<BinderPosition<T>> _results;

        public FindBinderAncestors(BinderPosition origin)
        {
            _origin = origin;
        }

        public BinderPosition Origin => _origin;

        protected ArrayBuilder<BinderPosition<T>> Results => _results;

        public BinderPosition<T> FindOne(bool includeSelf = false)
        {
            var results = FindAll(includeSelf);
            Debug.Assert(results.Length == 1);
            return results.Length > 0 ? results[0] : default;
        }

        public ImmutableArray<BinderPosition<T>> FindAll(bool includeSelf = false)
        {
            _results = new ArrayBuilder<BinderPosition<T>>();
            var walker = new BinderTreeWalker(_origin);
            var skipMove = includeSelf;
            while (true)
            {
                if (!skipMove)
                {
                    if (!walker.MoveToNextAncestor()) break;
                }
                else
                {
                    skipMove = false;
                }
                if (!walker.Syntax.Span.Contains(_origin.Syntax.Span)) break;
                var current = walker.Binder;
                if (current is T typedBinder && IsValidBinder(typedBinder)) _results.Add(new BinderPosition<T>(typedBinder, walker.LowestBinder, walker.Syntax));
                if (IsSearchBoundary(current)) break;
            }
            return _results.ToImmutableAndFree();
        }

        public abstract bool IsValidBinder(T binder);

        public abstract bool IsSearchBoundary(Binder binder);
    }
}
