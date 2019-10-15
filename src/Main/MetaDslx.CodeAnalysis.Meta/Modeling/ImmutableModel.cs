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
                foreach (var sid in this.Green.StrongObjects)
                {
                    yield return this.GetExistingObject(sid);
                }
            }
        }

        IEnumerable<IModelObject> IModel.Objects => this.Objects;

        IModelGroup IModel.ModelGroup => this.ModelGroup;

        internal ImmutableObject GetExistingObject(ObjectId sid)
        {
            if (sid == null) return null;
            if (this.group != null)
            {
                if (this.readOnly) return this.group.GetExistingReferenceObject(this.id, sid);
                else return this.group.GetExistingModelObject(this.id, sid);
            }
            else
            {
                return this.objects.GetValue(sid, key => key.CreateImmutable(this));
            }
        }

        internal ImmutableObject ResolveObject(ObjectId sid)
        {
            if (this.group != null)
            {
                return this.group.ResolveObject(sid);
            }
            else
            {
                if (!this.ContainsObject(sid)) return null;
                return this.GetExistingObject(sid);
            }
        }

        internal ImmutableObject GetObject(ObjectId sid)
        {
            if (sid == null) return null;
            if (!this.ContainsObject(sid)) return null;
            return this.GetExistingObject(sid);
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

        internal bool ContainsObject(ObjectId sid)
        {
            if (sid == null) return false;
            return this.Green.Objects.ContainsKey(sid);
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

        internal object ToRedValue(object value)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue();
                if (value is ImmutableObjectBase)
                {
                    return this.ResolveObject(((ImmutableObjectBase)value).MId);
                }
                else if (value is MutableObjectBase)
                {
                    return this.ResolveObject(((MutableObjectBase)value).MId);
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


        private object GetGreenValue(ObjectId sid, ModelProperty property)
        {
            GreenObject green;
            if (this.green.Objects.TryGetValue(sid, out green))
            {
                object greenValue;
                ModelPropertyInfo mpi = sid.Descriptor.GetPropertyInfo(property);
                if (mpi != null && mpi.RepresentingProperty != null) property = mpi.RepresentingProperty;
                if (green.Properties.TryGetValue(property, out greenValue))
                {
                    return greenValue;
                }
            }
            return GreenObject.Unassigned;
        }

        internal object GetValue(ObjectId sid, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            var greenValue = this.GetGreenValue(sid, property);
            return this.ToRedValue(greenValue);
        }

        internal ImmutableModelSet<T> GetSet<T>(ObjectId sid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var greenValue = this.GetGreenValue(sid, property);
            if (greenValue is GreenList)
            {
                return ImmutableModelSet<T>.FromGreenList((GreenList)greenValue, this);
            }
            return ImmutableModelSet<T>.FromGreenList(property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique, this);
        }

        internal ImmutableModelList<T> GetList<T>(ObjectId sid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var greenValue = this.GetGreenValue(sid, property);
            if (greenValue is GreenList)
            {
                return ImmutableModelList<T>.FromGreenList((GreenList)greenValue, this);
            }
            return ImmutableModelList<T>.FromGreenList(property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique, this);
        }

        internal ImmutableObject MParent(ObjectId sid)
        {
            GreenObject green;
            if (this.green.Objects.TryGetValue(sid, out green))
            {
                return this.GetExistingObject(green.Parent);
            }
            return null;
        }

        internal ImmutableModelList<ImmutableObject> MChildren(ObjectId sid)
        {
            GreenObject green;
            if (this.green.Objects.TryGetValue(sid, out green))
            {
                return ImmutableModelList<ImmutableObject>.FromObjectIdList(green.Children, this);
            }
            return ImmutableModelList<ImmutableObject>.Empty;
        }

        internal ImmutableModelList<ImmutableObject> MGetImports(ObjectId sid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(sid))
            {
                if (prop.IsImport)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(sid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(sid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return ImmutableModelList<ImmutableObject>.FromGreenList(result, this);
        }

        internal ImmutableModelList<ImmutableObject> MGetBases(ObjectId sid)
        {
            GreenList result = this.CollectBases(sid);
            result = result.Remove(sid);
            return ImmutableModelList<ImmutableObject>.FromGreenList(result, this);
        }

        internal ImmutableModelList<ImmutableObject> MGetAllBases(ObjectId sid)
        {
            GreenList result = GreenList.EmptyUnique;
            this.CollectAllBases(sid, ref result);
            result = result.Remove(sid);
            return ImmutableModelList<ImmutableObject>.FromGreenList(result, this);
        }

        private GreenList CollectBases(ObjectId sid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(sid))
            {
                if (prop.IsBaseScope)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(sid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(sid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return result;
        }

        private void CollectAllBases(ObjectId sid, ref GreenList result)
        {
            if (sid == null) return;

            var oldResult = result;
            result = result.Add(sid);
            if (result == oldResult) return;

            var bases = this.CollectBases(sid);
            foreach (var item in bases)
            {
                this.CollectAllBases(item as ObjectId, ref result);
            }
        }

        internal ImmutableModelList<ImmutableObject> MGetMembers(ObjectId sid)
        {
            GreenList result = GreenList.EmptyUnique;
            foreach (var prop in this.MProperties(sid))
            {
                if (prop.CanResolve)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetGreenValue(sid, prop) as GreenList;
                        if (items != null)
                        {
                            result = result.AddRange(items);
                        }
                    }
                    else
                    {
                        var item = this.GetGreenValue(sid, prop);
                        result = result.Add(item);
                    }
                }
            }
            return ImmutableModelList<ImmutableObject>.FromGreenList(result, this);
        }

        internal IReadOnlyList<ModelProperty> MProperties(ObjectId sid)
        {
            ModelObjectDescriptor msi = sid.Descriptor;
            if (msi != null)
            {
                return msi.Properties;
            }
            return ImmutableArray<ModelProperty>.Empty;
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(ObjectId sid)
        {
            GreenObject green;
            if (this.green.Objects.TryGetValue(sid, out green))
            {
                return green.Properties.Keys.ToList();
            }
            return ImmutableList<ModelProperty>.Empty;
        }

        internal object MGet(ObjectId sid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return this.GetList<object>(sid, property);
            }
            else
            {
                return this.GetValue(sid, property);
            }
        }

        internal bool MHasConcreteValue(ObjectId sid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return true;
            }
            else
            {
                var greenValue = this.GetGreenValue(sid, property);
                return greenValue != GreenObject.Unassigned && !(greenValue is LazyValue) && !(greenValue is GreenDerivedValue);
            }
        }

        internal bool MIsSet(ObjectId sid, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return true;
            }
            else
            {
                var greenValue = this.GetGreenValue(sid, property);
                return greenValue != GreenObject.Unassigned;
            }
        }

        public override string ToString()
        {
            return this.Green.ToString();
        }
    }

}
