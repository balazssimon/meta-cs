// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    public partial class Binder : ILookupValidator
    {

        /// <summary>
        /// Look for any symbols in scope with the given name and metadataName.
        /// </summary>
        /// <remarks>
        /// Makes a second attempt if the results are not viable, in order to produce more detailed failure information (symbols and diagnostics).
        /// </remarks>
        public Binder LookupSymbols(LookupResult result, LookupConstraints constraints, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(constraints.AreValid());

            // don't create diagnosis instances unless lookup fails
            var binder = this.LookupSymbolsInternal(result, constraints, false, ref useSiteDiagnostics);
            Debug.Assert((binder != null) || result.IsClear);

            if (result.Kind != LookupResultKind.Viable && result.Kind != LookupResultKind.Empty)
            {
                result.Clear();
                // retry to get diagnosis
                var otherBinder = this.LookupSymbolsInternal(result, constraints, true, ref useSiteDiagnostics);
                Debug.Assert(binder == otherBinder);
            }

            Debug.Assert(result.IsMultiViable || result.IsClear || result.Error != null);
            return binder;
        }

        private Binder LookupSymbolsInternal(LookupResult result, LookupConstraints constraints, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(result.IsClear);
            Debug.Assert(constraints.AreValid());

            Binder binder = null;
            for (var scope = this; scope != null && !result.IsMultiViable; scope = scope.Next)
            {
                if (binder != null)
                {
                    var tmp = LookupResult.GetInstance();
                    scope.LookupSymbolsInSingleBinder(tmp, constraints, diagnose, ref useSiteDiagnostics);
                    result.MergeEqual(tmp);
                    tmp.Free();
                }
                else
                {
                    scope.LookupSymbolsInSingleBinder(result, constraints, diagnose, ref useSiteDiagnostics);
                    if (!result.IsClear)
                    {
                        binder = scope;
                    }
                }
            }
            return binder;
        }

        private void LookupSymbolsInSingleBinder(LookupResult result, LookupConstraints constraints, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var candidates = LookupCandidates.GetInstance();
            AddLookupCandidateSymbolsInSingleBinder(candidates, constraints);
            if (diagnose)
            {
                if (useSiteDiagnostics == null) useSiteDiagnostics = new HashSet<DiagnosticInfo>();
                useSiteDiagnostics.UnionWith(candidates.UseSiteDiagnostics);
            }
            foreach (var symbol in candidates.Symbols)
            {
                var validatedResult = constraints.CheckSingleResultViability(symbol);
                result.MergeEqual(validatedResult);
            }
            candidates.Free();
        }

        public void AddCompletionSymbols(LookupCandidates result, LookupConstraints constraints)
        {
            this.AddLookupCandidateSymbols(result, constraints);
        }

        /// <summary>
        /// Look for names in scope
        /// </summary>
        public void AddLookupCandidateSymbols(LookupCandidates result, LookupConstraints constraints)
        {
            constraints = this.AdjustConstraints(constraints);
            for (var scope = this; scope != null; scope = scope.Next)
            {
                scope.AddLookupCandidateSymbolsInSingleBinder(result, constraints);
            }
        }

        public virtual void AddLookupCandidateSymbolsInSingleBinder(LookupCandidates result, LookupConstraints constraints)
        {
            this.AddCandidateSymbolsInternal(result, constraints);
        }

        /// <summary>
        /// Look for names of members
        /// </summary>
        private void AddCandidateSymbolsInternal(LookupCandidates result, LookupConstraints constraints)
        {
            var qualifier = constraints.QualifierOpt as NamespaceOrTypeSymbol;
            if (qualifier is null || qualifier is NamespaceSymbol)
            {
                AddCandidateSymbolsInNamespace(result, constraints);
            }
            else
            {
                AddCandidateSymbolsInType(result, constraints);
            }
        }

        private void AddCandidateSymbolsInType(LookupCandidates result, LookupConstraints constraints)
        {
            TypeSymbol type = (TypeSymbol)constraints.QualifierOpt;
            if (type.IsError)
            {
                this.AddCandidateSymbolsInErrorType(result, constraints);
            }
            else if (type is SubmissionSymbol)
            {
                this.AddCandidateSymbolsInSubmissions(result, constraints);
            }
            else
            {
                this.AddCandidateSymbolsInTypeAndBaseTypes(result, constraints.WithAccessThroughType(type));
            }
        }

        private void AddCandidateSymbolsInSubmissions(LookupCandidates result, LookupConstraints constraints)
        {
            // TODO: we need tests
            // TODO: optimize lookup (there might be many interactions in the chain)
            for (LanguageCompilation submission = Compilation; submission != null; submission = submission.PreviousSubmission)
            {
                if ((object)submission.ScriptClass != null)
                {
                    AddCandidateSymbolsWithoutInheritance(result, constraints.WithQualifier(submission.ScriptClass));
                }

                bool isCurrentSubmission = submission == Compilation;

                if (!(isCurrentSubmission && this.Flags.Includes(BinderFlags.InScriptUsing)))
                {
                    var submissionImports = submission.GetSubmissionImports();
                    if (!isCurrentSubmission)
                    {
                        submissionImports = Imports.ExpandPreviousSubmissionImports(submissionImports, Compilation);
                    }

                    // NB: We diverge from InContainerBinder here and only look in aliases.
                    // In submissions, regular usings are bubbled up to the outermost scope.
                    submissionImports.AddLookupCandidateSymbolsInAliases(result, constraints);
                }
            }
        }

        private void AddCandidateSymbolsInErrorType(LookupCandidates result, LookupConstraints constraints)
        {
            var errorType = constraints.QualifierOpt as IErrorSymbol;
            if (!errorType.CandidateSymbols.IsDefault && errorType.CandidateSymbols.Length == 1)
            {
                // The dev11 IDE experience provided meaningful information about members of inaccessible types,
                // so we should do the same (DevDiv #633340).
                // TODO: generalize to other result kinds and/or candidate counts?
                if (errorType.ErrorKind == ErrorKind.Inaccessible)
                {
                    TypeSymbol candidateType = errorType.CandidateSymbols.First() as TypeSymbol;
                    if ((object)candidateType != null)
                    {
                        AddCandidateSymbolsInType(result, constraints.WithQualifier(candidateType));
                        return; // Bypass call to Clear()
                    }
                }
            }

            result.Clear();
        }

        private void AddCandidateSymbolsInNamespace(LookupCandidates result, LookupConstraints constraints)
        {
            var candidateSymbols = LookupCandidates.GetInstance();
            AddLookupCandidateSymbolsInScope(candidateSymbols, constraints);
            foreach (var symbol in candidateSymbols.Symbols)
            {
                if (constraints.WithAccessThroughType(null).IsViable(symbol))
                {
                    result.Add(symbol);
                }
            }
            candidateSymbols.Free();
        }

        private void AddCandidateSymbolsInTypeAndBaseTypes(LookupCandidates result, LookupConstraints constraints)
        {
            AddCandidateSymbolsWithoutInheritance(result, constraints);

            var tmp = LookupCandidates.GetInstance();
            AddCandidateSymbolsInBaseTypes(tmp, constraints);
            constraints.MergeHidingLookupCandidates(result, tmp);
            tmp.Free();

            //this.AddCandidateSymbolsInTypeCore(result, constraints.WithQualifier(Compilation.GetSpecialSymbol(SpecialSymbol.System_Object))); // TODO:MetaDslx
        }

        private void AddCandidateSymbolsWithoutInheritance(LookupCandidates result, LookupConstraints constraints)
        {
            var candidateSymbols = LookupCandidates.GetInstance();
            AddLookupCandidateSymbolsInScope(candidateSymbols, constraints);
            foreach (var symbol in candidateSymbols.Symbols)
            {
                if (constraints.IsViable(symbol))
                {
                    result.Add(symbol);
                }
            }
            candidateSymbols.Free();
        }

        // Lookup member in a class, struct, enum, delegate.
        private void AddCandidateSymbolsInBaseTypes(LookupCandidates result, LookupConstraints constraints)
        {
            TypeSymbol? type = constraints.QualifierOpt as TypeSymbol;
            Debug.Assert(type is not null);
            //Debug.Assert(type.TypeKind != LanguageTypeKind.TypeParameter);

            var tmp = LookupCandidates.GetInstance();
            //type.ForceComplete(CompletionPart.FinishBaseTypes, null, default);
            foreach (var currentType in type.AllBaseTypesNoUseSiteDiagnostics)
            {
                tmp.Clear();
                AddCandidateSymbolsWithoutInheritance(tmp, constraints.WithQualifier(currentType));
                constraints.MergeHidingLookupCandidates(result, tmp);
                if (constraints.BasesBeingResolved != null && constraints.BasesBeingResolved.ContainsReference(type.OriginalDefinition))
                {
                    var other = GetNearestOtherSymbol(constraints.BasesBeingResolved, type);
                    var diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_CircularBase, type, other);
                    var error = (DeclaredSymbol)this.Compilation.SourceModule.SymbolFactory.MakeMetadataErrorSymbol(type, errorInfo: diagInfo, unreported: true);
                    result.Clear();
                    result.Add(error); // force lookup to be done w/ error symbol as result
                }
            }
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

        protected virtual void AddLookupCandidateSymbolsInScope(LookupCandidates result, LookupConstraints constraints)
        {
            var qualifier = constraints.QualifierOpt;
            if (qualifier is not null)
            {
                if (constraints.Name != null) result.AddRange(qualifier.GetMembers(constraints.Name));
                else result.AddRange(qualifier.GetMembersUnordered());
            }
        }

        protected virtual LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            if (Next == null) return constraints;
            else return Next.AdjustConstraints(constraints);
        }

        bool ILookupValidator.IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            return this.IsViable(symbol, constraints);
        }

        SingleLookupResult ILookupValidator.CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            return this.CheckSingleResultViability(result, aliasSymbol, constraints);
        }

        void ILookupValidator.CheckFinalResultViability(LookupResult result, LookupConstraints constraints)
        {
            this.CheckFinalResultViability(result, constraints);
        }

        protected virtual bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            return true;
        }

        protected virtual SingleLookupResult CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            return result;
        }

        protected virtual void CheckFinalResultViability(LookupResult result, LookupConstraints constraints)
        {
            
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType".
        /// </summary>
        public bool IsAccessible(Symbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, TypeSymbol? accessThroughType = null, ConsList<TypeSymbol>? basesBeingResolved = null)
        {
            bool failedThroughTypeCheck;
            return IsAccessible(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType", and sets "failedThroughTypeCheck" if fails
        /// the protected access check.
        /// </summary>
        public bool IsAccessible(Symbol symbol, TypeSymbol? accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol>? basesBeingResolved = null)
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
        protected virtual bool IsAccessibleHelper(Symbol symbol, TypeSymbol? accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol>? basesBeingResolved)
        {
            // By default, just delegate to containing binder.
            return Next.IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }
    }
}
