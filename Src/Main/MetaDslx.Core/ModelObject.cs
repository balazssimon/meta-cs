using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    public abstract class ModelObject
    {
        private ModelProperty nameProperty = null;

        private Dictionary<ModelProperty, WeakReference<object>> defaultValues;
        private Dictionary<ModelProperty, object> values;
        private Dictionary<ModelProperty, Lazy<object>> initializers;
        private Dictionary<ModelProperty, Func<object>> derivedValues;
        private Dictionary<ModelProperty, Dictionary<ModelProperty, Lazy<object>>> childInitializers;

        public ModelObject()
            : this(true)
        {
        }

        public ModelObject(bool addToModelContext)
        {
            if (addToModelContext)
            {
                if (ModelContext.HasContext())
                {
                    ModelContext.Current.AddInstance(this);
                }
            }
            this.MetaID = Guid.NewGuid().ToString();
            this.values = new Dictionary<ModelProperty, object>();
            this.initializers = new Dictionary<ModelProperty, Lazy<object>>();
            this.derivedValues = new Dictionary<ModelProperty, Func<object>>();
            this.childInitializers = new Dictionary<ModelProperty, Dictionary<ModelProperty, Lazy<object>>>();
        }

        public virtual MetaModel MMetaModel
        {
            get { return null; }
        }

        public virtual MetaClass MMetaClass
        {
            get { return null; }
        }

        public Model MModel { get; internal set; }

        public void MEvalLazyValues()
        {
            List<ModelProperty> properties = this.initializers.Keys.ToList();
            foreach (var property in properties)
            {
                this.MGet(property);
            }
            properties = this.values.Keys.ToList();
            foreach (var property in properties)
            {
                object value = this.MGet(property);
                ModelCollection collection = value as ModelCollection;
                if (collection != null)
                {
                    collection.MFlushLazyItems();
                }
            }
        }

        public bool MHasUninitializedValue()
        {
            HashSet<ModelProperty> lazyProperties = new HashSet<ModelProperty>(this.initializers.Keys);
            HashSet<ModelProperty> valueProperties = new HashSet<ModelProperty>(this.values.Keys);
            List<ModelProperty> diff = lazyProperties.Except(valueProperties).ToList();
            if (diff.Count > 0) return true;
            foreach (var property in valueProperties)
            {
                object value = this.MGet(property);
                ModelCollection collection = value as ModelCollection;
                if (collection != null)
                {
                    if (collection.MHasLazyItems()) return true;
                }
            }
            return false;
        }

        public void MMakeDefault()
        {
            this.defaultValues = new Dictionary<ModelProperty, WeakReference<object>>();
            foreach (var entry in this.values)
            {
                this.defaultValues.Add(entry.Key, new WeakReference<object>(entry.Value));
            }
        }

        public bool MIsDefault(ModelProperty property)
        {
            object currentValue = null;
            this.values.TryGetValue(property, out currentValue);
            object defaultValue = null;
            bool lostDefaultValue = false;
            if (this.defaultValues != null)
            {
                WeakReference<object> containedValue = null;
                if (this.defaultValues.TryGetValue(property, out containedValue))
                {
                    if (!containedValue.TryGetTarget(out defaultValue))
                    {
                        lostDefaultValue = true;
                    }
                }
            }
            if (!lostDefaultValue && defaultValue == null && currentValue == null) return true;
            else if (lostDefaultValue || defaultValue == null || currentValue == null) return false;
            else return object.ReferenceEquals(defaultValue, currentValue);
        }

        public bool MIsValueCreated(ModelProperty property)
        {
            return this.values.ContainsKey(property) || this.derivedValues.ContainsKey(property);
        }

        public bool MIsSet(ModelProperty property)
        {
            return this.values.ContainsKey(property) || this.initializers.ContainsKey(property)
                || this.derivedValues.ContainsKey(property);
        }

        public void MUnSet(ModelProperty property)
        {
            object oldValue;
            if (this.values.TryGetValue(property, out oldValue))
            {
                if (property.IsCollection && oldValue is ModelCollection)
                {
                    ((ModelCollection)oldValue).Clear();
                }
                else
                {
                    this.MRemove(property, oldValue);
                }
            }
            this.values.Remove(property);
            this.initializers.Remove(property);
        }

        public void MDerivedSet(ModelProperty property, Func<object> value)
        {
            this.derivedValues[property] = value;
        }

        public void MLazySet(ModelProperty property, Lazy<object> value)
        {
            object oldValue;
            if (this.values.TryGetValue(property, out oldValue))
            {
                if (property.IsCollection)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a collection property '" + property.ToString() + "'. Consider adding the items instead.");
                }
                else if (property.IsReadonly)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                }
                else
                {
                    this.MRemove(property, oldValue);
                }
            }
            this.values.Remove(property);
            this.initializers[property] = value;
        }

        public void MLazySetChild(ModelProperty child, ModelProperty property, Lazy<object> value)
        {
            Dictionary<ModelProperty, Lazy<object>> childProperties = null;
            if (!this.childInitializers.TryGetValue(child, out childProperties))
            {
                childProperties = new Dictionary<ModelProperty, Lazy<object>>();
                this.childInitializers.Add(child, childProperties);
            }
            Lazy<object> oldValue;
            if (childProperties.TryGetValue(property, out oldValue))
            {
                if (property.IsReadonly)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                }
                else
                {
                    childProperties.Remove(property);
                }
            }
            childProperties[property] = value;
            object childObject;
            if (this.values.TryGetValue(child, out childObject))
            {
                ModelObject childModelObject = childObject as ModelObject;
                if (childModelObject != null)
                {
                    childModelObject.MLazyAdd(property, value);
                }
            }
        }

        public void MSet(ModelProperty property, object newValue)
        {
            object oldValue;
            if (this.values.TryGetValue(property, out oldValue))
            {
                if (newValue == oldValue) return;
                if (property.IsCollection)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a collection property '" + property.ToString() + "'. Consider adding the items instead.");
                }
                else if (property.IsReadonly)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                }
            }
            if (newValue is ModelCollection)
            {
                this.values[property] = newValue;
            }
            else
            {
                this.MAdd(property, newValue);
            }
        }

        public object MGet(ModelProperty property, bool evalLazyValue = true)
        {
            object value;
            if (this.values.TryGetValue(property, out value))
            {
                return value;
            }
            else
            {
                Lazy<object> initializer;
                Func<object> derived;
                if (evalLazyValue && this.initializers.TryGetValue(property, out initializer))
                {
                    try
                    {
                        value = initializer.Value;
                    }
                    catch(InvalidOperationException ex)
                    {
                        if (ex.Message != null && ex.Message.Contains("ValueFactory"))
                        {
                            IModelCompiler compiler = ModelCompilerContext.Current;
                            if (compiler != null)
                            {
                                compiler.Diagnostics.AddWarning("The property '" + property + "' of '"+this+"' was accessed in a circular dependency.", compiler.FileName, this, true);
                            }
                            return null;
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                    this.values[property] = value;
                    if (!(value is ModelCollection))
                    {
                        this.MAdd(property, value);
                    }
                    return value;
                }
                else if (this.derivedValues.TryGetValue(property, out derived))
                {
                    return derived.Invoke();
                }
            }
            return null;
        }

        public ISet<ModelProperty> MGetProperties()
        {
            HashSet<ModelProperty> result = new HashSet<ModelProperty>(ModelProperty.GetPropertiesForType(this.GetType()));
            foreach (ModelProperty prop in this.values.Keys)
            {
                if (!result.Any(p => p.Name == prop.Name))
                {
                    result.Add(prop);
                }
            }
            foreach (ModelProperty prop in this.initializers.Keys)
            {
                if (!result.Any(p => p.Name == prop.Name))
                {
                    result.Add(prop);
                }
            }
            return result;
        }

        public ISet<ModelProperty> MGetAllProperties()
        {
            HashSet<ModelProperty> result = new HashSet<ModelProperty>(ModelProperty.GetAllPropertiesForType(this.GetType()));
            foreach (ModelProperty prop in this.values.Keys)
            {
                result.Add(prop);
            }
            foreach (ModelProperty prop in this.initializers.Keys)
            {
                result.Add(prop);
            }
            return result;
        }

        public ModelProperty MFindProperty(string name)
        {
            return this.MGetProperties().FirstOrDefault(p => p.Name == name);
        }

        public IEnumerable<ModelProperty> MFindProperties(string name)
        {
            var results =
                from p in this.MGetAllProperties()
                where p.Name == name
                select p;
            return results.ToList();
        }

        public string MetaID
        {
            get;
            set;
        }

        public void MLazyAdd(ModelProperty property, Lazy<object> value)
        {
            object oldValue;
            if (property.IsCollection && !this.values.ContainsKey(property))
            {
                // Initializing lazy collection:
                this.MGet(property);
            }
            if (this.values.TryGetValue(property, out oldValue))
            {
                ModelCollection collection = oldValue as ModelCollection;
                if (collection != null)
                {
                    collection.MLazyAdd(value);
                    return;
                }
                else if (property.IsReadonly)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                }
                else
                {
                    this.MRemove(property, oldValue);
                    this.values.Remove(property);
                }
            }
            this.initializers[property] = value;
        }

        public void MAdd(ModelProperty property, object value)
        {
            this.MOnAddValue(property, value, true);
        }

        public void MRemove(ModelProperty property, object value)
        {
            this.MOnRemoveValue(property, value, true);
        }

        internal void MOnAddValue(ModelProperty property, object value, bool firstCall, AddRemoveDirection addRemoveDir = AddRemoveDirection.None)
        {
            if (this.nameProperty == null && property.IsMetaName())
            {
                this.nameProperty = property;
            }
            bool added = false;
            object oldValue = this.MGet(property);
            ModelCollection collection = oldValue as ModelCollection;
            if (collection != null)
            {
                if (value != null && collection.MAdd(value, false))
                {
                    added = true;
                }
                else if (value != null && firstCall)
                {
                    added = true;
                }
            }
            else
            {
                if (value != oldValue)
                {
                    if (oldValue != null)
                    {
                        this.MOnRemoveValue(property, oldValue, false);
                    }
                    this.values[property] = value;
                    added = value != null;
                }
                else
                {
                    added = value != null && firstCall;
                }
            }
            if (added)
            {
                ModelObject modelObjectValue = value as ModelObject;
                if (modelObjectValue != null)
                {
                    if (property.IsContainment)
                    {
                        modelObjectValue.MParent = this;
                    }
                    Dictionary<ModelProperty, Lazy<object>> childProperties = null;
                    if (this.childInitializers.TryGetValue(property, out childProperties))
                    {
                        foreach (var childProp in childProperties)
                        {
                            modelObjectValue.MLazyAdd(childProp.Key, childProp.Value);
                        }
                    }
                }

                var allProperies = this.MGetAllProperties();
                var cachedSubsettedProperties = property.SubsettedProperties;
                foreach (ModelProperty subsettedProperty in cachedSubsettedProperties)
                {
                    if (allProperies.Contains(subsettedProperty))
                    {
                        this.MOnAddValue(subsettedProperty, value, true);
                    }
                }
                if (addRemoveDir != AddRemoveDirection.Redefined)
                {
                    var cachedRedefiningProperties = property.RedefiningProperties;
                    foreach (ModelProperty redefiningProperty in cachedRedefiningProperties)
                    {
                        if (allProperies.Contains(redefiningProperty))
                        {
                            this.MOnAddValue(redefiningProperty, value, true, AddRemoveDirection.Redefining);
                        }
                    }
                }
                if (addRemoveDir != AddRemoveDirection.Redefining)
                {
                    var cachedRedefinedProperties = property.RedefinedProperties;
                    foreach (ModelProperty redefinedProperty in cachedRedefinedProperties)
                    {
                        if (allProperies.Contains(redefinedProperty))
                        {
                            this.MOnAddValue(redefinedProperty, value, true, AddRemoveDirection.Redefined);
                        }
                    }
                }
                var cachedOppositeProperties = property.OppositeProperties;
                if (cachedOppositeProperties.Any())
                {
                    ModelObject oppositeObject = value as ModelObject;
                    if (oppositeObject != null)
                    {
                        var allOppositeProperies = oppositeObject.MGetAllProperties();
                        foreach (ModelProperty oppositeProperty in cachedOppositeProperties)
                        {
                            if (allOppositeProperies.Contains(oppositeProperty))
                            {
                                oppositeObject.MOnAddValue(oppositeProperty, this, false);
                            }
                        }
                    }
                    else
                    {
                        throw new ModelException("Error adding the current object " + this.GetType().Name + "." + property.Name + " to the opposite object. The current value must be a descendant of " + typeof(ModelObject) + ".");
                    }
                }
            }
        }

        internal void MOnRemoveValue(ModelProperty property, object value, bool firstCall, AddRemoveDirection addRemoveDir = AddRemoveDirection.None)
        {
            bool removed = false;
            object oldValue = this.MGet(property);
            ModelCollection collection = oldValue as ModelCollection;
            if (collection != null)
            {
                if (value != null && collection.MRemove(value, false))
                {
                    removed = true;
                }
                else if (value != null && firstCall)
                {
                    removed = true;
                }
            }
            else
            {
                if (value == oldValue) 
                {
                    this.values[property] = null;
                    removed = value != null;
                }
            }
            if (removed)
            {
                if (property.IsContainment)
                {
                    ModelObject modelObjectValue = value as ModelObject;
                    if (modelObjectValue != null)
                    {
                        modelObjectValue.MParent = null;
                    }
                }

                var allProperies = this.MGetAllProperties();
                var cachedSubsettingProperties = property.SubsettingProperties;
                foreach (ModelProperty subsettingProperty in cachedSubsettingProperties)
                {
                    if (allProperies.Contains(subsettingProperty))
                    {
                        this.MOnRemoveValue(subsettingProperty, value, true);
                    }
                }
                if (addRemoveDir != AddRemoveDirection.Redefined)
                {
                    var cachedRedefiningProperties = property.RedefiningProperties;
                    foreach (ModelProperty redefiningProperty in cachedRedefiningProperties)
                    {
                        if (allProperies.Contains(redefiningProperty))
                        {
                            this.MOnRemoveValue(redefiningProperty, value, true, AddRemoveDirection.Redefining);
                        }
                    }
                }
                if (addRemoveDir != AddRemoveDirection.Redefining)
                {
                    var cachedRedefinedProperties = property.RedefinedProperties;
                    foreach (ModelProperty redefinedProperty in cachedRedefinedProperties)
                    {
                        if (allProperies.Contains(redefinedProperty))
                        {
                            this.MOnRemoveValue(redefinedProperty, value, true, AddRemoveDirection.Redefined);
                        }
                    }
                }
                var cachedOppositeProperties = property.OppositeProperties;
                if (cachedOppositeProperties.Any())
                {
                    ModelObject oppositeObject = value as ModelObject;
                    if (oppositeObject != null)
                    {
                        var allOppositeProperies = oppositeObject.MGetAllProperties();
                        foreach (ModelProperty oppositeProperty in cachedOppositeProperties)
                        {
                            if (allOppositeProperies.Contains(oppositeProperty))
                            {
                                oppositeObject.MOnRemoveValue(oppositeProperty, this, false);
                            }
                        }
                    }
                    else
                    {
                        throw new ModelException("Error removing value of " + this.GetType().Name + "." + property.Name + " from the opposite object. The current value must be a descendant of " + typeof(ModelObject) + ".");
                    }
                }
            }
        }

        private ModelObject parent;
        private HashSet<ModelObject> children = new HashSet<ModelObject>();

        public ModelObject MParent
        {
            get { return this.parent; }
            set
            {
                if (this.parent != value)
                {
                    if (this.parent != null)
                    {
                        if (value != null)
                        {
                            throw new ModelException("Invalid new container parent "+value+". The object "+this+" is already contained by "+this.parent+".");
                        }
                        else
                        {
                            this.parent.children.Remove(this);
                            this.parent = null;
                        }
                    }
                    else
                    {
                        this.parent = value;
                        this.parent.children.Add(this);
                    }
                }
            }
        }

        public IEnumerable<ModelObject> MChildren
        {
            get
            {
                return this.children;
            }
        }

        public override string ToString()
        {
            string typeName = this.GetType().Name;
            if (typeName.EndsWith("Impl")) typeName = typeName.Substring(0, typeName.Length - 4);
            string name = this.MetaID;
            if (this.nameProperty != null)
            {
                object nameValue = this.MGet(this.nameProperty);
                if (nameValue != null)
                {
                    name = nameValue.ToString();
                    return typeName + "(" + name + ")";
                }
            }
            return typeName + "[" + name + "]";
        }

        private HashSet<ModelObject> FindAllObjectsByID(string ID)
        {
            HashSet<ModelObject> result = new HashSet<ModelObject>();
            if (this.MetaID == ID)
            {
                result.Add(this);
            }
            foreach (var child in this.MChildren)
            {
                HashSet<ModelObject> childResults = child.FindAllObjectsByID(ID);
                result.UnionWith(childResults);
            }
            return result;
        }

        public HashSet<ModelObject> MFindAllObjectsByID(string ID)
        {
            return this.FindAllObjectsByID(ID);
        }

        public ModelObject MFindObjectByID(string ID)
        {
            if (this.MetaID == ID) return this;
            foreach (var child in this.MChildren)
            {
                ModelObject result = child.MFindObjectByID(ID);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public T MFindObjectByID<T>(string ID) where T : ModelObject
        {
            return this.MFindObjectByID(ID) as T;
        }

        private HashSet<T> FindAllObjects<T>() where T : ModelObject
        {
            HashSet<T> result = new HashSet<T>();
            if (this is T)
            {
                result.Add((T)this);
            }
            foreach (var child in this.MChildren)
            {
                HashSet<T> childResults = child.FindAllObjects<T>();
                result.UnionWith(childResults);
            }
            return result;
        }

        public IEnumerable<T> MFindObjects<T>() where T : ModelObject
        {
            return this.FindAllObjects<T>();
        }

        public IEnumerable<object> Annotations
        {
            get { return this.GetType().GetCustomAttributes(true); }
        }        

        internal enum AddRemoveDirection
        {
            None,
            Redefining,
            Redefined
        }
    }
}
