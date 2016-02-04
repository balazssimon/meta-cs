using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class AnnotatedParserRuleContext : ParserRuleContext
    {
        public AnnotatedParserRuleContext(ParserRuleContext parent, int invokingState)
            : base(parent, invokingState)
        {

        }

    }
}
