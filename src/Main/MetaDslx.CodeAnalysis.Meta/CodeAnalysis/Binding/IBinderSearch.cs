using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public interface IBinderSearch<T>
        where T : Binder
    {
        BinderPosition Origin { get; }
        BinderPosition<T> FindOne(bool includeSelf = false);
        ImmutableArray<BinderPosition<T>> FindAll(bool includeSelf = false);
        bool IsValidBinder(T binder);
        bool IsSearchBoundary(Binder binder);
    }
}
