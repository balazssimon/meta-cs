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
    public abstract class GreenSymbol
    {
        public abstract ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model);
        public abstract MutableRedSymbol CreateMutableRed(MutableRedModel model);
    }

    public class RedSymbol
    {
        private GreenSymbol green;
        private RedModel model;

        public RedSymbol(GreenSymbol green, RedModel model)
        {
            this.green = green;
            this.model = model;
        }

        public GreenSymbol Green { get { return this.green; } }
        public RedModel Model { get { return this.model; } }
    }

    // thread-safe
    public class ImmutableRedSymbol : RedSymbol
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
    public class MutableRedSymbol : RedSymbol
    {
        private Dictionary<ModelProperty, object> properties;

        public MutableRedSymbol(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
        }

        public new MutableRedModel Model { get { return (MutableRedModel)base.Model; } }

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
            return result;
        }

        public MutableRedSymbolList<T> GetSymbolList<T>(ModelProperty property, ref MutableRedSymbolList<T> value)
            where T : class
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
            return result;
        }

        public bool SetValue<T>(ModelProperty property, ref T value, T newValue)
            where T : class
        {
            T oldValue = value;
            if (Interlocked.Exchange(ref value, newValue) != oldValue)
            {
                this.Model.SetValue(this, property, value);
                return true;
            }
            return false;
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

        public GreenValueList Green { get { return this.green; } }
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

        public ImmutableRedValueList(GreenValueList green, ImmutableRedModel model)
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

    public class ImmutableRedValueList<T> : IReadOnlyList<T>
    {
        private ImmutableRedValueList wrapped;

        public ImmutableRedValueList(ImmutableRedValueList wrapped)
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
    public class MutableRedValueList : RedValueList
    {
        private List<object> cachedItems = null;

        public MutableRedValueList(GreenValueList green, MutableRedModel model)
            : base(green, model)
        {
        }

        public new MutableRedModel Model { get { return (MutableRedModel)base.Model; } }

        public bool Add(object value)
        {
            return this.Model.AddListItem(this, this.cachedItems, value);
        }

        public bool Remove(object value)
        {
            return this.Model.RemoveListItem(this, this.cachedItems, value);
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

    public class MutableRedValueList<T> : IList<T>
    {
        private MutableRedValueList wrapped;

        public MutableRedValueList(MutableRedValueList wrapped)
        {
            this.wrapped = wrapped;
        }

        public T this[int index]
        {
            get
            {
                return (T)this.wrapped[index];
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            this.wrapped.Add(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            return this.wrapped.Remove(item);
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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

    public class ImmutableRedSymbolList<T> : IReadOnlyList<T>
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

        public bool Add(RedSymbol value)
        {
            return this.Model.AddListItem(this, this.cachedItems, value);
        }

        public bool Remove(RedSymbol value)
        {
            return this.Model.RemoveListItem(this, this.cachedItems, value);
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

    public class MutableRedSymbolList<T> : IList<T>
        where T : class
    {
        private MutableRedSymbolList wrapped;

        public MutableRedSymbolList(MutableRedSymbolList wrapped)
        {
            this.wrapped = wrapped;
        }

        public T this[int index]
        {
            get
            {
                return (T)(object)this.wrapped[index];
            }

            set
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            this.wrapped.Add((RedSymbol)(object)item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            return this.wrapped.Remove((RedSymbol)(object)item);
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    // thread-safe
    public class GreenModel
    {
        private static readonly IReadOnlyList<GreenSymbol> emptySymbolList = new List<GreenSymbol>();
        internal Dictionary<GreenSymbol, GreenSymbolEntry> symbols;

        internal GreenModel()
        {
        }

        internal GreenModel(Dictionary<GreenSymbol, GreenSymbolEntry> symbols)
        {
            this.symbols = symbols;
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

        internal virtual bool HasValue(GreenSymbol symbol, ModelProperty property)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            object storedValue;
            return this.TryGetValue(symbol, property, out storedValue);
        }

        internal virtual bool HasValue(GreenSymbol symbol, ModelProperty property, object value)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            object storedValue;
            if (this.TryGetValue(symbol, property, out storedValue))
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
            if (this.TryGetValue(symbol, property, out value))
            {
                return value;
            }
            return null;
        }

        internal virtual bool TryGetValue(GreenSymbol symbol, ModelProperty property, out object value)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            GreenSymbolEntry entry;
            if (this.symbols != null && this.symbols.TryGetValue(symbol, out entry))
            {
                if (entry != null && entry.properties != null && entry.properties.TryGetValue(property, out value))
                {
                    return true;
                }
            }
            value = null;
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
    public class GreenModelTransaction : GreenModel
    {
        private GreenModel baseModel;
        //private Dictionary<GreenSymbol, HashSet<ModelProperty>> lazyValues;

        internal GreenModelTransaction(GreenModel baseModel)
        {
            Debug.Assert(baseModel != null);
            this.baseModel = baseModel;
        }

        public bool IsChanged
        {
            get
            {
                return this.symbols != null;
            }
        }

        internal void CloneBaseModel()
        {
            if (this.symbols != null) return;
            this.symbols = this.baseModel.symbols?.ToDictionary(entry => entry.Key, entry => (GreenSymbolEntry)null);
        }

        internal GreenSymbolEntry GetEntryForReading(GreenSymbol symbol)
        {
            GreenSymbolEntry entry;
            if (this.symbols != null && this.symbols.TryGetValue(symbol, out entry))
            {
                if (entry != null)
                {
                    return entry;
                }
            }
            if (this.baseModel.symbols != null && this.baseModel.symbols.TryGetValue(symbol, out entry))
            {
                if (entry != null)
                {
                    return entry;
                }
            }
            return null;
        }

        internal GreenSymbolEntry CreateEntry(GreenSymbol symbol, bool createIfNotExists = true)
        {
            this.CloneBaseModel();
            GreenSymbolEntry entry;
            if (this.symbols.TryGetValue(symbol, out entry))
            {
                if (entry != null)
                {
                    return entry;
                }
                else
                {
                    GreenSymbolEntry baseEntry;
                    if (this.baseModel.symbols != null && this.baseModel.symbols.TryGetValue(symbol, out baseEntry))
                    {
                        if (baseEntry != null)
                        {
                            entry = baseEntry.Clone();
                        }
                    }
                    if (entry == null && createIfNotExists)
                    {
                        entry = new GreenSymbolEntry();
                    }
                    if (entry != null)
                    {
                        this.symbols[symbol] = entry;
                    }
                }
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

        internal void AddSymbol(GreenSymbol green)
        {
            if (!this.ContainsSymbol(green))
            {
                this.CloneBaseModel();
                this.symbols.Add(green, new GreenSymbolEntry());
            }
        }

        internal void RemoveSymbol(GreenSymbol green)
        {
            if (this.ContainsSymbol(green))
            {
                this.CloneBaseModel();
                GreenSymbolEntry entry = this.GetEntryForReading(green);
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

        internal override bool TryGetValue(GreenSymbol symbol, ModelProperty property, out object value)
        {
            return this.TryGetValue(symbol, property, true, out value);
        }

        internal bool TryGetValue(GreenSymbol symbol, ModelProperty property, bool clone, out object value)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            value = null;
            GreenSymbolEntry entry;
            if (clone)
            {
                entry = this.CreateEntry(symbol, false);
            }
            else
            {
                entry = this.GetEntryForReading(symbol);
            }
            if (entry != null && entry.properties != null && entry.properties.TryGetValue(property, out value))
            {
                return true;
            }
            return false;
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
            GreenSymbolEntry entry = this.CreateEntry(symbol, true);
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

        internal bool AddValue(GreenSymbol symbol, ModelProperty property, object value)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(property != null);
            if (property.IsCollection)
            {
                object collection;
                if (this.TryGetValue(symbol, property, out collection))
                {
                    if (collection is GreenValueList)
                    {
                        GreenValueList list = (GreenValueList)collection;
                        if (value != null && list.Add(value))
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
                if (this.TryGetValue(symbol, property, out collection))
                {
                    if (collection is GreenValueList)
                    {
                        GreenValueList list = (GreenValueList)collection;
                        if (value != null && list.Remove(value))
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
                    throw new ModelException("Property value is not set: it must initialized with a collection.");
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
                }
                return false;
            }
        }

        private void AddValueToRelatedProperties(GreenSymbol symbol, ModelProperty property, GreenList list, object value)
        {
            // TODO
        }

        private void RemoveValueFromRelatedProperties(GreenSymbol symbol, ModelProperty property, GreenList list, object value)
        {
            // TODO
        }
    }

    // thread-safe
    public abstract class RedModel
    {
        private GreenModel green;
        // TODO: weak reference
        private Dictionary<GreenSymbol, RedSymbol> symbols;
        private Dictionary<GreenValueList, RedValueList> valueLists;
        private Dictionary<GreenSymbolList, RedSymbolList> symbolLists;

        internal RedModel(GreenModel green)
        {
            this.green = green;
            this.symbols = new Dictionary<GreenSymbol, RedSymbol>();
            this.valueLists = new Dictionary<GreenValueList, RedValueList>();
            this.symbolLists = new Dictionary<GreenSymbolList, RedSymbolList>();
        }

        public GreenModel Green { get { return this.green; } }

        protected abstract RedSymbol CreateRedSymbol(GreenSymbol green);
        protected abstract RedValueList CreateRedValueList(GreenValueList green);
        protected abstract RedSymbolList CreateRedSymbolList(GreenSymbolList green);

        protected RedSymbol GetRedSymbol(GreenSymbol green)
        {
            if (!this.green.ContainsSymbol(green))
            {
                return null;
            }
            RedSymbol red;
            lock (this.symbols)
            {
                if (this.symbols.TryGetValue(green, out red))
                {
                    return red;
                }
            }
            red = this.CreateRedSymbol(green);
            lock (this.symbols)
            {
                RedSymbol oldRed;
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

        protected RedValueList GetRedValueList(GreenValueList green)
        {
            if (!this.green.ContainsSymbol(green.Parent))
            {
                return null;
            }
            RedValueList red;
            lock (this.valueLists)
            {
                if (this.valueLists.TryGetValue(green, out red))
                {
                    return red;
                }
            }
            red = this.CreateRedValueList(green);
            lock (this.valueLists)
            {
                RedValueList oldRed;
                if (this.valueLists.TryGetValue(green, out oldRed))
                {
                    return oldRed;
                }
                else
                {
                    this.valueLists.Add(green, red);
                    return red;
                }
            }
        }

        protected RedSymbolList GetRedSymbolList(GreenSymbolList green)
        {
            if (!this.green.ContainsSymbol(green.Parent))
            {
                return null;
            }
            RedSymbolList red;
            lock (this.symbolLists)
            {
                if (this.symbolLists.TryGetValue(green, out red))
                {
                    return red;
                }
            }
            red = this.CreateRedSymbolList(green);
            lock (this.symbolLists)
            {
                RedSymbolList oldRed;
                if (this.symbolLists.TryGetValue(green, out oldRed))
                {
                    return oldRed;
                }
                else
                {
                    this.symbolLists.Add(green, red);
                    return red;
                }
            }
        }
        internal object GetValue(RedSymbol symbol, ModelProperty property)
        {
            object greenObject = this.green.GetValue(symbol.Green, property);
            if (greenObject is GreenSymbol)
            {
                return this.GetRedSymbol((GreenSymbol)greenObject);
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
                if (redObject != null && (allowMultipleItems || !result.Contains(redObject)))
                {
                    result.Add(redObject);
                }
            }
            Interlocked.CompareExchange(ref items, result, null);
        }
    }

    // thread-safe
    public class ImmutableRedModel : RedModel
    {
        public ImmutableRedModel(GreenModel green)
            : base(green)
        {
        }

        internal new ImmutableRedSymbol GetRedSymbol(GreenSymbol green)
        {
            return (ImmutableRedSymbol)base.GetRedSymbol(green);
        }

        protected override RedSymbol CreateRedSymbol(GreenSymbol green)
        {
            return green.CreateImmutableRed(this);
        }

        protected override RedValueList CreateRedValueList(GreenValueList green)
        {
            return new ImmutableRedValueList(green, this);
        }

        protected override RedSymbolList CreateRedSymbolList(GreenSymbolList green)
        {
            return new ImmutableRedSymbolList(green, this);
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
            return new MutableRedModel(new GreenModelTransaction(this.Green), this);
        }
    }

    // NOT thread-safe
    public class MutableRedModel : RedModel
    {
        private ImmutableRedModel originalImmutableModel;

        internal MutableRedModel(GreenModelTransaction green)
            : base(green)
        {
        }

        internal MutableRedModel(GreenModelTransaction green, ImmutableRedModel originalImmutableModel)
            : base(green)
        {
            this.originalImmutableModel = originalImmutableModel;
        }

        public new GreenModelTransaction Green { get { return (GreenModelTransaction)base.Green; } }

        public void AddGreenSymbol(GreenSymbol green)
        {
            this.Green.AddSymbol(green);
        }

        internal void AddSymbol(RedSymbol symbol)
        {
            this.Green.AddSymbol(symbol.Green);
        }

        internal void RemoveSymbol(RedSymbol symbol)
        {
            this.Green.RemoveSymbol(symbol.Green);
            // TODO: remove from red property values
        }

        internal new MutableRedSymbol GetRedSymbol(GreenSymbol green)
        {
            return (MutableRedSymbol)base.GetRedSymbol(green);
        }

        protected override RedSymbol CreateRedSymbol(GreenSymbol green)
        {
            return green.CreateMutableRed(this);
        }

        protected override RedValueList CreateRedValueList(GreenValueList green)
        {
            return new MutableRedValueList(green, this);
        }

        protected override RedSymbolList CreateRedSymbolList(GreenSymbolList green)
        {
            return new MutableRedSymbolList(green, this);
        }

        internal bool SetValue(MutableRedSymbol symbol, ModelProperty property, object value)
        {
            if (value is RedSymbol)
            {
                value = ((RedSymbol)value).Green;
            }
            else if (value is RedValueList)
            {
                value = ((RedValueList)value).Green;
            }
            else if (value is RedSymbolList)
            {
                value = ((RedSymbolList)value).Green;
            }
            object oldValue;
            if (this.Green.SetValue(symbol.Green, property, value, out oldValue))
            {
                // TODO: invalidate related red properties (do it automatically from green values!)
                return true;
            }
            return false;
        }

        internal void CreateListItems(MutableRedSymbolList list, ref List<MutableRedSymbol> items)
        {
            bool allowMultipleItems = list.Green.AllowMultipleItems;
            List<MutableRedSymbol> result = new List<MutableRedSymbol>();
            foreach (var greenSymbol in list.Green)
            {
                MutableRedSymbol redSymbol = this.GetRedSymbol(greenSymbol);
                if (redSymbol != null && (allowMultipleItems || !result.Contains(redSymbol)))
                {
                    result.Add(redSymbol);
                }
            }
            Interlocked.CompareExchange(ref items, result, null);
        }

        internal bool AddListItem(MutableRedValueList list, List<object> cachedItems, object item)
        {
            if (this.Green.AddValue(list.Green.Parent, list.Green.Property, item))
            {
                cachedItems.Add(item);
                // TODO: invalidate related red properties
                return true;
            }
            return false;
        }

        internal bool RemoveListItem(MutableRedValueList list, List<object> cachedItems, object item)
        {
            if (this.Green.RemoveValue(list.Green.Parent, list.Green.Property, item))
            {
                cachedItems.Remove(item);
                // TODO: invalidate related red properties
                return true;
            }
            return false;
        }

        internal bool AddListItem(MutableRedSymbolList list, List<MutableRedSymbol> cachedItems, RedSymbol item)
        {
            if (this.Green.AddValue(list.Green.Parent, list.Green.Property, item))
            {
                cachedItems.Add(this.GetRedSymbol(item.Green));
                // TODO: invalidate related red properties
                return true;
            }
            return false;
        }

        internal bool RemoveListItem(MutableRedSymbolList list, List<MutableRedSymbol> cachedItems, RedSymbol item)
        {
            if (this.Green.RemoveValue(list.Green.Parent, list.Green.Property, item))
            {
                cachedItems.Remove(this.GetRedSymbol(item.Green));
                // TODO: invalidate related red properties
                return true;
            }
            return false;
        }

        internal GreenModel Fork()
        {
            // TODO
            throw new NotImplementedException();
        }

        public ImmutableRedModel ToImmutable()
        {
            if (this.Green.IsChanged)
            {
                return new ImmutableRedModel(this.Fork());
            }
            else
            {
                if (this.originalImmutableModel != null) return this.originalImmutableModel;
                else return new ImmutableRedModel(this.Green);
            }
        }
    }

}

