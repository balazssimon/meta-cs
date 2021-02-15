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
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling.Internal;
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

    internal enum ModelPropertyInitState
    {
        None,
        FlagsSet,
        Initialized
    }
    
    public sealed class ModelProperty : Slot
    {
        private static object lockObject = new object();
        private ModelPropertyInitState state;
        private ModelObjectDescriptor declaringDescriptor;
        private string name;
        private ModelPropertyFlags flags;
        private string symbolProperty;
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

        public string SymbolProperty
        {
            get { return this.symbolProperty; }
        }

        public bool IsName => this.symbolProperty == "Name";

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
                    else if (annot is SymbolPropertyAttribute spa)
                    {
                        this.symbolProperty = spa.PropertyName;
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

}
