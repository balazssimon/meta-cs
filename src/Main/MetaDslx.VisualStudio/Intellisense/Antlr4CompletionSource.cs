using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Compilation;

namespace MetaDslx.VisualStudio.Intellisense
{
    public class Antlr4CompletionSource
    {
        private readonly CompilationSnapshot _compilation;
        private readonly int _position;
        private string[] _parserRules;
        private IVocabulary _lexerVocabulary;

        public Antlr4CompletionSource(BackgroundCompilation compilation, int position)
        {
            _compilation = compilation.CompilationSnapshot;
            _position = position;
        }

        public IEnumerable<SyntaxKind> GetTokenSuggestions()
        {
            var antlr4Parser = _compilation.Parser as IAntlr4SyntaxParser;
            _lexerVocabulary = antlr4Parser.Lexer.Vocabulary;
            _parserRules = antlr4Parser.Parser.RuleNames;
            var tokens = antlr4Parser.Tokens.Where(t => t.Channel == 0 && t.Type >= 0).ToList();
            var suggestions = new HashSet<int>();
            Process(antlr4Parser.Parser.Atn.states[0], new CompletionTokenStream(tokens, _position), new ParserStack(), ImmutableHashSet<int>.Empty, ImmutableList.Create("start"), suggestions);
            return suggestions.Select(kind => kind.FromAntlr4(_compilation.Parser.Language.SyntaxFacts.SyntaxKindType));
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
                                if (nextToken != null && atomTransition.label == nextToken.Type)
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
                                    if (nextToken != null && label == nextToken.Type)
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

        private string StateName(ATNState state)
        {
            var result = state.stateNumber.ToString();
            if (state.ruleIndex >= 0)
            {
                result += $"({state.ruleIndex}:{_parserRules[state.ruleIndex]})";
            }
            return result;
        }

        private string LabelName(int label)
        {
            return $"{label}:{_lexerVocabulary.GetSymbolicName(label)}";
        }

        private string Concat(IntervalSet intervalSet)
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
