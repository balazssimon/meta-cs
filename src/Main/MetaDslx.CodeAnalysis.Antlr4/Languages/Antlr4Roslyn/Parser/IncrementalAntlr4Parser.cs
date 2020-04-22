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
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class IncrementalAntlr4Parser : SyntaxParser, IParseTreeListener
    {
        private static ConditionalWeakTable<GreenNode, IncrementalAntlr4Parser> _treeParsers = new ConditionalWeakTable<GreenNode, IncrementalAntlr4Parser>();

        private readonly IncrementalAntlr4Lexer _lexer;
        private readonly Parser _antlr4Parser;
        private readonly bool _isIncremental;
        private readonly IncrementalAntlr4Parser _oldParser;
        private GreenNode _syntaxTree;
        private int _lastVisitedTokenIndex;
        private Dictionary<(int currentTokenIndex, int ruleIndex, int state, int depth), ParserRuleContext> _ruleStartMap;
#if DEBUG
        private static ConditionalWeakTable<GreenNode, object> _greenVersion = new ConditionalWeakTable<GreenNode, object>();
        private Dictionary<ParserRuleContext, (GreenNode greenNode, Interval minMaxTokens, int tokenCount, int version)> _ruleMap;
        private readonly int _version;
#else
        private Dictionary<ParserRuleContext, (GreenNode greenNode, Interval minMaxTokens, int tokenCount)> _ruleMap;
#endif

        public IncrementalAntlr4Parser(Language language, SourceText text, LanguageParseOptions options, SyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default)
            : base(language, text, options, oldTree, changes, cancellationToken)
        {

            if (oldTree != null && oldTree.Green != null) _treeParsers.TryGetValue(oldTree.Green, out _oldParser);
            _isIncremental = changes != null && changes.Any() && _oldParser != null;
#if DEBUG
            _ruleMap = new Dictionary<ParserRuleContext, (GreenNode greenNode, Interval minMaxTokens, int tokenCount, int version)>();
            _version = _isIncremental ? _oldParser._version + 1 : 1;
#else
            _ruleMap = new Dictionary<ParserRuleContext, (GreenNode greenNode, Interval minMaxTokens, int tokenCount)>();
#endif
            _lexer = new IncrementalAntlr4Lexer(language, text, changes, _oldParser?.Lexer, cancellationToken);
            _antlr4Parser = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Parser(_lexer);
            ((IncrementalParser)_antlr4Parser)._incrementalParser = this;
            _antlr4Parser.AddParseListener(this);
            _ruleStartMap = new Dictionary<(int currentTokenIndex, int ruleIndex, int state, int depth), ParserRuleContext>();
            _lastVisitedTokenIndex = -1;
        }

        public IncrementalAntlr4Lexer Lexer => _lexer;

        public Parser Antlr4Parser => _antlr4Parser;

        public int CurrentTokenIndex => _lexer.Index;

        public override DirectiveStack Directives => DirectiveStack.Empty;

        public sealed override GreenNode Parse()
        {
            if (_syntaxTree == null)
            {
                var antlr4Root = this.Antlr4ParseMainRule();
                _syntaxTree = GetOrCreateGreenNode(antlr4Root);
                _treeParsers.Add(_syntaxTree, this);
            }
            return _syntaxTree;
        }

        protected abstract GreenNode GetOrCreateGreenNode(ParserRuleContext context);

        protected abstract ParserRuleContext Antlr4ParseMainRule();

        public static bool TryGetParser(SyntaxNode syntaxTree, out IncrementalAntlr4Parser parser)
        {
            var root = syntaxTree?.Green;
            if (root == null)
            {
                parser = null;
                return false;
            }
            else
            {
                return _treeParsers.TryGetValue(root, out parser);
            }
        }

        protected bool TryGetGreenNode(ParserRuleContext context, out GreenNode greenNode)
        {
            if (context != null && _ruleMap.TryGetValue(context, out var ruleInfo) && ruleInfo.greenNode != null) 
            {
                greenNode = ruleInfo.greenNode;
                return true;
            }
            else
            {
                greenNode = null;
                return false;
            }
        }

        public void CacheGreenNode(ParserRuleContext context, GreenNode greenNode)
        {
            if (context != null)
            {
                if (_ruleMap.TryGetValue(context, out var ruleInfo))
                {
                    if (ruleInfo.greenNode == null)
                    {
                        ruleInfo.greenNode = greenNode;
                        _ruleMap[context] = ruleInfo;
                        if (!_greenVersion.TryGetValue(greenNode, out var oldVersion))
                        {
                            _greenVersion.Add(greenNode, _version);
                        }
                    }
                }
            }
        }

        protected GreenNode VisitTerminal(ITerminalNode node, SyntaxKind expectedKind)
        {
            return this.VisitTerminal(node?.Symbol, expectedKind);
        }

        protected GreenNode VisitTerminal(IToken token, SyntaxKind expectedKind)
        {
            if (token == null)
            {
                if ((object)expectedKind == null)
                {
                    return null;
                }
                else
                {
                    var missing = this.factory.MissingToken(expectedKind);
                    return missing;
                }
            }
            var startIndex = _lastVisitedTokenIndex + 1;
            var endIndex = startIndex;
            while (endIndex <= Lexer.Index)
            {
                var lexerToken = Lexer.GetAntlr4TokenAt(endIndex);
                if (object.ReferenceEquals(token, lexerToken))
                {
                    var result = Lexer.GetTokenAt(endIndex);
                    /*if (startIndex < endIndex)
                    {
                        var skippedTokens = ArrayBuilder<InternalSyntaxTrivia>.GetInstance();
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            var skippedToken = Lexer.GetTokenAt(i);
                            var trivia = this.factory.Trivia(skippedToken.Kind, skippedToken.ToFullString());
                            skippedTokens.Add(trivia);
                        }
                        result = (InternalSyntaxToken)result.WithLeadingTrivia(this.factory.List(skippedTokens.ToArrayAndFree()).Node);
                    }*/
                    _lastVisitedTokenIndex = endIndex;
                    return result;
                }
                ++endIndex;
            }
            if (expectedKind == null) return null;
            else return this.factory.MissingToken(expectedKind);
        }

#if DEBUG
        public int GetVersion(GreenNode greenNode)
        {
            if (_greenVersion.TryGetValue(greenNode, out var versionInfo))
            {
                return (int)versionInfo;
            }
            return 0;
        }

        public int GetVersion(ParserRuleContext context)
        {
            if (_ruleMap.TryGetValue(context, out var ruleInfo))
            {
                return ruleInfo.version;
            }
            return 0;
        }
#endif

        private bool IsAffected(int start, int length)
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
            if (stateIndex >= 0) return (_antlr4Parser.Atn.states[stateIndex], ruleStartIndex, secondTokenIndex);
            else return (null, -1, -1);
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
            cancellationToken.ThrowIfCancellationRequested();
            // During rule entry, we push a new min/max token state.
            Lexer.PushIncrementalRuleInfo();
        }

        void IParseTreeListener.ExitEveryRule(ParserRuleContext ctx)
        {
            // On exit, we need to merge the min max into the current context
            var incrementalRuleInfo = Lexer.PopIncrementalRuleInfo();

            GreenNode greenNode = null;
            int tokenCount = incrementalRuleInfo.startEndTokens.b - incrementalRuleInfo.startEndTokens.a + 1;
            int depth = Lexer.MinMaxCount;
#if DEBUG
            int version = _version;
#endif

            Interval minMaxTokens = incrementalRuleInfo.minMaxTokens;
            foreach (var child in ctx.children)
            {
                var childRule = child as ParserRuleContext;
                if (childRule != null)
                {
                    var childRuleInfo = _ruleMap[childRule];
                    minMaxTokens = minMaxTokens.Union(childRuleInfo.minMaxTokens);
                }
            }

            _ruleStartMap[(incrementalRuleInfo.startEndTokens.a, ctx.RuleIndex, ctx.invokingState >= 0 ? ctx.invokingState : 0, depth)] = ctx;
#if DEBUG
            _ruleMap[ctx] = (greenNode, minMaxTokens, tokenCount, version);
#else
            _ruleMap[ctx] = (greenNode, minMaxTokens, tokenCount);
#endif
        }

        #endregion

        /// <summary>
        /// Guard a rule's previous context from being reused.
        /// </summary>
        /// <returns></returns>
        internal bool TryGetIncrementalContext<TContext>(ParserRuleContext parentContext, int state, int ruleIndex, out TContext existingContext)
            where TContext : ParserRuleContext
        {
            cancellationToken.ThrowIfCancellationRequested();
            existingContext = null;
            if (state < 0) state = 0;

            // If we have no previous parse data, the rule needs to be run.
            if (!_isIncremental) return false;

            // See if we have seen this state before at this starting point.
            // If we haven't seen it, we need to rerun this rule.
            var depth = Lexer.MinMaxCount;
            var oldTokenIndex = Lexer.GetOldTokenIndex(Lexer.Index);
            if (_oldParser._ruleStartMap.TryGetValue((oldTokenIndex, ruleIndex, state, depth), out var oldCtx))
            {
                if (oldCtx is TContext typedCtx)
                {
                    existingContext = typedCtx;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            var oldRuleInfo = _oldParser._ruleMap[existingContext];

            // We have seen it, see if it was affected by the parse
            if (this.IsAffected(oldTokenIndex, oldRuleInfo.tokenCount)) return false;

            // Everything checked out, reuse the rule context

            // At first, skip the old tokens in the new lexer
            for (int i = 0; i < oldRuleInfo.tokenCount; i++)
            {
                Lexer.Lex();
            }

            // add current context to parent if we have a parent
            if (parentContext != null) parentContext.AddChild(existingContext);

            // Store the old node and all its children
            foreach (var ruleStart in _oldParser._ruleStartMap)
            {
                var ruleStartInfo = ruleStart.Key;
                var context = ruleStart.Value;
                if (ruleStartInfo.currentTokenIndex >= oldTokenIndex && ruleStartInfo.currentTokenIndex < oldTokenIndex + oldRuleInfo.tokenCount)
                {
                    var ruleInfo = _oldParser._ruleMap[ruleStart.Value];
                    var minMaxTokens = Interval.Of(Lexer.GetNewTokenIndex(ruleInfo.minMaxTokens.a), Lexer.GetNewTokenIndex(ruleInfo.minMaxTokens.b));
                    _ruleStartMap.Add((Lexer.GetNewTokenIndex(ruleStartInfo.currentTokenIndex), ruleStartInfo.ruleIndex, ruleStartInfo.state, ruleStartInfo.depth), context);
#if DEBUG
                    _ruleMap[context] = (ruleInfo.greenNode, minMaxTokens, ruleInfo.tokenCount, ruleInfo.version);
#else
                    _ruleMap[context] = (ruleInfo.greenNode, minMaxTokens, ruleInfo.tokenCount);
#endif
                }
            }

            return true;
        }

        internal void PushNewRecursionContext(ParserRuleContext previousContext, ParserRuleContext localContext, int state, int ruleIndex)
        {
            cancellationToken.ThrowIfCancellationRequested();
            // TODO:MetaDslx
            //The new recursion context reparents the relationship between the contexts,
            //so we need to merge intervals here.
            // Do we? Now we are updating every parent based on their children in ExitEveryRule
        }
    }
}
