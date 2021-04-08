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
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.RuntimeMembers;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;

namespace MetaDslx.CodeAnalysis.Binding
{
    using Cci = MetaDslx.Cci;

    public partial class Binder
    {
        public DeclaredSymbol BindDeclaredSymbol(SyntaxNodeOrToken identifierSyntax, DiagnosticBag diagnostics, ConsList<TypeSymbol> basesBeingResolved = null)
        {
            return BindDeclaredSymbol(identifierSyntax, diagnostics, basesBeingResolved, basesBeingResolved != null);
        }

        /// <summary>
        /// This method is used in deeply recursive parts of the compiler and requires a non-trivial amount of stack
        /// space to execute. Preventing inlining here to keep recursive frames small.
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public DeclaredSymbol BindDeclaredSymbol(SyntaxNodeOrToken identifierSyntax, DiagnosticBag diagnostics, ConsList<TypeSymbol> basesBeingResolved, bool suppressUseSiteDiagnostics)
        {
            var result = BindDeclaredOrAliasSymbol(identifierSyntax, true, diagnostics, basesBeingResolved, suppressUseSiteDiagnostics, qualifierOpt: null);
            return LookupConstraints.UnwrapAlias(result, basesBeingResolved);
        }

        public DeclaredSymbol BindDeclaredOrAliasSymbol(SyntaxNodeOrToken identifierSyntax, bool allowMembers, DiagnosticBag diagnostics, ConsList<TypeSymbol> basesBeingResolved, bool suppressUseSiteDiagnostics, DeclaredSymbol qualifierOpt)
        {
            var syntaxFacts = Compilation.Language.SyntaxFacts;
            var identifierValueText = syntaxFacts.ExtractName(identifierSyntax);
            return BindDeclaredOrAliasSymbol(identifierValueText, identifierSyntax, allowMembers, diagnostics, basesBeingResolved, suppressUseSiteDiagnostics, qualifierOpt);
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
        private DeclaredSymbol BindDeclaredOrAliasSymbol(string identifierValueText, SyntaxNodeOrToken identifierSyntax, bool allowMembers, DiagnosticBag diagnostics, ConsList<TypeSymbol> basesBeingResolved, bool suppressUseSiteDiagnostics, DeclaredSymbol qualifierOpt)
        {
            var syntaxFacts = Compilation.Language.SyntaxFacts;

            // If we are here in an error-recovery scenario, say, "goo<int, >(123);" then
            // we might have an 'empty' simple name. In that case do not report an 
            // 'unable to find ""' error; we've already reported an error in the parser so
            // just bail out with an error symbol.

            if (string.IsNullOrWhiteSpace(identifierValueText))
            {
                return new ExtendedErrorTypeSymbol(Compilation.Assembly.GlobalNamespace, identifierValueText, identifierValueText, new LanguageDiagnosticInfo(InternalErrorCode.ERR_SingleTypeNameNotFound));
            }

            var result = LookupResult.GetInstance();
            LookupOptions options = allowMembers ? LookupOptions.Default : LookupOptions.NamespacesOrTypesOnly;

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            var constraints = new LookupConstraints(Compilation, identifierValueText, identifierValueText, qualifierOpt: qualifierOpt, basesBeingResolved: basesBeingResolved, options: options, diagnose: true);
            var identifierBinder = identifierSyntax.IsNull ? this : this.GetBinder(identifierSyntax);
            constraints = identifierBinder.AdjustConstraints(constraints.WithOriginalBinder(identifierBinder));
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

                bindingResult = constraints.ResultSymbol(result, identifierSyntax, diagnostics, suppressUseSiteDiagnostics, out wasError);
                if (bindingResult.Kind == LanguageSymbolKind.Alias)
                {
                    var aliasTarget = ((AliasSymbol)bindingResult).GetAliasTarget(basesBeingResolved);
                    if (aliasTarget.Kind == LanguageSymbolKind.NamedType && ((NamedTypeSymbol)aliasTarget).ContainsDynamic())
                    {
                        ReportUseSiteDiagnosticForDynamic(diagnostics, identifierSyntax);
                    }
                }
            }

            result.Free();
            return bindingResult;

        }

        public ImmutableArray<DeclaredSymbol> BindQualifiedName(ImmutableArray<SyntaxNodeOrToken> identifiers, DiagnosticBag diagnostics, ConsList<TypeSymbol> basesBeingResolved = null)
        {
            return BindQualifiedName(identifiers, diagnostics, basesBeingResolved, basesBeingResolved != null);
        }

        private ImmutableArray<DeclaredSymbol> BindQualifiedName(
            ImmutableArray<SyntaxNodeOrToken> identifiers,
            DiagnosticBag diagnostics,
            ConsList<TypeSymbol> basesBeingResolved,
            bool suppressUseSiteDiagnostics)
        {
            if (identifiers.Length == 0) return ImmutableArray<DeclaredSymbol>.Empty;
            var result = ArrayBuilder<DeclaredSymbol>.GetInstance();
            result.Add(BindDeclaredOrAliasSymbol(identifiers[0], true, diagnostics, basesBeingResolved, suppressUseSiteDiagnostics: false, qualifierOpt: null));

            var last = result[0];
            for (int i = 1; i < identifiers.Length; i++)
            {
                if (last == null) break;
                result.Add(this.BindDeclaredOrAliasSymbol(identifiers[i], true, diagnostics, basesBeingResolved, suppressUseSiteDiagnostics, last));
                last = result[i];
            }

            return result.ToImmutableAndFree();
        }

        public ImmutableArray<DeclaredSymbol> BindQualifiedName(ImmutableArray<string> identifiers, SyntaxNodeOrToken syntax, DiagnosticBag diagnostics)
        {
            if (identifiers.Length == 0) return ImmutableArray<DeclaredSymbol>.Empty;
            var result = ArrayBuilder<DeclaredSymbol>.GetInstance();
            result.Add(BindDeclaredOrAliasSymbol(identifiers[0], syntax, true, diagnostics, basesBeingResolved: null, suppressUseSiteDiagnostics: false, qualifierOpt: null));

            var last = result[0];
            for (int i = 1; i < identifiers.Length; i++)
            {
                if (last == null) break;
                result.Add(this.BindDeclaredOrAliasSymbol(identifiers[i], syntax, true, diagnostics, basesBeingResolved: null, suppressUseSiteDiagnostics: false, last));
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
                switch (s.Kind.Switch())
                {
                    case LanguageSymbolKind.Alias:
                        if (((AliasSymbol)s).Target.Kind == LanguageSymbolKind.NamedType) return true;
                        break;
                    case LanguageSymbolKind.NamedType:
                        return true;
                }
            }

            return false;
        }

        public virtual Symbol GetDefinedSymbol()
        {
            return null;
        }
    }
}
