using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Symbols;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test
{
    public class TestLangOneTestBase : IDisposable
    {
        protected DebugAssertUnitTestTraceListener DebugAssertListener;

        public TestLangOneTestBase()
        {
            DebugAssertListener = new DebugAssertUnitTestTraceListener();
        }

        protected TestLangOneCompilation Compile(string testId, string fileId, bool assertEmptyDiagnostics = true)
        {
            TestLangOneDescriptor.Initialize();
            string text = File.ReadAllText($@"..\..\..\InputFiles\Test{testId}-File{fileId}.txt");
            var st = TestLangOneSyntaxTree.ParseText(text);
            var options = new TestLangOneCompilationOptions(TestLangOneLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility/*, concurrentBuild: false*/);
            var comp = TestLangOneCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp);
            return comp;
        }

        protected void AssertEmptyDiagnostics(TestLangOneCompilation compilation)
        {
            var diagnostics = compilation.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }

        public void Dispose()
        {
            DebugAssertListener.Dispose();
        }
    }
}
