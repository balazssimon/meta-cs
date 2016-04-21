using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable4
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class OppositeAttribute : Attribute
    {
        public OppositeAttribute(Type declaringType, string propertyName)
        {
            this.DeclaringType = declaringType;
            this.PropertyName = propertyName;
        }

        public Type DeclaringType { get; private set; }
        public string PropertyName { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class SubsetsAttribute : Attribute
    {
        public SubsetsAttribute(Type declaringType, string propertyName)
        {
            this.DeclaringType = declaringType;
            this.PropertyName = propertyName;
        }

        public Type DeclaringType { get; private set; }
        public string PropertyName { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class SubtypesAttribute : Attribute
    {
        public SubtypesAttribute(Type declaringType, string propertyName)
        {
            this.DeclaringType = declaringType;
            this.PropertyName = propertyName;
        }

        public Type DeclaringType { get; private set; }
        public string PropertyName { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class RedefinesAttribute : Attribute
    {
        public RedefinesAttribute(Type declaringType, string propertyName)
        {
            this.DeclaringType = declaringType;
            this.PropertyName = propertyName;
        }

        public Type DeclaringType { get; private set; }
        public string PropertyName { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ReadonlyAttribute : Attribute
    {
        public ReadonlyAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ContainmentAttribute : Attribute
    {
        public ContainmentAttribute()
        {
        }
    }

    public class ModelPropertyTypeInfo
    {
        private System.Type type;
        private System.Type collectionType;
        private System.Type owningType;

        public ModelPropertyTypeInfo(System.Type type, System.Type collectionType, System.Type owningType)
        {
            this.type = type;
            this.collectionType = collectionType;
            this.owningType = owningType;
        }

        public System.Type Type { get { return this.type; } }
        public System.Type CollectionType { get { return this.collectionType; } }
        public System.Type OwningType { get { return this.owningType; } }
    }

    public class ModelProperty
    {
        private static Dictionary<System.Type, Dictionary<string, ModelProperty>> declaredProperties;
        private static Dictionary<System.Type, Dictionary<string, ModelProperty>> ownedProperties;
        private static Dictionary<System.Type, TypeCache> cachedTypes;

        static ModelProperty()
        {
            ModelProperty.declaredProperties = new Dictionary<System.Type, Dictionary<string, ModelProperty>>();
            ModelProperty.ownedProperties = new Dictionary<System.Type, Dictionary<string, ModelProperty>>();
            ModelProperty.cachedTypes = new Dictionary<Type, TypeCache>();
        }

        private string name;
        private ModelPropertyTypeInfo immutableTypeInfo;
        private ModelPropertyTypeInfo mutableTypeInfo;
        private string declaredName;
        private System.Type declaringType;

        private bool initialized = false;
        private List<object> annotations;

        private List<ModelProperty> oppositeProperties;
        private List<ModelProperty> subsettedProperties;
        private List<ModelProperty> subsettingProperties;
        private ModelProperty subtypedProperty;
        private List<ModelProperty> subtypingProperties;
        private ModelProperty redefinedProperty;
        private List<ModelProperty> redefiningProperties;
        /*
        private List<ModelProperty> addAffectedProperties;
        private List<ModelProperty> removeAffectedProperties;
        */

        private bool isReadonly = false;
        private bool isContainment = false;
        private bool isCollection = false;
        private bool isSymbol = false;

        protected ModelProperty(string name, string declaredName, System.Type declaringType, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            this.name = name;
            this.declaredName = declaredName;
            this.declaringType = declaringType;
            this.immutableTypeInfo = immutableTypeInfo;
            this.mutableTypeInfo = mutableTypeInfo;
            this.isSymbol = typeof(RedSymbol).IsAssignableFrom(immutableTypeInfo.Type) && typeof(RedSymbol).IsAssignableFrom(mutableTypeInfo.Type);
            Debug.Assert((immutableTypeInfo.CollectionType == null && mutableTypeInfo.CollectionType == null) || (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType != null));
            this.isCollection = immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType != null;
            this.annotations = new List<object>();
            this.oppositeProperties = new List<ModelProperty>();
            this.subsettedProperties = new List<ModelProperty>();
            this.subsettingProperties = new List<ModelProperty>();
            //this.subtypedProperties = new List<ModelProperty>();
            this.subtypingProperties = new List<ModelProperty>();
            //this.redefinedProperties = new List<ModelProperty>();
            this.redefiningProperties = new List<ModelProperty>();
            /*
            this.addAffectedProperties = new List<ModelProperty>();
            this.removeAffectedProperties = new List<ModelProperty>();
            */
        }

        public string Name { get { return this.name; } }
        public string DeclaredName { get { return this.declaredName; } }
        public System.Type DeclaringType { get { return this.declaringType; } }
        public ModelPropertyTypeInfo ImmutableTypeInfo { get { return this.immutableTypeInfo; } }
        public ModelPropertyTypeInfo MutableTypeInfo { get { return this.mutableTypeInfo; } }

        public bool IsSymbol
        {
            get
            {
                return this.isSymbol;
            }
        }

        public bool IsCollection
        {
            get
            {
                return this.isCollection;
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

        public ModelProperty SubtypedProperty
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.subtypedProperty;
            }
        }

        public IEnumerable<ModelProperty> SubtypingProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.subtypingProperties;
            }
        }

        public ModelProperty RedefinedProperty
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.redefinedProperty;
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

        private void Init()
        {
            if (this.initialized) return;
            this.initialized = true;
            FieldInfo info = this.DeclaringType.GetField(this.DeclaredName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (info != null)
            {
                this.annotations.AddRange(info.GetCustomAttributes());
                foreach (var attribute in this.annotations)
                {
                    if (attribute is OppositeAttribute)
                    {
                        OppositeAttribute oppositeAttribute = (OppositeAttribute)attribute;
                        RuntimeHelpers.RunClassConstructor(oppositeAttribute.DeclaringType.TypeHandle);
                        ModelProperty modelProperty = ModelProperty.Find(oppositeAttribute.DeclaringType, oppositeAttribute.PropertyName);
                        this.RegisterOppositeProperty(modelProperty);
                    }
                    else if (attribute is SubsetsAttribute)
                    {
                        SubsetsAttribute subsetsAttribute = (SubsetsAttribute)attribute;
                        RuntimeHelpers.RunClassConstructor(subsetsAttribute.DeclaringType.TypeHandle);
                        ModelProperty modelProperty = ModelProperty.Find(subsetsAttribute.DeclaringType, subsetsAttribute.PropertyName);
                        this.RegisterSubsettedProperty(modelProperty);
                    }
                    else if (attribute is SubtypesAttribute)
                    {
                        SubtypesAttribute subtypesAttribute = (SubtypesAttribute)attribute;
                        RuntimeHelpers.RunClassConstructor(subtypesAttribute.DeclaringType.TypeHandle);
                        ModelProperty modelProperty = ModelProperty.Find(subtypesAttribute.DeclaringType, subtypesAttribute.PropertyName);
                        this.RegisterSubtypedProperty(modelProperty);
                    }
                    else if (attribute is RedefinesAttribute)
                    {
                        RedefinesAttribute redefinesAttribute = (RedefinesAttribute)attribute;
                        RuntimeHelpers.RunClassConstructor(redefinesAttribute.DeclaringType.TypeHandle);
                        ModelProperty modelProperty = ModelProperty.Find(redefinesAttribute.DeclaringType, redefinesAttribute.PropertyName);
                        this.RegisterSubsettedProperty(modelProperty);
                    }
                    else if (attribute is ReadonlyAttribute)
                    {
                        this.isReadonly = true;
                    }
                    else if (attribute is ContainmentAttribute)
                    {
                        this.isContainment = true;
                    }
                }
            }
        }

        private void RegisterOppositeProperty(ModelProperty modelProperty)
        {
            if (modelProperty != null) return;
            lock (this)
            {
                List<ModelProperty> props = new List<ModelProperty>(this.oppositeProperties);
                props.Add(modelProperty);
                Interlocked.Exchange(ref this.oppositeProperties, props);
            }
            lock (modelProperty)
            {
                if (!modelProperty.oppositeProperties.Contains(this))
                {
                    List<ModelProperty> props = new List<ModelProperty>(modelProperty.oppositeProperties);
                    props.Add(this);
                    Interlocked.Exchange(ref modelProperty.oppositeProperties, props);
                }
            }
        }

        private void RegisterSubsettedProperty(ModelProperty modelProperty)
        {
            if (modelProperty != null) return;
            lock (this)
            {
                List<ModelProperty> props = new List<ModelProperty>(this.subsettedProperties);
                props.Add(modelProperty);
                Interlocked.Exchange(ref this.subsettedProperties, props);
            }
            lock (modelProperty)
            {
                List<ModelProperty> props = new List<ModelProperty>(modelProperty.subsettingProperties);
                props.Add(this);
                Interlocked.Exchange(ref modelProperty.subsettingProperties, props);
            }
        }

        private void RegisterSubtypedProperty(ModelProperty modelProperty)
        {
            if (modelProperty != null) return;
            lock (this)
            {
                /*List<ModelProperty> props = new List<ModelProperty>(this.subtypedProperties);
                props.Add(modelProperty);
                Interlocked.Exchange(ref this.subtypedProperties, props);*/
                Interlocked.Exchange(ref this.subtypedProperty, modelProperty);
            }
            lock (modelProperty)
            {
                List<ModelProperty> props = new List<ModelProperty>(modelProperty.subtypingProperties);
                props.Add(this);
                Interlocked.Exchange(ref modelProperty.subtypingProperties, props);
            }
        }

        private void RegisterRedefinedProperty(ModelProperty modelProperty)
        {
            if (modelProperty != null) return;
            lock (this)
            {
                /*List<ModelProperty> props = new List<ModelProperty>(this.redefinedProperties);
                props.Add(modelProperty);
                Interlocked.Exchange(ref this.redefinedProperties, props);*/
                Interlocked.Exchange(ref this.redefinedProperty, modelProperty);
            }
            lock (modelProperty)
            {
                List<ModelProperty> props = new List<ModelProperty>(modelProperty.redefiningProperties);
                props.Add(this);
                Interlocked.Exchange(ref modelProperty.redefiningProperties, props);
            }
        }
        /*
        private void RegisterAddAffectedProperty(ModelProperty modelProperty)
        {
            if (modelProperty != null) return;
            lock (this)
            {
                if (!this.addAffectedProperties.Contains(modelProperty))
                {
                    List<ModelProperty> props = new List<ModelProperty>(this.addAffectedProperties);
                    props.Add(modelProperty);
                    Interlocked.Exchange(ref this.addAffectedProperties, props);
                }
            }
        }

        private void RegisterRemoveAffectedProperty(ModelProperty modelProperty)
        {
            if (modelProperty != null) return;
            lock (this)
            {
                if (!this.removeAffectedProperties.Contains(modelProperty))
                {
                    List<ModelProperty> props = new List<ModelProperty>(this.removeAffectedProperties);
                    props.Add(modelProperty);
                    Interlocked.Exchange(ref this.removeAffectedProperties, props);
                }
            }
        }
        */
        public bool IsAssignableFrom(System.Type type)
        {
            return
                this.immutableTypeInfo.Type.IsAssignableFrom(type) ||
                this.mutableTypeInfo.Type.IsAssignableFrom(type);
        }

        public static ModelProperty Register(string name, System.Type declaringType, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, name + "Property", declaringType, immutableTypeInfo, mutableTypeInfo));
        }

        public static ModelProperty Register(string name, string declaredName, System.Type declaringType, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            return ModelProperty.RegisterProperty(new ModelProperty(name, declaredName, declaringType, immutableTypeInfo, mutableTypeInfo));
        }

        private static ModelProperty Find(System.Type declaringType, string name)
        {
            Dictionary<string, ModelProperty> propertyList = null;
            lock(ModelProperty.declaredProperties)
            {
                ModelProperty.declaredProperties.TryGetValue(declaringType, out propertyList);
            }
            if (propertyList != null)
            {
                lock(propertyList)
                {
                    ModelProperty result;
                    if (propertyList.TryGetValue(name, out result))
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        protected static ModelProperty RegisterProperty(ModelProperty property)
        {
            Dictionary<string, ModelProperty> propertyList = null;
            lock (ModelProperty.ownedProperties)
            {
                if (!ModelProperty.ownedProperties.TryGetValue(property.ImmutableTypeInfo.OwningType, out propertyList))
                {
                    propertyList = new Dictionary<string, ModelProperty>();
                    ModelProperty.ownedProperties.Add(property.ImmutableTypeInfo.OwningType, propertyList);
                }
                if (propertyList.ContainsKey(property.Name))
                {
                    throw new ModelException("Property '" + property + "' is already registered to '"+ property.ImmutableTypeInfo.OwningType.FullName + "' as '" + propertyList[property.Name] + "'.");
                }
                else
                {
                    propertyList.Add(property.Name, property);
                }
                if (!ModelProperty.ownedProperties.TryGetValue(property.MutableTypeInfo.OwningType, out propertyList))
                {
                    propertyList = new Dictionary<string, ModelProperty>();
                    ModelProperty.ownedProperties.Add(property.MutableTypeInfo.OwningType, propertyList);
                }
                if (propertyList.ContainsKey(property.Name))
                {
                    throw new ModelException("Property '" + property + "' is already registered to '" + property.MutableTypeInfo.OwningType.FullName + "' as '" + propertyList[property.Name] + "'.");
                }
                else
                {
                    propertyList.Add(property.Name, property);
                }
            }
            lock (ModelProperty.declaredProperties)
            {
                if (!ModelProperty.declaredProperties.TryGetValue(property.DeclaringType, out propertyList))
                {
                    propertyList = new Dictionary<string, ModelProperty>();
                    ModelProperty.declaredProperties.Add(property.DeclaringType, propertyList);
                }
                if (propertyList.ContainsKey(property.Name))
                {
                    throw new ModelException("Property '" + property + "' is already declared as '" + propertyList[property.Name] + "'.");
                }
                else
                {
                    propertyList.Add(property.Name, property);
                }
            }
            ModelProperty.ClearCache();
            return property;
        }

        private static void ClearCache()
        {
            Interlocked.Exchange(ref ModelProperty.cachedTypes, new Dictionary<System.Type, TypeCache>());
        }

        private static TypeCache GetCachedType(System.Type type)
        {
            RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            TypeCache typeCache;
            lock(ModelProperty.cachedTypes)
            {
                if (ModelProperty.cachedTypes.TryGetValue(type, out typeCache))
                {
                    return typeCache;
                }
            }
            typeCache = new TypeCache();
            HashSet<ModelProperty> allProperties = new HashSet<ModelProperty>();
            Dictionary<string, ModelProperty> propertyList;
            lock(ModelProperty.ownedProperties)
            {
                ModelProperty.ownedProperties.TryGetValue(type, out propertyList);
            }
            if (propertyList != null)
            {
                lock(propertyList)
                {
                    typeCache.declaredProperties.AddRange(propertyList.Values);
                    allProperties.UnionWith(propertyList.Values);
                    foreach (var prop in propertyList.Values)
                    {
                        if (!typeCache.properties.Any(p => p.Name == prop.Name))
                        {
                            typeCache.properties.Add(prop);
                        }
                    }
                }
            }
            foreach (var super in type.GetInterfaces())
            {
                var superProperties = ModelProperty.GetCachedType(super).allProperties;
                allProperties.UnionWith(superProperties);
                foreach (var prop in superProperties)
                {
                    if (!typeCache.properties.Any(p => p.Name == prop.Name))
                    {
                        typeCache.properties.Add(prop);
                    }
                }
            }
            typeCache.allProperties.AddRange(allProperties);
            lock (ModelProperty.cachedTypes)
            {
                ModelProperty.cachedTypes[type] = typeCache;
            }
            return typeCache;
        }

        public static IEnumerable<ModelProperty> GetPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedType(owningType).properties;
        }

        public static IEnumerable<ModelProperty> GetDeclaredPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedType(owningType).declaredProperties;
        }

        public static IEnumerable<ModelProperty> GetAllPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedType(owningType).allProperties;
        }

        public override string ToString()
        {
            return this.DeclaringType.FullName + "." + this.DeclaredName;
        }

        private class TypeCache
        {
            public TypeCache()
            {
                this.properties = new List<ModelProperty>();
                this.declaredProperties = new List<ModelProperty>();
                this.allProperties = new List<ModelProperty>();
            }

            internal List<ModelProperty> declaredProperties;
            internal List<ModelProperty> properties;
            internal List<ModelProperty> allProperties;
        }
    }

}
