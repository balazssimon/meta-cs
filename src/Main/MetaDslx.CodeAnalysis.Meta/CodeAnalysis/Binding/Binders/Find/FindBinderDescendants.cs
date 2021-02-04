using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class FindBinderDescendants<T> : IBinderSearch<T>
        where T : Binder
    {
        private BinderPosition _origin;

        public FindBinderDescendants(BinderPosition origin)
        {
            _origin = origin;
        }

        public BinderPosition Origin => _origin;

        public BinderPosition<T> FindOne(bool includeSelf = false)
        {
            var results = FindAll(includeSelf);
            Debug.Assert(results.Length == 1);
            return results.Length > 0 ? results[0] : default;
        }

        public ImmutableArray<BinderPosition<T>> FindAll(bool includeSelf = false)
        {
            var results = new ArrayBuilder<BinderPosition<T>>();
            var walker = new BinderTreeWalker(_origin);
            var skipMove = includeSelf;
            while (true)
            {
                if (!skipMove && !walker.MoveToNextDescendant()) break;
                var current = walker.Binder;
                if (current is T typedBinder && IsValidBinder(typedBinder)) results.Add(new BinderPosition<T>(typedBinder, walker.LowestBinder, walker.Syntax));
                if (IsSearchBoundary(current))
                {
                    if (!walker.MoveToNextSibling()) break;
                    skipMove = true;
                }
            }
            return results.ToImmutableAndFree();
        }

        public virtual bool IsValidBinder(T binder)
        {
            return false;
        }

        public virtual bool IsSearchBoundary(Binder binder)
        {
            return false;
        }
    }
}
