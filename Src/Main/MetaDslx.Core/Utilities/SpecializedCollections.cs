using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Utilities
{
    public static class SpecializedCollections
    {
        public static IEnumerable<T> SingletonEnumerable<T>(T value)
        {
            return new Singleton.Collection<T>(value);
        }

        public static ICollection<T> SingletonCollection<T>(T value)
        {
            return new Singleton.Collection<T>(value);
        }

        public static IEnumerator<T> SingletonEnumerator<T>(T value)
        {
            return new Singleton.Enumerator<T>(value);
        }

        public static IEnumerable<T> ReadOnlyEnumerable<T>(IEnumerable<T> values)
        {
            return new ReadOnly.Enumerable<IEnumerable<T>, T>(values);
        }

        public static ICollection<T> ReadOnlyCollection<T>(ICollection<T> collection)
        {
            return collection == null || collection.Count == 0
                ? EmptyCollections.Collection<T>()
                : new ReadOnly.Collection<ICollection<T>, T>(collection);
        }

        public static ISet<T> ReadOnlySet<T>(ISet<T> set)
        {
            return set == null || set.Count == 0
                ? EmptyCollections.Set<T>()
                : new ReadOnly.Set<ISet<T>, T>(set);
        }

        public static ISet<T> ReadOnlySet<T>(IEnumerable<T> values)
        {
            var set = values as ISet<T>;
            if (set != null)
            {
                return ReadOnlySet(set);
            }

            HashSet<T> result = null;
            foreach (var item in values)
            {
                result = result ?? new HashSet<T>();
                result.Add(item);
            }

            return ReadOnlySet(result);
        }

        private static partial class ReadOnly
        {
            internal class Enumerable<TUnderlying> : IEnumerable
                where TUnderlying : IEnumerable
            {
                protected readonly TUnderlying Underlying;

                public Enumerable(TUnderlying underlying)
                {
                    this.Underlying = underlying;
                }

                public IEnumerator GetEnumerator()
                {
                    return this.Underlying.GetEnumerator();
                }
            }

            internal class Enumerable<TUnderlying, T> : Enumerable<TUnderlying>, IEnumerable<T>
    where TUnderlying : IEnumerable<T>
            {
                public Enumerable(TUnderlying underlying)
                    : base(underlying)
                {
                }

                public new IEnumerator<T> GetEnumerator()
                {
                    return this.Underlying.GetEnumerator();
                }
            }

            internal class Collection<TUnderlying, T> : Enumerable<TUnderlying, T>, ICollection<T>
                where TUnderlying : ICollection<T>
            {
                public Collection(TUnderlying underlying)
                    : base(underlying)
                {
                }

                public void Add(T item)
                {
                    throw new NotSupportedException();
                }

                public void Clear()
                {
                    throw new NotSupportedException();
                }

                public bool Contains(T item)
                {
                    return this.Underlying.Contains(item);
                }

                public void CopyTo(T[] array, int arrayIndex)
                {
                    this.Underlying.CopyTo(array, arrayIndex);
                }

                public int Count
                {
                    get
                    {
                        return this.Underlying.Count;
                    }
                }

                public bool IsReadOnly
                {
                    get
                    {
                        return true;
                    }
                }

                public bool Remove(T item)
                {
                    throw new NotSupportedException();
                }
            }

            internal class Set<TUnderlying, T> : Collection<TUnderlying, T>, ISet<T>
    where TUnderlying : ISet<T>
            {
                public Set(TUnderlying underlying)
                    : base(underlying)
                {
                }

                public new bool Add(T item)
                {
                    throw new NotSupportedException();
                }

                public void ExceptWith(IEnumerable<T> other)
                {
                    throw new NotSupportedException();
                }

                public void IntersectWith(IEnumerable<T> other)
                {
                    throw new NotSupportedException();
                }

                public bool IsProperSubsetOf(IEnumerable<T> other)
                {
                    return Underlying.IsProperSubsetOf(other);
                }

                public bool IsProperSupersetOf(IEnumerable<T> other)
                {
                    return Underlying.IsProperSupersetOf(other);
                }

                public bool IsSubsetOf(IEnumerable<T> other)
                {
                    return Underlying.IsSubsetOf(other);
                }

                public bool IsSupersetOf(IEnumerable<T> other)
                {
                    return Underlying.IsSupersetOf(other);
                }

                public bool Overlaps(IEnumerable<T> other)
                {
                    return Underlying.Overlaps(other);
                }

                public bool SetEquals(IEnumerable<T> other)
                {
                    return Underlying.SetEquals(other);
                }

                public void SymmetricExceptWith(IEnumerable<T> other)
                {
                    throw new NotSupportedException();
                }

                public void UnionWith(IEnumerable<T> other)
                {
                    throw new NotSupportedException();
                }
            }

        }


        private static partial class Singleton
        {
            internal sealed class Collection<T> : ICollection<T>, IReadOnlyCollection<T>
            {
                private readonly T _loneValue;

                public Collection(T value)
                {
                    _loneValue = value;
                }

                public void Add(T item)
                {
                    throw new NotSupportedException();
                }

                public void Clear()
                {
                    throw new NotSupportedException();
                }

                public bool Contains(T item)
                {
                    return EqualityComparer<T>.Default.Equals(_loneValue, item);
                }

                public void CopyTo(T[] array, int arrayIndex)
                {
                    array[arrayIndex] = _loneValue;
                }

                public int Count
                {
                    get { return 1; }
                }

                public bool IsReadOnly
                {
                    get { return true; }
                }

                public bool Remove(T item)
                {
                    throw new NotSupportedException();
                }

                public IEnumerator<T> GetEnumerator()
                {
                    return new Enumerator<T>(_loneValue);
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }

            internal class Enumerator<T> : IEnumerator<T>
            {
                private readonly T _loneValue;
                private bool _moveNextCalled;

                public Enumerator(T value)
                {
                    _loneValue = value;
                    _moveNextCalled = false;
                }

                public T Current
                {
                    get
                    {
                        return _loneValue;
                    }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        return _loneValue;
                    }
                }

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    if (!_moveNextCalled)
                    {
                        _moveNextCalled = true;
                        return true;
                    }

                    return false;
                }

                public void Reset()
                {
                    _moveNextCalled = false;
                }
            }

        }
    }
}
