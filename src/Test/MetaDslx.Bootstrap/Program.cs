using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Binding;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Symbols;
//using MetaDslx.Languages.Mof.Generator;
//using MetaDslx.Languages.Mof.Model;
//using MetaDslx.Languages.Uml.Generator;
//using MetaDslx.Languages.Uml.Model;
//using MetaDslx.Languages.Ecore;
//using MetaDslx.Languages.Ecore.Model;
using MetaDslx.Modeling;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;

namespace MetaDslx.Bootstrap
{

    class Program
    {
        static void Main(string[] args)
        {
            /*/
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\MGenTest.mgen");
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Generator\CompilerGenerator.mgen");
            //MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.Core\Languages\Meta\Generator\ImmutableMetaModelGenerator.mgen");
            MetaGeneratorBootstrap mg = new MetaGeneratorBootstrap(@"..\..\..\..\..\Main\MetaDslx.Languages.Omg\Mof\Generator\MofModelToMetaModelGenerator.mgen");
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
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Samples\MetaDslx.Languages.Soal\Syntax\InternalSyntax\SoalLexer.ag4", "MetaDslx.Languages.Soal");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Samples\MetaDslx.Languages.Soal\Syntax\InternalSyntax\SoalParser.ag4", "MetaDslx.Languages.Soal");
            //a4p.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\WebSequenceDiagramsModel\Syntax\InternalSyntax\SequenceLexer.ag4", "WebSequenceDiagramsModel");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\WebSequenceDiagramsModel\Syntax\InternalSyntax\SequenceParser.ag4", "WebSequenceDiagramsModel");
            //a4p.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLangOne\Syntax\TestLangOneLexer.ag4", "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Syntax");
            //a4l.Compile();
            //Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLangOne\Syntax\TestLangOneParser.ag4", "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Syntax");
            //a4p.Compile();
            //Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Languages\MetaDslx.Languages.Uml-v2.5.1\Serialization\Syntax\InternalSyntax\WebSequenceDiagramsLexer.ag4", "MetaDslx.Languages.Uml.Serialization");
            //a4l.Compile();
            Antlr4RoslynBootstrap a4l = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLexerMode\Syntax\InternalSyntax\TestLexerModeLexer.ag4", "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax");
            a4l.Compile();
            Antlr4RoslynBootstrap a4p = new Antlr4RoslynBootstrap(@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLexerMode\Syntax\InternalSyntax\TestLexerModeParser.ag4", "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax");
            a4p.Compile();
            //*/

            /*/
            MGenTest test = new MGenTest();
            Console.WriteLine(test.SayHello("me"));
            //*/

            //*/
            ImmutableModel coreModel = MetaInstance.MModel;
            Console.WriteLine(coreModel);

            string text = File.ReadAllText(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Meta\Languages\Meta\Model\ImmutableMetaModel.mm");
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

            //string text = @"namespace A { metamodel M; class B { s";

            var tree = MetaSyntaxTree.ParseText(text);
            var declarations = MetaDeclarationTreeBuilderVisitor.ForTree((MetaSyntaxTree)tree, "Script", false);

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
                Console.WriteLine(diag.Location.SourceSpan);
                Console.WriteLine(formatter.Format(diag));
            }

            var boundTree = compilation.GetBoundTree(tree);
            Console.WriteLine(boundTree);
            var boundRoot = boundTree.GetBoundRoot();
            File.WriteAllText("BoundTree.txt", boundRoot.Dump());

            //*/

            /*/
            ImmutableMetaModelGenerator mmgen = new ImmutableMetaModelGenerator(compiledModel.Objects);
            string generatedCsharpModel = mmgen.Generate();
            File.WriteAllText("Model.cs.txt", generatedCsharpModel);
            //File.WriteAllText("Soal.txt", generatedCsharpModel);
            //File.WriteAllText("../../../Soal.cs", generatedCsharpModel);
            //File.WriteAllText(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Meta\Languages\Meta\Model\ImmutableMetaModel.cs", generatedCsharpModel);
            //File.WriteAllText("ImmutableMetaModel.txt", generatedCsharpModel);
            //File.WriteAllText(@"..\..\..\..\..\Test\WebSequenceDiagramsModel\Symbols\UmlModel.cs", generatedCsharpModel);
            //*/

            /*/
            BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            //BinderFlags binderFlags = BinderFlags.None;
            ImmutableModel soalModel = SoalInstance.Model;
            //string soalSource = File.ReadAllText(@"..\..\..\cinema.soal");
            //string soalSource = File.ReadAllText(@"..\..\..\Wsdl01.soal");
            //string soalSource = File.ReadAllText(@"..\..\..\Wsdl02.soal");
            //string soalSource = File.ReadAllText(@"..\..\..\Wsdl03.soal");
            //string soalSource = File.ReadAllText(@"..\..\..\Xsd11.soal");
            string soalSource = File.ReadAllText(@"..\..\..\Wsdl00.soal");
            var syntaxTree = SoalSyntaxTree.ParseText(soalSource);
            var compilation = SoalCompilation.Create("SoalTest")
                .AddSyntaxTrees(syntaxTree)
                .AddReferences(ModelReference.CreateFromModel(soalModel))
                .WithOptions(new SoalCompilationOptions(SoalLanguage.Instance, OutputKind.DynamicallyLinkedLibrary).WithConcurrentBuild(true).WithTopLevelBinderFlags(binderFlags));
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
                    writer.WriteLine("{0} ({1})", symbol, symbol.MId.Id);
                    foreach (var prop in symbol.MProperties)
                    {
                        object value = symbol.MGet(prop);
                        if (value is IEnumerable<object> collection)
                        {
                            writer.WriteLine("  {0} = ({1})", prop.Name, collection.Count());
                            foreach (var item in collection)
                            {
                                writer.WriteLine("    {0} ({1})", item, (item as IMetaSymbol)?.MId?.Id);
                            }
                        }
                        else
                        {
                            writer.WriteLine("  {0} = {1} ({2})", prop.Name, value, (value as IMetaSymbol)?.MId?.Id);
                        }
                    }
                }
            }
            //*/

            /*/
            GenerateWsdlTest(4);
            //SoalImportTest(1);
            //*/

            /*/
            WebSequenceDiagramsTest();
            //*/

            //*/
            //MetaXmiTest();
            //XmiTest();
            //MofXmiTest();
            //UmlXmiTest();
            //EcoreXmiTest();
            //MetaDslxXmiTest();
            //*/

            /*/
            using (var assertions = new DebugAssertUnitTestTraceListener())
            {
                try
                {
                    CallLogger.Enabled = true;
                    IncrementalCompiler compiler = new IncrementalCompiler();
                    //var pos = 507;
                    var pos = 2368;
                    //string source = File.ReadAllText($@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\InputFiles\LexerMode\MGenTest.txt").Substring(0, pos);
                    //string source = File.ReadAllText($@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\InputFiles\LexerMode\PropertyTest.txt").Substring(0, pos);
                    //string source = File.ReadAllText($@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\InputFiles\LexerMode\MetaModelGenerator.txt").Substring(0, pos);
                    string source = File.ReadAllText($@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\InputFiles\LexerMode\UmlModelToMetaModelGenerator.txt").Substring(0, pos);
                    compiler.Type(source, 2368-64);
                    //string source = File.ReadAllText($@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\InputFiles\LexerMode\MetaModelGenerator.txt");
                    //compiler.Type(source);
                    //string source = File.ReadAllText($@"..\..\..\..\..\Test\MetaDslx.CodeAnalysis.Antlr4.Test\InputFiles\LexerMode\UmlModelToMetaModelGenerator.txt");
                    //compiler.Type(source);
                    foreach (var assertion in assertions.AssertionFailures)
                    {
                        Console.WriteLine(assertion);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    File.WriteAllText(@"..\..\..\CallLog.txt", CallLogger.Instance.GetLog());
                }
            }
            //*/
            /*/
            try
            {
                CallLogger.Enabled = true;
                var text = @"namespace EntitiesSample
{
	etamodel Entities; 

    class NamedElement{}
}";
                var source = SourceText.From(text);
                var compiler = new MetaCompiler();
                var src1 = compiler.SingleEdit(source, 76, 1);
                var root = (LanguageSyntaxNode)src1.Item2.GetRoot();
                var tokens = root.FindTokens(TextSpan.FromBounds(0, src1.Item1.Length), true);
                foreach (var token in tokens)
                {
                    Console.WriteLine(token.RawKind+" "+token.GetKind().ToString()+" '"+token.Text+"' "+ token.GetContextualKind().ToString());
                }
                //var src2 = compiler.SingleEdit(src1, 77, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                var log = CallLogger.Instance.GetLog();
                File.WriteAllText(@"..\..\..\CallLogger.txt", log);
            }

            //*/
        }

