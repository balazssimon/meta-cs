using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Languages.Soal.Binding;
using MetaDslx.Languages.Soal.Symbols;
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
            /*try
            {*/
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
            Console.WriteLine("----");

            SoalCompilation comp = SoalCompilation.Create("SoalTest1").AddSyntaxTrees(tree);
            Console.WriteLine(comp.Declarations.MergedRoot);

            Console.WriteLine("----");
            foreach (var diag in comp.GetSyntaxDiagnostics())
            {
                Console.WriteLine(DiagnosticFormatter.Instance.Format(diag));
            }

            Console.WriteLine("----");
            Console.WriteLine(comp.GlobalNamespace);

            NamespaceBuilder gns = (NamespaceBuilder)comp.GlobalNamespace;
            Console.WriteLine(gns.Declarations.LazyCount);
            foreach (var childNs in gns.Declarations)
            {
                Console.WriteLine(childNs);
                Console.WriteLine(((NamespaceBuilder)childNs).Declarations.LazyCount);
                foreach (var decl in ((NamespaceBuilder)childNs).Declarations)
                {
                    Console.WriteLine("  "+decl);
                }
            }

            Console.WriteLine("----");
            var sm = comp.GetSemanticModel(tree);
            Console.WriteLine(sm);

            var root = (MainSyntax)tree.GetRoot();
            var ns = root.NamespaceDeclaration[0].QualifiedNameDef;

            var nsInfo = sm.GetSymbolInfo(ns);
            Console.WriteLine(nsInfo.Symbol);

            var _struct = root.NamespaceDeclaration[0].NamespaceBody.Declaration[0].StructDeclaration.NameDef;

            var _structInfo = sm.GetSymbolInfo(_struct);
            Console.WriteLine(_structInfo.Symbol);

            var _structBody = root.NamespaceDeclaration[0].NamespaceBody.Declaration[0].StructDeclaration.StructBody.PropertyDeclaration[0].NameDef;

            var _structBodyInfo = sm.GetSymbolInfo(_structBody);
            Console.WriteLine(_structBodyInfo.Symbol);

            //Console.WriteLine(comp.Model);

            /*}
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }*/
        }
    }
}
