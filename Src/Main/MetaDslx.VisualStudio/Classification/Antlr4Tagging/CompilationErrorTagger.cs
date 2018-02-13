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

namespace MetaDslx.VisualStudio.Classification.Antlr4Tagging
{
    internal class CompilationErrorTagger<TLexer, TParser> : CompilationTagger<TLexer, TParser>, ITagger<IErrorTag>
        where TLexer : Antlr4.Runtime.Lexer
        where TParser : Antlr4.Runtime.Parser
    {
        internal readonly CompilationErrorsFactory<TLexer, TParser> Factory;

        public CompilationErrorTagger(CompilationTaggerProvider<TLexer, TParser> taggerProvider, BackgroundCompilation<TLexer, TParser> backgroundCompilation)
            : base(taggerProvider, backgroundCompilation)
        {
            this.Factory = new CompilationErrorsFactory<TLexer, TParser>(this, new CompilationErrorsSnapshot<TLexer, TParser>(backgroundCompilation.FilePath, 0, backgroundCompilation.CompilationSnapshot));
            taggerProvider.AddCompilationErrorsFactory(this.Factory);
        }

        public override void Dispose()
        {
            this.TaggerProvider.RemoveCompilationErrorsFactory(this.Factory);
            base.Dispose();
        }

        protected override void CompilationChanged(object sender, CompilationChangedEventArgs<TLexer, TParser> e)
        {
            base.CompilationChanged(sender, e);
            this.Factory.UpdateErrors(this.BackgroundCompilation.FilePath, this.BackgroundCompilation.CompilationSnapshot);
        }

        public IEnumerable<ITagSpan<IErrorTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.BackgroundCompilation.CheckCompilationVersion();
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

    }

}
