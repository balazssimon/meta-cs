﻿using MetaDslx.Core.Collections.Transactional;
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

    // GREEN:
    internal class GreenList : IReadOnlyList<object>
    {
        private static readonly TxList<object> emptyList = new TxList<object>();
        private SymbolId parent;
        private ModelProperty property;
        private TxList<object> items;
        private TxList<object> lazyItems;

        internal GreenList(SymbolId parent, ModelProperty property)
        {
            this.parent = parent;
            this.property = property;
            this.items = new TxList<object>();
        }

        internal GreenList(GreenList other)
        {
            this.parent = other.parent;
            this.property = other.property;
            this.items = new TxList<object>(other.items);
            this.lazyItems = other.lazyItems != null ? new TxList<object>(other.lazyItems) : null;
        }

        internal SymbolId Parent { get { return this.parent; } }
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
            if (item is SymbolId)
            {
                if (!property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)item).MutableType))
                {
                    throw new ModelException(string.Format("An object of type '{0}' cannot be added to a collection of types '{1}'.", ((SymbolId)item).MutableType, property.MutableTypeInfo.Type));
                }
            }
            else 
            {
                if (!property.MutableTypeInfo.Type.IsAssignableFrom(item.GetType()))
                {
                    throw new ModelException(string.Format("An object of type '{0}' cannot be added to a collection of types '{1}'.", item.GetType(), property.MutableTypeInfo.Type));
                }
            }
            if (this.property.IsNonNull && item == null)
            {
                throw new ModelException(string.Format("Cannot add null to collection of non-null types '{0}'.", property.MutableTypeInfo.Type));
            }
            if (this.property.IsNonUnique || !this.items.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            return false;
        }

        internal bool AddRange(IEnumerable<object> items)
        {
            bool result = false;
            foreach (var item in items)
            {
                result |= this.Add(item);
            }
            return result;
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
            if (item is SymbolId)
            {
                if (!property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)item).MutableType))
                {
                    throw new ModelException(string.Format("An object of type '{0}' cannot be added to a collection of types '{1}'.", ((SymbolId)item).MutableType, property.MutableTypeInfo.Type));
                }
            }
            else
            {
                if (!property.MutableTypeInfo.Type.IsAssignableFrom(item.GetType()))
                {
                    throw new ModelException(string.Format("An object of type '{0}' cannot be added to a collection of types '{1}'.", item.GetType(), property.MutableTypeInfo.Type));
                }
            }
            if (this.property.IsNonNull && item == null)
            {
                throw new ModelException(string.Format("Cannot add null to collection of non-null types '{0}'.", property.MutableTypeInfo.Type));
            }
            if (this.property.IsNonUnique || !this.items.Contains(item))
            {
                this.items.Insert(index, item);
                return true;
            }
            else
            {
                this.items.Remove(item);
                this.items.Insert(index, item);
            }
            return false;
        }

        internal int IndexOf(object item)
        {
            return this.items.IndexOf(item);
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

        internal void AddLazy(object item)
        {
            Debug.Assert(item is GreenLazyValue || item is GreenLazyList);
            Interlocked.CompareExchange(ref this.lazyItems, new TxList<object>(), null);
            this.lazyItems.Add(item);
        }

        internal bool RemoveAll(object item)
        {
            bool result = false;
            for (int i = this.items.Count-1; i >= 0; i++)
            {
                if (this.items[i] == item)
                {
                    this.items.Remove(i);
                    result = true;
                }
            }
            return result;
        }

        internal void ClearLazyItems()
        {
            if (this.lazyItems != null)
            {
                this.lazyItems.Clear();
            }
        }
    }

    // RED:

    // thread-safe
    public sealed class ImmutableRedList<T> : ImmutableModelList<T>, IReadOnlyList<T>, IInternalReadOnlyCollection
    {
        private GreenList green;
        private ImmutableRedModelPart model;
        private List<T> cachedItems = null;

        internal ImmutableRedList(GreenList green, ImmutableRedModelPart model)
        {
            this.green = green;
            this.model = model;
        }

        GreenList IInternalReadOnlyCollection.Green { get { return this.green; } }
        public ModelProperty Property { get { return this.green.Property; } }
        public ImmutableRedModelPart Model { get { return this.model; } }

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
            object value = this.model.ToGreenValue(item);
            return this.green.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.cachedItems == null) this.CacheItems();
            foreach (var item in this.cachedItems)
            {
                yield return item;
            }
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
            return this.green.HasLazyItems;
        }
    }


    // NOT thread-safe
    public sealed class MutableRedList<T> : ModelList<T>, IList<T>
    {
        private GreenList green;
        private MutableRedModelPart model;

        internal MutableRedList(GreenList green, MutableRedModelPart model)
        {
            this.green = green;
            this.model = model;
        }

        internal GreenList Green { get { return this.green; } }
        public MutableRedModelPart Model { get { return this.model; } }

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

    internal class ImmutableReadOnlyRedList<T> : IReadOnlyList<T>
        where T : ImmutableRedSymbolBase
    {
        private IReadOnlyList<SymbolId> greenList;
        private ImmutableRedModelPart part;

        public ImmutableReadOnlyRedList(IReadOnlyList<SymbolId> greenList, ImmutableRedModelPart part)
        {
            this.greenList = greenList;
            this.part = part;
        }

        public T this[int index]
        {
            get
            {
                return (T)this.part.Model.GetRedSymbol(this.greenList[index]);
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
                yield return (T)this.part.Model.GetRedSymbol(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    internal class MutableReadOnlyRedList<T> : IReadOnlyList<T>
        where T : MutableRedSymbolBase
    {
        private IReadOnlyList<SymbolId> greenList;
        private MutableRedModelPart part;

        public MutableReadOnlyRedList(IReadOnlyList<SymbolId> greenList, MutableRedModelPart part)
        {
            this.greenList = greenList;
            this.part = part;
        }

        public T this[int index]
        {
            get
            {
                return (T)this.part.Model.GetRedSymbol(this.greenList[index]);
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
                yield return (T)this.part.Model.GetRedSymbol(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}