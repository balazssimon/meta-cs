using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Languages.Test.Languages.WebSequenceDiagrams;
using MetaDslx.CodeAnalysis.Languages.Test.Languages.WebSequenceDiagrams.Model;
using MetaDslx.Tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Languages.Test
{
    public abstract class WebSequenceDiagramsTestBase : DebugAssertUnitTest
    {
        protected SequenceCompilation Compile(string fileId, bool assertEmptyDiagnostics = true)
        {
            UmlDescriptor.Initialize();
            string text = File.ReadAllText($@"..\..\..\InputFiles\WebSequenceDiagrams\{fileId}.wsd");
            var st = SequenceSyntaxTree.ParseText(text);
            var options = new SequenceCompilationOptions(SequenceLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility, concurrentBuild: false);
            var comp = SequenceCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp);
            return comp;
        }

        protected void AssertEmptyDiagnostics(SequenceCompilation compilation)
        {
            var diagnostics = compilation.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }
    }
}
