using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Roslyn.Utilities;

#nullable enable

namespace MetaDslx.CodeAnalysis.Symbols
{
	public abstract partial class MethodLikeSymbol
	{
        public static new class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Attributes = MetaDslx.CodeAnalysis.Symbols.Symbol.CompletionParts.StartComputingProperty_Attributes;
            public static readonly CompletionPart FinishComputingProperty_Attributes = MetaDslx.CodeAnalysis.Symbols.Symbol.CompletionParts.FinishComputingProperty_Attributes;
            public static readonly CompletionPart StartComputingProperty_TypeParameters = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.StartComputingProperty_TypeParameters;
            public static readonly CompletionPart FinishComputingProperty_TypeParameters = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.FinishComputingProperty_TypeParameters;
            public static readonly CompletionPart StartComputingProperty_DeclaredAccessibility = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.StartComputingProperty_DeclaredAccessibility;
            public static readonly CompletionPart FinishComputingProperty_DeclaredAccessibility = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.FinishComputingProperty_DeclaredAccessibility;
            public static readonly CompletionPart StartComputingProperty_IsExtern = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.StartComputingProperty_IsExtern;
            public static readonly CompletionPart FinishComputingProperty_IsExtern = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.FinishComputingProperty_IsExtern;
            public static readonly CompletionPart StartComputingProperty_Members = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.StartComputingProperty_Members;
            public static readonly CompletionPart FinishComputingProperty_Members = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.FinishComputingProperty_Members;
            public static readonly CompletionPart StartComputingProperty_IsStatic = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.StartComputingProperty_IsStatic;
            public static readonly CompletionPart FinishComputingProperty_IsStatic = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.FinishComputingProperty_IsStatic;
            public static readonly CompletionPart StartComputingProperty_IsVirtual = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.StartComputingProperty_IsVirtual;
            public static readonly CompletionPart FinishComputingProperty_IsVirtual = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.FinishComputingProperty_IsVirtual;
            public static readonly CompletionPart StartComputingProperty_IsOverride = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.StartComputingProperty_IsOverride;
            public static readonly CompletionPart FinishComputingProperty_IsOverride = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.FinishComputingProperty_IsOverride;
            public static readonly CompletionPart StartComputingProperty_IsAbstract = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.StartComputingProperty_IsAbstract;
            public static readonly CompletionPart FinishComputingProperty_IsAbstract = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.FinishComputingProperty_IsAbstract;
            public static readonly CompletionPart StartComputingProperty_IsSealed = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.StartComputingProperty_IsSealed;
            public static readonly CompletionPart FinishComputingProperty_IsSealed = MetaDslx.CodeAnalysis.Symbols.MemberSymbol.CompletionParts.FinishComputingProperty_IsSealed;
            public static readonly CompletionPart StartComputingProperty_IsAsync = new CompletionPart(nameof(StartComputingProperty_IsAsync));
            public static readonly CompletionPart FinishComputingProperty_IsAsync = new CompletionPart(nameof(FinishComputingProperty_IsAsync));
            public static readonly CompletionPart StartComputingProperty_ReturnType = new CompletionPart(nameof(StartComputingProperty_ReturnType));
            public static readonly CompletionPart FinishComputingProperty_ReturnType = new CompletionPart(nameof(FinishComputingProperty_ReturnType));
            public static readonly CompletionPart StartComputingProperty_ReturnRefKind = new CompletionPart(nameof(StartComputingProperty_ReturnRefKind));
            public static readonly CompletionPart FinishComputingProperty_ReturnRefKind = new CompletionPart(nameof(FinishComputingProperty_ReturnRefKind));
            public static readonly CompletionPart StartComputingProperty_Parameters = new CompletionPart(nameof(StartComputingProperty_Parameters));
            public static readonly CompletionPart FinishComputingProperty_Parameters = new CompletionPart(nameof(FinishComputingProperty_Parameters));
            public static readonly CompletionPart StartComputingProperty_Body = new CompletionPart(nameof(StartComputingProperty_Body));
            public static readonly CompletionPart FinishComputingProperty_Body = new CompletionPart(nameof(FinishComputingProperty_Body));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_IsStatic, FinishComputingProperty_IsStatic, StartComputingProperty_IsVirtual, FinishComputingProperty_IsVirtual, StartComputingProperty_IsOverride, FinishComputingProperty_IsOverride, StartComputingProperty_IsAbstract, FinishComputingProperty_IsAbstract, StartComputingProperty_IsSealed, FinishComputingProperty_IsSealed, StartComputingProperty_IsAsync, FinishComputingProperty_IsAsync, StartComputingProperty_ReturnType, FinishComputingProperty_ReturnType, StartComputingProperty_ReturnRefKind, FinishComputingProperty_ReturnRefKind, StartComputingProperty_Parameters, FinishComputingProperty_Parameters, StartComputingProperty_Body, FinishComputingProperty_Body, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_IsStatic, FinishComputingProperty_IsStatic, StartComputingProperty_IsVirtual, FinishComputingProperty_IsVirtual, StartComputingProperty_IsOverride, FinishComputingProperty_IsOverride, StartComputingProperty_IsAbstract, FinishComputingProperty_IsAbstract, StartComputingProperty_IsSealed, FinishComputingProperty_IsSealed, StartComputingProperty_IsAsync, FinishComputingProperty_IsAsync, StartComputingProperty_ReturnType, FinishComputingProperty_ReturnType, StartComputingProperty_ReturnRefKind, FinishComputingProperty_ReturnRefKind, StartComputingProperty_Parameters, FinishComputingProperty_Parameters, StartComputingProperty_Body, FinishComputingProperty_Body, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted, CompletionGraph.StartValidatingSymbol, CompletionGraph.FinishValidatingSymbol);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_IsStatic, FinishComputingProperty_IsStatic, StartComputingProperty_IsVirtual, FinishComputingProperty_IsVirtual, StartComputingProperty_IsOverride, FinishComputingProperty_IsOverride, StartComputingProperty_IsAbstract, FinishComputingProperty_IsAbstract, StartComputingProperty_IsSealed, FinishComputingProperty_IsSealed, StartComputingProperty_IsAsync, FinishComputingProperty_IsAsync, StartComputingProperty_ReturnType, FinishComputingProperty_ReturnType, StartComputingProperty_ReturnRefKind, FinishComputingProperty_ReturnRefKind, StartComputingProperty_Parameters, FinishComputingProperty_Parameters, StartComputingProperty_Body, FinishComputingProperty_Body, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted, CompletionGraph.StartValidatingSymbol, CompletionGraph.FinishValidatingSymbol);
        }
	}
}
