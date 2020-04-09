using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.Languages.MetaGenerator.Classification
{
    internal class MetaGeneratorClassificationDefinitions
    {
        [Name(MetaGeneratorClassificationTypes.TemplateControl), Export]
        internal ClassificationTypeDefinition MetaGeneratorTemplateControlClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.TemplateControl)]
        [Name("MetaGeneratorTemplateControlFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorTemplateControlClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorTemplateControlClassificationFormat()
            {
                ForegroundColor = Colors.DarkGreen;
                this.DisplayName = "MetaGenerator TemplateControl";
            }
        }


        [Name(MetaGeneratorClassificationTypes.TemplateOutput), Export]
        internal ClassificationTypeDefinition MetaGeneratorTemplateOutputClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.TemplateOutput)]
        [Name("MetaGeneratorTemplateOutputFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorTemplateOutputClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorTemplateOutputClassificationFormat()
            {
                ForegroundColor = Colors.Gray;
                this.DisplayName = "MetaGenerator TemplateOutput";
            }
        }

    }
}
