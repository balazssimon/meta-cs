using MetaDslx.VisualStudio.Classification;
using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Commands
{
    internal class GoToDefinitionCommand : MetaDslxVsCommand
    {
        public GoToDefinitionCommand(ITextView textView, IServiceProvider serviceProvider) 
            : base(textView, serviceProvider)
        {
        }

        public void Execute()
        {
            var caret = TextView.Caret;
            var buffer = TextView.TextBuffer;
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
