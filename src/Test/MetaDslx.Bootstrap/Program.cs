using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Binding;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.IO;

namespace MetaDslx.Bootstrap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*/
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\MGenTest.mgen");
            MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Generator\CompilerGenerator.mgen");
            mg.Compile();
            //*/

            /*/
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorLexer.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorParser.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaLexer.ag4", "MetaDslx.Languages.Meta");
            a4l.Compile();
            Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaParser.ag4", "MetaDslx.Languages.Meta");
            a4p.Compile();
            //*/

            /*/
            MGenTest test = new MGenTest();
            Console.WriteLine(test.SayHello("me"));
            //*/

            //*/
            ImmutableModel model = MetaInstance.Model;
            Console.WriteLine(model);

            string text = File.ReadAllText(@"..\..\..\ImmutableMetaModel.mm");

            var tree = MetaSyntaxTree.ParseText(text);
            var declarations = MetaDeclarationTreeBuilderVisitor.ForTree((MetaSyntaxTree)tree, "Script", false);

            Console.WriteLine(declarations.Dump());

            var formatter = new DiagnosticFormatter();
            foreach (var diag in tree.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            foreach (var diag in declarations.Diagnostics)
            {
                Console.WriteLine(formatter.Format(diag));
            }
            //*/

            //*/
            var compilation = MetaCompilation.Create("MetaTest").AddSyntaxTrees(tree);
            foreach (var diag in compilation.GetParseDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            foreach (var diag in compilation.GetDeclarationDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            var compiledModel = compilation.Model;
            Console.WriteLine(compiledModel);
            foreach (var symbol in compiledModel.Symbols)
            {
                Console.WriteLine(symbol);
            }
            //*/
        }


    }
}
