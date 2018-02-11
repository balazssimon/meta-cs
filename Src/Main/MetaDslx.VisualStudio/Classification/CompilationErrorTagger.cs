using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using Microsoft.VisualStudio.Shell.TableControl;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Adornments;
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
    public class CompilationErrorTagger : CompilationTagger, ITagger<IErrorTag>
    {
        private ImmutableArray<Diagnostic> diagnostics;
        internal readonly CompilationErrorsFactory Factory;

        public CompilationErrorTagger(CompilationTaggerProvider taggerProvider, ITextView textView, ITextBuffer buffer)
            : base(taggerProvider, textView, buffer)
        {
            this.Factory = new CompilationErrorsFactory(this, new CompilationErrorsSnapshot(string.Empty, 0, null, ImmutableArray<Diagnostic>.Empty));
            taggerProvider.AddCompilationErrorsFactory(this.Factory);
        }

        public override void Dispose()
        {
            this.TaggerProvider.RemoveCompilationErrorsFactory(this.Factory);
            base.Dispose();
        }

        public IEnumerable<ITagSpan<IErrorTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.CheckCompilationVersion();
            ImmutableArray<Diagnostic> diagnostics = this.diagnostics;
            ITextSnapshot textSnapshot = this.TextSnapshot;
            if (diagnostics != null)
            {
                foreach (var diagnostic in diagnostics)
                {
                    if (diagnostic.Severity == DiagnosticSeverity.Hidden) continue;
                    SnapshotSpan diagnosticSpan = new SnapshotSpan(textSnapshot, Span.FromBounds(diagnostic.Location.SourceSpan.Start, diagnostic.Location.SourceSpan.End));
                    if (spans.IntersectsWith(diagnosticSpan))
                    {
                        string errorType = PredefinedErrorTypeNames.HintedSuggestion;
                        switch (diagnostic.Severity)
                        {
                            case DiagnosticSeverity.Hidden:
                                break;
                            case DiagnosticSeverity.Info:
                                errorType = PredefinedErrorTypeNames.HintedSuggestion;
                                break;
                            case DiagnosticSeverity.Warning:
                                errorType = PredefinedErrorTypeNames.Warning;
                                break;
                            case DiagnosticSeverity.Error:
                                errorType = PredefinedErrorTypeNames.CompilerError;
                                break;
                            default:
                                break;
                        }
                        yield return new TagSpan<IErrorTag>(diagnosticSpan, new ErrorTag(errorType));
                    }
                }
            }
        }

        protected override void CompilationUpdated(ITextSnapshot newTextSnapshot, Compilation newCompilation, ITextSnapshot oldTextSnapshot, Compilation oldCompilation)
        {
            if (newCompilation != null)
            {
                ImmutableArray<Diagnostic> diagnostics = newCompilation.GetDiagnostics();
                ImmutableInterlocked.InterlockedExchange(ref this.diagnostics, diagnostics);
            }
            else
            {
                ImmutableInterlocked.InterlockedExchange(ref this.diagnostics, ImmutableArray<Diagnostic>.Empty);
            }
        }
    }

}
