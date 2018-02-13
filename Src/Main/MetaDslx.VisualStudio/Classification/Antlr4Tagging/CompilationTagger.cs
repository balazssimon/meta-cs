using MetaDslx.Compiler;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification.Antlr4Tagging
{
    internal abstract class CompilationTagger<TLexer, TParser> : IDisposable
        where TLexer : Antlr4.Runtime.Lexer
        where TParser : Antlr4.Runtime.Parser
    {
        private CompilationTaggerProvider<TLexer, TParser> taggerProvider;
        private BackgroundCompilation<TLexer, TParser> backgroundCompilation;

        public CompilationTagger(CompilationTaggerProvider<TLexer, TParser> taggerProvider, BackgroundCompilation<TLexer, TParser> backgroundCompilation)
        {
            this.taggerProvider = taggerProvider;
            this.backgroundCompilation = backgroundCompilation;
            this.backgroundCompilation.CompilationChanged += CompilationChanged;
        }

        protected virtual void CompilationChanged(object sender, CompilationChangedEventArgs<TLexer, TParser> e)
        {
            ITextSnapshot textSnapshot = e.NewCompilation.Text;
            this.TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(new SnapshotSpan(textSnapshot, Span.FromBounds(0, textSnapshot.Length))));
        }

        public virtual void Dispose()
        {
        }

        public CompilationTaggerProvider<TLexer, TParser> TaggerProvider
        {
            get { return this.taggerProvider; }
        }

        public BackgroundCompilation<TLexer, TParser> BackgroundCompilation
        {
            get { return this.backgroundCompilation; }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

    }
}
