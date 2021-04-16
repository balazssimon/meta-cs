// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal static class NullableFlowStateExtensions
    {
        public static bool MayBeNull(this NullableFlowState state) => state != NullableFlowState.NotNull;

        public static bool IsNotNull(this NullableFlowState state) => state == NullableFlowState.NotNull;

        /// <summary>
        /// Join nullable flow states from distinct branches during flow analysis.
        /// The result is <see cref="NullableFlowState.MaybeNull"/> if either operand is that.
        /// </summary>
        public static NullableFlowState Join(this NullableFlowState a, NullableFlowState b) => (a > b) ? a : b;

        /// <summary>
        /// Meet two nullable flow states from distinct states for the meet (union) operation in flow analysis.
        /// The result is <see cref="NullableFlowState.NotNull"/> if either operand is that.
        /// </summary>
        public static NullableFlowState Meet(this NullableFlowState a, NullableFlowState b) => (a < b) ? a : b;

        internal static Microsoft.CodeAnalysis.NullableFlowState ToPublicFlowState(this NullableFlowState nullableFlowState) =>
            nullableFlowState switch
            {
                NullableFlowState.NotNull => Microsoft.CodeAnalysis.NullableFlowState.NotNull,
                NullableFlowState.MaybeNull => Microsoft.CodeAnalysis.NullableFlowState.MaybeNull,
                NullableFlowState.MaybeDefault => Microsoft.CodeAnalysis.NullableFlowState.MaybeNull,
                _ => throw ExceptionUtilities.UnexpectedValue(nullableFlowState)
            };

    }
}
