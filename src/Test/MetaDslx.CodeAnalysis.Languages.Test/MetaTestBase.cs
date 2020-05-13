using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Languages.Test
{
    public abstract class MetaTestBase : DebugAssertUnitTest
    {
        protected MetaCompilation Compile(string filePath, bool assertEmptyDiagnostics = true, bool compileMetaModelCore = false)
        {
            MetaDescriptor.Initialize();
            string text = File.ReadAllText(filePath);
            var st = MetaSyntaxTree.ParseText(text);

            BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            if (compileMetaModelCore)
            {
                BinderFlags binderFlags2 = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
                binderFlags = binderFlags.UnionWith(binderFlags2);
            }
            MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: true, concurrentBuild: false,
                topLevelBinderFlags: binderFlags);
            var compilation = MetaCompilation.
                Create("MetaModelCompilation").
                AddSyntaxTrees(st).
                AddReferences(
                    ModelReference.CreateFromModel(MetaInstance.MModel)
                    ).
                WithOptions(options);
            compilation.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(compilation);
            return compilation;
        }

        protected void AssertEmptyDiagnostics(MetaCompilation compilation)
        {
            var diagnostics = compilation.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }
    }
}
