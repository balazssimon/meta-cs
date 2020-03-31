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
            var buffer = TextView.TextBuffer;
            var symbols = _backgroundCompilation.CompilationSnapshot.GetCompilationStepResult<CollectSymbolsResult>(CollectSymbolsStep.Key);
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
            /*BackgroundCompilation compilation = buffer.Properties.GetOrCreateSingletonProperty(() => new BackgroundCompilation(this, buffer));
            var analysis = TextView.GetAnalysisAtCaret(_editorServices.Site);
            if (analysis != null && caret != null)
            {
                var defs = await analysis.Analyzer.AnalyzeExpressionAsync(analysis, caret.Value, ExpressionAtPointPurpose.FindDefinition);
                if (defs == null)
                {
                    return;
                }
                Dictionary<LocationInfo, SimpleLocationInfo> references, definitions, values;
                GetDefsRefsAndValues(analysis.Analyzer, _editorServices.Site, defs.Expression, defs.Variables, out definitions, out references, out values);

                if ((values.Count + definitions.Count) == 1)
                {
                    if (values.Count != 0)
                    {
                        foreach (var location in values.Keys)
                        {
                            GotoLocation(location);
                            break;
                        }
                    }
                    else
                    {
                        foreach (var location in definitions.Keys)
                        {
                            GotoLocation(location);
                            break;
                        }
                    }
                }
                else if (values.Count + definitions.Count == 0)
                {
                    if (String.IsNullOrWhiteSpace(defs.Expression))
                    {
                        MessageBox.Show(Strings.CannotGoToDefn, Strings.ProductTitle);
                    }
                    else
                    {
                        MessageBox.Show(Strings.CannotGoToDefn_Name.FormatUI(defs.Expression), Strings.ProductTitle);
                    }
                }
                else if (definitions.Count == 0)
                {
                    ShowFindSymbolsDialog(defs.Expression, new SymbolList(Strings.SymbolListValues, StandardGlyphGroup.GlyphForwardType, values.Values));
                }
                else if (values.Count == 0)
                {
                    ShowFindSymbolsDialog(defs.Expression, new SymbolList(Strings.SymbolListDefinitions, StandardGlyphGroup.GlyphLibrary, definitions.Values));
                }
                else
                {
                    ShowFindSymbolsDialog(defs.Expression,
                        new LocationCategory(
                            new SymbolList(Strings.SymbolListDefinitions, StandardGlyphGroup.GlyphLibrary, definitions.Values),
                            new SymbolList(Strings.SymbolListValues, StandardGlyphGroup.GlyphForwardType, values.Values)
                        )
                    );
                }
            }
            */
        }
    }
}
