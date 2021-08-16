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
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using System;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Declarations;

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
    [Symbol(ModelObjectOption = ParameterOption.Disabled)]
    public partial class AliasSymbol : DeclaredSymbol
    {
        [SymbolProperty]
        public virtual DeclaredSymbol? Target => null;

        public override bool IsStatic => false;
        public override Accessibility DeclaredAccessibility => Accessibility.NotApplicable;

        // For the purposes of SemanticModel, it is convenient to have an AliasSymbol for the "global" namespace that "global::" binds
        // to. This alias symbol is returned only when binding "global::" (special case code).
        internal static AliasSymbol CreateGlobalNamespaceAlias(NamespaceSymbol globalNamespace, Binder globalNamespaceBinder)
        {
            return new MetadataAliasSymbol(globalNamespaceBinder, globalNamespace, "global", ImmutableArray<Location>.Empty);
        }

        internal static AliasSymbol CreateCustomDebugInfoAlias(NamespaceOrTypeSymbol targetSymbol, SyntaxToken aliasToken, Binder binder)
        {
            return new MetadataAliasSymbol(binder, targetSymbol, aliasToken.ValueText, ImmutableArray.Create(aliasToken.GetLocation()));
        }

        internal static AliasSymbol CreateUsing(string aliasName, UsingDirective directive, Binder binder)
        {
            var singleDecl = new SingleDeclaration(aliasName, aliasName, typeof(AliasSymbol), null, directive.AliasName.GetReference(), (SourceLocation)directive.AliasName.GetLocation(),
                false, false, false, null, ImmutableArray<SingleDeclaration>.Empty, ImmutableArray<DeclarationTreeInfo.Property>.Empty, ImmutableArray<Diagnostic>.Empty);
            var mergedDecl = new MergedDeclaration(ImmutableArray.Create(singleDecl));
            return new SourceAliasSymbol(binder.ContainingSymbol, mergedDecl, false);
        }

        internal static AliasSymbol CreateExternAlias(string aliasName, ExternAliasDirective directive, Binder binder)
        {
            var singleDecl = new SingleDeclaration(aliasName, aliasName, typeof(AliasSymbol), null, directive.AliasName.GetReference(), (SourceLocation)directive.AliasName.GetLocation(),
                false, false, false, null, ImmutableArray<SingleDeclaration>.Empty, ImmutableArray<DeclarationTreeInfo.Property>.Empty, ImmutableArray<Diagnostic>.Empty);
            var mergedDecl = new MergedDeclaration(ImmutableArray.Create(singleDecl));
            return new SourceAliasSymbol(binder.ContainingSymbol, mergedDecl, false);
        }

        public virtual AliasSymbol ToNewSubmission(LanguageCompilation compilation)
        {
            throw new NotImplementedException("Only MetaAliasSymbols can be forwarded to new submissions.");
        }

        // basesBeingResolved is only used to break circular references.
        public virtual DeclaredSymbol GetAliasTarget(LookupConstraints recursionConstraints)
        {
            return this.Target;
        }

        public virtual DiagnosticBag AliasTargetDiagnostics => null;

        public virtual void CheckConstraints(DiagnosticBag diagnostics)
        {
            var target = this.Target as TypeSymbol;
            if ((object)target != null && Locations.Length > 0)
            {
                target.CheckAllConstraints(DeclaringCompilation, Locations[0], diagnostics);
            }
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
