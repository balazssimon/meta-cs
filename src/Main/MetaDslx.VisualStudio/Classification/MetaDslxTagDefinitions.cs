using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.Classification
{
    internal class MetaDslxTagDefinitions
    {
        [Name(MetaDslxTagTypes.GoToDefinitionLink), Export]
        internal ClassificationTypeDefinition MetaDslxGoToDefinitionLinkClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaDslxTagTypes.GoToDefinitionLink)]
        [Name("MetaDslx/GoToDefinitionLinkFormatDefinition")]
        internal sealed class MetaDslxGoToDefinitionLinkClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaDslxGoToDefinitionLinkClassificationFormat()
            {
                this.ForegroundColor = Colors.Blue;
                this.TextDecorations = new System.Windows.TextDecorationCollection();
                this.TextDecorations.Add(System.Windows.TextDecorations.Underline);
                this.DisplayName = "MetaDslx Go To Definition Link";
            }
        }


        [Name(MetaDslxTagTypes.HighlightWord), Export]
        internal MarkerFormatDefinition HighlightWordClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name("MarkerFormatDefinition/HighlightWordFormatDefinition")]
        [UserVisible(true)]
        internal sealed class HighlightWordFormatDefinition : MarkerFormatDefinition
        {
            public HighlightWordFormatDefinition()
            {
                this.BackgroundColor = Color.FromRgb(219, 224, 204);
                this.ForegroundColor = Colors.DarkBlue;
                this.DisplayName = "Highlight Word";
                this.ZOrder = 5;
            }
        }
    }

    internal class HighlightWordTag : TextMarkerTag
    {
        public HighlightWordTag()
            : base("MarkerFormatDefinition/HighlightWordFormatDefinition")
        {
        }
    }
}
