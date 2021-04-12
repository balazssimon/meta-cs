// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MetaDslx.CodeAnalysis.Collections;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;

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
            ImmutableArray<DeclaredSymbolAndUsingDirective>.Empty,
            ImmutableArray<AliasAndExternAliasDirective>.Empty,
            null);

        private readonly LanguageCompilation _compilation;
        private readonly DiagnosticBag _diagnostics;

        // completion state that tracks whether validation was done/not done/currently in process. 
        private CompletionState _state;

        public readonly ImmutableDictionary<string, AliasAndUsingDirective> UsingAliases;
        public readonly ImmutableArray<DeclaredSymbolAndUsingDirective> Usings;
        public readonly ImmutableArray<AliasAndExternAliasDirective> ExternAliases;

        private Imports(
            LanguageCompilation compilation,
            ImmutableDictionary<string, AliasAndUsingDirective> usingAliases,
            ImmutableArray<DeclaredSymbolAndUsingDirective> usings,
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

        public ImmutableArray<Diagnostic> Diagnostics => _diagnostics != null ? _diagnostics.ToReadOnly() : ImmutableArray<Diagnostic>.Empty;

        internal string GetDebuggerDisplay()
        {
            return string.Join("; ",
                UsingAliases.OrderBy(x => x.Value.UsingDirective.Location.SourceSpan.Start).Select(ua => $"{ua.Key} = {ua.Value.Alias.Target}").Concat(
                Usings.Select(u => u.DeclaredSymbol.ToString())).Concat(
                ExternAliases.Select(ea => $"extern alias {ea.Alias.Name}")));

        }

        public static Imports FromSyntax(
            SyntaxNodeOrToken syntax,
            DeclaredSymbol container,
            Binder scopeBinder,
            LookupConstraints constraints)
        {
            var diagnostics = new DiagnosticBag();
            Binder containerBinder;
            SyntaxNodeOrToken containerSyntax;

            var symbolDefBinder = FindBinders.FindFirstOrDefaultSymbolBinder(container, syntax.GetReference());
            if (symbolDefBinder.Binder != null)
            {
                containerBinder = symbolDefBinder.Binder;
                containerSyntax = symbolDefBinder.Syntax;
            }
            else
            {
                return Imports.Empty;
                // TODO:MetaDslx
                /*
                var rootBinder = FindBinders.FindCompilationUnitRootBinder(binder.GetBinderPosition());
                Debug.Assert(rootBinder.Binder != null);
                if (rootBinder.Binder != null)
                {
                    containerBinder = rootBinder.Binder;
                    containerSyntax = rootBinder.Syntax;
                }
                else
                {
                    return Imports.Empty;
                }*/
            }

            ImmutableArray<UsingDirective> usingDirectives = constraints.InUsing ? ImmutableArray<UsingDirective>.Empty : BuildUsingDirectives(containerSyntax, containerBinder, diagnostics);
            ImmutableArray<ExternAliasDirective> externAliasDirectives = BuildExternAliasDirectives(containerSyntax, containerBinder, diagnostics);

            if (usingDirectives.Length == 0 && externAliasDirectives.Length == 0)
            {
                return Empty;
            }

            // define all of the extern aliases first. They may used by the target of a using

            // using Bar=Goo::Bar;
            // using Goo::Baz;
            // extern alias Goo;

            var compilation = scopeBinder.Compilation;
            var language = compilation.Language;

            var externAliases = BuildExternAliases(externAliasDirectives, containerBinder, diagnostics);
            var usings = ArrayBuilder<DeclaredSymbolAndUsingDirective>.GetInstance();
            ImmutableDictionary<string, AliasAndUsingDirective>.Builder usingAliases = null;
            if (usingDirectives.Length > 0)
            {
                // A binder that contains the extern aliases but not the usings. The resolution of the target of a using directive or alias 
                // should not make use of other peer usings.
                Binder usingsBinder;
                if (containerSyntax.SyntaxTree.Options.Kind != SourceCodeKind.Regular)
                {
                    usingsBinder = containerBinder.Next;
                }
                else
                {
                    var imports = externAliases.Length == 0
                        ? Empty
                        : new Imports(
                            compilation,
                            ImmutableDictionary<string, AliasAndUsingDirective>.Empty,
                            ImmutableArray<DeclaredSymbolAndUsingDirective>.Empty,
                            externAliases,
                            diagnostics: null);
                    usingsBinder = new InContainerBinder(container, containerBinder.Next, imports);
                }

                var uniqueUsings = PooledHashSet<DeclaredSymbol>.GetInstance();

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

                        string identifierValueText = language.SyntaxFacts.ExtractName(usingDirective.AliasName);
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
                        if (usingDirective.TargetName.IsMissing || usingDirective.TargetQualifiedName.IsDefaultOrEmpty)
                        {
                            //don't try to lookup namespaces inserted by parser error recovery
                            continue;
                        }

                        var declarationBinder = usingsBinder.WithAdditionalFlags(BinderFlags.SuppressConstraintChecks);
                        var target = declarationBinder.BindQualifiedName(usingDirective.TargetQualifiedName, diagnostics, constraints.WithInUsing(true));
                        var imported = target.Length > 0 ? target[target.Length - 1] : null;
                        if (imported == null) continue;

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
                                usings.Add(new DeclaredSymbolAndUsingDirective(imported, usingDirective));
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
                                    uniqueUsings.Add(importedType);
                                    usings.Add(new DeclaredSymbolAndUsingDirective(importedType, usingDirective));
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
            var boundUsings = ArrayBuilder<DeclaredSymbolAndUsingDirective>.GetInstance();
            var uniqueUsings = PooledHashSet<DeclaredSymbol>.GetInstance();

            var syntaxFacts = compilation.Language.SyntaxFacts;

            foreach (string @using in usings)
            {
                if (!@using.IsValidClrNamespaceName())
                {
                    continue;
                }
                var qualifiedName = syntaxFacts.ExtractQualifiedName(@using);
                var imported = usingsBinder.BindQualifiedName(qualifiedName, null, diagnostics, new LookupConstraints(usingsBinder, inUsing: true)).LastOrDefault();
                if (uniqueUsings.Add(imported))
                {
                    boundUsings.Add(new DeclaredSymbolAndUsingDirective(imported, null));
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
                    if (uniqueUsings.Add(previousUsing.DeclaredSymbol))
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

            var expandedUsings = ImmutableArray<DeclaredSymbolAndUsingDirective>.Empty;
            if (!previousSubmissionImports.Usings.IsEmpty)
            {
                var expandedUsingsBuilder = ArrayBuilder<DeclaredSymbolAndUsingDirective>.GetInstance(previousSubmissionImports.Usings.Length);
                foreach (var previousUsing in previousSubmissionImports.Usings)
                {
                    var previousTarget = previousUsing.DeclaredSymbol;
                    if (previousTarget is NamespaceSymbol previousNamespace)
                    {
                        var expandedNamespace = ExpandPreviousSubmissionNamespace(previousNamespace, expandedGlobalNamespace);
                        expandedUsingsBuilder.Add(new DeclaredSymbolAndUsingDirective(expandedNamespace, previousUsing.UsingDirective));
                    }
                    else
                    {
                        expandedUsingsBuilder.Add(previousUsing);
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
            ImmutableArray<DeclaredSymbolAndUsingDirective> usings,
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

        private static ImmutableArray<ExternAliasDirective> BuildExternAliasDirectives(
            SyntaxNodeOrToken syntax,
            Binder binder,
            DiagnosticBag diagnostics)
        {
            LanguageCompilation compilation = binder.Compilation;
            SyntaxFacts syntaxFacts = compilation.Language.SyntaxFacts;

            var builder = ArrayBuilder<ExternAliasDirective>.GetInstance();

            var binderPosition = binder.GetBinderPosition();
            var importBinders = FindBinders.FindImportBinders(binderPosition);
            foreach (var importBinder in importBinders.Where(ib => ib.Binder.IsExtern))
            {
                var names = FindBinders.FindNameBinders(importBinder);
                if (names.Length > 0)
                {
                    foreach (var name in names)
                    {
                        builder.Add(new ExternAliasDirective((LanguageSyntaxNode)importBinder.Syntax.NodeOrParent, name.Syntax));
                    }
                }
            }
            return builder.ToImmutableAndFree();
        }

        private static ImmutableArray<UsingDirective> BuildUsingDirectives(
            SyntaxNodeOrToken syntax,
            Binder binder,
            DiagnosticBag diagnostics)
        {
            LanguageCompilation compilation = binder.Compilation;
            SyntaxFacts syntaxFacts = compilation.Language.SyntaxFacts;

            var builder = ArrayBuilder<UsingDirective>.GetInstance();

            var binderPosition = binder.GetBinderPosition();
            var importBinders = FindBinders.FindImportBinders(binderPosition);
            foreach (var importBinder in importBinders.Where(ib => !ib.Binder.IsExtern))
            {
                var nameBinders = FindBinders.FindNameBinders(importBinder);
                if (nameBinders.Length > 0)
                {
                    foreach (var nameBinder in nameBinders)
                    {
                        var valueBinders = FindBinders.FindValueBinders(importBinder);
                        Debug.Assert(valueBinders.Length == 1);
                        if (valueBinders.Length >= 1)
                        {
                            var isGlobal = syntaxFacts.IsGlobalAlias(nameBinder.Syntax);
                            var valueBinder = valueBinders[0];
                            var identifierBinders = FindBinders.FindIdentifierBinders(valueBinders[0]);
                            var identifiers = identifierBinders.SelectAsArray(ib => ib.Syntax);
                            builder.Add(new UsingDirective((LanguageSyntaxNode)importBinder.Syntax.NodeOrParent, nameBinder.Syntax, valueBinders[0].Syntax, identifiers, importBinder.Binder.IsStatic, isGlobal));
                        }
                    }
                }
                else
                {
                    var valueBinders = FindBinders.FindValueBinders(importBinder);
                    Debug.Assert(valueBinders.Length == 1);
                    if (valueBinders.Length >= 1)
                    {
                        var valueBinder = valueBinders[0];
                        var identifierBinders = FindBinders.FindIdentifierBinders(valueBinders[0]);
                        var identifiers = identifierBinders.SelectAsArray(ib => ib.Syntax);
                        builder.Add(new UsingDirective((LanguageSyntaxNode)importBinder.Syntax.NodeOrParent, null, valueBinders[0].Syntax, identifiers, importBinder.Binder.IsStatic, false));
                    }
                }
            }
            return builder.ToImmutableAndFree();
        }

        private static ImmutableArray<AliasAndExternAliasDirective> BuildExternAliases(
            ImmutableArray<ExternAliasDirective> directiveList,
            Binder binder,
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

                if (syntaxFacts.IsGlobalAlias(aliasSyntax.AliasName))
                {
                    diagnostics.Add(InternalErrorCode.ERR_GlobalExternAlias, aliasSyntax.AliasName.GetLocation());
                }

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
                alias.Alias.GetAliasTarget(null);
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
                if (@using.DeclaredSymbol is TypeSymbol typeSymbol)
                {
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

        private static bool IsValidLookupCandidateInUsings(DeclaredSymbol symbol)
        {
            switch (symbol.Kind.Switch())
            {
                // lookup via "using namespace" ignores namespaces inside
                case LanguageSymbolKind.Namespace:
                    return false;

                // lookup via "using static" ignores extension methods and non-static methods
                case LanguageSymbolKind.Member:
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

        internal void AddLookupCandidateSymbols(LookupCandidates result, LookupConstraints constraints)
        {
            AddLookupCandidateSymbolsInAliases(result, constraints);

            // Add types within namespaces imported through usings, but don't add nested namespaces.
            AddLookupCandidateSymbolsInUsings(this.Usings, result, constraints.WithAdditionalValidators(LookupValidators.MustNotBeNamespace));
        }

        internal void AddLookupCandidateSymbolsInAliases(LookupCandidates result, LookupConstraints constraints)
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

        private static void AddAliasSymbolToResult(LookupCandidates result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            if (constraints.WithAccessThroughType(null).IsViable(aliasSymbol))
            {
                result.Add(aliasSymbol);
            }
        }

        private static void AddLookupCandidateSymbolsInUsings(
            ImmutableArray<DeclaredSymbolAndUsingDirective> usings, LookupCandidates result, LookupConstraints constraints)
        {
            var binder = constraints.OriginalBinder;
            if (binder.Flags.Includes(BinderFlags.InScriptUsing))
            {
                return;
            }

            Debug.Assert(constraints.Validators.Contains(LookupValidators.MustNotBeNamespace));

            // look in all using namespaces
            foreach (var namespaceSymbol in usings)
            {
                foreach (var member in namespaceSymbol.DeclaredSymbol.GetMembersUnordered())
                {
                    if (IsValidLookupCandidateInUsings(member) && constraints.IsViable(member))
                    {
                        result.Add(member);
                        if (constraints.IsLookup) MarkImportDirective(binder.Compilation, namespaceSymbol.UsingDirective.SyntaxNode, binder.IsSemanticModelBinder);
                    }
                }
            }
        }

        private class UsingTargetComparer : IEqualityComparer<DeclaredSymbolAndUsingDirective>
        {
            public static readonly IEqualityComparer<DeclaredSymbolAndUsingDirective> Instance = new UsingTargetComparer();

            private UsingTargetComparer() { }

            bool IEqualityComparer<DeclaredSymbolAndUsingDirective>.Equals(DeclaredSymbolAndUsingDirective x, DeclaredSymbolAndUsingDirective y)
            {
                return x.DeclaredSymbol.Equals(y.DeclaredSymbol);
            }

            int IEqualityComparer<DeclaredSymbolAndUsingDirective>.GetHashCode(DeclaredSymbolAndUsingDirective obj)
            {
                return obj.DeclaredSymbol.GetHashCode();
            }
        }
    }
}
