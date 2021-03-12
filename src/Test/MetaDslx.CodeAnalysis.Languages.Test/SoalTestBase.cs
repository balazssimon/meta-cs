using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Languages.Test.Languages.Soal;
using MetaDslx.CodeAnalysis.Languages.Test.Languages.Soal.Model;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Languages.Test
{
    public abstract class SoalTestBase : DebugAssertUnitTest
    {
        protected SoalCompilation Compile(string fileId, bool assertEmptyDiagnostics = true)
        {
            SoalDescriptor.Initialize();
            string text = File.ReadAllText($@"..\..\..\InputFiles\Soal\{fileId}.soal");
            var st = SoalSyntaxTree.ParseText(text);
            var options = new SoalCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility/*, concurrentBuild: false, deterministic: true*/);
            var comp = SoalCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st).AddReferences(ModelReference.CreateFromModel(SoalInstance.MModel));
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp);
            return comp;
        }

        protected void AssertEmptyDiagnostics(SoalCompilation compilation)
        {
            var diagnostics = compilation.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }
    }
}
