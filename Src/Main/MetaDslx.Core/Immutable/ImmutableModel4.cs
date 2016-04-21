using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable4
{
    internal delegate void InvalidatePropertyDelegate(GreenSymbol symbol, ModelProperty property);

    public abstract class GreenSymbol
    {
        public abstract ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model);
        public abstract MutableRedSymbol CreateMutableRed(MutableRedModel model);
    }

    internal sealed class GreenLazyItem
    {
        private Func<object> lazy;

        internal GreenLazyItem(Func<object> lazy)
        {
            this.lazy = lazy;
        }

        public object CreateValue(ImmutableRedModel model)
        {
            object value = lazy();
            if (value is GreenLazyItem)
            {
                return ((GreenLazyItem)value).CreateValue(model);
            }
            else if (value is GreenLazySymbol)
            {
                return ((GreenLazySymbol)value).CreateImmutableRed(model);
            }
            else if (value is GreenSymbol)
            {
                return model.GetRedSymbol((GreenSymbol)value);
            }
            else if (value is RedSymbolBase)
            {
                return model.GetRedSymbol(((RedSymbolBase)value).Green);
            }
            return value;
        }

        public object CreateValue(MutableRedModel model)
        {
            object value = lazy();
            if (value is GreenLazyItem)
            {
                return ((GreenLazyItem)value).CreateValue(model);
            }
            else if (value is GreenLazySymbol)
            {
                return ((GreenLazySymbol)value).CreateMutableRed(model);
            }
            else if(value is GreenSymbol)
            {
                return model.GetRedSymbol((GreenSymbol)value);
            }
            else if (value is RedSymbolBase)
            {
                return model.GetRedSymbol(((RedSymbolBase)value).Green);
            }
            return value;
        }
    }

    internal sealed class GreenLazySymbol : GreenSymbol
    {
        private Func<object> lazy;

        internal GreenLazySymbol(Func<object> lazy)
        {
            this.lazy = lazy;
        }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            object value = lazy();
            if (value is GreenLazyItem)
            {
                return ((GreenLazyItem)value).CreateValue(model) as ImmutableRedSymbol;
            }
            else if (value is GreenLazySymbol)
            {
                return ((GreenLazySymbol)value).CreateImmutableRed(model);
            }
            else if(value is GreenSymbol)
            {
                return model.GetRedSymbol((GreenSymbol)value);
            }
            else if (value is RedSymbolBase)
            {
                return model.GetRedSymbol(((RedSymbolBase)value).Green);
            }
            return null;
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            object value = lazy();
            if (value is GreenLazyItem)
            {
                return ((GreenLazyItem)value).CreateValue(model) as MutableRedSymbol;
            }
            else if (value is GreenLazySymbol)
            {
                return ((GreenLazySymbol)value).CreateMutableRed(model);
            }
            else if (value is GreenSymbol)
            {
                return model.GetRedSymbol((GreenSymbol)value);
            }
            else if (value is RedSymbolBase)
            {
                return model.GetRedSymbol(((RedSymbolBase)value).Green);
            }
            return null;
        }
    }

    public interface RedSymbol
    {
    }

    public interface ImmutableModelList<out T> : IReadOnlyList<T>
    {

    }

    public interface ModelList<T> : IList<T>
    {
        void AddLazy(Func<T> lazy);
    }

    public abstract class RedSymbolBase : RedSymbol
    {
        private GreenSymbol green;
        private RedModel model;

        public RedSymbolBase(GreenSymbol green, RedModel model)
        {
            this.green = green;
            this.model = model;
        }

        internal GreenSymbol Green { get { return this.green; } }
        public RedModel Model { get { return this.model; } }
    }

    // thread-safe
    public class ImmutableRedSymbol : RedSymbolBase
    {
        public ImmutableRedSymbol(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public new ImmutableRedModel Model { get { return (ImmutableRedModel)base.Model; } }

        public T GetValue<T>(ModelProperty property, ref T value)
            where T : class
        {
            T result = value;
            if (result == null)
            {
                result = (T)this.Model.GetValue(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public ImmutableRedValueList<T> GetValueList<T>(ModelProperty property, ref ImmutableRedValueList<T> value)
        {
            ImmutableRedValueList<T> result = value;
            if (result == null)
            {
                ImmutableRedValueList wrapped = this.Model.GetValue(this, property) as ImmutableRedValueList;
                if (wrapped != null)
                {
                    result = new ImmutableRedValueList<T>(wrapped);
                    result = Interlocked.CompareExchange(ref value, result, null) ?? result;
                }
            }
            return result;
        }

        public ImmutableRedSymbolList<T> GetSymbolList<T>(ModelProperty property, ref ImmutableRedSymbolList<T> value)
            where T : class
        {
            ImmutableRedSymbolList<T> result = value;
            if (result == null)
            {
                ImmutableRedSymbolList wrapped = this.Model.GetValue(this, property) as ImmutableRedSymbolList; 
                if (wrapped != null)
                {
                    result = new ImmutableRedSymbolList<T>(wrapped);
                    result = Interlocked.CompareExchange(ref value, result, null) ?? result;
                }
            }
            return result;
        }
    }

    // NOT thread-safe
    public class MutableRedSymbol : RedSymbolBase
    {
        internal HashSet<ModelProperty> invalidatedProperties;

        public MutableRedSymbol(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
        }

        public new MutableRedModel Model { get { return (MutableRedModel)base.Model; } }

        internal void InvalidateProperty(ModelProperty property)
        {
            if (this.invalidatedProperties == null)
            {
                this.invalidatedProperties = new HashSet<ModelProperty>();
            }
            this.invalidatedProperties.Add(property);
        }

        private bool ClearInvalidatedProperty(ModelProperty property)
        {
            if (this.invalidatedProperties != null && this.invalidatedProperties.Contains(property))
            {
                this.invalidatedProperties.Remove(property);
                return true;
            }
            return false;
        }

        public T GetValue<T>(ModelProperty property, ref T value)
            where T : class
        {
            if (this.ClearInvalidatedProperty(property))
            {
                Interlocked.Exchange(ref value, null);
            }
            T result = value;
            if (result == null)
            {
                result = (T)this.Model.GetValue(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public MutableRedValueList<T> GetValueList<T>(ModelProperty property, ref MutableRedValueList<T> value)
        {
            MutableRedValueList<T> result = value;
            if (result == null)
            {
                MutableRedValueList wrapped = this.Model.GetValue(this, property) as MutableRedValueList;
                if (wrapped != null)
                {
                    result = new MutableRedValueList<T>(wrapped);
                    result = Interlocked.CompareExchange(ref value, result, null) ?? result;
                }
            }
            if (this.ClearInvalidatedProperty(property) && result != null)
            {
                this.Model.UpdateList(this, property, result.Wrapped);
            }
            return result;
        }

        public MutableRedSymbolList<T> GetSymbolList<T>(ModelProperty property, ref MutableRedSymbolList<T> value)
            where T : class, RedSymbol
        {
            MutableRedSymbolList<T> result = value;
            if (result == null)
            {
                MutableRedSymbolList wrapped = this.Model.GetValue(this, property) as MutableRedSymbolList;
                if (wrapped != null)
                {
                    result = new MutableRedSymbolList<T>(wrapped);
                    result = Interlocked.CompareExchange(ref value, result, null) ?? result;
                }
            }
            if (this.ClearInvalidatedProperty(property) && result != null)
            {
                this.Model.UpdateList(this, property, result.Wrapped);
            }
            return result;
        }

        public bool SetValue<T>(ModelProperty property, ref T value, T newValue)
            where T : class
        {
            T oldValue = value;
            if (Interlocked.Exchange(ref value, newValue) != oldValue)
            {
                this.Model.SetValue(this, property, value);
                this.ClearInvalidatedProperty(property);
                return true;
            }
            return false;
        }

        public bool SetLazyValue<T>(ModelProperty property, Func<T> value)
            where T : class
        {
            this.Model.SetLazyValue(this, property, value);
            this.ClearInvalidatedProperty(property);
            return true;
        }
        //protected abstract void ClearCachedValue(ModelProperty property);
    }

    public abstract class GreenList
    {
        private GreenSymbol parent;
        private ModelProperty property;
        private bool allowMultipleItems;

        internal GreenList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
        {
            this.parent = parent;
            this.property = property;
            this.allowMultipleItems = allowMultipleItems;
        }

        public GreenSymbol Parent { get { return this.parent; } }
        public ModelProperty Property { get { return this.property; } }
        public bool AllowMultipleItems { get { return this.allowMultipleItems; } }
    }

    // NOT thread-safe
    public sealed class GreenValueList : GreenList, IReadOnlyList<object>, ICloneable
    {
        private List<object> items;

        internal GreenValueList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
            : base(parent, property, allowMultipleItems)
        {
            this.items = new List<object>();
        }

        internal GreenValueList(GreenValueList other)
            : base(other.Parent, other.Property, other.AllowMultipleItems)
        {
            this.items = new List<object>(other.items);
        }

        internal bool Add(object item)
        {
            if (this.AllowMultipleItems || !this.items.Contains(item))
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

        public int Count
        {
            get { return this.items.Count; }
        }

        public object this[int index]
        {
            get{ return this.items[index]; }
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            return new GreenValueList(this);
        }
    }

    public abstract class RedValueList : IReadOnlyList<object>
    {
        private GreenValueList green;
        private RedModel model;

        internal RedValueList(GreenValueList green, RedModel model)
        {
            this.green = green;
            this.model = model;
        }

        internal GreenValueList Green
        {
            get { return this.green; }
        }

        internal virtual void SetGreen(GreenValueList green)
        {
            Interlocked.Exchange(ref this.green, green);
        }

        public RedModel Model { get { return this.model; } }

        public abstract int Count { get; }

        public abstract object this[int index] { get; }

        public abstract IEnumerator<object> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


    // thread-safe
    public sealed class ImmutableRedValueList : RedValueList
    {
        private List<object> cachedItems = null;

        internal ImmutableRedValueList(GreenValueList green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public new ImmutableRedModel Model { get { return (ImmutableRedModel)base.Model; } }

        public override object this[int index]
        {
            get
            {
                this.CacheItems();
                return this.cachedItems[index];
            }
        }

        public override int Count
        {
            get
            {
                this.CacheItems();
                return this.cachedItems.Count;
            }
        }

        public override IEnumerator<object> GetEnumerator()
        {
            this.CacheItems();
            return this.cachedItems.GetEnumerator();
        }

        internal void CacheItems()
        {
            if (this.cachedItems != null) return;
            this.Model.CreateListItems(this, ref this.cachedItems);
        }

    }

    public sealed class ImmutableRedValueList<T> : ImmutableModelList<T>
    {
        private ImmutableRedValueList wrapped;

        internal ImmutableRedValueList(ImmutableRedValueList wrapped)
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
    public sealed class MutableRedValueList : RedValueList
    {
        private List<object> cachedItems = null;

        internal MutableRedValueList(GreenValueList green, MutableRedModel model)
            : base(green, model)
        {
        }

        public new MutableRedModel Model { get { return (MutableRedModel)base.Model; } }

        internal override void SetGreen(GreenValueList green)
        {
            base.SetGreen(green);
            this.Invalidate();
        }

        internal void Invalidate()
        {
            Interlocked.Exchange(ref this.cachedItems, null);
        }

        public bool Add(object value)
        {
            return this.Model.AddListItem(this, value);
        }

        public bool AddLazy(Func<object> lazy)
        {
            return this.Model.AddListItem(this, new GreenLazyItem(lazy));
        }

        public bool Remove(object value)
        {
            return this.Model.RemoveListItem(this, value);
        }

        public override object this[int index]
        {
            get
            {
                this.CacheItems();
                return this.cachedItems[index];
            }
        }

        public override int Count
        {
            get
            {
                this.CacheItems();
                return this.cachedItems.Count;
            }
        }

        public void Clear()
        {
            this.Model.ClearList(this);
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

        public override IEnumerator<object> GetEnumerator()
        {
            this.CacheItems();
            return this.cachedItems.GetEnumerator();
        }

        internal void CacheItems()
        {
            if (this.cachedItems != null) return;
            this.Model.CreateListItems(this, ref this.cachedItems);
        }
    }

    public sealed class MutableRedValueList<T> : ModelList<T>
    {
        private MutableRedValueList wrapped;

        internal MutableRedValueList(MutableRedValueList wrapped)
        {
            this.wrapped = wrapped;
        }

        internal MutableRedValueList Wrapped { get { return this.wrapped; } }

        public T this[int index]
        {
            get
            {
                return (T)this.wrapped[index];
            }

            set
            {
                this.RemoveAt(index);
                this.Insert(index, value);
            }
        }

        public int Count
        {
            get
            {
                return this.wrapped.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            this.wrapped.Add(item);
        }

        public void AddLazy(Func<T> lazy)
        {
            this.wrapped.AddLazy(() => lazy());
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
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (arrayIndex + this.wrapped.Count > array.Length) throw new ArgumentException("Not enough space in array.");
            for (int i = 0; i < this.wrapped.Count; i++)
            {
                array[arrayIndex + i] = this[i];
            }
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


    // NOT thread-safe
    public class GreenSymbolList : GreenList, IReadOnlyList<GreenSymbol>
    {
        private List<GreenSymbol> items;

        internal GreenSymbolList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
            : base(parent, property, allowMultipleItems)
        {
            this.items = new List<GreenSymbol>();
        }

        internal GreenSymbolList(GreenSymbolList other)
            : base(other.Parent, other.Property, other.AllowMultipleItems)
        {
            this.items = new List<GreenSymbol>(other.items);
        }

        internal bool Add(GreenSymbol item)
        {
            if (this.AllowMultipleItems || !this.items.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            return false;
        }

        internal bool Remove(GreenSymbol item)
        {
            return this.items.Remove(item);
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public GreenSymbol this[int index]
        {
            get { return this.items[index]; }
        }

        public IEnumerator<GreenSymbol> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public abstract class RedSymbolList 
    {
        private GreenSymbolList green;
        private RedModel model;

        public RedSymbolList(GreenSymbolList green, RedModel model)
        {
            this.green = green;
            this.model = model;
        }

        public GreenSymbolList Green { get { return this.green; } }
        public RedModel Model { get { return this.model; } }

        internal virtual void SetGreen(GreenSymbolList green)
        {
            Interlocked.Exchange(ref this.green, green);
        }
    }

    // thread-safe
    public class ImmutableRedSymbolList : RedSymbolList, IReadOnlyList<ImmutableRedSymbol>
    {
        private List<ImmutableRedSymbol> cachedItems;

        public ImmutableRedSymbolList(GreenSymbolList green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public new ImmutableRedModel Model { get { return (ImmutableRedModel)base.Model; } }

        public ImmutableRedSymbol this[int index]
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

        public IEnumerator<ImmutableRedSymbol> GetEnumerator()
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
            this.Model.CreateListItems(this, ref this.cachedItems);
        }
    }

    public class ImmutableRedSymbolList<T> : ImmutableModelList<T>
        where T : class
    {
        private ImmutableRedSymbolList wrapped;

        public ImmutableRedSymbolList(ImmutableRedSymbolList wrapped)
        {
            this.wrapped = wrapped;
        }

        public T this[int index]
        {
            get
            {
                return (T)(object)this.wrapped[index];
            }
        }

        public int Count
        {
            get
            {
                return this.wrapped.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.wrapped)
            {
                yield return (T)(object)item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    // NOT thread-safe
    public class MutableRedSymbolList : RedSymbolList, IReadOnlyList<MutableRedSymbol>
    {
        private List<MutableRedSymbol> cachedItems;

        public MutableRedSymbolList(GreenSymbolList green, MutableRedModel model)
            : base(green, model)
        {
        }

        public new MutableRedModel Model { get { return (MutableRedModel)base.Model; } }

        internal override void SetGreen(GreenSymbolList green)
        {
            base.SetGreen(green);
            this.Invalidate();
        }

        internal void Invalidate()
        {
            Interlocked.Exchange(ref this.cachedItems, null);
        }

        public bool Add(RedSymbol value)
        {
            if (value == null) return false;
            return this.Model.AddListItem(this, value);
        }

        public bool AddLazy(Func<RedSymbol> lazy)
        {
            if (lazy == null) return false;
            return this.Model.AddListItem(this, new GreenLazySymbol(lazy));
        }

        public bool Remove(RedSymbol value)
        {
            if (value == null) return false;
            return this.Model.RemoveListItem(this, value);
        }

        public MutableRedSymbol this[int index]
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

        public void Clear()
        {
            this.Model.ClearList(this);
        }

        public bool Contains(RedSymbol item)
        {
            if (item == null) return false;
            this.CacheItems();
            MutableRedSymbol symbol = this.Model.ToRedSymbol(((RedSymbolBase)item).Green);
            return this.cachedItems.Contains(symbol);
        }

        public int IndexOf(RedSymbol item)
        {
            if (item == null) return -1;
            this.CacheItems();
            MutableRedSymbol symbol = this.Model.ToRedSymbol(((RedSymbolBase)item).Green);
            return this.cachedItems.IndexOf(symbol);
        }

        public void Insert(int index, RedSymbol item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public IEnumerator<MutableRedSymbol> GetEnumerator()
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
            this.Model.CreateListItems(this, ref this.cachedItems);
        }
    }

    public class MutableRedSymbolList<T> : ModelList<T>
        where T : class, RedSymbol
    {
        private MutableRedSymbolList wrapped;

        public MutableRedSymbolList(MutableRedSymbolList wrapped)
        {
            this.wrapped = wrapped;
        }

        internal MutableRedSymbolList Wrapped { get { return this.wrapped; } }

        public T this[int index]
        {
            get
            {
                return (T)(object)this.wrapped[index];
            }

            set
            {
                this.RemoveAt(index);
                this.Insert(index, value);
            }
        }

        public int Count
        {
            get
            {
                return this.wrapped.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            this.wrapped.Add(item);
        }

        public void AddLazy(Func<T> lazy)
        {
            this.wrapped.AddLazy(lazy);
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
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (arrayIndex + this.wrapped.Count > array.Length) throw new ArgumentException("Not enough space in array.");
            for (int i = 0; i < this.wrapped.Count; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.wrapped)
            {
                yield return (T)(object)item;
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

    // thread-safe
    internal class GreenModel
    {
        private static readonly IReadOnlyList<GreenSymbol> emptySymbolList = new List<GreenSymbol>();
        protected Dictionary<GreenSymbol, GreenSymbolEntry> symbols;

        internal GreenModel()
        {
        }

        internal GreenModel(Dictionary<GreenSymbol, GreenSymbolEntry> symbols)
        {
            this.symbols = symbols;
        }

        internal virtual GreenModelTransaction BeginTransaction(MutableRedModel model)
        {
            return new GreenModelTransaction(this, model);
        }

        internal virtual bool ContainsSymbol(GreenSymbol symbol)
        {
            if (this.symbols == null) return false;
            return this.symbols.ContainsKey(symbol);
        }

        internal virtual IEnumerable<GreenSymbol> GetSymbols()
        {
            if (this.symbols == null) return GreenModel.emptySymbolList;
            return this.symbols.Keys;
        }

        internal virtual Dictionary<GreenSymbol, GreenSymbolEntry> CloneSymbols()
        {
            if (this.symbols == null) return null;
            else return this.symbols.ToDictionary(entry => entry.Key, entry => (GreenSymbolEntry)null);
        }

        internal virtual Dictionary<GreenSymbol, GreenSymbolEntry> CloneSymbolsWithEntries()
        {
            if (this.symbols == null) return null;
            else return new Dictionary<GreenSymbol, GreenSymbolEntry>(this.symbols);
        }

        internal virtual Dictionary<GreenSymbol, GreenSymbolEntry> DeepCloneSymbolsWithEntries()
        {
            if (this.symbols == null) return null;
            else return this.symbols.ToDictionary(entry => entry.Key, entry => entry.Value?.Clone());
        }

        internal virtual GreenSymbolEntry GetEntry(GreenSymbol symbol, bool forWriting, bool createIfNotExists)
        {
            if (this.symbols == null) return null;
            GreenSymbolEntry entry;
            if (this.symbols.TryGetValue(symbol, out entry))
            {
                return entry;
            }
            return null;
        }

        internal virtual bool HasValue(GreenSymbol symbol, ModelProperty property)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            object storedValue;
            return this.TryGetValue(symbol, property, false, out storedValue);
        }

        internal virtual bool HasValue(GreenSymbol symbol, ModelProperty property, object value)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            object storedValue;
            if (this.TryGetValue(symbol, property, false, out storedValue))
            {
                return value == storedValue;
            }
            return false;
        }

        internal virtual object GetValue(GreenSymbol symbol, ModelProperty property)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            object value;
            if (this.TryGetValue(symbol, property, true, out value))
            {
                return value;
            }
            return null;
        }

        internal virtual bool TryGetValue(GreenSymbol symbol, ModelProperty property, bool forWriting, out object value)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            GreenSymbolEntry entry = this.GetEntry(symbol, forWriting, false);
            value = null;
            if (entry != null && entry.properties != null && entry.properties.TryGetValue(property, out value))
            {
                return true;
            }
            return false;
        }

        internal class GreenSymbolEntry 
        {
            internal Dictionary<ModelProperty, object> properties;
            internal Dictionary<GreenSymbol, HashSet<ModelProperty>> containers;

            public GreenSymbolEntry()
            {
            }

            public GreenSymbolEntry(GreenSymbolEntry other)
            {
                this.properties = other.properties != null ?
                    other.properties.ToDictionary(entry => entry.Key, 
                        entry => entry.Value is GreenSymbolList ? new GreenSymbolList((GreenSymbolList)entry.Value) : 
                                 entry.Value is GreenValueList ? new GreenValueList((GreenValueList)entry.Value) : 
                                 entry.Value)
                    : null;
                this.containers = other.containers != null ? other.containers.ToDictionary(entry => entry.Key, entry => new HashSet<ModelProperty>(entry.Value)) : null;
            }

            public GreenSymbolEntry Clone()
            {
                return new GreenSymbolEntry(this);
            }

            public void CreateProperties()
            {
                if (this.properties == null)
                {
                    this.properties = new Dictionary<ModelProperty, object>();
                }
            }

            public void CreateContainers()
            {
                if (this.containers == null)
                {
                    this.containers = new Dictionary<GreenSymbol, HashSet<ModelProperty>>();
                }
            }
        }
    }

    // NOT thread-safe
    internal class GreenModelTransaction : GreenModel
    {
        private GreenModel baseModel;
        private MutableRedModel redModel;
        // TODO: weak reference
        private Dictionary<GreenSymbol, MutableRedSymbol> redSymbols;
        private Dictionary<GreenLazyItem, object> lazyItems;
        private bool allowLazyEval = false;

        internal GreenModelTransaction(GreenModel baseModel, MutableRedModel redModel)
        {
            Debug.Assert(baseModel != null);
            Debug.Assert(redModel != null);
            this.baseModel = baseModel;
            this.redModel = redModel;
            this.redSymbols = null;
            this.lazyItems = null;
        }

        internal GreenModelTransaction(GreenModelTransaction baseTransaction, MutableRedModel redModel)
        {
            Debug.Assert(baseModel != null);
            Debug.Assert(redModel != null);
            this.baseModel = baseTransaction;
            this.redModel = redModel;
            this.allowLazyEval = baseTransaction.allowLazyEval;
            this.redSymbols = null;
            this.lazyItems = null;
        }

        internal GreenModel BaseModel { get { return this.baseModel; } }
        internal GreenModelTransaction ParentTransaction { get { return this.baseModel as GreenModelTransaction; } }

        public bool IsChanged
        {
            get
            {
                return this.symbols != null && (!this.ParentTransaction?.IsChanged ?? false);
            }
        }

        internal void CloneBaseModel()
        {
            if (this.symbols != null) return;
            this.symbols = this.baseModel.CloneSymbols();
        }

        internal override GreenModelTransaction BeginTransaction(MutableRedModel model)
        {
            return new GreenModelTransaction(this, model);
        }

        internal bool TryGetRedSymbol(GreenSymbol green, out MutableRedSymbol red)
        {
            if (this.redSymbols != null && this.redSymbols.TryGetValue(green, out red))
            {
                return true;
            }
            if (this.ParentTransaction != null && this.ParentTransaction.TryGetRedSymbol(green, out red))
            {
                return true;
            }
            red = null;
            return false;
        }

        internal MutableRedSymbol GetRedSymbol(GreenSymbol green)
        {
            if (!(green is GreenLazySymbol) && !this.ContainsSymbol(green))
            {
                return null;
            }
            MutableRedSymbol red;
            if (this.TryGetRedSymbol(green, out red))
            {
                return red;
            }
            if (green is GreenLazySymbol && !this.allowLazyEval)
            {
                return null;
            }
            red = green.CreateMutableRed(this.redModel);
            if (red != null)
            {
                if (this.redSymbols == null) this.redSymbols = new Dictionary<GreenSymbol, MutableRedSymbol>();
                this.redSymbols.Add(green, red);
            }
            return red;
        }

        internal override GreenSymbolEntry GetEntry(GreenSymbol symbol, bool forWriting, bool createIfNotExists)
        {
            if (forWriting)
            {
                this.CloneBaseModel();
            }
            GreenSymbolEntry entry = null;
            if (this.symbols != null && this.symbols.TryGetValue(symbol, out entry))
            {
                if (entry != null)
                {
                    return entry;
                }
            }
            GreenSymbolEntry baseEntry = this.baseModel.GetEntry(symbol, false, false);
            if (forWriting)
            {
                if (baseEntry != null)
                {
                    entry = baseEntry.Clone();
                }
                if (entry == null && createIfNotExists)
                {
                    entry = new GreenSymbolEntry();
                }
                if (entry != null && this.symbols.Keys.Contains(symbol))
                {
                    this.symbols[symbol] = entry;
                }
            }
            else
            {
                entry = baseEntry;
            }
            return entry;
        }

        internal override bool ContainsSymbol(GreenSymbol symbol)
        {
            if (this.symbols != null) return base.ContainsSymbol(symbol);
            else return this.baseModel.ContainsSymbol(symbol);
        }

        internal override IEnumerable<GreenSymbol> GetSymbols()
        {
            if (this.symbols != null) return base.GetSymbols();
            else return this.baseModel.GetSymbols();
        }

        internal override Dictionary<GreenSymbol, GreenSymbolEntry> CloneSymbols()
        {
            if (this.symbols != null) return base.CloneSymbols();
            else return this.baseModel.CloneSymbols();
        }

        internal void AddSymbol(GreenSymbol green)
        {
            if (!(green is GreenLazySymbol) && !this.ContainsSymbol(green))
            {
                this.CloneBaseModel();
                this.symbols.Add(green, new GreenSymbolEntry());
            }
        }

        internal void RemoveSymbol(GreenSymbol green)
        {
            if (!(green is GreenLazySymbol) && this.ContainsSymbol(green))
            {
                this.CloneBaseModel();
                GreenSymbolEntry entry = this.GetEntry(green, false, false);
                this.symbols.Remove(green);
                if (entry != null && entry.containers != null)
                {
                    foreach (var container in entry.containers)
                    {
                        foreach (var containingProperty in container.Value)
                        {
                            this.RemoveValue(container.Key, containingProperty, green);
                        }
                    }
                }
            }
        }

        internal bool TryGetLazyItem(GreenLazyItem lazy, out object value)
        {
            if (this.lazyItems != null && this.lazyItems.TryGetValue(lazy, out value))
            {
                return true;
            }
            if (this.ParentTransaction != null && this.ParentTransaction.TryGetLazyItem(lazy, out value))
            {
                return true;
            }
            value = null;
            return false;
        }

        internal object GetLazyItem(GreenLazyItem lazy)
        {
            object value;
            if (this.TryGetLazyItem(lazy, out value))
            {
                return value;
            }
            if (!this.allowLazyEval) return null;
            value = lazy.CreateValue(this.redModel);
            if (this.lazyItems == null) this.lazyItems = new Dictionary<GreenLazyItem, object>();
            this.lazyItems.Add(lazy, value);
            return value;
        }

        internal bool SetValue(GreenSymbol symbol, ModelProperty property, object value, out object oldValue)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            Debug.Assert(!property.IsCollection || value is GreenValueList || value is GreenSymbolList);
            if (this.TryGetValue(symbol, property, false, out oldValue))
            {
                if (value == oldValue)
                {
                    return false;
                }
            }
            GreenSymbolEntry entry = this.GetEntry(symbol, true, true);
            if (entry != null)
            {
                entry.CreateProperties();
                if (oldValue != null)
                {
                    entry.properties[property] = null;
                    this.RemoveValueFromRelatedProperties(symbol, property, null, oldValue);
                }
                entry.properties[property] = value;
                if (value != null)
                {
                    this.AddValueToRelatedProperties(symbol, property, null, value);
                }
                return true;
            }
            return false;
        }

        internal void ClearList(GreenSymbol symbol, ModelProperty property)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            if (property.IsCollection)
            {
                object collection;
                if (this.TryGetValue(symbol, property, true, out collection))
                {
                    if (collection is GreenValueList)
                    {
                        GreenValueList list = (GreenValueList)collection;
                        var copy = list.ToList();
                        foreach (var item in copy)
                        {
                            list.Remove(item);
                            this.RemoveValueFromRelatedProperties(symbol, property, list, item);
                        }
                    }
                    else if (collection is GreenSymbolList)
                    {
                        GreenSymbolList list = (GreenSymbolList)collection;
                        var copy = list.ToList();
                        foreach (var item in copy)
                        {
                            list.Remove(item);
                            this.RemoveValueFromRelatedProperties(symbol, property, list, item);
                        }
                    }
                    else
                    {
                        throw new ModelException("Property value must be a collection.");
                    }
                }
                else
                {
                    //throw new ModelException("Property value is not set: it must initialized with a collection.");
                }
            }
        }

        internal bool AddValue(GreenSymbol symbol, ModelProperty property, object value)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            if (property.IsCollection)
            {
                object collection;
                if (this.TryGetValue(symbol, property, true, out collection))
                {
                    if (collection is GreenValueList)
                    {
                        GreenValueList list = (GreenValueList)collection;
                        if ((list.AllowMultipleItems || value != null) && list.Add(value))
                        {
                            this.AddValueToRelatedProperties(symbol, property, list, value);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (collection is GreenSymbolList)
                    {
                        GreenSymbolList list = (GreenSymbolList)collection;
                        Debug.Assert(value is GreenSymbol);
                        GreenSymbol valueSymbol = value as GreenSymbol;
                        if (valueSymbol != null && list.Add(valueSymbol))
                        {
                            this.AddValueToRelatedProperties(symbol, property, list, value);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        throw new ModelException("Property value must be a collection.");
                    }
                }
                else
                {
                    throw new ModelException("Property value is not set: it must initialized with a collection.");
                }
            }
            else
            {
                object oldValue;
                return this.SetValue(symbol, property, value, out oldValue);
            }
        }

        internal bool RemoveValue(GreenSymbol symbol, ModelProperty property, object value)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            if (property.IsCollection)
            {
                object collection;
                if (this.TryGetValue(symbol, property, true, out collection))
                {
                    if (collection is GreenValueList)
                    {
                        GreenValueList list = (GreenValueList)collection;
                        if ((list.AllowMultipleItems || value != null) && list.Remove(value))
                        {
                            this.RemoveValueFromRelatedProperties(symbol, property, list, value);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (collection is GreenSymbolList)
                    {
                        GreenSymbolList list = (GreenSymbolList)collection;
                        Debug.Assert(value is GreenSymbol);
                        GreenSymbol valueSymbol = value as GreenSymbol;
                        if (valueSymbol != null && list.Remove(valueSymbol))
                        {
                            this.RemoveValueFromRelatedProperties(symbol, property, list, value);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        throw new ModelException("Property value must be a collection.");
                    }
                }
                else
                {
                    //throw new ModelException("Property value is not set: it must initialized with a collection.");
                }
            }
            else
            {
                object oldValue;
                if (this.TryGetValue(symbol, property, false, out oldValue))
                {
                    if (value == oldValue)
                    {
                        return this.SetValue(symbol, property, null, out oldValue);
                    }
                    else
                    {
                        //throw new ModelException("Trying to remove invalid property value.");
                    }
                }
            }
            return false;
        }

        private void AddValueToRelatedProperties(GreenSymbol symbol, ModelProperty property, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, property);
            // TODO: update container
            // TODO: related properties
        }

        private void RemoveValueFromRelatedProperties(GreenSymbol symbol, ModelProperty property, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, property);
            // TODO: update container
            // TODO: related properties
        }

        private void AddValueToOppositeProperty(GreenSymbol symbol, ModelProperty property, ModelProperty oppositeProperty, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, oppositeProperty);
            // TODO
        }

        private void RemoveValueFromOppositeProperty(GreenSymbol symbol, ModelProperty property, ModelProperty oppositeProperty, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, oppositeProperty);
            // TODO
        }

        private void AddValueToRedefiningProperty(GreenSymbol symbol, ModelProperty property, ModelProperty redefiningProperty, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, redefiningProperty);
            // TODO
        }

        private void RemoveValueFromRedefiningProperty(GreenSymbol symbol, ModelProperty property, ModelProperty redefiningProperty, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, redefiningProperty);
            // TODO
        }

        private void AddValueToRedefinedProperty(GreenSymbol symbol, ModelProperty property, ModelProperty redefinedProperty, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, redefinedProperty);
            // TODO
        }

        private void RemoveValueFromRedefinedProperty(GreenSymbol symbol, ModelProperty property, ModelProperty redefinedProperty, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, redefinedProperty);
            // TODO
        }

        private void AddValueToSubsettedProperty(GreenSymbol symbol, ModelProperty property, ModelProperty subsettedProperty, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, subsettedProperty);
            // TODO
        }

        private void RemoveValueFromSubsettingProperty(GreenSymbol symbol, ModelProperty property, ModelProperty subsettingProperty, GreenList list, object value)
        {
            this.redModel.InvalidateProperty(symbol, subsettingProperty);
            // TODO
        }

        internal void Commit(GreenModelTransaction transaction)
        {
            if (transaction.redSymbols != null)
            {
                if (this.redSymbols == null)
                {
                    this.redSymbols = transaction.redSymbols;
                }
                else
                {
                    foreach (var redSymbol in transaction.redSymbols)
                    {
                        this.redSymbols[redSymbol.Key] = redSymbol.Value;
                    }
                }
            }
            if (transaction.lazyItems != null)
            {
                if (this.lazyItems == null)
                {
                    this.lazyItems = transaction.lazyItems;
                }
                else
                {
                    foreach (var lazyItem in transaction.lazyItems)
                    {
                        this.lazyItems[lazyItem.Key] = lazyItem.Value;
                    }
                }
            }
            if (transaction.symbols != null)
            {
                if (this.symbols == null)
                {
                    this.symbols = transaction.symbols;
                }
                else
                {
                    foreach (var symbol in transaction.symbols)
                    {
                        if (symbol.Value != null)
                        {
                            this.symbols[symbol.Key] = symbol.Value;
                        }
                    }
                }
            }
        }

        internal void Rollback(GreenModelTransaction transaction)
        {
            if (transaction.symbols != null)
            {
                foreach (var symbol in transaction.symbols)
                {
                    if (symbol.Value != null)
                    {
                        GreenSymbolEntry entry = symbol.Value;
                        foreach (var prop in entry.properties.Keys)
                        {
                            this.redModel.InvalidateProperty(symbol.Key, prop);
                        }
                    }
                }
            }
        }

        internal GreenModel Fork()
        {
            List<GreenModelTransaction> transactions = new List<GreenModelTransaction>();
            GreenModelTransaction tx = this;
            while(tx != null)
            {
                transactions.Insert(0, tx);
                tx = tx.ParentTransaction;
            }
            GreenModel originalGreenModel = transactions[0].BaseModel;
            if (!this.IsChanged)
            {
                return originalGreenModel;
            }
            Dictionary<GreenSymbol, GreenSymbolEntry> symbols = originalGreenModel.CloneSymbolsWithEntries();
            foreach (var transaction in transactions)
            {
                if (transaction.symbols != null)
                {
                    foreach (var entry in transaction.symbols)
                    {
                        if (entry.Value != null)
                        {
                            symbols[entry.Key] = entry.Value.Clone();
                        }
                    }
                }
            }
            return new GreenModel(symbols);
        }
    }

    // thread-safe
    public abstract class RedModel
    {
        internal RedModel()
        {
        }
    }

    // thread-safe
    public sealed class ImmutableRedModel : RedModel
    {
        private GreenModel green;
        // TODO: weak reference
        private Dictionary<GreenSymbol, ImmutableRedSymbol> symbols;
        private Dictionary<GreenLazyItem, object> lazyItems;

        internal ImmutableRedModel(GreenModel green)
        {
            this.green = green;
            this.symbols = new Dictionary<GreenSymbol, ImmutableRedSymbol>();
            this.lazyItems = new Dictionary<GreenLazyItem, object>();
        }

        public ImmutableRedSymbol GetRedSymbol(GreenSymbol green)
        {
            if (!this.green.ContainsSymbol(green))
            {
                return null;
            }
            ImmutableRedSymbol red;
            lock (this.symbols)
            {
                if (this.symbols.TryGetValue(green, out red))
                {
                    return red;
                }
            }
            red = green.CreateImmutableRed(this);
            lock (this.symbols)
            {
                ImmutableRedSymbol oldRed;
                if (this.symbols.TryGetValue(green, out oldRed))
                {
                    return oldRed;
                }
                else
                {
                    this.symbols.Add(green, red);
                    return red;
                }
            }
        }

        private object GetLazyItem(GreenLazyItem lazy)
        {
            object value;
            lock (this.lazyItems)
            {
                if (this.lazyItems.TryGetValue(lazy, out value))
                {
                    return value;
                }
            }
            value = lazy.CreateValue(this);
            lock (this.lazyItems)
            {
                object oldValue;
                if (this.lazyItems.TryGetValue(lazy, out oldValue))
                {
                    return oldValue;
                }
                else
                {
                    this.lazyItems.Add(lazy, value);
                    return value;
                }
            }
        }
        private ImmutableRedValueList GetRedValueList(GreenValueList green)
        {
            if (!this.green.ContainsSymbol(green.Parent))
            {
                return null;
            }
            return new ImmutableRedValueList(green, this);
        }

        private ImmutableRedSymbolList GetRedSymbolList(GreenSymbolList green)
        {
            if (!this.green.ContainsSymbol(green.Parent))
            {
                return null;
            }
            return new ImmutableRedSymbolList(green, this);
        }

        internal object GetValue(RedSymbolBase symbol, ModelProperty property)
        {
            object greenObject = this.green.GetValue(symbol.Green, property);
            if (greenObject is GreenSymbol)
            {
                return this.GetRedSymbol((GreenSymbol)greenObject);
            }
            else if (greenObject is GreenLazyItem)
            {
                return this.GetLazyItem((GreenLazyItem)greenObject);
            }
            else if (greenObject is GreenValueList)
            {
                return this.GetRedValueList((GreenValueList)greenObject);
            }
            else if (greenObject is GreenSymbolList)
            {
                return this.GetRedSymbolList((GreenSymbolList)greenObject);
            }
            else
            {
                return greenObject;
            }
        }

        internal void CreateListItems(RedValueList list, ref List<object> items)
        {
            bool allowMultipleItems = list.Green.AllowMultipleItems;
            List<object> result = new List<object>();
            foreach (var greenObject in list.Green)
            {
                object redObject = greenObject;
                if (greenObject is GreenSymbol)
                {
                    redObject = this.GetRedSymbol((GreenSymbol)greenObject);
                }
                else if (greenObject is GreenLazyItem)
                {
                    redObject = this.GetLazyItem((GreenLazyItem)greenObject);
                }
                if (redObject != null && (allowMultipleItems || !result.Contains(redObject)))
                {
                    result.Add(redObject);
                }
            }
            Interlocked.CompareExchange(ref items, result, null);
        }

        internal void CreateListItems(ImmutableRedSymbolList list, ref List<ImmutableRedSymbol> items)
        {
            bool allowMultipleItems = list.Green.AllowMultipleItems;
            List<ImmutableRedSymbol> result = new List<ImmutableRedSymbol>();
            foreach (var greenSymbol in list.Green)
            {
                ImmutableRedSymbol redSymbol = this.GetRedSymbol(greenSymbol);
                if (allowMultipleItems || !result.Contains(redSymbol))
                {
                    result.Add(redSymbol);
                }
            }
            Interlocked.CompareExchange(ref items, result, null);
        }

        public MutableRedModel ToMutable()
        {
            return new MutableRedModel(this.green, this);
        }
    }

    // NOT thread-safe
    public sealed class MutableRedModel : RedModel
    {
        private GreenModelTransaction rootTransaction;
        private GreenModelTransaction currentTransaction;
        private ImmutableRedModel originalImmutableModel;

        public MutableRedModel()
            : this(new GreenModel(), null)
        {
        }

        internal MutableRedModel(GreenModel green)
            : this(green, null)
        {
        }

        internal MutableRedModel(GreenModel green, ImmutableRedModel originalImmutableModel)
        {
            this.originalImmutableModel = originalImmutableModel;
            this.currentTransaction = green.BeginTransaction(this);
            this.rootTransaction = this.currentTransaction;
        }

        internal GreenModelTransaction Transaction { get { return this.currentTransaction; } }

        internal object ToGreenValue(object value)
        {
            if (value is RedSymbolBase)
            {
                return ((RedSymbolBase)value).Green;
            }
            else if (value is RedValueList)
            {
                return ((RedValueList)value).Green;
            }
            else if (value is RedSymbolList)
            {
                return ((RedSymbolList)value).Green;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenSymbol)
            {
                return this.GetRedSymbol((GreenSymbol)value);
            }
            else if (value is GreenLazyItem)
            {
                return this.GetLazyItem((GreenLazyItem)value);
            }
            else if (value is GreenValueList)
            {
                return this.GetRedValueList((GreenValueList)value);
            }
            else if (value is GreenSymbolList)
            {
                return this.GetRedSymbolList((GreenSymbolList)value);
            }
            else
            {
                return value;
            }
        }

        internal GreenSymbol ToGreenSymbol(RedSymbol value)
        {
            return ((RedSymbolBase)value).Green;
        }

        internal MutableRedSymbol ToRedSymbol(GreenSymbol value)
        {
            return this.GetRedSymbol(value);
        }

        public MutableRedSymbol AddGreenSymbol(GreenSymbol green)
        {
            this.currentTransaction.AddSymbol(green);
            return this.ToRedSymbol(green);
        }

        public MutableRedSymbol AddSymbol(RedSymbol symbol)
        {
            return this.AddGreenSymbol(this.ToGreenSymbol(symbol));
        }

        public void RemoveSymbol(RedSymbol symbol)
        {
            this.currentTransaction.RemoveSymbol(this.ToGreenSymbol(symbol));
        }

        public RedModelTransaction BeginTransaction()
        {
            this.currentTransaction = this.currentTransaction.BeginTransaction(this);
            return new RedModelTransaction(this, this.currentTransaction);
        }

        internal void CommitTransaction(RedModelTransaction transaction)
        {
            if (this.currentTransaction == this.rootTransaction) return;
            if (transaction.Green != this.currentTransaction)
            {
                throw new ModelException("Invalid transaction.");
            }
            this.currentTransaction = transaction.Green.ParentTransaction;
            if (this.currentTransaction == null)
            {
                this.currentTransaction = this.rootTransaction;
            }
            else
            {
                this.currentTransaction.Commit(transaction.Green);
            }
        }

        internal void RollbackTransaction(RedModelTransaction transaction)
        {
            if (this.currentTransaction == this.rootTransaction) return;
            if (transaction.Green != this.currentTransaction)
            {
                throw new ModelException("Invalid transaction.");
            }
            this.currentTransaction = transaction.Green.ParentTransaction;
            if (this.currentTransaction == null)
            {
                this.currentTransaction = this.rootTransaction;
            }
            else
            {
                this.currentTransaction.Rollback(transaction.Green);
            }
        }

        public MutableRedSymbol GetRedSymbol(GreenSymbol green)
        {
            return this.currentTransaction.GetRedSymbol(green);
        }

        internal object GetLazyItem(GreenLazyItem lazy)
        {
            return this.currentTransaction.GetLazyItem(lazy);
        }

        private MutableRedValueList GetRedValueList(GreenValueList green)
        {
            if (!this.currentTransaction.ContainsSymbol(green.Parent))
            {
                return null;
            }
            return new MutableRedValueList(green, this);
        }

        private MutableRedSymbolList GetRedSymbolList(GreenSymbolList green)
        {
            if (!this.currentTransaction.ContainsSymbol(green.Parent))
            {
                return null;
            }
            return new MutableRedSymbolList(green, this);
        }

        internal object GetValue(RedSymbolBase symbol, ModelProperty property)
        {
            object greenObject = this.currentTransaction.GetValue(symbol.Green, property);
            return this.ToRedValue(greenObject);
        }

        internal void UpdateList(RedSymbolBase symbol, ModelProperty property, MutableRedValueList list)
        {
            object greenObject = this.currentTransaction.GetValue(symbol.Green, property);
            if (list.Green == greenObject) return;
            Debug.Assert(greenObject is GreenValueList);
            if (greenObject is GreenValueList)
            {
                list.SetGreen((GreenValueList)greenObject);
            }
        }

        internal void UpdateList(RedSymbolBase symbol, ModelProperty property, MutableRedSymbolList list)
        {
            object greenObject = this.currentTransaction.GetValue(symbol.Green, property);
            if (list.Green == greenObject) return;
            Debug.Assert(greenObject is GreenSymbolList);
            if (greenObject is GreenSymbolList)
            {
                list.SetGreen((GreenSymbolList)greenObject);
            }
        }

        internal bool SetValue(MutableRedSymbol symbol, ModelProperty property, object value)
        {
            value = this.ToGreenValue(value);
            object oldValue;
            return this.currentTransaction.SetValue(symbol.Green, property, value, out oldValue);
        }

        internal bool SetLazyValue(MutableRedSymbol symbol, ModelProperty property, Func<object> value)
        {
            if (value == null) return false;
            object oldValue;
            return this.currentTransaction.SetValue(symbol.Green, property, new GreenLazyItem(value), out oldValue);
        }

        internal void CreateListItems(RedValueList list, ref List<object> items)
        {
            bool allowMultipleItems = list.Green.AllowMultipleItems;
            List<object> result = new List<object>();
            foreach (var greenObject in list.Green)
            {
                object redObject = this.ToRedValue(greenObject);
                if (redObject != null && (allowMultipleItems || !result.Contains(redObject)))
                {
                    result.Add(redObject);
                }
            }
            Interlocked.CompareExchange(ref items, result, null);
        }

        internal void CreateListItems(MutableRedSymbolList list, ref List<MutableRedSymbol> items)
        {
            bool allowMultipleItems = list.Green.AllowMultipleItems;
            List<MutableRedSymbol> result = new List<MutableRedSymbol>();
            foreach (var greenSymbol in list.Green)
            {
                MutableRedSymbol redSymbol = this.ToRedSymbol(greenSymbol);
                if (redSymbol != null && (allowMultipleItems || !result.Contains(redSymbol)))
                {
                    result.Add(redSymbol);
                }
            }
            Interlocked.CompareExchange(ref items, result, null);
        }

        internal void ClearList(MutableRedValueList list)
        {
            this.currentTransaction.ClearList(list.Green.Parent, list.Green.Property);
        }

        internal void ClearList(MutableRedSymbolList list)
        {
            this.currentTransaction.ClearList(list.Green.Parent, list.Green.Property);
        }

        internal bool AddListItem(MutableRedValueList list, object item)
        {
            return this.currentTransaction.AddValue(list.Green.Parent, list.Green.Property, this.ToGreenValue(item));
        }

        internal bool RemoveListItem(MutableRedValueList list, object item)
        {
            return this.currentTransaction.RemoveValue(list.Green.Parent, list.Green.Property, this.ToGreenValue(item));
        }

        internal bool AddListItem(MutableRedSymbolList list, RedSymbol item)
        {
            return this.currentTransaction.AddValue(list.Green.Parent, list.Green.Property, this.ToGreenSymbol(item));
        }

        internal bool AddListItem(MutableRedSymbolList list, GreenLazySymbol item)
        {
            return this.currentTransaction.AddValue(list.Green.Parent, list.Green.Property, item);
        }

        internal bool RemoveListItem(MutableRedSymbolList list, RedSymbol item)
        {
            return this.currentTransaction.RemoveValue(list.Green.Parent, list.Green.Property, this.ToGreenSymbol(item));
        }

        internal void InvalidateProperty(GreenSymbol symbol, ModelProperty property)
        {
            MutableRedSymbol redSymbol = this.GetRedSymbol(symbol);
            if (redSymbol != null)
            {
                redSymbol.InvalidateProperty(property);
            }
        }

        internal GreenModel Fork()
        {
            return this.currentTransaction.Fork();
        }

        public ImmutableRedModel ToImmutable()
        {
            if (this.currentTransaction.IsChanged)
            {
                return new ImmutableRedModel(this.Fork());
            }
            else
            {
                if (this.originalImmutableModel != null) return this.originalImmutableModel;
                else return new ImmutableRedModel(this.currentTransaction.BaseModel);
            }
        }
    }

    public sealed class RedModelTransaction : IDisposable
    {
        private bool commited;
        private GreenModelTransaction green;
        private MutableRedModel model;

        internal RedModelTransaction(MutableRedModel model, GreenModelTransaction green)
        {
            this.model = model;
            this.green = green;
            this.commited = false;
        }

        internal GreenModelTransaction Green { get { return this.green; } }
        internal MutableRedModel Model { get { return this.model; } }

        public void Commit()
        {
            this.commited = true;
        }

        public void Rollback()
        {
            this.commited = false;
        }

        public void Dispose()
        {
            if (this.commited) model.CommitTransaction(this);
            else model.RollbackTransaction(this);
        }
    }

}

