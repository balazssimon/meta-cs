using MetaDslx.Languages.Compiler.Model;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MetaDslx.Languages.Compiler.Generator
{
    public class FixedToken
    {
        private static readonly Dictionary<string, string> s_tokenNames = new Dictionary<string, string>();

        private string _name;
        private string _value;
        private List<ParserRuleFixedElement> _parserFixedElements;
        private List<LexerRule> _lexerRules;

        public FixedToken(string name, string value)
        {
            _name = name;
            _value = value;
            _parserFixedElements = new List<ParserRuleFixedElement>();
            _lexerRules = new List<LexerRule>();
        }

        public string Name => _name;
        public string Value => _value;
        public List<ParserRuleFixedElement> ParserRuleFixedElements => _parserFixedElements;

        public bool AddParserFixedElement(ParserRuleFixedElement element, string value)
        {
            if (value == _value)
            {
                if (!_parserFixedElements.Contains(element))
                {
                    _parserFixedElements.Add(element);
                }
                return true;
            }
            return false;
        }

        public bool AddLexerRule(LexerRule rule, string value)
        {
            if (value == _value)
            {
                if (!_lexerRules.Contains(rule))
                {
                    _lexerRules.Add(rule);
                }
                return true;
            }
            return false;
        }

        public static string? GetFixedLexerRuleValue(LexerRule rule)
        {
            if (rule is not null && !rule.IsFragment && rule.Alternatives.Count == 1 && rule.Alternatives[0].Elements.Count == 1)
            {
                var ruleElement = rule.Alternatives[0].Elements[0];
                if (!ruleElement.IsNegated && ruleElement.Multiplicity == Multiplicity.ExactlyOne && ruleElement.Element is LexerRuleFixedStringElement element)
                {
                    var value = element.Value;
                    if (value.Length >= 2 && value.StartsWith("\"") && value.EndsWith("\"")) return StringUtilities.UnescapeStringLiteralValue(value.Substring(1, value.Length - 2));
                    else return value;
                }
            }
            return null;
        }

        public static string? ExtractName(object value)
        {
            if (value is null) return null;
            var name = value.ToString();
            if (s_tokenNames.TryGetValue(name, out var result)) return result;
            if (Regex.IsMatch(name, "^[A-Z][a-zA-Z0-9_]*$")) return name;
            else if (Regex.IsMatch(name, "^[a-z][a-zA-Z0-9_]*$")) return name.ToPascalCase();
            else return null;
        }

        public static string? ExtractValue(object? value)
        {
            if (value is null) return null;
            return "\"" + StringUtilities.EscapeStringLiteralValue(value.ToString()) + "\"";
        }

        static FixedToken()
        {
            s_tokenNames.Add("=", "TAssign");
            s_tokenNames.Add("==", "TEquals");
        }
    }
}
