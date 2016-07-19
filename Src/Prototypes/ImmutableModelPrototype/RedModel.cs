using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImmutableModelPrototype
{
    public abstract class ImmutableSymbol 
    {
        private SymbolId id;
        private ImmutableModel model;

        protected ImmutableSymbol(SymbolId id, ImmutableModel model)
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

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        public ImmutableModel MModel { get { return this.model; } }
        public ImmutableSymbol MParent { get; }
        public IReadOnlyList<ImmutableSymbol> MChildren { get; }

    }

    public abstract class MutableSymbol
    {
        private bool creating;
        private SymbolId id;
        private MutableModel model;

        protected MutableSymbol(SymbolId id, MutableModel model, bool creating)
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

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        public MutableModel MModel { get { return this.model; } }
        public MutableSymbol MParent { get; }
        public IReadOnlyList<MutableSymbol> MChildren { get; }

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
        private ConditionalWeakTable<SymbolId, ImmutableSymbol> symbols;

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
            this.symbols = new ConditionalWeakTable<SymbolId, ImmutableSymbol>();
            this.mutableModel = new WeakReference<MutableModel>(mutableModel);
        }

        internal ModelId Id { get { return this.green.Id; } }
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
            return this.GetSymbol(symbol.Id);
        }

        public ImmutableSymbol GetSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return null;
            return this.GetSymbol(symbol.Id);
        }

        internal bool ContainsSymbol(SymbolId sid)
        {
            if (sid == null) return false;
            return this.Green.Symbols.ContainsKey(sid);
        }

        public bool ContainsSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        public bool ContainsSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
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
            if (value is ImmutableSymbol)
            {
                return ((ImmutableSymbol)value).Id;
            }
            if (value is MutableSymbol)
            {
                return ((MutableSymbol)value).Id;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue();
                if (value is ImmutableSymbol)
                {
                    return this.ResolveSymbol(((ImmutableSymbol)value).Id);
                }
                else if (value is MutableSymbol)
                {
                    return this.ResolveSymbol(((MutableSymbol)value).Id);
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
            else if (value is SymbolId)
            {
                return this.ResolveSymbol((SymbolId)value);
            }
            else
            {
                return value;
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
        private ConditionalWeakTable<SymbolId, MutableSymbol> symbols;
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
            this.symbols = new ConditionalWeakTable<SymbolId, MutableSymbol>();
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

        internal MutableSymbol ResolveSymbol(SymbolId sid)
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
            return this.GetSymbol(symbol.Id);
        }

        public MutableSymbol GetSymbol(ImmutableSymbol symbol)
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

        public bool ContainsSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        public bool ContainsSymbol(ImmutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        internal MutableSymbol CreateSymbol(SymbolId sid, bool weakReference)
        {
            Debug.Assert(sid != null);
            Debug.Assert(!this.ContainsSymbol(sid));
            MutableSymbol result = sid.CreateMutable(this, true);
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
            if (value is ImmutableSymbol)
            {
                return ((ImmutableSymbol)value).Id;
            }
            if (value is MutableSymbol)
            {
                return ((MutableSymbol)value).Id;
            }
            return value;
        }

        internal object ToRedValue(object value)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue();
                if (value is ImmutableSymbol)
                {
                    return this.ResolveSymbol(((ImmutableSymbol)value).Id);
                }
                else if (value is MutableSymbol)
                {
                    return this.ResolveSymbol(((MutableSymbol)value).Id);
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
    }


    public sealed class ImmutableModelGroup 
    {
        private GreenModelGroup green;
        private WeakReference<MutableModelGroup> mutableGroup;
        private ConditionalWeakTable<ModelId, ImmutableModel> models;
        private ConditionalWeakTable<SymbolId, ImmutableSymbol> symbols;

        internal ImmutableModelGroup(GreenModelGroup green, MutableModelGroup mutableGroup)
        {
            this.green = green;
            this.mutableGroup = new WeakReference<MutableModelGroup>(mutableGroup);
            this.models = new ConditionalWeakTable<ModelId, ImmutableModel>();
            this.symbols = new ConditionalWeakTable<SymbolId, ImmutableSymbol>();
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
            lock (this.mutableGroup)
            {
                MutableModelGroup result;
                if (this.mutableGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
                {
                    return result.GetReference(mid);
                }
                return null;
            }
        }

        private MutableModel GetMutableModel(ModelId mid)
        {
            lock (this.mutableGroup)
            {
                MutableModelGroup result;
                if (this.mutableGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
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


        internal ImmutableSymbol GetExistingReferenceSymbol(ModelId mid, SymbolId sid)
        {
            return this.symbols.GetValue(sid, key => key.CreateImmutable(this.GetExistingReference(mid)));
        }

        internal ImmutableSymbol GetExistingModelSymbol(ModelId mid, SymbolId sid)
        {
            return this.symbols.GetValue(sid, key => key.CreateImmutable(this.GetExistingModel(mid)));
        }

        internal ImmutableSymbol ResolveSymbol(SymbolId sid)
        {
            ImmutableSymbol result;
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
            return this.ContainsSymbol(symbol.Id);
        }

        public bool ContainsSymbol(MutableSymbol symbol)
        {
            if (symbol == null) return false;
            return this.ContainsSymbol(symbol.Id);
        }

        public MutableModelGroup ToMutable(bool createNew = false)
        {
            MutableModelGroup result;
            if (!createNew)
            {
                lock (this.mutableGroup)
                {
                    if (this.mutableGroup.TryGetTarget(out result) && result != null)
                    {
                        return result;
                    }
                }
            }
            result = new MutableModelGroup(this.green, this);
            if (!createNew)
            {
                lock (this.mutableGroup)
                {
                    MutableModelGroup oldGroup = null;
                    if (this.mutableGroup.TryGetTarget(out oldGroup) && oldGroup != null)
                    {
                        return oldGroup;
                    }
                    else
                    {
                        this.mutableGroup.SetTarget(result);
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
            return this.ContainsSymbol(symbol.Id);
        }

        public bool ContainsSymbol(MutableSymbol symbol)
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


    public abstract class ModelFactory
    {
        private MutableModel model;

        public ModelFactory(MutableModel model)
        {
            this.model = model;
        }

        public MutableModel Model { get { return this.model; } }

        protected MutableSymbol CreateSymbol(SymbolId id, bool weakReference)
        {
            MutableSymbol symbol = this.model.CreateSymbol(id, weakReference);
            return symbol;
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
