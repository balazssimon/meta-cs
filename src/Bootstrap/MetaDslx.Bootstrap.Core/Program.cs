using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Compiler;
using MetaDslx.Languages.Compiler.Generator;
using MetaDslx.Languages.Compiler.Model;
using MetaDslx.Languages.Core;
using MetaDslx.Languages.Core.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.IO;

namespace MetaDslx.Bootstrap.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            CoreDescriptor.Initialize();
            CompilerDescriptor.Initialize();
            var coreAssembly = typeof(object).Assembly.Location;
            var assemblyPath = Path.GetDirectoryName(coreAssembly);
            var coreRef = MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "mscorlib.dll"));
            var formatter = new DiagnosticFormatter();

            //string text = "x => (int)5*true;";
            //string text = "x => 5*true;";
            //string text = "x => 5*7.0;";
            //string text = "3*4;";
            //string text = "3..^4;";
            //            string text = @"
            //bool x = true; 
            //if (4==5) 5; else 6;
            //switch(4)
            //{
            //    case x:
            //    case true: 
            //    default: break;
            //}
            //";
            //string text = "int x = 5; x = 10;";
            //string text = "var x = true; x = 10; y = 20; var y = 15; x &= true; x += 5; y = true ? 5 : true; var z = y++; x = y is bool w; w = 4;";
            string text = @"
enum Color { Red, Green, Blue }

struct Flag
{
    string Name = ""hello"";
    Color Color = Color.Red;
}

int Max(int a, int b) { return a > b ? a : b; }

void Print(int a) 
{
    switch(a)
    {
        case 4: return;
        case 3: 
        default: break;
    }
}

int x = 5;
int y = x+3;
var z = 3;
z = Max(x,y);
Print(z);
";
            /*var syntaxTree = CoreSyntaxTree.ParseText(text);
            var compilation = CoreCompilation.Create("CoreTest")
                .AddReferences(coreRef)
                .AddReferences(ModelReference.CreateFromModel(CoreInstance.MModel))
                .AddSyntaxTrees(syntaxTree);
            compilation.ForceComplete();
            var model = (MutableModel)compilation.Model;
            Console.WriteLine(model);
            foreach (var diag in compilation.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }*/

            var grammarCode = File.ReadAllText(@"..\..\..\Sample.mtext");
            var csyntaxTree = CompilerSyntaxTree.ParseText(grammarCode);
            var ccompilation = CompilerCompilation.Create("CompilerTest")
                .AddReferences(ModelReference.CreateFromModel(CompilerInstance.MModel))
                .AddReferences(MetadataReference.CreateFromFile(typeof(CompilerInstance).Assembly.Location))
                .AddSyntaxTrees(csyntaxTree);
            ccompilation.ForceComplete();
            var cmodel = (MutableModel)ccompilation.Model;
            Console.WriteLine(cmodel);
            foreach (var diag in ccompilation.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            var imodel = cmodel.ToImmutable();
            var a4gen = new Antlr4Generator();
            var a4info = new GrammarGenerationInfo(imodel);
            Console.WriteLine(a4gen.GenerateLexer(a4info));
        }
    }
}
