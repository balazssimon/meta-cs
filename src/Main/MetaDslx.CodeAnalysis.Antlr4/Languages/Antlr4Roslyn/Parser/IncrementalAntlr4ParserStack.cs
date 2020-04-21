using Antlr4.Runtime.Atn;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class IncrementalAntlr4ParserStack
    {
        private ImmutableStack<ATNState> _states;

        public IncrementalAntlr4ParserStack()
        {
            _states = ImmutableStack<ATNState>.Empty;
        }

        private IncrementalAntlr4ParserStack(ImmutableStack<ATNState> states)
        {
            _states = states;
        }

        public (bool, IncrementalAntlr4ParserStack) Process(ATNState state)
        {
            switch (state)
            {
                case RuleStartState ruleStart:
                case StarBlockStartState starBlockStart:
                case BasicBlockStartState basicBlockStart:
                case PlusBlockStartState plusBlockStart:
                case TokensStartState tokensStart:
                case StarLoopEntryState starLoopEntry:
                    return (true, new IncrementalAntlr4ParserStack(_states.Push(state)));
                case BlockEndState blockEnd:
                    if (blockEnd.startState == _states.Peek()) return (true, new IncrementalAntlr4ParserStack(_states.Pop()));
                    else return (false, this);
                case LoopEndState loopEnd:
                    if (_states.Peek() is StarLoopEntryState peekStarLoopEntry && peekStarLoopEntry.loopBackState == loopEnd.loopBackState) return (true, new IncrementalAntlr4ParserStack(_states.Pop()));
                    else return (false, this);
                case RuleStopState ruleStop:
                    if (_states.Peek() is RuleStartState peekRuleStart && peekRuleStart.stopState == ruleStop) return (true, new IncrementalAntlr4ParserStack(_states.Pop()));
                    else return (false, this);
                case BasicState basic:
                case StarLoopbackState starLoopback:
                case PlusLoopbackState plusLoopback:
                    return (true, this);
                default:
                    throw new NotImplementedException("Unsupported ATN state type: "+state.GetType());
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
}
