using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
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
        private CompilationSnapshot backgroundCompilationSnapshot;
        private ITextVersion backgroundVersion;
        private CancellationTokenSource cancellationTokenSource;

        private BackgroundWorker backgroundWorker;

        public BackgroundCompilation(CompilationTaggerProvider provider, ITextBuffer textBuffer)
        {
            this.provider = provider;
            this.textBuffer = new WeakReference<ITextBuffer>(textBuffer);
            this.cancellationTokenSource = new CancellationTokenSource();
            this.compilationSnapshot = MetaDslx.VisualStudio.Classification.CompilationSnapshot.Default;
            this.backgroundCompilationSnapshot = MetaDslx.VisualStudio.Classification.CompilationSnapshot.Default;
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
            ITextVersion textVersion = this.TextBuffer?.CurrentSnapshot?.Version;
            if (this.backgroundVersion == null || this.backgroundVersion != textVersion)
            {
                Interlocked.Exchange(ref this.backgroundVersion, textVersion);
                this.Compile();
            }
        }

        private void Compile()
        {
            try
            {
                this.cancellationTokenSource.Cancel();
                this.cancellationTokenSource.Dispose();
                this.cancellationTokenSource = null;
            }
            catch(Exception)
            {
                // nop
            }
            try
            {
                if (this.backgroundWorker != null)
                {
                    this.backgroundWorker.Dispose();
                    this.backgroundWorker = null;
                }
            }
            catch (Exception)
            {
                // nop
            }
            this.cancellationTokenSource = new CancellationTokenSource();
            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.DoWork += BackgroundWorker_DoWork;
            this.backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            this.backgroundWorker.RunWorkerAsync();
            //this.BackgroundCompile();
            //Task.Run(() => this.BackgroundCompile());
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompilationSnapshot oldCompilation = this.backgroundCompilationSnapshot;
            if (this.compilationSnapshot != oldCompilation)
            {
                Interlocked.Exchange(ref this.compilationSnapshot, this.backgroundCompilationSnapshot);
                this.CompilationChanged?.Invoke(this, new CompilationChangedEventArgs(oldCompilation, this.compilationSnapshot));
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.BackgroundCompile();
        }

        private void BackgroundCompile()
        {
            ITextBuffer textBuffer = this.TextBuffer;
            if (textBuffer == null) return;
            ITextSnapshot textSnapshot = textBuffer.CurrentSnapshot;
            if (this.backgroundCompilationSnapshot.Changed(textSnapshot))
            {
                string filePath = this.FilePath;
                string sourceText = textSnapshot.GetText();
                var versionBefore = textSnapshot.Version;
                var compilation = this.provider.Compile(filePath, sourceText, this.cancellationTokenSource.Token);
                if (this.backgroundCompilationSnapshot == null || compilation != null)
                {
                    textSnapshot = textBuffer.CurrentSnapshot;
                    var versionAfter = textSnapshot.Version;
                    if (versionAfter == versionBefore)
                    {
                        Interlocked.Exchange(ref this.backgroundCompilationSnapshot, this.backgroundCompilationSnapshot.Update(textSnapshot, compilation, this.GetSymbolTokens(compilation)));
                        //Interlocked.Exchange(ref this.compilationSnapshot, this.backgroundCompilationSnapshot);
                    }
                }
            }
        }

        private Dictionary<SyntaxToken, IClassificationTag> GetSymbolTokens(Compilation compilation)
        {
            Dictionary<SyntaxToken, IClassificationTag> result = new Dictionary<SyntaxToken, IClassificationTag>();
            SyntaxTree syntaxTree = compilation.SyntaxTrees.FirstOrDefault();
            if (syntaxTree == null) return result;
            SyntaxNode root;
            if (syntaxTree.TryGetRoot(out root))
            {
                SemanticModel semanticModel = compilation.GetSemanticModel(syntaxTree);
                foreach (var token in root.DescendantTokens())
                {
                    var tag = this.provider.GetTokenClassificationTag(token, syntaxTree, compilation, semanticModel);
                    if (tag != null)
                    {
                        result.Add(token, tag);
                    }
                }
                return result;
            }
            return result;
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
