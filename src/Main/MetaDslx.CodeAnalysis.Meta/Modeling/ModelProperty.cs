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
        Ordered = 0x0020,
        NonUnique = 0x0040,
        NonNull = 0x0080,
        Containment = 0x0100
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

    internal interface Slot
    {
        bool IsSimpleSlot { get; }
        ModelProperty EffectiveProperty { get; }
        string Name { get; }

        bool IsModelObject { get; }
        bool IsCollection { get; }
        bool IsReadonly { get; }
        bool IsDerived { get; }
        bool IsDerivedUnion { get; }
        bool IsContainment { get; }
        bool IsNonNull { get; }
        bool IsUnique { get; }
        object DefaultValue { get; }
        Type ImmutableType { get; }
        Type MutableType { get; }

        ImmutableArray<ModelProperty> EquivalentProperties { get; }
        ImmutableArray<Slot> SupersetSlots { get; }
        ImmutableArray<Slot> SubsetSlots { get; }
        ImmutableArray<Slot> SubsettedSlots { get; }
        ImmutableArray<Slot> SubsettingSlots { get; }
        ImmutableArray<Slot> DerivedUnionSlots { get; }
        ImmutableArray<ModelProperty> OppositeProperties { get; }

        bool IsAssignableFrom(Type type, out ModelProperty unassignableProperty);
    }

    public sealed class ModelProperty : Slot
    {
        private static object lockObject = new object();
        private ModelPropertyInitState state;
        private ModelObjectDescriptor declaringDescriptor;
        private string name;
        private ModelPropertyFlags flags;
        private MetaModelPropertyFlags metaFlags;
        private Type immutableType;
        private Type mutableType;
        private ImmutableArray<Attribute> annotations;
        private ImmutableArray<ModelProperty> subsettedProperties;
        private ImmutableArray<ModelProperty> redefinedProperties;
        private ImmutableArray<ModelProperty> oppositeProperties;
        private Lazy<MetaProperty> metaProperty = null;
        private object defaultValue = null;

        private ModelProperty(ModelObjectDescriptor declaringDescriptor, string name, Type immutableType, Type mutableType, Func<MetaProperty> metaProperty, object defaultValue)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (immutableType == null) throw new ArgumentNullException(nameof(immutableType));
            if (mutableType == null) throw new ArgumentNullException(nameof(mutableType));
            this.declaringDescriptor = declaringDescriptor;
            this.name = name;
            this.flags = ModelPropertyFlags.None;
            if (typeof(IModelObject).IsAssignableFrom(immutableType) || typeof(IModelObject).IsAssignableFrom(mutableType))
            {
                this.flags |= ModelPropertyFlags.ModelObject;
            }
            this.immutableType = immutableType;
            this.mutableType = mutableType;
            FieldInfo info = declaringDescriptor.DescriptorType.GetField(name + "Property", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (info == null) throw new InvalidOperationException("Cannot find static field '" + name + "Property' in " + declaringDescriptor.DescriptorType.FullName + ".");
            this.annotations = info.GetCustomAttributes().ToImmutableArray();
            this.state = ModelPropertyInitState.None;
            this.subsettedProperties = ImmutableArray<ModelProperty>.Empty;
            this.redefinedProperties = ImmutableArray<ModelProperty>.Empty;
            this.oppositeProperties = ImmutableArray<ModelProperty>.Empty;
            if (metaProperty != null) this.metaProperty = new Lazy<MetaProperty>(metaProperty, true);
            else this.metaProperty = new Lazy<MetaProperty>(() => null, true);
            this.defaultValue = defaultValue;
        }

        public static ModelProperty Register(Type declaringType, string name, Type immutableType, Type mutableType, Func<MetaProperty> metaProperty = null, object defaultValue = null)
        {
            ModelObjectDescriptor descriptor = ModelObjectDescriptor.GetDescriptorForDescriptorType(declaringType);
            ModelProperty result = new ModelProperty(descriptor, name, immutableType, mutableType, metaProperty, defaultValue);
            descriptor.AddProperty(result);
            return result;
        }

        public static ModelProperty Register(Type declaringType, string name, Type valueType, object defaultValue = null)
        {
            ModelObjectDescriptor descriptor = ModelObjectDescriptor.GetDescriptorForDescriptorType(declaringType);
            ModelProperty result = new ModelProperty(descriptor, name, valueType, valueType, null, defaultValue);
            descriptor.AddProperty(result);
            return result;
        }

        public bool IsSimpleSlot => true;
        ModelProperty Slot.EffectiveProperty => this;

        public ModelObjectDescriptor DeclaringDescriptor { get { return this.declaringDescriptor; } }
        public string Name { get { return this.name; } }
        internal ModelPropertyFlags Flags => this.flags;
        public bool IsModelObject { get { return this.flags.HasFlag(ModelPropertyFlags.ModelObject); } }
        public bool IsCollection
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.flags.HasFlag(ModelPropertyFlags.Collection);
            }
        }
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
        public bool IsOrdered
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.flags.HasFlag(ModelPropertyFlags.Ordered);
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


        public Type ImmutableType { get { return this.immutableType; } }
        public Type MutableType { get { return this.mutableType; } }

        public object DefaultValue
        {
            get
            {
                if (this.ImmutableType.IsValueType)
                {
                    return this.defaultValue ?? Activator.CreateInstance(this.ImmutableType);
                }
                else
                {
                    return this.defaultValue;
                }
            }
        }

        public ImmutableArray<Attribute> Annotations { get { return this.annotations; } }
        public ImmutableArray<ModelProperty> SubsettedProperties
        {
            get
            {
                if (this.state != ModelPropertyInitState.Initialized) this.Initialize();
                return this.subsettedProperties;
            }
        }
        public ImmutableArray<ModelProperty> RedefinedProperties
        {
            get
            {
                if (this.state != ModelPropertyInitState.Initialized) this.Initialize();
                return this.redefinedProperties;
            }
        }
        public ImmutableArray<ModelProperty> OppositeProperties
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
                    else if (annot is CollectionAttribute)
                    {
                        this.flags |= ModelPropertyFlags.Collection;
                    }
                    else if (annot is OrderedAttribute)
                    {
                        this.flags |= ModelPropertyFlags.Ordered;
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
                var subsettedPropertiesBuilder = ArrayBuilder<ModelProperty>.GetInstance();
                var redefinedPropertiesBuilder = ArrayBuilder<ModelProperty>.GetInstance();
                var oppositePropertiesBuilder = ArrayBuilder<ModelProperty>.GetInstance();
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
                            if (!this.IsUnique) throw new InvalidOperationException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetting property must be a collection of unique values.");
                            if (!prop.IsUnique) throw new InvalidOperationException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetted property must be a collection of unique values.");
                            subsettedPropertiesBuilder.Add(prop);
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
                            if (this.IsContainment && !prop.IsContainment) throw new InvalidOperationException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefining property cannot be a containment if the redefined property is not a containment.");
                            redefinedPropertiesBuilder.Add(prop);
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
                            oppositePropertiesBuilder.Add(prop);
                        }
                        else
                        {
                            throw new InvalidOperationException("Error in setting opposite property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". Opposite properties must be mutual.");
                        }
                    }
                    else if (annot is DerivedUnionAttribute)
                    {
                        if (!this.IsUnique) throw new InvalidOperationException("Error in property: " + this.FullDeclaredName + ". A derived union property must be contain unique values.");
                        this.flags |= ModelPropertyFlags.DerivedUnion | ModelPropertyFlags.Readonly;
                    }
                }
                subsettedProperties = subsettedPropertiesBuilder.ToImmutableAndFree();
                redefinedProperties = redefinedPropertiesBuilder.ToImmutableAndFree();
                oppositeProperties = oppositePropertiesBuilder.ToImmutableAndFree();
                this.state = ModelPropertyInitState.Initialized;
            }
        }

        public string FullDeclaredName
        {
            get { return this.DeclaringDescriptor.DescriptorType.FullName + "." + this.Name; }
        }

        ImmutableArray<ModelProperty> Slot.EquivalentProperties => ImmutableArray.Create(this);

        ImmutableArray<Slot> Slot.SupersetSlots => ImmutableArray<Slot>.Empty;

        ImmutableArray<Slot> Slot.SubsetSlots => ImmutableArray<Slot>.Empty;

        ImmutableArray<Slot> Slot.SubsettedSlots => ImmutableArray<Slot>.Empty;

        ImmutableArray<Slot> Slot.SubsettingSlots => ImmutableArray<Slot>.Empty;

        ImmutableArray<Slot> Slot.DerivedUnionSlots => ImmutableArray<Slot>.Empty;

        ImmutableArray<ModelProperty> Slot.OppositeProperties => ImmutableArray<ModelProperty>.Empty;

        bool Slot.IsAssignableFrom(Type type, out ModelProperty unassignableProperty)
        {
            if (this.ImmutableType.IsAssignableFrom(type) || this.MutableType.IsAssignableFrom(type))
            {
                unassignableProperty = null;
                return true;
            }
            else
            {
                unassignableProperty = this;
                return false;
            }
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

        public bool IsSubTypeOf(ModelPropertyTypeInfo superType)
        {
            return superType.Type.IsAssignableFrom(this.Type);
        }
    }

    internal sealed class ComplexSlot : Slot
    {
        private ModelPropertyFlags flags;
        private ModelProperty effectiveProperty;
        private ImmutableArray<ModelProperty> equivalentProperties;
        private ImmutableArray<Slot> supersetSlots;
        private ImmutableArray<Slot> subsetSlots;
        private ImmutableArray<Slot> subsettedSlots;
        private ImmutableArray<Slot> subsettingSlots;
        private ImmutableArray<Slot> derivedUnionSlots;
        private ImmutableArray<ModelProperty> oppositeProperties;

        internal ComplexSlot(ModelPropertyFlags flags, ModelProperty effectiveProperty)
        {
            this.flags = flags;
            this.effectiveProperty = effectiveProperty;
        }

        internal void UpdateSlots(ImmutableArray<ModelProperty> equivalentProperties, ImmutableArray<Slot> supersetSlots, ImmutableArray<Slot> subsetSlots,
            ImmutableArray<Slot> subsettedSlots, ImmutableArray<Slot> subsettingSlots, ImmutableArray<Slot> derivedUnionSlots, ImmutableArray<ModelProperty> oppositeProperties)
        {
            this.equivalentProperties = equivalentProperties;
            this.supersetSlots = supersetSlots;
            this.subsetSlots = subsetSlots;
            this.subsettedSlots = subsettedSlots;
            this.subsettingSlots = subsettingSlots;
            this.derivedUnionSlots = derivedUnionSlots;
            this.oppositeProperties = oppositeProperties;
        }

        public bool IsSimpleSlot => false;
        public ModelProperty EffectiveProperty => this.effectiveProperty;
        public string Name => this.effectiveProperty.Name;
        public ModelPropertyFlags Flags => this.flags;

        public ImmutableArray<ModelProperty> EquivalentProperties => this.equivalentProperties;
        public ImmutableArray<Slot> SupersetSlots => this.supersetSlots; 
        public ImmutableArray<Slot> SubsetSlots => this.subsetSlots;
        public ImmutableArray<Slot> SubsettedSlots => this.subsettedSlots; 
        public ImmutableArray<Slot> SubsettingSlots => this.subsettingSlots;
        public ImmutableArray<Slot> DerivedUnionSlots => this.derivedUnionSlots; 
        public ImmutableArray<ModelProperty> OppositeProperties => this.oppositeProperties; 

        public Type ImmutableType => this.effectiveProperty.ImmutableType;
        public Type MutableType => this.effectiveProperty.MutableType; 

        public object DefaultValue => this.effectiveProperty.DefaultValue;

        public bool IsModelObject => this.flags.HasFlag(ModelPropertyFlags.ModelObject); 
        public bool IsCollection => this.flags.HasFlag(ModelPropertyFlags.Collection); 
        public bool IsReadonly => this.flags.HasFlag(ModelPropertyFlags.Readonly);
        public bool IsDerived => this.flags.HasFlag(ModelPropertyFlags.Derived);
        public bool IsDerivedUnion => this.flags.HasFlag(ModelPropertyFlags.DerivedUnion);
        public bool IsNonNull => this.flags.HasFlag(ModelPropertyFlags.NonNull);
        public bool IsUnique => !this.flags.HasFlag(ModelPropertyFlags.NonUnique);
        public bool IsOrdered => this.flags.HasFlag(ModelPropertyFlags.Ordered);
        public bool IsContainment => this.flags.HasFlag(ModelPropertyFlags.Containment);

        public bool IsAssignableFrom(Type type, out ModelProperty unassignableProperty)
        {
            foreach (var eqProp in this.equivalentProperties)
            {
                if (!eqProp.ImmutableType.IsAssignableFrom(type) && !eqProp.MutableType.IsAssignableFrom(type))
                {
                    unassignableProperty = eqProp;
                    return false;
                }
            }
            unassignableProperty = null;
            return true;
        }

        public override string ToString()
        {
            return this.effectiveProperty.ToString();
        }
    }

    internal class ComplexSlotBuilder
    {
        private ModelProperty effectiveProperty;
        private ModelPropertyFlags flags;
        private Dictionary<ModelProperty, ComplexSlotBuilder> map;
        private ArrayBuilder<ModelProperty> equivalentProperties;
        private ArrayBuilder<ComplexSlotBuilder> supersetSlots;
        private ArrayBuilder<ComplexSlotBuilder> subsetSlots;
        private ArrayBuilder<ModelProperty> subsettedProperties;
        private ArrayBuilder<ModelProperty> subsettingProperties;
        private ArrayBuilder<ModelProperty> derivedUnionProperties;
        private ArrayBuilder<ModelProperty> oppositeProperties;

        public static ImmutableDictionary<ModelProperty, Slot> Build(ImmutableArray<ModelProperty> properties)
        {
            var effectiveProperties = ArrayBuilder<ModelProperty>.GetInstance();
            foreach (var prop in properties)
            {
                int nameIndex = effectiveProperties.FindIndex(p => p.Name == prop.Name);
                if (nameIndex >= 0) effectiveProperties.RemoveAt(nameIndex);
                foreach (var redefProp in prop.RedefinedProperties)
                {
                    int index = effectiveProperties.IndexOf(redefProp);
                    if (index >= 0) effectiveProperties.RemoveAt(index);
                }
                effectiveProperties.Add(prop);
            }
            var eqMap = new Dictionary<ModelProperty, ComplexSlotBuilder>();
            foreach (var prop in properties)
            {
                if (prop.RedefinedProperties.Length > 0)
                {
                    var slot = CreateComplexSlot(eqMap, prop);
                    slot.AddRedefinedProperty(prop, true);
                    foreach (var redefinedProp in prop.RedefinedProperties)
                    {
                        slot.AddRedefinedProperty(redefinedProp, true);
                    }
                }
            }
            var map = new Dictionary<ModelProperty, ComplexSlotBuilder>();
            foreach (var entry in eqMap)
            {
                var slot = GetComplexSlot(map, entry.Key);
                if (slot == null)
                {
                    slot = entry.Value;
                    slot.effectiveProperty = null;
                    foreach (var eqProp in entry.Value.equivalentProperties)
                    {
                        map.Add(eqProp, slot);
                        slot.flags = AddFlag(ModelPropertyFlags.ModelObject, slot.flags, eqProp.Flags);
                        slot.flags = RemoveFlag(ModelPropertyFlags.Collection, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.Readonly, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.Derived, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.DerivedUnion, slot.flags, eqProp.Flags);
                        slot.flags = RemoveFlag(ModelPropertyFlags.NonUnique, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.Ordered, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.NonNull, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.Containment, slot.flags, eqProp.Flags);
                        if (!slot.flags.HasFlag(ModelPropertyFlags.Collection)) slot.flags = slot.flags & ~ModelPropertyFlags.NonUnique;
                        if (effectiveProperties.Contains(eqProp))
                        {
                            Debug.Assert(slot.effectiveProperty == null);
                            slot.effectiveProperty = eqProp;
                        }
                    }
                    Debug.Assert(slot.effectiveProperty != null);
                }
            }
            effectiveProperties.Free();
            foreach (var prop in properties)
            {
                if (prop.SubsettedProperties.Length > 0)
                {
                    var slot = CreateComplexSlot(map, prop);
                    foreach (var subsettedProp in prop.SubsettedProperties)
                    {
                        var subsettedSlot = CreateComplexSlot(map, subsettedProp);
                        slot.AddSubsettedProperty(subsettedProp, true);
                        subsettedSlot.AddSubsettingProperty(prop, true);
                        if (subsettedProp.IsDerivedUnion)
                        {
                            slot.AddDerivedUnionProperty(subsettedProp, true);
                        }
                    }
                }
                if (prop.OppositeProperties.Length > 0)
                {
                    var slot = CreateComplexSlot(map, prop);
                    foreach (var oppositeProp in prop.OppositeProperties)
                    {
                        slot.AddOppositeProperty(oppositeProp, true);
                    }
                }
            }
            foreach (var prop in properties)
            {
                var slot = GetComplexSlot(map, prop);
                if (slot != null && slot.subsettedProperties.Count > 0)
                {
                    var visited = slot.supersetSlots;
                    visited.Add(slot);
                    int i = 0;
                    while (i < visited.Count)
                    {
                        var currentSlot = visited[i];
                        foreach (var subsettedProp in currentSlot.subsettedProperties)
                        {
                            var subsettedSlot = GetComplexSlot(map, subsettedProp);
                            if (subsettedSlot != null)
                            {
                                if (!visited.Contains(subsettedSlot))
                                {
                                    visited.Add(subsettedSlot);
                                    slot.flags = AddFlag(ModelPropertyFlags.ModelObject, slot.flags, subsettedSlot.flags);
                                    slot.flags = RemoveFlag(ModelPropertyFlags.Collection, slot.flags, subsettedSlot.flags);
                                    slot.flags = RemoveFlag(ModelPropertyFlags.NonUnique, slot.flags, subsettedSlot.flags);
                                    slot.flags = AddFlag(ModelPropertyFlags.Ordered, slot.flags, subsettedSlot.flags);
                                    slot.flags = AddFlag(ModelPropertyFlags.NonNull, slot.flags, subsettedSlot.flags);
                                    slot.flags = AddFlag(ModelPropertyFlags.Containment, slot.flags, subsettedSlot.flags);
                                    if (!slot.flags.HasFlag(ModelPropertyFlags.Collection)) slot.flags = slot.flags & ~ModelPropertyFlags.NonUnique;
                                }
                            }
                        }
                        ++i;
                    }
                    visited.RemoveAt(0);
                }
                if (slot != null && slot.subsettingProperties.Count > 0)
                {
                    var visited = slot.subsetSlots;
                    visited.Add(slot);
                    int i = 0;
                    while (i < visited.Count)
                    {
                        var currentSlot = visited[i];
                        foreach (var subsettingProp in currentSlot.subsettingProperties)
                        {
                            var subsettingSlot = GetComplexSlot(map, subsettingProp);
                            if (subsettingSlot != null)
                            {
                                if (!visited.Contains(subsettingSlot))
                                {
                                    visited.Add(subsettingSlot);
                                }
                            }
                        }
                        ++i;
                    }
                    visited.RemoveAt(0);
                }
            }
            var imap = new Dictionary<ComplexSlotBuilder, ComplexSlot>();
            var result = ImmutableDictionary.CreateBuilder<ModelProperty, Slot>();
            foreach (var slotBuilder in map.Values.Distinct())
            {
                imap.Add(slotBuilder, new ComplexSlot(slotBuilder.flags, slotBuilder.effectiveProperty));
            }
            foreach (var entry in map)
            {
                result.Add(entry.Key, entry.Value.ToImmutable(map, imap));
            }
            foreach (var slot in eqMap.Values)
            {
                slot.Free();
            }
            foreach (var prop in properties)
            {
                if (!result.ContainsKey(prop))
                {
                    result.Add(prop, prop);
                }
            }
            return result.ToImmutable();
        }

        private ComplexSlotBuilder(Dictionary<ModelProperty, ComplexSlotBuilder> map)
        {
            this.map = map;
            this.equivalentProperties = ArrayBuilder<ModelProperty>.GetInstance();
            this.supersetSlots = ArrayBuilder<ComplexSlotBuilder>.GetInstance();
            this.subsetSlots = ArrayBuilder<ComplexSlotBuilder>.GetInstance();
            this.subsettedProperties = ArrayBuilder<ModelProperty>.GetInstance();
            this.subsettingProperties = ArrayBuilder<ModelProperty>.GetInstance();
            this.derivedUnionProperties = ArrayBuilder<ModelProperty>.GetInstance();
            this.oppositeProperties = ArrayBuilder<ModelProperty>.GetInstance();
        }

        private ComplexSlot ToImmutable(Dictionary<ModelProperty, ComplexSlotBuilder> map, Dictionary<ComplexSlotBuilder, ComplexSlot> imap)
        {
            var equivalentProperties = this.equivalentProperties.ToImmutable();
            var supersetSlots = this.supersetSlots.Select(s => (Slot)imap[s]).ToImmutableArray();
            var subsetSlots = this.subsetSlots.Select(s => (Slot)imap[s]).ToImmutableArray();
            var subsettedSlots = this.subsettedProperties.Select(p => GetSlot(p, map, imap)).ToImmutableArray();
            var subsettingSlots = this.subsettingProperties.Select(p => GetSlot(p, map, imap)).ToImmutableArray();
            var derivedUnionSlots = this.derivedUnionProperties.Select(p => GetSlot(p, map, imap)).ToImmutableArray();
            var oppositeProperties = this.oppositeProperties.ToImmutable();
            var result = imap[this];
            result.UpdateSlots(equivalentProperties, supersetSlots, subsetSlots, subsettedSlots, subsettingSlots, derivedUnionSlots, oppositeProperties);
            return result;
        }

        private Slot GetSlot(ModelProperty property, Dictionary<ModelProperty, ComplexSlotBuilder> map, Dictionary<ComplexSlotBuilder, ComplexSlot> imap)
        {
            if (map.TryGetValue(property, out var slotBuilder))
            {
                if (imap.TryGetValue(slotBuilder, out var slot))
                {
                    return slot;
                }
                else
                {
                    Debug.Assert(false);
                    return property;
                }
            }
            else
            {
                return property;
            }
        }

        private void Free()
        {
            this.equivalentProperties.Free();
            this.supersetSlots.Free();
            this.subsetSlots.Free();
            this.subsettedProperties.Free();
            this.subsettingProperties.Free();
            this.derivedUnionProperties.Free();
        }

        private static ComplexSlotBuilder CreateComplexSlot(Dictionary<ModelProperty, ComplexSlotBuilder>  map, ModelProperty property)
        {
            ComplexSlotBuilder result;
            if (!map.TryGetValue(property, out result))
            {
                result = new ComplexSlotBuilder(map);
                map.Add(property, result);
                result.effectiveProperty = property;
                result.flags = property.Flags;
            }
            return result;
        }

        private static ComplexSlotBuilder GetComplexSlot(Dictionary<ModelProperty, ComplexSlotBuilder> map, ModelProperty property)
        {
            map.TryGetValue(property, out var result);
            return result;
        }

        private static ModelPropertyFlags AddFlag(ModelPropertyFlags flag, ModelPropertyFlags accumulatedFlags, ModelPropertyFlags propertyFlags)
        {
            if (propertyFlags.HasFlag(flag)) return accumulatedFlags | flag;
            else return accumulatedFlags;
        }

        private static ModelPropertyFlags RemoveFlag(ModelPropertyFlags flag, ModelPropertyFlags accumulatedFlags, ModelPropertyFlags propertyFlags)
        {
            if (!propertyFlags.HasFlag(flag)) return accumulatedFlags & ~flag;
            else return accumulatedFlags;
        }

        private void AddRedefinedProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (!this.equivalentProperties.Contains(property))
            {
                this.equivalentProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddRedefinedProperty(property, false);
                    }
                }
            }
        }

        private void AddSubsettedProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.subsettedProperties.Contains(property))
            {
                this.subsettedProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddSubsettedProperty(property, false);
                    }
                }
            }
        }

        private void AddSubsettingProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.subsettingProperties.Contains(property))
            {
                this.subsettingProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddSubsettingProperty(property, false);
                    }
                }
            }
        }

        private void AddDerivedUnionProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.derivedUnionProperties.Contains(property))
            {
                this.derivedUnionProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddDerivedUnionProperty(property, false);
                    }
                }
            }
        }

        private void AddOppositeProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.oppositeProperties.Contains(property))
            {
                this.oppositeProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddOppositeProperty(property, false);
                    }
                }
            }
        }

    }

}
