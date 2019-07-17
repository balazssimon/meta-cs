using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilerForBuildTask : ICompilerForBuildTask
    {
        private string _inputFilePath;
        private string _outputDirectory;
        private string _outputFilePath;
        private bool _compileMetaModelCore;

        private MetaCompilation _compilation;

        public MetaCompilerForBuildTask(string inputFilePath, string outputDirectory, bool compileMetaModelCore)
        {
            _inputFilePath = inputFilePath;
            _outputDirectory = outputDirectory;
            _outputFilePath = Path.Combine(_outputDirectory, Path.ChangeExtension(Path.GetFileName(_inputFilePath), ".cs"));
            _compileMetaModelCore = compileMetaModelCore;
        }

        public bool HasErrors
        {
            get
            {
                this.Compile();
                return _compilation.GetDiagnostics().Any(diag => diag.Severity == DiagnosticSeverity.Error);
            }
        }

        public void Compile()
        {
            if (_compilation == null)
            {
                ImmutableModel coreModel = MetaInstance.Model;
                string text = File.ReadAllText(_inputFilePath);
                var tree = MetaSyntaxTree.ParseText(text);

                BinderFlags binderFlags = null;
                if (_compileMetaModelCore) binderFlags = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
                MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: false, concurrentBuild: true,
                    topLevelBinderFlags: binderFlags);
                //MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: true, concurrentBuild: false);
                var compilation = MetaCompilation.
                    Create("MetaModelCompilation").
                    AddSyntaxTrees(tree).
                    AddReferences(
                        ModelReference.CreateFromModel(coreModel)
                        ).
                    WithOptions(options);
                Interlocked.CompareExchange(ref _compilation, compilation, null);
            }
            _compilation.ForceComplete();
        }

        public void Generate()
        {
            if (!this.HasErrors)
            {
                var compiledModel = _compilation.Model;
                ImmutableMetaModelGenerator mmgen = new ImmutableMetaModelGenerator(compiledModel.Symbols);
                string generatedCSharpModel = mmgen.Generate();
                File.WriteAllText(_outputFilePath, generatedCSharpModel);
            }
        }

        public ImmutableArray<Diagnostic> GetDiagnostics()
        {
            this.Compile();
            return _compilation.GetDiagnostics();
        }

        public ImmutableArray<string> GetGeneratedFileList()
        {
            return this.HasErrors ? ImmutableArray<string>.Empty : ImmutableArray.Create(_outputFilePath);
        }
    }
}
