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
        public abstract bool IsUnique { get; }
        public abstract T this[int index] { get; set; }
        public abstract int Count { get; }
        public abstract int LazyCount { get; }
        public abstract bool IsReadOnly { get; }
        public abstract void Add(T item);
        public abstract void Add(T item, object tag);
        public abstract void AddRange(IEnumerable<T> items);
        public abstract void AddRange(IEnumerable<T> items, object tag);
        public abstract void AddLazy(LazyValue<T> item);
        public abstract void AddRangeLazy(IEnumerable<LazyValue<T>> items);
        public abstract void Clear();
        public abstract void ClearLazy();
        public abstract bool Contains(T item);
        public abstract bool Contains(T item, object tag);
        public abstract void CopyTo(T[] array, int arrayIndex);
        public abstract IEnumerator<T> GetEnumerator();
        public abstract int IndexOf(T item);
        public abstract int IndexOf(T item, object tag);
        public abstract object GetTagAt(int index);
        public abstract object GetTagOf(T item);
        public abstract void Insert(int index, T item);
        public abstract void Insert(int index, T item, object tag);
        public abstract bool Remove(T item);
        public abstract bool Remove(T item, object tag);
        public abstract bool RemoveAll(T item);
        public abstract bool RemoveAll(T item, object tag);
        public abstract void RemoveAt(int index);

        public void AddLazy(Func<T> item)
        {
            this.AddLazy(LazyValue.Create(item));
        }
        public void AddLazy<TContext>(Func<TContext, T> item)
            where TContext: MutableObject
        {
            this.AddLazy(LazyValue.Create(item));
        }
        public void AddRangeLazy(IEnumerable<Func<T>> items)
        {
            this.AddRangeLazy(items.Select(f => LazyValue.Create(f)));
        }
        public void AddRangeLazy(Func<IEnumerable<T>> items)
        {
            this.AddLazy(LazyValue.CreateMulti(items));
        }
        public void AddRangeLazy<TContext>(Func<TContext, IEnumerable<T>> items)
            where TContext : MutableObject
        {
            this.AddLazy(LazyValue.CreateMulti(items));
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal static MutableModelList<T> FromGreenList(MutableObjectBase obj, Slot slot)
        {
            if (slot.IsCollection) return new MutableModelListFromGreenList<T>(obj, slot);
            else return new MutableModelListFromGreenSingle<T>(obj, slot);
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class MutableModelListFromGreenList<T> : MutableModelList<T>
    {
        private MutableObjectBase obj;
        private Slot slot;

        internal MutableModelListFromGreenList(MutableObjectBase obj, Slot slot)
        {
            this.obj = obj;
            this.slot = slot;
        }

        public override bool IsUnique => this.slot.IsUnique;

        private GreenList GetGreen(bool lazyEval)
        {
            return this.obj.MModel.GetGreenList(this.obj.MId, slot.EffectiveProperty, lazyEval);
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
            get { return this.obj.MIsReadOnly || this.slot.IsReadonly; }
        }

        public override T this[int index]
        {
            get
            {
                GreenList green = this.GetGreen(false);
                return (T)this.obj.MModel.ToRedValue(green[index], this.obj.MId, null);
            }
            set
            {
                this.obj.MModel.ReplaceItem(this.obj.MId, this.slot.EffectiveProperty, index, value, null, this.obj.MIsBeingCreated);
            }
        }

        public override void Add(T item)
        {
            this.Add(item, null);
        }

        public override void Add(T item, object tag)
        {
            this.obj.MModel.AddItem(this.obj.MId, this.slot.EffectiveProperty, item, tag, this.obj.MIsBeingCreated);
        }

        public override void AddRange(IEnumerable<T> items)
        {
            this.AddRange(items, null);
        }

        public override void AddRange(IEnumerable<T> items, object tag)
        {
            foreach (var item in items)
            {
                this.Add(item, tag);
            }
        }

        public override void AddLazy(LazyValue<T> item)
        {
            this.obj.MModel.AddLazyItem(this.obj.MId, this.slot.EffectiveProperty, item, this.obj.MIsBeingCreated);
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
            this.obj.MModel.ClearItems(this.obj.MId, this.slot.EffectiveProperty, this.obj.MIsBeingCreated);
        }

        public override void ClearLazy()
        {
            this.obj.MModel.ClearLazyItems(this.obj.MId, this.slot.EffectiveProperty, this.obj.MIsBeingCreated);
        }

        public override bool Contains(T item)
        {
            return this.Contains(item, null);
        }

        public override bool Contains(T item, object tag)
        {
            GreenList green = this.GetGreen(true);
            object greenItem = MutableModel.ToGreenValue(item, tag);
            return green.Contains(greenItem);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            MutableModel model = this.obj.MModel;
            GreenList green = this.GetGreen(true);
            for (int i = 0; i < green.Count && arrayIndex + i < array.Length; i++)
            {
                array[arrayIndex + i] = (T)model.ToRedValue(green[i], this.obj.MId, null);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            MutableModel model = this.obj.MModel;
            GreenList green = this.GetGreen(true);
            foreach (var greenValue in green)
            {
                yield return (T)model.ToRedValue(greenValue, this.obj.MId, null);
            }
        }

        public override int IndexOf(T item)
        {
            return this.IndexOf(item, null);
        }

        public override int IndexOf(T item, object tag)
        {
            GreenList green = this.GetGreen(true);
            object greenItem = MutableModel.ToGreenValue(item, tag);
            return green.IndexOf(greenItem);
        }

        public override object GetTagOf(T item)
        {
            var index = this.IndexOf(item);
            if (index < 0) return null;
            else return this.GetTagAt(index);
        }

        public override object GetTagAt(int index)
        {
            var green = this.GetGreen(false);
            var value = green[index];
            return GreenObject.ExtractTag(value);
        }

        public override void Insert(int index, T item)
        {
            this.Insert(index, item, null);
        }

        public override void Insert(int index, T item, object tag)
        {
            this.obj.MModel.InsertItem(this.obj.MId, this.slot.EffectiveProperty, index, item, tag, this.obj.MIsBeingCreated);
        }

        public override bool Remove(T item)
        {
            return this.Remove(item, null);
        }

        public override bool Remove(T item, object tag)
        {
            return this.obj.MModel.RemoveItem(this.obj.MId, this.slot.EffectiveProperty, item, tag, this.obj.MIsBeingCreated);
        }

        public override bool RemoveAll(T item)
        {
            return this.RemoveAll(item, null);
        }

        public override bool RemoveAll(T item, object tag)
        {
            return this.obj.MModel.RemoveAllItems(this.obj.MId, this.slot.EffectiveProperty, item, tag, this.obj.MIsBeingCreated);
        }

        public override void RemoveAt(int index)
        {
            this.obj.MModel.RemoveItemAt(this.obj.MId, this.slot.EffectiveProperty, index, this.obj.MIsBeingCreated);
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
    internal class MutableModelListFromGreenSingle<T> : MutableModelList<T>
    {
        private MutableObjectBase obj;
        private Slot slot;

        internal MutableModelListFromGreenSingle(MutableObjectBase obj, Slot slot)
        {
            this.obj = obj;
            this.slot = slot;
        }

        public override bool IsUnique => slot.IsUnique;

        public override T this[int index]
        {
            get
            {
                if (index == 0) return this.GetRed(true);
                else throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
            }
            set
            {
                if (index == 0) this.obj.MModel.SetValue<T>(this.obj.MId, this.slot.EffectiveProperty, value, null, this.obj.MIsBeingCreated);
                else throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
            }
        }

        public bool HasValue => !this.obj.MModel.MHasDefaultValue(this.obj.MId, this.slot.EffectiveProperty);
        public bool HasLazyValue => this.obj.MModel.GetLazyValue(this.obj.MId, this.slot.EffectiveProperty) != null;

        private bool HasKnownValue(T value, object tag)
        {
            object green = this.GetGreen(true);
            object greenItem = MutableModel.ToGreenValue(value, tag);
            return GreenObject.Equals(green, greenItem);
        }

        private T GetRed(bool lazyEval)
        {
            return (T)this.obj.MModel.GetValue(this.obj.MId, this.slot.EffectiveProperty);
        }

        private object GetGreen(bool lazyEval)
        {
            var redValue = this.obj.MModel.GetValue(this.obj.MId, this.slot.EffectiveProperty);
            var tag = this.obj.MModel.MGetTag(this.obj, this.slot.EffectiveProperty);
            return MutableModel.ToGreenValue(redValue, tag);
        }

        public override int Count
        {
            get { return this.HasValue ? 1 : 0; }
        }

        public override int LazyCount
        {
            get { return this.HasLazyValue ? 1 : 0; }
        }

        public override bool IsReadOnly
        {
            get { return this.obj.MIsReadOnly || this.slot.IsReadonly; }
        }

        public override void Add(T item)
        {
            this.Add(item, null);
        }

        public override void Add(T item, object tag)
        {
            if (this.HasValue && !this.HasKnownValue(item, tag)) throw new ModelException(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty.ToDiagnostic(GreenObject.ExtractLocation(tag), this.slot, this.obj));
            this.obj.MModel.SetValue<T>(this.obj.MId, this.slot.EffectiveProperty, item, tag, this.obj.MIsBeingCreated);
        }

        public override void AddRange(IEnumerable<T> items)
        {
            this.AddRange(items, null);
        }

        public override void AddRange(IEnumerable<T> items, object tag)
        {
            foreach (var item in items)
            {
                this.Add(item, tag);
            }
        }

        public override void AddLazy(LazyValue<T> item)
        {
            if (this.HasLazyValue) throw new ModelException(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty.ToDiagnostic(GreenObject.ExtractLocation(item.Tag), this.slot, this.obj));
            this.obj.MModel.AddLazyItem(this.obj.MId, this.slot.EffectiveProperty, item, this.obj.MIsBeingCreated);
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
            this.obj.MModel.SetValue(this.obj.MId, this.slot.EffectiveProperty, GreenObject.Unassigned, null, this.obj.MIsBeingCreated);
        }

        public override void ClearLazy()
        {
            this.obj.MModel.SetValue(this.obj.MId, this.slot.EffectiveProperty, GreenObject.Unassigned, null, this.obj.MIsBeingCreated);
        }

        public override bool Contains(T item)
        {
            return this.Contains(item, null);
        }

        public override bool Contains(T item, object tag)
        {
            return this.HasKnownValue(item, tag);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex == 0 && array.Length >= 1)
            {
                array[0] = this.GetRed(true);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            if (this.HasValue)
            {
                yield return this.GetRed(true);
            }
            else
            {
                yield break;
            }
        }

        public override int IndexOf(T item)
        {
            return this.IndexOf(item, null);
        }

        public override int IndexOf(T item, object tag)
        {
            if (this.HasKnownValue(item, tag)) return 0;
            else return -1;
        }

        public override object GetTagOf(T item)
        {
            var index = this.IndexOf(item);
            if (index < 0) return null;
            else return this.GetTagAt(index);
        }

        public override object GetTagAt(int index)
        {
            if (index != 0) throw new ArgumentOutOfRangeException(nameof(index));
            var value = this.GetGreen(false);
            return GreenObject.ExtractTag(value);
        }

        public override void Insert(int index, T item)
        {
            this.Insert(index, item, null);
        }

        public override void Insert(int index, T item, object tag)
        {
            if (index != 0) throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
            if (!this.HasValue)
            {
                this.obj.MModel.SetValue<T>(this.obj.MId, this.slot.EffectiveProperty, item, tag, this.obj.MIsBeingCreated);
            }
            else if (!this.HasKnownValue(item, tag))
            {
                throw new ModelException(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty.ToDiagnostic(GreenObject.ExtractLocation(tag), this.slot, this.obj));
            }
        }

        public override bool Remove(T item)
        {
            return this.Remove(item, null);
        }

        public override bool Remove(T item, object tag)
        {
            if (this.HasValue && this.HasKnownValue(item, tag))
            {
                this.obj.MModel.SetValue(this.obj.MId, this.slot.EffectiveProperty, GreenObject.Unassigned, tag, this.obj.MIsBeingCreated);
                return true;
            }
            return false;
        }

        public override bool RemoveAll(T item)
        {
            return this.RemoveAll(item, null);
        }

        public override bool RemoveAll(T item, object tag)
        {
            return this.Remove(item, tag);
        }

        public override void RemoveAt(int index)
        {
            if (index != 0) throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
            this.obj.MModel.SetValue(this.obj.MId, this.slot.EffectiveProperty, GreenObject.Unassigned, null, this.obj.MIsBeingCreated);
        }

        private string DebuggerDisplay
        {
            get
            {
                if (this.HasValue) return "Count = 1";
                else if (this.HasLazyValue) return "Count = 0, LazyCount = 1";
                else return "Count = 0";
            }
        }
    }

}
