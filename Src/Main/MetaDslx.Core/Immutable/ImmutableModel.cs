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
        public abstract Type ImmutableType { get; }
        public abstract Type MutableType { get; }
        public abstract ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model);
        public abstract MutableRedSymbol CreateMutableRed(MutableRedModel model);
    }

    // RED interface:

    // Symbol:

    public interface RedSymbol
    {
        object MMetaModel { get; }
        object MMetaClass { get; }
        RedModel MModel { get; }
        RedSymbol MParent { get; }
        IReadOnlyList<RedSymbol> MChildren { get; }
        IEnumerable<ModelProperty> MProperties { get; }
        IEnumerable<ModelProperty> MAllProperties { get; }
        object MGet(ModelProperty property);
        bool MIsSet(ModelProperty property);
        ModelProperty MGetProperty(string name);
        IEnumerable<ModelProperty> MGetAllProperties(string name);
    }

    public interface ImmutableRedSymbol : RedSymbol
    {
        new ImmutableRedModel MModel { get; }
    }

    public interface MutableRedSymbol : RedSymbol
    {
        new MutableRedModel MModel { get; }
        bool MAdd(ModelProperty property, object value);
        bool MLazyAdd(ModelProperty property, Func<object> value);
        bool MAddRange(ModelProperty property, IEnumerable<object> value);
        bool MLazyAddRange(ModelProperty property, Func<IEnumerable<object>> value);
        bool MLazyAddRange(ModelProperty property, IEnumerable<Func<object>> value);
        bool MRemove(ModelProperty property, object value);
        bool MLazySetChild(ModelProperty child, ModelProperty property, Func<object> value);
    }

    // List:

    public interface ImmutableModelList<T> : IReadOnlyList<T>
    {
        bool Contains(T item);
    }

    public interface ModelList<T> : IList<T>
    {
        void LazyAdd(Func<T> lazy);
        void LazyAddRange(Func<IEnumerable<T>> lazy);
        void LazyAddRange(IEnumerable<Func<T>> lazy);
    }

    // Model:

    public interface RedModel
    {

    }

}
