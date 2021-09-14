using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
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
            var coreAssembly = typeof(object).Assembly.Location;
            var assemblyPath = Path.GetDirectoryName(coreAssembly);
            var coreRef = MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "mscorlib.dll"));

            //string text = "3*4;";
            string text = "3*true;";
            var syntaxTree = CoreSyntaxTree.ParseText(text);
            var compilation = CoreCompilation.Create("CoreTest")
                .AddReferences(coreRef)
                .AddReferences(ModelReference.CreateFromModel(CoreInstance.MModel))
                .AddSyntaxTrees(syntaxTree);
            var model = (MutableModel)compilation.Model;
            Console.WriteLine(model);
            var formatter = new DiagnosticFormatter();
            foreach (var diag in compilation.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
        }
    }
}
