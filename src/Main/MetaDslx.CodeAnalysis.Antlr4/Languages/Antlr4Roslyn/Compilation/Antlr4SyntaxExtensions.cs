using Antlr4.Runtime;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public static class Antlr4SyntaxExtensions
    {
        public static int ToAntlr4(this SyntaxKind kind)
        {
            if (kind == SyntaxKind.Eof) return -1;
            else return kind.GetValue() - SyntaxKind.__LastPredefinedSyntaxKindValue;
        }

        public static SyntaxKind FromAntlr4(this int token, Type syntaxKindType)
        {
            return (SyntaxKind)EnumObject.FromIntUnsafe(syntaxKindType, token + SyntaxKind.__LastPredefinedSyntaxKindValue);
        }

        public static TextSpan GetTextSpan(this IToken token)
        {
            if (token == null) return default;
            return new TextSpan(token.StartIndex, token.StopIndex - token.StartIndex + 1);
        }

        public static LinePositionSpan GetLinePositionSpan(this IToken token)
        {
            if (token == null) return default;
            int startLine = token.Line;
            int startPosition = token.Column;
            int endLine;
            int endPosition;
            string text = token.Text;
            if (!text.Contains('\n'))
            {
                endLine = startLine;
                endPosition = startPosition + token.Text.Length;
            }
            else
            {
                endLine = token.Line + token.Text.Count(c => c == '\n');
                int index = text.LastIndexOf('\n');
                endPosition = text.Length - index;
            }
            return new LinePositionSpan(new LinePosition(startLine - 1, startPosition), new LinePosition(endLine - 1, endPosition));
        }

        public static TextSpan GetTextSpan(this ParserRuleContext rule)
        {
            if (rule == null || rule.Start == null || rule.Stop == null) return default;
            return new TextSpan(rule.Start.StartIndex, rule.Stop.StopIndex - rule.Start.StartIndex + 1);
        }

        public static LinePositionSpan GetLinePositionSpan(this ParserRuleContext rule)
        {
            if (rule == null || rule.Start == null || rule.Stop == null) return default;
            int startLine = rule.Start.Line;
            int startPosition = rule.Start.Column;
            int endLine = rule.Stop.Line;
            int endPosition = rule.Stop.Column + rule.Stop.Text.Length;
            if (startLine > 0 && endLine > 0)
            {
                --startLine;
                --endLine;
            }
            return new LinePositionSpan(new LinePosition(startLine, startPosition), new LinePosition(endLine, endPosition));
        }
    }
}
