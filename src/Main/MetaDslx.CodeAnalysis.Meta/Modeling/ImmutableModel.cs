using MetaDslx.Modeling.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.Modeling
{
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

        IEnumerable<IMetaSymbol> IModel.Symbols => this.Symbols;

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
            if (this.green.Symbols.TryGetValue(sid, out greenSymbol))
            {
                return greenSymbol.Properties.Keys.ToList();
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

}
