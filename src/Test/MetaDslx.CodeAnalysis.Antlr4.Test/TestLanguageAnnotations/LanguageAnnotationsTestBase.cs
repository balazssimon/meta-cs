﻿using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLanguageAnnotations
{
    public class LanguageAnnotationsTestBase : DebugAssertUnitTest
    {
        protected TestLanguageAnnotationsCompilation Compile(string testId, string fileId, bool assertEmptyDiagnostics = true)
        {
            TestLanguageAnnotationsDescriptor.Initialize();
            string text = File.ReadAllText($@"..\..\..\InputFiles\LanguageAnnotations\Test{testId}-File{fileId}.txt");
            var st = TestLanguageAnnotationsSyntaxTree.ParseText(text);
            var options = new TestLanguageAnnotationsCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility/*, concurrentBuild: false*/);
            var comp = TestLanguageAnnotationsCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp);
            return comp;
        }

        protected void AssertEmptyDiagnostics(TestLanguageAnnotationsCompilation compilation)
        {
            var diagnostics = compilation.GetDiagnostics();
            if (diagnostics.Length > 0) Assert.Null(diagnostics[0]);
        }

    }
}
