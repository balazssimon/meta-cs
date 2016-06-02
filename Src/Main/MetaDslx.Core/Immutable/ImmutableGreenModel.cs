using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
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

    internal sealed class GreenLazyList
    {
        private Func<IEnumerable<object>> lazy;

        internal GreenLazyList(Func<IEnumerable<object>> lazy)
        {
            this.lazy = lazy;
        }

        internal Func<object> Lazy
        {
            get { return this.lazy; }
        }

        internal List<object> CreateGreenValues()
        {
            List<object> result = new List<object>();
            foreach (var item in lazy())
            {
                object value = item;
                if (value is MutableSymbolBase)
                {
                    value = ((MutableSymbolBase)value).Id;
                }
                else if (value is ImmutableSymbolBase)
                {
                    value = ((ImmutableSymbolBase)value).Id;
                }
                result.Add(value);
            }
            return result;
        }
    }

    public sealed class LazyEvalEntry : IEquatable<LazyEvalEntry>
    {
        private SymbolId symbol;
        private ModelProperty property;

        public LazyEvalEntry(SymbolId symbol, ModelProperty property)
        {
            this.symbol = symbol;
            this.property = property;
        }

        public SymbolId Symbol { get { return this.symbol; } }
        public ModelProperty Property { get { return this.property; } }

        public bool Equals(LazyEvalEntry other)
        {
            if (other == null) return false;
            return this.symbol == other.symbol && this.property == other.property;
        }
    }

    public sealed class CircularContainmentException : ModelException
    {
        private List<SymbolId> symbols;

        internal CircularContainmentException(string message, List<SymbolId> symbols)
            : base(message)
        {
            this.symbols = symbols;
        }

        internal CircularContainmentException(string message, List<SymbolId> symbols, Exception innerException)
            : base(message, innerException)
        {
            this.symbols = symbols;
        }

        public IReadOnlyList<SymbolId> Symbols
        {
            get { return this.symbols; }
        }
    }

    public sealed class LazyEvalException : ModelException
    {
        private List<LazyEvalEntry> evalStack;

        internal LazyEvalException(string message, List<LazyEvalEntry> evalStack)
            : base(message)
        {
            this.evalStack = evalStack;
        }

        internal LazyEvalException(string message, List<LazyEvalEntry> evalStack, Exception innerException)
            : base(message, innerException)
        {
            this.evalStack = evalStack;
        }

        public IReadOnlyList<LazyEvalEntry> EvalStack
        {
            get { return this.evalStack; }
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
            this.items = items;
            this.lazyItems = lazyItems;
        }

        private GreenList Update(ImmutableList<object> items, ImmutableList<object> lazyItems)
        {
            if (this.items != items || this.lazyItems != lazyItems)
            {
                return new GreenList(this.unique, this.items, this.lazyItems);
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

    internal class GreenSymbolContext
    {
        private GreenModelGroup group;
        private GreenModel model;
        private ImmutableDictionary<GreenModel, ImmutableDictionary<SymbolId, GreenSymbol>> modifiedSymbols;

        internal GreenSymbolContext(GreenModelGroup group, GreenModel model)
        {
            this.group = group;
            this.model = model;
            this.modifiedSymbols = ImmutableDictionary<GreenModel, ImmutableDictionary<SymbolId, GreenSymbol>>.Empty;
        }

        internal GreenSymbolContext(GreenModelGroup group, GreenModel model, ImmutableDictionary<GreenModel, ImmutableDictionary<SymbolId, GreenSymbol>> modifiedSymbols)
        {
            this.group = group;
            this.model = model;
            this.modifiedSymbols = modifiedSymbols;
        }

        internal void AddModifiedSymbol(GreenSymbol symbol)
        {
            GreenModel model;
            bool readOnly;
            GreenSymbol oldSymbol = this.GetSymbol(symbol.Id, out model, out readOnly);
            this.AddModifiedSymbol(model, oldSymbol, symbol);
        }

        internal void AddModifiedSymbol(GreenModel model, GreenSymbol oldSymbol, GreenSymbol newSymbol)
        {
            if (oldSymbol != newSymbol)
            {
                ImmutableDictionary<SymbolId, GreenSymbol> symbols;
                if (this.modifiedSymbols.TryGetValue(model, out symbols))
                {
                    this.modifiedSymbols = this.modifiedSymbols.SetItem(model, symbols.SetItem(newSymbol.Id, newSymbol));
                }
                else
                {
                    this.modifiedSymbols = this.modifiedSymbols.Add(model, ImmutableDictionary<SymbolId, GreenSymbol>.Empty.Add(newSymbol.Id, newSymbol));
                }
            }
        }

        internal GreenSymbol GetSymbol(SymbolId id, out GreenModel model, out bool readOnly)
        {
            GreenSymbol result;
            foreach (var entries in this.modifiedSymbols)
            {
                if (entries.Value.TryGetValue(id, out result))
                {
                    model = entries.Key;
                    readOnly = false;
                    return result;
                }
            }
            if (this.group != null)
            {
                return this.group.GetSymbol(id, out model, out readOnly);
            }
            else if (this.model != null)
            {
                result = this.model.GetSymbol(id);
                if (result != null)
                {
                    model = this.model;
                    readOnly = false;
                    return result;
                }
            }
            model = null;
            readOnly = true;
            return null;
        }

        internal ImmutableDictionary<GreenModel, ImmutableDictionary<SymbolId, GreenSymbol>> ModifiedSymbols
        {
            get { return this.modifiedSymbols; }
            set { this.modifiedSymbols = value; }
        }

        internal bool SymbolExists(SymbolId value)
        {
            throw new NotImplementedException();
        }
    }

    internal class GreenSymbol
    {
        private static object Unassigned = new object();

        private SymbolId id;
        private SymbolId parent;
        private ImmutableList<SymbolId> children;
        private ImmutableHashSet<ModelProperty> parentProperties;
        private ImmutableDictionary<ModelProperty, object> properties;
        private ImmutableList<ModelProperty> attachedProperties;
        private ImmutableHashSet<ModelProperty> lazyIndex;
        private ImmutableDictionary<ModelProperty, ImmutableDictionary<ModelProperty, object>> childInitializers;

        internal GreenSymbol(SymbolId id)
        {
            Debug.Assert(id != null, "The value of 'id' must not be null.");
            this.id = id;
            this.parent = null;
            this.children = ImmutableList<SymbolId>.Empty;
            this.parentProperties = ImmutableHashSet<ModelProperty>.Empty;
            this.properties = ImmutableDictionary<ModelProperty, object>.Empty;
            this.attachedProperties = ImmutableList<ModelProperty>.Empty;
            this.lazyIndex = ImmutableHashSet<ModelProperty>.Empty;
            this.childInitializers = ImmutableDictionary<ModelProperty, ImmutableDictionary<ModelProperty, object>>.Empty;
        }

        private GreenSymbol(
            SymbolId id,
            SymbolId parent,
            ImmutableList<SymbolId> children,
            ImmutableHashSet<ModelProperty> parentProperties,
            ImmutableDictionary<ModelProperty, object> properties,
            ImmutableList<ModelProperty> attachedProperties,
            ImmutableHashSet<ModelProperty> lazyIndex,
            ImmutableDictionary<ModelProperty, ImmutableDictionary<ModelProperty, object>> childInitializers)
        {
            Debug.Assert(id != null, "The value of 'id' must not be null.");
            this.id = id;
            this.parent = parent;
            this.children = children;
            this.parentProperties = parentProperties;
            this.properties = properties;
            this.attachedProperties = attachedProperties;
            this.lazyIndex = lazyIndex;
            this.childInitializers = childInitializers;
        }

        private GreenSymbol Update(
            SymbolId id,
            SymbolId parent,
            ImmutableList<SymbolId> children,
            ImmutableHashSet<ModelProperty> parentProperties,
            ImmutableDictionary<ModelProperty, object> properties,
            ImmutableList<ModelProperty> attachedProperties,
            ImmutableHashSet<ModelProperty> lazyIndex,
            ImmutableDictionary<ModelProperty, ImmutableDictionary<ModelProperty, object>> childInitializers)
        {
            if (this.id != id || this.parent != parent || 
                this.children != children || this.parentProperties != parentProperties || 
                this.properties != properties || this.attachedProperties != attachedProperties ||
                this.lazyIndex != lazyIndex || this.childInitializers != childInitializers)
            {
                return new GreenSymbol(id, parent, children, parentProperties,
                    properties, attachedProperties, lazyIndex, childInitializers);
            }
            return this;
        }

        internal SymbolId Id
        {
            get { return this.id; }
        }

        internal SymbolId Parent
        {
            get { return this.parent; }
        }

        internal IReadOnlyList<SymbolId> Children
        {
            get { return this.children; }
        }

        internal IEnumerable<ModelProperty> Properties
        {
            get { return this.properties.Keys; }
        }

        internal IEnumerable<ModelProperty> AttachedProperties
        {
            get { return this.attachedProperties; }
        }

        internal bool HasLazyValues
        {
            get { return this.lazyIndex.Count > 0; }
        }

        internal GreenSymbol AddProperty(GreenSymbolContext context, ModelProperty property)
        {
            if (!this.properties.ContainsKey(property))
            {
                bool declared = ModelProperty.GetDeclaredPropertiesForType(id.MutableType).Contains(property);
                // TODO: related properties
                return this.Update(
                    this.id, 
                    this.parent, 
                    this.children,
                    this.parentProperties,
                    this.properties.Add(property, GreenSymbol.Unassigned),
                    declared ? this.attachedProperties : this.attachedProperties.Add(property),
                    this.lazyIndex,
                    this.childInitializers);
            }
            return this;
        }

        internal GreenSymbol RemoveProperty(GreenSymbolContext context, ModelProperty property)
        {
            if (this.properties.ContainsKey(property))
            {
                bool declared = ModelProperty.GetDeclaredPropertiesForType(id.MutableType).Contains(property);
                if (declared)
                {
                    return this;
                }
                else
                {
                    GreenSymbol result = this;
                    if (property.IsCollection)
                    {
                        result = this.ClearLazyItems(context, property, false).ClearItems(context, property, false);
                    }
                    else
                    {
                        result = this.SetValue(context, property, true, Unassigned);
                    }
                    return result.Update(
                        result.id,
                        result.parent,
                        result.children,
                        result.parentProperties,
                        result.properties.Remove(property),
                        result.attachedProperties.Remove(property),
                        result.lazyIndex,
                        result.childInitializers);
                }
            }
            return this;
        }

        internal bool TryGetValue(ModelProperty property, out object value)
        {
            if (this.TryGetValueCore(property, false, false, out value))
            {
                return true;
            }
            return false;
        }

        internal bool HasValue(ModelProperty property)
        {
            object value;
            return this.TryGetValueCore(property, false, false, out value);
        }

        internal object GetValue(ModelProperty property)
        {
            object value;
            if (this.TryGetValueCore(property, false, false, out value))
            {
                return value;
            }
            return null;
        }

        internal bool HasLazyValue(ModelProperty property)
        {
            object value;
            if (this.TryGetValueCore(property, false, true, out value))
            {
                if (value is GreenLazyValue)
                {
                    return true;
                }
                else if (value is GreenList)
                {
                    return ((GreenList)value).HasLazyItems;
                }
            }
            return false;
        }

        internal GreenLazyValue GetLazyValue(ModelProperty property)
        {
            object value;
            if (this.TryGetValueCore(property, false, true, out value))
            {
                return value as GreenLazyValue;
            }
            return null;
        }

        internal GreenSymbol GetValue(GreenSymbolContext context, ModelProperty property, bool lazyEval, out object value)
        {
            GreenSymbol result = this;
            if (lazyEval && result.lazyIndex.Count > 0)
            {
                if (property.HasRemoveAffectedProperties)
                {
                    foreach (var prop in property.RemoveAffectedProperties)
                    {
                        if (result.lazyIndex.Contains(prop))
                        {
                            result = result.LazyEvalCore(context, prop, new List<LazyEvalEntry>());
                        }
                    }
                }
                if (result.lazyIndex.Contains(property))
                {
                    result = result.LazyEvalCore(context, property, new List<LazyEvalEntry>());
                }
            }
            value = result.GetValue(property);
            return result;
        }

        internal GreenSymbol SetValue(GreenSymbolContext context, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(!property.IsCollection);
            Debug.Assert(!(value is GreenLazyList));
            if (!this.properties.ContainsKey(property)) return this;
            object oldValue;
            if (this.ValueChangedCore(property, value, out oldValue))
            {
                if (!property.HasAffectedProperties || value is GreenLazyValue || value is GreenDerivedValue)
                {
                    return this.SetValueCore(context, property, reassign, value, oldValue);
                }
                else
                {
                    return this.SlowAddValueCore(context, property, reassign, -1, value, oldValue);
                }
            }
            return this;
        }

        internal GreenSymbol AddItem(GreenSymbolContext context, ModelProperty property, bool reassign, bool replace, int index, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (!property.HasAddAffectedProperties || value is GreenLazyValue || value is GreenLazyList)
            {
                if (replace) result = result.RemoveValueCore(context, property, reassign, index, false, null);
                return result.AddValueCore(context, property, reassign, index, value);
            }
            else
            {
                if (replace) result = result.SlowRemoveValueCore(context, property, reassign, index, false, null);
                return result.SlowAddValueCore(context, property, reassign, index, value, Unassigned);
            }
        }

        internal GreenSymbol AddItems(GreenSymbolContext context, ModelProperty property, bool reassign, IEnumerable<object> values)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (!property.HasAddAffectedProperties)
            {
                foreach (var value in values)
                {
                    result = result.AddValueCore(context, property, reassign, -1, value);
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (value is GreenLazyValue || value is GreenLazyList)
                    {
                        result = result.AddValueCore(context, property, reassign, -1, value);
                    }
                    else
                    {
                        result = result.SlowAddValueCore(context, property, reassign, -1, value, Unassigned);
                    }
                }
            }
            return result;
        }

        internal GreenSymbol RemoveItem(GreenSymbolContext context, ModelProperty property, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            if (!this.properties.ContainsKey(property)) return this;
            if (!property.HasRemoveAffectedProperties)
            {
                return this.RemoveValueCore(context, property, reassign, index, removeAll, value);
            }
            else
            {
                return this.SlowRemoveValueCore(context, property, reassign, index, removeAll, value);
            }
        }

        internal GreenSymbol ClearItems(GreenSymbolContext context, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            object listValue;
            GreenSymbol result = this;
            if (this.TryGetValueCore(property, false, false, out listValue) && (listValue is GreenList))
            {
                GreenList list = (GreenList)listValue;
                foreach (var value in list)
                {
                    result = result.RemoveItem(context, property, reassign, -1, true, value);
                }
            }
            return result;
        }

        internal GreenSymbol ClearLazyItems(GreenSymbolContext context, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            object listValue;
            GreenSymbol result = this;
            if (this.TryGetValueCore(property, false, false, out listValue) && (listValue is GreenList))
            {
                GreenList list = (GreenList)listValue;
                result = result.Update(
                    result.id,
                    result.parent,
                    result.children,
                    result.parentProperties,
                    result.properties.SetItem(property, list.ClearLazy()),
                    result.attachedProperties,
                    result.lazyIndex.Remove(property),
                    result.childInitializers);
            }
            return result;
        }

        internal GreenSymbol ChildSetValue(GreenSymbolContext context, ModelProperty child, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(!property.IsCollection);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + this.PropertyRef(child) + " must be a containment.");
            }
            ImmutableDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = ImmutableDictionary<ModelProperty, object>.Empty;
            }
            return this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.SetItem(child, initValues.SetItem(property, value)));
        }

        internal GreenSymbol ChildAddItem(GreenSymbolContext context, ModelProperty child, ModelProperty property, object value)
        {
            Debug.Assert(property.IsCollection);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + this.PropertyRef(child) + " must be a containment.");
            }
            ImmutableDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = ImmutableDictionary<ModelProperty, object>.Empty;
            }
            object initValue;
            ImmutableList<object> initList = ImmutableList<object>.Empty;
            if (!initValues.TryGetValue(property, out initValue) && initValue is ImmutableList<object>)
            {
                initList = (ImmutableList<object>)initValue;
            }
            initList = initList.Add(value);
            return this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.SetItem(child, initValues.SetItem(property, initList)));
        }

        internal GreenSymbol ChildAddItems(GreenSymbolContext context, ModelProperty child, ModelProperty property, IEnumerable<object> values)
        {
            Debug.Assert(property.IsCollection);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + this.PropertyRef(child) + " must be a containment.");
            }
            ImmutableDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = ImmutableDictionary<ModelProperty, object>.Empty;
            }
            object initValue;
            ImmutableList<object> initList = ImmutableList<object>.Empty;
            if (!initValues.TryGetValue(property, out initValue) && initValue is ImmutableList<object>)
            {
                initList = (ImmutableList<object>)initValue;
            }
            initList = initList.AddRange(values);
            return this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.SetItem(child, initValues.SetItem(property, initList)));
        }

        internal GreenSymbol ChildClear(GreenSymbolContext context, ModelProperty child)
        {
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + this.PropertyRef(child) + " must be a containment.");
            }
            return this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.Remove(child));
        }

        internal GreenSymbol ChildClear(GreenSymbolContext context, ModelProperty child, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + this.PropertyRef(child) + " must be a containment.");
            }
            ImmutableDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = ImmutableDictionary<ModelProperty, object>.Empty;
            }
            return this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.SetItem(child, initValues.Remove(property)));
        }

        private bool TryGetValueCore(ModelProperty property, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            if (this.properties.TryGetValue(property, out value))
            {
                if (value != GreenSymbol.Unassigned)
                {
                    Debug.Assert(!(value is GreenLazyList));
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

        private bool ValueChangedCore(ModelProperty property, object value, out object oldValue)
        {
            if (this.TryGetValueCore(property, true, true, out oldValue))
            {
                return value != oldValue;
            }
            oldValue = GreenSymbol.Unassigned;
            return value != oldValue;
        }

        private void CheckOldValue(ModelProperty property, bool reassign, object oldValue)
        {
            if (!reassign)
            {
                if (property.IsDerived && oldValue != GreenSymbol.Unassigned)
                {
                    throw new ModelException("Cannot reassign a derived property: " + this.PropertyRef(property));
                }
                if (property.IsReadonly && oldValue != GreenSymbol.Unassigned)
                {
                    throw new ModelException("Cannot reassign a read-only property: " + this.PropertyRef(property));
                }
                if (oldValue is GreenLazyValue)
                {
                    throw new ModelException("Cannot reassign a lazy-valued property: " + this.PropertyRef(property));
                }
            }
        }

        private void CheckNewValue(GreenSymbolContext context, ModelProperty property, object value)
        {
            if (value == null && property.IsNonNull)
            {
                throw new ModelException("Null value cannot be assigned to property: " + this.PropertyRef(property));
            }
            if (!(value == null || value == GreenSymbol.Unassigned || (value is GreenLazyValue) || (value is GreenDerivedValue) ||
                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType())))))
            {
                throw new ModelException("Value '" + value + "' of type '" + value.GetType() + "' cannot be assigned to property " + this.PropertyRef(property) + " of type '" + property.MutableTypeInfo.Type + "'.");
            }
            if (value is SymbolId)
            {
                if (!context.SymbolExists((SymbolId)value))
                {
                    throw new ModelException("Symbol '" + value + "' with id '" + ((SymbolId)value).Id + "' cannot be assigned to property " + this.PropertyRef(property) + " of type '" + property.MutableTypeInfo.Type + "', since the value cannot be resolved within the model group. Make sure to reference the required models from the model group.");
                }
            }
        }

        private void CheckOldItem(ModelProperty property, bool reassign)
        {
            if (!reassign)
            {
                if (property.IsDerived)
                {
                    throw new ModelException("Cannot change a derived property: " + this.PropertyRef(property));
                }
                if (property.IsReadonly)
                {
                    throw new ModelException("Cannot change a read-only property: " + this.PropertyRef(property));
                }
            }
        }

        private void CheckNewItem(GreenSymbolContext context, ModelProperty property, object value)
        {
            if (value == null && property.IsNonNull)
            {
                throw new ModelException("Null value cannot be added to property: " + this.PropertyRef(property));
            }
            if (!(value == null || (value is GreenLazyValue) || (value is GreenLazyList) ||
                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType())))))
            {
                throw new ModelException("Value '" + value + "' of type '" + value.GetType() + "' cannot be added to property " + this.PropertyRef(property) + " of type '" + property.MutableTypeInfo.Type + "'.");
            }
            if (value is SymbolId)
            {
                if (!context.SymbolExists((SymbolId)value))
                {
                    throw new ModelException("Symbol '" + value + "' with id '" + ((SymbolId)value).Id + "' cannot be added to property " + this.PropertyRef(property) + " of type '" + property.MutableTypeInfo.Type + "', since the value cannot be resolved within the model group. Make sure to reference the required models from the model group.");
                }
            }
        }

        private GreenSymbol SetValueCore(GreenSymbolContext context, ModelProperty property, bool reassign, object value, object oldValue)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(!(value is GreenLazyList));
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is ISymbol));
            Debug.Assert(!(oldValue is GreenLazyList));
            Debug.Assert(!(oldValue is ISymbol));
            if (value == oldValue) return this;
            this.CheckOldValue(property, reassign, oldValue);
            this.CheckNewValue(context, property, value);
            ImmutableList<SymbolId> newChildren = this.children;
            ImmutableHashSet<ModelProperty> newLazyIndex = this.lazyIndex;
            if (oldValue != null && oldValue != GreenSymbol.Unassigned)
            {
                if (oldValue is SymbolId)
                {
                    if (property.IsContainment)
                    {
                        newChildren = this.RemoveChildCore(context, property, (SymbolId)oldValue, newChildren);
                    }
                }
                else if (oldValue is GreenLazyValue && !(value is GreenLazyValue))
                {
                    newLazyIndex = newLazyIndex.Remove(property);
                }
            }
            bool addedAsChild = false;
            ImmutableDictionary<ModelProperty, object> newProperties = this.properties.SetItem(property, value);
            if (value != null && value != GreenSymbol.Unassigned)
            {
                if (value is SymbolId)
                {
                    if (property.IsContainment)
                    {
                        ImmutableList<SymbolId> oldChildren = newChildren;
                        newChildren = this.AddChildCore(context, property, (SymbolId)value, newChildren);
                        addedAsChild = newChildren != oldChildren;
                    }
                }
                else if (value is GreenLazyValue && !(oldValue is GreenLazyValue))
                {
                    newLazyIndex = newLazyIndex.Add(property);
                }
            }
            GreenSymbol result = this.Update(
                this.id,
                this.parent,
                newChildren,
                this.parentProperties,
                newProperties,
                this.attachedProperties,
                newLazyIndex,
                this.childInitializers);
            if (addedAsChild)
            {
                result.InitChildCore(context, property, (SymbolId)value);
            }
            return result;
        }

        private GreenSymbol AddValueCore(GreenSymbolContext context, ModelProperty property, bool reassign, int index, object value)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(value != Unassigned);
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is ISymbol));
            this.CheckOldItem(property, reassign);
            this.CheckNewItem(context, property, value);
            GreenList list;
            object listValue;
            if (!this.TryGetValueCore(property, false, false, out listValue) || !(listValue is GreenList))
            {
                list = property.IsNonUnique ? GreenList.EmptyNonUnique : GreenList.EmptyUnique;
            }
            else
            {
                list = (GreenList)listValue;
            }
            bool addedAsChild = false;
            ImmutableList<SymbolId> newChildren = this.children;
            ImmutableHashSet<ModelProperty> newLazyIndex = this.lazyIndex;
            ImmutableDictionary<ModelProperty, object> newProperties = this.properties;
            GreenList oldList = list;
            if (value is GreenLazyValue || value is GreenLazyList)
            {
                list = list.AddLazy(value);
                newLazyIndex = newLazyIndex.Add(property);
            }
            else
            {
                if (index >= 0)
                {
                    list = list.Insert(index, value);
                }
                else
                {
                    list = list.Add(value);
                }
                if (property.IsContainment && value is SymbolId && !oldList.Contains(value))
                {
                    ImmutableList<SymbolId> oldChildren = newChildren;
                    newChildren = this.AddChildCore(context, property, (SymbolId)value, newChildren);
                    addedAsChild = newChildren != oldChildren;
                }
            }
            if (list != oldList)
            {
                newProperties = newProperties.SetItem(property, list);
            }
            GreenSymbol result = this.Update(
                this.id,
                this.parent,
                newChildren,
                this.parentProperties,
                newProperties,
                this.attachedProperties,
                newLazyIndex,
                this.childInitializers);
            if (addedAsChild)
            {
                result.InitChildCore(context, property, (SymbolId)value);
            }
            return result;
        }

        private GreenSymbol RemoveValueCore(GreenSymbolContext context, ModelProperty property, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(value != Unassigned);
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is ISymbol));
            Debug.Assert(!(index >= 0 && removeAll));
            this.CheckOldItem(property, reassign);
            if (index < 0 && value == null && property.IsNonNull)
            {
                return this;
            }
            GreenList list;
            object listValue;
            if (this.TryGetValueCore(property, false, false, out listValue))
            {
                if (listValue == null) return this;
                Debug.Assert(listValue is GreenList);
                list = (GreenList)listValue;
            }
            else
            {
                return this;
            }
            ImmutableList<SymbolId> newChildren = this.children;
            ImmutableDictionary<ModelProperty, object> newProperties = this.properties;
            GreenList oldList = list;
            bool removedAll;
            if (index >= 0)
            {
                list = list.RemoveAt(index);
            }
            else if (removeAll)
            {
                list = list.RemoveAll(value);
            }
            else
            {
                list = list.Remove(value);
            }
            removedAll = removeAll || !list.Contains(value);
            if (property.IsContainment && removedAll && value is SymbolId)
            {
                newChildren = this.RemoveChildCore(context, property, (SymbolId)value, newChildren);
            }
            if (list != oldList)
            {
                newProperties = newProperties.SetItem(property, list);
            }
            return this.Update(
                this.id,
                this.parent,
                newChildren,
                this.parentProperties,
                newProperties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers);
        }

        private void CollectAddAffectedProperties(ModelProperty property, object value, GreenSymbol opposite, HashSet<ModelProperty> properties, HashSet<ModelProperty> oppositeProperties)
        {
            if (!this.properties.ContainsKey(property)) return;
            if (properties.Add(property))
            {
                if (opposite != null)
                {
                    if (property.HasAddAffectedProperties)
                    {
                        HashSet<ModelProperty> newProperties = new HashSet<ModelProperty>();
                        newProperties.Add(property);
                        foreach (var prop in property.AddAffectedProperties)
                        {
                            if (properties.Add(prop))
                            {
                                newProperties.Add(prop);
                            }
                        }
                        Type mutableType = value is SymbolId ? ((SymbolId)value).MutableType : null;
                        Type valueType = value.GetType();
                        foreach (var prop in property.AddAffectedOptionalProperties)
                        {
                            if (value == null || value is GreenLazyValue || value is GreenLazyList ||
                                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(mutableType))) ||
                                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(valueType))))
                            {
                                if (properties.Add(prop))
                                {
                                    newProperties.Add(prop);
                                }
                            }
                        }
                        foreach (var prop in newProperties)
                        {
                            if (prop.HasOppositeProperties)
                            {
                                foreach (var oppProp in prop.OppositeProperties)
                                {
                                    opposite.CollectAddAffectedProperties(oppProp, this.id, this, oppositeProperties, properties);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (property.HasOppositeProperties)
                        {
                            foreach (var oppProp in property.OppositeProperties)
                            {
                                opposite.CollectAddAffectedProperties(oppProp, this.id, this, oppositeProperties, properties);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var prop in property.AddAffectedProperties)
                    {
                        properties.Add(prop);
                    }
                    Type mutableType = value is SymbolId ? ((SymbolId)value).MutableType : null;
                    Type valueType = value.GetType();
                    foreach (var prop in property.AddAffectedOptionalProperties)
                    {
                        if (value == null || value is GreenLazyValue || value is GreenLazyList ||
                            ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(mutableType))) ||
                            (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(valueType))))
                        {
                            properties.Add(prop);
                        }
                    }
                }
            }
        }

        private void CollectRemoveAffectedProperties(ModelProperty property, object value, GreenSymbol opposite, HashSet<ModelProperty> properties, HashSet<ModelProperty> oppositeProperties)
        {
            if (!this.properties.ContainsKey(property)) return;
            if (properties.Add(property))
            {
                if (opposite != null)
                {
                    if (property.HasRemoveAffectedProperties)
                    {
                        HashSet<ModelProperty> newProperties = new HashSet<ModelProperty>();
                        newProperties.Add(property);
                        foreach (var prop in property.RemoveAffectedProperties)
                        {
                            if (properties.Add(prop))
                            {
                                newProperties.Add(prop);
                            }
                        }
                        Type mutableType = value is SymbolId ? ((SymbolId)value).MutableType : null;
                        Type valueType = value.GetType();
                        foreach (var prop in property.RemoveAffectedOptionalProperties)
                        {
                            if (value == null || value is GreenLazyValue || value is GreenLazyList ||
                                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(mutableType))) ||
                                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(valueType))))
                            {
                                if (properties.Add(prop))
                                {
                                    newProperties.Add(prop);
                                }
                            }
                        }
                        foreach (var prop in newProperties)
                        {
                            if (prop.HasOppositeProperties)
                            {
                                foreach (var oppProp in prop.OppositeProperties)
                                {
                                    opposite.CollectRemoveAffectedProperties(oppProp, this.id, this, oppositeProperties, properties);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (property.HasOppositeProperties)
                        {
                            foreach (var oppProp in property.OppositeProperties)
                            {
                                opposite.CollectRemoveAffectedProperties(oppProp, this.id, this, oppositeProperties, properties);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var prop in property.RemoveAffectedProperties)
                    {
                        properties.Add(prop);
                    }
                    Type mutableType = value is SymbolId ? ((SymbolId)value).MutableType : null;
                    Type valueType = value.GetType();
                    foreach (var prop in property.RemoveAffectedOptionalProperties)
                    {
                        if (value == null || value is GreenLazyValue || value is GreenLazyList ||
                            ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(mutableType))) ||
                            (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(valueType))))
                        {
                            properties.Add(prop);
                        }
                    }
                }
            }
        }


        private GreenSymbol SlowAddValueCore(GreenSymbolContext context, ModelProperty property, bool reassign, int index, object value, object oldValue)
        {
            Debug.Assert(!(value is GreenList));
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (oldValue != GreenSymbol.Unassigned)
            {
                HashSet<ModelProperty> removeAffectedProperties = new HashSet<ModelProperty>();
                HashSet<ModelProperty> removeAffectedOppositeProperties = new HashSet<ModelProperty>();
                SymbolId oldValueId = oldValue as SymbolId;
                GreenModel oldValueModel = null;
                bool oldValueReadOnly = true;
                GreenSymbol oldValueSymbol = null;
                if (oldValueId != null)
                {
                    oldValueSymbol = context.GetSymbol(oldValueId, out oldValueModel, out oldValueReadOnly);
                }
                this.CollectRemoveAffectedProperties(property, oldValue, oldValueSymbol, removeAffectedProperties, removeAffectedOppositeProperties);
                foreach (var prop in removeAffectedProperties)
                {
                    if (prop.IsCollection)
                    {
                        result = result.RemoveValueCore(context, prop, reassign, prop == property ? index : -1, false, oldValue);
                    }
                    else
                    {
                        result = result.SetValueCore(context, prop, reassign, null, oldValue);
                    }
                }
                if (oldValueSymbol != null && !oldValueReadOnly && removeAffectedOppositeProperties.Count > 0)
                {
                    foreach (var prop in removeAffectedOppositeProperties)
                    {
                        if (prop.IsCollection)
                        {
                            oldValueSymbol = oldValueSymbol.RemoveValueCore(context, prop, reassign, -1, false, oldValue);
                        }
                        else
                        {
                            oldValueSymbol = oldValueSymbol.SetValueCore(context, prop, reassign, null, oldValue);
                        }
                    }
                    context.AddModifiedSymbol(oldValueSymbol);
                }
            }
            if (value != GreenSymbol.Unassigned)
            {
                HashSet<ModelProperty> addAffectedProperties = new HashSet<ModelProperty>();
                HashSet<ModelProperty> addAffectedOppositeProperties = new HashSet<ModelProperty>();
                SymbolId valueId = value as SymbolId;
                GreenModel valueModel = null;
                bool valueReadOnly = true;
                GreenSymbol valueSymbol = null;
                if (valueId != null)
                {
                    valueSymbol = context.GetSymbol(valueId, out valueModel, out valueReadOnly);
                }
                this.CollectAddAffectedProperties(property, value, valueSymbol, addAffectedProperties, addAffectedOppositeProperties);
                foreach (var prop in addAffectedProperties)
                {
                    if (prop.IsCollection)
                    {
                        result = result.AddValueCore(context, prop, reassign, prop == property ? index : -1, value);
                    }
                    else
                    {
                        result = result.SetValueCore(context, prop, reassign, null, value);
                    }
                }
                if (valueSymbol != null && !valueReadOnly && addAffectedOppositeProperties.Count > 0)
                {
                    foreach (var prop in addAffectedOppositeProperties)
                    {
                        if (prop.IsCollection)
                        {
                            valueSymbol = valueSymbol.RemoveValueCore(context, prop, reassign, -1, false, this.id);
                        }
                        else
                        {
                            valueSymbol = valueSymbol.SetValueCore(context, prop, reassign, null, this.id);
                        }
                    }
                    context.AddModifiedSymbol(valueSymbol);
                }
            }
            return result;
        }

        private GreenSymbol SlowRemoveValueCore(GreenSymbolContext context, ModelProperty property, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(!(value is GreenList));
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (value != GreenSymbol.Unassigned)
            {
                HashSet<ModelProperty> removeAffectedProperties = new HashSet<ModelProperty>();
                HashSet<ModelProperty> removeAffectedOppositeProperties = new HashSet<ModelProperty>();
                SymbolId valueId = value as SymbolId;
                GreenModel valueModel = null;
                bool valueReadOnly = true;
                GreenSymbol valueSymbol = null;
                if (valueId != null)
                {
                    valueSymbol = context.GetSymbol(valueId, out valueModel, out valueReadOnly);
                }
                this.CollectRemoveAffectedProperties(property, value, valueSymbol, removeAffectedProperties, removeAffectedOppositeProperties);
                foreach (var prop in removeAffectedProperties)
                {
                    if (prop.IsCollection)
                    {
                        result = result.RemoveValueCore(context, prop, reassign, prop == property ? index : -1, removeAll, value);
                    }
                    else
                    {
                        result = result.SetValueCore(context, prop, reassign, null, value);
                    }
                }
                if (valueSymbol != null && !valueReadOnly && removeAffectedOppositeProperties.Count > 0)
                {
                    foreach (var prop in removeAffectedOppositeProperties)
                    {
                        if (prop.IsCollection)
                        {
                            valueSymbol = valueSymbol.RemoveValueCore(context, prop, reassign, -1, removeAll, value);
                        }
                        else
                        {
                            valueSymbol = valueSymbol.SetValueCore(context, prop, reassign, null, value);
                        }
                    }
                    context.AddModifiedSymbol(valueSymbol);
                }
            }
            return result;
        }

        private GreenSymbol LazyEvalCore(GreenSymbolContext context, ModelProperty property, List<LazyEvalEntry> lazyEvalStack)
        {
            object lazyValue;
            GreenSymbol result = this;
            LazyEvalEntry entry = new LazyEvalEntry(id, property);
            int entryIndex = lazyEvalStack.IndexOf(entry);
            if (entryIndex >= 0)
            {
                List<LazyEvalEntry> stack = new List<LazyEvalEntry>();
                for (int i = entryIndex, n = lazyEvalStack.Count; i < n; i++)
                {
                    stack.Add(lazyEvalStack[i]);
                }
                throw new LazyEvalException("Circular dependency between lazy values.", stack);
            }
            try
            {
                lazyEvalStack.Add(entry);
                if (result.TryGetValueCore(property, false, true, out lazyValue))
                {
                    if (lazyValue is GreenLazyValue)
                    {
                        object value = result.LazyEvalValue((GreenLazyValue)lazyValue, lazyEvalStack);
                        if (!property.IsDerived)
                        {
                            result = result.SetValue(context, property, true, value);
                        }
                    }
                    else if (lazyValue is GreenList)
                    {
                        GreenList list = (GreenList)lazyValue;
                        List<object> values = new List<object>();
                        result = result.Update(
                            result.id,
                            result.parent,
                            result.children,
                            result.parentProperties,
                            result.properties.SetItem(property, list.ClearLazy()),
                            result.attachedProperties,
                            result.lazyIndex.Remove(property),
                            result.childInitializers);
                        foreach (var lazyItem in list.LazyItems)
                        {
                            if (lazyItem is GreenLazyValue)
                            {
                                object value = result.LazyEvalValue((GreenLazyValue)lazyItem, lazyEvalStack);
                                values.Add(value);
                            }
                            else if (lazyItem is GreenLazyList)
                            {
                                List<object> valueList = result.LazyEvalValue((GreenLazyList)lazyItem, lazyEvalStack);
                                values.AddRange(valueList);
                            }
                        }
                        foreach (var value in values)
                        {
                            result = result.AddItem(context, property, false, false, -1, value);
                        }
                    }
                }
                return result;
            }
            finally
            {
                lazyEvalStack.RemoveAt(lazyEvalStack.Count - 1);
            }
        }

        private object LazyEvalValue(GreenLazyValue lazyValue, List<LazyEvalEntry> lazyEvalStack)
        {
            try
            {
                return lazyValue.CreateGreenValue();
            }
            catch (Exception ex)
            {
                throw new LazyEvalException("An exception was thrown by the lazy evaluator.", lazyEvalStack.ToList(), ex);
            }
        }

        private List<object> LazyEvalValue(GreenLazyList lazyList, List<LazyEvalEntry> lazyEvalStack)
        {
            try
            {
                return lazyList.CreateGreenValues();
            }
            catch (Exception ex)
            {
                throw new LazyEvalException("An exception was thrown by the lazy evaluator.", lazyEvalStack.ToList(), ex);
            }
        }

        private ImmutableList<SymbolId> AddChildCore(GreenSymbolContext context, ModelProperty property, SymbolId valueId, ImmutableList<SymbolId> currentChildren)
        {
            Debug.Assert(property != null);
            Debug.Assert(valueId != null);
            if (currentChildren == null) currentChildren = this.children;
            GreenModel valueModel;
            bool valueReadOnly;
            GreenSymbol valueSymbol = context.GetSymbol(valueId, out valueModel, out valueReadOnly);
            if (valueSymbol != null && !valueReadOnly)
            {
                if (valueSymbol.parent != null)
                {
                    if (valueSymbol.parent == this.id)
                    {
                        return currentChildren;
                    }
                    else
                    {
                        throw new ModelException("Invalid containment in " + this.PropertyRef(property) + ": symbol '" + valueSymbol + "' is already contained by '" + valueSymbol.parent + "'.");
                    }
                }
                else if (!this.children.Contains(valueId))
                {
                    if (valueId == this.id)
                    {
                        throw new ModelException("Invalid containment in " + this.PropertyRef(property) + ": a symbol cannot contain itself.");
                    }
                    if (this.parent != null)
                    {
                        List<SymbolId> ids = new List<SymbolId>();
                        ids.Add(valueId);
                        SymbolId currentId = this.parent;
                        while (currentId != null)
                        {
                            if (ids.Contains(currentId))
                            {
                                throw new CircularContainmentException("Invalid containment in " + this.PropertyRef(property) + ": circular containment.", ids);
                            }
                            ids.Add(currentId);
                            GreenModel currentModel;
                            bool currentReadOnly;
                            GreenSymbol currentSymbol = context.GetSymbol(currentId, out currentModel, out currentReadOnly);
                            currentId = currentSymbol.parent;
                        }
                    }
                    GreenModel thisModel;
                    bool thisReadOnly;
                    GreenSymbol thisSymbol = context.GetSymbol(this.id, out thisModel, out thisReadOnly);
                    if (valueModel.Id != thisModel.Id)
                    {
                        throw new ModelException("Invalid containment in " + this.PropertyRef(property) + ": the containing symbol and the contained symbol must be in the same model.");
                    }
                    GreenSymbol newValueSymbol = valueSymbol.Update(
                        valueSymbol.id,
                        this.id,
                        valueSymbol.children,
                        valueSymbol.parentProperties.Add(property),
                        valueSymbol.properties,
                        valueSymbol.attachedProperties,
                        valueSymbol.lazyIndex,
                        valueSymbol.childInitializers);
                    context.AddModifiedSymbol(valueModel, valueSymbol, newValueSymbol);
                    return currentChildren.Add(valueId);
                }
            }
            return currentChildren;
        }

        private ImmutableList<SymbolId> RemoveChildCore(GreenSymbolContext context, ModelProperty property, SymbolId valueId, ImmutableList<SymbolId> currentChildren)
        {
            Debug.Assert(property != null);
            Debug.Assert(valueId != null);
            if (currentChildren == null) currentChildren = this.children;
            GreenModel valueModel;
            bool valueReadOnly;
            GreenSymbol valueSymbol = context.GetSymbol(valueId, out valueModel, out valueReadOnly);
            GreenSymbol newValueSymbol = valueSymbol;
            if (valueSymbol != null && !valueReadOnly)
            {
                newValueSymbol = valueSymbol.Update(
                    valueSymbol.id,
                    null,
                    valueSymbol.children,
                    valueSymbol.parentProperties.Remove(property),
                    valueSymbol.properties,
                    valueSymbol.attachedProperties,
                    valueSymbol.lazyIndex,
                    valueSymbol.childInitializers);
                context.AddModifiedSymbol(valueModel, valueSymbol, newValueSymbol);
                if (!valueSymbol.parentProperties.IsEmpty && newValueSymbol.parentProperties.IsEmpty)
                {
                    return currentChildren.Remove(valueId);
                }
            }
            return currentChildren;
        }

        private GreenSymbol InitChildCore(GreenSymbolContext context, ModelProperty childProperty, SymbolId valueId)
        {
            ImmutableDictionary<ModelProperty, object> initValues;
            if (this.childInitializers.TryGetValue(childProperty, out initValues) && initValues != null && !initValues.IsEmpty)
            {
                GreenModel valueModel;
                bool valueReadOnly;
                GreenSymbol valueSymbol = context.GetSymbol(valueId, out valueModel, out valueReadOnly);
                if (valueSymbol != null && !valueReadOnly)
                {
                    GreenSymbol oldValueSymbol = valueSymbol;
                    foreach (var initValue in initValues)
                    {
                        object oldValue;
                        if (!valueSymbol.properties.TryGetValue(initValue.Key, out oldValue) || oldValue == GreenSymbol.Unassigned)
                        {
                            if (initValue.Key.IsCollection)
                            {
                                if (initValue.Value is ImmutableList<object>)
                                {
                                    valueSymbol = valueSymbol.AddItems(context, initValue.Key, false, (ImmutableList<object>)initValue.Value);
                                }
                            }
                            else
                            {
                                valueSymbol = valueSymbol.SetValue(context, initValue.Key, false, initValue.Value);
                            }
                        }
                    }
                    context.AddModifiedSymbol(valueModel, oldValueSymbol, valueSymbol);
                    GreenModel thisModel;
                    bool thisReadOnly;
                    return context.GetSymbol(this.id, out thisModel, out thisReadOnly);
                }
            }
            return this;
        }

        private string PropertyRef(ModelProperty property)
        {
            return this.PropertyRef(this, property);
        }

        private string PropertyRef(GreenSymbol symbol, ModelProperty property)
        {
            return symbol.Id + "." + property.Name;
        }

        internal void EvaluateLazyValues(GreenSymbolContext context)
        {
            throw new NotImplementedException();
        }
    }

    internal class GreenModel
    {
        internal static readonly GreenModel Empty = new GreenModel();

        private ModelId id;
        private ImmutableDictionary<SymbolId, GreenSymbol> symbols;
        private ImmutableHashSet<SymbolId> lazySymbols;

        internal GreenModel()
        {
            this.id = new ModelId();
            this.symbols = ImmutableDictionary<SymbolId, GreenSymbol>.Empty;
            this.lazySymbols = ImmutableHashSet<SymbolId>.Empty;
        }

        internal GreenModel(
            ModelId id,
            ImmutableDictionary<SymbolId, GreenSymbol> symbols,
            ImmutableHashSet<SymbolId> lazySymbols)
        {
            this.id = id;
            this.symbols = symbols;
            this.lazySymbols = lazySymbols;
        }

        internal GreenModel Update(
            ModelId id,
            ImmutableDictionary<SymbolId, GreenSymbol> symbols,
            ImmutableHashSet<SymbolId> lazySymbols)
        {
            if (this.id != id || this.symbols != symbols || this.lazySymbols != lazySymbols)
            {
                return new GreenModel(id, symbols, lazySymbols);
            }
            return this;
        }

        internal ModelId Id
        {
            get { return this.id; }
        }

        internal IEnumerable<SymbolId> Symbols
        {
            get { return this.symbols.Keys; }
        }

        internal bool TryGetSymbol(SymbolId id, out GreenSymbol symbol)
        {
            return this.symbols.TryGetValue(id, out symbol);
        }

        internal GreenSymbol GetSymbol(SymbolId id)
        {
            GreenSymbol result;
            if (this.symbols.TryGetValue(id, out result))
            {
                return result;
            }
            return null;
        }

        internal bool ContainsSymbol(SymbolId id)
        {
            GreenSymbol result;
            return this.symbols.TryGetValue(id, out result) && result != null;
        }

        internal GreenModel AddSymbol(SymbolId id)
        {
            if (this.symbols.ContainsKey(id)) return this;
            return this.Update(this.id, this.symbols.Add(id, new GreenSymbol(id)), this.lazySymbols);
        }

        internal GreenModel AddSymbol(GreenSymbol symbol)
        {
            if (this.symbols.ContainsKey(symbol.Id)) return this;
            return this.Update(this.id, this.symbols.Add(symbol.Id, symbol), this.lazySymbols);
        }

        internal void EvaluateLazyValues(GreenSymbolContext context)
        {
            if (context == null) context = new GreenSymbolContext(null, this);
            foreach (var symbolId in this.lazySymbols)
            {
                GreenModel symbolModel;
                bool symbolReadOnly;
                GreenSymbol symbol = context.GetSymbol(symbolId, out symbolModel, out symbolReadOnly);
                GreenSymbol newSymbol = symbol;
                if (symbol != null && !symbolReadOnly)
                {
                    symbol.EvaluateLazyValues(context);
                }
            }
        }
    }

    internal class GreenModelGroup
    {
        internal static readonly GreenModelGroup Empty = new GreenModelGroup();

        private ImmutableDictionary<ModelId, GreenModel> models;
        private ImmutableDictionary<ModelId, GreenModel> references;

        internal GreenModelGroup()
        {
            this.models = ImmutableDictionary<ModelId, GreenModel>.Empty;
            this.references = ImmutableDictionary<ModelId, GreenModel>.Empty;
        }

        internal GreenModelGroup(ImmutableDictionary<ModelId, GreenModel> models, ImmutableDictionary<ModelId, GreenModel> references)
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

        internal IEnumerable<GreenModel> Models
        {
            get { return this.models.Values; }
        }

        internal IEnumerable<GreenModel> References
        {
            get { return this.references.Values; }
        }

        internal bool TryGetSymbol(SymbolId id, out GreenSymbol symbol, out GreenModel model, out bool readOnly)
        {
            foreach (var m in this.models)
            {
                if (m.Value.TryGetSymbol(id, out symbol))
                {
                    readOnly = false;
                    model = m.Value;
                    return true;
                }
            }
            foreach (var r in this.references)
            {
                if (r.Value.TryGetSymbol(id, out symbol))
                {
                    readOnly = true;
                    model = r.Value;
                    return true;
                }
            }
            symbol = null;
            readOnly = true;
            model = null;
            return false;
        }

        internal GreenSymbol GetSymbol(SymbolId id, out GreenModel model, out bool readOnly)
        {
            GreenSymbol result;
            if (this.TryGetSymbol(id, out result, out model, out readOnly))
            {
                return result;
            }
            return null;
        }

        internal bool ContainsSymbol(SymbolId id)
        {
            foreach (var m in this.models)
            {
                if (m.Value.ContainsSymbol(id)) return true; 
            }
            foreach (var r in this.references)
            {
                if (r.Value.ContainsSymbol(id)) return true;
            }
            return false;
        }
    }
}
