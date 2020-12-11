using MetaDslx.Languages.Meta.Model;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling.Internal
{
    public abstract class MutableObjectPoolItem<TIntf, TImpl, TThis> : ObjectPoolItem<TIntf, TImpl, TThis>, MutableObject
        where TImpl : MutableObjectPoolItem<TIntf, TImpl, TThis>, TIntf, new()
        where TIntf : class, TThis
        where TThis : class, MutableObject
    {
        public MutableModel MModel => _This.MModel;

        public MutableObject MParent => _This.MParent;

        public ImmutableModelList<MutableObject> MChildren => _This.MChildren;

        public MutableObject MType => _This.MType;

        public IMetaModel MMetaModel => _This.MMetaModel;

        public MetaClass MMetaClass => _This.MMetaClass;

        public ObjectId MId => _This.MId;

        public string MName => _This.MName;

        public IReadOnlyList<ModelProperty> MProperties => _This.MProperties;

        public IReadOnlyList<ModelProperty> MAllProperties => _This.MAllProperties;

        public bool MIsReadOnly => throw new NotImplementedException();

        IModel IModelObject.MModel => _This.MModel;

        IModelObject IModelObject.MType => _This.MType;

        MutableObject MutableObject.MType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        IModelObject IModelObject.MParent => _This.MParent;

        IReadOnlyList<IModelObject> IModelObject.MChildren => _This.MChildren;

        string MutableObject.MName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Equals(IModelObject other)
        {
            return _This.Equals(other);
        }

        public void MAdd(ModelProperty property, object value)
        {
            _This.MAdd(property, value);
        }

        public void MAddLazy(ModelProperty property, LazyValue value)
        {
            _This.MAddLazy(property, value);
        }

        public void MAddRange(ModelProperty property, IEnumerable<object> value)
        {
            _This.MAddRange(property, value);
        }

        public void MAddRangeLazy(ModelProperty property, IEnumerable<LazyValue> value)
        {
            _This.MAddRangeLazy(property, value);
        }

        public void MAttachProperty(ModelProperty property)
        {
            _This.MAttachProperty(property);
        }

        public object MGet(ModelProperty property)
        {
            return _This.MGet(property);
        }

        public IReadOnlyList<ModelProperty> MGetProperties(string name)
        {
            return _This.MGetProperties(name);
        }

        public ModelProperty MGetProperty(string name)
        {
            return _This.MGetProperty(name);
        }

        public T MGetReference<T>(ModelProperty property) where T : class
        {
            return _This.MGetReference<T>(property);
        }

        public T MGetValue<T>(ModelProperty property) where T : struct
        {
            return _This.MGetValue<T>(property);
        }

        public bool MHasConcreteValue(ModelProperty property)
        {
            return _This.MHasConcreteValue(property);
        }

        public bool MHasDefaultValue(ModelProperty property)
        {
            return _This.MHasDefaultValue(property);
        }

        public bool MIsSet(ModelProperty property)
        {
            return _This.MIsSet(property);
        }

        public void MMakeCreated()
        {
            _This.MMakeCreated();
        }

        public void MSet(ModelProperty property, object value)
        {
            _This.MSet(property, value);
        }

        public void MSetLazy(ModelProperty property, LazyValue value)
        {
            _This.MSetLazy(property, value);
        }

        public abstract void MInit();

        public virtual void MValidate(DiagnosticBag diagnostics, CancellationToken cancellationToken = default)
        {

        }

        public ImmutableObject ToImmutable()
        {
            return _This.ToImmutable();
        }

        public ImmutableObject ToImmutable(ImmutableModel immutableModel)
        {
            return _This.ToImmutable(immutableModel);
        }
    }

}
