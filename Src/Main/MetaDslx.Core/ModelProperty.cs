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

namespace MetaDslx.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ModelSymbolDescriptorAttribute : Attribute
    {
        private static Type[] EmptyTypeArray = new Type[0];

        public ModelSymbolDescriptorAttribute()
        {
            this.BaseSymbolDescriptors = EmptyTypeArray;
        }

        public ModelSymbolDescriptorAttribute(Type immutableType, Type mutableType)
        {
            this.ImmutableType = immutableType;
            this.MutableType = mutableType;
            this.BaseSymbolDescriptors = EmptyTypeArray;
        }

        public Type[] BaseSymbolDescriptors { get; set; }
        public Type ImmutableType { get; }
        public Type MutableType { get; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class OppositeAttribute : Attribute
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
    public sealed class SubsetsAttribute : Attribute
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
    public sealed class RedefinesAttribute : Attribute
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
    public sealed class ReadonlyAttribute : Attribute
    {
        public ReadonlyAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class DerivedAttribute : Attribute
    {
        public DerivedAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class DerivedUnionAttribute : Attribute
    {
        public DerivedUnionAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class NonUniqueAttribute : Attribute
    {
        public NonUniqueAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class NonNullAttribute : Attribute
    {
        public NonNullAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ContainmentAttribute : Attribute
    {
        public ContainmentAttribute()
        {
        }
    }



    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class NameAttribute : Attribute
    {

    }

    [System.AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class TypeAttribute : Attribute
    {

    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ScopeEntryAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class ScopeAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ImportedScopeAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ImportedScopeEntryAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class InheritedScopeAttribute : Attribute
    {
    }


    [Flags]
    internal enum ModelPropertyFlags : uint
    {
        None = 0x0000,
        Symbol = 0x0001,
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
        ScopeEntry = 0x0004,
        ImportedScope = 0x0008,
        ImportedScopeEntry = 0x0010,
        InheritedScope = 0x0020
    }

    [Flags]
    internal enum MetaModelSymbolFlags : uint
    {
        None = 0x0000,
        Scope = 0x0001,
        Type = 0x0002
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
        private ModelSymbolInfo declaringSymbol;
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

        private ModelProperty(ModelSymbolInfo declaringSymbol, string name, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo, Func<MetaProperty> metaProperty)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (immutableTypeInfo == null) throw new ArgumentNullException(nameof(immutableTypeInfo));
            if (mutableTypeInfo == null) throw new ArgumentNullException(nameof(mutableTypeInfo));
            if ((immutableTypeInfo.CollectionType == null && mutableTypeInfo.CollectionType != null) ||
                (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType == null))
            {
                throw new ArgumentException("The immutable and mutable types must must be of the same kind: either a single value or a collection.");
            }
            this.declaringSymbol = declaringSymbol;
            this.name = name;
            this.flags = ModelPropertyFlags.None;
            if (typeof(ImmutableSymbolBase).IsAssignableFrom(immutableTypeInfo.Type) || typeof(MutableSymbolBase).IsAssignableFrom(mutableTypeInfo.Type))
            {
                this.flags |= ModelPropertyFlags.Symbol;
            }
            if (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType != null)
            {
                this.flags |= ModelPropertyFlags.Collection;
            }
            this.immutableTypeInfo = immutableTypeInfo;
            this.mutableTypeInfo = mutableTypeInfo;
            FieldInfo info = declaringSymbol.SymbolDescriptorType.GetField(name + "Property", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (info == null) throw new ModelException("Cannot find static field '" + name + "Property' in " + declaringSymbol.SymbolDescriptorType.FullName + ".");
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
            ModelSymbolInfo symbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(declaringType);
            ModelProperty result = new ModelProperty(symbolInfo, name, immutableTypeInfo, mutableTypeInfo, metaProperty);
            symbolInfo.AddProperty(result);
            return result;
        }

        public ModelSymbolInfo DeclaringSymbol { get { return this.declaringSymbol; } }
        public string Name { get { return this.name; } }
        public bool IsSymbol { get { return this.flags.HasFlag(ModelPropertyFlags.Symbol); } }
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
        public bool IsScopeEntry
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.ScopeEntry);
            }
        }
        public bool IsImportedScope
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.ImportedScope);
            }
        }
        public bool IsImportedScopeEntry
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.ImportedScopeEntry);
            }
        }
        public bool IsInheritedScope
        {
            get
            {
                if (this.state == ModelPropertyInitState.None) this.InitializeFlags();
                return this.metaFlags.HasFlag(MetaModelPropertyFlags.InheritedScope);
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
                    else if (annot is ScopeEntryAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.ScopeEntry;
                    }
                    else if (annot is ImportedScopeAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.ImportedScope;
                    }
                    else if (annot is ImportedScopeAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.ImportedScopeEntry;
                    }
                    else if (annot is InheritedScopeAttribute)
                    {
                        this.metaFlags |= MetaModelPropertyFlags.InheritedScope;
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
                        ModelSymbolInfo propSymbol = ModelSymbolInfo.GetDescriptorSymbolInfo(propAnnot.DeclaringType);
                        ModelProperty prop = propSymbol.GetDeclaredProperty(propAnnot.PropertyName);
                        if (prop == null)
                        {
                            throw new ModelException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetted property cannot be found.");
                        }
                        if ((propSymbol == this.declaringSymbol || this.declaringSymbol.BaseSymbols.Contains(propSymbol)))
                        {
                            if (!this.IsCollection || !this.IsUnique) throw new ModelException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetting property must be a collection of unique values.");
                            if (!prop.IsCollection || !prop.IsUnique) throw new ModelException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetted property must be a collection of unique values.");
                            this.RegisterSubsettedProperty(prop);
                        }
                        else
                        {
                            throw new ModelException("Error subsetting property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The subsetted property must come from the current type or from a base type.");
                        }
                    }
                    else if (annot is RedefinesAttribute)
                    {
                        RedefinesAttribute propAnnot = (RedefinesAttribute)annot;
                        ModelSymbolInfo propSymbol = ModelSymbolInfo.GetDescriptorSymbolInfo(propAnnot.DeclaringType);
                        ModelProperty prop = propSymbol.GetDeclaredProperty(propAnnot.PropertyName);
                        if (prop == null)
                        {
                            throw new ModelException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefined property cannot be found.");
                        }
                        if ((propSymbol == this.declaringSymbol || this.declaringSymbol.BaseSymbols.Contains(propSymbol)))
                        {
                            if (this.IsCollection ^ prop.IsCollection) throw new ModelException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefining and the redefined property must be of the same kind: either a single value or a collection.");
                            if (this.IsCollection && prop.IsCollection)
                            {
                                if (this.IsUnique ^ prop.IsUnique) throw new ModelException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefining and the redefined property must have the same uniqueness.");
                            }
                            this.RegisterRedefinedProperty(prop);
                        }
                        else
                        {
                            throw new ModelException("Error redefining property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". The redefined property must come from the current type or from a base type.");
                        }
                    }
                    else if (annot is OppositeAttribute)
                    {
                        OppositeAttribute propAnnot = (OppositeAttribute)annot;
                        ModelSymbolInfo propSymbol = ModelSymbolInfo.GetDescriptorSymbolInfo(propAnnot.DeclaringType);
                        ModelProperty prop = propSymbol.GetDeclaredProperty(propAnnot.PropertyName);
                        if (prop == null)
                        {
                            throw new ModelException("Error in setting opposite property: " + this.FullDeclaredName + "->" + propAnnot.DeclaringType+"."+propAnnot.PropertyName + ". The opposite property cannot be found.");
                        }
                        if (!this.IsUnique) throw new ModelException("Error in setting opposite property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". A property which has an opposite must be either a single value or a unique collection.");
                        bool foundThisProperty = false;
                        foreach (var oppositeAnnot in prop.annotations)
                        {
                            if (oppositeAnnot is OppositeAttribute)
                            {
                                OppositeAttribute propOppositeAnnot = (OppositeAttribute)oppositeAnnot;
                                if (propOppositeAnnot.DeclaringType == this.declaringSymbol.SymbolDescriptorType &&
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
                            throw new ModelException("Error in setting opposite property: " + this.FullDeclaredName + "->" + prop.FullDeclaredName + ". Opposite properties must be mutual.");
                        }
                    }
                    else if (annot is DerivedUnionAttribute)
                    {
                        if (!this.IsCollection || !this.IsUnique) throw new ModelException("Error in property: " + this.FullDeclaredName + ". A derived union property must be a collection of unique values.");
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
            get { return this.DeclaringSymbol.SymbolDescriptorType.FullName + "." + this.Name; }
        }

        public override string ToString()
        {
            return this.DeclaringSymbol.SymbolDescriptorType.Name + "." + this.Name;
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

        internal void AddRedefinedProperty(ModelSymbolInfo symbolInfo, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (!this.equivalentProperties.Contains(property))
            {
                this.equivalentProperties = this.equivalentProperties.Add(property);
                if (firstCall)
                {
                    ModelPropertyInfo propInfo = symbolInfo.GetOrCreatePropertyInfo(property);
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        propInfo.AddRedefinedProperty(symbolInfo, eqProp, false);
                    }
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = symbolInfo.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddRedefinedProperty(symbolInfo, property, false);
                    }
                }
            }
        }

        internal void SetRepresentingProperty(ModelSymbolInfo symbolInfo, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            this.representingProperty = property;
            if (firstCall)
            {
                foreach (var eqProp in this.equivalentProperties)
                {
                    ModelPropertyInfo eqPropInfo = symbolInfo.GetOrCreatePropertyInfo(eqProp);
                    eqPropInfo.SetRepresentingProperty(symbolInfo, property, false);
                }
            }
        }

        internal void AddSupersetProperty(ModelSymbolInfo symbolInfo, ModelProperty property, bool firstCall)
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
                        ModelPropertyInfo eqPropInfo = symbolInfo.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddSupersetProperty(symbolInfo, property, false);
                    }
                }
            }
        }

        internal void AddSubsetProperty(ModelSymbolInfo symbolInfo, ModelProperty property, bool firstCall)
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
                        ModelPropertyInfo eqPropInfo = symbolInfo.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddSubsetProperty(symbolInfo, property, false);
                    }
                }
            }
        }
        internal void AddSubsettedProperty(ModelSymbolInfo symbolInfo, ModelProperty property, bool firstCall)
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
                        ModelPropertyInfo eqPropInfo = symbolInfo.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddSubsettedProperty(symbolInfo, property, false);
                    }
                }
            }
        }

        internal void AddSubsettingProperty(ModelSymbolInfo symbolInfo, ModelProperty property, bool firstCall)
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
                        ModelPropertyInfo eqPropInfo = symbolInfo.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddSubsettingProperty(symbolInfo, property, false);
                    }
                }
            }
        }

        internal void AddDerivedUnionProperty(ModelSymbolInfo symbolInfo, ModelProperty property, bool firstCall)
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
                        ModelPropertyInfo eqPropInfo = symbolInfo.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddDerivedUnionProperty(symbolInfo, property, false);
                    }
                }
            }
        }

        internal void AddOppositeProperty(ModelSymbolInfo symbolInfo, ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (!this.oppositeProperties.Contains(property))
            {
                this.oppositeProperties = this.oppositeProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        ModelPropertyInfo eqPropInfo = symbolInfo.GetOrCreatePropertyInfo(eqProp);
                        eqPropInfo.AddOppositeProperty(symbolInfo, property, false);
                    }
                }
            }
        }
    }

    public sealed class ModelSymbolInfo
    {
        private static ImmutableDictionary<Type, ModelSymbolInfo> descriptors = ImmutableDictionary<Type, ModelSymbolInfo>.Empty;
        private static ImmutableDictionary<Type, ModelSymbolInfo> immutableTypes = ImmutableDictionary<Type, ModelSymbolInfo>.Empty;
        private static ImmutableDictionary<Type, ModelSymbolInfo> mutableTypes = ImmutableDictionary<Type, ModelSymbolInfo>.Empty;

        private bool initialized;
        private bool initializedBaseSymbols;
        private Type symbolDescriptorType;
        private GreenSymbol emptyGreenSymbol;
        private MetaModelSymbolFlags metaFlags;
        private Type immutableType;
        private Type mutableType;
        private ModelProperty nameProperty;
        private ModelProperty typeProperty;
        private ImmutableList<Attribute> annotations;
        private ImmutableList<ModelSymbolInfo> baseSymbols;
        private ImmutableList<ModelProperty> declaredProperties;
        private ImmutableDictionary<ModelProperty, ModelPropertyInfo> propertyInfo;
        private ImmutableList<ModelProperty> properties;

        private ModelSymbolInfo(Type symbolDescriptorType)
        {
            this.initialized = false;
            this.initializedBaseSymbols = false;
            this.symbolDescriptorType = symbolDescriptorType;
            this.annotations = symbolDescriptorType.GetCustomAttributes(false).OfType<Attribute>().ToImmutableList();
            this.metaFlags = MetaModelSymbolFlags.None;
            foreach (var annot in this.annotations)
            {
                if (annot is ModelSymbolDescriptorAttribute)
                {
                    ModelSymbolDescriptorAttribute da = (ModelSymbolDescriptorAttribute)annot;
                    this.immutableType = da.ImmutableType;
                    this.mutableType = da.MutableType;
                }
                else if (annot is ScopeAttribute)
                {
                    this.metaFlags |= MetaModelSymbolFlags.Scope;
                }
                else if (annot is TypeAttribute)
                {
                    this.metaFlags |= MetaModelSymbolFlags.Type;
                }
            }
            this.nameProperty = null;
            this.typeProperty = null;
            this.emptyGreenSymbol = GreenSymbol.Empty;
            this.baseSymbols = ImmutableList<ModelSymbolInfo>.Empty;
            this.declaredProperties = ImmutableList<ModelProperty>.Empty;
            this.propertyInfo = ImmutableDictionary<ModelProperty, ModelPropertyInfo>.Empty;
            this.properties = ImmutableList<ModelProperty>.Empty;
        }

        public static ModelSymbolInfo GetSymbolInfo(Type type)
        {
            ModelSymbolInfo result = null;
            if (ModelSymbolInfo.immutableTypes.TryGetValue(type, out result))
            {
                return result;
            }
            if (ModelSymbolInfo.mutableTypes.TryGetValue(type, out result))
            {
                return result;
            }
            return result;
        }

        public static ModelSymbolInfo GetDescriptorSymbolInfo(Type symbolDescriptorType)
        {
            ImmutableDictionary<Type, ModelSymbolInfo> oldSymbols;
            ImmutableDictionary<Type, ModelSymbolInfo> newSymbols;
            ModelSymbolInfo newSymbolInfo = null;
            do
            {
                oldSymbols = ModelSymbolInfo.descriptors;
                ModelSymbolInfo result;
                if (oldSymbols.TryGetValue(symbolDescriptorType, out result))
                {
                    newSymbolInfo = result;
                    break;
                }
                else
                {
                    if (newSymbolInfo == null) newSymbolInfo = new ModelSymbolInfo(symbolDescriptorType);
                    newSymbols = oldSymbols.Add(symbolDescriptorType, newSymbolInfo);
                }
            } while (Interlocked.CompareExchange(ref ModelSymbolInfo.descriptors, newSymbols, oldSymbols) != oldSymbols);
            if (newSymbolInfo.immutableType != null)
            {
                do
                {
                    oldSymbols = ModelSymbolInfo.immutableTypes;
                    ModelSymbolInfo result;
                    if (oldSymbols.TryGetValue(newSymbolInfo.immutableType, out result))
                    {
                        break;
                    }
                    else
                    {
                        newSymbols = oldSymbols.Add(newSymbolInfo.immutableType, newSymbolInfo);
                    }
                } while (Interlocked.CompareExchange(ref ModelSymbolInfo.immutableTypes, newSymbols, oldSymbols) != oldSymbols);
            }
            if (newSymbolInfo.mutableType != null)
            {
                do
                {
                    oldSymbols = ModelSymbolInfo.mutableTypes;
                    ModelSymbolInfo result;
                    if (oldSymbols.TryGetValue(newSymbolInfo.mutableType, out result))
                    {
                        break;
                    }
                    else
                    {
                        newSymbols = oldSymbols.Add(newSymbolInfo.mutableType, newSymbolInfo);
                    }
                } while (Interlocked.CompareExchange(ref ModelSymbolInfo.mutableTypes, newSymbols, oldSymbols) != oldSymbols);
            }
            return newSymbolInfo;
        }

        internal ModelProperty GetDeclaredProperty(string name)
        {
            RuntimeHelpers.RunClassConstructor(this.symbolDescriptorType.TypeHandle);
            return this.declaredProperties.FirstOrDefault(p => p.Name == name);
        }

        public static ImmutableDictionary<Type, ModelSymbolInfo> Symbols
        {
            get { return ModelSymbolInfo.descriptors; }
        }

        private void AddBaseSymbol(ModelSymbolInfo baseSymbol)
        {
            if (this.initializedBaseSymbols) throw new InvalidOperationException("Cannot add a base symbol to an initialized symbol.");
            ImmutableList<ModelSymbolInfo> oldBaseSymbols;
            ImmutableList<ModelSymbolInfo> newBaseSymbols;
            do
            {
                oldBaseSymbols = this.baseSymbols;
                if (!oldBaseSymbols.Contains(baseSymbol))
                {
                    newBaseSymbols = oldBaseSymbols.Add(baseSymbol);
                }
                else
                {
                    newBaseSymbols = oldBaseSymbols;
                }
            } while (Interlocked.CompareExchange(ref this.baseSymbols, newBaseSymbols, oldBaseSymbols) != oldBaseSymbols);
            if (baseSymbol.IsScope)
            {
                this.metaFlags |= MetaModelSymbolFlags.Scope;
            }
            if (baseSymbol.IsType)
            {
                this.metaFlags |= MetaModelSymbolFlags.Type;
            }
        }

        internal void AddProperty(ModelProperty property)
        {
            if (this.initialized) throw new InvalidOperationException("Cannot register a property into an initialized symbol.");
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
        internal Type SymbolDescriptorType { get { return this.symbolDescriptorType; } }
        public ImmutableList<Attribute> Annotations { get { return this.annotations; } }
        public Type ImmutableType
        {
            get { return this.immutableType; }
        }
        public Type MutableType
        {
            get { return this.mutableType; }
        }
        public ImmutableList<ModelSymbolInfo> BaseSymbols 
        {
            get
            {
                if (!this.initializedBaseSymbols) this.InitializeBaseSymbols();
                return this.baseSymbols;
            }
        }
        public ImmutableList<ModelProperty> DeclaredProperties { get { return this.declaredProperties; } }

        public bool IsScope
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelSymbolFlags.Scope);
            }
        }
        public bool IsType
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelSymbolFlags.Type);
            }
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
        public ImmutableList<ModelProperty> Properties
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
        internal GreenSymbol EmptyGreenSymbol
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.emptyGreenSymbol;
            }
        }

        private void InitializeBaseSymbols()
        {
            if (this.initializedBaseSymbols) return;
            lock (this)
            {
                if (this.initializedBaseSymbols) return;
                foreach (var annot in this.annotations)
                {
                    if (annot is ModelSymbolDescriptorAttribute)
                    {
                        ModelSymbolDescriptorAttribute descrAnnot = (ModelSymbolDescriptorAttribute)annot;
                        foreach (var baseType in descrAnnot.BaseSymbolDescriptors)
                        {
                            this.AddBaseSymbol(ModelSymbolInfo.GetDescriptorSymbolInfo(baseType));
                        }
                    }
                }
                this.initializedBaseSymbols = true;
            }
        }

        private void Initialize()
        {
            if (this.initialized) return;
            lock (this)
            {
                if (this.initialized) return;
                this.InitializeBaseSymbols();
                this.initialized = true;
                RuntimeHelpers.RunClassConstructor(this.symbolDescriptorType.TypeHandle);
                this.CreateProperties();
                this.CreatePropertyInfo();
                this.CreateEmptyGreenSymbol();
            }
        }

        private void CreateProperties()
        {
            ImmutableList<ModelProperty> properties = ImmutableList<ModelProperty>.Empty;
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
            foreach (var baseSymbol in this.baseSymbols.Reverse())
            {
                foreach (var prop in baseSymbol.Properties.Reverse())
                {
                    if (!properties.Contains(prop))
                    {
                        properties = properties.Add(prop);
                        if (this.nameProperty == null && prop.IsName)
                        {
                            this.nameProperty = prop;
                        }
                        if (this.typeProperty == null && prop.IsType)
                        {
                            this.typeProperty = prop;
                        }
                    }
                }
            }
            properties = properties.AddRange(this.declaredProperties);
            Interlocked.Exchange(ref this.properties, properties);
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
                    while(i < supersetProperties.Count)
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

        private void CreateEmptyGreenSymbol()
        {
            Interlocked.Exchange(ref this.emptyGreenSymbol, GreenSymbol.CreateWithProperties(this.Properties));
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
            return this.GetType().FullName;
        }
    }

}
