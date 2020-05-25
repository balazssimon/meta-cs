using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class ReferencesTagger : ITagger<ReferencesTag>
    {
        private ITextBuffer _textBuffer;
        private MetaDslxTaggerProvider _taggerProvider;
        private BackgroundCompilation _backgroundCompilation;
        private SymbolReferencesResult _symbols;

        public ReferencesTagger(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, ITextBuffer textBuffer)
        {
            _taggerProvider = taggerProvider;
            _textBuffer = textBuffer;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, textBuffer);
            _backgroundCompilation.CompilationChanged += CompilationChanged;
        }

        public static ReferencesTagger GetOrCreate(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new ReferencesTagger(
                mefServices,
                taggerProvider,
                textBuffer
            ));
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        protected virtual void CompilationChanged(object sender, EventArgs e)
        {
            var compilationSnapshot = _backgroundCompilation.CompilationSnapshot;
            var symbols = compilationSnapshot.GetCompilationStepResult<SymbolReferencesResult>();
            if (_symbols != symbols)
            {
                Interlocked.Exchange(ref _symbols, symbols);
                ITextSnapshot textSnapshot = compilationSnapshot.Text;
                this.TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(new SnapshotSpan(textSnapshot, Span.FromBounds(0, textSnapshot.Length))));
            }
        }

        public IEnumerable<ITagSpan<ReferencesTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            var compilationSnapshot = _backgroundCompilation.CompilationSnapshot;
            var symbols = compilationSnapshot?.GetCompilationStepResult<SymbolReferencesResult>();
            if (symbols == null) yield break;
            ITextSnapshot textSnapshot = compilationSnapshot.Text;
            if (textSnapshot == null || spans.Count == 0 || spans.First().Snapshot.Version != textSnapshot.Version) yield break;
            foreach (var symbol in symbols.Symbols)
            {
                var definitions = symbols.GetNameDefinitions(symbol);
                foreach (var defSpan in definitions)
                {
                    if (spans.IntersectsWith(defSpan))
                    {
                        var references = symbols.GetReferences(symbol);
                        yield return new TagSpan<ReferencesTag>(defSpan, new ReferencesTag(references));
                    }
                }
            }
        }


    }
}
