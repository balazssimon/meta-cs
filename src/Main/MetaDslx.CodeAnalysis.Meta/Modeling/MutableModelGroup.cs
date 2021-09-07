using MetaDslx.Modeling.Internal;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Linq;

namespace MetaDslx.Modeling
{
    public sealed class MutableModelGroup : IModelGroup
    {
        private GreenModelGroup green;
        private ThreadLocal<GreenModelUpdater> updater;
        private WeakReference<ImmutableModelGroup> immutableModelGroup;
        private ConditionalWeakTable<ModelId, MutableModel> models;
        private ConditionalWeakTable<ObjectId, MutableObject> objects;

        public MutableModelGroup()
            : this(GreenModelGroup.Empty, null)
        {
        }

        internal MutableModelGroup(GreenModelGroup green, ImmutableModelGroup immutableModelGroup)
        {
            this.green = green;
            this.updater = new ThreadLocal<GreenModelUpdater>();
            this.immutableModelGroup = new WeakReference<ImmutableModelGroup>(immutableModelGroup);
            this.models = new ConditionalWeakTable<ModelId, MutableModel>();
            this.objects = new ConditionalWeakTable<ObjectId, MutableObject>();
        }

        internal GreenModelGroup Green
        {
            get
            {
                GreenModelUpdater updater = this.updater.Value;
                if (updater != null) return updater.Group;
                else return this.green;
            }
        }
        internal GreenModelUpdater Updater
        {
            get
            {
                return this.updater.Value;
            }
        }
        public IEnumerable<MutableModel> References
        {
            get
            {
                foreach (var mid in this.Green.References.Keys)
                {
                    yield return this.GetExistingReference(mid);
                }
            }
        }

        IEnumerable<IModel> IModelGroup.References => this.References;

        public IEnumerable<MutableModel> Models
        {
            get
            {
                foreach (var mid in this.Green.Models.Keys)
                {
                    yield return this.GetExistingModel(mid);
                }
            }
        }

        IEnumerable<IModel> IModelGroup.Models => this.Models;

        public IEnumerable<MutableObject> Objects
        {
            get
            {
                foreach (var mid in this.Green.Models.Keys)
                {
                    foreach (var mobj in this.GetExistingModel(mid).Objects)
                    {
                        yield return mobj;
                    }
                }
            }
        }

        IEnumerable<IModelObject> IModelGroup.Objects => this.Objects;

        private ImmutableModel GetImmutableReference(ModelId mid)
        {
            ImmutableModelGroup result;
            if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result.GetReference(mid);
            }
            return null;
        }

