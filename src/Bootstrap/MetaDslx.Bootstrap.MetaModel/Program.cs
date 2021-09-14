using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Source;
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
            var coreAssembly = typeof(object).Assembly.Location;
            var assemblyPath = Path.GetDirectoryName(coreAssembly);
            var coreRef = MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "mscorlib.dll"));
            Console.WriteLine(coreRef);

            string text = File.ReadAllText(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Meta\Languages\Meta\Model\ImmutableMetaModel.mm");
            //string text = File.ReadAllText(@"..\..\..\ImmutableMetaModel.mm");
            //string text = File.ReadAllText(@"..\..\..\PropertiesTestLang.mm");
            //string text = File.ReadAllText(@"..\..\..\Calculator.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\..\..\soal-cs\Src\Main\MetaDslx.Languages.Soal\Symbols\Soal.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Test\WebSequenceDiagramsModel\Symbols\UmlModel.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Languages.Test\Languages\Soal\Model\Soal.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Meta.Test\Languages\PropertiesTest\PropertiesTestLang.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Main\MetaDslx.Languages.Omg\Mof\Model\Mof.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Languages\MetaDslx.Languages.Uml-v2.5.1\Model\Uml.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Languages\MetaDslx.Languages.Ecore\Ecore\Model\Ecore.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Examples\RailDsl\Model\RailDsl.mm");
            //string text = File.ReadAllText(@"..\..\..\Error0.mm");
            //string text = File.ReadAllText(@"..\..\..\Error1.mm");
            //string text = File.ReadAllText(@"..\..\..\Error2.mm");
            //string text = File.ReadAllText(@"..\..\..\Error3.mm");
            //string text = File.ReadAllText(@"..\..\..\Error4.mm");
            //string text = File.ReadAllText(@"..\..\..\Error5.mm");
            //string text = File.ReadAllText(@"..\..\..\ImmutableMetaModelTest02.mm");
            //string text = File.ReadAllText(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestIncrementalCompilation\Symbols\TestIncrementalCompilation.mm");
            var tree = MetaSyntaxTree.ParseText(text);
            var declarations = MetaDeclarationTreeBuilderVisitor.ForTree(tree, MetaLanguage.Instance.SymbolFacts, "Script", false);

            //Console.WriteLine(declarations.Dump());

            var formatter = new DiagnosticFormatter();
            foreach (var diag in tree.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            //foreach (var diag in declarations.Diagnostics)
            //{
            //    Console.WriteLine(formatter.Format(diag));
            //}

            //MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: false, concurrentBuild: true);
            BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            BinderFlags ignoreDuplicates = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
            BinderFlags allowMetaConstants = BinderFlags.AllowMetaConstants;
            binderFlags = binderFlags.UnionWith(ignoreDuplicates, allowMetaConstants);
            MetaCompilationOptions options = new MetaCompilationOptions(OutputKind.NetModule, deterministic: true, concurrentBuild: false).WithTopLevelBinderFlags(binderFlags); 
            //MetaCompilationOptions options = new MetaCompilationOptions(OutputKind.NetModule, deterministic: false, concurrentBuild: true).WithTopLevelBinderFlags(binderFlags);
            var compilation = MetaCompilation.
                Create("MetaTest").
                AddSyntaxTrees(tree).
                AddReferences(coreRef).
                AddReferences(ModelReference.CreateFromModel(coreModel)).
                AddReferences(MetadataReference.CreateFromFile(typeof(Symbol).Assembly.Location)).
                WithOptions(options);
            var compiledModel = compilation.Model as MutableModel;
            Console.WriteLine(compiledModel);

            var corLib = compilation.GetAssemblyOrModuleSymbol(coreRef) as AssemblySymbol;
            var corInt32 = corLib.GetSpecialSymbol(SpecialType.System_Int32) as TypeSymbol;
            Console.WriteLine("corInt32:");
            Console.WriteLine(corInt32 + " -> System.Int32:" + corInt32.IsSpecialSymbol(SpecialType.System_Int32) + " -> MetaInstance.Int:" + corInt32.IsSpecialModelObject(MetaInstance.Int) + " -> MetaInstance.Int+Lang:" + corInt32.IsSpecialModelObject(MetaInstance.Int, MetaLanguage.Instance));
            Console.WriteLine("None: " + corInt32.GetSpecialSymbol() + " - CSharp: " + corInt32.GetSpecialSymbol(CSharpLanguage.Instance) + " - Meta: " + corInt32.GetSpecialSymbol(MetaLanguage.Instance));
            Console.WriteLine(corInt32 + " -> System.Int64:" + corInt32.IsSpecialSymbol(SpecialType.System_Int64) + " -> MetaInstance.Long:" + corInt32.IsSpecialModelObject(MetaInstance.Long) + " -> MetaInstance.Long+Lang:" + corInt32.IsSpecialModelObject(MetaInstance.Long, MetaLanguage.Instance));
            Console.WriteLine("----");

            var corInt64 = corLib.GetSpecialSymbol(SpecialType.System_Int64) as TypeSymbol;
            Console.WriteLine("corInt64:");
            Console.WriteLine(corInt64 + " -> System.Int32:" + corInt64.IsSpecialSymbol(SpecialType.System_Int32) + " -> MetaInstance.Int:" + corInt64.IsSpecialModelObject(MetaInstance.Int) + " -> MetaInstance.Int+Lang:" + corInt64.IsSpecialModelObject(MetaInstance.Int, MetaLanguage.Instance));
            Console.WriteLine("None: " + corInt32.GetSpecialSymbol() + " - CSharp: " + corInt32.GetSpecialSymbol(CSharpLanguage.Instance) + " - Meta: " + corInt32.GetSpecialSymbol(MetaLanguage.Instance));
            Console.WriteLine(corInt64 + " -> System.Int64:" + corInt64.IsSpecialSymbol(SpecialType.System_Int64) + " -> MetaInstance.Long:" + corInt64.IsSpecialModelObject(MetaInstance.Long) + " -> MetaInstance.Long+Lang:" + corInt64.IsSpecialModelObject(MetaInstance.Long, MetaLanguage.Instance));
            Console.WriteLine("----");

            var compInt32 = compilation.Assembly.GetSpecialSymbol(SpecialType.System_Int32) as TypeSymbol;
            Console.WriteLine("compInt32:");
            Console.WriteLine(compInt32 + " -> System.Int32:" + compInt32.IsSpecialSymbol(SpecialType.System_Int32) + " -> MetaInstance.Int:" + compInt32.IsSpecialModelObject(MetaInstance.Int));
            Console.WriteLine("None: " + compInt32.GetSpecialSymbol() + " - CSharp: " + compInt32.GetSpecialSymbol(CSharpLanguage.Instance) + " - Meta: " + compInt32.GetSpecialSymbol(MetaLanguage.Instance));
            Console.WriteLine(compInt32 + " -> System.Int64:" + compInt32.IsSpecialSymbol(SpecialType.System_Int64) + " -> MetaInstance.Long:" + compInt32.IsSpecialModelObject(MetaInstance.Long));
            Console.WriteLine("----");

            var metaInt32 = compilation.Assembly.ResolveModelSymbol(MetaInstance.Int) as TypeSymbol;
            Console.WriteLine("metaInt32:");
            Console.WriteLine(metaInt32 + " -> System.Int32:" + metaInt32.IsSpecialSymbol(SpecialType.System_Int32) + " -> MetaInstance.Int:" + metaInt32.IsSpecialModelObject(MetaInstance.Int));
            Console.WriteLine("None: " + metaInt32.GetSpecialSymbol() + " - CSharp: " + metaInt32.GetSpecialSymbol(CSharpLanguage.Instance) + " - Meta: " + metaInt32.GetSpecialSymbol(MetaLanguage.Instance));
            Console.WriteLine(metaInt32 + " -> System.Int64:" + metaInt32.IsSpecialSymbol(SpecialType.System_Int64) + " -> MetaInstance.Long:" + metaInt32.IsSpecialModelObject(MetaInstance.Long));
            Console.WriteLine("----");

            var compMobj = compilation.Assembly.GetSpecialSymbol(MetaInstance.ModelObject) as TypeSymbol;
            Console.WriteLine(compMobj + " -> MetaInstance.ModelObject:" + compMobj.IsSpecialSymbol(MetaInstance.ModelObject));
            Console.WriteLine("----");

            var metaMobj = compilation.Assembly.ResolveModelSymbol(MetaInstance.ModelObject) as TypeSymbol;
            Console.WriteLine(metaMobj + " -> MetaInstance.ModelObject:" + metaMobj.IsSpecialSymbol(MetaInstance.ModelObject));
            Console.WriteLine("----");

            HashSet<DiagnosticInfo>? usd = null;
            Console.WriteLine("corInt32->corInt32: " + compilation.Conversions.ClassifyConversionFromType(corInt32, corInt32, ref usd));
            Console.WriteLine("corInt32->compInt32: " + compilation.Conversions.ClassifyConversionFromType(corInt32, compInt32, ref usd));
            Console.WriteLine("corInt32->metaInt32: " + compilation.Conversions.ClassifyConversionFromType(corInt32, metaInt32, ref usd));
            Console.WriteLine("compInt32->corInt32: " + compilation.Conversions.ClassifyConversionFromType(compInt32, corInt32, ref usd));
            Console.WriteLine("compInt32->compInt32: " + compilation.Conversions.ClassifyConversionFromType(compInt32, compInt32, ref usd));
            Console.WriteLine("compInt32->metaInt32: " + compilation.Conversions.ClassifyConversionFromType(compInt32, metaInt32, ref usd));
            Console.WriteLine("metaInt32->corInt32: " + compilation.Conversions.ClassifyConversionFromType(metaInt32, corInt32, ref usd));
            Console.WriteLine("metaInt32->compInt32: " + compilation.Conversions.ClassifyConversionFromType(metaInt32, compInt32, ref usd));
            Console.WriteLine("metaInt32->metaInt32: " + compilation.Conversions.ClassifyConversionFromType(metaInt32, metaInt32, ref usd));
            Console.WriteLine("corInt64->corInt32: " + compilation.Conversions.ClassifyConversionFromType(corInt64, corInt32, ref usd));
            Console.WriteLine("corInt64->compInt32: " + compilation.Conversions.ClassifyConversionFromType(corInt64, compInt32, ref usd));
            Console.WriteLine("corInt64->metaInt32: " + compilation.Conversions.ClassifyConversionFromType(corInt64, metaInt32, ref usd));
            Console.WriteLine("corInt32->corInt64: " + compilation.Conversions.ClassifyConversionFromType(corInt32, corInt64, ref usd));
            Console.WriteLine("compInt32->corInt64: " + compilation.Conversions.ClassifyConversionFromType(compInt32, corInt64, ref usd));
            Console.WriteLine("metaInt32->corInt64: " + compilation.Conversions.ClassifyConversionFromType(metaInt32, corInt64, ref usd));
            Console.WriteLine("metaInt32->metaMobj: " + compilation.Conversions.ClassifyConversionFromType(metaInt32, metaMobj, ref usd));
            Console.WriteLine("metaInt32->object: " + compilation.Conversions.ClassifyConversionFromType(metaInt32, compilation.ObjectType, ref usd));
            Console.WriteLine("metaMobj->object: " + compilation.Conversions.ClassifyConversionFromType(metaMobj, compilation.ObjectType, ref usd));
            Console.WriteLine("metaInt32->dynamic: " + compilation.Conversions.ClassifyConversionFromType(metaInt32, compilation.DynamicType, ref usd));
            Console.WriteLine("metaMobj->dynamic: " + compilation.Conversions.ClassifyConversionFromType(metaMobj, compilation.DynamicType, ref usd));
            Console.WriteLine("object->metaInt32: " + compilation.Conversions.ClassifyConversionFromType(compilation.ObjectType, metaInt32, ref usd));
            Console.WriteLine("object->metaMobj: " + compilation.Conversions.ClassifyConversionFromType(compilation.ObjectType, metaMobj, ref usd));
            Console.WriteLine("dynamic->metaInt32: " + compilation.Conversions.ClassifyConversionFromType(compilation.DynamicType, metaInt32, ref usd));
            Console.WriteLine("dynamic->metaMobj: " + compilation.Conversions.ClassifyConversionFromType(compilation.DynamicType, metaMobj, ref usd));
            Console.WriteLine("----");

            Console.WriteLine("++corInt32: " + compilation.UnaryOperators.ClassifyOperatorByType(UnaryOperatorKind.PrefixIncrement, corInt32));
            Console.WriteLine("++compInt32: " + compilation.UnaryOperators.ClassifyOperatorByType(UnaryOperatorKind.PrefixIncrement, compInt32));
            Console.WriteLine("++metaInt32: " + compilation.UnaryOperators.ClassifyOperatorByType(UnaryOperatorKind.PrefixIncrement, metaInt32));
            Console.WriteLine("++metaMobj: " + compilation.UnaryOperators.ClassifyOperatorByType(UnaryOperatorKind.PrefixIncrement, metaMobj));

            Console.WriteLine("----");

            Console.WriteLine("corInt32+corInt32: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, corInt32, corInt32));
            Console.WriteLine("corInt64+corInt32: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, corInt64, corInt32));
            Console.WriteLine("compInt32+corInt32: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, compInt32, corInt32));
            Console.WriteLine("metaInt32+corInt32: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, metaInt32, corInt32));
            Console.WriteLine("metaMobj+corInt32: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, metaMobj, corInt32));

            Console.WriteLine("corInt32+corInt32: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, corInt32, corInt32));
            Console.WriteLine("corInt32+corInt64: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, corInt32, corInt64));
            Console.WriteLine("corInt32+compInt32: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, corInt32, compInt32));
            Console.WriteLine("corInt32+metaInt32: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, corInt32, metaInt32));
            Console.WriteLine("corInt32+metaMobj: " + compilation.BinaryOperators.ClassifyOperatorByType(BinaryOperatorKind.Addition, corInt32, metaMobj));

            Console.WriteLine("----");

            //var node = tree.GetCompilationUnitRoot().NamespaceDeclaration.NamespaceBody.Declaration[0].ConstDeclaration;
            //var node = tree.GetCompilationUnitRoot().NamespaceDeclaration.NamespaceBody.Declaration[0].ConstDeclaration.TypeReference.SimpleType.ClassType.Qualifier.Identifier[0];
            //var node = tree.GetCompilationUnitRoot().NamespaceDeclaration.NamespaceBody.Declaration[0].ConstDeclaration.Name.Identifier;
            //var info = compilation.GetSemanticModel(tree, true).GetSymbolInfo(node);
            //Console.WriteLine(info.Symbol);
            //var info = compilation.GetSemanticModel(tree, true).GetTypeInfo(node);
            //Console.WriteLine(info.Type);

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

        private static IEnumerable<MetadataReference> SystemRuntimeAssemblies()
        {
            var assemblyNames = new string[] { "mscorlib.dll" };
            var coreTypes = new Type[] { typeof(object) };
            var coreAssembly = typeof(object).Assembly.Location;
            var assemblyPath = Path.GetDirectoryName(coreAssembly);
            var result = new List<MetadataReference>();
            result.AddRange(assemblyNames.Select(assemblyName => MetadataReference.CreateFromFile(Path.Combine(assemblyPath, assemblyName))));
            result.AddRange(coreTypes.Select(type => MetadataReference.CreateFromFile(type.Assembly.Location)));
            return result;
        }
    }


}
