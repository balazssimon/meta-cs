﻿using MetaDslx.Core.Collections.Transactional;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public sealed class ImmutableModel : RedModel
    {
        private GreenModel green;
        private bool cachedSymbols;
        private Dictionary<SymbolId, IImmutableSymbol> symbols;

        internal ImmutableModel(GreenModel green)
        {
            this.green = green;
            this.cachedSymbols = false;
        }

        internal GreenModel Green { get { return this.green; } }

        public IEnumerable<IImmutableSymbol> Symbols
        {
            get
            {
                if (!this.cachedSymbols) this.CacheSymbols();
                return this.symbols.Values;
            }
        }

        public MutableModel ToMutable()
        {
            return new MutableModel(this.green, this);
        }

        public IImmutableSymbol GetSymbol(ISymbol symbol)
        {
            if (symbol is ImmutableSymbolBase)
            {
                return this.GetRedSymbol(((ImmutableSymbolBase)symbol).Green);
            }
            if (symbol is MutableSymbolBase)
            {
                return this.GetRedSymbol(((MutableSymbolBase)symbol).Green);
            }
            return null;
        }

        public bool ContainsSymbol(ISymbol symbol)
        {
            if (symbol is ImmutableSymbolBase)
            {
                return this.green.ContainsSymbol(((ImmutableSymbolBase)symbol).Green);
            }
            if (symbol is MutableSymbolBase)
            {
                return this.green.ContainsSymbol(((MutableSymbolBase)symbol).Green);
            }
            return false;
        }

        internal IImmutableSymbol GetRedSymbol(SymbolId green)
        {
            if (green == null) return null;
            if (!this.cachedSymbols) this.CacheSymbols();
            IImmutableSymbol red;
            if (this.symbols.TryGetValue(green, out red))
            {
                return red;
            }
            return null;
        }

        private void CacheSymbols()
        {
            if (this.cachedSymbols) return;
            lock (this)
            {
                if (this.cachedSymbols) return;
                this.cachedSymbols = true;
                this.symbols = new Dictionary<SymbolId, IImmutableSymbol>();
                foreach (var greenSymbol in this.green.Symbols)
                {
                    IImmutableSymbol red = greenSymbol.CreateImmutable(this);
                    this.symbols.Add(greenSymbol, red);
                }
            }
        }
        internal object GetValue(ImmutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            object greenObject = this.green.GetValue(symbol.Green, property, false);
            return this.ToRedValue(greenObject);
        }

        internal ImmutableModelList<T> GetList<T>(ImmutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            object greenObject = this.green.GetValue(symbol.Green, property, false);
            if (greenObject is GreenList)
            {
                return new ImmutableModelList<T>((GreenList)greenObject, this);
            }
            else
            {
                return null;
            }
        }

        internal List<T> CreateListItems<T>(IInternalReadOnlyCollection list)
        {
            List<T> result = new List<T>();
            foreach (var greenObject in list.Green)
            {
                object redObject = greenObject;
                if (greenObject is SymbolId)
                {
                    redObject = this.GetRedSymbol((SymbolId)greenObject);
                    Debug.Assert(redObject != null);
                }
                result.Add((T)redObject);
            }
            return result;
        }

        internal IImmutableSymbol MParent(ImmutableSymbolBase redSymbol)
        {
            return this.GetRedSymbol(this.green.MParent(redSymbol.Green));
        }

        internal IReadOnlyList<IImmutableSymbol> MChildren(ImmutableSymbolBase redSymbol)
        {
            return new ReadOnlyImmutableModelList<ImmutableSymbolBase>(this.green.MChildren(redSymbol.Green), this);
        }

        internal IReadOnlyList<ModelProperty> MProperties(ImmutableSymbolBase redSymbol)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType());
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(ImmutableSymbolBase redSymbol)
        {
            return this.green.MAllProperties(redSymbol.Green);
        }

        internal object MGet(ImmutableSymbolBase redSymbol, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return this.GetList<object>(redSymbol, property);
            }
            else
            {
                return this.GetValue(redSymbol, property);
            }
        }

        internal bool MIsSet(ImmutableSymbolBase redSymbol, ModelProperty property)
        {
            return this.green.MIsSet(redSymbol.Green, property);
        }

        internal ModelProperty MGetProperty(ImmutableSymbolBase redSymbol, string name)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType()).FirstOrDefault(p => p.Name == name);
        }

        internal IReadOnlyList<ModelProperty> MGetAllProperties(ImmutableSymbolBase redSymbol, string name)
        {
            return this.green.MGetAllProperties(redSymbol.Green, name);
        }

        internal bool MHasLazy(ImmutableSymbolBase redSymbol, ModelProperty property)
        {
            return this.green.MHasLazy(redSymbol.Green, property);
        }

        internal bool MIsAttached(ImmutableSymbolBase redSymbol, ModelProperty property)
        {
            return !ModelProperty.GetDeclaredPropertiesForType(redSymbol.GetType()).Contains(property);
        }

        internal bool MTryGet(ImmutableSymbolBase redSymbol, ModelProperty property, out object value)
        {
            return this.green.MTryGet(redSymbol.Green, property, out value);
        }

        internal object ToGreenValue(object value)
        {
            if (value is ImmutableSymbolBase)
            {
                return ((ImmutableSymbolBase)value).Green;
            }
            else if (value is MutableSymbolBase)
            {
                Debug.Assert(false);
                return ((MutableSymbolBase)value).Green;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenLazyValue)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is GreenLazyList)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is GreenList)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is SymbolId)
            {
                return this.GetRedSymbol((SymbolId)value);
            }
            return value;
        }
    }

    public sealed class MutableModel : RedModel
    {
        private GreenModel green;
        private ImmutableModel originalImmutableModel;
        private bool cachedSymbols;
        private TxValue<bool> allowLazyEval;
        private TxDictionary<SymbolId, IMutableSymbol> symbols;

        public MutableModel()
            : this(new GreenModel(), null)
        {
            this.allowLazyEval = new TxValue<bool>(true);
        }

        internal MutableModel(GreenModel green, ImmutableModel originalImmutableModel)
        {
            this.green = green;
            this.originalImmutableModel = originalImmutableModel;
            this.symbols = new TxDictionary<SymbolId, IMutableSymbol>();
            this.allowLazyEval = new TxValue<bool>(!this.green.IsReadOnly);
        }

        public bool IsReadOnly
        {
            get { return this.green.IsReadOnly; }
        }

        public IEnumerable<IMutableSymbol> Symbols
        {
            get
            {
                if (!this.cachedSymbols) this.CacheSymbols();
                return this.symbols.Values;
            }
        }

        public bool AllowLazyEvaluation
        {
            get { return this.allowLazyEval.Value; }
            set { this.allowLazyEval.Value = value; }
        }

        public RedModelTransaction BeginTransaction()
        {
            if (this.IsReadOnly) throw new ModelException("Cannot change a read-only mutable model. Create a new one instead.");
            return new RedModelTransaction(this);
        }

        public void EvaluateLazyValues()
        {
            if (this.IsReadOnly) throw new ModelException("Cannot change a read-only mutable model. Create a new one instead.");
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                this.green.EvaluateLazyValues(false);
                scope.Commit();
            }
        }

        public ImmutableModel ToImmutable(bool finish = true, bool evalLazy = false, bool evalDerived = false)
        {
            if (this.green.Group != null)
            {
                throw new ModelException("Cannot create an immutable model within a group. Try create an immutable model group from the whole group instead.");
            }
            if (this.green.IsChanged || this.green.BaseModel == null)
            {
                GreenModel fork = this.green.Fork(null);
                fork.Finish();
                return new ImmutableModel(fork);
            }
            else
            {
                if (this.originalImmutableModel != null)
                {
                    if (this.originalImmutableModel.Green.HasLazyValues && (evalLazy || evalDerived))
                    {
                        GreenModel fork = this.green.Fork(null);
                        fork.EvaluateLazyValues(evalDerived);
                        fork.Finish();
                        return new ImmutableModel(fork);
                    }
                    else
                    {
                        return this.originalImmutableModel;
                    }
                }
                else
                {
                    GreenModel fork = this.green.Fork(null);
                    if (evalLazy || evalDerived)
                    {
                        fork.EvaluateLazyValues(evalDerived);
                    }
                    fork.Finish();
                    return new ImmutableModel(fork);
                }
            }
        }

        public IMutableSymbol GetSymbol(ISymbol symbol)
        {
            if (symbol is ImmutableSymbolBase)
            {
                return this.GetRedSymbol(((ImmutableSymbolBase)symbol).Green);
            }
            if (symbol is MutableSymbolBase)
            {
                return this.GetRedSymbol(((MutableSymbolBase)symbol).Green);
            }
            return null;
        }

        public bool ContainsSymbol(ISymbol symbol)
        {
            if (symbol is ImmutableSymbolBase)
            {
                return this.green.ContainsSymbol(((ImmutableSymbolBase)symbol).Green);
            }
            if (symbol is MutableSymbolBase)
            {
                return this.green.ContainsSymbol(((MutableSymbolBase)symbol).Green);
            }
            return false;
        }

        internal IMutableSymbol GetRedSymbol(SymbolId green)
        {
            if (green == null) return null;
            if (!this.cachedSymbols) this.CacheSymbols();
            IMutableSymbol red;
            if (this.symbols.TryGetValue(green, out red))
            {
                return red;
            }
            return null;
        }

        internal void EnsureWritable(string errorMessage = "Cannot change a read-only mutable model. Create a new one instead.")
        {
            if (this.green.IsReadOnly) throw new ModelException(errorMessage);
        }

        private void CacheSymbols()
        {
            if (this.cachedSymbols) return;
            using (new CollectionTxScope(TransactionPropagation.DisableTx))
            {
                foreach (var greenSymbol in this.green.Symbols)
                {
                    IMutableSymbol red = greenSymbol.CreateMutable(this);
                    this.symbols.Add(greenSymbol, red);
                }
                this.cachedSymbols = true;
            }
        }

        public IMutableSymbol AddSymbol(SymbolId symbol)
        {
            this.EnsureWritable();
            if (!this.cachedSymbols) this.CacheSymbols();
            this.green.AddSymbol(symbol);
            IMutableSymbol red = symbol.CreateMutable(this);
            this.symbols.Add(symbol, red);
            return red;
        }

        internal object ToGreenValue(object value)
        {
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).Green;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenLazyValue)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is GreenLazyList)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is GreenList)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is SymbolId)
            {
                return this.GetRedSymbol((SymbolId)value);
            }
            else
            {
                return value;
            }
        }

        internal object GetValue(MutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            object greenObject;
            if (!this.AllowLazyEvaluation)
            {
                greenObject = this.green.GetValue(symbol.Green, property, false);
            }
            else
            {
                this.EnsureWritable("Cannot change a read-only mutable model. Create a new mutable model instead, and enable lazy evaluation mode.");
                greenObject = this.green.GetValue(symbol.Green, property, true);
            }
            return this.ToRedValue(greenObject);
        }

        internal Func<object> GetLazyValue(MutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            GreenLazyValue lazyValue = this.green.GetLazyValue(symbol.Green, property);
            if (lazyValue != null) return lazyValue.Lazy;
            else return null;
        }

        internal IMutableModelList<T> GetList<T>(MutableSymbolBase symbol, ModelProperty property, IMutableModelList<T> modelList)
        {
            Debug.Assert(property.IsCollection);
            object greenObject;
            if (!this.AllowLazyEvaluation)
            {
                greenObject = this.green.GetValue(symbol.Green, property, false);
            }
            else
            {
                this.EnsureWritable("Cannot change a read-only mutable model. Create a new mutable model instead, and enable lazy evaluation mode.");
                greenObject = this.green.GetValue(symbol.Green, property, true);
            }
            if (greenObject is GreenList)
            {
                MutableModelList<T> redList = modelList as MutableModelList<T>;
                if (redList == null)
                {
                    return new MutableModelList<T>((GreenList)greenObject, this);
                }
                else
                {
                    if (redList.Green != greenObject) redList.UpdateGreen((GreenList)greenObject);
                    return redList;
                }
            }
            else
            {
                return null;
            }
        }

        internal bool SetValue(MutableSymbolBase symbol, ModelProperty property, object redValue, bool reassign)
        {
            Debug.Assert(!property.IsCollection);
            this.EnsureWritable();
            object greenValue = this.ToGreenValue(redValue);
            return this.green.SetValue(symbol.Green, property, reassign, greenValue);
        }

        internal bool SetLazyValue(MutableSymbolBase symbol, ModelProperty property, Func<object> redLazy, bool reassign)
        {
            Debug.Assert(!property.IsCollection);
            this.EnsureWritable();
            if (redLazy == null) return false;
            return this.green.SetValue(symbol.Green, property, reassign, new GreenLazyValue(redLazy));
        }

        internal bool AddItem(GreenList collection, object greenItem)
        {
            this.EnsureWritable();
            return this.green.AddItem(collection.Parent, collection.Property, -1, false, greenItem);
        }

        internal bool AddLazyItem(GreenList collection, object greenLazyItem)
        {
            this.EnsureWritable();
            return this.green.AddItem(collection.Parent, collection.Property, -1, false, greenLazyItem);
        }

        internal bool RemoveItem(GreenList collection, object greenItem)
        {
            this.EnsureWritable();
            return this.green.RemoveItem(collection.Parent, collection.Property, -1, false, greenItem);
        }

        internal bool RemoveAllItems(GreenList collection, object greenItem)
        {
            this.EnsureWritable();
            return this.green.RemoveItem(collection.Parent, collection.Property, -1, true, greenItem);
        }

        internal bool InsertItem(GreenList collection, int index, object greenItem)
        {
            this.EnsureWritable();
            return this.green.AddItem(collection.Parent, collection.Property, index, false, greenItem);
        }

        internal bool ReplaceItem(GreenList collection, int index, object greenItem)
        {
            this.EnsureWritable();
            return this.green.AddItem(collection.Parent, collection.Property, index, true, greenItem);
        }

        internal bool RemoveItemAt(GreenList collection, int index)
        {
            this.EnsureWritable();
            return this.green.RemoveItem(collection.Parent, collection.Property, index, false, null);
        }

        internal bool ClearItems(GreenList collection)
        {
            this.EnsureWritable();
            return this.green.ClearItems(collection.Parent, collection.Property);
        }

        internal bool ClearLazyItems(GreenList collection)
        {
            this.EnsureWritable();
            return this.green.ClearLazyItems(collection.Parent, collection.Property);
        }

        internal IMutableSymbol MParent(MutableSymbolBase redSymbol)
        {
            return this.GetRedSymbol(this.green.MParent(redSymbol.Green));
        }

        internal IReadOnlyList<IMutableSymbol> MChildren(MutableSymbolBase redSymbol)
        {
            return new ReadOnlyMutableModelList<MutableSymbolBase>(this.green.MChildren(redSymbol.Green), this);
        }

        internal IReadOnlyList<ModelProperty> MProperties(MutableSymbolBase redSymbol)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType());
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(MutableSymbolBase redSymbol)
        {
            return this.green.MAllProperties(redSymbol.Green);
        }

        internal object MGet(MutableSymbolBase redSymbol, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return this.GetList<object>(redSymbol, property, null);
            }
            else
            {
                return this.GetValue(redSymbol, property);
            }
        }

        internal bool MIsSet(MutableSymbolBase redSymbol, ModelProperty property)
        {
            return this.green.MIsSet(redSymbol.Green, property);
        }

        internal ModelProperty MGetProperty(MutableSymbolBase redSymbol, string name)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType()).FirstOrDefault(p => p.Name == name);
        }

        internal IReadOnlyList<ModelProperty> MGetAllProperties(MutableSymbolBase redSymbol, string name)
        {
            return this.green.MGetAllProperties(redSymbol.Green, name);
        }

        internal bool MHasLazy(MutableSymbolBase redSymbol, ModelProperty property)
        {
            return this.green.MHasLazy(redSymbol.Green, property);
        }

        internal bool MIsAttached(MutableSymbolBase redSymbol, ModelProperty property)
        {
            return !ModelProperty.GetDeclaredPropertiesForType(redSymbol.GetType()).Contains(property);
        }

        internal bool MTryGet(MutableSymbolBase redSymbol, ModelProperty property, out object value)
        {
            return this.green.MTryGet(redSymbol.Green, property, out value);
        }

        internal bool MAttachProperty(MutableSymbolBase redSymbol, ModelProperty property)
        {
            this.EnsureWritable();
            return this.green.MAttachProperty(redSymbol.Green, property);
        }

        internal bool MDetachProperty(MutableSymbolBase redSymbol, ModelProperty property)
        {
            this.EnsureWritable();
            return this.green.MDetachProperty(redSymbol.Green, property);
        }

        internal bool MClear(MutableSymbolBase redSymbol, ModelProperty property, bool clearLazy)
        {
            this.EnsureWritable();
            return this.green.MClear(redSymbol.Green, property, clearLazy);
        }

        internal bool MClearLazy(MutableSymbolBase redSymbol, ModelProperty property)
        {
            this.EnsureWritable();
            return this.green.MClearLazy(redSymbol.Green, property);
        }

        internal bool MAdd(MutableSymbolBase redSymbol, ModelProperty property, object value, bool reset)
        {
            this.EnsureWritable();
            return this.green.MAdd(redSymbol.Green, property, this.ToGreenValue(value), reset);
        }

        internal bool MLazyAdd(MutableSymbolBase redSymbol, ModelProperty property, Func<object> value, bool reset)
        {
            this.EnsureWritable();
            return this.green.MLazyAdd(redSymbol.Green, property, new GreenLazyValue(value), reset);
        }

        internal bool MAddRange(MutableSymbolBase redSymbol, ModelProperty property, IEnumerable<object> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MAddRange(redSymbol.Green, property, values.Select(v => this.ToGreenValue(v)), reset);
        }

        internal bool MLazyAddRange(MutableSymbolBase redSymbol, ModelProperty property, Func<IEnumerable<object>> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MLazyAddRange(redSymbol.Green, property, new GreenLazyList(values), reset);
        }

        internal bool MLazyAddRange(MutableSymbolBase redSymbol, ModelProperty property, IEnumerable<Func<object>> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MLazyAddRange(redSymbol.Green, property, values.Select(v => new GreenLazyValue(v)), reset);
        }

        internal void MEvaluateLazy(MutableSymbolBase redSymbol)
        {
            this.EnsureWritable();
            this.green.MEvaluateLazy(redSymbol.Green);
        }

        internal bool MChildLazyAdd(MutableSymbolBase redSymbol, ModelProperty child, ModelProperty property, Func<object> value, bool reset)
        {
            this.EnsureWritable();
            if (property.IsCollection) throw new ModelException("The property must not be a collection.");
            return this.green.MChildLazySet(redSymbol.Green, child, property, new GreenLazyValue(value), reset);
        }

        internal bool MChildLazyAddRange(MutableSymbolBase redSymbol, ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MChildLazyAddRange(redSymbol.Green, child, property, new GreenLazyList(values), reset);
        }

        internal bool MChildLazyAddRange(MutableSymbolBase redSymbol, ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MChildLazyAddRange(redSymbol.Green, child, property, values.Select(v => new GreenLazyValue(v)), reset);
        }

        internal bool MChildLazyClear(MutableSymbolBase redSymbol, ModelProperty child)
        {
            this.EnsureWritable();
            return this.green.MChildLazyClear(redSymbol.Green, child);
        }

        internal bool MChildLazyClear(MutableSymbolBase redSymbol, ModelProperty child, ModelProperty property)
        {
            this.EnsureWritable();
            return this.green.MChildLazyClear(redSymbol.Green, child, property);
        }

        internal bool MRemove(MutableSymbolBase redSymbol, ModelProperty property, object value, bool removeAll)
        {
            this.EnsureWritable();
            return this.green.MRemove(redSymbol.Green, property, value, removeAll);
        }

        internal void MUnset(MutableSymbolBase redSymbol, ModelProperty property)
        {
            this.EnsureWritable();
            this.green.MUnset(redSymbol.Green, property);
        }

        internal bool MIsCreated(MutableSymbolBase redSymbol)
        {
            return this.green.MIsCreated(redSymbol.Green);
        }

        internal void MMakeCreated(MutableSymbolBase redSymbol)
        {
            this.EnsureWritable();
            this.green.MMakeCreated(redSymbol.Green);
        }
    }

    /*
        public sealed class ImmutableRedModelPart : RedModelPart
        {
            private GreenModelPart green;
            private ImmutableRedModel model;

            internal ImmutableRedModelPart(GreenModelPart green, ImmutableRedModel model)
            {
                if (!green.IsReadOnly) throw new ModelException("The green model must be read-only.");
                this.green = green;
                this.model = model;
            }

            public ImmutableRedModel Model
            {
                get { return this.model; }
            }

            public bool ContainsSymbol(RedSymbol symbol)
            {
                if (symbol is ImmutableRedSymbolBase)
                {
                    return this.green.ContainsSymbol(((ImmutableRedSymbolBase)symbol).Green);
                }
                if (symbol is MutableRedSymbolBase)
                {
                    return this.green.ContainsSymbol(((MutableRedSymbolBase)symbol).Green);
                }
                return false;
            }

            internal object GetValue(ImmutableRedSymbolBase symbol, ModelProperty property)
            {
                Debug.Assert(!property.IsCollection);
                object greenObject = this.green.GetValue(symbol.Green, property, false);
                return this.ToRedValue(greenObject);
            }

            internal ImmutableRedList<T> GetList<T>(ImmutableRedSymbolBase symbol, ModelProperty property)
            {
                Debug.Assert(property.IsCollection);
                object greenObject = this.green.GetValue(symbol.Green, property, false);
                if (greenObject is GreenList)
                {
                    return new ImmutableRedList<T>((GreenList)greenObject, this);
                }
                else
                {
                    return null;
                }
            }

            internal List<T> CreateListItems<T>(IInternalReadOnlyCollection list)
            {
                List<T> result = new List<T>();
                foreach (var greenObject in list.Green)
                {
                    object redObject = greenObject;
                    if (greenObject is SymbolId)
                    {
                        redObject = this.model.GetRedSymbol((SymbolId)greenObject);
                        Debug.Assert(redObject != null);
                    }
                    result.Add((T)redObject);
                }
                return result;
            }

            internal ImmutableRedSymbol MParent(ImmutableRedSymbolBase redSymbol)
            {
                return this.model.GetRedSymbol(this.green.MParent(redSymbol.Green));
            }

            internal IReadOnlyList<ImmutableRedSymbol> MChildren(ImmutableRedSymbolBase redSymbol)
            {
                return new ImmutableReadOnlyRedList<ImmutableRedSymbolBase>(this.green.MChildren(redSymbol.Green), this);
            }

            internal IReadOnlyList<ModelProperty> MProperties(ImmutableRedSymbolBase redSymbol)
            {
                return ModelProperty.GetPropertiesForType(redSymbol.GetType());
            }

            internal IReadOnlyList<ModelProperty> MAllProperties(ImmutableRedSymbolBase redSymbol)
            {
                return this.green.MAllProperties(redSymbol.Green);
            }

            internal object MGet(ImmutableRedSymbolBase redSymbol, ModelProperty property)
            {
                if (property.IsCollection)
                {
                    return this.GetList<object>(redSymbol, property);
                }
                else
                {
                    return this.GetValue(redSymbol, property);
                }
            }

            internal bool MIsSet(ImmutableRedSymbolBase redSymbol, ModelProperty property)
            {
                return this.green.MIsSet(redSymbol.Green, property);
            }

            internal ModelProperty MGetProperty(ImmutableRedSymbolBase redSymbol, string name)
            {
                return ModelProperty.GetPropertiesForType(redSymbol.GetType()).FirstOrDefault(p => p.Name == name);
            }

            internal IReadOnlyList<ModelProperty> MGetAllProperties(ImmutableRedSymbolBase redSymbol, string name)
            {
                return this.green.MGetAllProperties(redSymbol.Green, name);
            }

            internal bool MHasLazy(ImmutableRedSymbolBase redSymbol, ModelProperty property)
            {
                return this.green.MHasLazy(redSymbol.Green, property);
            }

            internal bool MIsAttached(ImmutableRedSymbolBase redSymbol, ModelProperty property)
            {
                return !ModelProperty.GetDeclaredPropertiesForType(redSymbol.GetType()).Contains(property);
            }

            internal bool MTryGet(ImmutableRedSymbolBase redSymbol, ModelProperty property, out object value)
            {
                return this.green.MTryGet(redSymbol.Green, property, out value);
            }

            internal object ToGreenValue(object value)
            {
                if (value is ImmutableRedSymbolBase)
                {
                    return ((ImmutableRedSymbolBase)value).Green;
                }
                else if (value is MutableRedSymbolBase)
                {
                    Debug.Assert(false);
                    return ((MutableRedSymbolBase)value).Green;
                }
                return value;
            }

            internal object ToRedValue(object value)
            {
                if (value is GreenLazyValue)
                {
                    Debug.Assert(false);
                    return null;
                }
                else if (value is GreenLazyList)
                {
                    Debug.Assert(false);
                    return null;
                }
                else if (value is GreenList)
                {
                    Debug.Assert(false);
                    return null;
                }
                else if (value is SymbolId)
                {
                    return this.model.GetRedSymbol((SymbolId)value);
                }
                return value;
            }
        }

        public sealed class MutableRedModelPart : RedModelPart
        {
            private GreenModelPart green;
            private MutableRedModel model;

            internal MutableRedModelPart(GreenModelPart green, MutableRedModel model)
            {
                this.green = green;
                this.model = model;
            }

            public MutableRedModel Model
            {
                get { return this.model; }
            }

            public bool ContainsSymbol(RedSymbol symbol)
            {
                if (symbol is ImmutableRedSymbolBase)
                {
                    return this.green.ContainsSymbol(((ImmutableRedSymbolBase)symbol).Green);
                }
                if (symbol is MutableRedSymbolBase)
                {
                    return this.green.ContainsSymbol(((MutableRedSymbolBase)symbol).Green);
                }
                return false;
            }
        }
    */
    public sealed class RedModelTransaction : IDisposable
    {
        private MutableModel model;
        private CollectionTxScope txScope;

        internal RedModelTransaction(MutableModel model)
        {
            this.model = model;
            this.txScope = new CollectionTxScope();
        }

        internal MutableModel Model { get { return this.model; } }
        internal TransactionContexState State { get { return this.txScope.State; } }

        public void Commit()
        {
            this.txScope.Commit();
        }

        public void Rollback()
        {
            this.txScope.Rollback();
        }

        public void Dispose()
        {
            this.txScope.Dispose();
        }
    }
}