        private ImmutableModel GetImmutableModel(ModelId mid)
        {
            ImmutableModelGroup result;
            if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result.GetModel(mid);
            }
            return null;
        }

        private MutableModel GetExistingReference(ModelId mid)
        {
            return this.models.GetValue(mid, key => new MutableModel(key, this, true, this.Green.References[key].Metadata));
        }

        private MutableModel GetExistingModel(ModelId mid)
        {
            return this.models.GetValue(mid, key => new MutableModel(key, this, false, this.Green.Models[key].Metadata));
        }

        public MutableModel GetReference(ModelId mid)
        {
            if (mid == null || !this.Green.References.ContainsKey(mid)) return null;
            return this.GetExistingReference(mid);
        }

        public MutableModel GetModel(ModelId mid)
        {
            if (mid == null || !this.Green.Models.ContainsKey(mid)) return null;
            return this.GetExistingModel(mid);
        }


        internal MutableObject GetExistingReferenceObject(ModelId mid, ObjectId oid)
        {
            return this.objects.GetValue(oid, key => key.CreateMutable(this.GetExistingReference(mid), false));
        }

        internal MutableObject GetExistingModelObject(ModelId mid, ObjectId oid)
        {
            return this.objects.GetValue(oid, key => key.CreateMutable(this.GetExistingModel(mid), false));
        }

        internal void RegisterObject(ObjectId oid, MutableObject obj)
        {
            this.objects.Add(oid, obj);
        }

        internal MutableObject ResolveObject(ObjectId oid)
        {
            MutableObject result;
            if (this.objects.TryGetValue(oid, out result) && result != null)
            {
                return result;
            }
            foreach (var modelEntry in this.Green.Models)
            {
                if (modelEntry.Value.Objects.ContainsKey(oid))
                {
                    return this.GetExistingModelObject(modelEntry.Key, oid);
                }
            }
            foreach (var modelEntry in this.Green.References)
            {
                if (modelEntry.Value.Objects.ContainsKey(oid))
                {
                    return this.GetExistingReferenceObject(modelEntry.Key, oid);
                }
            }
            return null;
        }

        internal bool ContainsObject(ObjectId oid)
        {
            if (oid == null) return false;
            return this.Green.ContainsObject(oid);
        }

        public bool ContainsObject(ImmutableObject obj)
        {
            if (obj == null) return false;
            return this.ContainsObject(((ImmutableObjectBase)obj).MId);
        }

        public bool ContainsObject(MutableObject obj)
        {
            if (obj == null) return false;
            return this.ContainsObject(((MutableObjectBase)obj).MId);
        }

        public void EvaluateLazyValues(CancellationToken cancellationToken = default(CancellationToken))
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

        public ImmutableModelGroup ToImmutable(bool evaluateLazyValues = true, CancellationToken cancellationToken = default)
        {
            ImmutableModelGroup result;
            if (this.immutableModelGroup.TryGetTarget(out result) && result != null && result.Green == this.Green)
            {
                return result;
            }
            else
            {
                if (evaluateLazyValues) this.EvaluateLazyValues(cancellationToken);
                result = new ImmutableModelGroup(this.Green, this);
                Interlocked.Exchange(ref this.immutableModelGroup, new WeakReference<ImmutableModelGroup>(result));
                return result;
            }
        }

        internal GreenModelUpdateContext BeginUpdate()
        {
            GreenModelUpdater updater = this.updater.Value;
            if (updater != null)
            {
                return new GreenModelUpdateContext(false, updater, this.green);
            }
            else
            {
                GreenModelGroup green = this.green;
                updater = new GreenModelUpdater(green, this);
                this.updater.Value = updater;
                return new GreenModelUpdateContext(true, updater, green);
            }
        }

        internal bool EndUpdate(GreenModelUpdateContext context)
        {
            if (context.NewUpdater)
            {
                this.updater.Value = null;
                return Interlocked.CompareExchange(ref this.green, context.Updater.Group, context.OriginalModelGroup) == context.OriginalModelGroup;
            }
            else
            {
                return true;
            }
        }

        internal void FinalizeUpdate(GreenModelUpdateContext context)
        {
            if (context != null && context.NewUpdater)
            {
                this.updater.Value = null;
            }
        }

        private void AddReference(GreenModel reference)
        {
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    ctx.Updater.AddModelReference(reference);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
        }

        public void AddReference(IEnumerable<IModel> models)
        {
            foreach (var model in models)
            {
                if (model is ImmutableModel immutableModel) this.AddReference(immutableModel);
                else if (model is MutableModel mutableModel) this.AddReference(mutableModel);
                else throw new ArgumentException("The model must be either an ImmutableModel or a MutableModel.", nameof(models));
            }
        }

        public void AddReference(params IModel[] models)
        {
            this.AddReference(models.ToList());
        }

        public void AddReference(IEnumerable<IModelGroup> modelGroups)
        {
            foreach (var modelGroup in modelGroups)
            {
                if (modelGroup is ImmutableModelGroup immutableModelGroup) this.AddReference(immutableModelGroup);
                else if (modelGroup is MutableModelGroup mutableModelGroup) this.AddReference(mutableModelGroup);
                else throw new ArgumentException("The model must be either an ImmutableModelGroup or a MutableModelGroup.", nameof(modelGroups));
            }
        }

        public void AddReference(params IModelGroup[] modelGroups)
        {
            this.AddReference(modelGroups.ToList());
        }

        private void AddReference(ImmutableModelGroup reference)
        {
            GreenModelGroup gmg = reference.Green;
            foreach (var greenReference in gmg.References)
            {
                this.AddReference(greenReference.Value);
            }
            foreach (var greenModel in gmg.Models)
            {
                this.AddReference(greenModel.Value);
            }
        }

        private void AddReference(ImmutableModel reference)
        {
            if (reference.ModelGroup != null)
            {
                GreenModelGroup gmg = reference.ModelGroup.Green;
                foreach (var greenReference in gmg.References)
                {
                    this.AddReference(greenReference.Value);
                }
                foreach (var greenModel in gmg.Models)
                {
                    this.AddReference(greenModel.Value);
                }
            }
            else
            {
                this.AddReference(reference.Green);
            }
        }

        private void AddReference(MutableModelGroup reference)
        {
            GreenModelGroup gmg = reference.Green;
            foreach (var greenReference in gmg.References)
            {
                this.AddReference(greenReference.Value);
            }
            foreach (var greenModel in gmg.Models)
            {
                this.AddReference(greenModel.Value);
            }
        }

        private void AddReference(MutableModel reference)
        {
            if (reference.ModelGroup != null)
            {
                GreenModelGroup gmg = reference.ModelGroup.Green;
                foreach (var greenReference in gmg.References)
                {
                    this.AddReference(greenReference.Value);
                }
                foreach (var greenModel in gmg.Models)
                {
                    this.AddReference(greenModel.Value);
                }
            }
            else
            {
                this.AddReference(reference.Green);
            }
        }

        /*public void AddModel(ImmutableModel model)
        {
            // TODO
            throw new NotImplementedException();
        }

        public void AddModel(MutableModel model)
        {
            // TODO
            throw new NotImplementedException();
        }*/

        public MutableModel CreateModel(string name = null, ModelVersion version = default, string uri = null, string prefix = null, string namespaceName = null, Func<MutableModel, ModelFactoryFlags, IModelFactory> factoryConstructor = null)
        {
            var metadata = new GreenMetadata(namespaceName, name, version, uri, prefix, factoryConstructor);
            ModelId mid = new ModelId();
            MutableModel model = new MutableModel(mid, this, false, metadata);
            this.models.Add(mid, model);
            GreenModel greenModel;
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    greenModel = ctx.Updater.CreateModel(mid, metadata);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return model;
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
    }

}
