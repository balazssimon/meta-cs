using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImmutableModelPrototype
{
    public abstract class SymbolId
    {
        public abstract ModelSymbolInfo ModelSymbol { get; }
        public abstract Type MutableType { get; }
        public abstract Type ImmutableType { get; }
        public abstract object CreateMutable();
        public abstract object CreateImmutable();
    }

    public class ModelId
    {
    }

    internal sealed class GreenDerivedValue
    {
        private Func<object> lazy;

        internal GreenDerivedValue(Func<object> lazy)
        {
            this.lazy = lazy;
        }

        internal Func<object> Lazy
        {
            get { return this.lazy; }
        }

        internal object CreateRedValue()
        {
            return lazy();
        }
    }

    internal sealed class GreenLazyValue
    {
        private Func<object> lazy;

        internal GreenLazyValue(Func<object> lazy)
        {
            this.lazy = lazy;
        }

        internal Func<object> Lazy
        {
            get { return this.lazy; }
        }

        internal object CreateGreenValue()
        {
            object value = lazy();
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).Id;
            }
            else if (value is ImmutableSymbolBase)
            {
                return ((ImmutableSymbolBase)value).Id;
            }
            return value;
        }
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

    internal class GreenSymbol
    {
        internal static readonly GreenSymbol Empty = new GreenSymbol();
        internal static readonly object Unassigned = new object();

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

        internal GreenSymbol Update(
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

        internal static GreenSymbol CreateWithProperties(ImmutableList<ModelProperty> properties)
        {
            return GreenSymbol.Empty.Update(
                null, 
                ImmutableList<SymbolId>.Empty, 
                properties.ToImmutableDictionary(p => p, p => GreenSymbol.Unassigned));
        }

        internal SymbolId Parent { get { return this.parent; } }
        internal ImmutableList<SymbolId> Children { get { return this.children; } }
        internal ImmutableDictionary<ModelProperty, object> Properties { get { return this.properties; } }
    }

    internal class GreenModel
    {
        private ModelId id;
        private ImmutableHashSet<SymbolId> strongSymbols;
        // TODO: replace with immutable weak dictionaries:
        private ImmutableDictionary<SymbolId, GreenSymbol> symbols;
        private ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> lazyProperties;
        private ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> references;

        internal GreenModel(ModelId id)
        {
            this.id = id;
            this.symbols = ImmutableDictionary<SymbolId, GreenSymbol>.Empty;
            this.strongSymbols = ImmutableHashSet<SymbolId>.Empty;
            this.lazyProperties = ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>.Empty;
            this.references = ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>>.Empty;
        }

        private GreenModel(ModelId id,
            ImmutableDictionary<SymbolId, GreenSymbol> symbols,
            ImmutableHashSet<SymbolId> strongSymbols,
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> lazyProperties,
            ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> references)
        {
            this.id = id;
            this.symbols = symbols;
            this.strongSymbols = strongSymbols;
            this.lazyProperties = lazyProperties;
            this.references = references;
        }

        internal GreenModel Update(
            ImmutableDictionary<SymbolId, GreenSymbol> symbols,
            ImmutableHashSet<SymbolId> strongSymbols,
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> lazyProperties,
            ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> references)
        {
            if (this.symbols != symbols || this.strongSymbols != strongSymbols || 
                this.lazyProperties != lazyProperties || this.references != references)
            {
                return new GreenModel(this.id, symbols, strongSymbols, lazyProperties, references);
            }
            return this;
        }

        internal ModelId Id { get { return this.id; } }
        internal ImmutableDictionary<SymbolId, GreenSymbol> Symbols { get { return this.symbols; } }
        internal ImmutableHashSet<SymbolId> StrongSymbols { get { return this.strongSymbols; } }
        internal ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> LazyProperties { get { return this.lazyProperties; } }
        internal ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> References { get { return this.references; } }

        internal GreenModel AddSymbol(SymbolId id, bool weak)
        {
            Debug.Assert(!this.symbols.ContainsKey(id), "The green model already contains this symbol.");
            return this.Update(this.symbols.Add(id, id.ModelSymbol.EmptyGreenSymbol), weak ? this.strongSymbols : this.strongSymbols.Add(id), this.lazyProperties, this.references);
        }
    }

    internal class GreenModelGroup
    {
        private ImmutableDictionary<ModelId, GreenModel> models;
        private ImmutableDictionary<ModelId, GreenModel> references;

        private GreenModelGroup()
        {
            this.models = ImmutableDictionary<ModelId, GreenModel>.Empty;
            this.references = ImmutableDictionary<ModelId, GreenModel>.Empty;
        }

        private GreenModelGroup(ImmutableDictionary<ModelId, GreenModel> models, ImmutableDictionary<ModelId, GreenModel> references)
        {
            this.models = models;
            this.references = references;
        }

        internal GreenModelGroup Update(ImmutableDictionary<ModelId, GreenModel> models, ImmutableDictionary<ModelId, GreenModel> references)
        {
            if (this.models != models || this.references != references)
            {
                return new GreenModelGroup(models, references);
            }
            return this;
        }

        internal ImmutableDictionary<ModelId, GreenModel> Models { get { return this.models; } }
        internal ImmutableDictionary<ModelId, GreenModel> References { get { return this.references; } }

        internal GreenModelGroup AddModel(ModelId id)
        {
            if (this.models.ContainsKey(id) || this.references.ContainsKey(id)) return this;
            return this.Update(this.models.Add(id, new GreenModel(id)), this.references);
        }

        internal GreenModelGroup AddModel(GreenModel model)
        {
            if (this.models.ContainsKey(model.Id) || this.references.ContainsKey(model.Id)) return this;
            return this.Update(this.models.Add(model.Id, model), this.references);
        }

        internal GreenModelGroup AddReference(GreenModel reference)
        {
            if (this.models.ContainsKey(reference.Id) || this.references.ContainsKey(reference.Id)) return this;
            return this.Update(this.models, this.references.Add(reference.Id, reference));
        }

        internal GreenModelGroup UpdateModel(GreenModel model)
        {
            if (!this.models.ContainsKey(model.Id)) return this;
            return this.Update(this.models.SetItem(model.Id, model), this.references);
        }
    }

    /// <summary>
    /// This class is responsible for updating a green model. The class is not thread-safe,
    /// and it should be used only from a single thread.
    /// </summary>
    /// If multiple threads can update the model, create a different updater for each thread, 
    /// and merge the results using the following pattern:
    ///     do
    ///     {
    ///         oldState = someObject.State;
    ///         newState = oldState.WithSomeChanges(); // this is where to call the updater of the current thread
    ///     } while (Interlocked.CompareExchange(ref someObject.State, newState, oldState) != oldState;
    internal class GreenModelUpdater
    {
        private GreenModel model;
        private GreenModelGroup group;

        internal GreenModelUpdater(GreenModel model)
        {
            this.model = model;
            this.group = null;
        }

        internal GreenModelUpdater(GreenModelGroup group)
        {
            this.model = null;
            this.group = group;
        }

        internal GreenModel Model { get { return this.model; } }
        internal GreenModelGroup Group { get { return this.group; } }

        private GreenModel GetModel(ModelId mid)
        {
            if (this.group != null)
            {
                GreenModel model;
                if (this.group.Models.TryGetValue(mid, out model))
                {
                    return model;
                }
                return null;
            }
            else
            {
                if (this.model.Id == mid)
                {
                    return this.model;
                }
                return null;
            }
        }

        private ModelRef ResolveModel(ModelId mid)
        {
            if (this.group != null)
            {
                GreenModel model;
                if (this.group.Models.TryGetValue(mid, out model))
                {
                    return new ModelRef(model, false);
                }
                if (this.group.References.TryGetValue(mid, out model))
                {
                    return new ModelRef(model, true);
                }
                return null;
            }
            else
            {
                if (this.model.Id == mid)
                {
                    return new ModelRef(this.model, false);
                }
                return null;
            }
        }

        private GreenSymbol GetSymbol(SymbolId sid, bool onlyFromModels = false)
        {
            GreenSymbol symbol = null;
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Symbols.TryGetValue(sid, out symbol))
                    {
                        return symbol;
                    }
                }
                if (!onlyFromModels)
                {
                    foreach (var model in this.group.References.Values)
                    {
                        if (model.Symbols.TryGetValue(sid, out symbol))
                        {
                            return symbol;
                        }
                    }
                }
                return null;
            }
            else
            {
                if (this.model.Symbols.TryGetValue(sid, out symbol))
                {
                    return symbol;
                }
            }
            return null;
        }

        private GreenSymbol GetSymbol(ModelId mid, SymbolId sid)
        {
            GreenModel model = this.GetModel(mid);
            GreenSymbol symbol;
            if (model != null && model.Symbols.TryGetValue(sid, out symbol))
            {
                return symbol;
            }
            return null;
        }

        private SymbolRef ResolveSymbol(SymbolId sid, bool onlyFromModels = false)
        {
            GreenSymbol symbol = null;
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Symbols.TryGetValue(sid, out symbol))
                    {
                        return new SymbolRef(model, sid, symbol, false);
                    }
                }
                if (!onlyFromModels)
                {
                    foreach (var model in this.group.References.Values)
                    {
                        if (model.Symbols.TryGetValue(sid, out symbol))
                        {
                            return new SymbolRef(model, sid, symbol, true);
                        }
                    }
                }
                return null;
            }
            else
            {
                if (this.model.Symbols.TryGetValue(sid, out symbol))
                {
                    return new SymbolRef(this.model, sid, symbol, false);
                }
            }
            return null;
        }

        private SymbolRef ResolveSymbol(ModelId mid, SymbolId sid, bool onlyFromModels = false)
        {
            GreenModel model = null;
            bool readOnly = false;
            if (this.group != null)
            {
                if (this.group.Models.TryGetValue(mid, out model))
                {
                    readOnly = false;
                }
                else if (!onlyFromModels && this.group.References.TryGetValue(mid, out model))
                {
                    readOnly = true;
                }
            }
            else
            {
                if (this.model.Id == mid)
                {
                    model = this.model;
                }
            }
            if (model != null)
            {
                GreenSymbol symbol = null;
                if (model.Symbols.TryGetValue(sid, out symbol))
                {
                    return new SymbolRef(model, sid, symbol, readOnly);
                }
            }
            return null;
        }

        private void UpdateModel(GreenModel model)
        {
            if (this.group != null)
            {
                this.group = this.group.Update(this.group.Models.SetItem(model.Id, model), this.group.References);
            }
            else
            {
                this.model = model;
            }
        }

        private GreenModel UpdateSymbol(ModelId mid, SymbolId sid, GreenSymbol symbol)
        {
            GreenModel model = this.GetModel(mid);
            Debug.Assert(model != null);
            model = model.Update(model.Symbols.SetItem(sid, symbol), model.StrongSymbols, model.LazyProperties, model.References);
            if (this.group != null)
            {
                this.group = this.group.Update(this.group.Models.SetItem(model.Id, model), this.group.References);
            }
            else
            {
                this.model = model;
            }
            return model;
        }

        internal bool SymbolExists(SymbolId sid)
        {
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Symbols.ContainsKey(sid)) return true;
                }
                foreach (var model in this.group.References.Values)
                {
                    if (model.Symbols.ContainsKey(sid)) return true;
                }
                return false;
            }
            else
            {
                return this.model.Symbols.ContainsKey(sid);
            }
        }

        internal bool ContainsSymbol(SymbolId sid)
        {
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Symbols.ContainsKey(sid)) return true;
                }
                return false;
            }
            else
            {
                return this.model.Symbols.ContainsKey(sid);
            }
        }

        internal bool ContainsSymbol(ModelId mid, SymbolId sid)
        {
            GreenModel model;
            if (this.group != null)
            {
                if (!this.group.Models.TryGetValue(mid, out model))
                {
                    return false;
                }
            }
            else
            {
                Debug.Assert(this.model.Id == mid);
                model = this.model;
            }
            return model.Symbols.ContainsKey(sid); 
        }

        internal void AddSymbol(ModelId mid, SymbolId sid, bool weak)
        {
            if (this.ContainsSymbol(sid))
            {
                if (this.group != null) throw new ModelException("The symbol is already contained by the model group.");
                else throw new ModelException("The symbol is already contained by the model.");
            }
            GreenModel model = this.GetModel(mid);
            if (model == null)
            {
                Debug.Assert(false);
                throw new ModelException("Cannot resolve the model based on the id.");
            }
            if (this.group != null)
            {
                this.group = this.group.UpdateModel(model.AddSymbol(sid, weak));
            }
            else
            {
                this.model = model.AddSymbol(sid, weak);
            }
        }

        internal bool TryGetValue(ModelId mid, SymbolId sid, ModelProperty property, out object value)
        {
            if (this.TryGetValueCore(mid, sid, property, false, false, out value))
            {
                return true;
            }
            return false;
        }

        internal bool HasValue(ModelId mid, SymbolId sid, ModelProperty property)
        {
            object value;
            return this.TryGetValueCore(mid, sid, property, false, false, out value);
        }

        internal object GetValue(ModelId mid, SymbolId sid, ModelProperty property)
        {
            object value;
            if (this.TryGetValueCore(mid, sid, property, false, false, out value))
            {
                return value;
            }
            return null;
        }

        internal void SetValue(ModelId mid, SymbolId sid, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(!property.IsCollection);
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenSymbol symbol = symbolRef.Symbol;
            object oldValue; 
            if (symbol.Properties.TryGetValue(property, out oldValue) && value != oldValue)
            {
                if (!sid.ModelSymbol.HasAffectedProperties(property) || value is GreenLazyValue || value is GreenDerivedValue)
                {
                    this.SetValueCore(symbolRef, property, reassign, value, oldValue);
                }
                else
                {
                    this.SlowRemoveValueCore(symbolRef, property, true, reassign, -1, false, oldValue, null, null);
                    this.SlowAddValueCore(symbolRef, property, reassign, -1, value, null, null);
                }
            }
        }

        internal void AddItem(ModelId mid, SymbolId sid, ModelProperty property, bool reassign, bool replace, int index, object value)
        {
            Debug.Assert(property.IsCollection);
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenSymbol symbol = symbolRef.Symbol;
            if (symbol.Properties.ContainsKey(property))
            {
                if (!sid.ModelSymbol.HasAffectedProperties(property) || value is GreenLazyValue || value is GreenDerivedValue)
                {
                    object oldValue = null;
                    if (replace && index >= 0) this.RemoveItemCore(symbolRef, property, true, reassign, index, false, ref oldValue);
                    this.AddItemCore(symbolRef, property, reassign, index, value);
                }
                else
                {
                    if (replace && index >= 0) this.SlowRemoveValueCore(symbolRef, property, true, reassign, index, false, null, null, null);
                    this.SlowAddValueCore(symbolRef, property, reassign, index, value, null, null);
                }
            }
        }

        internal void RemoveItem(ModelId mid, SymbolId sid, ModelProperty property, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(property.IsCollection);
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenSymbol symbol = symbolRef.Symbol;
            if (symbol.Properties.ContainsKey(property))
            {
                if (!sid.ModelSymbol.HasAffectedProperties(property) || value is GreenLazyValue || value is GreenDerivedValue)
                {
                    this.RemoveItemCore(symbolRef, property, true, reassign, index, removeAll, ref value);
                }
                else
                {
                    this.SlowRemoveValueCore(symbolRef, property, true, reassign, index, removeAll, value, null, null);
                }
            }
        }

        internal void ClearItems(ModelId mid, SymbolId sid, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            object listValue;
            if (this.TryGetValueCore(mid, sid, property, false, false, out listValue) && (listValue is GreenList))
            {
                GreenList list = (GreenList)listValue;
                if (property.IsSymbol || sid.ModelSymbol.HasAffectedProperties(property))
                {
                    this.ClearLazyItems(mid, sid, property, reassign);
                    foreach (var value in list)
                    {
                        this.RemoveItem(mid, sid, property, reassign, -1, true, value);
                    }
                }
                else
                {
                    SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
                    Debug.Assert(symbolRef != null);
                    GreenModel oldModel = symbolRef.Model;
                    ImmutableHashSet<ModelProperty> oldLazyProperties;
                    bool hasLazy = oldModel.LazyProperties.TryGetValue(sid, out oldLazyProperties) && oldLazyProperties.Contains(property);
                    GreenSymbol oldSymbol = symbolRef.Symbol;
                    GreenSymbol newSymbol = 
                        oldSymbol.Update(
                            oldSymbol.Parent, 
                            oldSymbol.Children, 
                            oldSymbol.Properties.SetItem(property, hasLazy ? list.ClearLazy().Clear() : list.Clear()));
                    GreenModel newModel =
                        oldModel.Update(
                            oldModel.Symbols.SetItem(sid, newSymbol),
                            oldModel.StrongSymbols,
                            oldModel.LazyProperties.SetItem(sid, hasLazy ? oldLazyProperties.Remove(property) : oldLazyProperties),
                            oldModel.References);
                    this.UpdateModel(newModel);
                }
            }
        }

        internal void ClearLazyItems(ModelId mid, SymbolId sid, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenModel oldModel = symbolRef.Model;
            ImmutableHashSet<ModelProperty> oldLazyProperties;
            if (oldModel.LazyProperties.TryGetValue(sid, out oldLazyProperties) && oldLazyProperties.Contains(property))
            {
                object listValue;
                if (this.TryGetValueCore(symbolRef, property, false, false, out listValue) && (listValue is GreenList))
                {
                    GreenList list = (GreenList)listValue;
                    GreenSymbol oldSymbol = symbolRef.Symbol;
                    GreenSymbol newSymbol = oldSymbol.Update(oldSymbol.Parent, oldSymbol.Children, oldSymbol.Properties.SetItem(property, list.ClearLazy()));
                    GreenModel newModel = 
                        oldModel.Update(
                            oldModel.Symbols.SetItem(sid, newSymbol), 
                            oldModel.StrongSymbols, 
                            oldModel.LazyProperties.SetItem(sid, oldLazyProperties.Remove(property)), 
                            oldModel.References);
                    this.UpdateModel(newModel);
                }
            }
        }

        private bool TryGetValueCore(SymbolRef symbolRef, ModelProperty property, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            GreenSymbol symbol = symbolRef.Symbol;
            if (symbol.Properties.TryGetValue(property, out value))
            {
                if (value != GreenSymbol.Unassigned)
                {
                    if (!returnLazyValue && (value is GreenLazyValue))
                    {
                        value = null;
                        return false;
                    }
                    return true;
                }
                else
                {
                    if (!returnUnassignedValue)
                    {
                        value = null;
                    }
                }
            }
            return false;
        }

        private bool TryGetValueCore(ModelId mid, SymbolId sid, ModelProperty property, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            GreenSymbol symbol = this.GetSymbol(mid, sid);
            if (symbol == null)
            {
                value = null;
                return false;
            }
            if (symbol.Properties.TryGetValue(property, out value))
            {
                if (value != GreenSymbol.Unassigned)
                {
                    if (!returnLazyValue && (value is GreenLazyValue))
                    {
                        value = null;
                        return false;
                    }
                    return true;
                }
                else
                {
                    if (!returnUnassignedValue)
                    {
                        value = null;
                    }
                }
            }
            return false;
        }

        private void CheckOldValue(SymbolRef symbolRef, ModelProperty property, bool reassign, object oldValue)
        {
            if (!reassign)
            {
                if (property.IsDerived && oldValue != GreenSymbol.Unassigned)
                {
                    throw new ModelException("Cannot reassign a derived property: " + this.PropertyRef(symbolRef.Id, property));
                }
                if (property.IsReadonly && oldValue != GreenSymbol.Unassigned)
                {
                    throw new ModelException("Cannot reassign a read-only property: " + this.PropertyRef(symbolRef.Id, property));
                }
                if (oldValue is GreenLazyValue)
                {
                    throw new ModelException("Cannot reassign a lazy-valued property: " + this.PropertyRef(symbolRef.Id, property));
                }
            }
        }

        private void CheckNewValue(SymbolRef symbolRef, ModelProperty property, object value)
        {
            if (value == null && property.IsNonNull)
            {
                throw new ModelException("Null value cannot be assigned to property: " + this.PropertyRef(symbolRef.Id, property));
            }
            if (!(value == null || value == GreenSymbol.Unassigned || (value is GreenLazyValue) || (value is GreenDerivedValue) ||
                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType())))))
            {
                throw new ModelException("Value '" + value + "' of type '" + value.GetType() + "' cannot be assigned to property " + this.PropertyRef(symbolRef.Id, property) + " of type '" + property.MutableTypeInfo.Type + "'.");
            }
            if (value is SymbolId)
            {
                if (!this.SymbolExists((SymbolId)value))
                {
                    if (this.group != null) throw new ModelException("Symbol '" + value + "' cannot be assigned to property " + this.PropertyRef(symbolRef.Id, property) + " of type '" + property.MutableTypeInfo.Type + "', since the symbol cannot be resolved within the model group. Either add the symbol to the model first, or make sure to reference the model which contains the symbol from the model group.");
                    else throw new ModelException("Symbol '" + value + "' cannot be assigned to property " + this.PropertyRef(symbolRef.Id, property) + " of type '" + property.MutableTypeInfo.Type + "', since the symbol cannot be resolved within the model. Either add the symbol to the model first, or create a model group referencing the model which contains the symbol.");
                }
            }
        }

        private void CheckOldItem(SymbolRef symbolRef, ModelProperty property, bool reassign)
        {
            if (!reassign)
            {
                if (property.IsDerived)
                {
                    throw new ModelException("Cannot change a derived property: " + this.PropertyRef(symbolRef.Id, property));
                }
                if (property.IsReadonly)
                {
                    throw new ModelException("Cannot change a read-only property: " + this.PropertyRef(symbolRef.Id, property));
                }
            }
        }

        private void CheckNewItem(SymbolRef symbolRef, ModelProperty property, object value)
        {
            if (value == null && property.IsNonNull)
            {
                throw new ModelException("Null value cannot be added to property: " + this.PropertyRef(symbolRef.Id, property));
            }
            if (!(value == null || (value is GreenLazyValue) || 
                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType())))))
            {
                throw new ModelException("Value '" + value + "' of type '" + value.GetType() + "' cannot be added to property " + this.PropertyRef(symbolRef.Id, property) + " of type '" + property.MutableTypeInfo.Type + "'.");
            }
            if (value is SymbolId)
            {
                if (!this.SymbolExists((SymbolId)value))
                {
                    if (this.group != null) throw new ModelException("Symbol '" + value + "' cannot be assigned to property " + this.PropertyRef(symbolRef.Id, property) + " of type '" + property.MutableTypeInfo.Type + "', since the symbol cannot be resolved within the model group. Either add the symbol to the model first, or make sure to reference the model which contains the symbol from the model group.");
                    else throw new ModelException("Symbol '" + value + "' cannot be assigned to property " + this.PropertyRef(symbolRef.Id, property) + " of type '" + property.MutableTypeInfo.Type + "', since the symbol cannot be resolved within the model. Either add the symbol to the model first, or create a model group referencing the model which contains the symbol.");
                }
            }
        }

        private bool SetValueCore(SymbolRef symbolRef, ModelProperty property, bool reassign, object value, object oldValue)
        {
            Debug.Assert(symbolRef.Symbol.Properties.ContainsKey(property));
            if (value == oldValue) return false;
            this.CheckOldValue(symbolRef, property, reassign, oldValue);
            this.CheckNewValue(symbolRef, property, value);
            if (oldValue != null && oldValue != GreenSymbol.Unassigned)
            {
                if (oldValue is SymbolId)
                {
                    this.RemoveReferenceCore(symbolRef, property, (SymbolId)oldValue);
                }
                else if (oldValue is GreenLazyValue && !(value is GreenLazyValue))
                {
                    this.RemoveLazyPropertyCore(symbolRef, property, (SymbolId)oldValue);
                }
            }
            if (value != null && value != GreenSymbol.Unassigned)
            {
                if (value is SymbolId)
                {
                    this.AddReferenceCore(symbolRef, property, (SymbolId)value);
                }
                else if (value is GreenLazyValue && !(oldValue is GreenLazyValue))
                {
                    this.AddLazyPropertyCore(symbolRef, property, (SymbolId)value);
                }
            }
            GreenSymbol symbol = symbolRef.Symbol;
            symbol = symbol.Update(symbol.Parent, symbol.Children, symbol.Properties.SetItem(property, value));
            symbolRef.Update(symbol);
            return true;
        }

        private bool AddItemCore(SymbolRef symbolRef, ModelProperty property, bool reassign, int index, object value)
        {
            Debug.Assert(symbolRef.Symbol.Properties.ContainsKey(property));
            this.CheckOldItem(symbolRef, property, reassign);
            this.CheckNewItem(symbolRef, property, value);
            GreenList list;
            object listValue;
            if (!this.TryGetValueCore(symbolRef, property, false, false, out listValue) || !(listValue is GreenList))
            {
                list = property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
            }
            else
            {
                list = (GreenList)listValue;
            }
            GreenList oldList = list;
            if (value is GreenLazyValue)
            {
                list = list.AddLazy(value);
                this.AddLazyPropertyCore(symbolRef, property, (SymbolId)value);
            }
            else
            {
                bool newReference = value is SymbolId && !list.Contains(value);
                if (index >= 0 && index <= list.Count)
                {
                    list = list.Insert(index, value);
                }
                else
                {
                    list = list.Add(value);
                }
                if (newReference)
                {
                    this.AddReferenceCore(symbolRef, property, (SymbolId)value);
                }
            }
            GreenSymbol symbol = symbolRef.Symbol;
            symbol = symbol.Update(symbol.Parent, symbol.Children, symbol.Properties.SetItem(property, list));
            symbolRef.Update(symbol);
            return list != oldList;
        }

        private bool RemoveItemCore(SymbolRef symbolRef, ModelProperty property, bool forceRemove, bool reassign, int index, bool removeAll, ref object value)
        {
            Debug.Assert(symbolRef.Symbol.Properties.ContainsKey(property));
            this.CheckOldItem(symbolRef, property, reassign);
            GreenList list;
            object listValue;
            if (this.TryGetValueCore(symbolRef, property, false, false, out listValue))
            {
                if (listValue == null) return false;
                Debug.Assert(listValue is GreenList);
                list = (GreenList)listValue;
            }
            else
            {
                return false;
            }
            if (!forceRemove && property.IsDerivedUnion)
            {
                if (index >= 0)
                {
                    if (index < list.Count) value = list[index];
                }
                ModelSymbolInfo symbolInfo = symbolRef.Id.ModelSymbol;
                if (symbolInfo != null)
                {
                    ModelPropertyInfo propInfo = symbolInfo.GetPropertyInfo(property);
                    if (propInfo != null && propInfo.SubsettingProperties.Count > 0)
                    {
                        ImmutableDictionary<ModelProperty, object> properties = symbolRef.Symbol.Properties;
                        foreach (var subsetProp in propInfo.SubsettingProperties)
                        {
                            ModelProperty representingSubsetProp = subsetProp;
                            ModelPropertyInfo subsetPropInfo = symbolInfo.GetPropertyInfo(subsetProp);
                            if (subsetPropInfo != null && subsetPropInfo.RepresentingProperty != null) representingSubsetProp = subsetPropInfo.RepresentingProperty;
                            object representingSubsetValue;
                            if (properties.TryGetValue(representingSubsetProp, out representingSubsetValue))
                            {
                                if (representingSubsetValue is GreenList)
                                {
                                    GreenList subsetList = (GreenList)representingSubsetValue;
                                    if (subsetList.Contains(value))
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            GreenList oldList = list;
            if (index >= 0)
            {
                if (index < list.Count)
                {
                    list = list.RemoveAt(index);
                }
            }
            else if (removeAll)
            {
                list = list.RemoveAll(value);
            }
            else
            {
                list = list.Remove(value);
            }
            bool removedAll = !list.Contains(value);
            if (value is SymbolId)
            {
                if (removedAll)
                {
                    this.RemoveReferenceCore(symbolRef, property, (SymbolId)value);
                }
            }
            GreenSymbol symbol = symbolRef.Symbol;
            symbol = symbol.Update(symbol.Parent, symbol.Children, symbol.Properties.SetItem(property, list));
            symbolRef.Update(symbol);
            return oldList != list || removedAll;
        }

        private void SlowAddValueCore(SymbolRef symbolRef, ModelProperty property, bool reassign, int index, object value, HashSet<ModelProperty> valueAddedToSelf, HashSet<ModelProperty> valueAddedToOpposite)
        {
            if (valueAddedToSelf != null && valueAddedToSelf.Contains(property)) return;
            ModelSymbolInfo info = symbolRef.Id.ModelSymbol;
            if (info == null) return;
            ModelPropertyInfo propertyInfo = info.GetPropertyInfo(property);
            if (propertyInfo == null) return;
            ModelProperty representingProperty = propertyInfo.RepresentingProperty;
            if (representingProperty == null) representingProperty = property;
            // Setting the value:
            bool valueAdded = false;
            if (representingProperty.IsCollection)
            {
                valueAdded = this.AddItemCore(symbolRef, representingProperty, reassign, index, value);
            }
            else
            {
                valueAdded = this.SetValueCore(symbolRef, representingProperty, reassign, value, GreenSymbol.Unassigned);
            }
            if (!valueAdded)
            {
                if (valueAddedToSelf != null)
                {
                    valueAddedToSelf.UnionWith(propertyInfo.EquivalentProperties);
                    valueAddedToSelf.Add(property);
                }
                return;
            }
            // Updating subsetted properties:
            bool initValueAdded = true;
            if (propertyInfo.SubsettedProperties.Count > 0)
            {
                initValueAdded = false;
                if (valueAddedToSelf == null) valueAddedToSelf = new HashSet<ModelProperty>(propertyInfo.EquivalentProperties);
                else valueAddedToSelf.UnionWith(propertyInfo.EquivalentProperties);
                valueAddedToSelf.Add(property);
                foreach (var subsettedProp in propertyInfo.SubsettedProperties)
                {
                    this.SlowAddValueCore(symbolRef, subsettedProp, reassign, -1, value, valueAddedToSelf, valueAddedToOpposite);
                }
            }
            // Updating opposite properties:
            if (value is SymbolId && propertyInfo.OppositeProperties.Count > 0)
            {
                SymbolRef valueSymbolRef = this.ResolveSymbol((SymbolId)value, true);
                if (valueSymbolRef != null)
                {
                    if (initValueAdded)
                    {
                        if (valueAddedToSelf == null) valueAddedToSelf = new HashSet<ModelProperty>(propertyInfo.EquivalentProperties);
                        else valueAddedToSelf.UnionWith(propertyInfo.EquivalentProperties);
                        valueAddedToSelf.Add(property);
                    }
                    foreach (var oppositeProp in propertyInfo.OppositeProperties)
                    {
                        this.SlowAddValueCore(valueSymbolRef, oppositeProp, reassign, -1, symbolRef.Id, valueAddedToOpposite, valueAddedToSelf);
                    }
                }
            }
        }

        private void SlowRemoveValueCore(SymbolRef symbolRef, ModelProperty property, bool forceRemove, bool reassign, int index, bool removeAll, object value, HashSet<ModelProperty> valueRemovedFromSelf, HashSet<ModelProperty> valueRemovedFromOpposite)
        {
            if (valueRemovedFromSelf != null && valueRemovedFromSelf.Contains(property)) return;
            ModelSymbolInfo info = symbolRef.Id.ModelSymbol;
            if (info == null) return;
            ModelPropertyInfo propertyInfo = info.GetPropertyInfo(property);
            if (propertyInfo == null) return;
            ModelProperty representingProperty = propertyInfo.RepresentingProperty;
            if (representingProperty == null) representingProperty = property;
            // Setting the value:
            bool valueRemoved = false;
            if (representingProperty.IsCollection)
            {
                valueRemoved = this.RemoveItemCore(symbolRef, representingProperty, forceRemove, reassign, index, removeAll, ref value);
            }
            else
            {
                valueRemoved = this.SetValueCore(symbolRef, representingProperty, reassign, GreenSymbol.Unassigned, value);
            }
            if (!valueRemoved)
            {
                if (forceRemove || !property.IsDerivedUnion)
                {
                    if (valueRemovedFromSelf != null)
                    {
                        valueRemovedFromSelf.UnionWith(propertyInfo.EquivalentProperties);
                        valueRemovedFromSelf.Add(property);
                    }
                }
                return;
            }            
            // Updating subsetting properties:
            bool initValueRemoved = true;
            if (propertyInfo.SubsettingProperties.Count > 0 || propertyInfo.DerivedUnionProperties.Count > 0)
            {
                if (valueRemovedFromSelf == null) valueRemovedFromSelf = new HashSet<ModelProperty>(propertyInfo.EquivalentProperties);
                else valueRemovedFromSelf.UnionWith(propertyInfo.EquivalentProperties);
                valueRemovedFromSelf.Add(property);
                initValueRemoved = false;
                foreach (var subsettingProp in propertyInfo.SubsettingProperties)
                {
                    this.SlowRemoveValueCore(symbolRef, subsettingProp, true, reassign, -1, removeAll, value, valueRemovedFromSelf, valueRemovedFromOpposite);
                }
                foreach (var subsettedProp in propertyInfo.DerivedUnionProperties)
                {
                    this.SlowRemoveValueCore(symbolRef, subsettedProp, false, reassign, -1, removeAll, value, valueRemovedFromSelf, valueRemovedFromOpposite);
                }
            }
            // Updating opposite properties:
            if (value is SymbolId && propertyInfo.OppositeProperties.Count > 0)
            {
                SymbolRef valueSymbolRef = this.ResolveSymbol((SymbolId)value, true);
                if (valueSymbolRef != null)
                {
                    if (initValueRemoved)
                    {
                        if (valueRemovedFromSelf == null) valueRemovedFromSelf = new HashSet<ModelProperty>(propertyInfo.EquivalentProperties);
                        else valueRemovedFromSelf.UnionWith(propertyInfo.EquivalentProperties);
                        valueRemovedFromSelf.Add(property);
                    }
                    foreach (var oppositeProp in propertyInfo.OppositeProperties)
                    {
                        this.SlowRemoveValueCore(valueSymbolRef, oppositeProp, true, reassign, -1, removeAll, symbolRef.Id, valueRemovedFromOpposite, valueRemovedFromSelf);
                    }
                }
            }
        }

        private void AddReferenceCore(SymbolRef symbolRef, ModelProperty property, SymbolId valueSid)
        {
            GreenModel model = symbolRef.Model;
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> references;
            if (!model.References.TryGetValue(valueSid, out references))
            {
                references = ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>.Empty;
            }
            SymbolId sid = symbolRef.Id;
            ImmutableHashSet<ModelProperty> properties;
            if (!references.TryGetValue(sid, out properties))
            {
                properties = ImmutableHashSet<ModelProperty>.Empty;
            }
            if (!properties.Contains(property))
            {
                if (property.IsContainment)
                {
                    SymbolRef valueRef = this.ResolveSymbol(valueSid, true);
                    if (valueRef != null)
                    {
                        if (valueRef.Symbol.Parent != null)
                        {
                            if (valueRef.Symbol.Parent != sid)
                            {
                                throw new ModelException("Invalid containment in " + this.PropertyRef(sid, property) + ": symbol '" + valueSid + "' is already contained by '" + valueRef.Symbol.Parent + "'.");
                            }
                        }
                        else
                        {
                            if (valueSid == sid)
                            {
                                throw new ModelException("Invalid containment in " + this.PropertyRef(sid, property) + ": a symbol cannot contain itself.");
                            }
                            if (valueRef.Model != model)
                            {
                                throw new ModelException("Invalid containment in " + this.PropertyRef(sid, property) + ": the containing symbol and the contained symbol must be in the same model.");
                            }
                            if (symbolRef.Symbol.Parent != null)
                            {
                                List<SymbolId> ids = new List<SymbolId>();
                                ids.Add(valueSid);
                                GreenSymbol currentSymbol = symbolRef.Symbol;
                                SymbolId currentId = currentSymbol.Parent;
                                while (currentId != null)
                                {
                                    if (ids.Contains(currentId))
                                    {
                                        throw new CircularContainmentException("Invalid containment in " + this.PropertyRef(sid, property) + ": circular containment.", ids);
                                    }
                                    ids.Add(currentId);
                                    if (model.Symbols.TryGetValue(currentId, out currentSymbol))
                                    {
                                        currentId = currentSymbol.Parent;
                                    }
                                    else
                                    {
                                        currentId = null;
                                    }
                                }
                            }
                            GreenSymbol symbol = symbolRef.Symbol;
                            Debug.Assert(!symbol.Children.Contains(valueSid));
                            symbolRef.Update(symbol.Update(symbol.Parent, symbol.Children.Add(valueSid), symbol.Properties));
                            GreenSymbol valueSymbol;
                            if (symbolRef.Model.Symbols.TryGetValue(valueSid, out valueSymbol))
                            {
                                valueRef.Update(symbolRef.Model, valueRef.Symbol.Update(sid, valueSymbol.Children, valueSymbol.Properties), true);
                                model = valueRef.Model;
                            }
                            else
                            {
                                Debug.Assert(false);
                            }
                        }
                    }
                }
                references = references.SetItem(sid, properties.Add(property));
                model = model.Update(model.Symbols, model.StrongSymbols, model.LazyProperties, model.References.SetItem(valueSid, references));
                symbolRef.Update(model, symbolRef.Symbol, false);
            }
        }

        private void RemoveReferenceCore(SymbolRef symbolRef, ModelProperty property, SymbolId valueSid)
        {
            GreenModel model = symbolRef.Model;
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> references;
            if (!model.References.TryGetValue(valueSid, out references))
            {
                return;
            }
            SymbolId sid = symbolRef.Id;
            ImmutableHashSet<ModelProperty> properties;
            if (!references.TryGetValue(sid, out properties))
            {
                return;
            }
            if (properties.Contains(property))
            {
                properties = properties.Remove(property);
                if (properties.IsEmpty) references = references.Remove(sid);
                else references = references.SetItem(sid, properties.Remove(property));
                ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> modelReferences;
                if (references.IsEmpty) modelReferences = model.References.Remove(valueSid);
                else modelReferences = model.References.SetItem(valueSid, references);
                ImmutableDictionary<SymbolId, GreenSymbol> modelSymbols = model.Symbols;
                GreenSymbol symbol = symbolRef.Symbol;
                if (property.IsContainment)
                {
                    bool lostParent = true;
                    foreach (var prop in properties)
                    {
                        if (prop.IsContainment)
                        {
                            lostParent = false;
                            break;
                        }
                    }
                    if (lostParent)
                    {
                        GreenSymbol valueSymbol;
                        if (model.Symbols.TryGetValue(valueSid, out valueSymbol))
                        {
                            symbol = symbol.Update(symbol.Parent, symbol.Children.Remove(valueSid), symbol.Properties);
                            modelSymbols = modelSymbols.
                                SetItem(valueSid, valueSymbol.Update(null, valueSymbol.Children, valueSymbol.Properties)).
                                SetItem(sid, symbol);
                        }
                        else
                        {
                            Debug.Assert(false);
                        }
                    }
                }
                model = model.Update(modelSymbols, model.StrongSymbols, model.LazyProperties, modelReferences);
                symbolRef.Update(model, symbolRef.Symbol, symbol != symbolRef.Symbol);
            }
        }

        private void AddLazyPropertyCore(SymbolRef symbolRef, ModelProperty property, SymbolId valueSid)
        {
            SymbolId sid = symbolRef.Id;
            ImmutableHashSet<ModelProperty> lazyProperties;
            GreenModel model = symbolRef.Model;
            if (!model.LazyProperties.TryGetValue(sid, out lazyProperties))
            {
                lazyProperties = ImmutableHashSet<ModelProperty>.Empty;
            }
            if (!lazyProperties.Contains(property))
            {
                lazyProperties = lazyProperties.Add(property);
                model = model.Update(model.Symbols, model.StrongSymbols, model.LazyProperties.SetItem(sid, lazyProperties), model.References);
                symbolRef.Update(model, symbolRef.Symbol, false);
            }
        }

        private void RemoveLazyPropertyCore(SymbolRef symbolRef, ModelProperty property, SymbolId valueSid)
        {
            SymbolId sid = symbolRef.Id;
            ImmutableHashSet<ModelProperty> lazyProperties;
            GreenModel model = symbolRef.Model;
            if (model.LazyProperties.TryGetValue(sid, out lazyProperties))
            {
                lazyProperties = lazyProperties.Remove(property);
                if (lazyProperties.IsEmpty) model = model.Update(model.Symbols, model.StrongSymbols, model.LazyProperties.Remove(sid), model.References);
                else model = model.Update(model.Symbols, model.StrongSymbols, model.LazyProperties.SetItem(sid, lazyProperties), model.References);
                symbolRef.Update(model, symbolRef.Symbol, false);
            }
        }

        private string PropertyRef(SymbolId sid, ModelProperty property)
        {
            return sid + "." + property.Name;
        }

        private class ModelRef
        {
            private GreenModel model;
            private bool isReadonly;

            public ModelRef(GreenModel model, bool isReadonly)
            {
                this.model = model;
                this.isReadonly = isReadonly;
            }

            public GreenModel Model { get { return this.model; } }
            public bool IsReadonly { get { return this.isReadonly; } }
        }

        private class SymbolRef
        {
            private GreenModel model;
            private SymbolId id;
            private GreenSymbol symbol;
            private bool isReadonly;

            public SymbolRef(GreenModel model, SymbolId id, GreenSymbol symbol, bool isReadonly)
            {
                this.model = model;
                this.id = id;
                this.symbol = symbol;
                this.isReadonly = isReadonly;
            }

            public GreenModel Model { get { return this.model; } }
            public SymbolId Id { get { return this.id; } }
            public GreenSymbol Symbol { get { return this.symbol; } }
            public bool IsReadonly { get { return this.isReadonly; } }

            public void Update(GreenModel model, GreenSymbol symbol, bool addSymbolToModel)
            {
                if (addSymbolToModel) this.model = model.Update(model.Symbols.SetItem(this.id, symbol), model.StrongSymbols, model.LazyProperties, model.References);
                else this.model = model;
                this.symbol = symbol;
            }

            public void Update(GreenSymbol symbol)
            {
                this.model = model.Update(model.Symbols.SetItem(this.id, symbol), model.StrongSymbols, model.LazyProperties, model.References);
                this.symbol = symbol;
            }
        }
    }
}
