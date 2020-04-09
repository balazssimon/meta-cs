using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Commands
{
    internal class GoToDefinitionCommand : MetaDslxVsCommand
    {
        private BackgroundCompilation _backgroundCompilation;

        public GoToDefinitionCommand(IWpfTextView textView, IVsTextView vsTextView, MetaDslxMefServices mefServices) 
            : base(textView, vsTextView, mefServices)
        {
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, textView.TextBuffer);
        }

        public void Execute()
        {
            var position = TextView.Caret.Position.BufferPosition.Position;
            var symbols = _backgroundCompilation.CompilationSnapshot.GetCompilationStepResult<CollectSymbolsResult>();
            if (symbols != null)
            {
                foreach (var token in symbols.TokensWithSymbols)
                {
                    if (token.Span.Contains(position))
                    {
                        this.GoToDefinition(token);
                        return;
                    }
                }
            }
        }

        public void GoToDefinition(SyntaxToken tokenWithSymbol, CollectSymbolsResult symbols = null)
        {
            if (tokenWithSymbol == null) return;
            if (symbols == null) symbols = _backgroundCompilation.CompilationSnapshot.GetCompilationStepResult<CollectSymbolsResult>();
            if (symbols != null)
            {
                var symbol = symbols.GetSymbol(tokenWithSymbol);
                SnapshotSpan extent;
                if (symbol != null)
                {
                    var location = symbol.Locations.FirstOrDefault();
                    if (location != null)
                    {
                        extent = new SnapshotSpan(TextView.TextSnapshot, location.SourceSpan.Start, location.SourceSpan.Length);
                    }
                    else
                    {
                        extent = new SnapshotSpan(TextView.TextSnapshot, tokenWithSymbol.Span.Start, tokenWithSymbol.Span.Length);
                    }
                }
                else
                {
                    extent = new SnapshotSpan(TextView.TextSnapshot, tokenWithSymbol.Span.Start, tokenWithSymbol.Span.Length);
                }
                TextView.Selection.Select(extent, false);
                TextView.Caret.MoveTo(TextView.Selection.ActivePoint);
                TextView.ViewScroller.EnsureSpanVisible(extent);
            }
        }
    }
}
