using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable4.Eager
{
    // NOT thread-safe
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

    public class ImmutableRedSymbol : RedSymbol
    {
        public ImmutableRedSymbol(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public new ImmutableRedModel Model { get { return (ImmutableRedModel)base.Model; } }

        public T GetValue<T>(ref T value, ModelProperty property)
            where T : class
        {
            T result = (T)this.Model.GetValue(this, property);
            result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            return result;
        }
    }

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
            T result = (T)this.Model.GetValue(this, property);
            result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            return result;
        }

        public void SetValue<T>(ModelProperty property, T value)
            where T : class
        {
            this.Model.SetValue(this, property, value);
        }
    }


    // NOT thread-safe
    public class GreenValueList : IReadOnlyList<object>, ICloneable
    {
        private GreenSymbol parent;
        private ModelProperty property;
        private bool allowMultipleItems;
        private List<object> items;

        internal GreenValueList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
        {
            this.parent = parent;
            this.property = property;
            this.allowMultipleItems = allowMultipleItems;
            this.items = new List<object>();
        }

        internal GreenValueList(GreenValueList other)
        {
            this.parent = other.parent;
            this.property = other.property;
            this.allowMultipleItems = other.allowMultipleItems;
            this.items = new List<object>(other.items);
        }

        internal bool Add(object item)
        {
            if (allowMultipleItems || !this.items.Contains(item))
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

    public class ImmutableRedValueList : IReadOnlyList<object>
    {
        private GreenValueList green;
        private ImmutableRedModel model;

        public ImmutableRedValueList(GreenValueList green, ImmutableRedModel model)
        {
            this.green = green;
            this.model = model;
        }

        public GreenValueList Green { get { return this.green; } }
        public ImmutableRedModel Model { get { return this.model; } }

        public object this[int index]
        {
            get { return this.green[index]; }
        }

        public int Count
        {
            get { return this.green.Count; }
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this.green.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class MutableRedValueList : IReadOnlyList<object>
    {
        private GreenValueList green;
        private MutableRedModel model;

        public MutableRedValueList(GreenValueList green, MutableRedModel model)
        {
            this.green = green;
            this.model = model;
        }

        public GreenValueList Green { get { return this.green; } }
        public MutableRedModel Model { get { return this.model; } }

        public bool Add(object value)
        {
            return this.green.Add(value);
        }

        public bool Remove(object value)
        {
            return this.green.Remove(value);
        }

        public object this[int index]
        {
            get { return this.green[index]; }
        }

        public int Count
        {
            get { return this.green.Count; }
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this.green.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }


    // NOT thread-safe
    public class GreenSymbolList : IReadOnlyList<GreenSymbol>
    {
        private GreenSymbol parent;
        private ModelProperty property;
        private bool allowMultipleItems;
        private List<GreenSymbol> items;

        internal GreenSymbolList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
        {
            this.parent = parent;
            this.property = property;
            this.allowMultipleItems = allowMultipleItems;
            this.items = new List<GreenSymbol>();
        }

        internal GreenSymbolList(GreenSymbolList other)
        {
            this.parent = other.parent;
            this.property = other.property;
            this.allowMultipleItems = other.allowMultipleItems;
            this.items = new List<GreenSymbol>(other.items);
        }

        internal bool Add(GreenSymbol item)
        {
            if (allowMultipleItems || !this.items.Contains(item))
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

    public class ImmutableRedSymbolList : IReadOnlyList<ImmutableRedSymbol>
    {
        private GreenSymbolList green;
        private ImmutableRedModel model;
        private List<ImmutableRedSymbol> items;

        public ImmutableRedSymbolList(GreenSymbolList green, ImmutableRedModel model)
        {
            this.green = green;
            this.model = model;
            this.items = new List<ImmutableRedSymbol>(this.green.Count);
            for (int i = 0, n = this.green.Count; i < n; ++i)
            {
                this.items.Add(null);
            }
        }

        public GreenSymbolList Green { get { return this.green; } }
        public ImmutableRedModel Model { get { return this.model; } }

        public ImmutableRedSymbol this[int index]
        {
            get { return this.GetItem(index); }
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public IEnumerator<ImmutableRedSymbol> GetEnumerator()
        {
            for (int i = 0, n = this.Count; i < n; ++i)
            {
                yield return this.GetItem(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private ImmutableRedSymbol GetItem(int index)
        {
            lock (this.items)
            {
                if (this.items[index] != null) return this.items[index];
            }
            ImmutableRedSymbol red = this.model.GetSymbol(this.green[index]);
            lock(this.items)
            { 
                this.items[index] = red;
                return red;
            }
        }
    }

    public class MutableRedSymbolList : IReadOnlyList<MutableRedSymbol>
    {
        private GreenSymbolList green;
        private MutableRedModel model;
        private List<MutableRedSymbol> items;

        public MutableRedSymbolList(GreenSymbolList green, MutableRedModel model)
        {
            this.green = green;
            this.model = model;
            this.items = new List<MutableRedSymbol>(this.green.Count);
            for (int i = 0, n = this.green.Count; i < n; ++i)
            {
                this.items.Add(null);
            }
        }

        public GreenSymbolList Green { get { return this.green; } }
        public MutableRedModel Model { get { return this.model; } }

        public bool Add(RedSymbol item)
        {
            if (this.green.Add(item.Green))
            {
                this.items.Add(null);
                return true;
            }
            return false;
        }

        public bool Remove(RedSymbol item)
        {
            if (this.green.Remove(item.Green))
            {
                this.items.Add(null);
                return true;
            }
            return false;
        }

        public MutableRedSymbol this[int index]
        {
            get { return this.GetItem(index); }
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public IEnumerator<MutableRedSymbol> GetEnumerator()
        {
            for (int i = 0, n = this.Count; i < n; ++i)
            {
                yield return this.GetItem(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private MutableRedSymbol GetItem(int index)
        {
            lock (this.items)
            {
                if (this.items[index] != null) return this.items[index];
            }
            MutableRedSymbol red = this.model.GetSymbol(this.green[index]);
            lock (this.items)
            {
                this.items[index] = red;
                return red;
            }
        }
    }


    // NOT thread-safe
    public class GreenModel
    {
        private Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> symbols;

        internal GreenModel()
        {
            this.symbols = new Dictionary<GreenSymbol, Dictionary<ModelProperty, object>>();
        }

        internal GreenModel(GreenModel other)
        {
            this.symbols = other.symbols.ToDictionary(entry => entry.Key, entry => entry.Value.ToDictionary(innerEntry => innerEntry.Key, innerEntry => innerEntry.Value));
        }

        public bool ContainsSymbol(GreenSymbol symbol)
        {
            return this.symbols.ContainsKey(symbol);
        }

        public bool HasValue(GreenSymbol symbol, ModelProperty property)
        {
            Dictionary<ModelProperty, object> properties;
            if (this.symbols.TryGetValue(symbol, out properties))
            {
                return properties.ContainsKey(property);
            }
            return false;
        }

        public object GetValue(GreenSymbol symbol, ModelProperty property)
        {
            Dictionary<ModelProperty, object> properties;
            if (this.symbols.TryGetValue(symbol, out properties))
            {
                object value;
                if (properties.TryGetValue(property, out value))
                {
                    return value;
                }
            }
            return null;
        }

        public IEnumerable<GreenSymbol> GetSymbols()
        {
            return this.symbols.Keys;
        }
    }

    public class RedModel
    {
        internal GreenModel green;

        public RedModel(GreenModel green)
        {
            this.green = green;
        }
    }

    public class ImmutableRedModel : RedModel
    {
        // TODO: weak reference
        private bool allSymbolsCreated = false;
        private Dictionary<GreenSymbol, ImmutableRedSymbol> symbols;

        public ImmutableRedModel(GreenModel green)
            : base(green)
        {
            this.symbols = new Dictionary<GreenSymbol, ImmutableRedSymbol>();
        }

        internal ImmutableRedSymbol GetSymbol(GreenSymbol green)
        {
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
                if (!this.symbols.ContainsKey(green))
                {
                    this.symbols.Add(green, red);
                }
            }
            return red;
        }

        internal object GetValue(ImmutableRedSymbol symbol, ModelProperty property)
        {
            return null;
        }

        public IEnumerable<ImmutableRedSymbol> GetSymbols()
        {
            if (this.allSymbolsCreated) return this.symbols.Values;
            this.CreateAllSymbols();
            return this.symbols.Values;
        }

        private void CreateAllSymbols()
        {
            lock(this)
            {
                if (this.allSymbolsCreated) return;
                foreach (var green in this.green.GetSymbols())
                {
                    this.GetSymbol(green);
                }
                this.allSymbolsCreated = true;
            }
        }
    }

    public class MutableRedModel : RedModel
    {
        // TODO: weak reference
        private bool allSymbolsCreated = false;
        private Dictionary<GreenSymbol, MutableRedSymbol> symbols;

        public MutableRedModel(GreenModel green)
            : base(green)
        {
            this.symbols = new Dictionary<GreenSymbol, MutableRedSymbol>();
        }

        internal MutableRedSymbol GetSymbol(GreenSymbol green)
        {
            MutableRedSymbol red;
            lock (this.symbols)
            {
                if (this.symbols.TryGetValue(green, out red))
                {
                    return red;
                }
            }
            red = green.CreateMutableRed(this);
            lock (this.symbols)
            {
                if (!this.symbols.ContainsKey(green))
                {
                    this.symbols.Add(green, red);
                }
            }
            return red;
        }

        internal object GetValue(MutableRedSymbol symbol, ModelProperty property)
        {
            return null;
        }

        internal void SetValue(MutableRedSymbol symbol, ModelProperty property, object value)
        {

        }

        public IEnumerable<MutableRedSymbol> GetSymbols()
        {
            if (this.allSymbolsCreated) return this.symbols.Values;
            this.CreateAllSymbols();
            return this.symbols.Values;
        }

        private void CreateAllSymbols()
        {
            lock (this)
            {
                if (this.allSymbolsCreated) return;
                foreach (var green in this.green.GetSymbols())
                {
                    this.GetSymbol(green);
                }
                this.allSymbolsCreated = true;
            }
        }
    }

}

/*
    public class GreenModel
    {
        private Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> symbols;

        internal GreenModel()
        {
            this.symbols = new Dictionary<GreenSymbol, Dictionary<ModelProperty, object>>();
        }

        internal GreenModel(Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> symbols)
        {
            this.symbols = symbols;
        }

        internal void AddSymbol(GreenSymbol symbol)
        {
            if (!this.symbols.ContainsKey(symbol))
            {
                this.symbols.Add(symbol, new Dictionary<ModelProperty, object>());
            }
        }

        internal void RemoveSymbol(GreenSymbol symbol)
        {
            this.symbols.Remove(symbol);
            // TODO: remove from other symbol's properties
        }

        public object GetValue(GreenSymbol symbol, ModelProperty property)
        {
            Dictionary<ModelProperty, object> properties;
            if (this.symbols.TryGetValue(symbol, out properties))
            {
                object value;
                if (properties.TryGetValue(property, out value))
                {
                    return value;
                }
            }
            return null;
        }

        internal bool SetValue(GreenSymbol symbol, ModelProperty property, object value)
        {
            Dictionary<ModelProperty, object> properties;
            if (this.symbols.TryGetValue(symbol, out properties))
            {
                if (!property.IsCollection || !properties.ContainsKey(property))
                {
                    if (property.IsModelObject)
                    {
                        Debug.Assert(value == null || value is GreenSymbol);
                    }
                    properties[property] = value;
                    return true;
                }
                else
                {
                    Debug.Assert(false);
                }
            }
            else
            {
                Debug.Assert(false);
            }
            return false;
        }

        internal bool AddValue(GreenSymbol symbol, ModelProperty property, object value)
        {
            Dictionary<ModelProperty, object> properties;
            if (this.symbols.TryGetValue(symbol, out properties))
            {
                if (property.IsCollection)
                {
                    object oldValue;
                    if (properties.TryGetValue(property, out oldValue))
                    {
                        GreenSymbolList gsl = oldValue as GreenSymbolList;
                        if (gsl != null)
                        {
                            Debug.Assert(value is GreenSymbol);
                            return gsl.Add((GreenSymbol)value);
                        }
                        else
                        {
                            GreenValueList gvl = oldValue as GreenValueList;
                            if (gvl != null)
                            {
                                return gvl.Add(value);
                            }
                            else
                            {
                                Debug.Assert(false);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (property.IsModelObject)
                        {
                            GreenSymbolList gsl = new GreenSymbolList(symbol, property, false);
                            properties.Add(property, gsl);
                            Debug.Assert(value is GreenSymbol);
                            return gsl.Add((GreenSymbol)value);
                        }
                        else
                        {
                            GreenValueList gvl = new GreenValueList(symbol, property, false);
                            properties.Add(property, gvl);
                            return gvl.Add(value);
                        }
                    }
                }
                else
                {
                    return this.SetValue(symbol, property, value);
                }
            }
            else
            {
                Debug.Assert(false);
                return false;
            }
        }

        internal bool RemoveValue(GreenSymbol symbol, ModelProperty property, object value)
        {
            Dictionary<ModelProperty, object> properties;
            if (this.symbols.TryGetValue(symbol, out properties))
            {
                if (property.IsCollection)
                {
                    object oldValue;
                    if (properties.TryGetValue(property, out oldValue))
                    {
                        GreenSymbolList gsl = oldValue as GreenSymbolList;
                        if (gsl != null)
                        {
                            Debug.Assert(value is GreenSymbol);
                            return gsl.Remove((GreenSymbol)value);
                        }
                        else
                        {
                            GreenValueList gvl = oldValue as GreenValueList;
                            if (gvl != null)
                            {
                                return gvl.Remove(value);
                            }
                            else
                            {
                                Debug.Assert(false);
                                return false;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    return this.SetValue(symbol, property, null);
                }
            }
            else
            {
                Debug.Assert(false);
                return false;
            }
        }
    }
*/
