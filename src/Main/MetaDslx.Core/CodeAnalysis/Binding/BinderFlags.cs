// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// A specific location for binding.
    /// </summary>
    [Flags]
    internal enum BinderFlags : uint
    {
        None, // No specific location
        /// <summary>
        /// Indicates that this binder is being used to answer SemanticModel questions (i.e. not
        /// for batch compilation).
        /// </summary>
        /// <remarks>
        /// Imports touched by a binder with this flag set are not consider "used".
        /// </remarks>
        SemanticModel = 1 << 0,
        EarlyAttributeBinding = 1 << 1,
        IgnoreAccessibility = 1 << 2,

        // Groups
    }

    /// <summary>
    /// Extension methods for the <see cref="BinderFlags"/> type.
    /// </summary>
    internal static class BinderFlagsExtensions
    {
        public static bool Includes(this BinderFlags self, BinderFlags other)
        {
            return (self & other) == other;
        }

        public static bool IncludesAny(this BinderFlags self, BinderFlags other)
        {
            return (self & other) != 0;
        }
    }
}