        /*/
        private static bool GenerateWsdlTest(int index)
        {
            string testDirectory = @"..\..\..\..\..\..\..\soal-cs\Src\Test\MetaDslx.Languages.Soal.Test\";
            bool result = false;
            string inputFileName = string.Format(testDirectory + @"InputFiles\soal\Wsdl{0:00}.soal", index);
            string expectedXsdFileName = string.Format(testDirectory + @"ExpectedFiles\xsd\Wsdl{0:00}.Hello.xsd", index);
            string outputXsdFileName = string.Format(testDirectory + @"OutputFiles\xsd\Wsdl{0:00}.Hello.xsd", index);
            string expectedWsdlFileName = string.Format(testDirectory + @"ExpectedFiles\wsdl\Wsdl{0:00}.Hello.wsdl", index);
            string outputWsdlFileName = string.Format(testDirectory + @"OutputFiles\wsdl\Wsdl{0:00}.Hello.wsdl", index);
            string outputDirectory = string.Format(testDirectory + @"OutputFiles");
            string inputSoal = null;
            using (StreamReader reader = new StreamReader(inputFileName))
            {
                inputSoal = reader.ReadToEnd();
            }
            SoalSyntaxTree syntaxTree = SoalSyntaxTree.ParseText(inputSoal);
            ModelReference soalReference = ModelReference.CreateFromModel(SoalInstance.Model);
            BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            SoalCompilationOptions options = new SoalCompilationOptions(SoalLanguage.Instance, OutputKind.NetModule, topLevelBinderFlags: binderFlags, concurrentBuild: false);
            SoalCompilation compilation = SoalCompilation.Create("SoalTest").AddReferences(soalReference).AddSyntaxTrees(syntaxTree).WithOptions(options);
            compilation.ForceComplete();
            ImmutableModel model = compilation.Model;

            Debug.Assert(!compilation.GetDiagnostics().Any(d => d.Severity == DiagnosticSeverity.Error));
            DiagnosticFormatter formatter = new DiagnosticFormatter();
            foreach (var diagnostic in compilation.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diagnostic));
            }

            DiagnosticBag generatorDiagnostics = new DiagnosticBag();
            SoalGenerator generator = new SoalGenerator(model, compilation.BuildModelObjectToSymbolMap(), outputDirectory, generatorDiagnostics, inputFileName);
            generator.SeparateXsdWsdl = true;
            generator.SingleFileWsdl = false;
            generator.Generate();

            var generatorDiagnosticList = generatorDiagnostics.ToReadOnly();
            Debug.Assert(!generatorDiagnosticList.Any(d => d.Severity == DiagnosticSeverity.Error));
            foreach (var diagnostic in generatorDiagnosticList)
            {
                Console.WriteLine(formatter.Format(diagnostic));
            }

            string expectedXsd = null;
            using (StreamReader reader = new StreamReader(expectedXsdFileName))
            {
                expectedXsd = reader.ReadToEnd();
            }
            string outputXsd = null;
            using (StreamReader reader = new StreamReader(outputXsdFileName))
            {
                outputXsd = reader.ReadToEnd();
            }
            Debug.Assert(expectedXsd == outputXsd);
            string expectedWsdl = null;
            using (StreamReader reader = new StreamReader(expectedWsdlFileName))
            {
                expectedWsdl = reader.ReadToEnd();
            }
            string outputWsdl = null;
            using (StreamReader reader = new StreamReader(outputWsdlFileName))
            {
                outputWsdl = reader.ReadToEnd();
            }
            Debug.Assert(expectedWsdl == outputWsdl);
            return result;

        }

        private static bool SoalImportTest(int index)
        {
            string testDirectory = @"..\..\..\..\..\..\..\soal-cs\Src\Test\MetaDslx.Languages.Soal.Test\";
            bool result = false;
            string inputFileName = string.Format(testDirectory + @"InputFiles\wsdl\Wsdl{0:00}.Hello.wsdl", index);
            string expectedFileName = string.Format(testDirectory + @"ExpectedFiles\soal\Wsdl{0:00}.soal", index);
            string outputFileName = string.Format(testDirectory + @"OutputFiles\soal\Wsdl{0:00}.Hello.soal", index);
            string outputLogFileName = string.Format(testDirectory + @"OutputFiles\soal\Wsdl{0:00}.Hello.log", index);
            string outputDirectory = string.Format(testDirectory + @"OutputFiles\soal", index);
            DiagnosticBag diagnostics = new DiagnosticBag();
            ImmutableModel model = SoalImporter.Import(inputFileName, diagnostics);
            using (StreamWriter writer = new StreamWriter(outputLogFileName))
            {
                foreach (var msg in diagnostics.AsEnumerable())
                {
                    writer.WriteLine(msg);
                }
            }
            Debug.Assert(!diagnostics.HasAnyErrors());
            Directory.CreateDirectory(outputDirectory);
            string outputSoal = null;
            SoalPrinter printer = new SoalPrinter(model.Symbols);
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                outputSoal = printer.Generate();
                writer.WriteLine(outputSoal);
            }
            string expectedSoal = null;
            using (StreamReader reader = new StreamReader(expectedFileName))
            {
                expectedSoal = reader.ReadToEnd();
            }
            File.WriteAllText(@"..\..\..\expected.txt", expectedSoal);
            File.WriteAllText(@"..\..\..\actual.txt", outputSoal);
            Debug.Assert(expectedSoal == outputSoal);
            return result;
        }
        //*/

