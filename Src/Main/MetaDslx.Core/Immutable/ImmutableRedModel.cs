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
        private Dictionary<GreenSymbol, ImmutableRedSymbol> symbols;
        private Dictionary<GreenLazyValue, object> lazyItems;

        internal ImmutableRedModel(GreenModel green)
        {
            this.green = green;
            this.symbols = new Dictionary<GreenSymbol, ImmutableRedSymbol>();
            this.lazyItems = new Dictionary<GreenLazyValue, object>();
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
        private ImmutableRedList GetRedSymbolList(GreenList green)
        {
            if (!this.green.ContainsSymbol(green.Parent))
            {
                return null;
            }
            return new ImmutableRedList(green, this);
        }

        internal object GetValue(RedSymbolBase symbol, ModelProperty property)
        {
            object greenObject = this.green.GetValue(symbol.Green, property);
            // TODO: lazy
            if (greenObject is GreenSymbol)
            {
                return this.GetRedSymbol((GreenSymbol)greenObject);
            }
            else
            {
                return greenObject;
            }
        }

        internal void CreateListItems(ImmutableRedList list, ref List<object> items)
        {
            bool allowMultipleItems = list.Property.IsNonUnique;
            List<object> result = new List<object>();
            foreach (var greenObject in list.Green)
            {
                object redObject = greenObject;
                if (greenObject is GreenLazyList)
                {
                    var redItems = ((GreenLazyList)greenObject).CreateValues(this);
                    foreach (var redItem in redItems)
                    {
                        if (redItem != null && (allowMultipleItems || !result.Contains(redItem)))
                        {
                            result.Add(redItem);
                        }
                    }
                }
                else
                {
                    if (greenObject is GreenSymbol)
                    {
                        redObject = this.GetRedSymbol((GreenSymbol)greenObject);
                    }
                    else if (greenObject is GreenLazyValue)
                    {
                        redObject = ((GreenLazyValue)greenObject).CreateValue(this);
                    }
                    if (redObject != null && (allowMultipleItems || !result.Contains(redObject)))
                    {
                        result.Add(redObject);
                    }
                }
            }
            Interlocked.CompareExchange(ref items, result, null);
        }

        public MutableRedModel ToMutable()
        {
            return new MutableRedModel(this.green, this);
        }
    }

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
            if (value is GreenLazySymbol)
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

        public MutableRedSymbolBase GetRedSymbol(GreenSymbol green)
        {
            return this.currentTransaction.GetRedSymbol(green);
        }

        internal object GetValue(RedSymbolBase symbol, ModelProperty property)
        {
            object greenObject = this.currentTransaction.GetValue(symbol.Green, property);
            return this.ToRedValue(greenObject);
        }

        internal bool SetValue(MutableRedSymbolBase symbol, ModelProperty property, object value)
        {
            value = this.ToGreenValue(value);
            object oldValue;
            return this.currentTransaction.SetValue(symbol.Green, property, value, out oldValue);
        }

        internal bool SetLazyValue(MutableRedSymbolBase symbol, ModelProperty property, Func<object> value)
        {
            if (value == null) return false;
            object oldValue;
            return this.currentTransaction.SetValue(symbol.Green, property, new GreenLazyValue(value), out oldValue);
        }

        internal bool SetLazySymbol(MutableRedSymbolBase symbol, ModelProperty property, Func<RedSymbol> value)
        {
            if (value == null) return false;
            object oldValue;
            return this.currentTransaction.SetValue(symbol.Green, property, new GreenLazyValue(value), out oldValue);
        }

        internal bool AddListItem(MutableRedList list, object item)
        {
            return this.currentTransaction.AddValue(list.Green.Parent, list.Green.Property, this.ToGreenValue(item));
        }

        internal bool RemoveListItem(MutableRedList list, object item)
        {
            return this.currentTransaction.RemoveValue(list.Green.Parent, list.Green.Property, this.ToGreenValue(item));
        }

        internal void CreateListItems(MutableRedList list, ref List<object> items)
        {
            bool allowMultipleItems = list.Property.IsNonUnique;
            List<object> result = new List<object>();
            foreach (var greenObject in list.Green)
            {
                object redObject = greenObject;
                if (greenObject is GreenLazyList)
                {
                    // TODO: cache items
                    var redItems = ((GreenLazyList)greenObject).CreateValues(this);
                    foreach (var redItem in redItems)
                    {
                        if (redItem != null && (allowMultipleItems || !result.Contains(redItem)))
                        {
                            result.Add(redItem);
                        }
                    }
                }
                else
                {
                    if (greenObject is GreenSymbol)
                    {
                        redObject = this.GetRedSymbol((GreenSymbol)greenObject);
                    }
                    else if (greenObject is GreenLazyValue)
                    {
                        // TODO: cache
                        redObject = ((GreenLazyValue)greenObject).CreateValue(this);
                    }
                    if (redObject != null && (allowMultipleItems || !result.Contains(redObject)))
                    {
                        result.Add(redObject);
                    }
                }
            }
            Interlocked.CompareExchange(ref items, result, null);
        }

        internal void UpdateList(RedSymbolBase symbol, ModelProperty property, MutableRedList list)
        {
            object greenObject = this.currentTransaction.GetValue(symbol.Green, property);
            if (list.Green == greenObject) return;
            Debug.Assert(greenObject is GreenList);
            if (greenObject is GreenList)
            {
                list.SetGreen((GreenList)greenObject);
            }
        }

        internal void InvalidateProperty(GreenSymbol symbol, ModelProperty property)
        {
            MutableRedSymbolBase redSymbol = this.GetRedSymbol(symbol);
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
                else return new ImmutableRedModel(this.currentTransaction.ParentModel);
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
