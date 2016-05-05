using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
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

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
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

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
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
    public class NonUniqueAttribute : Attribute
    {
        public NonUniqueAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class NonNullAttribute : Attribute
    {
        public NonNullAttribute()
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

    [Flags]
    public enum ModelPropertyFlags : uint
    {
        IsReadonly = 0x0001,
        IsCollection = 0x0002,
        IsSymbol = 0x0004,
        IsNonUnique = 0x0008,
        IsNonNull = 0x0010,
        IsContainment = 0x0020,
        HasAnnotations = 0x0040,
        HasOppositeProperties = 0x0080,
        HasSubsettedProperties = 0x0100,
        HasSubsettingProperties = 0x0200,
        HasSubtypedProperties = 0x0400,
        HasSubtypingProperties = 0x0800,
        HasRedefinedProperties = 0x1000,
        HasRedefiningProperties = 0x2000,
        HasAffectedProperties = HasOppositeProperties | HasSubsettedProperties | HasSubsettingProperties |
            HasSubtypedProperties | HasSubtypingProperties | HasRedefinedProperties | HasRedefiningProperties,
        HasAddAffectedProperties = HasOppositeProperties | HasSubsettingProperties | HasSubtypingProperties | 
            HasRedefiningProperties,
        HasRemoveAffectedProperties = HasOppositeProperties | HasSubsettedProperties | HasSubtypedProperties |
            HasRedefinedProperties,
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
        private static readonly HashSet<ModelProperty> EmptySet = new HashSet<ModelProperty>();
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
        private ModelPropertyFlags flags;

        private HashSet<ModelProperty> oppositeProperties;
        private HashSet<ModelProperty> subsettedProperties;
        private HashSet<ModelProperty> subsettingProperties;
        private HashSet<ModelProperty> subtypedProperties;
        private HashSet<ModelProperty> subtypingProperties;
        private HashSet<ModelProperty> redefinedProperties;
        private HashSet<ModelProperty> redefiningProperties;

        private HashSet<ModelProperty> addAffectedProperties;
        private HashSet<ModelProperty> removeAffectedProperties;
        private HashSet<ModelProperty> addAffectedOptionalProperties;
        private HashSet<ModelProperty> removeAffectedOptionalProperties;

        private ModelProperty(string name, string declaredName, System.Type declaringType, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (declaredName == null) throw new ArgumentNullException(nameof(declaredName));
            if (declaringType == null) throw new ArgumentNullException(nameof(declaringType));
            if (immutableTypeInfo == null) throw new ArgumentNullException(nameof(immutableTypeInfo));
            if (mutableTypeInfo == null) throw new ArgumentNullException(nameof(mutableTypeInfo));
            this.name = name;
            this.declaredName = declaredName;
            this.declaringType = declaringType;
            this.immutableTypeInfo = immutableTypeInfo;
            this.mutableTypeInfo = mutableTypeInfo;
            if (typeof(ImmutableRedSymbolBase).IsAssignableFrom(immutableTypeInfo.Type) && typeof(MutableRedSymbolBase).IsAssignableFrom(mutableTypeInfo.Type))
            {
                this.flags |= ModelPropertyFlags.IsSymbol;
            }
            if ((immutableTypeInfo.CollectionType == null && mutableTypeInfo.CollectionType != null) || (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType == null))
            {
                throw new ArgumentException("Inconsistent collection type.");
            }
            if (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType != null)
            {
                this.flags |= ModelPropertyFlags.IsCollection;
            }
        }

        public string Name { get { return this.name; } }
        public string DeclaredName { get { return this.declaredName; } }
        public System.Type DeclaringType { get { return this.declaringType; } }
        public ModelPropertyTypeInfo ImmutableTypeInfo { get { return this.immutableTypeInfo; } }
        public ModelPropertyTypeInfo MutableTypeInfo { get { return this.mutableTypeInfo; } }

        public bool IsSymbol { get { if (!this.initialized) this.Init(); return this.flags.HasFlag(ModelPropertyFlags.IsSymbol); } }
        public bool IsNonUnique { get { if (!this.initialized) this.Init(); return this.flags.HasFlag(ModelPropertyFlags.IsNonUnique); } }
        public bool IsNonNull { get { if (!this.initialized) this.Init(); return this.flags.HasFlag(ModelPropertyFlags.IsNonNull); } }
        public bool IsCollection { get { return this.flags.HasFlag(ModelPropertyFlags.IsCollection); } }

        public bool HasAffectedProperties { get { if (!this.initialized) this.Init(); return (this.flags & ModelPropertyFlags.HasAffectedProperties) != 0; } }
        public bool HasAddAffectedProperties { get { if (!this.initialized) this.Init(); return (this.flags & ModelPropertyFlags.HasAddAffectedProperties) != 0; } }
        public bool HasRemoveAffectedProperties { get { if (!this.initialized) this.Init(); return (this.flags & ModelPropertyFlags.HasRemoveAffectedProperties) != 0; } }
        public bool HasOppositeProperties { get { if (!this.initialized) this.Init(); return (this.flags & ModelPropertyFlags.HasOppositeProperties) != 0; } }

        public bool IsReadonly
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.flags.HasFlag(ModelPropertyFlags.IsReadonly);
            }
        }

        public bool IsContainment
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.flags.HasFlag(ModelPropertyFlags.IsContainment);
            }
        }

        public IEnumerable<ModelProperty> OppositeProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.oppositeProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> SubsettedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.subsettedProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> SubsettingProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.subsettingProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> SubtypedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.subtypedProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> SubtypingProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.subtypingProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> RedefinedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.redefinedProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> RedefiningProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.redefiningProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> AddAffectedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.addAffectedProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> RemoveAffectedProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.removeAffectedProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> AddAffectedOptionalProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.addAffectedOptionalProperties ?? ModelProperty.EmptySet;
            }
        }

        public IEnumerable<ModelProperty> RemoveAffectedOptionalProperties
        {
            get
            {
                if (!this.initialized) this.Init();
                return this.removeAffectedOptionalProperties ?? ModelProperty.EmptySet;
            }
        }

        internal void Init()
        {
            if (this.initialized) return;
            this.initialized = true;
            FieldInfo info = this.DeclaringType.GetField(this.DeclaredName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (info != null)
            {
                foreach (var attribute in info.GetCustomAttributes())
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
                        this.RegisterRedefinedProperty(modelProperty);
                    }
                    else if (attribute is ReadonlyAttribute)
                    {
                        this.flags |= ModelPropertyFlags.IsReadonly;
                    }
                    else if (attribute is NonUniqueAttribute)
                    {
                        this.flags |= ModelPropertyFlags.IsNonUnique;
                    }
                    else if (attribute is NonNullAttribute)
                    {
                        this.flags |= ModelPropertyFlags.IsNonNull;
                    }
                    else if (attribute is ContainmentAttribute)
                    {
                        this.flags |= ModelPropertyFlags.IsContainment;
                    }
                }
            }
        }

        private void RegisterOppositeProperty(ModelProperty modelProperty)
        {
            if (modelProperty == null) return;
            lock (this)
            {
                HashSet<ModelProperty> props = new HashSet<ModelProperty>();
                if (this.oppositeProperties != null) props.UnionWith(this.oppositeProperties);
                props.Add(modelProperty);
                Interlocked.Exchange(ref this.oppositeProperties, props);
                this.flags |= ModelPropertyFlags.HasOppositeProperties;
            }
            lock (modelProperty)
            {
                HashSet<ModelProperty> props = new HashSet<ModelProperty>();
                if (modelProperty.oppositeProperties != null) props.UnionWith(modelProperty.oppositeProperties);
                props.Add(this);
                Interlocked.Exchange(ref modelProperty.oppositeProperties, props);
                modelProperty.flags |= ModelPropertyFlags.HasOppositeProperties;
            }
        }

        private void RegisterSubsettedProperty(ModelProperty modelProperty)
        {
            if (modelProperty == null) return;
            lock (this)
            {
                HashSet<ModelProperty> props = new HashSet<ModelProperty>();
                if (this.subsettedProperties != null) props.UnionWith(this.subsettedProperties);
                props.Add(modelProperty);
                Interlocked.Exchange(ref this.subsettedProperties, props);
                this.flags |= ModelPropertyFlags.HasSubsettedProperties;
            }
            lock (modelProperty)
            {
                HashSet<ModelProperty> props = new HashSet<ModelProperty>();
                if (modelProperty.subsettingProperties != null) props.UnionWith(modelProperty.subsettingProperties);
                props.Add(this);
                Interlocked.Exchange(ref modelProperty.subsettingProperties, props);
                modelProperty.flags |= ModelPropertyFlags.HasSubsettingProperties;
            }
            this.RegisterAddAffectedProperty(modelProperty, false);
            modelProperty.RegisterRemoveAffectedProperty(this, false);
        }

        private void RegisterSubtypedProperty(ModelProperty modelProperty)
        {
            if (modelProperty == null) return;
            lock (this)
            {
                HashSet<ModelProperty> props = new HashSet<ModelProperty>();
                if (this.subtypedProperties != null) props.UnionWith(this.subtypedProperties);
                props.Add(modelProperty);
                Interlocked.Exchange(ref this.subtypedProperties, props);
                this.flags |= ModelPropertyFlags.HasSubtypedProperties;
            }
            lock (modelProperty)
            {
                HashSet<ModelProperty> props = new HashSet<ModelProperty>();
                if (modelProperty.subtypingProperties != null) props.UnionWith(modelProperty.subtypingProperties);
                props.Add(this);
                Interlocked.Exchange(ref modelProperty.subtypingProperties, props);
                modelProperty.flags |= ModelPropertyFlags.HasSubtypingProperties;
            }
            this.RegisterAddAffectedProperty(modelProperty, false);
            modelProperty.RegisterAddAffectedProperty(this, true);
            this.RegisterRemoveAffectedProperty(modelProperty, true);
            modelProperty.RegisterRemoveAffectedProperty(this, false);
        }

        private void RegisterRedefinedProperty(ModelProperty modelProperty)
        {
            if (modelProperty == null) return;
            lock (this)
            {
                HashSet<ModelProperty> props = new HashSet<ModelProperty>();
                if (this.redefinedProperties != null) props.UnionWith(this.redefinedProperties);
                props.Add(modelProperty);
                Interlocked.Exchange(ref this.redefinedProperties, props);
                this.flags |= ModelPropertyFlags.HasRedefinedProperties;
            }
            lock (modelProperty)
            {
                HashSet<ModelProperty> props = new HashSet<ModelProperty>();
                if (modelProperty.redefiningProperties != null) props.UnionWith(modelProperty.redefiningProperties);
                props.Add(this);
                Interlocked.Exchange(ref modelProperty.redefiningProperties, props);
                modelProperty.flags |= ModelPropertyFlags.HasRedefiningProperties;
            }
            this.RegisterAddAffectedProperty(modelProperty, false);
            modelProperty.RegisterAddAffectedProperty(this, false);
            this.RegisterRemoveAffectedProperty(modelProperty, false);
            modelProperty.RegisterRemoveAffectedProperty(this, false);
        }

        private void RegisterAddAffectedProperty(ModelProperty modelProperty, bool optional)
        {
            if (modelProperty == null) return;
            HashSet<ModelProperty> props;
            HashSet<ModelProperty> remProps = new HashSet<ModelProperty>();
            lock(this)
            {
                remProps.Add(this);
                if (this.removeAffectedProperties != null) remProps.UnionWith(this.removeAffectedProperties);
                if (this.removeAffectedOptionalProperties != null) remProps.UnionWith(this.removeAffectedOptionalProperties);
            }
            foreach (var remProp in remProps)
            {
                lock (remProp)
                {
                    bool remOptional = false;
                    if (this.removeAffectedOptionalProperties?.Contains(remProp) ?? false) remOptional = true;
                    if (this.removeAffectedProperties?.Contains(remProp) ?? false) remOptional = false;
                    if (remProp == this) remOptional = false;
                    if (optional || remOptional)
                    {
                        props = new HashSet<ModelProperty>();
                        props.Add(modelProperty);
                        if (remProp.addAffectedOptionalProperties != null) props.UnionWith(remProp.addAffectedOptionalProperties);
                        if (modelProperty.addAffectedProperties != null) props.UnionWith(modelProperty.addAffectedProperties);
                        if (modelProperty.addAffectedOptionalProperties != null) props.UnionWith(modelProperty.addAffectedOptionalProperties);
                        props.Remove(remProp);
                        if (remProp.addAffectedProperties != null) props.ExceptWith(remProp.addAffectedProperties);
                        Interlocked.Exchange(ref remProp.addAffectedOptionalProperties, props);
                    }
                    else
                    {
                        if (remProp.addAffectedProperties == null || !remProp.addAffectedProperties.Contains(modelProperty))
                        {
                            if (remProp.addAffectedOptionalProperties?.Contains(modelProperty) ?? false)
                            {
                                props = new HashSet<ModelProperty>(remProp.addAffectedOptionalProperties);
                                props.Remove(modelProperty);
                                Interlocked.Exchange(ref remProp.addAffectedOptionalProperties, props);
                            }
                            props = new HashSet<ModelProperty>();
                            props.Add(modelProperty);
                            if (remProp.addAffectedProperties != null) props.UnionWith(remProp.addAffectedProperties);
                            if (modelProperty.addAffectedProperties != null) props.UnionWith(modelProperty.addAffectedProperties);
                            props.Remove(remProp);
                            Interlocked.Exchange(ref remProp.addAffectedProperties, props);
                            if (modelProperty.addAffectedOptionalProperties != null)
                            {
                                props = new HashSet<ModelProperty>();
                                if (remProp.addAffectedOptionalProperties != null) props.UnionWith(remProp.addAffectedOptionalProperties);
                                if (modelProperty.addAffectedOptionalProperties != null) props.UnionWith(modelProperty.addAffectedOptionalProperties);
                                if (remProp.addAffectedProperties != null) props.ExceptWith(remProp.addAffectedProperties);
                                props.Remove(remProp);
                                Interlocked.Exchange(ref this.addAffectedOptionalProperties, props);
                            }
                        }
                    }
                }
            }
        }

        private void RegisterRemoveAffectedProperty(ModelProperty modelProperty, bool optional)
        {
            if (modelProperty == null) return;
            HashSet<ModelProperty> props;
            HashSet<ModelProperty> addProps = new HashSet<ModelProperty>();
            lock (this)
            {
                addProps.Add(this);
                if (this.addAffectedProperties != null) addProps.UnionWith(this.addAffectedProperties);
                if (this.addAffectedOptionalProperties != null) addProps.UnionWith(this.addAffectedOptionalProperties);
            }
            foreach (var addProp in addProps)
            {
                lock (addProp)
                {
                    bool addOptional = false;
                    if (this.addAffectedOptionalProperties?.Contains(addProp) ?? false) addOptional = true;
                    if (this.addAffectedProperties?.Contains(addProp) ?? false) addOptional = false;
                    if (addProp == this) addOptional = false;
                    if (optional || addOptional)
                    {
                        props = new HashSet<ModelProperty>();
                        props.Add(modelProperty);
                        if (addProp.removeAffectedOptionalProperties != null) props.UnionWith(addProp.removeAffectedOptionalProperties);
                        if (modelProperty.removeAffectedProperties != null) props.UnionWith(modelProperty.removeAffectedProperties);
                        if (modelProperty.removeAffectedOptionalProperties != null) props.UnionWith(modelProperty.removeAffectedOptionalProperties);
                        props.Remove(addProp);
                        if (addProp.removeAffectedProperties != null) props.ExceptWith(addProp.removeAffectedProperties);
                        Interlocked.Exchange(ref addProp.removeAffectedOptionalProperties, props);
                    }
                    else
                    {
                        if (addProp.removeAffectedProperties == null || !addProp.removeAffectedProperties.Contains(modelProperty))
                        {
                            if (addProp.removeAffectedOptionalProperties?.Contains(modelProperty) ?? false)
                            {
                                props = new HashSet<ModelProperty>(addProp.removeAffectedOptionalProperties);
                                props.Remove(modelProperty);
                                Interlocked.Exchange(ref addProp.removeAffectedOptionalProperties, props);
                            }
                            props = new HashSet<ModelProperty>();
                            props.Add(modelProperty);
                            if (addProp.removeAffectedProperties != null) props.UnionWith(addProp.removeAffectedProperties);
                            if (modelProperty.removeAffectedProperties != null) props.UnionWith(modelProperty.removeAffectedProperties);
                            props.Remove(addProp);
                            Interlocked.Exchange(ref addProp.removeAffectedProperties, props);
                            if (modelProperty.removeAffectedOptionalProperties != null)
                            {
                                props = new HashSet<ModelProperty>();
                                if (addProp.removeAffectedOptionalProperties != null) props.UnionWith(addProp.removeAffectedOptionalProperties);
                                if (modelProperty.removeAffectedOptionalProperties != null) props.UnionWith(modelProperty.removeAffectedOptionalProperties);
                                if (addProp.removeAffectedProperties != null) props.ExceptWith(addProp.removeAffectedProperties);
                                props.Remove(addProp);
                                Interlocked.Exchange(ref this.removeAffectedOptionalProperties, props);
                            }
                        }
                    }
                }
            }
        }

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
            lock (ModelProperty.declaredProperties)
            {
                ModelProperty.declaredProperties.TryGetValue(declaringType, out propertyList);
            }
            if (propertyList != null)
            {
                lock (propertyList)
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
                    throw new ModelException("Property '" + property + "' is already registered to '" + property.ImmutableTypeInfo.OwningType.FullName + "' as '" + propertyList[property.Name] + "'.");
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
            lock (ModelProperty.cachedTypes)
            {
                if (ModelProperty.cachedTypes.TryGetValue(type, out typeCache))
                {
                    return typeCache;
                }
            }
            typeCache = new TypeCache();
            typeCache.allProperties = new List<ModelProperty>();
            Dictionary<string, ModelProperty> propertyList;
            lock (ModelProperty.ownedProperties)
            {
                ModelProperty.ownedProperties.TryGetValue(type, out propertyList);
            }
            if (propertyList != null)
            {
                lock (propertyList)
                {
                    typeCache.allProperties.AddRange(propertyList.Values);
                    typeCache.declaredProperties.AddRange(propertyList.Values);
                    typeCache.properties.AddRange(propertyList.Values);
                }
            }
            foreach (var super in type.GetInterfaces())
            {
                var superProperties = ModelProperty.GetCachedType(super).allProperties;
                foreach (var prop in superProperties)
                {
                    typeCache.allProperties.Add(prop);
                    if (!typeCache.properties.Any(p => p.Name == prop.Name))
                    {
                        typeCache.properties.Add(prop);
                    }
                }
            }
            lock (ModelProperty.cachedTypes)
            {
                ModelProperty.cachedTypes[type] = typeCache;
            }
            return typeCache;
        }

        public static IReadOnlyList<ModelProperty> GetPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedType(owningType).properties;
        }

        public static IReadOnlyList<ModelProperty> GetDeclaredPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedType(owningType).declaredProperties;
        }

        public static IReadOnlyList<ModelProperty> GetAllPropertiesForType(System.Type owningType)
        {
            return ModelProperty.GetCachedType(owningType).allProperties;
        }

        public override string ToString()
        {
            return this.DeclaringType.FullName + "." + this.DeclaredName;
        }

        public override int GetHashCode()
        {
            return this.DeclaringType.GetHashCode() * 59 + this.DeclaredName.GetHashCode();
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
