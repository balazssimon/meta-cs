using MetaDslx.Compiler.References;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Represents metadata image reference.
    /// </summary>
    /// <remarks>
    /// Represents a logical location of the image, not the content of the image. 
    /// The content might change in time. A snapshot is taken when the compiler queries the reference for its metadata.
    /// </remarks>
    public abstract class MetadataReference
    {
        protected MetadataReference()
        {

        }

        /// <summary>
        /// Path or name used in error messages to identify the reference.
        /// </summary>
        public virtual string Display { get { return null; } }

        /// <summary>
        /// Returns true if this reference is an unresolved reference.
        /// </summary>
        public virtual bool IsUnresolved
        {
            get { return false; }
        }

        public override string ToString()
        {
            return this.Display;
        }

        public static MetadataReference CreateFromModel(ImmutableModel model)
        {
            return new ModelReference(model);
        }

        public static MetadataReference CreateFromModel(MutableModel model)
        {
            return new ModelReference(model.ToImmutable());
        }

        public static MetadataReference CreateFromModelGroup(ImmutableModelGroup modelGroup)
        {
            return new ModelGroupReference(modelGroup);
        }

        public static MetadataReference CreateFromModelGroup(MutableModelGroup modelGroup)
        {
            return new ModelGroupReference(modelGroup.ToImmutable());
        }
    }
}
