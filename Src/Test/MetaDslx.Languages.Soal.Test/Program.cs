using MetaDslx.Compiler;
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

            MetadataReference[] metadataReferences = new MetadataReference[]
            {
                MetadataReference.CreateFromModel(SoalInstance.Model)
            };

            SoalSyntaxTree syntaxTree = SoalSyntaxTree.ParseText(source);

            MainSyntax main = (MainSyntax)syntaxTree.GetRoot();
            Console.WriteLine(main);
            foreach (var diag in syntaxTree.GetDiagnostics())
            {
                Console.WriteLine(DiagnosticFormatter.Instance.Format(diag));
            }

            SoalCompilation comp = SoalCompilation.Create("SoalTest1", new[] { syntaxTree }, references: metadataReferences);

            Console.WriteLine(comp.Declarations.MergedRoot);

            /*Console.WriteLine("----");
            foreach (var diag in comp.GetSyntaxDiagnostics())
            {
                Console.WriteLine(DiagnosticFormatter.Instance.Format(diag));
            }*/

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
            var sm = comp.GetSemanticModel(syntaxTree);
            Console.WriteLine(sm);


            Console.WriteLine("----");
            Console.WriteLine(comp.Model);
            var root = (MainSyntax)syntaxTree.GetRoot();
            var ns = root.NamespaceDeclaration[0].QualifiedName;

            var nsInfo = sm.GetSymbolInfo(ns);
            Console.WriteLine(nsInfo.Symbol);

            var _struct = root.NamespaceDeclaration[0].NamespaceBody.Declaration[0].StructDeclaration.Name;

            var _structInfo = sm.GetSymbolInfo(_struct);
            Console.WriteLine(_structInfo.Symbol);

            var _entity = root.NamespaceDeclaration[0].NamespaceBody.Declaration[4].DatabaseDeclaration.DatabaseBody.EntityReference[0].Qualifier;

            var _entityInfo = sm.GetSymbolInfo(_entity);
            Console.WriteLine(_entityInfo.Symbol);

            var symbolsInMathStruct = sm.LookupSymbols(_entity.SpanStart);
            Console.WriteLine(symbolsInMathStruct);

            Console.WriteLine(comp.Model);
            
            foreach (var symbol in comp.Model.Symbols)
            {
                Console.WriteLine(symbol);
                foreach (var prop in symbol.MAllProperties)
                {
                    if (prop.Name != "Type" && prop.Name != "Source" && prop.Name != "Target") continue;
                    Console.WriteLine("  "+prop.Name+"="+symbol.MGet(prop));
                }
            }

            Console.WriteLine("----");
            foreach (var diag in comp.GetSyntaxDiagnostics())
            {
                Console.WriteLine(DiagnosticFormatter.Instance.Format(diag));
            }
            foreach (var diag in comp.GetDeclarationDiagnostics())
            {
                Console.WriteLine(DiagnosticFormatter.Instance.Format(diag));
            }
            foreach (var diag in comp.GetSemanticDiagnostics())
            {
                Console.WriteLine(DiagnosticFormatter.Instance.Format(diag));
            }

            Console.WriteLine("----");
            /*}
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }*/
        }
    }
}
