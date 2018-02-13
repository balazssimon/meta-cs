using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification.Antlr4Tagging
{
    internal class CompilationSymbolTagger<TLexer, TParser> : CompilationTagger<TLexer, TParser>, ITagger<IClassificationTag>
        where TLexer : Antlr4.Runtime.Lexer
        where TParser : Antlr4.Runtime.Parser
    {
        public CompilationSymbolTagger(CompilationTaggerProvider<TLexer, TParser> taggerProvider, BackgroundCompilation<TLexer, TParser> backgroundCompilation)
            : base(taggerProvider, backgroundCompilation)
        {

        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.BackgroundCompilation.CheckCompilationVersion();
            var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
            var compilation = compilationSnapshot.Compilation;
            if (compilation == null) return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
            // TODO
            return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
        }


    }
}
