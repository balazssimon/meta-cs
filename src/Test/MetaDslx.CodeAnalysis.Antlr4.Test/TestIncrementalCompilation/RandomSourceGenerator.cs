using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class RandomSourceGenerator
    {
        private static readonly string[] s_fixedTokens = new string[]
        {
            "namespace", "using", "metamodel", "extern", "typedef", "abstract", "class", "struct", "enum", "association", "containment", "with", "new", "null", "true", "false", "void", "object", "symbol", "string", "int", "long", "float", "double", "byte", "bool", "list",
            "any", "none", "error", "set", "multi_list", "multi_set", "this", "typeof", "as", "is", "base", "const", "redefines", "subsets", "readonly", "lazy", "synthetized", "inherited", "derived", "union", "builder", "static", ";", ":", ".", ",",
            "(", ")", "[", "]", "{", "}", "<", ">", "?", "??", "&", "^", "|", "&&", "||", "++", "--", "+", "-", "~", "!", "/", "%", "<=", ">=", "==", "!=", "*=", "/=", "%=", "+=", "-=", "<<=", ">>=", "&=", "^=", "|=", "Uri", "Prefix", "@\"", "@'", "/*", "\"", "'"
        };

        private static Random s_random = new Random();

        public string NextSource(int tokenCount)
        {
            return GetRandomSource(tokenCount);
        }

        protected void AddRandomWhitespace(StringBuilder sb, int length)
        {
            for (int i = 0; i < length; i++)
            {
                var rnd = s_random.Next(10);
                if (rnd == 0) sb.Append("\t");
                else if (rnd == 1) sb.Append("\r\n");
                else sb.Append(" ");
            }
        }

        protected void AddRandomFixedToken(StringBuilder sb)
        {
            var index = s_random.Next(s_fixedTokens.Length);
            sb.Append(s_fixedTokens[index]);
        }

        protected void AddRandomIdentifier(StringBuilder sb, int nameLength)
        {
            var rnd = s_random.Next(53);
            if (rnd == 0) sb.Append("_");
            else if (rnd >= 1 && rnd <= 26)
            {
                var ch = (char)('a' + rnd - 1);
                sb.Append(ch);
            }
            else
            {
                var ch = (char)('A' + rnd - 1);
                sb.Append(ch);
            }
            rnd = s_random.Next(63);
            if (rnd == 0) sb.Append("_");
            else if (rnd >= 1 && rnd <= 26)
            {
                var ch = (char)('a' + rnd - 1);
                sb.Append(ch);
            }
            else if (rnd >= 27 && rnd <= 52)
            {
                var ch = (char)('A' + rnd - 27);
                sb.Append(ch);
            }
            else
            {
                var ch = (char)('0' + rnd - 53);
                sb.Append(ch);
            }
        }

        protected void AddRandomComment(StringBuilder sb, int commentLength)
        {
            var rnd = s_random.Next(3);
            if (rnd == 0)
            {
                sb.Append("/*");
                AddRandomIdentifier(sb, commentLength);
                sb.Append("*/");
            }
            else
            {
                sb.Append("//");
                AddRandomIdentifier(sb, commentLength);
                rnd = s_random.Next(3);
                sb.Append("\r\n");
            }
        }

        protected string GetRandomSource(int tokenCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tokenCount; i++)
            {
                var rnd = s_random.Next(10);

                if (i > 0) AddRandomWhitespace(sb, s_random.Next(5) + 1);

                if (rnd == 0) AddRandomComment(sb, s_random.Next(10) + 1);
                else if (rnd >= 1 && rnd <= 4) AddRandomIdentifier(sb, s_random.Next(10) + 1);
                else AddRandomFixedToken(sb);

                if (s_random.Next(5) == 0) AddRandomWhitespace(sb, s_random.Next(5) + 1);
            }
            return sb.ToString();
        }
    }
}
