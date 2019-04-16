// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp
{
    /// <summary>
    /// Represents symbols imported to the binding scope via using namespace, using alias, and extern alias.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal sealed class Imports
    {
        internal static readonly Imports Empty = new Imports(
            null,
            ImmutableDictionary<string, AliasAndUsingDirective>.Empty,
            ImmutableArray<NamespaceOrTypeAndUsingDirective>.Empty,
            ImmutableArray<AliasAndExternAliasDirective>.Empty,
            null);

        private readonly CSharpCompilation _compilation;
        private readonly DiagnosticBag _diagnostics;

        // completion state that tracks whether validation was done/not done/currently in process. 
        private SymbolCompletionState _state;

        public readonly ImmutableDictionary<string, AliasAndUsingDirective> UsingAliases;
        public readonly ImmutableArray<NamespaceOrTypeAndUsingDirective> Usings;
        public readonly ImmutableArray<AliasAndExternAliasDirective> ExternAliases;

        private Imports(
            CSharpCompilation compilation,
            ImmutableDictionary<string, AliasAndUsingDirective> usingAliases,
            ImmutableArray<NamespaceOrTypeAndUsingDirective> usings,
            ImmutableArray<AliasAndExternAliasDirective> externs,
            DiagnosticBag diagnostics)
        {
            Debug.Assert(usingAliases != null);
            Debug.Assert(!usings.IsDefault);
            Debug.Assert(!externs.IsDefault);

            _compilation = compilation;
            this.UsingAliases = usingAliases;
            this.Usings = usings;
            _diagnostics = diagnostics;
            this.ExternAliases = externs;
        }

        internal string GetDebuggerDisplay()
        {
            return string.Join("; ",
                UsingAliases.OrderBy(x => x.Value.UsingDirective.Location.SourceSpan.Start).Select(ua => $"{ua.Key} = {ua.Value.Alias.Target}").Concat(
                Usings.Select(u => u.NamespaceOrType.ToString())).Concat(
                ExternAliases.Select(ea => $"extern alias {ea.Alias.Name}")));

        }

        public static Imports FromSyntax(
            CSharpSyntaxNode declarationSyntax,
            InContainerBinder binder,
            ConsList<TypeSymbol> basesBeingResolved,
            bool inUsing)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public static Imports FromGlobalUsings(CSharpCompilation compilation)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        // TODO (https://github.com/dotnet/roslyn/issues/5517): skip namespace expansion if references haven't changed.
        internal static Imports ExpandPreviousSubmissionImports(Imports previousSubmissionImports, CSharpCompilation newSubmission)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static NamespaceSymbol ExpandPreviousSubmissionNamespace(NamespaceSymbol originalNamespace, NamespaceSymbol expandedGlobalNamespace)
        {
            // Soft assert: we'll still do the right thing if it fails.
            Debug.Assert(!originalNamespace.IsGlobalNamespace, "Global using to global namespace");

            // Hard assert: we depend on this.
            Debug.Assert(expandedGlobalNamespace.IsGlobalNamespace, "Global namespace required");

            var nameParts = ArrayBuilder<string>.GetInstance();
            var curr = originalNamespace;
            while (!curr.IsGlobalNamespace)
            {
                nameParts.Add(curr.Name);
                curr = curr.ContainingNamespace;
            }

            var expandedNamespace = expandedGlobalNamespace;
            for (int i = nameParts.Count - 1; i >= 0; i--)
            {
                // Note, the name may have become ambiguous (e.g. if a type with the same name
                // is now in scope), but we're not rebinding - we're just expanding to the
                // current contents of the same namespace.
                expandedNamespace = expandedNamespace.GetMembers(nameParts[i]).OfType<NamespaceSymbol>().Single();
            }
            nameParts.Free();

            return expandedNamespace;
        }

        public static Imports FromCustomDebugInfo(
            CSharpCompilation compilation,
            ImmutableDictionary<string, AliasAndUsingDirective> usingAliases,
            ImmutableArray<NamespaceOrTypeAndUsingDirective> usings,
            ImmutableArray<AliasAndExternAliasDirective> externs)
        {
            return new Imports(compilation, usingAliases, usings, externs, diagnostics: null);
        }

        /// <remarks>
        /// Does not preserve diagnostics.
        /// </remarks>
        internal Imports Concat(Imports otherImports)
        {
            Debug.Assert(otherImports != null);

            if (this == Empty)
            {
                return otherImports;
            }

            if (otherImports == Empty)
            {
                return this;
            }

            Debug.Assert(_compilation == otherImports._compilation);

            var usingAliases = this.UsingAliases.SetItems(otherImports.UsingAliases); // NB: SetItems, rather than AddRange
            var usings = this.Usings.AddRange(otherImports.Usings).Distinct(UsingTargetComparer.Instance);
            var externAliases = ConcatExternAliases(this.ExternAliases, otherImports.ExternAliases);

            return new Imports(_compilation, usingAliases, usings, externAliases, diagnostics: null);
        }

        private static ImmutableArray<AliasAndExternAliasDirective> ConcatExternAliases(ImmutableArray<AliasAndExternAliasDirective> externs1, ImmutableArray<AliasAndExternAliasDirective> externs2)
        {
            if (externs1.Length == 0)
            {
                return externs2;
            }

            if (externs2.Length == 0)
            {
                return externs1;
            }

            var replacedExternAliases = PooledHashSet<string>.GetInstance();
            replacedExternAliases.AddAll(externs2.Select(e => e.Alias.Name));
            return externs1.WhereAsArray(e => !replacedExternAliases.Contains(e.Alias.Name)).AddRange(externs2);
        }

        private static ImmutableArray<AliasAndExternAliasDirective> BuildExternAliases(
            SyntaxList<CSharpSyntaxNode> externAliasyntaxList,
            InContainerBinder binder,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void MarkImportDirective(CSharpSyntaxNode directive, bool callerIsSemanticModel)
        {
            MarkImportDirective(_compilation, directive, callerIsSemanticModel);
        }

        private static void MarkImportDirective(CSharpCompilation compilation, CSharpSyntaxNode directive, bool callerIsSemanticModel)
        {
            Debug.Assert(compilation != null); // If any directives are used, then there must be a compilation.
            if (directive != null && !callerIsSemanticModel)
            {
                compilation.MarkImportDirectiveAsUsed(directive);
            }
        }

        internal void Complete(CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                switch (incompletePart)
                {
                    case CompletionPart.StartValidatingImports:
                        {
                            if (_state.NotePartComplete(CompletionPart.StartValidatingImports))
                            {
                                Validate();
                                _state.NotePartComplete(CompletionPart.FinishValidatingImports);
                            }
                        }
                        break;

                    case CompletionPart.FinishValidatingImports:
                        // some other thread has started validating imports (otherwise we would be in the case above) so
                        // we just wait for it to both finish and report the diagnostics.
                        Debug.Assert(_state.HasComplete(CompletionPart.StartValidatingImports));
                        _state.SpinWaitComplete(CompletionPart.FinishValidatingImports, cancellationToken);
                        break;

                    case CompletionPart.None:
                        return;

                    default:
                        // any other values are completion parts intended for other kinds of symbols
                        _state.NotePartComplete(CompletionPart.All & ~CompletionPart.ImportsAll);
                        break;
                }

                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }
        }

        private void Validate()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal bool IsUsingAlias(string name, bool callerIsSemanticModel)
        {
            AliasAndUsingDirective node;
            if (this.UsingAliases.TryGetValue(name, out node))
            {
                // This method is called by InContainerBinder.LookupSymbolsInSingleBinder to see if
                // there's a conflict between an alias and a member.  As a conflict may cause a
                // speculative lambda binding to fail this is semantically relevant and we need to
                // mark this using alias as referenced (and thus not something that can be removed).
                MarkImportDirective(node.UsingDirective, callerIsSemanticModel);
                return true;
            }

            return false;
        }

        internal void LookupSymbol(
            Binder originalBinder,
            LookupResult result,
            string name,
            int arity,
            ConsList<TypeSymbol> basesBeingResolved,
            LookupOptions options,
            bool diagnose,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            LookupSymbolInAliases(originalBinder, result, name, arity, basesBeingResolved, options, diagnose, ref useSiteDiagnostics);

            if (!result.IsMultiViable && (options & LookupOptions.NamespaceAliasesOnly) == 0)
            {
                LookupSymbolInUsings(this.Usings, originalBinder, result, name, arity, basesBeingResolved, options, diagnose, ref useSiteDiagnostics);
            }
        }

        internal void LookupSymbolInAliases(
            Binder originalBinder,
            LookupResult result,
            string name,
            int arity,
            ConsList<TypeSymbol> basesBeingResolved,
            LookupOptions options,
            bool diagnose,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static void LookupSymbolInUsings(
            ImmutableArray<NamespaceOrTypeAndUsingDirective> usings,
            Binder originalBinder,
            LookupResult result,
            string name,
            int arity,
            ConsList<TypeSymbol> basesBeingResolved,
            LookupOptions options,
            bool diagnose,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static bool IsValidLookupCandidateInUsings(Symbol symbol)
        {
            switch (symbol.Kind)
            {
                // lookup via "using namespace" ignores namespaces inside
                case SymbolKind.Namespace:
                    return false;

                // lookup via "using static" ignores extension methods and non-static methods
                case SymbolKind.Method:
                    if (!symbol.IsStatic || ((MethodSymbol)symbol).IsExtensionMethod)
                    {
                        return false;
                    }

                    break;

                // types are considered static members for purposes of "using static" feature
                // regardless of whether they are declared with "static" modifier or not
                case SymbolKind.NamedType:
                    break;

                // lookup via "using static" ignores non-static members
                default:
                    if (!symbol.IsStatic)
                    {
                        return false;
                    }

                    break;
            }

            return true;
        }

        internal void LookupExtensionMethodsInUsings(
            ArrayBuilder<MethodSymbol> methods,
            string name,
            int arity,
            LookupOptions options,
            Binder originalBinder)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        // Note: we do not mark nodes when looking up arities or names.  This is because these two
        // types of lookup are only around to make the public
        // SemanticModel.LookupNames/LookupSymbols work and do not count as usages of the directives
        // when the actual code is bound.

        internal void AddLookupSymbolsInfo(LookupSymbolsInfo result, LookupOptions options, Binder originalBinder)
        {
            AddLookupSymbolsInfoInAliases(result, options, originalBinder);

            // Add types within namespaces imported through usings, but don't add nested namespaces.
            LookupOptions usingOptions = (options & ~(LookupOptions.NamespaceAliasesOnly | LookupOptions.NamespacesOrTypesOnly)) | LookupOptions.MustNotBeNamespace;
            AddLookupSymbolsInfoInUsings(this.Usings, result, usingOptions, originalBinder);
        }

        internal void AddLookupSymbolsInfoInAliases(LookupSymbolsInfo result, LookupOptions options, Binder originalBinder)
        {
            foreach (var (_, usingAlias) in this.UsingAliases)
            {
                AddAliasSymbolToResult(result, usingAlias.Alias, options, originalBinder);
            }

            foreach (var externAlias in this.ExternAliases)
            {
                AddAliasSymbolToResult(result, externAlias.Alias, options, originalBinder);
            }
        }

        private static void AddAliasSymbolToResult(LookupSymbolsInfo result, AliasSymbol aliasSymbol, LookupOptions options, Binder originalBinder)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static void AddLookupSymbolsInfoInUsings(
            ImmutableArray<NamespaceOrTypeAndUsingDirective> usings, LookupSymbolsInfo result, LookupOptions options, Binder originalBinder)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private class UsingTargetComparer : IEqualityComparer<NamespaceOrTypeAndUsingDirective>
        {
            public static readonly IEqualityComparer<NamespaceOrTypeAndUsingDirective> Instance = new UsingTargetComparer();

            private UsingTargetComparer() { }

            bool IEqualityComparer<NamespaceOrTypeAndUsingDirective>.Equals(NamespaceOrTypeAndUsingDirective x, NamespaceOrTypeAndUsingDirective y)
            {
                return x.NamespaceOrType.Equals(y.NamespaceOrType);
            }

            int IEqualityComparer<NamespaceOrTypeAndUsingDirective>.GetHashCode(NamespaceOrTypeAndUsingDirective obj)
            {
                return obj.NamespaceOrType.GetHashCode();
            }
        }
    }
}
