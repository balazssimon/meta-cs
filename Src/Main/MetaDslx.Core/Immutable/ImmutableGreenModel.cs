using MetaDslx.Core.Collections.Transactional;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    // GREEN:
    internal class GreenLazyValue
    {
        private Func<object> lazy;

        internal GreenLazyValue(Func<object> lazy)
        {
            this.lazy = lazy;
        }

        internal object CreateValue(MutableRedModelPart part)
        {
            object value = lazy();
            if (value is MutableRedSymbolBase)
            {
                return part.Model.GetRedSymbol(((MutableRedSymbolBase)value).Green);
            }
            else if (value is ImmutableRedSymbolBase)
            {
                return part.Model.GetRedSymbol(((ImmutableRedSymbolBase)value).Green);
            }
            return value;
        }
    }

    internal class GreenLazyList
    {
        private Func<IEnumerable<object>> lazy;

        internal GreenLazyList(Func<IEnumerable<object>> lazy)
        {
            this.lazy = lazy;
        }

        internal List<object> CreateValues(MutableRedModelPart part)
        {
            List<object> result = new List<object>();
            foreach (var item in lazy())
            {
                object value = item;
                if (value is MutableRedSymbolBase)
                {
                    value = part.Model.GetRedSymbol(((MutableRedSymbolBase)value).Green);
                }
                else if (value is ImmutableRedSymbolBase)
                {
                    value = part.Model.GetRedSymbol(((ImmutableRedSymbolBase)value).Green);
                }
                result.Add(value);
            }
            return result;
        }
    }

    // TODO: memory optimization
    internal class GreenSymbol
    {
        private static object Unassigned = new object();

        private SymbolId id;
        private TxValue<SymbolId> parent;
        private TxHashSet<ModelProperty> childProperties;
        private TxList<SymbolId> children;
        private TxDictionary<ModelProperty, object> properties;
        private TxList<ModelProperty> attachedProperties;
        private TxDictionary<SymbolId, TxHashSet<ModelProperty>> references;
        private TxDictionary<ModelProperty, TxDictionary<ModelProperty, object>> childInitializers;

        internal GreenSymbol(SymbolId id)
        {
            Debug.Assert(id != null);
            this.id = id;
            this.parent = new TxValue<SymbolId>();
            this.childProperties = new TxHashSet<ModelProperty>();
            this.children = new TxList<SymbolId>();
            this.properties = new TxDictionary<ModelProperty, object>();
            this.attachedProperties = new TxList<ModelProperty>();
            this.references = new TxDictionary<SymbolId, TxHashSet<ModelProperty>>();
            this.childInitializers = new TxDictionary<ModelProperty, TxDictionary<ModelProperty, object>>();
        }

        internal GreenSymbol(GreenSymbol other)
        {
            Debug.Assert(other != null);
            this.id = other.id;
            this.parent = new TxValue<SymbolId>(other.parent.Value);
            this.childProperties = new TxHashSet<ModelProperty>(other.childProperties);
            this.children = new TxList<SymbolId>(other.children);
            this.properties = new TxDictionary<ModelProperty, object>(other.properties, entry => entry is GreenList ? new GreenList((GreenList)entry) : entry);
            this.attachedProperties = new TxList<ModelProperty>(other.attachedProperties);
            this.references = new TxDictionary<SymbolId, TxHashSet<ModelProperty>>(other.references, entry => new TxHashSet<ModelProperty>(entry));
            this.childInitializers = new TxDictionary<ModelProperty, TxDictionary<ModelProperty, object>>(other.childInitializers, entry => new TxDictionary<ModelProperty, object>(entry));
        }

        public SymbolId Id
        {
            get { return this.id; }
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

        public bool AddProperty(GreenModelPart modelPart, ModelProperty property)
        {
            Debug.Assert(!modelPart.IsReadOnly);
            if (!this.properties.ContainsKey(property))
            {
                property.Init();
                this.properties.Add(property, Unassigned);
                if (property.IsCollection)
                {
                    object value;
                    this.TryGetValueCore(property, false, false, true, out value);
                }
                bool declared = ModelProperty.GetDeclaredPropertiesForType(this.id.MutableType).Contains(property);
                if (!declared)
                {
                    this.attachedProperties.Add(property);
                }
                return true;
            }
            return false;
        }

        public bool RemoveProperty(GreenModelPart modelPart, ModelProperty property)
        {
            Debug.Assert(!modelPart.IsReadOnly);
            if (this.properties.ContainsKey(property))
            {
                bool declared = ModelProperty.GetDeclaredPropertiesForType(this.id.MutableType).Contains(property);
                if (declared)
                {
                    return false;
                }
                else
                {
                    if (property.IsCollection)
                    {
                        this.ClearLazyItems(modelPart, property);
                        this.ClearItems(modelPart, property);
                    }
                    else
                    {
                        this.SetValue(modelPart, property, true, Unassigned);
                    }
                    this.properties.Remove(property);
                    if (!ModelProperty.GetDeclaredPropertiesForType(this.id.MutableType).Contains(property))
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

        public object GetValue(ModelProperty property)
        {
            object value;
            if (this.TryGetValueCore(property, false, false, false, out value))
            {
                return value;
            }
            return null;
        }

        public object GetValue(GreenModelPart modelPart, ModelProperty property, bool lazyEval)
        {
            if (!lazyEval) return this.GetValue(property);
            Debug.Assert(!modelPart.IsReadOnly);
            // TODO: lazy eval related properties
            object value;
            if (this.TryGetValueCore(property, false, true, false, out value))
            {
                if (value is GreenLazyValue)
                {
                    // TODO: eval lazy value
                }
                return value;
            }
            return null;
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

        public bool ClearValue(GreenModelPart modelPart, ModelProperty property)
        {
            Debug.Assert(!modelPart.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (property.IsCollection)
            {
                this.ClearLazyItems(modelPart, property);
                this.ClearItems(modelPart, property);
                return true;
            }
            else
            {
                return this.SetValue(modelPart, property, true, Unassigned);
            }
        }

        public bool ClearLazyValue(GreenModelPart modelPart, ModelProperty property)
        {
            Debug.Assert(!modelPart.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (property.IsCollection)
            {
                this.ClearLazyItems(modelPart, property);
                return true;
            }
            else
            {
                return this.SetValue(modelPart, property, true, Unassigned);
            }
        }

        public bool SetValue(GreenModelPart modelPart, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(!property.IsCollection);
            Debug.Assert(!(value is GreenLazyList));
            Debug.Assert(!modelPart.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            object oldValue;
            if (this.ValueChangedCore(property, value, out oldValue))
            {
                if (!property.HasAffectedProperties || value is GreenLazyValue)
                {
                    return this.SetValueCore(modelPart, property, reassign, value, oldValue);
                }
                else
                {
                    return this.SlowAddValueCore(modelPart, property, null, -1, value, oldValue, null);
                }
            }
            return false;
        }

        public bool AddItem(GreenModelPart modelPart, ModelProperty property, int index, bool replace, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (!property.HasAddAffectedProperties || value is GreenLazyValue || value is GreenLazyList)
            {
                if (replace) this.RemoveValueCore(modelPart, property, null, index, false, null);
                return this.AddValueCore(modelPart, property, null, index, value);
            }
            else
            {
                return this.SlowAddValueCore(modelPart, property, null, index, value, null, null);
            }
        }

        public bool AddItems(GreenModelPart modelPart, ModelProperty property, IEnumerable<object> values)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
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
                    result |= this.AddValueCore(modelPart, property, list, -1, value);
                }
            }
            else
            {
                foreach (var value in values)
                {
                    result |= this.SlowAddValueCore(modelPart, property, list, -1, value, null, null);
                }
            }
            return result;
        }

        public bool RemoveItem(GreenModelPart modelPart, ModelProperty property, int index, bool removeAll, object value)
        {
            Debug.Assert(property != null);
            Debug.Assert(property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
            if (!this.properties.ContainsKey(property)) return false;
            if (!property.HasRemoveAffectedProperties)
            {
                return this.RemoveValueCore(modelPart, property, null, index, removeAll, value);
            }
            else
            {
                return this.SlowRemoveValueCore(modelPart, property, null, index, removeAll, value, null);
            }
        }

        public bool ClearItems(GreenModelPart modelPart, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
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
                    return this.RemoveValueCore(modelPart, property, list, -1, true, item);
                }
            }
            else
            {
                foreach (var item in items)
                {
                    return this.SlowRemoveValueCore(modelPart, property, list, -1, true, item, null);
                }
            }
            return true;
        }

        public bool ClearLazyItems(GreenModelPart modelPart, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
            object listValue;
            if (!this.TryGetValueCore(property, false, false, true, out listValue) || !(listValue is GreenList))
            {
                Debug.Assert(false);
            }
            GreenList list = (GreenList)listValue;
            list.ClearLazyItems();
            modelPart.UnregisterLazyValue(this.id, property);
            return true;
        }

        public bool ChildSetValue(GreenModelPart modelPart, ModelProperty child, ModelProperty property, bool reassign, Func<object> value)
        {
            Debug.Assert(!property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
            TxDictionary<ModelProperty, object> initValues;
            if (!this.childInitializers.TryGetValue(child, out initValues))
            {
                initValues = new TxDictionary<ModelProperty, object>();
                this.childInitializers.Add(child, initValues);
            }
            object initValue;
            if (initValues.TryGetValue(property, out initValue))
            {
                if (!reassign)
                {
                    throw new ModelException("Cannot reassign the child initializer: " + this.id + "::" + child + "::" + property);
                }
            }
            initValue = new GreenLazyValue(value);
            initValues[property] = initValue;
            return true;
        }

        public bool ChildAddItem(GreenModelPart modelPart, ModelProperty child, ModelProperty property, Func<object> value)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
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
            items.Add(new GreenLazyValue(value));
            return true;
        }

        public bool ChildAddItems(GreenModelPart modelPart, ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
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
            items.AddRange(values.Select(v => new GreenLazyValue(v)));
            return true;
        }

        public bool ChildAddItems(GreenModelPart modelPart, ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values)
        {
            Debug.Assert(property.IsCollection);
            Debug.Assert(!modelPart.IsReadOnly);
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
            items.Add(new GreenLazyList(values));
            return true;
        }

        public bool ChildClear(GreenModelPart modelPart, ModelProperty child)
        {
            Debug.Assert(!modelPart.IsReadOnly);
            return this.childInitializers.Remove(child);
        }

        public bool ChildClear(GreenModelPart modelPart, ModelProperty child, ModelProperty property)
        {
            Debug.Assert(!modelPart.IsReadOnly);
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
                    /*foreach (var redefProp in property.RedefinedProperties)
                    {
                        object redefValue;
                        if (this.properties.TryGetValue(redefProp, out redefValue) && redefValue != Unassigned)
                        {
                            this.properties[property] = redefValue;
                            return true;
                        }
                    }
                    foreach (var redefProp in property.RedefiningProperties)
                    {
                        object redefValue;
                        if (this.properties.TryGetValue(redefProp, out redefValue) && redefValue != Unassigned)
                        {
                            this.properties[property] = redefValue;
                            return true;
                        }
                    }*/
                    value = new GreenList(this.id, property);
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

        private bool SetValueCore(GreenModelPart modelPart, ModelProperty property, bool reassign, object value, object oldValue)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(modelPart != null);
            Debug.Assert(!(value is GreenLazyList));
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is RedSymbol));
            Debug.Assert(!(oldValue is GreenLazyList));
            Debug.Assert(!(oldValue is RedSymbol));
            if (value == oldValue) return false;
            if (!reassign)
            {
                if (property.IsReadonly && oldValue != Unassigned)
                {
                    throw new ModelException("Cannot reassign a read-only property: " + this.id + "::" + property);
                }
                if (oldValue is GreenLazyValue)
                {
                    throw new ModelException("Cannot reassign a lazy-valued property: " + this.id + "::" + property);
                }
            }
            if (value == null && property.IsNonNull)
            {
                throw new ModelException("Null value cannot be assigned to property: " + this.id + "::" + property);
            }
            if (oldValue != null && oldValue != Unassigned)
            {
                if (oldValue is SymbolId)
                {
                    GreenSymbol oldSymbol;
                    bool readOnly;
                    if (modelPart.TryGetSymbol((SymbolId)oldValue, true, true, out oldSymbol, out readOnly) && !readOnly)
                    {
                        this.RemoveReferenceCore(modelPart, property, oldSymbol);
                    }
                }
                else if (oldValue is GreenLazyValue)
                {
                    modelPart.UnregisterLazyValue(this.id, property);
                }
            }
            if (value == null || value == Unassigned ||
                ((value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                (!(value is SymbolId) && (property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType()))))
            {
                this.properties[property] = value;
            }
            else
            {
                throw new ModelException("Value of type '"+value.GetType()+"' cannot be assigned to property "+ this.id + "::" + property + " of type '"+ property.MutableTypeInfo.Type+"'.");
            }
            if (value != null && value != Unassigned)
            {
                if (value is SymbolId)
                {
                    GreenSymbol valueSymbol;
                    bool readOnly;
                    if (modelPart.TryGetSymbol((SymbolId)value, true, true, out valueSymbol, out readOnly))
                    {
                        if (!readOnly)
                        {
                            bool addedAsChild;
                            this.AddReferenceCore(modelPart, property, valueSymbol, out addedAsChild);
                            if (addedAsChild)
                            {
                                this.InitChildCore(modelPart, property, valueSymbol);
                            }
                        }
                    }
                    else
                    {
                        throw new ModelException("Cannot find referenced symbol '" + value + "' for property: " + this.id + "::" + property);
                    }
                }
                else if (value is GreenLazyValue)
                {
                    modelPart.RegisterLazyValue(this.id, property);
                }
            }
            return true;
        }

        private bool AddValueCore(GreenModelPart modelPart, ModelProperty property, GreenList list, int index, object value)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(modelPart != null);
            Debug.Assert(value != Unassigned);
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is RedSymbol));
            if (value == null && property.IsNonNull)
            {
                throw new ModelException("Null value cannot added to property: " + this.id + "::" + property);
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
                modelPart.RegisterLazyValue(this.id, property);
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
                    GreenSymbol valueSymbol;
                    bool readOnly;
                    if (modelPart.TryGetSymbol((SymbolId)value, true, true, out valueSymbol, out readOnly))
                    {
                        if (!readOnly)
                        {
                            bool addedAsChild;
                            this.AddReferenceCore(modelPart, property, valueSymbol, out addedAsChild);
                            if (addedAsChild)
                            {
                                this.InitChildCore(modelPart, property, valueSymbol);
                            }
                        }
                    }
                    else
                    {
                        throw new ModelException("Cannot find referenced symbol '" + value + "' for property: " + this.id + "::" + property);
                    }
                }
                return added;
            }
        }

        private bool RemoveValueCore(GreenModelPart modelPart, ModelProperty property, GreenList list, int index, bool removeAll, object value)
        {
            Debug.Assert(this.properties.ContainsKey(property));
            Debug.Assert(modelPart != null);
            Debug.Assert(value != Unassigned);
            Debug.Assert(!(value is GreenSymbol));
            Debug.Assert(!(value is RedSymbol));
            Debug.Assert(!(index >= 0 && removeAll));
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
                GreenSymbol valueSymbol;
                bool readOnly;
                if (modelPart.TryGetSymbol((SymbolId)value, true, true, out valueSymbol, out readOnly))
                {
                    if (!readOnly)
                    {
                        this.RemoveReferenceCore(modelPart, property, valueSymbol);
                    }
                }
                else
                {
                    throw new ModelException("Cannot find referenced symbol '" + value + "' for property: " + this.id + "::" + property);
                }
            }
            return result;
        }

        private bool SlowAddValueCore(GreenModelPart modelPart, ModelProperty property, GreenList list, int index, object value, object oldValue, ChangeInfo change)
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
                    removed = this.RemoveValueCore(modelPart, property, list, index, false, oldValue);
                }
                else
                {
                    removed = this.SetValueCore(modelPart, property, false, null, oldValue);
                }
                if (removed)
                {
                    if (property.HasRemoveAffectedProperties)
                    {
                        foreach (var remProp in property.RemoveAffectedProperties)
                        {
                            this.SlowRemoveValueCore(modelPart, remProp, null, -1, false, oldValue, change);
                        }
                        foreach (var remProp in property.RemoveAffectedOptionalProperties)
                        {
                            this.SlowRemoveValueCore(modelPart, remProp, null, -1, false, oldValue, change);
                        }
                    }
                    if (property.HasOppositeProperties && oldValue is SymbolId)
                    {
                        GreenSymbol oldSymbol;
                        bool readOnly;
                        if (modelPart.TryGetSymbol((SymbolId)oldValue, true, true, out oldSymbol, out readOnly))
                        {
                            if (!readOnly)
                            {
                                foreach (var oppProp in property.OppositeProperties)
                                {
                                    oldSymbol.SlowRemoveValueCore(modelPart, oppProp, null, -1, false, this.id, change.oldOpposite);
                                }
                            }
                        }
                        else
                        {
                            throw new ModelException("Cannot find opposite symbol '" + oldValue + "' for property: " + this.id + "::" + property);
                        }
                    }
                }
            }
            bool result;
            if (property.IsCollection)
            {
                result = this.AddValueCore(modelPart, property, list, index, value);
            }
            else
            {
                result = this.SetValueCore(modelPart, property, false, value, null);
            }
            if (result)
            {
                if (property.HasAddAffectedProperties)
                {
                    foreach (var addProp in property.AddAffectedProperties)
                    {
                        this.SlowAddValueCore(modelPart, addProp, null, -1, value, null, change);
                    }
                    foreach (var addProp in property.AddAffectedOptionalProperties)
                    {
                        if (value == null ||
                            ((value is SymbolId) && (addProp.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).MutableType))) ||
                            (!(value is SymbolId) && (addProp.MutableTypeInfo.Type.IsAssignableFrom(value.GetType()))))
                        {
                            this.SlowAddValueCore(modelPart, addProp, null, -1, value, null, change);
                        }
                    }
                }
                if (property.HasOppositeProperties && value is SymbolId)
                {
                    GreenSymbol oppSymbol;
                    bool readOnly;
                    if (modelPart.TryGetSymbol((SymbolId)value, true, true, out oppSymbol, out readOnly))
                    {
                        if (!readOnly)
                        {
                            foreach (var oppProp in property.OppositeProperties)
                            {
                                object oldOppValue = oppSymbol.GetValue(oppProp);
                                if (oppProp.IsCollection)
                                {
                                    GreenList oldOppList = oldOppValue as GreenList;
                                    if (oldOppList != null && !oldOppList.Contains(this.id))
                                    {
                                        oppSymbol.SlowAddValueCore(modelPart, oppProp, oldOppList, -1, this.id, null, change.newOpposite);
                                    }
                                }
                                else
                                {
                                    if (oldOppValue != this)
                                    {
                                        oppSymbol.SlowAddValueCore(modelPart, oppProp, null, -1, this.id, oldOppValue, change.newOpposite);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new ModelException("Cannot find opposite symbol '" + value + "' for property: " + this.id + "::" + property);
                    }
                }
            }
            return result;
        }

        private bool SlowRemoveValueCore(GreenModelPart modelPart, ModelProperty property, GreenList list, int index, bool removeAll, object value, ChangeInfo change)
        {
            Debug.Assert(!(value is GreenLazyValue || value is GreenLazyList || value is GreenList));
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
                result = this.RemoveValueCore(modelPart, property, list, index, removeAll, value);
            }
            else
            {
                result = this.SetValueCore(modelPart, property, false, null, value);
            }
            if (result)
            {
                if (property.HasRemoveAffectedProperties)
                {
                    foreach (var remProp in property.RemoveAffectedProperties)
                    {
                        this.SlowRemoveValueCore(modelPart, remProp, null, -1, removeAll, value, change);
                    }
                    foreach (var remProp in property.RemoveAffectedOptionalProperties)
                    {
                        this.SlowRemoveValueCore(modelPart, remProp, null, -1, removeAll, value, change);
                    }
                }
                if (property.HasOppositeProperties && value is SymbolId)
                {
                    GreenSymbol oppSymbol;
                    bool readOnly;
                    if (modelPart.TryGetSymbol((SymbolId)value, true, true, out oppSymbol, out readOnly))
                    {
                        if (!readOnly)
                        {
                            foreach (var oppProp in property.OppositeProperties)
                            {
                                oppSymbol.SlowRemoveValueCore(modelPart, oppProp, null, -1, removeAll, this.id, change.oldOpposite);
                            }
                        }
                    }
                    else
                    {
                        throw new ModelException("Cannot find opposite symbol '" + value + "' for property: " + this.id + "::" + property);
                    }
                }
            }
            return result;
        }

        private void AddReferenceCore(GreenModelPart modelPart, ModelProperty property, GreenSymbol value, out bool addedAsChild)
        {
            Debug.Assert(property != null);
            Debug.Assert(value != null);
            addedAsChild = false;
            TxHashSet<ModelProperty> properties;
            if (!value.references.TryGetValue(this.id, out properties))
            {
                properties = new TxHashSet<ModelProperty>();
                value.references.Add(this.id, properties);
            }
            properties.Add(property);
            if (property.IsContainment)
            {
                if (value.parent.Value != null && value.parent.Value != this.id)
                {
                    throw new ModelException("Invalid containment in " + this.id + "::" + property + ": symbol '" + value + "' is already contained by '" + value.parent.Value + "'.");
                }
                this.childProperties.Add(property);
                if (!this.children.Contains(value.id))
                {
                    this.children.Add(value.id);
                    value.parent.Value = this.id;
                    addedAsChild = true;
                }
            }
        }

        private void RemoveReferenceCore(GreenModelPart modelPart, ModelProperty property, GreenSymbol value)
        {
            Debug.Assert(property != null);
            Debug.Assert(value != null);
            TxHashSet<ModelProperty> properties;
            if (value.references.TryGetValue(this.id, out properties))
            {
                properties.Remove(property);
            }
            Debug.Assert(properties != null);
            if (property.IsContainment)
            {
                bool lostParent = !this.childProperties.Overlaps(properties);
                if (lostParent)
                {
                    this.children.Remove(value.id);
                    value.parent.Value = null;
                }
            }
        }

        private void InitChildCore(GreenModelPart modelPart, ModelProperty childProperty, GreenSymbol child)
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
                            child.AddItems(modelPart, initValue.Key, values);
                        }
                    }
                    else
                    {
                        child.SetValue(modelPart, initValue.Key, false, initValue.Value);
                    }
                }
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

    internal class GreenModelPart
    {
        private GreenModel model;
        private GreenModelPart baseModelPart;
        private TxValue<bool> changed;
        private TxDictionary<SymbolId, GreenSymbol> symbols;
        private TxDictionary<ModelProperty, TxHashSet<SymbolId>> lazyIndex;

        internal GreenModelPart(GreenModel model)
        {
            this.model = model;
            this.changed = new TxValue<bool>(false);
            this.symbols = new TxDictionary<SymbolId, GreenSymbol>();
            this.lazyIndex = new TxDictionary<ModelProperty, TxHashSet<SymbolId>>();
        }

        internal GreenModelPart(GreenModel model, GreenModelPart baseModelPart, bool deepCopy)
        {
            this.model = model;
            this.baseModelPart = deepCopy ? null : baseModelPart;
            this.changed = new TxValue<bool>(false);
            this.symbols = deepCopy ?
                new TxDictionary<SymbolId, GreenSymbol>(baseModelPart.symbols, symbol => new GreenSymbol(symbol)) :
                new TxDictionary<SymbolId, GreenSymbol>(baseModelPart.symbols, symbol => null);
            this.lazyIndex = new TxDictionary<ModelProperty, TxHashSet<SymbolId>>(baseModelPart.lazyIndex, symbols => new TxHashSet<SymbolId>(symbols));
        }

        internal bool IsChanged
        {
            get { return this.changed.Value; }
        }

        internal bool IsReadOnly
        {
            get { return this.model.IsReadOnly; }
        }

        internal IEnumerable<SymbolId> Symbols
        {
            get { return this.symbols.Keys; }
        }

        internal bool TryGetSymbol(SymbolId id, bool forWriting, bool lookupInModel, out GreenSymbol symbol, out bool readOnly)
        {
            Debug.Assert(id != null);
            //Debug.Assert(!this.model.IsReadOnly || !forWriting);
            if (this.symbols.TryGetValue(id, out symbol))
            {
                if (symbol != null)
                {
                    readOnly = this.model.IsReadOnly;
                    return true;
                }
                GreenSymbol baseSymbol;
                if (this.baseModelPart != null && this.baseModelPart.TryGetSymbol(id, false, lookupInModel, out baseSymbol, out readOnly))
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
            else if (lookupInModel)
            {
                if (this.model.ModelPartCrossReference)
                {
                    return this.model.TryGetSymbol(this, id, forWriting, out symbol, out readOnly);
                }
                else
                {
                    throw new ModelException("Cross references in model parts is not allowed. Enable 'ModelPartCrossReference' in the model.");
                }
            }
            symbol = null;
            readOnly = true;
            return false;
        }

        private GreenSymbol GetSymbol(SymbolId id, bool forWriting)
        {
            GreenSymbol symbol;
            bool readOnly;
            if (this.TryGetSymbol(id, forWriting, false, out symbol, out readOnly))
            {
                if (readOnly && forWriting) return null;
                return symbol;
            }
            return null;
        }

        internal void AddSymbol(SymbolId id)
        {
            Debug.Assert(id != null);
            this.symbols.Add(id, new GreenSymbol(id));
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

        internal void RegisterLazyValue(SymbolId id, ModelProperty property)
        {
            Debug.Assert(id != null);
            Debug.Assert(property != null);
            Debug.Assert(this.symbols.ContainsKey(id));
            TxHashSet<SymbolId> symbols;
            if (!this.lazyIndex.TryGetValue(property, out symbols))
            {
                symbols = new TxHashSet<SymbolId>();
                this.lazyIndex.Add(property, symbols);
            }
            symbols.Add(id);
            // TODO: cross-ref model parts
        }

        internal void UnregisterLazyValue(SymbolId id, ModelProperty property)
        {
            Debug.Assert(id != null);
            Debug.Assert(property != null);
            Debug.Assert(this.symbols.ContainsKey(id));
            TxHashSet<SymbolId> symbols;
            if (this.lazyIndex.TryGetValue(property, out symbols) && symbols != null)
            {
                symbols.Remove(id);
                if (symbols.Count == 0)
                {
                    this.lazyIndex.Remove(property);
                }
            }
            // TODO: cross-ref model parts
        }

        internal bool ContainsSymbol(SymbolId id)
        {
            return this.symbols.ContainsKey(id);
        }

        internal object GetValue(SymbolId id, ModelProperty property, bool lazyEval)
        {
            GreenSymbol symbol = this.GetSymbol(id, lazyEval);
            if (symbol != null)
            {
                return symbol.GetValue(this, property, lazyEval);
            }
            return null;
        }

        internal bool SetValue(SymbolId id, ModelProperty property, bool reassign, object value)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.SetValue(this, property, reassign, value);
            }
            return false;
        }

        internal bool AddItem(SymbolId id, ModelProperty property, int index, bool replace, object value)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.AddItem(this, property, index, replace, value);
            }
            return false;
        }

        internal bool RemoveItem(SymbolId id, ModelProperty property, int index, bool removeAll, object value)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.RemoveItem(this, property, index, removeAll, value);
            }
            return false;
        }

        internal bool ClearItems(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.ClearItems(this, property);
            }
            return false;
        }

        internal bool ClearLazyItems(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.ClearLazyItems(this, property);
            }
            return false;
        }

        internal void EvaluateLazyValues()
        {
            // TODO
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

        internal bool MAdd(SymbolId id, ModelProperty property, object value)
        {
            if (property.IsCollection)
            {
                return this.AddItem(id, property, -1, false, value);
            }
            else
            {
                bool result = this.SetValue(id, property, false, value);
                return result;
            }
        }

        internal bool MClear(SymbolId id, ModelProperty property, bool clearLazy)
        {
            throw new NotImplementedException();
        }

        internal bool MClearLazy(SymbolId id, ModelProperty property)
        {
            throw new NotImplementedException();
        }

        internal bool MReset(SymbolId id, ModelProperty property, object value)
        {
            throw new NotImplementedException();
        }

        internal bool AddItems(SymbolId id, ModelProperty property, IEnumerable<object> values)
        {
            throw new NotImplementedException();
        }

        internal bool MAttachProperty(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.AddProperty(this, property);
            }
            return false;
        }

        internal bool MDetachProperty(SymbolId id, ModelProperty property)
        {
            GreenSymbol symbol = this.GetSymbol(id, true);
            if (symbol != null)
            {
                return symbol.RemoveProperty(this, property);
            }
            return false;
        }

        internal void MEvaluateLazy(SymbolId id)
        {
            throw new NotImplementedException();
        }

        internal bool MChildLazySet(SymbolId id, ModelProperty child, ModelProperty property, GreenLazyValue value)
        {
            throw new NotImplementedException();
        }

        internal bool MChildLazyAddRange(SymbolId id, ModelProperty child, ModelProperty property, GreenLazyList values)
        {
            throw new NotImplementedException();
        }

        internal bool MChildLazyAddRange(SymbolId id, ModelProperty child, ModelProperty property, IEnumerable<GreenLazyValue> values)
        {
            throw new NotImplementedException();
        }

        internal bool MChildLazyClear(SymbolId id, ModelProperty child)
        {
            throw new NotImplementedException();
        }

        internal bool MChildLazyClear(SymbolId id, ModelProperty child, ModelProperty property)
        {
            throw new NotImplementedException();
        }

        internal bool MRemove(SymbolId id, ModelProperty property, object value, bool removeAll)
        {
            throw new NotImplementedException();
        }

        internal void MUnset(SymbolId id, ModelProperty property)
        {
            throw new NotImplementedException();
        }
    }

    internal class GreenModel
    {
        private static readonly IReadOnlyList<SymbolId> emptySymbolList = new List<SymbolId>();
        private static readonly IReadOnlyList<SymbolId> emptyPropertyList = new List<SymbolId>();
        private bool readOnly = false;
        private GreenModel baseModel;
        private TxValue<GreenModelPart> singlePart;
        private TxHashSet<GreenModelPart> parts;
        private TxValue<bool> modelPartCrossReference;
        private TxValue<LazyEvaluationMode> lazyEvalMode;

        internal GreenModel()
        {
            this.singlePart = new TxValue<GreenModelPart>(new GreenModelPart(this));
            this.parts = new TxHashSet<GreenModelPart>();
            this.modelPartCrossReference = new TxValue<bool>(true);
            this.lazyEvalMode = new TxValue<LazyEvaluationMode>(LazyEvaluationMode.Evaluate);
        }

        internal GreenModel(GreenModel baseModel, bool readOnly, bool deepCopy)
        {
            this.readOnly = readOnly;
            if (readOnly && !baseModel.IsReadOnly) deepCopy = true;
            this.baseModel = deepCopy ? null : baseModel;
            this.singlePart = baseModel.singlePart.Value != null ? new TxValue<GreenModelPart>(new GreenModelPart(this, baseModel.singlePart.Value, deepCopy)) : new TxValue<GreenModelPart>(null);
            this.parts = new TxHashSet<GreenModelPart>(baseModel.parts.Select(part => new GreenModelPart(this, part, deepCopy)));
            this.modelPartCrossReference = new TxValue<bool>(baseModel.modelPartCrossReference.Value);
            this.lazyEvalMode = new TxValue<LazyEvaluationMode>(baseModel.lazyEvalMode.Value);
        }

        internal bool IsReadOnly
        {
            get { return this.readOnly; }
        }

        internal bool IsChanged
        {
            get
            {
                if (this.singlePart.Value != null)
                {
                    return this.singlePart.Value.IsChanged;
                }
                else
                {
                    foreach (var part in this.parts)
                    {
                        if (part.IsChanged) return true;
                    }
                }
                return false;
            }
        }

        internal GreenModel BaseModel
        {
            get { return this.baseModel; }
        }

        internal bool ModelPartCrossReference
        {
            get { return this.modelPartCrossReference.Value; }
            set
            {
                Debug.Assert(!this.readOnly);
                this.modelPartCrossReference.Value = value;
            }
        }

        internal LazyEvaluationMode LazyMode
        {
            get { return this.lazyEvalMode.Value; }
            set
            {
                Debug.Assert(!this.readOnly);
                this.lazyEvalMode.Value = value;
            }
        }

        internal bool TryGetSymbol(GreenModelPart callerModelPart, SymbolId id, bool forWriting, out GreenSymbol symbol, out bool readOnly)
        {
            //Debug.Assert(!this.readOnly || !forWriting);
            if (this.singlePart.Value != null)
            {
                if (this.singlePart.Value != callerModelPart)
                {
                    if (this.singlePart.Value.TryGetSymbol(id, forWriting, false, out symbol, out readOnly))
                    {
                        return true;
                    }
                }
            }
            else 
            {
                foreach (var part in this.parts)
                {
                    if (part != callerModelPart)
                    {
                        if (part.TryGetSymbol(id, forWriting, false, out symbol, out readOnly))
                        {
                            return true;
                        }
                    }
                }
            }
            symbol = null;
            readOnly = true;
            return false;
        }

        internal void EvaluateLazyValues()
        {
            // TODO
        }

        public GreenModel Fork(bool finish)
        {
            if (finish)
            {
                this.readOnly = true;
                return this;
            }
            else
            {
                return new GreenModel(this, true, true);
            }
        }

        public bool ContainsSymbol(SymbolId id)
        {
            if (this.singlePart.Value != null)
            {
                return this.singlePart.Value.ContainsSymbol(id);
            }
            else
            {
                foreach (var part in this.parts)
                {
                    if (part.ContainsSymbol(id)) return true;
                }
            }
            return false;
        }

        public IEnumerable<SymbolId> GetSymbols()
        {
            if (this.singlePart.Value != null)
            {
                foreach (var symbol in this.singlePart.Value.Symbols)
                {
                    yield return symbol;
                }
            }
            else
            {
                foreach (var part in this.parts)
                {
                    foreach (var symbol in part.Symbols)
                    {
                        yield return symbol;
                    }
                }
            }
        }

        public IEnumerable<GreenModelPart> GetParts()
        {
            if (this.singlePart.Value != null)
            {
                return new GreenModelPart[] { this.singlePart.Value };
            }
            else
            {
                return this.parts;
            }
        }
    }

}
