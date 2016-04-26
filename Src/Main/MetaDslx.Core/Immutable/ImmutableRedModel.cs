using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public sealed class ImmutableRedModel : RedModel
    {
        private GreenModel green;
        private bool cached;
        private Dictionary<GreenSymbol, ImmutableRedSymbol> symbols;

        internal ImmutableRedModel(GreenModel green)
        {
            this.green = green;
            this.symbols = null;
            this.cached = false;
        }

        internal object ToGreenValue(object redValue)
        {
            if (redValue is RedSymbolBase)
            {
                return ((RedSymbolBase)redValue).Green;
            }
            return redValue;
        }

        internal object ToRedValue(object redValue)
        {
            if (redValue is GreenSymbol)
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

        internal object GetValue(RedSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            object greenObject = this.green.GetValue(symbol.Green, property);
            return this.ToRedValue(greenObject);
        }

        internal ImmutableRedList<T> GetList<T>(RedSymbolBase symbol, ModelProperty property)
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

        private void CacheSymbols()
        {
            if (this.cached) return;
            lock(this)
            {
                if (this.cached) return;
                this.symbols = new Dictionary<GreenSymbol, ImmutableRedSymbol>();
                foreach (var greenSymbol in this.green.Symbols)
                {
                    this.GetRedSymbol(greenSymbol);
                }
            }
        }
    }

    public sealed class MutableRedModel : RedModel
    {
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
            this.originalImmutableModel = originalImmutableModel;
            this.transaction = green.BeginTransaction(this);
        }

        public RedModelTransaction BeginTransaction()
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return new RedModelTransaction(this);
        }

        internal object ToGreenValue(object value)
        {
            if (value is RedSymbolBase)
            {
                return ((RedSymbolBase)value).Green;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenLazyValue)
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

        public MutableRedSymbolBase GetRedSymbol(GreenSymbol green)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.GetRedSymbol(green);
        }

        internal object GetValue(MutableRedSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            object greenObject = this.transaction.GetValue(symbol.Green, property);
            return this.ToRedValue(greenObject);
        }

        internal MutableRedList<T> GetList<T>(RedSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            object greenObject = this.transaction.GetValue(symbol.Green, property);
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

        internal bool ClearList(GreenList collection)
        {
            if (this.finished) throw new ModelException("Cannot change a finished mutable model. Create a new one instead.");
            return this.transaction.ClearList(collection.Parent, collection.Property);
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
