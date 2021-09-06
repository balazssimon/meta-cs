using MetaDslx.Languages.Meta.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling
{
    public abstract class MutableObjectBase : MutableObject
    {
        private bool creating;
        private ObjectId id;
        private MutableModel model;

        protected MutableObjectBase(ObjectId id, MutableModel model, bool creating)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            this.id = id;
            this.model = model;
            this.creating = creating;
        }

        public ImmutableObject ToImmutable()
        {
            ImmutableModel immutableModel = this.model.ToImmutable();
            return immutableModel.GetObject(this);
        }

        public ImmutableObject ToImmutable(ImmutableModel immutableModel)
        {
            if (immutableModel == null) throw new ArgumentNullException(nameof(immutableModel));
            return immutableModel.GetObject(this);
        }

        public ObjectId MId { get { return this.id; } }
        internal bool MIsBeingCreated { get { return this.creating; } }
        public bool MIsReadOnly { get { return this.model.IsReadOnly; } }

        public abstract IMetaModel MMetaModel { get; }
        public abstract MetaClass MMetaClass { get; }

        public MutableModel MModel { get { return this.model; } }
        IModel IModelObject.MModel { get { return this.MModel; } }
        public MutableObject MParent { get { return this.model.MParent(this.id); } }
        public ImmutableModelList<MutableObject> MChildren { get { return this.model.MChildren(this.id); } }

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
        public void MAttachProperty(ModelProperty property)
        {
            this.model.MAttachProperty(this.id, property);
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
            set
            {
                ModelProperty nameProperty = this.id.Descriptor.NameProperty;
                if (nameProperty != null)
                {
                    this.SetReference(nameProperty, value);
                }
            }
        }

        protected abstract void MInit();

        internal void MCallInit()
        {
            this.MInit();
        }

        public void MMakeCreated()
        {
            this.creating = false;
        }

        public object MGet(ModelProperty property)
        {
            return this.model.MGet(this, property);
        }

        public object MGetTag(ModelProperty property)
        {
            return this.model.MGetTag(this, property);
        }

        public object MGetTag(ModelProperty property, object value)
        {
            return this.model.MGetTag(this, property, value);
        }

        public bool MHasDefaultValue(ModelProperty property)
        {
            return this.model.MHasDefaultValue(this.id, property);
        }

        public bool MHasConcreteValue(ModelProperty property)
        {
            return this.model.MHasConcreteValue(this.id, property);
        }

        public bool MIsSet(ModelProperty property)
        {
            return this.model.MIsSet(this.id, property);
        }

        public void MSet(ModelProperty property, object value, object tag = null)
        {
            if (property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotReassignCollectionProperty.ToDiagnosticWithNoLocation(property, this));
            this.model.SetValue(this.id, property, value, tag, this.creating);
        }

        public void MSetLazy(ModelProperty property, LazyValue value)
        {
            if (property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotReassignCollectionProperty.ToDiagnostic(value.GetLocation(), property, this));
            this.model.SetLazyValue(this.id, property, value, this.creating);
        }

        public void MAdd(ModelProperty property, object value, object tag = null)
        {
            if (property.IsCollection)
            {
                this.model.AddItem(this.id, property, value, tag, this.creating);
            }
            else
            {
                this.model.SetValue(this.id, property, value, tag, this.creating);
            }
        }

        public void MAddLazy(ModelProperty property, LazyValue value)
        {
            if (property.IsCollection)
            {
                this.model.AddLazyItem(this.id, property, value, this.creating);
            }
            else
            {
                this.model.SetLazyValue(this.id, property, value, this.creating);
            }
        }

        public void MAddRange(ModelProperty property, IEnumerable<object> values, object tag = null)
        {
            if (!property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty.ToDiagnosticWithNoLocation(property, this));
            this.model.AddItems(this.id, property, values, tag, this.creating);
        }

        public void MAddRangeLazy(ModelProperty property, IEnumerable<LazyValue> values)
        {
            if (!property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty.ToDiagnosticWithNoLocation(property, this));
            this.model.AddLazyItems(this.id, property, values, this.creating);
        }

        public T MGetValue<T>(ModelProperty property) where T : struct
        {
            return this.GetValue<T>(property);
        }

        public T MGetReference<T>(ModelProperty property) where T : class
        {
            return this.GetReference<T>(property);
        }

        protected T GetValue<T>(ModelProperty property)
            where T : struct
        {
            object valueObj = this.model.GetValue(this.id, property);
            if (valueObj == null) return default(T);
            else return (T)valueObj;
        }

        protected void SetValue<T>(ModelProperty property, T value, object tag = null)
            where T : struct
        {
            this.model.SetValue(this.id, property, value, tag, this.creating);
        }

        protected T GetReference<T>(ModelProperty property)
            where T : class
        {
            return (T)this.model.GetValue(this.id, property);
        }

        protected void SetReference<T>(ModelProperty property, T value, object tag = null)
            where T : class
        {
            var resolvedValue = value;
            if (value is MutableObjectBase mutableObj && mutableObj.model != this.model)
            {
                resolvedValue = (T)this.model.ToRedValue(MutableModel.ToGreenValue(value, null), mutableObj.id, property);
                if (value != null && resolvedValue == null)
                {
                    throw new ModelException(ModelErrorCode.ERR_CannotResolveModelObject.ToDiagnostic(Microsoft.CodeAnalysis.Location.None, value.ToString(), this.model.ToString(), mutableObj.model.ToString()));
                }
            }
            this.model.SetValue(this.id, property, value, tag, this.creating);
        }

        protected Func<T> GetLazyValue<T>(ModelProperty property)
            where T : struct
        {
            return (Func<T>)(object)this.model.GetLazyValue(this.id, property);
        }

        protected void SetLazyValue<T>(ModelProperty property, Func<T> value)
            where T : struct
        {
            this.model.SetLazyValue(this.id, property, LazyValue.Create(value), this.creating);
        }

        protected void SetLazyValue<TContext, T>(ModelProperty property, Func<TContext, T> value)
            where TContext : IModelObject
            where T : struct
        {
            this.model.SetLazyValue(this.id, property, LazyValue.Create(value), this.creating);
        }

        protected void SetLazyValue<TContext, T>(ModelProperty property, Func<TContext, IEnumerable<T>> value)
            where TContext : IModelObject
            where T : struct
        {
            this.model.SetLazyValue(this.id, property, LazyValue.CreateMulti(value), this.creating);
        }

        protected void SetLazyValue<TImmutableContext, TMutableContext, TImmutable, TMutable>(ModelProperty property, Func<TImmutableContext, TImmutable> immutableValue, Func<TMutableContext, TMutable> mutableValue)
            where TImmutableContext : ImmutableObject
            where TMutableContext : MutableObject
            where TImmutable : struct
            where TMutable : struct
        {
            this.model.SetLazyValue(this.id, property, LazyValue.Create(immutableValue, mutableValue), this.creating);
        }

        protected void SetLazyValue<TImmutableContext, TMutableContext, TImmutable, TMutable>(ModelProperty property, Func<TImmutableContext, IEnumerable<TImmutable>> immutableValue, Func<TMutableContext, IEnumerable<TMutable>> mutableValue)
            where TImmutableContext : ImmutableObject
            where TMutableContext : MutableObject
            where TImmutable : struct
            where TMutable : struct
        {
            this.model.SetLazyValue(this.id, property, LazyValue.CreateMulti(immutableValue, mutableValue), this.creating);
        }

        protected Func<T> GetLazyReference<T>(ModelProperty property)
            where T : class
        {
            return (Func<T>)this.model.GetLazyValue(this.id, property);
        }

        protected void SetLazyReference<T>(ModelProperty property, Func<T> value)
            where T : class
        {
            this.model.SetLazyValue(this.id, property, LazyValue.Create(value), this.creating);
        }

        protected void SetLazyReference<TContext, T>(ModelProperty property, Func<TContext, T> value)
            where TContext : IModelObject
            where T : class
        {
            this.model.SetLazyValue(this.id, property, LazyValue.Create(value), this.creating);
        }

        protected void SetLazyReference<TContext, T>(ModelProperty property, Func<TContext, IEnumerable<T>> value)
            where TContext : IModelObject
            where T : class
        {
            this.model.SetLazyValue(this.id, property, LazyValue.CreateMulti(value), this.creating);
        }

        protected void SetLazyReference<TImmutableContext, TMutableContext, TImmutable, TMutable>(ModelProperty property, Func<TImmutableContext, TImmutable> immutableValue, Func<TMutableContext, TMutable> mutableValue)
            where TImmutableContext : ImmutableObject
            where TMutableContext : MutableObject
            where TImmutable : class
            where TMutable : class
        {
            this.model.SetLazyValue(this.id, property, LazyValue.Create(immutableValue, mutableValue), this.creating);
        }

        protected void SetLazyReference<TImmutableContext, TMutableContext, TImmutable, TMutable>(ModelProperty property, Func<TImmutableContext, IEnumerable<TImmutable>> immutableValue, Func<TMutableContext, IEnumerable<TMutable>> mutableValue)
            where TImmutableContext : ImmutableObject
            where TMutableContext : MutableObject
            where TImmutable : class
            where TMutable : class
        {
            this.model.SetLazyValue(this.id, property, LazyValue.CreateMulti(immutableValue, mutableValue), this.creating);
        }

        protected MutableModelSet<T> GetSet<T>(ModelProperty property, ref MutableModelSet<T> value)
        {
            MutableModelSet<T> result = value;
            if (result == null)
            {
                result = this.model.GetSet<T>(this, property);
                result = Interlocked.CompareExchange(ref value, result, null) ?? result;
            }
            return result;
        }

        protected MutableModelList<T> GetList<T>(ModelProperty property, ref MutableModelList<T> value)
        {
            MutableModelList<T> result = value;
            if (result == null)
            {
                result = this.model.GetList<T>(this, property);
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
