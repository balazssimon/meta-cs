using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable3
{
    public interface ISymbol
    {
        object GetValue(ModelProperty property);
        bool HasValue(ModelProperty property);
    }

    public interface IImmutableSymbol : ISymbol
    {

    }

    public interface IMutableSymbol : ISymbol
    {
        void SetValue(ModelProperty property, object value);
        void SetValueLazy(ModelProperty property, Lazy<object> value);
        bool AddValue(ModelProperty property, object value);
        bool AddValueLazy(ModelProperty property, Lazy<object> value);
        bool RemoveValue(ModelProperty property, object value);
    }

    public sealed class SymbolId
    {

    }

    public abstract class Symbol
    {
        private SymbolId id;
        private Model model;

        internal Symbol(SymbolId id, Model model)
        {
            Debug.Assert(id != null);
            Debug.Assert(model != null);
            this.id = id;
            this.model = model;
        }

        internal SymbolId Id { get { return this.id; } }
        internal Model Model { get { return this.model; } }
    }

    public abstract class ImmutableSymbol : Symbol, IImmutableSymbol
    {
        protected ImmutableSymbol(SymbolId id, Model model)
            : base(id, model)
        {
        }

        public object GetValue(ModelProperty property)
        {
            return this.Model.GetValue(this, property);
        }

        public bool HasValue(ModelProperty property)
        {
            return this.Model.HasValue(this, property);
        }

        protected abstract MutableSymbol ToMutable();
    }

    public abstract class MutableSymbol : Symbol, IMutableSymbol
    {
        protected MutableSymbol(SymbolId id, Model model)
            : base(id, model)
        {

        }

        public object GetValue(ModelProperty property)
        {
            return this.Model.GetValue(this, property);
        }

        public bool HasValue(ModelProperty property)
        {
            return this.Model.HasValue(this, property);
        }

        public bool AddValue(ModelProperty property, object value)
        {
            return this.Model.AddValue(this, property, value);
        }

        public bool AddValueLazy(ModelProperty property, Lazy<object> value)
        {
            return this.Model.AddValueLazy(this, property, value);
        }

        public bool RemoveValue(ModelProperty property, object value)
        {
            return this.Model.RemoveValue(this, property, value);
        }

        public void SetValue(ModelProperty property, object value)
        {
            this.Model.SetValue(this, property, value);
        }

        public void SetValueLazy(ModelProperty property, Lazy<object> value)
        {
            this.Model.SetValueLazy(this, property, value);
        }

        protected abstract ImmutableSymbol ToImmutable();
    }

    internal class InternalSymbolList : IReadOnlyList<object>
    {
        private bool allowMultipleElements;
        private SymbolId symbolId;
        private ModelProperty property;
        private List<object> items = new List<object>();

        internal InternalSymbolList(SymbolId symbolId, ModelProperty property, bool allowMultipleElements = false)
        {
            this.symbolId = symbolId;
            this.property = property;
            this.allowMultipleElements = allowMultipleElements;
        }

        public bool AllowMultipleItems { get { return this.allowMultipleElements; } }
        public SymbolId SymbolId { get { return this.symbolId; } }
        public ModelProperty Property { get { return this.property; } }
        public int Count { get { return this.items.Count; } }
        public object this[int index] { get { return this.items[index]; } }

        public bool Add(Model model, SymbolId item)
        {
            if (item == null) return false;
            if (allowMultipleElements || !this.items.Contains(item))
            {
                this.items.Add(item);
                model.AddRelatedValues(this.symbolId, this.property, item);
                return true;
            }
            return false;
        }

        public bool Add(Model model, Lazy<Symbol> item)
        {
            if (item == null) return false;
            if (allowMultipleElements || !this.items.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            return false;
        }

        public bool Remove(Model model, SymbolId item)
        {
            if (item == null) return false;
            if (this.items.Remove(item))
            {
                model.RemoveRelatedValues(this.symbolId, this.property, item);
                return true;
            }
            return false;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal List<object> CopyOfItems()
        {
            return this.items.ToList();
        }
    }

    public class SymbolList
    {
        internal Model model;
        internal Symbol parent;
        internal InternalSymbolList internalList;
        internal List<Symbol> items = null;
        internal List<Lazy<Symbol>> newLazyItems = null;

        internal SymbolList(Model model, Symbol parent, InternalSymbolList internalList)
        {
            this.model = model;
            this.parent = parent;
            this.internalList = internalList;
        }

        internal bool Add(Symbol item)
        {
            bool result = this.internalList.Add(this.model, item.Id);
            this.InternalAdd(item);
            return result;
        }

        internal bool Add(Lazy<Symbol> item)
        {
            bool result = this.internalList.Add(this.model, item);
            if (this.newLazyItems == null)
            {
                this.newLazyItems = new List<Lazy<Symbol>>();
            }
            this.newLazyItems.Add(item);
            return result;
        }

        internal bool Remove(Symbol item)
        {
            bool result = this.internalList.Remove(this.model, item.Id);
            this.InternalRemove(item);
            return result;
        }

        internal bool InternalAdd(Symbol item)
        {
            if (item == null) return false;
            if (this.items == null) this.EvaluateItems();
            if (this.newLazyItems != null && this.newLazyItems.Count > 0) this.EvaluateLazyItems();
            if (this.internalList.AllowMultipleItems || !this.items.Contains(item))
            {
                this.items.Add(item);
                this.model.AddRelatedInternalValues(this.parent, this.internalList.Property, item);
                return true;
            }
            return false;
        }

        internal bool InternalRemove(Symbol item)
        {
            if (item == null) return false;
            if (this.items == null) this.EvaluateItems();
            if (this.newLazyItems != null && this.newLazyItems.Count > 0) this.EvaluateLazyItems();
            if (this.items.Remove(item))
            {
                this.model.RemoveRelatedInternalValues(this.parent, this.internalList.Property, item);
                return true;
            }
            return false;
        }

        private void EvaluateItems()
        {
            Debug.Assert(this.items == null);
            this.items = new List<Symbol>();
            foreach (var item in this.internalList)
            {
                if (item is SymbolId)
                {
                    this.InternalAdd(this.model.GetSymbol((SymbolId)item));
                }
                else if (item is Lazy<Symbol>)
                {
                    this.InternalAdd(((Lazy<Symbol>)item).Value);
                }
            }
        }

        private void EvaluateLazyItems()
        {
            Debug.Assert(this.newLazyItems != null);
            Debug.Assert(this.newLazyItems.Count > 0);
            foreach (var lazyItem in this.newLazyItems)
            {
                var item = lazyItem.Value;
                this.InternalAdd(item);
            }
            this.newLazyItems.Clear();
        }
    }

    public class SymbolList<T> : SymbolList
        where T : Symbol
    {
        internal SymbolList(Model model, Symbol parent, InternalSymbolList internalList)
            : base(model, parent, internalList)
        {
        }

        public bool Add(T item)
        {
            return this.model.AddValue(this, item);
        }

        public bool Add(Lazy<T> item)
        {
            return this.model.AddValueLazy(this, new Lazy<Symbol>(() => item.Value));
        }

        public bool Remove(T item)
        {
            return this.model.RemoveValue(this, item);
        }
    }

    public class ModelPart
    {
        private object id;
        private Dictionary<SymbolId, Dictionary<ModelProperty, object>> symbols;

        internal ModelPart(object id)
        {
            this.id = id;
            this.symbols = new Dictionary<SymbolId, Dictionary<ModelProperty, object>>();
        }

        internal object Id { get { return this.id; } }

        internal bool AddSymbol(Symbol symbol)
        {
            lock(this.symbols)
            {
                if (!this.symbols.ContainsKey(symbol.Id))
                {
                    this.symbols.Add(symbol.Id, new Dictionary<ModelProperty, object>());
                    return true;
                }
            }
            return false;
        }

        internal bool RemoveSymbol(Symbol symbol)
        {
            lock (this.symbols)
            {
                return this.symbols.Remove(symbol.Id);
            }
        }

    }


    public class Model
    {
        private Dictionary<object, ModelPart> parts;
        private Dictionary<SymbolId, Symbol> cachedSymbols;
        private Dictionary<Lazy<object>, object> cachedLazyValues;
        private Dictionary<InternalSymbolList, object> cachedLists;
        private HashSet<ModelProperty> evaluatingProps = new HashSet<ModelProperty>();
        private HashSet<ModelProperty> evaluatedProps = new HashSet<ModelProperty>();

        internal Model(IEnumerable<ModelPart> parts)
        {
            this.parts = parts.ToDictionary(part => part.Id);
            this.cachedSymbols = new Dictionary<SymbolId, Symbol>();
            this.cachedLazyValues = new Dictionary<Lazy<object>, object>();
            this.cachedLists = new Dictionary<InternalSymbolList, object>();
            this.evaluatingProps = new HashSet<ModelProperty>();
            this.evaluatedProps = new HashSet<ModelProperty>();
        }

        internal void ResetLazyProperties()
        {
            this.cachedLazyValues = new Dictionary<Lazy<object>, object>();
            this.cachedLists = new Dictionary<InternalSymbolList, object>();
        }

        internal Symbol GetSymbol(SymbolId id)
        {
            Symbol result;
            if (this.cachedSymbols.TryGetValue(id, out result))
            {
                return result;
            }
            else
            {
                // TODO: create symbol
                return null;
            }
        }


        internal object GetValue(Symbol symbol, ModelProperty property)
        {
            return null;
        }
        internal bool HasValue(Symbol symbol, ModelProperty property)
        {
            return false;
        }
        internal void SetValue(Symbol symbol, ModelProperty property, object value)
        {

        }
        internal void SetValueLazy(Symbol symbol, ModelProperty property, Lazy<object> value)
        {

        }
        internal bool AddValue(Symbol symbol, ModelProperty property, object value)
        {
            return false;
        }
        internal bool AddValueLazy(Symbol symbol, ModelProperty property, Lazy<object> value)
        {
            return false;
        }
        internal bool RemoveValue(Symbol symbol, ModelProperty property, object value)
        {
            return false;
        }

        internal void AddRelatedValues(SymbolId symbol, ModelProperty property, SymbolId value)
        {

        }
        internal void RemoveRelatedValues(SymbolId symbol, ModelProperty property, SymbolId value)
        {

        }

        internal bool AddValue(SymbolList list, Symbol value)
        {
            lock(list)
            {
                return list.Add(value);
            }
        }
        internal bool AddValueLazy(SymbolList list, Lazy<Symbol> value)
        {
            lock (list)
            {
                return list.Add(value);
            }
        }
        internal bool RemoveValue(SymbolList list, Symbol value)
        {
            lock (list)
            {
                return list.Remove(value);
            }
        }

        internal void AddRelatedInternalValues(Symbol symbol, ModelProperty property, Symbol value)
        {

        }
        internal void RemoveRelatedInternalValues(Symbol symbol, ModelProperty property, Symbol value)
        {

        }

        private void EvaluateLazyProperties(ModelProperty property)
        {

        }
    }


}
