using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Languages.Meta.Model;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.Modeling
{
    [Flags]
    internal enum ModelPropertyFlags : uint
    {
        None = 0x0000,
        ModelObject = 0x0001,
        Collection = 0x0002,
        Readonly = 0x0004,
        Derived = 0x0008,
        DerivedUnion = 0x0010,
        NonUnique = 0x0020,
        NonNull = 0x0040,
        Containment = 0x0080
    }

    [Flags]
    internal enum MetaModelPropertyFlags : uint
    {
        None = 0x0000,
        Name = 0x0001,
        Type = 0x0002,
        Member = 0x0004,
        NonMember = 0x0008,
        Import = 0x0010,
        BaseScope = 0x0020,
        Local = 0x0040,
        Static = 0x0080
    }

    internal enum ModelPropertyInitState
    {
        None,
        FlagsSet,
        Initialized
    }

    public sealed class ModelProperty
    {
        private static object lockObject = new object();
        private ModelPropertyInitState state;
        private ModelObjectDescriptor declaringDescriptor;
        private string name;
        private ModelPropertyFlags flags;
        private MetaModelPropertyFlags metaFlags;
        private ModelPropertyTypeInfo immutableTypeInfo;
        private ModelPropertyTypeInfo mutableTypeInfo;
        private ImmutableList<Attribute> annotations;
        private ImmutableList<ModelProperty> subsettedProperties;
        private ImmutableList<ModelProperty> redefinedProperties;
        private ImmutableList<ModelProperty> oppositeProperties;
        private Lazy<MetaProperty> metaProperty = null;

        private ModelProperty(ModelObjectDescriptor declaringDescriptor, string name, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo, Func<MetaProperty> metaProperty)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (immutableTypeInfo == null) throw new ArgumentNullException(nameof(immutableTypeInfo));
            if (mutableTypeInfo == null) throw new ArgumentNullException(nameof(mutableTypeInfo));
            if ((immutableTypeInfo.CollectionType == null && mutableTypeInfo.CollectionType != null) ||
                (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType == null))
            {
                throw new ArgumentException("The immutable and mutable types must must be of the same kind: either a single value or a collection.");
            }
            this.declaringDescriptor = declaringDescriptor;
            this.name = name;
            this.flags = ModelPropertyFlags.None;
            if (typeof(ImmutableObjectBase).IsAssignableFrom(immutableTypeInfo.Type) || typeof(MutableObjectBase).IsAssignableFrom(mutableTypeInfo.Type))
            {
                this.flags |= ModelPropertyFlags.ModelObject;
            }
            if (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType != null)
            {
                this.flags |= ModelPropertyFlags.Collection;
            }
            this.immutableTypeInfo = immutableTypeInfo;
            this.mutableTypeInfo = mutableTypeInfo;
            FieldInfo info = declaringDescriptor.DescriptorType.GetField(name + "Property", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (info == null) throw new InvalidOperationException("Cannot find static field '" + name + "Property' in " + declaringDescriptor.DescriptorType.FullName + ".");
            this.annotations = info.GetCustomAttributes().ToImmutableList();
            this.state = ModelPropertyInitState.None;
            this.subsettedProperties = ImmutableList<ModelProperty>.Empty;
            this.redefinedProperties = ImmutableList<ModelProperty>.Empty;
            this.oppositeProperties = ImmutableList<ModelProperty>.Empty;
            if (metaProperty != null) this.metaProperty = new Lazy<MetaProperty>(metaProperty, true);
            else this.metaProperty = new Lazy<MetaProperty>(() => null, true);
        }

        public static ModelProperty Register(Type declaringType, string name, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo, Func<MetaProperty> metaProperty = null)
        {
            ModelObjectDescriptor descriptor = ModelObjectDescriptor.GetDescriptorForDescriptorType(declaringType);
            ModelProperty result = new ModelProperty(descriptor, name, immutableTypeInfo, mutableTypeInfo, metaProperty);
            descriptor.AddProperty(result);
            return result;
        }

        public static ModelProperty Register(Type declaringType, string name, Type valueType)
        {
            ModelObjectDescriptor descriptor = ModelObjectDescriptor.GetDescriptorForDescriptorType(declaringType);
            ModelProperty result = new ModelProperty(descriptor, name, new ModelPropertyTypeInfo(valueType, null), new ModelPropertyTypeInfo(valueType, null), null);
            descriptor.AddProperty(result);
            return result;
        }

        public ModelObjectDescriptor DeclaringDescriptor { get { return this.declaringDescriptor; } }
        public string Name { get { return this.name; } }
        public bool IsModelObject { get { return this.flags.HasFlag(ModelPropertyFlags.ModelObject); } }
        public bool IsCollection { get { return this.flags.HasFlag(ModelPropertyFlags.Collection); } }
        public bool IsReadonly
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.flags.HasFlag(ModelPropertyFlags.Readonly);
            }
        }
        public bool IsDerived
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.flags.HasFlag(ModelPropertyFlags.Derived);
            }
        }
        public bool IsDerivedUnion
        {
            get
            {
                if (this.state != ModelPropertyInitState.Initialized) this.Initialize();
                return this.flags.HasFlag(ModelPropertyFlags.DerivedUnion);
            }
        }
        public bool IsNonNull
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.flags.HasFlag(ModelPropertyFlags.NonNull);
            }
        }
        public bool IsUnique
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return !this.flags.HasFlag(ModelPropertyFlags.NonUnique);
            }
        }
        public bool IsContainment
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.flags.HasFlag(ModelPropertyFlags.Containment);
            }
        }

        public bool IsName
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.Name);
            }
        }
        public bool IsType
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.Type);
            }
        }
        public bool IsLocal
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.Local);
            }
        }
        public bool CanResolve
        {
            get
            {
                return (this.IsContainment && !this.IsNonMember) || this.IsMember;
            }
        }
        public bool IsMember
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.Member);
            }
        }
        public bool IsStatic
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.Static);
            }
        }
        public bool IsStaticMember
        {
            get { return this.IsMember && this.IsStatic; }
        }
        public bool IsNonMember
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.NonMember);
            }
        }
        public bool IsImport
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.Import);
            }
        }
        public bool IsBaseScope
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.BaseScope);
            }
        }


        public ModelPropertyTypeInfo ImmutableTypeInfo { get { return this.immutableTypeInfo; } }
        public ModelPropertyTypeInfo MutableTypeInfo { get { return this.mutableTypeInfo; } }
        public ImmutableList<Attribute> Annotations { get { return this.annotations; } }
        public ImmutableList<ModelProperty> SubsettedProperties
        {
            get
            {
                if (this.state != ModelPropertyInitState.Initialized) this.Initialize();
                return this.subsettedProperties;
            }
        }
        public ImmutableList<ModelProperty> RedefinedProperties
        {
            get
            {
                if (this.state != ModelPropertyInitState.Initialized) this.Initialize();
                return this.redefinedProperties;
            }
        }
        public ImmutableList<ModelProperty> OppositeProperties
        {
            get
            {
                if (this.state != ModelPropertyInitState.Initialized) this.Initialize();
                return this.oppositeProperties;
            }
        }
        public MetaProperty MetaProperty
        {
            get { return this.metaProperty.Value; }
        }

        private void InitializeFlags()
        {
            if (this.state == ModelPropertyInitState.Initialized) return;
            lock (ModelProperty.lockObject)
            {
                if (this.state == ModelPropertyInitState.Initialized) return;
                foreach (var annot in this.annotations)
                {
                    if (annot is ReadonlyAttribute)
                    {
                        this.flags |= ModelPropertyFlags.Readonly;
                    }
                    else if (annot is DerivedAttribute)
                    {
                        this.flags |= ModelPropertyFlags.Derived | ModelPropertyFlags.Readonly;
                    }
                    else if (annot is NonUniqueAttribute)
                    {
                        this.flags |= ModelPropertyFlags.NonUnique;
                    }
                    else if (annot is NonNullAttribute)
                    {
                        this.flags |= ModelPropertyFlags.NonNull;
                    }
                    else if (annot is ContainmentAttribute)
                    {
                        this.flags |= ModelPropertyFlags.Containment;
                    }
                    else if (annot is NameAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.Name;
                    }
                    else if (annot is TypeAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.Type;
                    }
                    else if (annot is MemberAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.Member;
                    }
                    else if (annot is NonMemberAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.NonMember;
                    }
                    else if (annot is ImportAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.Import;
                    }
                    else if (annot is BaseScopeAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.BaseScope;
                    }
                }
                this.state = ModelPropertyInitState.FlagsSet;
            }
        }

        public void Initialize()
        {
            if (this.state == ModelPropertyInitState.Initialized) return;
            lock (ModelProperty.lockObject)
            {
                if (this.state == ModelPropertyInitState.Initialized) return;
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                foreach (var annot in this.annotations)
                {
                    if (annot is SubsetsAttribute)
                    {
                        SubsetsAttribute propAnnot = (SubsetsAttribute)annot;
                        ModelObjectDescriptor descriptor = ModelObjectDescriptor.GetDescriptorForDescriptorType(propAnnot.DeclaringType);
                        ModelProperty prop = descriptor.GetDeclaredProperty(propAnnot.PropertyName);
                        if (prop == null)
                        {
                            throw new InvalidOperationException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetted property cannot be found.");
                        }
                        if ((descriptor == this.declaringDescriptor || this.declaringDescriptor.AllBaseDescriptors.Contains(descriptor)))
                        {
                            if (!this.IsCollection || !this.IsUnique) throw new InvalidOperationException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetting property must be a collection of unique values.");
                            if (!prop.IsCollection || !prop.IsUnique) throw new InvalidOperationException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetted property must be a collection of unique values.");
                            this.RegisterSubsettedProperty(prop);
                        }
                        else
                        {
                            throw new InvalidOperationException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetted property must come from the current type or from a base type.");
                        }
                    }
                    else if (annot is RedefinesAttribute)
                    {
                        RedefinesAttribute propAnnot = (RedefinesAttribute)annot;
                        ModelObjectDescriptor descriptor = ModelObjectDescriptor.GetDescriptorForDescriptorType(propAnnot.DeclaringType);
                        ModelProperty prop = descriptor.GetDeclaredProperty(propAnnot.PropertyName);
                        if (prop == null)
                        {
                            throw new InvalidOperationException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefined property cannot be found.");
                        }
                        if ((descriptor == this.declaringDescriptor || this.declaringDescriptor.AllBaseDescriptors != null && this.declaringDescriptor.AllBaseDescriptors.Contains(descriptor)))
                        {
                            if (this.IsCollection ^ prop.IsCollection) throw new InvalidOperationException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefining and the redefined property must be of the same kind: either a single value or a collection.");
                            if (this.IsCollection && prop.IsCollection)
                            {
                                if (this.IsUnique ^ prop.IsUnique) throw new InvalidOperationException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefining and the redefined property must have the same uniqueness.");
                            }
                            this.RegisterRedefinedProperty(prop);
                        }
                        else
                        {
                            throw new InvalidOperationException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefined property must come from the current type or from a base type.");
                        }
                    }
                    else if (annot is OppositeAttribute)
                    {
                        OppositeAttribute propAnnot = (OppositeAttribute)annot;
                        ModelObjectDescriptor descriptor = ModelObjectDescriptor.GetDescriptorForDescriptorType(propAnnot.DeclaringType);
                        ModelProperty prop = descriptor.GetDeclaredProperty(propAnnot.PropertyName);
                        if (prop == null)
                        {
                            throw new InvalidOperationException("Error in setting opposite property: " + this.FullDeclaredName + "->" + propAnnot.DeclaringType+"."+propAnnot.PropertyName + ". The opposite property cannot be found.");
                        }
                        if (!this.IsUnique) throw new InvalidOperationException("Error in setting opposite property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". A property which has an opposite must be either a single value or a unique collection.");
                        bool foundThisProperty = false;
                        foreach (var oppositeAnnot in prop.annotations)
                        {
                            if (oppositeAnnot is OppositeAttribute)
                            {
                                OppositeAttribute propOppositeAnnot = (OppositeAttribute)oppositeAnnot;
                                if (propOppositeAnnot.DeclaringType == this.declaringDescriptor.DescriptorType &&
                                    propOppositeAnnot.PropertyName == this.name)
                                {
                                    foundThisProperty = true;
                                    break;
                                }
                            }
                        }
                        if (foundThisProperty)
                        {
                            this.RegisterOppositeProperty(prop);
                        }
                        else
                        {
                            throw new InvalidOperationException("Error in setting opposite property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". Opposite properties must be mutual.");
                        }
                    }
                    else if (annot is DerivedUnionAttribute)
                    {
                        if (!this.IsCollection || !this.IsUnique) throw new InvalidOperationException("Error in property: " + this.FullDeclaredName + ". A derived union property must be a collection of unique values.");
                        this.flags |= ModelPropertyFlags.DerivedUnion | ModelPropertyFlags.Readonly;
                    }
                }
                this.state = ModelPropertyInitState.Initialized;
            }
        }

        private void RegisterSubsettedProperty(ModelProperty property)
        {
            ImmutableList<ModelProperty> oldProperties;
            ImmutableList<ModelProperty> newProperties;
            do
            {
                oldProperties = this.subsettedProperties;
                if (!oldProperties.Contains(property))
                {
                    newProperties = oldProperties.Add(property);
                }
                else
                {
                    newProperties = oldProperties;
                }
            } while (Interlocked.CompareExchange(ref this.subsettedProperties, newProperties, oldProperties) != oldProperties);
        }

        private void RegisterRedefinedProperty(ModelProperty property)
        {
            ImmutableList<ModelProperty> oldProperties;
            ImmutableList<ModelProperty> newProperties;
            do
            {
                oldProperties = this.redefinedProperties;
                if (!oldProperties.Contains(property))
                {
                    newProperties = oldProperties.Add(property);
                }
                else
                {
                    newProperties = oldProperties;
                }
            } while (Interlocked.CompareExchange(ref this.redefinedProperties, newProperties, oldProperties) != oldProperties);
        }

        private void RegisterOppositeProperty(ModelProperty property)
        {
            ImmutableList<ModelProperty> oldProperties;
            ImmutableList<ModelProperty> newProperties;
            do
            {
                oldProperties = this.oppositeProperties;
                if (!oldProperties.Contains(property))
                {
                    newProperties = oldProperties.Add(property);
                }
                else
                {
                    newProperties = oldProperties;
                }
            } while (Interlocked.CompareExchange(ref this.oppositeProperties, newProperties, oldProperties) != oldProperties);
        }

        public string FullDeclaredName
        {
            get { return this.DeclaringDescriptor.DescriptorType.FullName + "." + this.Name; }
        }

        public override string ToString()
        {
            return this.DeclaringDescriptor.DescriptorType.Name + "." + this.Name;
        }
    }

    public sealed class ModelPropertyTypeInfo
    {
        private System.Type type;
        private System.Type collectionType;

        public ModelPropertyTypeInfo(System.Type type, System.Type collectionType)
        {
            this.type = type;
            this.collectionType = collectionType;
        }

        public System.Type Type { get { return this.type; } }
        public System.Type CollectionType { get { return this.collectionType; } }
    }

    public sealed class ModelPropertyInfo
    {
        private ModelProperty representingProperty;
        private ImmutableHashSet<ModelProperty> equivalentProperties;
        private ImmutableHashSet<ModelProperty> supersetProperties;
        private ImmutableHashSet<ModelProperty> subsetProperties;
        private ImmutableHashSet<ModelProperty> subsettedProperties;
        private ImmutableHashSet<ModelProperty> subsettingProperties;
        private ImmutableHashSet<ModelProperty> derivedUnionProperties;
        private ImmutableHashSet<ModelProperty> oppositeProperties;

        internal ModelPropertyInfo(ModelProperty property)
        {
            this.representingProperty = null;
            this.equivalentProperties = ImmutableHashSet<ModelProperty>.Empty;
            this.supersetProperties = ImmutableHashSet<ModelProperty>.Empty;
            this.subsetProperties = ImmutableHashSet<ModelProperty>.Empty;
            this.subsettedProperties = ImmutableHashSet<ModelProperty>.Empty;
            this.subsettingProperties = ImmutableHashSet<ModelProperty>.Empty;
            this.derivedUnionProperties = ImmutableHashSet<ModelProperty>.Empty;
            this.oppositeProperties = ImmutableHashSet<ModelProperty>.Empty;
        }

        public ModelProperty RepresentingProperty { get { return this.representingProperty; } }
        public ImmutableHashSet<ModelProperty> EquivalentProperties { get { return this.equivalentProperties; } }
        public ImmutableHashSet<ModelProperty> SupersetProperties { get { return this.supersetProperties; } }
        public ImmutableHashSet<ModelProperty> SubsetProperties { get { return this.subsetProperties; } }
        public ImmutableHashSet<ModelProperty> SubsettedProperties { get { return this.subsettedProperties; } }
        public ImmutableHashSet<ModelProperty> SubsettingProperties { get { return this.subsettingProperties; } }
        public ImmutableHashSet<ModelProperty> DerivedUnionProperties { get { return this.derivedUnionProperties; } }
        public ImmutableHashSet<ModelProperty> OppositeProperties { get { return this.oppositeProperties; } }

        internal void AddRedefinedProperty(ModelObjectDescriptor descriptor, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (!this.equivalentProperties.Contains(property))
            {
                this.equivalentProperties = this.equivalentProperties.Add(property);
                if (firstCall)
                {
                    ModelPropertyInfo propInfo = descriptor.GetOrCreatePropertyInfo(property);
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        propInfo.AddRedefinedProperty(descriptor, eqProp, false);
                    }
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = descriptor.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddRedefinedProperty(descriptor, property, false);
                    }
                }
            }
        }

        internal void SetRepresentingProperty(ModelObjectDescriptor descriptor, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            this.representingProperty = property;
            if (firstCall)
            {
                foreach (var eqProp in this.equivalentProperties)
                {
                    ModelPropertyInfo eqPropInfo = descriptor.GetOrCreatePropertyInfo(eqProp);
                    eqPropInfo.SetRepresentingProperty(descriptor, property, false);
                }
            }
        }

        internal void AddSupersetProperty(ModelObjectDescriptor descriptor, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.supersetProperties.Contains(property))
            {
                this.supersetProperties = this.supersetProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = descriptor.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddSupersetProperty(descriptor, property, false);
                    }
                }
            }
        }

        internal void AddSubsetProperty(ModelObjectDescriptor descriptor, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.subsetProperties.Contains(property))
            {
                this.subsetProperties = this.subsetProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = descriptor.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddSubsetProperty(descriptor, property, false);
                    }
                }
            }
        }
        internal void AddSubsettedProperty(ModelObjectDescriptor descriptor, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.subsettedProperties.Contains(property))
            {
                this.subsettedProperties = this.subsettedProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = descriptor.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddSubsettedProperty(descriptor, property, false);
                    }
                }
            }
        }

        internal void AddSubsettingProperty(ModelObjectDescriptor descriptor, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.subsettingProperties.Contains(property))
            {
                this.subsettingProperties = this.subsettingProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = descriptor.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddSubsettingProperty(descriptor, property, false);
                    }
                }
            }
        }

        internal void AddDerivedUnionProperty(ModelObjectDescriptor descriptor, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.derivedUnionProperties.Contains(property))
            {
                this.derivedUnionProperties = this.derivedUnionProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = descriptor.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddDerivedUnionProperty(descriptor, property, false);
                    }
                }
            }
        }

        internal void AddOppositeProperty(ModelObjectDescriptor descriptor, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (!this.oppositeProperties.Contains(property))
            {
                this.oppositeProperties = this.oppositeProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = descriptor.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddOppositeProperty(descriptor, property, false);
                    }
                }
            }
        }
    }
}
