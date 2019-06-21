﻿using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Binding;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.IO;

namespace MetaDslx.Bootstrap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*/
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\MGenTest.mgen");
            MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Generator\CompilerGenerator.mgen");
            mg.Compile();
            //*/
            
            /*/
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorLexer.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            //Antlr4RoslynBootstrap a4r = new Antlr4RoslynBootstrap(@"..\..\..\MetaGeneratorParser.ag4", "MetaDslx.Bootstrap.MetaGenerator");
            Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaLexer.ag4", "MetaDslx.Languages.Meta");
            a4l.Compile();
            Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaParser.ag4", "MetaDslx.Languages.Meta");
            a4p.Compile();
            //*/

            /*/
            MGenTest test = new MGenTest();
            Console.WriteLine(test.SayHello("me"));
            //*/

            //*/
            ImmutableModel coreModel = MetaInstance.Model;
            Console.WriteLine(coreModel);

            string text = File.ReadAllText(@"..\..\..\ImmutableMetaModel.mm");
            //string text = File.ReadAllText(@"..\..\..\Calculator.mm");
            //string text = File.ReadAllText(@"..\..\..\Soal.mm");

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

            MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: true);
            var compilation = MetaCompilation.
                Create("MetaTest").
                AddSyntaxTrees(tree).
                AddReferences(
                    ModelReference.CreateFromModel(coreModel),
                    ModelReference.CreateFromModel(MetaAnnotations.Model)
                    ).
                WithOptions(options);

            var modules = compilation.SourceModule.ContainingAssembly.Modules.AsImmutable();
            //var objectType = compilation.ObjectType;
            //Console.WriteLine(objectType);
            //foreach (var member in objectType.MemberNames)
            //{
            //    Console.WriteLine("  "+member);
            //}
            int index = 0;
            foreach (var module in modules)
            {
                foreach (var assembly in module.ReferencedAssemblySymbols)
                {
                    Console.WriteLine("  ReferencedAssembly: " + assembly);
                    foreach (var member in assembly.GlobalNamespace.GetMembers())
                    {
                        Console.WriteLine("    {0}: {1}", member.Name, member.GetType());
                    }
                }
                Console.WriteLine("Module[{0}]: {1}", index, module.GetType());
                foreach (var member in module.GlobalNamespace.GetMembers())
                {
                    Console.WriteLine("  {0}: {1}", member.Name, member.GetType());
                }
                ++index;
            }

            var compiledModel = compilation.Model;
            Console.WriteLine(compiledModel);
            foreach (var symbol in compiledModel.Symbols)
            {
                Console.WriteLine(symbol);
            }

            foreach (var diag in compilation.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }

            var boundTree = compilation.GetBoundTree(tree);
            Console.WriteLine(boundTree);
            var boundRoot = boundTree.GetBoundRoot();
            File.WriteAllText("BountTree.txt", boundRoot.Dump());

            //*/
        }


    }
}
