using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using PilV2;
using Microsoft.CodeAnalysis;
using PilV2.Symbols;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using MetaDslx.Tests;

namespace MetaDslx.CodeAnalysis.Languages.Test
{
    public class PilTestBase : DebugAssertUnitTest
    {
        protected PilCompilation Compile(string fileId, bool assertEmptyDiagnostics = true)
        {
            PilDescriptor.Initialize();
            string text = File.ReadAllText($@"..\..\..\InputFiles\PilV2\{fileId}.pil2");
            var st = PilSyntaxTree.ParseText(text);
            var options = new PilCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility, concurrentBuild: false);
            var comp = PilCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st).AddReferences(ModelReference.CreateFromModel(PilInstance.MModel));
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp);
            return comp;
        }

        protected void AssertEmptyDiagnostics(PilCompilation compilation)
        {
            var diagnostics = compilation.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }
    }
}
