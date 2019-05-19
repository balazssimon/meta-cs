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
            MGenTest test = new MGenTest();
            Console.WriteLine(test.SayHello("me"));
        }


    }
}
