using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.VisualStudio.Utilities;
using MetaDslx.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Text;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Compilation
{
    public sealed class BackgroundCompilation : IDisposable
    {
        private readonly ITextBuffer _textBuffer;
        private readonly MetaDslxMefServices _mefServices;

        private TaskScheduler _synchronizationContext;

        private SourceText _sourceText;
        private ConcurrentQueue<ImmutableArray<TextChange>> _textChanges;
        private LanguageSyntaxTree _syntaxTree;
        private ManualResetEvent _syntaxTreeResetEvent;

        private CompilationSnapshot _compilationSnapshot;
        private CancellationTokenSource _cancellationTokenSource;

        private IBackgroundCompilationFactory _compilationFactory;
        private List<IBackgroundCompilationStep> _compilationSteps;

        private BackgroundCompilation(MetaDslxMefServices mefServices, ITextBuffer textBuffer)
        {
            _textBuffer = textBuffer;
            _textBuffer.Changed += TextBuffer_Changed;
            _sourceText = SourceText.From(_textBuffer.CurrentSnapshot.GetText());
            _syntaxTreeResetEvent = new ManualResetEvent(true);
            _textChanges = new ConcurrentQueue<ImmutableArray<TextChange>>();
            _mefServices = mefServices;

            _synchronizationContext = TaskScheduler.FromCurrentSynchronizationContext();
            _cancellationTokenSource = new CancellationTokenSource();
            _compilationSnapshot = CompilationSnapshot.Default;
        }

        private void TextBuffer_Changed(object sender, TextContentChangedEventArgs e)
        {
            var changes = ArrayBuilder<TextChange>.GetInstance();
            foreach (var change in e.Changes)
            {
                changes.Add(new TextChange(new MetaDslx.CodeAnalysis.Text.TextSpan(change.OldPosition, change.OldLength), change.NewText));
            }
            _textChanges.Enqueue(changes.ToImmutableAndFree());
            this.Recompile();
        }

        public static BackgroundCompilation GetOrCreate(MetaDslxMefServices mefServices, ITextBuffer textBuffer)
        {
            var result = textBuffer.Properties.GetOrCreateSingletonProperty(typeof(BackgroundCompilation), () => new BackgroundCompilation(mefServices, textBuffer));
            result.Recompile();
            return result;
        }

        public MetaDslxMefServices MefServices => _mefServices;

        public event EventHandler CompilationChanged;

        public CompilationSnapshot CompilationSnapshot => _compilationSnapshot;

        public ITextBuffer TextBuffer => _textBuffer;

        public ITextDocument TextDocument
        {
            get
            {
                ITextBuffer textBuffer = TextBuffer;
                if (textBuffer == null) return null;

                ITextDocument textDocument;
                if (textBuffer.Properties.TryGetProperty(typeof(ITextDocument), out textDocument))
                {
                    return textDocument;
                }
                else
                {
                    return null;
                }
            }
        }

        public string FilePath => TextDocument?.FilePath;

        private IBackgroundCompilationFactory GetCompilationFactory()
        {
            if (_compilationFactory == null)
            {
                var factory = _mefServices.GetService<IBackgroundCompilationFactory>(_textBuffer.ContentType);
                Interlocked.CompareExchange(ref _compilationFactory, factory, null);
            }
            return _compilationFactory;
        }

        private List<IBackgroundCompilationStep> GetCompilationSteps()
        {
            if (_compilationSteps == null)
            {
                var steps = GetCompilationFactory().CreateCompilationSteps(this).ToList();
                Interlocked.CompareExchange(ref _compilationSteps, steps, null);
            }
            return _compilationSteps;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _textBuffer.Changed -= TextBuffer_Changed;
                Cancel();
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion

        private void Recompile()
        {
            var compilationSnapshot = _compilationSnapshot;
            var textSnapshot = _textBuffer.CurrentSnapshot;
            if (compilationSnapshot != null && !compilationSnapshot.Changed(textSnapshot)) return;
            Cancel();
            var newCompilationSnapshot = new CompilationSnapshot(textSnapshot, null, null, ImmutableDictionary<object, object>.Empty);
            Interlocked.Exchange(ref _compilationSnapshot, newCompilationSnapshot);
            NotifyCompilationChanged();
            Compile();
        }

        private void Cancel()
        {
            try
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
            catch (Exception)
            {
                // nop
            }
        }

        private void Compile()
        {
            try
            {
                GetCompilationSteps(); // cache compilation steps
                _cancellationTokenSource = new CancellationTokenSource();
                Task.Run(() => SyntaxTreeWorker(_cancellationTokenSource.Token));
            }
            catch (Exception ex)
            {
                // nop
                Debug.WriteLine(ex.ToString());
            }
        }

        private void SyntaxTreeWorker(CancellationToken cancellationToken)
        {
            if (_syntaxTree == null || _textChanges.Count > 0)
            {
                var factory = this.GetCompilationFactory();
                var language = factory.Language;
                var textSnapshot = _textBuffer.CurrentSnapshot;
                var versionBefore = textSnapshot.Version;
                _syntaxTreeResetEvent.WaitOne();
                var sourceText = _sourceText;
                var syntaxTree = _syntaxTree;
                var oldCompilationSnapshot = _compilationSnapshot;
                try
                {
                    var allChanges = ArrayBuilder<TextChange>.GetInstance();
                    while (_textChanges.TryDequeue(out var changes))
                    {
                        allChanges.AddRange(changes);
                    }
                    if (syntaxTree == null)
                    {
                        allChanges.Free();
                        sourceText = SourceText.From(textSnapshot.GetText());
                        string filePath = this.FilePath;
                        syntaxTree = language.SyntaxFactory.ParseSyntaxTree(sourceText, language.SyntaxFactory.DefaultParseOptions/*.WithIncremental(true)*/, filePath);
                    }
                    else
                    {
                        sourceText = sourceText.WithChanges(allChanges);
                        allChanges.Free();
                        syntaxTree = (LanguageSyntaxTree)syntaxTree.WithChangedText(sourceText);
                    }
                    Interlocked.Exchange(ref _syntaxTree, syntaxTree);
                    Interlocked.Exchange(ref _sourceText, sourceText);
                    var compilationSnapshot = new CompilationSnapshot(textSnapshot, syntaxTree, null, ImmutableDictionary<object, object>.Empty);
                    Interlocked.Exchange(ref _compilationSnapshot, compilationSnapshot);
                    Task.Run(() => CompilationWorker(cancellationToken))
                        .ContinueWith(task => NotifyCompilationChanged(), CancellationToken.None, TaskContinuationOptions.None, _synchronizationContext);
                }
                catch (Exception ex)
                {
                    syntaxTree = null;
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    _syntaxTreeResetEvent.Set();
                }
            }
        }

        private void CompilationWorker(CancellationToken cancellationToken)
        {
            try
            {
                var factory = this.GetCompilationFactory();
                var compilationSnapshot = _compilationSnapshot;
                if (factory != null)
                {
                    var compilation = factory.CreateCompilation(this, ImmutableArray.Create(compilationSnapshot.SyntaxTree), cancellationToken);
                    if (compilationSnapshot == null || compilation != null)
                    {
                        if (cancellationToken.IsCancellationRequested) return;
                        compilation.ForceComplete(cancellationToken);
                        if (cancellationToken.IsCancellationRequested) return;
                        var newCompilationSnapshot = compilationSnapshot.Update(compilationSnapshot.Text, compilationSnapshot.SyntaxTree, compilation, ImmutableDictionary<object, object>.Empty);
                        Interlocked.Exchange(ref _compilationSnapshot, newCompilationSnapshot);
                        Task.Run(() => CompilationStepWorker(0, cancellationToken))
                            .ContinueWith(task => NotifyCompilationChanged(), CancellationToken.None, TaskContinuationOptions.None, _synchronizationContext);
                    }
                }
            }
            catch(Exception ex)
            {
                // nop
                Debug.WriteLine(ex.ToString());
            }
        }

        private void CompilationStepWorker(int stepIndex, CancellationToken cancellationToken)
        {
            try
            {
                var steps = this.GetCompilationSteps();
                if (stepIndex >= 0 && stepIndex < steps.Count)
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    var step = steps[stepIndex];
                    var compilationSnapshot = _compilationSnapshot;
                    var result = step.Execute(compilationSnapshot.Compilation, cancellationToken);
                    if (cancellationToken.IsCancellationRequested) return;
                    var newCompilationSnapshot = compilationSnapshot.Update(compilationSnapshot.Text, compilationSnapshot.SyntaxTree, compilationSnapshot.Compilation, compilationSnapshot.CompilationStepResults.Add(step.ResultKey, result));
                    Interlocked.Exchange(ref _compilationSnapshot, newCompilationSnapshot);
                    Task.Run(() => CompilationStepWorker(stepIndex + 1, cancellationToken))
                        .ContinueWith(task => NotifyCompilationChanged(), CancellationToken.None, TaskContinuationOptions.None, _synchronizationContext);
                }
            }
            catch (Exception ex)
            {
                // nop
                Debug.WriteLine(ex.ToString());
            }
        }

        private void NotifyCompilationChanged()
        {
            if (CompilationChanged != null) CompilationChanged(this, new EventArgs());
        }
    }

}
