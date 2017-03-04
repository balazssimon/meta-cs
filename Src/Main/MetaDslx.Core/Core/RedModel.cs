using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Languages.Meta.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public interface ISymbol : IMessageSerializable
    {
        MetaModel MMetaModel { get; }
        MetaClass MMetaClass { get; }
        SymbolId MId { get; }
        IModel MModel { get; }

        string MName { get; }
        ISymbol MType { get; }
        bool MIsNamespace { get; }
        bool MIsType { get; }
        bool MIsNamedType { get; }
        bool MIsScope { get; }
        bool MIsLocalScope { get; }

        ISymbol MParent { get; }
        IReadOnlyList<ISymbol> MChildren { get; }

        ImmutableList<ModelProperty> MProperties { get; }
        ImmutableList<ModelProperty> MAllProperties { get; }
        ModelProperty MGetProperty(string name);
        ImmutableList<ModelProperty> MGetProperties(string name);

        object MGet(ModelProperty property);
        bool MHasConcreteValue(ModelProperty property);
        bool MIsSet(ModelProperty property);
        IReadOnlyList<ISymbol> MGetImports();
        IReadOnlyList<ISymbol> MGetBases();
        IReadOnlyList<ISymbol> MGetAllBases();
        IReadOnlyList<ISymbol> MGetMembers();
    }

    public interface IModel
    {
        ModelId Id { get; }
        string Name { get; }
        ModelVersion Version { get; }
    }

    public interface ImmutableSymbol : ISymbol
    {
        new ImmutableModel MModel { get; }
        new ImmutableSymbol MParent { get; }
        new ImmutableModelList<ImmutableSymbol> MChildren { get; }

        new ImmutableSymbol MType { get; }

        MutableSymbol ToMutable();
        MutableSymbol ToMutable(MutableModel mutableModel);
    }

    public interface MutableSymbol : ISymbol
    {
        bool MIsReadOnly { get; }
        new MutableModel MModel { get; }
        new MutableSymbol MParent { get; }
        new ImmutableModelList<MutableSymbol> MChildren { get; }

        void MAttachProperty(ModelProperty property);

        new string MName { get; set; }
        new MutableSymbol MType { get; set; }

        void MSet(ModelProperty property, object value);
        void MSetLazy(ModelProperty property, LazyValue value);
        void MAdd(ModelProperty property, object value);
        void MAddLazy(ModelProperty property, LazyValue value);
        void MAddRange(ModelProperty property, IEnumerable<object> value);
        void MAddRangeLazy(ModelProperty property, LazyValue value);
        void MAddRangeLazy(ModelProperty property, IEnumerable<LazyValue> value);
        void MSetOrAdd(ModelProperty property, object value);
        void MSetOrAddLazy(ModelProperty property, LazyValue value);
        void MMakeCreated();

        ImmutableSymbol ToImmutable();
        ImmutableSymbol ToImmutable(ImmutableModel immutableModel);
    }

    public abstract class LazyValue
    {
        internal LazyValue()
        {

        }

        internal virtual bool IsSingleValue
        {
            get { return true; }
        }

        internal virtual bool IsSilent
        {
            get { return false; }
        }

        internal virtual DiagnosticBag Diagnostics
        {
            get { return null; }
        }

        internal virtual Location Location
        {
            get { return Location.None; }
        }

        internal protected virtual object CreateRedValue()
        {
            return null;
        }

        internal protected virtual object[] CreateRedValues()
        {
            return EmptyCollections.ObjectArray;
        }

        internal object CreateGreenValue()
        {
            object value = this.CreateRedValue();
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).MId;
            }
            else if (value is ImmutableSymbolBase)
            {
                return ((ImmutableSymbolBase)value).MId;
            }
            return value;
        }

        internal object[] CreateGreenValues()
        {
            var values = this.CreateRedValues();
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                if (value is MutableSymbolBase)
                {
                    values[i] = ((MutableSymbolBase)value).MId;
                }
                else if (value is ImmutableSymbolBase)
                {
                    values[i] = ((ImmutableSymbolBase)value).MId;
                }
            }
            return values;
        }

        public static LazyValue CreateSingle(Func<object> lazy, bool silent = false)
        {
            if (silent) return new SilentSingleLazyValue(lazy);
            else return new SingleLazyValue(lazy);
        }

        public static LazyValue CreateSingle(Func<object> lazy, Location location, DiagnosticBag diagnostics)
        {
            return new SingleLazyValueWithLocation(lazy, location, diagnostics);
        }

        public static LazyValue CreateMultiple(Func<IEnumerable<object>> lazy, bool silent = false)
        {
            if (silent) return new SilentMultipleLazyValues(lazy);
            else return new MultipleLazyValues(lazy);
        }

        public static LazyValue CreateMultiple(Func<IEnumerable<object>> lazy, Location location, DiagnosticBag diagnostics)
        {
            return new MultipleLazyValuesWithLocation(lazy, location, diagnostics);
        }

        public static IEnumerable<LazyValue> CreateMultiple(IEnumerable<Func<object>> lazy)
        {
            return lazy.Select(l => CreateSingle(l));
        }

        public static IEnumerable<LazyValue> CreateMultiple(IEnumerable<Func<object>> lazy, Location location, DiagnosticBag diagnostics)
        {
            return lazy.Select(l => CreateSingle(l, location, diagnostics));
        }
    }

    internal class SingleLazyValue : LazyValue
    {
        private Func<object> lazy;

        internal SingleLazyValue(Func<object> lazy)
        {
            this.lazy = lazy;
        }

        internal Func<object> Lazy
        {
            get { return this.lazy; }
        }

        internal protected override object CreateRedValue()
        {
            return lazy();
        }

    }

    internal class SilentSingleLazyValue : LazyValue
    {
        private Func<object> lazy;

        internal SilentSingleLazyValue(Func<object> lazy)
        {
            this.lazy = lazy;
        }

        internal override bool IsSilent
        {
            get { return true; }
        }

        internal Func<object> Lazy
        {
            get { return this.lazy; }
        }

        internal protected override object CreateRedValue()
        {
            return lazy();
        }
    }

    internal class SingleLazyValueWithLocation : SingleLazyValue
    {
        private DiagnosticBag diagnostics;
        private Location location;

        internal SingleLazyValueWithLocation(Func<object> lazy, Location location, DiagnosticBag diagnostics)
            : base(lazy)
        {
            this.diagnostics = diagnostics;
            this.location = location;
        }

        internal override bool IsSilent
        {
            get { return true; }
        }

        internal override DiagnosticBag Diagnostics
        {
            get { return this.diagnostics; }
        }

        internal override Location Location
        {
            get { return this.location; }
        }
    }

    internal class MultipleLazyValues : LazyValue
    {
        private Func<IEnumerable<object>> lazy;

        internal MultipleLazyValues(Func<IEnumerable<object>> lazy)
        {
            this.lazy = lazy;
        }

        internal override bool IsSingleValue
        {
            get { return false; }
        }

        internal Func<IEnumerable<object>> Lazy
        {
            get { return this.lazy; }
        }

        internal protected override object[] CreateRedValues()
        {
            return lazy().ToArray();
        }
    }

    internal class SilentMultipleLazyValues : LazyValue
    {
        private Func<IEnumerable<object>> lazy;

        internal SilentMultipleLazyValues(Func<IEnumerable<object>> lazy)
        {
            this.lazy = lazy;
        }

        internal override bool IsSilent
        {
            get { return true; }
        }

        internal override bool IsSingleValue
        {
            get { return false; }
        }

        internal Func<IEnumerable<object>> Lazy
        {
            get { return this.lazy; }
        }

        internal protected override object[] CreateRedValues()
        {
            return lazy().ToArray();
        }
    }

    internal class MultipleLazyValuesWithLocation : MultipleLazyValues
    {
        private DiagnosticBag diagnostics;
        private Location location;

        internal MultipleLazyValuesWithLocation(Func<IEnumerable<object>> lazy, Location location, DiagnosticBag diagnostics)
            : base(lazy)
        {
            this.diagnostics = diagnostics;
            this.location = location;
        }

        internal override bool IsSilent
        {
            get { return true; }
        }

        internal override DiagnosticBag Diagnostics
        {
            get { return this.diagnostics; }
        }

        internal override Location Location
        {
            get { return this.location; }
        }
    }

    public abstract class ImmutableSymbolBase : ImmutableSymbol
    {
        private SymbolId id;
        private ImmutableModel model;

        protected ImmutableSymbolBase(SymbolId id, ImmutableModel model)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            this.id = id;
            this.model = model;
        }

        public MutableSymbol ToMutable()
        {
            MutableModel mutableModel = this.model.ToMutable();
            return mutableModel.GetSymbol(this);
        }

        public MutableSymbol ToMutable(MutableModel mutableModel)
        {
            if (mutableModel == null) throw new ArgumentNullException(nameof(mutableModel));
            return mutableModel.GetSymbol(this);
        }

        public SymbolId MId { get { return this.id; } }

        public abstract MetaModel MMetaModel { get; }
        public abstract MetaClass MMetaClass { get; }

        public ImmutableModel MModel { get { return this.model; } }
        IModel ISymbol.MModel { get { return this.MModel; } }
        public ImmutableSymbol MParent { get { return this.model.MParent(this.id); } }
        public ImmutableModelList<ImmutableSymbol> MChildren { get { return this.model.MChildren(this.id); } }

        ISymbol ISymbol.MParent { get { return this.model.MParent(this.id); } }
        IReadOnlyList<ISymbol> ISymbol.MChildren { get { return this.model.MChildren(this.id); } }

        public IReadOnlyList<ISymbol> MGetImports() { return this.model.MGetImports(this.id); }
        public IReadOnlyList<ISymbol> MGetBases() { return this.model.MGetBases(this.id); }
        public IReadOnlyList<ISymbol> MGetAllBases() { return this.model.MGetAllBases(this.id); }
        public IReadOnlyList<ISymbol> MGetMembers() { return this.model.MGetMembers(this.id); }

        public ImmutableList<ModelProperty> MProperties { get { return this.model.MProperties(this.id); } }
        public ImmutableList<ModelProperty> MAllProperties { get { return this.model.MAllProperties(this.id); } }
        public ModelProperty MGetProperty(string name)
        {
            ImmutableList<ModelProperty> properties = this.MProperties;
            for (int i = properties.Count-1; i >= 0; i--)
            {
                ModelProperty prop = properties[i];
                if (prop.Name == name) return prop;
            }
            return null;
        }
        public ImmutableList<ModelProperty> MGetProperties(string name)
        {
            return this.MProperties.Where(p => p.Name == name).ToImmutableList().Reverse();
        }

        public string MName
        {
            get
            {
                ModelProperty nameProperty = this.id.SymbolInfo.NameProperty;
                if (nameProperty != null)
                {
                    object nameObj = this.MGet(nameProperty);
                    if (nameObj == null) return null;
                    else return nameObj.ToString();
                }
                return null;
            }
        }
        public ImmutableSymbol MType
        {
            get
            {
                ModelProperty typeProperty = this.id.SymbolInfo.TypeProperty;
                if (typeProperty != null)
                {
                    object typeObj = this.MGet(typeProperty);
                    return typeObj as ImmutableSymbol;
                }
                return null;
            }
        }
        public bool MIsNamespace { get { return this.id.SymbolInfo.IsNamespace; } }
        public bool MIsType { get { return this.id.SymbolInfo.IsType; } }
        public bool MIsNamedType { get { return this.id.SymbolInfo.IsNamedType; } }

        public bool MIsScope { get { return this.id.SymbolInfo.IsScope; } }
        public bool MIsLocalScope { get { return this.id.SymbolInfo.IsLocalScope; } }

        ISymbol ISymbol.MType
        {
            get
            {
                return this.MType;
            }
        }

        public object MGet(ModelProperty property)
        {
            return this.model.MGet(this.id, property);
        }
        public bool MIsSet(ModelProperty property)
        {
            return this.model.MIsSet(this.id, property);
        }
        public bool MHasConcreteValue(ModelProperty property)
        {
            return this.model.MHasConcreteValue(this.id, property);
        }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : struct
        {
            object valueObj = this.model.GetValue(this.id, property);
            if (valueObj == null) value = default(T);
            else value = (T)valueObj;
            return value;
        }

        protected T GetReference<T>(ModelProperty property, ref T value)
            where T : class
        {
            T result = value;
            if (result == null)
            {
                result = (T)this.model.GetValue(this.id, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected ImmutableModelSet<T> GetSet<T>(ModelProperty property, ref ImmutableModelSet<T> value)
        {
            ImmutableModelSet<T> result = value;
            if (result == null)
            {
                result = this.model.GetSet<T>(this.id, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected ImmutableModelList<T> GetList<T>(ModelProperty property, ref ImmutableModelList<T> value)
        {
            ImmutableModelList<T> result = value;
            if (result == null)
            {
                result = this.model.GetList<T>(this.id, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public override string ToString()
        {
            string result = this.id.SymbolInfo.ImmutableType?.Name;
            string name = this.MName;
            if (name != null)
            {
                result = name + " (" + result + ")";
            }
            return result;
        }
    }

    public abstract class MutableSymbolBase : MutableSymbol
    {
        private bool creating;
        private SymbolId id;
        private MutableModel model;

        protected MutableSymbolBase(SymbolId id, MutableModel model, bool creating)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            this.id = id;
            this.model = model;
            this.creating = creating;
        }

        public ImmutableSymbol ToImmutable()
        {
            ImmutableModel immutableModel = this.model.ToImmutable();
            return immutableModel.GetSymbol(this);
        }

        public ImmutableSymbol ToImmutable(ImmutableModel immutableModel)
        {
            if (immutableModel == null) throw new ArgumentNullException(nameof(immutableModel));
            return immutableModel.GetSymbol(this);
        }

        public SymbolId MId { get { return this.id; } }
        internal bool MIsBeingCreated { get { return this.creating; } }
        public bool MIsReadOnly { get { return this.model.IsReadOnly; } }

        public abstract MetaModel MMetaModel { get; }
        public abstract MetaClass MMetaClass { get; }

        public MutableModel MModel { get { return this.model; } }
        IModel ISymbol.MModel { get { return this.MModel; } }
        public MutableSymbol MParent { get { return this.model.MParent(this.id); } }
        public ImmutableModelList<MutableSymbol> MChildren { get { return this.model.MChildren(this.id); } }

        ISymbol ISymbol.MParent { get { return this.model.MParent(this.id); } }
        IReadOnlyList<ISymbol> ISymbol.MChildren { get { return this.model.MChildren(this.id); } }

        public IReadOnlyList<ISymbol> MGetImports() { return this.model.MGetImports(this); }
        public IReadOnlyList<ISymbol> MGetBases() { return this.model.MGetBases(this); }
        public IReadOnlyList<ISymbol> MGetAllBases() { return this.model.MGetAllBases(this); }
        public IReadOnlyList<ISymbol> MGetMembers() { return this.model.MGetMembers(this); }

        public ImmutableList<ModelProperty> MProperties { get { return this.model.MProperties(this.id); } }
        public ImmutableList<ModelProperty> MAllProperties { get { return this.model.MAllProperties(this.id); } }
        public ModelProperty MGetProperty(string name)
        {
            ImmutableList<ModelProperty> properties = this.MProperties;
            for (int i = properties.Count - 1; i >= 0; i--)
            {
                ModelProperty prop = properties[i];
                if (prop.Name == name) return prop;
            }
            return null;
        }
        public ImmutableList<ModelProperty> MGetProperties(string name)
        {
            return this.MProperties.Where(p => p.Name == name).ToImmutableList().Reverse();
        }
        public void MAttachProperty(ModelProperty property)
        {
            this.model.MAttachProperty(this.id, property);
        }

        public string MName
        {
            get
            {
                ModelProperty nameProperty = this.id.SymbolInfo.NameProperty;
                if (nameProperty != null)
                {
                    object nameObj = this.MGet(nameProperty);
                    if (nameObj == null) return null;
                    else return nameObj.ToString();
                }
                return null;
            }
            set
            {
                ModelProperty nameProperty = this.id.SymbolInfo.NameProperty;
                if (nameProperty != null)
                {
                    this.SetReference(nameProperty, value);
                }
            }
        }
        public MutableSymbol MType
        {
            get
            {
                ModelProperty typeProperty = this.id.SymbolInfo.TypeProperty;
                if (typeProperty != null)
                {
                    object typeObj = this.MGet(typeProperty);
                    return typeObj as MutableSymbol;
                }
                return null;
            }
            set
            {
                ModelProperty typeProperty = this.id.SymbolInfo.TypeProperty;
                if (typeProperty != null)
                {
                    this.SetReference(typeProperty, value);
                }
            }
        }
        public bool MIsNamespace { get { return this.id.SymbolInfo.IsNamespace; } }
        public bool MIsType { get { return this.id.SymbolInfo.IsType; } }
        public bool MIsNamedType { get { return this.id.SymbolInfo.IsNamedType; } }

        public bool MIsScope { get { return this.id.SymbolInfo.IsScope; } }
        public bool MIsLocalScope { get { return this.id.SymbolInfo.IsLocalScope; } }

        ISymbol ISymbol.MType
        {
            get
            {
                return this.MType;
            }
        }

        protected virtual void MInit()
        {
        }

        internal void MCallInit()
        {
            this.MInit();
        }

        public void MMakeCreated()
        {
            this.creating = false;
        }

        public object MGet(ModelProperty property)
        {
            return this.model.MGet(this, property);
        }

        public bool MHasConcreteValue(ModelProperty property)
        {
            return this.model.MHasConcreteValue(this.id, property);
        }

        public bool MIsSet(ModelProperty property)
        {
            return this.model.MIsSet(this.id, property);
        }

        public void MSet(ModelProperty property, object value)
        {
            if (property.IsCollection) throw new ModelException(Location.None, new DiagnosticInfo(ModelErrorCode.ERR_CannotReassignCollectionProperty, property, this));
            this.model.SetValue(this.id, property, value, this.creating);
        }

        public void MSetLazy(ModelProperty property, LazyValue value)
        {
            if (property.IsCollection) throw new ModelException(value.Location, new DiagnosticInfo(ModelErrorCode.ERR_CannotReassignCollectionProperty, property, this));
            this.model.SetLazyValue(this.id, property, value, this.creating);
        }

        public void MAdd(ModelProperty property, object value)
        {
            if (property.IsCollection)
            {
                this.model.AddItem(this.id, property, value, this.creating);
            }
            else
            {
                this.model.SetValue(this.id, property, value, this.creating);
            }
        }

        public void MAddLazy(ModelProperty property, LazyValue value)
        {
            if (property.IsCollection)
            {
                this.model.AddLazyItem(this.id, property, value, this.creating);
            }
            else
            {
                this.model.SetLazyValue(this.id, property, value, this.creating);
            }
        }

        public void MAddRange(ModelProperty property, IEnumerable<object> values)
        {
            if (!property.IsCollection) throw new ModelException(Location.None, new DiagnosticInfo(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty, property, this));
            this.model.AddItems(this.id, property, values, this.creating);
        }

        public void MAddRangeLazy(ModelProperty property, LazyValue values)
        {
            if (!property.IsCollection) throw new ModelException(values.Location, new DiagnosticInfo(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty, property, this));
            this.model.AddLazyItems(this.id, property, values, this.creating);
        }

        public void MAddRangeLazy(ModelProperty property, IEnumerable<LazyValue> values)
        {
            if (!property.IsCollection) throw new ModelException(Location.None, new DiagnosticInfo(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty, property, this));
            this.model.AddLazyItems(this.id, property, values, this.creating);
        }

        public void MSetOrAdd(ModelProperty property, object value)
        {
            if (property.IsCollection)
            {
                this.model.AddItem(this.id, property, value, this.creating);
            }
            else
            {
                this.model.SetValue(this.id, property, value, this.creating);
            }
        }

        public void MSetOrAddLazy(ModelProperty property, LazyValue value)
        {
            if (property.IsCollection)
            {
                this.model.AddLazyItem(this.id, property, value, this.creating);
            }
            else
            {
                this.model.SetLazyValue(this.id, property, value, this.creating);
            }
        }

        protected T GetValue<T>(ModelProperty property)
            where T : struct
        {
            object valueObj = this.model.GetValue(this.id, property);
            if (valueObj == null) return default(T);
            else return (T)valueObj;
        }

        protected void SetValue<T>(ModelProperty property, T value)
            where T : struct
        {
            this.model.SetValue(this.id, property, value, this.creating);
        }

        protected T GetReference<T>(ModelProperty property)
            where T : class
        {
            return (T)this.model.GetValue(this.id, property);
        }

        protected void SetReference<T>(ModelProperty property, T value)
            where T : class
        {
            if (value is MutableSymbolBase && ((MutableSymbolBase)(object)value).model != this.model)
            {
                value = (T)this.model.ToRedValue(this.model.ToGreenValue(value));
            }
            this.model.SetValue(this.id, property, value, this.creating);
        }

        protected Func<T> GetLazyValue<T>(ModelProperty property)
            where T : struct
        {
            return (Func<T>)(object)this.model.GetLazyValue(this.id, property);
        }

        protected void SetLazyValue<T>(ModelProperty property, Func<T> value)
            where T : struct
        {
            this.model.SetLazyValue(this.id, property, LazyValue.CreateSingle((Func<object>)(object)value), this.creating);
        }

        protected Func<T> GetLazyReference<T>(ModelProperty property)
            where T : class
        {
            return (Func<T>)this.model.GetLazyValue(this.id, property);
        }

        protected void SetLazyReference<T>(ModelProperty property, Func<T> value)
            where T : class
        {
            this.model.SetLazyValue(this.id, property, LazyValue.CreateSingle(value), this.creating);
        }

        protected MutableModelSet<T> GetSet<T>(ModelProperty property, ref MutableModelSet<T> value)
        {
            MutableModelSet<T> result = value;
            if (result == null)
            {
                result = this.model.GetSet<T>(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected MutableModelList<T> GetList<T>(ModelProperty property, ref MutableModelList<T> value)
        {
            MutableModelList<T> result = value;
            if (result == null)
            {
                result = this.model.GetList<T>(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public override string ToString()
        {
            string result = this.id.SymbolInfo.ImmutableType?.Name;
            string name = this.MName;
            if (name != null)
            {
                result = name + " (" + result + ")";
            }
            return result;
        }
    }


    public sealed class ImmutableModel : IModel
    {
        private bool readOnly;
        private WeakReference<MutableModel> mutableModel;

        // Used in models contained by a group:
        private ModelId id;
        private ImmutableModelGroup group;

        // Used in standalone models:
        private GreenModel green;
        private ConditionalWeakTable<SymbolId, ImmutableSymbol> symbols;

        internal ImmutableModel(ModelId id, ImmutableModelGroup group, GreenModel green, bool readOnly, MutableModel mutableModel)
        {
            this.id = id;
            this.group = group;
            this.green = green;
            this.readOnly = readOnly;
            this.symbols = null;
            this.mutableModel = new WeakReference<MutableModel>(mutableModel);
        }

        internal ImmutableModel(GreenModel green, MutableModel mutableModel)
        {
            this.id = green.Id;
            this.group = null;
            this.green = green;
            this.readOnly = false;
            this.symbols = new ConditionalWeakTable<SymbolId, ImmutableSymbol>();
            this.mutableModel = new WeakReference<MutableModel>(mutableModel);
        }

        public ModelId Id { get { return this.id; } }
        public string Name { get { return this.green.Name; } }
        public ModelVersion Version { get { return this.green.Version; } }
        internal GreenModel Green { get { return this.green; } }
        public ImmutableModelGroup ModelGroup { get { return this.group; } }
        public IEnumerable<ImmutableSymbol> Symbols
        {
            get
            {
                foreach (var sid in this.Green.StrongSymbols)
                {
                    yield return this.GetExistingSymbol(sid);
                }
            }
        }

        internal ImmutableSymbol GetExistingSymbol(SymbolId sid)
        {
            if (sid == null) return null;
            if (this.group != null)
            {
                if (this.readOnly) return this.group.GetExistingReferenceSymbol(this.id, sid);
                else return this.group.GetExistingModelSymbol(this.id, sid);
            }
            else
            {
                return this.symbols.GetValue(sid, key => key.CreateImmutable(this));
            }
        }

        internal ImmutableSymbol ResolveSymbol(SymbolId sid)
        {
            if (this.group != null)
            {
                return this.group.ResolveSymbol(sid);
            }
            else
            {
                if (!this.ContainsSymbol(sid)) return null;
                return this.GetExistingSymbol(sid);
            }
        }

        internal ImmutableSymbol GetSymbol(SymbolId sid)
        {
            if (sid == null) return null;
            if (!this.ContainsSymbol(sid)) return null;
            return this.GetExistingSymbol(sid);
        }

        public ImmutableSymbol GetSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(((MutableSymbolBase)symbol).MId);
        }

        public ImmutableSymbol GetSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(((ImmutableSymbolBase)symbol).MId);
        }

        internal bool ContainsSymbol(SymbolId sid)
        {
            if (sid == null) return false;
            return this.Green.Symbols.ContainsKey(sid);
        }

        public bool ContainsSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((MutableSymbolBase)symbol).MId);
        }

        public bool ContainsSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((ImmutableSymbolBase)symbol).MId);
        }

        public MutableModel ToMutable(bool createNew = false)
        {
            MutableModel result = null;
            if (!createNew)
            {
                if (this.mutableModel.TryGetTarget(out result) && result != null)
                {
                    return result;
                }
            }
            MutableModel newModel = null;
            if (this.group != null)
            {
                MutableModelGroup mutableGroup = this.group.ToMutable(createNew);
                newModel = mutableGroup.GetModel(this.green.Id);
            }
            else
            {
                newModel = new MutableModel(this.green, this);
            }
            return newModel;
        }

        internal object ToGreenValue(object value)
        {
            if (value is ImmutableSymbolBase)
            {
                return ((ImmutableSymbolBase)value).MId;
            }
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).MId;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue();
                if (value is ImmutableSymbolBase)
                {
                    return this.ResolveSymbol(((ImmutableSymbolBase)value).MId);
                }
                else if (value is MutableSymbolBase)
                {
                    return this.ResolveSymbol(((MutableSymbolBase)value).MId);
                }
                return redValue;
            }
            else if (value is LazyValue)
            {
                return null;
            }
            else if (value == GreenSymbol.Unassigned)
            {
                return null;
            }
            else if (value is GreenList)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is SymbolId)
            {
                return this.ResolveSymbol((SymbolId)value);
            }
            else
            {
                return value;
            }
        }


        private object GetGreenValue(SymbolId sid, ModelProperty property)
        {
            GreenSymbol greenSymbol;
            if (this.green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                object greenValue;
                ModelPropertyInfo mpi = sid.SymbolInfo.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (greenSymbol.Properties.TryGetValue(property, out greenValue))
                {
                    return greenValue;
                }
            }
            return GreenSymbol.Unassigned;
        }

        internal object GetValue(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            var greenValue = this.GetGreenValue(sid, property);
            return this.ToRedValue(greenValue);
        }

        internal ImmutableModelSet<T> GetSet<T>(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var greenValue = this.GetGreenValue(sid, property);
            if (greenValue is GreenList)
            {
                return ImmutableModelSet<T>.FromGreenList((GreenList)greenValue, this);
            }
            return ImmutableModelSet<T>.FromGreenList(property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique, this);
        }

        internal ImmutableModelList<T> GetList<T>(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var greenValue = this.GetGreenValue(sid, property);
            if (greenValue is GreenList)
            {
                return ImmutableModelList<T>.FromGreenList((GreenList)greenValue, this);
            }
            return ImmutableModelList<T>.FromGreenList(property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique, this);
        }

        internal ImmutableSymbol MParent(SymbolId sid)
        {
            GreenSymbol greenSymbol;
            if (this.green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                return this.GetExistingSymbol(greenSymbol.Parent);
            }
            return null;
        }

        internal ImmutableModelList<ImmutableSymbol> MChildren(SymbolId sid)
        {
            GreenSymbol greenSymbol;
            if (this.green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                return ImmutableModelList<ImmutableSymbol>.FromSymbolIdList(greenSymbol.Children, this);
            }
            return ImmutableModelList<ImmutableSymbol>.Empty;
        }

        internal ImmutableModelList<ImmutableSymbol> MGetImports(SymbolId sid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(sid))
            {
                if (prop.IsImport)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(sid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(sid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return ImmutableModelList<ImmutableSymbol>.FromGreenList(result, this);
        }

        internal ImmutableModelList<ImmutableSymbol> MGetBases(SymbolId sid)
        {
            GreenList result = this.CollectBases(sid);
            result = result.Remove(sid);
            return ImmutableModelList<ImmutableSymbol>.FromGreenList(result, this);
        }

        internal ImmutableModelList<ImmutableSymbol> MGetAllBases(SymbolId sid)
        {
            GreenList result = GreenList.EmptyUnique;
            this.CollectAllBases(sid, ref result);
            result = result.Remove(sid);
            return ImmutableModelList<ImmutableSymbol>.FromGreenList(result, this);
        }

        private GreenList CollectBases(SymbolId sid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(sid))
            {
                if (prop.IsBaseScope)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(sid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(sid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return result;
        }

        private void CollectAllBases(SymbolId sid, ref GreenList result)
        {
            if (sid == null) return;

            var oldResult = result;
            result = result.Add(sid);
            if (result == oldResult) return;

            var bases = this.CollectBases(sid);
            foreach (var item in bases)
            {
                this.CollectAllBases(item as SymbolId, ref result);
            }
        }

        internal ImmutableModelList<ImmutableSymbol> MGetMembers(SymbolId sid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(sid))
            {
                if (prop.CanResolve)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(sid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(sid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return ImmutableModelList<ImmutableSymbol>.FromGreenList(result, this);
        }

        internal ImmutableList<ModelProperty> MProperties(SymbolId sid)
        {
            ModelSymbolInfo msi = sid.SymbolInfo;
            if (msi != null)
            {
                return msi.Properties;
            }
            return ImmutableList<ModelProperty>.Empty;
        }

        internal ImmutableList<ModelProperty> MAllProperties(SymbolId sid)
        {
            GreenSymbol greenSymbol;
            if (this.green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                return greenSymbol.Properties.Keys.ToImmutableList();
            }
            return ImmutableList<ModelProperty>.Empty;
        }

        internal object MGet(SymbolId sid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return this.GetList<object>(sid, property);
            }
            else
            {
                return this.GetValue(sid, property);
            }
        }

        internal bool MHasConcreteValue(SymbolId sid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return true;
            }
            else
            {
                var greenValue = this.GetGreenValue(sid, property);
                return greenValue != GreenSymbol.Unassigned && !(greenValue is LazyValue) && !(greenValue is GreenDerivedValue);
            }
        }

        internal bool MIsSet(SymbolId sid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return true;
            }
            else
            {
                var greenValue = this.GetGreenValue(sid, property);
                return greenValue != GreenSymbol.Unassigned;
            }
        }

        public override string ToString()
        {
            return this.Green.ToString();
        }
    }

    internal class ModelUpdateContext
    {
        public ModelUpdateContext(bool newUpdater, GreenModelUpdater updater, GreenModel model)
        {
            this.NewUpdater = newUpdater;
            this.Updater = updater;
            this.OriginalModel = model;
        }

        public ModelUpdateContext(bool newUpdater, GreenModelUpdater updater, GreenModelGroup group)
        {
            this.NewUpdater = newUpdater;
            this.Updater = updater;
            this.OriginalModelGroup = group;
        }

        internal bool NewUpdater { get; }
        internal GreenModelUpdater Updater { get; }
        internal GreenModel OriginalModel { get; }
        internal GreenModelGroup OriginalModelGroup { get; }
    }

    public enum ExceptionMode : int
    {
        Throw,
        Diagnose,
        Silent
    }

    public sealed class MutableModel : IModel
    {
        private bool readOnly;
        private WeakReference<ImmutableModel> immutableModel;

        // Used in models contained by a group:
        private ModelId id;
        private MutableModelGroup group;

        // Used in standalone models:
        private GreenModel green;
        private ConditionalWeakTable<SymbolId, MutableSymbol> symbols;
        private ThreadLocal<GreenModelUpdater> updater;

        public MutableModel(string name = null, ModelVersion version = null)
            : this(new GreenModel(new ModelId(), name, version), null)
        {
        }

        internal MutableModel(ModelId id, MutableModelGroup group, bool readOnly, ImmutableModel immutableModel)
        {
            this.id = id;
            this.group = group;
            this.green = null;
            this.updater = null;
            this.readOnly = readOnly;
            this.symbols = null;
            this.immutableModel = new WeakReference<ImmutableModel>(immutableModel);
        }

        internal MutableModel(GreenModel green, ImmutableModel immutableModel)
        {
            this.id = green.Id;
            this.group = null;
            this.green = green;
            this.updater = new ThreadLocal<GreenModelUpdater>();
            this.readOnly = false;
            this.symbols = new ConditionalWeakTable<SymbolId, MutableSymbol>();
            this.immutableModel = new WeakReference<ImmutableModel>(immutableModel);
        }

        public ModelId Id
        {
            get { return this.Green.Id; }
        }
        
        public string Name
        {
            get
            {
                return this.Green.Name;
            }
            set
            {
                ModelUpdateContext ctx;
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.SetName(this.id, value);
                } while (!this.EndUpdate(ctx));
            }
        }

        public ModelVersion Version
        {
            get
            {
                return this.green.Version;
            }
            set
            {
                ModelUpdateContext ctx;
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.SetVersion(this.id, value);
                } while (!this.EndUpdate(ctx));
            }
        }

        internal GreenModel Green
        {
            get
            {
                if (this.group != null)
                {
                    GreenModelGroup greenGroup = this.group.Green;
                    GreenModel result;
                    if (this.readOnly)
                    {
                        if (greenGroup.References.TryGetValue(this.id, out result)) return result;
                    }
                    else
                    {
                        if (greenGroup.Models.TryGetValue(this.id, out result)) return result;
                    }
                    return null;
                }
                else
                {
                    GreenModelUpdater updater = this.updater.Value;
                    if (updater != null) return updater.Model;
                    else return this.green;
                }
            }
        }
        internal GreenModelUpdater Updater
        {
            get
            {
                if (this.group != null) return this.group.Updater;
                else return this.updater.Value;
            }
        }
        public bool IsReadOnly { get { return this.readOnly; } }
        public MutableModelGroup ModelGroup { get { return this.group; } }
        public IEnumerable<MutableSymbol> Symbols
        {
            get
            {
                foreach (var sid in this.Green.StrongSymbols)
                {
                    yield return this.GetExistingSymbol(sid);
                }
            }
        }

        internal MutableSymbol GetExistingSymbol(SymbolId sid)
        {
            if (sid == null) return null;
            if (this.group != null)
            {
                if (this.readOnly) return this.group.GetExistingReferenceSymbol(this.id, sid);
                else return this.group.GetExistingModelSymbol(this.id, sid);
            }
            else
            {
                return this.symbols.GetValue(sid, key => key.CreateMutable(this, false));
            }
        }

        internal void RegisterSymbol(SymbolId sid, MutableSymbol symbol)
        {
            if (this.group != null)
            {
                this.group.RegisterSymbol(sid, symbol);
            }
            else
            {
                this.symbols.Add(sid, symbol);
            }
        }

        public MutableSymbol ResolveSymbol(SymbolId sid)
        {
            if (this.group != null)
            {
                return this.group.ResolveSymbol(sid);
            }
            else
            {
                if (!this.ContainsSymbol(sid)) return null;
                return this.GetExistingSymbol(sid);
            }
        }

        internal MutableSymbol GetSymbol(SymbolId sid)
        {
            if (sid == null) return null;
            if (!this.ContainsSymbol(sid)) return null;
            return this.GetExistingSymbol(sid);
        }

        public MutableSymbol GetSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(((MutableSymbolBase)symbol).MId);
        }

        public MutableSymbol GetSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(((ImmutableSymbolBase)symbol).MId);
        }

        internal bool ContainsSymbol(SymbolId sid)
        {
            if (sid == null) return false;
            GreenModelUpdater updater = this.Updater;
            if (updater != null)
            {
                return updater.ContainsSymbol(sid);
            }
            else
            {
                return this.Green.Symbols.ContainsKey(sid);
            }
        }

        public bool ContainsSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((MutableSymbolBase)symbol).MId);
        }

        public bool ContainsSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((ImmutableSymbolBase)symbol).MId);
        }

        public bool RemoveSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            bool result = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                result = ctx.Updater.RemoveSymbol(this.id, ((MutableSymbolBase)symbol).MId);
            } while (!this.EndUpdate(ctx));
            return result;
        }

        public void MergeSymbols(MutableSymbol targetSymbol, MutableSymbol partSymbol)
        {
            if (targetSymbol == partSymbol) return;
            if (targetSymbol.MMetaClass != partSymbol.MMetaClass) throw new ModelException(Location.None, new DiagnosticInfo(ModelErrorCode.ERR_CannotMergeDifferentSymbols, partSymbol, targetSymbol, partSymbol.MId.SymbolInfo.MutableType, targetSymbol.MId.SymbolInfo.MutableType));
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.MergeSymbols(this.id, ((ImmutableSymbolBase)targetSymbol).MId, ((ImmutableSymbolBase)partSymbol).MId);
            } while (!this.EndUpdate(ctx));
        }

        internal MutableSymbolBase CreateSymbol(SymbolId sid, bool weakReference)
        {
            Debug.Assert(sid != null);
            Debug.Assert(!this.ContainsSymbol(sid));
            MutableSymbolBase result = null;
            result = sid.CreateMutable(this, true);
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.AddSymbol(this.id, sid, weakReference);
            } while (!this.EndUpdate(ctx));
            this.RegisterSymbol(sid, result);
            return result;
        }

        public ImmutableModel ToImmutable()
        {
            ImmutableModel result;
            if (this.group != null)
            {
                ImmutableModelGroup immutableGroup = this.group.ToImmutable();
                if (immutableGroup != null)
                {
                    if (this.readOnly)
                    {
                        result = immutableGroup.GetReference(this.id);
                    }
                    else
                    {
                        result = immutableGroup.GetModel(this.id);
                    }
                    return result;
                }
            }
            else
            {
                GreenModel currentGreen = this.Green;
                if (this.immutableModel.TryGetTarget(out result) && result != null && result.Green == currentGreen)
                {
                    return result;
                }
                else
                {
                    result = new ImmutableModel(currentGreen, this);
                    Interlocked.Exchange(ref this.immutableModel, new WeakReference<ImmutableModel>(result));
                    return result;
                }
            }
            return null;
        }

        internal ModelUpdateContext BeginUpdate()
        {
            if (this.group != null)
            {
                return this.group.BeginUpdate();
            }
            else
            {
                GreenModelUpdater updater = this.updater.Value;
                if (updater != null)
                {
                    return new ModelUpdateContext(false, updater, this.green);
                }
                else
                {
                    GreenModel green = this.green;
                    updater = new GreenModelUpdater(green, this);
                    this.updater.Value = updater;
                    return new ModelUpdateContext(true, updater, green);
                }
            }
        }

        internal bool EndUpdate(ModelUpdateContext context)
        {
            if (this.group != null)
            {
                return this.group.EndUpdate(context);
            }
            else
            {
                if (context.NewUpdater)
                {
                    return Interlocked.CompareExchange(ref this.green, context.Updater.Model, context.OriginalModel) == context.OriginalModel;
                }
                else
                {
                    return true;
                }
            }
        }

        internal object ToGreenValue(object value)
        {
            if (value is ImmutableSymbolBase)
            {
                return ((ImmutableSymbolBase)value).MId;
            }
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).MId;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue();
                if (value is ImmutableSymbolBase)
                {
                    return this.ResolveSymbol(((ImmutableSymbolBase)value).MId);
                }
                else if (value is MutableSymbolBase)
                {
                    return this.ResolveSymbol(((MutableSymbolBase)value).MId);
                }
                return redValue;
            }
            else if (value is LazyValue)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is GreenList)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value == GreenSymbol.Unassigned)
            {
                return null;
            }
            else if (value is SymbolId)
            {
                return this.ResolveSymbol((SymbolId)value);
            }
            else
            {
                return value;
            }
        }

        public void EvaluateLazyValues(CancellationToken cancellationToken = default(CancellationToken))
        {
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.EvaluateLazyValues(cancellationToken);
            } while (!this.EndUpdate(ctx));
        }

        public void ExecuteTransaction(Action transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                transaction();
            } while (!this.EndUpdate(ctx));
        }

        internal object GetValue(SymbolId sid, ModelProperty property)
        {
            object value = null;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                value = ctx.Updater.GetValue(this.id, sid, property, true);
            } while (!this.EndUpdate(ctx));
            value = this.ToRedValue(value);
            return value;
        }

        private object GetGreenValue(SymbolId sid, ModelProperty property)
        {
            GreenSymbol greenSymbol;
            if (this.Green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                object greenValue;
                ModelPropertyInfo mpi = sid.SymbolInfo.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (greenSymbol.Properties.TryGetValue(property, out greenValue))
                {
                    return greenValue;
                }
            }
            return GreenSymbol.Unassigned;
        }

        internal bool MHasConcreteValue(SymbolId sid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return true;
            }
            else
            {
                var greenValue = this.GetGreenValue(sid, property);
                return greenValue != GreenSymbol.Unassigned && !(greenValue is LazyValue) && !(greenValue is GreenDerivedValue);
            }
        }

        internal bool MIsSet(SymbolId sid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return true;
            }
            else
            {
                var greenValue = this.GetGreenValue(sid, property);
                return greenValue != GreenSymbol.Unassigned;
            }
        }

        internal void SetValue<T>(SymbolId sid, ModelProperty property, T value, bool creating) 
        {
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.SetValue(this.id, sid, property, creating, this.ToGreenValue(value));
            } while (!this.EndUpdate(ctx));
        }

        internal object GetLazyValue(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            var greenValue = this.GetGreenValue(sid, property);
            if (greenValue is SingleLazyValue)
            {
                return ((SingleLazyValue)greenValue).Lazy;
            }
            else if (greenValue is MultipleLazyValues)
            {
                return ((MultipleLazyValues)greenValue).Lazy;
            }
            return null;
        }

        internal void SetLazyValue(SymbolId sid, ModelProperty property, LazyValue value, bool creating)
        {
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.SetValue(this.id, sid, property, creating, property.IsDerived ? (object)new GreenDerivedValue(value) : value);
            } while (!this.EndUpdate(ctx));
        }

        internal GreenList GetGreenList(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var greenValue = this.GetGreenValue(sid, property);
            if (greenValue is GreenList)
            {
                return (GreenList)greenValue;
            }
            return property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
        }

        internal GreenList GetGreenList(SymbolId sid, ModelProperty property, bool lazyEval)
        {
            Debug.Assert(property.IsCollection);
            object value = null;
            if (!lazyEval) return this.GetGreenList(sid, property);
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                value = ctx.Updater.GetValue(this.id, sid, property, true);
            } while (!this.EndUpdate(ctx));
            GreenList result = value as GreenList;
            if (result == null) result = property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
            return result;
        }

        internal MutableModelSet<T> GetSet<T>(MutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            return MutableModelSet<T>.FromGreenList(symbol, property);
        }

        internal MutableModelList<T> GetList<T>(MutableSymbolBase symbol, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            return MutableModelList<T>.FromGreenList(symbol, property);
        }

        internal bool AddItem(SymbolId sid, ModelProperty property, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, this.ToGreenValue(value));
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool AddLazyItem(SymbolId sid, ModelProperty property, LazyValue value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, value);
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool AddItems(SymbolId sid, ModelProperty property, IEnumerable<object> values, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                foreach (var value in values)
                {
                    changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, this.ToGreenValue(value));
                }
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool AddLazyItems(SymbolId sid, ModelProperty property, IEnumerable<LazyValue> values, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                foreach (var value in values)
                {
                    changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, value);
                }
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool AddLazyItems(SymbolId sid, ModelProperty property, LazyValue values, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, values);
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool RemoveItem(SymbolId sid, ModelProperty property, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.RemoveItem(this.id, sid, property, creating, -1, false, this.ToGreenValue(value));
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool RemoveAllItems(SymbolId sid, ModelProperty property, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.RemoveItem(this.id, sid, property, creating, -1, true, this.ToGreenValue(value));
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool InsertItem(SymbolId sid, ModelProperty property, int index, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, index, this.ToGreenValue(value));
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool ReplaceItem(SymbolId sid, ModelProperty property, int index, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.AddItem(this.id, sid, property, creating, true, index, this.ToGreenValue(value));
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool RemoveItemAt(SymbolId sid, ModelProperty property, int index, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.RemoveItem(this.id, sid, property, creating, index, false, null);
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool ClearItems(SymbolId sid, ModelProperty property, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.ClearItems(this.id, sid, property, creating);
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal bool ClearLazyItems(SymbolId sid, ModelProperty property, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.ClearLazyItems(this.id, sid, property, creating);
            } while (!this.EndUpdate(ctx));
            return changed;
        }

        internal MutableSymbol MParent(SymbolId sid)
        {
            GreenSymbol greenSymbol;
            if (this.Green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                return this.GetExistingSymbol(greenSymbol.Parent);
            }
            return null;
        }

        internal ImmutableModelList<MutableSymbol> MChildren(SymbolId sid)
        {
            ImmutableList<SymbolId> children = ImmutableList<SymbolId>.Empty;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                children = ctx.Updater.GetChildren(this.id, sid);
            } while (!this.EndUpdate(ctx));
            return ImmutableModelList<MutableSymbol>.FromSymbolIdList(children, this);
        }

        internal IReadOnlyList<MutableSymbol> MGetImports(MutableSymbolBase symbol)
        {
            List<MutableSymbol> result = new List<MutableSymbol>();
            foreach (var prop in symbol.MProperties)
            {
                if (prop.IsImport)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetList<MutableSymbol>(symbol, prop);
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                if (item != null && !result.Contains(item))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        var item = this.GetValue(symbol.MId, prop) as MutableSymbol;
                        if (item != null && !result.Contains(item))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        internal IReadOnlyList<MutableSymbol> MGetBases(MutableSymbolBase symbol)
        {
            List<MutableSymbol> result = new List<MutableSymbol>();
            this.CollectBases(symbol, result);
            result.Remove(symbol);
            return result;
        }

        internal IReadOnlyList<MutableSymbol> MGetAllBases(MutableSymbolBase symbol)
        {
            List<MutableSymbol> result = new List<MutableSymbol>();
            this.CollectAllBases(symbol, result);
            result.Remove(symbol);
            return result;
        }

        private void CollectBases(MutableSymbolBase symbol, List<MutableSymbol> result)
        {
            foreach (var prop in symbol.MProperties)
            {
                if (prop.IsImport)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetList<MutableSymbol>(symbol, prop);
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                if (item != null && !result.Contains(item))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        var item = this.GetValue(symbol.MId, prop) as MutableSymbol;
                        if (item != null && !result.Contains(item))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
        }

        private void CollectAllBases(MutableSymbolBase symbol, List<MutableSymbol> result)
        {
            if (symbol == null) return;

            if (!result.Contains(symbol))
            {
                result.Add(symbol);
                var bases = symbol.MGetBases();
                foreach (var item in bases)
                {
                    this.CollectAllBases(item as MutableSymbolBase, result);
                }
            }
        }

        internal IReadOnlyList<MutableSymbol> MGetMembers(MutableSymbolBase symbol)
        {
            List<MutableSymbol> result = new List<MutableSymbol>();
            foreach (var prop in symbol.MProperties)
            {
                if (prop.CanResolve)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetList<MutableSymbol>(symbol, prop);
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                if (item != null && !result.Contains(item))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        var item = this.GetValue(symbol.MId, prop) as MutableSymbol;
                        if (item != null && !result.Contains(item))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        internal ImmutableList<ModelProperty> MProperties(SymbolId sid)
        {
            ModelSymbolInfo msi = sid.SymbolInfo;
            if (msi != null)
            {
                return msi.Properties;
            }
            return ImmutableList<ModelProperty>.Empty;
        }

        internal ImmutableList<ModelProperty> MAllProperties(SymbolId sid)
        {
            GreenSymbol greenSymbol;
            if (this.Green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                return greenSymbol.Properties.Keys.ToImmutableList();
            }
            return ImmutableList<ModelProperty>.Empty;
        }

        internal object MGet(MutableSymbolBase symbol, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return this.GetList<object>(symbol, property);
            }
            else
            {
                return this.GetValue(symbol.MId, property);
            }
        }
        internal void MAttachProperty(SymbolId sid, ModelProperty property)
        {
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.AttachProperty(this.id, sid, property);
            } while (!this.EndUpdate(ctx));
        }

        public override string ToString()
        {
            return this.Green.ToString();
        }
    }


    public sealed class ImmutableModelGroup 
    {
        private GreenModelGroup green;
        private WeakReference<MutableModelGroup> mutableModelGroup;
        private ConditionalWeakTable<ModelId, ImmutableModel> models;
        private ConditionalWeakTable<SymbolId, ImmutableSymbolBase> symbols;

        internal ImmutableModelGroup(GreenModelGroup green, MutableModelGroup mutableModelGroup)
        {
            this.green = green;
            this.mutableModelGroup = new WeakReference<MutableModelGroup>(mutableModelGroup);
            this.models = new ConditionalWeakTable<ModelId, ImmutableModel>();
            this.symbols = new ConditionalWeakTable<SymbolId, ImmutableSymbolBase>();
        }

        internal GreenModelGroup Green { get { return this.green; } }

        public IEnumerable<ImmutableModel> References
        {
            get
            {
                foreach (var mid in this.Green.References.Keys)
                {
                    yield return this.GetExistingReference(mid);
                }
            }
        }
        public IEnumerable<ImmutableModel> Models
        {
            get
            {
                foreach (var mid in this.Green.Models.Keys)
                {
                    yield return this.GetExistingModel(mid);
                }
            }
        }

        private MutableModel GetMutableReference(ModelId mid)
        {
            MutableModelGroup result;
            if (this.mutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result.GetReference(mid);
            }
            return null;
        }

        private MutableModel GetMutableModel(ModelId mid)
        {
            MutableModelGroup result;
            if (this.mutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result.GetModel(mid);
            }
            return null;
        }

        private ImmutableModel GetExistingReference(ModelId mid)
        {
            return this.models.GetValue(mid, key => new ImmutableModel(key, this, this.Green.References.GetValueOrDefault(key), true, this.GetMutableReference(key)));
        }

        private ImmutableModel GetExistingModel(ModelId mid)
        {
            return this.models.GetValue(mid, key => new ImmutableModel(key, this, this.Green.Models.GetValueOrDefault(key), false, this.GetMutableReference(key)));
        }

        public ImmutableModel GetReference(ModelId mid)
        {
            if (mid == null || !this.Green.References.ContainsKey(mid)) return null;
            return this.GetExistingReference(mid);
        }

        public ImmutableModel GetModel(ModelId mid)
        {
            if (mid == null || !this.Green.Models.ContainsKey(mid)) return null;
            return this.GetExistingModel(mid);
        }


        internal ImmutableSymbolBase GetExistingReferenceSymbol(ModelId mid, SymbolId sid)
        {
            return this.symbols.GetValue(sid, key => key.CreateImmutable(this.GetExistingReference(mid)));
        }

        internal ImmutableSymbolBase GetExistingModelSymbol(ModelId mid, SymbolId sid)
        {
            return this.symbols.GetValue(sid, key => key.CreateImmutable(this.GetExistingModel(mid)));
        }

        internal ImmutableSymbolBase ResolveSymbol(SymbolId sid)
        {
            ImmutableSymbolBase result;
            if (this.symbols.TryGetValue(sid, out result) && result != null)
            {
                return result;
            }
            foreach (var modelEntry in this.Green.Models)
            {
                if (modelEntry.Value.Symbols.ContainsKey(sid))
                {
                    return this.GetExistingModelSymbol(modelEntry.Key, sid);
                }
            }
            foreach (var modelEntry in this.Green.References)
            {
                if (modelEntry.Value.Symbols.ContainsKey(sid))
                {
                    return this.GetExistingReferenceSymbol(modelEntry.Key, sid);
                }
            }
            return null;
        }

        internal bool ContainsSymbol(SymbolId sid)
        {
            if (sid == null) return false;
            return this.Green.ContainsSymbol(sid);
        }

        public bool ContainsSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((ImmutableSymbolBase)symbol).MId);
        }

        public bool ContainsSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((MutableSymbolBase)symbol).MId);
        }

        public MutableModelGroup ToMutable(bool createNew = false)
        {
            MutableModelGroup result;
            if (!createNew)
            {
                if (this.mutableModelGroup.TryGetTarget(out result) && result != null)
                {
                    return result;
                }
            }
            return new MutableModelGroup(this.green, this);
        }
    }

    public sealed class MutableModelGroup 
    {
        private GreenModelGroup green;
        private ThreadLocal<GreenModelUpdater> updater;
        private WeakReference<ImmutableModelGroup> immutableModelGroup;
        private ConditionalWeakTable<ModelId, MutableModel> models;
        private ConditionalWeakTable<SymbolId, MutableSymbol> symbols;

        public MutableModelGroup()
            : this(GreenModelGroup.Empty, null)
        {
        }

        internal MutableModelGroup(GreenModelGroup green, ImmutableModelGroup immutableModelGroup)
        {
            this.green = green;
            this.updater = new ThreadLocal<GreenModelUpdater>();
            this.immutableModelGroup = new WeakReference<ImmutableModelGroup>(immutableModelGroup);
            this.models = new ConditionalWeakTable<ModelId, MutableModel>();
            this.symbols = new ConditionalWeakTable<SymbolId, MutableSymbol>();
        }

        internal GreenModelGroup Green
        {
            get
            {
                GreenModelUpdater updater = this.updater.Value;
                if (updater != null) return updater.Group;
                else return this.green;
            }
        }
        internal GreenModelUpdater Updater
        {
            get
            {
                return this.updater.Value;
            }
        }
        public IEnumerable<MutableModel> References
        {
            get
            {
                foreach (var mid in this.Green.References.Keys)
                {
                    yield return this.GetExistingReference(mid);
                }
            }
        }
        public IEnumerable<MutableModel> Models
        {
            get
            {
                foreach (var mid in this.Green.Models.Keys)
                {
                    yield return this.GetExistingModel(mid);
                }
            }
        }

        private ImmutableModel GetImmutableReference(ModelId mid)
        {
            ImmutableModelGroup result;
            if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result.GetReference(mid);
            }
            return null;
        }

        private ImmutableModel GetImmutableModel(ModelId mid)
        {
            ImmutableModelGroup result;
            if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result.GetModel(mid);
            }
            return null;
        }

        private MutableModel GetExistingReference(ModelId mid)
        {
            return this.models.GetValue(mid, key => new MutableModel(key, this, true, null));
        }

        private MutableModel GetExistingModel(ModelId mid)
        {
            return this.models.GetValue(mid, key => new MutableModel(key, this, false, null));
        }

        public MutableModel GetReference(ModelId mid)
        {
            if (mid == null || !this.Green.References.ContainsKey(mid)) return null;
            return this.GetExistingReference(mid);
        }

        public MutableModel GetModel(ModelId mid)
        {
            if (mid == null || !this.Green.Models.ContainsKey(mid)) return null;
            return this.GetExistingModel(mid);
        }


        internal MutableSymbol GetExistingReferenceSymbol(ModelId mid, SymbolId sid)
        {
            return this.symbols.GetValue(sid, key => key.CreateMutable(this.GetExistingReference(mid), false));
        }

        internal MutableSymbol GetExistingModelSymbol(ModelId mid, SymbolId sid)
        {
            return this.symbols.GetValue(sid, key => key.CreateMutable(this.GetExistingModel(mid), false));
        }

        internal void RegisterSymbol(SymbolId sid, MutableSymbol symbol)
        {
            this.symbols.Add(sid, symbol);
        }

        internal MutableSymbol ResolveSymbol(SymbolId sid)
        {
            MutableSymbol result;
            if (this.symbols.TryGetValue(sid, out result) && result != null)
            {
                return result;
            }
            foreach (var modelEntry in this.Green.Models)
            {
                if (modelEntry.Value.Symbols.ContainsKey(sid))
                {
                    return this.GetExistingModelSymbol(modelEntry.Key, sid);
                }
            }
            foreach (var modelEntry in this.Green.References)
            {
                if (modelEntry.Value.Symbols.ContainsKey(sid))
                {
                    return this.GetExistingReferenceSymbol(modelEntry.Key, sid);
                }
            }
            return null;
        }

        internal bool ContainsSymbol(SymbolId sid)
        {
            if (sid == null) return false;
            return this.Green.ContainsSymbol(sid);
        }

        public bool ContainsSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((ImmutableSymbolBase)symbol).MId);
        }

        public bool ContainsSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((MutableSymbolBase)symbol).MId);
        }

        public ImmutableModelGroup ToImmutable()
        {
            ImmutableModelGroup result;
            if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result;
            }
            else
            {
                result = new ImmutableModelGroup(this.Green, this);
                Interlocked.Exchange(ref this.immutableModelGroup, new WeakReference<ImmutableModelGroup>(result));
                return result;
            }
        }

        internal ModelUpdateContext BeginUpdate()
        {
            GreenModelUpdater updater = this.updater.Value;
            if (updater != null)
            {
                return new ModelUpdateContext(false, updater, this.green);
            }
            else
            {
                GreenModelGroup green = this.green;
                updater = new GreenModelUpdater(green, this);
                this.updater.Value = updater;
                return new ModelUpdateContext(true, updater, green);
            }
        }

        internal bool EndUpdate(ModelUpdateContext context)
        {
            if (context.NewUpdater)
            {
                return Interlocked.CompareExchange(ref this.green, context.Updater.Group, context.OriginalModelGroup) == context.OriginalModelGroup;
            }
            else
            {
                return true;
            }
        }

        private void AddReference(GreenModel reference)
        {
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.AddModelReference(reference);
            } while (!this.EndUpdate(ctx));
        }

        public void AddReference(ImmutableModel reference)
        {
            if (reference.ModelGroup != null)
            {
                GreenModelGroup gmg = reference.ModelGroup.Green;
                foreach (var greenReference in gmg.References)
                {
                    this.AddReference(greenReference.Value);
                }
                foreach (var greenModel in gmg.Models)
                {
                    this.AddReference(greenModel.Value);
                }
            }
            else
            {
                this.AddReference(reference.Green);
            }
        }

        public void AddReference(MutableModel reference)
        {
            if (reference.ModelGroup != null)
            {
                GreenModelGroup gmg = reference.ModelGroup.Green;
                foreach (var greenReference in gmg.References)
                {
                    this.AddReference(greenReference.Value);
                }
                foreach (var greenModel in gmg.Models)
                {
                    this.AddReference(greenModel.Value);
                }
            }
            else
            {
                this.AddReference(reference.Green);
            }
        }

        public void AddModel(ImmutableModel model)
        {
            // TODO
            throw new NotImplementedException();
        }

        public void AddModel(MutableModel model)
        {
            // TODO
            throw new NotImplementedException();
        }

        public MutableModel CreateModel(string name = null, ModelVersion version = null)
        {
            ModelId mid = new ModelId();
            MutableModel model = new MutableModel(mid, this, false, null);
            this.models.Add(mid, model);
            GreenModel greenModel;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                greenModel = ctx.Updater.CreateModel(mid, name, version);
            } while (!this.EndUpdate(ctx));
            return model;
        }

        public void ExecuteTransaction(Action transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                transaction();
            } while (!this.EndUpdate(ctx));
        }
    }

    [Flags]
    public enum ModelFactoryFlags
    {
        None = 0x00,
        DontMakeSymbolsCreated = 0x01,
        CreateWeakSymbols = 0x02,
        CreateStrongSymbols = 0x04
    }

    public abstract class ModelFactory
    {
        private MutableModel model;
        private ModelFactoryFlags flags;

        public ModelFactory(MutableModel model, ModelFactoryFlags flags)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            this.model = model;
            this.flags = flags;
        }

        public MutableModel Model { get { return this.model; } }

        protected MutableSymbol CreateSymbol(SymbolId id)
        {
            MutableSymbolBase symbol = this.model.CreateSymbol(id, this.flags.HasFlag(ModelFactoryFlags.CreateWeakSymbols));
            symbol.MCallInit();
            if (!this.flags.HasFlag(ModelFactoryFlags.DontMakeSymbolsCreated)) symbol.MMakeCreated();
            return symbol;
        }

        public MutableSymbol Create(Type type)
        {
            // TODO: instantiate any type from any model
            return this.Create(type.Name);
        }
        public abstract MutableSymbol Create(string type);
    }

    public class PropertyInit
    {
        public ModelProperty Property { get; private set; }
        public Func<object> Value { get; private set; }
        public IEnumerable<Func<object>> Values { get; private set; }

        public PropertyInit(ModelProperty property, Func<object> value)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (value == null) throw new ArgumentNullException(nameof(value));
            this.Property = property;
            this.Value = value;
        }
        public PropertyInit(ModelProperty property, IEnumerable<Func<object>> values)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (!property.IsCollection) throw new ArgumentException("Property '" + property + "' must be a collection.", nameof(property));
            this.Property = property;
            this.Values = values;
        }
    }
}
