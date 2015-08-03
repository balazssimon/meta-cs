using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class Antlr4TextSpan : TextSpan
    {
        public Antlr4TextSpan() 
            : base(0, 0, 0, 0)
        {
        }

        public Antlr4TextSpan(int startLine, int startPosition, int endLine, int endPosition)
            : base(startLine, startPosition, endLine, endPosition)
        {
        }

        public Antlr4TextSpan(object node)
            : this()
        {
            IToken token = node as IToken;
            if (token != null)
            {
                this.CreateFromToken(token);
            }
            else
            {
                IParseTree parseTree = node as IParseTree;
                if (parseTree != null)
                {
                    ITerminalNode terminal = parseTree as ITerminalNode;
                    if (terminal != null)
                    {
                        this.CreateFromToken(terminal.Symbol);
                    }
                    else
                    {
                        ParserRuleContext prc = parseTree as ParserRuleContext;
                        this.CreateFromRule(prc);
                    }
                }
            }
        }

        private void CreateFromToken(IToken token)
        {
            if (token == null) return;
            this.StartLine = token.Line;
            this.StartPosition = token.Column + 1;
            string text = token.Text;
            if (!text.Contains('\n'))
            {
                this.EndLine = this.StartLine;
                this.EndPosition = this.StartPosition + token.Text.Length;
            }
            else
            {
                this.EndLine = token.Line + token.Text.Count(c => c == '\n');
                int index = text.LastIndexOf('\n');
                this.EndPosition = text.Length - index;
            }
        }

        private void CreateFromRule(ParserRuleContext rule)
        {
            if (rule == null) return;
            this.StartLine = rule.Start.Line;
            this.StartPosition = rule.Start.Column + 1;
            this.EndLine = rule.Stop.Line;
            this.EndPosition = rule.Stop.Column + rule.Stop.Text.Length + 1;
        }
    }

}
