// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;

namespace MetaDslx.CodeAnalysis
{
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    /// <summary>
    /// Allows asking semantic questions about a tree of syntax nodes in a Compilation. Typically,
    /// an instance is obtained by a call to <see cref="Compilation"/>.<see
    /// cref="Compilation.GetSemanticModel"/>. 
    /// </summary>
    /// <remarks>
    /// <para>An instance of <see cref="LanguageSemanticModel"/> caches local symbols and semantic
    /// information. Thus, it is much more efficient to use a single instance of <see
    /// cref="LanguageSemanticModel"/> when asking multiple questions about a syntax tree, because
    /// information from the first question may be reused. This also means that holding onto an
    /// instance of SemanticModel for a long time may keep a significant amount of memory from being
    /// garbage collected.
    /// </para>
    /// <para>
    /// When an answer is a named symbol that is reachable by traversing from the root of the symbol
    /// table, (that is, from an <see cref="AssemblySymbol"/> of the <see cref="Compilation"/>),
    /// that symbol will be returned (i.e. the returned value will be reference-equal to one
    /// reachable from the root of the symbol table). Symbols representing entities without names
    /// (e.g. array-of-int) may or may not exhibit reference equality. However, some named symbols
    /// (such as local variables) are not reachable from the root. These symbols are visible as
    /// answers to semantic questions. When the same SemanticModel object is used, the answers
    /// exhibit reference-equality.  
    /// </para>
    /// </remarks>
    internal abstract class LanguageSemanticModel : SemanticModelAdapter
    {
        /// <summary>
        /// The compilation this object was obtained from.
        /// </summary>
        public new abstract LanguageCompilation Compilation { get; }

        /// <summary>
        /// The root node of the syntax tree that this binding is based on.
        /// </summary>
        public new abstract LanguageSyntaxNode Root { get; }

        public new Language Language => this.Compilation.Language;

        protected override Language LanguageCore => this.Language;

        public SyntaxFactory SyntaxFactory => this.Language.SyntaxFactory;

        public SyntaxFacts SyntaxFacts => this.Language.SyntaxFacts;

        public abstract BoundTree BoundTree { get; }

        // Is this node one that could be successfully interrogated by GetSymbolInfo/GetTypeInfo/GetMemberGroup/GetConstantValue?
        // WARN: If isSpeculative is true, then don't look at .Parent - there might not be one.
        public virtual bool CanGetSemanticInfo(LanguageSyntaxNode node, bool allowNamedArgumentName = false, bool isSpeculative = false)
        {
            Debug.Assert(node != null);
            // If we are being asked for binding info on a "missing" syntax node
            // then there's no point in doing any work at all. For example, the user might
            // have something like "class C { [] void M() {} }". The caller might obtain 
            // the attribute declaration syntax and then attempt to ask for type information
            // about the contents of the attribute. But the parser has recovered from the 
            // missing attribute type and filled in a "missing" node in its place. There's
            // nothing we can do with that, so let's not allow it.
            if (node.IsMissing)
            {
                return false;
            }
            return true;
        }

        #region Abstract worker methods

        /// <summary>
        /// Gets symbol information about a syntax node. This is overridden by various specializations of SemanticModel.
        /// It can assume that CheckSyntaxNode and CanGetSemanticInfo have already been called, as well as that named
        /// argument nodes have been handled.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="options">Options to control behavior.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        internal abstract SymbolInfo GetSymbolInfoWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets type information about a syntax node. This is overridden by various specializations of SemanticModel.
        /// It can assume that CheckSyntaxNode and CanGetSemanticInfo have already been called, as well as that named
        /// argument nodes have been handled.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        internal abstract LanguageTypeInfo GetTypeInfoWorker(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a list of method or indexed property symbols for a syntax node. This is overridden by various specializations of SemanticModel.
        /// It can assume that CheckSyntaxNode and CanGetSemanticInfo have already been called, as well as that named
        /// argument nodes have been handled.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        internal abstract ImmutableArray<Symbol> GetMemberGroupWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the constant value for a syntax node. This is overridden by various specializations of SemanticModel.
        /// It can assume that CheckSyntaxNode and CanGetSemanticInfo have already been called, as well as that named
        /// argument nodes have been handled.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        internal abstract Optional<object> GetConstantValueWorker(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken));

        #endregion Abstract worker methods

        #region Helpers for speculative binding

        internal virtual Binder GetSpeculativeBinder(int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            Debug.Assert(node != null);
            position = CheckAndAdjustPosition(position);
            Binder binder = this.GetEnclosingBinder(position);
            return binder;
        }

        private static BoundNode GetSpeculativelyBoundExpressionHelper(Binder binder, LanguageSyntaxNode expression, SpeculativeBindingOption bindingOption, DiagnosticBag diagnostics)
        {
            Debug.Assert(binder != null);
            Debug.Assert(binder.IsSemanticModelBinder);
            Debug.Assert(expression != null);
            throw new NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Bind the given expression speculatively at the given position, and return back
        /// the resulting bound node. May return null in some error cases.
        /// </summary>
        /// <remarks>
        /// Keep in sync with Binder.BindCrefParameterOrReturnType.
        /// </remarks>
        private BoundNode GetSpeculativelyBoundNode(int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption, out Binder binder)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            node = this.Language.SyntaxFactory.GetStandaloneNode(node);
            binder = this.GetSpeculativeBinder(position, node, bindingOption);
            if (binder == null) return default;
            var diagnostics = DiagnosticBag.GetInstance();
            var boundNode = GetSpeculativelyBoundExpressionHelper(binder, node, bindingOption, diagnostics);
            diagnostics.Free();
            return boundNode;
        }

        #endregion Helpers for speculative binding

        protected override IOperation GetOperationCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            var csnode = (LanguageSyntaxNode)node;
            CheckSyntaxNode(csnode);

            return this.GetOperationWorker(csnode, cancellationToken);
        }

        internal virtual IOperation GetOperationWorker(LanguageSyntaxNode node, CancellationToken cancellationToken)
        {
            return null;
        }

        #region GetSymbolInfo

        /// <summary>
        /// Returns what symbol(s), if any, the given expression syntax bound to in the program.
        /// 
        /// An AliasSymbol will never be returned by this method. What the alias refers to will be
        /// returned instead. To get information about aliases, call GetAliasInfo.
        /// 
        /// If binding the type name C in the expression "new C(...)" the actual constructor bound to
        /// will be returned (or all constructor if overload resolution failed). This occurs as long as C
        /// unambiguously binds to a single type that has a constructor. If C ambiguously binds to multiple
        /// types, or C binds to a static class, then type(s) are returned.
        /// </summary>
        public SymbolInfo GetSymbolInfo(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(node);
            if (!CanGetSemanticInfo(node, allowNamedArgumentName: true))
            {
                return SymbolInfo.None;
            }
            return this.GetSymbolInfoWorker(node, SymbolInfoOptions.DefaultOptions, cancellationToken);
        }

        /// <summary>
        /// Binds the expression in the context of the specified location and gets symbol information.
        /// This method is used to get symbol information about an expression that did not actually
        /// appear in the source code.
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="expression">A syntax node that represents a parsed expression. This syntax
        /// node need not and typically does not appear in the source code referred to by the
        /// SemanticModel instance.</param>
        /// <param name="bindingOption">Indicates whether to binding the expression as a full expressions,
        /// or as a type or namespace. If SpeculativeBindingOption.BindAsTypeOrNamespace is supplied, then
        /// expression should derive from TypeSyntax.</param>
        /// <returns>The symbol information for the topmost node of the expression.</returns>
        /// <remarks>
        /// The passed in expression is interpreted as a stand-alone expression, as if it
        /// appeared by itself somewhere within the scope that encloses "position".
        /// 
        /// <paramref name="bindingOption"/> is ignored if <paramref name="position"/> is within a documentation
        /// comment cref attribute value.
        /// </remarks>
        public SymbolInfo GetSpeculativeSymbolInfo(int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            if (!CanGetSemanticInfo(node, isSpeculative: true)) return SymbolInfo.None;

            Binder binder;
            BoundNode boundNode = GetSpeculativelyBoundNode(position, node, bindingOption, out binder); //calls CheckAndAdjustPosition
            var symbolInfo = this.GetSymbolInfoForNode(SymbolInfoOptions.DefaultOptions, ImmutableArray.Create(boundNode), boundNodeForSyntacticParent: default, binderOpt: binder);
            return symbolInfo;
        }

        #endregion GetSymbolInfo

        #region GetTypeInfo

