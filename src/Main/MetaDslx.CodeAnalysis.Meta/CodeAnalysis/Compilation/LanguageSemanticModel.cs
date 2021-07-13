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
        public new abstract SyntaxNodeOrToken Root { get; }

        public new Language Language => this.Compilation.Language;

        protected override Language LanguageCore => this.Language;

        public SyntaxFactory SyntaxFactory => this.Language.SyntaxFactory;

        public SyntaxFacts SyntaxFacts => this.Language.SyntaxFacts;

        public abstract BoundTree BoundTree { get; }

        public override AliasSymbol? GetAliasInfo(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Optional<object?> GetConstantValue(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Symbol> GetMemberGroup(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override DeclaredSymbol? GetDeclaredSymbol(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<DeclaredSymbol> GetDeclaredSymbols(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override AliasSymbol? GetSpeculativeAliasInfo(int position, SyntaxNodeOrToken syntax, SpeculativeBindingOption bindingOption)
        {
            throw new NotImplementedException();
        }

        public override NullableContext GetNullableContext(int position)
        {
            throw new NotImplementedException();
        }

        #region Helpers for speculative binding

        protected virtual Binder GetSpeculativeBinder(int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption)
        {
            Debug.Assert(node is not null);
            position = CheckAndAdjustPosition(position);
            Binder binder = this.GetEnclosingBinder(position);
            return binder;
        }

        /// <summary>
        /// Bind the given expression speculatively at the given position, and return back
        /// the resulting bound node. May return null in some error cases.
        /// </summary>
        /// <remarks>
        /// Keep in sync with Binder.BindCrefParameterOrReturnType.
        /// </remarks>
        private BoundNode? GetSpeculativelyBoundNode(int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption, out Binder binder)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            node = this.Language.SyntaxFactory.GetStandaloneNode(node);
            binder = this.GetSpeculativeBinder(position, node, bindingOption);
            if (binder == null) return default;
            var diagnostics = DiagnosticBag.GetInstance();
            var boundNode = binder.Bind(diagnostics, default);
            diagnostics.Free();
            return boundNode;
        }

        #endregion Helpers for speculative binding

        /// <summary>
        /// Gets the binder that encloses the position.
        /// </summary>
        protected Binder GetEnclosingBinder(int position)
        {
            Binder result = GetEnclosingBinderCore(position);
            Debug.Assert(result == null || result.IsSemanticModelBinder);
            return result;
        }

        protected abstract Binder GetEnclosingBinderCore(int position);

        /// <summary>
        /// Gets the MemberSemanticModel that contains the node.
        /// </summary>
        internal abstract MemberSemanticModel GetMemberModel(SyntaxNode node);

        protected bool IsInTree(SyntaxNode node)
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

        protected void CheckSyntaxNode(SyntaxNodeOrToken syntax)
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
        public override ImmutableArray<DeclaredSymbol> LookupSymbols(int position, DeclaredSymbol? container, string? name, bool includeReducedExtensionMethods)
        {
            var options = includeReducedExtensionMethods ? LookupOptions.IncludeExtensionMethods : LookupOptions.Default;
            return LookupSymbolsInternal(position, container, name, options, useBaseReferenceAccessibility: false);
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
        public override ImmutableArray<DeclaredSymbol> LookupBaseMembers(
            int position,
            string? name = null)
        {
            return LookupSymbolsInternal(position, container: null, name: name, options: LookupOptions.Default, useBaseReferenceAccessibility: true);
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
        public override ImmutableArray<DeclaredSymbol> LookupStaticMembers(
            int position,
            DeclaredSymbol? container = null,
            string? name = null)
        {
            return LookupSymbolsInternal(position, container, name, LookupOptions.MustNotBeInstance, useBaseReferenceAccessibility: false);
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
        public override ImmutableArray<DeclaredSymbol> LookupNamespacesAndTypes(
            int position,
            DeclaredSymbol? container = null,
            string? name = null)
        {
            return LookupSymbolsInternal(position, container, name, LookupOptions.NamespacesOrTypesOnly, useBaseReferenceAccessibility: false);
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
        public override ImmutableArray<LabelSymbol> LookupLabels(
            int position,
            string? name = null)
        {
            return LookupSymbolsInternal(position, container: null, name: name, options: LookupOptions.LabelsOnly, useBaseReferenceAccessibility: false).CastDown<DeclaredSymbol, LabelSymbol>();
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
            DeclaredSymbol? container,
            string? name,
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

            if (container is null || container.Kind == Symbols.SymbolKind.Namespace)
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
                Debug.Assert(container is null);
                TypeSymbol containingType = binder.ContainingType;
                TypeSymbol baseType = null;

                // For a script class or a submission class base should have no members.
                if (containingType is not null && containingType.Kind == Symbols.SymbolKind.NamedType && ((NamedTypeSymbol)containingType).IsScript)
                {
                    return ImmutableArray<DeclaredSymbol>.Empty;
                }

                if (containingType is null || containingType.BaseTypes.IsEmpty)
                {
                    throw new ArgumentException(
                        "Not a valid position for a call to LookupBaseMembers (must be in a type with a base type)",
                        nameof(position));
                }
                container = baseType;
            }

            var candidates = LookupCandidates.GetInstance();

            if (container is null)
            {
                binder.AddLookupCandidateSymbols(candidates, new LookupConstraints(originalBinder: binder, name: name));
            }
            else
            {
                binder.AddLookupCandidateSymbols(candidates, new LookupConstraints(originalBinder: binder, name: name, qualifierOpt: container));
            }


            if ((options & LookupOptions.IncludeExtensionMethods) != 0)
            {
                throw new NotImplementedException("TODO:MetaDslx");
            }

            ImmutableArray<DeclaredSymbol> sealedResults = candidates.Symbols.ToImmutableArray();
            candidates.Free();

            return name == null
                ? FilterNotReferencable(sealedResults)
                : sealedResults;
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
        public override bool IsAccessible(int position, Symbol symbol)
        {
            position = CheckAndAdjustPosition(position);
            var binder = this.GetEnclosingBinder(position);
            if (binder != null)
            {
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                return binder.IsAccessible(symbol, ref useSiteDiagnostics, null);
            }

            return false;
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

        protected static Symbol UnwrapAlias(Symbol symbol)
        {
            return symbol is AliasSymbol aliasSym ? aliasSym.Target : symbol;
        }

        protected static ImmutableArray<Symbol> UnwrapAliases(ImmutableArray<Symbol> symbols)
        {
            bool anyAliases = false;

            foreach (Symbol symbol in symbols)
            {
                if (symbol.Kind == Symbols.SymbolKind.Alias)
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

        internal BinderFlags GetSemanticModelBinderFlags()
        {
            return this.IgnoresAccessibility
                ? FlagsObject.Union<BinderFlags>(BinderFlags.SemanticModel, BinderFlags.IgnoreAccessibility)
                : BinderFlags.SemanticModel;
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
        public override Symbol? GetEnclosingSymbol(
            int position,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            position = CheckAndAdjustPosition(position);
            var binder = GetEnclosingBinder(position);
            return binder?.ContainingSymbol;
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

        protected sealed override SyntaxNode RootCore => this.Root.IsNode ? this.Root.AsNode() : this.Root.Parent;

        internal override void ComputeDeclarationsInSpan(TextSpan span, bool getSymbol, ArrayBuilder<DeclarationInfo> builder, CancellationToken cancellationToken)
        {
            LanguageDeclarationComputer.ComputeDeclarationsInSpan(this, span, getSymbol, builder, cancellationToken);
        }

        internal override void ComputeDeclarationsInNode(SyntaxNode node, ISymbol associatedSymbol, bool getSymbol, ArrayBuilder<DeclarationInfo> builder, CancellationToken cancellationToken, int? levelsToCompute = null)
        {
            LanguageDeclarationComputer.ComputeDeclarationsInNode(this, node, associatedSymbol as DeclaredSymbol, getSymbol, builder, cancellationToken, levelsToCompute);
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


        #endregion


    }
}