        /*/
        private static void WebSequenceDiagramsTest()
        {
            MetaDescriptor.Initialize();
            UmlDescriptor.Initialize();

            string text = File.ReadAllText(@"..\..\..\test2.wsd");

            SequenceLexer lexer = new SequenceLexer(new AntlrInputStream(text));
            while(!lexer._hitEOF)
            {
                var token = lexer.NextToken();
                var tokenType = SequenceLexer.DefaultVocabulary.GetDisplayName(token.Type);
                Console.WriteLine(tokenType+": "+token.Text);
            }

            SequenceSyntaxTree st = SequenceSyntaxTree.ParseText(text);
            //Console.WriteLine(st);
            DiagnosticFormatter df = new DiagnosticFormatter();
            foreach (var diag in st.GetDiagnostics())
            {
                Console.WriteLine(df.Format(diag));
            }

            SequenceCompilationOptions options = new SequenceCompilationOptions(SequenceLanguage.Instance, OutputKind.DynamicallyLinkedLibrary, concurrentBuild: false, deterministic: true);
            SequenceCompilation compilation = SequenceCompilation.Create("Sequence").WithOptions(options).AddSyntaxTrees(st);
            compilation.ForceComplete();
            var model = compilation.Model;
            Console.WriteLine(model);
        }
        //*/

