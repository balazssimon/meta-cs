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
    public abstract class MutableModelList<T> : IMutableModelCollection<T>, IList<T>, IReadOnlyList<T>
    {
        public abstract T this[int index] { get; set; }
        public abstract int Count { get; }
        public abstract int LazyCount { get; }
        public abstract bool IsReadOnly { get; }
        public abstract void Add(T item);
        public abstract void AddRange(IEnumerable<T> items);
        public abstract void AddLazy(Func<T> item);
        public abstract void AddRangeLazy(IEnumerable<Func<T>> items);
        public abstract void Clear();
        public abstract void ClearLazy();
        public abstract bool Contains(T item);
        public abstract void CopyTo(T[] array, int arrayIndex);
        public abstract IEnumerator<T> GetEnumerator();
        public abstract int IndexOf(T item);
        public abstract void Insert(int index, T item);
        public abstract bool Remove(T item);
        public abstract bool RemoveAll(T item);
        public abstract void RemoveAt(int index);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static MutableModelList<T> CreateUnique()
        {
            return new MutableModelListFromEnumerable<T>(true);
        }

        public static MutableModelList<T> CreateNonUnique()
        {
            return new MutableModelListFromEnumerable<T>(false);
        }

        public static MutableModelList<T> CreateUnique(IEnumerable<T> items)
        {
            return new MutableModelListFromEnumerable<T>(items, true);
        }

        public static MutableModelList<T> CreateUnique(ISet<T> items)
        {
            return new MutableModelListFromEnumerable<T>(items, true);
        }

        public static MutableModelList<T> CreateUnique(ImmutableHashSet<T> items)
        {
            return new MutableModelListFromEnumerable<T>(items, true);
        }

        public static MutableModelList<T> CreateNonUnique(IEnumerable<T> items)
        {
            return new MutableModelListFromEnumerable<T>(items, false);
        }

        public static MutableModelList<T> CreateNonUnique(ImmutableList<T> items)
        {
            return new MutableModelListFromEnumerable<T>(items, false);
        }

        internal static MutableModelList<T> FromGreenList(MutableObjectBase obj, ModelProperty property)
        {
            return new MutableModelListFromGreenList<T>(obj, property);
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class MutableModelListFromEnumerable<T> : MutableModelList<T>
    {
        private bool unique;
        private ImmutableList<T> items;
        private ImmutableList<Func<T>> lazyItems;

        internal MutableModelListFromEnumerable(bool unique)
        {
            this.unique = unique;
            this.items = ImmutableList<T>.Empty;
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        internal MutableModelListFromEnumerable(IEnumerable<T> items, bool unique)
        {
            this.unique = unique;
            if (this.unique)
            {
                this.items = ImmutableList<T>.Empty;
                this.AddRange(items);
            }
            else
            {
                this.items = items.ToImmutableList();
            }
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        internal MutableModelListFromEnumerable(ISet<T> items, bool unique)
        {
            this.unique = unique;
            this.items = items.ToImmutableList();
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        internal MutableModelListFromEnumerable(ImmutableHashSet<T> items, bool unique)
        {
            this.unique = unique;
            this.items = items.ToImmutableList();
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        internal MutableModelListFromEnumerable(ImmutableList<T> items, bool unique)
        {
            this.unique = unique;
            if (this.unique)
            {
                this.items = ImmutableList<T>.Empty;
                this.AddRange(items);
            }
            else
            {
                this.items = items;
            }
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        private void EvalLazyItems()
        {
            if (this.lazyItems.Count == 0) return;
            ImmutableList<Func<T>> oldLazyItems;
            ImmutableList<Func<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = ImmutableList<Func<T>>.Empty;
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
            foreach (var lazyItem in oldLazyItems)
            {
                T item = lazyItem();
                this.Add(item);
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

        public override T this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                ImmutableList<T> oldItems;
                ImmutableList<T> newItems;
                do
                {
                    oldItems = this.items;
                    if (this.unique)
                    {
                        newItems = oldItems.RemoveAt(index).Remove(value);
                        if (index > newItems.Count) index = newItems.Count;
                        newItems = newItems.Insert(index, value);
                    }
                    else
                    {
                        newItems = oldItems.SetItem(index, value);
                    }
                } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
            }
        }

        public override void Add(T item)
        {
            ImmutableList<T> oldItems;
            ImmutableList<T> newItems;
            do
            {
                oldItems = this.items;
                if (this.unique)
                {
                    if (oldItems.Contains(item)) newItems = oldItems;
                    else newItems = oldItems.Add(item);
                }
                else
                {
                    newItems = oldItems.Add(item);
                }
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
        }

        public override void AddRange(IEnumerable<T> items)
        {
            if (this.unique)
            {
                foreach (var item in items)
                {
                    this.Add(item);
                }
            }
            else
            {
                ImmutableList<T> oldItems;
                ImmutableList<T> newItems;
                do
                {
                    oldItems = this.items;
                    newItems = oldItems.AddRange(items);
                } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
            }
        }

        public override void AddLazy(Func<T> item)
        {
            ImmutableList<Func<T>> oldLazyItems;
            ImmutableList<Func<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = oldLazyItems.Add(item);
            } while (Interlocked.CompareExchange(ref this.lazyItems, newLazyItems, oldLazyItems) != oldLazyItems);
        }

        public override void AddRangeLazy(IEnumerable<Func<T>> items)
        {
            ImmutableList<Func<T>> oldLazyItems;
            ImmutableList<Func<T>> newLazyItems;
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
            ImmutableList<Func<T>> oldLazyItems;
            ImmutableList<Func<T>> newLazyItems;
            do
            {
                oldLazyItems = this.lazyItems;
                newLazyItems = ImmutableList<Func<T>>.Empty;
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

        public override int IndexOf(T item)
        {
            this.EvalLazyItems();
            return this.items.IndexOf(item);
        }

        public override void Insert(int index, T item)
        {
            ImmutableList<T> oldItems;
            ImmutableList<T> newItems;
            do
            {
                oldItems = this.items;
                if (this.unique)
                {
                    newItems = oldItems.Remove(item);
                    if (index > newItems.Count) index = newItems.Count;
                    newItems = newItems.Insert(index, item);
                }
                else
                {
                    newItems = oldItems.Insert(index, item);
                }
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
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

        public override void RemoveAt(int index)
        {
            ImmutableList<T> oldItems;
            ImmutableList<T> newItems;
            do
            {
                oldItems = this.items;
                newItems = oldItems.RemoveAt(index);
            } while (Interlocked.CompareExchange(ref this.items, newItems, oldItems) != oldItems);
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.items.Count, this.lazyItems.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class MutableModelListFromGreenList<T> : MutableModelList<T>
    {
        private MutableObjectBase obj;
        private ModelProperty property;

        internal MutableModelListFromGreenList(MutableObjectBase obj, ModelProperty property)
        {
            this.obj = obj;
            this.property = property;
        }

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

        public override T this[int index]
        {
            get
            {
                GreenList green = this.GetGreen(false);
                return (T)this.obj.MModel.ToRedValue(green[index]);
            }
            set
            {
                this.obj.MModel.ReplaceItem(this.obj.MId, this.property, index, value, this.obj.MIsBeingCreated);
            }
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

        public override void AddLazy(Func<T> item)
        {
            this.obj.MModel.AddLazyItem(this.obj.MId, this.property, LazyValue.Create((Func<object>)(object)item), this.obj.MIsBeingCreated);
        }

        public override void AddRangeLazy(IEnumerable<Func<T>> items)
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
                array[arrayIndex + i] = (T)model.ToRedValue(green[i]);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            MutableModel model = this.obj.MModel;
            GreenList green = this.GetGreen(true);
            foreach (var greenValue in green)
            {
                yield return (T)model.ToRedValue(greenValue);
            }
        }

        public override int IndexOf(T item)
        {
            GreenList green = this.GetGreen(true);
            object greenItem = this.obj.MModel.ToGreenValue(item);
            return green.IndexOf(item);
        }

        public override void Insert(int index, T item)
        {
            this.obj.MModel.InsertItem(this.obj.MId, this.property, index, item, this.obj.MIsBeingCreated);
        }

        public override bool Remove(T item)
        {
            return this.obj.MModel.RemoveItem(this.obj.MId, this.property, item, this.obj.MIsBeingCreated);
        }

        public override bool RemoveAll(T item)
        {
            return this.obj.MModel.RemoveAllItems(this.obj.MId, this.property, item, this.obj.MIsBeingCreated);
        }

        public override void RemoveAt(int index)
        {
            this.obj.MModel.RemoveItemAt(this.obj.MId, this.property, index, this.obj.MIsBeingCreated);
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
