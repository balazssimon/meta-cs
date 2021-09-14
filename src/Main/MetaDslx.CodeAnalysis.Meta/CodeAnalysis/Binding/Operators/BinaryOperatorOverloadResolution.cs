// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed partial class OverloadResolution
    {
        public void BinaryOperatorOverloadResolution(BinaryOperatorKind kind, ExpressionSymbol left, ExpressionSymbol right, BinaryOperatorOverloadResolutionResult result, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            if (kind is null || left is null || right is null)
            {
                result.Results.Add(BinaryOperatorAnalysisResult.Inapplicable(BinaryOperatorSignature.Error, Conversions.NoConversion, Conversions.NoConversion));
                return;
            }

            // We can do a table lookup for well-known problems in overload resolution.
            GetStandardOrUserDefinedOperator(kind, left, right, result, ref useSiteDiagnostics);
            if (result.Results.Count > 0)
            {
                return;
            }

            // TODO:MetaDslx - use built-in operators for enums, delegates, etc.
        }


        private void GetStandardOrUserDefinedOperator(BinaryOperatorKind kind, ExpressionSymbol left, ExpressionSymbol right, BinaryOperatorOverloadResolutionResult result, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var leftType = left.Type;
            if (leftType is null)
            {
                return;
            }
            var rightType = right.Type;
            if (rightType is null)
            {
                return;
            }

            var signature = this.Compilation.BinaryOperators.ClassifyOperatorByType(kind, leftType, rightType);

            if (signature.IsError)
            {
                return;
            }

            var leftConversion = Conversions.ClassifyConversionFromType(leftType, signature.LeftType, ref useSiteDiagnostics);
            var rightConversion = Conversions.ClassifyConversionFromType(leftType, signature.RightType, ref useSiteDiagnostics);
            Debug.Assert(leftConversion.IsImplicit);
            Debug.Assert(rightConversion.IsImplicit);

            result.Results.Add(BinaryOperatorAnalysisResult.Applicable(signature, leftConversion, rightConversion));
        }

    }
}
