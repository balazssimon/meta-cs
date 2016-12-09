using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public interface IModelCollection<out T> : IReadOnlyCollection<T>
    {
    }

    public interface IImmutableModelCollection<out T> : IModelCollection<T>
    {

    }

    public interface IMutableModelCollection<T> : IModelCollection<T>, ICollection<T>
    {

    }

    public abstract class ImmutableModelSet<T> : IImmutableModelCollection<T>
    {
        public static readonly ImmutableModelSet<T> Empty = new ImmutableModelSetFromEnumerableSet<T>();

        public abstract int Count { get; }

        public abstract bool Contains(T item);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static ImmutableModelSet<T> CreateUnique(IEnumerable<T> items)
        {
            return new ImmutableModelSetFromEnumerableSet<T>(items);
        }

        public static ImmutableModelSet<T> CreateNonUnique(IEnumerable<T> items)
        {
            return new ImmutableModelSetFromEnumerableList<T>(items);
        }

        public static ImmutableModelSet<T> CreateUnique(ImmutableHashSet<T> items)
        {
            return new ImmutableModelSetFromEnumerableSet<T>(items);
        }

        public static ImmutableModelSet<T> CreateNonUnique(ImmutableList<T> items)
        {
            return new ImmutableModelSetFromEnumerableList<T>(items);
        }

        internal static ImmutableModelSet<T> FromGreenList(GreenList green, ImmutableModel model)
        {
            return new ImmutableModelSetFromGreenListImmutable<T>(green, model);
        }

        internal static ImmutableModelSet<T> FromGreenList(GreenList green, MutableModel model)
        {
            return new ImmutableModelSetFromGreenListMutable<T>(green, model);
        }

        internal static ImmutableModelSet<T> FromSymbolIdList(ImmutableList<SymbolId> green, ImmutableModel model)
        {
            return new ImmutableModelSetFromSymbolIdListImmutable<T>(green, model);
        }

        internal static ImmutableModelSet<T> FromSymbolIdList(ImmutableList<SymbolId> green, MutableModel model)
        {
            return new ImmutableModelSetFromSymbolIdListMutable<T>(green, model);
        }
    }

    public abstract class ImmutableModelList<T> : IImmutableModelCollection<T>, IReadOnlyList<T>
    {
        public static readonly ImmutableModelList<T> Empty = new ImmutableModelListFromEnumerable<T>();

        public abstract T this[int index] { get; }

        public abstract int Count { get; }

        public abstract bool Contains(T item);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static ImmutableModelList<T> CreateUnique(IEnumerable<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, true);
        }

        public static ImmutableModelList<T> CreateNonUnique(IEnumerable<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, false);
        }

        public static ImmutableModelList<T> CreateUnique(ISet<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, true);
        }

        public static ImmutableModelList<T> CreateUnique(ImmutableHashSet<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, true);
        }

        public static ImmutableModelList<T> CreateNonUnique(ImmutableList<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, false);
        }

        internal static ImmutableModelList<T> FromGreenList(GreenList green, ImmutableModel model)
        {
            return new ImmutableModelListFromGreenListImmutable<T>(green, model);
        }

        internal static ImmutableModelList<T> FromGreenList(GreenList green, MutableModel model)
        {
            return new ImmutableModelListFromGreenListMutable<T>(green, model);
        }

        internal static ImmutableModelList<T> FromSymbolIdList(ImmutableList<SymbolId> green, ImmutableModel model)
        {
            return new ImmutableModelListFromSymbolIdListImmutable<T>(green, model);
        }

        internal static ImmutableModelList<T> FromSymbolIdList(ImmutableList<SymbolId> green, MutableModel model)
        {
            return new ImmutableModelListFromSymbolIdListMutable<T>(green, model);
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelSetFromEnumerableSet<T> : ImmutableModelSet<T>
    {
        private ImmutableHashSet<T> items;

        internal ImmutableModelSetFromEnumerableSet()
        {
            this.items = ImmutableHashSet<T>.Empty;
        }

        internal ImmutableModelSetFromEnumerableSet(IEnumerable<T> items)
        {
            this.items = items.ToImmutableHashSet();
        }

        internal ImmutableModelSetFromEnumerableSet(ImmutableHashSet<T> items)
        {
            this.items = items;
        }

        public override int Count { get { return this.items.Count; } }

        public override bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.items.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelSetFromEnumerableList<T> : ImmutableModelSet<T>
    {
        private ImmutableList<T> items;

        internal ImmutableModelSetFromEnumerableList()
        {
            this.items = ImmutableList<T>.Empty;
        }

        internal ImmutableModelSetFromEnumerableList(IEnumerable<T> items)
        {
            this.items = items.ToImmutableList();
        }

        internal ImmutableModelSetFromEnumerableList(ImmutableList<T> items)
        {
            this.items = items;
        }

        public override int Count { get { return this.items.Count; } }

        public override bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.items.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelSetFromGreenListImmutable<T> : ImmutableModelSet<T>
    {
        private GreenList green;
        private ImmutableModel model;

        internal ImmutableModelSetFromGreenListImmutable(GreenList green, ImmutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.green.Count, this.green.LazyItems.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelSetFromGreenListMutable<T> : ImmutableModelSet<T>
    {
        private GreenList green;
        private MutableModel model;

        internal ImmutableModelSetFromGreenListMutable(GreenList green, MutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.green.Count, this.green.LazyItems.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromEnumerable<T> : ImmutableModelList<T>
    {
        private ImmutableList<T> items;

        internal ImmutableModelListFromEnumerable()
        {
            this.items = ImmutableList<T>.Empty;
        }

        internal ImmutableModelListFromEnumerable(IEnumerable<T> items, bool unique)
        {
            if (unique) this.items = items.Distinct().ToImmutableList();
            else this.items = items.ToImmutableList();
        }

        internal ImmutableModelListFromEnumerable(ISet<T> items, bool unique)
        {
            this.items = items.ToImmutableList();
        }

        internal ImmutableModelListFromEnumerable(ImmutableHashSet<T> items, bool unique)
        {
            this.items = items.ToImmutableList();
        }

        public override T this[int index]
        {
            get { return this.items[index]; }
        }

        public override int Count { get { return this.items.Count; } }

        public override bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.items.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromGreenListImmutable<T> : ImmutableModelList<T>
    {
        private GreenList green;
        private ImmutableModel model;

        internal ImmutableModelListFromGreenListImmutable(GreenList green, ImmutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override T this[int index]
        {
            get { return (T)this.model.ToRedValue(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.green.Count, this.green.LazyItems.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromGreenListMutable<T> : ImmutableModelList<T>
    {
        private GreenList green;
        private MutableModel model;

        internal ImmutableModelListFromGreenListMutable(GreenList green, MutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override T this[int index]
        {
            get { return (T)this.model.ToRedValue(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.green.Count, this.green.LazyItems.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelSetFromSymbolIdListImmutable<T> : ImmutableModelSet<T>
    {
        private ImmutableList<SymbolId> green;
        private ImmutableModel model;

        internal ImmutableModelSetFromSymbolIdListImmutable(ImmutableList<SymbolId> green, ImmutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveSymbol(sid);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.green.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelSetFromSymbolIdListMutable<T> : ImmutableModelSet<T>
    {
        private ImmutableList<SymbolId> green;
        private MutableModel model;

        internal ImmutableModelSetFromSymbolIdListMutable(ImmutableList<SymbolId> green, MutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveSymbol(sid);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.green.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromSymbolIdListImmutable<T> : ImmutableModelList<T>
    {
        private ImmutableList<SymbolId> green;
        private ImmutableModel model;

        internal ImmutableModelListFromSymbolIdListImmutable(ImmutableList<SymbolId> green, ImmutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override T this[int index]
        {
            get { return (T)(object)this.model.ResolveSymbol(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveSymbol(sid);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.green.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromSymbolIdListMutable<T> : ImmutableModelList<T>
    {
        private ImmutableList<SymbolId> green;
        private MutableModel model;

        internal ImmutableModelListFromSymbolIdListMutable(ImmutableList<SymbolId> green, MutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override T this[int index]
        {
            get { return (T)(object)this.model.ResolveSymbol(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveSymbol(sid);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.green.Count); }
        }
    }

    public abstract class MutableModelSet<T> : IMutableModelCollection<T>
    {
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
        public abstract bool Remove(T item);
        public abstract bool RemoveAll(T item);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


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
        }

        internal static MutableModelSet<T> FromGreenList(MutableSymbolBase symbol, ModelProperty property)
        {
            return new MutableModelSetFromGreenList<T>(symbol, property);
        }
    }

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

        internal static MutableModelList<T> FromGreenList(MutableSymbolBase symbol, ModelProperty property)
        {
            return new MutableModelListFromGreenList<T>(symbol, property);
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class MutableModelSetFromEnumerableSet<T> : MutableModelSet<T>
    {
        private ImmutableHashSet<T> items;
        private ImmutableList<Func<T>> lazyItems;

        internal MutableModelSetFromEnumerableSet()
        {
            this.items = ImmutableHashSet<T>.Empty;
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        internal MutableModelSetFromEnumerableSet(IEnumerable<T> items)
        {
            this.items = items.ToImmutableHashSet();
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        internal MutableModelSetFromEnumerableSet(ImmutableHashSet<T> items)
        {
            this.items = items;
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
            ImmutableList<T> items = this.items.ToImmutableList();
            for (int i = 0; i < items.Count && arrayIndex+i < array.Length; i++)
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
        private ImmutableList<Func<T>> lazyItems;

        internal MutableModelSetFromEnumerableList()
        {
            this.items = ImmutableList<T>.Empty;
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        internal MutableModelSetFromEnumerableList(IEnumerable<T> items)
        {
            this.items = items.ToImmutableList();
            this.lazyItems = ImmutableList<Func<T>>.Empty;
        }

        internal MutableModelSetFromEnumerableList(ImmutableList<T> items)
        {
            this.items = items;
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
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class MutableModelSetFromGreenList<T> : MutableModelSet<T>
    {
        private MutableSymbolBase symbol;
        private ModelProperty property;

        internal MutableModelSetFromGreenList(MutableSymbolBase symbol, ModelProperty property)
        {
            this.symbol = symbol;
            this.property = property;
        }

        private GreenList GetGreen(bool lazyEval)
        {
            return this.symbol.MModel.GetGreenList(this.symbol.MId, property, lazyEval);
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
            get { return this.symbol.MIsReadOnly || this.property.IsReadonly; }
        }

        public override void Add(T item)
        {
            this.symbol.MModel.AddItem(this.symbol.MId, this.property, item, this.symbol.MIsBeingCreated);
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
            this.symbol.MModel.AddLazyItem(this.symbol.MId, this.property, (Func<object>)(object)item, this.symbol.MIsBeingCreated);
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
            this.symbol.MModel.ClearItems(this.symbol.MId, this.property, this.symbol.MIsBeingCreated);
        }

        public override void ClearLazy()
        {
            this.symbol.MModel.ClearLazyItems(this.symbol.MId, this.property, this.symbol.MIsBeingCreated);
        }

        public override bool Contains(T item)
        {
            GreenList green = this.GetGreen(true);
            object greenItem = this.symbol.MModel.ToGreenValue(item);
            return green.Contains(greenItem);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            MutableModel model = this.symbol.MModel;
            GreenList green = this.GetGreen(true);
            for (int i = 0; i < green.Count && arrayIndex + i < array.Length; i++)
            {
                array[arrayIndex + i] = (T)model.ToRedValue(green[i]);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            MutableModel model = this.symbol.MModel;
            GreenList green = this.GetGreen(true);
            foreach (var greenValue in green)
            {
                yield return (T)model.ToRedValue(greenValue);
            }
        }

        public override bool Remove(T item)
        {
            return this.symbol.MModel.RemoveItem(this.symbol.MId, this.property, item, this.symbol.MIsBeingCreated);
        }

        public override bool RemoveAll(T item)
        {
            return this.symbol.MModel.RemoveAllItems(this.symbol.MId, this.property, item, this.symbol.MIsBeingCreated);
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
        private MutableSymbolBase symbol;
        private ModelProperty property;

        internal MutableModelListFromGreenList(MutableSymbolBase symbol, ModelProperty property)
        {
            this.symbol = symbol;
            this.property = property;
        }

        private GreenList GetGreen(bool lazyEval)
        {
            return this.symbol.MModel.GetGreenList(this.symbol.MId, property, lazyEval);
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
            get { return this.symbol.MIsReadOnly || this.property.IsReadonly; }
        }

        public override T this[int index]
        {
            get
            {
                GreenList green = this.GetGreen(false);
                return (T)this.symbol.MModel.ToRedValue(green[index]);
            }
            set
            {
                this.symbol.MModel.ReplaceItem(this.symbol.MId, this.property, index, value, this.symbol.MIsBeingCreated);
            }
        }

        public override void Add(T item)
        {
            this.symbol.MModel.AddItem(this.symbol.MId, this.property, item, this.symbol.MIsBeingCreated);
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
            this.symbol.MModel.AddLazyItem(this.symbol.MId, this.property, (Func<object>)(object)item, this.symbol.MIsBeingCreated);
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
            this.symbol.MModel.ClearItems(this.symbol.MId, this.property, this.symbol.MIsBeingCreated);
        }

        public override void ClearLazy()
        {
            this.symbol.MModel.ClearLazyItems(this.symbol.MId, this.property, this.symbol.MIsBeingCreated);
        }

        public override bool Contains(T item)
        {
            GreenList green = this.GetGreen(true);
            object greenItem = this.symbol.MModel.ToGreenValue(item);
            return green.Contains(greenItem);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            MutableModel model = this.symbol.MModel;
            GreenList green = this.GetGreen(true);
            for (int i = 0; i < green.Count && arrayIndex + i < array.Length; i++)
            {
                array[arrayIndex + i] = (T)model.ToRedValue(green[i]);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            MutableModel model = this.symbol.MModel;
            GreenList green = this.GetGreen(true);
            foreach (var greenValue in green)
            {
                yield return (T)model.ToRedValue(greenValue);
            }
        }

        public override int IndexOf(T item)
        {
            GreenList green = this.GetGreen(true);
            object greenItem = this.symbol.MModel.ToGreenValue(item);
            return green.IndexOf(item);
        }

        public override void Insert(int index, T item)
        {
            this.symbol.MModel.InsertItem(this.symbol.MId, this.property, index, item, this.symbol.MIsBeingCreated);
        }

        public override bool Remove(T item)
        {
            return this.symbol.MModel.RemoveItem(this.symbol.MId, this.property, item, this.symbol.MIsBeingCreated);
        }

        public override bool RemoveAll(T item)
        {
            return this.symbol.MModel.RemoveAllItems(this.symbol.MId, this.property, item, this.symbol.MIsBeingCreated);
        }

        public override void RemoveAt(int index)
        {
            this.symbol.MModel.RemoveItemAt(this.symbol.MId, this.property, index, this.symbol.MIsBeingCreated);
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

    // TODO: Dictionary, Qualified...
}
