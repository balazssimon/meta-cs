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
        internal static Dictionary<Type, Dictionary<string, ModelProperty>> declaredProperties;
        internal static Dictionary<Type, Dictionary<string, ModelProperty>> properties;
        internal static Dictionary<Type, HashSet<Type>> ancestors;

        static ModelProperty()
        {
            ModelProperty.declaredProperties = new Dictionary<Type, Dictionary<string, ModelProperty>>();
            ModelProperty.properties = new Dictionary<Type, Dictionary<string, ModelProperty>>();
            ModelProperty.ancestors = new Dictionary<Type, HashSet<Type>>();
        }

        private bool initialized = false;
        private List<ModelProperty> oppositeProperties;
        private List<ModelProperty> subsettedProperties;
        private List<ModelProperty> subsettingProperties;
        private List<ModelProperty> redefinedProperties;
        private List<ModelProperty> redefiningProperties;
        private bool isReadonly = false;
        private bool isContainment = false;
        private Type itemType = null;
        private bool isCollection = false;

        protected ModelProperty(string name, Type type, Type owningType, string declaredName, Type declaringType)
        {
            this.Name = name;
            this.DeclaredName = declaredName;
            this.Type = type;
            this.OwningType = owningType;
            this.DeclaringType = declaringType;
            this.oppositeProperties = new List<ModelProperty>();
            this.subsettedProperties = new List<ModelProperty>();
            this.subsettingProperties = new List<ModelProperty>();
            this.redefinedProperties = new List<ModelProperty>();
            this.redefiningProperties = new List<ModelProperty>();
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

        public IEnumerable<ModelProperty> SubsettedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.subsettedProperties;
            }
        }

        public IEnumerable<ModelProperty> SubsettingProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.subsettingProperties;
            }
        }
        
        public IEnumerable<ModelProperty> RedefinedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.redefinedProperties;
            }
        }

        public IEnumerable<ModelProperty> RedefiningProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.redefiningProperties;
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

        public Type ItemType
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
                if (ModelProperty.IsAssignableToGenericType(this.Type,typeof(ICollection<>)))
                {
                    Type[] genericArguments = this.Type.GetGenericArguments();
                    Type lastGenericArgument = genericArguments[genericArguments.Length - 1];
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
                            modelProperty.subsettingProperties.Add(this);
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
                            modelProperty.redefiningProperties.Add(this);
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

        public bool IsAssignableFrom(Type type)
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

        public static void RegisterAncestor(Type type, Type ancestorType)
        {
            if (type == null || ancestorType == null) return;
            RuntimeHelpers.RunClassConstructor(ancestorType.TypeHandle);
            HashSet<Type> ancestorsSet = null;
            if (!ModelProperty.ancestors.TryGetValue(type, out ancestorsSet))
            {
                ancestorsSet = new HashSet<Type>();
                ModelProperty.ancestors.Add(type, ancestorsSet);
            }
            ancestorsSet.Add(ancestorType);
        }

        public static ModelProperty Register(string name, Type type, Type owningType)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, type, owningType, name + "Property", owningType));
        }

        public static ModelProperty Register(string name, Type type, Type owningType, string declaredName)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, type, owningType, declaredName, owningType));
        }

        public static ModelProperty Register(string name, Type type, Type owningType, Type declaringType)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, type, owningType, name + "Property", declaringType));
        }

        public static ModelProperty Register(string name, Type type, Type owningType, string declaredName, Type declaringType)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, type, owningType, declaredName, declaringType));
        }

        protected static ModelProperty Find(Type declaringType, string name)
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
            propertyList.Add(property.Name, property);
            if (!ModelProperty.declaredProperties.TryGetValue(property.DeclaringType, out propertyList))
            {
                propertyList = new Dictionary<string, ModelProperty>();
                ModelProperty.declaredProperties.Add(property.DeclaringType, propertyList);
            }
            if (propertyList.ContainsKey(property.Name))
            {
                throw new ModelException("Property '" + property + "' is already declared as '" + propertyList[property.Name] + "'.");
            }
            propertyList.Add(property.Name, property);
            return property;
        }

        public static IEnumerable<ModelProperty> GetPropertiesForType(Type owningType)
        {
            Dictionary<string, ModelProperty> propertyList;
            RuntimeHelpers.RunClassConstructor(owningType.TypeHandle);
            if (ModelProperty.properties.TryGetValue(owningType, out propertyList))
            {
                return propertyList.Values;
            }
            return new ModelProperty[0];
        }

        public static IEnumerable<ModelProperty> GetAllPropertiesForType(Type owningType)
        {
            List<ModelProperty> result = new List<ModelProperty>();
            Dictionary<string, ModelProperty> propertyList;
            RuntimeHelpers.RunClassConstructor(owningType.TypeHandle);
            if (ModelProperty.properties.TryGetValue(owningType, out propertyList))
            {
                result.AddRange(propertyList.Values);
            }
            HashSet<Type> ancestorSet;
            if (ModelProperty.ancestors.TryGetValue(owningType, out ancestorSet))
            {
                foreach (var ancestor in ancestorSet)
                {
                    result.AddRange(ModelProperty.GetAllPropertiesForType(ancestor));
                }
            }
            return result;
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

        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }
    }
}
