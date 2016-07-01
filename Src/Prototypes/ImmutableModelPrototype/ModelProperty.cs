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

namespace ImmutableModelPrototype
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ModelSymbolDecriptorAttribute : Attribute
    {
        private ImmutableArray<Type> baseSymbolDescriptors;

        public ModelSymbolDecriptorAttribute(Type[] baseSymbolDescriptors)
        {
            this.baseSymbolDescriptors = baseSymbolDescriptors.ToImmutableArray();
        }

        public ImmutableArray<Type> BaseSymbolDescriptors { get { return this.baseSymbolDescriptors; } }
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
    public sealed class SubtypesAttribute : Attribute
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


    [Flags]
    internal enum ModelPropertyFlags : uint
    {
        None = 0x0000,
        Symbol = 0x0001,
        Collection = 0x0002,
        Readonly = 0x0004,
        Derived = 0x0008,
        Union = 0x0010,
        NonUnique = 0x0020,
        NonNull = 0x0040,
        Containment = 0x0080
    }

    public sealed class ModelProperty
    {
        private ModelSymbolInfo declaringSymbol;
        private string name;
        private ModelPropertyFlags flags;
        private ModelPropertyTypeInfo immutableTypeInfo;
        private ModelPropertyTypeInfo mutableTypeInfo;
        private ImmutableList<Attribute> annotations;
        private ImmutableList<ModelProperty> subsettedProperties;
        private ImmutableList<ModelProperty> subtypedProperties;
        private ImmutableList<ModelProperty> redefinedProperties;
        private ImmutableList<ModelProperty> oppositeProperties;

        private ModelProperty(ModelSymbolInfo declaringSymbol, string name, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (immutableTypeInfo == null) throw new ArgumentNullException(nameof(immutableTypeInfo));
            if (mutableTypeInfo == null) throw new ArgumentNullException(nameof(mutableTypeInfo));
            if ((immutableTypeInfo.CollectionType == null && mutableTypeInfo.CollectionType != null) ||
                (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType == null))
            {
                throw new ArgumentException("The immutable and mutable types must both be either a collection or a non-collection.");
            }
            this.declaringSymbol = declaringSymbol;
            this.name = name;
            this.flags = ModelPropertyFlags.None;
            if (immutableTypeInfo.Type is ISymbol || mutableTypeInfo.Type is ISymbol)
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
            if (info == null) throw new ModelException("Cannot find static field '"+name+"Property' in "+ declaringSymbol.SymbolDescriptorType.FullName+".");
            this.annotations = info.GetCustomAttributes().ToImmutableList();
            this.Initialize();
        }

        public static ModelProperty Register(Type declaringType, string name, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            ModelSymbolInfo symbolInfo = ModelSymbolInfo.GetSymbolInfo(declaringType);
            return new ModelProperty(symbolInfo, name, immutableTypeInfo, mutableTypeInfo);
        }

        public ModelSymbolInfo DeclaringSymbol { get { return this.declaringSymbol; } }
        public string Name { get { return this.name; } }
        public bool IsSymbol { get { return this.flags.HasFlag(ModelPropertyFlags.Symbol); } }
        public bool IsCollection { get { return this.flags.HasFlag(ModelPropertyFlags.Collection); } }
        public bool IsReadonly { get { return this.flags.HasFlag(ModelPropertyFlags.Readonly); } }
        public bool IsDerived { get { return this.flags.HasFlag(ModelPropertyFlags.Derived); } }
        public bool IsUnion { get { return this.flags.HasFlag(ModelPropertyFlags.Union); } }
        public bool IsNonNull { get { return this.flags.HasFlag(ModelPropertyFlags.NonNull); } }
        public bool IsUnique { get { return !this.flags.HasFlag(ModelPropertyFlags.NonUnique); } }
        public bool IsContainment { get { return this.flags.HasFlag(ModelPropertyFlags.Containment); } }
        public ModelPropertyTypeInfo ImmutableTypeInfo { get { return this.immutableTypeInfo; } }
        public ModelPropertyTypeInfo MutableTypeInfo { get { return this.mutableTypeInfo; } }

        private void Initialize()
        {
            foreach (var annot in this.annotations)
            {
                if (annot is OppositeAttribute)
                {
                    OppositeAttribute oppositeAnnot = (OppositeAttribute)annot;
                    ModelSymbolInfo oppositeSymbol = ModelSymbolInfo.GetSymbolInfo(oppositeAnnot.DeclaringType);
                    ModelProperty oppositeProperty = oppositeSymbol.GetDeclaredProperty(oppositeAnnot.PropertyName);
                    this.RegisterOppositeProperty(oppositeProperty);
                }
            }
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
        private ImmutableList<ModelProperty> subsettedProperties;
        private ImmutableList<ModelProperty> subsettingProperties;
        private ImmutableList<ModelProperty> subtypedProperties;
        private ImmutableList<ModelProperty> subtypingProperties;
        private ImmutableList<ModelProperty> redefinedProperties;
        private ImmutableList<ModelProperty> redefiningProperties;
        private ImmutableList<ModelProperty> oppositeProperties;

        private ImmutableList<ModelProperty> addAffectedProperties;
        private ImmutableList<ModelProperty> removeAffectedProperties;
        private ImmutableList<ModelProperty> addAffectedTypedProperties;
        private ImmutableList<ModelProperty> removeAffectedTypedProperties;

        internal ModelPropertyInfo()
        {
            this.subsettedProperties = ImmutableList<ModelProperty>.Empty;
            this.subsettingProperties = ImmutableList<ModelProperty>.Empty;
            this.subtypedProperties = ImmutableList<ModelProperty>.Empty;
            this.subtypingProperties = ImmutableList<ModelProperty>.Empty;
            this.redefinedProperties = ImmutableList<ModelProperty>.Empty;
            this.redefiningProperties = ImmutableList<ModelProperty>.Empty;
            this.oppositeProperties = ImmutableList<ModelProperty>.Empty;
            this.addAffectedProperties = ImmutableList<ModelProperty>.Empty;
            this.removeAffectedProperties = ImmutableList<ModelProperty>.Empty;
            this.addAffectedTypedProperties = ImmutableList<ModelProperty>.Empty;
            this.removeAffectedTypedProperties = ImmutableList<ModelProperty>.Empty;
        }

        public ImmutableList<ModelProperty> SubsettedProperties { get { return this.subsettedProperties; } }
        public ImmutableList<ModelProperty> SubsettingProperties { get { return this.subsettingProperties; } }
        public ImmutableList<ModelProperty> SubtypedProperties { get { return this.subtypedProperties; } }
        public ImmutableList<ModelProperty> SubtypingProperties { get { return this.subtypingProperties; } }
        public ImmutableList<ModelProperty> RedefinedProperties { get { return this.redefinedProperties; } }
        public ImmutableList<ModelProperty> RedefiningProperties { get { return this.redefiningProperties; } }
        public ImmutableList<ModelProperty> OppositeProperties { get { return this.oppositeProperties; } }

        public ImmutableList<ModelProperty> AddAffectedProperties { get { return this.addAffectedProperties; } }
        public ImmutableList<ModelProperty> RemoveAffectedProperties { get { return this.removeAffectedProperties; } }
        public ImmutableList<ModelProperty> AddAffectedTypedProperties { get { return this.addAffectedTypedProperties; } }
        public ImmutableList<ModelProperty> RemoveAffectedTypedProperties { get { return this.removeAffectedTypedProperties; } }

    }

    public sealed class ModelSymbolInfo
    {
        private static ImmutableDictionary<Type, ModelSymbolInfo> symbols = ImmutableDictionary<Type, ModelSymbolInfo>.Empty;

        private bool initialized;
        private Type symbolDescriptorType;
        private GreenSymbol emptyGreenSymbol;
        private ImmutableList<Attribute> annotations;
        private ImmutableList<ModelSymbolInfo> baseSymbols;
        private ImmutableList<ModelProperty> declaredProperties;
        private ImmutableDictionary<ModelProperty, ModelPropertyInfo> propertyInfo;
        private ImmutableList<ModelProperty> properties;

        private ModelSymbolInfo(Type symbolDescriptorType)
        {
            this.initialized = false;
            this.symbolDescriptorType = symbolDescriptorType;
            this.annotations = symbolDescriptorType.GetCustomAttributes(false).OfType<Attribute>().ToImmutableList();
            this.emptyGreenSymbol = GreenSymbol.Empty;
            this.baseSymbols = ImmutableList<ModelSymbolInfo>.Empty;
            this.declaredProperties = ImmutableList<ModelProperty>.Empty;
            this.propertyInfo = ImmutableDictionary<ModelProperty, ModelPropertyInfo>.Empty;
            this.properties = ImmutableList<ModelProperty>.Empty;
        }

        internal static ModelSymbolInfo GetSymbolInfo(Type symbolDescriptorType)
        {
            ImmutableDictionary<Type, ModelSymbolInfo> oldSymbols;
            ImmutableDictionary<Type, ModelSymbolInfo> newSymbols;
            ModelSymbolInfo newSymbolInfo = null;
            do
            {
                oldSymbols = ModelSymbolInfo.symbols;
                ModelSymbolInfo result;
                if (oldSymbols.TryGetValue(symbolDescriptorType, out result))
                {
                    return result;
                }
                else
                {
                    if (newSymbolInfo == null) newSymbolInfo = new ModelSymbolInfo(symbolDescriptorType);
                    newSymbols = oldSymbols.Add(symbolDescriptorType, newSymbolInfo);
                }
            } while (Interlocked.CompareExchange(ref ModelSymbolInfo.symbols, newSymbols, oldSymbols) != oldSymbols);
            return newSymbolInfo;
        }

        internal ModelProperty GetDeclaredProperty(string name)
        {
            RuntimeHelpers.RunClassConstructor(this.symbolDescriptorType.TypeHandle);
            return this.declaredProperties.FirstOrDefault(p => p.Name == name);
        }

        public static ImmutableDictionary<Type, ModelSymbolInfo> Symbols
        {
            get { return ModelSymbolInfo.symbols; }
        }

        internal void AddBaseSymbol(ModelSymbolInfo baseSymbol)
        {
            if (this.initialized) throw new InvalidOperationException("Cannot add a base symbol to an initialized symbol.");
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
        public ImmutableList<ModelSymbolInfo> BaseSymbols { get { return this.baseSymbols; } }
        public ImmutableList<ModelProperty> DeclaredProperties { get { return this.declaredProperties; } }
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


        private void Initialize()
        {
            if (this.initialized) return;
            lock (this)
            {
                if (this.initialized) return;
                RuntimeHelpers.RunClassConstructor(this.symbolDescriptorType.TypeHandle);
                this.CreateProperties();
                this.CreatePropertyInfo();
                this.CreateEmptyGreenSymbol();
                this.initialized = true;
            }
        }

        private void CreateProperties()
        {
            ImmutableList<ModelProperty> properties = ImmutableList<ModelProperty>.Empty;
            foreach (var baseSymbol in this.baseSymbols)
            {
                foreach (var prop in baseSymbol.Properties)
                {
                    if (!properties.Contains(prop))
                    {
                        properties = properties.Add(prop);
                    }
                }
            }
            properties.AddRange(this.declaredProperties);
            Interlocked.Exchange(ref this.properties, properties);
        }

        private void CreatePropertyInfo()
        {
            // TODO
        }

        private void CreateEmptyGreenSymbol()
        {
            Interlocked.Exchange(ref this.emptyGreenSymbol, GreenSymbol.CreateWithProperties(this.Properties));
        }

        public bool HasAffectedProperties(ModelProperty property)
        {
            return this.propertyInfo.ContainsKey(property);
        }

        public override string ToString()
        {
            return this.GetType().FullName;
        }
    }

}
