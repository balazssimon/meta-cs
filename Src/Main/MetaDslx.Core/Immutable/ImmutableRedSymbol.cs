using MetaDslx.Core.Collections.Transactional;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private ImmutableRedModel model;

        protected ImmutableRedSymbolBase(SymbolId green, ImmutableRedModel model)
        {
            this.id = Guid.NewGuid().ToString();
            this.green = green;
            this.model = model;
        }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : struct
        {
            if (default(T).Equals(value))
            {
                object valueObj = this.model.GetValue(this, property);
                if (valueObj == null) value = default(T);
                else value = (T)valueObj;
            }
            return value;
        }

        protected T GetReference<T>(ModelProperty property, ref T value)
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

        protected ImmutableModelList<T> GetList<T>(ModelProperty property, ref ImmutableModelList<T> value)
        {
            ImmutableModelList<T> result = value;
            if (result == null)
            {
                result = this.model.GetList<T>(this, property);
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
        public IReadOnlyList<ImmutableRedSymbol> MChildren
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

        public override int GetHashCode()
        {
            return this.green.GetHashCode();
        }

        RedModel RedSymbol.MModel
        {
            get { return this.MModel; }
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
        private bool created;
        private SymbolId green;
        private MutableRedModel model;

        protected MutableRedSymbolBase(SymbolId green, MutableRedModel model)
        {
            this.id = Guid.NewGuid().ToString();
            this.green = green;
            this.model = model;
        }

        protected T GetValue<T>(ModelProperty property)
            where T : struct
        {
            object valueObj = this.model.GetValue(this, property);
            if (valueObj == null) return default(T);
            else return (T)valueObj;
        }

        protected void SetValue<T>(ModelProperty property, T value)
            where T : struct
        {
            this.model.SetValue(this, property, value, !this.MIsCreated);
        }

        protected T GetReference<T>(ModelProperty property)
            where T : class
        {
            return (T)this.model.GetValue(this, property);
        }

        protected void SetReference<T>(ModelProperty property, T value)
            where T : class
        {
            if (value is MutableRedSymbolBase && ((MutableRedSymbolBase)(object)value).model != this.model)
            {
                value = (T)this.model.ToRedValue(this.model.ToGreenValue(value));
            }
            this.model.SetValue(this, property, value, !this.MIsCreated);
        }

        protected Func<T> GetLazyValue<T>(ModelProperty property)
            where T : struct
        {
            return (Func<T>)(object)this.model.GetLazyValue(this, property);
        }

        protected void SetLazyValue<T>(ModelProperty property, Func<T> value)
            where T : struct
        {
            this.model.SetLazyValue(this, property, (Func<object>)(object)value, !this.MIsCreated);
        }

        protected Func<T> GetLazyReference<T>(ModelProperty property)
            where T : class
        {
            return (Func<T>)this.model.GetLazyValue(this, property);
        }

        protected void SetLazyReference<T>(ModelProperty property, Func<T> value)
            where T : class
        {
            this.model.SetLazyValue(this, property, value, !this.MIsCreated);
        }

        protected ModelList<T> GetList<T>(ModelProperty property, ref ModelList<T> value)
        {
            ModelList<T> result = this.model.GetList(this, property, value);
            Interlocked.Exchange(ref value, result);
            return value;
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        internal SymbolId Green { get { return this.green; } }

        public void MInit()
        {
            if (this.MIsCreated) return;
            this.MDoInit();
        }

        protected abstract void MDoInit();

        public void MInitProperties(IEnumerable<PropertyInit> propertyInitializers)
        {
            if (this.MIsCreated) return;
            foreach (var propInit in propertyInitializers)
            {
                if (propInit.Property.IsCollection)
                {
                    if (propInit.Values != null)
                    {
                        this.MLazyAddRange(propInit.Property, propInit.Values, true);
                    }
                    else if (propInit.Value != null)
                    {
                        this.MLazyAdd(propInit.Property, propInit.Value, true);
                    }
                    else
                    {
                        Debug.Assert(false);
                    }
                }
                else
                {
                    if (propInit.Value != null)
                    {
                        this.MLazyAdd(propInit.Property, propInit.Value, true);
                    }
                    else
                    {
                        Debug.Assert(false);
                    }
                }
            }
        }

        private void MCheckPropertyInitialization()
        {
            foreach (var prop in this.MAllProperties)
            {
                if (prop.IsReadonly || prop.IsDerived)
                {
                    if (!this.MIsSet(prop)) throw new ModelException("Property '"+prop+"' was not set in the type initializer.");
                }
            }
        }

        public bool MIsCreated
        {
            get
            {
                if (!this.created)
                {
                    this.created = this.model.MIsCreated(this);
                }
                return this.created;
            }
        }

        public void MMakeCreated()
        {
            this.model.MMakeCreated(this);
            this.MCheckPropertyInitialization();
        }

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
        public IReadOnlyList<MutableRedSymbol> MChildren
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

        public void MEvaluateLazy()
        {
            this.model.MEvaluateLazy(this);
        }
        public bool MAttachProperty(ModelProperty property)
        {
            return this.model.MAttachProperty(this, property);
        }
        public bool MDetachProperty(ModelProperty property)
        {
            return this.model.MDetachProperty(this, property);
        }
        public bool MClear(ModelProperty property, bool clearLazy = true)
        {
            return this.model.MClear(this, property, clearLazy);
        }
        public bool MClearLazy(ModelProperty property)
        {
            return this.model.MClearLazy(this, property);
        }
        public bool MAdd(ModelProperty property, object value, bool reset = false)
        {
            return this.model.MAdd(this, property, value, reset);
        }
        public bool MLazyAdd(ModelProperty property, Func<object> value, bool reset = false)
        {
            return this.model.MLazyAdd(this, property, value, reset);
        }
        public bool MAddRange(ModelProperty property, IEnumerable<object> value, bool reset = false)
        {
            return this.model.MAddRange(this, property, value, reset);
        }
        public bool MLazyAddRange(ModelProperty property, Func<IEnumerable<object>> values, bool reset = false)
        {
            return this.model.MLazyAddRange(this, property, values, reset);
        }
        public bool MLazyAddRange(ModelProperty property, IEnumerable<Func<object>> values, bool reset = false)
        {
            return this.model.MLazyAddRange(this, property, values, reset);
        }
        public bool MChildLazyAdd(ModelProperty child, ModelProperty property, Func<object> value, bool reset = false)
        {
            return this.model.MChildLazyAdd(this, child, property, value, reset);
        }
        public bool MChildLazyAddRange(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset = false)
        {
            return this.model.MChildLazyAddRange(this, child, property, values, reset);
        }
        public bool MChildLazyAddRange(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset = false)
        {
            return this.model.MChildLazyAddRange(this, child, property, values, reset);
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

        public override int GetHashCode()
        {
            return this.green.GetHashCode();
        }

        RedModel RedSymbol.MModel
        {
            get { return this.MModel; }
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

    public class LazyChildBuilderBase
    {
        public LazyChildBuilderBase(MutableRedSymbolBase parent, ModelProperty property)
        {
            this.MParent = parent;
            this.MProperty = property;
        }

        public MutableRedSymbolBase MParent { get; private set; }
        public ModelProperty MProperty { get; private set; }
    }

}
