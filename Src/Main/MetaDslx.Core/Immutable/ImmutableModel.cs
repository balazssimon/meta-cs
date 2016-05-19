using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
   
    // GREEN interface:

    public abstract class SymbolId
    {
        private string id;
        public SymbolId()
        {
            this.id = Guid.NewGuid().ToString();
        }
        public string Id { get { return this.id; } }
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

    public interface RedModel
    {

    }

    public abstract class ModelFactory
    {
        private MutableRedModel model;

        public ModelFactory()
        {
            this.model = new MutableRedModel();
        }

        public ModelFactory(MutableRedModel model)
        {
            this.model = model;
        }

        public MutableRedModel Model { get { return this.model; } }

        protected MutableRedSymbol AddSymbol(SymbolId id)
        {
            MutableRedSymbol symbol = this.model.AddSymbol(id);
            return symbol;
        }

        public abstract MutableRedSymbol Create(string type);
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
            //if (property.IsCollection) throw new ArgumentException("Property '" + property + "' must not be a collection.", nameof(property));
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
