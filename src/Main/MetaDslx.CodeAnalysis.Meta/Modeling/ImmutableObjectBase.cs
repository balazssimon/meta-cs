using MetaDslx.Languages.Meta.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling
{
    public abstract class ImmutableObjectBase : ImmutableObject
    {
        private ObjectId id;
        private ImmutableModel model;

        protected ImmutableObjectBase(ObjectId id, ImmutableModel model)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            this.id = id;
            this.model = model;
        }

        public MutableObject ToMutable()
        {
            MutableModel mutableModel = this.model.ToMutable();
            return mutableModel.GetObject(this);
        }

        public MutableObject ToMutable(MutableModel mutableModel)
        {
            if (mutableModel == null) throw new ArgumentNullException(nameof(mutableModel));
            return mutableModel.GetObject(this);
        }

        public ObjectId MId { get { return this.id; } }

        public abstract IMetaModel MMetaModel { get; }
        public abstract MetaClass MMetaClass { get; }

        public ImmutableModel MModel { get { return this.model; } }
        IModel IModelObject.MModel { get { return this.MModel; } }
        public ImmutableObject MParent { get { return this.model.MParent(this.id); } }
        public ImmutableModelList<ImmutableObject> MChildren { get { return this.model.MChildren(this.id); } }

        IModelObject IModelObject.MParent { get { return this.model.MParent(this.id); } }
        IReadOnlyList<IModelObject> IModelObject.MChildren { get { return this.model.MChildren(this.id); } }

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
                ModelProperty nameProperty = this.id.Descriptor.NameProperty;
                if (nameProperty != null && this.model.MHasConcreteValue(this.id, nameProperty))
                {
                    object nameObj = this.MGet(nameProperty);
                    if (nameObj == null) return null;
                    else return nameObj.ToString();
                }
                return null;
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

        public bool MHasDefaultValue(ModelProperty property)
        {
            return this.model.MHasDefaultValue(this.id, property);
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

        public bool Equals(IModelObject other)
        {
            return other != null && this.id.Equals(other.MId);
        }

        public override bool Equals(object obj)
        {
            if (obj is IModelObject other)
            {
                return this.Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public override string ToString()
        {
            string metaType = this.id.DisplayTypeName;
            string name = this.MName;
            if (name != null) return $"[{metaType}] {name}";
            else return $"[{metaType}]";
        }

    }

}
