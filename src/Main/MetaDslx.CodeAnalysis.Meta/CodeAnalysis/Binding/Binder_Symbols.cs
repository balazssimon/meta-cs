// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Meta.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.RuntimeMembers;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;

namespace MetaDslx.CodeAnalysis.Binding
{
    using Cci = Microsoft.Cci;

    public partial class Binder
    {
        /// <summary>
        /// Bind the syntax into a declared symbol by also unwrapping alias symbols. 
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public DeclaredSymbol BindDeclaredSymbol(SyntaxNodeOrToken identifierSyntax, DiagnosticBag diagnostics, LookupConstraints recursionConstraints = null, ILookupValidator validatorOpt = null)
        {
            var result = BindDeclaredOrAliasSymbolInternal(identifierSyntax, diagnostics, recursionConstraints);
            return LookupConstraints.UnwrapAlias(result, recursionConstraints);
        }

        /// <summary>
        /// Bind the syntax into a declared symbol or an alias. 
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public DeclaredSymbol BindDeclaredOrAliasSymbol(SyntaxNodeOrToken identifierSyntax, DiagnosticBag diagnostics, LookupConstraints recursionConstraints = null, ILookupValidator validatorOpt = null)
        {
            var result = BindDeclaredOrAliasSymbolInternal(identifierSyntax, diagnostics, recursionConstraints);
            return result;
        }

        /// <summary>
        /// Bind the syntax into a namespace, type or alias symbol. 
        /// </summary>
        /// <remarks>
        /// This method is used in deeply recursive parts of the compiler. Specifically this and
        /// <see cref="BindQualifiedName(ExpressionSyntax, SimpleNameSyntax, DiagnosticBag, ConsList{TypeSymbol}, bool)"/>
        /// are mutually recursive. The non-recursive parts of this method tend to reserve significantly large 
        /// stack frames due to their use of large struct like <see cref="TypeWithAnnotations"/>.
        ///
        /// To keep the stack frame size on recursive paths small the non-recursive parts are factored into local 
        /// functions. This means we pay their stack penalty only when they are used. They are themselves big 
        /// enough they should be disqualified from inlining. In the future when attributes are allowed on 
        /// local functions we should explicitly mark them as <see cref="MethodImplOptions.NoInlining"/>
        /// </remarks>
        private DeclaredSymbol BindDeclaredOrAliasSymbolInternal(SyntaxNodeOrToken identifierSyntax, DiagnosticBag diagnostics, LookupConstraints recursionConstraints, string nameOpt = null, DeclaredSymbol qualifierOpt = null, ILookupValidator validatorOpt = null)
        {
            var syntaxFacts = Compilation.Language.SyntaxFacts;

            var name = nameOpt != null ? nameOpt : syntaxFacts.ExtractName(identifierSyntax);
            var metadataName = nameOpt != null ? nameOpt : syntaxFacts.ExtractMetadataName(identifierSyntax);

            // If we are here in an error-recovery scenario, say, "goo<int, >(123);" then
            // we might have an 'empty' simple name. In that case do not report an 
            // 'unable to find ""' error; we've already reported an error in the parser so
            // just bail out with an error symbol.

            if (string.IsNullOrWhiteSpace(name))
            {
                return new ExtendedErrorTypeSymbol(Compilation.Assembly.GlobalNamespace, name, metadataName, new LanguageDiagnosticInfo(InternalErrorCode.ERR_SingleTypeNameNotFound));
            }

            var validators = validatorOpt != null ? ImmutableArray.Create(validatorOpt) : ImmutableArray<ILookupValidator>.Empty;
            var result = LookupResult.GetInstance();
            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            var binder = identifierSyntax.IsNull ? this : this.GetBinder(identifierSyntax);
            var constraints = new LookupConstraints(binder, name, metadataName, qualifierOpt: qualifierOpt, isLookup: true, basesBeingResolved: recursionConstraints?.BasesBeingResolved, diagnose: recursionConstraints?.Diagnose ?? true, inUsing: recursionConstraints?.InUsing ?? false, validators: validators);
            constraints = binder.AdjustConstraints(constraints);
            LookupSymbols(result, constraints, ref useSiteDiagnostics);
            diagnostics.Add(identifierSyntax.GetLocation(), useSiteDiagnostics);

            DeclaredSymbol bindingResult;
            // If we were looking up the identifier "dynamic" at the topmost level and didn't find anything good,
            // we actually have the type dynamic (assuming /langversion is at least 4).
            if ((object)qualifierOpt == null && !identifierSyntax.IsNull &&
                (identifierSyntax.Parent == null || syntaxFacts.IsInTypeOnlyContext(identifierSyntax)) &&
                syntaxFacts.IsDynamicTypeDeclaration(identifierSyntax) &&
                !IsViableType(result))
            {
                bindingResult = Compilation.DynamicType;
                ReportUseSiteDiagnosticForDynamic(diagnostics, identifierSyntax);
            }
            else
            {
                bool wasError;

                bindingResult = constraints.ResultSymbol(result, diagnostics, recursionConstraints?.Diagnose ?? true, out wasError);
                if (bindingResult is AliasSymbol aliasSymbol)
                {
                    var aliasTarget = aliasSymbol.GetAliasTarget(recursionConstraints);
                    if (aliasTarget is NamedTypeSymbol namedTypeSymbol && namedTypeSymbol.ContainsDynamic())
                    {
                        ReportUseSiteDiagnosticForDynamic(diagnostics, identifierSyntax);
                    }
                }
            }

            result.Free();
            return bindingResult;

        }

