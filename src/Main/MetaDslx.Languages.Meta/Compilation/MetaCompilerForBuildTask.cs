using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using MetaDslx.CodeGeneration;
using MetaDslx.CodeAnalysis.Symbols;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilerForBuildTask : CodeGenerator, ICompilerForBuildTask
    {
        private string _inputFilePath;
        private bool _compileMetaModelCore;
        private string _metaModelCoreNamespace;

        private MetaCompilation _compilation;

        public MetaCompilerForBuildTask(string manualOutputDirectory, string automaticOutputDirectory, string inputFilePath, bool compileMetaModelCore, string metaModelCoreNamespace)
            : base(manualOutputDirectory, automaticOutputDirectory)
        {
            _inputFilePath = inputFilePath;
            _compileMetaModelCore = compileMetaModelCore;
            _metaModelCoreNamespace = metaModelCoreNamespace;
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
                ImmutableModel coreModel = MetaInstance.MModel;
                string text = File.ReadAllText(_inputFilePath);
                var tree = MetaSyntaxTree.ParseText(text, path: _inputFilePath);

                BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
                if (_compileMetaModelCore)
                {
                    BinderFlags binderFlags2 = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
                    binderFlags = binderFlags.UnionWith(binderFlags2);
                }
                MetaCompilationOptions options = new MetaCompilationOptions(OutputKind.NetModule, deterministic: true, concurrentBuild: false).WithTopLevelBinderFlags(binderFlags);
                //MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule, deterministic: true, concurrentBuild: false);
                var compilation = MetaCompilation.
                    Create("MetaModelCompilation").
                    AddSyntaxTrees(tree).
                    AddReferences(
                        MetadataReference.CreateFromFile(typeof(Symbol).Assembly.Location),
                        ModelReference.CreateFromModel(coreModel)).
                    WithOptions(options);
                Interlocked.CompareExchange(ref _compilation, compilation, null);
            }
            _compilation.ForceComplete();
        }

        public void Generate()
        {
            if (!this.HasErrors)
            {
                var compiledModel = _compilation.Model as MutableModel;
                var immutableModel = compiledModel.ToImmutable();
                ImmutableMetaModelGenerator mmgen = new ImmutableMetaModelGenerator(immutableModel.Objects);
                mmgen.Properties.MetaNs = "global::" + _metaModelCoreNamespace;

                var bareFilePath = Path.ChangeExtension(_inputFilePath, null);

                var outputFilePath = bareFilePath + ".cs";
                string generatedCSharpModel = mmgen.Generate();
                this.WriteOutputFile(outputFilePath, generatedCSharpModel);

                string generatedCSharpModelImpl = mmgen.GenerateImplementation();
                var outputImplFilePath = bareFilePath + "Implementation.cs";
                this.WriteOutputFile(outputImplFilePath, generatedCSharpModelImpl, automatic: false);
            }
        }

        public ImmutableArray<Diagnostic> GetDiagnostics()
        {
            this.Compile();
            return _compilation.GetDiagnostics();
        }
    }
}
