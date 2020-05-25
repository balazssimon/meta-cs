using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
using MetaDslx.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Bootstrap
{
    public class MetaCompiler : Antlr4RoslynTestBase
    {
        public override Language Language => MetaLanguage.Instance;

        public override Lexer CreateAntlr4Lexer(ICharStream stream)
        {
            return new MetaLexer(stream);
        }

        public override Parser CreateAntlr4Parser(ITokenStream stream)
        {
            return new MetaParser(stream);
        }

        public override ParserRuleContext Antlr4MainRule(Parser parser)
        {
            return ((MetaParser)parser).main();
        }

    }
}
