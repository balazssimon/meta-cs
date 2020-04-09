using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class ReferencesAdornmentTagger : IntraTextAdornmentTagger<ReferencesTag, ReferencesAdornment>
    {
        private MetaDslxMefServices _mefServices;
        private ITagAggregator<ReferencesTag> _referencesTagger;
        private MetaDslxTaggerProvider _taggerProvider;
        private BackgroundCompilation _backgroundCompilation;
        private SymbolReferencesResult _symbols;

        private ReferencesAdornmentTagger(MetaDslxMefServices mefServices, IWpfTextView wpfTextView, MetaDslxTaggerProvider taggerProvider, ITagAggregator<ReferencesTag> referencesTagger)
            : base(wpfTextView)
        {
            _mefServices = mefServices;
            _referencesTagger = referencesTagger;
            _taggerProvider = taggerProvider;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, wpfTextView.TextBuffer);
            _backgroundCompilation.CompilationChanged += CompilationChanged;
        }

        public static ReferencesAdornmentTagger GetOrCreate(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, IWpfTextView wpfTextView, Lazy<ITagAggregator<ReferencesTag>> referencesTagger)
        {
            return wpfTextView.Properties.GetOrCreateSingletonProperty(() => new ReferencesAdornmentTagger(
                mefServices,
                wpfTextView,
                taggerProvider,
                referencesTagger.Value
            ));
        }

        protected virtual void CompilationChanged(object sender, CompilationChangedEventArgs e)
        {
            var symbols = e.NewCompilation.GetCompilationStepResult<SymbolReferencesResult>();
            if (_symbols != symbols)
            {
                Interlocked.Exchange(ref _symbols, symbols);
                ITextSnapshot textSnapshot = e.NewCompilation.Text;
                this.RaiseTagsChanged(new SnapshotSpan(textSnapshot, Span.FromBounds(0, textSnapshot.Length)));
            }
        }

        public void Dispose()
        {
            _referencesTagger.Dispose();

            view.Properties.RemoveProperty(typeof(ReferencesAdornmentTagger));
        }

        // To produce adornments that don't obscure the text, the adornment tags
        // should have zero length spans. Overriding this method allows control
        // over the tag spans.
        protected override IEnumerable<Tuple<SnapshotSpan, PositionAffinity?, ReferencesTag>> GetAdornmentData(NormalizedSnapshotSpanCollection spans)
        {
            if (spans.Count == 0)
                yield break;

            ITextSnapshot snapshot = spans[0].Snapshot;

            var dataTags = _referencesTagger.GetTags(spans);

            foreach (IMappingTagSpan<ReferencesTag> dataTagSpan in dataTags)
            {
                NormalizedSnapshotSpanCollection dataTagSpans = dataTagSpan.Span.GetSpans(snapshot);

                // Ignore data tags that are split by projection.
                // This is theoretically possible but unlikely in current scenarios.
                if (dataTagSpans.Count != 1)
                    continue;

                SnapshotSpan adornmentSpan = new SnapshotSpan(dataTagSpans[0].End, 0);

                yield return Tuple.Create(adornmentSpan, (PositionAffinity?)PositionAffinity.Successor, dataTagSpan.Tag);
            }
        }

        protected override ReferencesAdornment CreateAdornment(ReferencesTag dataTag, SnapshotSpan span)
        {
            return new ReferencesAdornment(dataTag);
        }

        protected override bool UpdateAdornment(ReferencesAdornment adornment, ReferencesTag dataTag)
        {
            adornment.Update(dataTag);
            return true;
        }
    }
}
