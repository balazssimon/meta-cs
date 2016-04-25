using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Runtime.CompilerServices;

namespace MetaDslx.Core
{
    public class ModelProperty
    {
        private static Dictionary<System.Type, Dictionary<string, ModelProperty>> declaredProperties;
        private static Dictionary<System.Type, Dictionary<string, ModelProperty>> properties;
        private static Dictionary<System.Type, PropertyCache> cachedProperties;

        static ModelProperty()
        {
            ModelProperty.declaredProperties = new Dictionary<System.Type, Dictionary<string, ModelProperty>>();
            ModelProperty.properties = new Dictionary<System.Type, Dictionary<string, ModelProperty>>();
            ModelProperty.cachedProperties = new Dictionary<Type, PropertyCache>();
        }

        private bool initialized = false;
        private List<object> annotations;
        private List<ModelProperty> oppositeProperties;
        private List<ModelProperty> subsettedProperties;
        private List<ModelProperty> subsettingProperties;
        private List<ModelProperty> redefinedProperties;
        private List<ModelProperty> redefiningProperties;
        private List<ModelProperty> cachedOppositeProperties;
        private List<ModelProperty> cachedSubsettedProperties;
        private List<ModelProperty> cachedSubsettingProperties;
        private List<ModelProperty> cachedRedefinedProperties;
        private List<ModelProperty> cachedRedefiningProperties;
        private bool isReadonly = false;
        private bool isContainment = false;
        private System.Type itemType = null;
        private bool isCollection = false;
        private Lazy<MetaProperty> metaProperty = null;

        protected ModelProperty(string name, System.Type type, System.Type owningType, string declaredName, System.Type declaringType, Lazy<MetaProperty> metaProperty)
        {
            this.Name = name;
            this.DeclaredName = declaredName;
            this.Type = type;
            this.OwningType = owningType;
            this.DeclaringType = declaringType;
            this.annotations = new List<object>();
            this.oppositeProperties = new List<ModelProperty>();
            this.subsettedProperties = new List<ModelProperty>();
            this.subsettingProperties = new List<ModelProperty>();
            this.redefinedProperties = new List<ModelProperty>();
            this.redefiningProperties = new List<ModelProperty>();
            this.metaProperty = metaProperty;
        }

        public string Name { get; private set; }
        public string DeclaredName { get; private set; }
        public System.Type Type { get; private set; }
        public System.Type OwningType { get; private set; }
        public System.Type DeclaringType { get; private set; }
        public MetaProperty MetaProperty
        {
            get
            {
                if (this.metaProperty != null) return this.metaProperty.Value;
                else return null;
            }
        }

