// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// The parsed representation of a C# source document.
    /// </summary>
    public abstract partial class LanguageSyntaxTree : SyntaxTree
    {
        public Language Language => ((LanguageParseOptions)this.Options).Language;

        /// <summary>
        /// Determines if two trees are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="tree">The tree to compare against.</param>
        /// <param name="topLevel">
        /// If true then the trees are equivalent if the contained nodes and tokens declaring metadata visible symbolic information are equivalent,
        /// ignoring any differences of nodes inside method bodies or initializer expressions, otherwise all nodes and tokens must be equivalent.
        /// </param>
        public override bool IsEquivalentTo(SyntaxTree tree, bool topLevel = false)
        {
            return Language.SyntaxFactory.AreEquivalent(this, tree, topLevel);
        }

        internal LanguageSyntaxNode GetRootNode()
        {
            return (LanguageSyntaxNode)GetRoot();
        }

        internal ICompilationUnitRootSyntax GetRootSyntax()
        {
            return (ICompilationUnitRootSyntax)GetRoot();
        }

        public bool HasReferenceDirectives
        {
            get
            {
                Debug.Assert(HasCompilationUnitRoot);
                return Options.Kind == SourceCodeKind.Script && GetRootSyntax().GetReferenceDirectives().Count > 0;
            }
        }

        public bool HasReferenceOrLoadDirectives
        {
            get
            {
                Debug.Assert(HasCompilationUnitRoot);

                if (Options.Kind == SourceCodeKind.Script)
                {
                    var compilationUnitRoot = GetRootSyntax();
                    return compilationUnitRoot.GetReferenceDirectives().Count > 0 || compilationUnitRoot.GetLoadDirectives().Count > 0;
                }

                return false;
            }
        }

        #region Preprocessor Symbols
        private bool _hasDirectives;
        private DirectiveStack _directives;

        protected void SetDirectiveStack(DirectiveStack directives)
        {
            _directives = directives;
            _hasDirectives = true;
        }

        protected DirectiveStack GetDirectives()
        {
            if (!_hasDirectives)
            {
                var stack = ((InternalSyntaxNode)this.GetRoot().Green).ApplyDirectives(default(DirectiveStack));
                SetDirectiveStack(stack);
            }

            return _directives;
        }

        public bool IsAnyPreprocessorSymbolDefined(ImmutableArray<string> conditionalSymbols)
        {
            Debug.Assert(conditionalSymbols != null);

            foreach (string conditionalSymbol in conditionalSymbols)
            {
                if (IsPreprocessorSymbolDefined(conditionalSymbol))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsPreprocessorSymbolDefined(string symbolName)
        {
            return IsPreprocessorSymbolDefined(GetDirectives(), symbolName);
        }

        private bool IsPreprocessorSymbolDefined(DirectiveStack directives, string symbolName)
        {
            switch (directives.IsDefined(symbolName))
            {
                case DefineState.Defined:
                    return true;
                case DefineState.Undefined:
                    return false;
                default:
                    return ((LanguageParseOptions)this.Options).PreprocessorSymbols.Contains(symbolName);
            }
        }

        /// <summary>
        /// Stores positions where preprocessor state changes. Sorted by position.
        /// The updated state can be found in <see cref="_preprocessorStates"/> array at the same index.
        /// </summary>
        private ImmutableArray<int> _preprocessorStateChangePositions;

        /// <summary>
        /// Preprocessor states corresponding to positions in <see cref="_preprocessorStateChangePositions"/>.
        /// </summary>
        private ImmutableArray<DirectiveStack> _preprocessorStates;

        public bool IsPreprocessorSymbolDefined(string symbolName, int position)
        {
            if (_preprocessorStateChangePositions.IsDefault)
            {
                BuildPreprocessorStateChangeMap();
            }

            int searchResult = _preprocessorStateChangePositions.BinarySearch(position);
            DirectiveStack directives;

            if (searchResult < 0)
            {
                searchResult = (~searchResult) - 1;

                if (searchResult >= 0)
                {
                    directives = _preprocessorStates[searchResult];
                }
                else
                {
                    directives = DirectiveStack.Empty;
                }
            }
            else
            {
                directives = _preprocessorStates[searchResult];
            }

            return IsPreprocessorSymbolDefined(directives, symbolName);
        }

        private void BuildPreprocessorStateChangeMap()
        {
            DirectiveStack currentState = DirectiveStack.Empty;
            var positions = ArrayBuilder<int>.GetInstance();
            var states = ArrayBuilder<DirectiveStack>.GetInstance();

            foreach (IDirectiveTriviaSyntax directive in this.GetRootNode().
                GetDirectives(d =>
                            {
                                switch (((IDirectiveTriviaSyntax)d).Directive.Kind)
                                {
                                    case DirectiveKind.If:
                                    case DirectiveKind.Elif:
                                    case DirectiveKind.Else:
                                    case DirectiveKind.EndIf:
                                    case DirectiveKind.Define:
                                    case DirectiveKind.Undef:
                                        return true;
                                    default:
                                        return false;
                                }
                            }))
            {
                currentState = currentState.Add(directive.Directive);
                int position = ((SyntaxNode)directive).SpanStart;
                switch (directive.Directive.Kind)
                {
                    case DirectiveKind.If:
                        // #if directive doesn't affect the set of defined/undefined symbols
                        break;
                    case DirectiveKind.Elif:
                    case DirectiveKind.Else:
                    case DirectiveKind.EndIf:
                    case DirectiveKind.Define:
                    case DirectiveKind.Undef:
                        states.Add(currentState);
                        positions.Add(position);
                        break;
                    default:
                        throw ExceptionUtilities.UnexpectedValue(directive.Directive.Kind);
                }
            }

#if DEBUG
            int currentPos = -1;
            foreach (int pos in positions)
            {
                Debug.Assert(currentPos < pos);
                currentPos = pos;
            }
#endif

            ImmutableInterlocked.InterlockedInitialize(ref _preprocessorStates, states.ToImmutableAndFree());
            ImmutableInterlocked.InterlockedInitialize(ref _preprocessorStateChangePositions, positions.ToImmutableAndFree());
        }

        #endregion

        #region Changes

        /// <summary>
        /// Produces a pessimistic list of spans that denote the regions of text in this tree that
        /// are changed from the text of the old tree.
        /// </summary>
        /// <param name="oldTree">The old tree. Cannot be <c>null</c>.</param>
        /// <remarks>The list is pessimistic because it may claim more or larger regions than actually changed.</remarks>
        public override IList<TextSpan> GetChangedSpans(SyntaxTree oldTree)
        {
            if (oldTree == null)
            {
                throw new ArgumentNullException(nameof(oldTree));
            }

            return SyntaxDiffer.GetPossiblyDifferentTextSpans(oldTree, this);
        }

        /// <summary>
        /// Gets a list of text changes that when applied to the old tree produce this tree.
        /// </summary>
        /// <param name="oldTree">The old tree. Cannot be <c>null</c>.</param>
        /// <remarks>The list of changes may be different than the original changes that produced this tree.</remarks>
        public override IList<TextChange> GetChanges(SyntaxTree oldTree)
        {
            if (oldTree == null)
            {
                throw new ArgumentNullException(nameof(oldTree));
            }

            return SyntaxDiffer.GetTextChanges(oldTree, this);
        }

        #endregion

        #region LinePositions and Locations

        /// <summary>
        /// Gets the location in terms of path, line and column for a given span.
        /// </summary>
        /// <param name="span">Span within the tree.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// <see cref="FileLinePositionSpan"/> that contains path, line and column information.
        /// </returns>
        /// <remarks>The values are not affected by line mapping directives (<c>#line</c>).</remarks>
        public override FileLinePositionSpan GetLineSpan(TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new FileLinePositionSpan(this.FilePath, GetLinePosition(span.Start), GetLinePosition(span.End));
        }

        /// <summary>
        /// Gets the location in terms of path, line and column after applying source line mapping directives (<c>#line</c>). 
        /// </summary>
        /// <param name="span">Span within the tree.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// <para>A valid <see cref="FileLinePositionSpan"/> that contains path, line and column information.</para>
        /// <para>
        /// If the location path is mapped the resulting path is the path specified in the corresponding <c>#line</c>,
        /// otherwise it's <see cref="SyntaxTree.FilePath"/>.
        /// </para>
        /// <para>
        /// A location path is considered mapped if the first <c>#line</c> directive that precedes it and that
        /// either specifies an explicit file path or is <c>#line default</c> exists and specifies an explicit path.
        /// </para>
        /// </returns>
        public override FileLinePositionSpan GetMappedLineSpan(TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_lazyLineDirectiveMap == null)
            {
                // Create the line directive map on demand.
                Interlocked.CompareExchange(ref _lazyLineDirectiveMap, new LineDirectiveMap(this), null);
            }

            return _lazyLineDirectiveMap.TranslateSpan(this.GetText(cancellationToken), this.FilePath, span);
        }

        public override LineVisibility GetLineVisibility(int position, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_lazyLineDirectiveMap == null)
            {
                // Create the line directive map on demand.
                Interlocked.CompareExchange(ref _lazyLineDirectiveMap, new LineDirectiveMap(this), null);
            }

            return _lazyLineDirectiveMap.GetLineVisibility(this.GetText(cancellationToken), position);
        }

        /// <summary>
        /// Gets a <see cref="FileLinePositionSpan"/> for a <see cref="TextSpan"/>. FileLinePositionSpans are used
        /// primarily for diagnostics and source locations.
        /// </summary>
        /// <param name="span">The source <see cref="TextSpan" /> to convert.</param>
        /// <param name="isHiddenPosition">When the method returns, contains a boolean value indicating whether this span is considered hidden or not.</param>
        /// <returns>A resulting <see cref="FileLinePositionSpan"/>.</returns>
        internal override FileLinePositionSpan GetMappedLineSpanAndVisibility(TextSpan span, out bool isHiddenPosition)
        {
            if (_lazyLineDirectiveMap == null)
            {
                // Create the line directive map on demand.
                Interlocked.CompareExchange(ref _lazyLineDirectiveMap, new LineDirectiveMap(this), null);
            }

            return _lazyLineDirectiveMap.TranslateSpanAndVisibility(this.GetText(), this.FilePath, span, out isHiddenPosition);
        }

        /// <summary>
        /// Gets a boolean value indicating whether there are any hidden regions in the tree.
        /// </summary>
        /// <returns>True if there is at least one hidden region.</returns>
        public override bool HasHiddenRegions()
        {
            if (_lazyLineDirectiveMap == null)
            {
                // Create the line directive map on demand.
                Interlocked.CompareExchange(ref _lazyLineDirectiveMap, new LineDirectiveMap(this), null);
            }

            return _lazyLineDirectiveMap.HasAnyHiddenRegions();
        }

        /// <summary>
        /// Given the error code and the source location, get the warning state based on <c>#pragma warning</c> directives.
        /// </summary>
        /// <param name="id">Error code.</param>
        /// <param name="position">Source location.</param>
        internal PragmaWarningState GetPragmaDirectiveWarningState(string id, int position)
        {
            if (_lazyPragmaWarningStateMap == null)
            {
                // Create the warning state map on demand.
                Interlocked.CompareExchange(ref _lazyPragmaWarningStateMap, new PragmaWarningStateMap(this, false), null);
            }

            return _lazyPragmaWarningStateMap.GetWarningState(id, position);
        }

        /// <summary>
        /// Returns true if the `#nullable` directive preceding the position is
        /// `enable` or `safeonly`, false if `disable`, and null if no preceding directive,
        /// or directive preceding the position is `restore`.
        /// </summary>
        internal bool? GetNullableDirectiveState(int position)
        {
            if (_lazyNullableDirectiveMap == null)
            {
                // Create the #nullable directive map on demand.
                Interlocked.CompareExchange(ref _lazyNullableDirectiveMap, NullableDirectiveMap.Create(this, false), null);
            }

            return _lazyNullableDirectiveMap.GetDirectiveState(position);
        }

        private LineDirectiveMap _lazyLineDirectiveMap;
        private PragmaWarningStateMap _lazyPragmaWarningStateMap;
        private NullableDirectiveMap _lazyNullableDirectiveMap;

        private LinePosition GetLinePosition(int position)
        {
            return this.GetText().Lines.GetLinePosition(position);
        }

        /// <summary>
        /// Gets a <see cref="Location"/> for the specified text <paramref name="span"/>.
        /// </summary>
        public override Location GetLocation(TextSpan span)
        {
            return new SourceLocation(this, span);
        }

        #endregion

        #region Diagnostics

        /// <summary>
        /// Gets a list of all the diagnostics in the sub tree that has the specified node as its root.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(SyntaxNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            return GetDiagnostics(node.Green, node.Position);
        }

        private IEnumerable<Diagnostic> GetDiagnostics(GreenNode greenNode, int position)
        {
            if (greenNode == null)
            {
                throw new InvalidOperationException();
            }

            if (greenNode.ContainsDiagnostics)
            {
                return EnumerateDiagnostics(greenNode, position);
            }

            return SpecializedCollections.EmptyEnumerable<Diagnostic>();
        }

        private IEnumerable<Diagnostic> EnumerateDiagnostics(GreenNode node, int position)
        {
            var enumerator = new SyntaxTreeDiagnosticEnumerator(this, node, position);
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        /// <summary>
        /// Gets a list of all the diagnostics associated with the token and any related trivia.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(SyntaxToken token)
        {
            return GetDiagnostics(token.Node, token.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics associated with the trivia.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(SyntaxTrivia trivia)
        {
            return GetDiagnostics(trivia.UnderlyingNode, trivia.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics in either the sub tree that has the specified node as its root or
        /// associated with the token and its related trivia. 
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(SyntaxNodeOrToken nodeOrToken)
        {
            return GetDiagnostics(nodeOrToken.UnderlyingNode, nodeOrToken.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics in the syntax tree.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetDiagnostics(this.GetRoot(cancellationToken));
        }

        #endregion

        public ImmutableArray<SyntaxKind> LookupTokens(int position, CancellationToken cancellationToken = default)
        {
            return this.LookupTokensCore(position, cancellationToken);
        }

        protected virtual ImmutableArray<SyntaxKind> LookupTokensCore(int position, CancellationToken cancellationToken = default)
        {
            return ImmutableArray<SyntaxKind>.Empty;
        }
    }
}
