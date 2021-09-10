// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Roslyn.Utilities;
using System;

namespace MetaDslx.CodeAnalysis.Binding
{
    using CSharpBinderFlags = Microsoft.CodeAnalysis.CSharp.BinderFlags;

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
        public const string AllowMetaConstants = nameof(AllowMetaConstants);

        /// <summary>
        /// Indicates that this binder is being used to answer SemanticModel questions (i.e. not
        /// for batch compilation).
        /// </summary>
        /// <remarks>
        /// Imports touched by a binder with this flag set are not consider "used".
        /// </remarks>
        public const string SemanticModel = nameof(SemanticModel);

        public const string Completion = nameof(Completion);

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

        internal CSharpBinderFlags ToCSharp()
        {
            CSharpBinderFlags result = CSharpBinderFlags.None;
            if (this.Includes(SuppressConstraintChecks)) result |= CSharpBinderFlags.SuppressConstraintChecks;
            if (this.Includes(SuppressObsoleteChecks)) result |= CSharpBinderFlags.SuppressObsoleteChecks;
            if (this.Includes(IgnoreCorLibraryDuplicatedTypes)) result |= CSharpBinderFlags.IgnoreCorLibraryDuplicatedTypes;
            if (this.Includes(IgnoreMetaLibraryDuplicatedTypes)) result |= CSharpBinderFlags.IgnoreCorLibraryDuplicatedTypes;
            if (this.Includes(SemanticModel)) result |= CSharpBinderFlags.SemanticModel;
            if (this.Includes(Completion)) result |= CSharpBinderFlags.SemanticModel;
            if (this.Includes(EarlyAttributeBinding)) result |= CSharpBinderFlags.EarlyAttributeBinding;
            if (this.Includes(IgnoreAccessibility)) result |= CSharpBinderFlags.IgnoreAccessibility;
            if (this.Includes(InScriptUsing)) result |= CSharpBinderFlags.InScriptUsing;
            if (this.Includes(InLoadedSyntaxTree)) result |= CSharpBinderFlags.InLoadedSyntaxTree;
            return result;
        }
    }

}
