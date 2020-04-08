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
        private IWpfTextView _textView;
        private CompilationTaggerProvider _taggerProvider;
        private BackgroundCompilation _backgroundCompilation;
        private CollectSymbolsResult _symbols;

        public CompilationTagger(MetaDslxMefServices mefServices, CompilationTaggerProvider taggerProvider, IWpfTextView wpfTextView)
        {
            _taggerProvider = taggerProvider;
            _textView = wpfTextView;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, wpfTextView);
            _backgroundCompilation.CompilationChanged += CompilationChanged;
        }

        protected virtual void CompilationChanged(object sender, CompilationChangedEventArgs e)
        {
            var symbols = e.NewCompilation.GetCompilationStepResult<CollectSymbolsResult>();
            if (_symbols != symbols)
            {
                Interlocked.Exchange(ref _symbols, symbols);
                ITextSnapshot textSnapshot = e.NewCompilation.Text;
                this.TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(new SnapshotSpan(textSnapshot, Span.FromBounds(0, textSnapshot.Length))));
            }
        }

        protected virtual void OnTagsChanged(IEnumerable<SnapshotSpan> spans)
        {
            var tempEvent = this.TagsChanged;
            foreach (var span in spans)
            {
                tempEvent?.Invoke(this, new SnapshotSpanEventArgs(span));
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
