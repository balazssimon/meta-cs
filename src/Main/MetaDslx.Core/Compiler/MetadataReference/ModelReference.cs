using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public sealed class ModelReference : MetadataReference, IEquatable<ModelReference>
    {
        private ImmutableModel model;
        public ImmutableModel Model { get { return this.model; } }

        internal ModelReference(ImmutableModel model, MetadataReferenceProperties properties = default)
            : base(properties)
        {
            this.model = model;
        }

        public override string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        public bool Equals(ModelReference other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(this.Model, other.Model);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ModelReference);
        }

        public override int GetHashCode()
        {
            return this.Model.GetHashCode();
        }

        internal override MetadataReference WithPropertiesImplReturningMetadataReference(MetadataReferenceProperties properties)
        {
            return new ModelReference(this.Model, properties);
        }
    }
}
