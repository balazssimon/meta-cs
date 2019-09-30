using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Symbols;
using MetaDslx.CodeAnalysis.Binding;
using System;
using System.IO;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test
{
    public class UnitTest01
    {
        public UnitTest01()
        {
            TestLangOneDescriptor.Initialize();
        }

        [Fact]
        public void Test01File01()
        {
            string text = File.ReadAllText(@"..\..\..\InputFiles\Test01-File01.txt");
            var st = TestLangOneSyntaxTree.ParseText(text);
            var options = new TestLangOneCompilationOptions(TestLangOneLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility);
            var comp = TestLangOneCompilation.Create("Test01").WithOptions(options).AddSyntaxTrees(st);
            var model = comp.Model;
            var diagnostics = comp.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }

        [Fact]
        public void Test01File02()
        {
            string text = File.ReadAllText(@"..\..\..\InputFiles\Test01-File02.txt");
            var st = TestLangOneSyntaxTree.ParseText(text);
            var options = new TestLangOneCompilationOptions(TestLangOneLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility);
            var comp = TestLangOneCompilation.Create("Test01").WithOptions(options).AddSyntaxTrees(st);
            var model = comp.Model;
            var diagnostics = comp.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }

        [Fact]
        public void Test01File03()
        {
            string text = File.ReadAllText(@"..\..\..\InputFiles\Test01-File03.txt");
            var st = TestLangOneSyntaxTree.ParseText(text);
            var options = new TestLangOneCompilationOptions(TestLangOneLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility);
            var comp = TestLangOneCompilation.Create("Test01").WithOptions(options).AddSyntaxTrees(st);
            var model = comp.Model;
            var diagnostics = comp.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }
    }
}
