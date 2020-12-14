// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.Modeling;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// Represents symbols imported to the binding scope via using namespace, using alias, and extern alias.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    public sealed class Imports
    {
        public static readonly Imports Empty = new Imports(
            null,
            ImmutableDictionary<string, AliasAndUsingDirective>.Empty,
            ImmutableArray<NamespaceOrTypeAndUsingDirective>.Empty,
            ImmutableArray<AliasAndExternAliasDirective>.Empty,
            null);

        private readonly LanguageCompilation _compilation;
        private readonly DiagnosticBag _diagnostics;

        // completion state that tracks whether validation was done/not done/currently in process. 
        private CompletionState _state;

        public readonly ImmutableDictionary<string, AliasAndUsingDirective> UsingAliases;
        public readonly ImmutableArray<NamespaceOrTypeAndUsingDirective> Usings;
        public readonly ImmutableArray<AliasAndExternAliasDirective> ExternAliases;

        private Imports(
            LanguageCompilation compilation,
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

            if (_compilation != null) _state = CompletionState.Create(_compilation.Language);
            else _state = null;
        }

        internal string GetDebuggerDisplay()
        {
            return string.Join("; ",
                UsingAliases.OrderBy(x => x.Value.UsingDirective.Location.SourceSpan.Start).Select(ua => $"{ua.Key} = {ua.Value.Alias.Target}").Concat(
                Usings.Select(u => u.NamespaceOrType.ToString())).Concat(
                ExternAliases.Select(ea => $"extern alias {ea.Alias.Name}")));

        }

        public static Imports FromSyntax(
            LanguageSyntaxNode declarationSyntax,
            InContainerBinder binder,
            ConsList<TypeSymbol> basesBeingResolved,
            bool inUsing)
        {
            SyntaxFacts syntaxFacts = declarationSyntax.Language.SyntaxFacts;
            ImmutableArray<UsingDirective> usingDirectives = inUsing ? ImmutableArray<UsingDirective>.Empty : syntaxFacts.GetUsingDirectives(declarationSyntax);
            ImmutableArray<ExternAliasDirective> externAliasDirectives = syntaxFacts.GetExternAliasDirectives(declarationSyntax);

            if (usingDirectives.Length == 0 && externAliasDirectives.Length == 0)
            {
                return Empty;
            }

            // define all of the extern aliases first. They may used by the target of a using

            // using Bar=Goo::Bar;
            // using Goo::Baz;
            // extern alias Goo;

            var diagnostics = new DiagnosticBag();

            var compilation = binder.Compilation;

            var externAliases = BuildExternAliases(externAliasDirectives, binder, diagnostics);
            var usings = ArrayBuilder<NamespaceOrTypeAndUsingDirective>.GetInstance();
            ImmutableDictionary<string, AliasAndUsingDirective>.Builder usingAliases = null;
            if (usingDirectives.Length > 0)
            {
                // A binder that contains the extern aliases but not the usings. The resolution of the target of a using directive or alias 
                // should not make use of other peer usings.
                Binder usingsBinder;
                if (declarationSyntax.SyntaxTree.Options.Kind != SourceCodeKind.Regular)
                {
                    usingsBinder = compilation.GetBinderFactory(declarationSyntax.SyntaxTree).GetImportsBinder(declarationSyntax, inUsing: true);
                }
                else
                {
                    var imports = externAliases.Length == 0
                        ? Empty
                        : new Imports(
                            compilation,
                            ImmutableDictionary<string, AliasAndUsingDirective>.Empty,
                            ImmutableArray<NamespaceOrTypeAndUsingDirective>.Empty,
                            externAliases,
                            diagnostics: null);
                    usingsBinder = new InContainerBinder(binder.Container, binder.Next, imports);
                }

                var uniqueUsings = PooledHashSet<NamespaceOrTypeSymbol>.GetInstance();

                foreach (var usingDirective in usingDirectives)
                {
                    compilation.RecordImport(usingDirective);

                    if (usingDirective.AliasName != null)
                    {
                        if (usingDirective.IsGlobal)
                        {
                            diagnostics.Add(InternalErrorCode.WRN_GlobalAliasDefn, usingDirective.AliasName.GetLocation());
                        }

                        if (usingDirective.IsStatic)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_NoAliasHere, usingDirective.AliasName.GetLocation());
                        }

                        string identifierValueText = syntaxFacts.ExtractName(usingDirective.AliasName);
                        if (usingAliases != null && usingAliases.ContainsKey(identifierValueText))
                        {
                            // Suppress diagnostics if we're already broken.
                            if (!usingDirective.TargetName.IsMissing)
                            {
                                // The using alias '{0}' appeared previously in this namespace
                                diagnostics.Add(InternalErrorCode.ERR_DuplicateAlias, usingDirective.AliasName.GetLocation(), identifierValueText);
                            }
                        }
                        else
                        {
                            // an O(m*n) algorithm here but n (number of extern aliases) will likely be very small.
                            foreach (var externAlias in externAliases)
                            {
                                if (externAlias.Alias.Name == identifierValueText)
                                {
                                    // The using alias '{0}' appeared previously in this namespace
                                    diagnostics.Add(InternalErrorCode.ERR_DuplicateAlias, usingDirective.Location, identifierValueText);
                                    break;
                                }
                            }

                            if (usingAliases == null)
                            {
                                usingAliases = ImmutableDictionary.CreateBuilder<string, AliasAndUsingDirective>();
                            }

                            // construct the alias sym with the binder for which we are building imports. That
                            // way the alias target can make use of extern alias definitions.
                            usingAliases.Add(identifierValueText, new AliasAndUsingDirective(AliasSymbol.CreateUsing(identifierValueText, usingDirective, usingsBinder), usingDirective));
                        }
                    }
                    else
                    {
                        if (usingDirective.TargetName.IsMissing)
                        {
                            //don't try to lookup namespaces inserted by parser error recovery
                            continue;
                        }

                        var declarationBinder = usingsBinder.WithAdditionalFlags(BinderFlags.SuppressConstraintChecks);
                        var imported = declarationBinder.BindNamespaceOrTypeSymbol(usingDirective.TargetName, diagnostics, basesBeingResolved);
                        if (imported.Kind == LanguageSymbolKind.Namespace)
                        {
                            if (usingDirective.IsStatic)
                            {
                                diagnostics.Add(InternalErrorCode.ERR_BadUsingType, usingDirective.TargetName.GetLocation(), imported);
                            }
                            else if (uniqueUsings.Contains(imported))
                            {
                                diagnostics.Add(InternalErrorCode.WRN_DuplicateUsing, usingDirective.TargetName.GetLocation(), imported);
                            }
                            else
                            {
                                uniqueUsings.Add(imported);
                                usings.Add(new NamespaceOrTypeAndUsingDirective(imported, usingDirective));
                            }
                        }
                        else if (imported.Kind == LanguageSymbolKind.NamedType)
                        {
                            if (usingDirective.IsStatic)
                            {
                                diagnostics.Add(InternalErrorCode.ERR_BadUsingNamespace, usingDirective.TargetName.GetLocation(), imported);
                            }
                            else
                            {
                                var importedType = (NamedTypeSymbol)imported;
                                if (uniqueUsings.Contains(importedType))
                                {
                                    diagnostics.Add(InternalErrorCode.WRN_DuplicateUsing, usingDirective.TargetName.GetLocation(), importedType);
                                }
                                else
                                {
                                    declarationBinder.ReportDiagnosticsIfObsolete(diagnostics, importedType, usingDirective.TargetName, hasBaseReceiver: false);

                                    uniqueUsings.Add(importedType);
                                    usings.Add(new NamespaceOrTypeAndUsingDirective(importedType, usingDirective));
                                }
                            }
                        }
                        else if (imported.Kind != LanguageSymbolKind.ErrorType)
                        {
                            // Do not report additional error if the symbol itself is erroneous.

                            // error: '<symbol>' is a '<symbol kind>' but is used as 'type or namespace'
                            diagnostics.Add(InternalErrorCode.ERR_BadSKknown, usingDirective.TargetName.GetLocation(), usingDirective.TargetName, imported.GetKindText(), "type or namespace");
                        }
                    }
                }

                uniqueUsings.Free();
            }

            var boundSymbolDef = compilation.GetBoundNode<BoundSymbolDef>(declarationSyntax);
            if (boundSymbolDef != null)
            {
                foreach (var symbol in boundSymbolDef.Symbols)
                {
                    var importProps = symbol.ModelSymbolInfo.Properties.Where(p => p.IsImport).ToImmutableArray();
                    foreach (var prop in importProps)
                    {
                        var boundProps = boundSymbolDef.GetChildProperties(prop.Name);
                        foreach (var boundProp in boundProps)
                        {
                            foreach (var boundValue in boundProp.BoundValues)
                            {
                                foreach (var value in boundValue.Values)
                                {
                                    var importedSymbol = value as NamespaceOrTypeSymbol;
                                    if (symbol != null)
                                    {
                                        bool isStaticImport = importedSymbol is NamedTypeSymbol;
                                        usings.Add(new NamespaceOrTypeAndUsingDirective(importedSymbol, new UsingDirective(declarationSyntax, null, boundValue.Syntax, isStaticImport, false)));
                                    }
                                    else
                                    {
                                        diagnostics.Add(ModelErrorCode.ERR_InvalidImport, boundValue.Syntax.Location, value);
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }

            if (diagnostics.IsEmptyWithoutResolution)
            {
                diagnostics = null;
            }

            return new Imports(compilation, usingAliases.ToImmutableDictionaryOrEmpty(), usings.ToImmutableAndFree(), externAliases, diagnostics);
        }

        public static Imports FromGlobalUsings(LanguageCompilation compilation)
        {
            var usings = compilation.Options.Usings;

            if (usings.Length == 0 && compilation.PreviousSubmission == null)
            {
                return Empty;
            }

            var diagnostics = new DiagnosticBag();
            var usingsBinder = new InContainerBinder(compilation.GlobalNamespace, new BuckStopsHereBinder(compilation));
            var boundUsings = ArrayBuilder<NamespaceOrTypeAndUsingDirective>.GetInstance();
            var uniqueUsings = PooledHashSet<NamespaceOrTypeSymbol>.GetInstance();

            var syntaxFacts = compilation.Language.SyntaxFacts;

            foreach (string @using in usings)
            {
                if (!@using.IsValidClrNamespaceName())
                {
                    continue;
                }
                var qualifiedName = syntaxFacts.ExtractQualifiedName(@using);
                var imported = usingsBinder.BindNamespaceOrTypeSymbol(qualifiedName, diagnostics);
                if (uniqueUsings.Add(imported))
                {
                    boundUsings.Add(new NamespaceOrTypeAndUsingDirective(imported, null));
                }
            }

            if (diagnostics.IsEmptyWithoutResolution)
            {
                diagnostics = null;
            }

            var previousSubmissionImports = compilation.PreviousSubmission?.GlobalImports;
            if (previousSubmissionImports != null)
            {
                // Currently, only usings are supported.
                Debug.Assert(previousSubmissionImports.UsingAliases.IsEmpty);
                Debug.Assert(previousSubmissionImports.ExternAliases.IsEmpty);

                var expandedImports = ExpandPreviousSubmissionImports(previousSubmissionImports, compilation);

                foreach (var previousUsing in expandedImports.Usings)
                {
                    if (uniqueUsings.Add(previousUsing.NamespaceOrType))
                    {
                        boundUsings.Add(previousUsing);
                    }
                }
            }

            uniqueUsings.Free();

            if (boundUsings.Count == 0)
            {
                boundUsings.Free();
                return Empty;
            }

            return new Imports(compilation, ImmutableDictionary<string, AliasAndUsingDirective>.Empty, boundUsings.ToImmutableAndFree(), ImmutableArray<AliasAndExternAliasDirective>.Empty, diagnostics);
        }

        // TODO (https://github.com/dotnet/roslyn/issues/5517): skip namespace expansion if references haven't changed.
        internal static Imports ExpandPreviousSubmissionImports(Imports previousSubmissionImports, LanguageCompilation newSubmission)
        {
            if (previousSubmissionImports == Empty)
            {
                return Empty;
            }

            Debug.Assert(previousSubmissionImports != null);
            Debug.Assert(previousSubmissionImports._compilation.IsSubmission);
            Debug.Assert(newSubmission.IsSubmission);

            var expandedGlobalNamespace = newSubmission.GlobalNamespace;

            var expandedAliases = ImmutableDictionary<string, AliasAndUsingDirective>.Empty;
            if (!previousSubmissionImports.UsingAliases.IsEmpty)
            {
                var expandedAliasesBuilder = ImmutableDictionary.CreateBuilder<string, AliasAndUsingDirective>();
                foreach (var pair in previousSubmissionImports.UsingAliases)
                {
                    var name = pair.Key;
                    var directive = pair.Value;
                    expandedAliasesBuilder.Add(name, new AliasAndUsingDirective(directive.Alias.ToNewSubmission(newSubmission), directive.UsingDirective));
                }
                expandedAliases = expandedAliasesBuilder.ToImmutable();
            }

            var expandedUsings = ImmutableArray<NamespaceOrTypeAndUsingDirective>.Empty;
            if (!previousSubmissionImports.Usings.IsEmpty)
            {
                var expandedUsingsBuilder = ArrayBuilder<NamespaceOrTypeAndUsingDirective>.GetInstance(previousSubmissionImports.Usings.Length);
                foreach (var previousUsing in previousSubmissionImports.Usings)
                {
                    var previousTarget = previousUsing.NamespaceOrType;
                    if (previousTarget.IsType)
                    {
                        expandedUsingsBuilder.Add(previousUsing);
                    }
                    else
                    {
                        var expandedNamespace = ExpandPreviousSubmissionNamespace((NamespaceSymbol)previousTarget, expandedGlobalNamespace);
                        expandedUsingsBuilder.Add(new NamespaceOrTypeAndUsingDirective(expandedNamespace, previousUsing.UsingDirective));
                    }
                }
                expandedUsings = expandedUsingsBuilder.ToImmutableAndFree();
            }

            return new Imports(
                newSubmission,
                expandedAliases,
                expandedUsings,
                previousSubmissionImports.ExternAliases,
                diagnostics: null);
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
            LanguageCompilation compilation,
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
            ImmutableArray<ExternAliasDirective> directiveList,
            InContainerBinder binder,
            DiagnosticBag diagnostics)
        {
            LanguageCompilation compilation = binder.Compilation;
            SyntaxFacts syntaxFacts = compilation.Language.SyntaxFacts;

            var builder = ArrayBuilder<AliasAndExternAliasDirective>.GetInstance();

            foreach (ExternAliasDirective aliasSyntax in directiveList)
            {
                compilation.RecordImport(aliasSyntax);

                // Extern aliases not allowed in interactive submissions:
                if (compilation.IsSubmission)
                {
                    diagnostics.Add(InternalErrorCode.ERR_ExternAliasNotAllowed, aliasSyntax.Location);
                    continue;
                }

                string aliasName = syntaxFacts.ExtractName(aliasSyntax.AliasName);
                // some n^2 action, but n should be very small.
                foreach (var existingAlias in builder)
                {
                    if (existingAlias.Alias.Name == aliasName)
                    {
                        diagnostics.Add(InternalErrorCode.ERR_DuplicateAlias, existingAlias.Alias.Locations[0], existingAlias.Alias.Name);
                        break;
                    }
                }

                /* TODO:MetaDslx?
                if (aliasSyntax.Identifier.ContextualKind() == SyntaxKind.GlobalKeyword)
                {
                    diagnostics.Add(InternalErrorCode.ERR_GlobalExternAlias, aliasSyntax.Identifier.GetLocation());
                }
                */

                builder.Add(new AliasAndExternAliasDirective(AliasSymbol.CreateExternAlias(aliasName, aliasSyntax, binder), aliasSyntax));
            }

            return builder.ToImmutableAndFree();
        }

        private void MarkImportDirective(ExternAliasDirective directive, bool callerIsSemanticModel)
        {
            MarkImportDirective(_compilation, directive.SyntaxNode, callerIsSemanticModel);
        }

        private void MarkImportDirective(UsingDirective directive, bool callerIsSemanticModel)
        {
            MarkImportDirective(_compilation, directive.SyntaxNode, callerIsSemanticModel);
        }

        private static void MarkImportDirective(LanguageCompilation compilation, LanguageSyntaxNode directive, bool callerIsSemanticModel)
        {
            Debug.Assert(compilation != null); // If any directives are used, then there must be a compilation.
            if (directive != null && !callerIsSemanticModel)
            {
                compilation.MarkImportDirectiveAsUsed(directive);
            }
        }

        internal void Complete(CancellationToken cancellationToken)
        {
            if (_state == null) return;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.StartValidatingImports)
                {
                    if (_state.NotePartComplete(CompletionPart.StartValidatingImports))
                    {
                        Validate();
                        _state.NotePartComplete(CompletionPart.FinishValidatingImports);
                    }
                }
                else if (incompletePart == CompletionPart.FinishValidatingImports)
                {
                    // some other thread has started validating imports (otherwise we would be in the case above) so
                    // we just wait for it to both finish and report the diagnostics.
                    Debug.Assert(_state.HasComplete(CompletionPart.StartValidatingImports));
                    _state.SpinWaitComplete(CompletionPart.FinishValidatingImports, cancellationToken);
                }
                else if (incompletePart == null || incompletePart == CompletionPart.None)
                {
                    return;
                }
                else
                {
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                    Debug.Assert(!CompletionPart.ImportsAll.Contains(incompletePart));
                }
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }
        }

        private void Validate()
        {
            if (this == Empty)
            {
                return;
            }

            DiagnosticBag semanticDiagnostics = _compilation.DeclarationDiagnostics;

            // Check constraints within named aliases.

            // Force resolution of named aliases.
            foreach (var (_, alias) in UsingAliases)
            {
                alias.Alias.GetAliasTarget(basesBeingResolved: null);
                semanticDiagnostics.AddRange(alias.Alias.AliasTargetDiagnostics);
            }

            foreach (var (_, alias) in UsingAliases)
            {
                alias.Alias.CheckConstraints(semanticDiagnostics);
            }

            var corLibrary = _compilation.SourceAssembly.CorLibrary;
            var conversions = new TypeConversions(corLibrary);
            foreach (var @using in Usings)
            {
                // Check if `using static` directives meet constraints.
                if (@using.NamespaceOrType.IsType)
                {
                    var typeSymbol = (TypeSymbol)@using.NamespaceOrType;
                    var location = @using.UsingDirective?.TargetName.GetLocation() ?? NoLocation.Singleton;
                    typeSymbol.CheckAllConstraints(_compilation, conversions, location, semanticDiagnostics);
                }
            }

            // Force resolution of extern aliases.
            foreach (var alias in ExternAliases)
            {
                alias.Alias.GetAliasTarget(null);
                semanticDiagnostics.AddRange(alias.Alias.AliasTargetDiagnostics);
            }

            if (_diagnostics != null && !_diagnostics.IsEmptyWithoutResolution)
            {
                semanticDiagnostics.AddRange(_diagnostics.AsEnumerable());
            }
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

        internal void LookupSymbol(LookupResult result, LookupConstraints constraints)
        {
            LookupSymbolInAliases(result, constraints);

            if (!result.IsMultiViable && (constraints.Options & LookupOptions.NamespaceAliasesOnly) == 0)
            {
                LookupSymbolInUsings(this.Usings, result, constraints);
            }
        }

        internal void LookupSymbolInAliases(LookupResult result, LookupConstraints constraints)
        {
            bool callerIsSemanticModel = constraints.OriginalBinder.IsSemanticModelBinder;

            AliasAndUsingDirective alias;
            if (this.UsingAliases.TryGetValue(constraints.Name, out alias))
            {
                // Found a match in our list of normal aliases.  Mark the alias as being seen so that
                // it won't be reported to the user as something that can be removed.
                var res = constraints.OriginalBinder.CheckViability(alias.Alias, constraints.WithAccessThroughType(null));
                if (res.Kind == LookupResultKind.Viable)
                {
                    MarkImportDirective(alias.UsingDirective, callerIsSemanticModel);
                }

                result.MergeEqual(res);
            }

            foreach (var a in this.ExternAliases)
            {
                if (a.Alias.Name == constraints.Name)
                {
                    // Found a match in our list of extern aliases.  Mark the extern alias as being
                    // seen so that it won't be reported to the user as something that can be
                    // removed.
                    var res = constraints.OriginalBinder.CheckViability(a.Alias, constraints.WithAccessThroughType(null));
                    if (res.Kind == LookupResultKind.Viable)
                    {
                        MarkImportDirective(a.ExternAliasDirective, callerIsSemanticModel);
                    }

                    result.MergeEqual(res);
                }
            }
        }

        internal static void LookupSymbolInUsings(
            ImmutableArray<NamespaceOrTypeAndUsingDirective> usings,
            LookupResult result,
            LookupConstraints constraints)
        {
            if (constraints.OriginalBinder.Flags.Includes(BinderFlags.InScriptUsing))
            {
                return;
            }

            bool callerIsSemanticModel = constraints.OriginalBinder.IsSemanticModelBinder;

            foreach (var typeOrNamespace in usings)
            {
                ImmutableArray<DeclaredSymbol> candidates = Binder.GetCandidateMembers(constraints.WithQualifier(typeOrNamespace.NamespaceOrType));
                foreach (DeclaredSymbol symbol in candidates)
                {
                    if (!IsValidLookupCandidateInUsings(symbol))
                    {
                        continue;
                    }

                    // Found a match in our list of normal using directives.  Mark the directive
                    // as being seen so that it won't be reported to the user as something that
                    // can be removed.
                    var res = constraints.OriginalBinder.CheckViability(symbol, constraints.WithAccessThroughType(null));
                    if (res.Kind == LookupResultKind.Viable)
                    {
                        MarkImportDirective(constraints.OriginalBinder.Compilation, typeOrNamespace.UsingDirective.SyntaxNode, callerIsSemanticModel);
                    }

                    result.MergeEqual(res);
                }
            }
        }

        private static bool IsValidLookupCandidateInUsings(DeclaredSymbol symbol)
        {
            switch (symbol.Kind.Switch())
            {
                // lookup via "using namespace" ignores namespaces inside
                case LanguageSymbolKind.Namespace:
                    return false;

                // lookup via "using static" ignores extension methods and non-static methods
                case LanguageSymbolKind.Operation:
                    if (!symbol.IsStatic)
                    {
                        return false;
                    }

                    break;

                // types are considered static members for purposes of "using static" feature
                // regardless of whether they are declared with "static" modifier or not
                case LanguageSymbolKind.NamedType:
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

        // Note: we do not mark nodes when looking up arities or names.  This is because these two
        // types of lookup are only around to make the public
        // SemanticModel.LookupNames/LookupSymbols work and do not count as usages of the directives
        // when the actual code is bound.

        internal void AddLookupSymbolsInfo(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            AddLookupSymbolsInfoInAliases(result, constraints);

            // Add types within namespaces imported through usings, but don't add nested namespaces.
            LookupOptions usingOptions = (constraints.Options & ~(LookupOptions.NamespaceAliasesOnly | LookupOptions.NamespacesOrTypesOnly)) | LookupOptions.MustNotBeNamespace;
            AddLookupSymbolsInfoInUsings(this.Usings, result, constraints.WithOptions(usingOptions));
        }

        internal void AddLookupSymbolsInfoInAliases(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            foreach (var (_, usingAlias) in this.UsingAliases)
            {
                AddAliasSymbolToResult(result, usingAlias.Alias, constraints);
            }

            foreach (var externAlias in this.ExternAliases)
            {
                AddAliasSymbolToResult(result, externAlias.Alias, constraints);
            }
        }

        private static void AddAliasSymbolToResult(LookupSymbolsInfo result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            var targetSymbol = aliasSymbol.GetAliasTarget(basesBeingResolved: null);
            if (constraints.OriginalBinder.CanAddLookupSymbolInfo(targetSymbol, result, constraints.WithAccessThroughType(null), aliasSymbol: aliasSymbol))
            {
                result.AddSymbol(aliasSymbol, aliasSymbol.Name, aliasSymbol.Name);
            }
        }

        private static void AddLookupSymbolsInfoInUsings(
            ImmutableArray<NamespaceOrTypeAndUsingDirective> usings, LookupSymbolsInfo result, LookupConstraints constraints)
        {
            if (constraints.OriginalBinder.Flags.Includes(BinderFlags.InScriptUsing))
            {
                return;
            }

            Debug.Assert(!constraints.Options.CanConsiderNamespaces());

            // look in all using namespaces
            foreach (var namespaceSymbol in usings)
            {
                foreach (var member in namespaceSymbol.NamespaceOrType.GetMembersUnordered())
                {
                    if (IsValidLookupCandidateInUsings(member) && constraints.OriginalBinder.CanAddLookupSymbolInfo(member, result, constraints, null))
                    {
                        result.AddSymbol(member, member.Name, member.MetadataName);
                    }
                }
            }
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
