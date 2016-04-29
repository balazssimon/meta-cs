using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    // GREEN interface:

    public abstract class GreenSymbol
    {
        private string id;
        public GreenSymbol()
        {
            this.id = Guid.NewGuid().ToString();
        }
        public abstract Type ImmutableType { get; }
        public abstract Type MutableType { get; }
        public abstract ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model);
        public abstract MutableRedSymbol CreateMutableRed(MutableRedModel model);

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GreenSymbol)) return false;
            return ((GreenSymbol)obj).id == this.id;
        }
    }

    // RED interface:

    public interface RedSymbol
    {
        object MMetaModel { get; }
        object MMetaClass { get; }

        RedModel MModel { get; }
        RedSymbol MParent { get; }
        IReadOnlyList<RedSymbol> MChildren { get; }
    }

    // Symbol:
    public interface ImmutableRedSymbol : RedSymbol
    {
        new ImmutableRedModel MModel { get; }
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
        bool MAdd(ModelProperty property, object value);
        bool MClear(ModelProperty property, bool clearLazy = true);
        bool MClearLazy(ModelProperty property);
        bool MReset(ModelProperty property, object value);
        bool MLazyAdd(ModelProperty property, Func<object> value);
        bool MAddRange(ModelProperty property, IEnumerable<object> value);
        bool MLazyAddRange(ModelProperty property, Func<IEnumerable<object>> values);
        bool MLazyAddRange(ModelProperty property, IEnumerable<Func<object>> values);
        bool MRemove(ModelProperty property, object value, bool removeAll = false);
        bool MChildLazySet(ModelProperty child, ModelProperty property, Func<object> value);
        bool MChildLazyAddRange(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values);
        bool MChildLazyAddRange(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values);
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

    public interface RedModel
    {

    }
}
