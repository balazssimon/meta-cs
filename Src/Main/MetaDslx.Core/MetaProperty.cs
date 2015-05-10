using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MetaDslx.Core
{
    public class MetaProperty
    {
        internal static Dictionary<Type, Dictionary<string, MetaProperty>> properties;

        static MetaProperty()
        {
            MetaProperty.properties = new Dictionary<Type, Dictionary<string, MetaProperty>>();
        }

        private bool initialized = false;
        private List<MetaProperty> oppositeProperties;
        private bool isReadonly = false;
        private bool isContainment = false;

        protected MetaProperty(string name, Type type, Type owningType, string declaredName, Type declaringType)
        {
            this.Name = name;
            this.DeclaredName = declaredName;
            this.Type = type;
            this.OwningType = owningType;
            this.DeclaringType = declaringType;
            this.oppositeProperties = new List<MetaProperty>();
            if (!typeof(MetaObject).IsAssignableFrom(this.OwningType))
            {
                throw new MetaException("Error in ModelProperty '" + this.ToString() + "'. The property must have an owning type that is a subclass of ModelObject.");
            }
        }

        public string Name { get; private set; }
        public string DeclaredName { get; private set; }
        public Type Type { get; private set; }
        public Type OwningType { get; private set; }
        public Type DeclaringType { get; private set; }

        public IEnumerable<MetaProperty> OppositeProperties
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
                        if (typeof(MetaObject).IsAssignableFrom(this.Type) || typeof(MetaCollection).IsAssignableFrom(this.Type))
                        {
                            MetaProperty modelProperty = MetaProperty.Find(oppositeAttribute.DeclaringType, oppositeAttribute.PropertyName);
                            if (modelProperty != null)
                            {
                                this.oppositeProperties.Add(modelProperty);
                            }
                            else
                            {
                                throw new MetaException("Error in ModelProperty '" + this.ToString() + "'. Opposite property '" + oppositeAttribute.DeclaringType.FullName + "." + oppositeAttribute.PropertyName + "' could not be found.");
                            }
                        }
                        else
                        {
                            throw new MetaException("Error in ModelProperty '" + this.ToString() + "'. A property with an opposite property must have a type that is a descendant of either ModelObject or ModelCollection.");
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
                return typeof(MetaCollection).IsAssignableFrom(this.Type);
            }
        }

        public static MetaProperty Register(string name, Type type, Type owningType)
        {
            return MetaProperty.RegisterProperty(owningType, name, new MetaProperty(name, type, owningType, name, owningType));
        }

        public static MetaProperty Register(string name, Type type, Type owningType, string declaredName)
        {
            return MetaProperty.RegisterProperty(owningType, name, new MetaProperty(name, type, owningType, declaredName, owningType));
        }

        public static MetaProperty Register(string name, Type type, Type owningType, Type declaringType)
        {
            return MetaProperty.RegisterProperty(owningType, name, new MetaProperty(name, type, owningType, name, declaringType));
        }

        public static MetaProperty Register(string name, Type type, Type owningType, string declaredName, Type declaringType)
        {
            return MetaProperty.RegisterProperty(owningType, name, new MetaProperty(name, type, owningType, declaredName, declaringType));
        }

        public static MetaProperty Find(Type declaringType, string name)
        {
            Dictionary<string, MetaProperty> propertyList;
            if (MetaProperty.properties.TryGetValue(declaringType, out propertyList))
            {
                MetaProperty result;
                if (propertyList.TryGetValue(name, out result))
                {
                    return result;
                }
            }
            return null;
        }

        protected static MetaProperty RegisterProperty(Type declaringType, string name, MetaProperty property)
        {
            Dictionary<string, MetaProperty> propertyList;
            if (!MetaProperty.properties.TryGetValue(declaringType, out propertyList))
            {
                propertyList = new Dictionary<string, MetaProperty>();
                MetaProperty.properties.Add(declaringType, propertyList);
            }
            if (propertyList.ContainsKey(name))
            {
                throw new MetaException("Property '" + property + "' is already registered as '" + propertyList[name] + "'.");
            }
            propertyList.Add(name, property);
            return property;
        }

        public static IEnumerable<MetaProperty> GetPropertiesForType(Type declaringType)
        {
            Dictionary<string, MetaProperty> propertyList;
            if (MetaProperty.properties.TryGetValue(declaringType, out propertyList))
            {
                return propertyList.Values;
            }
            return new MetaProperty[0];
        }

        public override string ToString()
        {
            return this.OwningType.FullName + "." + this.Name + " (" + this.DeclaringType.FullName + "." + this.DeclaredName + ")";
        }

       
    }
}
