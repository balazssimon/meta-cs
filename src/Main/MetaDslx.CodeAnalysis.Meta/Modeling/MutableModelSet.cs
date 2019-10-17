using MetaDslx.Modeling.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling
{
    public abstract class MutableModelSet<T> : IMutableModelCollection<T>
    {
        /*public ImmutableModelSet<TImmutable> ToImmutable<TImmutable>()
        {
            var immutableItems = this.Select(item => item is MutableObject immObj ? (TImmutable)immObj.ToImmutable() : (TImmutable)(object)item);
            if (this.IsUnique) return ImmutableModelSet<TImmutable>.CreateUnique(immutableItems);
            else return ImmutableModelSet<TImmutable>.CreateNonUnique(immutableItems);
        }

        public ImmutableModelSet<TImmutable> ToImmutable<TImmutable>(ImmutableModel model)
        {
            var immutableItems = this.Select(item => item is MutableObject immObj ? (TImmutable)immObj.ToImmutable(model) : (TImmutable)(object)item);
            if (this.IsUnique) return ImmutableModelSet<TImmutable>.CreateUnique(immutableItems);
            else return ImmutableModelSet<TImmutable>.CreateNonUnique(immutableItems);
        }*/

        public abstract bool IsUnique { get; }

        public abstract int Count { get; }
        public abstract int LazyCount { get; }
        public abstract bool IsReadOnly { get; }
        public abstract void Add(T item);
        public abstract void AddRange(IEnumerable<T> items);
        public abstract void AddLazy(LazyValue<T> item);
        public abstract void AddRangeLazy(IEnumerable<LazyValue<T>> items);
        public abstract void Clear();
        public abstract void ClearLazy();
        public abstract bool Contains(T item);
        public abstract void CopyTo(T[] array, int arrayIndex);
        public abstract IEnumerator<T> GetEnumerator();
        public abstract bool Remove(T item);
        public abstract bool RemoveAll(T item);

        public void AddLazy(Func<T> item)
        {
            this.AddLazy(LazyValue.Create(item));
        }
        public void AddRangeLazy(IEnumerable<Func<T>> items)
        {
            this.AddRangeLazy(items.Select(f => LazyValue.Create(f)));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /*
        public static MutableModelSet<T> CreateUnique()
        {
            return new MutableModelSetFromEnumerableSet<T>();
        }

        public static MutableModelSet<T> CreateNonUnique()
        {
            return new MutableModelSetFromEnumerableList<T>();
        }

        public static MutableModelSet<T> CreateUnique(IEnumerable<T> items)
        {
            return new MutableModelSetFromEnumerableSet<T>(items);
        }

        public static MutableModelSet<T> CreateUnique(ImmutableHashSet<T> items)
        {
            return new MutableModelSetFromEnumerableSet<T>(items);
        }

        public static MutableModelSet<T> CreateNonUnique(IEnumerable<T> items)
        {
            return new MutableModelSetFromEnumerableList<T>(items);
        }

        public static MutableModelSet<T> CreateNonUnique(ImmutableList<T> items)
        {
            return new MutableModelSetFromEnumerableList<T>(items);
        }*/

        internal static MutableModelSet<T> FromGreenList(MutableObjectBase obj, ModelProperty property)
        {
            return new MutableModelSetFromGreenList<T>(obj, property);
        }
    }

    /*
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class MutableModelSetFromEnumerableSet<T> : MutableModelSet<T>
    {
        private ImmutableHashSet<T> items;
        private ImmutableList<LazyValue<T>> lazyItems;

        internal MutableModelSetFromEnumerableSet()
        {
            this.items = ImmutableHashSet<T>.Empty;
            this.lazyItems = ImmutableList<LazyValue<T>>.Empty;
        }

        internal MutableModelSetFromEnumerableSet(IEnumerable<T> items)
        {
            this.items = items.ToImmutableHashSet();
            this.lazyItems = ImmutableList<LazyValue<T>>.Empty;
        }

        internal MutableModelSetFromEnumerableSet(ImmutableHashSet<T> items)
        {
            this.items = items;
            this.lazyItems = ImmutableList<LazyValue<T>>.Empty;
        }

        public override bool IsUnique => true;

        private void EvalLazyItems()
        {
            if (this.lazyItems.Count == 0) return;
            ImmutableList<LazyValue<T>> oldLazyItems;
            ImmutableList<LazyValue<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = ImmutableList<LazyValue<T>>.Empty;
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
            foreach (var lazyItem in oldLazyItems)
            {
                if (lazyItem.IsSingleValue) this.Add(lazyItem.CreateTypedRedValue());
                else this.AddRange(lazyItem.CreateTypedRedValues());
            }
        }

        public override int Count
        {
            get
            {
                this.EvalLazyItems();
                return this.items.Count;
            }
        }

        public override int LazyCount
        {
            get { return this.lazyItems.Count; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override void Add(T item)
        {
            ImmutableHashSet<T> oldItems;
            ImmutableHashSet<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = oldItems.Add(item);
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
        }

        public override void AddRange(IEnumerable<T> items)
        {
            ImmutableHashSet<T> oldItems;
            ImmutableHashSet<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = oldItems.Union(items);
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
        }

        public override void AddLazy(LazyValue<T> item)
        {
            ImmutableList<LazyValue<T>> oldLazyItems;
            ImmutableList<LazyValue<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = oldLazyItems.Add(item);
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
        }

        public override void AddRangeLazy(IEnumerable<LazyValue<T>> items)
        {
            ImmutableList<LazyValue<T>> oldLazyItems;
            ImmutableList<LazyValue<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = oldLazyItems.AddRange(items);
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
        }

        public override void Clear()
        {
            this.ClearLazy();
            ImmutableHashSet<T> oldItems;
            ImmutableHashSet<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = ImmutableHashSet<T>.Empty;
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
        }

        public override void ClearLazy()
        {
            ImmutableList<LazyValue<T>> oldLazyItems;
            ImmutableList<LazyValue<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = ImmutableList<LazyValue<T>>.Empty;
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
        }

        public override bool Contains(T item)
        {
            this.EvalLazyItems();
            return this.items.Contains(item);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            this.EvalLazyItems();
            ImmutableList<T> items = this.items.ToImmutableList();
            for (int i = 0; i < items.Count && arrayIndex + i < array.Length; i++)
            {
                array[arrayIndex + i] = items[i];
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            this.EvalLazyItems();
            return this.items.GetEnumerator();
        }

        public override bool Remove(T item)
        {
            ImmutableHashSet<T> oldItems;
            ImmutableHashSet<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = oldItems.Remove(item);
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
            return newItems != oldItems;
        }

        public override bool RemoveAll(T item)
        {
            return this.Remove(item);
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.items.Count, this.lazyItems.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class MutableModelSetFromEnumerableList<T> : MutableModelSet<T>
    {
        private ImmutableList<T> items;
        private ImmutableList<LazyValue<T>> lazyItems;

        internal MutableModelSetFromEnumerableList()
        {
            this.items = ImmutableList<T>.Empty;
            this.lazyItems = ImmutableList<LazyValue<T>>.Empty;
        }

        internal MutableModelSetFromEnumerableList(IEnumerable<T> items)
        {
            this.items = items.ToImmutableList();
            this.lazyItems = ImmutableList<LazyValue<T>>.Empty;
        }

        internal MutableModelSetFromEnumerableList(ImmutableList<T> items)
        {
            this.items = items;
            this.lazyItems = ImmutableList<LazyValue<T>>.Empty;
        }

        public override bool IsUnique => false;

        private void EvalLazyItems()
        {
            if (this.lazyItems.Count == 0) return;
            ImmutableList<LazyValue<T>> oldLazyItems;
            ImmutableList<LazyValue<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = ImmutableList<LazyValue<T>>.Empty;
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
            foreach (var lazyItem in oldLazyItems)
            {
                if (lazyItem.IsSingleValue) this.Add(lazyItem.CreateTypedRedValue());
                else this.AddRange(lazyItem.CreateTypedRedValues());
            }
        }

        public override int Count
        {
            get
            {
                this.EvalLazyItems();
                return this.items.Count;
            }
        }

        public override int LazyCount
        {
            get { return this.lazyItems.Count; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override void Add(T item)
        {
            ImmutableList<T> oldItems;
            ImmutableList<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = oldItems.Add(item);
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
        }

        public override void AddRange(IEnumerable<T> items)
        {
            ImmutableList<T> oldItems;
            ImmutableList<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = oldItems.AddRange(items);
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
        }

        public override void AddLazy(LazyValue<T> item)
        {
            ImmutableList<LazyValue<T>> oldLazyItems;
            ImmutableList<LazyValue<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = oldLazyItems.Add(item);
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
        }

        public override void AddRangeLazy(IEnumerable<LazyValue<T>> items)
        {
            ImmutableList<LazyValue<T>> oldLazyItems;
            ImmutableList<LazyValue<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = oldLazyItems.AddRange(items);
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
        }

        public override void Clear()
        {
            this.ClearLazy();
            ImmutableList<T> oldItems;
            ImmutableList<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = ImmutableList<T>.Empty;
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
        }

        public override void ClearLazy()
        {
            ImmutableList<LazyValue<T>> oldLazyItems;
            ImmutableList<LazyValue<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = ImmutableList<LazyValue<T>>.Empty;
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
        }

        public override bool Contains(T item)
        {
            this.EvalLazyItems();
            return this.items.Contains(item);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            this.EvalLazyItems();
            ImmutableList<T> items = this.items;
            for (int i = 0; i < items.Count && arrayIndex + i < array.Length; i++)
            {
                array[arrayIndex + i] = items[i];
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            this.EvalLazyItems();
            return this.items.GetEnumerator();
        }

        public override bool Remove(T item)
        {
            ImmutableList<T> oldItems;
            ImmutableList<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = oldItems.Remove(item);
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
            return newItems != oldItems;
        }

        public override bool RemoveAll(T item)
        {
            ImmutableList<T> oldItems;
            ImmutableList<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = oldItems.RemoveAll(it => (it == null && item == null) || (it != null && it.Equals(item)));
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
            return newItems != oldItems;
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.items.Count, this.lazyItems.Count); }
        }
    }*/

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class MutableModelSetFromGreenList<T> : MutableModelSet<T>
    {
        private MutableObjectBase obj;
        private ModelProperty property;

        internal MutableModelSetFromGreenList(MutableObjectBase obj, ModelProperty property)
        {
            this.obj = obj;
            this.property = property;
        }

        public override bool IsUnique => property.IsUnique;

        private GreenList GetGreen(bool lazyEval)
        {
            return this.obj.MModel.GetGreenList(this.obj.MId, property, lazyEval);
        }

        public override int Count
        {
            get { return this.GetGreen(true).Count; }
        }

        public override int LazyCount
        {
            get { return this.GetGreen(false).LazyItems.Count; }
        }

        public override bool IsReadOnly
        {
            get { return this.obj.MIsReadOnly || this.property.IsReadonly; }
        }

        public override void Add(T item)
        {
            this.obj.MModel.AddItem(this.obj.MId, this.property, item, this.obj.MIsBeingCreated);
        }

        public override void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public override void AddLazy(LazyValue<T> item)
        {
            this.obj.MModel.AddLazyItem(this.obj.MId, this.property, item, this.obj.MIsBeingCreated);
        }

        public override void AddRangeLazy(IEnumerable<LazyValue<T>> items)
        {
            foreach (var item in items)
            {
                this.AddLazy(item);
            }
        }

        public override void Clear()
        {
            this.obj.MModel.ClearItems(this.obj.MId, this.property, this.obj.MIsBeingCreated);
        }

        public override void ClearLazy()
        {
            this.obj.MModel.ClearLazyItems(this.obj.MId, this.property, this.obj.MIsBeingCreated);
        }

        public override bool Contains(T item)
        {
            GreenList green = this.GetGreen(true);
            object greenItem = this.obj.MModel.ToGreenValue(item);
            return green.Contains(greenItem);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            MutableModel model = this.obj.MModel;
            GreenList green = this.GetGreen(true);
            for (int i = 0; i < green.Count && arrayIndex + i < array.Length; i++)
            {
                array[arrayIndex + i] = (T)model.ToRedValue(green[i], this.obj.MId);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            MutableModel model = this.obj.MModel;
            GreenList green = this.GetGreen(true);
            foreach (var greenValue in green)
            {
                yield return (T)model.ToRedValue(greenValue, this.obj.MId);
            }
        }

        public override bool Remove(T item)
        {
            return this.obj.MModel.RemoveItem(this.obj.MId, this.property, item, this.obj.MIsBeingCreated);
        }

        public override bool RemoveAll(T item)
        {
            return this.obj.MModel.RemoveAllItems(this.obj.MId, this.property, item, this.obj.MIsBeingCreated);
        }

        private string DebuggerDisplay
        {
            get
            {
                GreenList green = this.GetGreen(false);
                return string.Format("Count = {0}, LazyCount = {1}", green.Count, green.LazyItems.Count);
            }
        }
    }

}
