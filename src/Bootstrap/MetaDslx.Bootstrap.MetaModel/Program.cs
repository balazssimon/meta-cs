using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Binding;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MetaDslx.Bootstrap.MetaModel
{
    class Program
    {
        static void Main(string[] args)
        {
            ImmutableModel coreModel = MetaInstance.MModel;
            Console.WriteLine(coreModel);

            //string text = File.ReadAllText(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Meta\Languages\Meta\Model\ImmutableMetaModel.mm");
            string text = File.ReadAllText(@"..\..\..\ImmutableMetaModel.mm");
            //string text = File.ReadAllText(@"..\..\..\Calculator.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\..\..\soal-cs\Src\Main\MetaDslx.Languages.Soal\Symbols\Soal.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Test\WebSequenceDiagramsModel\Symbols\UmlModel.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Main\MetaDslx.Languages.Omg\Mof\Model\Mof.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Languages\MetaDslx.Languages.Uml-v2.5.1\Model\Uml.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Languages\MetaDslx.Languages.Ecore\Model\Ecore.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Examples\RailDsl\Model\RailDsl.mm");
            //string text = File.ReadAllText(@"..\..\..\Error0.mm");
            //string text = File.ReadAllText(@"..\..\..\Error1.mm");
            //string text = File.ReadAllText(@"..\..\..\Error2.mm");
            //string text = File.ReadAllText(@"..\..\..\Error3.mm");
            //string text = File.ReadAllText(@"..\..\..\Error4.mm");
            //string text = File.ReadAllText(@"..\..\..\Error5.mm");

            var tree = MetaSyntaxTree.ParseText(text);
            var declarations = MetaDeclarationTreeBuilderVisitor.ForTree(tree, "Script", false);

            //Console.WriteLine(declarations.Dump());

            var formatter = new DiagnosticFormatter();
            //foreach (var diag in tree.GetDiagnostics())
            //{
            //    Console.WriteLine(formatter.Format(diag));
            //}
            //foreach (var diag in declarations.Diagnostics)
            //{
            //    Console.WriteLine(formatter.Format(diag));
            //}

            //MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: false, concurrentBuild: true);
            BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            BinderFlags binderFlags2 = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
            binderFlags = binderFlags.UnionWith(binderFlags2);
            MetaCompilationOptions options = new MetaCompilationOptions(OutputKind.NetModule, deterministic: true, concurrentBuild: false, topLevelBinderFlags: binderFlags);
            var compilation = MetaCompilation.
                Create("MetaTest").
                AddSyntaxTrees(tree).
                AddReferences(ModelReference.CreateFromModel(coreModel)).
                WithOptions(options);

            var compiledModel = compilation.Model as MutableModel;
            Console.WriteLine(compiledModel);
            using (StreamWriter writer = new StreamWriter("Model.txt"))
            {
                foreach (var symbol in compiledModel.Objects)
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

            //*/

            //*/
            var immutableModel = compiledModel.ToImmutable();
            ImmutableMetaModelGenerator mmgen = new ImmutableMetaModelGenerator(immutableModel.Objects);
            string generatedCsharpModel = mmgen.Generate();
            File.WriteAllText("Model.cs.txt", generatedCsharpModel);
            //File.WriteAllText(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Meta\Languages\Meta\Model\ImmutableMetaModel.cs", generatedCsharpModel);
            //File.WriteAllText("ImmutableMetaModel.txt", generatedCsharpModel);
            //*/

        }
    }
}
