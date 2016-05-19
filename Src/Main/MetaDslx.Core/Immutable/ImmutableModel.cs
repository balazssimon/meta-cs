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
        public abstract IImmutableSymbol CreateImmutable(ImmutableModel model);
        public abstract IMutableSymbol CreateMutable(MutableModel model);

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

    public interface ISymbol
    {
        object MMetaModel { get; }
        object MMetaClass { get; }

        RedModel MModel { get; }
        bool MIsReadOnly { get; }
        ISymbol MParent { get; }
        IReadOnlyList<ISymbol> MChildren { get; }
    }

    // Symbol:
    public interface IImmutableSymbol : ISymbol
    {
        new ImmutableModel MModel { get; }
        new IImmutableSymbol MParent { get; }
        new IReadOnlyList<IImmutableSymbol> MChildren { get; }
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

    public interface IMutableSymbol : ISymbol
    {
        new MutableModel MModel { get; }
        new IMutableSymbol MParent { get; }
        new IReadOnlyList<IMutableSymbol> MChildren { get; }
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

    public interface IImmutableModelList<T> : IReadOnlyList<T>
    {
        bool Contains(T item);
        bool HasLazy();
    }

    public interface IMutableModelList<T> : IList<T>
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
        private MutableModel model;

        public ModelFactory()
        {
            this.model = new MutableModel();
        }

        public ModelFactory(MutableModel model)
        {
            this.model = model;
        }

        public MutableModel Model { get { return this.model; } }

        protected IMutableSymbol AddSymbol(SymbolId id)
        {
            IMutableSymbol symbol = this.model.AddSymbol(id);
            return symbol;
        }

        public abstract IMutableSymbol Create(string type);
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
