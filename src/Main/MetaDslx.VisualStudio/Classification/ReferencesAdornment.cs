using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.Classification
{
    internal sealed class ReferencesAdornment : TextBlock
    {
        internal ReferencesAdornment(ReferencesTag referencesTag)
        {
            Foreground = Brushes.DarkGray;
            Margin = new Thickness(0);
            Padding = new Thickness(0);
            FontFamily = new FontFamily("Consolas");
            FontSize = 11;
            FontWeight = FontWeights.Regular;
            Update(referencesTag);
        }

        internal void Update(ReferencesTag referencesTag)
        {
            string text = $" ({referencesTag?.References.Length ?? '-'}) ";
            /*if (referencesTag == null) text = "- references";
            else if (referencesTag.References.Length == 0) text = "0 references";
            else if (referencesTag.References.Length == 1) text = "1 reference";
            else text = $"{referencesTag.References.Length} references";*/
            Inlines.Clear();
            Inlines.Add(text);
        }

    }
}
