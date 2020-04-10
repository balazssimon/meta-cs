using Antlr4.Runtime.Atn;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security;
using System.Text;

namespace Antlr4Intellisense
{
    public class ParserStack
    {
        private ImmutableStack<ATNState> _states;

        public ParserStack()
        {
            _states = ImmutableStack<ATNState>.Empty;
        }

        private ParserStack(ImmutableStack<ATNState> states)
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
                    if (blockEnd.startState == _states.Peek()) return (true, new ParserStack(_states.Pop()));
                    else return (false, this);
                case LoopEndState loopEnd:
                    if (_states.Peek() is StarLoopEntryState peekStarLoopEntry && peekStarLoopEntry.loopBackState == loopEnd.loopBackState) return (true, new ParserStack(_states.Pop()));
                    else return (false, this);
                case RuleStopState ruleStop:
                    if (_states.Peek() is RuleStartState peekRuleStart && peekRuleStart.stopState == ruleStop) return (true, new ParserStack(_states.Pop()));
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
