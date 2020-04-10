using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4Intellisense.Syntax.InternalSyntax;

namespace Antlr4Intellisense
{
    public class Antlr4CompletionSource
    {
        private string _code;
        private SandyLexer _lexer;
        private string[] _ruleNames;
        private IVocabulary _vocabulary;

        public Antlr4CompletionSource(string code)
        {
            _code = code;
        }

        public HashSet<int> GetTokenSuggestions()
        {
            var tokens = GetTokens();
            var suggestions = new HashSet<int>();
            Process(SandyParser._ATN.states[0], new CompletionTokenStream(tokens), new ParserStack(), ImmutableHashSet<int>.Empty, ImmutableList.Create("start"), suggestions);
            return suggestions;
        }

        private List<IToken> GetTokens()
        {
            if (_lexer == null)
            {
                _lexer = new SandyLexer(new AntlrInputStream(_code));
                _vocabulary = _lexer.Vocabulary;
                _ruleNames = _lexer.RuleNames;
            }
            var result = new List<IToken>(_lexer.GetAllTokens().Where(t => t.Channel == 0 && t.Type >= 0));
            //result.Add(new CommonToken(CompletionTokenStream.CARET_TOKEN_TYPE));
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
        /// <param name="stream"></param>
        /// <param name="parserStack"></param>
        /// <param name="alreadyPassed"></param>
        /// <param name="history"></param>
        /// <param name="suggestions"></param>
        private void Process(ATNState state, CompletionTokenStream stream, ParserStack parserStack, ImmutableHashSet<int> alreadyPassed, ImmutableList<string> history, HashSet<int> suggestions)
        {
            var atCaret = stream.AtCaret;
            var (compatible, nextParserStack) = parserStack.Process(state);
            if (!compatible) return;

            foreach (var transition in state.Transitions)
            {
                var desc = Describe(state, transition);
                if (transition.IsEpsilon)
                {
                    if (!alreadyPassed.Contains(transition.target.stateNumber))
                    {
                        Process(transition.target, stream, nextParserStack, alreadyPassed.Add(transition.target.stateNumber), history.Add(desc), suggestions);
                    }
                }
                else
                {
                    var nextToken = stream.Next;
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
                                    Process(transition.target, stream.Move(), nextParserStack, ImmutableHashSet<int>.Empty, history.Add(desc), suggestions);
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
                                        Process(setTransition.target, stream.Move(), nextParserStack, ImmutableHashSet<int>.Empty, history.Add(desc), suggestions);
                                    }
                                }
                            }
                            break;
                        default:
                            throw new NotImplementedException("Unsupported ATN transition type: "+transition.GetType());
                    }
                }
            }
        }

        private string Describe(ATNState state, Transition transition)
        {
            switch (transition)
            {
                case EpsilonTransition epsilonTransition:
                    return $"{StateName(state)} -- epsilon --> {StateName(epsilonTransition.target)}";
                case AtomTransition atomTransition:
                    return $"{StateName(state)} -- {LabelName(atomTransition.label)} --> {StateName(atomTransition.target)}";
                case SetTransition setTransition:
                    return $"{StateName(state)} -- {Concat(setTransition.Label)} --> {StateName(setTransition.target)}";
                case RuleTransition ruleTransition:
                    return $"{StateName(state)} -- {ruleTransition.ruleIndex}:{Concat(ruleTransition.Label)} --> {StateName(ruleTransition.target)}";
                default:
                    return $"{StateName(state)} -- {Concat(transition.Label)} --> {StateName(transition.target)}";
                    //throw new NotImplementedException("Unsupported ATN transition type: " + transition.GetType());
            }
        }

        private static string StateName(ATNState state)
        {
            var vocabulary = SandyLexer.DefaultVocabulary;
            var result = state.stateNumber.ToString();
            if (state.ruleIndex >= 0)
            {
                result += $"({state.ruleIndex})";
            }
            return result;
        }

        private static string LabelName(int label)
        {
            var vocabulary = SandyParser.DefaultVocabulary;
            return $"{label}({vocabulary.GetSymbolicName(label)})";
        }

        private static string Concat(IntervalSet intervalSet)
        {
            if (intervalSet == null) return string.Empty;
            var result = new StringBuilder();
            foreach (var item in intervalSet.ToIntegerList())
            {
                if (result.Length > 0) result.Append(",");
                result.Append(LabelName(item));
            }
            return result.ToString();
        }
    }
}
