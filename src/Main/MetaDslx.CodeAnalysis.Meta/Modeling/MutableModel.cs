using MetaDslx.CodeAnalysis;
using MetaDslx.Modeling.Internal;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling
{
    public sealed class MutableModel : IModel
    {
        private ModelMetadata metadata;
        private bool readOnly;

        // Used in models contained by a group:
        private ModelId id;
        private MutableModelGroup group;

        // Used in standalone models:
        private GreenModel green;
        private ConditionalWeakTable<ObjectId, MutableObject> objects;
        private ThreadLocal<GreenModelUpdater> updater;
        private WeakReference<ImmutableModel> immutableModel;

        public MutableModel(string name = null, ModelVersion version = default, string uri = null, string prefix = null, string namespaceName = null, Func<MutableModel, ModelFactoryFlags, IModelFactory> factoryConstructor = null)
            : this(new GreenModel(new ModelId(), new GreenMetadata(namespaceName, name, version, uri, prefix, factoryConstructor)))
        {
            this.immutableModel = new WeakReference<ImmutableModel>(null);
        }

        internal MutableModel(ModelId id, MutableModelGroup group, bool readOnly, GreenMetadata greenMetadata)
        {
            this.id = id;
            this.metadata = new ModelMetadata(this, greenMetadata);
            this.group = group;
            this.green = null;
            this.updater = null;
            this.readOnly = readOnly;
            this.objects = null;
            this.immutableModel = null;
        }

        internal MutableModel(GreenModel green, ImmutableModel immutableModel)
            : this(green)
        {
            this.immutableModel = new WeakReference<ImmutableModel>(immutableModel);
        }

        private MutableModel(GreenModel green)
        {
            if (green == null) green = new GreenModel(new ModelId(), new GreenMetadata(ImmutableArray<string>.Empty, default, default, default, default, null));
            this.id = green.Id;
            this.metadata = new ModelMetadata(this, green.Metadata);
            this.group = null;
            this.green = green;
            this.updater = new ThreadLocal<GreenModelUpdater>();
            this.readOnly = false;
            this.objects = new ConditionalWeakTable<ObjectId, MutableObject>();
        }

        public ModelId Id => this.id;
        public ModelMetadata Metadata => this.metadata;

        public string Name
        {
            get
            {
                return this.Green.Metadata.Name;
            }
            set
            {
                GreenModelUpdateContext ctx = null;
                try
                {
                    do
                    {
                        ctx = this.BeginUpdate();
                        ctx.Updater.SetName(this.id, value);
                    } while (!this.EndUpdate(ctx));
                }
                finally
                {
                    this.FinalizeUpdate(ctx);
                }
            }
        }

        public ModelVersion Version
        {
            get
            {
                return this.Green.Metadata.Version;
            }
            set
            {
                GreenModelUpdateContext ctx = null;
                try
                {
                    do
                    {
                        ctx = this.BeginUpdate();
                        ctx.Updater.SetVersion(this.id, value);
                    } while (!this.EndUpdate(ctx));
                }
                finally
                {
                    this.FinalizeUpdate(ctx);
                }
            }
        }

        internal GreenModel Green
        {
            get
            {
                if (this.group != null)
                {
                    GreenModelGroup greenGroup = this.group.Green;
                    GreenModel result;
                    if (this.readOnly)
                    {
                        if (greenGroup.References.TryGetValue(this.id, out result)) return result;
                    }
                    else
                    {
                        if (greenGroup.Models.TryGetValue(this.id, out result)) return result;
                    }
                    return null;
                }
                else
                {
                    GreenModelUpdater updater = this.updater.Value;
                    if (updater != null) return updater.Model;
                    else return this.green;
                }
            }
        }
        internal GreenModelUpdater Updater
        {
            get
            {
                if (this.group != null) return this.group.Updater;
                else return this.updater.Value;
            }
        }
        public bool IsReadOnly { get { return this.readOnly; } }
        internal bool AllowMetaConstants { get; set; }
        public MutableModelGroup ModelGroup { get { return this.group; } }
        public IEnumerable<MutableObject> Objects
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

        internal MutableObject GetExistingObject(ObjectId oid)
        {
            if (oid == null) return null;
            if (this.group != null)
            {
                if (this.readOnly) return this.group.GetExistingReferenceObject(this.id, oid);
                else return this.group.GetExistingModelObject(this.id, oid);
            }
            else
            {
                return this.objects.GetValue(oid, key => key.CreateMutable(this, false));
            }
        }

        internal void RegisterObject(ObjectId oid, MutableObject obj)
        {
            if (this.group != null)
            {
                this.group.RegisterObject(oid, obj);
            }
            else
            {
                this.objects.Add(oid, obj);
            }
        }

        public MutableObject ResolveObject(ObjectId oid)
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

        internal MutableObject GetObject(ObjectId oid)
        {
            if (oid == null) return null;
            if (!this.ContainsObject(oid)) return null;
            return this.GetExistingObject(oid);
        }

        public MutableObject GetObject(MutableObject obj)
        {
            if (obj == null) return null;
            return this.GetObject(((MutableObjectBase)obj).MId);
        }

        public MutableObject GetObject(ImmutableObject obj)
        {
            if (obj == null) return null;
            return this.GetObject(((ImmutableObjectBase)obj).MId);
        }

        internal bool ContainsObject(ObjectId oid)
        {
            if (oid == null) return false;
            GreenModelUpdater updater = this.Updater;
            if (updater != null)
            {
                return updater.ContainsObject(oid);
            }
            else
            {
                return this.Green.Objects.ContainsKey(oid);
            }
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

        public bool RemoveObject(MutableObject obj)
        {
            if (obj == null) return false;
            bool result = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    result = ctx.Updater.RemoveObject(this.id, ((MutableObjectBase)obj).MId);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return result;
        }

        public void MergeObjects(MutableObject targetObject, MutableObject sourceObject)
        {
            if (targetObject == sourceObject) return;
            if (targetObject.MMetaClass != sourceObject.MMetaClass) throw new ModelException(ModelErrorCode.ERR_CannotMergeDifferentObjects.ToDiagnosticWithNoLocation(sourceObject, targetObject, sourceObject.MId.Descriptor.MutableType, targetObject.MId.Descriptor.MutableType));
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.MergeObjects(this.id, ((ImmutableObjectBase)targetObject).MId, ((ImmutableObjectBase)sourceObject).MId);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal MutableObjectBase CreateObject(ObjectId oid, bool weakReference)
        {
            Debug.Assert(oid != null);
            Debug.Assert(!this.ContainsObject(oid));
            MutableObjectBase result = null;
            result = oid.CreateMutable(this, true);
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.AddObject(this.id, oid, weakReference);
                } while (!this.EndUpdate(ctx));
                this.RegisterObject(oid, result);
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return result;
        }

        public ImmutableModel ToImmutable(bool evaluateLazyValues = true, CancellationToken cancellationToken = default)
        {
            ImmutableModel result;
            if (this.group != null)
            {
                ImmutableModelGroup immutableGroup = this.group.ToImmutable(evaluateLazyValues, cancellationToken);
                if (immutableGroup != null)
                {
                    if (this.readOnly)
                    {
                        result = immutableGroup.GetReference(this.id);
                    }
                    else
                    {
                        result = immutableGroup.GetModel(this.id);
                    }
                    return result;
                }
            }
            else
            {
                if (evaluateLazyValues) this.EvaluateLazyValues(cancellationToken);
                GreenModel currentGreen = this.Green;
                if (this.immutableModel.TryGetTarget(out result) && result != null && result.Green == currentGreen)
                {
                    return result;
                }
                else
                {
                    result = new ImmutableModel(currentGreen, this);
                    Interlocked.Exchange(ref this.immutableModel, new WeakReference<ImmutableModel>(result));
                    return result;
                }
            }
            return null;
        }

        internal GreenModelUpdateContext BeginUpdate()
        {
            if (this.group != null)
            {
                return this.group.BeginUpdate();
            }
            else
            {
                GreenModelUpdater updater = this.updater.Value;
                if (updater != null)
                {
                    return new GreenModelUpdateContext(false, updater, this.green);
                }
                else
                {
                    GreenModel green = this.green;
                    updater = new GreenModelUpdater(green, this);
                    this.updater.Value = updater;
                    return new GreenModelUpdateContext(true, updater, green);
                }
            }
        }

        internal bool EndUpdate(GreenModelUpdateContext context)
        {
            if (this.group != null)
            {
                return this.group.EndUpdate(context);
            }
            else
            {
                if (context.NewUpdater)
                {
                    this.updater.Value = null;
                    return Interlocked.CompareExchange(ref this.green, context.Updater.Model, context.OriginalModel) == context.OriginalModel;
                }
                else
                {
                    return true;
                }
            }
        }

        internal void FinalizeUpdate(GreenModelUpdateContext context)
        {
            if (this.group != null)
            {
                this.group.FinalizeUpdate(context);
            }
            else
            {
                if (context != null && context.NewUpdater)
                {
                    this.updater.Value = null;
                }
            }
        }

        internal static object ToGreenValue(object value, object tag)
        {
            if (tag != null)
            {
                if (value is MutableObjectBase mob)
                {
                    return new GreenValueWithTag(mob.MId, tag);
                }
                else if (value is ImmutableObjectBase iob)
                {
                    return new GreenValueWithTag(iob.MId, tag);
                }
                return new GreenValueWithTag(value, tag);
            }
            else
            {
                if (value is MutableObjectBase mob)
                {
                    return mob.MId;
                }
                else if (value is ImmutableObjectBase iob)
                {
                    return iob.MId;
                }
                return value;
            }
        }

        internal object ToRedValue(object value, ObjectId context, ModelProperty property)
        {
            if (value is GreenDerivedValue)
            {
                object redValue = ((GreenDerivedValue)value).CreateRedValue(this, context);
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
                Debug.Assert(false);
                return null;
            }
            else if (value is GreenList)
            {
                Debug.Assert(false);
                return null;
            }
            else if (value == GreenObject.Unassigned)
            {
                return property?.DefaultValue;
            }
            if (value is GreenValueWithTag taggedValue)
            {
                value = taggedValue.Value;
            }
            if (value is ObjectId)
            {
                return this.ResolveObject((ObjectId)value);
            }
            else
            {
                return value;
            }
        }

        public void EvaluateLazyValues(CancellationToken cancellationToken = default)
        {
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.EvaluateLazyValues(cancellationToken);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        public void ExecuteTransaction(Action<CancellationToken> transaction, CancellationToken cancellationToken = default)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    ctx = this.BeginUpdate();
                    transaction(cancellationToken);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal object GetValue(ObjectId oid, ModelProperty property)
        {
            object value = null;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    value = ctx.Updater.GetValue(this.id, oid, slot, true);
                } while (!this.EndUpdate(ctx));
                value = this.ToRedValue(value, oid, property);
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return value;
        }

        internal object MGetTag(MutableObjectBase obj, ModelProperty property)
        {
            object value = this.GetGreenValue(obj.MId, property);
            return GreenObject.ExtractTag(value);
        }

        internal object MGetTag(MutableObjectBase obj, ModelProperty property, object value)
        {
            if (property.IsCollection)
            {
                var greenValue = ToGreenValue(value, null);
                var greenList = this.GetGreenList(obj.MId, property);
                return greenList.GetTagOf(greenValue);
            }
            else
            {
                var greenValue = this.GetGreenValue(obj.MId, property);
                return GreenObject.ExtractTag(greenValue);
            }
        }

        private object GetGreenValue(ObjectId oid, ModelProperty property)
        {
            GreenObject green;
            if (this.Green.Objects.TryGetValue(oid, out green))
            {
                object greenValue;
                var slot = oid.Descriptor.GetSlot(property);
                if (green.Slots.TryGetValue(slot, out greenValue))
                {
                    return greenValue;
                }
            }
            return GreenObject.Unassigned;
        }

        internal bool MHasDefaultValue(ObjectId oid, ModelProperty property)
        {
            var greenValue = this.GetGreenValue(oid, property);
            if (property.IsCollection)
            {
                return greenValue == GreenObject.Unassigned || (greenValue is GreenList greenList && greenList.Count == 0);
            }
            else
            {
                return greenValue == GreenObject.Unassigned || object.Equals(greenValue, property.DefaultValue);
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

        internal void SetValue<T>(ObjectId oid, ModelProperty property, T value, object tag, bool creating)
        {
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.SetValue(this.id, oid, slot, creating, ToGreenValue(value, tag));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal object GetLazyValue(ObjectId oid, ModelProperty property)
        {
            Debug.Assert(!property.IsCollection);
            var greenValue = this.GetGreenValue(oid, property);
            if (greenValue is LazyValue)
            {
                return ((LazyValue)greenValue).LazyConstructor;
            }
            return null;
        }

        internal void SetLazyValue(ObjectId oid, ModelProperty property, LazyValue value, bool creating)
        {
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.SetValue(this.id, oid, slot, creating, property.IsDerived ? (object)new GreenDerivedValue(value) : value);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal GreenList GetGreenList(ObjectId oid, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var greenValue = this.GetGreenValue(oid, property);
            if (greenValue is GreenList)
            {
                return (GreenList)greenValue;
            }
            return property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
        }

        internal GreenList GetGreenList(ObjectId oid, ModelProperty property, bool lazyEval)
        {
            Debug.Assert(property.IsCollection);
            object value = null;
            if (!lazyEval) return this.GetGreenList(oid, property);
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    value = ctx.Updater.GetValue(this.id, oid, slot, true);
                } while (!this.EndUpdate(ctx));
                GreenList result = value as GreenList;
                if (result == null) result = property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
                return result;
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal MutableModelSet<T> GetSet<T>(MutableObjectBase obj, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var slot = obj.MId.Descriptor.GetSlot(property);
            return MutableModelSet<T>.FromGreenList(obj, slot);
        }

        internal MutableModelList<T> GetList<T>(MutableObjectBase obj, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            var slot = obj.MId.Descriptor.GetSlot(property);
            return MutableModelList<T>.FromGreenList(obj, slot);
        }

        internal bool AddItem(ObjectId oid, ModelProperty property, object value, object tag, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, -1, ToGreenValue(value, tag));
                } while (!this.EndUpdate(ctx));
                return changed;
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        internal bool AddLazyItem(ObjectId oid, ModelProperty property, LazyValue value, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, -1, value);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool AddItems(ObjectId oid, ModelProperty property, IEnumerable<object> values, object tag, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    foreach (var value in values)
                    {
                        changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, -1, ToGreenValue(value, tag));
                    }
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool AddLazyItems(ObjectId oid, ModelProperty property, IEnumerable<LazyValue> values, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    foreach (var value in values)
                    {
                        changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, -1, value);
                    }
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool AddLazyItems(ObjectId oid, ModelProperty property, LazyValue values, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, -1, values);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool RemoveItem(ObjectId oid, ModelProperty property, object value, object tag, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.RemoveItem(this.id, oid, slot, creating, -1, false, ToGreenValue(value, tag));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool RemoveAllItems(ObjectId oid, ModelProperty property, object value, object tag, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.RemoveItem(this.id, oid, slot, creating, -1, true, ToGreenValue(value, tag));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool InsertItem(ObjectId oid, ModelProperty property, int index, object value, object tag, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, index, ToGreenValue(value, tag));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool ReplaceItem(ObjectId oid, ModelProperty property, int index, object value, object tag, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, oid, slot, creating, true, index, ToGreenValue(value, tag));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool RemoveItemAt(ObjectId oid, ModelProperty property, int index, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.RemoveItem(this.id, oid, slot, creating, index, false, null);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool ClearItems(ObjectId oid, ModelProperty property, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.ClearItems(this.id, oid, slot, creating);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool ClearLazyItems(ObjectId oid, ModelProperty property, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.ClearLazyItems(this.id, oid, slot, creating);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal MutableObject MParent(ObjectId oid)
        {
            GreenObject green;
            if (this.Green.Objects.TryGetValue(oid, out green))
            {
                return this.GetExistingObject(green.Parent);
            }
            return null;
        }

        internal ImmutableModelList<MutableObject> MChildren(ObjectId oid)
        {
            ImmutableList<ObjectId> children = ImmutableList<ObjectId>.Empty;
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    children = ctx.Updater.GetChildren(this.id, oid);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return ImmutableModelList<MutableObject>.FromObjectIdList(children, this);
        }

        internal IReadOnlyList<ModelProperty> MProperties(ObjectId oid)
        {
            ModelObjectDescriptor descriptor = oid.Descriptor;
            if (descriptor != null)
            {
                return descriptor.Properties;
            }
            return ImmutableArray<ModelProperty>.Empty;
        }

        internal IReadOnlyList<ModelProperty> MAllProperties(ObjectId oid)
        {
            GreenObject green;
            if (this.Green.Objects.TryGetValue(oid, out green))
            {
                return green.Slots.Keys.Select(s => s.EffectiveProperty).ToImmutableArray();
            }
            return ImmutableArray<ModelProperty>.Empty;
        }

        internal object MGet(MutableObjectBase obj, ModelProperty property)
        {
            if (property.IsCollection)
            {
                return this.GetList<object>(obj, property);
            }
            else
            {
                return this.GetValue(obj.MId, property);
            }
        }
        internal void MAttachProperty(ObjectId oid, ModelProperty property)
        {
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.AttachProperty(this.id, oid, property);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        public void PurgeWeakObjects()
        {
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.PurgeWeakObjects();
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is IModel other)
            {
                return this.id.Equals(other.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public override string ToString()
        {
            return this.Green.ToString();
        }
    }

}
