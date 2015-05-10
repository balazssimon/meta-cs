using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    public abstract class MetaObject
    {
        private Dictionary<MetaProperty, object> values;
        private Dictionary<MetaProperty, Func<object>> initializers;

        public MetaObject()
        {
            this.MetaID = Guid.NewGuid().ToString();
            this.values = new Dictionary<MetaProperty, object>();
            this.initializers = new Dictionary<MetaProperty, Func<object>>();
        }

        public bool MetaIsSet(MetaProperty property)
        {
            return this.values.ContainsKey(property) || this.initializers.ContainsKey(property);
        }
        
        public void MetaInitValue(MetaProperty property, Func<object> value)
        {
            object oldValue;
            if (this.values.TryGetValue(property, out oldValue))
            {
                if (property.IsCollection)
                {
                    throw new MetaException("Error in '" + this.ToString() + "'. Cannot reassign a collection property '" + property.ToString() + "'. Consider adding the items instead.");
                }
                else if (property.IsReadonly)
                {
                    throw new MetaException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                }
                else
                {
                    this.values.Remove(property);
                }
            }
            this.initializers[property] = value;
        }

        public void MetaSetValue(MetaProperty property, object newValue)
        {
            object oldValue;
            if (this.values.TryGetValue(property, out oldValue))
            {
                if (newValue == oldValue) return;
                if (property.IsCollection)
                {
                    throw new MetaException("Error in '" + this.ToString() + "'. Cannot reassign a collection property '" + property.ToString() + "'. Consider adding the items instead.");
                }
                else if (property.IsReadonly)
                {
                    throw new MetaException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                }
            }
            if (property.IsCollection)
            {
                this.values[property] = newValue;
            }
            else
            {
                this.MetaOnAddValue(property, newValue, true);
            }
        }

        public object MetaGetValue(MetaProperty property)
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
                        this.MetaOnAddValue(property, value, true);
                    }
                    return value;
                }
            }
            return null;
        }

        public IEnumerable<MetaProperty> MetaGetAllProperties()
        {
            HashSet<MetaProperty> result = new HashSet<MetaProperty>();
            foreach (MetaProperty prop in this.values.Keys)
            {
                result.Add(prop);
            }
            foreach (MetaProperty prop in MetaProperty.GetPropertiesForType(this.GetType()))
            {
                result.Add(prop);
            }
            return result;
        }

        public MetaProperty MetaFindProperty(string name)
        {
            return this.SelectSingleProperty(this.MetaFindProperties(name));
        }

        public IEnumerable<MetaProperty> MetaFindProperties(string name)
        {
            var results =
                from p in this.MetaGetAllProperties()
                where p.Name == name
                select p;
            return results.ToList();
        }

        public MetaProperty MetaFindProperty(string name, Type declaringType)
        {
            return this.SelectSingleProperty(this.MetaFindProperties(name, declaringType));
        }

        public IEnumerable<MetaProperty> MetaFindProperties(string name, Type declaringType)
        {
            var results =
                from p in this.MetaGetAllProperties()
                where p.Name == name && declaringType.IsAssignableFrom(p.OwningType)
                select p;
            return results.ToList();
        }

        private MetaProperty SelectSingleProperty(IEnumerable<MetaProperty> properties)
        {
            List<MetaProperty> results = properties.ToList();
            if (results.Count == 0) return null;
            if (results.Count == 1) return results[0];
            throw new MetaException("More than one property found.");
        }

        public string MetaID
        {
            get;
            set;
        }

        internal void MetaOnAddValue(MetaProperty property, object value, bool firstCall)
        {
            bool added = false;
            if (property.IsCollection)
            {
                MetaCollection collection = this.MetaGetValue(property) as MetaCollection;
                if (collection != null)
                {
                    if (value != null && collection.MetaAdd(value))
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
                object oldValue = this.MetaGetValue(property);
                if (value != oldValue)
                {
                    if (oldValue != null)
                    {
                        this.MetaOnRemoveValue(property, oldValue, false);
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
                    MetaObject mofObjectValue = value as MetaObject;
                    if (mofObjectValue != null)
                    {
                        mofObjectValue.MetaParent = this;
                    }
                }
                foreach (MetaProperty oppositeProperty in property.OppositeProperties)
                {
                    MetaObject oppositeObject = value as MetaObject;
                    if (oppositeObject != null)
                    {
                        oppositeObject.MetaOnAddValue(oppositeProperty, this, false);
                    }
                }
            }
        }

        internal void MetaOnRemoveValue(MetaProperty property, object value, bool firstCall)
        {
            bool removed = false;
            if (property.IsCollection)
            {
                MetaCollection collection = this.MetaGetValue(property) as MetaCollection;
                if (collection != null)
                {
                    if (value != null && collection.MetaRemove(value))
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
                object oldValue = this.MetaGetValue(property);
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
                    MetaObject mofObjectValue = value as MetaObject;
                    if (mofObjectValue != null)
                    {
                        mofObjectValue.MetaParent = null;
                    }
                }
                foreach (MetaProperty oppositeProperty in property.OppositeProperties)
                {
                    MetaObject oppositeObject = value as MetaObject;
                    if (oppositeObject != null)
                    {
                        oppositeObject.MetaOnRemoveValue(oppositeProperty, this, false);
                    }
                }
            }
        }

        public override string ToString()
        {
            return "[" + this.MetaID + "]";
        }

        private MetaObject parent;
        private HashSet<MetaObject> children = new HashSet<MetaObject>();

        public MetaObject MetaParent
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
                            throw new MetaException("Invalid new container parent "+value+". The object "+this+" is already contained by "+this.parent+".");
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

        public IEnumerable<MetaObject> MetaChildren
        {
            get
            {
                return this.children;
            }
        }

        private HashSet<MetaObject> FindAllObjectsByID(string ID)
        {
            HashSet<MetaObject> result = new HashSet<MetaObject>();
            if (this.MetaID == ID)
            {
                result.Add(this);
            }
            foreach (var child in this.MetaChildren)
            {
                HashSet<MetaObject> childResults = child.FindAllObjectsByID(ID);
                result.UnionWith(childResults);
            }
            return result;
        }

        public MetaObject MetaFindObjectByID(string ID)
        {
            if (this.MetaID == ID) return this;
            foreach (var child in this.MetaChildren)
            {
                MetaObject result = child.MetaFindObjectByID(ID);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public T MetaFindObjectByID<T>(string ID) where T : MetaObject
        {
            return this.MetaFindObjectByID(ID) as T;
        }

        private HashSet<T> FindAllObjects<T>() where T : MetaObject
        {
            HashSet<T> result = new HashSet<T>();
            if (this is T)
            {
                result.Add((T)this);
            }
            foreach (var child in this.MetaChildren)
            {
                HashSet<T> childResults = child.FindAllObjects<T>();
                result.UnionWith(childResults);
            }
            return result;
        }

        public IEnumerable<T> MetaFindObjects<T>() where T : MetaObject
        {
            return this.FindAllObjects<T>();
        }
    }
}
