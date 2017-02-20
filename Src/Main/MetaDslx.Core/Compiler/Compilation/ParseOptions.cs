using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Represents parse options common to all languages.
    /// </summary>
    public abstract class ParseOptions
    {
        /// <summary>
        /// Specifies whether to parse as regular code files, script files or interactive code.
        /// </summary>
        public SourceCodeKind Kind { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether the documentation comments are parsed.
        /// </summary>
        /// <value><c>true</c> if documentation comments are parsed, <c>false</c> otherwise.</value>
        public DocumentationMode DocumentationMode { get; protected set; }

        protected ParseOptions(SourceCodeKind kind, DocumentationMode documentationMode)
        {
            this.Kind = kind;
            this.DocumentationMode = documentationMode;
        }

        /// <summary>
        /// Creates a new options instance with the specified source code kind.
        /// </summary>
        public ParseOptions WithKind(SourceCodeKind kind)
        {
            return CommonWithKind(kind);
        }

        public abstract ParseOptions CommonWithKind(SourceCodeKind kind);

        /// <summary>
        /// Creates a new options instance with the specified documentation mode.
        /// </summary>
        public ParseOptions WithDocumentationMode(DocumentationMode documentationMode)
        {
            return CommonWithDocumentationMode(documentationMode);
        }

        protected abstract ParseOptions CommonWithDocumentationMode(DocumentationMode documentationMode);

        /// <summary>
        /// Enable some experimental language features for testing.
        /// </summary>
        public ParseOptions WithFeatures(IEnumerable<KeyValuePair<string, string>> features)
        {
            return CommonWithFeatures(features);
        }

        protected abstract ParseOptions CommonWithFeatures(IEnumerable<KeyValuePair<string, string>> features);

        /// <summary>
        /// Returns the experimental features.
        /// </summary>
        public abstract IReadOnlyDictionary<string, string> Features
        {
            get;
        }

        public abstract override bool Equals(object obj);

        protected bool EqualsHelper(ParseOptions other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            return
                this.Kind == other.Kind &&
                this.DocumentationMode == other.DocumentationMode &&
                this.Features.SequenceEqual(other.Features);
        }

        public abstract override int GetHashCode();

        protected int GetHashCodeHelper()
        {
            return
                Hash.Combine((int)this.Kind,
                Hash.Combine((int)this.DocumentationMode,
                Hash.Combine(HashFeatures(this.Features), 0)));
        }

        private static int HashFeatures(IReadOnlyDictionary<string, string> features)
        {
            int value = 0;
            foreach (var kv in features)
            {
                value = Hash.Combine(kv.Key.GetHashCode(),
                        Hash.Combine(kv.Value.GetHashCode(), value));
            }

            return value;
        }
    }

}