        public IEnumerable<object> Annotations
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.annotations;
            }
        }

        public IEnumerable<ModelProperty> OppositeProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                if (this.cachedOppositeProperties == null)
                {
                    this.cachedOppositeProperties = new List<ModelProperty>(this.oppositeProperties);
                }
                return this.cachedOppositeProperties;
            }
        }

        public IEnumerable<ModelProperty> SubsettedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                if (this.cachedSubsettedProperties == null)
                {
                    this.cachedSubsettedProperties = new List<ModelProperty>(this.subsettedProperties);
                }
                return this.cachedSubsettedProperties;
            }
        }

        public IEnumerable<ModelProperty> SubsettingProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                if (this.cachedSubsettingProperties == null)
                {
                    this.cachedSubsettingProperties = new List<ModelProperty>(this.subsettingProperties);
                }
                return this.cachedSubsettingProperties;
            }
        }
        
        public IEnumerable<ModelProperty> RedefinedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                if (this.cachedRedefinedProperties == null)
                {
                    this.cachedRedefinedProperties = new List<ModelProperty>(this.redefinedProperties);
                }
                return this.cachedRedefinedProperties;
            }
        }

        public IEnumerable<ModelProperty> RedefiningProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                if (this.cachedRedefiningProperties == null)
                {
                    this.cachedRedefiningProperties = new List<ModelProperty>(this.redefiningProperties);
                }
                return this.cachedRedefiningProperties;
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

        public bool IsCollection
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.isCollection;
            }
        }

        public System.Type ItemType
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.itemType;
            }
        }

        private void Init()
        {
            if (this.initialized) return;
            this.initialized = true;
            FieldInfo info = this.DeclaringType.GetField(this.DeclaredName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (info != null)
            {
                this.annotations.AddRange(info.GetCustomAttributes());
                if (ModelProperty.IsAssignableToGenericType(this.Type,typeof(ICollection<>)))
                {
                    System.Type[] genericArguments = this.Type.GetGenericArguments();
                    System.Type lastGenericArgument = genericArguments[genericArguments.Length - 1];
                    if (genericArguments.Length > 0 && !lastGenericArgument.IsGenericParameter)
                    {
                        this.isCollection = true;
                        this.itemType = lastGenericArgument;
                    }
                }
                foreach (var attribute in info.GetCustomAttributes(typeof(OppositeAttribute), true))
                {
                    OppositeAttribute oppositeAttribute = attribute as OppositeAttribute;
                    if (oppositeAttribute != null)
                    {
                        RuntimeHelpers.RunClassConstructor(oppositeAttribute.DeclaringType.TypeHandle); 
                        ModelProperty modelProperty = ModelProperty.Find(oppositeAttribute.DeclaringType, oppositeAttribute.PropertyName);
                        if (modelProperty != null)
                        {
                            this.oppositeProperties.Add(modelProperty);
                            this.cachedOppositeProperties = null;
                        }
                    }
                }
                foreach (var attribute in info.GetCustomAttributes(typeof(SubsetsAttribute), true))
                {
                    SubsetsAttribute subsetsAttribute = attribute as SubsetsAttribute;
                    if (subsetsAttribute != null)
                    {
                        RuntimeHelpers.RunClassConstructor(subsetsAttribute.DeclaringType.TypeHandle);
                        ModelProperty modelProperty = ModelProperty.Find(subsetsAttribute.DeclaringType, subsetsAttribute.PropertyName);
                        if (modelProperty != null)
                        {
                            this.subsettedProperties.Add(modelProperty);
                            this.cachedSubsettedProperties = null;
                            modelProperty.subsettingProperties.Add(this);
                            modelProperty.cachedSubsettingProperties = null;
                        }
                    }
                }
                foreach (var attribute in info.GetCustomAttributes(typeof(RedefinesAttribute), true))
                {
                    RedefinesAttribute redefinesAttribute = attribute as RedefinesAttribute;
                    if (redefinesAttribute != null)
                    {
                        RuntimeHelpers.RunClassConstructor(redefinesAttribute.DeclaringType.TypeHandle);
                        ModelProperty modelProperty = ModelProperty.Find(redefinesAttribute.DeclaringType, redefinesAttribute.PropertyName);
                        if (modelProperty != null)
                        {
                            this.redefinedProperties.Add(modelProperty);
                            this.cachedRedefinedProperties = null;
                            modelProperty.redefiningProperties.Add(this);
                            modelProperty.cachedRedefiningProperties = null;
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
                }
                foreach (var attribute in info.GetCustomAttributes(typeof(ContainmentAttribute), true))
                {
                    ContainmentAttribute containmentAttribute = attribute as ContainmentAttribute;
                    if (containmentAttribute != null)
                    {
                        this.isContainment = true;
                    }
                }
            }
        }

        public bool IsAssignableFrom(System.Type type)
        {
            if (this.Type == null || type == null) return false;
            if (this.IsCollection)
            {
                return this.ItemType.IsAssignableFrom(type);
            }
            else
            {
                return this.Type.IsAssignableFrom(type);
            }
        }

        public static ModelProperty Register(string name, System.Type type, System.Type owningType)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, type, owningType, name + "Property", owningType, null));
        }

        public static ModelProperty Register(string name, System.Type type, System.Type owningType, System.Type declaringType, Lazy<MetaProperty> metaProperty)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, type, owningType, name + "Property", declaringType, metaProperty));
        }

        public static ModelProperty Register(string name, System.Type type, System.Type owningType, string declaredName, System.Type declaringType, Lazy<MetaProperty> metaProperty)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, type, owningType, declaredName, declaringType, metaProperty));
        }

        protected static ModelProperty Find(System.Type declaringType, string name)
        {
            Dictionary<string, ModelProperty> propertyList;
            if (ModelProperty.declaredProperties.TryGetValue(declaringType, out propertyList))
            {
                ModelProperty result;
                if (propertyList.TryGetValue(name, out result))
                {
                    return result;
                }
            }
            return null;
        }

        private static void ClearCache()
        {
            ModelProperty.cachedProperties = new Dictionary<System.Type, PropertyCache>();
        }

        private static PropertyCache GetCachedProperties(System.Type type)
        {
            RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            PropertyCache propertyCache;
            if (!ModelProperty.cachedProperties.TryGetValue(type, out propertyCache))
            {
                propertyCache = new PropertyCache();
                ModelProperty.cachedProperties.Add(type, propertyCache);
                HashSet<ModelProperty> allProperties = new HashSet<ModelProperty>();
                Dictionary<string, ModelProperty> propertyList;
                if (ModelProperty.properties.TryGetValue(type, out propertyList))
                {
                    propertyCache.DeclaredProperties.AddRange(propertyList.Values);
                    allProperties.UnionWith(propertyList.Values);
                    foreach (var prop in propertyList.Values)
                    {
                        if (!propertyCache.Properties.Any(p => p.Name == prop.Name))
                        {
                            propertyCache.Properties.Add(prop);
                        }
                    }
                }
                foreach (var super in type.GetInterfaces())
                {
                    var superProperties = ModelProperty.GetCachedProperties(super).AllProperties;
                    allProperties.UnionWith(superProperties);
                    foreach (var prop in superProperties)
                    {
                        if (!propertyCache.Properties.Any(p => p.Name == prop.Name))
                        {
                            propertyCache.Properties.Add(prop);
                        }
                    }
                }
                propertyCache.AllProperties.AddRange(allProperties);
            }
            return propertyCache;
        }

        protected static ModelProperty RegisterProperty(ModelProperty property)
        {
            Dictionary<string, ModelProperty> propertyList;
            if (!ModelProperty.properties.TryGetValue(property.OwningType, out propertyList))
            {
                propertyList = new Dictionary<string, ModelProperty>();
                ModelProperty.properties.Add(property.OwningType, propertyList);
            }
            if (propertyList.ContainsKey(property.Name))
            {
                throw new ModelException("Property '" + property + "' is already registered as '" + propertyList[property.Name] + "'.");
            }
            Dictionary<string, ModelProperty> declaredPropertyList;
            if (!ModelProperty.declaredProperties.TryGetValue(property.DeclaringType, out declaredPropertyList))
            {
                declaredPropertyList = new Dictionary<string, ModelProperty>();
                ModelProperty.declaredProperties.Add(property.DeclaringType, declaredPropertyList);
            }
            if (declaredPropertyList.ContainsKey(property.Name))
            {
                throw new ModelException("Property '" + property + "' is already declared as '" + declaredPropertyList[property.Name] + "'.");
            }
            propertyList.Add(property.Name, property);
            declaredPropertyList.Add(property.Name, property);
            ModelProperty.ClearCache();
            return property;
        }

        public static IEnumerable<ModelProperty> GetPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedProperties(owningType).Properties;
        }

        public static IEnumerable<ModelProperty> GetDeclaredPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedProperties(owningType).DeclaredProperties;
        }

        public static IEnumerable<ModelProperty> GetAllPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedProperties(owningType).AllProperties;
        }

        public override string ToString()
        {
            if (this.DeclaringType != this.OwningType)
            {
                return this.OwningType.FullName + "." + this.Name + " (" + this.DeclaringType.FullName + "." + this.DeclaredName + ")";
            }
            else
            {
                return this.OwningType.FullName + "." + this.Name;
            }
        }

        private static bool IsAssignableToGenericType(System.Type givenType, System.Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            System.Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }

        private class PropertyCache
        {
            public PropertyCache()
            {
                this.Properties = new List<ModelProperty>();
                this.DeclaredProperties = new List<ModelProperty>();
                this.AllProperties = new List<ModelProperty>();
            }

            public List<ModelProperty> DeclaredProperties { get; private set; }
            public List<ModelProperty> Properties { get; private set; }
            public List<ModelProperty> AllProperties { get; private set; }
        }
    }
}
