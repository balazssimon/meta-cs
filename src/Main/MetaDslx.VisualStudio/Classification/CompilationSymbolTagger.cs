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
        public CompilationSymbolTagger(CompilationTaggerProvider taggerProvider, ITextView textView, BackgroundCompilation backgroundCompilation)
            : base(taggerProvider, textView, backgroundCompilation)
        {

        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.BackgroundCompilation.CheckCompilationVersion();
            var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
            var symbols = compilationSnapshot?.GetCompilationStepResult<CollectSymbolsResult>(CollectSymbolsStep.Key);
            if (symbols == null) yield break;
            ITextSnapshot textSnapshot = compilationSnapshot.Text;
            if (textSnapshot == null || spans.Count == 0 || spans.First().Snapshot.Version != textSnapshot.Version) yield break;
            foreach (var token in symbols.TokensWithSymbols)
            {
                var tokenSpan = new SnapshotSpan(textSnapshot, new Span(token.Span.Start, token.Span.Length));
                if (spans.IntersectsWith(tokenSpan))
                {
                    var tag = symbols.GetClassificationTag(token);
                    if (tag != null)
                    {
                        yield return new TagSpan<IClassificationTag>(tokenSpan, tag);
                    }
                }
            }
        }


    }
}
