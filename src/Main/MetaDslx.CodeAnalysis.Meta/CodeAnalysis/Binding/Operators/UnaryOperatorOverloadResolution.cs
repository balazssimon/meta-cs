// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

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
        public void UnaryOperatorOverloadResolution(UnaryOperatorKind kind, ExpressionSymbol operand, UnaryOperatorOverloadResolutionResult result, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            if (kind is null || operand is null)
            {
                result.Results.Add(UnaryOperatorAnalysisResult.Inapplicable(UnaryOperatorSignature.Error, Conversions.NoConversion));
                return;
            }

            Debug.Assert(operand != null);
            Debug.Assert(result.Results.Count == 0);

            // We can do a table lookup for well-known problems in overload resolution.
            // SPEC: An operation of the form op x or x op, where op is an overloadable unary operator,
            // SPEC: and x is an expression of type X, is processed as follows:

            // SPEC: The set of candidate user-defined operators provided by X for the operation operator 
            // SPEC: op(x) is determined using the rules of 7.3.5.

            GetStandardOrUserDefinedOperator(kind, operand, result, ref useSiteDiagnostics);
            if (result.Results.Count > 0)
            {
                return;
            }

            // SPEC: If the set of candidate user-defined operators is not empty, then this becomes the 
            // SPEC: set of candidate operators for the operation. Otherwise, the predefined unary operator 
            // SPEC: implementations, including their lifted forms, become the set of candidate operators 
            // SPEC: for the operation. 

            GetAllBuiltInOperators(kind, operand, result.Results, ref useSiteDiagnostics);

            // SPEC: The overload resolution rules of 7.5.3 are applied to the set of candidate operators 
            // SPEC: to select the best operator with respect to the argument list (x), and this operator 
            // SPEC: becomes the result of the overload resolution process. If overload resolution fails 
            // SPEC: to select a single best operator, a binding-time error occurs.

            UnaryOperatorOverloadResolution(operand, result, ref useSiteDiagnostics);
        }

        private void GetStandardOrUserDefinedOperator(UnaryOperatorKind kind, ExpressionSymbol operand, UnaryOperatorOverloadResolutionResult result, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var operandType = operand.Type;
            if (operandType is null)
            {
                return;
            }

            var signature = this.Compilation.UnaryOperators.ClassifyOperatorByType(kind, operandType);

            if (signature.IsError)
            {
                return;
            }

            Conversion? conversion = Conversions.ClassifyConversionFromType(operandType, signature.OperandType, ref useSiteDiagnostics);
            Debug.Assert(conversion is not null && conversion.IsImplicit);
            result.Results.Add(UnaryOperatorAnalysisResult.Applicable(signature, conversion));
        }

        // Takes a list of candidates and mutates the list to throw out the ones that are worse than
        // another applicable candidate.
        private void UnaryOperatorOverloadResolution(
            ExpressionSymbol operand,
            UnaryOperatorOverloadResolutionResult result,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // SPEC: Given the set of applicable candidate function members, the best function member in that set is located. 
            // SPEC: If the set contains only one function member, then that function member is the best function member. 

            if (result.SingleValid())
            {
                return;
            }

            // SPEC: Otherwise, the best function member is the one function member that is better than all other function 
            // SPEC: members with respect to the given argument list, provided that each function member is compared to all 
            // SPEC: other function members using the rules in 7.5.3.2. If there is not exactly one function member that is 
            // SPEC: better than all other function members, then the function member invocation is ambiguous and a binding-time 
            // SPEC: error occurs.

            var candidates = result.Results;
            // Try to find a single best candidate
            int bestIndex = GetTheBestCandidateIndex(operand, candidates, ref useSiteDiagnostics);
            if (bestIndex != -1)
            {
                // Mark all other candidates as worse
                for (int index = 0; index < candidates.Count; ++index)
                {
                    if (candidates[index].Kind != OperatorAnalysisResultKind.Inapplicable && index != bestIndex)
                    {
                        candidates[index] = candidates[index].Worse();
                    }
                }

                return;
            }

            for (int i = 1; i < candidates.Count; ++i)
            {
                if (candidates[i].Kind != OperatorAnalysisResultKind.Applicable)
                {
                    continue;
                }

                // Is this applicable operator better than every other applicable method?
                for (int j = 0; j < i; ++j)
                {
                    if (candidates[j].Kind == OperatorAnalysisResultKind.Inapplicable)
                    {
                        continue;
                    }

                    var better = BetterOperator(candidates[i].Signature, candidates[j].Signature, operand, ref useSiteDiagnostics);
                    if (better == BetterResult.Left)
                    {
                        candidates[j] = candidates[j].Worse();
                    }
                    else if (better == BetterResult.Right)
                    {
                        candidates[i] = candidates[i].Worse();
                    }
                }
            }
        }

        private int GetTheBestCandidateIndex(
            ExpressionSymbol operand,
            ArrayBuilder<UnaryOperatorAnalysisResult> candidates,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            int currentBestIndex = -1;
            for (int index = 0; index < candidates.Count; index++)
            {
                if (candidates[index].Kind != OperatorAnalysisResultKind.Applicable)
                {
                    continue;
                }

                // Assume that the current candidate is the best if we don't have any
                if (currentBestIndex == -1)
                {
                    currentBestIndex = index;
                }
                else
                {
                    var better = BetterOperator(candidates[currentBestIndex].Signature, candidates[index].Signature, operand, ref useSiteDiagnostics);
                    if (better == BetterResult.Right)
                    {
                        // The current best is worse
                        currentBestIndex = index;
                    }
                    else if (better != BetterResult.Left)
                    {
                        // The current best is not better
                        currentBestIndex = -1;
                    }
                }
            }

            // Make sure that every candidate up to the current best is worse
            for (int index = 0; index < currentBestIndex; index++)
            {
                if (candidates[index].Kind == OperatorAnalysisResultKind.Inapplicable)
                {
                    continue;
                }

                var better = BetterOperator(candidates[currentBestIndex].Signature, candidates[index].Signature, operand, ref useSiteDiagnostics);
                if (better != BetterResult.Left)
                {
                    // The current best is not better
                    return -1;
                }
            }

            return currentBestIndex;
        }

        private BetterResult BetterOperator(UnaryOperatorSignature op1, UnaryOperatorSignature op2, ExpressionSymbol operand, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // First we see if the conversion from the operand to one operand type is better than 
            // the conversion to the other.

            BetterResult better = BetterConversionFromExpression(operand, RefKind.None, op1.OperandType, op2.OperandType, ref useSiteDiagnostics);

            if (better == BetterResult.Left || better == BetterResult.Right)
            {
                return better;
            }

            // There was no better member on the basis of conversions. Go to the tiebreaking round.

            // SPEC: In case the parameter type sequences P1, P2 and Q1, Q2 are equivalent -- that is, every Pi
            // SPEC: has an identity conversion to the corresponding Qi -- the following tie-breaking rules
            // SPEC: are applied:

            if (Conversions.HasIdentityConversion(op1.OperandType, op2.OperandType))
            {
                // SPEC: If Mp has more specific parameter types than Mq then Mp is better than Mq.

                // Under what circumstances can two unary operators with identical signatures be "more specific"
                // than another? With a binary operator you could have C<T>.op+(C<T>, T) and C<T>.op+(C<T>, int).
                // When doing overload resolution on C<int> + int, the latter is more specific. But with a unary
                // operator, the sole operand *must* be the containing type or its nullable type. Therefore
                // if there is an identity conversion, then the parameters really were identical. We therefore
                // skip checking for specificity.

                // SPEC: If one member is a non-lifted operator and the other is a lifted operator,
                // SPEC: the non-lifted one is better.

                bool lifted1 = op1.IsLifted;
                bool lifted2 = op2.IsLifted;

                if (lifted1 && !lifted2)
                {
                    return BetterResult.Right;
                }
                else if (!lifted1 && lifted2)
                {
                    return BetterResult.Left;
                }
            }

            // Always prefer operators with val parameters over operators with in parameters:
            if (op1.RefKind == RefKind.None && op2.RefKind == RefKind.In)
            {
                return BetterResult.Left;
            }
            else if (op2.RefKind == RefKind.None && op1.RefKind == RefKind.In)
            {
                return BetterResult.Right;
            }

            return BetterResult.Neither;
        }

        private void GetAllBuiltInOperators(UnaryOperatorKind kind, ExpressionSymbol operand, ArrayBuilder<UnaryOperatorAnalysisResult> results, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // The spec states that overload resolution is performed upon the infinite set of
            // operators defined on enumerated types, pointers and delegates. Clearly we cannot
            // construct the infinite set; we have to pare it down. Previous implementations of C#
            // implement a much stricter rule; they only add the special operators to the candidate
            // set if one of the operands is of the relevant type. This means that operands
            // involving user-defined implicit conversions from class or struct types to enum,
            // pointer and delegate types do not cause the right candidates to participate in
            // overload resolution. It also presents numerous problems involving delegate variance
            // and conversions from lambdas to delegate types.
            //
            // It is onerous to require the actually specified behavior. We should change the
            // specification to match the previous implementation.

            var operators = ArrayBuilder<UnaryOperatorSignature>.GetInstance();

            /* TODO:MetaDslx
            this.Compilation.builtInOperators.GetSimpleBuiltInOperators(kind, operators, skipNativeIntegerOperators: !operand.Type.IsNativeIntegerOrNullableNativeIntegerType());

            GetEnumOperations(kind, operand, operators);

            var pointerOperator = GetPointerOperation(kind, operand);
            if (pointerOperator != null)
            {
                operators.Add(pointerOperator.Value);
            }
            */

            CandidateOperators(operators, operand, results, ref useSiteDiagnostics);
            operators.Free();
        }

        // Returns true if there were any applicable candidates.
        private bool CandidateOperators(ArrayBuilder<UnaryOperatorSignature> operators, ExpressionSymbol operand, ArrayBuilder<UnaryOperatorAnalysisResult> results, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            bool anyApplicable = false;
            foreach (var op in operators)
            {
                var conversion = Conversions.ClassifyConversionFromExpression(operand, op.OperandType, ref useSiteDiagnostics);
                if (conversion.IsImplicit)
                {
                    anyApplicable = true;
                    results.Add(UnaryOperatorAnalysisResult.Applicable(op, conversion));
                }
                else
                {
                    results.Add(UnaryOperatorAnalysisResult.Inapplicable(op, conversion));
                }
            }

            return anyApplicable;
        }

    }
}
