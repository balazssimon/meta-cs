using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Binding;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Soal;
using MetaDslx.Languages.Soal.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MetaDslx.Bootstrap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*/
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\MGenTest.mgen");
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Generator\CompilerGenerator.mgen");
            MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.Core\Languages\Meta\Generator\ImmutableMetaModelGenerator.mgen");
            mg.Compile();
            //*/

            /*/
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax\Antlr4RoslynLexer.ag4", "MetaDslx.Languages.Antlr4Roslyn");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax\Antlr4RoslynParser.ag4", "MetaDslx.Languages.Antlr4Roslyn");
            //a4r.Compile();
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorLexer.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorParser.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaLexer.ag4", "MetaDslx.Languages.Meta");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaParser.ag4", "MetaDslx.Languages.Meta");
            //a4p.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Samples\MetaDslx.Languages.Soal\SoalLexer.ag4", "MetaDslx.Languages.Soal");
            //a4l.Compile();
            Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Samples\MetaDslx.Languages.Soal\SoalParser.ag4", "MetaDslx.Languages.Soal");
            a4p.Compile();
            //*/

            /*/
            MGenTest test = new MGenTest();
            Console.WriteLine(test.SayHello("me"));
            //*/

            /*/
            ImmutableModel coreModel = MetaInstance.Model;
            Console.WriteLine(coreModel);

            //string text = File.ReadAllText(@"..\..\..\..\..\Main\MetaDslx.Core\Languages\Meta\Symbols\ImmutableMetaModel.mm");
            //string text = File.ReadAllText(@"..\..\..\Calculator.mm");
            string text = File.ReadAllText(@"..\..\..\..\..\Samples\MetaDslx.Languages.Soal\Soal.mm");

            var tree = MetaSyntaxTree.ParseText(text);
            var declarations = MetaDeclarationTreeBuilderVisitor.ForTree((MetaSyntaxTree)tree, "Script", false);

            //Console.WriteLine(declarations.Dump());

            var formatter = new DiagnosticFormatter();
            foreach (var diag in tree.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            foreach (var diag in declarations.Diagnostics)
            {
                Console.WriteLine(formatter.Format(diag));
            }

            //MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: false, concurrentBuild: true);
            BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            BinderFlags binderFlags2 = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
            binderFlags = binderFlags.UnionWith(binderFlags2);
            MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: true, concurrentBuild: false, topLevelBinderFlags: binderFlags);
            var compilation = MetaCompilation.
                Create("MetaTest").
                AddSyntaxTrees(tree).
                AddReferences(
                    ModelReference.CreateFromModel(coreModel),
                    ModelReference.CreateFromModel(MetaAnnotations.Model)
                    ).
                WithOptions(options);

            //var modules = compilation.SourceModule.ContainingAssembly.Modules.AsImmutable();
            //var objectType = compilation.ObjectType;
            //Console.WriteLine(objectType);
            //foreach (var member in objectType.MemberNames)
            //{
            //    Console.WriteLine("  "+member);
            //}
            //int index = 0;
            //foreach (var module in modules)
            //{
            //    foreach (var assembly in module.ReferencedAssemblySymbols)
            //    {
            //        Console.WriteLine("  ReferencedAssembly: " + assembly);
            //        foreach (var member in assembly.GlobalNamespace.GetMembers())
            //        {
            //            Console.WriteLine("    {0}: {1}", member.Name, member.GetType());
            //        }
            //    }
            //    Console.WriteLine("Module[{0}]: {1}", index, module.GetType());
            //    foreach (var member in module.GlobalNamespace.GetMembers())
            //    {
            //        Console.WriteLine("  {0}: {1}", member.Name, member.GetType());
            //    }
            //    ++index;
            //}

            var compiledModel = compilation.Model;
            Console.WriteLine(compiledModel);
            using (StreamWriter writer = new StreamWriter("Model.txt"))
            {
                foreach (var symbol in compiledModel.Symbols)
                {
                    writer.WriteLine(symbol);
                    foreach (var prop in symbol.MProperties)
                    {
                        object value = symbol.MGet(prop);
                        if (value is IEnumerable<object> collection)
                        {
                            writer.WriteLine("  {0} = ({1})", prop.Name, collection.Count());
                            foreach (var item in collection)
                            {
                                writer.WriteLine("    {0}", item);
                            }
                        }
                        else
                        {
                            writer.WriteLine("  {0} = {1}", prop.Name, value);
                        }
                    }
                }
            }

            foreach (var diag in compilation.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }

            var boundTree = compilation.GetBoundTree(tree);
            Console.WriteLine(boundTree);
            var boundRoot = boundTree.GetBoundRoot();
            File.WriteAllText("BoundTree.txt", boundRoot.Dump());

            //*/

            /*/
            ImmutableMetaModelGenerator mmgen = new ImmutableMetaModelGenerator(compiledModel.Symbols);
            string generatedCsharpModel = mmgen.Generate();
            File.WriteAllText("Soal.txt", generatedCsharpModel);
            //File.WriteAllText("../../../Soal.cs", generatedCsharpModel);
            //File.WriteAllText(@"..\..\..\..\..\Main\MetaDslx.Core\Languages\Meta\Symbols\ImmutableMetaModel.cs", generatedCsharpModel);
            //File.WriteAllText("ImmutableMetaModel.txt", generatedCsharpModel);
            //*/

            //*/
            //BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            BinderFlags binderFlags = BinderFlags.None;
            ImmutableModel soalModel = SoalInstance.Model;
            //string soalSource = File.ReadAllText(@"..\..\..\cinema.soal");
            string soalSource = File.ReadAllText(@"..\..\..\Wsdl01.soal");
            var syntaxTree = SoalSyntaxTree.ParseText(soalSource);
            var compilation = SoalCompilation.Create("SoalTest")
                .AddSyntaxTrees(syntaxTree)
                .AddReferences(ModelReference.CreateFromModel(soalModel))
                .WithOptions(new SoalCompilationOptions(SoalLanguage.Instance, OutputKind.DynamicallyLinkedLibrary).WithConcurrentBuild(false).WithTopLevelBinderFlags(binderFlags));
            compilation.ForceComplete();
            var formatter = new DiagnosticFormatter();
            foreach (var diag in compilation.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            var boundTree = compilation.GetBoundTree(syntaxTree);
            Console.WriteLine(boundTree);
            var boundRoot = boundTree.GetBoundRoot();
            File.WriteAllText("BoundTree.txt", boundRoot.Dump());

            var compiledModel = compilation.Model;
            Console.WriteLine(compiledModel);
            using (StreamWriter writer = new StreamWriter("Model.txt"))
            {
                foreach (var symbol in compiledModel.Symbols)
                {
                    writer.WriteLine(symbol);
                    foreach (var prop in symbol.MProperties)
                    {
                        object value = symbol.MGet(prop);
                        if (value is IEnumerable<object> collection)
                        {
                            writer.WriteLine("  {0} = ({1})", prop.Name, collection.Count());
                            foreach (var item in collection)
                            {
                                writer.WriteLine("    {0}", item);
                            }
                        }
                        else
                        {
                            writer.WriteLine("  {0} = {1}", prop.Name, value);
                        }
                    }
                }
            }
            //*/

        }


    }
}
