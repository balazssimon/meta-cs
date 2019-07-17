// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Roslyn.Utilities;
using System;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// A specific location for binding.
    /// </summary>
    public class BinderFlags : FlagsObject
    {
        /// <summary>
        /// No specific location
        /// </summary>
        public const string None = nameof(None);

        public const string SuppressConstraintChecks = nameof(SuppressConstraintChecks);
        public const string SuppressObsoleteChecks = nameof(SuppressObsoleteChecks);
        public const string IgnoreCorLibraryDuplicatedTypes = nameof(IgnoreCorLibraryDuplicatedTypes);
        public const string IgnoreMetaLibraryDuplicatedTypes = nameof(IgnoreMetaLibraryDuplicatedTypes);

        /// <summary>
        /// Indicates that this binder is being used to answer SemanticModel questions (i.e. not
        /// for batch compilation).
        /// </summary>
        /// <remarks>
        /// Imports touched by a binder with this flag set are not consider "used".
        /// </remarks>
        public const string SemanticModel = nameof(SemanticModel);

        public const string EarlyAttributeBinding = nameof(EarlyAttributeBinding);
        public const string IgnoreAccessibility = nameof(IgnoreAccessibility);

        /// <summary>
        /// When binding imports in scripts/submissions, using aliases (other than from the current submission)
        /// are considered but other imports are not.
        /// </summary>
        public const string InScriptUsing = nameof(InScriptUsing);

        /// <summary>
        /// In a file that has been included in the compilation via #load.
        /// </summary>
        public const string InLoadedSyntaxTree = nameof(InLoadedSyntaxTree);

        protected BinderFlags(string name) : base(name)
        {
        }

        protected BinderFlags(FlagsObject flags) : base(flags)
        {
        }

        static BinderFlags()
        {
            RegisterDefault<BinderFlags>(None);
            FlagsObject.AutoInit<BinderFlags>();
        }

        public static implicit operator BinderFlags(string name)
        {
            return FromString<BinderFlags>(name);
        }

        public static explicit operator BinderFlags(int value)
        {
            return FromIntUnsafe<BinderFlags>(value);
        }

        public static BinderFlags operator &(BinderFlags left, FlagsObject right)
        {
            return right?.IntersectWith(left) ?? GetDefault<BinderFlags>();
        }

        public static BinderFlags operator |(BinderFlags left, FlagsObject right)
        {
            return right?.UnionWith(left) ?? left;
        }
    }

}
