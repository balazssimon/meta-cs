using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace MetaDslx.Bootstrap.IncrementalCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //MetaCompiler.RandomEdit("meta01.txt");
            MetaCompiler.SerialEdit("meta01.txt");

            //TestMetaCompiler.NoEdit("meta09.txt");
            //TestMetaCompiler.Type("meta01.txt");
            //TestIncrementalCompiler.RandomEdit("meta01.txt");

            //TestMGenCompiler.Type("mgen03.txt");
            //TestMGenCompiler.SerialEdit("mgen03.txt");
            //TestMGenCompiler.RandomEdit("mgen03.txt");
            //TestMGenCompiler.Type("mgen04.txt");
            //TestMGenCompiler.SerialEdit("mgen04.txt");
            //TestMGenCompiler.RandomEdit("mgen04.txt");
            //TestMGenCompiler.Type("mgen05.txt");
            //TestMGenCompiler.Compile("mgen06.txt");

            //CompileMeta("meta01.txt");
            //CompileMeta("meta02.txt");
            //EditAndCompileMeta("meta01.txt");
            //CompileMeta("meta03.txt");
            //EditAndCompileMeta("meta03.txt");
            //CompileMeta("meta04.txt");
            //EditAndCompileMeta("meta04.txt");
            //SingleEditMeta("meta01.txt", 194, 593);
            //CompileMeta("meta05.txt");
            //CompileMeta("meta06.txt");
            //CompileMGen("mgen01.txt");
            //CompileMGen("mgen02.txt");
            //CompileMGen("mgen03.txt");
            //CompileMGen("mgen04.txt");
            //IncrementalCompileMGen("mgen03.txt");
        }

    }
}
