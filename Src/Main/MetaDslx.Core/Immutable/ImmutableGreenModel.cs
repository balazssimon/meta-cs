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

    internal class GreenSymbolReference
    {
        internal static readonly GreenSymbolReference None = new GreenSymbolReference(null, null, true);

        private GreenSymbol symbol;
        private GreenModel model;
        private bool readOnly;

        internal GreenSymbolReference(GreenSymbol symbol, GreenModel model, bool readOnly)
        {
            this.symbol = symbol;
            this.model = model;
            this.readOnly = readOnly;
        }

        internal GreenSymbol Symbol { get { return this.symbol; } }
        internal GreenModel Model { get { return this.model; } }
        internal bool IsReadOnly { get { return this.readOnly; } }
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

        internal ImmutableList<SymbolId> Children
        {
            get { return this.children; }
        }

        internal IEnumerable<ModelProperty> Properties
        {
            get { return this.properties.Keys; }
        }

        internal ImmutableList<ModelProperty> AttachedProperties
        {
            get { return this.attachedProperties; }
        }

        internal bool HasLazyValues
        {
            get { return this.lazyIndex.Count > 0; }
        }

        internal GreenSymbol AddProperty(GreenModelTransaction transaction, ModelProperty property)
        {
            if (!this.properties.ContainsKey(property))
            {
                bool declared = ModelProperty.GetDeclaredPropertiesForType(id.MutableType).Contains(property);
                // TODO: related properties
                GreenSymbol result = this.Update(
                    this.id, 
                    this.parent, 
                    this.children,
                    this.parentProperties,
                    this.properties.Add(property, GreenSymbol.Unassigned),
                    declared ? this.attachedProperties : this.attachedProperties.Add(property),
                    this.lazyIndex,
                    this.childInitializers);
                transaction.UpdateSymbol(result);
                return result;
            }
            return this;
        }

        internal GreenSymbol RemoveProperty(GreenModelTransaction transaction, ModelProperty property)
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
                    result = result.UnsetValue(transaction, property, true);
                    result = result.Update(
                        result.id,
                        result.parent,
                        result.children,
                        result.parentProperties,
                        result.properties.Remove(property),
                        result.attachedProperties.Remove(property),
                        result.lazyIndex,
                        result.childInitializers);
                    transaction.UpdateSymbol(result);
                    return result;
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

        internal GreenSymbol EvaluateLazyValues(GreenModelTransaction transaction)
        {
            GreenSymbol result = this;
            foreach (var prop in this.lazyIndex)
            {
                result = result.LazyEvalCore(transaction, prop, new List<LazyEvalEntry>());
            }
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol GetValue(GreenModelTransaction transaction, ModelProperty property, bool lazyEval, out object value)
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
                            result = result.LazyEvalCore(transaction, prop, new List<LazyEvalEntry>());
                        }
                    }
                }
                if (result.lazyIndex.Contains(property))
                {
                    result = result.LazyEvalCore(transaction, property, new List<LazyEvalEntry>());
                }
            }
            value = result.GetValue(property);
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol SetValue(GreenModelTransaction transaction, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(!property.IsCollection);
            Debug.Assert(!(value is GreenLazyList));
            if (!this.properties.ContainsKey(property)) return this;
            object oldValue;
            GreenSymbol result = this;
            if (this.ValueChangedCore(property, value, out oldValue))
            {
                if (!property.HasAffectedProperties || value is GreenLazyValue || value is GreenDerivedValue)
                {
                    result = result.SetValueCore(transaction, property, reassign, value, oldValue);
                }
                else
                {
                    result = result.SlowAddValueCore(transaction, property, reassign, -1, value, oldValue);
                }
            }
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol UnsetValue(GreenModelTransaction transaction, ModelProperty property, bool reassign)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            if (!this.properties.ContainsKey(property)) return this;
            if (property.IsCollection)
            {
                return this.ClearLazyItems(transaction, property, reassign).ClearItems(transaction, property, reassign);
            }
            else
            {
                return this.SetValue(transaction, property, reassign, Unassigned);
            }
        }

        internal GreenSymbol AddItem(GreenModelTransaction transaction, ModelProperty property, bool reassign, bool replace, int index, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (!property.HasAddAffectedProperties || value is GreenLazyValue || value is GreenLazyList)
            {
                if (replace) result = result.RemoveValueCore(transaction, property, reassign, index, false, null);
                result = result.AddValueCore(transaction, property, reassign, index, value);
            }
            else
            {
                if (replace) result = result.SlowRemoveValueCore(transaction, property, reassign, index, false, null);
                result = result.SlowAddValueCore(transaction, property, reassign, index, value, Unassigned);
            }
            if (result != this)
            {
                 transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol AddItems(GreenModelTransaction transaction, ModelProperty property, bool reassign, IEnumerable<object> values)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (!property.HasAddAffectedProperties)
            {
                foreach (var value in values)
                {
                    result = result.AddValueCore(transaction, property, reassign, -1, value);
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (value is GreenLazyValue || value is GreenLazyList)
                    {
                        result = result.AddValueCore(transaction, property, reassign, -1, value);
                    }
                    else
                    {
                        result = result.SlowAddValueCore(transaction, property, reassign, -1, value, Unassigned);
                    }
                }
            }
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol RemoveItem(GreenModelTransaction transaction, ModelProperty property, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (!property.HasRemoveAffectedProperties)
            {
                result = result.RemoveValueCore(transaction, property, reassign, index, removeAll, value);
            }
            else
            {
                result = result.SlowRemoveValueCore(transaction, property, reassign, index, removeAll, value);
            }
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol ClearItems(GreenModelTransaction transaction, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            object listValue;
            GreenSymbol result = this;
            if (this.TryGetValueCore(property, false, false, out listValue) && (listValue is GreenList))
            {
                GreenList list = (GreenList)listValue;
                foreach (var value in list)
                {
                    result = result.RemoveItem(transaction, property, reassign, -1, true, value);
                }
            }
            return result;
        }

        internal GreenSymbol ClearLazyItems(GreenModelTransaction transaction, ModelProperty property, bool reassign)
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
                if (result != this)
                {
                    transaction.UpdateSymbol(result);
                }
            }
            return result;
        }

        internal GreenSymbol ChildSetValue(GreenModelTransaction transaction, ModelProperty child, ModelProperty property, bool reassign, object value)
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
            GreenSymbol result = this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.SetItem(child, initValues.SetItem(property, value)));
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol ChildAddItem(GreenModelTransaction transaction, ModelProperty child, ModelProperty property, object value)
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
            GreenSymbol result = this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.SetItem(child, initValues.SetItem(property, initList)));
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol ChildAddItems(GreenModelTransaction transaction, ModelProperty child, ModelProperty property, IEnumerable<object> values)
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
            GreenSymbol result = this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.SetItem(child, initValues.SetItem(property, initList)));
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol ChildClear(GreenModelTransaction transaction, ModelProperty child)
        {
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + this.PropertyRef(child) + " must be a containment.");
            }
            GreenSymbol result = this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.Remove(child));
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
        }

        internal GreenSymbol ChildClear(GreenModelTransaction transaction, ModelProperty child, ModelProperty property)
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
            GreenSymbol result = this.Update(
                this.id,
                this.parent,
                this.children,
                this.parentProperties,
                this.properties,
                this.attachedProperties,
                this.lazyIndex,
                this.childInitializers.SetItem(child, initValues.Remove(property)));
            if (result != this)
            {
                transaction.UpdateSymbol(result);
            }
            return result;
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

        private void CheckNewValue(GreenModelTransaction transaction, ModelProperty property, object value)
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
                if (!transaction.SymbolExists((SymbolId)value))
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

        private void CheckNewItem(GreenModelTransaction transaction, ModelProperty property, object value)
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
                if (!transaction.SymbolExists((SymbolId)value))
                {
                    throw new ModelException("Symbol '" + value + "' with id '" + ((SymbolId)value).Id + "' cannot be added to property " + this.PropertyRef(property) + " of type '" + property.MutableTypeInfo.Type + "', since the value cannot be resolved within the model group. Make sure to reference the required models from the model group.");
                }
            }
        }

        private GreenSymbol SetValueCore(GreenModelTransaction transaction, ModelProperty property, bool reassign, object value, object oldValue)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(!(value is GreenLazyList));
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is ISymbol));
            Debug.Assert(!(oldValue is GreenLazyList));
            Debug.Assert(!(oldValue is ISymbol));
            if (value == oldValue) return this;
            this.CheckOldValue(property, reassign, oldValue);
            this.CheckNewValue(transaction, property, value);
            ImmutableList<SymbolId> newChildren = this.children;
            ImmutableHashSet<ModelProperty> newLazyIndex = this.lazyIndex;
            if (oldValue != null && oldValue != GreenSymbol.Unassigned)
            {
                if (oldValue is SymbolId)
                {
                    if (property.IsContainment)
                    {
                        newChildren = this.RemoveChildCore(transaction, property, (SymbolId)oldValue, newChildren);
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
                        newChildren = this.AddChildCore(transaction, property, (SymbolId)value, newChildren);
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
                result = result.InitChildCore(transaction, property, (SymbolId)value);
            }
            return result;
        }

        private GreenSymbol AddValueCore(GreenModelTransaction transaction, ModelProperty property, bool reassign, int index, object value)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(value != Unassigned);
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is ISymbol));
            this.CheckOldItem(property, reassign);
            this.CheckNewItem(transaction, property, value);
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
                    newChildren = this.AddChildCore(transaction, property, (SymbolId)value, newChildren);
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
                result = result.InitChildCore(transaction, property, (SymbolId)value);
            }
            return result;
        }

        private GreenSymbol RemoveValueCore(GreenModelTransaction transaction, ModelProperty property, bool reassign, int index, bool removeAll, object value)
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
                newChildren = this.RemoveChildCore(transaction, property, (SymbolId)value, newChildren);
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
                            if (this.properties.ContainsKey(prop) && properties.Add(prop))
                            {
                                newProperties.Add(prop);
                            }
                        }
                        Type mutableType = value is SymbolId ? ((SymbolId)value).MutableType : null;
                        Type valueType = value != null ? value.GetType() : null;
                        foreach (var prop in property.AddAffectedOptionalProperties)
                        {
                            if (value == null || value is GreenLazyValue || value is GreenLazyList ||
                                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(mutableType))) ||
                                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(valueType))))
                            {
                                if (this.properties.ContainsKey(prop) && properties.Add(prop))
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
                        if (this.properties.ContainsKey(prop))
                        {
                            properties.Add(prop);
                        }
                    }
                    Type mutableType = value is SymbolId ? ((SymbolId)value).MutableType : null;
                    Type valueType = value != null ? value.GetType() : null;
                    foreach (var prop in property.AddAffectedOptionalProperties)
                    {
                        if (value == null || value is GreenLazyValue || value is GreenLazyList ||
                            ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(mutableType))) ||
                            (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(valueType))))
                        {
                            if (this.properties.ContainsKey(prop))
                            {
                                properties.Add(prop);
                            }
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
                            if (this.properties.ContainsKey(prop) && properties.Add(prop))
                            {
                                newProperties.Add(prop);
                            }
                        }
                        Type mutableType = value is SymbolId ? ((SymbolId)value).MutableType : null;
                        Type valueType = value != null ? value.GetType() : null;
                        foreach (var prop in property.RemoveAffectedOptionalProperties)
                        {
                            if (value == null || value is GreenLazyValue || value is GreenLazyList ||
                                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(mutableType))) ||
                                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(valueType))))
                            {
                                if (this.properties.ContainsKey(prop) && properties.Add(prop))
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
                        if (this.properties.ContainsKey(prop))
                        {
                            properties.Add(prop);
                        }
                    }
                    Type mutableType = value is SymbolId ? ((SymbolId)value).MutableType : null;
                    Type valueType = value != null ? value.GetType() : null;
                    foreach (var prop in property.RemoveAffectedOptionalProperties)
                    {
                        if (value == null || value is GreenLazyValue || value is GreenLazyList ||
                            ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(mutableType))) ||
                            (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(valueType))))
                        {
                            if (this.properties.ContainsKey(prop))
                            {
                                properties.Add(prop);
                            }
                        }
                    }
                }
            }
        }


        private GreenSymbol SlowAddValueCore(GreenModelTransaction transaction, ModelProperty property, bool reassign, int index, object value, object oldValue)
        {
            Debug.Assert(!(value is GreenList));
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (oldValue != GreenSymbol.Unassigned)
            {
                HashSet<ModelProperty> removeAffectedProperties = new HashSet<ModelProperty>();
                HashSet<ModelProperty> removeAffectedOppositeProperties = new HashSet<ModelProperty>();
                SymbolId oldValueId = oldValue as SymbolId;
                GreenSymbolReference oldValueSymbolRef = null;
                GreenSymbol oldValueSymbol = null;
                if (oldValueId != null)
                {
                    oldValueSymbolRef = transaction.GetSymbolReference(oldValueId);
                    if (oldValueSymbolRef != null)
                    {
                        oldValueSymbol = oldValueSymbolRef.Symbol;
                    }
                }
                this.CollectRemoveAffectedProperties(property, oldValue, oldValueSymbol, removeAffectedProperties, removeAffectedOppositeProperties);
                foreach (var prop in removeAffectedProperties)
                {
                    if (prop.IsCollection)
                    {
                        result = result.RemoveValueCore(transaction, prop, reassign, prop == property ? index : -1, false, oldValue);
                    }
                    else
                    {
                        result = result.SetValueCore(transaction, prop, reassign, null, oldValue);
                    }
                }
                transaction.UpdateSymbol(result);
                if (oldValueSymbolRef != null && !oldValueSymbolRef.IsReadOnly && removeAffectedOppositeProperties.Count > 0)
                {
                    oldValueSymbol = transaction.GetSymbol(oldValueSymbolRef.Model.Id, oldValueSymbol.id);
                    foreach (var prop in removeAffectedOppositeProperties)
                    {
                        if (prop.IsCollection)
                        {
                            oldValueSymbol = oldValueSymbol.RemoveValueCore(transaction, prop, reassign, -1, false, this.id);
                        }
                        else
                        {
                            oldValueSymbol = oldValueSymbol.SetValueCore(transaction, prop, reassign, null, this.id);
                        }
                    }
                    transaction.UpdateSymbol(oldValueSymbol);
                    result = transaction.GetSymbolReference(this.id).Symbol;
                }
            }
            if (value != GreenSymbol.Unassigned)
            {
                HashSet<ModelProperty> addAffectedProperties = new HashSet<ModelProperty>();
                HashSet<ModelProperty> addAffectedOppositeProperties = new HashSet<ModelProperty>();
                SymbolId valueId = value as SymbolId;
                GreenSymbolReference valueSymbolRef = null;
                GreenSymbol valueSymbol = null;
                if (valueId != null)
                {
                    valueSymbolRef = transaction.GetSymbolReference(valueId);
                    if (valueSymbolRef != null)
                    {
                        valueSymbol = valueSymbolRef.Symbol;
                    }
                }
                this.CollectAddAffectedProperties(property, value, valueSymbol, addAffectedProperties, addAffectedOppositeProperties);
                foreach (var prop in addAffectedProperties)
                {
                    if (prop.IsCollection)
                    {
                        result = result.AddValueCore(transaction, prop, reassign, prop == property ? index : -1, value);
                    }
                    else
                    {
                        result = result.SetValueCore(transaction, prop, reassign, value, null);
                    }
                }
                transaction.UpdateSymbol(result);
                if (valueSymbolRef != null && !valueSymbolRef.IsReadOnly && addAffectedOppositeProperties.Count > 0)
                {
                    valueSymbol = transaction.GetSymbol(valueSymbolRef.Model.Id, valueSymbol.id);
                    foreach (var prop in addAffectedOppositeProperties)
                    {
                        if (prop.IsCollection)
                        {
                            valueSymbol = valueSymbol.AddValueCore(transaction, prop, reassign, -1, this.id);
                        }
                        else
                        {
                            object oldOppositeValue;
                            valueSymbol.properties.TryGetValue(property, out oldOppositeValue);
                            valueSymbol = valueSymbol.SetValueCore(transaction, prop, reassign, this.id, oldOppositeValue);
                        }
                    }
                    transaction.UpdateSymbol(valueSymbol);
                    result = transaction.GetSymbolReference(this.id).Symbol;
                }
            }
            return result;
        }

        private GreenSymbol SlowRemoveValueCore(GreenModelTransaction transaction, ModelProperty property, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(!(value is GreenList));
            if (!this.properties.ContainsKey(property)) return this;
            GreenSymbol result = this;
            if (value != GreenSymbol.Unassigned)
            {
                HashSet<ModelProperty> removeAffectedProperties = new HashSet<ModelProperty>();
                HashSet<ModelProperty> removeAffectedOppositeProperties = new HashSet<ModelProperty>();
                SymbolId valueId = value as SymbolId;
                GreenSymbolReference valueSymbolRef = null;
                GreenSymbol valueSymbol = null;
                if (valueId != null)
                {
                    valueSymbolRef = transaction.GetSymbolReference(valueId);
                    if (valueSymbolRef != null)
                    {
                        valueSymbol = valueSymbolRef.Symbol;
                    }
                }
                this.CollectRemoveAffectedProperties(property, value, valueSymbol, removeAffectedProperties, removeAffectedOppositeProperties);
                foreach (var prop in removeAffectedProperties)
                {
                    if (prop.IsCollection)
                    {
                        result = result.RemoveValueCore(transaction, prop, reassign, prop == property ? index : -1, removeAll, value);
                    }
                    else
                    {
                        result = result.SetValueCore(transaction, prop, reassign, null, value);
                    }
                }
                transaction.UpdateSymbol(result);
                if (valueSymbolRef != null && !valueSymbolRef.IsReadOnly && removeAffectedOppositeProperties.Count > 0)
                {
                    valueSymbol = transaction.GetSymbol(valueSymbolRef.Model.Id, valueSymbol.id);
                    foreach (var prop in removeAffectedOppositeProperties)
                    {
                        if (prop.IsCollection)
                        {
                            valueSymbol = valueSymbol.RemoveValueCore(transaction, prop, reassign, -1, removeAll, this.id);
                        }
                        else
                        {
                            valueSymbol = valueSymbol.SetValueCore(transaction, prop, reassign, null, this.id);
                        }
                    }
                    transaction.UpdateSymbol(valueSymbol);
                    result = transaction.GetSymbolReference(this.id).Symbol;
                }
            }
            return result;
        }

        private GreenSymbol LazyEvalCore(GreenModelTransaction transaction, ModelProperty property, List<LazyEvalEntry> lazyEvalStack)
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
                            result = result.SetValue(transaction, property, true, value);
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
                            result = result.AddItem(transaction, property, false, false, -1, value);
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

        private ImmutableList<SymbolId> AddChildCore(GreenModelTransaction transaction, ModelProperty property, SymbolId valueId, ImmutableList<SymbolId> currentChildren)
        {
            Debug.Assert(property != null);
            Debug.Assert(valueId != null);
            if (currentChildren == null) currentChildren = this.children;
            GreenSymbolReference valueSymbolRef = transaction.GetSymbolReference(valueId);
            if (valueSymbolRef != null && !valueSymbolRef.IsReadOnly)
            {
                GreenSymbol valueSymbol = valueSymbolRef.Symbol;
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
                            GreenSymbolReference currentSymbolRef = transaction.GetSymbolReference(currentId);
                            currentId = currentSymbolRef.Symbol.parent;
                        }
                    }
                    GreenSymbolReference thisSymbolRef = transaction.GetSymbolReference(this.id);
                    if (valueSymbolRef.Model.Id != thisSymbolRef.Model.Id)
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
                    transaction.UpdateSymbol(newValueSymbol);
                    return currentChildren.Add(valueId);
                }
            }
            return currentChildren;
        }

        private ImmutableList<SymbolId> RemoveChildCore(GreenModelTransaction transaction, ModelProperty property, SymbolId valueId, ImmutableList<SymbolId> currentChildren)
        {
            Debug.Assert(property != null);
            Debug.Assert(valueId != null);
            if (currentChildren == null) currentChildren = this.children;
            GreenSymbolReference valueSymbolRef = transaction.GetSymbolReference(valueId);
            if (valueSymbolRef != null && !valueSymbolRef.IsReadOnly)
            {
                GreenSymbol valueSymbol = valueSymbolRef.Symbol;
                GreenSymbol newValueSymbol = valueSymbol.Update(
                    valueSymbol.id,
                    null,
                    valueSymbol.children,
                    valueSymbol.parentProperties.Remove(property),
                    valueSymbol.properties,
                    valueSymbol.attachedProperties,
                    valueSymbol.lazyIndex,
                    valueSymbol.childInitializers);
                transaction.UpdateSymbol(newValueSymbol);
                if (!valueSymbol.parentProperties.IsEmpty && newValueSymbol.parentProperties.IsEmpty)
                {
                    return currentChildren.Remove(valueId);
                }
            }
            return currentChildren;
        }

        private GreenSymbol InitChildCore(GreenModelTransaction transaction, ModelProperty childProperty, SymbolId valueId)
        {
            ImmutableDictionary<ModelProperty, object> initValues;
            if (this.childInitializers.TryGetValue(childProperty, out initValues) && initValues != null && !initValues.IsEmpty)
            {
                GreenSymbolReference valueSymbolRef = transaction.GetSymbolReference(valueId);
                if (valueSymbolRef != null && !valueSymbolRef.IsReadOnly)
                {
                    GreenSymbol valueSymbol = valueSymbolRef.Symbol;
                    foreach (var initValue in initValues)
                    {
                        object oldValue;
                        if (!valueSymbol.properties.TryGetValue(initValue.Key, out oldValue) || oldValue == GreenSymbol.Unassigned)
                        {
                            if (initValue.Key.IsCollection)
                            {
                                if (initValue.Value is ImmutableList<object>)
                                {
                                    valueSymbol = valueSymbol.AddItems(transaction, initValue.Key, false, (ImmutableList<object>)initValue.Value);
                                }
                            }
                            else
                            {
                                valueSymbol = valueSymbol.SetValue(transaction, initValue.Key, false, initValue.Value);
                            }
                        }
                    }
                    return transaction.GetSymbolReference(this.id).Symbol;
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
    }

    internal class GreenModelTransaction
    {
        private GreenModelGroup group;
        private GreenModel model;

        internal GreenModelTransaction(GreenModelGroup group, GreenModel model)
        {
            this.group = group;
            this.model = model;
        }

        internal GreenModelTransaction(GreenModelTransaction other)
        {
            this.group = other.group;
            this.model = other.model;
        }

        internal void Update(GreenModelGroup group, GreenModel model)
        {
            Interlocked.Exchange(ref this.group, group);
            Interlocked.Exchange(ref this.model, model);
        }

        internal GreenModelGroup Group { get { return this.group; } }
        internal GreenModel Model { get { return this.model; } }

        internal void UpdateSymbol(GreenSymbol symbol)
        {
            GreenModelGroup newGroup = this.group;
            GreenModel newModel = this.model;
            if (newGroup != null) newGroup = newGroup.UpdateSymbol(symbol);
            if (newModel != null) newModel = newModel.UpdateSymbol(symbol);
            this.Update(newGroup, newModel);
        }

        internal void UpdateSymbols(IEnumerable<GreenSymbol> symbols)
        {
            GreenModelGroup newGroup = this.group;
            GreenModel newModel = this.model;
            if (newGroup != null) newGroup = newGroup.UpdateSymbols(symbols);
            if (newModel != null) newModel = newModel.UpdateSymbols(symbols);
            this.Update(newGroup, newModel);
        }

        internal GreenSymbolReference GetSymbolReference(SymbolId symbolId)
        {
            return this.GetSymbolReference(null, symbolId);
        }

        internal GreenSymbolReference GetSymbolReference(ModelId modelId, SymbolId symbolId)
        {
            if (this.group != null)
            {
                return this.group.GetSymbolReference(modelId, symbolId);
            }
            else if (this.model != null && (modelId == null || this.model.Id == modelId))
            {
                GreenSymbol symbol = this.model.GetSymbol(symbolId);
                if (symbol != null)
                {
                    return new GreenSymbolReference(symbol, this.model, false);
                }
            }
            return null;
        }

        internal GreenSymbol GetSymbol(ModelId modelId, SymbolId symbolId)
        {
            if (this.group != null)
            {
                return this.group.GetSymbol(modelId, symbolId);
            }
            else if (this.model != null && (modelId == null || this.model.Id == modelId))
            {
                return this.model.GetSymbol(symbolId);
            }
            return null;
        }

        internal bool SymbolExists(SymbolId id)
        {
            if (this.group != null)
            {
                return this.group.ContainsSymbol(id);
            }
            else if (this.model != null)
            {
                return this.model.ContainsSymbol(id);
            }
            return false;
        }

        internal GreenModel GetModel(ModelId id)
        {
            if (this.group != null)
            {
                return this.group.GetModel(id);
            }
            else if (this.model != null)
            {
                if (this.model.Id == id) return this.model;
            }
            return null;
        }

        internal void AddModel(GreenModel greenModel)
        {
            if (this.group != null)
            {
                this.Update(this.group.AddModel(greenModel), this.model);
            }
        }

        internal void AddReference(GreenModel greenModel)
        {
            if (this.group != null)
            {
                this.Update(this.group.AddReference(greenModel), this.model);
            }
        }

        internal void UpdateModel(GreenModel greenModel)
        {
            if (this.group != null)
            {
                this.Update(this.group.UpdateModel(greenModel), this.model);
            }
            else if (this.model != null)
            {
                this.Update(this.group, greenModel);
            }
        }

        internal void AddSymbol(ModelId modelId, SymbolId symbolId)
        {
            if (this.group != null)
            {
                GreenModel gm = this.group.GetModel(modelId);
                if (gm != null)
                {
                    this.Update(this.group.UpdateModel(gm.AddSymbol(symbolId)), this.model);
                }
            }
            else if (this.model != null)
            {
                Debug.Assert(this.model.Id == modelId);
                this.Update(this.group, this.model.AddSymbol(symbolId));
            }
        }

        internal void EvaluateLazyValues()
        {
            if (this.group != null)
            {
                foreach (var m in this.group.Models)
                {
                    foreach (var symbolId in m.Symbols)
                    {
                        GreenSymbol symbol = m.GetSymbol(symbolId);
                        symbol.EvaluateLazyValues(this);
                    }
                }
            }
            else if (this.model != null)
            {
                foreach (var symbolId in this.model.Symbols)
                {
                    GreenSymbol symbol = this.model.GetSymbol(symbolId);
                    symbol.EvaluateLazyValues(this);
                }
            }
        }

        internal object GetValue(ModelId modelId, SymbolId symbolId, ModelProperty property, bool lazyEval)
        {
            GreenSymbol symbol = this.GetSymbol(modelId, symbolId);
            object result = null;
            if (symbol != null)
            {
                symbol.GetValue(this, property, lazyEval, out result);
            }
            return result;
        }

        internal GreenLazyValue GetLazyValue(ModelId modelId, SymbolId symbolId, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(modelId, symbolId);
            if (symbol != null)
            {
                return symbol.GetLazyValue(property);
            }
            return null;
        }

        internal bool SetValue(ModelId modelId, SymbolId symbolId, ModelProperty property, bool reassign, object greenValue)
        {
            GreenSymbol symbol = this.GetSymbol(modelId, symbolId);
            if (symbol != null)
            {
                symbol.SetValue(this, property, reassign, greenValue);
                return true;
            }
            return false;
        }

        internal bool AddItem(ModelId modelId, SymbolId symbolId, ModelProperty property, bool reassign, int index, bool replace, object greenValue)
        {
            GreenSymbol symbol = this.GetSymbol(modelId, symbolId);
            if (symbol != null)
            {
                symbol.AddItem(this, property, reassign, replace, index, greenValue);
                return true;
            }
            return false;
        }

        internal bool RemoveItem(ModelId modelId, SymbolId symbolId, ModelProperty property, bool reassign, int index, bool removeAll, object greenValue)
        {
            GreenSymbol symbol = this.GetSymbol(modelId, symbolId);
            if (symbol != null)
            {
                symbol.RemoveItem(this, property, reassign, index, removeAll, greenValue);
                return true;
            }
            return false;
        }

        internal bool ClearItems(ModelId modelId, SymbolId symbolId, ModelProperty property, bool reassign)
        {
            GreenSymbol symbol = this.GetSymbol(modelId, symbolId);
            if (symbol != null)
            {
                symbol.ClearItems(this, property, reassign);
                return true;
            }
            return false;
        }

        internal bool ClearLazyItems(ModelId modelId, SymbolId symbolId, ModelProperty property, bool reassign)
        {
            GreenSymbol symbol = this.GetSymbol(modelId, symbolId);
            if (symbol != null)
            {
                symbol.ClearLazyItems(this, property, reassign);
                return true;
            }
            return false;
        }
    }

    internal class GreenModel
    {
        internal static readonly GreenModel Empty = new GreenModel();

        private ModelId id;
        private ImmutableDictionary<SymbolId, GreenSymbol> symbols;

        internal GreenModel()
        {
            this.id = new ModelId();
            this.symbols = ImmutableDictionary<SymbolId, GreenSymbol>.Empty;
        }

        internal GreenModel(
            ModelId id,
            ImmutableDictionary<SymbolId, GreenSymbol> symbols)
        {
            this.id = id;
            this.symbols = symbols;
        }

        private GreenModel Update(
            ModelId id,
            ImmutableDictionary<SymbolId, GreenSymbol> symbols)
        {
            if (this.id != id || this.symbols != symbols)
            {
                return new GreenModel(id, symbols);
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
            return this.Update(this.id, this.symbols.Add(id, new GreenSymbol(id)));
        }

        internal GreenModel AddSymbol(GreenSymbol symbol)
        {
            if (this.symbols.ContainsKey(symbol.Id)) return this;
            return this.Update(this.id, this.symbols.Add(symbol.Id, symbol));
        }

        internal GreenModel UpdateSymbol(GreenSymbol symbol)
        {
            if (symbol == null) return this;
            GreenSymbol oldSymbol;
            if (this.symbols.TryGetValue(symbol.Id, out oldSymbol))
            {
                if (symbol != oldSymbol)
                {
                    return this.Update(this.id, this.symbols.SetItem(symbol.Id, symbol));
                }
            }
            return this;
        }

        internal GreenModel UpdateSymbols(IEnumerable<GreenSymbol> symbols)
        {
            if (symbols == null) return this;
            GreenModel result = this;
            foreach (var symbol in symbols)
            {
                result = result.UpdateSymbol(symbol);
            }
            return result;
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

        private GreenModelGroup Update(ImmutableDictionary<ModelId, GreenModel> models, ImmutableDictionary<ModelId, GreenModel> references)
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

        internal bool TryGetSymbol(ModelId modelId, SymbolId symbolId, out GreenSymbol symbol)
        {
            if (modelId == null)
            {
                foreach (var m in this.models)
                {
                    if (m.Value.TryGetSymbol(symbolId, out symbol))
                    {
                        return true;
                    }
                }
                foreach (var r in this.references)
                {
                    if (r.Value.TryGetSymbol(symbolId, out symbol))
                    {
                        return true;
                    }
                }
            }
            else
            {
                GreenModel model;
                if (this.models.TryGetValue(modelId, out model))
                {
                    symbol = model.GetSymbol(symbolId);
                    return true;
                }
                if (this.references.TryGetValue(modelId, out model))
                {
                    symbol = model.GetSymbol(symbolId);
                    return true;
                }
            }
            symbol = null;
            return false;
        }

        internal GreenSymbol GetSymbol(ModelId modelId, SymbolId symbolId)
        {
            GreenSymbol result;
            if (this.TryGetSymbol(modelId, symbolId, out result))
            {
                return result;
            }
            return null;
        }

        internal bool TryGetSymbolReference(ModelId modelId, SymbolId symbolId, out GreenSymbolReference symbolRef)
        {
            if (modelId == null)
            {
                foreach (var m in this.models)
                {
                    GreenSymbol symbol;
                    if (m.Value.TryGetSymbol(symbolId, out symbol))
                    {
                        symbolRef = new GreenSymbolReference(symbol, m.Value, false);
                        return true;
                    }
                }
                foreach (var r in this.references)
                {
                    GreenSymbol symbol;
                    if (r.Value.TryGetSymbol(symbolId, out symbol))
                    {
                        symbolRef = new GreenSymbolReference(symbol, r.Value, true);
                        return true;
                    }
                }
            }
            else
            {
                GreenModel model;
                if (this.models.TryGetValue(modelId, out model))
                {
                    GreenSymbol symbol = model.GetSymbol(symbolId);
                    symbolRef = new GreenSymbolReference(symbol, model, false);
                    return true;
                }
                if (this.references.TryGetValue(modelId, out model))
                {
                    GreenSymbol symbol = model.GetSymbol(symbolId);
                    symbolRef = new GreenSymbolReference(symbol, model, true);
                    return true;
                }
            }
            symbolRef = null;
            return false;
        }

        internal GreenSymbolReference GetSymbolReference(ModelId modelId, SymbolId symbolId)
        {
            GreenSymbolReference result;
            if (this.TryGetSymbolReference(modelId, symbolId, out result))
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

        internal GreenModelGroup UpdateSymbol(GreenSymbol symbol)
        {
            if (symbol == null) return this;
            GreenSymbolReference oldSymbolRef = this.GetSymbolReference(null, symbol.Id);
            if (oldSymbolRef == null || oldSymbolRef.IsReadOnly) return this;
            if (oldSymbolRef.Symbol != symbol)
            {
                return this.Update(this.models.SetItem(oldSymbolRef.Model.Id, oldSymbolRef.Model.UpdateSymbol(symbol)), this.references);
            }
            return this;
        }

        internal GreenModelGroup UpdateSymbols(IEnumerable<GreenSymbol> symbols)
        {
            if (symbols == null) return this;
            GreenModelGroup result = this;
            foreach (var symbol in symbols)
            {
                result = result.UpdateSymbol(symbol);
            }
            return result;
        }

        internal GreenModel GetModel(ModelId id)
        {
            GreenModel result;
            if (this.models.TryGetValue(id, out result))
            {
                return result;
            }
            return null;
        }

        internal GreenModel GetReference(ModelId id)
        {
            GreenModel result;
            if (this.references.TryGetValue(id, out result))
            {
                return result;
            }
            return null;
        }

        internal GreenModelGroup AddModel(GreenModel model)
        {
            return this.Update(this.models.Add(model.Id, model), this.references);
        }

        internal GreenModelGroup AddReference(GreenModel model)
        {
            return this.Update(this.models, this.references.Add(model.Id, model));
        }

        internal GreenModelGroup UpdateModel(GreenModel model)
        {
            if (model == null) return this;
            GreenModel oldModel;
            if (this.models.TryGetValue(model.Id, out oldModel))
            {
                return this.Update(this.models.SetItem(model.Id, model), this.references);
            }
            return this;
        }
    }
}
