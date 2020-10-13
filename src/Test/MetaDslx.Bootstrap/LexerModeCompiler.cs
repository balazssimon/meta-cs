using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
//using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
//using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax;
//using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.Bootstrap
{
    //public class LexerModeCompiler : Antlr4RoslynTestBase
    //{
    //    public override Language Language => TestLexerModeLanguage.Instance;

    //    public override Lexer CreateAntlr4Lexer(ICharStream stream)
    //    {
    //        return new TestLexerModeLexer(stream);
    //    }

    //    public override Parser CreateAntlr4Parser(ITokenStream stream)
    //    {
    //        return new TestLexerModeParser(stream);
    //    }

    //    public override ParserRuleContext Antlr4MainRule(Parser parser)
    //    {
    //        return ((TestLexerModeParser)parser).main();
    //    }

    //}
}
