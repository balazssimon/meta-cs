// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Symbol representing a using alias appearing in a compilation unit or within a namespace
    /// declaration. Generally speaking, these symbols do not appear in the set of symbols reachable
    /// from the unnamed namespace declaration.  In other words, when a using alias is used in a
    /// program, it acts as a transparent alias, and the symbol to which it is an alias is used in
    /// the symbol table.  For example, in the source code
    /// <pre>
    /// namespace NS
    /// {
    ///     using o = System.Object;
    ///     partial class C : o {}
    ///     partial class C : object {}
    ///     partial class C : System.Object {}
    /// }
    /// </pre>
    /// all three declarations for class C are equivalent and result in the same symbol table object
    /// for C. However, these using alias symbols do appear in the results of certain SemanticModel
    /// APIs. Specifically, for the base clause of the first of C's class declarations, the
    /// following APIs may produce a result that contains an AliasSymbol:
    /// <pre>
    ///     SemanticInfo SemanticModel.GetSemanticInfo(ExpressionSyntax expression);
    ///     SemanticInfo SemanticModel.BindExpression(CSharpSyntaxNode location, ExpressionSyntax expression);
    ///     SemanticInfo SemanticModel.BindType(CSharpSyntaxNode location, ExpressionSyntax type);
    ///     SemanticInfo SemanticModel.BindNamespaceOrType(CSharpSyntaxNode location, ExpressionSyntax type);
    /// </pre>
    /// Also, the following are affected if container==null (and, for the latter, when arity==null
    /// or arity==0):
    /// <pre>
    ///     IList&lt;string&gt; SemanticModel.LookupNames(CSharpSyntaxNode location, NamespaceOrTypeSymbol container = null, LookupOptions options = LookupOptions.Default, List&lt;string> result = null);
    ///     IList&lt;Symbol&gt; SemanticModel.LookupSymbols(CSharpSyntaxNode location, NamespaceOrTypeSymbol container = null, string name = null, int? arity = null, LookupOptions options = LookupOptions.Default, List&lt;Symbol> results = null);
    /// </pre>
    /// </summary>
    [Symbol(NoMeta = true, OptionalModelObject = true)]
    public partial class AliasSymbol : DeclaredSymbol
    {
        [SymbolProperty]
        public virtual DeclaredSymbol? Target => null;
        [SymbolProperty]
        public override bool IsExtern => false;

        public override bool IsSealed => false;
        public override bool IsAbstract => false;
        public override bool IsOverride => false;
        public override bool IsVirtual => false;
        public override bool IsStatic => false;
        public override Accessibility DeclaredAccessibility => Accessibility.NotApplicable;

        // For the purposes of SemanticModel, it is convenient to have an AliasSymbol for the "global" namespace that "global::" binds
        // to. This alias symbol is returned only when binding "global::" (special case code).
        internal static AliasSymbol CreateGlobalNamespaceAlias(NamespaceSymbol globalNamespace, Binder globalNamespaceBinder)
        {
            return null;
        }

        internal static AliasSymbol CreateCustomDebugInfoAlias(NamespaceOrTypeSymbol targetSymbol, SyntaxToken aliasToken, Binder binder)
        {
            return null;
        }

        internal static AliasSymbol CreateUsing(string aliasName, UsingDirective directive, Binder binder)
        {
            return null;
        }

        internal static AliasSymbol CreateExternAlias(string aliasName, ExternAliasDirective directive, Binder binder)
        {
            return null;
        }

        internal AliasSymbol ToNewSubmission(LanguageCompilation compilation)
        {
            return null;
        }

        // basesBeingResolved is only used to break circular references.
        public DeclaredSymbol GetAliasTarget(LookupConstraints recursionConstraints)
        {
            return null;
        }

        internal DiagnosticBag AliasTargetDiagnostics => null;

        internal void CheckConstraints(DiagnosticBag diagnostics)
        {
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return ImmutableArray<DeclaredSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            AliasSymbol other = obj as AliasSymbol;

            return (object)other != null &&
                Equals(this.Locations.FirstOrDefault(), other.Locations.FirstOrDefault()) &&
                this.ContainingAssembly == other.ContainingAssembly;
        }

        public override int GetHashCode()
        {
            if (this.Locations.Length > 0)
                return this.Locations.First().GetHashCode();
            else
                return Name.GetHashCode();
        }

    }
}
