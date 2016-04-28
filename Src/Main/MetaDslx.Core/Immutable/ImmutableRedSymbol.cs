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
        private GreenSymbol green;
        private ImmutableRedModel model;

        protected ImmutableRedSymbolBase(GreenSymbol green, ImmutableRedModel model)
        {
            this.green = green;
            this.model = model;
        }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : class
        {
            T result = value;
            if (result == null)
            {
                result = (T)this.model.GetValue(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected ImmutableRedList<T> GetList<T>(ModelProperty property, ref ImmutableRedList<T> value)
        {
            ImmutableRedList<T> result = value;
            if (result == null)
            {
                result = this.model.GetList<T>(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        internal GreenSymbol Green { get { return this.green; } }
        public ImmutableRedModel MModel
        {
            get
            {
                return this.model;
            }
        }
        public ImmutableRedSymbol MParent
        {
            get
            {
                return this.model.MParent(this);
            }
        }
        public IEnumerable<ImmutableRedSymbol> MChildren
        {
            get
            {
                return this.model.MChildren(this);
            }
        }
        public IReadOnlyList<ModelProperty> MProperties
        {
            get
            {
                return this.model.MProperties(this);
            }
        }
        public IReadOnlyList<ModelProperty> MAllProperties
        {
            get
            {
                return this.model.MAllProperties(this);
            }
        }

        public object MGet(ModelProperty property)
        {
            return this.model.MGet(this, property);
        }
        public bool MIsSet(ModelProperty property)
        {
            return this.model.MIsSet(this, property);
        }
        public ModelProperty MGetProperty(string name)
        {
            return this.model.MGetProperty(this, name);
        }
        public IReadOnlyList<ModelProperty> MGetAllProperties(string name)
        {
            return this.model.MGetAllProperties(this, name);
        }
        public bool MTryGet(ModelProperty property, out object value)
        {
            bool result = this.model.MTryGet(this, property, out value);
            value = this.model.ToRedValue(value);
            return result;
        }
        public bool MHasLazy(ModelProperty property)
        {
            return this.model.MHasLazy(this, property);
        }
        public bool MIsAttached(ModelProperty property)
        {
            return this.model.MIsAttached(this, property);
        }
    }

    public abstract class MutableRedSymbolBase : MutableRedSymbol
    {
        private GreenSymbol green;
        private MutableRedModel model;

        internal HashSet<ModelProperty> invalidatedProperties;

        protected MutableRedSymbolBase(GreenSymbol green, MutableRedModel model)
        {
            this.green = green;
            this.model = model;
        }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : class
        {
            T result = value;
            if (result == null)
            {
                result = (T)this.model.GetValue(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected void SetValue<T>(ModelProperty property, ref T target, T value)
            where T : class
        {
            if (value is MutableRedSymbolBase && ((MutableRedSymbolBase)(object)value).model != this.model)
            {
                value = (T)this.model.ToRedValue(this.model.ToGreenValue(value));
            }
            if (this.model.SetValue(this, property, value))
            {
                Interlocked.Exchange(ref target, value);
            }
        }

        protected MutableRedList<T> GetList<T>(ModelProperty property, ref MutableRedList<T> value)
        {
            MutableRedList<T> result = value;
            if (result == null)
            {
                result = this.model.GetList<T>(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        internal GreenSymbol Green { get { return this.green; } }

        public MutableRedModel MModel
        {
            get
            {
                return this.model;
            }
        }
        public MutableRedSymbol MParent
        {
            get
            {
                return this.model.MParent(this);
            }
        }
        public IEnumerable<MutableRedSymbol> MChildren
        {
            get
            {
                return this.model.MChildren(this);
            }
        }
        public IReadOnlyList<ModelProperty> MProperties
        {
            get
            {
                return this.model.MProperties(this);
            }
        }
        public IReadOnlyList<ModelProperty> MAllProperties
        {
            get
            {
                return this.model.MAllProperties(this);
            }
        }

        public object MGet(ModelProperty property)
        {
            return this.model.MGet(this, property);
        }
        public bool MIsSet(ModelProperty property)
        {
            return this.model.MIsSet(this, property);
        }
        public ModelProperty MGetProperty(string name)
        {
            return this.model.MGetProperty(this, name);
        }
        public IReadOnlyList<ModelProperty> MGetAllProperties(string name)
        {
            return this.model.MGetAllProperties(this, name);
        }
        public bool MTryGet(ModelProperty property, out object value)
        {
            bool result = this.model.MTryGet(this, property, out value);
            value = this.model.ToRedValue(value);
            return result;
        }
        public bool MHasLazy(ModelProperty property)
        {
            return this.model.MHasLazy(this, property);
        }
        public bool MIsAttached(ModelProperty property)
        {
            return this.model.MIsAttached(this, property);
        }

        public bool MAdd(ModelProperty property, object value)
        {
            return this.model.MAdd(this, property, value);
        }
        public bool MClear(ModelProperty property, bool clearLazy = true)
        {
            return this.model.MClear(this, property, clearLazy);
        }
        public bool MClearLazy(ModelProperty property)
        {
            return this.model.MClearLazy(this, property);
        }
        public bool MReset(ModelProperty property, object value)
        {
            return this.model.MReset(this, property, value);
        }
        public bool MAddRange(ModelProperty property, IEnumerable<object> value)
        {
            return this.model.MAddRange(this, property, value);
        }
        public bool MAttachProperty(ModelProperty property)
        {
            return this.model.MAttachProperty(this, property);
        }
        public bool MDetachProperty(ModelProperty property)
        {
            return this.model.MDetachProperty(this, property);
        }
        public void MEvaluateLazy()
        {
            this.model.MEvaluateLazy(this);
        }
        public bool MLazyAdd(ModelProperty property, Func<object> value)
        {
            return this.model.MLazyAdd(this, property, value);
        }
        public bool MLazyAddRange(ModelProperty property, Func<IEnumerable<object>> values)
        {
            return this.model.MLazyAddRange(this, property, values);
        }
        public bool MLazyAddRange(ModelProperty property, IEnumerable<Func<object>> values)
        {
            return this.model.MLazyAddRange(this, property, values);
        }
        public bool MChildLazySet(ModelProperty child, ModelProperty property, Func<object> value)
        {
            return this.model.MChildLazySet(this, child, property, value);
        }
        public bool MChildLazyAddRange(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values)
        {
            return this.model.MChildLazyAddRange(this, child, property, values);
        }
        public bool MChildLazyAddRange(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values)
        {
            return this.model.MChildLazyAddRange(this, child, property, values);
        }
        public bool MChildLazyClear(ModelProperty child)
        {
            return this.model.MChildLazyClear(this, child);
        }
        public bool MChildLazyClear(ModelProperty child, ModelProperty property)
        {
            return this.model.MChildLazyClear(this, child, property);
        }
        public bool MRemove(ModelProperty property, object value, bool removeAll = false)
        {
            return this.model.MRemove(this, property, value, removeAll);
        }
        public void MUnset(ModelProperty property)
        {
            this.model.MUnset(this, property);
        }

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
