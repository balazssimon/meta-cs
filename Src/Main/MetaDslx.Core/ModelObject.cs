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
        
        public void MInitValue(ModelProperty property, Func<object> value)
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
                if (property.IsCollection)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a collection property '" + property.ToString() + "'. Consider adding the items instead.");
                }
                else if (property.IsReadonly)
                {
                    throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                }
            }
            if (property.IsCollection)
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
                    if (!property.IsCollection)
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
            foreach (ModelProperty prop in ModelProperty.GetPropertiesForType(this.GetType()))
            {
                result.Add(prop);
            }
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

        internal void MOnAddValue(ModelProperty property, object value, bool firstCall)
        {
            bool added = false;
            if (property.IsCollection)
            {
                ModelCollection collection = this.MGetValue(property) as ModelCollection;
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
            }
            else
            {
                object oldValue = this.MGetValue(property);
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
                foreach (ModelProperty oppositeProperty in property.OppositeProperties)
                {
                    ModelObject oppositeObject = value as ModelObject;
                    if (oppositeObject != null)
                    {
                        oppositeObject.MOnAddValue(oppositeProperty, this, false);
                    }
                }
            }
        }

        internal void MOnRemoveValue(ModelProperty property, object value, bool firstCall)
        {
            bool removed = false;
            if (property.IsCollection)
            {
                ModelCollection collection = this.MGetValue(property) as ModelCollection;
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
            }
            else
            {
                object oldValue = this.MGetValue(property);
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
                foreach (ModelProperty oppositeProperty in property.OppositeProperties)
                {
                    ModelObject oppositeObject = value as ModelObject;
                    if (oppositeObject != null)
                    {
                        oppositeObject.MOnRemoveValue(oppositeProperty, this, false);
                    }
                }
            }
        }

        public override string ToString()
        {
            return "[" + this.MetaID + "]";
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
