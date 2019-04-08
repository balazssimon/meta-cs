using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Syntax
{
    public class SyntaxTreeDirectives
    {
        public bool HasReferenceOrLoadDirectives
        {
            get;
        }
        /*
        internal bool HasReferenceDirectives
        {
            get
            {
                Debug.Assert(HasCompilationUnitRoot);

                return Options.Kind == SourceCodeKind.Script && GetCompilationUnitRootInterface().GetReferenceDirectives().Count > 0;
            }
        }

        internal bool HasReferenceOrLoadDirectives
        {
            get
            {
                Debug.Assert(HasCompilationUnitRoot);

                if (Options.Kind == SourceCodeKind.Script)
                {
                    var compilationUnitRoot = GetCompilationUnitRootInterface();
                    return compilationUnitRoot.GetReferenceDirectives().Count > 0 || compilationUnitRoot.GetLoadDirectives().Count > 0;
                }

                return false;
            }
        }

        #region Preprocessor Symbols
        private bool _hasDirectives;
        private InternalSyntax.DirectiveStack _directives;

        internal void SetDirectiveStack(InternalSyntax.DirectiveStack directives)
        {
            _directives = directives;
            _hasDirectives = true;
        }

        private InternalSyntax.DirectiveStack GetDirectives()
        {
            if (!_hasDirectives)
            {
                var stack = ((InternalSyntaxNode)this.GetRoot().Green).ApplyDirectives(default(InternalSyntax.DirectiveStack));
                SetDirectiveStack(stack);
            }

            return _directives;
        }

        internal bool IsAnyPreprocessorSymbolDefined(ImmutableArray<string> conditionalSymbols)
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

        internal bool IsPreprocessorSymbolDefined(string symbolName)
        {
            return IsPreprocessorSymbolDefined(GetDirectives(), symbolName);
        }

        private bool IsPreprocessorSymbolDefined(InternalSyntax.DirectiveStack directives, string symbolName)
        {
            switch (directives.IsDefined(symbolName))
            {
                case InternalSyntax.DefineState.Defined:
                    return true;
                case InternalSyntax.DefineState.Undefined:
                    return false;
                default:
                    return this.Options.PreprocessorSymbols.Contains(symbolName);
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
        private ImmutableArray<InternalSyntax.DirectiveStack> _preprocessorStates;

        internal bool IsPreprocessorSymbolDefined(string symbolName, int position)
        {
            if (_preprocessorStateChangePositions.IsDefault)
            {
                BuildPreprocessorStateChangeMap();
            }

            int searchResult = _preprocessorStateChangePositions.BinarySearch(position);
            InternalSyntax.DirectiveStack directives;

            if (searchResult < 0)
            {
                searchResult = (~searchResult) - 1;

                if (searchResult >= 0)
                {
                    directives = _preprocessorStates[searchResult];
                }
                else
                {
                    directives = InternalSyntax.DirectiveStack.Empty;
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
            InternalSyntax.DirectiveStack currentState = InternalSyntax.DirectiveStack.Empty;
            var positions = ArrayBuilder<int>.GetInstance();
            var states = ArrayBuilder<InternalSyntax.DirectiveStack>.GetInstance();

            foreach (DirectiveTriviaSyntax directive in this.GetRoot().GetDirectives(d =>
            {
                switch (d.Kind())
                {
                    case SyntaxKind.IfDirectiveTrivia:
                    case SyntaxKind.ElifDirectiveTrivia:
                    case SyntaxKind.ElseDirectiveTrivia:
                    case SyntaxKind.EndIfDirectiveTrivia:
                    case SyntaxKind.DefineDirectiveTrivia:
                    case SyntaxKind.UndefDirectiveTrivia:
                        return true;
                    default:
                        return false;
                }
            }))
            {
                currentState = directive.ApplyDirectives(currentState);

                switch (directive.Kind())
                {
                    case SyntaxKind.IfDirectiveTrivia:
                        // #if directive doesn't affect the set of defined/undefined symbols
                        break;

                    case SyntaxKind.ElifDirectiveTrivia:
                        states.Add(currentState);
                        positions.Add(((ElifDirectiveTriviaSyntax)directive).ElifKeyword.SpanStart);
                        break;

                    case SyntaxKind.ElseDirectiveTrivia:
                        states.Add(currentState);
                        positions.Add(((ElseDirectiveTriviaSyntax)directive).ElseKeyword.SpanStart);
                        break;

                    case SyntaxKind.EndIfDirectiveTrivia:
                        states.Add(currentState);
                        positions.Add(((EndIfDirectiveTriviaSyntax)directive).EndIfKeyword.SpanStart);
                        break;

                    case SyntaxKind.DefineDirectiveTrivia:
                        states.Add(currentState);
                        positions.Add(((DefineDirectiveTriviaSyntax)directive).Name.SpanStart);
                        break;

                    case SyntaxKind.UndefDirectiveTrivia:
                        states.Add(currentState);
                        positions.Add(((UndefDirectiveTriviaSyntax)directive).Name.SpanStart);
                        break;

                    default:
                        throw ExceptionUtilities.UnexpectedValue(directive.Kind());
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
                Interlocked.CompareExchange(ref _lazyLineDirectiveMap, new CSharpLineDirectiveMap(this), null);
            }

            return _lazyLineDirectiveMap.TranslateSpan(this.GetText(cancellationToken), this.FilePath, span);
        }

        public override LineVisibility GetLineVisibility(int position, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_lazyLineDirectiveMap == null)
            {
                // Create the line directive map on demand.
                Interlocked.CompareExchange(ref _lazyLineDirectiveMap, new CSharpLineDirectiveMap(this), null);
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
                Interlocked.CompareExchange(ref _lazyLineDirectiveMap, new CSharpLineDirectiveMap(this), null);
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
                Interlocked.CompareExchange(ref _lazyLineDirectiveMap, new CSharpLineDirectiveMap(this), null);
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
                Interlocked.CompareExchange(ref _lazyPragmaWarningStateMap, new CSharpPragmaWarningStateMap(this, IsGeneratedCode()), null);
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
                Interlocked.CompareExchange(ref _lazyNullableDirectiveMap, NullableDirectiveMap.Create(this, IsGeneratedCode()), null);
            }

            return _lazyNullableDirectiveMap.GetDirectiveState(position);
        }

        internal bool IsGeneratedCode()
        {
            if (_lazyIsGeneratedCode == ThreeState.Unknown)
            {
                // Create the generated code status on demand
                bool isGenerated = GeneratedCodeUtilities.IsGeneratedCode(
                           this,
                           isComment: trivia => trivia.Kind() == SyntaxKind.SingleLineCommentTrivia || trivia.Kind() == SyntaxKind.MultiLineCommentTrivia,
                           cancellationToken: default);

                _lazyIsGeneratedCode = isGenerated.ToThreeState();
            }

            return _lazyIsGeneratedCode == ThreeState.True;
        }

        private CSharpLineDirectiveMap _lazyLineDirectiveMap;
        private CSharpPragmaWarningStateMap _lazyPragmaWarningStateMap;
        private NullableDirectiveMap _lazyNullableDirectiveMap;
        private ThreeState _lazyIsGeneratedCode = ThreeState.Unknown;*/
    }
}
