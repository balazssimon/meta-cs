using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
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
using Microsoft.CodeAnalysis;

namespace MetaDslx.VisualStudio.Classification
{
    internal class ErrorTagger : CompilationTagger, ITagger<IErrorTag>
    {
        internal readonly CompilationErrorsFactory Factory;

        public ErrorTagger(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, IWpfTextView wpfTextView)
            : base(mefServices, taggerProvider, wpfTextView)
        {
            this.Factory = new CompilationErrorsFactory(this);
            taggerProvider.AddCompilationErrorsFactory(this.Factory);
        }

        public static ErrorTagger GetOrCreate(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, IWpfTextView wpfTextView)
        {
            return wpfTextView.Properties.GetOrCreateSingletonProperty(() => new ErrorTagger(
                mefServices,
                taggerProvider,
                wpfTextView
            ));
        }

        public override void Dispose()
        {
            this.TaggerProvider.RemoveCompilationErrorsFactory(this.Factory);
            base.Dispose();
        }

        protected override void CompilationChanged(object sender, EventArgs e)
        {
            base.CompilationChanged(sender, e);
            var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
            this.Factory.UpdateErrors(this.BackgroundCompilation.FilePath, compilationSnapshot.Compilation);
            this.TaggerProvider.UpdateAllSinks();
        }

        public IEnumerable<ITagSpan<IErrorTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
            if (compilationSnapshot.Compilation == null) yield break;
            ImmutableArray<Diagnostic> diagnostics = compilationSnapshot.Compilation.GetDiagnostics();
            ITextSnapshot textSnapshot = compilationSnapshot.Text;
            if (textSnapshot == null || spans.Count == 0 || spans.First().Snapshot.Version != textSnapshot.Version) yield break;
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
                                errorType = PredefinedErrorTypeNames.SyntaxError;
                                break;
                            default:
                                break;
                        }
                        yield return new TagSpan<IErrorTag>(diagnosticSpan, new ErrorTag(errorType, diagnostic.GetMessage()));
                    }
                }
            }
        }

    }

}
