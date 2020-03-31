using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal abstract class CompilationTagger : IDisposable
    {
        private ITextView _textView;
        private CompilationTaggerProvider _taggerProvider;
        private BackgroundCompilation _backgroundCompilation;
        private CollectSymbolsResult _symbols;

        public CompilationTagger(CompilationTaggerProvider taggerProvider, ITextView textView, BackgroundCompilation backgroundCompilation)
        {
            _taggerProvider = taggerProvider;
            _textView = textView;
            _backgroundCompilation = backgroundCompilation;
            _backgroundCompilation.CompilationChanged += CompilationChanged;
        }

        protected virtual void CompilationChanged(object sender, CompilationChangedEventArgs e)
        {
            var symbols = e.NewCompilation.GetCompilationStepResult<CollectSymbolsResult>(CollectSymbolsStep.Key);
            if (_symbols != symbols)
            {
                Interlocked.Exchange(ref _symbols, symbols);
                ITextSnapshot textSnapshot = e.NewCompilation.Text;
                this.TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(new SnapshotSpan(textSnapshot, Span.FromBounds(0, textSnapshot.Length))));
            }
        }

        public virtual void Dispose()
        {
        }

        public CompilationTaggerProvider TaggerProvider => _taggerProvider;

        public BackgroundCompilation BackgroundCompilation => _backgroundCompilation;

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

    }
}
