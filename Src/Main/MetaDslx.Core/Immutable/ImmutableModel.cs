﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public enum ReferenceMode
    {
        Default,
        StrongReference,
        WeakReference
    }
    
    // GREEN interface:

    public abstract class SymbolId
    {
        private string id;
        public SymbolId()
        {
            this.id = Guid.NewGuid().ToString();
        }
        public abstract Type ImmutableType { get; }
        public abstract Type MutableType { get; }
        public abstract ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart part);
        public abstract MutableRedSymbol CreateMutableRed(MutableRedModelPart part);

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SymbolId)) return false;
            return ((SymbolId)obj).id == this.id;
        }
    }

    // RED interface:

    public interface RedSymbol
    {
        object MMetaModel { get; }
        object MMetaClass { get; }

        RedModel MModel { get; }
        RedModelPart MModelPart { get; }
        RedSymbol MParent { get; }
        IReadOnlyList<RedSymbol> MChildren { get; }
    }

    // Symbol:
    public interface ImmutableRedSymbol : RedSymbol
    {
        new ImmutableRedModel MModel { get; }
        new ImmutableRedModelPart MModelPart { get; }
        new ImmutableRedSymbol MParent { get; }
        new IReadOnlyList<ImmutableRedSymbol> MChildren { get; }
        IReadOnlyList<ModelProperty> MProperties { get; }
        IReadOnlyList<ModelProperty> MAllProperties { get; }
        bool MTryGet(ModelProperty property, out object value);
        object MGet(ModelProperty property);
        bool MIsSet(ModelProperty property);
        bool MIsAttached(ModelProperty property);
        bool MHasLazy(ModelProperty property);
        ModelProperty MGetProperty(string name);
        IReadOnlyList<ModelProperty> MGetAllProperties(string name);
    }

    public interface MutableRedSymbol : RedSymbol
    {
        new MutableRedModel MModel { get; }
        new MutableRedModelPart MModelPart { get; }
        new MutableRedSymbol MParent { get; }
        new IReadOnlyList<MutableRedSymbol> MChildren { get; }
        IReadOnlyList<ModelProperty> MProperties { get; }
        IReadOnlyList<ModelProperty> MAllProperties { get; }
        bool MTryGet(ModelProperty property, out object value);
        object MGet(ModelProperty property);
        bool MIsSet(ModelProperty property);
        bool MIsAttached(ModelProperty property);
        bool MHasLazy(ModelProperty property);
        ModelProperty MGetProperty(string name);
        IReadOnlyList<ModelProperty> MGetAllProperties(string name);

        bool MAttachProperty(ModelProperty property);
        bool MDetachProperty(ModelProperty property);
        void MUnset(ModelProperty property);
        bool MClear(ModelProperty property, bool clearLazy = true);
        bool MClearLazy(ModelProperty property);
        bool MAdd(ModelProperty property, object value, bool reset = false);
        bool MLazyAdd(ModelProperty property, Func<object> value, bool reset = false);
        bool MAddRange(ModelProperty property, IEnumerable<object> value, bool reset = false);
        bool MLazyAddRange(ModelProperty property, Func<IEnumerable<object>> values, bool reset = false);
        bool MLazyAddRange(ModelProperty property, IEnumerable<Func<object>> values, bool reset = false);
        bool MRemove(ModelProperty property, object value, bool removeAll = false);
        bool MChildLazyAdd(ModelProperty child, ModelProperty property, Func<object> value, bool reset = false);
        bool MChildLazyAddRange(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset = false);
        bool MChildLazyAddRange(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset = false);
        bool MChildLazyClear(ModelProperty child);
        bool MChildLazyClear(ModelProperty child, ModelProperty property);
        void MEvaluateLazy();
    }

    // List:

    public interface ImmutableModelList<T> : IReadOnlyList<T>
    {
        bool Contains(T item);
        bool HasLazy();
    }

    public interface ModelList<T> : IList<T>
    {
        void LazyAdd(Func<T> lazy);
        void LazyAddRange(Func<IEnumerable<T>> lazy);
        void LazyAddRange(IEnumerable<Func<T>> lazy);
        bool HasLazy();
        void ClearLazy();
    }

    // Model:

    public interface RedModelPart
    {

    }

    public interface RedModel
    {

    }

    public abstract class ModelFactory
    {
        private MutableRedModel model;
        private MutableRedModelPart part;

        public ModelFactory()
        {
            this.model = new MutableRedModel();
            var parts = this.model.Parts.ToList();
            if (parts.Count != 1)
            {
                throw new ModelException("The model must have exactly one part.");
            }
            this.part = parts[0];
        }

        public ModelFactory(MutableRedModel model)
        {
            this.model = model;
            var parts = this.model.Parts.ToList();
            if (parts.Count != 1)
            {
                throw new ModelException("The model must have exactly one part.");
            }
            this.part = parts[0];
        }

        public ModelFactory(MutableRedModel model, MutableRedModelPart part)
        {
            this.model = model;
            if (!model.Parts.Contains(part))
            {
                throw new ModelException("The model must contain the given part.");
            }
            this.part = part;
        }

        public MutableRedModel Model { get { return this.model; } }
        public MutableRedModelPart ModelPart { get { return this.part; } }

        protected MutableRedSymbol AddSymbol(SymbolId id)
        {
            MutableRedSymbol symbol = this.part.AddSymbol(id);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public abstract MutableRedSymbol Create(string type);
    }
}
