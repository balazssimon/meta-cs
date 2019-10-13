// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    public partial class Binder
    {
        /// <summary>
        /// Performs name lookup for simple generic or non-generic name
        /// within an optional qualifier namespace or type symbol.
        /// If LookupOption.AttributeTypeOnly is set, then it performs
        /// attribute type lookup which involves attribute name lookup
        /// with and without "Attribute" suffix.
        /// </summary>
        public void LookupSymbolsSimpleName(
            LookupResult result,
            LookupConstraints constraints)
        {
            constraints = this.AdjustConstraints(constraints);
            if (constraints.Options.IsAttributeTypeLookup())
            {
                this.LookupAttributeType(result, constraints);
            }
            else
            {
                this.LookupSymbolsOrMembersInternal(result, constraints);
            }
        }

        /// <summary>
        /// Look for any symbols in scope with the given name and metadataName.
        /// </summary>
        /// <remarks>
        /// Makes a second attempt if the results are not viable, in order to produce more detailed failure information (symbols and diagnostics).
        /// </remarks>
        private Binder LookupSymbolsWithFallback(LookupResult result, LookupConstraints constraints)
        {
            Debug.Assert(constraints.AreValid());

            // don't create diagnosis instances unless lookup fails
            var binder = this.LookupSymbolsInternal(result, constraints.WithDiagnose(false));
            Debug.Assert((binder != null) || result.IsClear);

            if (result.Kind != LookupResultKind.Viable && result.Kind != LookupResultKind.Empty)
            {
                result.Clear();
                // retry to get diagnosis
                var otherBinder = this.LookupSymbolsInternal(result, constraints.WithDiagnose(true));
                Debug.Assert(binder == otherBinder);
            }

            Debug.Assert(result.IsMultiViable || result.IsClear || result.Error != null);
            return binder;
        }

        private Binder LookupSymbolsInternal(LookupResult result, LookupConstraints constraints)
        {
            Debug.Assert(result.IsClear);
            Debug.Assert(constraints.AreValid());

            Binder binder = null;
            for (var scope = this; scope != null && !result.IsMultiViable; scope = scope.Next)
            {
                if (binder != null)
                {
                    var tmp = LookupResult.GetInstance();
                    scope.LookupSymbolsInSingleBinder(tmp, constraints);
                    result.MergeEqual(tmp);
                    tmp.Free();
                }
                else
                {
                    scope.LookupSymbolsInSingleBinder(result, constraints);
                    if (!result.IsClear)
                    {
                        binder = scope;
                    }
                }
            }
            return binder;
        }

        public virtual void LookupSymbolsInSingleBinder(LookupResult result, LookupConstraints constraints)
        {
        }

        /// <summary>
        /// If qualifierOpt is null, look for any symbols in
        /// scope with the given name and metadataName.
        /// Otherwise look for symbols that are members of the specified qualifierOpt.
        /// </summary>
        private void LookupSymbolsOrMembersInternal(
            LookupResult result,
            LookupConstraints constraints)
        {
            if ((object)constraints.QualifierOpt == null)
            {
                this.LookupSymbolsInternal(result, constraints);
            }
            else
            {
                this.LookupMembersInternal(result, constraints);
            }
        }

        /// <summary>
        /// Look for symbols that are members of the specified namespace or type.
        /// </summary>
        private void LookupMembersWithFallback(LookupResult result, LookupConstraints constraints)
        {
            Debug.Assert(constraints.AreValid());

            // don't create diagnosis unless lookup fails
            this.LookupMembersInternal(result, constraints.WithDiagnoseAndOriginalBinder(false, this));
            if (!result.IsMultiViable && !result.IsClear)
            {
                result.Clear();
                // retry to get diagnosis
                this.LookupMembersInternal(result, constraints.WithDiagnoseAndOriginalBinder(true, this));
            }

            Debug.Assert(result.IsMultiViable || result.IsClear || result.Error != null);
        }

        protected void LookupMembersInternal(LookupResult result, LookupConstraints constraints)
        {
            Debug.Assert(constraints.AreValid());
            if (constraints.QualifierOpt.IsNamespace)
            {
                LookupMembersInNamespace(result, constraints);
            }
            else
            {
                this.LookupMembersInType(result, constraints);
            }
        }

        // Looks up a member of given name and metadataName in a particular type.
        protected void LookupMembersInType(LookupResult result, LookupConstraints constraints)
        {
            TypeSymbol type = (TypeSymbol)constraints.QualifierOpt;
            switch (type.TypeKind.Switch())
            {
                case LanguageTypeKind.NamedType:
                case LanguageTypeKind.Enum:
                case LanguageTypeKind.Dynamic:
                    this.LookupMembersInTypeCore(result, constraints);
                    break;

                case LanguageTypeKind.Submission:
                    this.LookupMembersInSubmissions(result, constraints);
                    break;

                case LanguageTypeKind.Error:
                    LookupMembersInErrorType(result, constraints);
                    break;

                case LanguageTypeKind.Constructed:
                    result.Clear();
                    break;

                case LanguageTypeKind.None:
                default:
                    throw ExceptionUtilities.UnexpectedValue(type.TypeKind);
            }

            // TODO: Diagnose ambiguity problems here, and conflicts between non-method and method? Or is that
            // done in the caller?
        }

        private void LookupMembersInErrorType(LookupResult result, LookupConstraints constraints)
        {
            ErrorTypeSymbol errorType = (ErrorTypeSymbol)constraints.QualifierOpt;
            if (!errorType.CandidateSymbols.IsDefault && errorType.CandidateSymbols.Length == 1)
            {
                // The dev11 IDE experience provided meaningful information about members of inaccessible types,
                // so we should do the same (DevDiv #633340).
                // TODO: generalize to other result kinds and/or candidate counts?
                if (errorType.ResultKind == LookupResultKind.Inaccessible)
                {
                    TypeSymbol candidateType = errorType.CandidateSymbols.First() as TypeSymbol;
                    if ((object)candidateType != null)
                    {
                        LookupMembersInType(result, constraints.WithQualifier(candidateType));
                        return; // Bypass call to Clear()
                    }
                }
            }

            result.Clear();
        }

        /// <summary>
        /// Lookup a member name in a submission chain.
        /// </summary>
        /// <remarks>
        /// We start with the current submission class and walk the submission chain back to the first submission.
        /// The search has two phases
        /// 1) We are looking for any symbol matching the given name, metadataName, and options. If we don't find any the search is over.
        ///    If we find and overloadable symbol(s) (a method or an indexer) we start looking for overloads of this kind 
        ///    (lookingForOverloadsOfKind) of symbol in phase 2.
        /// 2) If a visited submission contains a matching member of a kind different from lookingForOverloadsOfKind we stop 
        ///    looking further. Otherwise, if we find viable overload(s) we add them into the result.
        ///    
        /// Note that indexers are not supported in script but we deal with them here to handle errors.
        /// </remarks>
        private void LookupMembersInSubmissions(LookupResult result, LookupConstraints constraints)
        {
            TypeSymbol submissionClass = (TypeSymbol)constraints.QualifierOpt;
            LookupResult submissionSymbols = LookupResult.GetInstance();
            LookupResult nonViable = LookupResult.GetInstance();
            LanguageSymbolKind lookingForOverloadsOfKind = null;

            // TODO: optimize lookup (there might be many interactions in the chain)
            for (LanguageCompilation submission = Compilation; submission != null; submission = submission.PreviousSubmission)
            {
                submissionSymbols.Clear();

                var isCurrentSubmission = submission == Compilation;
                var considerUsings = !(isCurrentSubmission && this.Flags.Includes(BinderFlags.InScriptUsing));

                Imports submissionImports;
                if (!considerUsings)
                {
                    submissionImports = Imports.Empty;
                }
                else if (!this.Flags.Includes(BinderFlags.InLoadedSyntaxTree))
                {
                    submissionImports = submission.GetSubmissionImports();
                }
                else if (isCurrentSubmission)
                {
                    submissionImports = this.GetImports(constraints.BasesBeingResolved);
                }
                else
                {
                    submissionImports = Imports.Empty;
                }

                // If a viable using alias and a matching member are both defined in the submission an error is reported elsewhere.
                // Ignore the member in such case.
                if ((constraints.Options & LookupOptions.NamespaceAliasesOnly) == 0 && (object)submission.ScriptClass != null)
                {
                    LookupMembersWithoutInheritance(submissionSymbols, constraints.WithQualifierAndAccessThroughType(submission.ScriptClass, submissionClass));

                    // NB: It doesn't matter that submissionImports hasn't been expanded since we're not actually using the alias target. 
                    if (submissionSymbols.IsMultiViable &&
                        considerUsings &&
                        submissionImports.IsUsingAlias(constraints.Name, constraints.OriginalBinder.IsSemanticModelBinder))
                    {
                        // using alias is ambiguous with another definition within the same submission iff the other definition is a 0-ary type or a non-type:
                        Symbol existingDefinition = submissionSymbols.Symbols.First();
                        if (existingDefinition.Kind != LanguageSymbolKind.NamedType || constraints.Name == constraints.MetadataName)
                        {
                            var diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_ConflictingAliasAndDefinition, constraints.Name, existingDefinition.GetKindText());
                            var error = new ExtendedErrorTypeSymbol((NamespaceOrTypeSymbol)null, constraints.Name, constraints.MetadataName, diagInfo, unreported: true);
                            result.SetFrom(LookupResult.Good(error)); // force lookup to be done w/ error symbol as result
                            break;
                        }
                    }
                }

                if (!submissionSymbols.IsMultiViable && considerUsings)
                {
                    if (!isCurrentSubmission)
                    {
                        submissionImports = Imports.ExpandPreviousSubmissionImports(submissionImports, Compilation);
                    }

                    // NB: We diverge from InContainerBinder here and only look in aliases.
                    // In submissions, regular usings are bubbled up to the outermost scope.
                    submissionImports.LookupSymbolInAliases(submissionSymbols, constraints);
                }

                if (lookingForOverloadsOfKind == null)
                {
                    if (!submissionSymbols.IsMultiViable)
                    {
                        // skip non-viable members, but remember them in case no viable members are found in previous submissions:
                        nonViable.MergePrioritized(submissionSymbols);
                        continue;
                    }

                    result.MergeEqual(submissionSymbols);

                    Symbol firstSymbol = submissionSymbols.Symbols.First();
                    if (!IsMethodOrIndexer(firstSymbol))
                    {
                        break;
                    }

                    // we are now looking for any kind of member regardless of the original binding restrictions:
                    constraints = constraints.WithOptions(constraints.Options & ~(LookupOptions.MustBeInvocableIfMember | LookupOptions.NamespacesOrTypesOnly));
                    lookingForOverloadsOfKind = firstSymbol.Kind;
                }
                else
                {
                    // found a non-method - the overload set is final now
                    if (submissionSymbols.Symbols.Count > 0 && submissionSymbols.Symbols.First().Kind != lookingForOverloadsOfKind)
                    {
                        break;
                    }

                    // found a viable overload:
                    if (submissionSymbols.IsMultiViable)
                    {
                        // merge overloads:
                        Debug.Assert(result.Symbols.All(IsMethodOrIndexer));
                        result.MergeEqual(submissionSymbols);
                    }
                }
            }

            if (result.Symbols.Count == 0)
            {
                result.SetFrom(nonViable);
            }

            submissionSymbols.Free();
            nonViable.Free();
        }

        private static void LookupMembersInNamespace(LookupResult result, LookupConstraints constraints)
        {
            var members = GetCandidateMembers(constraints);

            Binder originalBinder = constraints.OriginalBinder;
            foreach (Symbol member in members)
            {
                SingleLookupResult resultOfThisMember = originalBinder.CheckViability(member, constraints);
                result.MergeEqual(resultOfThisMember);
            }
        }

        #region "AttributeTypeLookup"

        /// <summary>
        /// Lookup attribute name in the given binder. By default two name lookups are performed:
        ///     (1) With the provided name
        ///     (2) With an Attribute suffix added to the provided name
        /// Lookup with Attribute suffix is performed only if LookupOptions.VerbatimAttributeName is not set.
        /// 
        /// If either lookup is ambiguous, we return the corresponding result with ambiguous symbols.
        /// Else if exactly one result is single viable attribute type, we return that result.
        /// Otherwise, we return a non-viable result with LookupResult.NotAnAttributeType or an empty result.
        /// </summary>
        private void LookupAttributeType(
            LookupResult result,
            LookupConstraints constraints)
        {
            Debug.Assert(result.IsClear);
            Debug.Assert(constraints.AreValid());
            Debug.Assert(constraints.Options.IsAttributeTypeLookup());

            //  SPEC:   By convention, attribute classes are named with a suffix of Attribute. 
            //  SPEC:   An attribute-name of the form type-name may either include or omit this suffix.
            //  SPEC:   If an attribute class is found both with and without this suffix, an ambiguity 
            //  SPEC:   is present, and a compile-time error results. If the attribute-name is spelled
            //  SPEC:   such that its right-most identifier is a verbatim identifier (§2.4.2), then only
            //  SPEC:   an attribute without a suffix is matched, thus enabling such an ambiguity to be resolved.

            // Roslyn Bug 9681: Compilers incorrectly use the *failure* of binding some subexpression to indicate some other strategy is applicable (attributes, 'var')

            // Roslyn reproduces Dev10 compiler behavior which doesn't report an error if one of the 
            // lookups is single viable and other lookup is ambiguous. If one of the lookup results 
            // (either with or without "Attribute" suffix) is single viable and is an attribute type we 
            // use it  disregarding the second result which may be ambiguous. 

            // Note: if both are single and attribute types, we still report ambiguity.

            // Lookup symbols without attribute suffix.
            LookupSymbolsOrMembersInternal(result, constraints);

            // Result without 'Attribute' suffix added.
            Symbol symbolWithoutSuffix;
            bool resultWithoutSuffixIsViable = IsSingleViableAttributeType(result, out symbolWithoutSuffix);

            // Generic types are not allowed.
            Debug.Assert(constraints.MetadataName == constraints.Name || !result.IsMultiViable);

            // Result with 'Attribute' suffix added.
            LookupResult resultWithSuffix = null;
            Symbol symbolWithSuffix = null;
            bool resultWithSuffixIsViable = false;
            if (!constraints.Options.IsVerbatimNameAttributeTypeLookup())
            {
                resultWithSuffix = LookupResult.GetInstance();
                this.LookupSymbolsOrMembersInternal(resultWithSuffix, constraints.WithName(constraints.Name + Language.SymbolFacts.AttributeNameSuffix));
                resultWithSuffixIsViable = IsSingleViableAttributeType(resultWithSuffix, out symbolWithSuffix);

                // Generic types are not allowed.
                Debug.Assert(constraints.MetadataName == constraints.Name || !result.IsMultiViable);
            }

            if (resultWithoutSuffixIsViable && resultWithSuffixIsViable)
            {
                // Single viable lookup symbol found both with and without Attribute suffix.
                // We merge both results, ambiguity error will be reported later in ResultSymbol.
                result.MergeEqual(resultWithSuffix);
            }
            else if (resultWithoutSuffixIsViable)
            {
                // single viable lookup symbol only found without Attribute suffix, return result.
            }
            else if (resultWithSuffixIsViable)
            {
                Debug.Assert(resultWithSuffix != null);

                // Single viable lookup symbol only found with Attribute suffix, return resultWithSuffix.
                result.SetFrom(resultWithSuffix);
            }
            else
            {
                // Both results are clear, non-viable or ambiguous.

                if (!result.IsClear)
                {
                    if ((object)symbolWithoutSuffix != null) // was not ambiguous, but not viable
                    {
                        result.SetFrom(GenerateNonViableAttributeTypeResult(symbolWithoutSuffix, result.Error, constraints.Diagnose));
                    }
                }

                if (resultWithSuffix != null)
                {
                    if (!resultWithSuffix.IsClear)
                    {
                        if ((object)symbolWithSuffix != null)
                        {
                            resultWithSuffix.SetFrom(GenerateNonViableAttributeTypeResult(symbolWithSuffix, resultWithSuffix.Error, constraints.Diagnose));
                        }
                    }

                    result.MergePrioritized(resultWithSuffix);
                }
            }

            resultWithSuffix?.Free();
        }

        private bool IsAmbiguousResult(LookupResult result, out Symbol resultSymbol)
        {
            resultSymbol = null;
            var symbols = result.Symbols;

            switch (symbols.Count)
            {
                case 0:
                    return false;
                case 1:
                    resultSymbol = symbols[0];
                    return false;
                default:
                    // If there are two or more symbols in the result, one from source and others from PE,
                    // then the source symbol overrides the PE symbols and must be chosen.
                    // NOTE: Kind of the symbol doesn't matter here. If the resolved symbol is not an attribute type, we will subsequently generate a lookup error.

                    // CONSIDER: If this source symbol is the eventual result symbol for attribute type lookup and it is not a valid attribute type,
                    // CONSIDER: we generate an error but don't generate warning CS0436 for source/PE name conflict.
                    // CONSIDER: We may want to also generate CS0436 for this case.

                    resultSymbol = ResolveMultipleSymbolsInAttributeTypeLookup(symbols);
                    return (object)resultSymbol == null;
            }
        }

        private Symbol ResolveMultipleSymbolsInAttributeTypeLookup(ArrayBuilder<Symbol> symbols)
        {
            Debug.Assert(symbols.Count >= 2);

            var originalSymbols = symbols.ToImmutable();

            for (int i = 0; i < symbols.Count; i++)
            {
                symbols[i] = UnwrapAliasNoDiagnostics(symbols[i]);
            }

            BestSymbolInfo secondBest;
            BestSymbolInfo best = GetBestSymbolInfo(symbols, out secondBest);

            Debug.Assert(!best.IsNone);
            Debug.Assert(!secondBest.IsNone);

            if (best.IsFromCompilation && !secondBest.IsFromCompilation)
            {
                var srcSymbol = symbols[best.Index];
                var mdSymbol = symbols[secondBest.Index];

                //if names match, arities match, and containing symbols match (recursively), ...
                if (srcSymbol.ToDisplayString(SymbolDisplayFormat.QualifiedNameArityFormat) ==
                    mdSymbol.ToDisplayString(SymbolDisplayFormat.QualifiedNameArityFormat))
                {
                    return originalSymbols[best.Index];
                }
            }

            return null;
        }

        private bool IsSingleViableAttributeType(LookupResult result, out Symbol symbol)
        {
            if (IsAmbiguousResult(result, out symbol))
            {
                return false;
            }

            if (result == null || result.Kind != LookupResultKind.Viable || (object)symbol == null)
            {
                return false;
            }

            DiagnosticInfo discarded = null;
            return CheckAttributeTypeViability(UnwrapAliasNoDiagnostics(symbol), diagnose: false, diagInfo: ref discarded);
        }

        private SingleLookupResult GenerateNonViableAttributeTypeResult(Symbol symbol, DiagnosticInfo diagInfo, bool diagnose)
        {
            Debug.Assert((object)symbol != null);

            symbol = UnwrapAliasNoDiagnostics(symbol);
            CheckAttributeTypeViability(symbol, diagnose, ref diagInfo);
            return LookupResult.NotAnAttributeType(symbol, diagInfo);
        }

        public virtual bool CheckAttributeTypeViability(Symbol symbol, bool diagnose, ref DiagnosticInfo diagInfo)
        {
            Debug.Assert((object)symbol != null);

            if (symbol.Kind == LanguageSymbolKind.NamedType)
            {
                var namedType = (NamedTypeSymbol)symbol;
                if (namedType.IsAbstract)
                {
                    // Attribute class cannot be abstract.
                    diagInfo = diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_AbstractAttributeClass, symbol) : null;
                    return false;
                }
                else
                {
                    return true;
                    /* TODO:MetaDslx
                    HashSet<DiagnosticInfo> useSiteDiagnostics = null;

                    if (Compilation.IsEqualOrDerivedFromWellKnownClass(namedType, WellKnownType.System_Attribute, ref useSiteDiagnostics))
                    {
                        // Reuse existing diagnostic info.
                        return true;
                    }

                    if (diagnose && !useSiteDiagnostics.IsNullOrEmpty())
                    {
                        foreach (var info in useSiteDiagnostics)
                        {
                            if (info.Severity == DiagnosticSeverity.Error)
                            {
                                diagInfo = info;
                                return false;
                            }
                        }
                    }*/
                }
            }

            /* TODO:MetaDslx
            diagInfo = diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_NotAnAttributeClass, symbol) : null;
            return false;
            */
            return true;
        }

        #endregion

        // Does a member lookup in a single type, without considering inheritance.
        protected static void LookupMembersWithoutInheritance(LookupResult result, LookupConstraints constraints)
        {
            var members = GetCandidateMembers(constraints);

            foreach (Symbol member in members)
            {
                // Do we need to exclude override members, or is that done later by overload resolution. It seems like
                // not excluding them here can't lead to problems, because we will always find the overridden method as well.
                SingleLookupResult resultOfThisMember = constraints.OriginalBinder.CheckViability(member, constraints);
                result.MergeEqual(resultOfThisMember);
            }
        }

        // Lookup member in a class, struct, enum, delegate.
        private void LookupMembersInTypeCore(LookupResult result, LookupConstraints constraints)
        {
            LookupMembersInTypeAndBaseTypes(result, constraints);
        }

        // Lookup member in interface, and any base interfaces.
        private static void LookupMembersInCurrentType(LookupResult current, LookupConstraints constraints)
        {
            Debug.Assert((object)constraints.QualifierOpt != null);

            LookupMembersWithoutInheritance(current, constraints);
            if ((constraints.Options & (LookupOptions.NamespaceAliasesOnly | LookupOptions.NamespacesOrTypesOnly)) == 0)
            {
                TypeSymbol type = (TypeSymbol)constraints.QualifierOpt;
                LookupMembersInTypesWithoutInheritance(current, type.AllBaseTypesWithDefinitionUseSiteDiagnostics(ref constraints.UseSiteDiagnostics), constraints);
            }
        }

        private static void LookupMembersInTypesWithoutInheritance(LookupResult current, ImmutableArray<NamedTypeSymbol> baseTypes, LookupConstraints constraints)
        {
            if (baseTypes.Length > 0)
            {
                var tmp = LookupResult.GetInstance();
                foreach (TypeSymbol baseType in baseTypes)
                {
                    LookupMembersWithoutInheritance(tmp, constraints.WithQualifier(baseType));
                    MergeHidingLookupResults(current, tmp, constraints);
                    tmp.Clear();
                }
                tmp.Free();
            }
        }

        // Lookup member in interface, and any base interfaces, and System.Object.
        private void LookupMembersInTypeAndBaseTypes(LookupResult current, LookupConstraints constraints)
        {
            Debug.Assert((object)constraints.QualifierOpt != null);

            LookupMembersInCurrentType(current, constraints);

            var tmp = LookupResult.GetInstance();
            // NB: we assume use-site-errors on System.Object, if any, have been reported earlier.
            this.LookupMembersInBaseTypes(tmp, constraints.WithQualifier(this.Compilation.GetSpecialType(SpecialType.System_Object)));
            MergeHidingLookupResults(current, tmp, constraints);
            tmp.Free();
        }

        // Lookup member in a class, struct, enum, delegate.
        private void LookupMembersInBaseTypes(LookupResult result, LookupConstraints constraints)
        {
            TypeSymbol type = constraints.QualifierOpt as TypeSymbol;
            Debug.Assert((object)type != null);
            //Debug.Assert(type.TypeKind != LanguageTypeKind.TypeParameter);

            var tmp = LookupResult.GetInstance();
            PooledHashSet<NamedTypeSymbol> visited = null;
            foreach (var currentType in type.AllBaseTypesNoUseSiteDiagnostics)
            {
                tmp.Clear();
                LookupMembersWithoutInheritance(tmp, constraints.WithQualifier(currentType));

                MergeHidingLookupResults(result, tmp, constraints);

                NamedTypeSymbol namedType = currentType as NamedTypeSymbol;

                // any viable non-methods [non-indexers] found here will hide viable methods [indexers] (with the same name) in any further base classes
                bool tmpHidesMethodOrIndexers = tmp.IsMultiViable && !IsMethodOrIndexer(tmp.Symbols[0]);

                // short circuit looking up bases if we already have a viable result and we won't be adding on more
                if (result.IsMultiViable && (tmpHidesMethodOrIndexers || !IsMethodOrIndexer(result.Symbols[0])))
                {
                    break;
                }

                if (constraints.BasesBeingResolved != null && constraints.BasesBeingResolved.ContainsReference(type.OriginalDefinition))
                {
                    var other = GetNearestOtherSymbol(constraints.BasesBeingResolved, type);
                    var diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_CircularBase, type, other);
                    var error = new ExtendedErrorTypeSymbol(this.Compilation, constraints.Name, constraints.MetadataName, diagInfo, unreported: true);
                    result.SetFrom(LookupResult.Good(error)); // force lookup to be done w/ error symbol as result
                }
            }

            visited?.Free();
            tmp.Free();
        }

        // find the nearest symbol in list to the symbol 'type'.  It may be the same symbol if its the only one.
        private static Symbol GetNearestOtherSymbol(ConsList<TypeSymbol> list, TypeSymbol type)
        {
            TypeSymbol other = type;

            for (; list != null && list != ConsList<TypeSymbol>.Empty; list = list.Tail)
            {
                if (TypeSymbol.Equals(list.Head, type.OriginalDefinition, TypeCompareKind.ConsiderEverything2))
                {
                    if (TypeSymbol.Equals(other, type, TypeCompareKind.ConsiderEverything2) && list.Tail != null && list.Tail != ConsList<TypeSymbol>.Empty)
                    {
                        other = list.Tail.Head;
                    }
                    break;
                }
                else
                {
                    other = list.Head;
                }
            }

            return other;
        }

        private static bool IsDerivedType(NamedTypeSymbol baseType, NamedTypeSymbol derivedType, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(!TypeSymbol.Equals(baseType, derivedType, TypeCompareKind.ConsiderEverything2));
            return derivedType.AllBaseTypesWithDefinitionUseSiteDiagnostics(ref useSiteDiagnostics).Contains(baseType);
        }

        // Merge resultHidden into resultHiding, whereby viable results in resultHiding should hide results
        // in resultHidden if the owner of the symbol in resultHiding is a subtype of the owner of the symbol
        // in resultHidden. We merge together methods [indexers], but non-methods [non-indexers] hide everything and methods [indexers] hide non-methods [non-indexers].
        private static void MergeHidingLookupResults(LookupResult resultHiding, LookupResult resultHidden, LookupConstraints constraints)
        {
            // Methods hide non-methods, non-methods hide everything.

            if (resultHiding.IsMultiViable && resultHidden.IsMultiViable)
            {
                var hidingSymbols = resultHiding.Symbols;
                var hidingCount = hidingSymbols.Count;
                var hiddenSymbols = resultHidden.Symbols;
                var hiddenCount = hiddenSymbols.Count;
                for (int i = 0; i < hiddenCount; i++)
                {
                    var sym = hiddenSymbols[i];
                    var hiddenContainer = sym.ContainingType;

                    // TODO:MetaDslx - Check if resultHiding has any non-methods. If so, it hides everything in resultHidden.

                    hidingSymbols.Add(sym); // not hidden
                }
            }
            else
            {
                resultHiding.MergePrioritized(resultHidden);
            }
        }

        /// <summary>
        /// This helper is used to determine whether this symbol hides / is hidden
        /// based on its signature, as opposed to its name.
        /// </summary>
        /// <remarks>
        /// CONSIDER: It might be nice to generalize this - maybe an extension method
        /// on Symbol (e.g. IsOverloadable or HidesByName).
        /// </remarks>
        private static bool IsMethodOrIndexer(Symbol symbol)
        {
            return symbol.Kind == LanguageSymbolKind.Operation; // TODO:MetaDslx || symbol.IsIndexer();
        }

        public static ImmutableArray<Symbol> GetCandidateMembers(LookupConstraints constraints)
        {
            if ((constraints.Options & LookupOptions.NamespacesOrTypesOnly) != 0 && constraints.QualifierOpt is TypeSymbol)
            {
                return constraints.QualifierOpt.GetTypeMembers(constraints.Name).Cast<NamedTypeSymbol, Symbol>();
            }
            /* TODO:MetaDslx - else if (nsOrType.Kind == LanguageSymbolKind.NamedType && originalBinder.IsEarlyAttributeBinder)
            {
                return ((NamedTypeSymbol)nsOrType).GetEarlyAttributeDecodingMembers(name);
            }*/
            else if ((constraints.Options & LookupOptions.LabelsOnly) != 0)
            {
                return ImmutableArray<Symbol>.Empty;
            }
            else
            {
                if (constraints.Name != null) return constraints.QualifierOpt.GetMembers(constraints.Name);
                else return constraints.QualifierOpt.GetMembersUnordered();
            }
        }

        /// <remarks>
        /// Distinguish from <see cref="CanAddLookupSymbolInfo"/>, which performs an analogous task for Add*LookupSymbolsInfo*.
        /// </remarks>
        public virtual SingleLookupResult CheckViability(Symbol symbol, LookupConstraints constraints)
        {
            bool inaccessibleViaQualifier;
            DiagnosticInfo diagInfo;

            // General pattern: checks and diagnostics refer to unwrapped symbol,
            // but lookup results refer to symbol.

            var unwrappedSymbol = symbol.Kind == LanguageSymbolKind.Alias
                ? ((AliasSymbol)symbol).GetAliasTarget(constraints.BasesBeingResolved)
                : symbol;

            if (WrongArity(symbol, constraints.MetadataName, constraints.Diagnose, constraints.Options, out diagInfo))
            {
                return LookupResult.WrongArity(symbol, diagInfo);
            }
            else if (!unwrappedSymbol.CanBeReferencedByName)
            {
                diagInfo = constraints.Diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_CantCallSpecialMethod, unwrappedSymbol) : null;
                return LookupResult.NotReferencable(symbol, diagInfo);
            }
            else if ((constraints.Options & LookupOptions.NamespacesOrTypesOnly) != 0 && !(unwrappedSymbol is NamespaceOrTypeSymbol))
            {
                return LookupResult.NotTypeOrNamespace(unwrappedSymbol, symbol, constraints.Diagnose);
            }
            else if ((constraints.Options & LookupOptions.MustBeInvocableIfMember) != 0
                && IsNonInvocableMember(unwrappedSymbol))
            {
                return LookupResult.NotInvocable(unwrappedSymbol, symbol, constraints.Diagnose);
            }
            else if (!this.IsAccessible(unwrappedSymbol,
                                        RefineAccessThroughType(constraints.Options, constraints.AccessThroughType),
                                        out inaccessibleViaQualifier,
                                        ref constraints.UseSiteDiagnostics,
                                        constraints.BasesBeingResolved))
            {
                if (!constraints.Diagnose)
                {
                    diagInfo = null;
                }
                else if (inaccessibleViaQualifier)
                {
                    diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_BadProtectedAccess, unwrappedSymbol, constraints.AccessThroughType, this.ContainingType);
                }
                else if (IsBadIvtSpecification())
                {
                    diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_FriendRefNotEqualToThis, unwrappedSymbol.ContainingAssembly.Identity.ToString(), AssemblyIdentity.PublicKeyToString(this.Compilation.Assembly.PublicKey));
                }
                else
                {
                    diagInfo = new SymbolDiagnosticInfo(ImmutableArray.Create<ISymbol>(unwrappedSymbol), ImmutableArray<Location>.Empty, InternalErrorCode.ERR_BadAccess, unwrappedSymbol);
                }

                return LookupResult.Inaccessible(symbol, diagInfo);
            }
            else if ((constraints.Options & LookupOptions.MustBeInstance) != 0 && !IsInstance(unwrappedSymbol))
            {
                diagInfo = constraints.Diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_ObjectRequired, unwrappedSymbol) : null;
                return LookupResult.StaticInstanceMismatch(symbol, diagInfo);
            }
            else if ((constraints.Options & LookupOptions.MustNotBeInstance) != 0 && IsInstance(unwrappedSymbol))
            {
                diagInfo = constraints.Diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_ObjectProhibited, unwrappedSymbol) : null;
                return LookupResult.StaticInstanceMismatch(symbol, diagInfo);
            }
            else if ((constraints.Options & LookupOptions.MustNotBeNamespace) != 0 && unwrappedSymbol.Kind == LanguageSymbolKind.Namespace)
            {
                diagInfo = constraints.Diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_BadSKunknown, unwrappedSymbol, unwrappedSymbol.GetKindText()) : null;
                return LookupResult.NotTypeOrNamespace(symbol, diagInfo);
            }
            /*else if ((options & LookupOptions.LabelsOnly) != 0 && unwrappedSymbol.Kind != LanguageSymbolKind.Label)
            {
                diagInfo = diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_LabelNotFound, unwrappedSymbol.Name) : null;
                return LookupResult.NotLabel(symbol, diagInfo);
            }*/
            else if (constraints.Kinds.Length > 0 && !constraints.Kinds.Any(st => st.ImmutableType.IsAssignableFrom(symbol.ModelSymbolInfo.ImmutableType)))
            {
                return LookupResult.WrongSymbol(symbol, symbol, constraints.Kinds, true);
            }
            else
            {
                return LookupResult.Good(symbol);
            }

            bool IsBadIvtSpecification()
            {
                // Ensures that during binding we don't ask for public key which results in attribute binding and stack overflow.
                // If looking up attributes, don't ask for public key.
                if ((unwrappedSymbol.DeclaredAccessibility == Accessibility.Internal ||
                    unwrappedSymbol.DeclaredAccessibility == Accessibility.ProtectedAndInternal ||
                    unwrappedSymbol.DeclaredAccessibility == Accessibility.ProtectedOrInternal)
                    && !constraints.Options.IsAttributeTypeLookup())
                {
                    var assemblyName = this.Compilation.AssemblyName;
                    if (assemblyName == null)
                    {
                        return false;
                    }
                    var keys = unwrappedSymbol.ContainingAssembly.GetInternalsVisibleToPublicKeys(assemblyName);
                    if (!keys.Any())
                    {
                        return false;
                    }
                    foreach (ImmutableArray<byte> key in keys)
                    {
                        if (key.SequenceEqual(this.Compilation.Assembly.Identity.PublicKey))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
        }

        public void CheckViability<TSymbol>(LookupResult result, ImmutableArray<TSymbol> symbols, LookupConstraints constraints) where TSymbol : Symbol
        {
            foreach (var symbol in symbols)
            {
                var res = this.CheckViability(symbol, constraints);
                result.MergeEqual(res);
            }
        }

        /// <summary>
        /// Used by Add*LookupSymbolsInfo* to determine whether the symbol is of interest.
        /// Distinguish from <see cref="CheckViability"/>, which performs an analogous task for LookupSymbols*.
        /// </summary>
        /// <remarks>
        /// Does not consider <see cref="Symbol.CanBeReferencedByName"/> - that is left to the caller.
        /// </remarks>
        public bool CanAddLookupSymbolInfo(Symbol symbol, LookupSymbolsInfo info, LookupConstraints constraints, AliasSymbol aliasSymbol = null)
        {
            Debug.Assert(symbol.Kind != LanguageSymbolKind.Alias, "It is the caller's responsibility to unwrap aliased symbols.");
            Debug.Assert(aliasSymbol == null || aliasSymbol.GetAliasTarget(basesBeingResolved: null) == symbol);
            Debug.Assert(constraints.AreValid());

            var name = aliasSymbol != null ? aliasSymbol.Name : symbol.Name;
            if (!info.CanBeAdded(name))
            {
                return false;
            }

            if ((constraints.Options & LookupOptions.NamespacesOrTypesOnly) != 0 && !(symbol is NamespaceOrTypeSymbol))
            {
                return false;
            }
            else if ((constraints.Options & LookupOptions.MustBeInvocableIfMember) != 0
                && IsNonInvocableMember(symbol))
            {
                return false;
            }
            else if ((constraints.Options & LookupOptions.MustBeInstance) != 0 && !IsInstance(symbol))
            {
                return false;
            }
            else if ((constraints.Options & LookupOptions.MustNotBeInstance) != 0 && IsInstance(symbol))
            {
                return false;
            }
            else if ((constraints.Options & LookupOptions.MustNotBeNamespace) != 0 && (symbol.Kind == LanguageSymbolKind.Namespace))
            {
                return false;
            }
            else
            {
                // This viability check is only used by SemanticModel.LookupSymbols, which does its own
                // filtering of not-referenceable symbols.  Hence, we do not check CanBeReferencedByName
                // here.
                return true;
            }
        }

        private static TypeSymbol RefineAccessThroughType(LookupOptions options, TypeSymbol accessThroughType)
        {
            // Normally, when we access a protected instance member, we need to know the type of the receiver so we
            // can determine whether the member is actually accessible in the containing type.  There is one exception:
            // If the receiver is "base", then it's okay if the receiver type isn't derived from the containing type.
            return ((options & LookupOptions.UseBaseReferenceAccessibility) != 0)
                ? null
                : accessThroughType;
        }

        /// <summary>
        /// A symbol is accessible for referencing in a cref if it is in the same assembly as the reference
        /// or the symbols's effective visibility is not private.
        /// </summary>
        private bool IsCrefAccessible(Symbol symbol)
        {
            return !IsEffectivelyPrivate(symbol) || symbol.ContainingAssembly == this.Compilation.Assembly;
        }

        private static bool IsEffectivelyPrivate(Symbol symbol)
        {
            for (Symbol s = symbol; (object)s != null; s = s.ContainingSymbol)
            {
                if (s.DeclaredAccessibility == Accessibility.Private)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType".
        /// </summary>
        public bool IsAccessible(Symbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, TypeSymbol accessThroughType = null, ConsList<TypeSymbol> basesBeingResolved = null)
        {
            bool failedThroughTypeCheck;
            return IsAccessible(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType", and sets "failedThroughTypeCheck" if fails
        /// the protected access check.
        /// </summary>
        public bool IsAccessible(Symbol symbol, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol> basesBeingResolved = null)
        {
            if (this.Flags.Includes(BinderFlags.IgnoreAccessibility))
            {
                failedThroughTypeCheck = false;
                return true;
            }

            return IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        /// <remarks>
        /// Should only be called by <see cref="IsAccessible(Symbol, TypeSymbol, out bool, ref HashSet{DiagnosticInfo}, ConsList{TypeSymbol})"/>,
        /// which will already have checked for <see cref="BinderFlags.IgnoreAccessibility"/>.
        /// </remarks>
        public virtual bool IsAccessibleHelper(Symbol symbol, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol> basesBeingResolved)
        {
            // By default, just delegate to containing binder.
            return Next.IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        public bool IsNonInvocableMember(Symbol symbol)
        {
            switch (symbol.Kind.Switch())
            {
                case LanguageSymbolKind.Operation:
                case LanguageSymbolKind.Property:
                case LanguageSymbolKind.NamedType:
                    return !IsInvocableMember(symbol);

                default:
                    return false;
            }
        }

        private bool IsInvocableMember(Symbol symbol)
        {
            // If a member is a method or event, or if it is a constant, field or property of 
            // either a delegate type or the type dynamic, then the member is said to be invocable.

            TypeSymbol type = null;

            switch (symbol.Kind.Switch())
            {
                case LanguageSymbolKind.Operation:
                    return true;
            }

            // TODO:MetaDslx - delegate typed members

            return (object)type != null && type.IsDynamic();
        }

        private static bool IsInstance(Symbol symbol)
        {
            switch (symbol.Kind.Switch())
            {
                case LanguageSymbolKind.Name:
                case LanguageSymbolKind.Property:
                case LanguageSymbolKind.Operation:
                    return !symbol.IsStatic;
                default:
                    return false;
            }
        }

        // Check if the given symbol can be accessed with the given metadataName. If OK, return false.
        // If not OK, return true and return a diagnosticinfo. Note that methods with type arguments
        // can be accesses with metadataName zero due to type inference (but non types).
        private static bool WrongArity(Symbol symbol, string metadataName, bool diagnose, LookupOptions options, out DiagnosticInfo diagInfo)
        {
            if (symbol.MetadataName != metadataName)
            {
                diagInfo = diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_TypeArgsNotAllowed, symbol, symbol.MetadataName) : null;
                return true;
            }
            diagInfo = null;
            return false;
        }

        /// <summary>
        /// Look for names in scope
        /// </summary>
        public void AddLookupSymbolsInfo(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            constraints = this.AdjustConstraints(constraints);
            for (var scope = this; scope != null; scope = scope.Next)
            {
                scope.AddLookupSymbolsInfoInSingleBinder(result, constraints);
            }
        }

        protected virtual void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo info, LookupConstraints constraints)
        {
            // overridden in other binders
        }

        /// <summary>
        /// Look for names of members
        /// </summary>
        public void AddMemberLookupSymbolsInfo(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            constraints = this.AdjustConstraints(constraints);
            if (constraints.QualifierOpt.IsNamespace)
            {
                AddMemberLookupSymbolsInfoInNamespace(result, constraints);
            }
            else
            {
                this.AddMemberLookupSymbolsInfoInType(result, constraints);
            }
        }

        private void AddMemberLookupSymbolsInfoInType(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            TypeSymbol type = (TypeSymbol)constraints.QualifierOpt;
            switch (type.TypeKind.Switch())
            {
                case LanguageTypeKind.NamedType:
                case LanguageTypeKind.Enum:
                case LanguageTypeKind.Dynamic:
                case LanguageTypeKind.Constructed:
                    this.AddMemberLookupSymbolsInfoInTypeCore(result, constraints.WithAccessThroughType(type));
                    break;

                case LanguageTypeKind.Submission:
                    this.AddMemberLookupSymbolsInfoInSubmissions(result, constraints);
                    break;
            }
        }

        private void AddMemberLookupSymbolsInfoInSubmissions(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            // TODO: we need tests
            // TODO: optimize lookup (there might be many interactions in the chain)
            for (LanguageCompilation submission = Compilation; submission != null; submission = submission.PreviousSubmission)
            {
                if ((object)submission.ScriptClass != null)
                {
                    AddMemberLookupSymbolsInfoWithoutInheritance(result, constraints.WithQualifier(submission.ScriptClass));
                }

                bool isCurrentSubmission = submission == Compilation;

                // If we are looking only for labels we do not need to search through the imports.
                if ((constraints.Options & LookupOptions.LabelsOnly) == 0 && !(isCurrentSubmission && this.Flags.Includes(BinderFlags.InScriptUsing)))
                {
                    var submissionImports = submission.GetSubmissionImports();
                    if (!isCurrentSubmission)
                    {
                        submissionImports = Imports.ExpandPreviousSubmissionImports(submissionImports, Compilation);
                    }

                    // NB: We diverge from InContainerBinder here and only look in aliases.
                    // In submissions, regular usings are bubbled up to the outermost scope.
                    submissionImports.AddLookupSymbolsInfoInAliases(result, constraints);
                }
            }
        }

        private static void AddMemberLookupSymbolsInfoInNamespace(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            var candidateMembers = GetCandidateMembers(constraints.WithName(result.FilterName));
            foreach (var symbol in candidateMembers)
            {
                if (constraints.OriginalBinder.CanAddLookupSymbolInfo(symbol, result, constraints.WithAccessThroughType(null))) 
                {
                    result.AddSymbol(symbol, symbol.Name, symbol.MetadataName);
                }
            }
        }

        private static void AddMemberLookupSymbolsInfoWithoutInheritance(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            var candidateMembers = GetCandidateMembers(constraints.WithName(result.FilterName));
            foreach (var symbol in candidateMembers)
            {
                if (constraints.OriginalBinder.CanAddLookupSymbolInfo(symbol, result, constraints))
                {
                    result.AddSymbol(symbol, symbol.Name, symbol.MetadataName);
                }
            }
        }

        private void AddMemberLookupSymbolsInfoInTypeCore(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            AddMemberLookupSymbolsInfoWithoutInheritance(result, constraints);

            TypeSymbol type = (TypeSymbol)constraints.QualifierOpt;
            foreach (var baseInterface in type.AllBaseTypesNoUseSiteDiagnostics)
            {
                AddMemberLookupSymbolsInfoWithoutInheritance(result, constraints.WithQualifier(baseInterface));
            }

            this.AddMemberLookupSymbolsInfoInTypeCore(result, constraints.WithQualifier(Compilation.GetSpecialType(SpecialType.System_Object)));
        }

        protected virtual LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            return constraints.WithOriginalBinder(this);
        }
    }
}
