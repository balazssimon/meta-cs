// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// A type and its corresponding flow state resulting from evaluating an rvalue expression.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    internal readonly struct TypeWithState
    {
        public readonly TypeSymbol? Type;
        public readonly NullableFlowState State;
        [MemberNotNullWhen(false, nameof(Type))]
        public bool HasNullType => Type is null;
        public bool MayBeNull => State == NullableFlowState.MaybeNull;
        public bool IsNotNull => State == NullableFlowState.NotNull;

    }
}
