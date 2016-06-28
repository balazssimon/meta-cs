using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImmutableModelPrototype
{
    [Flags]
    public enum ModelPropertyFlags : uint
    {
        Readonly = 0x0001,
        Derived = 0x0002,
        NonUnique = 0x0004,
        NonNull = 0x0008,
        Containment = 0x0010,
    }

    public sealed class ModelProperty
    {
        private ModelSymbol declaringSymbol;
        private string name;
        private ModelPropertyFlags flags;
        private bool isSymbol;
        private bool isCollection;
        private ModelPropertyTypeInfo immutableTypeInfo;
        private ModelPropertyTypeInfo mutableTypeInfo;
        private ImmutableList<ModelProperty> subsettedProperties;
        private ImmutableList<ModelProperty> subtypedProperties;
        private ImmutableList<ModelProperty> redefinedProperties;
        private ImmutableList<ModelProperty> oppositeProperties;

        private ModelProperty(ModelSymbol declaringSymbol, string name, ModelPropertyFlags flags, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            this.declaringSymbol = declaringSymbol;
            this.name = name;
            this.flags = flags;
            this.isSymbol = immutableTypeInfo.Type is ISymbol || mutableTypeInfo.Type is ISymbol;
            this.isCollection = immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType != null;
            this.immutableTypeInfo = immutableTypeInfo;
            this.mutableTypeInfo = mutableTypeInfo;
        }

        internal static ModelProperty Create(ModelSymbol declaringSymbol, string name, ModelPropertyFlags flags, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            return new ModelProperty(declaringSymbol, name, flags, immutableTypeInfo, mutableTypeInfo);
        }

        internal void RegisterSubsettedProperty(ModelProperty property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (!this.subsettedProperties.Contains(property))
            {
                this.subsettedProperties = this.subsettedProperties.Add(property);
            }
        }

        internal void RegisterSubtypedProperty(ModelProperty property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (!this.subtypedProperties.Contains(property))
            {
                this.subtypedProperties = this.subtypedProperties.Add(property);
            }
        }

        internal void RegisterRedefinedProperty(ModelProperty property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (!this.redefinedProperties.Contains(property))
            {
                this.redefinedProperties = this.redefinedProperties.Add(property);
            }
        }

        internal void RegisterOppositeProperty(ModelProperty property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (!this.oppositeProperties.Contains(property))
            {
                this.oppositeProperties = this.oppositeProperties.Add(property);
            }
        }

        public ModelSymbol DeclaringSymbol { get { return this.declaringSymbol; } }
        public string Name { get { return this.name; } }
        public bool IsSymbol { get { return this.isSymbol; } }
        public bool IsCollection { get { return this.isCollection; } }
        public bool IsReadonly { get { return this.flags.HasFlag(ModelPropertyFlags.Readonly); } }
        public bool IsDerived { get { return this.flags.HasFlag(ModelPropertyFlags.Derived); } }
        public bool IsNonNull { get { return this.flags.HasFlag(ModelPropertyFlags.NonNull); } }
        public bool IsUnique { get { return !this.flags.HasFlag(ModelPropertyFlags.NonUnique); } }
        public bool IsContainment { get { return this.flags.HasFlag(ModelPropertyFlags.Containment); } }
        public ModelPropertyTypeInfo ImmutableTypeInfo { get { return this.immutableTypeInfo; } }
        public ModelPropertyTypeInfo MutableTypeInfo { get { return this.mutableTypeInfo; } }
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

    public sealed class RelatedProperties
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

        internal RelatedProperties()
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

    public abstract class ModelSymbol
    {
        private bool initialized;
        private GreenSymbol emptyGreenSymbol;
        private ImmutableList<ModelSymbol> baseSymbols;
        private ImmutableList<ModelProperty> declaredProperties;
        private ImmutableDictionary<ModelProperty, RelatedProperties> relatedProperties;
        private ImmutableList<ModelProperty> properties;

        protected ModelSymbol()
        {
            this.initialized = false;
            this.baseSymbols = ImmutableList<ModelSymbol>.Empty;
            this.declaredProperties = ImmutableList<ModelProperty>.Empty;
            this.relatedProperties = ImmutableDictionary<ModelProperty, RelatedProperties>.Empty;
            this.properties = null;
        }

        protected void AddBaseSymbol(ModelSymbol baseSymbol)
        {
            Debug.Assert(baseSymbol != null);
            if (baseSymbol == null) return;
            if (!this.baseSymbols.Contains(baseSymbol))
            {
                this.baseSymbols = this.baseSymbols.Add(baseSymbol);
                this.properties = null;
            }
        }

        protected ModelProperty AddProperty(string name, ModelPropertyFlags flags, ModelPropertyTypeInfo immutableTypeInfo, ModelPropertyTypeInfo mutableTypeInfo)
        {
            if (this.initialized) throw new InvalidOperationException("Cannot register a property into an initialized symbol.");
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (immutableTypeInfo == null) throw new ArgumentNullException(nameof(immutableTypeInfo));
            if (mutableTypeInfo == null) throw new ArgumentNullException(nameof(mutableTypeInfo));
            if ((immutableTypeInfo.CollectionType == null && mutableTypeInfo.CollectionType != null) ||
                (immutableTypeInfo.CollectionType != null && mutableTypeInfo.CollectionType == null))
            {
                throw new ArgumentException("The immutable and mutable types must both be either a collection or a non-collection.");
            }
            if (this.declaredProperties.Any(p => p.Name == name))
            {
                throw new InvalidOperationException("A property with name '" + name + "' is already declared for " + this.ToString());
            }
            else
            {
                ModelProperty property = ModelProperty.Create(this, name, flags, immutableTypeInfo, mutableTypeInfo);
                this.declaredProperties = this.declaredProperties.Add(property);
                this.properties = null;
                return property;
            }
        }

        protected void RegisterSubsettingProperty(ModelProperty subsettingProperty, ModelProperty subsettedProperty)
        {
            if (this.initialized) throw new InvalidOperationException("Cannot register a property into an initialized symbol.");
            if (subsettingProperty == null) throw new ArgumentNullException(nameof(subsettingProperty));
            if (subsettedProperty == null) throw new ArgumentNullException(nameof(subsettedProperty));
            if (!this.declaredProperties.Contains(subsettingProperty)) throw new ArgumentOutOfRangeException("The subsetting property must be declared in this symbol.");
            if (!this.Properties.Contains(subsettedProperty)) throw new ArgumentOutOfRangeException("The subsetted property must be declared in this symbol or in a base symbol.");
            subsettingProperty.RegisterSubsettedProperty(subsettedProperty);
        }

        protected void RegisterSubtypingProperty(ModelProperty subtypingProperty, ModelProperty subtypedProperty)
        {
            if (this.initialized) throw new InvalidOperationException("Cannot register a property into an initialized symbol.");
            if (subtypingProperty == null) throw new ArgumentNullException(nameof(subtypingProperty));
            if (subtypedProperty == null) throw new ArgumentNullException(nameof(subtypedProperty));
            if (!this.declaredProperties.Contains(subtypingProperty)) throw new ArgumentOutOfRangeException("The subtyping property must be declared in this symbol.");
            if (!this.Properties.Contains(subtypedProperty)) throw new ArgumentOutOfRangeException("The subtyped property must be declared in this symbol or in a base symbol.");
            subtypingProperty.RegisterSubsettedProperty(subtypedProperty);
        }

        protected void RegisterRedefiningProperty(ModelProperty redefiningProperty, ModelProperty redefinedProperty)
        {
            if (this.initialized) throw new InvalidOperationException("Cannot register a property into an initialized symbol.");
            if (redefiningProperty == null) throw new ArgumentNullException(nameof(redefiningProperty));
            if (redefinedProperty == null) throw new ArgumentNullException(nameof(redefinedProperty));
            if (!this.declaredProperties.Contains(redefiningProperty)) throw new ArgumentOutOfRangeException("The redefining property must be declared in this symbol.");
            if (!this.Properties.Contains(redefinedProperty)) throw new ArgumentOutOfRangeException("The redefined property must be declared in this symbol or in a base symbol.");
            redefiningProperty.RegisterSubsettedProperty(redefinedProperty);
        }

        private void RegisterOppositeProperty(ModelProperty declaredProperty, ModelProperty oppositeProperty)
        {
            declaredProperty.RegisterOppositeProperty(oppositeProperty);
        }

        public static void RegisterOppositeProperties(ModelProperty firstEnd, ModelProperty otherEnd)
        {
            if (firstEnd == null) throw new ArgumentNullException(nameof(firstEnd));
            if (otherEnd == null) throw new ArgumentNullException(nameof(otherEnd));
            ModelSymbol firstSymbol = firstEnd.DeclaringSymbol;
            ModelSymbol otherSymbol = otherEnd.DeclaringSymbol;
            if (firstSymbol.initialized) throw new InvalidOperationException("Cannot register an opposite property into an initialized symbol.");
            if (otherSymbol.initialized) throw new InvalidOperationException("Cannot register an opposite property into an initialized symbol.");
            firstSymbol.RegisterOppositeProperty(firstEnd, otherEnd);
            otherSymbol.RegisterOppositeProperty(otherEnd, firstEnd);
        }

        public bool Initialized { get { return this.initialized; } }
        public ImmutableList<ModelSymbol> BaseSymbols { get { return this.baseSymbols; } }
        public ImmutableList<ModelProperty> DeclaredProperties { get { return this.declaredProperties; } }
        public ImmutableList<ModelProperty> Properties
        {
            get
            {
                ImmutableList<ModelProperty> result = this.properties;
                if (result != null) return result;
                result = ImmutableList<ModelProperty>.Empty;
                foreach (var baseSymbol in this.baseSymbols)
                {
                    foreach (var prop in baseSymbol.Properties)
                    {
                        if (!result.Contains(prop))
                        {
                            result = result.Add(prop);
                        }
                    }
                }
                result.AddRange(this.declaredProperties);
                result = Interlocked.CompareExchange(ref this.properties, result, null) ?? result;
                return result;
            }
        }
        internal ImmutableDictionary<ModelProperty, RelatedProperties> RelatedProperties { get { return this.relatedProperties; } }

        public void Initialize()
        {
            if (this.initialized) return;
            lock (this)
            {
                if (this.initialized) return;
                this.RegisterProperties();
                this.CreateRelatedProperties();
                this.emptyGreenSymbol = GreenSymbol.CreateWithProperties(this.Properties);
                this.initialized = true;
            }
        }

        private void CreateRelatedProperties()
        {
            // TODO
        }

        public bool HasAffectedProperties(ModelProperty property)
        {
            return this.relatedProperties.ContainsKey(property);
        }

        public abstract Type MutableType { get; }
        public abstract Type ImmutableType { get; }
        protected abstract void RegisterProperties();
        internal GreenSymbol EmptyGreenSymbol { get { return this.emptyGreenSymbol; } }

        public override string ToString()
        {
            return this.GetType().FullName;
        }
    }

}
