using MetaDslx.Core.Collections.Transactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public abstract class ImmutableRedSymbolBase : ImmutableRedSymbol
    {
        private string id;
        private SymbolId green;
        private ImmutableRedModelPart part;

        protected ImmutableRedSymbolBase(SymbolId green, ImmutableRedModelPart part)
        {
            this.id = Guid.NewGuid().ToString();
            this.green = green;
            this.part = part;
        }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : class
        {
            T result = value;
            if (result == null)
            {
                result = (T)this.part.GetValue(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected ImmutableRedList<T> GetList<T>(ModelProperty property, ref ImmutableRedList<T> value)
        {
            ImmutableRedList<T> result = value;
            if (result == null)
            {
                result = this.part.GetList<T>(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        internal SymbolId Green { get { return this.green; } }
        public ImmutableRedModel MModel
        {
            get
            {
                return this.part.Model;
            }
        }
        public ImmutableRedModelPart MModelPart
        {
            get
            {
                return this.part;
            }
        }
        public ImmutableRedSymbol MParent
        {
            get
            {
                return this.part.MParent(this);
            }
        }
        public IReadOnlyList<ImmutableRedSymbol> MChildren
        {
            get
            {
                return this.part.MChildren(this);
            }
        }
        public IReadOnlyList<ModelProperty> MProperties
        {
            get
            {
                return this.part.MProperties(this);
            }
        }
        public IReadOnlyList<ModelProperty> MAllProperties
        {
            get
            {
                return this.part.MAllProperties(this);
            }
        }

        public object MGet(ModelProperty property)
        {
            return this.part.MGet(this, property);
        }
        public bool MIsSet(ModelProperty property)
        {
            return this.part.MIsSet(this, property);
        }
        public ModelProperty MGetProperty(string name)
        {
            return this.part.MGetProperty(this, name);
        }
        public IReadOnlyList<ModelProperty> MGetAllProperties(string name)
        {
            return this.part.MGetAllProperties(this, name);
        }
        public bool MTryGet(ModelProperty property, out object value)
        {
            bool result = this.part.MTryGet(this, property, out value);
            value = this.part.ToRedValue(value);
            return result;
        }
        public bool MHasLazy(ModelProperty property)
        {
            return this.part.MHasLazy(this, property);
        }
        public bool MIsAttached(ModelProperty property)
        {
            return this.part.MIsAttached(this, property);
        }

        public override int GetHashCode()
        {
            return this.green.GetHashCode();
        }

        RedModel RedSymbol.MModel
        {
            get { return this.MModel; }
        }

        RedModelPart RedSymbol.MModelPart
        {
            get { return this.MModelPart; }
        }

        RedSymbol RedSymbol.MParent
        {
            get { return this.MParent; }
        }

        IReadOnlyList<RedSymbol> RedSymbol.MChildren
        {
            get { return this.MChildren; }
        }
    }

    public abstract class MutableRedSymbolBase : MutableRedSymbol
    {
        private string id;
        private SymbolId green;
        private MutableRedModelPart part;
        private HashSet<ModelProperty> invalidatedProperties;

        protected MutableRedSymbolBase(SymbolId green, MutableRedModelPart part)
        {
            this.id = Guid.NewGuid().ToString();
            this.green = green;
            this.part = part;
            //this.invalidatedProperties = new HashSet<ModelProperty>();
        }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : class
        {
            T result = value;
            //if (result == null)
            {
                result = (T)this.part.GetValue(this, property);
                result = Interlocked.Exchange(ref value, result);
            }
            return value;
        }

        protected void SetValue<T>(ModelProperty property, ref T target, T value)
            where T : class
        {
            if (value is MutableRedSymbolBase && ((MutableRedSymbolBase)(object)value).part != this.part)
            {
                value = (T)this.part.ToRedValue(this.part.ToGreenValue(value));
            }
            if (this.part.SetValue(this, property, value))
            {
                //Interlocked.Exchange(ref target, value);
            }
        }

        protected MutableRedList<T> GetList<T>(ModelProperty property, ref MutableRedList<T> value)
        {
            MutableRedList<T> result = value;
            if (result == null)
            {
                result = this.part.GetList<T>(this, property, result);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        internal SymbolId Green { get { return this.green; } }

        public void Created()
        {
            this.part.CreatedSymbol(this);
        }

        public MutableRedModel MModel
        {
            get
            {
                return this.part.Model;
            }
        }
        public MutableRedModelPart MModelPart
        {
            get
            {
                return this.part;
            }
        }
        public MutableRedSymbol MParent
        {
            get
            {
                return this.part.MParent(this);
            }
        }
        public IReadOnlyList<MutableRedSymbol> MChildren
        {
            get
            {
                return this.part.MChildren(this);
            }
        }
        public IReadOnlyList<ModelProperty> MProperties
        {
            get
            {
                return this.part.MProperties(this);
            }
        }
        public IReadOnlyList<ModelProperty> MAllProperties
        {
            get
            {
                return this.part.MAllProperties(this);
            }
        }

        public object MGet(ModelProperty property)
        {
            return this.part.MGet(this, property);
        }
        public bool MIsSet(ModelProperty property)
        {
            return this.part.MIsSet(this, property);
        }
        public ModelProperty MGetProperty(string name)
        {
            return this.part.MGetProperty(this, name);
        }
        public IReadOnlyList<ModelProperty> MGetAllProperties(string name)
        {
            return this.part.MGetAllProperties(this, name);
        }
        public bool MTryGet(ModelProperty property, out object value)
        {
            bool result = this.part.MTryGet(this, property, out value);
            value = this.part.ToRedValue(value);
            return result;
        }
        public bool MHasLazy(ModelProperty property)
        {
            return this.part.MHasLazy(this, property);
        }
        public bool MIsAttached(ModelProperty property)
        {
            return this.part.MIsAttached(this, property);
        }

        public void MEvaluateLazy()
        {
            this.part.MEvaluateLazy(this);
        }
        public bool MAttachProperty(ModelProperty property)
        {
            return this.part.MAttachProperty(this, property);
        }
        public bool MDetachProperty(ModelProperty property)
        {
            return this.part.MDetachProperty(this, property);
        }
        public bool MClear(ModelProperty property, bool clearLazy = true)
        {
            return this.part.MClear(this, property, clearLazy);
        }
        public bool MClearLazy(ModelProperty property)
        {
            return this.part.MClearLazy(this, property);
        }
        public bool MAdd(ModelProperty property, object value, bool reset = false)
        {
            return this.part.MAdd(this, property, value, reset);
        }
        public bool MLazyAdd(ModelProperty property, Func<object> value, bool reset = false)
        {
            return this.part.MLazyAdd(this, property, value, reset);
        }
        public bool MAddRange(ModelProperty property, IEnumerable<object> value, bool reset = false)
        {
            return this.part.MAddRange(this, property, value, reset);
        }
        public bool MLazyAddRange(ModelProperty property, Func<IEnumerable<object>> values, bool reset = false)
        {
            return this.part.MLazyAddRange(this, property, values, reset);
        }
        public bool MLazyAddRange(ModelProperty property, IEnumerable<Func<object>> values, bool reset = false)
        {
            return this.part.MLazyAddRange(this, property, values, reset);
        }
        public bool MChildLazyAdd(ModelProperty child, ModelProperty property, Func<object> value, bool reset = false)
        {
            return this.part.MChildLazyAdd(this, child, property, value, reset);
        }
        public bool MChildLazyAddRange(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset = false)
        {
            return this.part.MChildLazyAddRange(this, child, property, values, reset);
        }
        public bool MChildLazyAddRange(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset = false)
        {
            return this.part.MChildLazyAddRange(this, child, property, values, reset);
        }
        public bool MChildLazyClear(ModelProperty child)
        {
            return this.part.MChildLazyClear(this, child);
        }
        public bool MChildLazyClear(ModelProperty child, ModelProperty property)
        {
            return this.part.MChildLazyClear(this, child, property);
        }
        public bool MRemove(ModelProperty property, object value, bool removeAll = false)
        {
            return this.part.MRemove(this, property, value, removeAll);
        }
        public void MUnset(ModelProperty property)
        {
            this.part.MUnset(this, property);
        }

        public override int GetHashCode()
        {
            return this.green.GetHashCode();
        }

        RedModel RedSymbol.MModel
        {
            get { return this.MModel; }
        }

        RedModelPart RedSymbol.MModelPart
        {
            get { return this.MModelPart; }
        }

        RedSymbol RedSymbol.MParent
        {
            get { return this.MParent; }
        }

        IReadOnlyList<RedSymbol> RedSymbol.MChildren
        {
            get { return this.MChildren; }
        }
    }

}
