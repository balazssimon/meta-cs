using System;

namespace MetaDslx.Bootstrap.Antlr4Roslyn
{
    class Program
    {
        static void Main(string[] args)
        {
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax\Antlr4RoslynLexer.ag4", "MetaDslx.Languages.Antlr4Roslyn");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax\Antlr4RoslynParser.ag4", "MetaDslx.Languages.Antlr4Roslyn");
            //a4r.Compile();
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorLexer.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorParser.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaLexer.ag4", "MetaDslx.Languages.Meta");
            a4l.Compile();
            Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaParser.ag4", "MetaDslx.Languages.Meta");
            a4p.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Samples\MetaDslx.Languages.Soal\Syntax\InternalSyntax\SoalLexer.ag4", "MetaDslx.Languages.Soal");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Samples\MetaDslx.Languages.Soal\Syntax\InternalSyntax\SoalParser.ag4", "MetaDslx.Languages.Soal");
            //a4p.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\WebSequenceDiagramsModel\Syntax\InternalSyntax\SequenceLexer.ag4", "WebSequenceDiagramsModel");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\WebSequenceDiagramsModel\Syntax\InternalSyntax\SequenceParser.ag4", "WebSequenceDiagramsModel");
            //a4p.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLangOne\Syntax\TestLangOneLexer.ag4", "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Syntax");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLangOne\Syntax\TestLangOneParser.ag4", "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Syntax");
            //a4p.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Languages\MetaDslx.Languages.Uml-v2.5.1\Serialization\Syntax\InternalSyntax\WebSequenceDiagramsLexer.ag4", "MetaDslx.Languages.Uml.Serialization");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLexerMode\Syntax\InternalSyntax\TestLexerModeLexer.ag4", "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLexerMode\Syntax\InternalSyntax\TestLexerModeParser.ag4", "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax");
            //a4p.Compile();
            //*/
        }
    }
}
