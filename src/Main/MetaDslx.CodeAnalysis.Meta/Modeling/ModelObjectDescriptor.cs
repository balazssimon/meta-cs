using MetaDslx.CodeAnalysis.Symbols;
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
        private ConstructorInfo _idConstructor;
        private Type idType;
        private Type immutableType;
        private Type mutableType;
        private Type symbolType;
        private ModelProperty nameProperty;
        private ImmutableArray<Attribute> annotations;
        private ImmutableArray<ModelObjectDescriptor> baseDescriptors;
        private ImmutableArray<ModelProperty> declaredProperties;
        private ImmutableDictionary<ModelProperty, Slot> slotMap;
        private ImmutableArray<Slot> slots;
        private ImmutableArray<ModelProperty> allProperties;
        private ImmutableArray<ModelProperty> properties;

        private ModelObjectDescriptor(Type descriptorType)
        {
            this.initialized = false;
            this.initializedBaseDescriptors = false;
            this.descriptorType = descriptorType;
            this.annotations = descriptorType.GetCustomAttributes(false).OfType<Attribute>().ToImmutableArray();
            foreach (var annot in this.annotations)
            {
                if (annot is ModelObjectDescriptorAttribute da)
                {
                    this.idType = da.IdType;
                    this.immutableType = da.ImmutableType;
                    this.mutableType = da.MutableType;
                }
                if (annot is SymbolAttribute sa)
                {
                    this.symbolType = sa.SymbolType;
                }
            }
            this.nameProperty = null;
            this.emptyGreenObject = GreenObject.Empty;
            this.baseDescriptors = ImmutableArray<ModelObjectDescriptor>.Empty;
            this.declaredProperties = ImmutableArray<ModelProperty>.Empty;
            this.slotMap = ImmutableDictionary<ModelProperty, Slot>.Empty;
            this.slots = ImmutableArray<Slot>.Empty;
            this.allProperties = ImmutableArray<ModelProperty>.Empty;
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
            ImmutableArray<ModelObjectDescriptor> oldBaseDescriptors;
            ImmutableArray<ModelObjectDescriptor> newBaseDescriptors;
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
            } while (ImmutableInterlocked.InterlockedCompareExchange(ref this.baseDescriptors, newBaseDescriptors, oldBaseDescriptors) != oldBaseDescriptors);
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
                ImmutableArray<ModelProperty> oldDeclaredProperties;
                ImmutableArray<ModelProperty> newDeclaredProperties;
                do
                {
                    oldDeclaredProperties = this.declaredProperties;
                    newDeclaredProperties = oldDeclaredProperties.Add(property);
                } while (ImmutableInterlocked.InterlockedCompareExchange(ref this.declaredProperties, newDeclaredProperties, oldDeclaredProperties) != oldDeclaredProperties);
            }
        }

        internal bool Initialized { get { return this.initialized; } }
        internal Type DescriptorType { get { return this.descriptorType; } }
        public ImmutableArray<Attribute> Annotations { get { return this.annotations; } }

        public string Name => this.ImmutableType.Name;

        public Type SymbolType
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.symbolType;
            }
        }

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

        public ImmutableArray<ModelObjectDescriptor> BaseDescriptors
        {
            get
            {
                if (!this.initializedBaseDescriptors) this.InitializeBaseDescriptors();
                return this.baseDescriptors;
            }
        }

        private ImmutableArray<ModelObjectDescriptor> lazyAllBaseDescriptors;

        /// <summary>
        /// The list of all descriptors of which this descriptors is a declared subtype, excluding this descriptor
        /// itself. This includes all declared base descriptors, all declared base descriptors of base
        /// descriptors, and all declared base descriptors of those results (recursively).  Each result
        /// appears exactly once in the list. This list is topologically sorted by the inheritance
        /// relationship: if descriptors type A extends descriptors type B, then A precedes B in the list.
        /// </summary>
        public ImmutableArray<ModelObjectDescriptor> AllBaseDescriptors
        {
            get
            {
                if (lazyAllBaseDescriptors.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref lazyAllBaseDescriptors, this.MakeAllBaseDescriptors());
                }
                return lazyAllBaseDescriptors;
            }
        }

        /// Produce all base descriptors in topologically sorted order. We use
        /// ModelObjectDescriptor.BaseDescriptors as the source of edge data, which has had cycles and infinitely
        /// long dependency cycles removed. Consequently, it is possible (and we do) use the
        /// simplest version of Tarjan's topological sorting algorithm.
        private ImmutableArray<ModelObjectDescriptor> MakeAllBaseDescriptors()
        {
            var result = ArrayBuilder<ModelObjectDescriptor>.GetInstance();
            var visited = new HashSet<ModelObjectDescriptor>();
            var baseTypes = this.BaseDescriptors;
            for (int i = baseTypes.Length - 1; i >= 0; i--)
            {
                AddAllBaseDescriptors(baseTypes[i], visited, result);
            }
            result.ReverseContents();
            return result.ToImmutableAndFree();
        }

        private static void AddAllBaseDescriptors(ModelObjectDescriptor baseType, HashSet<ModelObjectDescriptor> visited, ArrayBuilder<ModelObjectDescriptor> result)
        {
            if (visited.Add(baseType))
            {
                ImmutableArray<ModelObjectDescriptor> baseTypes = baseType.BaseDescriptors;
                for (int i = baseTypes.Length - 1; i >= 0; i--)
                {
                    var nextBaseType = baseTypes[i];
                    AddAllBaseDescriptors(nextBaseType, visited, result);
                }
                result.Add(baseType);
            }
        }

        public ImmutableArray<ModelProperty> DeclaredProperties
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.declaredProperties;
            }
        }
        public ImmutableArray<ModelProperty> AllProperties 
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.allProperties;
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

