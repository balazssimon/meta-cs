using MetaDslx.Core.Collections.Transactional;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    internal interface IInternalReadOnlyCollection
    {
        GreenList Green { get; }
    }

    internal interface IInternalCollection : IInternalReadOnlyCollection
    {
        void InternalAdd(object value);
        void InternalRemove(object value);
    }

    internal interface IInternalList : IInternalCollection
    {
        void InternalInsert(int index, object value);
        void InternalReplace(int index, object value);
        void InternalRemoveAt(int index);
    }

    // RED:

    // thread-safe
    public sealed class ImmutableModelList<T> : IImmutableModelList<T>, IReadOnlyList<T>, IInternalReadOnlyCollection
    {
        internal static readonly ImmutableModelList<T> Empty = new ImmutableModelList<T>(null, null);

        private GreenList green;
        private ImmutableModel model;
        private ImmutableList<T> cachedItems = null;

        internal ImmutableModelList(GreenList green, ImmutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        GreenList IInternalReadOnlyCollection.Green { get { return this.green; } }

        public T this[int index]
        {
            get
            {
                if (this.cachedItems == null) this.CacheItems();
                return this.cachedItems[index];
            }
        }

        public int Count
        {
            get
            {
                return this.green.Count;
            }
        }

        public bool Contains(T item)
        {
            object value = null;
            if (this.model != null)
            {
                this.model.ToGreenValue(item);
            }
            return this.green != null && this.green.Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.cachedItems == null) this.CacheItems();
            return this.cachedItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal void CacheItems()
        {
            if (this.cachedItems != null) return;
            Interlocked.CompareExchange(ref this.cachedItems, this.model.CreateListItems<T>(this), null);
        }

        public bool HasLazy()
        {
            return this.green != null && this.green.HasLazyItems;
        }
    }


    // NOT thread-safe
    public sealed class MutableModelList<T> : IMutableModelList<T>, IList<T>
    {
        private GreenList green;
        private MutableModel model;

        internal MutableModelList(GreenList green, MutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        internal GreenList Green { get { return this.green; } }
        public MutableModel Model { get { return this.model; } }

        internal void UpdateGreen(GreenList value)
        {
            if (value != this.green && value != null)
            {
                Interlocked.Exchange(ref this.green, value);
            }
        }

        public void Add(T item)
        {
            this.model.AddItem(this.green, this.model.ToGreenValue(item));
        }

        public void LazyAdd(Func<T> lazy)
        {
            if (lazy == null) return;
            this.model.AddLazyItem(this.green, new GreenLazyValue(() => lazy()));
        }

        public void LazyAddRange(Func<IEnumerable<T>> lazy)
        {
            if (lazy == null) return;
            this.model.AddLazyItem(this.green, new GreenLazyList(() => lazy().Select(v => (object)v)));
        }

        public void LazyAddRange(IEnumerable<Func<T>> lazy)
        {
            if (lazy == null) return;
            foreach (var item in lazy)
            {
                this.LazyAdd(item);
            }
        }

        public bool Remove(T item)
        {
            return this.model.RemoveItem(this.green, this.model.ToGreenValue(item));
        }

        public T this[int index]
        {
            get
            {
                return (T)this.model.ToRedValue(this.green[index]);
            }
            set
            {
                this.model.ReplaceItem(this.green, index, this.model.ToGreenValue(value));
            }
        }

        public int Count
        {
            get
            {
                return this.green.Count;
            }
        }

        public bool IsReadOnly { get { return false; } }

        public void Clear()
        {
            this.model.ClearItems(this.green);
        }

        public bool Contains(T item)
        {
            object greenValue = this.model.ToGreenValue(item);
            return this.green.Contains(greenValue);
        }

        public int IndexOf(T item)
        {
            object greenValue = this.model.ToGreenValue(item);
            return this.green.IndexOf(greenValue);
        }

        public void Insert(int index, T item)
        {
            this.model.InsertItem(this.green, index, this.model.ToGreenValue(item));
        }

        public void RemoveAt(int index)
        {
            this.model.RemoveItemAt(this.green, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.green)
            {
                yield return (T)this.model.ToRedValue(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            // TODO
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool HasLazy()
        {
            return this.green.HasLazyItems;
        }

        public void ClearLazy()
        {
            this.model.ClearLazyItems(this.green);
        }
    }

    internal class ReadOnlyImmutableModelList<T> : IReadOnlyList<T>
        where T : ImmutableSymbolBase
    {
        private IReadOnlyList<SymbolId> greenList;
        private ImmutableModel model;

        public ReadOnlyImmutableModelList(IReadOnlyList<SymbolId> greenList, ImmutableModel model)
        {
            this.greenList = greenList;
            this.model = model;
        }

        public T this[int index]
        {
            get
            {
                return (T)this.model.GetRedSymbol(this.greenList[index]);
            }
        }

        public int Count
        {
            get
            {
                return this.greenList.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in greenList)
            {
                yield return (T)this.model.GetRedSymbol(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    internal class ReadOnlyMutableModelList<T> : IReadOnlyList<T>
        where T : MutableSymbolBase
    {
        private IReadOnlyList<SymbolId> greenList;
        private MutableModel model;

        public ReadOnlyMutableModelList(IReadOnlyList<SymbolId> greenList, MutableModel model)
        {
            this.greenList = greenList;
            this.model = model;
        }

        public T this[int index]
        {
            get
            {
                return (T)this.model.GetRedSymbol(this.greenList[index]);
            }
        }

        public int Count
        {
            get
            {
                return this.greenList.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in greenList)
            {
                yield return (T)this.model.GetRedSymbol(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
