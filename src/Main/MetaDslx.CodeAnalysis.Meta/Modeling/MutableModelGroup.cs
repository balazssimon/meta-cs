using MetaDslx.Modeling.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

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
            return this.models.GetValue(mid, key => new MutableModel(key, this, true, null));
        }

        private MutableModel GetExistingModel(ModelId mid)
        {
            return this.models.GetValue(mid, key => new MutableModel(key, this, false, null));
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

        public void AddReference(ImmutableModelGroup reference)
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

        public void AddReference(ImmutableModel reference)
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

        public void AddReference(MutableModelGroup reference)
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

        public void AddReference(MutableModel reference)
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

        public void AddModel(ImmutableModel model)
        {
            // TODO
            throw new NotImplementedException();
        }

        public void AddModel(MutableModel model)
        {
            // TODO
            throw new NotImplementedException();
        }

        public MutableModel CreateModel(string name = null, ModelVersion version = default)
        {
            ModelId mid = new ModelId();
            MutableModel model = new MutableModel(mid, this, false, null);
            this.models.Add(mid, model);
            GreenModel greenModel;
            GreenModelUpdateContext ctx = null;
            try
            {
                do
                {
                    ctx = this.BeginUpdate();
                    greenModel = ctx.Updater.CreateModel(mid, name, version);
                } while (!this.EndUpdate(ctx));
            }
            finally
            {
                this.FinalizeUpdate(ctx);
            }
            return model;
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

        public void Validate(DiagnosticBag diagnostics)
        {
            foreach (var model in this.Models)
            {
                model.Validate(diagnostics);
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
