using MetaDslx.Languages.Meta.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    public abstract class ImmutableObjectPoolItem<TIntf, TImpl, TThis> : ObjectPoolItem<TIntf, TImpl, TThis>, ImmutableObject
        where TImpl : ImmutableObjectPoolItem<TIntf, TImpl, TThis>, TIntf, new()
        where TIntf : class, TThis
        where TThis : class, ImmutableObject
    {
        public ImmutableModel MModel => _This.MModel;

        public ImmutableObject MParent => _This.MParent;

        public ImmutableModelList<ImmutableObject> MChildren => _This.MChildren;

        public ImmutableObject MType => _This.MType;

        public IMetaModel MMetaModel => _This.MMetaModel;

        public MetaClass MMetaClass => _This.MMetaClass;

        public ObjectId MId => _This.MId;

        public string MName => _This.MName;

        public IReadOnlyList<ModelProperty> MProperties => _This.MProperties;

        public IReadOnlyList<ModelProperty> MAllProperties => _This.MAllProperties;

        IModel IModelObject.MModel => _This.MModel;

        IModelObject IModelObject.MType => _This.MType;

        IModelObject IModelObject.MParent => _This.MParent;

        IReadOnlyList<IModelObject> IModelObject.MChildren => _This.MChildren;

        public bool Equals(IModelObject other)
        {
            return _This.Equals(other);
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

        public MutableObject ToMutable()
        {
            return _This.ToMutable();
        }

        public MutableObject ToMutable(MutableModel mutableModel)
        {
            return _This.ToMutable(mutableModel);
        }
    }
}