        public ImmutableArray<DeclaredSymbol> BindQualifiedName(ImmutableArray<SyntaxNodeOrToken> identifiers, DiagnosticBag diagnostics, LookupConstraints recursionConstraints)
        {
            if (identifiers.Length == 0) return ImmutableArray<DeclaredSymbol>.Empty;
            var result = ArrayBuilder<DeclaredSymbol>.GetInstance();
            result.Add(BindDeclaredOrAliasSymbolInternal(identifiers[0], diagnostics, recursionConstraints, qualifierOpt: null));

            var last = result[0];
            for (int i = 1; i < identifiers.Length; i++)
            {
                if (last == null) break;
                result.Add(this.BindDeclaredOrAliasSymbolInternal(identifiers[i], diagnostics, recursionConstraints, qualifierOpt: last));
                last = result[i];
            }

            return result.ToImmutableAndFree();
        }

        public ImmutableArray<DeclaredSymbol> BindQualifiedName(ImmutableArray<string> identifiers, SyntaxNodeOrToken syntax, DiagnosticBag diagnostics, LookupConstraints recursionConstraints)
        {
            if (identifiers.Length == 0) return ImmutableArray<DeclaredSymbol>.Empty;
            var result = ArrayBuilder<DeclaredSymbol>.GetInstance();
            result.Add(BindDeclaredOrAliasSymbolInternal(syntax, diagnostics, recursionConstraints, nameOpt: identifiers[0], qualifierOpt: null));

            var last = result[0];
            for (int i = 1; i < identifiers.Length; i++)
            {
                if (last == null) break;
                result.Add(this.BindDeclaredOrAliasSymbolInternal(syntax, diagnostics, recursionConstraints, nameOpt: identifiers[i], qualifierOpt: last));
                last = result[i];
            }

            return result.ToImmutableAndFree();
        }

        private void ReportUseSiteDiagnosticForDynamic(DiagnosticBag diagnostics, SyntaxNodeOrToken node)
        {
            // TODO:MetaDslx
        }

        private static bool IsViableType(LookupResult result)
        {
            if (!result.IsMultiViable)
            {
                return false;
            }

            foreach (var s in result.Symbols)
            {
                if (s is AliasSymbol aliasSymbol)
                {
                    return aliasSymbol.Target is NamedTypeSymbol;
                }
                else if (s is NamedTypeSymbol)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual Symbol GetDefinedSymbol()
        {
            return null;
        }

        public virtual ImmutableArray<Symbol> GetDefinedSymbols()
        {
            return ImmutableArray<Symbol>.Empty;
        }
    }
}
