using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class IncrementalAntlr4Parser : SyntaxParser, IParseTreeListener
    {
        private readonly IncrementalAntlr4Lexer _lexer;
        private readonly Parser _parser;
        private readonly bool _isIncremental;
        private readonly IncrementalAntlr4Parser _oldParser;
        private SyntaxNode _syntaxTree;
        private Dictionary<(int depth, int state, int ruleIndex, int currentTokenIndex), IncrementalParserRuleContext> _ruleStartMap;
#if DEBUG
        private readonly int _version;
#endif

        public IncrementalAntlr4Parser(Language language, SourceText text, LanguageParseOptions options, ImmutableArray<TextChangeRange> changes, IncrementalAntlr4Parser oldParser, CancellationToken cancellationToken = default)
            : base(text, language, options, oldParser?._syntaxTree, changes, cancellationToken)
        {
            _isIncremental = changes.Length > 0 && oldParser != null;
#if DEBUG
            _version = _isIncremental ? oldParser._version + 1 : 1;
#endif
            _oldParser = oldParser;
            _lexer = new IncrementalAntlr4Lexer(language, text, changes, oldParser?.Lexer, cancellationToken);
            _parser = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Parser(_lexer);
            ((IncrementalParser)_parser)._incrementalParser = this;
            _parser.AddParseListener(this);
            _ruleStartMap = new Dictionary<(int depth, int state, int ruleIndex, int currentTokenIndex), IncrementalParserRuleContext>();
        }

        public IncrementalAntlr4Lexer Lexer => _lexer;

        public Parser Antlr4Parser => _parser;

        public int CurrentTokenIndex => _lexer.Index;

        public override DirectiveStack Directives => DirectiveStack.Empty;

        public bool TryGetContext<TContext>(int depth, int state, int ruleIndex, int currentTokenIndex, out TContext existingContext)
            where TContext : IncrementalParserRuleContext
        {
            if (_oldParser != null)
            {
                var key = (depth, state, ruleIndex, currentTokenIndex);
                if (_oldParser._ruleStartMap.TryGetValue(key, out var ctx))
                {
                    if (ctx is TContext typedCtx)
                    {
                        existingContext = typedCtx;
                        return true;
                    }
                }
            }
            existingContext = null;
            return false;
        }

        public bool IsAffected(int start, int length)
        {
            return _lexer.AffectedOldTokenRange.Intersection(Interval.Of(start, start + length - 1)).Length > 0;
        }

        public HashSet<int> GetCompletionTokensAt(int position)
        {
            (ATNState state, int ruleStartIndex, int tokenIndex) = FindRuleStartStateAt(position);
            var result = new HashSet<int>();
            Process(state, ruleStartIndex, tokenIndex, new IncrementalAntlr4ParserStack(), ImmutableHashSet<int>.Empty, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// ATN is an internal structure used by the ANTLR parser. It represents an automata that can change state through epsilon transitions 
        /// or when a certain token is received. We will start from the initial state and process the tokens we have in front of us until we reach 
        /// the special token representing the caret. At that point we will look which transitions are available in the current state. The tokens 
        /// used by those transitions are the tokens the parser would expect and therefore they will be the tokens we will suggest to the user.
        ///
        /// Note that multiple transitions are possible from some states so we will follow all possible paths. We will collect all suggestions 
        /// using the suggestions object. At this stage we are not concern about performance issue. In practice we may want to use some form of caching.
        /// 
        /// The parserStack is needed to track the path followed by the automata. This is because certain transitions should be followed only if 
        /// the parser arrives from a certain path. For example at the end of an expression we may want to recognize a right parenthesis to complete 
        /// parsing an expression surrounded by parenthesis. However this makes sense only if we have recognized a left parenthesis before. 
        /// The parserStack tells us that.
        /// <param name="state"></param>
        /// <param name="parserStack"></param>
        /// <param name="alreadyPassed"></param>
        /// <param name="suggestions"></param>
        private void Process(ATNState state, int currentIndex, int lastIndex, IncrementalAntlr4ParserStack parserStack, ImmutableHashSet<int> alreadyPassed, HashSet<int> suggestions)
        {
            var atCaret = currentIndex == lastIndex;
            var (compatible, nextParserStack) = parserStack.Process(state);
            if (!compatible) return;

            foreach (var transition in state.Transitions)
            {
                if (transition.IsEpsilon)
                {
                    if (!alreadyPassed.Contains(transition.target.stateNumber))
                    {
                        Process(transition.target, currentIndex, lastIndex, nextParserStack, alreadyPassed.Add(transition.target.stateNumber), suggestions);
                    }
                }
                else
                {
                    var nextToken = ((ITokenStream)_lexer).Get(currentIndex);
                    switch (transition)
                    {
                        case AtomTransition atomTransition:
                            if (atCaret)
                            {
                                if (parserStack.IsCompatibleWith(atomTransition.target))
                                {
                                    suggestions.Add(atomTransition.label);
                                }
                            }
                            else
                            {
                                if (atomTransition.label == nextToken.Type)
                                {
                                    Process(transition.target, currentIndex+1, lastIndex, nextParserStack, ImmutableHashSet<int>.Empty, suggestions);
                                }
                            }
                            break;
                        case SetTransition setTransition:
                            foreach (var label in setTransition.Label.ToIntegerList())
                            {
                                if (atCaret)
                                {
                                    if (parserStack.IsCompatibleWith(setTransition.target))
                                    {
                                        suggestions.Add(label);
                                    }
                                }
                                else
                                {
                                    if (label == nextToken.Type)
                                    {
                                        Process(setTransition.target, currentIndex + 1, lastIndex, nextParserStack, ImmutableHashSet<int>.Empty, suggestions);
                                    }
                                }
                            }
                            break;
                        default:
                            throw new NotImplementedException("Unsupported ATN transition type: " + transition.GetType());
                    }
                }
            }
        }

        private (ATNState state, int ruleStartIndex, int tokenIndex) FindRuleStartStateAt(int position)
        {
            (var firstTokenIndex, var secondTokenIndex) = _lexer.GetNeighboringIndicesAtPosition(position);
            int stateIndex = -1;
            int ruleStartIndex = -1;
            int depth = -1;
            foreach (var state in _ruleStartMap.Keys)
            {
                if (state.currentTokenIndex >= 0 && firstTokenIndex >= state.currentTokenIndex && (ruleStartIndex < 0 || (state.currentTokenIndex <= ruleStartIndex && (depth < 0 || state.depth < depth))))
                {
                    ruleStartIndex = state.currentTokenIndex;
                    stateIndex = state.state;
                    depth = state.depth;
                }
            }
            if (stateIndex >= 0) return (_parser.Atn.states[stateIndex], ruleStartIndex, secondTokenIndex);
            else return (null, -1, -1);
        }

        private void StateTransition(HashSet<ATNState> states, int token, HashSet<int> alreadyPassed, HashSet<ATNState> nextStates)
        {
            foreach (var state in states)
            {
                StateTransition(state, token, alreadyPassed, nextStates);
            }
        }

        private void StateTransition(ATNState state, int token, HashSet<int> alreadyPassed, HashSet<ATNState> nextStates)
        {
            foreach (var transition in state.Transitions)
            {
                if (transition.IsEpsilon)
                {
                    if (alreadyPassed.Add(transition.target.stateNumber))
                    {
                        StateTransition(transition.target, token, alreadyPassed, nextStates);
                    }
                }
                else
                {
                    switch (transition)
                    {
                        case AtomTransition atomTransition:
                            if (atomTransition.label == token) nextStates.Add(transition.target);
                            break;
                        case SetTransition setTransition:
                            if (setTransition.Label.Contains(token)) nextStates.Add(transition.target);
                            break;
                        default:
                            throw new NotImplementedException("Unsupported ATN transition type: " + transition.GetType());
                    }
                }
            }
        }

        private void FindCandidateTokens(HashSet<ATNState> states, HashSet<int> alreadyPassed, HashSet<int> suggestions)
        {
            foreach (var state in states)
            {
                FindCandidateTokens(state, alreadyPassed, suggestions);
            }
        }
        
        private void FindCandidateTokens(ATNState state, HashSet<int> alreadyPassed, HashSet<int> suggestions)
        {
            foreach (var transition in state.Transitions)
            {
                if (transition.IsEpsilon)
                {
                    if (alreadyPassed.Add(transition.target.stateNumber))
                    {
                        FindCandidateTokens(transition.target, alreadyPassed, suggestions);
                    }
                }
                else
                {
                    switch (transition)
                    {
                        case AtomTransition atomTransition:
                            suggestions.Add(atomTransition.label);
                            break;
                        case SetTransition setTransition:
                            foreach (var label in setTransition.Label.ToIntegerList())
                            {
                                suggestions.Add(label);
                            }
                            break;
                        default:
                            throw new NotImplementedException("Unsupported ATN transition type: " + transition.GetType());
                    }
                }
            }
        }

        #region ParseTreeListener API

        void IParseTreeListener.VisitTerminal(ITerminalNode node)
        {
        }

        void IParseTreeListener.VisitErrorNode(IErrorNode node)
        {
        }

        void IParseTreeListener.EnterEveryRule(ParserRuleContext ctx)
        {
            // During rule entry, we push a new min/max token state.
            Lexer.PushIncrementalRuleInfo();
        }

        void IParseTreeListener.ExitEveryRule(ParserRuleContext ctx)
        {
            // On exit, we need to merge the min max into the current context,
            // and then merge the current context interval into our parent.
            var incrementalRuleInfo = Lexer.PopIncrementalRuleInfo();

            // First merge with the interval on the top of the stack.
            var incCtx = ctx as IncrementalParserRuleContext;
#if DEBUG
            if (incCtx.Version == 0)
            {
                incCtx.Version = _version;
            }
#endif
            incCtx.MinMaxTokenIndex = incCtx.MinMaxTokenIndex.Union(incrementalRuleInfo.minMaxTokens);
            incCtx.TokenCount = incrementalRuleInfo.startEndTokens.b - incrementalRuleInfo.startEndTokens.a + 1;

            // Popped interval is wrong because there may have been child
            // intervals already merged into this ctx.
            var interval = incCtx.MinMaxTokenIndex;

            // Now merge with our parent interval.
            if (incCtx.parent != null)
            {
                var parentIncCtx = incCtx.parent as IncrementalParserRuleContext;
                parentIncCtx.MinMaxTokenIndex = parentIncCtx.MinMaxTokenIndex.Union(interval);
            }

            var key = (ctx.Depth(), ctx.invokingState >= 0 ? ctx.invokingState : 0, ctx.RuleIndex, incrementalRuleInfo.startEndTokens.a);
            _ruleStartMap[key] = incCtx;
        }

        #endregion
    }
}
