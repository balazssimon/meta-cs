using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.References
{
    /// <summary>
    /// Reference to another compilation.
    /// </summary>
    public class CompilationReference : MetadataReference, IEquatable<CompilationReference>
    {
        private readonly Compilation compilation;
        private readonly ImmutableArray<string> aliases;

        public Compilation Compilation { get { return this.compilation; } }
        public ImmutableArray<string> Aliases { get { return this.aliases; } }

        internal CompilationReference(Compilation compilation, ImmutableArray<string> aliases)
        {
            this.compilation = compilation;
        }

        public override string Display
        {
            get
            {
                return Compilation.CompilationName;
            }
        }

        /// <summary>
        /// Returns an instance of the reference with specified aliases.
        /// </summary>
        /// <param name="aliases">The new aliases for the reference.</param>
        /// <exception cref="ArgumentException">Alias is invalid for the metadata kind.</exception> 
        public CompilationReference WithAliases(IEnumerable<string> aliases)
        {
            return this.WithAliases(ImmutableArray.CreateRange(aliases));
        }

        /// <summary>
        /// Returns an instance of the reference with specified aliases.
        /// </summary>
        /// <param name="aliases">The new aliases for the reference.</param>
        /// <exception cref="ArgumentException">Alias is invalid for the metadata kind.</exception> 
        public CompilationReference WithAliases(ImmutableArray<string> aliases)
        {
            return new CompilationReference(this.compilation, this.aliases);
        }

        public bool Equals(CompilationReference other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(this.Compilation, other.Compilation);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CompilationReference);
        }

        public override int GetHashCode()
        {
            return this.Compilation.GetHashCode();
        }
    }
}
