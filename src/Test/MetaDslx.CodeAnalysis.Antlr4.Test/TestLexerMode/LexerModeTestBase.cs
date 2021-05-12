using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public class LexerModeTestBase : Antlr4RoslynTestBase
    {
        protected string TestId = string.Empty;
        public static string InputFileDirectory = @"..\..\..\InputFiles\LexerMode";

        public override Language Language => TestLexerModeLanguage.Instance;

        public override Lexer CreateAntlr4Lexer(ICharStream stream)
        {
            return new TestLexerModeLexer(stream);
        }

        public override Parser CreateAntlr4Parser(ITokenStream stream)
        {
            return new TestLexerModeParser(stream);
        }

        public override ParserRuleContext Antlr4MainRule(Parser parser)
        {
            return ((TestLexerModeParser)parser).main();
        }

        protected SourceText LoadFile(string fileName)
        {
            return SourceText.From(File.ReadAllText(Path.Combine(InputFileDirectory, fileName)));
        }

    }
}
