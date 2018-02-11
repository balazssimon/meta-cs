using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class BackgroundCompilation : IDisposable
    {
        private CompilationTaggerProvider provider;
        private WeakReference<ITextBuffer> textBuffer;

        private CompilationSnapshot compilationSnapshot;
        private CancellationTokenSource cancellationTokenSource;

        public BackgroundCompilation(CompilationTaggerProvider provider, ITextBuffer textBuffer)
        {
            this.provider = provider;
            this.textBuffer = new WeakReference<ITextBuffer>(textBuffer);
            this.cancellationTokenSource = new CancellationTokenSource();
            this.compilationSnapshot = MetaDslx.VisualStudio.Classification.CompilationSnapshot.Default;
        }

        public void Dispose()
        {
            this.cancellationTokenSource.Cancel();
            this.cancellationTokenSource.Dispose();
        }

        public event EventHandler<CompilationChangedEventArgs> CompilationChanged;

        public ITextBuffer TextBuffer
        {
            get
            {
                ITextBuffer result;
                if (this.textBuffer.TryGetTarget(out result))
                {
                    return result;
                }
                return null;
            }
        }

        public ITextDocument TextDocument
        {
            get
            {
                ITextBuffer textBuffer = TextBuffer;
                if (textBuffer == null)
                    return null;

                ITextDocument textDocument;
                if (!this.provider.TextDocumentFactoryService.TryGetTextDocument(textBuffer, out textDocument))
                    return null;

                return textDocument;
            }
        }

        public string FilePath
        {
            get
            {
                ITextDocument textDocument = this.TextDocument;
                if (textDocument != null)
                {
                    return textDocument.FilePath;
                }
                return null;
            }
        }

        public CompilationSnapshot CompilationSnapshot
        {
            get { return this.compilationSnapshot; }
        }

        public void CheckCompilationVersion()
        {
            ITextSnapshot textSnapshot = this.TextBuffer?.CurrentSnapshot;
            if (this.compilationSnapshot == null || this.compilationSnapshot.Changed(textSnapshot))
            {
                this.Compile();
            }
        }

        public void Compile()
        {
            this.cancellationTokenSource.Cancel();
            this.cancellationTokenSource.Dispose();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.BackgroundCompile();
            // TODO: Task.Run(() => this.BackgroundCompile());
        }

        public void Cancel()
        {
            this.cancellationTokenSource.Cancel();
        }

        private void BackgroundCompile()
        {
            ITextBuffer textBuffer = this.TextBuffer;
            if (textBuffer == null) return;
            ITextSnapshot textSnapshot = textBuffer.CurrentSnapshot;
            if (this.compilationSnapshot.Changed(textSnapshot))
            {
                string filePath = this.FilePath;
                string sourceText = textSnapshot.GetText();
                var versionBefore = textSnapshot.Version;
                var compilation = this.provider.Compile(filePath, sourceText, this.cancellationTokenSource.Token);
                if (this.compilationSnapshot == null || compilation != null)
                {
                    textSnapshot = textBuffer.CurrentSnapshot;
                    var versionAfter = textSnapshot.Version;
                    if (versionAfter == versionBefore)
                    {
                        CompilationSnapshot oldCompilation = this.compilationSnapshot;
                        Interlocked.Exchange(ref this.compilationSnapshot, this.compilationSnapshot.Update(textSnapshot, compilation));
                        this.CompilationChanged?.Invoke(this, new CompilationChangedEventArgs(oldCompilation, this.compilationSnapshot));
                    }
                }
            }
        }
    }

    internal class CompilationChangedEventArgs
    {
        public CompilationChangedEventArgs(CompilationSnapshot oldCompilation, CompilationSnapshot newCompilation)
        {
            this.OldCompilation = oldCompilation;
            this.NewCompilation = newCompilation;
        }

        public CompilationSnapshot OldCompilation { get; private set; }
        public CompilationSnapshot NewCompilation { get; private set; }
    }
}
