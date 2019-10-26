using MetaDslx.CodeAnalysis;
using MetaDslx.Modeling.Internal;
using Microsoft.CodeAnalysis;
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
        private bool readOnly;
        private WeakReference<ImmutableModel> immutableModel;

        // Used in models contained by a group:
        private ModelId id;
        private MutableModelGroup group;

        // Used in standalone models:
        private GreenModel green;
        private ConditionalWeakTable<ObjectId, MutableObject> objects;
        private ThreadLocal<GreenModelUpdater> updater;

        public MutableModel(string name = null, ModelVersion version = default)
            : this(new GreenModel(new ModelId(), name, version), null)
        {
        }

        internal MutableModel(ModelId id, MutableModelGroup group, bool readOnly, ImmutableModel immutableModel)
        {
            this.id = id;
            this.group = group;
            this.green = null;
            this.updater = null;
            this.readOnly = readOnly;
            this.objects = null;
            this.immutableModel = new WeakReference<ImmutableModel>(immutableModel);
        }

        internal MutableModel(GreenModel green, ImmutableModel immutableModel)
        {
            this.id = green.Id;
            this.group = null;
            this.green = green;
            this.updater = new ThreadLocal<GreenModelUpdater>();
            this.readOnly = false;
            this.objects = new ConditionalWeakTable<ObjectId, MutableObject>();
            this.immutableModel = new WeakReference<ImmutableModel>(immutableModel);
        }

        public ModelId Id
        {
            get { return this.Green.Id; }
        }

        public string Name
        {
            get
            {
                return this.Green.Name;
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
                return this.green.Version;
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
                ImmutableModelGroup immutableGroup = this.group.ToImmutable(evaluateLazyValues);
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

        public void ExecuteTransaction(Action transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    transaction();
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
                value = this.ToRedValue(value, oid);
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return value;
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
                return greenValue is GreenList greenList && greenList.Count == 0;
            }
            else
            {
                return greenValue == GreenObject.Unassigned || greenValue == property.DefaultValue;
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

        internal void SetValue<T>(ObjectId oid, ModelProperty property, T value, bool creating)
        {
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.SetValue(this.id, oid, slot, creating, this.ToGreenValue(value));
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
            return MutableModelSet<T>.FromGreenList(obj, property);
        }

        internal MutableModelList<T> GetList<T>(MutableObjectBase obj, ModelProperty property)
        {
            Debug.Assert(property.IsCollection);
            return MutableModelList<T>.FromGreenList(obj, property);
        }

        internal bool AddItem(ObjectId oid, ModelProperty property, object value, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, -1, this.ToGreenValue(value));
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

        internal bool AddItems(ObjectId oid, ModelProperty property, IEnumerable<object> values, bool creating)
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
                        changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, -1, this.ToGreenValue(value));
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

        internal bool RemoveItem(ObjectId oid, ModelProperty property, object value, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.RemoveItem(this.id, oid, slot, creating, -1, false, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool RemoveAllItems(ObjectId oid, ModelProperty property, object value, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.RemoveItem(this.id, oid, slot, creating, -1, true, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool InsertItem(ObjectId oid, ModelProperty property, int index, object value, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, oid, slot, creating, false, index, this.ToGreenValue(value));
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return changed;
        }

        internal bool ReplaceItem(ObjectId oid, ModelProperty property, int index, object value, bool creating)
        {
            bool changed = false;
            GreenModelUpdateContext ctx = null;
            try
            {
                var slot = oid.Descriptor.GetSlot(property);
                do
                {
                    ctx = this.BeginUpdate();
                    changed = ctx.Updater.AddItem(this.id, oid, slot, creating, true, index, this.ToGreenValue(value));
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

        internal IReadOnlyList<MutableObject> MGetImports(MutableObjectBase obj)
        {
            List<MutableObject> result = new List<MutableObject>();
            foreach (var prop in obj.MProperties)
            {
                if (prop.IsImport)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetList<MutableObject>(obj, prop);
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                if (item != null && !result.Contains(item))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        var item = this.GetValue(obj.MId, prop) as MutableObject;
                        if (item != null && !result.Contains(item))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        internal IReadOnlyList<MutableObject> MGetBases(MutableObjectBase obj)
        {
            List<MutableObject> result = new List<MutableObject>();
            this.CollectBases(obj, result);
            result.Remove(obj);
            return result;
        }

        internal IReadOnlyList<MutableObject> MGetAllBases(MutableObjectBase obj)
        {
            List<MutableObject> result = new List<MutableObject>();
            this.CollectAllBases(obj, result);
            result.Remove(obj);
            return result;
        }

        private void CollectBases(MutableObjectBase obj, List<MutableObject> result)
        {
            foreach (var prop in obj.MProperties)
            {
                if (prop.IsImport)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetList<MutableObject>(obj, prop);
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                if (item != null && !result.Contains(item))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        var item = this.GetValue(obj.MId, prop) as MutableObject;
                        if (item != null && !result.Contains(item))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
        }

        private void CollectAllBases(MutableObjectBase obj, List<MutableObject> result)
        {
            if (obj == null) return;

            if (!result.Contains(obj))
            {
                result.Add(obj);
                var bases = obj.MGetBases();
                foreach (var item in bases)
                {
                    this.CollectAllBases(item as MutableObjectBase, result);
                }
            }
        }

        internal IReadOnlyList<MutableObject> MGetMembers(MutableObjectBase obj)
        {
            List<MutableObject> result = new List<MutableObject>();
            foreach (var prop in obj.MProperties)
            {
                if (prop.CanResolve)
                {
                    if (prop.IsCollection)
                    {
                        var items = this.GetList<MutableObject>(obj, prop);
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                if (item != null && !result.Contains(item))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        var item = this.GetValue(obj.MId, prop) as MutableObject;
                        if (item != null && !result.Contains(item))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
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

        public void Validate(DiagnosticBag diagnostics)
        {
            foreach (var obj in this.Objects)
            {
                obj.MValidate(diagnostics);
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
