using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public abstract class ImmutableSymbolBase : IImmutableSymbol
    {
        private SymbolId id;
        private ImmutableModel model;

        protected ImmutableSymbolBase(SymbolId id, ImmutableModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (id == null) throw new ArgumentNullException(nameof(id));
            this.model = model;
            this.id = id;
        }

        public IMutableSymbol ToMutable()
        {
            MutableModel mutableModel = this.model.ToMutable();
            return mutableModel.GetSymbol(this);
        }

        protected T GetValue<T>(ModelProperty property, ref T value)
            where T : struct
        {
            object valueObj = this.model.GetValue(this, property);
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
                result = (T)this.model.GetValue(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected IImmutableModelList<T> GetList<T>(ModelProperty property, ref IImmutableModelList<T> value)
        {
            IImmutableModelList<T> result = value;
            if (result == null)
            {
                result = this.model.GetList<T>(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        internal SymbolId Id { get { return this.id; } }
        internal GreenSymbol Green { get { return this.model.Green.GetSymbol(this.id); } }

        public ImmutableModel MModel
        {
            get
            {
                return this.model;
            }
        }
        public bool MIsReadOnly
        {
            get { return true; }
        }
        public IImmutableSymbol MParent
        {
            get
            {
                return this.model.MParent(this);
            }
        }
        public IReadOnlyList<IImmutableSymbol> MChildren
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
        public IEnumerable<ModelProperty> MAllProperties
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

        RedModel ISymbol.MModel
        {
            get { return this.MModel; }
        }

        ISymbol ISymbol.MParent
        {
            get { return this.MParent; }
        }

        IReadOnlyList<ISymbol> ISymbol.MChildren
        {
            get { return this.MChildren; }
        }
    }

    public abstract class MutableSymbolBase : IMutableSymbol
    {
        private bool created;
        private SymbolId id;
        private MutableModel model;

        protected MutableSymbolBase(SymbolId id, MutableModel model, bool created)
        {
            this.id = id;
            this.model = model;
            this.created = created;
        }

        public IImmutableSymbol ToImmutable()
        {
            ImmutableModel immutableModel = this.model.ToImmutable();
            return immutableModel.GetSymbol(this);
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
            this.model.SetValue(this, property, value, !this.created);
        }

        protected T GetReference<T>(ModelProperty property)
            where T : class
        {
            return (T)this.model.GetValue(this, property);
        }

        protected void SetReference<T>(ModelProperty property, T value)
            where T : class
        {
            if (value is MutableSymbolBase && ((MutableSymbolBase)(object)value).model != this.model)
            {
                value = (T)this.model.ToRedValue(this.model.ToGreenValue(value));
            }
            this.model.SetValue(this, property, value, !this.created);
        }

        protected Func<T> GetLazyValue<T>(ModelProperty property)
            where T : struct
        {
            return (Func<T>)(object)this.model.GetLazyValue(this, property);
        }

        protected void SetLazyValue<T>(ModelProperty property, Func<T> value)
            where T : struct
        {
            this.model.SetLazyValue(this, property, (Func<object>)(object)value, !this.created);
        }

        protected Func<T> GetLazyReference<T>(ModelProperty property)
            where T : class
        {
            return (Func<T>)this.model.GetLazyValue(this, property);
        }

        protected void SetLazyReference<T>(ModelProperty property, Func<T> value)
            where T : class
        {
            this.model.SetLazyValue(this, property, value, !this.created);
        }

        protected IMutableModelList<T> GetList<T>(ModelProperty property, ref IMutableModelList<T> value)
        {
            IMutableModelList<T> result = this.model.GetList(this, property, value);
            result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            return result;
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        public bool MIsReadOnly
        {
            get { return this.model.IsReadOnly; }
        }
         
        internal SymbolId Id { get { return this.id; } }
        internal GreenSymbol Green { get { return this.model.Green.GetSymbol(this.id); } }
        internal bool MIsCreated { get { return this.created; } }

        public void MInit()
        {
            if (this.created) return;
            this.MDoInit();
        }

        protected abstract void MDoInit();

        public void MInitProperties(IEnumerable<PropertyInit> propertyInitializers)
        {
            if (this.created) return;
            foreach (var propInit in propertyInitializers)
            {
                if (propInit.Property.IsCollection)
                {
                    if (propInit.Values != null)
                    {
                        this.MAddRangeLazy(propInit.Property, propInit.Values, true);
                    }
                    else if (propInit.Value != null)
                    {
                        this.MAddLazy(propInit.Property, propInit.Value, true);
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
                        this.MAddLazy(propInit.Property, propInit.Value, true);
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

        public void MMakeCreated()
        {
            this.created = true;
            this.MCheckPropertyInitialization();
        }

        public MutableModel MModel
        {
            get
            {
                return this.model;
            }
        }
        public IMutableSymbol MParent
        {
            get
            {
                return this.model.MParent(this);
            }
        }
        public IReadOnlyList<IMutableSymbol> MChildren
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
        public IEnumerable<ModelProperty> MAllProperties
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
        public void MAttachProperty(ModelProperty property)
        {
            this.model.MAttachProperty(this, property);
        }
        public void MDetachProperty(ModelProperty property)
        {
            this.model.MDetachProperty(this, property);
        }
        public void MClear(ModelProperty property, bool clearLazy = true, bool reset = false)
        {
            this.model.MClear(this, property, clearLazy, reset);
        }
        public void MClearLazy(ModelProperty property, bool reset = false)
        {
            this.model.MClearLazy(this, property, reset);
        }
        public void MSet(ModelProperty property, object value, bool reset = false)
        {
            this.model.MSet(this, property, value, reset);
        }
        public void MSetLazy(ModelProperty property, Func<object> value, bool reset = false)
        {
            this.model.MSetLazy(this, property, value, reset);
        }
        public void MSetRange(ModelProperty property, IEnumerable<object> value, bool reset = false)
        {
            this.model.MSetRange(this, property, value, reset);
        }
        public void MSetRangeLazy(ModelProperty property, Func<IEnumerable<object>> values, bool reset = false)
        {
            this.model.MSetRangeLazy(this, property, values, reset);
        }
        public void MSetRangeLazy(ModelProperty property, IEnumerable<Func<object>> values, bool reset = false)
        {
            this.model.MSetRangeLazy(this, property, values, reset);
        }
        public void MAdd(ModelProperty property, object value, bool reset = false)
        {
            this.model.MAdd(this, property, value, reset);
        }
        public void MAddLazy(ModelProperty property, Func<object> value, bool reset = false)
        {
            this.model.MAddLazy(this, property, value, reset);
        }
        public void MAddRange(ModelProperty property, IEnumerable<object> value, bool reset = false)
        {
            this.model.MAddRange(this, property, value, reset);
        }
        public void MAddRangeLazy(ModelProperty property, Func<IEnumerable<object>> values, bool reset = false)
        {
            this.model.MAddRangeLazy(this, property, values, reset);
        }
        public void MAddRangeLazy(ModelProperty property, IEnumerable<Func<object>> values, bool reset = false)
        {
            this.model.MAddRangeLazy(this, property, values, reset);
        }
        public void MChildSetLazy(ModelProperty child, ModelProperty property, Func<object> value, bool reset = false)
        {
            this.model.MChildSetLazy(this, child, property, value, reset);
        }
        public void MChildSetRangeLazy(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset = false)
        {
            this.model.MChildSetRangeLazy(this, child, property, values, reset);
        }
        public void MChildSetRangeLazy(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset = false)
        {
            this.model.MChildSetRangeLazy(this, child, property, values, reset);
        }
        public void MChildAddLazy(ModelProperty child, ModelProperty property, Func<object> value, bool reset = false)
        {
            this.model.MChildAddLazy(this, child, property, value, reset);
        }
        public void MChildAddRangeLazy(ModelProperty child, ModelProperty property, Func<IEnumerable<object>> values, bool reset = false)
        {
            this.model.MChildAddRangeLazy(this, child, property, values, reset);
        }
        public void MChildAddRangeLazy(ModelProperty child, ModelProperty property, IEnumerable<Func<object>> values, bool reset = false)
        {
            this.model.MChildAddRangeLazy(this, child, property, values, reset);
        }
        public void MChildClearLazy(ModelProperty child, bool reset = false)
        {
            this.model.MChildClearLazy(this, child, reset);
        }
        public void MChildClearLazy(ModelProperty child, ModelProperty property, bool reset = false)
        {
            this.model.MChildClearLazy(this, child, property, reset);
        }
        public void MRemove(ModelProperty property, object value, bool removeAll = false, bool reset = false)
        {
            this.model.MRemove(this, property, value, removeAll, reset);
        }
        public void MUnset(ModelProperty property, bool reset = false)
        {
            this.model.MUnset(this, property, reset);
        }

        RedModel ISymbol.MModel
        {
            get { return this.MModel; }
        }

        ISymbol ISymbol.MParent
        {
            get { return this.MParent; }
        }

        IReadOnlyList<ISymbol> ISymbol.MChildren
        {
            get { return this.MChildren; }
        }
    }

    public class LazyChildBuilderBase
    {
        public LazyChildBuilderBase(MutableSymbolBase parent, ModelProperty property)
        {
            this.MParent = parent;
            this.MProperty = property;
        }

        public MutableSymbolBase MParent { get; private set; }
        public ModelProperty MProperty { get; private set; }
    }

}
