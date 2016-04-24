using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    // GREEN:

    internal class GreenList : IReadOnlyList<object>
    {
        private static readonly List<object> emptyList = new List<object>();
        private GreenSymbol parent;
        private ModelProperty property;
        private List<object> items;
        private List<object> lazyItems;

        internal GreenList(GreenSymbol parent, ModelProperty property)
        {
            this.parent = parent;
            this.property = property;
            this.items = new List<object>();
        }

        internal GreenList(GreenList other)
        {
            this.parent = other.parent;
            this.property = other.property;
            this.items = new List<object>(other.items);
        }

        internal GreenSymbol Parent { get { return this.parent; } }
        internal ModelProperty Property { get { return this.property; } }

        public int Count { get { return this.items.Count; } }
        public object this[int index] { get { return this.items[index]; } }

        internal bool HasLazyItems { get { return this.lazyItems != null && this.lazyItems.Count > 0; } }
        internal IReadOnlyList<object> LazyItems { get { return this.lazyItems ?? GreenList.emptyList; } }

        public IEnumerator<object> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal bool Add(object item)
        {
            Debug.Assert(!(item is GreenLazyValue || item is GreenLazyList));
            if (this.property.IsNonUnique || !this.items.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            return false;
        }

        internal bool Remove(object item)
        {
            return this.items.Remove(item);
        }

        internal bool Contains(object item)
        {
            return this.items.Contains(item);
        }

        internal bool Insert(int index, object item)
        {
            Debug.Assert(!(item is GreenLazyValue || item is GreenLazyList));
            if (this.property.IsNonUnique || !this.items.Contains(item))
            {
                this.items.Insert(index, item);
                return true;
            }
            return false;
        }

        internal bool RemoveAt(int index, object item)
        {
            if (this.items[index] == item)
            {
                this.items.RemoveAt(index);
                return true;
            }
            return false;
        }

        internal bool RemoveAll(object item)
        {
            return this.items.RemoveAll(i => i == item) > 0;
        }

        internal void AddLazy(object item)
        {
            Debug.Assert(item is GreenLazyValue || item is GreenLazyList);
            Interlocked.CompareExchange(ref this.lazyItems, new List<object>(), null);
            this.lazyItems.Add(item);
        }
    }

    // RED:

    // thread-safe
    public sealed class ImmutableRedList : IReadOnlyList<object>
    {
        private GreenList green;
        private ImmutableRedModel model;
        private List<object> cachedItems = null;

        internal ImmutableRedList(GreenList green, ImmutableRedModel model)
        {
            this.green = green;
            this.model = model;
        }

        internal GreenList Green { get { return this.green; } }
        public ModelProperty Property { get { return this.green.Property; } }
        public ImmutableRedModel Model { get { return this.model; } }

        public object this[int index]
        {
            get
            {
                this.CacheItems();
                return this.cachedItems[index];
            }
        }

        public int Count
        {
            get
            {
                this.CacheItems();
                return this.cachedItems.Count;
            }
        }

        public bool Contains(object item)
        {
            this.CacheItems();
            return this.cachedItems.Contains(item);
        }

        public IEnumerator<object> GetEnumerator()
        {
            this.CacheItems();
            return this.cachedItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal void CacheItems()
        {
            if (this.cachedItems != null) return;
            this.model.CreateListItems(this, ref this.cachedItems);
        }
    }

    public sealed class ImmutableRedList<T> : ImmutableModelList<T>
    {
        private ImmutableRedList wrapped;

        internal ImmutableRedList(ImmutableRedList wrapped)
        {
            this.wrapped = wrapped;
        }

        public T this[int index]
        {
            get
            {
                return (T)this.wrapped[index];
            }
        }

        public int Count
        {
            get
            {
                return this.wrapped.Count;
            }
        }

        public bool Contains(T item)
        {
            return this.wrapped.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.wrapped)
            {
                yield return (T)item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    // NOT thread-safe
    public sealed class MutableRedList : IList<object>
    {
        private GreenList green;
        private ModelProperty property;
        private MutableRedModel model;
        private List<object> cachedItems = null;

        internal MutableRedList(GreenList green, ModelProperty property, MutableRedModel model)
        {
            this.green = green;
            this.property = property;
            this.model = model;
        }

        internal GreenList Green { get { return this.green; } }
        public ModelProperty Property { get { return this.property; } }
        public MutableRedModel Model { get { return this.model; } }

        internal void SetGreen(GreenList green)
        {
            Interlocked.Exchange(ref this.green, green);
            this.Invalidate();
        }

        internal void Invalidate()
        {
            Interlocked.Exchange(ref this.cachedItems, null);
        }

        public void Add(object value)
        {
            this.model.AddListItem(this, value);
        }

        public void LazyAdd(Func<object> lazy)
        {
            this.model.AddListItem(this, new GreenLazyValue(lazy));
        }

        public void LazyAddRange(Func<IEnumerable<object>> lazy)
        {
            this.model.AddListItem(this, new GreenLazyList(lazy));
        }

        public bool Remove(object value)
        {
            return this.model.RemoveListItem(this, value);
        }

        public object this[int index]
        {
            get
            {
                this.CacheItems();
                return this.cachedItems[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public int Count
        {
            get
            {
                this.CacheItems();
                return this.cachedItems.Count;
            }
        }

        public bool IsReadOnly { get { return false; } }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(object item)
        {
            this.CacheItems();
            return this.cachedItems.Contains(item);
        }

        public int IndexOf(object item)
        {
            this.CacheItems();
            return this.cachedItems.IndexOf(item);
        }

        public void Insert(int index, object item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public IEnumerator<object> GetEnumerator()
        {
            this.CacheItems();
            return this.cachedItems.GetEnumerator();
        }

        internal void CacheItems()
        {
            if (this.cachedItems != null) return;
            this.model.CreateListItems(this, ref this.cachedItems);
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public sealed class MutableRedValueList<T> : ModelList<T>
    {
        private MutableRedList wrapped;

        internal MutableRedValueList(MutableRedList wrapped)
        {
            this.wrapped = wrapped;
        }

        internal MutableRedList Wrapped { get { return this.wrapped; } }

        public T this[int index]
        {
            get
            {
                return (T)this.wrapped[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public int Count { get { return this.wrapped.Count; } }

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            this.wrapped.Add(item);
        }

        public void LazyAdd(Func<T> lazy)
        {
            this.wrapped.LazyAdd(() => lazy());
        }

        public void LazyAddRange(Func<IEnumerable<T>> lazy)
        {
            this.wrapped.LazyAddRange(() => (IEnumerable<object>)lazy());
        }

        public void LazyAddRange(IEnumerable<Func<T>> lazy)
        {
            this.wrapped.LazyAddRange(() => lazy.Select(f => (object)f()));
        }

        public void Clear()
        {
            this.wrapped.Clear();
        }

        public bool Contains(T item)
        {
            return this.wrapped.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.wrapped)
            {
                yield return (T)item;
            }
        }

        public int IndexOf(T item)
        {
            return this.wrapped.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.wrapped.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return this.wrapped.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.wrapped.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
