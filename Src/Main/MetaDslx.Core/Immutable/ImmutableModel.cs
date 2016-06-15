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
        public abstract IMutableSymbol CreateMutable(MutableModel model, bool created);

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
        IMutableSymbol ToMutable();
        IMutableSymbol ToMutable(MutableModel model);
        new ImmutableModel MModel { get; }
        new IImmutableSymbol MParent { get; }
        new IReadOnlyList<IImmutableSymbol> MChildren { get; }
        IReadOnlyList<ModelProperty> MProperties { get; }
        IEnumerable<ModelProperty> MAllProperties { get; }
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
        IImmutableSymbol ToImmutable();
        IImmutableSymbol ToImmutable(ImmutableModel model);
        new MutableModel MModel { get; }
        new IMutableSymbol MParent { get; }
        new IReadOnlyList<IMutableSymbol> MChildren { get; }
        IReadOnlyList<ModelProperty> MProperties { get; }
        IEnumerable<ModelProperty> MAllProperties { get; }
        bool MTryGet(ModelProperty property, out object value);
        object MGet(ModelProperty property);
        bool MIsSet(ModelProperty property);
        bool MIsAttached(ModelProperty property);
        bool MHasLazy(ModelProperty property);
        ModelProperty MGetProperty(string name);
        IReadOnlyList<ModelProperty> MGetAllProperties(string name);

        void MAttachProperty(ModelProperty property);
        void MDetachProperty(ModelProperty property);
        void MUnset(ModelProperty property, bool reset = false);
        void MClear(ModelProperty property, bool clearLazy = true, bool reset = false);
        void MClearLazy(ModelProperty property, bool reset = false);
        void MSet(ModelProperty property, object value, bool reset = false);
        void MSetLazy(ModelProperty property, Func<object> value, bool reset = false);
        void MSetRange(ModelProperty property, IEnumerable<object> values, bool reset = false);
        void MSetRangeLazy(ModelProperty property, IEnumerable<Func<object>> values, bool reset = false);
        void MSetRangeLazy(ModelProperty property, Func<IEnumerable<object>> values, bool reset = false);
        void MAdd(ModelProperty property, object value, bool reset = false);
        void MAddLazy(ModelProperty property, Func<object> value, bool reset = false);
        void MAddRange(ModelProperty property, IEnumerable<object> value, bool reset = false);
        void MAddRangeLazy(ModelProperty property, Func<IEnumerable<object>> values, bool reset = false);
        void MAddRangeLazy(ModelProperty property, IEnumerable<Func<object>> values, bool reset = false);
        void MRemove(ModelProperty property, object value, bool removeAll = false, bool reset = false);
        void MChildSetLazy(ModelProperty child, ModelProperty property, Func<object> value, bool reset = false);
        void MChildSetRangeLazy(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset = false);
        void MChildSetRangeLazy(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset = false);
        void MChildAddLazy(ModelProperty child, ModelProperty property, Func<object> value, bool reset = false);
        void MChildAddRangeLazy(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset = false);
        void MChildAddRangeLazy(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset = false);
        void MChildClearLazy(ModelProperty child, bool reset = false);
        void MChildClearLazy(ModelProperty child, ModelProperty property, bool reset = false);
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
        void AddLazy(Func<T> lazy);
        void AddRangeLazy(Func<IEnumerable<T>> lazy);
        void AddRangeLazy(IEnumerable<Func<T>> lazy);
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
            this.model = new MutableModel(new GreenModel(), null, false, null);
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
