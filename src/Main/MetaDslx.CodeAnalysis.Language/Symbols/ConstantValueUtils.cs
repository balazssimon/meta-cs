// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Binding;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class EvaluatedConstant
    {
        public readonly ConstantValue Value;
        public readonly ImmutableArray<Diagnostic> Diagnostics;

        public EvaluatedConstant(ConstantValue value, ImmutableArray<Diagnostic> diagnostics)
        {
            this.Value = value;
            this.Diagnostics = diagnostics.NullToEmpty();
        }
    }

    internal static class ConstantValueUtils
    {
        public static ConstantValue EvaluateFieldConstant(
            SourceFieldSymbol symbol,
            CSharpSyntaxNode equalsValueNode,
            HashSet<SourceFieldSymbolWithSyntaxReference> dependencies,
            bool earlyDecodingWellKnownAttributes,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static ConstantValue GetAndValidateConstantValue(
            BoundExpression boundValue,
            Symbol thisSymbol,
            TypeSymbol typeSymbol,
            Location initValueNodeLocation,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }
    }
}
