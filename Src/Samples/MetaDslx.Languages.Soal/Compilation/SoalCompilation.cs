using MetaDslx.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Core;
using System.Collections.Immutable;
using MetaDslx.Compiler.Syntax;
using System.Threading;

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilation : Compilation
    {
        public SoalCompilation(
            string name, 
            ImmutableArray<ImmutableModel> references, 
            bool isSubmission, 
            AsyncQueue<CompilationEvent> eventQueue) 
            : base(
                  name, 
                  references, 
                  isSubmission, 
                  eventQueue)
        {
        }

        public override bool IsCaseSensitive
        {
            get
            {
                return true;
            }
        }

        public override Language Language
        {
            get
            {
                return SoalLanguage.Instance;
            }
        }

        public override MessageProvider MessageProvider
        {
            get
            {
                return SoalMessageProvider.Instance;
            }
        }

        protected override IMetaSymbol CommonGlobalNamespace
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override CompilationOptions CommonOptions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override ScriptCompilationInfo CommonScriptCompilationInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override ImmutableModelGroup CommonSourceModel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override IEnumerable<SyntaxTree> CommonSyntaxTrees
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int CompareSourceLocations(Location loc1, Location loc2)
        {
            throw new NotImplementedException();
        }

        public override bool ContainsSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateErrorTypeSymbol(IMetaSymbol container, string name, int arity)
        {
            throw new NotImplementedException();
        }

        public override bool FilterAndAppendAndFreeDiagnostics(DiagnosticBag accumulator, ref DiagnosticBag incoming)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetParseDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IMetaSymbol> GetSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override int GetSyntaxTreeOrdinal(SyntaxTree tree)
        {
            throw new NotImplementedException();
        }

        public override ImmutableModelGroup ToMetadataReference(ImmutableArray<string> aliases = default(ImmutableArray<string>))
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonAddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonClone()
        {
            throw new NotImplementedException();
        }

        protected override bool CommonContainsSyntaxTree(SyntaxTree syntaxTree)
        {
            throw new NotImplementedException();
        }

        protected override SemanticModel CommonGetSemanticModel(SyntaxTree syntaxTree, bool ignoreAccessibility)
        {
            throw new NotImplementedException();
        }

        protected override IMetaSymbol CommonGetTypeByMetadataName(string metadataName)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonRemoveAllSyntaxTrees()
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonRemoveSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonWithCompilationName(string compilationName)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonWithEventQueue(AsyncQueue<CompilationEvent> eventQueue)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonWithOptions(CompilationOptions options)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonWithReferences(IEnumerable<ImmutableModel> newReferences)
        {
            throw new NotImplementedException();
        }
    }
}
