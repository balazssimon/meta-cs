using MetaDslx.CodeAnalysis;
using MetaDslx.VisualStudio.Utilities;
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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Compilation
{
    public sealed class BackgroundCompilation : IDisposable
    {
        private readonly ITextView _textView;
        private readonly MetaDslxMefServices _mefServices;

        private CompilationSnapshot _compilationSnapshot;
        private CompilationSnapshot _backgroundCompilationSnapshot;
        private ITextVersion _backgroundVersion;
        private CancellationTokenSource _cancellationTokenSource;

        private BackgroundWorker _backgroundWorker;

        private IBackgroundCompilationFactory _compilationFactory;
        private List<IBackgroundCompilationStep> _compilationSteps;

        private BackgroundCompilation(MetaDslxMefServices mefServices, ITextView textView)
        {
            _textView = textView;
            _mefServices = mefServices;

            _cancellationTokenSource = new CancellationTokenSource();
            _compilationSnapshot = CompilationSnapshot.Default;
            _backgroundCompilationSnapshot = CompilationSnapshot.Default;
        }

        public static BackgroundCompilation GetOrCreate(MetaDslxMefServices mefServices, ITextView textView)
        {
            return textView.Properties.GetOrCreateSingletonProperty(typeof(BackgroundCompilation), () => new BackgroundCompilation(mefServices, textView));
        }

        public MetaDslxMefServices MefServices => _mefServices;

        public event EventHandler<CompilationChangedEventArgs> CompilationChanged;

        public CompilationSnapshot CompilationSnapshot => _compilationSnapshot;

        public ITextBuffer TextBuffer => _textView.TextBuffer;

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
                var factory = _mefServices.GetService<IBackgroundCompilationFactory>(_textView.TextBuffer.ContentType);
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
                if (disposing)
                {
                    _cancellationTokenSource.Cancel();
                    _cancellationTokenSource.Dispose();
                }
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

        public void CheckCompilationVersion()
        {
            ITextVersion textVersion = this.TextBuffer?.CurrentSnapshot?.Version;
            if (_backgroundVersion == null || _backgroundVersion != textVersion)
            {
                Interlocked.Exchange(ref _backgroundVersion, textVersion);
                if (this.GetCompilationFactory() != null) this.Compile();
            }
        }

        private void Compile()
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
            try
            {
                if (_backgroundWorker != null)
                {
                    _backgroundWorker.DoWork -= BackgroundWorker_DoWork;
                    _backgroundWorker.RunWorkerCompleted -= BackgroundWorker_RunWorkerCompleted;
                    _backgroundWorker.Dispose();
                    _backgroundWorker = null;
                }
            }
            catch (Exception)
            {
                // nop
            }
            _cancellationTokenSource = new CancellationTokenSource();
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync(null);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompilationSnapshot oldCompilation = _backgroundCompilationSnapshot;
            if (_compilationSnapshot != oldCompilation)
            {
                Interlocked.Exchange(ref _compilationSnapshot, _backgroundCompilationSnapshot);
                var tempEvent = this.CompilationChanged;
                tempEvent?.Invoke(this, new CompilationChangedEventArgs(oldCompilation, _compilationSnapshot));
            }
            if (e.Result != null)
            {
                var steps = this.GetCompilationSteps();
                int index = (int)e.Result;
                if (index < steps.Count)
                {
                    try
                    {
                        if (_backgroundWorker != null)
                        {
                            _backgroundWorker.DoWork -= BackgroundWorker_DoWork;
                            _backgroundWorker.RunWorkerCompleted -= BackgroundWorker_RunWorkerCompleted;
                            _backgroundWorker.Dispose();
                            _backgroundWorker = new BackgroundWorker();
                            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
                            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
                            _backgroundWorker.RunWorkerAsync(index);
                        }
                    }
                    catch (Exception)
                    {
                        // nop
                    }
                }
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                ITextBuffer textBuffer = this.TextBuffer;
                if (textBuffer == null) return;
                ITextSnapshot textSnapshot = textBuffer.CurrentSnapshot;
                if (_backgroundCompilationSnapshot.Changed(textSnapshot))
                {
                    string filePath = this.FilePath;
                    string sourceText = textSnapshot.GetText();
                    var versionBefore = textSnapshot.Version;
                    var cancellationToken = _cancellationTokenSource.Token;
                    var compilation = this.GetCompilationFactory().CreateCompilation(this, filePath, sourceText, cancellationToken);
                    if (_backgroundCompilationSnapshot == null || compilation != null)
                    {
                        compilation.ForceComplete(cancellationToken);
                        if (cancellationToken.IsCancellationRequested) return;
                        textSnapshot = textBuffer.CurrentSnapshot;
                        var versionAfter = textSnapshot.Version;
                        if (versionAfter == versionBefore)
                        {
                            Interlocked.Exchange(ref _backgroundCompilationSnapshot, _backgroundCompilationSnapshot.Update(textSnapshot, compilation, ImmutableDictionary<object, object>.Empty));
                            e.Result = 0;
                        }
                    }
                }
            }
            else
            {
                int index = (int)e.Argument;
                var steps = this.GetCompilationSteps();
                if (index < steps.Count)
                {
                    var step = steps[index];
                    var cancellationToken = _cancellationTokenSource.Token;
                    ITextBuffer textBuffer = this.TextBuffer;
                    if (textBuffer == null) return;
                    ITextSnapshot textSnapshot = textBuffer.CurrentSnapshot;
                    var snaphsotBefore = _backgroundCompilationSnapshot;
                    if (!snaphsotBefore.Changed(textSnapshot))
                    {
                        var result = step.Execute(snaphsotBefore.Compilation, cancellationToken);
                        if (cancellationToken.IsCancellationRequested) return;
                        if (!snaphsotBefore.Changed(textSnapshot))
                        {
                            Interlocked.Exchange(ref _backgroundCompilationSnapshot, _backgroundCompilationSnapshot.Update(snaphsotBefore.Text, snaphsotBefore.Compilation, snaphsotBefore.CompilationStepResults.Add(step.ResultKey, result)));
                            e.Result = index + 1;
                        }
                    }
                }
            }
        }
    }


}