        /*/
        public static void MofXmiTest()
        {
            MofDescriptor.Initialize();

            string fileName = "../../../Uml.xmi";

            try
            {
                var xmi = new MofXmiSerializer();
                var modelGroup = xmi.ReadModelGroupFromFile(fileName);
                Console.WriteLine(modelGroup);
                var writeOptions = new MofXmiWriteOptions();
                int i = 0;
                foreach (var model in modelGroup.Models)
                {
                    writeOptions.ModelToFileMap.Add(model, "../../../file" + i + ".xmi");
                    ++i;
                }
                xmi.WriteModelGroupToFile(modelGroup, writeOptions);
                //var xmiCode = xmi.WriteModelGroup(modelGroup);
                MofModelToMetaModelGenerator mgen = new MofModelToMetaModelGenerator(modelGroup.Objects);
                string metaCode = mgen.Generate("MetaDslx.Languages.Uml.Model", "Uml", "http://www.omg.org/spec/UML");
                File.WriteAllText("../../../Uml.txt", metaCode);
            }
            catch (ModelException mex)
            {
                Console.WriteLine(mex.Diagnostic.ToString());
            }
        }
        //*/

        /*/
        public static void UmlXmiTest()
        {
            UmlDescriptor.Initialize();

            string fileName = "../../../Uml.xmi";

            try
            {
                var xmi = new UmlXmiSerializer();
                var readOptions = new UmlXmiReadOptions();
                readOptions.IgnoredNamespaces.Add("http://www.omg.org/spec/MOF/20131001");
                var modelGroup = xmi.ReadModelGroupFromFile(fileName, readOptions);
                Console.WriteLine(modelGroup);
                var writeOptions = new UmlXmiWriteOptions();
                int i = 0;
                foreach (var model in modelGroup.Models)
                {
                    writeOptions.ModelToFileMap.Add(model, "../../../file" + i + ".xmi");
                    ++i;
                }
                xmi.WriteModelGroupToFile(modelGroup, writeOptions);
                //var xmiCode = xmi.WriteModelGroup(modelGroup);
                UmlModelToMetaModelGenerator mgen = new UmlModelToMetaModelGenerator(modelGroup.Objects);
                string metaCode = mgen.Generate("MetaDslx.Languages.Uml.Model", "Uml", "http://www.omg.org/spec/UML");
                File.WriteAllText("../../../Uml.txt", metaCode);
            }
            catch (ModelException mex)
            {
                Console.WriteLine(mex.Diagnostic.ToString());
            }
        }
        //*/


