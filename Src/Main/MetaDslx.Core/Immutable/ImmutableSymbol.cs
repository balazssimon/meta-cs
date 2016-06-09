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
    public abstract class ImmutableSymbolBase : IImmutableSymbol
    {
        private SymbolId id;
        private ImmutableModel model;

        protected ImmutableSymbolBase(ImmutableModel model, SymbolId id)
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
            if (this.model != null)
            {
                if (default(T).Equals(value))
                {
                    object valueObj = this.green.GetValue(this.model.Green, this.id, property, false, false);
                    if (valueObj == null) value = default(T);
                    else value = (T)valueObj;
                }
                return value;
            }
            else
            {
                return value;
            }
        }

        protected T GetReference<T>(ModelProperty property, ref T value)
            where T : class
        {
            if (this.model != null)
            {
                T result = value;
                if (result == null)
                {
                    result = (T)this.green.GetValue(this.model.Green, this.id, property, false, false);
                    result = Interlocked.CompareExchange(ref value, result, null) ?? result;
                }
                return result;
            }
            else
            {
                return value;
            }
        }

        protected IImmutableModelList<T> GetList<T>(ModelProperty property, ref IImmutableModelList<T> value)
        {
            if (this.model != null)
            {
                IImmutableModelList<T> result = value;
                if (result == null)
                {
                    object greenObject = this.green.GetValue(this.model.Green, this.id, property, false, false);
                    if (greenObject is GreenList)
                    {
                        result = new ImmutableModelList<T>((GreenList)greenObject, this.model);
                    }
                    result = Interlocked.CompareExchange(ref value, result, null) ?? result;
                }
                return result;
            }
            else
            {
                IImmutableModelList<T> result = value;
                if (result == null)
                {
                    result = Interlocked.CompareExchange(ref value, ImmutableModelList<T>.Empty, null) ?? result;
                }
                return result;
            }
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        internal SymbolId Id { get { return this.id; } }

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
            if (value is MutableSymbolBase && ((MutableSymbolBase)(object)value).model != this.model)
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

        protected IMutableModelList<T> GetList<T>(ModelProperty property, ref IMutableModelList<T> value)
        {
            IMutableModelList<T> result = this.model.GetList(this, property, value);
            Interlocked.Exchange(ref value, result);
            return value;
        }

        public abstract object MMetaModel { get; }
        public abstract object MMetaClass { get; }

        public bool MIsReadOnly
        {
            get { return this.model.IsReadOnly; }
        }

        internal SymbolId Id { get { return this.id; } }
        
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
