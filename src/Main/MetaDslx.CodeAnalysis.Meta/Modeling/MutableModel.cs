using MetaDslx.Modeling.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling
{
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

        public MutableModel(string name = null, ModelVersion version = default)
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
                ModelUpdateContext ctx = null;
                try
                {
                    do
                    {
                        ctx = this.BeginUpdate();
                        ctx.Updater.SetName(this.id, value);
                    } while (!this.EndUpdate(ctx));
                }
                finally
                {
                    this.FinalizeUpdate(ctx);
                }
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
                ModelUpdateContext ctx = null;
                try
                {
                    do
                    {
                        ctx = this.BeginUpdate();
                        ctx.Updater.SetVersion(this.id, value);
                    } while (!this.EndUpdate(ctx));
                }
                finally
                {
                    this.FinalizeUpdate(ctx);
                }
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

        IEnumerable<IMetaSymbol> IModel.Symbols => this.Symbols;

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
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    result = ctx.Updater.RemoveSymbol(this.id, ((MutableSymbolBase)symbol).MId);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return result;
        }

        public void MergeSymbols(MutableSymbol targetSymbol, MutableSymbol partSymbol)
        {
            if (targetSymbol == partSymbol) return;
            if (targetSymbol.MMetaClass != partSymbol.MMetaClass) throw new ModelException(Location.None, ModelErrorCode.ERR_CannotMergeDifferentSymbols.ToDiagnosticInfo(partSymbol, targetSymbol, partSymbol.MId.SymbolInfo.MutableType, targetSymbol.MId.SymbolInfo.MutableType));
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.MergeSymbols(this.id, ((ImmutableSymbolBase)targetSymbol).MId, ((ImmutableSymbolBase)partSymbol).MId);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal MutableSymbolBase CreateSymbol(SymbolId sid, bool weakReference)
        {
            Debug.Assert(sid != null);
            Debug.Assert(!this.ContainsSymbol(sid));
            MutableSymbolBase result = null;
            result = sid.CreateMutable(this, true);
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.AddSymbol(this.id, sid, weakReference);
                } while (!this.EndUpdate(ctx));
                this.RegisterSymbol(sid, result);
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return result;
        }

        public ImmutableModel ToImmutable(bool evaluateLazyValues = true, CancellationToken cancellationToken = default)
        {
            ImmutableModel result;
            if (this.group != null)
            {
                ImmutableModelGroup immutableGroup = this.group.ToImmutable(evaluateLazyValues);
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
                if (evaluateLazyValues) this.EvaluateLazyValues(cancellationToken);
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
                    this.updater.Value = null;
                    return Interlocked.CompareExchange(ref this.green, context.Updater.Model, context.OriginalModel) == context.OriginalModel;
                }
                else
                {
                    return true;
                }
            }
        }

        internal void FinalizeUpdate(ModelUpdateContext context)
        {
            if (this.group != null)
            {
                this.group.FinalizeUpdate(context);
            }
            else
            {
                if (context != null && context.NewUpdater)
                {
                    this.updater.Value = null;
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

        public void EvaluateLazyValues(CancellationToken cancellationToken = default)
        {
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.EvaluateLazyValues(cancellationToken);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        public void ExecuteTransaction(Action transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    transaction();
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal object GetValue(SymbolId sid, ModelProperty property)
        {
            object value = null;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    value = ctx.Updater.GetValue(this.id, sid, property, true);
                } while (!this.EndUpdate(ctx));
                value = this.ToRedValue(value);
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
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
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.SetValue(this.id, sid, property, creating, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
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
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.SetValue(this.id, sid, property, creating, property.IsDerived ? (object)new GreenDerivedValue(value) : value);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
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
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    value = ctx.Updater.GetValue(this.id, sid, property, true);
                } while (!this.EndUpdate(ctx));
                GreenList result = value as GreenList;
                if (result == null) result = property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
                return result;
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
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
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
                return changed;
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal bool AddLazyItem(SymbolId sid, ModelProperty property, LazyValue value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, value);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool AddItems(SymbolId sid, ModelProperty property, IEnumerable<object> values, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    foreach (var value in values)
                    {
                        changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, this.ToGreenValue(value));
                    }
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool AddLazyItems(SymbolId sid, ModelProperty property, IEnumerable<LazyValue> values, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    foreach (var value in values)
                    {
                        changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, value);
                    }
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool AddLazyItems(SymbolId sid, ModelProperty property, LazyValue values, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, -1, values);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool RemoveItem(SymbolId sid, ModelProperty property, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.RemoveItem(this.id, sid, property, creating, -1, false, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool RemoveAllItems(SymbolId sid, ModelProperty property, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.RemoveItem(this.id, sid, property, creating, -1, true, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool InsertItem(SymbolId sid, ModelProperty property, int index, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, sid, property, creating, false, index, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool ReplaceItem(SymbolId sid, ModelProperty property, int index, object value, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, sid, property, creating, true, index, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool RemoveItemAt(SymbolId sid, ModelProperty property, int index, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.RemoveItem(this.id, sid, property, creating, index, false, null);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool ClearItems(SymbolId sid, ModelProperty property, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.ClearItems(this.id, sid, property, creating);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool ClearLazyItems(SymbolId sid, ModelProperty property, bool creating)
        {
            bool changed = false;
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.ClearLazyItems(this.id, sid, property, creating);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
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
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    children = ctx.Updater.GetChildren(this.id, sid);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
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

        internal IReadOnlyList<ModelProperty> MProperties(SymbolId sid)
        {
            ModelSymbolInfo msi = sid.SymbolInfo;
            if (msi != null)
            {
                return msi.Properties;
            }
            return ImmutableArray<ModelProperty>.Empty;
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(SymbolId sid)
        {
            GreenSymbol greenSymbol;
            if (this.Green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                return greenSymbol.Properties.Keys.ToImmutableArray();
            }
            return ImmutableArray<ModelProperty>.Empty;
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
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.AttachProperty(this.id, sid, property);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        public void Validate(DiagnosticBag diagnostics)
        {
            foreach (var symbol in this.Symbols)
            {
                symbol.MValidate(diagnostics);
            }
        }

        public void PurgeWeakSymbols()
        {
            ModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.PurgeWeakSymbols();
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        public override string ToString()
        {
            return this.Green.ToString();
        }
    }

}
