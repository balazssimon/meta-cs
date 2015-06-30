using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    public abstract class ModelObject
    {
        private Dictionary<ModelProperty, object> values;
        private Dictionary<ModelProperty, Func<object>> initializers;

        public ModelObject()
        {
            this.MetaID = Guid.NewGuid().ToString();
            this.values = new Dictionary<ModelProperty, object>();
            this.initializers = new Dictionary<ModelProperty, Func<object>>();
        }

        public bool MIsSet(ModelProperty property)
        {
            return this.values.ContainsKey(property) || this.initializers.ContainsKey(property);
        }

        public void MUnSet(ModelProperty property)
        {
            this.values.Remove(property);
            this.initializers.Remove(property);
        }

        public void MInitValue(ModelProperty property, Func<object> value)
        {
            object oldValue;
            if (this.values.TryGetValue(property, out oldValue))
            {
                if (oldValue is ModelCollection)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a collection property '" + property.ToString() + "'. Consider adding the items instead.");
                }
                else if (property.IsReadonly)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                }
                else
                {
                    this.values.Remove(property);
                }
            }
            this.initializers[property] = value;
        }

        public void MSetValue(ModelProperty property, object newValue)
        {
            object oldValue;
            if (this.values.TryGetValue(property, out oldValue))
            {
                if (newValue == oldValue) return;
                if (oldValue is ModelCollection || newValue is ModelCollection)
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
                this.MOnAddValue(property, newValue, true);
            }
        }

        public object MGetValue(ModelProperty property)
        {
            object value;
            if (this.values.TryGetValue(property, out value))
            {
                return value;
            }
            else
            {
                Func<object> initializer;
                if (this.initializers.TryGetValue(property, out initializer))
                {
                    value = initializer();
                    this.values[property] = value;
                    if (!(value is ModelCollection))
                    {
                        this.MOnAddValue(property, value, true);
                    }
                    return value;
                }
            }
            return null;
        }

        public IEnumerable<ModelProperty> MGetAllProperties()
        {
            HashSet<ModelProperty> result = new HashSet<ModelProperty>();
            foreach (ModelProperty prop in this.values.Keys)
            {
                result.Add(prop);
            }
            result.UnionWith(ModelProperty.GetAllPropertiesForType(this.GetType()));
            return result;
        }

        public ModelProperty MFindProperty(string name)
        {
            return this.SelectSingleProperty(this.MFindProperties(name));
        }

        public IEnumerable<ModelProperty> MFindProperties(string name)
        {
            var results =
                from p in this.MGetAllProperties()
                where p.Name == name
                select p;
            return results.ToList();
        }

        public ModelProperty MFindProperty(string name, Type declaringType)
        {
            return this.SelectSingleProperty(this.MFindProperties(name, declaringType));
        }

        public IEnumerable<ModelProperty> MFindProperties(string name, Type declaringType)
        {
            var results =
                from p in this.MGetAllProperties()
                where p.Name == name && declaringType.IsAssignableFrom(p.OwningType)
                select p;
            return results.ToList();
        }

        private ModelProperty SelectSingleProperty(IEnumerable<ModelProperty> properties)
        {
            List<ModelProperty> results = properties.ToList();
            if (results.Count == 0) return null;
            if (results.Count == 1) return results[0];
            throw new ModelException("More than one property found.");
        }

        public string MetaID
        {
            get;
            set;
        }

        public void MAdd(ModelProperty property, object value)
        {
            this.MOnAddValue(property, value, true);
        }

        public void MRemove(ModelProperty property, object value)
        {
            this.MOnRemoveValue(property, value, true);
        }

        internal void MOnAddValue(ModelProperty property, object value, bool firstCall)
        {
            bool added = false;
            object oldValue = this.MGetValue(property);
            ModelCollection collection = oldValue as ModelCollection;
            if (collection != null)
            {
                if (value != null && collection.MAdd(value))
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
                if (property.IsContainment)
                {
                    ModelObject mofObjectValue = value as ModelObject;
                    if (mofObjectValue != null)
                    {
                        mofObjectValue.MParent = this;
                    }
                }
                List<ModelProperty> cachedOppositeProperties = property.OppositeProperties.ToList();
                foreach (ModelProperty oppositeProperty in cachedOppositeProperties)
                {
                    ModelObject oppositeObject = value as ModelObject;
                    if (oppositeObject != null)
                    {
                        oppositeObject.MOnAddValue(oppositeProperty, this, false);
                    }
                    else
                    {
                        throw new ModelException("Error adding value of " + this.GetType().Name + "." + property.Name + ": the value of the opposite property " + oppositeProperty + " must be a descendant of " + typeof(ModelObject) + ".");
                    }
                }
            }
        }

        internal void MOnRemoveValue(ModelProperty property, object value, bool firstCall)
        {
            bool removed = false;
            object oldValue = this.MGetValue(property);
            ModelCollection collection = oldValue as ModelCollection;
            if (collection != null)
            {
                if (value != null && collection.MRemove(value))
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
                    ModelObject mofObjectValue = value as ModelObject;
                    if (mofObjectValue != null)
                    {
                        mofObjectValue.MParent = null;
                    }
                }
                List<ModelProperty> cachedOppositeProperties = property.OppositeProperties.ToList();
                foreach (ModelProperty oppositeProperty in cachedOppositeProperties)
                {
                    ModelObject oppositeObject = value as ModelObject;
                    if (oppositeObject != null)
                    {
                        oppositeObject.MOnRemoveValue(oppositeProperty, this, false);
                    }
                    else
                    {
                        throw new ModelException("Error removing value of " + this.GetType().Name + "." + property.Name + ": the value of the opposite property "+oppositeProperty+" must be a descendant of " + typeof(ModelObject) + ".");
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.GetType() + "[" + this.MetaID + "]";
        }

        private ModelObject parent;
        private HashSet<ModelObject> children = new HashSet<ModelObject>();

        public ModelObject MParent
        {
            get { return this.parent; }
            private set
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
    }
}
