using MetaDslx.Core.Collections.Transactional;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public sealed class GreenLazyValue
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

        internal object CreateValue()
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

    public sealed class GreenLazyList
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

        internal List<object> CreateValues()
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

    public sealed class GreenSymbol
    {
        private static object Unassigned = new object();
        private static ThreadLocal<List<LazyEvalEntry>> lazyEvalStack = new ThreadLocal<List<LazyEvalEntry>>(() => new List<LazyEvalEntry>());

        private TxValue<bool> created;
        private TxValue<SymbolId> parent;
        private TxList<SymbolId> children;
        private TxHashSet<ModelProperty> parentProperties;
        private TxDictionary<ModelProperty, object> properties;
        private TxList<ModelProperty> attachedProperties;
        private TxHashSet<ModelProperty> lazyIndex;
        private TxDictionary<ModelProperty, TxDictionary<ModelProperty, object>> childInitializers;

        internal GreenSymbol()
        {
            this.created = new TxValue<bool>(false);
            this.parent = new TxValue<SymbolId>();
            this.children = new TxList<SymbolId>();
            this.parentProperties = new TxHashSet<ModelProperty>();
            this.properties = new TxDictionary<ModelProperty, object>();
            this.attachedProperties = new TxList<ModelProperty>();
            this.lazyIndex = new TxHashSet<ModelProperty>();
            this.childInitializers = new TxDictionary<ModelProperty, TxDictionary<ModelProperty, object>>();
        }

        internal GreenSymbol(GreenSymbol other)
        {
            Debug.Assert(other != null);
            this.created = new TxValue<bool>(true);
            this.parent = new TxValue<SymbolId>(other.parent.Value);
            this.children = new TxList<SymbolId>(other.children);
            this.parentProperties = new TxHashSet<ModelProperty>(other.parentProperties);
            this.properties = new TxDictionary<ModelProperty, object>(other.properties, entry => entry is GreenList ? new GreenList((GreenList)entry) : entry);
            this.attachedProperties = new TxList<ModelProperty>(other.attachedProperties);
            this.lazyIndex = new TxHashSet<ModelProperty>(other.lazyIndex);
            this.childInitializers = new TxDictionary<ModelProperty, TxDictionary<ModelProperty, object>>(other.childInitializers, entry => new TxDictionary<ModelProperty, object>(entry));
        }

        public bool IsCreated
        {
            get { return this.created.Value; }
        }

        public SymbolId Parent
        {
            get { return this.parent.Value; }
        }

        public IReadOnlyList<SymbolId> Children
        {
            get { return this.children; }
        }

        public ICollection<ModelProperty> Properties
        {
            get { return this.properties.Keys; }
        }

        public ICollection<ModelProperty> AttachedProperties
        {
            get { return this.attachedProperties; }
        }

        internal void MakeCreated()
        {
            this.created.Value = true;
        }

        public bool AddProperty(GreenModel model, SymbolId id, ModelProperty property)
        {
            Debug.Assert(!model.IsReadOnly);
            if (!this.properties.ContainsKey(property))
            {
                this.properties.Add(property, Unassigned);
                if (property.IsCollection)
                {
                    object value;
                    this.TryGetValueCore(property, false, false, true, out value);
                }
                bool declared = ModelProperty.GetDeclaredPropertiesForType(id.MutableType).Contains(property);
                if (!declared)
                {
                    this.attachedProperties.Add(property);
                }
                return true;
            }
            return false;
        }

        public bool RemoveProperty(GreenModel model, SymbolId id, ModelProperty property)
        {
            Debug.Assert(!model.IsReadOnly);
            if (this.properties.ContainsKey(property))
            {
                bool declared = ModelProperty.GetDeclaredPropertiesForType(id.MutableType).Contains(property);
                if (declared)
                {
                    return false;
                }
                else
                {
                    if (property.IsCollection)
                    {
                        this.ClearLazyItems(model, id, property);
                        this.ClearItems(model, id, property);
                    }
                    else
                    {
                        this.SetValue(model, id, property, true, Unassigned);
                    }
                    this.properties.Remove(property);
                    if (!ModelProperty.GetDeclaredPropertiesForType(id.MutableType).Contains(property))
                    {
                        this.attachedProperties.Remove(property);
                    }
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(ModelProperty property, out object value)
        {
            if (this.TryGetValueCore(property, false, false, false, out value))
            {
                return true;
            }
            return false;
        }

        public bool HasValue(ModelProperty property)
        {
            object value;
            return this.TryGetValueCore(property, false, false, false, out value);
        }

        public bool HasLazyValue(ModelProperty property)
        {
            object value;
            if (this.TryGetValueCore(property, false, true, false, out value))
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

        internal object GetValue(ModelProperty property)
        {
            object value;
            if (this.TryGetValueCore(property, false, false, false, out value))
            {
                return value;
            }
            return null;
        }

        public object GetValue(GreenModel model, SymbolId id, ModelProperty property, bool lazyEval, bool forceReplaceWithConcreteValue)
        {
            if (property.IsDerived)
            {
                Debug.Assert(!model.IsReadOnly || !forceReplaceWithConcreteValue);
                return this.LazyEvalCore(model, id, property, forceReplaceWithConcreteValue);
            }
            else if (lazyEval)
            {
                Debug.Assert(!model.IsReadOnly);
                if (property.HasRemoveAffectedProperties)
                {
                    foreach (var prop in property.RemoveAffectedProperties)
                    {
                        this.LazyEvalCore(model, id, prop, forceReplaceWithConcreteValue);
                    }
                }
                this.LazyEvalCore(model, id, property, forceReplaceWithConcreteValue);
            }
            return this.GetValue(property);
        }

        private object LazyEvalCore(GreenModel model, SymbolId id, ModelProperty property, bool forceReplaceWithConcreteValue)
        {
            object lazyValue;
            LazyEvalEntry entry = new LazyEvalEntry(id, property);
            int entryIndex = lazyEvalStack.Value.IndexOf(entry);
            if (entryIndex >= 0)
            {
                List<LazyEvalEntry> stack = new List<LazyEvalEntry>();
                for (int i = entryIndex, n = lazyEvalStack.Value.Count; i < n; i++)
                {
                    stack.Add(lazyEvalStack.Value[i]);
                }
                throw new LazyEvalException("Circular dependency between lazy values.", stack);
            }
            try
            {
                lazyEvalStack.Value.Add(entry);
                if (this.TryGetValueCore(property, false, true, false, out lazyValue))
                {
                    if (lazyValue is GreenLazyValue)
                    {
                        object value = this.LazyEvalValue((GreenLazyValue)lazyValue);
                        if (!property.IsDerived || forceReplaceWithConcreteValue)
                        {
                            this.SetValue(model, id, property, true, value);
                        }
                        return value;
                    }
                    else if (lazyValue is GreenList)
                    {
                        GreenList list = (GreenList)lazyValue;
                        GreenList resultList = property.IsDerived && !forceReplaceWithConcreteValue ? new GreenList(list) : list;
                        var lazyItems = list.LazyItems;
                        resultList.ClearLazyItems();
                        foreach (var lazyItem in lazyItems)
                        {
                            if (lazyItem is GreenLazyValue)
                            {
                                object value = this.LazyEvalValue((GreenLazyValue)lazyItem);
                                resultList.Add(value);
                                return value;
                            }
                            else if (lazyItem is GreenLazyList)
                            {
                                List<object> values = this.LazyEvalValue((GreenLazyList)lazyItem);
                                resultList.AddRange(values);
                                return list;
                            }
                        }
                        return resultList;
                    }
                    return lazyValue;
                }
                return null;
            }
            finally
            {
                lazyEvalStack.Value.RemoveAt(lazyEvalStack.Value.Count - 1);
            }
        }

        internal object LazyEvalValue(GreenLazyValue lazyValue)
        {
            try
            {
                return lazyValue.CreateValue();
            }
            catch(Exception ex)
            {
                throw new LazyEvalException("An exception was thrown by the lazy evaluator.", lazyEvalStack.Value.ToList(), ex);
            }
        }

        internal List<object> LazyEvalValue(GreenLazyList lazyList)
        {
            try
            {
                return lazyList.CreateValues();
            }
            catch (Exception ex)
            {
                throw new LazyEvalException("An exception was thrown by the lazy evaluator.", lazyEvalStack.Value.ToList(), ex);
            }
        }

        public GreenLazyValue GetLazyValue(ModelProperty property)
        {
            object value;
            if (this.TryGetValueCore(property, false, true, false, out value))
            {
                return value as GreenLazyValue;
            }
            return null;
        }

        public bool UnsetValue(GreenModel model, SymbolId id, ModelProperty property)
        {
            Debug.Assert(!model.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (property.IsCollection)
            {
                this.ClearLazyItems(model, id, property);
                this.ClearItems(model, id, property);
                return true;
            }
            else
            {
                return this.SetValue(model, id, property, true, Unassigned);
            }
        }

        public bool ClearValue(GreenModel model, SymbolId id, ModelProperty property)
        {
            Debug.Assert(!model.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (property.IsCollection)
            {
                this.ClearLazyItems(model, id, property);
                this.ClearItems(model, id, property);
                return true;
            }
            else
            {
                return this.SetValue(model, id, property, true, null);
            }
        }

        public bool ClearLazyValue(GreenModel model, SymbolId id, ModelProperty property)
        {
            Debug.Assert(!model.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (property.IsCollection)
            {
                return this.ClearLazyItems(model, id, property);
            }
            else
            {
                object value;
                if (this.TryGetValueCore(property, false, true, false, out value) && value is GreenLazyValue)
                {
                    return this.SetValue(model, id, property, true, Unassigned);
                }
            }
            return false;
        }

        public bool SetValue(GreenModel model, SymbolId id, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(!property.IsCollection);
            Debug.Assert(!(value is GreenLazyList));
            Debug.Assert(!model.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            object oldValue;
            if (this.ValueChangedCore(property, value, out oldValue))
            {
                if (!property.HasAffectedProperties || value is GreenLazyValue)
                {
                    return this.SetValueCore(model, id, property, reassign, value, oldValue);
                }
                else
                {
                    return this.SlowAddValueCore(model, id, property, null, -1, reassign, value, oldValue, null);
                }
            }
            return false;
        }

        public bool AddItem(GreenModel model, SymbolId id, ModelProperty property, int index, bool replace, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (!property.HasAddAffectedProperties || value is GreenLazyValue || value is GreenLazyList)
            {
                if (replace) this.RemoveValueCore(model, id, property, null, index, false, null);
                return this.AddValueCore(model, id, property, null, index, value);
            }
            else
            {
                if (replace) this.SlowRemoveValueCore(model, id, property, null, index, false, value, null);
                return this.SlowAddValueCore(model, id, property, null, index, false, value, Unassigned, null);
            }
        }

        public bool AddItems(GreenModel model, SymbolId id, ModelProperty property, IEnumerable<object> values)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            object listValue;
            if (!this.TryGetValueCore(property, false, false, true, out listValue) || !(listValue is GreenList))
            {
                Debug.Assert(false);
            }
            GreenList list = (GreenList)listValue;
            bool result = false;
            if (!property.HasAddAffectedProperties)
            {
                foreach (var value in values)
                {
                    result |= this.AddValueCore(model, id, property, list, -1, value);
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (value is GreenLazyValue || value is GreenLazyList)
                    {
                        result |= this.AddValueCore(model, id, property, list, -1, value);
                    }
                    else
                    {
                        result |= this.SlowAddValueCore(model, id, property, list, -1, false, value, Unassigned, null);
                    }
                }
            }
            return result;
        }

        public bool RemoveItem(GreenModel model, SymbolId id, ModelProperty property, int index, bool removeAll, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (!property.HasRemoveAffectedProperties)
            {
                return this.RemoveValueCore(model, id, property, null, index, removeAll, value);
            }
            else
            {
                return this.SlowRemoveValueCore(model, id, property, null, index, removeAll, value, null);
            }
        }

        public bool ClearItems(GreenModel model, SymbolId id, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            object listValue;
            if (!this.TryGetValueCore(property, false, false, true, out listValue) || !(listValue is GreenList))
            {
                Debug.Assert(false);
            }
            GreenList list = (GreenList)listValue;
            if (list.Count == 0) return true;
            List<object> items = list.ToList();
            if (!property.HasRemoveAffectedProperties)
            {
                foreach (var item in items)
                {
                    return this.RemoveValueCore(model, id, property, list, -1, true, item);
                }
            }
            else
            {
                foreach (var item in items)
                {
                    return this.SlowRemoveValueCore(model, id, property, list, -1, true, item, null);
                }
            }
            return true;
        }

        public bool ClearLazyItems(GreenModel model, SymbolId id, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            object listValue;
            if (!this.TryGetValueCore(property, false, false, true, out listValue) || !(listValue is GreenList))
            {
                Debug.Assert(false);
            }
            GreenList list = (GreenList)listValue;
            list.ClearLazyItems();
            this.UnregisterLazyValueCore(model, id, property);
            return true;
        }

        public bool ChildSetValue(GreenModel model, SymbolId id, ModelProperty child, ModelProperty property, bool reassign, GreenLazyValue value)
        {
            Debug.Assert(!property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + id + "::" + child + " must be a containment.");
            }
            TxDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = new TxDictionary<ModelProperty, object>();
                this.childInitializers.Add(child, initValues);
            }
            object initValue;
            if (initValues.TryGetValue(property, out initValue))
            {
                if (this.IsCreated && !reassign)
                {
                    throw new ModelException("Cannot reassign the child initializer: " + id + "::" + child + "::" + property);
                }
            }
            initValues[property] = value;
            return true;
        }

        public bool ChildAddItem(GreenModel model, SymbolId id, ModelProperty child, ModelProperty property, GreenLazyValue values)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + id + "::" + child + " must be a containment.");
            }
            TxDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = new TxDictionary<ModelProperty, object>();
                this.childInitializers.Add(child, initValues);
            }
            object initValue;
            if (!initValues.TryGetValue(property, out initValue))
            {
                initValue = new TxList<object>();
                initValues.Add(property, initValue);
            }
            Debug.Assert(initValue is TxList<object>);
            TxList<object> items = (TxList<object>)initValue;
            items.Add(values);
            return true;
        }

        public bool ChildAddItems(GreenModel model, SymbolId id, ModelProperty child, ModelProperty property, IEnumerable<GreenLazyValue> values)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + id + "::" + child + " must be a containment.");
            }
            TxDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = new TxDictionary<ModelProperty, object>();
                this.childInitializers.Add(child, initValues);
            }
            object initValue;
            if (!initValues.TryGetValue(property, out initValue))
            {
                initValue = new TxList<object>();
                initValues.Add(property, initValue);
            }
            Debug.Assert(initValue is TxList<object>);
            TxList<object> items = (TxList<object>)initValue;
            items.AddRange(values);
            return true;
        }

        public bool ChildAddItems(GreenModel model, SymbolId id, ModelProperty child, ModelProperty property, GreenLazyList values)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!model.IsReadOnly);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + id + "::" + child + " must be a containment.");
            }
            TxDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = new TxDictionary<ModelProperty, object>();
                this.childInitializers.Add(child, initValues);
            }
            object initValue;
            if (!initValues.TryGetValue(property, out initValue))
            {
                initValue = new TxList<object>();
                initValues.Add(property, initValue);
            }
            Debug.Assert(initValue is TxList<object>);
            TxList<object> items = (TxList<object>)initValue;
            items.Add(values);
            return true;
        }

        public bool ChildClear(GreenModel model, SymbolId id, ModelProperty child)
        {
            Debug.Assert(!model.IsReadOnly);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + id + "::" + child + " must be a containment.");
            }
            return this.childInitializers.Remove(child);
        }

        public bool ChildClear(GreenModel model, SymbolId id, ModelProperty child, ModelProperty property)
        {
            Debug.Assert(!model.IsReadOnly);
            if (!child.IsContainment)
            {
                throw new ModelException("The child property " + id + "::" + child + " must be a containment.");
            }
            TxDictionary<ModelProperty, object> initValues;
            if (this.childInitializers.TryGetValue(child, out initValues))
            {
                return initValues.Remove(property);
            }
            return false;
        }

        private bool TryGetValueCore(ModelProperty property, bool returnUnassignedValue, bool returnLazyValue, bool createIfNotExists, out object value)
        {
            Debug.Assert(property != null);
            if (this.properties.TryGetValue(property, out value))
            {
                if (value != Unassigned)
                {
                    Debug.Assert(!(value is GreenLazyList));
                    if (!returnLazyValue && (value is GreenLazyValue))
                    {
                        value = null;
                        return false;
                    }
                    return true;
                }
                else if (createIfNotExists && property.IsCollection)
                {
                    value = new GreenList(!property.IsNonUnique);
                    this.properties[property] = value;
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
            if (this.TryGetValueCore(property, true, true, false, out oldValue))
            {
                return !(value == oldValue);
            }
            oldValue = Unassigned;
            return true;
        }

        private bool SetValueCore(GreenModel model, SymbolId id, ModelProperty property, bool reassign, object value, object oldValue)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(!(value is GreenLazyList));
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is ISymbol));
            Debug.Assert(!(oldValue is GreenLazyList));
            Debug.Assert(!(oldValue is ISymbol));
            if (value == oldValue) return false;
            if (this.IsCreated && !reassign)
            {
                if (property.IsDerived && oldValue != Unassigned)
                {
                    throw new ModelException("Cannot reassign a derived property: " + id + "::" + property);
                }
                if (property.IsReadonly && oldValue != Unassigned)
                {
                    throw new ModelException("Cannot reassign a read-only property: " + id + "::" + property);
                }
                if (oldValue is GreenLazyValue)
                {
                    throw new ModelException("Cannot reassign a lazy-valued property: " + id + "::" + property);
                }
            }
            if (value == null && property.IsNonNull)
            {
                throw new ModelException("Null value cannot be assigned to property: " + id + "::" + property);
            }
            if (!(value == null || value == Unassigned || (value is GreenLazyValue) ||
                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType())))))
            {
                throw new ModelException("Value of type '" + value.GetType() + "' cannot be assigned to property " + id + "::" + property + " of type '" + property.MutableTypeInfo.Type + "'.");
            }
            if (value is SymbolId)
            {
                if (!model.SymbolExists((SymbolId)value))
                {
                    throw new ModelException("Symbol with id '" + ((SymbolId)value).Id + "' cannot be assigned to property " + id + "::" + property + " of type '" + property.MutableTypeInfo.Type + "', since the value cannot be resolved within the model group. Make sure to reference the required models from the model group.");
                }
            }
            if (oldValue != null && oldValue != Unassigned)
            {
                if (oldValue is SymbolId)
                {
                    SymbolId oldId = (SymbolId)value;
                    GreenModel oldModel = model.GetModelOf(oldId);
                    if (oldModel != null)
                    {
                        GreenSymbol oldSymbol;
                        bool readOnly;
                        if (oldModel.TryGetSymbol(oldId, true, out oldSymbol, out readOnly))
                        {
                            this.RemoveReferenceCore(model, id, property, oldModel, oldId, oldSymbol, readOnly);
                        }
                    }
                }
                else if (oldValue is GreenLazyValue)
                {
                    this.UnregisterLazyValueCore(model, id, property);
                }
            }
            this.properties[property] = value;
            if (value != null && value != Unassigned)
            {
                if (value is SymbolId)
                {
                    SymbolId childId = (SymbolId)value;
                    GreenModel childModel = model.GetModelOf(childId);
                    if (childModel != null)
                    {
                        GreenSymbol childSymbol;
                        bool readOnly;
                        if (childModel.TryGetSymbol(childId, true, out childSymbol, out readOnly))
                        {
                            this.AddReferenceCore(model, id, property, childModel, childId, childSymbol, readOnly);
                        }
                        else
                        {
                            throw new ModelException("Cannot find referenced symbol '" + value + "' for property: " + id + "::" + property);
                        }
                    }
                    else
                    {
                        throw new ModelException("Cannot find the model of the referenced symbol '" + value + "' for property: " + id + "::" + property);
                    }
                }
                else if (value is GreenLazyValue)
                {
                    this.RegisterLazyValueCore(model, id, property);
                }
            }
            return true;
        }

        private bool AddValueCore(GreenModel model, SymbolId id, ModelProperty property, GreenList list, int index, object value)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(value != Unassigned);
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is ISymbol));
            if (this.IsCreated)
            {
                if (property.IsDerived)
                {
                    throw new ModelException("Cannot change a derived property: " + id + "::" + property);
                }
                if (property.IsReadonly)
                {
                    throw new ModelException("Cannot change a read-only property: " + id + "::" + property);
                }
            }
            if (value == null && property.IsNonNull)
            {
                throw new ModelException("Null value cannot added to property: " + id + "::" + property);
            }
            if (value is SymbolId)
            {
                if (!model.SymbolExists((SymbolId)value))
                {
                    throw new ModelException("Symbol with id '" + ((SymbolId)value).Id + "' cannot be added to property " + id + "::" + property + " of type '" + property.MutableTypeInfo.Type + "', since the value cannot be resolved within the model group. Make sure to reference the required models from the model group.");
                }
            }
            if (!(value == null || (value is GreenLazyValue) || (value is GreenLazyList) ||
                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType())))))
            {
                throw new ModelException("Value of type '" + value.GetType() + "' cannot be added to property " + id + "::" + property + " of type '" + property.MutableTypeInfo.Type + "'.");
            }
            if (list == null)
            {
                object listValue;
                if (!this.TryGetValueCore(property, false, false, true, out listValue) || !(listValue is GreenList))
                {
                    Debug.Assert(false);
                }
                list = (GreenList)listValue;
            }
            if (value is GreenLazyValue || value is GreenLazyList)
            {
                list.AddLazy(value);
                this.RegisterLazyValueCore(model, id, property);
                return true;
            }
            else
            {
                bool added = false;
                if (index >= 0)
                {
                    added = list.Insert(index, value);
                }
                else
                {
                    added = list.Add(value);
                }
                if (added && value is SymbolId)
                {
                    SymbolId childId = (SymbolId)value;
                    GreenModel childModel = model.GetModelOf(childId);
                    if (childModel != null)
                    {
                        GreenSymbol childSymbol;
                        bool readOnly;
                        if (childModel.TryGetSymbol(childId, true, out childSymbol, out readOnly))
                        {
                            this.AddReferenceCore(model, id, property, childModel, childId, childSymbol, readOnly);
                        }
                        else
                        {
                            throw new ModelException("Cannot find referenced symbol '" + value + "' for property: " + id + "::" + property);
                        }
                    }
                    else
                    {
                        throw new ModelException("Cannot find the model of the referenced symbol '" + value + "' for property: " + id + "::" + property);
                    }
                }
                return added;
            }
        }

        private bool RemoveValueCore(GreenModel model, SymbolId id, ModelProperty property, GreenList list, int index, bool removeAll, object value)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(value != Unassigned);
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is ISymbol));
            Debug.Assert(!(index >= 0 && removeAll));
            if (this.IsCreated)
            {
                if (property.IsDerived)
                {
                    throw new ModelException("Cannot change a derived property: " + id + "::" + property);
                }
                if (property.IsReadonly)
                {
                    throw new ModelException("Cannot change a read-only property: " + id + "::" + property);
                }
            }
            if (index < 0 && value == null && property.IsNonNull)
            {
                return false;
            }
            if (list == null)
            {
                object listValue;
                if (this.TryGetValueCore(property, false, false, false, out listValue))
                {
                    if (listValue == null) return false;
                    Debug.Assert(listValue is GreenList);
                    list = (GreenList)listValue;
                }
                else
                {
                    return false;
                }
            }
            bool result;
            bool removedAll;
            if (index >= 0)
            {
                value = list[index];
                result = list.RemoveAt(index, value);
                removedAll = result && !list.Contains(value);
            }
            else if(removeAll)
            {
                result = list.RemoveAll(value);
                removedAll = result;
            }
            else 
            {
                result = list.Remove(value);
                removedAll = result && !list.Contains(value);
            }
            if (removedAll && value is SymbolId)
            {
                SymbolId valueId = (SymbolId)value;
                GreenModel valueModel = model.GetModelOf(valueId);
                if (valueModel != null)
                {
                    GreenSymbol oldSymbol;
                    bool readOnly;
                    if (valueModel.TryGetSymbol(valueId, true, out oldSymbol, out readOnly))
                    {
                        this.RemoveReferenceCore(model, id, property, valueModel, valueId, oldSymbol, readOnly);
                    }
                }
            }
            return result;
        }

        private bool SlowAddValueCore(GreenModel model, SymbolId id, ModelProperty property, GreenList list, int index, bool reassign, object value, object oldValue, ChangeInfo change)
        {
            Debug.Assert(!(value is GreenLazyValue || value is GreenLazyList || value is GreenList));
            if (!this.properties.ContainsKey(property)) return false;
            if (change == null)
            {
                change = new ChangeInfo();
                change.visitedAdd.Add(property);
            }
            else
            {
                if (change.visitedAdd.Contains(property)) return false;
                else change.visitedAdd.Add(property);
            }
            if (oldValue != Unassigned)
            {
                change.visitedRemove.Add(property);
                bool removed = false;
                if (property.IsCollection)
                {
                    removed = this.RemoveValueCore(model, id, property, list, index, false, oldValue);
                }
                else
                {
                    removed = this.SetValueCore(model, id, property, reassign, null, oldValue);
                }
                if (removed)
                {
                    if (property.HasRemoveAffectedProperties)
                    {
                        foreach (var remProp in property.RemoveAffectedProperties)
                        {
                            this.SlowRemoveValueCore(model, id, remProp, null, -1, false, oldValue, change);
                        }
                        foreach (var remProp in property.RemoveAffectedOptionalProperties)
                        {
                            this.SlowRemoveValueCore(model, id, remProp, null, -1, false, oldValue, change);
                        }
                    }
                    if (property.HasOppositeProperties && oldValue is SymbolId)
                    {
                        SymbolId oldId = (SymbolId)oldValue;
                        GreenModel oldModel = model.GetModelOf(oldId);
                        if (oldModel != null)
                        {
                            GreenSymbol oldSymbol;
                            bool readOnly;
                            if (oldModel.TryGetSymbol(oldId, true, out oldSymbol, out readOnly))
                            {
                                if (!readOnly)
                                {
                                    foreach (var oppProp in property.OppositeProperties)
                                    {
                                        oldSymbol.SlowRemoveValueCore(oldModel, oldId, oppProp, null, -1, false, id, change.oldOpposite);
                                    }
                                }
                            }
                            else
                            {
                                throw new ModelException("Cannot find opposite symbol '" + oldValue + "' for property: " + id + "::" + property);
                            }
                        }
                        else
                        {
                            throw new ModelException("Cannot find the model of the opposite symbol '" + oldValue + "' for property: " + id + "::" + property);
                        }
                    }
                }
            }
            bool result;
            if (property.IsCollection)
            {
                result = this.AddValueCore(model, id, property, list, index, value);
            }
            else
            {
                result = this.SetValueCore(model, id, property, reassign, value, null);
            }
            if (result && !(value is GreenLazyValue || value is GreenLazyList))
            {
                if (property.HasAddAffectedProperties)
                {
                    foreach (var addProp in property.AddAffectedProperties)
                    {
                        this.SlowAddValueCore(model, id, addProp, null, -1, reassign, value, null, change);
                    }
                    foreach (var addProp in property.AddAffectedOptionalProperties)
                    {
                        if (value == null ||
                            ((value is SymbolId) && (addProp.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                            (!(value is SymbolId) && (addProp.MutableTypeInfo.Type.IsAssignableFrom(value.GetType()))))
                        {
                            this.SlowAddValueCore(model, id, addProp, null, -1, reassign, value, null, change);
                        }
                    }
                }
                if (property.HasOppositeProperties && value is SymbolId)
                {
                    SymbolId oppId = (SymbolId)value;
                    GreenModel oppModel = model.GetModelOf(oppId);
                    if (oppModel != null)
                    {
                        GreenSymbol oppSymbol;
                        bool readOnly;
                        if (oppModel.TryGetSymbol(oppId, true, out oppSymbol, out readOnly))
                        {
                            if (!readOnly)
                            {
                                foreach (var oppProp in property.OppositeProperties)
                                {
                                    object oldOppValue = oppSymbol.GetValue(oppProp);
                                    if (oppProp.IsCollection)
                                    {
                                        GreenList oldOppList = oldOppValue as GreenList;
                                        if (oldOppList != null && !oldOppList.Contains(id))
                                        {
                                            oppSymbol.SlowAddValueCore(oppModel, oppId, oppProp, oldOppList, -1, reassign, id, null, change.newOpposite);
                                        }
                                    }
                                    else
                                    {
                                        if (oldOppValue != this)
                                        {
                                            oppSymbol.SlowAddValueCore(oppModel, oppId, oppProp, null, -1, reassign, id, oldOppValue, change.newOpposite);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new ModelException("Cannot find opposite symbol '" + value + "' for property: " + id + "::" + property);
                        }
                    }
                    else
                    {
                        throw new ModelException("Cannot find the model of the opposite symbol '" + oldValue + "' for property: " + id + "::" + property);
                    }
                }
            }
            return result;
        }

        private bool SlowRemoveValueCore(GreenModel model, SymbolId id, ModelProperty property, GreenList list, int index, bool removeAll, object value, ChangeInfo change)
        {
            Debug.Assert(!(value is GreenLazyValue || value is GreenLazyList || value is GreenList));
            Debug.Assert(model.ContainsSymbol(id));
            if (!this.properties.ContainsKey(property)) return false;
            if (change == null)
            {
                change = new ChangeInfo();
                change.visitedRemove.Add(property);
            }
            else
            {
                if (change.visitedRemove.Contains(property)) return false;
                else change.visitedRemove.Add(property);
            }
            bool result;
            if (property.IsCollection)
            {
                result = this.RemoveValueCore(model, id, property, list, index, removeAll, value);
            }
            else
            {
                result = this.SetValueCore(model, id, property, false, null, value);
            }
            if (result)
            {
                if (property.HasRemoveAffectedProperties)
                {
                    foreach (var remProp in property.RemoveAffectedProperties)
                    {
                        this.SlowRemoveValueCore(model, id, remProp, null, -1, removeAll, value, change);
                    }
                    foreach (var remProp in property.RemoveAffectedOptionalProperties)
                    {
                        this.SlowRemoveValueCore(model, id, remProp, null, -1, removeAll, value, change);
                    }
                }
                if (property.HasOppositeProperties && value is SymbolId)
                {
                    SymbolId oppId = (SymbolId)value;
                    GreenModel oppModel = model.GetModelOf(oppId);
                    if (oppModel != null)
                    {
                        GreenSymbol oppSymbol;
                        bool readOnly;
                        if (oppModel.TryGetSymbol((SymbolId)value, true, out oppSymbol, out readOnly))
                        {
                            if (!readOnly)
                            {
                                foreach (var oppProp in property.OppositeProperties)
                                {
                                    oppSymbol.SlowRemoveValueCore(oppModel, oppId, oppProp, null, -1, removeAll, id, change.oldOpposite);
                                }
                            }
                        }
                        else
                        {
                            throw new ModelException("Cannot find opposite symbol '" + value + "' for property: " + id + "::" + property);
                        }
                    }
                    else
                    {
                        throw new ModelException("Cannot find the model of the opposite symbol '" + value + "' for property: " + id + "::" + property);
                    }
                }
            }
            return result;
        }

        private void AddReferenceCore(GreenModel model, SymbolId id, ModelProperty property, GreenModel valueModel, SymbolId valueId, GreenSymbol value, bool readOnlyValue)
        {
            Debug.Assert(property != null);
            Debug.Assert(value != null);
            //model.AddReference(id, property, valueId);
            if (property.IsContainment)
            {
                if (value.parent.Value != null && value.parent.Value != id)
                {
                    throw new ModelException("Invalid containment in " + id + "::" + property + ": symbol '" + value + "' is already contained by '" + value.parent.Value + "'.");
                }
                if (!readOnlyValue)
                {
                    value.parent.Value = id;
                    value.parentProperties.Add(property);
                }
                if (!this.children.Contains(valueId))
                {
                    this.children.Add(valueId);
                    if (!readOnlyValue)
                    {
                        this.InitChildCore(property, valueModel, valueId, value);
                    }
                }
            }
        }

        private void RemoveReferenceCore(GreenModel model, SymbolId id, ModelProperty property, GreenModel valueModel, SymbolId valueId, GreenSymbol value, bool readOnlyValue)
        {
            Debug.Assert(property != null);
            Debug.Assert(value != null);
            //model.RemoveReference(id, property, valueId);
            if (property.IsContainment)
            {
                if (!readOnlyValue)
                {
                    value.parentProperties.Remove(property);
                    value.parent.Value = null;
                    this.children.Remove(valueId);
                }
                else
                {
                    bool lostParent = true;
                    foreach (var prop in this.properties)
                    {
                        if (prop.Key != property && prop.Key.IsContainment)
                        {
                            if (prop.Value is GreenList)
                            {
                                if (((GreenList)prop.Value).Contains(valueId)) lostParent = false;
                            }
                            else
                            {
                                if (prop.Value == valueId) lostParent = false;
                            }
                        }
                    }
                    if (lostParent)
                    {
                        this.children.Remove(valueId);
                    }
                }
            }
        }

        private void InitChildCore(ModelProperty childProperty, GreenModel childModel, SymbolId childId, GreenSymbol child)
        {
            TxDictionary<ModelProperty, object> initValues;
            if (this.childInitializers.TryGetValue(childProperty, out initValues) && initValues != null)
            {
                foreach (var initValue in initValues)
                {
                    if (initValue.Key.IsCollection)
                    {
                        TxList<object> values = initValue.Value as TxList<object>;
                        if (values != null)
                        {
                            child.AddItems(childModel, childId, initValue.Key, values);
                        }
                    }
                    else
                    {
                        child.SetValue(childModel, childId, initValue.Key, false, initValue.Value);
                    }
                }
            }
        }

        private void RegisterLazyValueCore(GreenModel model, SymbolId id, ModelProperty property)
        {
            if (this.lazyIndex.Count == 0)
            {
                model.RegisterLazySymbol(id);
            }
            this.lazyIndex.Add(property);
        }

        private void UnregisterLazyValueCore(GreenModel model, SymbolId id, ModelProperty property)
        {
            if (this.lazyIndex.Count > 0)
            {
                this.lazyIndex.Remove(property);
                if (this.lazyIndex.Count == 0)
                {
                    model.UnregisterLazySymbol(id);
                }
            }
        }

        internal void EvaluateLazyValues(GreenModel model, SymbolId id, bool forceReplaceWithConcreteValue)
        {
            var lazyProps = this.lazyIndex.ToList();
            foreach (var prop in lazyProps)
            {
                this.LazyEvalCore(model, id, prop, forceReplaceWithConcreteValue);
            }
        }

        private class ChangeInfo
        {
            public ChangeInfo oldOpposite;
            public ChangeInfo newOpposite;
            public HashSet<ModelProperty> visitedAdd;
            public HashSet<ModelProperty> visitedRemove;

            public ChangeInfo()
            {
                this.oldOpposite = new ChangeInfo(this, true);
                this.newOpposite = new ChangeInfo(this, false);
                this.visitedAdd = new HashSet<ModelProperty>();
                this.visitedRemove = new HashSet<ModelProperty>();
            }

            private ChangeInfo(ChangeInfo opposite, bool old)
            {
                if (old) this.oldOpposite = opposite;
                else this.newOpposite = opposite;
                this.visitedAdd = new HashSet<ModelProperty>();
                this.visitedRemove = new HashSet<ModelProperty>();
            }
        }
    }

    public sealed class GreenModel
    {
        private static readonly IReadOnlyList<SymbolId> emptySymbolList = new List<SymbolId>();
        private static readonly IReadOnlyList<SymbolId> emptyPropertyList = new List<SymbolId>();
        private GreenModelGroup group;
        private GreenModel baseModel;
        private bool readOnly = false;
        private TxValue<bool> changed;
        private TxDictionary<SymbolId, GreenSymbol> symbols;
        private TxHashSet<SymbolId> lazySymbols;

        internal GreenModel(GreenModelGroup group = null)
        {
            this.group = group;
            this.changed = new TxValue<bool>(false);
            this.symbols = new TxDictionary<SymbolId, GreenSymbol>();
            this.lazySymbols = new TxHashSet<SymbolId>();
        }

        internal GreenModel(GreenModelGroup group, GreenModel baseModel, bool readOnly, bool deepCopy)
        {
            this.group = group;
            this.readOnly = readOnly;
            this.changed = new TxValue<bool>(false);
            if (readOnly && !baseModel.IsReadOnly) deepCopy = true;
            if (deepCopy)
            {
                this.baseModel = null;
                this.symbols = new TxDictionary<SymbolId, GreenSymbol>();
                foreach (var entry in baseModel.symbols)
                {
                    this.symbols.Add(entry.Key, baseModel.GetSymbol(entry.Key, !this.readOnly) ?? new GreenSymbol());
                }
            }
            else
            {
                this.baseModel = baseModel;
                this.symbols = new TxDictionary<SymbolId, GreenSymbol>(baseModel.symbols, symbol => null);
            }
            this.lazySymbols = new TxHashSet<SymbolId>(baseModel.lazySymbols);
        }

        internal GreenModelGroup Group
        {
            get { return this.group; }
        }

        internal GreenModel BaseModel
        {
            get { return this.baseModel; }
        }

        internal bool IsChanged
        {
            get { return this.changed.Value; }
        }

        internal bool IsReadOnly
        {
            get { return this.readOnly; }
        }

        internal bool HasLazyValues
        {
            get { return this.lazySymbols.Count > 0; }
        }

        internal IEnumerable<SymbolId> Symbols
        {
            get { return this.symbols.Keys; }
        }

        internal bool TryGetSymbol(SymbolId id, bool forWriting, out GreenSymbol symbol, out bool readOnly)
        {
            Debug.Assert(id != null);
            if (this.symbols.TryGetValue(id, out symbol))
            {
                if (symbol != null)
                {
                    readOnly = this.readOnly;
                    return true;
                }
                GreenSymbol baseSymbol;
                if (this.baseModel != null && this.baseModel.TryGetSymbol(id, false, out baseSymbol, out readOnly))
                {
                    if (forWriting)
                    {
                        symbol = new GreenSymbol(baseSymbol);
                        this.symbols[id] = symbol;
                        this.changed.Value = true;
                        readOnly = false;
                    }
                    else
                    {
                        symbol = baseSymbol;
                        readOnly = true;
                    }
                    return true;
                }
            }
            symbol = null;
            readOnly = true;
            return false;
        }

        internal GreenSymbol GetSymbol(SymbolId id, bool forWriting)
        {
            GreenSymbol symbol;
            bool readOnly;
            if (this.TryGetSymbol(id, forWriting, out symbol, out readOnly))
            {
                if (readOnly && forWriting) return null;
                return symbol;
            }
            return null;
        }

        internal GreenModel GetModelOf(SymbolId id)
        {
            if (this.group != null)
            {
                return this.group.GetModelOf(id);
            }
            else if (this.symbols.ContainsKey(id))
            {
                return this;
            }
            return null;
        }

        internal bool ContainsSymbol(SymbolId id)
        {
            return this.symbols.ContainsKey(id);
        }

        internal bool SymbolExists(SymbolId id)
        {
            if (this.ContainsSymbol(id)) return true;
            if (this.group != null)
            {
                return this.group.SymbolExists(id);
            }
            return false;
        }

        internal GreenSymbol AddSymbol(SymbolId id)
        {
            Debug.Assert(id != null);
            if (this.group != null)
            {
                if (this.group.ContainsSymbol(id))
                {
                    throw new ModelException("Symbol " + id + " is already contained by the model group.");
                }
            }
            else
            {
                if (this.ContainsSymbol(id)) 
                {
                    throw new ModelException("Symbol " + id + " is already contained by the model.");
                }
            }
            GreenSymbol symbol = new GreenSymbol();
            this.symbols.Add(id, symbol);
            return symbol;
        }

        internal void RemoveSymbol(SymbolId id)
        {
            // TODO
            throw new NotImplementedException();
        }

        internal void ReplaceSymbol(SymbolId fromId, SymbolId toId)
        {
            // TODO
            throw new NotImplementedException();
        }


        internal void RegisterLazySymbol(SymbolId id)
        {
            Debug.Assert(id != null);
            Debug.Assert(this.symbols.ContainsKey(id));
            this.lazySymbols.Add(id);
        }

        internal void UnregisterLazySymbol(SymbolId id)
        {
            Debug.Assert(id != null);
            Debug.Assert(this.symbols.ContainsKey(id));
            this.lazySymbols.Remove(id);
        }

        internal void EvaluateLazyValues(bool forceReplaceWithConcreteValue)
        {
            var symbolIds = this.lazySymbols.ToList();
            foreach (var id in symbolIds)
            {
                var symbol = this.GetSymbol(id, true);
                symbol.EvaluateLazyValues(this, id, forceReplaceWithConcreteValue);
            }
        }
        /*
        internal bool AddReference(SymbolId id, ModelProperty property, SymbolId valueId)
        {
            if (id == null) return false;
            if (property == null) return false;
            if (valueId == null) return false;
            TxDictionary<SymbolId, TxHashSet<ModelProperty>> symbols;
            if (!this.references.TryGetValue(valueId, out symbols))
            {
                symbols = new TxDictionary<SymbolId, TxHashSet<ModelProperty>>();
                this.references.Add(valueId, symbols);
            }
            TxHashSet<ModelProperty> properties;
            if (!symbols.TryGetValue(id, out properties))
            {
                properties = new TxHashSet<ModelProperty>();
                symbols.Add(id, properties);
            }
            properties.Add(property);
            return property.IsContainment;
        }

        internal bool RemoveReference(SymbolId id, ModelProperty property, SymbolId valueId)
        {
            if (id == null) return false;
            if (property == null) return false;
            if (valueId == null) return false;
            TxDictionary<SymbolId, TxHashSet<ModelProperty>> symbols;
            if (!this.references.TryGetValue(valueId, out symbols))
            {
                return false;
            }
            TxHashSet<ModelProperty> properties;
            if (!symbols.TryGetValue(id, out properties))
            {
                return false;
            }
            properties.Remove(property);
            bool lostParent = property.IsContainment && properties.All(p => !p.IsContainment);
            return lostParent;
        }

        internal void RegisterLazyValue(SymbolId id, ModelProperty property)
        {
            Debug.Assert(id != null);
            Debug.Assert(property != null);
            Debug.Assert(this.symbols.ContainsKey(id));
            TxHashSet<ModelProperty> properties;
            if (!this.lazyIndex.TryGetValue(id, out properties))
            {
                properties = new TxHashSet<ModelProperty>();
                this.lazyIndex.Add(id, properties);
            }
            properties.Add(property);
        }

        internal void UnregisterLazyValue(SymbolId id, ModelProperty property)
        {
            Debug.Assert(id != null);
            Debug.Assert(property != null);
            Debug.Assert(this.symbols.ContainsKey(id));
            TxHashSet<ModelProperty> properties;
            if (this.lazyIndex.TryGetValue(id, out properties) && properties != null)
            {
                properties.Remove(property);
                if (properties.Count == 0)
                {
                    this.lazyIndex.Remove(id);
                }
            }
        }

        internal void EvaluateLazyValues(bool forceReplaceWithConcreteValue)
        {
            var symbolIds = this.lazyIndex.Keys.ToList();
            foreach (var id in symbolIds)
            {
                TxHashSet<ModelProperty> properties;
                if (this.lazyIndex.TryGetValue(id, out properties))
                {
                    GreenSymbol symbol = this.GetSymbol(id, true);
                    var propertyList = properties.ToList();
                    foreach (var property in propertyList)
                    {
                        symbol.GetValue(this, id, property, true, forceReplaceWithConcreteValue);
                    }
                }
            }
        }
        */
        /*
        internal object GetValue(SymbolId id, ModelProperty property, bool lazyEval)
        {
            GreenSymbol symbol = this.GetSymbol(id, lazyEval);
            if (symbol != null)
            {
                return symbol.GetValue(property, lazyEval, false);
            }
            return null;
        }

        internal GreenLazyValue GetLazyValue(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, false);
            if (symbol != null)
            {
                return symbol.GetLazyValue(property);
            }
            return null;
        }

        internal bool SetValue(SymbolId id, ModelProperty property, bool reassign, object value)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.SetValue(property, reassign, value);
            }
            return false;
        }

        internal bool AddItem(SymbolId id, ModelProperty property, int index, bool replace, object value)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.AddItem(property, index, replace, value);
            }
            return false;
        }

        internal bool RemoveItem(SymbolId id, ModelProperty property, int index, bool removeAll, object value)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.RemoveItem(property, index, removeAll, value);
            }
            return false;
        }

        internal bool ClearItems(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.ClearItems(property);
            }
            return false;
        }

        internal bool ClearLazyItems(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.ClearLazyItems(property);
            }
            return false;
        }

        internal SymbolId MParent(SymbolId id)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.Parent;
            }
            return null;
        }

        internal IReadOnlyList<SymbolId> MChildren(SymbolId id)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.Children;
            }
            return null;
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(SymbolId id)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                ICollection<ModelProperty> attachedProperties = symbol.AttachedProperties;
                if (attachedProperties != null && attachedProperties.Count > 0)
                {
                    List<ModelProperty> result = new List<ModelProperty>(ModelProperty.GetDeclaredPropertiesForType(id.MutableType));
                    result.AddRange(attachedProperties);
                    return result;
                }
                else
                {
                    return ModelProperty.GetDeclaredPropertiesForType(id.MutableType);
                }
            }
            return null;
        }

        internal bool MIsSet(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.HasValue(property);
            }
            return false;
        }

        internal IReadOnlyList<ModelProperty> MGetAllProperties(SymbolId id, string name)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                ICollection<ModelProperty> attachedProperties = symbol.AttachedProperties;
                if (attachedProperties != null && attachedProperties.Count > 0)
                {
                    List<ModelProperty> result = new List<ModelProperty>(ModelProperty.GetDeclaredPropertiesForType(id.MutableType).Where(p => p.Name == name));
                    result.AddRange(attachedProperties.Where(p => p.Name == name));
                    return result;
                }
                else
                {
                    return ModelProperty.GetDeclaredPropertiesForType(id.MutableType).Where(p => p.Name == name).ToList();
                }
            }
            return null;
        }

        internal bool MHasLazy(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.HasLazyValue(property);
            }
            return false;
        }

        internal bool MTryGet(SymbolId id, ModelProperty property, out object value)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.TryGetValue(property, out value);
            }
            value = null;
            return false;
        }

        internal bool MClear(SymbolId id, ModelProperty property, bool clearLazy)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.ClearValue(property);
            }
            return false;
        }

        internal bool MClearLazy(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.ClearLazyValue(property);
            }
            return false;
        }

        internal bool MAttachProperty(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.AddProperty(property);
            }
            return false;
        }

        internal bool MDetachProperty(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.RemoveProperty(property);
            }
            return false;
        }

        internal void MEvaluateLazy(SymbolId id)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                foreach (var property in symbol.Properties)
                {
                    symbol.GetValue(property, true, false);
                }
            }
        }

        internal bool MChildLazySet(SymbolId id, ModelProperty child, ModelProperty property, GreenLazyValue value, bool reset)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                if (reset) symbol.ChildClear(child, property);
                return symbol.ChildSetValue(child, property, reset, value);
            }
            return false;
        }

        internal bool MChildLazyAddRange(SymbolId id, ModelProperty child, ModelProperty property, GreenLazyList values, bool reset)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                if (reset) symbol.ChildClear(child, property);
                return symbol.ChildAddItems(child, property, values);
            }
            return false;
        }

        internal bool MChildLazyAddRange(SymbolId id, ModelProperty child, ModelProperty property, IEnumerable<GreenLazyValue> values, bool reset)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                if (reset) symbol.ChildClear(child, property);
                return symbol.ChildAddItems(child, property, values);
            }
            return false;
        }

        internal bool MChildLazyClear(SymbolId id, ModelProperty child)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                symbol.ChildClear(child);
            }
            return false;
        }

        internal bool MChildLazyClear(SymbolId id, ModelProperty child, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                symbol.ChildClear(child, property);
            }
            return false;
        }

        internal bool MRemove(SymbolId id, ModelProperty property, object value, bool removeAll)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.RemoveItem(property, -1, removeAll, value);
            }
            return false;
        }

        internal void MUnset(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                symbol.UnsetValue(property);
            }
        }

        internal bool MAdd(SymbolId id, ModelProperty property, object value, bool reset)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                if (reset) symbol.UnsetValue(property);
                if (property.IsCollection)
                {
                    return symbol.AddItem(property, -1, false, value);
                }
                else
                {
                    bool result = symbol.SetValue(property, false, value);
                    return result;
                }
            }
            return false;
        }

        internal bool MLazyAdd(SymbolId id, ModelProperty property, GreenLazyValue value, bool reset)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                if (reset) symbol.UnsetValue(property);
                if (property.IsCollection)
                {
                    return symbol.AddItem(property, -1, false, value);
                }
                else
                {
                    bool result = symbol.SetValue(property, false, value);
                    return result;
                }
            }
            return false;
        }

        internal bool MAddRange(SymbolId id, ModelProperty property, IEnumerable<object> values, bool reset)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                if (reset) symbol.UnsetValue(property);
                return symbol.AddItems(property, values);
            }
            return false;
        }

        internal bool MLazyAddRange(SymbolId id, ModelProperty property, IEnumerable<GreenLazyValue> values, bool reset)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                if (reset) symbol.UnsetValue(property);
                return symbol.AddItems(property, values);
            }
            return false;
        }

        internal bool MLazyAddRange(SymbolId id, ModelProperty property, GreenLazyList values, bool reset)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                if (reset) symbol.UnsetValue(property);
                return symbol.AddItem(property, -1, false, values);
            }
            return false;
        }
        */
        /*
        internal void MMakeCreated(SymbolId id)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                symbol.MakeCreated();
            }
        }

        internal bool MIsCreated(SymbolId id)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.IsCreated;
            }
            return true;
        }
        */
        public GreenModel Fork(GreenModelGroup group)
        {
            return new GreenModel(group, this, false, true);
        }

        public void Finish()
        {
            this.readOnly = true;
        }
    }

    public sealed class GreenModelGroup
    {
        private bool readOnly;
        private TxList<GreenModel> references;
        private TxList<GreenModel> models;

        internal GreenModelGroup()
        {
            this.readOnly = false;
            this.references = new TxList<GreenModel>();
            this.models = new TxList<GreenModel>();
        }

        internal GreenModelGroup(IEnumerable<GreenModel> references)
        {
            this.readOnly = false;
            this.references = new TxList<GreenModel>(references);
            this.models = new TxList<GreenModel>();
        }

        internal GreenModelGroup(IEnumerable<GreenModel> references, IEnumerable<GreenModel> models, bool readOnly)
        {
            this.readOnly = readOnly;
            this.references = new TxList<GreenModel>(references);
            this.models = new TxList<GreenModel>(models);
        }

        public bool IsReadOnly
        {
            get { return this.readOnly; }
        }

        public IReadOnlyList<GreenModel> References
        {
            get { return this.references; }
        }

        public IReadOnlyList<GreenModel> Models
        {
            get { return this.models; }
        }

        internal void AddReference(GreenModel reference, bool replace = true)
        {
            if (this.readOnly) return;
            this.references.Add(reference);
        }

        internal void AddModel(GreenModel model, bool replace = true)
        {
            if (this.readOnly) return;
            this.models.Add(model);
        }

        internal GreenModelGroup Fork(bool finish, bool evalLazy, bool evalDerived)
        {
            if (finish)
            {
                if (evalLazy || evalDerived)
                {
                    this.EvaluateLazyValues(evalDerived);
                }
                this.Finish();
                return this;
            }
            else
            {
                GreenModelGroup result = new GreenModelGroup(this.references);
                foreach (var model in this.models)
                {
                    result.AddModel(model.Fork(result));
                }
                if (evalLazy || evalDerived)
                {
                    result.EvaluateLazyValues(evalDerived);
                }
                return result;
            }
        }

        internal void Finish()
        {
            foreach (var model in this.models)
            {
                model.Finish();
            }
            this.readOnly = true;
        }

        internal void EvaluateLazyValues(bool evalDerived)
        {
            if (this.readOnly) return;
            foreach (var model in this.models)
            {
                model.EvaluateLazyValues(evalDerived);
            }
        }

        internal bool ContainsSymbol(SymbolId id)
        {
            foreach (var model in this.models)
            {
                if (model.ContainsSymbol(id)) return true;
            }
            return false;
        }

        internal bool SymbolExists(SymbolId id)
        {
            foreach (var model in this.models)
            {
                if (model.ContainsSymbol(id)) return true;
            }
            foreach (var reference in this.references)
            {
                if (reference.ContainsSymbol(id)) return true;
            }
            return false;
        }

        internal bool TryGetSymbol(SymbolId id, bool forWriting, out GreenSymbol symbol, out bool readOnly)
        {
            return this.TryGetSymbol(null, id, forWriting, out symbol, out readOnly);
        }

        internal bool TryGetSymbol(GreenModel sender, SymbolId id, bool forWriting, out GreenSymbol symbol, out bool readOnly)
        {
            foreach (var model in this.models)
            {
                if (model != sender)
                {
                    if (model.TryGetSymbol(id, forWriting, out symbol, out readOnly))
                    {
                        return true;
                    }
                }
            }
            foreach (var reference in this.references)
            {
                if (reference != sender)
                {
                    if (reference.TryGetSymbol(id, false, out symbol, out readOnly))
                    {
                        return true;
                    }
                }
            }
            symbol = null;
            readOnly = true;
            return false;
        }

        internal GreenModel GetModelOf(SymbolId id)
        {
            foreach (var model in this.models)
            {
                if (model.ContainsSymbol(id))
                {
                    return model;
                }
            }
            return null;
        }
    }

}
