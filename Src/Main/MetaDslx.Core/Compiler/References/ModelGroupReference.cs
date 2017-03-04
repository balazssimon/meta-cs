using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.References
{
    public sealed class ModelGroupReference : MetadataReference, IEquatable<ModelGroupReference>
    {
        private ImmutableModelGroup modelGroup;
        public ImmutableModelGroup ModelGroup { get { return this.modelGroup; } }

        internal ModelGroupReference(ImmutableModelGroup modelGroup)
        {
            this.modelGroup = modelGroup;
        }

        public override string Display
        {
            get
            {
                return ModelGroup.ToString();
            }
        }

        public bool Equals(ModelGroupReference other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(this.ModelGroup, other.ModelGroup);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ModelGroupReference);
        }

        public override int GetHashCode()
        {
            return this.ModelGroup.GetHashCode();
        }

    }
}
