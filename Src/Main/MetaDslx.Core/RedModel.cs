using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public interface ImmutableSymbol
    {
        MetaModel MMetaModel { get; }
        MetaClass MMetaClass { get; }

        ImmutableModel MModel { get; }
        ImmutableSymbol MParent { get; }
        ImmutableModelList<ImmutableSymbol> MChildren { get; }

        ImmutableList<ModelProperty> MProperties { get; }
        ImmutableList<ModelProperty> MAllProperties { get; }
        object MGet(ModelProperty property);

        MutableSymbol ToMutable();
        MutableSymbol ToMutable(MutableModel mutableModel);
    }

    public interface MutableSymbol
    {
        MetaModel MMetaModel { get; }
        MetaClass MMetaClass { get; }

        bool MIsReadOnly { get; }
        MutableModel MModel { get; }
        MutableSymbol MParent { get; }
        ImmutableModelList<MutableSymbol> MChildren { get; }

        ImmutableSymbol ToImmutable();
        ImmutableSymbol ToImmutable(ImmutableModel immutableModel);
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

        internal SymbolId Id { get { return this.id; } }

        public abstract MetaModel MMetaModel { get; }
        public abstract MetaClass MMetaClass { get; }

        public ImmutableModel MModel { get { return this.model; } }
        public ImmutableSymbol MParent { get { return this.model.MParent(this.id); } }
        public ImmutableModelList<ImmutableSymbol> MChildren { get { return this.model.MChildren(this.id); } }

        public ImmutableList<ModelProperty> MProperties { get { return this.model.MProperties(this.id); } }
        public ImmutableList<ModelProperty> MAllProperties { get { return this.model.MAllProperties(this.id); } }
        public object MGet(ModelProperty property)
        {
            return this.model.MGet(this.id, property);
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

        internal SymbolId Id { get { return this.id; } }
        internal bool MIsBeingCreated { get { return this.creating; } }
        public bool MIsReadOnly { get { return this.model.IsReadOnly; } }

        public abstract MetaModel MMetaModel { get; }
        public abstract MetaClass MMetaClass { get; }

        public MutableModel MModel { get { return this.model; } }
        public MutableSymbol MParent { get { return this.model.MParent(this.id); } }
        public ImmutableModelList<MutableSymbol> MChildren { get { return this.model.MChildren(this.id); } }

        internal protected virtual void MInit()
        {
        }

        public void MMakeCreated()
        {
            this.creating = false;
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
            this.model.SetLazyValue(this.id, property, (Func<object>)(object)value, this.creating);
        }

        protected Func<T> GetLazyReference<T>(ModelProperty property)
            where T : class
        {
            return (Func<T>)this.model.GetLazyValue(this.id, property);
        }

        protected void SetLazyReference<T>(ModelProperty property, Func<T> value)
            where T : class
        {
            this.model.SetLazyValue(this.id, property, value, this.creating);
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
    }


    public sealed class ImmutableModel 
    {
        private bool readOnly;
        private WeakReference<MutableModel> mutableModel;

        // Used in models contained by a group:
        private ModelId id;
        private ImmutableModelGroup group;

        // Used in standalone models:
        private GreenModel green;
        private ConditionalWeakTable<SymbolId, ImmutableSymbolBase> symbols;

        internal ImmutableModel(ModelId id, ImmutableModelGroup group, bool readOnly, MutableModel mutableModel)
        {
            this.id = id;
            this.group = group;
            this.green = null;
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
            this.symbols = new ConditionalWeakTable<SymbolId, ImmutableSymbolBase>();
            this.mutableModel = new WeakReference<MutableModel>(mutableModel);
        }

        internal ModelId Id { get { return this.green.Id; } }
        internal GreenModel Green { get { return this.green; } }
        public ImmutableModelGroup ModelGroup { get { return this.group; } }
        public IEnumerable<ImmutableSymbolBase> Symbols
        {
            get
            {
                foreach (var sid in this.Green.StrongSymbols)
                {
                    yield return this.GetExistingSymbol(sid);
                }
            }
        }

        internal ImmutableSymbolBase GetExistingSymbol(SymbolId sid)
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

        internal ImmutableSymbolBase ResolveSymbol(SymbolId sid)
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

        internal ImmutableSymbolBase GetSymbol(SymbolId sid)
        {
            if (sid == null) return null;
            if (!this.ContainsSymbol(sid)) return null;
            return this.GetExistingSymbol(sid);
        }

        public ImmutableSymbol GetSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(((MutableSymbolBase)symbol).Id);
        }

        public ImmutableSymbol GetSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(((ImmutableSymbolBase)symbol).Id);
        }

        internal bool ContainsSymbol(SymbolId sid)
        {
            if (sid == null) return false;
            return this.Green.Symbols.ContainsKey(sid);
        }

        public bool ContainsSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((MutableSymbolBase)symbol).Id);
        }

        public bool ContainsSymbol(ImmutableSymbolBase symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(((ImmutableSymbolBase)symbol).Id);
        }

        public MutableModel ToMutable(bool createNew = false)
        {
            MutableModel result = null;
            if (!createNew)
            {
                lock (this.mutableModel)
                {
                    if (this.mutableModel.TryGetTarget(out result) && result != null)
                    {
                        return result;
                    }
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
            if (newModel != null)
            {
                if (!createNew)
                {
                    lock (this.mutableModel)
                    {
                        MutableModel oldModel;
                        if (this.mutableModel.TryGetTarget(out oldModel) && oldModel != null)
                        {
                            return oldModel;
                        }
                        else
                        {
                            this.mutableModel.SetTarget(newModel);
                        }
                    }
                }
            }
            return newModel;
        }

        internal object ToGreenValue(object value)
        {
            if (value is ImmutableSymbolBase)
            {
                return ((ImmutableSymbolBase)value).Id;
            }
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).Id;
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
                    return this.ResolveSymbol(((ImmutableSymbolBase)value).Id);
                }
                else if (value is MutableSymbolBase)
                {
                    return this.ResolveSymbol(((MutableSymbolBase)value).Id);
                }
                return redValue;
            }
            else if (value is GreenLazyValue)
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

        internal object GetValue(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            GreenSymbol greenSymbol;
            if (this.green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                object greenValue;
                ModelPropertyInfo mpi = sid.ModelSymbolInfo.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (greenSymbol.Properties.TryGetValue(property, out greenValue))
                {
                    return this.ToRedValue(greenValue);
                }
            }
            return null;
        }

        internal ImmutableModelSet<T> GetSet<T>(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            GreenSymbol greenSymbol;
            if (this.green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                object greenValue;
                ModelPropertyInfo mpi = sid.ModelSymbolInfo.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (greenSymbol.Properties.TryGetValue(property, out greenValue) && greenValue is GreenList)
                {
                    return ImmutableModelSet<T>.FromGreenList((GreenList)greenValue, this);
                }
            }
            return ImmutableModelSet<T>.FromGreenList(property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique, this);
        }

        internal ImmutableModelList<T> GetList<T>(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            GreenSymbol greenSymbol;
            if (this.green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                object greenValue;
                ModelPropertyInfo mpi = sid.ModelSymbolInfo.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (greenSymbol.Properties.TryGetValue(property, out greenValue) && greenValue is GreenList)
                {
                    return ImmutableModelList<T>.FromGreenList((GreenList)greenValue, this);
                }
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

        internal ImmutableList<ModelProperty> MProperties(SymbolId sid)
        {
            ModelSymbolInfo msi = sid.ModelSymbolInfo;
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


    public sealed class MutableModel 
    {
        private bool readOnly;
        private WeakReference<ImmutableModel> immutableModel;

        // Used in models contained by a group:
        private ModelId id;
        private MutableModelGroup group;

        // Used in standalone models:
        private GreenModel green;
        private ConditionalWeakTable<SymbolId, MutableSymbolBase> symbols;
        private ThreadLocal<GreenModelUpdater> updater;

        public MutableModel()
            : this(new GreenModel(new ModelId()), null)
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
            this.symbols = new ConditionalWeakTable<SymbolId, MutableSymbolBase>();
            this.immutableModel = new WeakReference<ImmutableModel>(immutableModel);
        }

        internal ModelId Id { get { return this.id; } }
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
        public IEnumerable<MutableSymbolBase> Symbols
        {
            get
            {
                foreach (var sid in this.Green.StrongSymbols)
                {
                    yield return this.GetExistingSymbol(sid);
                }
            }
        }

        internal MutableSymbolBase GetExistingSymbol(SymbolId sid)
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

        internal void RegisterSymbol(SymbolId sid, MutableSymbolBase symbol)
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

        internal MutableSymbolBase ResolveSymbol(SymbolId sid)
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

        internal MutableSymbolBase GetSymbol(SymbolId sid)
        {
            if (sid == null) return null;
            if (!this.ContainsSymbol(sid)) return null;
            return this.GetExistingSymbol(sid);
        }

        public MutableSymbolBase GetSymbol(MutableSymbolBase symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(symbol.Id);
        }

        public MutableSymbolBase GetSymbol(ImmutableSymbolBase symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(symbol.Id);
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

        public bool ContainsSymbol(MutableSymbolBase symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        public bool ContainsSymbol(ImmutableSymbolBase symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        internal MutableSymbolBase CreateSymbol(SymbolId sid, bool weakReference)
        {
            Debug.Assert(sid != null);
            Debug.Assert(!this.ContainsSymbol(sid));
            MutableSymbolBase result = sid.CreateMutable(this, true);
            this.RegisterSymbol(sid, result);
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.AddSymbol(this.id, sid, weakReference);
            } while (!this.EndUpdate(ctx));
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
                        result = immutableGroup.GetReference(this.green.Id);
                    }
                    else
                    {
                        result = immutableGroup.GetModel(this.green.Id);
                    }
                    return result;
                }
            }
            else
            {
                GreenModel currentGreen = this.Green;
                lock (this.immutableModel)
                {
                    if (this.immutableModel.TryGetTarget(out result) && result != null && result.Green == currentGreen)
                    {
                        return result;
                    }
                    else
                    {
                        result = new ImmutableModel(currentGreen, this);
                        this.immutableModel.SetTarget(result);
                        return result;
                    }
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
                    updater = new GreenModelUpdater(green);
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
                return ((ImmutableSymbolBase)value).Id;
            }
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).Id;
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
                    return this.ResolveSymbol(((ImmutableSymbolBase)value).Id);
                }
                else if (value is MutableSymbolBase)
                {
                    return this.ResolveSymbol(((MutableSymbolBase)value).Id);
                }
                return redValue;
            }
            else if (value is GreenLazyValue)
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

        public void EvaluateLazyValues()
        {
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.EvaluateLazyValues();
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
            object value;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                value = ctx.Updater.GetValue(this.id, sid, property, true);
            } while (!this.EndUpdate(ctx));
            return this.ToRedValue(value);
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
            GreenSymbol greenSymbol;
            if (this.Green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                object greenValue;
                ModelPropertyInfo mpi = sid.ModelSymbolInfo.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (greenSymbol.Properties.TryGetValue(property, out greenValue) && greenValue is GreenLazyValue)
                {
                    return ((GreenLazyValue)greenValue).Lazy;
                }
            }
            return null;
        }

        internal void SetLazyValue(SymbolId sid, ModelProperty property, Func<object> value, bool creating)
        {
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                ctx.Updater.SetValue(this.id, sid, property, creating, property.IsDerived ? (object)new GreenDerivedValue(value) : (object)new GreenLazyValue(value));
            } while (!this.EndUpdate(ctx));
        }

        internal GreenList GetGreenList(SymbolId sid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            GreenSymbol greenSymbol;
            if (this.Green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                object greenValue;
                ModelPropertyInfo mpi = sid.ModelSymbolInfo.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (greenSymbol.Properties.TryGetValue(property, out greenValue) && greenValue is GreenList)
                {
                    return (GreenList)greenValue;
                }
            }
            return property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
        }

        internal GreenList GetGreenList(SymbolId sid, ModelProperty property, bool lazyEval)
        {
            Debug.Assert(property.IsCollection);
            if (!lazyEval) return this.GetGreenList(sid, property);
            object value;
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

        internal bool AddLazyItem(SymbolId sid, ModelProperty property, Func<object> value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, new GreenLazyValue(value));
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
            GreenSymbol greenSymbol;
            if (this.Green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                return ImmutableModelList<MutableSymbol>.FromSymbolIdList(greenSymbol.Children, this);
            }
            return null;
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
            lock (this.mutableModelGroup)
            {
                MutableModelGroup result;
                if (this.mutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
                {
                    return result.GetReference(mid);
                }
                return null;
            }
        }

        private MutableModel GetMutableModel(ModelId mid)
        {
            lock (this.mutableModelGroup)
            {
                MutableModelGroup result;
                if (this.mutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
                {
                    return result.GetModel(mid);
                }
                return null;
            }
        }

        private ImmutableModel GetExistingReference(ModelId mid)
        {
            return this.models.GetValue(mid, key => new ImmutableModel(key, this, true, this.GetMutableReference(key)));
        }

        private ImmutableModel GetExistingModel(ModelId mid)
        {
            return this.models.GetValue(mid, key => new ImmutableModel(key, this, false, this.GetMutableReference(key)));
        }

        internal ImmutableModel GetReference(ModelId mid)
        {
            if (mid == null || !this.Green.References.ContainsKey(mid)) return null;
            return this.GetExistingReference(mid);
        }

        internal ImmutableModel GetModel(ModelId mid)
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

        public bool ContainsSymbol(ImmutableSymbolBase symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        public bool ContainsSymbol(MutableSymbolBase symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        public MutableModelGroup ToMutable(bool createNew = false)
        {
            MutableModelGroup result;
            if (!createNew)
            {
                lock (this.mutableModelGroup)
                {
                    if (this.mutableModelGroup.TryGetTarget(out result) && result != null)
                    {
                        return result;
                    }
                }
            }
            result = new MutableModelGroup(this.green, this);
            if (!createNew)
            {
                lock (this.mutableModelGroup)
                {
                    MutableModelGroup oldGroup = null;
                    if (this.mutableModelGroup.TryGetTarget(out oldGroup) && oldGroup != null)
                    {
                        return oldGroup;
                    }
                    else
                    {
                        this.mutableModelGroup.SetTarget(result);
                        return result;
                    }
                }
            }
            return result;
        }
    }

    public sealed class MutableModelGroup 
    {
        private GreenModelGroup green;
        private ThreadLocal<GreenModelUpdater> updater;
        private WeakReference<ImmutableModelGroup> immutableModelGroup;
        private ConditionalWeakTable<ModelId, MutableModel> models;
        private ConditionalWeakTable<SymbolId, MutableSymbolBase> symbols;

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
            this.symbols = new ConditionalWeakTable<SymbolId, MutableSymbolBase>();
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
            lock (this.immutableModelGroup)
            {
                ImmutableModelGroup result;
                if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
                {
                    return result.GetReference(mid);
                }
                return null;
            }
        }

        private ImmutableModel GetImmutableModel(ModelId mid)
        {
            lock (this.immutableModelGroup)
            {
                ImmutableModelGroup result;
                if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
                {
                    return result.GetModel(mid);
                }
                return null;
            }
        }

        private MutableModel GetExistingReference(ModelId mid)
        {
            return this.models.GetValue(mid, key => new MutableModel(key, this, true, this.GetImmutableReference(key)));
        }

        private MutableModel GetExistingModel(ModelId mid)
        {
            return this.models.GetValue(mid, key => new MutableModel(key, this, false, this.GetImmutableReference(key)));
        }

        internal MutableModel GetReference(ModelId mid)
        {
            if (mid == null || !this.Green.References.ContainsKey(mid)) return null;
            return this.GetExistingReference(mid);
        }

        internal MutableModel GetModel(ModelId mid)
        {
            if (mid == null || !this.Green.Models.ContainsKey(mid)) return null;
            return this.GetExistingModel(mid);
        }


        internal MutableSymbolBase GetExistingReferenceSymbol(ModelId mid, SymbolId sid)
        {
            return this.symbols.GetValue(sid, key => key.CreateMutable(this.GetExistingReference(mid), false));
        }

        internal MutableSymbolBase GetExistingModelSymbol(ModelId mid, SymbolId sid)
        {
            return this.symbols.GetValue(sid, key => key.CreateMutable(this.GetExistingModel(mid), false));
        }

        internal void RegisterSymbol(SymbolId sid, MutableSymbolBase symbol)
        {
            this.symbols.Add(sid, symbol);
        }

        internal MutableSymbolBase ResolveSymbol(SymbolId sid)
        {
            MutableSymbolBase result;
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

        public bool ContainsSymbol(ImmutableSymbolBase symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        public bool ContainsSymbol(MutableSymbolBase symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        public ImmutableModelGroup ToImmutable()
        {
            lock (this.immutableModelGroup)
            {
                ImmutableModelGroup result;
                if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
                {
                    return result;
                }
                result = new ImmutableModelGroup(this.Green, this);
                this.immutableModelGroup.SetTarget(result);
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
                updater = new GreenModelUpdater(green);
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
                throw new NotImplementedException("Referencing a model contained by a group not yet supported.");
            }
            this.AddReference(reference.Green);
        }

        public void AddReference(MutableModel reference)
        {
            if (reference.ModelGroup != null)
            {
                throw new NotImplementedException("Referencing a model contained by a group not yet supported.");
            }
            this.AddReference(reference.Green);
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

        public MutableModel CreateModel()
        {
            ModelId mid = new ModelId();
            MutableModel model = new MutableModel(mid, this, false, null);
            this.models.Add(mid, model);
            GreenModel greenModel;
            ModelUpdateContext ctx;
            do
            {
                ctx = this.BeginUpdate();
                greenModel = ctx.Updater.CreateModel(mid);
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

        protected MutableSymbolBase CreateSymbol(SymbolId id)
        {
            MutableSymbolBase symbol = this.model.CreateSymbol(id, this.flags.HasFlag(ModelFactoryFlags.CreateWeakSymbols));
            symbol.MInit();
            if (!this.flags.HasFlag(ModelFactoryFlags.DontMakeSymbolsCreated)) symbol.MMakeCreated();
            return symbol;
        }

        public abstract MutableSymbolBase Create(string type);
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
