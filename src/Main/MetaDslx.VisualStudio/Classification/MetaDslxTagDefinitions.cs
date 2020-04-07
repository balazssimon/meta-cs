﻿using Microsoft.VisualStudio.Text.Classification;
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
                //this.ForegroundColor = Colors.DarkBlue;
                this.DisplayName = "Highlight Word";
                this.ZOrder = 5;
            }
        }
    }
}
