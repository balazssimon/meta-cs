// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Binding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal static class ParameterHelpers
    {
        public static ImmutableArray<ParameterSymbol> MakeParameters(
            Binder binder,
            Symbol owner,
            CSharpSyntaxNode syntax,
            out SyntaxToken arglistToken,
            DiagnosticBag diagnostics,
            bool allowRefOrOut,
            bool allowThis,
            bool addRefReadOnlyModifier)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static void EnsureIsReadOnlyAttributeExists(ImmutableArray<ParameterSymbol> parameters, DiagnosticBag diagnostics, bool modifyCompilation)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.RefKind == RefKind.In)
                {
                    // These parameters might not come from a compilation (example: lambdas evaluated in EE).
                    // During rewriting, lowering will take care of flagging the appropriate PEModuleBuilder instead.
                    parameter.DeclaringCompilation?.EnsureIsReadOnlyAttributeExists(diagnostics, parameter.GetNonNullSyntaxNode().Location, modifyCompilation);
                }
            }
        }

        internal static void EnsureNullableAttributeExists(ImmutableArray<ParameterSymbol> parameters, DiagnosticBag diagnostics, bool modifyCompilation)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.TypeWithAnnotations.NeedsNullableAttribute())
                {
                    // These parameters might not come from a compilation (example: lambdas evaluated in EE).
                    // During rewriting, lowering will take care of flagging the appropriate PEModuleBuilder instead.
                    parameter.DeclaringCompilation?.EnsureNullableAttributeExists(diagnostics, parameter.GetNonNullSyntaxNode().Location, modifyCompilation);
                }
            }
        }

        internal static bool ReportDefaultParameterErrors(
            Binder binder,
            Symbol owner,
            CSharpSyntaxNode parameterSyntax,
            SourceParameterSymbol parameter,
            BoundExpression defaultExpression,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static MethodSymbol FindContainingGenericMethod(Symbol symbol)
        {
            for (Symbol current = symbol; (object)current != null; current = current.ContainingSymbol)
            {
                if (current.Kind == SymbolKind.Method)
                {
                    MethodSymbol method = (MethodSymbol)current;
                    if (method.MethodKind != MethodKind.AnonymousFunction)
                    {
                        return method.IsGenericMethod ? method : null;
                    }
                }
            }
            return null;
        }
    }
}
