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
    public class Antlr4CompletionSource
    {
        private LanguageSyntaxNode _root;
        private ATN _atn;
        private SyntaxFacts _syntaxFacts;

        public Antlr4CompletionSource(LanguageSyntaxNode root, ATN atn)
        {
            Debug.Assert(Antlr4SyntaxParser.GetTreeAnnotation(root.Green) != null);
            _root = root;
            _atn = atn;
            _syntaxFacts = _root.Language.SyntaxFacts;
        }

        public ImmutableArray<SyntaxKind> GetTokenSuggestions(int position, CancellationToken cancellationToken = default)
        {
            (var node, var annot) = FindInnermostNodeWithAnnotation(position);
            if (annot == null || !(annot.State is Antlr4ParserState)) return ImmutableArray<SyntaxKind>.Empty;
            var startState = _atn.states[((Antlr4ParserState)annot.State).State];
            var tokens = node.DescendantTokens().ToList();

            var adjustedPosition = position;
            var tokenStart = string.Empty;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                var span = token.Span;
                if (span.Contains(position))
                {
                    adjustedPosition = span.Start;
                    tokenStart = token.Text.Substring(0, position - adjustedPosition);
                    break;
                }
                else if (span.End < position)
                {
                    break;
                }
            }

            var suggestions = new HashSet<int>();
            Process(startState, new CompletionTokenStream(tokens, adjustedPosition), new ParserStack(ImmutableStack<ATNState>.Empty), ImmutableHashSet<int>.Empty, suggestions, cancellationToken);
            var result = ArrayBuilder<SyntaxKind>.GetInstance();
            if (!string.IsNullOrEmpty(tokenStart))
            {
                foreach (var tokenType in suggestions)
                {
                    var kind = tokenType.FromAntlr4(_syntaxFacts.SyntaxKindType);
                    if (IsValidSuggestion(kind, tokenStart))
                    {
                        result.Add(kind);
                    }
                }
            }
            else
            {
                result.AddRange(suggestions.Select(tokenType => tokenType.FromAntlr4(_syntaxFacts.SyntaxKindType)));
            }
            return result.ToImmutableAndFree();
        }

        private bool IsValidSuggestion(SyntaxKind kind, string tokenStart)
        {
            if (!_syntaxFacts.IsFixedToken(kind)) return true;
            var fixedText = _syntaxFacts.GetText(kind);
            if (fixedText == null || fixedText.StartsWith(tokenStart)) return true;
            return false;
        }

        private (LanguageSyntaxNode, IncrementalNodeAnnotation) FindInnermostNodeWithAnnotation(int position)
        {
            var innermost = _root.ChildThatContainsPosition(position);
            var node = innermost.NodeOrParent;
            var annot = Antlr4SyntaxParser.GetNodeAnnotation(node.Green);
            while (node.Parent != null && annot == null)
            {
                node = node.Parent;
                annot = Antlr4SyntaxParser.GetNodeAnnotation(node.Green);
            }
            if (annot != null) return ((LanguageSyntaxNode)node, annot);
            else return (_root, null);
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

            foreach (var transition in state.Transitions)
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
                                if (atomTransition.label == nextToken)
                                {
                                    Process(transition.target, stream.MoveNext(), nextParserStack, ImmutableHashSet<int>.Empty, suggestions, cancellationToken);
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
                                    if (label == nextToken)
                                    {
                                        Process(setTransition.target, stream.MoveNext(), nextParserStack, ImmutableHashSet<int>.Empty, suggestions, cancellationToken);
                                    }
                                }
                            }
                            break;
                        default:
                            Debug.Assert(false, "Unsupported ATN transition type: "+transition.GetType());
                            break;
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
                if (state.epsilonOnlyTransitions) return state.Transitions.Any(t => nextStack.IsCompatibleWith(t.target));
                else return true;
            }
        }

        private struct CompletionTokenStream
        {
            private readonly IList<SyntaxToken> _tokens;
            private readonly int _index;
            private readonly int _position;

            public CompletionTokenStream(IList<SyntaxToken> tokens, int position)
            {
                _tokens = tokens;
                _index = 0;
                _position = position;
            }

            private CompletionTokenStream(IList<SyntaxToken> tokens, int index, int position)
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