        /// <summary>
        /// Gets type information about an expression.
        /// </summary>
        /// <param name="expression">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public TypeInfo GetTypeInfo(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(node);
            if (!CanGetSemanticInfo(node))
            {
                return LanguageTypeInfo.None;
            }
            return GetTypeInfoWorker(node, cancellationToken);
        }

        /// <summary>
        /// Gets the conversion that occurred between the expression's type and type implied by the expression's context.
        /// </summary>
        public Conversion GetConversion(SyntaxNode expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            var csnode = (LanguageSyntaxNode)expression;

            CheckSyntaxNode(csnode);

            var info = CanGetSemanticInfo(csnode)
                ? GetTypeInfoWorker(csnode, cancellationToken)
                : LanguageTypeInfo.None;

            return info.ImplicitConversion;
        }

        /// <summary>
        /// Binds the expression in the context of the specified location and gets type information.
        /// This method is used to get type information about an expression that did not actually
        /// appear in the source code.
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="node">A syntax node that represents a parsed expression. This syntax
        /// node need not and typically does not appear in the source code referred to by the
        /// SemanticModel instance.</param>
        /// <param name="bindingOption">Indicates whether to binding the expression as a full expressions,
        /// or as a type or namespace. If SpeculativeBindingOption.BindAsTypeOrNamespace is supplied, then
        /// expression should derive from TypeSyntax.</param>
        /// <returns>The type information for the topmost node of the expression.</returns>
        /// <remarks>The passed in expression is interpreted as a stand-alone expression, as if it
        /// appeared by itself somewhere within the scope that encloses "position".</remarks>
        public TypeInfo GetSpeculativeTypeInfo(int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            return GetSpeculativeTypeInfoWorker(position, node, bindingOption);
        }

        internal LanguageTypeInfo GetSpeculativeTypeInfoWorker(int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            if (!CanGetSemanticInfo(node, isSpeculative: true))
            {
                return LanguageTypeInfo.None;
            }
            Binder binder;
            BoundNode boundNode = GetSpeculativelyBoundNode(position, node, bindingOption, out binder); //calls CheckAndAdjustPosition
            var typeInfo = GetTypeInfoForNode(ImmutableArray.Create(boundNode), boundNodeForSyntacticParent: default);
            return typeInfo;
        }

        /// <summary>
        /// Gets the conversion that occurred between the expression's type and type implied by the expression's context.
        /// </summary>
        public Conversion GetSpeculativeConversion(int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            var info = this.GetSpeculativeTypeInfoWorker(position, node, bindingOption);
            return info.ImplicitConversion;
        }

        #endregion GetTypeInfo

        #region GetMemberGroup

        /// <summary>
        /// Gets a list of method or indexed property symbols for a syntax node.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public ImmutableArray<ISymbol> GetMemberGroup(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(node);

            return CanGetSemanticInfo(node)
                ? StaticCast<ISymbol>.From(this.GetMemberGroupWorker(node, SymbolInfoOptions.DefaultOptions, cancellationToken))
                : ImmutableArray<ISymbol>.Empty;
        }

        #endregion GetIndexerGroup

        #region GetConstantValue

        public Optional<object> GetConstantValue(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(node);

            return CanGetSemanticInfo(node)
                ? this.GetConstantValueWorker(node, cancellationToken)
                : default(Optional<object>);
        }

        #endregion GetConstantValue

        /// <summary>
        /// If <paramref name="aliasSyntax"/> resolves to an alias name, return the AliasSymbol corresponding
        /// to A. Otherwise return null.
        /// </summary>
        public IAliasSymbol GetAliasInfo(LanguageSyntaxNode aliasSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(aliasSyntax);

            if (!CanGetSemanticInfo(aliasSyntax))
                return null;

            SymbolInfo info = GetSymbolInfoWorker(aliasSyntax, SymbolInfoOptions.PreferTypeToConstructors | SymbolInfoOptions.PreserveAliases, cancellationToken);
            return info.Symbol as AliasSymbol;
        }

        /// <summary>
        /// Binds the name in the context of the specified location and sees if it resolves to an
        /// alias name. If it does, return the AliasSymbol corresponding to it. Otherwise, return null.
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="aliasSyntax">A syntax node that represents a name. This syntax
        /// node need not and typically does not appear in the source code referred to by the
        /// SemanticModel instance.</param>
        /// <param name="bindingOption">Indicates whether to binding the name as a full expression,
        /// or as a type or namespace. If SpeculativeBindingOption.BindAsTypeOrNamespace is supplied, then
        /// expression should derive from TypeSyntax.</param>
        /// <remarks>The passed in name is interpreted as a stand-alone name, as if it
        /// appeared by itself somewhere within the scope that encloses "position".</remarks>
        public IAliasSymbol GetSpeculativeAliasInfo(int position, LanguageSyntaxNode aliasSyntax, SpeculativeBindingOption bindingOption)
        {
            Binder binder;
            BoundNode boundNode = GetSpeculativelyBoundNode(position, aliasSyntax, bindingOption, out binder); //calls CheckAndAdjustPosition

            var symbolInfo = this.GetSymbolInfoForNode(SymbolInfoOptions.PreferTypeToConstructors | SymbolInfoOptions.PreserveAliases,
                ImmutableArray.Create(boundNode), boundNodeForSyntacticParent: default, binderOpt: binder);

            return symbolInfo.Symbol as AliasSymbol;
        }

        /// <summary>
        /// Gets the binder that encloses the position.
        /// </summary>
        internal Binder GetEnclosingBinder(int position)
        {
            Binder result = GetEnclosingBinderInternal(position);
            Debug.Assert(result == null || result.IsSemanticModelBinder);
            return result;
        }

        internal abstract Binder GetEnclosingBinderInternal(int position);

        /// <summary>
        /// Gets the MemberSemanticModel that contains the node.
        /// </summary>
        internal abstract MemberSemanticModel GetMemberModel(SyntaxNode node);

        internal bool IsInTree(SyntaxNode node)
        {
            return node.SyntaxTree == this.SyntaxTree;
        }

        /// <summary>
        /// Given a position, locates the containing token.  If the position is actually within the
        /// leading trivia of the containing token or if that token is EOF, moves one token to the
        /// left.  Returns the start position of the resulting token.
        /// 
        /// This has the effect of moving the position left until it hits the beginning of a non-EOF
        /// token.
        /// 
        /// Throws an ArgumentOutOfRangeException if position is not within the root of this model.
        /// </summary>
        protected int CheckAndAdjustPosition(int position)
        {
            return BoundTree.CheckAndAdjustPosition(position);
        }

        protected int CheckAndAdjustPosition(int position, out SyntaxToken token)
        {
            return BoundTree.CheckAndAdjustPosition(position, out token);
        }

        /// <summary>
        /// A convenience method that determines a position from a node.  If the node is missing,
        /// then its position will be adjusted using CheckAndAdjustPosition.
        /// </summary>
        protected int GetAdjustedNodePosition(SyntaxNode node)
        {
            return BoundTree.GetAdjustedNodePosition(node);
        }

        [Conditional("DEBUG")]
        protected void AssertPositionAdjusted(int position)
        {
            Debug.Assert(position == CheckAndAdjustPosition(position), "Expected adjusted position");
        }

        protected void CheckSyntaxNode(LanguageSyntaxNode syntax)
        {
            BoundTree.CheckSyntaxNode(syntax);
        }

        // This method ensures that the given syntax node to speculate is non-null and doesn't belong to a SyntaxTree of any model in the chain.
        private void CheckModelAndSyntaxNodeToSpeculate(LanguageSyntaxNode syntax)
        {
            if (syntax == null)
            {
                throw new ArgumentNullException(nameof(syntax));
            }

            if (this.IsSpeculativeSemanticModel)
            {
                throw new InvalidOperationException(CSharpResources.ChainingSpeculativeModelIsNotSupported);
            }

            if (this.Compilation.ContainsSyntaxTree(syntax.SyntaxTree))
            {
                throw new ArgumentException(CSharpResources.SpeculatedSyntaxNodeCannotBelongToCurrentCompilation);
            }
        }

        /// <summary>
        /// Gets the available named symbols in the context of the specified location and optional container. Only
        /// symbols that are accessible and visible from the given location are returned.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="container">The container to search for symbols within. If null then the enclosing declaration
        /// scope around position is used.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <param name="includeReducedExtensionMethods">Consider (reduced) extension methods.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible. Even if "container" is
        /// specified, the "position" location is significant for determining which members of "containing" are
        /// accessible. 
        /// 
        /// Labels are not considered (see <see cref="LookupLabels"/>).
        /// 
        /// Non-reduced extension methods are considered regardless of the value of <paramref name="includeReducedExtensionMethods"/>.
        /// </remarks>
        public new ImmutableArray<ISymbol> LookupSymbols(
            int position,
            INamespaceOrTypeSymbol container = null,
            string name = null,
            bool includeReducedExtensionMethods = false)
        {
            var options = includeReducedExtensionMethods ? LookupOptions.IncludeExtensionMethods : LookupOptions.Default;
            return StaticCast<ISymbol>.From(LookupSymbolsInternal(position, ToLanguageSpecific(container), name, options, useBaseReferenceAccessibility: false));
        }

        /// <summary>
        /// Gets the available base type members in the context of the specified location.  Akin to
        /// calling <see cref="LookupSymbols"/> with the container set to the immediate base type of
        /// the type in which <paramref name="position"/> occurs.  However, the accessibility rules
        /// are different: protected members of the base type will be visible.
        /// 
        /// Consider the following example:
        /// 
        ///   public class Base
        ///   {
        ///       protected void M() { }
        ///   }
        ///   
        ///   public class Derived : Base
        ///   {
        ///       void Test(Base b)
        ///       {
        ///           b.M(); // Error - cannot access protected member.
        ///           base.M();
        ///       }
        ///   }
        /// 
        /// Protected members of an instance of another type are only accessible if the instance is known
        /// to be "this" instance (as indicated by the "base" keyword).
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible.
        /// 
        /// Non-reduced extension methods are considered, but reduced extension methods are not.
        /// </remarks>
        public new ImmutableArray<ISymbol> LookupBaseMembers(
            int position,
            string name = null)
        {
            return StaticCast<ISymbol>.From(LookupSymbolsInternal(position, container: null, name: name, options: LookupOptions.Default, useBaseReferenceAccessibility: true));
        }

        /// <summary>
        /// Gets the available named static member symbols in the context of the specified location and optional container.
        /// Only members that are accessible and visible from the given location are returned.
        /// 
        /// Non-reduced extension methods are considered, since they are static methods.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="container">The container to search for symbols within. If null then the enclosing declaration
        /// scope around position is used.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible. Even if "container" is
        /// specified, the "position" location is significant for determining which members of "containing" are
        /// accessible. 
        /// </remarks>
        public new ImmutableArray<ISymbol> LookupStaticMembers(
            int position,
            INamespaceOrTypeSymbol container = null,
            string name = null)
        {
            return StaticCast<ISymbol>.From(LookupSymbolsInternal(position, ToLanguageSpecific(container), name, LookupOptions.MustNotBeInstance, useBaseReferenceAccessibility: false));
        }

        /// <summary>
        /// Gets the available named namespace and type symbols in the context of the specified location and optional container.
        /// Only members that are accessible and visible from the given location are returned.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="container">The container to search for symbols within. If null then the enclosing declaration
        /// scope around position is used.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible. Even if "container" is
        /// specified, the "position" location is significant for determining which members of "containing" are
        /// accessible. 
        /// 
        /// Does not return INamespaceOrTypeSymbol, because there could be aliases.
        /// </remarks>
        public new ImmutableArray<ISymbol> LookupNamespacesAndTypes(
            int position,
            INamespaceOrTypeSymbol container = null,
            string name = null)
        {
            return StaticCast<ISymbol>.From(LookupSymbolsInternal(position, ToLanguageSpecific(container), name, LookupOptions.NamespacesOrTypesOnly, useBaseReferenceAccessibility: false));
        }

        /// <summary>
        /// Gets the available named label symbols in the context of the specified location and optional container.
        /// Only members that are accessible and visible from the given location are returned.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible. Even if "container" is
        /// specified, the "position" location is significant for determining which members of "containing" are
        /// accessible. 
        /// </remarks>
        public new ImmutableArray<ISymbol> LookupLabels(
            int position,
            string name = null)
        {
            return StaticCast<ISymbol>.From(LookupSymbolsInternal(position, container: null, name: name, options: LookupOptions.LabelsOnly, useBaseReferenceAccessibility: false));
        }

        /// <summary>
        /// Gets the available named symbols in the context of the specified location and optional
        /// container. Only symbols that are accessible and visible from the given location are
        /// returned.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration
        /// scope and accessibility.</param>
        /// <param name="container">The container to search for symbols within. If null then the
        /// enclosing declaration scope around position is used.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <param name="options">Additional options that affect the lookup process.</param>
        /// <param name="useBaseReferenceAccessibility">Ignore 'throughType' in accessibility checking. 
        /// Used in checking accessibility of symbols accessed via 'MyBase' or 'base'.</param>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible. Even if
        /// "container" is specified, the "position" location is significant for determining which
        /// members of "containing" are accessible. 
        /// </remarks>
        /// <exception cref="ArgumentException">Throws an argument exception if the passed lookup options are invalid.</exception>
        private ImmutableArray<DeclaredSymbol> LookupSymbolsInternal(
            int position,
            NamespaceOrTypeSymbol container,
            string name,
            LookupOptions options,
            bool useBaseReferenceAccessibility)
        {
            Debug.Assert((options & LookupOptions.UseBaseReferenceAccessibility) == 0, "Use the useBaseReferenceAccessibility parameter.");
            if (useBaseReferenceAccessibility)
            {
                options |= LookupOptions.UseBaseReferenceAccessibility;
            }
            Debug.Assert(!options.IsAttributeTypeLookup()); // Not exposed publicly.

            options.ThrowIfInvalid();

            SyntaxToken token;
            position = CheckAndAdjustPosition(position, out token);

            if ((object)container == null || container.Kind == LanguageSymbolKind.Namespace)
            {
                options &= ~LookupOptions.IncludeExtensionMethods;
            }

            var binder = GetEnclosingBinder(position);
            if (binder == null)
            {
                return ImmutableArray<DeclaredSymbol>.Empty;
            }

            if (useBaseReferenceAccessibility)
            {
                Debug.Assert((object)container == null);
                TypeSymbol containingType = binder.ContainingType;
                TypeSymbol baseType = null;

                // For a script class or a submission class base should have no members.
                if ((object)containingType != null && containingType.Kind == LanguageSymbolKind.NamedType && ((NamedTypeSymbol)containingType).IsScript)
                {
                    return ImmutableArray<DeclaredSymbol>.Empty;
                }

                if ((object)containingType == null || containingType.BaseTypesNoUseSiteDiagnostics.IsEmpty)
                {
                    throw new ArgumentException(
                        "Not a valid position for a call to LookupBaseMembers (must be in a type with a base type)",
                        nameof(position));
                }
                container = baseType;
            }

            var info = LookupSymbolsInfo.GetInstance();
            info.FilterName = name;

            if ((object)container == null)
            {
                binder.AddLookupSymbolsInfo(info, new LookupConstraints(options: options));
            }
            else
            {
                binder.AddMemberLookupSymbolsInfo(info, new LookupConstraints(qualifierOpt: container, options: options));
            }

            var results = ArrayBuilder<DeclaredSymbol>.GetInstance(info.Count);

            if (name == null)
            {
                // If they didn't provide a name, then look up all names and associated arities 
                // and find all the corresponding symbols.
                foreach (string foundName in info.Names)
                {
                    AppendSymbolsWithName(results, foundName, binder, container, options, info);
                }
            }
            else
            {
                // They provided a name.  Find all the arities for that name, and then look all of those up.
                AppendSymbolsWithName(results, name, binder, container, options, info);
            }

            info.Free();


            if ((options & LookupOptions.IncludeExtensionMethods) != 0)
            {
                throw new NotImplementedException("TODO:MetaDslx");
            }

            ImmutableArray<DeclaredSymbol> sealedResults = results.ToImmutableAndFree();
            return name == null
                ? FilterNotReferencable(sealedResults)
                : sealedResults;
        }

        private void AppendSymbolsWithName(ArrayBuilder<DeclaredSymbol> results, string name, Binder binder, NamespaceOrTypeSymbol container, LookupOptions options, LookupSymbolsInfo info)
        {
            IEnumerable<string> metadataNames;
            DeclaredSymbol uniqueSymbol;

            if (info.TryGetMultipleNamesAndUniqueSymbol(name, out metadataNames, out uniqueSymbol))
            {
                if ((object)uniqueSymbol != null)
                {
                    // This name mapped to something unique.  We don't need to proceed
                    // with a costly lookup.  Just add it straight to the results.
                    results.Add(uniqueSymbol);
                }
                else
                {
                    // The name maps to multiple symbols. Actually do a real lookup so 
                    // that we will properly figure out hiding and whatnot.
                    if (metadataNames != null)
                    {
                        foreach (var metadataName in metadataNames)
                        {
                            this.AppendSymbolsWithMetadataName(results, name, metadataName, binder, container, options);
                        }
                    }
                    else
                    {
                        //non-unique symbol with non-zero arity doesn't seem possible.
                        this.AppendSymbolsWithMetadataName(results, name, name, binder, container, options);
                    }
                }
            }
        }

        private void AppendSymbolsWithMetadataName(
            ArrayBuilder<DeclaredSymbol> results,
            string name,
            string metadataName,
            Binder binder,
            NamespaceOrTypeSymbol container,
            LookupOptions options)
        {
            Debug.Assert(results != null);

            // Don't need to de-dup since AllMethodsOnArityZero can't be set at this point (not exposed in CommonLookupOptions).
            Debug.Assert((options & LookupOptions.AllMethodsOnArityZero) == 0);

            var lookupResult = LookupResult.GetInstance();

            binder.LookupSymbolsSimpleName(
                lookupResult,
                new LookupConstraints(
                name,
                metadataName,
                qualifierOpt: container,
                basesBeingResolved: null,
                options: options & ~LookupOptions.IncludeExtensionMethods,
                diagnose: false));

            if (lookupResult.IsMultiViable)
            {
                if (lookupResult.Symbols.Any(t => t.Kind == LanguageSymbolKind.NamedType || t.Kind == LanguageSymbolKind.Namespace || t.Kind == LanguageSymbolKind.ErrorType))
                {
                    // binder.ResultSymbol is defined only for type/namespace lookups
                    bool wasError;
                    var diagnostics = DiagnosticBag.GetInstance();  // client code never expects a null diagnostic bag.
                    DeclaredSymbol singleSymbol = binder.ResultSymbol(lookupResult, name, metadataName, this.Root, diagnostics, true, out wasError, container, options);
                    diagnostics.Free();

                    if (!wasError)
                    {
                        results.Add(singleSymbol);
                    }
                    else
                    {
                        results.AddRange(lookupResult.Symbols);
                    }
                }
                else
                {
                    results.AddRange(lookupResult.Symbols);
                }
            }

            lookupResult.Free();
        }

        private static ImmutableArray<DeclaredSymbol> FilterNotReferencable(ImmutableArray<DeclaredSymbol> sealedResults)
        {
            ArrayBuilder<DeclaredSymbol> builder = null;
            int pos = 0;
            foreach (var result in sealedResults)
            {
                if (result.CanBeReferencedByName)
                {
                    builder?.Add(result);
                }
                else if (builder == null)
                {
                    builder = ArrayBuilder<DeclaredSymbol>.GetInstance();
                    builder.AddRange(sealedResults, pos);
                }
                pos++;
            }

            return builder?.ToImmutableAndFree() ?? sealedResults;
        }

        /// <summary>
        /// Determines if the symbol is accessible from the specified location. 
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="symbol">The symbol that we are checking to see if it accessible.</param>
        /// <returns>
        /// True if "symbol is accessible, false otherwise.</returns>
        /// <remarks>
        /// This method only checks accessibility from the point of view of the accessibility
        /// modifiers on symbol and its containing types. Even if true is returned, the given symbol
        /// may not be able to be referenced for other reasons, such as name hiding.
        /// </remarks>
        public new bool IsAccessible(int position, ISymbol symbol)
        {
            position = CheckAndAdjustPosition(position);

            if ((object)symbol == null)
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            var cssymbol = symbol.EnsureLanguageSymbolOrNull<ISymbol, DeclaredSymbol>(nameof(symbol));

            var binder = this.GetEnclosingBinder(position);
            if (binder != null)
            {
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                return binder.IsAccessible(cssymbol, ref useSiteDiagnostics, null);
            }

            return false;
        }

        // Gets the semantic info from a specific bound node and a set of diagnostics
        // lowestBoundNode: The lowest node in the bound tree associated with node
        // highestBoundNode: The highest node in the bound tree associated with node
        // boundNodeForSyntacticParent: The lowest node in the bound tree associated with node.Parent.
        // binderOpt: If this is null, then the one enclosing the bound node's syntax will be used (unsafe during speculative binding).
        [PerformanceSensitive(
            "https://github.com/dotnet/roslyn/issues/23582",
            Constraint = "Provide " + nameof(ArrayBuilder<Symbol>) + " capacity to reduce number of allocations.")]
        internal SymbolInfo GetSymbolInfoForNode(
            SymbolInfoOptions options,
            ImmutableArray<BoundNode> boundNodes,
            BoundNode boundNodeForSyntacticParent,
            Binder binderOpt)
        {
            if (boundNodes.Length == 0) return SymbolInfo.None;

            // TODO: Should parenthesized expression really not have symbols? At least for C#, I'm not sure that
            // is right. For example, C# allows the assignment statement:
            //    (i) = 9;
            // So we don't think this code should special case parenthesized expressions.

            // Get symbols and result kind from the lowest and highest nodes associated with the
            // syntax node.
            ImmutableArray<Symbol> symbols = GetSemanticSymbols(
                boundNodes[0], boundNodeForSyntacticParent, binderOpt, options, out bool isDynamic, out LookupResultKind resultKind, out ImmutableArray<Symbol> unusedMemberGroup);

            /*if (highestBoundNode is BoundExpression highestBoundExpr)
            {
                LookupResultKind highestResultKind;
                bool highestIsDynamic;
                ImmutableArray<Symbol> unusedHighestMemberGroup;
                ImmutableArray<Symbol> highestSymbols = GetSemanticSymbols(
                    highestBoundExpr, boundNodeForSyntacticParent, binderOpt, options, out highestIsDynamic, out highestResultKind, out unusedHighestMemberGroup);

                if ((symbols.Length != 1 || resultKind == LookupResultKind.OverloadResolutionFailure) && highestSymbols.Length > 0)
                {
                    symbols = highestSymbols;
                    resultKind = highestResultKind;
                    isDynamic = highestIsDynamic;
                }
                else if (highestResultKind != LookupResultKind.Empty && highestResultKind < resultKind)
                {
                    resultKind = highestResultKind;
                    isDynamic = highestIsDynamic;
                }
                else 
                {
                    symbols = highestSymbols;
                    resultKind = highestResultKind;
                    isDynamic = highestIsDynamic;
                }
            }*/

            if (resultKind == LookupResultKind.Empty)
            {
                // Empty typically indicates an error symbol that was created because no real
                // symbol actually existed.
                return SymbolInfoFactory.Create(ImmutableArray<Symbol>.Empty, LookupResultKind.Empty, isDynamic);
            }
            else
            {
                // Caas clients don't want ErrorTypeSymbol in the symbols, but the best guess
                // instead. If no best guess, then nothing is returned.
                var builder = ArrayBuilder<Symbol>.GetInstance(symbols.Length);
                foreach (Symbol symbol in symbols)
                {
                    AddUnwrappingErrorTypes(builder, symbol);
                }

                symbols = builder.ToImmutableAndFree();
            }

            if ((options & SymbolInfoOptions.ResolveAliases) != 0)
            {
                symbols = UnwrapAliases(symbols);
            }

            if (resultKind == LookupResultKind.Viable && symbols.Length > 1)
            {
                resultKind = LookupResultKind.OverloadResolutionFailure;
            }

            return SymbolInfoFactory.Create(symbols, resultKind, isDynamic);
        }

        private static void AddUnwrappingErrorTypes(ArrayBuilder<Symbol> builder, Symbol s)
        {
            var originalErrorSymbol = (s as DeclaredSymbol)?.OriginalDefinition as ErrorTypeSymbol;
            if ((object)originalErrorSymbol != null)
            {
                builder.AddRange(originalErrorSymbol.CandidateSymbols);
            }
            else
            {
                builder.Add(s);
            }
        }

        // Gets the semantic info from a specific bound node and a set of diagnostics
        // lowestBoundNode: The lowest node in the bound tree associated with node
        // highestBoundNode: The highest node in the bound tree associated with node
        // boundNodeForSyntacticParent: The lowest node in the bound tree associated with node.Parent.
        internal LanguageTypeInfo GetTypeInfoForNode(
            ImmutableArray<BoundNode> boundNodes,
            BoundNode boundNodeForSyntacticParent)
        {
            if (boundNodes.Length > 0)
            {
                // TODO: Should parenthesized expression really not have symbols? At least for C#, I'm not sure that 
                // is right. For example, C# allows the assignment statement:
                //    (i) = 9;  
                // So I don't assume this code should special case parenthesized expressions.
                TypeSymbol type = null;
                TypeSymbol convertedType = type;
                Conversion conversion = Conversion.Identity;
                return new LanguageTypeInfo(type, convertedType, conversion);
            }

            return LanguageTypeInfo.None;
        }

        // Gets the method or property group from a specific bound node.
        // lowestBoundNode: The lowest node in the bound tree associated with node
        // highestBoundNode: The highest node in the bound tree associated with node
        // boundNodeForSyntacticParent: The lowest node in the bound tree associated with node.Parent.
        internal ImmutableArray<Symbol> GetMemberGroupForNode(
            SymbolInfoOptions options,
            BoundNode boundNode,
            BoundNode boundNodeForSyntacticParent,
            Binder binderOpt)
        {
            LookupResultKind resultKind;
            ImmutableArray<Symbol> memberGroup;
            bool isDynamic;
            GetSemanticSymbols(boundNode, boundNodeForSyntacticParent, binderOpt, options, out isDynamic, out resultKind, out memberGroup);
            return memberGroup;
        }

        // Gets symbol info for a type or namespace or alias reference. It is assumed that any error cases will come in
        // as a type whose OriginalDefinition is an error symbol from which the ResultKind can be retrieved.
        internal static SymbolInfo GetSymbolInfoForSymbol(Symbol symbol, SymbolInfoOptions options)
        {
            Debug.Assert((object)symbol != null);

            // Determine type. Dig through aliases if necessary.
            Symbol unwrapped = UnwrapAlias(symbol);
            TypeSymbol type = unwrapped as TypeSymbol;

            // Determine symbols and resultKind.
            var originalErrorSymbol = (object)type != null ? type.OriginalDefinition as ErrorTypeSymbol : null;

            if ((object)originalErrorSymbol != null)
            {
                // Error case.
                var symbols = ImmutableArray<Symbol>.Empty;

                LookupResultKind resultKind = originalErrorSymbol.ResultKind;
                if (resultKind != LookupResultKind.Empty)
                {
                    symbols = StaticCast<Symbol>.From(originalErrorSymbol.CandidateSymbols);
                }

                if ((options & SymbolInfoOptions.ResolveAliases) != 0)
                {
                    symbols = UnwrapAliases(symbols);
                }

                return SymbolInfoFactory.Create(symbols, resultKind, isDynamic: false);
            }
            else
            {
                // Non-error case. Use constructor that doesn't require creation of a Symbol array.
                var symbolToReturn = ((options & SymbolInfoOptions.ResolveAliases) != 0) ? unwrapped : symbol;
                return new SymbolInfo(symbolToReturn, ImmutableArray<ISymbol>.Empty, CandidateReason.None);
            }
        }

        // Gets TypeInfo for a type or namespace or alias reference.
        internal static LanguageTypeInfo GetTypeInfoForSymbol(Symbol symbol)
        {
            Debug.Assert((object)symbol != null);

            // Determine type. Dig through aliases if necessary.
            TypeSymbol type = UnwrapAlias(symbol) as TypeSymbol;
            return new LanguageTypeInfo(type, type, Conversion.Identity);
        }

        protected static Symbol UnwrapAlias(Symbol symbol)
        {
            return symbol is AliasSymbol aliasSym ? aliasSym.Target : symbol;
        }

        protected static ImmutableArray<Symbol> UnwrapAliases(ImmutableArray<Symbol> symbols)
        {
            bool anyAliases = false;

            foreach (Symbol symbol in symbols)
            {
                if (symbol.Kind == LanguageSymbolKind.Alias)
                    anyAliases = true;
            }

            if (!anyAliases)
                return symbols;

            ArrayBuilder<Symbol> builder = ArrayBuilder<Symbol>.GetInstance();
            foreach (Symbol symbol in symbols)
            {
                // Caas clients don't want ErrorTypeSymbol in the symbols, but the best guess
                // instead. If no best guess, then nothing is returned.
                AddUnwrappingErrorTypes(builder, UnwrapAlias(symbol));
            }

            return builder.ToImmutableAndFree();
        }

        // This is used by other binding APIs to invoke the right binder API
        internal virtual BoundNode Bind(Binder binder, LanguageSyntaxNode node, DiagnosticBag diagnostics)
        {
            /*switch (node)
            {
                case ExpressionSyntax expression:
                    var parent = expression.Parent;
                    return parent.IsKind(SyntaxKind.GotoStatement)
                        ? binder.BindLabel(expression, diagnostics)
                        : binder.BindNamespaceOrTypeOrExpression(expression, diagnostics);
                case StatementSyntax statement:
                    return binder.BindStatement(statement, diagnostics);
                case GlobalStatementSyntax globalStatement:
                    BoundStatement bound = binder.BindStatement(globalStatement.Statement, diagnostics);
                    return new BoundGlobalStatementInitializer(node, bound);
            }

            return null;*/

            throw new NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Analyze control-flow within a part of a method body. 
        /// </summary>
        /// <param name="firstStatement">The first statement to be included in the analysis.</param>
        /// <param name="lastStatement">The last statement to be included in the analysis.</param>
        /// <returns>An object that can be used to obtain the result of the control flow analysis.</returns>
        /// <exception cref="ArgumentException">The two statements are not contained within the same statement list.</exception>
        public virtual ControlFlowAnalysis AnalyzeControlFlow(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            // Only supported on a SyntaxTreeSemanticModel.
            throw new NotSupportedException();
        }

        /// <summary>
        /// Analyze control-flow within a part of a method body. 
        /// </summary>
        /// <param name="statement">The statement to be included in the analysis.</param>
        /// <returns>An object that can be used to obtain the result of the control flow analysis.</returns>
        public virtual ControlFlowAnalysis AnalyzeControlFlow(LanguageSyntaxNode statement)
        {
            return AnalyzeControlFlow(statement, statement);
        }

        /// <summary>
        /// Analyze data-flow within an expression or  within a part of a method body. 
        /// </summary>
        /// <param name="expression">The expression within the associated SyntaxTree to analyze.</param>
        /// <returns>An object that can be used to obtain the result of the data flow analysis.</returns>
        public virtual DataFlowAnalysis AnalyzeDataFlow(LanguageSyntaxNode expression)
        {
            // Only supported on a SyntaxTreeSemanticModel.
            throw new NotSupportedException();
        }

        /// <summary>
        /// Analyze data-flow within a part of a method body. 
        /// </summary>
        /// <param name="firstStatement">The first statement to be included in the analysis.</param>
        /// <param name="lastStatement">The last statement to be included in the analysis.</param>
        /// <returns>An object that can be used to obtain the result of the data flow analysis.</returns>
        /// <exception cref="ArgumentException">The two statements are not contained within the same statement list.</exception>
        public virtual DataFlowAnalysis AnalyzeDataFlow(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            // Only supported on a SyntaxTreeSemanticModel.
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get a SemanticModel object that is associated with a type syntax node that did not appear in
        /// this source code. This can be used to get detailed semantic information about sub-parts
        /// of a type syntax that did not appear in source code. 
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and accessibility. This
        /// character position must be within the FullSpan of the Root syntax node in this SemanticModel.
        /// </param>
        /// <param name="node">A syntax node that represents a parsed expression. This expression should not be
        /// present in the syntax tree associated with this object.</param>
        /// <param name="bindingOption">Indicates whether to bind the expression as a full expression,
        /// or as a type or namespace.</param>
        /// <param name="speculativeModel">A SemanticModel object that can be used to inquire about the semantic
        /// information associated with syntax nodes within <paramref name="type"/>.</param>
        /// <returns>Flag indicating whether a speculative semantic model was created.</returns>
        /// <exception cref="ArgumentException">Throws this exception if the <paramref name="type"/> node is contained any SyntaxTree in the current Compilation</exception>
        /// <exception cref="ArgumentNullException">Throws this exception if <paramref name="type"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Throws this exception if this model is a speculative semantic model, i.e. <see cref="SemanticModel.IsSpeculativeSemanticModel"/> is true.
        /// Chaining of speculative semantic model is not supported.</exception>
        public bool TryGetSpeculativeSemanticModel(int position, LanguageSyntaxNode node, out SemanticModel speculativeModel, SpeculativeBindingOption bindingOption = SpeculativeBindingOption.BindAsExpression)
        {
            CheckModelAndSyntaxNodeToSpeculate(node);
            return TryGetSpeculativeSemanticModelCore((SyntaxTreeSemanticModel)this, position, node, bindingOption, out speculativeModel);
        }

        internal abstract bool TryGetSpeculativeSemanticModelCore(SyntaxTreeSemanticModel parentModel, int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption, out SemanticModel speculativeModel);


        /// <summary>
        /// If this is a speculative semantic model, then returns its parent semantic model.
        /// Otherwise, returns null.
        /// </summary>
        public new abstract LanguageSemanticModel ParentModel
        {
            get;
        }

        /// <summary>
        /// The SyntaxTree that this object is associated with.
        /// </summary>
        public new abstract SyntaxTree SyntaxTree
        {
            get;
        }

        /// <summary>
        /// Determines what type of conversion, if any, would be used if a given expression was
        /// converted to a given type.  If isExplicitInSource is true, the conversion produced is
        /// that which would be used if the conversion were done for a cast expression.
        /// </summary>
        /// <param name="expression">An expression which much occur within the syntax tree
        /// associated with this object.</param>
        /// <param name="destination">The type to attempt conversion to.</param>
        /// <param name="isExplicitInSource">True if the conversion should be determined as for a cast expression.</param>
        /// <returns>Returns a Conversion object that summarizes whether the conversion was
        /// possible, and if so, what kind of conversion it was. If no conversion was possible, a
        /// Conversion object with a false "Exists" property is returned.</returns>
        /// <remarks>To determine the conversion between two types (instead of an expression and a
        /// type), use Compilation.ClassifyConversion.</remarks>
        public abstract Conversion ClassifyConversion(LanguageSyntaxNode expression, ITypeSymbol destination, bool isExplicitInSource = false);

        /// <summary>
        /// Determines what type of conversion, if any, would be used if a given expression was
        /// converted to a given type.  If isExplicitInSource is true, the conversion produced is
        /// that which would be used if the conversion were done for a cast expression.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration
        /// scope and accessibility.</param>
        /// <param name="expression">The expression to classify. This expression does not need to be
        /// present in the syntax tree associated with this object.</param>
        /// <param name="destination">The type to attempt conversion to.</param>
        /// <param name="isExplicitInSource">True if the conversion should be determined as for a cast expression.</param>
        /// <returns>Returns a Conversion object that summarizes whether the conversion was
        /// possible, and if so, what kind of conversion it was. If no conversion was possible, a
        /// Conversion object with a false "Exists" property is returned.</returns>
        /// <remarks>To determine the conversion between two types (instead of an expression and a
        /// type), use Compilation.ClassifyConversion.</remarks>
        public Conversion ClassifyConversion(int position, LanguageSyntaxNode expression, ITypeSymbol destination, bool isExplicitInSource = false)
        {
            if ((object)destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var cdestination = destination.EnsureLanguageSymbolOrNull<ITypeSymbol, TypeSymbol>(nameof(destination));

            if (isExplicitInSource)
            {
                return ClassifyConversionForCast(position, expression, cdestination);
            }

            // Note that it is possible for an expression to be convertible to a type
            // via both an implicit user-defined conversion and an explicit built-in conversion.
            // In that case, this method chooses the implicit conversion.

            position = CheckAndAdjustPosition(position);
            var binder = this.GetEnclosingBinder(position);
            if (binder != null)
            {
                var bnode = binder.Bind(expression) as BoundSymbol;

                if (bnode != null && !cdestination.IsErrorType())
                {
                    HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                    return binder.Conversions.ClassifyConversionFromExpression(bnode, cdestination, ref useSiteDiagnostics);
                }
            }

            return Conversion.NoConversion;
        }

        /// <summary>
        /// Determines what type of conversion, if any, would be used if a given expression was
        /// converted to a given type using an explicit cast.
        /// </summary>
        /// <param name="expression">An expression which much occur within the syntax tree
        /// associated with this object.</param>
        /// <param name="destination">The type to attempt conversion to.</param>
        /// <returns>Returns a Conversion object that summarizes whether the conversion was
        /// possible, and if so, what kind of conversion it was. If no conversion was possible, a
        /// Conversion object with a false "Exists" property is returned.</returns>
        /// <remarks>To determine the conversion between two types (instead of an expression and a
        /// type), use Compilation.ClassifyConversion.</remarks>
        internal abstract Conversion ClassifyConversionForCast(LanguageSyntaxNode expression, TypeSymbol destination);

        /// <summary>
        /// Determines what type of conversion, if any, would be used if a given expression was
        /// converted to a given type using an explicit cast.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration
        /// scope and accessibility.</param>
        /// <param name="expression">The expression to classify. This expression does not need to be
        /// present in the syntax tree associated with this object.</param>
        /// <param name="destination">The type to attempt conversion to.</param>
        /// <returns>Returns a Conversion object that summarizes whether the conversion was
        /// possible, and if so, what kind of conversion it was. If no conversion was possible, a
        /// Conversion object with a false "Exists" property is returned.</returns>
        /// <remarks>To determine the conversion between two types (instead of an expression and a
        /// type), use Compilation.ClassifyConversion.</remarks>
        internal Conversion ClassifyConversionForCast(int position, LanguageSyntaxNode expression, TypeSymbol destination)
        {
            if ((object)destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            position = CheckAndAdjustPosition(position);
            var binder = this.GetEnclosingBinder(position);
            if (binder != null)
            {
                var bnode = binder.Bind(expression) as BoundSymbol;

                if (bnode != null && !destination.IsErrorType())
                {
                    HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                    return binder.Conversions.ClassifyConversionFromExpression(bnode, destination, ref useSiteDiagnostics, forCast: true);
                }
            }

            return Conversion.NoConversion;
        }

        #region "GetDeclaredSymbol overloads for MemberDeclarationSyntax and its subtypes"

        /// <summary>
        /// Given a member declaration syntax, get the corresponding symbol.
        /// </summary>
        /// <param name="declarationSyntax">The syntax node that declares a member.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The symbol that was declared.</returns>
        /// <remarks>
        /// NOTE:   We have no GetDeclaredSymbol overloads for following subtypes of MemberDeclarationSyntax:
        /// NOTE:   (1) GlobalStatementSyntax as they don't declare any symbols.
        /// NOTE:   (2) IncompleteMemberSyntax as there are no symbols for incomplete members.
        /// NOTE:   (3) BaseFieldDeclarationSyntax or its subtypes as these declarations can contain multiple variable declarators.
        /// NOTE:       GetDeclaredSymbol should be called on the variable declarators directly.
        /// </remarks>
        public abstract IDeclaredSymbol GetDeclaredSymbol(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Given a base field declaration syntax, get the corresponding symbols.
        /// </summary>
        /// <param name="declarationSyntax">The syntax node that declares one or more fields or events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The symbols that were declared.</returns>
        public abstract ImmutableArray<IDeclaredSymbol> GetDeclaredSymbols(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken));

        // Get the symbols and possible method or property group associated with a bound node, as
        // they should be exposed through GetSemanticInfo.
        // NB: It is not safe to pass a null binderOpt during speculative binding.
        private ImmutableArray<Symbol> GetSemanticSymbols(
            BoundNode boundNode,
            BoundNode boundNodeForSyntacticParent,
            Binder binderOpt,
            SymbolInfoOptions options,
            out bool isDynamic,
            out LookupResultKind resultKind,
            out ImmutableArray<Symbol> memberGroup)
        {
            memberGroup = ImmutableArray<Symbol>.Empty;
            ImmutableArray<Symbol> symbols = ImmutableArray<Symbol>.Empty;
            resultKind = LookupResultKind.Viable;
            isDynamic = false;
            throw new NotImplementedException("TODO:MetaDslx");
            //return symbols;
        }

        #endregion

        internal BinderFlags GetSemanticModelBinderFlags()
        {
            return this.IgnoresAccessibility
                ? FlagsObject.Union<BinderFlags>(BinderFlags.SemanticModel, BinderFlags.IgnoreAccessibility)
                : BinderFlags.SemanticModel;
        }

        /// <summary>
        /// If the given node is within a preprocessing directive, gets the preprocessing symbol info for it.
        /// </summary>
        /// <param name="node">Preprocessing symbol identifier node.</param>
        public PreprocessingSymbolInfo GetPreprocessingSymbolInfo(LanguageSyntaxNode node)
        {
            CheckSyntaxNode(node);

            if (node.Ancestors().Any(n => this.Language.SyntaxFacts.IsPreprocessorDirective(n.GetKind())))
            {
                /*bool isDefined = this.SyntaxTree.IsPreprocessorSymbolDefined(node.Identifier.ValueText, node.Identifier.SpanStart);
                return new PreprocessingSymbolInfo(new PreprocessingSymbol(node.Identifier.ValueText), isDefined);*/
                throw new NotImplementedException("TODO:MetaDslx");
            }

            return PreprocessingSymbolInfo.None;
        }

        /// <summary>
        /// Options to control the internal working of GetSymbolInfoWorker. Not currently exposed
        /// to public clients, but could be if desired.
        /// </summary>
        [Flags]
        internal enum SymbolInfoOptions
        {
            /// <summary>
            /// When binding "C" new C(...), return the type C and do not return information about
            /// which constructor was bound to. Bind "new C(...)" to get information about which constructor
            /// was chosen.
            /// </summary>
            PreferTypeToConstructors = 0x1,

            /// <summary>
            /// When binding "C" new C(...), return the constructor of C that was bound to, if C unambiguously
            /// binds to a single type with at least one constructor. 
            /// </summary>
            PreferConstructorsToType = 0x2,

            /// <summary>
            /// When binding a name X that was declared with a "using X=OtherTypeOrNamespace", return OtherTypeOrNamespace.
            /// </summary>
            ResolveAliases = 0x4,

            /// <summary>
            /// When binding a name X that was declared with a "using X=OtherTypeOrNamespace", return the alias symbol X.
            /// </summary>
            PreserveAliases = 0x8,

            // Default Options.
            DefaultOptions = PreferConstructorsToType | ResolveAliases
        }

        internal static void ValidateSymbolInfoOptions(SymbolInfoOptions options)
        {
            Debug.Assert(((options & SymbolInfoOptions.PreferConstructorsToType) != 0) !=
                         ((options & SymbolInfoOptions.PreferTypeToConstructors) != 0), "Options are mutually exclusive");
            Debug.Assert(((options & SymbolInfoOptions.ResolveAliases) != 0) !=
                         ((options & SymbolInfoOptions.PreserveAliases) != 0), "Options are mutually exclusive");
        }

        /// <summary>
        /// Given a position in the SyntaxTree for this SemanticModel returns the innermost
        /// NamedType that the position is considered inside of.
        /// </summary>
        public new ISymbol GetEnclosingSymbol(
            int position,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            position = CheckAndAdjustPosition(position);
            var binder = GetEnclosingBinder(position);
            return binder == null ? null : binder.ContainingSymbol;
        }

        #region SemanticModel Members

        protected sealed override Compilation CompilationCore
        {
            get
            {
                return this.Compilation;
            }
        }

        protected sealed override SemanticModel ParentModelCore
        {
            get
            {
                return this.ParentModel;
            }
        }

        protected sealed override SyntaxTree SyntaxTreeCore
        {
            get
            {
                return this.SyntaxTree;
            }
        }

        protected sealed override SyntaxNode RootCore => this.Root;

        private SymbolInfo GetSymbolInfoFromNode(SyntaxNode node, CancellationToken cancellationToken)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            var syntaxNode = (LanguageSyntaxNode)node;
            var boundNode = this.Compilation.GetBinder(syntaxNode).Bind(syntaxNode) as BoundSymbol;
            if (boundNode != null)
            {
                return new SymbolInfo(boundNode.Symbols.Cast<Symbol, ISymbol>(), boundNode.CandidateReason);
            }
            return SymbolInfo.None;
        }

        private TypeInfo GetTypeInfoFromNode(SyntaxNode node, CancellationToken cancellationToken)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            var syntaxNode = (LanguageSyntaxNode)node;
            var boundNode = this.Compilation.GetBinder(syntaxNode).Bind(syntaxNode) as BoundSymbol;
            if (boundNode?.Symbols.FirstOrDefault() is TypeSymbol typeSymbol)
            {
                return new LanguageTypeInfo(typeSymbol, typeSymbol, Conversion.NoConversion);
            }
            return LanguageTypeInfo.None;
        }

        private ImmutableArray<IDeclaredSymbol> GetMemberGroupFromNode(SyntaxNode node, CancellationToken cancellationToken)
        {
            switch (node)
            {
                case null:
                    throw new ArgumentNullException(nameof(node));
                /* TODO:MetaDslx - implement in descendants
                case ExpressionSyntax expression:
                    return this.GetMemberGroup(expression, cancellationToken);
                case ConstructorInitializerSyntax initializer:
                    return this.GetMemberGroup(initializer, cancellationToken);
                case AttributeSyntax attribute:
                    return this.GetMemberGroup(attribute, cancellationToken);*/
            }

            return ImmutableArray<IDeclaredSymbol>.Empty;
        }

        protected sealed override ImmutableArray<IDeclaredSymbol> GetMemberGroupCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            var methodGroup = this.GetMemberGroupFromNode(node, cancellationToken);
            return StaticCast<IDeclaredSymbol>.From(methodGroup);
        }

        protected sealed override SymbolInfo GetSpeculativeSymbolInfoCore(int position, SyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            /* TODO:MetaDslx - implement in descendants
            switch (node)
            {
                case ExpressionSyntax expression:
                    return GetSpeculativeSymbolInfo(position, expression, bindingOption);
                case ConstructorInitializerSyntax initializer:
                    return GetSpeculativeSymbolInfo(position, initializer);
                case AttributeSyntax attribute:
                    return GetSpeculativeSymbolInfo(position, attribute);
                case CrefSyntax cref:
                    return GetSpeculativeSymbolInfo(position, cref);
            }*/

            return SymbolInfo.None;
        }

        protected sealed override TypeInfo GetSpeculativeTypeInfoCore(int position, SyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            return GetSpeculativeTypeInfo(position, node, bindingOption);
        }

        protected sealed override IAliasSymbol GetSpeculativeAliasInfoCore(int position, SyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            return GetSpeculativeAliasInfo(position, node, bindingOption);
        }

        protected sealed override SymbolInfo GetSymbolInfoCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            return this.GetSymbolInfoFromNode(node, cancellationToken);
        }

        protected sealed override TypeInfo GetTypeInfoCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            return this.GetTypeInfoFromNode(node, cancellationToken);
        }

        protected sealed override IAliasSymbol GetAliasInfoCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            return GetAliasInfo(node, cancellationToken);
        }

        protected sealed override PreprocessingSymbolInfo GetPreprocessingSymbolInfoCore(SyntaxNode node)
        {
            return GetPreprocessingSymbolInfo(node);
        }

        protected sealed override IDeclaredSymbol GetDeclaredSymbolCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            /* TODO:MetaDslx - implement in descendants
            switch (node)
            {
                case AccessorDeclarationSyntax accessor:
                    return this.GetDeclaredSymbol(accessor, cancellationToken);
                case BaseTypeDeclarationSyntax type:
                    return this.GetDeclaredSymbol(type, cancellationToken);
                case QueryClauseSyntax clause:
                    return this.GetDeclaredSymbol(clause, cancellationToken);
                case MemberDeclarationSyntax member:
                    return this.GetDeclaredSymbol(member, cancellationToken);
            }

            switch (node.RawKind)
            {
                case SyntaxKind.LocalFunctionStatement:
                    return this.GetDeclaredSymbol((LocalFunctionStatementSyntax)node, cancellationToken);
                case SyntaxKind.LabeledStatement:
                    return this.GetDeclaredSymbol((LabeledStatementSyntax)node, cancellationToken);
                case SyntaxKind.CaseSwitchLabel:
                case SyntaxKind.DefaultSwitchLabel:
                    return this.GetDeclaredSymbol((SwitchLabelSyntax)node, cancellationToken);
                case SyntaxKind.AnonymousObjectCreationExpression:
                    return this.GetDeclaredSymbol((AnonymousObjectCreationExpressionSyntax)node, cancellationToken);
                case SyntaxKind.AnonymousObjectMemberDeclarator:
                    return this.GetDeclaredSymbol((AnonymousObjectMemberDeclaratorSyntax)node, cancellationToken);
                case SyntaxKind.TupleExpression:
                    return this.GetDeclaredSymbol((TupleExpressionSyntax)node, cancellationToken);
                case SyntaxKind.Argument:
                    return this.GetDeclaredSymbol((ArgumentSyntax)node, cancellationToken);
                case SyntaxKind.VariableDeclarator:
                    return this.GetDeclaredSymbol((VariableDeclaratorSyntax)node, cancellationToken);
                case SyntaxKind.SingleVariableDesignation:
                    return this.GetDeclaredSymbol((SingleVariableDesignationSyntax)node, cancellationToken);
                case SyntaxKind.TupleElement:
                    return this.GetDeclaredSymbol((TupleElementSyntax)node, cancellationToken);
                case SyntaxKind.NamespaceDeclaration:
                    return this.GetDeclaredSymbol((NamespaceDeclarationSyntax)node, cancellationToken);
                case SyntaxKind.Parameter:
                    return this.GetDeclaredSymbol((ParameterSyntax)node, cancellationToken);
                case SyntaxKind.TypeParameter:
                    return this.GetDeclaredSymbol((TypeParameterSyntax)node, cancellationToken);
                case SyntaxKind.UsingDirective:
                    var usingDirective = (UsingDirectiveSyntax)node;
                    if (usingDirective.Alias == null)
                    {
                        break;
                    }

                    return this.GetDeclaredSymbol(usingDirective, cancellationToken);
                case SyntaxKind.ForEachStatement:
                    return this.GetDeclaredSymbol((ForEachStatementSyntax)node, cancellationToken);
                case SyntaxKind.CatchDeclaration:
                    return this.GetDeclaredSymbol((CatchDeclarationSyntax)node, cancellationToken);
                case SyntaxKind.JoinIntoClause:
                    return this.GetDeclaredSymbol((JoinIntoClauseSyntax)node, cancellationToken);
                case SyntaxKind.QueryContinuation:
                    return this.GetDeclaredSymbol((QueryContinuationSyntax)node, cancellationToken);
            }*/

            return null;
        }

        protected sealed override ImmutableArray<IDeclaredSymbol> GetDeclaredSymbolsCore(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            ImmutableArray<IDeclaredSymbol> result = this.GetDeclaredSymbols((LanguageSyntaxNode)declaration, cancellationToken);

            if (result.IsDefault)
            {
                var symbol = GetDeclaredSymbolCore(declaration, cancellationToken);
                if (symbol != null)
                {
                    return ImmutableArray.Create(symbol);
                }
            }

            return ImmutableArray.Create<IDeclaredSymbol>();
        }

        internal override void ComputeDeclarationsInSpan(TextSpan span, bool getSymbol, ArrayBuilder<DeclarationInfo> builder, CancellationToken cancellationToken)
        {
            LanguageDeclarationComputer.ComputeDeclarationsInSpan(this, span, getSymbol, builder, cancellationToken);
        }

        internal override void ComputeDeclarationsInNode(SyntaxNode node, bool getSymbol, ArrayBuilder<DeclarationInfo> builder, CancellationToken cancellationToken, int? levelsToCompute = null)
        {
            LanguageDeclarationComputer.ComputeDeclarationsInNode(this, node, getSymbol, builder, cancellationToken, levelsToCompute);
        }

        protected internal override SyntaxNode GetTopmostNodeForDiagnosticAnalysis(ISymbol symbol, SyntaxNode declaringSyntax)
        {
            /* TODO:MetaDslx
            switch (symbol.Kind)
            {
                case LanguageSymbolKind.Event:  // for field-like events
                case LanguageSymbolKind.Field:
                    var fieldDecl = declaringSyntax.FirstAncestorOrSelf<BaseFieldDeclarationSyntax>();
                    if (fieldDecl != null)
                    {
                        return fieldDecl;
                    }

                    break;
            }*/

            return declaringSyntax;
        }

        protected sealed override ImmutableArray<ISymbol> LookupSymbolsCore(int position, INamespaceOrTypeSymbol container, string name, bool includeReducedExtensionMethods)
        {
            return LookupSymbols(position, ToLanguageSpecific(container), name, includeReducedExtensionMethods);
        }

        protected sealed override ImmutableArray<ISymbol> LookupBaseMembersCore(int position, string name)
        {
            return LookupBaseMembers(position, name);
        }

        protected sealed override ImmutableArray<ISymbol> LookupStaticMembersCore(int position, INamespaceOrTypeSymbol container, string name)
        {
            return LookupStaticMembers(position, ToLanguageSpecific(container), name);
        }

        protected sealed override ImmutableArray<ISymbol> LookupNamespacesAndTypesCore(int position, INamespaceOrTypeSymbol container, string name)
        {
            return LookupNamespacesAndTypes(position, ToLanguageSpecific(container), name);
        }

        protected sealed override ImmutableArray<ISymbol> LookupLabelsCore(int position, string name)
        {
            return LookupLabels(position, name);
        }

        private static NamespaceOrTypeSymbol ToLanguageSpecific(INamespaceOrTypeSymbol container)
        {
            if ((object)container == null)
            {
                return null;
            }

            if (!(container is NamespaceOrTypeSymbol namespaceOrTypeSymbol))
            {
                throw new ArgumentException(CSharpResources.NotACSharpSymbol, nameof(container));
            }

            return namespaceOrTypeSymbol;
        }

        protected sealed override ControlFlowAnalysis AnalyzeControlFlowCore(SyntaxNode firstStatement, SyntaxNode lastStatement)
        {
            if (firstStatement == null)
            {
                throw new ArgumentNullException(nameof(firstStatement));
            }

            if (lastStatement == null)
            {
                throw new ArgumentNullException(nameof(lastStatement));
            }

            if (!(firstStatement is LanguageSyntaxNode firstStatementSyntax))
            {
                throw new ArgumentException("firstStatement is not a StatementSyntax.");
            }

            if (!(lastStatement is LanguageSyntaxNode lastStatementSyntax))
            {
                throw new ArgumentException("firstStatement is a StatementSyntax but lastStatement isn't.");
            }

            return this.AnalyzeControlFlow(firstStatementSyntax, lastStatementSyntax);
        }

        protected sealed override ControlFlowAnalysis AnalyzeControlFlowCore(SyntaxNode statement)
        {
            if (statement == null)
            {
                throw new ArgumentNullException(nameof(statement));
            }

            if (!(statement is LanguageSyntaxNode statementSyntax))
            {
                throw new ArgumentException("statement is not a StatementSyntax.");
            }

            return this.AnalyzeControlFlow(statementSyntax);
        }

        protected sealed override DataFlowAnalysis AnalyzeDataFlowCore(SyntaxNode firstStatement, SyntaxNode lastStatement)
        {
            if (firstStatement == null)
            {
                throw new ArgumentNullException(nameof(firstStatement));
            }

            if (lastStatement == null)
            {
                throw new ArgumentNullException(nameof(lastStatement));
            }

            if (!(firstStatement is LanguageSyntaxNode firstStatementSyntax))
            {
                throw new ArgumentException("firstStatement is not a StatementSyntax.");
            }

            if (!(lastStatement is LanguageSyntaxNode lastStatementSyntax))
            {
                throw new ArgumentException("lastStatement is not a StatementSyntax.");
            }

            return this.AnalyzeDataFlow(firstStatementSyntax, lastStatementSyntax);
        }

        protected sealed override DataFlowAnalysis AnalyzeDataFlowCore(SyntaxNode statementOrExpression)
        {
            switch (statementOrExpression)
            {
                case null:
                    throw new ArgumentNullException(nameof(statementOrExpression));
                case LanguageSyntaxNode syntax:
                    return this.AnalyzeDataFlow(syntax);
                default:
                    throw new ArgumentException("statementOrExpression is not a StatementSyntax or an ExpressionSyntax.");
            }
            /*switch (statementOrExpression)
            {
                case null:
                    throw new ArgumentNullException(nameof(statementOrExpression));
                case StatementSyntax statementSyntax:
                    return this.AnalyzeDataFlow(statementSyntax);
                case ExpressionSyntax expressionSyntax:
                    return this.AnalyzeDataFlow(expressionSyntax);
                default:
                    throw new ArgumentException("statementOrExpression is not a StatementSyntax or an ExpressionSyntax.");
            }*/
        }

        protected sealed override Optional<object> GetConstantValueCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            return GetConstantValue(node, cancellationToken);
        }

        protected sealed override ISymbol GetEnclosingSymbolCore(int position, CancellationToken cancellationToken)
        {
            return this.GetEnclosingSymbol(position, cancellationToken);
        }

        protected sealed override bool IsAccessibleCore(int position, ISymbol symbol)
        {
            return this.IsAccessible(position, symbol.EnsureLanguageSymbolOrNull<ISymbol, Symbol>(nameof(symbol)));
        }

        protected sealed override bool IsEventUsableAsFieldCore(int position, IEventSymbol symbol)
        {
            return false;
        }

        #endregion


    }
}
