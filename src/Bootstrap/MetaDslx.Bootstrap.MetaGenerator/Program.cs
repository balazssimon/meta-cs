using System;

namespace MetaDslx.Bootstrap.MetaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\MGenTest.mgen");
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Generator\CompilerGenerator.mgen");
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.Core\Languages\Meta\Generator\ImmutableMetaModelGenerator.mgen");
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Omg\Mof\Generator\MofModelToMetaModelGenerator.mgen");
            mg.Compile();
        }
    }
}
