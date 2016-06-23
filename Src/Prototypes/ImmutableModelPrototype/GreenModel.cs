using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImmutableModelPrototype
{
    public abstract class SymbolId
    {
    }

    public class ModelId
    {
    }

    internal class GreenList : IEnumerable<object>
    {
        internal static readonly GreenList EmptyUnique = new GreenList(true);
        internal static readonly GreenList EmptyNonUnique = new GreenList(false);

        private bool unique;
        private ImmutableList<object> items;
        private ImmutableList<object> lazyItems;

        private GreenList(bool unique)
        {
            this.unique = unique;
            this.items = ImmutableList<object>.Empty;
            this.lazyItems = ImmutableList<object>.Empty;
        }

        private GreenList(bool unique, ImmutableList<object> items, ImmutableList<object> lazyItems)
        {
            this.unique = unique;
            this.items = items;
            this.lazyItems = lazyItems;
        }

        private GreenList Update(ImmutableList<object> items, ImmutableList<object> lazyItems)
        {
            if (this.items != items || this.lazyItems != lazyItems)
            {
                return new GreenList(this.unique, items, lazyItems);
            }
            return this;
        }

        internal int Count
        {
            get { return this.items.Count; }
        }

        internal object this[int index]
        {
            get { return this.items[index]; }
        }

        internal bool HasLazyItems
        {
            get { return this.lazyItems.Count > 0; }
        }

        internal ImmutableList<object> LazyItems
        {
            get { return this.lazyItems; }
        }

        internal GreenList Clear()
        {
            return this.Update(this.items.Clear(), this.lazyItems);
        }

        internal GreenList ClearLazy()
        {
            return this.Update(this.items, this.lazyItems.Clear());
        }

        internal bool Contains(object value)
        {
            return this.items.Contains(value);
        }

        internal int IndexOf(object value)
        {
            return this.items.IndexOf(value);
        }

        internal GreenList Add(object value)
        {
            return this.Update(this.items.Add(value), this.lazyItems);
        }

        internal GreenList AddLazy(object value)
        {
            return this.Update(this.items, this.lazyItems.Add(value));
        }

        internal GreenList AddRange(IEnumerable<object> items)
        {
            return this.Update(this.items.AddRange(items), this.lazyItems);
        }

        internal GreenList Insert(int index, object element)
        {
            return this.Update(this.items.Insert(index, element), this.lazyItems);
        }

        internal GreenList Remove(object value)
        {
            return this.Update(this.items.Remove(value), this.lazyItems);
        }

        internal GreenList RemoveAll(object value)
        {
            return this.Update(this.items.RemoveAll(v => v == value), this.lazyItems);
        }

        internal GreenList RemoveAt(int index)
        {
            return this.Update(this.items.RemoveAt(index), this.lazyItems);
        }

        internal GreenList SetItem(int index, object value)
        {
            return this.Update(this.items.SetItem(index, value), this.lazyItems);
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class GreenSymbol
    {
        public static readonly GreenSymbol Empty = new GreenSymbol();

        private SymbolId parent;
        private ImmutableList<SymbolId> children;
        private ImmutableDictionary<ModelProperty, object> properties;

        private GreenSymbol()
        {
            this.children = ImmutableList<SymbolId>.Empty;
            this.properties = ImmutableDictionary<ModelProperty, object>.Empty;
        }

        private GreenSymbol(
            SymbolId parent, 
            ImmutableList<SymbolId> children, 
            ImmutableDictionary<ModelProperty, object> properties)
        {
            this.parent = parent;
            this.children = children;
            this.properties = properties;
        }

        public GreenSymbol Update(
            SymbolId parent, 
            ImmutableList<SymbolId> children, 
            ImmutableDictionary<ModelProperty, object> properties)
        {
            if (this.parent != parent || this.children != children || this.properties != properties)
            {
                return new GreenSymbol(parent, children, properties);
            }
            return this;
        }

        public SymbolId Parent { get { return this.parent; } }
        public ImmutableList<SymbolId> Children { get { return this.children; } }
        public ImmutableDictionary<ModelProperty, object> Properties { get { return this.properties; } }
    }

    public class GreenModel
    {
        private ModelId id;
        private ImmutableDictionary<SymbolId, GreenSymbol> symbols;
        private ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ModelProperty>> references;

        public GreenModel(ModelId id)
        {
            this.id = id;
            this.symbols = ImmutableDictionary<SymbolId, GreenSymbol>.Empty;
            this.references = ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ModelProperty>>.Empty;
        }

        private GreenModel(ModelId id, 
            ImmutableDictionary<SymbolId, GreenSymbol> symbols, 
            ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ModelProperty>> references)
        {
            this.id = id;
            this.symbols = symbols;
            this.references = references;
        }

        public GreenModel Update(
            ImmutableDictionary<SymbolId, GreenSymbol> symbols,
            ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ModelProperty>> references)
        {
            if (this.symbols != symbols || this.references != references)
            {
                return new GreenModel(this.id, symbols, references);
            }
            return this;
        }

        public ModelId Id { get { return this.id; } }
        public ImmutableDictionary<SymbolId, GreenSymbol> Symbols { get { return this.symbols; } }
        public ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ModelProperty>> References { get { return this.references; } }
    }

    public class GreenModelUpdater
    {
        private GreenModel model;

        public GreenModelUpdater(GreenModel model)
        {
            this.model = model;
        }

        private bool Update(GreenModel oldModel, GreenModel newModel)
        {
            return Interlocked.CompareExchange(ref this.model, newModel, oldModel) == oldModel;
        }

        public void AddSymbol(SymbolId id)
        {
            GreenModel oldModel;
            GreenModel newModel;
            do
            {
                oldModel = this.model;
                newModel = oldModel.Update(oldModel.Symbols.Add(id, GreenSymbol.Empty), oldModel.References);
            } while (!this.Update(oldModel, newModel));
        }
    }
}
