using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
using MetaDslx.Languages.MetaGenerator.Compilation;
using MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
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
            //TestMetaCompiler.Type("meta01.txt");
            //TestMetaCompiler.SerialEdit("meta01.txt");
            //TestMetaCompiler.RandomEdit("meta01.txt");

            //TestMGenCompiler.Type("mgen03.txt");
            TestMGenCompiler.SerialEdit("mgen03.txt");
            //TestMGenCompiler.RandomEdit("mgen03.txt");
            //TestMGenCompiler.Type("mgen04.txt");
            //TestMGenCompiler.SerialEdit("mgen04.txt");
            //TestMGenCompiler.RandomEdit("mgen04.txt");
            //TestMGenCompiler.Type("mgen05.txt");

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