public ModelProperty NameProperty
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.nameProperty;
            }
        }
        internal ImmutableArray<Slot> Slots
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.slots;
            }
        }
        internal ImmutableDictionary<ModelProperty, Slot> PropertyInfo
        {
            get
            {
                if (!this.initialized) this.Initialize();
                return this.slotMap;
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
                this.CreateSlots();
                this.CreateEmptyGreenObject();
            }
        }

        private void CreateProperties()
        {
            var allProperties = ArrayBuilder<ModelProperty>.GetInstance();
            var properties = ArrayBuilder<ModelProperty>.GetInstance();
            try
            {
                foreach (var baseDescriptor in this.AllBaseDescriptors)
                {
                    if (this.symbolType == null) this.symbolType = baseDescriptor.SymbolType;
                }
                foreach (var baseDescriptor in this.AllBaseDescriptors.Reverse())
                {
                    baseDescriptor.Initialize();
                    foreach (var prop in baseDescriptor.AllProperties)
                    {
                        if (!allProperties.Contains(prop))
                        {
                            allProperties.Add(prop);
                            if (prop.IsName)
                            {
                                this.nameProperty = prop;
                            }
                        }
                    }
                }
                allProperties.AddRange(this.declaredProperties);
                foreach (var prop in this.declaredProperties)
                {
                    if (prop.IsName)
                    {
                        this.nameProperty = prop;
                    }
                }
                foreach (var prop in allProperties)
                {
                    int nameIndex = properties.FindIndex(p => p.Name == prop.Name);
                    if (nameIndex >= 0) properties.RemoveAt(nameIndex);
                    foreach (var redefProp in prop.RedefinedProperties)
                    {
                        int index = properties.IndexOf(redefProp);
                        if (index >= 0) properties.RemoveAt(index);
                    }
                    properties.Add(prop);
                }
            }
            finally
            {
                ImmutableInterlocked.InterlockedExchange(ref this.allProperties, allProperties.ToImmutableAndFree());
                ImmutableInterlocked.InterlockedExchange(ref this.properties, properties.ToImmutableAndFree());
            }
        }

        private void CreateSlots()
        {
            this.slotMap = ComplexSlotBuilder.Build(this.allProperties);
            this.slots = this.allProperties.Select(p => this.slotMap[p]).ToImmutableArray();
        }

        private void CreateEmptyGreenObject()
        {
            Interlocked.Exchange(ref this.emptyGreenObject, GreenObject.CreateWithSlots(this.Slots));
        }

        internal Slot GetSlot(ModelProperty property)
        {
            Slot result;
            if (this.slotMap.TryGetValue(property, out result))
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
