using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public struct Antlr4CompletionSource
    {
        private ParseData _parseData;
        private LanguageSyntaxNode _root;
        private ATN _atn;
        private SyntaxFacts _syntaxFacts;

        public Antlr4CompletionSource(ParseData parseData, LanguageSyntaxNode root, ATN atn)
        {
            Debug.Assert(parseData != null);
            _parseData = parseData;
            _root = root;
            _atn = atn;
            _syntaxFacts = _root.Language.SyntaxFacts;
        }

        public ImmutableArray<SyntaxKind> GetTokenSuggestions(int position, CancellationToken cancellationToken = default)
        {
            (var node, var startStateIndex, var startPosition) = FindStartState(position);
            if (startStateIndex < 0) startStateIndex = 0;
            var startState = _atn.states[startStateIndex];

            var tokens = ArrayBuilder<SyntaxToken>.GetInstance();
            bool last = false;
            foreach (var token in node.DescendantTokens())
            {
                var span = token.Span;
                if (span.End > startPosition && span.Start <= position)
                {
                    tokens.Add(token);
                }
                else if (span.Start > position)
                {
                    if (last)
                    {
                        break;
                    }
                    else
                    {
                        tokens.Add(token);
                        last = true;
                    }
                }
            }

            var suggestions = new HashSet<int>();
            Process(startState, new CompletionTokenStream(tokens, position), new ParserStack(ImmutableStack<ATNState>.Empty), ImmutableHashSet<int>.Empty, suggestions, cancellationToken);
            tokens.Free();

            var result = ArrayBuilder<SyntaxKind>.GetInstance();
            var syntaxKindType = _syntaxFacts.SyntaxKindType;
            result.AddRange(suggestions.Select(tokenType => tokenType.FromAntlr4(syntaxKindType)));
            return result.ToImmutableAndFree();
        }

        private bool IsValidSuggestion(SyntaxKind kind, string tokenStart)
        {
            if (!_syntaxFacts.IsFixedToken(kind)) return true;
            var fixedText = _syntaxFacts.GetText(kind);
            if (fixedText == null || fixedText.StartsWith(tokenStart)) return true;
            return false;
        }

        private (LanguageSyntaxNode? node, int startState, int startPosition) FindStartState(int position)
        {
            var token = _root.FindToken(position);

            SyntaxToken prevToken;
            if (token.Span.End <= position)
            {
                prevToken = token;
                token = _root.FindToken(token.FullSpan.End);
            }
            else
            {
                var prevPosition = token.FullSpan.Start - 1;
                if (prevPosition < 0) prevPosition = 0;
                prevToken = _root.FindToken(prevPosition);
            }

            SyntaxNode? node;
            IncrementalNodeData? incrementalData = null;

            node = prevToken.Parent;
            if (node != null && node.Span.End <= position)
            {
                var lastPrevNode = node;
                incrementalData = null;
                while (node != null && node.Span.End <= position)
                {
                    lastPrevNode = node;
                    node = node.Parent;
                }
                if (lastPrevNode != null && _parseData.TryGetIncrementalData(lastPrevNode.Green, out incrementalData) && incrementalData != null)
                {
                    return ((LanguageSyntaxNode)token.Parent, ((Antlr4ParserState)incrementalData.EndParserState).State, lastPrevNode.Span.End);
                }
            }

            node = token.Parent;
            var lastNode = node;
            while (node != null && node.SpanStart == token.SpanStart)
            {
                lastNode = node;
                node = node.Parent;
            }
            if (lastNode != null && _parseData.TryGetIncrementalData(lastNode.Green, out incrementalData) && incrementalData != null)
            {
                return ((LanguageSyntaxNode)token.Parent, ((Antlr4ParserState)incrementalData.StartParserState).State, lastNode.Span.End);
            }

            return (_root, 0, 0);
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
        /// <param name="stream"></param>
        /// <param name="parserStack"></param>
        /// <param name="alreadyPassed"></param>
        /// <param name="suggestions"></param>
        private void Process(ATNState state, CompletionTokenStream stream, ParserStack parserStack, ImmutableHashSet<int> alreadyPassed, HashSet<int> suggestions, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var atCaret = stream.AtCaret;
            var (compatible, nextParserStack) = parserStack.Process(state);
            if (!compatible) return;

            foreach (var transition in state.TransitionsArray)
            {
                if (transition.IsEpsilon)
                {
                    if (!alreadyPassed.Contains(transition.target.stateNumber))
                    {
                        Process(transition.target, stream, nextParserStack, alreadyPassed.Add(transition.target.stateNumber), suggestions, cancellationToken);
                    }
                }
                else
                {
                    var nextToken = stream.CurrentToken;
                    foreach (var label in transition.Label.ToIntegerList())
                    {
                        if (atCaret)
                        {
                            if (parserStack.IsCompatibleWith(transition.target))
                            {
                                suggestions.Add(label);
                            }
                        }
                        else
                        {
                            if (label == nextToken)
                            {
                                Process(transition.target, stream.MoveNext(), nextParserStack, ImmutableHashSet<int>.Empty, suggestions, cancellationToken);
                            }
                        }
                    }
                }
            }
        }

        private struct ParserStack
        {
            private ImmutableStack<ATNState> _states;

            public ParserStack(ImmutableStack<ATNState> states)
            {
                _states = states;
            }

            public (bool, ParserStack) Process(ATNState state)
            {
                switch (state)
                {
                    case RuleStartState ruleStart:
                    case StarBlockStartState starBlockStart:
                    case BasicBlockStartState basicBlockStart:
                    case PlusBlockStartState plusBlockStart:
                    case TokensStartState tokensStart:
                    case StarLoopEntryState starLoopEntry:
                        return (true, new ParserStack(_states.Push(state)));
                    case BlockEndState blockEnd:
                        if (!_states.IsEmpty && blockEnd.startState == _states.Peek()) return (true, new ParserStack(_states.Pop()));
                        else return (false, this);
                    case LoopEndState loopEnd:
                        if (!_states.IsEmpty && _states.Peek() is StarLoopEntryState peekStarLoopEntry && peekStarLoopEntry.loopBackState == loopEnd.loopBackState) return (true, new ParserStack(_states.Pop()));
                        else return (false, this);
                    case RuleStopState ruleStop:
                        if (!_states.IsEmpty && _states.Peek() is RuleStartState peekRuleStart && peekRuleStart.stopState == ruleStop) return (true, new ParserStack(_states.Pop()));
                        else return (false, this);
                    case BasicState basic:
                    case StarLoopbackState starLoopback:
                    case PlusLoopbackState plusLoopback:
                        return (true, this);
                    default:
                        throw new NotImplementedException("Unsupported ATN state type: " + state.GetType());
                }
            }

            public bool IsCompatibleWith(ATNState state)
            {
                var (compatible, nextStack) = this.Process(state);
                if (!compatible) return false;
                if (state.epsilonOnlyTransitions) return state.TransitionsArray.Any(t => nextStack.IsCompatibleWith(t.target));
                else return true;
            }
        }

        private struct CompletionTokenStream
        {
            private readonly ArrayBuilder<SyntaxToken> _tokens;
            private readonly int _index;
            private readonly int _position;

            public CompletionTokenStream(ArrayBuilder<SyntaxToken> tokens, int position)
            {
                _tokens = tokens;
                _index = 0;
                _position = position;
            }

            private CompletionTokenStream(ArrayBuilder<SyntaxToken> tokens, int index, int position)
            {
                _tokens = tokens;
                _index = index;
                _position = position;
            }

            public int CurrentToken
            {
                get
                {
                    return _index < _tokens.Count && _tokens[_index].Span.Start < _position ? _tokens[_index].GetKind().ToAntlr4() : -1;
                }
            }

            public bool AtCaret => _index >= _tokens.Count || _tokens[_index].Span.Start >= _position;

            public CompletionTokenStream MoveNext()
            {
                if (_index < _tokens.Count && _tokens[_index].Span.Start < _position) return new CompletionTokenStream(_tokens, _index + 1, _position);
                else return this;
            }
        }

    }
}
