using System;

namespace MetaDslx.Bootstrap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*/
            MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\MGenTest.mgen");
            mg.Compile();
            //*/
            /*/
            MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Generator\CompilerGenerator.mgen");
            mg.Compile();
            //*/
            /*/
            MGenTest test = new MGenTest();
            Console.WriteLine(test.SayHello("me"));
            //*/
            //*/
            Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorLexer.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            a4r.Compile();
            //*/
        }


    }
}
