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
        private GreenList green = null;
        private GreenSymbol greenParent = null;
        private MutableSymbolBase parent;
        private ModelProperty property;
        private MutableModel model;

        internal MutableModelList(MutableSymbolBase parent, ModelProperty property, MutableModel model)
        {
            this.parent = parent;
            this.property = property;
            this.model = model;
        }

        internal MutableSymbolBase Parent { get { return this.parent; } }
        internal ModelProperty Prpoperty { get { return this.property; } }
        internal GreenList Green
        {
            get
            {
                if (this.greenParent != this.parent.Green)
                {
                    this.greenParent = this.parent.Green;
                    this.green = this.greenParent.GetValue(this.property) as GreenList;
                }
                return this.green;
            }
        }

        public MutableModel Model { get { return this.model; } }

        public void Add(T item)
        {
            this.model.AddItem(this.parent.Id, this.property, this.model.ToGreenValue(item), !this.parent.MIsCreated);
        }

        public void LazyAdd(Func<T> lazy)
        {
            if (lazy == null) return;
            this.model.AddLazyItem(this.parent.Id, this.property, new GreenLazyValue(() => lazy()), !this.parent.MIsCreated);
        }

        public void LazyAddRange(Func<IEnumerable<T>> lazy)
        {
            if (lazy == null) return;
            this.model.AddLazyItem(this.parent.Id, this.property, new GreenLazyList(() => lazy().Select(v => (object)v)), !this.parent.MIsCreated);
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
            return this.model.RemoveItem(this.parent.Id, this.property, this.model.ToGreenValue(item), !this.parent.MIsCreated);
        }

        public T this[int index]
        {
            get
            {
                return (T)this.model.ToRedValue(this.Green[index]);
            }
            set
            {
                this.model.ReplaceItem(this.parent.Id, this.property, index, this.model.ToGreenValue(value), !this.parent.MIsCreated);
            }
        }

        public int Count
        {
            get
            {
                return this.Green.Count;
            }
        }

        public bool IsReadOnly { get { return false; } }

        public void Clear()
        {
            this.model.ClearItems(this.parent.Id, this.property, !this.parent.MIsCreated);
        }

        public bool Contains(T item)
        {
            object greenValue = this.model.ToGreenValue(item);
            return this.Green.Contains(greenValue);
        }

        public int IndexOf(T item)
        {
            object greenValue = this.model.ToGreenValue(item);
            return this.Green.IndexOf(greenValue);
        }

        public void Insert(int index, T item)
        {
            this.model.InsertItem(this.parent.Id, this.property, index, this.model.ToGreenValue(item), !this.parent.MIsCreated);
        }

        public void RemoveAt(int index)
        {
            this.model.RemoveItemAt(this.parent.Id, this.property, index, !this.parent.MIsCreated);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.Green)
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
            return this.Green.HasLazyItems;
        }

        public void ClearLazy()
        {
            this.model.ClearLazyItems(this.parent.Id, this.property, !this.parent.MIsCreated);
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
                return (T)this.model.GetRedSymbol(this.greenList[index], true);
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
                yield return (T)this.model.GetRedSymbol(item, true);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
