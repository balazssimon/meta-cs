﻿using MetaDslx.Core.Collections.Transactional;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        private ImmutableModelGroup group;
        private bool cachedSymbols;
        private ImmutableDictionary<SymbolId, IImmutableSymbol> symbols;
        private WeakReference<MutableModel> mutableModel;

        internal ImmutableModel(GreenModel green, ImmutableModelGroup group, MutableModel mutableModel)
        {
            this.green = green;
            this.group = group;
            this.cachedSymbols = false;
            this.symbols = ImmutableDictionary<SymbolId, IImmutableSymbol>.Empty;
            this.mutableModel = new WeakReference<MutableModel>(mutableModel);
        }

        public bool IsReadOnly
        {
            get { return true; }
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

        public MutableModel ToMutable(bool createNew = false)
        {
            MutableModel result = null;
            if (!createNew)
            {
                lock (this.mutableModel)
                {
                    if (this.mutableModel.TryGetTarget(out result) && result != null)
                    {
                        return result; 
                    }
                }
            }
            MutableModel newModel = null;
            if (this.group != null)
            {
                MutableModelGroup mutableGroup = this.group.ToMutable(createNew);
                mutableGroup.Models.TryGetValue(this.green.Id, out newModel);
            }
            else
            {
                newModel = new MutableModel(this.green, null, false, this);
            }
            if (newModel != null)
            {
                if (!createNew)
                {
                    lock (this.mutableModel)
                    {
                        MutableModel oldModel;
                        if (this.mutableModel.TryGetTarget(out oldModel) && oldModel != null)
                        {
                            return oldModel;
                        }
                        else
                        {
                            this.mutableModel.SetTarget(newModel);
                        }
                    }
                }
            }
            return newModel;
        }

        internal object ToGreenValue(object value)
        {
            if (value is ImmutableSymbolBase)
            {
                return ((ImmutableSymbolBase)value).Id;
            }
            else if (value is MutableSymbolBase)
            {
                Debug.Assert(false);
                return ((MutableSymbolBase)value).Id;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue();
                if (value is ImmutableSymbolBase)
                {
                    return (ImmutableSymbolBase)value;
                }
                else if (value is MutableSymbolBase)
                {
                    return ((MutableSymbolBase)value).ToImmutable();
                }
            }
            else if (value is GreenLazyValue)
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

        public IImmutableSymbol GetSymbol(ISymbol symbol)
        {
            if (symbol is ImmutableSymbolBase)
            {
                return this.GetRedSymbol(((ImmutableSymbolBase)symbol).Id);
            }
            if (symbol is MutableSymbolBase)
            {
                return this.GetRedSymbol(((MutableSymbolBase)symbol).Id);
            }
            return null;
        }

        public bool ContainsSymbol(ISymbol symbol)
        {
            if (symbol is ImmutableSymbolBase)
            {
                return this.green.ContainsSymbol(((ImmutableSymbolBase)symbol).Id);
            }
            if (symbol is MutableSymbolBase)
            {
                return this.green.ContainsSymbol(((MutableSymbolBase)symbol).Id);
            }
            return false;
        }

        internal IImmutableSymbol GetRedSymbol(SymbolId green)
        {
            if (green == null) return null;
            if (!this.green.ContainsSymbol(green)) return null;
            IImmutableSymbol red;
            if (!this.symbols.TryGetValue(green, out red))
            {
                red = this.CreateRedSymbol(green);
            }
            return red;
        }

        private IImmutableSymbol CreateRedSymbol(SymbolId green)
        {
            ImmutableDictionary<SymbolId, IImmutableSymbol> redSymbols = this.symbols;
            IImmutableSymbol red = green.CreateImmutable(this, green);
            redSymbols = redSymbols.Add(green, red);
            Interlocked.Exchange(ref this.symbols, redSymbols);
            IImmutableSymbol result;
            if (this.symbols != redSymbols && this.symbols.TryGetValue(green, out result) && result != null)
            {
                return result;
            }
            return red;
        }

        private void CacheSymbols()
        {
            if (this.cachedSymbols) return;
            lock (this)
            {
                if (this.cachedSymbols) return;
                this.cachedSymbols = true;
                ImmutableDictionary<SymbolId, IImmutableSymbol> redSymbols = this.symbols;
                foreach (var greenId in this.green.Symbols)
                {
                    if (!redSymbols.ContainsKey(greenId))
                    {
                        IImmutableSymbol red = greenId.CreateImmutable(this, greenId);
                        redSymbols = redSymbols.Add(greenId, red);
                    }
                }
                this.symbols = redSymbols;
            }
        }

        internal ImmutableList<T> CreateListItems<T>(IInternalReadOnlyCollection list)
        {
            ImmutableList<T> result = ImmutableList<T>.Empty;
            foreach (var greenObject in list.Green)
            {
                object redObject = greenObject;
                if (greenObject is SymbolId)
                {
                    redObject = this.GetRedSymbol((SymbolId)greenObject);
                    Debug.Assert(redObject != null);
                }
                result = result.Add((T)redObject);
            }
            return result;
        }
        /*
        internal object GetValue(ImmutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            object greenObject = this.green.GetValue(symbol.Id, property, false);
            return this.ToRedValue(greenObject);
        }

        internal ImmutableModelList<T> GetList<T>(ImmutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            object greenObject = this.green.GetValue(symbol.Id, property, false);
            if (greenObject is GreenList)
            {
                return new ImmutableModelList<T>((GreenList)greenObject, this);
            }
            else
            {
                return null;
            }
        }

        internal IImmutableSymbol MParent(ImmutableSymbolBase redSymbol)
        {
            return this.GetRedSymbol(this.green.MParent(redSymbol.Id));
        }

        internal IReadOnlyList<IImmutableSymbol> MChildren(ImmutableSymbolBase redSymbol)
        {
            return new ReadOnlyImmutableModelList<ImmutableSymbolBase>(this.green.MChildren(redSymbol.Id), this);
        }

        internal IReadOnlyList<ModelProperty> MProperties(ImmutableSymbolBase redSymbol)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType());
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(ImmutableSymbolBase redSymbol)
        {
            return this.green.MAllProperties(redSymbol.Id);
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
            return this.green.MIsSet(redSymbol.Id, property);
        }

        internal ModelProperty MGetProperty(ImmutableSymbolBase redSymbol, string name)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType()).FirstOrDefault(p => p.Name == name);
        }

        internal IReadOnlyList<ModelProperty> MGetAllProperties(ImmutableSymbolBase redSymbol, string name)
        {
            return this.green.MGetAllProperties(redSymbol.Id, name);
        }

        internal bool MHasLazy(ImmutableSymbolBase redSymbol, ModelProperty property)
        {
            return this.green.MHasLazy(redSymbol.Id, property);
        }

        internal bool MIsAttached(ImmutableSymbolBase redSymbol, ModelProperty property)
        {
            return !ModelProperty.GetDeclaredPropertiesForType(redSymbol.GetType()).Contains(property);
        }

        internal bool MTryGet(ImmutableSymbolBase redSymbol, ModelProperty property, out object value)
        {
            return this.green.MTryGet(redSymbol.Id, property, out value);
        }
        */
    }

    public sealed class ImmutableModelGroup
    {
        private GreenModelGroup green;
        private ImmutableDictionary<ModelId, ImmutableModel> references;
        private ImmutableDictionary<ModelId, ImmutableModel> models;
        private WeakReference<MutableModelGroup> mutableGroup;

        internal ImmutableModelGroup(GreenModelGroup green, MutableModelGroup mutableGroup)
        {
            this.green = green;
            this.mutableGroup = new WeakReference<MutableModelGroup>(mutableGroup);
            if (mutableGroup != null)
            {
                this.models = green.Models.ToImmutableDictionary(v => v.Id, v => new ImmutableModel(v, this, mutableGroup.Models.GetValueOrDefault(v.Id)));
                this.references = green.References.ToImmutableDictionary(v => v.Id, v => new ImmutableModel(v, this, mutableGroup.References.GetValueOrDefault(v.Id)));
            }
            else
            {
                this.models = green.Models.ToImmutableDictionary(v => v.Id, v => new ImmutableModel(v, this, null));
                this.references = green.References.ToImmutableDictionary(v => v.Id, v => new ImmutableModel(v, this, null));
            }
        }

        private ImmutableModelGroup(GreenModelGroup green, ImmutableDictionary<ModelId, ImmutableModel> models, ImmutableDictionary<ModelId, ImmutableModel> references)
        {
            this.green = green;
            this.models = models;
            this.references = references;
        }

        private ImmutableModelGroup Update(GreenModelGroup green, ImmutableDictionary<ModelId, ImmutableModel> models, ImmutableDictionary<ModelId, ImmutableModel> references)
        {
            if (this.green != green || this.models != models || this.references != references)
            {
                return new ImmutableModelGroup(green, models, references);
            }
            return this;
        }

        public MutableModelGroup ToMutable(bool createNew = false)
        {
            MutableModelGroup result;
            if (!createNew)
            {
                lock(this.mutableGroup)
                {
                    if (this.mutableGroup.TryGetTarget(out result) && result != null)
                    {
                        return result;
                    }
                }
            }
            result = new MutableModelGroup(this.green, this);
            if (!createNew)
            {
                lock(this.mutableGroup)
                {
                    MutableModelGroup oldGroup = null;
                    if (this.mutableGroup.TryGetTarget(out oldGroup) && oldGroup != null)
                    {
                        return oldGroup;
                    }
                    else
                    {
                        this.mutableGroup.SetTarget(result);
                        return result;
                    }
                }
            }
            return result;
        }

        internal GreenModelGroup Green
        {
            get { return this.green; }
        }

        public ImmutableDictionary<ModelId, ImmutableModel> Models
        {
            get { return this.models; }
        }

        public ImmutableDictionary<ModelId, ImmutableModel> References
        {
            get { return this.references; }
        }
    }

    internal class MutableModelState
    {
        private GreenModelTransaction greenTransaction;
        private bool cachedSymbols;
        private ImmutableDictionary<SymbolId, IMutableSymbol> symbols;
        private bool allowLazyEval;
        private WeakReference<ImmutableModel> immutableModel;

        internal MutableModelState(
            GreenModelTransaction greenTransaction,
            bool cachedSymbols,
            ImmutableDictionary<SymbolId, IMutableSymbol> symbols,
            bool allowLazyEval,
            WeakReference<ImmutableModel> immutableModel)
        {
            this.greenTransaction = greenTransaction;
            this.cachedSymbols = cachedSymbols;
            this.symbols = symbols;
            this.allowLazyEval = allowLazyEval;
            this.immutableModel = immutableModel;
        }

        internal MutableModelState Update(
            GreenModelTransaction greenTransaction,
            bool cachedSymbols,
            ImmutableDictionary<SymbolId, IMutableSymbol> symbols,
            bool allowLazyEval,
            WeakReference<ImmutableModel> immutableModel)
        {
            if (this.greenTransaction != greenTransaction || this.cachedSymbols != cachedSymbols ||
                this.symbols != symbols || this.allowLazyEval != allowLazyEval || this.immutableModel != immutableModel)
            {
                return new MutableModelState(greenTransaction, cachedSymbols, symbols, allowLazyEval, immutableModel);
            }
            return this;
        }

        internal GreenModelTransaction GreenTransaction { get { return this.greenTransaction; } }
        internal bool CachedSymbols { get { return this.cachedSymbols; } }
        internal ImmutableDictionary<SymbolId, IMutableSymbol> Symbols { get { return this.symbols; } }
        internal bool AllowLazyEval { get { return this.allowLazyEval; } }
        internal WeakReference<ImmutableModel> ImmutableModel { get { return this.immutableModel; } }

        internal MutableModelState WithGreenTransaction(GreenModelTransaction greenTransaction)
        {
            return this.Update(greenTransaction, this.cachedSymbols, this.symbols, this.allowLazyEval, this.immutableModel);
        }

        internal MutableModelState WithSymbol(SymbolId id, IMutableSymbol symbol)
        {
            return this.Update(this.greenTransaction, this.cachedSymbols, symbols.SetItem(id, symbol), this.allowLazyEval, this.immutableModel);
        }

        internal MutableModelState WithSymbols(ImmutableDictionary<SymbolId, IMutableSymbol> symbols, bool cachedSymbols)
        {
            return this.Update(this.greenTransaction, cachedSymbols, symbols, this.allowLazyEval, this.immutableModel);
        }

        internal MutableModelState WithAllowLazyEval(bool allowLazyEval)
        {
            return this.Update(this.greenTransaction, this.cachedSymbols, this.symbols, allowLazyEval, this.immutableModel);
        }

        internal MutableModelState BeginTransaction()
        {
            ImmutableModel im = null;
            this.immutableModel.TryGetTarget(out im);
            return this.Update(new GreenModelTransaction(this.greenTransaction), this.cachedSymbols, this.symbols, this.allowLazyEval, new WeakReference<ImmutableModel>(im));
        }

        internal MutableModelState BeginGroupTransaction(GreenModelTransaction gtx)
        {
            ImmutableModel im = null;
            this.immutableModel.TryGetTarget(out im);
            return this.Update(gtx, this.cachedSymbols, this.symbols, this.allowLazyEval, new WeakReference<ImmutableModel>(im));
        }
    }

    public sealed class MutableModel : RedModel
    {
        private ModelId id;
        private MutableModelGroup group;
        private bool readOnly;
        private MutableModelState state;
        private ModelTransaction transaction;

        internal MutableModel(GreenModel green, MutableModelGroup group, bool readOnly, ImmutableModel immutableModel)
        {
            this.id = green.Id;
            this.group = group;
            this.readOnly = readOnly;
            this.state = new MutableModelState(
                group != null ? group.GreenTransaction : new GreenModelTransaction(null, green),
                false,
                ImmutableDictionary<SymbolId, IMutableSymbol>.Empty,
                true,
                new WeakReference<ImmutableModel>(immutableModel));
            this.transaction = null;
        }

        private void Update(MutableModelState state)
        {
            Interlocked.Exchange(ref this.state, state);
        }

        internal MutableModelState State
        {
            get { return this.state; }
        }

        public bool IsReadOnly
        {
            get { return this.readOnly; }
        }

        internal ModelId Id
        {
            get { return this.id; }
        }

        internal GreenModel Green
        {
            get { return this.state.GreenTransaction.GetModel(this.id); }
        }

        internal GreenModelTransaction GreenTransaction
        {
            get { return this.state.GreenTransaction; }
        }

        internal ModelTransaction CurrentTransaction
        {
            get { return this.transaction; }
        }

        public IEnumerable<IMutableSymbol> Symbols
        {
            get
            {
                if (!this.state.CachedSymbols) this.CacheSymbols();
                return this.state.Symbols.Values;
            }
        }

        public bool AllowLazyEvaluation
        {
            get { return this.state.AllowLazyEval; }
            set { this.Update(this.state.WithAllowLazyEval(value)); }
        }

        public ImmutableModel ToImmutable()
        {
            ImmutableModel result;
            if (this.group != null)
            {
                ImmutableModelGroup immutableGroup = this.group.ToImmutable();
                if (immutableGroup != null)
                {
                    if (immutableGroup.Models.TryGetValue(this.id, out result))
                    {
                        return result;
                    }
                    if (immutableGroup.References.TryGetValue(this.id, out result))
                    {
                        return result;
                    }
                }
            }
            else
            {
                GreenModel currentGreen = this.Green;
                if (this.state.ImmutableModel.TryGetTarget(out result) && result != null && result.Green == currentGreen)
                {
                    return result;
                }
                else
                {
                    result = new ImmutableModel(currentGreen, null, this);
                    this.state.ImmutableModel.SetTarget(result);
                    return result;
                }
            }
            return null;
        }

        internal object ToGreenValue(object value)
        {
            if (value is ImmutableSymbolBase)
            {
                Debug.Assert(false);
                return ((ImmutableSymbolBase)value).Id;
            }
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).Id;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue();
                if (value is ImmutableSymbolBase)
                {
                    return ((ImmutableSymbolBase)value).ToMutable();
                }
                else if (value is MutableSymbolBase)
                {
                    return (MutableSymbolBase)value;
                }
                return redValue;
            }
            else if (value is GreenLazyValue)
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

        public IMutableSymbol GetSymbol(ISymbol symbol)
        {
            if (symbol is ImmutableSymbolBase)
            {
                return this.GetRedSymbol(((ImmutableSymbolBase)symbol).Id);
            }
            if (symbol is MutableSymbolBase)
            {
                return this.GetRedSymbol(((MutableSymbolBase)symbol).Id);
            }
            return null;
        }

        public bool ContainsSymbol(ISymbol symbol)
        {
            if (symbol is ImmutableSymbolBase)
            {
                return this.Green.ContainsSymbol(((ImmutableSymbolBase)symbol).Id);
            }
            if (symbol is MutableSymbolBase)
            {
                return this.Green.ContainsSymbol(((MutableSymbolBase)symbol).Id);
            }
            return false;
        }

        internal IMutableSymbol GetRedSymbol(SymbolId id)
        {
            if (id == null) return null;
            if (!this.Green.ContainsSymbol(id)) return null;
            IMutableSymbol red;
            if (this.state.Symbols.TryGetValue(id, out red))
            {
                return red;
            }
            red = id.CreateMutable(this, id);
            this.Update(this.state.WithSymbol(id, red));
            return red;
        }

        private void CacheSymbols()
        {
            if (this.state.CachedSymbols) return;
            ImmutableDictionary<SymbolId, IMutableSymbol> redSymbols = this.state.Symbols;
            foreach (var greenId in this.Green.Symbols)
            {
                if (!redSymbols.ContainsKey(greenId))
                {
                    IMutableSymbol red = greenId.CreateMutable(this, greenId);
                    redSymbols = redSymbols.Add(greenId, red);
                }
            }
            this.Update(this.state.WithSymbols(redSymbols, true));
        }

        public ModelTransaction BeginTransaction()
        {
            if (!this.readOnly) throw new ModelException("Cannot change a read-only model.");
            if (this.group != null)
            {
                return this.group.BeginTransaction();
            }
            else
            {
                this.transaction = new ModelTransaction(this, this.transaction);
                this.Update(this.state.BeginTransaction());
                return this.transaction;
            }
        }

        internal MutableModelState BeginGroupTransaction(ModelTransaction tx, GreenModelTransaction gtx)
        {
            MutableModelState result = this.state;
            this.Update(this.state.BeginGroupTransaction(gtx));
            this.transaction = tx;
            return result;
        }

        internal void CommitTransaction(ModelTransaction transaction)
        {
            if (this.transaction != transaction)
            {
                throw new ModelException("Only the current transaction can be finished.");
            }
            this.transaction = this.transaction.Parent;
        }

        internal void RollbackTransaction(ModelTransaction transaction)
        {
            if (this.transaction != transaction)
            {
                throw new ModelException("Only the current transaction can be finished.");
            }
            this.Update(transaction.OriginalModelState);
            this.transaction = this.transaction.Parent;
        }

        internal void CommitGroupTransaction(ModelTransaction tx)
        {
            this.transaction = tx.Parent;
        }

        internal void RollbackGroupTransaction(ModelTransaction tx)
        {
            MutableModelState originalState;
            if (tx.OriginalModelStates.TryGetValue(this.id, out originalState))
            {
                this.Update(originalState);
            }
            this.transaction = tx.Parent;
        }

        public IMutableSymbol AddSymbol(SymbolId id)
        {
            this.GreenTransaction.AddSymbol(this.id, id);
            return this.GetRedSymbol(id);
        }

        public void EvaluateLazyValues()
        {
            using (ModelTransaction tx = this.BeginTransaction())
            {
                GreenModelTransaction gtx = this.GreenTransaction;
                gtx.EvaluateLazyValues();
                tx.Commit();
            }
        }
        /*
        internal object GetValue(MutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            object greenObject;
            if (!this.AllowLazyEvaluation)
            {
                greenObject = this.green.GetValue(symbol.Id, property, false);
            }
            else
            {
                this.EnsureWritable("Cannot change a read-only mutable model. Create a new mutable model instead, and enable lazy evaluation mode.");
                greenObject = this.green.GetValue(symbol.Id, property, true);
            }
            return this.ToRedValue(greenObject);
        }

        internal Func<object> GetLazyValue(MutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            GreenLazyValue lazyValue = this.green.GetLazyValue(symbol.Id, property);
            if (lazyValue != null) return lazyValue.Lazy;
            else return null;
        }

        internal IMutableModelList<T> GetList<T>(MutableSymbolBase symbol, ModelProperty property, IMutableModelList<T> modelList)
        {
            Debug.Assert(property.IsCollection);
            object greenObject;
            if (!this.AllowLazyEvaluation)
            {
                greenObject = this.green.GetValue(symbol.Id, property, false);
            }
            else
            {
                this.EnsureWritable("Cannot change a read-only mutable model. Create a new mutable model instead, and enable lazy evaluation mode.");
                greenObject = this.green.GetValue(symbol.Id, property, true);
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
            return this.green.SetValue(symbol.Id, property, reassign, greenValue);
        }

        internal bool SetLazyValue(MutableSymbolBase symbol, ModelProperty property, Func<object> redLazy, bool reassign)
        {
            Debug.Assert(!property.IsCollection);
            this.EnsureWritable();
            if (redLazy == null) return false;
            return this.green.SetValue(symbol.Id, property, reassign, new GreenLazyValue(redLazy));
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
            return this.GetRedSymbol(this.green.MParent(redSymbol.Id));
        }

        internal IReadOnlyList<IMutableSymbol> MChildren(MutableSymbolBase redSymbol)
        {
            return new ReadOnlyMutableModelList<MutableSymbolBase>(this.green.MChildren(redSymbol.Id), this);
        }

        internal IReadOnlyList<ModelProperty> MProperties(MutableSymbolBase redSymbol)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType());
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(MutableSymbolBase redSymbol)
        {
            return this.green.MAllProperties(redSymbol.Id);
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
            return this.green.MIsSet(redSymbol.Id, property);
        }

        internal ModelProperty MGetProperty(MutableSymbolBase redSymbol, string name)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType()).FirstOrDefault(p => p.Name == name);
        }

        internal IReadOnlyList<ModelProperty> MGetAllProperties(MutableSymbolBase redSymbol, string name)
        {
            return this.green.MGetAllProperties(redSymbol.Id, name);
        }

        internal bool MHasLazy(MutableSymbolBase redSymbol, ModelProperty property)
        {
            return this.green.MHasLazy(redSymbol.Id, property);
        }

        internal bool MIsAttached(MutableSymbolBase redSymbol, ModelProperty property)
        {
            return !ModelProperty.GetDeclaredPropertiesForType(redSymbol.GetType()).Contains(property);
        }

        internal bool MTryGet(MutableSymbolBase redSymbol, ModelProperty property, out object value)
        {
            return this.green.MTryGet(redSymbol.Id, property, out value);
        }

        internal bool MAttachProperty(MutableSymbolBase redSymbol, ModelProperty property)
        {
            this.EnsureWritable();
            return this.green.MAttachProperty(redSymbol.Id, property);
        }

        internal bool MDetachProperty(MutableSymbolBase redSymbol, ModelProperty property)
        {
            this.EnsureWritable();
            return this.green.MDetachProperty(redSymbol.Id, property);
        }

        internal bool MClear(MutableSymbolBase redSymbol, ModelProperty property, bool clearLazy)
        {
            this.EnsureWritable();
            return this.green.MClear(redSymbol.Id, property, clearLazy);
        }

        internal bool MClearLazy(MutableSymbolBase redSymbol, ModelProperty property)
        {
            this.EnsureWritable();
            return this.green.MClearLazy(redSymbol.Id, property);
        }

        internal bool MAdd(MutableSymbolBase redSymbol, ModelProperty property, object value, bool reset)
        {
            this.EnsureWritable();
            return this.green.MAdd(redSymbol.Id, property, this.ToGreenValue(value), reset);
        }

        internal bool MLazyAdd(MutableSymbolBase redSymbol, ModelProperty property, Func<object> value, bool reset)
        {
            this.EnsureWritable();
            return this.green.MLazyAdd(redSymbol.Id, property, new GreenLazyValue(value), reset);
        }

        internal bool MAddRange(MutableSymbolBase redSymbol, ModelProperty property, IEnumerable<object> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MAddRange(redSymbol.Id, property, values.Select(v => this.ToGreenValue(v)), reset);
        }

        internal bool MLazyAddRange(MutableSymbolBase redSymbol, ModelProperty property, Func<IEnumerable<object>> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MLazyAddRange(redSymbol.Id, property, new GreenLazyList(values), reset);
        }

        internal bool MLazyAddRange(MutableSymbolBase redSymbol, ModelProperty property, IEnumerable<Func<object>> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MLazyAddRange(redSymbol.Id, property, values.Select(v => new GreenLazyValue(v)), reset);
        }

        internal void MEvaluateLazy(MutableSymbolBase redSymbol)
        {
            this.EnsureWritable();
            this.green.MEvaluateLazy(redSymbol.Id);
        }

        internal bool MChildLazyAdd(MutableSymbolBase redSymbol, ModelProperty child, ModelProperty property, Func<object> value, bool reset)
        {
            this.EnsureWritable();
            if (property.IsCollection) throw new ModelException("The property must not be a collection.");
            return this.green.MChildLazySet(redSymbol.Id, child, property, new GreenLazyValue(value), reset);
        }

        internal bool MChildLazyAddRange(MutableSymbolBase redSymbol, ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MChildLazyAddRange(redSymbol.Id, child, property, new GreenLazyList(values), reset);
        }

        internal bool MChildLazyAddRange(MutableSymbolBase redSymbol, ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset)
        {
            this.EnsureWritable();
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.green.MChildLazyAddRange(redSymbol.Id, child, property, values.Select(v => new GreenLazyValue(v)), reset);
        }

        internal bool MChildLazyClear(MutableSymbolBase redSymbol, ModelProperty child)
        {
            this.EnsureWritable();
            return this.green.MChildLazyClear(redSymbol.Id, child);
        }

        internal bool MChildLazyClear(MutableSymbolBase redSymbol, ModelProperty child, ModelProperty property)
        {
            this.EnsureWritable();
            return this.green.MChildLazyClear(redSymbol.Id, child, property);
        }

        internal bool MRemove(MutableSymbolBase redSymbol, ModelProperty property, object value, bool removeAll)
        {
            this.EnsureWritable();
            return this.green.MRemove(redSymbol.Id, property, value, removeAll);
        }

        internal void MUnset(MutableSymbolBase redSymbol, ModelProperty property)
        {
            this.EnsureWritable();
            this.green.MUnset(redSymbol.Id, property);
        }

        internal bool MIsCreated(MutableSymbolBase redSymbol)
        {
            return this.green.MIsCreated(redSymbol.Id);
        }

        internal void MMakeCreated(MutableSymbolBase redSymbol)
        {
            this.EnsureWritable();
            this.green.MMakeCreated(redSymbol.Id);
        }
        */
    }

    internal class MutableModelGroupState
    {
        private GreenModelTransaction greenTransaction;
        private WeakReference<ImmutableModelGroup> immutableModelGroup;
        private ImmutableDictionary<ModelId, MutableModel> references;
        private ImmutableDictionary<ModelId, MutableModel> models;

        internal MutableModelGroupState(
            GreenModelTransaction greenTransaction,
            ImmutableDictionary<ModelId, MutableModel> models,
            ImmutableDictionary<ModelId, MutableModel> references,
            WeakReference<ImmutableModelGroup> immutableModelGroup)
        {
            this.greenTransaction = greenTransaction;
            this.immutableModelGroup = immutableModelGroup;
        }

        internal MutableModelGroupState Update(
            GreenModelTransaction greenTransaction,
            ImmutableDictionary<ModelId, MutableModel> models,
            ImmutableDictionary<ModelId, MutableModel> references,
            WeakReference<ImmutableModelGroup> immutableModelGroup)
        {
            if (this.greenTransaction != greenTransaction || this.models != models || this.references != references || 
                this.immutableModelGroup != immutableModelGroup)
            {
                return new MutableModelGroupState(greenTransaction, models, references, immutableModelGroup);
            }
            return this;
        }

        internal GreenModelTransaction GreenTransaction { get { return this.greenTransaction; } }
        internal ImmutableDictionary<ModelId, MutableModel> Models { get { return this.models; } }
        internal ImmutableDictionary<ModelId, MutableModel> References { get { return this.references; } }
        internal WeakReference<ImmutableModelGroup> ImmutableModelGroup { get { return this.immutableModelGroup; } }

        internal MutableModelGroupState WithGreenTransaction(GreenModelTransaction greenTransaction)
        {
            return this.Update(greenTransaction, this.models, this.references, this.immutableModelGroup);
        }

        internal MutableModelGroupState WithModel(MutableModel model)
        {
            return this.Update(greenTransaction, this.models.SetItem(model.Id, model), this.references, this.immutableModelGroup);
        }

        internal MutableModelGroupState WithReference(MutableModel model)
        {
            return this.Update(greenTransaction, this.models, this.references.SetItem(model.Id, model), this.immutableModelGroup);
        }

        internal MutableModelGroupState BeginTransaction()
        {
            ImmutableModelGroup img = null;
            this.immutableModelGroup.TryGetTarget(out img);
            return this.Update(new GreenModelTransaction(this.greenTransaction), this.models, this.references, new WeakReference<ImmutableModelGroup>(img));
        }
    }

    public sealed class MutableModelGroup
    {
        private MutableModelGroupState state;
        private ModelTransaction transaction = null;

        internal MutableModelGroup(GreenModelGroup green, ImmutableModelGroup immutableGroup)
        {
            ImmutableDictionary<ModelId, MutableModel> models;
            ImmutableDictionary<ModelId, MutableModel> references;
            if (immutableGroup != null)
            {
                models = green.Models.ToImmutableDictionary(v => v.Id, v => new MutableModel(v, this, false, immutableGroup.Models.GetValueOrDefault(v.Id)));
                references = green.References.ToImmutableDictionary(v => v.Id, v => new MutableModel(v, this, true, immutableGroup.Models.GetValueOrDefault(v.Id)));
            }
            else
            {
                models = green.Models.ToImmutableDictionary(v => v.Id, v => new MutableModel(v, this, false, null));
                references = green.References.ToImmutableDictionary(v => v.Id, v => new MutableModel(v, this, true, null));
            }
            this.state = new MutableModelGroupState(new GreenModelTransaction(green, null), models, references, new WeakReference<ImmutableModelGroup>(immutableGroup));
        }

        private void Update(MutableModelGroupState state)
        {
            Interlocked.Exchange(ref this.state, state);
        }

        public ImmutableModelGroup ToImmutable()
        {
            ImmutableModelGroup result;
            if (this.state.ImmutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result;
            }
            result = new ImmutableModelGroup(this.Green, this);
            this.state.ImmutableModelGroup.SetTarget(result);
            return result;
        }

        internal MutableModelGroupState State
        {
            get { return this.state; }
        }

        internal GreenModelGroup Green
        {
            get { return this.state.GreenTransaction.Group; }
        }

        internal GreenModelTransaction GreenTransaction
        {
            get { return this.state.GreenTransaction; }
        }

        internal ModelTransaction CurrentTransaction
        {
            get { return this.transaction; }
        }

        public ImmutableDictionary<ModelId, MutableModel> Models
        {
            get { return this.state.Models; }
        }

        public ImmutableDictionary<ModelId, MutableModel> References
        {
            get { return this.state.References; }
        }

        public ModelTransaction BeginTransaction()
        {
            this.transaction = new ModelTransaction(this, this.transaction);
            this.Update(this.state.BeginTransaction());
            GreenModelTransaction gtx = this.state.GreenTransaction;
            Dictionary<ModelId, MutableModelState> modelStates = new Dictionary<ModelId, MutableModelState>();
            foreach (var model in this.Models)
            {
                modelStates.Add(model.Key, model.Value.BeginGroupTransaction(this.transaction, gtx));
            }
            this.transaction.SetOriginalModelStates(modelStates);
            return this.transaction;
        }

        internal void CommitTransaction(ModelTransaction transaction)
        {
            if (this.transaction != transaction)
            {
                throw new ModelException("Only the current transaction can be finished.");
            }
            foreach (var model in this.Models)
            {
                model.Value.CommitGroupTransaction(this.transaction);
            }
            this.transaction = this.transaction.Parent;
        }

        internal void RollbackTransaction(ModelTransaction transaction)
        {
            if (this.transaction != transaction)
            {
                throw new ModelException("Only the current transaction can be finished.");
            }
            this.Update(transaction.OriginalGroupState);
            foreach (var model in this.Models)
            {
                model.Value.RollbackGroupTransaction(this.transaction);
            }
            this.transaction = this.transaction.Parent;
        }
    }

    [Flags]
    public enum ModelTransactionState : byte
    {
        None = 0,
        Commit = 1,
        Disposing = 2,
        Disposed = 4
    }

    public sealed class ModelTransaction : IDisposable
    {
        private MutableModelGroup group;
        private MutableModelGroupState originalGroupState;
        private Dictionary<ModelId, MutableModelState> originalModelStates;
        private MutableModel model;
        private MutableModelState originalModelState;
        private ModelTransaction parent;
        private ModelTransactionState state = ModelTransactionState.None;

        internal ModelTransaction(MutableModelGroup group, ModelTransaction parent)
        {
            this.group = group;
            this.originalGroupState = group.State;
            this.parent = parent;
        }

        internal ModelTransaction(MutableModel model, ModelTransaction parent)
        {
            this.model = model;
            this.originalModelState = model.State;
            this.parent = parent;
        }

        internal MutableModelGroup Group { get { return this.group; } }
        internal MutableModelGroupState OriginalGroupState { get { return this.originalGroupState; } }
        internal Dictionary<ModelId, MutableModelState> OriginalModelStates { get { return this.originalModelStates; } }
        internal MutableModel Model { get { return this.model; } }
        internal MutableModelState OriginalModelState { get { return this.originalModelState; } }
        internal ModelTransaction Parent { get { return this.parent; } }

        internal void SetOriginalModelStates(Dictionary<ModelId, MutableModelState> modelStates)
        {
            this.originalModelStates = modelStates;
        }

        public bool IsCommited { get { return (this.state & ModelTransactionState.Commit) != 0; } }

        public void Commit()
        {
            this.state |= ModelTransactionState.Commit;
        }

        public void Rollback()
        {
            this.state &= ~ModelTransactionState.Commit;
        }

        public void Dispose()
        {
            if ((this.state & ModelTransactionState.Disposing) != 0) return;
            this.state |= ModelTransactionState.Disposing;
            if (this.IsCommited)
            {
                if (this.group != null) this.group.CommitTransaction(this);
                else if (this.model != null) this.model.CommitTransaction(this);
            }
            else
            {
                if (this.group != null) this.group.RollbackTransaction(this);
                else if (this.model != null) this.model.RollbackTransaction(this);
            }
            this.state |= ModelTransactionState.Disposed;
        }
    }
}
