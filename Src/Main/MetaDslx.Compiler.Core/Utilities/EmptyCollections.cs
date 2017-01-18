using MetaDslx.Compiler.Syntax.InternalSyntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Utilities
{
    public static class EmptyCollections
    {
        public static readonly byte[] ByteArray = new byte[0];
        public static readonly object[] ObjectArray = new object[0];
        public static readonly GreenNode[] GreenArray = new GreenNode[0];

        public static IEnumerator Enumerator() => EmptyCollections.Empty.Enumerator.Instance;
        public static IEnumerator<T> Enumerator<T>() => EmptyCollections.Empty.Enumerator<T>.Instance;

        public static IEnumerable<T> Enumerable<T>()
        {
            return Empty.Collection<T>.Instance;
        }

        public static IReadOnlyList<T> ReadOnlyList<T>()
        {
            return Empty.List<T>.Instance;
        }

        public static IList<T> List<T>()
        {
            return Empty.List<T>.Instance;
        }

        private static class Empty
        {
            public class Enumerator : IEnumerator
            {
                public static readonly IEnumerator Instance = new Enumerator();

                protected Enumerator()
                {
                }

                public object Current
                {
                    get
                    {
                        throw new InvalidOperationException();
                    }
                }

                public bool MoveNext()
                {
                    return false;
                }

                public void Reset()
                {
                    throw new InvalidOperationException();
                }
            }

            public class Enumerator<T> : Enumerator, IEnumerator<T>
            {
                public static new readonly IEnumerator<T> Instance = new Enumerator<T>();

                protected Enumerator()
                {
                }

                public new T Current
                {
                    get
                    {
                        throw new InvalidOperationException();
                    }
                }

                public void Dispose()
                {
                }
            }

            public class Enumerable<T> : IEnumerable<T>
            {
                // PERF: cache the instance of enumerator. 
                // accessing a generic static field is kinda slow from here,
                // but since empty enumerables are singletons, there is no harm in having 
                // one extra instance field
                private readonly IEnumerator<T> _enumerator = Enumerator<T>.Instance;

                public IEnumerator<T> GetEnumerator()
                {
                    return _enumerator;
                }

                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }

            public class Collection<T> : Enumerable<T>, ICollection<T>
            {
                public static readonly ICollection<T> Instance = new Collection<T>();

                protected Collection()
                {
                }

                public void Add(T item)
                {
                    throw new NotSupportedException();
                }

                public void Clear()
                {
                }

                public bool Contains(T item)
                {
                    return false;
                }

                public void CopyTo(T[] array, int arrayIndex)
                {
                }

                public int Count
                {
                    get
                    {
                        return 0;
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

            public class List<T> : Collection<T>, IList<T>, IReadOnlyList<T>
            {
                public static readonly new List<T> Instance = new List<T>();

                protected List()
                {
                }

                public int IndexOf(T item)
                {
                    return -1;
                }

                public void Insert(int index, T item)
                {
                    throw new NotSupportedException();
                }

                public void RemoveAt(int index)
                {
                    throw new NotSupportedException();
                }

                public T this[int index]
                {
                    get
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
                    }

                    set
                    {
                        throw new NotSupportedException();
                    }
                }
            }
        }
    }
}
