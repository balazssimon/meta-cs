// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Compares model identities. 
    /// Derived types may implement platform specific unification and portability policies.
    /// </summary>
    public class ModelIdentityComparer
    {
        public static ModelIdentityComparer Default { get; } = new ModelIdentityComparer();

        public static StringComparer SimpleNameComparer
        {
            get { return StringComparer.OrdinalIgnoreCase; }
        }

        internal ModelIdentityComparer()
        {
        }

        /// <summary>
        /// A set of possible outcomes of <see cref="ModelIdentity"/> comparison.
        /// </summary>
        public enum ComparisonResult
        {
            /// <summary>
            /// Reference doesn't match definition.
            /// </summary>
            NotEquivalent = 0,

            /// <summary>
            /// Strongly named reference matches strongly named definition (strong identity is identity with public key or token),
            /// Or weak reference matches weak definition.
            /// </summary>
            Equivalent = 1,

            /// <summary>
            /// Reference matches definition except for version (reference version is lower or higher than definition version).
            /// </summary>
            EquivalentIgnoringVersion = 2
        }

        /// <summary>
        /// Compares assembly reference name (possibly partial) with definition identity.
        /// </summary>
        /// <param name="referenceDisplayName">Partial or full assembly display name.</param>
        /// <param name="definition">Full assembly display name.</param>
        /// <returns>True if the reference name matches the definition identity.</returns>
        public bool ReferenceMatchesDefinition(string referenceDisplayName, ModelIdentity definition)
        {
            bool unificationApplied;
            return Compare(null, referenceDisplayName, definition, out unificationApplied, ignoreVersion: false) != ComparisonResult.NotEquivalent;
        }

        /// <summary>
        /// Compares assembly reference identity with definition identity.
        /// </summary>
        /// <param name="reference">Reference assembly identity.</param>
        /// <param name="definition">Full assembly display name.</param>
        /// <returns>True if the reference identity matches the definition identity.</returns>
        public bool ReferenceMatchesDefinition(ModelIdentity reference, ModelIdentity definition)
        {
            bool unificationApplied;
            return Compare(reference, null, definition, out unificationApplied, ignoreVersion: false) != ComparisonResult.NotEquivalent;
        }

        /// <summary>
        /// Compares reference assembly identity with definition identity and returns their relationship.
        /// </summary>
        /// <param name="reference">Reference identity.</param>
        /// <param name="definition">Definition identity.</param>
        public ComparisonResult Compare(ModelIdentity reference, ModelIdentity definition)
        {
            bool unificationApplied;
            return Compare(reference, null, definition, out unificationApplied, ignoreVersion: true);
        }

        // internal for testing
        internal ComparisonResult Compare(ModelIdentity reference, string referenceDisplayName, ModelIdentity definition, out bool unificationApplied, bool ignoreVersion)
        {
            Debug.Assert((reference != null) ^ (referenceDisplayName != null));
            unificationApplied = false;
            ModelIdentityParts parts;

            if (reference != null)
            {
                // fast path
                bool? eq = TriviallyEquivalent(reference, definition);
                if (eq.HasValue)
                {
                    return eq.Value ? ComparisonResult.Equivalent : ComparisonResult.NotEquivalent;
                }

                parts = ModelIdentityParts.Name | ModelIdentityParts.Version;
            }
            else
            {
                if (!ModelIdentity.TryParseDisplayName(referenceDisplayName, out reference, out parts))
                {
                    return ComparisonResult.NotEquivalent;
                }
            }

            if (ReferenceEquals(reference, definition))
            {
                return ComparisonResult.Equivalent;
            }

            if (!ModelIdentity.IsFullName(parts))
            {
                if (!SimpleNameComparer.Equals(reference.Name, definition.Name))
                {
                    return ComparisonResult.NotEquivalent;
                }
                // version is ignored
                return ComparisonResult.Equivalent;
            }

            if (!SimpleNameComparer.Equals(reference.Name, definition.Name))
            {
                return ComparisonResult.NotEquivalent;
            }

            bool hasSomeVersionParts = (parts & ModelIdentityParts.Version) != 0;
            bool hasPartialVersion = (parts & ModelIdentityParts.Version) != ModelIdentityParts.Version;

            // If any version parts were specified then compare the versions. The comparison fails if some version parts are missing.
            if (hasSomeVersionParts &&
                (hasPartialVersion || reference.Version != definition.Version))
            {
                if (ignoreVersion)
                {
                    return ComparisonResult.EquivalentIgnoringVersion;
                }
                return ComparisonResult.NotEquivalent;
            }

            return ComparisonResult.Equivalent;
        }

        private static bool? TriviallyEquivalent(ModelIdentity x, ModelIdentity y)
        {
            return ModelIdentity.MemberwiseEqual(x, y);
        }
    }
}