        /*/
        public static void EcoreXmiTest()
        {
            EcoreDescriptor.Initialize();

            string fileName = "../../../RailDsl.ecore";

            try
            {
                var xmi = new EcoreXmiSerializer();
                var emodel = xmi.ReadModelFromFile(fileName);
                Console.WriteLine(emodel);
                xmi.WriteModelToFile("../../../RailDsl2.ecore", emodel);
                var metaModel = EcoreModelConverter.ToMetaModel(emodel);
                var gen = new MetaModelGenerator(metaModel.Objects);
                string metaCode = gen.Generate(metaModel.Objects.OfType<MetaModel>().First());
                File.WriteAllText("../../../RailDsl.mm", metaCode);
                //MofModelToMetaModelGenerator mgen = new MofModelToMetaModelGenerator(model.Objects);
                //string metaCode = mgen.Generate("MetaDslx.Languages.Uml.Model", "Uml", "http://www.omg.org/spec/UML/20161101");
                //File.WriteAllText("../../../Uml.txt", metaCode);
            }
            catch (ModelException mex)
            {
                Console.WriteLine(mex.Diagnostic.ToString());
            }
        }
        //*/

        /*/
        public static void MetaDslxXmiTest()
        {
            MetaDescriptor.Initialize();

            string fileName = "../../../RailDsl.ecore";

            try
            {
                var xmi = new MetaXmiSerializer();
                var model = xmi.ReadModelFromFile(fileName);
                Console.WriteLine(model);
                xmi.WriteModelToFile("../../../RailDsl2.ecore", model);
                //MofModelToMetaModelGenerator mgen = new MofModelToMetaModelGenerator(model.Objects);
                //string metaCode = mgen.Generate("MetaDslx.Languages.Uml.Model", "Uml", "http://www.omg.org/spec/UML/20161101");
                //File.WriteAllText("../../../Uml.txt", metaCode);
            }
            catch (ModelException mex)
            {
                Console.WriteLine(mex.Diagnostic.ToString());
            }
        }
        //*/
    }
}
