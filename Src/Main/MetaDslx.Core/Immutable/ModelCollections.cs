using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public abstract class ImmutableModelSet<T> : IReadOnlyCollection<T>
    {
        public abstract int Count { get; }

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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

    public abstract class ImmutableModelList<T> : IReadOnlyList<T>
    {
        public abstract T this[int index] { get; }

        public abstract int Count { get; }

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }
    }

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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }
    }

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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }
    }

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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }
    }

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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveSymbol(sid);
            }
        }
    }

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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveSymbol(sid);
            }
        }
    }

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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveSymbol(sid);
            }
        }
    }

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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveSymbol(sid);
            }
        }
    }

    public abstract class MutableModelSet<T> : ICollection<T>
    {
        public abstract int Count { get; }
        public abstract int LazyCount { get; }
        public abstract bool IsReadOnly { get; }
        public abstract void Add(T item);
        public abstract void AddLazy(Func<T> item);
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

        internal static MutableModelSet<T> FromGreenList(MutableSymbolBase symbol, ModelProperty property)
        {
            return new MutableModelSetFromGreenList<T>(symbol, property);
        }
    }

    public abstract class MutableModelList<T> : IList<T>
    {
        public abstract T this[int index] { get; set; }
        public abstract int Count { get; }
        public abstract int LazyCount { get; }
        public abstract bool IsReadOnly { get; }
        public abstract void Add(T item);
        public abstract void AddLazy(Func<T> item);
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

        internal static MutableModelList<T> FromGreenList(MutableSymbolBase symbol, ModelProperty property)
        {
            return new MutableModelListFromGreenList<T>(symbol, property);
        }
    }

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
            return this.symbol.MModel.GetGreenList(this.symbol.Id, property, lazyEval); 
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
            this.symbol.MModel.AddItem(this.symbol.Id, this.property, item, this.symbol.MIsBeingCreated);
        }

        public override void AddLazy(Func<T> item)
        {
            this.symbol.MModel.AddLazyItem(this.symbol.Id, this.property, (Func<object>)(object)item, this.symbol.MIsBeingCreated);
        }

        public override void Clear()
        {
            this.symbol.MModel.ClearItems(this.symbol.Id, this.property, this.symbol.MIsBeingCreated);
        }

        public override void ClearLazy()
        {
            this.symbol.MModel.ClearLazyItems(this.symbol.Id, this.property, this.symbol.MIsBeingCreated);
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
            return this.symbol.MModel.RemoveItem(this.symbol.Id, this.property, item, this.symbol.MIsBeingCreated);
        }

        public override bool RemoveAll(T item)
        {
            return this.symbol.MModel.RemoveAllItems(this.symbol.Id, this.property, item, this.symbol.MIsBeingCreated);
        }
    }

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
            return this.symbol.MModel.GetGreenList(this.symbol.Id, property, lazyEval);
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
                GreenList green = this.GetGreen(true);
                return (T)this.symbol.MModel.ToRedValue(green[index]);
            }
            set
            {
                this.symbol.MModel.ReplaceItem(this.symbol.Id, this.property, index, value, this.symbol.MIsBeingCreated);
            }
        }

        public override void Add(T item)
        {
            this.symbol.MModel.AddItem(this.symbol.Id, this.property, item, this.symbol.MIsBeingCreated);
        }

        public override void AddLazy(Func<T> item)
        {
            this.symbol.MModel.AddLazyItem(this.symbol.Id, this.property, (Func<object>)(object)item, this.symbol.MIsBeingCreated);
        }

        public override void Clear()
        {
            this.symbol.MModel.ClearItems(this.symbol.Id, this.property, this.symbol.MIsBeingCreated);
        }

        public override void ClearLazy()
        {
            this.symbol.MModel.ClearLazyItems(this.symbol.Id, this.property, this.symbol.MIsBeingCreated);
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
            this.symbol.MModel.InsertItem(this.symbol.Id, this.property, index, item, this.symbol.MIsBeingCreated);
        }

        public override bool Remove(T item)
        {
            return this.symbol.MModel.RemoveItem(this.symbol.Id, this.property, item, this.symbol.MIsBeingCreated);
        }

        public override bool RemoveAll(T item)
        {
            return this.symbol.MModel.RemoveAllItems(this.symbol.Id, this.property, item, this.symbol.MIsBeingCreated);
        }

        public override void RemoveAt(int index)
        {
            this.symbol.MModel.RemoveItemAt(this.symbol.Id, this.property, index, this.symbol.MIsBeingCreated);
        }
    }

    // TODO: Dictionary, Qualified...
}
