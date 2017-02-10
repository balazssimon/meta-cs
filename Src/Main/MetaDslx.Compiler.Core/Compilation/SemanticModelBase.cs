using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public abstract class SemanticModelBase : SemanticModel
    {
        // Is this node one that could be successfully interrogated by GetSymbolInfo/GetTypeInfo/GetMemberGroup/GetConstantValue?
        // WARN: If isSpeculative is true, then don't look at .Parent - there might not be one.
        public virtual bool CanGetSemanticInfo(SyntaxNode node, bool isSpeculative = false)
        {
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
        protected abstract SymbolInfo GetSymbolInfoWorker(SyntaxNode node, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets type information about a syntax node. This is overridden by various specializations of SemanticModel.
        /// It can assume that CheckSyntaxNode and CanGetSemanticInfo have already been called, as well as that named
        /// argument nodes have been handled.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected abstract TypeInfo GetTypeInfoWorker(SyntaxNode node, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a list of method or indexed property symbols for a syntax node. This is overridden by various specializations of SemanticModel.
        /// It can assume that CheckSyntaxNode and CanGetSemanticInfo have already been called, as well as that named
        /// argument nodes have been handled.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected abstract ImmutableArray<IMetaSymbol> GetMembersWorker(SyntaxNode node, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the constant value for a syntax node. This is overridden by various specializations of SemanticModel.
        /// It can assume that CheckSyntaxNode and CanGetSemanticInfo have already been called, as well as that named
        /// argument nodes have been handled.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected abstract Optional<object> GetConstantValueWorker(SyntaxNode node, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken));

        protected abstract IMetaSymbol GetDeclaredSymbolWorker(SyntaxNode declaration, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken));

        protected abstract ImmutableArray<IMetaSymbol> GetDeclaredSymbolsWorker(SyntaxNode declaration, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken));

        #endregion Abstract worker methods

        protected abstract Binder GetSpeculativeBinder(int position, SyntaxNode node);

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
            SyntaxToken unused;
            return CheckAndAdjustPosition(position, out unused);
        }

        protected int CheckAndAdjustPosition(int position, out SyntaxToken token)
        {
            int fullStart = this.Root.Position;
            int fullEnd = this.Root.FullSpan.End;
            bool atEOF = position == fullEnd && position == this.SyntaxTree.GetRoot().FullSpan.End;

            if ((fullStart <= position && position < fullEnd) || atEOF) // allow for EOF
            {
                token = (atEOF ? this.SyntaxTree.GetRoot() : Root).FindToken(position);

                if (position < token.SpanStart) // NB: Span, not FullSpan
                {
                    // If this is already the first token, then the result will be default(SyntaxToken)
                    token = token.GetPreviousToken();
                }

                // If the first token in the root is missing, it's possible to step backwards
                // past the start of the root.  All sorts of bad things will happen in that case,
                // so just use the start of the root span.
                // CONSIDER: this should only happen when we step past the first token found, so
                // the start of that token would be another possible return value.
                return Math.Max(token.SpanStart, fullStart);
            }
            else if (fullStart == fullEnd && position == fullEnd)
            {
                // The root is an empty span and isn't the full compilation unit. No other choice here.
                token = default(SyntaxToken);
                return fullStart;
            }

            throw new ArgumentOutOfRangeException(nameof(position), position,
                string.Format("Position is not within syntax tree with full span {0}", Root.FullSpan));
        }

        /// <summary>
        /// A convenience method that determines a position from a node.  If the node is missing,
        /// then its position will be adjusted using CheckAndAdjustPosition.
        /// </summary>
        protected int GetAdjustedNodePosition(SyntaxNode node)
        {
            Debug.Assert(IsInTree(node));

            var fullSpan = this.Root.FullSpan;
            var position = node.SpanStart;

            if (fullSpan.IsEmpty)
            {
                Debug.Assert(position == fullSpan.Start);
                // At end of zero-width full span. No need to call
                // CheckAndAdjustPosition since that will simply 
                // return the original position.
                return position;
            }
            else if (position == fullSpan.End)
            {
                Debug.Assert(node.Width == 0);
                // For zero-width node at the end of the full span,
                // check and adjust the preceding position.
                return CheckAndAdjustPosition(position - 1);
            }
            else if (node.IsMissing || node.HasErrors || node.Width == 0 || node.IsPartOfStructuredTrivia())
            {
                return CheckAndAdjustPosition(position);
            }
            else
            {
                // No need to adjust position.
                return position;
            }
        }

        [Conditional("DEBUG")]
        protected void AssertPositionAdjusted(int position)
        {
            Debug.Assert(position == CheckAndAdjustPosition(position), "Expected adjusted position");
        }

        // This method ensures that the given syntax node to speculate is non-null and doesn't belong to a SyntaxTree of any model in the chain.
        private void CheckModelAndSyntaxNodeToSpeculate(SyntaxNode syntax)
        {
            if (syntax == null)
            {
                throw new ArgumentNullException(nameof(syntax));
            }

            if (this.IsSpeculativeSemanticModel)
            {
                throw new InvalidOperationException("Chaining speculative semantic model is not supported. You should create a speculative model from the non-speculative ParentModel.");
            }

            if (this.Compilation.ContainsSyntaxTree(syntax.SyntaxTree))
            {
                throw new ArgumentException("Syntax node to be speculated cannot belong to a syntax tree from the current compilation.");
            }
        }

        /// <summary>
        /// Returns what symbol(s), if any, the given syntax node bound to in the program.
        /// </summary>
        /// <param name="attributeSyntax">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected sealed override SymbolInfo GetSymbolInfoCore(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(node);

            return CanGetSemanticInfo(node)
                ? GetSymbolInfoWorker(node, BindingOptions.Default, cancellationToken)
                : SymbolInfo.None;
        }

        protected sealed override TypeInfo GetTypeInfoCore(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(node);

            return CanGetSemanticInfo(node)
                ? GetTypeInfoWorker(node, BindingOptions.Default, cancellationToken)
                : TypeInfo.None;
        }

        /// <summary>
        /// Gets a list of member symbols for a syntax node.
        /// </summary>
        /// <param name="expression">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected sealed override ImmutableArray<IMetaSymbol> GetMembersCore(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(node);

            return CanGetSemanticInfo(node)
                ? this.GetMembersWorker(node, BindingOptions.Default, cancellationToken)
                : ImmutableArray<IMetaSymbol>.Empty;
        }

        protected sealed override Optional<object> GetConstantValueCore(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(node);

            return CanGetSemanticInfo(node)
                ? this.GetConstantValueWorker(node, BindingOptions.Default, cancellationToken)
                : default(Optional<object>);
        }

        protected sealed override SymbolInfo GetSpeculativeSymbolInfoCore(int position, SyntaxNode expression)
        {
            throw new NotImplementedException();
        }

        protected sealed override TypeInfo GetSpeculativeTypeInfoCore(int position, SyntaxNode expression)
        {
            throw new NotImplementedException();
        }

        protected sealed override IMetaSymbol GetDeclaredSymbolCore(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            return this.GetDeclaredSymbolWorker(declaration, BindingOptions.Default, cancellationToken);
        }

        protected sealed override ImmutableArray<IMetaSymbol> GetDeclaredSymbolsCore(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            ImmutableArray<IMetaSymbol> result = this.GetDeclaredSymbolsWorker(declaration, BindingOptions.Default, cancellationToken);

            if (result.IsDefault)
            {
                var symbol = this.GetDeclaredSymbolWorker(declaration, BindingOptions.Default, cancellationToken);
                if (symbol != null)
                {
                    return ImmutableArray.Create(symbol);
                }
            }

            return ImmutableArray.Create<IMetaSymbol>();
        }

        /// <summary>
        /// Given a position in the SyntaxTree for this SemanticModel returns the innermost
        /// NamedType that the position is considered inside of.
        /// </summary>
        protected sealed override IMetaSymbol GetEnclosingSymbolCore(
            int position,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            position = CheckAndAdjustPosition(position);
            var binder = GetEnclosingBinder(position);
            return binder == null ? null : binder.ContainingMember;
        }

        /// <summary>
        /// Gets the binder that encloses the position.
        /// </summary>
        protected Binder GetEnclosingBinder(int position)
        {
            Binder result = this.GetEnclosingBinderCore(position);
            Debug.Assert(result == null || result.IsSemanticModelBinder);
            return result;
        }

        protected abstract Binder GetEnclosingBinderCore(int position);

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
        protected override ImmutableArray<IMetaSymbol> LookupSymbolsCore(
            int position,
            IMetaSymbol container = null,
            string name = null)
        {
            return LookupSymbolsInternal(position, container, name, BindingOptions.Default);
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
        protected override ImmutableArray<IMetaSymbol> LookupBaseMembersCore(
            int position,
            string name = null)
        {
            return LookupSymbolsInternal(position, container: null, name: name, options: BindingOptions.Default.WithLookupUseBaseReferenceAccessibility(true));
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
        protected override ImmutableArray<IMetaSymbol> LookupStaticMembersCore(
            int position,
            IMetaSymbol container = null,
            string name = null)
        {
            return LookupSymbolsInternal(position, container, name, BindingOptions.None.WithLookupStaticMembers(true));
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
        protected override ImmutableArray<IMetaSymbol> LookupNamespacesAndTypesCore(
            int position,
            IMetaSymbol container = null,
            string name = null)
        {
            return LookupSymbolsInternal(position, container, name, BindingOptions.None.WithLookupNamespacesOrTypes(true));
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
        protected ImmutableArray<IMetaSymbol> LookupSymbolsInternal(
            int position,
            IMetaSymbol container,
            string name,
            BindingOptions options)
        {
            SyntaxToken token;
            position = CheckAndAdjustPosition(position, out token);

            var binder = GetEnclosingBinder(position);
            if (binder == null)
            {
                return ImmutableArray<IMetaSymbol>.Empty;
            }

            var results = ArrayBuilder<IMetaSymbol>.GetInstance();
            ImmutableArray<IMetaSymbol> sealedResults = ImmutableArray<IMetaSymbol>.Empty;
            try
            {
                if ((object)container == null)
                {
                    binder.AddLookupSymbolsInfo(results, options);
                }
                else
                {
                    binder.AddMemberLookupSymbolsInfo(results, container, options, binder);
                }
            }
            finally
            {
                sealedResults = results.ToImmutableAndFree();
            }

            return name == null
                ? FilterNotReferencable(sealedResults)
                : sealedResults;
        }

        private static ImmutableArray<IMetaSymbol> FilterNotReferencable(ImmutableArray<IMetaSymbol> sealedResults)
        {
            ArrayBuilder<IMetaSymbol> builder = null;
            int pos = 0;
            foreach (var result in sealedResults)
            {
                if (result.MName != null)
                {
                    if (builder != null)
                    {
                        builder.Add(result);
                    }
                }
                else if (builder == null)
                {
                    builder = ArrayBuilder<IMetaSymbol>.GetInstance();
                    builder.AddRange(sealedResults, pos);
                }
                pos++;
            }
            return builder == null
                ? sealedResults
                : builder.ToImmutableAndFree();
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
        protected override bool IsAccessibleCore(int position, IMetaSymbol symbol)
        {
            position = CheckAndAdjustPosition(position);

            if ((object)symbol == null)
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            var binder = this.GetEnclosingBinder(position);
            if (binder != null)
            {
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                return binder.IsAccessible(symbol, ref useSiteDiagnostics, null);
            }

            return false;
        }

        private void VerifySpanForGetDiagnostics(TextSpan? span)
        {
            if (span.HasValue && !this.Root.FullSpan.Contains(span.Value))
            {
                throw new ArgumentException("span");
            }
        }

        public override ImmutableArray<Diagnostic> GetSyntaxDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
                CompilationStage.Parse, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
                CompilationStage.Declare, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetSemanticDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
                CompilationStage.Compile, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
                CompilationStage.Compile, this.SyntaxTree, span, includeEarlierStages: true, cancellationToken: cancellationToken);
        }

    }
}
