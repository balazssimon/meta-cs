using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Modeling.Internal;
using Microsoft.CodeAnalysis;
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

        public abstract MetaModel MMetaModel { get; }
        public abstract MetaClass MMetaClass { get; }

        public MutableModel MModel { get { return this.model; } }
        IModel IModelObject.MModel { get { return this.MModel; } }
        public MutableObject MParent { get { return this.model.MParent(this.id); } }
        public ImmutableModelList<MutableObject> MChildren { get { return this.model.MChildren(this.id); } }

        IModelObject IModelObject.MParent { get { return this.model.MParent(this.id); } }
        IReadOnlyList<IModelObject> IModelObject.MChildren { get { return this.model.MChildren(this.id); } }

        public IReadOnlyList<IModelObject> MGetImports() { return this.model.MGetImports(this); }
        public IReadOnlyList<IModelObject> MGetBases() { return this.model.MGetBases(this); }
        public IReadOnlyList<IModelObject> MGetAllBases() { return this.model.MGetAllBases(this); }
        public IReadOnlyList<IModelObject> MGetMembers() { return this.model.MGetMembers(this); }

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
                if (nameProperty != null)
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
        public MutableObject MType
        {
            get
            {
                ModelProperty typeProperty = this.id.Descriptor.TypeProperty;
                if (typeProperty != null)
                {
                    object typeObj = this.MGet(typeProperty);
                    return typeObj as MutableObject;
                }
                return null;
            }
            set
            {
                ModelProperty typeProperty = this.id.Descriptor.TypeProperty;
                if (typeProperty != null)
                {
                    this.SetReference(typeProperty, value);
                }
            }
        }
        public bool MIsNamespace { get { return this.id.Descriptor.IsNamespace; } }
        public bool MIsType { get { return this.id.Descriptor.IsType; } }
        public bool MIsNamedType { get { return this.id.Descriptor.IsNamedType; } }

        public bool MIsScope { get { return this.id.Descriptor.IsScope; } }
        public bool MIsLocalScope { get { return this.id.Descriptor.IsLocalScope; } }

        IModelObject IModelObject.MType
        {
            get
            {
                return this.MType;
            }
        }

        protected abstract void MInit();

        public virtual void MValidate(DiagnosticBag diagnostics) { }

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

        public bool MHasConcreteValue(ModelProperty property)
        {
            return this.model.MHasConcreteValue(this.id, property);
        }

        public bool MIsSet(ModelProperty property)
        {
            return this.model.MIsSet(this.id, property);
        }

        public void MSet(ModelProperty property, object value)
        {
            if (property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotReassignCollectionProperty.ToDiagnosticWithNoLocation(property, this));
            this.model.SetValue(this.id, property, value, this.creating);
        }

        public void MSetLazy(ModelProperty property, LazyValue value)
        {
            if (property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotReassignCollectionProperty.ToDiagnostic(value.Location, property, this));
            this.model.SetLazyValue(this.id, property, value, this.creating);
        }

        public void MAdd(ModelProperty property, object value)
        {
            if (property.IsCollection)
            {
                this.model.AddItem(this.id, property, value, this.creating);
            }
            else
            {
                this.model.SetValue(this.id, property, value, this.creating);
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

        public void MAddRange(ModelProperty property, IEnumerable<object> values)
        {
            if (!property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty.ToDiagnosticWithNoLocation(property, this));
            this.model.AddItems(this.id, property, values, this.creating);
        }

        public void MAddRangeLazy(ModelProperty property, LazyValue values)
        {
            if (!property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty.ToDiagnostic(values.Location, property, this));
            this.model.AddLazyItems(this.id, property, values, this.creating);
        }

        public void MAddRangeLazy(ModelProperty property, IEnumerable<LazyValue> values)
        {
            if (!property.IsCollection) throw new ModelException(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty.ToDiagnosticWithNoLocation(property, this));
            this.model.AddLazyItems(this.id, property, values, this.creating);
        }

        public void MSetOrAdd(ModelProperty property, object value)
        {
            if (property.IsCollection)
            {
                this.model.AddItem(this.id, property, value, this.creating);
            }
            else
            {
                this.model.SetValue(this.id, property, value, this.creating);
            }
        }

        public void MSetOrAddLazy(ModelProperty property, LazyValue value)
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

        protected void SetValue<T>(ModelProperty property, T value)
            where T : struct
        {
            this.model.SetValue(this.id, property, value, this.creating);
        }

        protected T GetReference<T>(ModelProperty property)
            where T : class
        {
            return (T)this.model.GetValue(this.id, property);
        }

        protected void SetReference<T>(ModelProperty property, T value)
            where T : class
        {
            if (value is MutableObjectBase && ((MutableObjectBase)(object)value).model != this.model)
            {
                value = (T)this.model.ToRedValue(this.model.ToGreenValue(value));
            }
            this.model.SetValue(this.id, property, value, this.creating);
        }

        protected Func<T> GetLazyValue<T>(ModelProperty property)
            where T : struct
        {
            return (Func<T>)(object)this.model.GetLazyValue(this.id, property);
        }

        protected void SetLazyValue<T>(ModelProperty property, Func<T> value)
            where T : struct
        {
            this.model.SetLazyValue(this.id, property, LazyValue.Create((Func<object>)(object)value), this.creating);
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

        public override bool Equals(object obj)
        {
            if (obj is IModelObject other)
            {
                return this.id.Equals(other.MId);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public override string ToString()
        {
            string result = this.id.DisplayTypeName;
            string name = this.MName;
            if (name != null)
            {
                result = name + " (" + result + ")";
            }
            return result;
        }
    }

}
