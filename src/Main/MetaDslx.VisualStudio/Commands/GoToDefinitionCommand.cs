using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
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

        public GoToDefinitionCommand(ITextView textView, IVsTextView vsTextView, MetaDslxMefServices mefServices) 
            : base(textView, vsTextView, mefServices)
        {
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, textView);
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
                        var symbol = symbols.GetSymbol(token);
                        if (symbol != null)
                        {
                            var location = symbol.Locations.FirstOrDefault();
                            if (location != null)
                            {
                                var mappedSpan = location.GetMappedLineSpan();
                                VsTextView.SetCaretPos(mappedSpan.EndLinePosition.Line, mappedSpan.EndLinePosition.Character);
                                VsTextView.CenterLines(mappedSpan.EndLinePosition.Line, 1);
                                VsTextView.SetSelection(mappedSpan.StartLinePosition.Line, mappedSpan.StartLinePosition.Character, mappedSpan.EndLinePosition.Line, mappedSpan.EndLinePosition.Character);
                            }
                        }
                    }
                }
            }
        }
    }
}
