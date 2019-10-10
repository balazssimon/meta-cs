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
    internal enum MetaModelSymbolFlags : uint
    {
        None = 0x0000,
        Scope = 0x0001,
        LocalScope = 0x0002,
        Type = 0x0004,
        Local = 0x0008
    }

    public sealed class ModelSymbolInfo
    {
        private static Type[] EmptyTypeArray = new Type[0];
        private static object[] EmptyObjectArray = new object[0];

        private static ImmutableDictionary<Type, ModelSymbolInfo> descriptors = ImmutableDictionary<Type, ModelSymbolInfo>.Empty;
        private static ImmutableDictionary<Type, ModelSymbolInfo> immutableTypes = ImmutableDictionary<Type, ModelSymbolInfo>.Empty;
        private static ImmutableDictionary<Type, ModelSymbolInfo> mutableTypes = ImmutableDictionary<Type, ModelSymbolInfo>.Empty;

        private bool initialized;
        private bool initializedBaseSymbols;
        private Type symbolDescriptorType;
        private GreenSymbol emptyGreenSymbol;
        private MetaModelSymbolFlags metaFlags;
        private ModelSymbolDescriptorAttribute descriptor;
        private ConstructorInfo _idConstructor;
        private Type idType;
        private Type immutableType;
        private Type mutableType;
        private ModelProperty nameProperty;
        private ModelProperty typeProperty;
        private ImmutableArray<Attribute> annotations;
        private ImmutableList<ModelSymbolInfo> baseSymbols;
        private ImmutableList<ModelProperty> declaredProperties;
        private ImmutableDictionary<ModelProperty, ModelPropertyInfo> propertyInfo;
        private ImmutableArray<ModelProperty> properties;

        private ModelSymbolInfo(Type symbolDescriptorType)
        {
            this.initialized = false;
            this.initializedBaseSymbols = false;
            this.symbolDescriptorType = symbolDescriptorType;
            this.annotations = symbolDescriptorType.GetCustomAttributes(false).OfType<Attribute>().ToImmutableArray();
            this.metaFlags = MetaModelSymbolFlags.None;
            foreach (var annot in this.annotations)
            {
                if (annot is ModelSymbolDescriptorAttribute)
                {
                    ModelSymbolDescriptorAttribute da = (ModelSymbolDescriptorAttribute)annot;
                    this.idType = da.IdType;
                    this.immutableType = da.ImmutableType;
                    this.mutableType = da.MutableType;
                }
                else if (annot is LocalAttribute)
                {
                    this.metaFlags |= MetaModelSymbolFlags.Local;
                }
                else if (annot is ScopeAttribute)
                {
                    this.metaFlags |= MetaModelSymbolFlags.Scope;
                }
                else if (annot is LocalScopeAttribute)
                {
                    this.metaFlags |= MetaModelSymbolFlags.LocalScope;
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
            this.properties = ImmutableArray<ModelProperty>.Empty;
        }

        public static ModelSymbolInfo GetSymbolInfo(Type type)
        {
            if (type == null) return null;
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

        public SymbolId CreateSymbolId()
        {
            if (_idConstructor == null)
            {
                Interlocked.CompareExchange(ref _idConstructor, idType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, EmptyTypeArray, null), null);
            }
            return (SymbolId)_idConstructor.Invoke(EmptyObjectArray);
        }

        public MutableSymbolBase CreateMutable(MutableModel model, bool weakReference = false)
        {
            var symbol = model.CreateSymbol(this.CreateSymbolId(), false);
            symbol.MCallInit();
            symbol.MMakeCreated();
            return symbol;
        }

        internal ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return this.CreateSymbolId().CreateImmutable(model);
        }

        public ImmutableList<ModelSymbolInfo> BaseSymbols
        {
            get
            {
                if (!this.initializedBaseSymbols) this.InitializeBaseSymbols();
                return this.baseSymbols;
            }
        }

        private ImmutableArray<ModelSymbolInfo> lazyAllBaseSymbols;
        public ImmutableArray<ModelSymbolInfo> AllBaseSymbols
        {
            get
            {
                if (lazyAllBaseSymbols == default)
                {
                    var builder = ArrayBuilder<ModelSymbolInfo>.GetInstance();
                    try
                    {
                        this.CollectAllBaseSymbols(builder);
                    }
                    finally
                    {
                        ImmutableInterlocked.InterlockedCompareExchange(ref lazyAllBaseSymbols, builder.ToImmutableAndFree(), default);
                    }
                }
                return lazyAllBaseSymbols;
            }
        }

        private void CollectAllBaseSymbols(ArrayBuilder<ModelSymbolInfo> baseSymbols)
        {
            foreach (var item in this.BaseSymbols)
            {
                if (!baseSymbols.Contains(item))
                {
                    foreach (var baseItem in item.AllBaseSymbols)
                    {
                        if (!baseSymbols.Contains(baseItem))
                        {
                            baseSymbols.Add(baseItem);
                        }
                    }
                    baseSymbols.Add(item);
                }
            }
        }

        public ImmutableList<ModelProperty> DeclaredProperties { get { return this.declaredProperties; } }

        public bool IsLocal
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelSymbolFlags.Local);
            }
        }
        public bool IsScope
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelSymbolFlags.Scope);
            }
        }
        public bool IsLocalScope
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.metaFlags.HasFlag(MetaModelSymbolFlags.LocalScope);
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
                foreach (var baseSymbol in this.baseSymbols.Reverse())
                {
                    foreach (var prop in baseSymbol.Properties.Reverse())
                    {
                        if (!properties.Contains(prop))
                        {
                            properties.Add(prop);
                            if (this.nameProperty == null && prop.IsName)
                            {
                                this.nameProperty = prop;
                                if (prop.IsLocal)
                                {
                                    this.metaFlags |= MetaModelSymbolFlags.Local;
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
            if (this.immutableType != null) return this.immutableType.FullName;
            else if (this.mutableType != null) return this.mutableType.FullName;
            else if (this.symbolDescriptorType != null) return this.symbolDescriptorType.FullName;
            else return base.ToString();
        }
    }

}
