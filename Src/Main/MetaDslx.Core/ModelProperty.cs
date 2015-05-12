using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MetaDslx.Core
{
    public class ModelProperty
    {
        internal static Dictionary<Type, Dictionary<string, ModelProperty>> properties;

        static ModelProperty()
        {
            ModelProperty.properties = new Dictionary<Type, Dictionary<string, ModelProperty>>();
        }

        private bool initialized = false;
        private List<ModelProperty> oppositeProperties;
        private bool isReadonly = false;
        private bool isContainment = false;

        protected ModelProperty(string name, Type type, Type owningType, string declaredName, Type declaringType)
        {
            this.Name = name;
            this.DeclaredName = declaredName;
            this.Type = type;
            this.OwningType = owningType;
            this.DeclaringType = declaringType;
            this.oppositeProperties = new List<ModelProperty>();
            if (!typeof(ModelObject).IsAssignableFrom(this.OwningType))
            {
                throw new ModelException("Error in ModelProperty '" + this.ToString() + "'. The property must have an owning type that is a subclass of ModelObject.");
            }
        }

        public string Name { get; private set; }
        public string DeclaredName { get; private set; }
        public Type Type { get; private set; }
        public Type OwningType { get; private set; }
        public Type DeclaringType { get; private set; }

        public IEnumerable<ModelProperty> OppositeProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.oppositeProperties;
            }
        }

        public bool IsReadonly
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.isReadonly;
            }
        }

        public bool IsContainment
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.isContainment;
            }
        }

        private void Init()
        {
            if (this.initialized) return;
            FieldInfo info = this.DeclaringType.GetField(this.DeclaredName + "Property", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (info != null)
            {
                foreach (var attribute in info.GetCustomAttributes(typeof(OppositeAttribute), true))
                {
                    OppositeAttribute oppositeAttribute = attribute as OppositeAttribute;
                    if (oppositeAttribute != null)
                    {
                        if (typeof(ModelObject).IsAssignableFrom(this.Type) || typeof(ModelCollection).IsAssignableFrom(this.Type))
                        {
                            ModelProperty modelProperty = ModelProperty.Find(oppositeAttribute.DeclaringType, oppositeAttribute.PropertyName);
                            if (modelProperty != null)
                            {
                                this.oppositeProperties.Add(modelProperty);
                            }
                            else
                            {
                                throw new ModelException("Error in "+this.GetType().Name+" '" + this.ToString() + "'. Opposite property '" + oppositeAttribute.DeclaringType.FullName + "." + oppositeAttribute.PropertyName + "' could not be found.");
                            }
                        }
                        else
                        {
                            throw new ModelException("Error in " + this.GetType().Name + " '" + this.ToString() + "'. A property with an opposite property must have a type that is a descendant of either " + typeof(ModelObject).Name + " or " + typeof(ModelCollection).Name + ".");
                        }
                    }
                }
                foreach (var attribute in info.GetCustomAttributes(typeof(ReadonlyAttribute), true))
                {
                    ReadonlyAttribute readonlyAttribute = attribute as ReadonlyAttribute;
                    if (readonlyAttribute != null)
                    {
                        this.isReadonly = true;
                    }
                    ContainmentAttribute containmentAttribute = attribute as ContainmentAttribute;
                    if (containmentAttribute != null)
                    {
                        this.isContainment = true;
                    }
                }
            }
        }

        public bool IsCollection
        {
            get
            {
                return typeof(ModelCollection).IsAssignableFrom(this.Type);
            }
        }

        public static ModelProperty Register(string name, Type type, Type owningType)
        {
            return ModelProperty.RegisterProperty(owningType, name, new ModelProperty(name, type, owningType, name, owningType));
        }

        public static ModelProperty Register(string name, Type type, Type owningType, string declaredName)
        {
            return ModelProperty.RegisterProperty(owningType, name, new ModelProperty(name, type, owningType, declaredName, owningType));
        }

        public static ModelProperty Register(string name, Type type, Type owningType, Type declaringType)
        {
            return ModelProperty.RegisterProperty(owningType, name, new ModelProperty(name, type, owningType, name, declaringType));
        }

        public static ModelProperty Register(string name, Type type, Type owningType, string declaredName, Type declaringType)
        {
            return ModelProperty.RegisterProperty(owningType, name, new ModelProperty(name, type, owningType, declaredName, declaringType));
        }

        public static ModelProperty Find(Type declaringType, string name)
        {
            Dictionary<string, ModelProperty> propertyList;
            if (ModelProperty.properties.TryGetValue(declaringType, out propertyList))
            {
                ModelProperty result;
                if (propertyList.TryGetValue(name, out result))
                {
                    return result;
                }
            }
            return null;
        }

        protected static ModelProperty RegisterProperty(Type declaringType, string name, ModelProperty property)
        {
            Dictionary<string, ModelProperty> propertyList;
            if (!ModelProperty.properties.TryGetValue(declaringType, out propertyList))
            {
                propertyList = new Dictionary<string, ModelProperty>();
                ModelProperty.properties.Add(declaringType, propertyList);
            }
            if (propertyList.ContainsKey(name))
            {
                throw new ModelException("Property '" + property + "' is already registered as '" + propertyList[name] + "'.");
            }
            propertyList.Add(name, property);
            return property;
        }

        public static IEnumerable<ModelProperty> GetPropertiesForType(Type declaringType)
        {
            Dictionary<string, ModelProperty> propertyList;
            if (ModelProperty.properties.TryGetValue(declaringType, out propertyList))
            {
                return propertyList.Values;
            }
            return new ModelProperty[0];
        }

        public override string ToString()
        {
            return this.OwningType.FullName + "." + this.Name + " (" + this.DeclaringType.FullName + "." + this.DeclaredName + ")";
        }

       
    }
}
