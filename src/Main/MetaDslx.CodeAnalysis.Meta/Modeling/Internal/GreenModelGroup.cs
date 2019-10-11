using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class GreenModelGroup
    {
        internal static readonly GreenModelGroup Empty = new GreenModelGroup();

        private readonly ImmutableDictionary<ModelId, GreenModel> models;
        private readonly ImmutableDictionary<ModelId, GreenModel> references;

        private GreenModelGroup()
        {
            this.models = ImmutableDictionary<ModelId, GreenModel>.Empty;
            this.references = ImmutableDictionary<ModelId, GreenModel>.Empty;
        }

        private GreenModelGroup(ImmutableDictionary<ModelId, GreenModel> models, ImmutableDictionary<ModelId, GreenModel> references)
        {
            this.models = models;
            this.references = references;
        }

        internal GreenModelGroup Update(ImmutableDictionary<ModelId, GreenModel> models, ImmutableDictionary<ModelId, GreenModel> references)
        {
            if (this.models != models || this.references != references)
            {
                return new GreenModelGroup(models, references);
            }
            return this;
        }

        internal ImmutableDictionary<ModelId, GreenModel> Models { get { return this.models; } }
        internal ImmutableDictionary<ModelId, GreenModel> References { get { return this.references; } }

        internal GreenModelGroup AddModel(GreenModel model)
        {
            if (this.models.ContainsKey(model.Id) || this.references.ContainsKey(model.Id)) return this;
            return this.Update(this.models.Add(model.Id, model), this.references);
        }

        internal GreenModelGroup AddReference(GreenModel reference)
        {
            if (this.models.ContainsKey(reference.Id) || this.references.ContainsKey(reference.Id)) return this;
            return this.Update(this.models, this.references.Add(reference.Id, reference));
        }

        internal GreenModelGroup UpdateModel(GreenModel model)
        {
            if (!this.models.ContainsKey(model.Id)) return this;
            return this.Update(this.models.SetItem(model.Id, model), this.references);
        }

        internal bool ObjectExists(ObjectId oid)
        {
            foreach (var model in this.models.Values)
            {
                if (model.Objects.ContainsKey(oid)) return true;
            }
            foreach (var model in this.references.Values)
            {
                if (model.Objects.ContainsKey(oid)) return true;
            }
            return false;
        }

        internal bool ContainsObject(ObjectId oid)
        {
            foreach (var model in this.models.Values)
            {
                if (model.Objects.ContainsKey(oid)) return true;
            }
            return false;
        }

        internal bool ContainsObject(ModelId mid, ObjectId oid)
        {
            GreenModel model;
            if (!this.models.TryGetValue(mid, out model))
            {
                return false;
            }
            return model.Objects.ContainsKey(oid);
        }

        internal GreenModelGroup RemoveObject(ObjectId oid)
        {
            GreenModelGroup result = this;
            foreach (var model in this.models.Values)
            {
                result = result.UpdateModel(model.RemoveObject(oid));
            }
            return result;
        }

        internal GreenModelGroup ReplaceObject(ObjectId oid, ObjectId targetOid)
        {
            GreenModelGroup result = this;
            foreach (var model in this.models.Values)
            {
                result = result.UpdateModel(model.ReplaceObject(oid, targetOid));
            }
            return result;
        }

        internal GreenModelGroup PurgeWeakObjects(HashSet<ObjectId> strongObjects)
        {
            GreenModelGroup result = this;
            foreach (var model in this.models.Values)
            {
                result = result.UpdateModel(model.PurgeWeakObjects(strongObjects));
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("models: [");
            bool first = true;
            foreach (var model in this.models.Values)
            {
                if (!first) result.Append(", ");
                result.Append(model.ToString());
                first = false;
            }
            result.Append("], references: [");
            first = true;
            foreach (var reference in this.references.Values)
            {
                if (!first) result.Append(", ");
                result.Append(reference.ToString());
                first = false;
            }
            result.Append("]");
            return result.ToString();
        }

        public string ToFullString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("models: [");
            bool first = true;
            foreach (var model in this.models.Values)
            {
                if (!first) result.Append(", ");
                result.Append(model.ToFullString());
                first = false;
            }
            result.Append("], references: [");
            first = true;
            foreach (var reference in this.references.Values)
            {
                if (!first) result.Append(", ");
                result.Append(reference.ToFullString());
                first = false;
            }
            result.Append("]");
            return result.ToString();
        }
    }

}
