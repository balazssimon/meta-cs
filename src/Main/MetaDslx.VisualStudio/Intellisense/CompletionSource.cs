using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Operations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.Intellisense
{
    public class CompletionSource : ICompletionSource
    {
        private readonly MetaDslxMefServices _mefServices;
        private readonly MetaDslxCompletionSourceProvider _provider;
        private readonly ITextBuffer _textBuffer;
        private readonly BackgroundCompilation _backgroundCompilation;
        private List<Completion> _compList;

        public CompletionSource(MetaDslxMefServices mefServices, MetaDslxCompletionSourceProvider provider, ITextBuffer textBuffer)
        {
            _mefServices = mefServices;
            _provider = provider;
            _textBuffer = textBuffer;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, textBuffer);
        }

        public static CompletionSource GetOrCreate(MetaDslxMefServices mefServices, MetaDslxCompletionSourceProvider provider, ITextBuffer textBuffer)
        {
            textBuffer.Properties.TryGetProperty<IClassifier>(typeof(IClassifier), out var classifier);
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new CompletionSource(
                mefServices,
                provider,
                textBuffer
            ));
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            if (_isDisposed) throw new ObjectDisposedException("CompletionSource");

            ITextSnapshot snapshot = _textBuffer.CurrentSnapshot;
            var triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
            if (triggerPoint == null) return;

            var compilation = (LanguageCompilation)_backgroundCompilation.CompilationSnapshot.Compilation;
            if (compilation == null) return;

            var syntaxTree = (LanguageSyntaxTree)compilation.SyntaxTrees.FirstOrDefault();
            if (syntaxTree == null) return;

            var language = compilation.Language;
            SyntaxNode root;
            if (syntaxTree.TryGetRoot(out root))
            {
                var syntaxFacts = language.SyntaxFacts;
                var results = CompletionResult.Create(compilation, syntaxTree, triggerPoint.Position);
                var applicableTo = triggerPoint.Snapshot.CreateTrackingSpan(triggerPoint.Position, 0, SpanTrackingMode.EdgeInclusive);
                var completions = results.CompletionItems.Select(ci => new Completion(ci.Name));
                completionSets.Add(new CompletionSet("All", "All", applicableTo, completions, Enumerable.Empty<Completion>()));
            }
        }

        #region IDisposable Support
        private bool _isDisposed;
        public void Dispose()
        {
            if (!_isDisposed)
            {
                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
        }
        #endregion
    }
}
