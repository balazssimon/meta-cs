using MetaDslx.Core.Collections.Transactional;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public enum LazyEvaluationMode
    {
        Evaluate,
        ThrowException,
        ReturnNull
    }

    public sealed class ImmutableRedModel 
    {
        private GreenModel green;
        private bool cached;
        private Dictionary<GreenSymbol, ImmutableRedSymbol> symbols;

        internal ImmutableRedModel(GreenModel green)
        {
            this.green = green;
            this.symbols = new Dictionary<GreenSymbol, ImmutableRedSymbol>();
            this.cached = false;
        }

        public ImmutableRedSymbol GetSymbol(ImmutableRedSymbol symbol)
        {
            return this.GetRedSymbol(((ImmutableRedSymbolBase)symbol).Green);
        }

        public ImmutableRedSymbol GetSymbol(MutableRedSymbol symbol)
        {
            return this.GetRedSymbol(((MutableRedSymbolBase)symbol).Green);
        }

        public bool ContainsSymbol(ImmutableRedSymbol symbol)
        {
            return this.green.ContainsSymbol(((ImmutableRedSymbolBase)symbol).Green);
        }

        public bool ContainsSymbol(MutableRedSymbol symbol)
        {
            return this.green.ContainsSymbol(((MutableRedSymbolBase)symbol).Green);
        }

        public MutableRedModel ToMutable()
        {
            return new MutableRedModel(this.green, this);
        }

        public IEnumerable<ImmutableRedSymbol> Symbols
        {
            get
            {
                if (!this.cached) this.CacheSymbols();
                return this.symbols.Values;
            }
        }

        internal object ToGreenValue(object redValue)
        {
            if (redValue is ImmutableRedSymbolBase)
            {
                return ((ImmutableRedSymbolBase)redValue).Green;
            }
            return redValue;
        }

        internal object ToRedValue(object redValue)
        {
            if (redValue == GreenModelTransaction.Unassigned)
            {
                return null;
            }
            else if (redValue is GreenSymbol)
            {
                return this.GetRedSymbol((GreenSymbol)redValue);
            }
            return redValue;
        }

        internal ImmutableRedSymbol GetRedSymbol(GreenSymbol green)
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

        internal object GetValue(ImmutableRedSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            object greenObject = this.green.GetValue(symbol.Green, property);
            return this.ToRedValue(greenObject);
        }

        internal ImmutableRedList<T> GetList<T>(ImmutableRedSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            object greenObject = this.green.GetValue(symbol.Green, property);
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
                if (greenObject is GreenSymbol)
                {
                    redObject = this.GetRedSymbol((GreenSymbol)greenObject);
                    Debug.Assert(redObject != null);
                }
                result.Add((T)redObject);
            }
            return result;
        }

        private void CacheSymbols()
        {
            if (this.cached) return;
            lock (this)
            {
                if (this.cached) return;
                foreach (var greenSymbol in this.green.Symbols)
                {
                    this.GetRedSymbol(greenSymbol);
                }
            }
        }

        internal ImmutableRedSymbol MParent(ImmutableRedSymbolBase redSymbol)
        {
            return this.GetRedSymbol(this.green.MParent(redSymbol.Green));
        }

        internal IEnumerable<ImmutableRedSymbol> MChildren(ImmutableRedSymbolBase redSymbol)
        {
            foreach (var child in this.green.MChildren(redSymbol.Green))
            {
                yield return this.GetRedSymbol(child);
            } 
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
    }

    public sealed class MutableRedModel 
    {
        private GreenModel green;
        private GreenModelTransaction transaction;
        private ImmutableRedModel originalImmutableModel;

        private bool finished = false;

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
            this.green = green;
            this.originalImmutableModel = originalImmutableModel;
            this.transaction = green.BeginTransaction(this);
        }

        public LazyEvaluationMode LazyMode
        {
            get { return this.transaction.LazyMode; }
            set { this.transaction.LazyMode = value; }
        }

        public RedModelTransaction BeginTransaction()
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return new RedModelTransaction(this);
        }

        public MutableRedSymbol GetSymbol(ImmutableRedSymbol symbol)
        {
            return this.GetRedSymbol(((ImmutableRedSymbolBase)symbol).Green);
        }

        public MutableRedSymbol GetSymbol(MutableRedSymbol symbol)
        {
            return this.GetRedSymbol(((MutableRedSymbolBase)symbol).Green);
        }

        public bool ContainsSymbol(ImmutableRedSymbol symbol)
        {
            return this.green.ContainsSymbol(((ImmutableRedSymbolBase)symbol).Green);
        }

        public bool ContainsSymbol(MutableRedSymbol symbol)
        {
            return this.green.ContainsSymbol(((MutableRedSymbolBase)symbol).Green);
        }

        public MutableRedSymbol AddSymbol(GreenSymbol symbol)
        {
            this.transaction.AddSymbol(symbol);
            return this.GetRedSymbol(symbol);
        }

        public void AddSymbol(ImmutableRedSymbol symbol)
        {
            this.transaction.AddSymbol(((ImmutableRedSymbolBase)symbol).Green);
        }

        public void RemoveSymbol(ImmutableRedSymbol symbol)
        {
            this.transaction.RemoveSymbol(((ImmutableRedSymbolBase)symbol).Green);
        }

        public void AddSymbol(MutableRedSymbol symbol)
        {
            this.transaction.AddSymbol(((MutableRedSymbolBase)symbol).Green);
        }

        public void RemoveSymbol(MutableRedSymbol symbol)
        {
            this.transaction.RemoveSymbol(((MutableRedSymbolBase)symbol).Green);
        }

        public void EvaluateLazy()
        {
            using (CollectionTxScope scope = new CollectionTxScope())
            {
                foreach (var symbol in this.transaction.Symbols)
                {
                    this.transaction.MEvaluateLazy(symbol);
                }
                scope.Commit();
            }
        }

        public ImmutableRedModel ToImmutable(bool finish = true)
        {
            if (finish) this.finished = true;
            if (this.transaction.IsChanged)
            {
                if (this.finished)
                {
                    return new ImmutableRedModel(this.transaction.AsGreenModel());
                }
                else
                {
                    return new ImmutableRedModel(this.transaction.Fork());
                }
            }
            else
            {
                if (this.originalImmutableModel != null) return this.originalImmutableModel;
                else return new ImmutableRedModel(this.transaction.ParentModel);
            }
        }

        internal MutableRedSymbolBase GetRedSymbol(GreenSymbol green)
        {
            return this.transaction.GetRedSymbol(green);
        }

        internal object ToGreenValue(object value)
        {
            if (value is MutableRedSymbolBase)
            {
                return ((MutableRedSymbolBase)value).Green;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value == GreenModelTransaction.Unassigned)
            {
                return null;
            }
            else if (value is GreenLazyValue)
            {
                return null;
            }
            else if (value is GreenLazyList)
            {
                return null;
            }
            else if (value is GreenSymbol)
            {
                return this.GetRedSymbol((GreenSymbol)value);
            }
            else
            {
                return value;
            }
        }

        internal object GetValue(MutableRedSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            object greenObject;
            if (this.LazyMode == LazyEvaluationMode.ReturnNull)
            {
                greenObject = this.transaction.GetValue(symbol.Green, property);
            }
            else
            {
                if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead, or, if the model is only read, change the lazy evaluation mode to '"+nameof(LazyEvaluationMode.ReturnNull)+"'.");
                greenObject = this.transaction.GetValueWithLazyEval(symbol.Green, property);
            }
            return this.ToRedValue(greenObject);
        }

        internal MutableRedList<T> GetList<T>(MutableRedSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            object greenObject;
            if (this.LazyMode == LazyEvaluationMode.ReturnNull)
            {
                greenObject = this.transaction.GetValue(symbol.Green, property);
            }
            else
            {
                if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead, or, if the model is only read, change the lazy evaluation mode to '" + nameof(LazyEvaluationMode.ReturnNull) + "'.");
                greenObject = this.transaction.GetValueWithLazyEval(symbol.Green, property);
            }
            if (greenObject is GreenList)
            {
                return new MutableRedList<T>((GreenList)greenObject, this);
            }
            else
            {
                return null;
            }
        }

        internal bool SetValue(MutableRedSymbolBase symbol, ModelProperty property, object redValue)
        {
            Debug.Assert(!property.IsCollection);
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            object oldValue;
            object greenValue = this.ToGreenValue(redValue);
            return this.transaction.SetValue(symbol.Green, property, false, greenValue, out oldValue);
        }

        internal bool SetLazyValue(MutableRedSymbolBase symbol, ModelProperty property, Func<object> redLazy)
        {
            Debug.Assert(!property.IsCollection);
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (redLazy == null) return false;
            object oldValue;
            return this.transaction.SetValue(symbol.Green, property, false, new GreenLazyValue(redLazy), out oldValue);
        }

        internal bool AddItem(GreenList collection, object greenItem)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.AddItem(collection.Parent, collection.Property, -1, false, greenItem);
        }

        internal bool AddLazyItem(GreenList collection, object greenLazyItem)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.AddItem(collection.Parent, collection.Property, -1, false, greenLazyItem);
        }

        internal bool RemoveItem(GreenList collection, object greenItem)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.RemoveItem(collection.Parent, collection.Property, -1, false, greenItem);
        }

        internal bool RemoveAllItems(GreenList collection, object greenItem)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.RemoveItem(collection.Parent, collection.Property, -1, true, greenItem);
        }

        internal bool InsertItem(GreenList collection, int index, object greenItem)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.AddItem(collection.Parent, collection.Property, index, false, greenItem);
        }

        internal bool ReplaceItem(GreenList collection, int index, object greenItem)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.AddItem(collection.Parent, collection.Property, index, true, greenItem);
        }

        internal bool RemoveItemAt(GreenList collection, int index)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.RemoveItem(collection.Parent, collection.Property, index, false, null);
        }

        internal bool ClearItems(GreenList collection)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.ClearItems(collection.Parent, collection.Property);
        }

        internal bool ClearLazyItems(GreenList collection)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.ClearLazyItems(collection.Parent, collection.Property);
        }

        internal void InvalidateProperty(GreenSymbol symbol, ModelProperty property)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            MutableRedSymbolBase redSymbol = this.GetRedSymbol(symbol);
            if (redSymbol != null)
            {
                redSymbol.InvalidateProperty(property);
            }
        }

        internal MutableRedSymbol MParent(MutableRedSymbolBase redSymbol)
        {
            return this.GetRedSymbol(this.transaction.MParent(redSymbol.Green));
        }

        internal IEnumerable<MutableRedSymbol> MChildren(MutableRedSymbolBase redSymbol)
        {
            foreach (var child in this.transaction.MChildren(redSymbol.Green))
            {
                yield return this.GetRedSymbol(child);
            }
        }

        internal IReadOnlyList<ModelProperty> MProperties(MutableRedSymbolBase redSymbol)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType());
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(MutableRedSymbolBase redSymbol)
        {
            return this.transaction.MAllProperties(redSymbol.Green);
        }

        internal object MGet(MutableRedSymbolBase redSymbol, ModelProperty property)
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

        internal bool MIsSet(MutableRedSymbolBase redSymbol, ModelProperty property)
        {
            return this.transaction.MIsSet(redSymbol.Green, property);
        }

        internal ModelProperty MGetProperty(MutableRedSymbolBase redSymbol, string name)
        {
            return ModelProperty.GetPropertiesForType(redSymbol.GetType()).FirstOrDefault(p => p.Name == name);
        }

        internal IReadOnlyList<ModelProperty> MGetAllProperties(MutableRedSymbolBase redSymbol, string name)
        {
            return this.transaction.MGetAllProperties(redSymbol.Green, name);
        }

        internal bool MHasLazy(MutableRedSymbolBase redSymbol, ModelProperty property)
        {
            return this.transaction.MHasLazy(redSymbol.Green, property);
        }

        internal bool MIsAttached(MutableRedSymbolBase redSymbol, ModelProperty property)
        {
            return !ModelProperty.GetDeclaredPropertiesForType(redSymbol.GetType()).Contains(property);
        }

        internal bool MTryGet(MutableRedSymbolBase redSymbol, ModelProperty property, out object value)
        {
            return this.transaction.MTryGet(redSymbol.Green, property, out value);
        }

        internal bool MAdd(MutableRedSymbolBase redSymbol, ModelProperty property, object value)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (property.IsCollection)
            {
                return this.transaction.AddItem(redSymbol.Green, property, -1, false, this.ToGreenValue(value));
            }
            else
            {
                object oldValue;
                bool result = this.transaction.SetValue(redSymbol.Green, property, false, this.ToGreenValue(value), out oldValue);
                return result;
            }
        }

        internal bool MClear(MutableRedSymbolBase redSymbol, ModelProperty property, bool clearLazy)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (property.IsCollection)
            {
                return this.transaction.ClearItems(redSymbol.Green, property) && (!clearLazy || this.transaction.ClearLazyItems(redSymbol.Green, property));
            }
            else
            {
                object oldValue;
                bool result = this.transaction.SetValue(redSymbol.Green, property, false, null, out oldValue);
                return result;
            }
        }

        internal bool MClearLazy(MutableRedSymbolBase redSymbol, ModelProperty property)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (this.MHasLazy(redSymbol, property))
            {
                if (property.IsCollection)
                {
                    return this.transaction.ClearLazyItems(redSymbol.Green, property);
                }
                else
                {
                    object oldValue;
                    bool result = this.transaction.SetValue(redSymbol.Green, property, true, GreenModelTransaction.Unassigned, out oldValue);
                    return result;
                }
            }
            return false;
        }

        internal bool MReset(MutableRedSymbolBase redSymbol, ModelProperty property, object value)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (property.IsCollection)
            {
                return this.transaction.ClearItems(redSymbol.Green, property);
            }
            else
            {
                object oldValue;
                return this.transaction.SetValue(redSymbol.Green, property, true, value, out oldValue);
            }
        }

        internal bool MAddRange(MutableRedSymbolBase redSymbol, ModelProperty property, IEnumerable<object> values)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.transaction.AddItems(redSymbol.Green, property, values);
        }

        internal bool MAttachProperty(MutableRedSymbolBase redSymbol, ModelProperty property)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.MAttachProperty(redSymbol.Green, property);
        }

        internal bool MDetachProperty(MutableRedSymbolBase redSymbol, ModelProperty property)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.MDetachProperty(redSymbol.Green, property);
        }

        internal bool MLazyAdd(MutableRedSymbolBase redSymbol, ModelProperty property, Func<object> value)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (property.IsCollection)
            {
                return this.transaction.AddItem(redSymbol.Green, property, -1, false, new GreenLazyValue(value));
            }
            else
            {
                object oldValue;
                bool result = this.transaction.SetValue(redSymbol.Green, property, false, new GreenLazyValue(value), out oldValue);
                return result;
            }
        }

        internal bool MLazyAddRange(MutableRedSymbolBase redSymbol, ModelProperty property, Func<IEnumerable<object>> values)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.transaction.AddItem(redSymbol.Green, property, -1, false, new GreenLazyList(values));
        }

        internal bool MLazyAddRange(MutableRedSymbolBase redSymbol, ModelProperty property, IEnumerable<Func<object>> values)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            bool result = false;
            foreach (var value in values)
            {
                result |= this.transaction.AddItem(redSymbol.Green, property, -1, false, new GreenLazyValue(value));
            }
            return result;
        }

        internal void MEvaluateLazy(MutableRedSymbolBase redSymbol)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            this.transaction.MEvaluateLazy(redSymbol.Green);
        }

        internal bool MChildLazySet(MutableRedSymbolBase redSymbol, ModelProperty child, ModelProperty property, Func<object> value)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (property.IsCollection) throw new ModelException("The property must not be a collection.");
            return this.transaction.MChildLazySet(redSymbol.Green, child, property, value);
        }

        internal bool MChildLazyAddRange(MutableRedSymbolBase redSymbol, ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.transaction.MChildLazyAddRange(redSymbol.Green, child, property, values);
        }

        internal bool MChildLazyAddRange(MutableRedSymbolBase redSymbol, ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (!property.IsCollection) throw new ModelException("The property must be a collection.");
            return this.transaction.MChildLazyAddRange(redSymbol.Green, child, property, values);
        }

        internal bool MChildLazyClear(MutableRedSymbolBase redSymbol, ModelProperty child)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.MChildLazyClear(redSymbol.Green, child);
        }

        internal bool MChildLazyClear(MutableRedSymbolBase redSymbol, ModelProperty child, ModelProperty property)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.MChildLazyClear(redSymbol.Green, child, property);
        }

        internal bool MRemove(MutableRedSymbolBase redSymbol, ModelProperty property, object value, bool removeAll)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (property.IsCollection)
            {
                return this.transaction.RemoveItem(redSymbol.Green, property, -1, removeAll, value);
            }
            else
            {
                object oldValue;
                if (this.MTryGet(redSymbol, property, out oldValue) && oldValue == value && oldValue != null)
                {
                    return this.transaction.SetValue(redSymbol.Green, property, false, null, out oldValue);
                }
            }
            return false;
        }

        internal void MUnset(MutableRedSymbolBase redSymbol, ModelProperty property)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            if (property.IsCollection)
            {
                this.transaction.ClearItems(redSymbol.Green, property);
            }
            else
            {
                object oldValue;
                this.transaction.SetValue(redSymbol.Green, property, true, GreenModelTransaction.Unassigned, out oldValue);
            }
        }
    }

    public sealed class RedModelTransaction : IDisposable
    {
        private MutableRedModel model;
        private CollectionTxScope txScope;

        internal RedModelTransaction(MutableRedModel model)
        {
            this.model = model;
            this.txScope = new CollectionTxScope();
        }

        internal MutableRedModel Model { get { return this.model; } }
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
