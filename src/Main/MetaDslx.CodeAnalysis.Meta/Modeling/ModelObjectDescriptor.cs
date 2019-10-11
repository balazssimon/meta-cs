using MetaDslx.Modeling.Internal;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling
{

    [Flags]
    internal enum MetaModelObjectFlags : uint
    {
        None = 0x0000,
        Scope = 0x0001,
        LocalScope = 0x0002,
        Type = 0x0004,
        Local = 0x0008
    }

    public sealed class ModelObjectDescriptor
    {
        private static Type[] EmptyTypeArray = new Type[0];
        private static object[] EmptyObjectArray = new object[0];

        private static ImmutableDictionary<Type, ModelObjectDescriptor> descriptors = ImmutableDictionary<Type, ModelObjectDescriptor>.Empty;
        private static ImmutableDictionary<Type, ModelObjectDescriptor> immutableTypes = ImmutableDictionary<Type, ModelObjectDescriptor>.Empty;
        private static ImmutableDictionary<Type, ModelObjectDescriptor> mutableTypes = ImmutableDictionary<Type, ModelObjectDescriptor>.Empty;

        private bool initialized;
        private bool initializedBaseDescriptors;
        private Type descriptorType;
        private GreenObject emptyGreenObject;
        private MetaModelObjectFlags metaFlags;
        private ModelObjectDescriptorAttribute descriptor;
        private ConstructorInfo _idConstructor;
        private Type idType;
        private Type immutableType;
        private Type mutableType;
        private ModelProperty nameProperty;
        private ModelProperty typeProperty;
        private ImmutableArray<Attribute> annotations;
        private ImmutableList<ModelObjectDescriptor> baseDescriptors;
        private ImmutableList<ModelProperty> declaredProperties;
        private ImmutableDictionary<ModelProperty, ModelPropertyInfo> propertyInfo;
        private ImmutableArray<ModelProperty> properties;

        private ModelObjectDescriptor(Type descriptorType)
        {
            this.initialized = false;
            this.initializedBaseDescriptors = false;
            this.descriptorType = descriptorType;
            this.annotations = descriptorType.GetCustomAttributes(false).OfType<Attribute>().ToImmutableArray();
            this.metaFlags = MetaModelObjectFlags.None;
            foreach (var annot in this.annotations)
            {
                if (annot is ModelObjectDescriptorAttribute)
                {
                    ModelObjectDescriptorAttribute da = (ModelObjectDescriptorAttribute)annot;
                    this.idType = da.IdType;
                    this.immutableType = da.ImmutableType;
                    this.mutableType = da.MutableType;
                }
                else if (annot is LocalAttribute)
                {
                    this.metaFlags |= MetaModelObjectFlags.Local;
                }
                else if (annot is ScopeAttribute)
                {
                    this.metaFlags |= MetaModelObjectFlags.Scope;
                }
                else if (annot is LocalScopeAttribute)
                {
                    this.metaFlags |= MetaModelObjectFlags.LocalScope;
                }
                else if (annot is TypeAttribute)
                {
                    this.metaFlags |= MetaModelObjectFlags.Type;
                }
            }
            this.nameProperty = null;
            this.typeProperty = null;
            this.emptyGreenObject = GreenObject.Empty;
            this.baseDescriptors = ImmutableList<ModelObjectDescriptor>.Empty;
            this.declaredProperties = ImmutableList<ModelProperty>.Empty;
            this.propertyInfo = ImmutableDictionary<ModelProperty, ModelPropertyInfo>.Empty;
            this.properties = ImmutableArray<ModelProperty>.Empty;
        }

        public static ModelObjectDescriptor GetDescriptor(Type type)
        {
            if (type == null) return null;
            ModelObjectDescriptor result = null;
            if (ModelObjectDescriptor.immutableTypes.TryGetValue(type, out result))
            {
                return result;
            }
            if (ModelObjectDescriptor.mutableTypes.TryGetValue(type, out result))
            {
                return result;
            }
            return result;
        }

        public static ModelObjectDescriptor GetDescriptorForDescriptorType(Type descriptorType)
        {
            ImmutableDictionary<Type, ModelObjectDescriptor> oldDescriptors;
            ImmutableDictionary<Type, ModelObjectDescriptor> newDescriptors;
            ModelObjectDescriptor newDescriptor = null;
            do
            {
                oldDescriptors = ModelObjectDescriptor.descriptors;
                ModelObjectDescriptor result;
                if (oldDescriptors.TryGetValue(descriptorType, out result))
                {
                    newDescriptor = result;
                    break;
                }
                else
                {
                    if (newDescriptor == null) newDescriptor = new ModelObjectDescriptor(descriptorType);
                    newDescriptors = oldDescriptors.Add(descriptorType, newDescriptor);
                }
            } while (Interlocked.CompareExchange(ref ModelObjectDescriptor.descriptors, newDescriptors, oldDescriptors) != oldDescriptors);
            if (newDescriptor.immutableType != null)
            {
                do
                {
                    oldDescriptors = ModelObjectDescriptor.immutableTypes;
                    ModelObjectDescriptor result;
                    if (oldDescriptors.TryGetValue(newDescriptor.immutableType, out result))
                    {
                        break;
                    }
                    else
                    {
                        newDescriptors = oldDescriptors.Add(newDescriptor.immutableType, newDescriptor);
                    }
                } while (Interlocked.CompareExchange(ref ModelObjectDescriptor.immutableTypes, newDescriptors, oldDescriptors) != oldDescriptors);
            }
            if (newDescriptor.mutableType != null)
            {
                do
                {
                    oldDescriptors = ModelObjectDescriptor.mutableTypes;
                    ModelObjectDescriptor result;
                    if (oldDescriptors.TryGetValue(newDescriptor.mutableType, out result))
                    {
                        break;
                    }
                    else
                    {
                        newDescriptors = oldDescriptors.Add(newDescriptor.mutableType, newDescriptor);
                    }
                } while (Interlocked.CompareExchange(ref ModelObjectDescriptor.mutableTypes, newDescriptors, oldDescriptors) != oldDescriptors);
            }
            return newDescriptor;
        }

        internal ModelProperty GetDeclaredProperty(string name)
        {
            RuntimeHelpers.RunClassConstructor(this.descriptorType.TypeHandle);
            return this.declaredProperties.FirstOrDefault(p => p.Name == name);
        }

        public static ImmutableDictionary<Type, ModelObjectDescriptor> Descriptors
        {
            get { return ModelObjectDescriptor.descriptors; }
        }

        private void AddBaseDescriptor(ModelObjectDescriptor baseDescriptor)
        {
            if (this.initializedBaseDescriptors) throw new InvalidOperationException("Cannot add a base descriptor to an initialized descriptor.");
            ImmutableList<ModelObjectDescriptor> oldBaseDescriptors;
            ImmutableList<ModelObjectDescriptor> newBaseDescriptors;
            do
            {
                oldBaseDescriptors = this.baseDescriptors;
                if (!oldBaseDescriptors.Contains(baseDescriptor))
                {
                    newBaseDescriptors = oldBaseDescriptors.Add(baseDescriptor);
                }
                else
                {
                    newBaseDescriptors = oldBaseDescriptors;
                }
            } while (Interlocked.CompareExchange(ref this.baseDescriptors, newBaseDescriptors, oldBaseDescriptors) != oldBaseDescriptors);
            if (baseDescriptor.IsScope)
            {
                this.metaFlags |= MetaModelObjectFlags.Scope;
            }
            if (baseDescriptor.IsType)
            {
                this.metaFlags |= MetaModelObjectFlags.Type;
            }
        }

        internal void AddProperty(ModelProperty property)
        {
            if (this.initialized) throw new InvalidOperationException("Cannot register a property into an initialized descriptor.");
            if (this.declaredProperties.Any(p => p.Name == property.Name))
            {
                throw new InvalidOperationException("A property with name '" + property.Name + "' is already declared for " + this.ToString());
            }
            else
            {
                ImmutableList<ModelProperty> oldDeclaredProperties;
                ImmutableList<ModelProperty> newDeclaredProperties;
                do
                {
                    oldDeclaredProperties = this.declaredProperties;
                    newDeclaredProperties = oldDeclaredProperties.Add(property);
                } while (Interlocked.CompareExchange(ref this.declaredProperties, newDeclaredProperties, oldDeclaredProperties) != oldDeclaredProperties);
            }
        }

        internal bool Initialized { get { return this.initialized; } }
        internal Type DescriptorType { get { return this.descriptorType; } }
        public ImmutableArray<Attribute> Annotations { get { return this.annotations; } }

        public string Name => this.ImmutableType.Name;

        public Type ImmutableType
        {
            get { return this.immutableType; }
        }

        public Type MutableType
        {
            get { return this.mutableType; }
        }

        public ObjectId CreateObjectId()
        {
            if (_idConstructor == null)
            {
                Interlocked.CompareExchange(ref _idConstructor, idType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, EmptyTypeArray, null), null);
            }
            return (ObjectId)_idConstructor.Invoke(EmptyObjectArray);
        }

        public MutableObjectBase CreateMutable(MutableModel model, bool weakReference = false, bool makeCreated = true)
        {
            var obj = model.CreateObject(this.CreateObjectId(), false);
            obj.MCallInit();
            if (makeCreated) obj.MMakeCreated();
            return obj;
        }

        internal ImmutableObjectBase CreateImmutable(ImmutableModel model)
        {
            return this.CreateObjectId().CreateImmutable(model);
        }

        public ImmutableList<ModelObjectDescriptor> BaseDescriptors
        {
            get
            {
                if (!this.initializedBaseDescriptors) this.InitializeBaseDescriptors();
                return this.baseDescriptors;
            }
        }

        private ImmutableArray<ModelObjectDescriptor> lazyAllBaseDescriptors;
        public ImmutableArray<ModelObjectDescriptor> AllBaseDescriptors
        {
            get
            {
                if (lazyAllBaseDescriptors == default)
                {
                    var builder = ArrayBuilder<ModelObjectDescriptor>.GetInstance();
                    try
                    {
                        this.CollectAllBaseDescriptors(builder);
                    }
                    finally
                    {
                        ImmutableInterlocked.InterlockedCompareExchange(ref lazyAllBaseDescriptors, builder.ToImmutableAndFree(), default);
                    }
                }
                return lazyAllBaseDescriptors;
            }
        }

        private void CollectAllBaseDescriptors(ArrayBuilder<ModelObjectDescriptor> baseDescriptors)
        {
            foreach (var item in this.BaseDescriptors)
            {
                if (!baseDescriptors.Contains(item))
                {
                    foreach (var baseItem in item.AllBaseDescriptors)
                    {
                        if (!baseDescriptors.Contains(baseItem))
                        {
                            baseDescriptors.Add(baseItem);
                        }
                    }
                    baseDescriptors.Add(item);
                }
            }
        }

        public ImmutableList<ModelProperty> DeclaredProperties { get { return this.declaredProperties; } }

        public bool IsLocal
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelObjectFlags.Local);
            }
        }
        public bool IsScope
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelObjectFlags.Scope);
            }
        }
        public bool IsLocalScope
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelObjectFlags.LocalScope);
            }
        }
        public bool IsType
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelObjectFlags.Type);
            }
        }
        public bool HasName
        {
            get { return this.NameProperty != null; }
        }
        public bool HasType
        {
            get { return this.TypeProperty != null; }
        }
        public bool IsName
        {
            get { return this.HasName && !this.IsScope && !this.IsType; }
        }
        public bool IsNamespace
        {
            get { return this.HasName && this.IsScope && !this.IsType; }
        }
        public bool IsNamedType
        {
            get { return this.HasName && this.IsType; }
        }
        public bool IsAnonymousType
        {
            get { return !this.HasName && this.IsType; }
        }

        public ModelProperty NameProperty
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.nameProperty;
            }
        }
        public ModelProperty TypeProperty
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.typeProperty;
            }
        }
        public ImmutableArray<ModelProperty> Properties
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.properties;
            }
        }
        internal ImmutableDictionary<ModelProperty, ModelPropertyInfo> PropertyInfo
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.propertyInfo;
            }
        }
        internal GreenObject EmptyGreenObject
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.emptyGreenObject;
            }
        }

        private void InitializeBaseDescriptors()
        {
            if (this.initializedBaseDescriptors) return;
            lock (this)
            {
                if (this.initializedBaseDescriptors) return;
                foreach (var annot in this.annotations)
                {
                    if (annot is ModelObjectDescriptorAttribute)
                    {
                        ModelObjectDescriptorAttribute descrAnnot = (ModelObjectDescriptorAttribute)annot;
                        foreach (var baseType in descrAnnot.BaseDescriptors)
                        {
                            this.AddBaseDescriptor(ModelObjectDescriptor.GetDescriptorForDescriptorType(baseType));
                        }
                    }
                }
                this.initializedBaseDescriptors = true;
            }
        }

        private void Initialize()
        {
            if (this.initialized) return;
            lock (this)
            {
                if (this.initialized) return;
                this.InitializeBaseDescriptors();
                this.initialized = true;
                RuntimeHelpers.RunClassConstructor(this.descriptorType.TypeHandle);
                this.CreateProperties();
                this.CreatePropertyInfo();
                this.CreateEmptyGreenObject();
            }
        }

        private void CreateProperties()
        {
            var properties = ArrayBuilder<ModelProperty>.GetInstance();
            try
            {
                foreach (var prop in this.declaredProperties)
                {
                    if (prop.IsName)
                    {
                        this.nameProperty = prop;
                    }
                    if (prop.IsType)
                    {
                        this.typeProperty = prop;
                    }
                }
                foreach (var baseDescriptor in this.baseDescriptors.Reverse())
                {
                    foreach (var prop in baseDescriptor.Properties.Reverse())
                    {
                        if (!properties.Contains(prop))
                        {
                            properties.Add(prop);
                            if (this.nameProperty == null && prop.IsName)
                            {
                                this.nameProperty = prop;
                                if (prop.IsLocal)
                                {
                                    this.metaFlags |= MetaModelObjectFlags.Local;
                                }
                            }
                            if (this.typeProperty == null && prop.IsType)
                            {
                                this.typeProperty = prop;
                            }
                        }
                    }
                }
                properties.AddRange(this.declaredProperties);
            }
            finally
            {
                ImmutableInterlocked.InterlockedExchange(ref this.properties, properties.ToImmutableAndFree());
            }
        }

        private void CreatePropertyInfo()
        {
            foreach (var prop in this.properties)
            {
                if (prop.RedefinedProperties.Count > 0)
                {
                    ModelPropertyInfo propInfo = this.GetOrCreatePropertyInfo(prop);
                    propInfo.AddRedefinedProperty(this, prop, true);
                    foreach (var redefinedProp in prop.RedefinedProperties)
                    {
                        propInfo.AddRedefinedProperty(this, redefinedProp, true);
                    }
                }
            }
            foreach (var prop in this.properties)
            {
                ModelPropertyInfo propInfo = this.GetPropertyInfo(prop);
                if (propInfo != null && propInfo.EquivalentProperties.Count > 0)
                {
                    int index = -1;
                    ModelProperty representingProp = null;
                    foreach (var eqProp in propInfo.EquivalentProperties)
                    {
                        int eqIndex = this.properties.IndexOf(eqProp);
                        if (index < 0 || (eqIndex >= 0 && eqIndex < index))
                        {
                            index = eqIndex;
                            representingProp = eqProp;
                        }
                    }
                    Debug.Assert(representingProp != null);
                    if (representingProp != null)
                    {
                        propInfo.SetRepresentingProperty(this, representingProp, true);
                    }
                }
            }
            foreach (var prop in this.properties)
            {
                if (prop.SubsettedProperties.Count > 0)
                {
                    ModelPropertyInfo propInfo = this.GetOrCreatePropertyInfo(prop);
                    foreach (var subsettedProp in prop.SubsettedProperties)
                    {
                        ModelPropertyInfo subsettedPropInfo = this.GetOrCreatePropertyInfo(subsettedProp);
                        propInfo.AddSubsettedProperty(this, subsettedProp, true);
                        subsettedPropInfo.AddSubsettingProperty(this, prop, true);
                        if (subsettedProp.IsDerivedUnion)
                        {
                            propInfo.AddDerivedUnionProperty(this, subsettedProp, true);
                        }
                    }
                }
                if (prop.OppositeProperties.Count > 0)
                {
                    ModelPropertyInfo propInfo = this.GetOrCreatePropertyInfo(prop);
                    foreach (var oppositeProp in prop.OppositeProperties)
                    {
                        propInfo.AddOppositeProperty(this, oppositeProp, true);
                    }
                }
            }
            foreach (var prop in this.properties)
            {
                ModelPropertyInfo propInfo = this.GetPropertyInfo(prop);
                if (propInfo != null && propInfo.SubsettedProperties.Count > 0)
                {
                    List<ModelProperty> supersetProperties = new List<ModelProperty>();
                    ModelProperty repProp = propInfo.RepresentingProperty;
                    if (repProp == null) repProp = prop;
                    supersetProperties.Add(repProp);
                    int i = 0;
                    while (i < supersetProperties.Count)
                    {
                        ModelProperty currentProp = supersetProperties[i];
                        foreach (var subsettedProp in currentProp.SubsettedProperties)
                        {
                            ModelPropertyInfo subsettedPropInfo = this.GetPropertyInfo(subsettedProp);
                            if (subsettedPropInfo != null)
                            {
                                ModelProperty subsettedRepProp = subsettedProp;
                                if (subsettedPropInfo.RepresentingProperty != null) subsettedRepProp = subsettedPropInfo.RepresentingProperty;
                                if (!supersetProperties.Contains(subsettedRepProp))
                                {
                                    supersetProperties.Add(subsettedRepProp);
                                }
                            }
                        }
                        ++i;
                    }
                    supersetProperties.Remove(repProp);
                    foreach (var supersetProp in supersetProperties)
                    {
                        propInfo.AddSupersetProperty(this, supersetProp, true);
                    }
                }
                if (propInfo != null && propInfo.SubsettingProperties.Count > 0)
                {
                    List<ModelProperty> subsetProperties = new List<ModelProperty>();
                    ModelProperty repProp = propInfo.RepresentingProperty;
                    if (repProp == null) repProp = prop;
                    subsetProperties.Add(repProp);
                    int i = 0;
                    while (i < subsetProperties.Count)
                    {
                        ModelProperty currentProp = subsetProperties[i];
                        ModelPropertyInfo currentPropInfo = this.GetPropertyInfo(currentProp);
                        foreach (var subsettedProp in currentPropInfo.SubsettingProperties)
                        {
                            ModelPropertyInfo subsettedPropInfo = this.GetPropertyInfo(subsettedProp);
                            if (subsettedPropInfo != null)
                            {
                                ModelProperty subsettedRepProp = subsettedProp;
                                if (subsettedPropInfo.RepresentingProperty != null) subsettedRepProp = subsettedPropInfo.RepresentingProperty;
                                if (!subsetProperties.Contains(subsettedRepProp))
                                {
                                    subsetProperties.Add(subsettedRepProp);
                                }
                            }
                        }
                        ++i;
                    }
                    subsetProperties.Remove(repProp);
                    foreach (var subsetProp in subsetProperties)
                    {
                        propInfo.AddSubsetProperty(this, subsetProp, true);
                    }
                }
            }
        }

        internal ModelPropertyInfo GetOrCreatePropertyInfo(ModelProperty property)
        {
            ModelPropertyInfo result;
            if (!this.propertyInfo.TryGetValue(property, out result))
            {
                result = new ModelPropertyInfo(property);
                Interlocked.Exchange(ref this.propertyInfo, this.propertyInfo.Add(property, result));
            }
            return result;
        }

        private void CreateEmptyGreenObject()
        {
            Interlocked.Exchange(ref this.emptyGreenObject, GreenObject.CreateWithProperties(this.Properties));
        }

        public bool HasAffectedProperties(ModelProperty property)
        {
            return this.propertyInfo.ContainsKey(property);
        }

        public ModelPropertyInfo GetPropertyInfo(ModelProperty property)
        {
            ModelPropertyInfo result;
            if (this.propertyInfo.TryGetValue(property, out result))
            {
                return result;
            }
            return null;
        }

        public override string ToString()
        {
            if (this.immutableType != null) return this.immutableType.FullName;
            else if (this.mutableType != null) return this.mutableType.FullName;
            else if (this.descriptorType != null) return this.descriptorType.FullName;
            else return base.ToString();
        }
    }

}
