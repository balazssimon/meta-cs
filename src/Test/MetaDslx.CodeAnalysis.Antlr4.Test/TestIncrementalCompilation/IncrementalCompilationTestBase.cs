using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.InternalSyntax;
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

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class IncrementalCompilationTestBase : Antlr4RoslynTestBase
    {
        protected string TestId = string.Empty;
        public static string InputFileDirectory = @"..\..\..\InputFiles\IncrementalCompilation";

        public override Language Language => TestIncrementalCompilationLanguage.Instance;

        public override ParserRuleContext Antlr4MainRule(Parser parser)
        {
            return ((TestIncrementalCompilationParser)parser).main();
        }

        public override Lexer CreateAntlr4Lexer(ICharStream stream)
        {
            return new TestIncrementalCompilationLexer(stream);
        }

        public override Parser CreateAntlr4Parser(ITokenStream stream)
        {
            return new TestIncrementalCompilationParser(stream);
        }

        protected SourceText LoadFile(string fileName)
        {
            return SourceText.From(File.ReadAllText(Path.Combine(InputFileDirectory, fileName)));
        }
    }
}
