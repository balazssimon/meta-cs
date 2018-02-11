using MetaDslx.Compiler;
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
        public CompilationSymbolTagger(CompilationTaggerProvider taggerProvider, BackgroundCompilation backgroundCompilation)
            : base(taggerProvider, backgroundCompilation)
        {

        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.BackgroundCompilation.CheckCompilationVersion();
            return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
        }


    }
}
