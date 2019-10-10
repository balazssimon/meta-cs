using MetaDslx.Modeling.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.Modeling
{
    public sealed class ImmutableModelGroup : IModelGroup
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

        IEnumerable<IModel> IModelGroup.Models => this.Models;

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

}
