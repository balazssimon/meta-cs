using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public abstract class RedSymbolBase : RedSymbol
    {
        private GreenSymbol green;
        private RedModel model;

        public RedSymbolBase(GreenSymbol green, RedModel model)
        {
            this.green = green;
            this.model = model;
        }

        internal GreenSymbol Green { get { return this.green; } }
        public RedModel MModel { get { return this.model; } }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }
        public abstract RedSymbol MParent { get; }
        public abstract IReadOnlyList<RedSymbol> MChildren { get; }
        public abstract IEnumerable<ModelProperty> MProperties { get; }
        public abstract IEnumerable<ModelProperty> MAllProperties { get; }

        public abstract object MGet(ModelProperty property);
        public abstract bool MIsSet(ModelProperty property);
        public abstract ModelProperty MGetProperty(string name);
        public abstract IEnumerable<ModelProperty> MGetAllProperties(string name);
    }

    public abstract class ImmutableRedSymbolBase : RedSymbolBase, ImmutableRedSymbol
    {
        protected ImmutableRedSymbolBase(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public new ImmutableRedModel MModel { get { return (ImmutableRedModel)this.MModel; } }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : class
        {
            T result = value;
            if (result == null)
            {
                result = (T)this.MModel.GetValue(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected ImmutableRedList<T> GetList<T>(ModelProperty property, ref ImmutableRedList<T> value)
        {
            ImmutableRedList<T> result = value;
            if (result == null)
            {
                result = this.MModel.GetList<T>(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }
    }

    public abstract class MutableRedSymbolBase : RedSymbolBase, MutableRedSymbol
    {
        internal HashSet<ModelProperty> invalidatedProperties;

        protected MutableRedSymbolBase(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
        }

        public new MutableRedModel MModel { get { return (MutableRedModel)this.MModel; } }

        public abstract bool MAdd(ModelProperty property, object value);
        public abstract bool MAddRange(ModelProperty property, IEnumerable<object> value);
        public abstract bool MLazyAdd(ModelProperty property, Func<object> value);
        public abstract bool MLazyAddRange(ModelProperty property, Func<IEnumerable<object>> value);
        public abstract bool MLazyAddRange(ModelProperty property, IEnumerable<Func<object>> value);
        public abstract bool MLazySetChild(ModelProperty child, ModelProperty property, Func<object> value);
        public abstract bool MRemove(ModelProperty property, object value);

        internal void InvalidateProperty(ModelProperty property)
        {
            if (this.invalidatedProperties == null)
            {
                this.invalidatedProperties = new HashSet<ModelProperty>();
            }
            this.invalidatedProperties.Add(property);
        }

        private bool ClearInvalidatedProperty(ModelProperty property)
        {
            if (this.invalidatedProperties != null && this.invalidatedProperties.Contains(property))
            {
                this.invalidatedProperties.Remove(property);
                return true;
            }
            return false;
        }
    }

}
