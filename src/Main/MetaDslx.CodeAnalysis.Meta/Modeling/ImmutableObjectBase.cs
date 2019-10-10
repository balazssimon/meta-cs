using MetaDslx.Languages.Meta.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling
{
    public abstract class ImmutableSymbolBase : ImmutableSymbol
    {
        private SymbolId id;
        private ImmutableModel model;

        protected ImmutableSymbolBase(SymbolId id, ImmutableModel model)
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

        public SymbolId MId { get { return this.id; } }

        public abstract MetaModel MMetaModel { get; }
        public abstract MetaClass MMetaClass { get; }

        public ImmutableModel MModel { get { return this.model; } }
        IModel IMetaSymbol.MModel { get { return this.MModel; } }
        public ImmutableSymbol MParent { get { return this.model.MParent(this.id); } }
        public ImmutableModelList<ImmutableSymbol> MChildren { get { return this.model.MChildren(this.id); } }

        IMetaSymbol IMetaSymbol.MParent { get { return this.model.MParent(this.id); } }
        IReadOnlyList<IMetaSymbol> IMetaSymbol.MChildren { get { return this.model.MChildren(this.id); } }

        public IReadOnlyList<IMetaSymbol> MGetImports() { return this.model.MGetImports(this.id); }
        public IReadOnlyList<IMetaSymbol> MGetBases() { return this.model.MGetBases(this.id); }
        public IReadOnlyList<IMetaSymbol> MGetAllBases() { return this.model.MGetAllBases(this.id); }
        public IReadOnlyList<IMetaSymbol> MGetMembers() { return this.model.MGetMembers(this.id); }

        public IReadOnlyList<ModelProperty> MProperties { get { return this.model.MProperties(this.id); } }
        public IReadOnlyList<ModelProperty> MAllProperties { get { return this.model.MAllProperties(this.id); } }
        public ModelProperty MGetProperty(string name)
        {
            IReadOnlyList<ModelProperty> properties = this.MProperties;
            for (int i = properties.Count - 1; i >= 0; i--)
            {
                ModelProperty prop = properties[i];
                if (prop.Name == name) return prop;
            }
            return null;
        }
        public IReadOnlyList<ModelProperty> MGetProperties(string name)
        {
            return this.MProperties.Where(p => p.Name == name).ToImmutableList().Reverse();
        }

        public string MName
        {
            get
            {
                ModelProperty nameProperty = this.id.SymbolInfo.NameProperty;
                if (nameProperty != null)
                {
                    object nameObj = this.MGet(nameProperty);
                    if (nameObj == null) return null;
                    else return nameObj.ToString();
                }
                return null;
            }
        }
        public ImmutableSymbol MType
        {
            get
            {
                ModelProperty typeProperty = this.id.SymbolInfo.TypeProperty;
                if (typeProperty != null)
                {
                    object typeObj = this.MGet(typeProperty);
                    return typeObj as ImmutableSymbol;
                }
                return null;
            }
        }

        IMetaSymbol IMetaSymbol.MType
        {
            get
            {
                return this.MType;
            }
        }

        public object MGet(ModelProperty property)
        {
            return this.model.MGet(this.id, property);
        }
        public bool MIsSet(ModelProperty property)
        {
            return this.model.MIsSet(this.id, property);
        }
        public bool MHasConcreteValue(ModelProperty property)
        {
            return this.model.MHasConcreteValue(this.id, property);
        }

        public T MGetValue<T>(ModelProperty property) where T : struct
        {
            T dummy = default;
            return this.GetValue<T>(property, ref dummy);
        }

        public T MGetReference<T>(ModelProperty property) where T : class
        {
            T dummy = null;
            return this.GetReference<T>(property, ref dummy);
        }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : struct
        {
            object valueObj = this.model.GetValue(this.id, property);
            if (valueObj == null) value = default(T);
            else value = (T)valueObj;
            return value;
        }

        protected T GetReference<T>(ModelProperty property, ref T value)
            where T : class
        {
            T result = value;
            if (result == null)
            {
                result = (T)this.model.GetValue(this.id, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected ImmutableModelSet<T> GetSet<T>(ModelProperty property, ref ImmutableModelSet<T> value)
        {
            ImmutableModelSet<T> result = value;
            if (result == null)
            {
                result = this.model.GetSet<T>(this.id, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected ImmutableModelList<T> GetList<T>(ModelProperty property, ref ImmutableModelList<T> value)
        {
            ImmutableModelList<T> result = value;
            if (result == null)
            {
                result = this.model.GetList<T>(this.id, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is IMetaSymbol other)
            {
                return this.id.Equals(other.MId);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public override string ToString()
        {
            string result = this.id.DisplayTypeName;
            string name = this.MName;
            if (name != null)
            {
                result = name + " (" + result + ")";
            }
            return result;
        }
    }

}
