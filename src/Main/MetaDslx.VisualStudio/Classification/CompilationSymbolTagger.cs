using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class CompilationSymbolTagger : CompilationTagger, ITagger<IClassificationTag>
    {
        public CompilationSymbolTagger(CompilationTaggerProvider taggerProvider, ITextView textView)
            : base(taggerProvider, textView)
        {

        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.BackgroundCompilation.CheckCompilationVersion();
            var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
            var symbolTokens = (Dictionary<SyntaxToken, IClassificationTag>)compilationSnapshot?.GetCompilationStepResult(CollectSymbolsStep.Key);
            if (symbolTokens == null) return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
            ITextSnapshot textSnapshot = compilationSnapshot.Text;
            if (textSnapshot == null || spans.Count == 0 || spans.First().Snapshot.Version != textSnapshot.Version) return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
            return symbolTokens.Select(t => new TagSpan<IClassificationTag>(new SnapshotSpan(textSnapshot, new Span(t.Key.Span.Start, t.Key.Span.Length)), t.Value));
        }


    }
}
