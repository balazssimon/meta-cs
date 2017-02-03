using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Languages.Soal.Binder;
using MetaDslx.Languages.Soal.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "../../SoalTest1.soal";
            string source = null;
            using (StreamReader reader = new StreamReader(fileName))
            {
                source = reader.ReadToEnd();
            }
            SoalSyntaxTree tree = SoalSyntaxTree.ParseText(source);
            MainSyntax main = (MainSyntax)tree.GetRoot();
            Console.WriteLine(main);
            foreach (var diag in tree.GetDiagnostics())
            {
                Console.WriteLine(DiagnosticFormatter.Instance.Format(diag));
            }
            Soal.Symbols.SoalDescriptor.Initialize();
            var rootDecl = SoalDeclarationTreeBuilder.ForTree(tree, string.Empty, false);
            Console.WriteLine(rootDecl);
        }
    }
}
