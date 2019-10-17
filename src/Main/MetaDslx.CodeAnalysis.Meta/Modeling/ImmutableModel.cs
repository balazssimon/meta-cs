using MetaDslx.Modeling.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.Modeling
{
    public sealed class ImmutableModel : IModel
    {
        private bool readOnly;
        private WeakReference<MutableModel> mutableModel;

        // Used in models contained by a group:
        private ModelId id;
        private ImmutableModelGroup group;

        // Used in standalone models:
        private GreenModel green;
        private ConditionalWeakTable<ObjectId, ImmutableObject> objects;

        internal ImmutableModel(ModelId id, ImmutableModelGroup group, GreenModel green, bool readOnly, MutableModel mutableModel)
        {
            this.id = id;
            this.group = group;
            this.green = green;
            this.readOnly = readOnly;
            this.objects = null;
            this.mutableModel = new WeakReference<MutableModel>(mutableModel);
        }

        internal ImmutableModel(GreenModel green, MutableModel mutableModel)
        {
            this.id = green.Id;
            this.group = null;
            this.green = green;
            this.readOnly = false;
            this.objects = new ConditionalWeakTable<ObjectId, ImmutableObject>();
            this.mutableModel = new WeakReference<MutableModel>(mutableModel);
        }

        public ModelId Id { get { return this.id; } }
        public string Name { get { return this.green.Name; } }
        public ModelVersion Version { get { return this.green.Version; } }
        internal GreenModel Green { get { return this.green; } }
        public ImmutableModelGroup ModelGroup { get { return this.group; } }
        public IEnumerable<ImmutableObject> Objects
        {
            get
            {
                foreach (var oid in this.Green.StrongObjects)
                {
                    yield return this.GetExistingObject(oid);
                }
            }
        }

        IEnumerable<IModelObject> IModel.Objects => this.Objects;

        IModelGroup IModel.ModelGroup => this.ModelGroup;

        internal ImmutableObject GetExistingObject(ObjectId oid)
        {
            if (oid == null) return null;
            if (this.group != null)
            {
                if (this.readOnly) return this.group.GetExistingReferenceObject(this.id, oid);
                else return this.group.GetExistingModelObject(this.id, oid);
            }
            else
            {
                return this.objects.GetValue(oid, key => key.CreateImmutable(this));
            }
        }

        internal ImmutableObject ResolveObject(ObjectId oid)
        {
            if (this.group != null)
            {
                return this.group.ResolveObject(oid);
            }
            else
            {
                if (!this.ContainsObject(oid)) return null;
                return this.GetExistingObject(oid);
            }
        }

        internal ImmutableObject GetObject(ObjectId oid)
        {
            if (oid == null) return null;
            if (!this.ContainsObject(oid)) return null;
            return this.GetExistingObject(oid);
        }

        public ImmutableObject GetObject(MutableObject obj)
        {
            if (obj == null) return null;
            return this.GetObject(((MutableObjectBase)obj).MId);
        }

        public ImmutableObject GetObject(ImmutableObject obj)
        {
            if (obj == null) return null;
            return this.GetObject(((ImmutableObjectBase)obj).MId);
        }

        internal bool ContainsObject(ObjectId oid)
        {
            if (oid == null) return false;
            return this.Green.Objects.ContainsKey(oid);
        }

        public bool ContainsObject(MutableObject obj)
        {
            if (obj == null) return false;
            return this.ContainsObject(((MutableObjectBase)obj).MId);
        }

        public bool ContainsObject(ImmutableObject obj)
        {
            if (obj == null) return false;
            return this.ContainsObject(((ImmutableObjectBase)obj).MId);
        }

        public MutableModel ToMutable(bool createNew = false)
        {
            MutableModel result = null;
            if (!createNew)
            {
                if (this.mutableModel.TryGetTarget(out result) && result != null)
                {
                    return result;
                }
            }
            MutableModel newModel = null;
            if (this.group != null)
            {
                MutableModelGroup mutableGroup = this.group.ToMutable(createNew);
                newModel = mutableGroup.GetModel(this.green.Id);
            }
            else
            {
                newModel = new MutableModel(this.green, this);
            }
            return newModel;
        }

        internal object ToGreenValue(object value)
        {
            if (value is ImmutableObjectBase)
            {
                return ((ImmutableObjectBase)value).MId;
            }
            if (value is MutableObjectBase)
            {
                return ((MutableObjectBase)value).MId;
            }
            return value;
        }

        internal object ToRedValue(object value, ObjectId context)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue(this, context);
                if (redValue is ImmutableObjectBase)
                {
                    return this.ResolveObject(((ImmutableObjectBase)redValue).MId);
                }
                else if (redValue is MutableObjectBase)
                {
                    return this.ResolveObject(((MutableObjectBase)redValue).MId);
                }
                return redValue;
            }
            else if (value is LazyValue)
            {
                return null;
            }
            else if (value == GreenObject.Unassigned)
            {
                return null;
            }
            else if (value is GreenList)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value is ObjectId)
            {
                return this.ResolveObject((ObjectId)value);
            }
            else
            {
                return value;
            }
        }


        private object GetGreenValue(ObjectId oid, ModelProperty property)
        {
            GreenObject green;
            if (this.green.Objects.TryGetValue(oid, out green))
            {
                object greenValue;
                ModelPropertyInfo mpi = oid.Descriptor.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (green.Properties.TryGetValue(property, out greenValue))
                {
                    return greenValue;
                }
            }
            return GreenObject.Unassigned;
        }

        internal object GetValue(ObjectId oid, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            var greenValue = this.GetGreenValue(oid, property);
            return this.ToRedValue(greenValue, oid);
        }

        internal ImmutableModelSet<T> GetSet<T>(ObjectId oid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var greenValue = this.GetGreenValue(oid, property);
            if (greenValue is GreenList)
            {
                return ImmutableModelSet<T>.FromGreenList((GreenList)greenValue, this, oid);
            }
            return ImmutableModelSet<T>.FromGreenList(property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique, this, oid);
        }

        internal ImmutableModelList<T> GetList<T>(ObjectId oid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var greenValue = this.GetGreenValue(oid, property);
            if (greenValue is GreenList)
            {
                return ImmutableModelList<T>.FromGreenList((GreenList)greenValue, this, oid);
            }
            return ImmutableModelList<T>.FromGreenList(property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique, this, oid);
        }

        internal ImmutableObject MParent(ObjectId oid)
        {
            GreenObject green;
            if (this.green.Objects.TryGetValue(oid, out green))
            {
                return this.GetExistingObject(green.Parent);
            }
            return null;
        }

        internal ImmutableModelList<ImmutableObject> MChildren(ObjectId oid)
        {
            GreenObject green;
            if (this.green.Objects.TryGetValue(oid, out green))
            {
                return ImmutableModelList<ImmutableObject>.FromObjectIdList(green.Children, this);
            }
            return ImmutableModelList<ImmutableObject>.Empty;
        }

        internal ImmutableModelList<ImmutableObject> MGetImports(ObjectId oid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(oid))
            {
                if (prop.IsImport)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(oid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(oid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return ImmutableModelList<ImmutableObject>.FromGreenList(result, this, oid);
        }

        internal ImmutableModelList<ImmutableObject> MGetBases(ObjectId oid)
        {
            GreenList result = this.CollectBases(oid);
            result = result.Remove(oid);
            return ImmutableModelList<ImmutableObject>.FromGreenList(result, this, oid);
        }

        internal ImmutableModelList<ImmutableObject> MGetAllBases(ObjectId oid)
        {
            GreenList result = GreenList.EmptyUnique;
            this.CollectAllBases(oid, ref result);
            result = result.Remove(oid);
            return ImmutableModelList<ImmutableObject>.FromGreenList(result, this, oid);
        }

        private GreenList CollectBases(ObjectId oid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(oid))
            {
                if (prop.IsBaseScope)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(oid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(oid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return result;
        }

        private void CollectAllBases(ObjectId oid, ref GreenList result)
        {
            if (oid == null) return;

            var oldResult = result;
            result = result.Add(oid);
            if (result == oldResult) return;

            var bases = this.CollectBases(oid);
            foreach (var item in bases)
            {
                this.CollectAllBases(item as ObjectId, ref result);
            }
        }

        internal ImmutableModelList<ImmutableObject> MGetMembers(ObjectId oid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(oid))
            {
                if (prop.CanResolve)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(oid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(oid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return ImmutableModelList<ImmutableObject>.FromGreenList(result, this, oid);
        }

        internal IReadOnlyList<ModelProperty> MProperties(ObjectId oid)
        {
            ModelObjectDescriptor msi = oid.Descriptor;
            if (msi != null)
            {
                return msi.Properties;
            }
            return ImmutableArray<ModelProperty>.Empty;
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(ObjectId oid)
        {
            GreenObject green;
            if (this.green.Objects.TryGetValue(oid, out green))
            {
                return green.Properties.Keys.ToList();
            }
            return ImmutableList<ModelProperty>.Empty;
        }

        internal object MGet(ObjectId oid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return this.GetList<object>(oid, property);
            }
            else
            {
                return this.GetValue(oid, property);
            }
        }

        internal bool MHasConcreteValue(ObjectId oid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return true;
            }
            else
            {
                var greenValue = this.GetGreenValue(oid, property);
                return greenValue != GreenObject.Unassigned && !(greenValue is LazyValue) && !(greenValue is GreenDerivedValue);
            }
        }

        internal bool MIsSet(ObjectId oid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return true;
            }
            else
            {
                var greenValue = this.GetGreenValue(oid, property);
                return greenValue != GreenObject.Unassigned;
            }
        }

        public override string ToString()
        {
            return this.Green.ToString();
        }
    }

}
