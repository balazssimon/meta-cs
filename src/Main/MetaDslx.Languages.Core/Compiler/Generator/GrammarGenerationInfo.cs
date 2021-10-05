using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Compiler.Model;
using MetaDslx.Languages.Compiler.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Languages.Compiler.Generator
{
    public class GrammarGenerationInfo
    {
        private ImmutableModel _model;
        private Grammar _grammar;
        private List<FixedToken>? _fixedTokens;

        public GrammarGenerationInfo(ImmutableModel model)
        {
            _model = model;
            _grammar = _model.Objects.OfType<Grammar>().First();
        }

        public Grammar Grammar => _grammar;

        public List<FixedToken> FixedTokens
        {
            get
            {
                if (_fixedTokens is null)
                {
                    _fixedTokens = ComputeFixedTokens();
                }
                return _fixedTokens;
            }
        }

        private List<FixedToken> ComputeFixedTokens()
        {
            var fixedTokenCounter = 1;
            var result = new List<FixedToken>();
            foreach (var lexerRule in _model.Objects.OfType<LexerRule>())
            {
                var name = lexerRule.Name;
                var value = FixedToken.ExtractValue(FixedToken.GetFixedLexerRuleValue(lexerRule));
                if (value is not null)
                {
                    var handled = false;
                    foreach (var fixedToken in result)
                    {
                        if (fixedToken.AddLexerRule(lexerRule, value))
                        {
                            handled = true;
                            break;
                        }
                    }
                    if (!handled)
                    {
                        var fixedToken = new FixedToken(name, value);
                        result.Add(fixedToken);
                        fixedToken.AddLexerRule(lexerRule, value);
                    }
                }
            }
            foreach (var fixedElement in _model.Objects.OfType<ParserRuleFixedElement>())
            {
                var name = FixedToken.ExtractName(fixedElement.Value);
                var value = FixedToken.ExtractValue(fixedElement.Value);
                if (name is null) name = $"FixedToken{fixedTokenCounter++}";
                if (value is not null)
                {
                    var handled = false;
                    foreach (var fixedToken in result)
                    {
                        if (fixedToken.AddParserFixedElement(fixedElement, value))
                        {
                            handled = true;
                            break;
                        }
                    }
                    if (!handled)
                    {
                        var fixedToken = new FixedToken(name, value);
                        result.Add(fixedToken);
                        fixedToken.AddParserFixedElement(fixedElement, value);
                    }
                }
            }
            return result;
        }

    }
}
