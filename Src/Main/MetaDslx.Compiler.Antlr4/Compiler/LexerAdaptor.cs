using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Antlr4Roslyn
{
    public abstract class LexerAdaptor : Lexer
    {
        public LexerAdaptor(ICharStream input)
            : base(input)
        {
        }

        /**
         * Track whether we are inside of a rule and whether it is lexical parser. _currentRuleType==Token.INVALID_TYPE
         * means that we are outside of a rule. At the first sign of a rule name reference and _currentRuleType==invalid, we
         * can assume that we are starting a parser rule. Similarly, seeing a token reference when not already in rule means
         * starting a token rule. The terminating ';' of a rule, flips this back to invalid type.
         *
         * This is not perfect logic but works. For example, "grammar T;" means that we start and stop a lexical rule for
         * the "T;". Dangerous but works.
         *
         * The whole point of this state information is to distinguish between [..arg actions..] and [charsets]. Char sets
         * can only occur in lexical rules and arg actions cannot occur.
         */
        private static int INVALID_TYPE = -1;

        private int _currentRuleType = INVALID_TYPE;

        public int getCurrentRuleType()
        {
            return _currentRuleType;
        }

        public void setCurrentRuleType(int ruleType)
        {
            this._currentRuleType = ruleType;
        }

        protected void handleBeginArgument()
        {
            if (inLexerRule())
            {
                PushMode(Antlr4RoslynLexer.LexerCharSet);
                More();
            }
            else
            {
                PushMode(Antlr4RoslynLexer.Argument);
            }
        }

        protected void handleEndArgument()
        {
            PopMode();
            if (this.ModeStack.Count > 0)
            {
                Type = Antlr4RoslynLexer.ARGUMENT_CONTENT;
            }
        }

        protected void handleEndAction()
        {
            PopMode();
            if (this.ModeStack.Count > 0)
            {
                Type = Antlr4RoslynLexer.ACTION_CONTENT;
            }
        }

        public override IToken Emit()
        {
            if (Type == Antlr4RoslynLexer.ID)
            {
                String firstChar = this.Text;
                if (char.IsUpper(firstChar[0]))
                {
                    Type = Antlr4RoslynLexer.TOKEN_REF;
                }
                else
                {
                    Type = Antlr4RoslynLexer.RULE_REF;
                }

                if (_currentRuleType == INVALID_TYPE)
                { // if outside of rule def
                    _currentRuleType = Type; // set to inside lexer or parser rule
                }
            }
            else if (Type == Antlr4RoslynLexer.SEMI)
            { // exit rule def
                _currentRuleType = INVALID_TYPE;
            }

            return base.Emit();
        }

        private bool inLexerRule()
        {
            return _currentRuleType == Antlr4RoslynLexer.TOKEN_REF;
        }


        private bool inParserRule()
        { 
            // not used, but added for clarity
            return _currentRuleType == Antlr4RoslynLexer.RULE_REF;
        }
    }
}
