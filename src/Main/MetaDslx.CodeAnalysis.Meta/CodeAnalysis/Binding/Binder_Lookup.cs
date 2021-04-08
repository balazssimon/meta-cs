// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    public partial class Binder
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
            var binder = this.LookupSymbolsInternal(result, constraints.WithDiagnose(false), ref useSiteDiagnostics);
            Debug.Assert((binder != null) || result.IsClear);

            if (result.Kind != LookupResultKind.Viable && result.Kind != LookupResultKind.Empty)
            {
                result.Clear();
                // retry to get diagnosis
                var otherBinder = this.LookupSymbolsInternal(result, constraints.WithDiagnose(true), ref useSiteDiagnostics);
                Debug.Assert(binder == otherBinder);
            }

            Debug.Assert(result.IsMultiViable || result.IsClear || result.Error != null);
            return binder;
        }

        private Binder LookupSymbolsInternal(LookupResult result, LookupConstraints constraints, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(result.IsClear);
            Debug.Assert(constraints.AreValid());

            Binder binder = null;
            for (var scope = this; scope != null && !result.IsMultiViable; scope = scope.Next)
            {
                if (binder != null)
                {
                    var tmp = LookupResult.GetInstance();
                    scope.LookupSymbolsInSingleBinder(tmp, constraints, ref useSiteDiagnostics);
                    result.MergeEqual(tmp);
                    tmp.Free();
                }
                else
                {
                    scope.LookupSymbolsInSingleBinder(result, constraints, ref useSiteDiagnostics);
                    if (!result.IsClear)
                    {
                        binder = scope;
                    }
                }
            }
            return binder;
        }

        protected virtual void LookupSymbolsInSingleBinder(LookupResult result, LookupConstraints constraints, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var candidates = LookupCandidates.GetInstance();
            AddLookupCandidateSymbolsInSingleBinder(candidates, constraints);
            foreach (var symbol in candidates.Symbols)
            {
                result.MergeEqual(LookupResult.Good(symbol));
            }
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

        protected virtual void AddLookupCandidateSymbolsInSingleBinder(LookupCandidates result, LookupConstraints constraints)
        {
            this.AddCandidateSymbols(result, constraints);
        }

        /// <summary>
        /// Look for names of members
        /// </summary>
        private void AddCandidateSymbols(LookupCandidates result, LookupConstraints constraints)
        {
            var qualifier = constraints.QualifierOpt as NamespaceOrTypeSymbol;
            if (qualifier == null || qualifier.IsNamespace)
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
            switch (type.TypeKind.Switch())
            {
                case Symbols.TypeKind.NamedType:
                case Symbols.TypeKind.Enum:
                case Symbols.TypeKind.Dynamic:
                case Symbols.TypeKind.Constructed:
                    this.AddCandidateSymbolsInTypeCore(result, constraints.WithAccessThroughType(type));
                    break;

                case Symbols.TypeKind.Submission:
                    this.AddCandidateSymbolsInSubmissions(result, constraints);
                    break;
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
                    submissionImports.AddLookupCandidateSymbolsInAliases(result, constraints);
                }
            }
        }

        private void AddCandidateSymbolsInNamespace(LookupCandidates result, LookupConstraints constraints)
        {
            var candidateMembers = GetCandidateSymbols(constraints);
            foreach (var symbol in candidateMembers)
            {
                if (constraints.WithAccessThroughType(null).IsViable(symbol))
                {
                    result.Add(symbol);
                }
            }
        }

        private void AddCandidateSymbolsWithoutInheritance(LookupCandidates result, LookupConstraints constraints)
        {
            var candidateMembers = GetCandidateSymbols(constraints);
            foreach (var symbol in candidateMembers)
            {
                if (constraints.IsViable(symbol))
                {
                    result.Add(symbol);
                }
            }
        }

        private void AddCandidateSymbolsInTypeCore(LookupCandidates result, LookupConstraints constraints)
        {
            AddCandidateSymbolsWithoutInheritance(result, constraints);

            TypeSymbol type = (TypeSymbol)constraints.QualifierOpt;
            foreach (var baseInterface in type.AllBaseTypesNoUseSiteDiagnostics)
            {
                AddCandidateSymbolsWithoutInheritance(result, constraints.WithQualifier(baseInterface));
            }

            //this.AddCandidateSymbolsInTypeCore(result, constraints.WithQualifier(Compilation.GetSpecialType(SpecialType.System_Object))); // TODO:MetaDslx
        }

        private ImmutableArray<DeclaredSymbol> GetCandidateSymbols(LookupConstraints constraints)
        {
            if (constraints.QualifierOpt != null)
            {
                if ((constraints.Options & LookupOptions.NamespacesOrTypesOnly) != 0 && constraints.QualifierOpt is TypeSymbol)
                {
                    return constraints.QualifierOpt.GetTypeMembers(constraints.Name).Cast<NamedTypeSymbol, DeclaredSymbol>();
                }
                else
                {
                    if (constraints.Name != null) return constraints.QualifierOpt.GetMembers(constraints.Name);
                    else return constraints.QualifierOpt.GetMembersUnordered();
                }
            }
            return ImmutableArray<DeclaredSymbol>.Empty;
        }


        protected virtual LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            if (Next == null) return constraints;
            else return Next.AdjustConstraints(constraints);
        }

    }
}
