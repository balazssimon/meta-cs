using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.MetaGenerator.Classification
{
    internal class MetaGeneratorClassificationDefinitions
    {
        [Name(MetaGeneratorClassificationTypes.None), Export]
        internal ClassificationTypeDefinition MetaGeneratorNoneClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.None)]
        [Name("MetaGeneratorNoneFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorNoneClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorNoneClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "MetaGenerator None";
            }
        }


        [Name(MetaGeneratorClassificationTypes.Whitespace), Export]
        internal ClassificationTypeDefinition MetaGeneratorWhitespaceClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.Whitespace)]
        [Name("MetaGeneratorWhitespaceFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorWhitespaceClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorWhitespaceClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "MetaGenerator Whitespace";
            }
        }


        [Name(MetaGeneratorClassificationTypes.Identifier), Export]
        internal ClassificationTypeDefinition MetaGeneratorIdentifierClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.Identifier)]
        [Name("MetaGeneratorIdentifierFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorIdentifierClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorIdentifierClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "MetaGenerator Identifier";
            }
        }


        [Name(MetaGeneratorClassificationTypes.Keyword), Export]
        internal ClassificationTypeDefinition MetaGeneratorKeywordClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.Keyword)]
        [Name("MetaGeneratorKeywordFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorKeywordClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorKeywordClassificationFormat()
            {
                ForegroundColor = Colors.Blue;
                this.DisplayName = "MetaGenerator Keyword";
            }
        }


        [Name(MetaGeneratorClassificationTypes.Number), Export]
        internal ClassificationTypeDefinition MetaGeneratorNumberClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.Number)]
        [Name("MetaGeneratorNumberFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorNumberClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorNumberClassificationFormat()
            {
                ForegroundColor = Colors.Purple;
                this.DisplayName = "MetaGenerator Number";
            }
        }


        [Name(MetaGeneratorClassificationTypes.String), Export]
        internal ClassificationTypeDefinition MetaGeneratorStringClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.String)]
        [Name("MetaGeneratorStringFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorStringClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorStringClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(163, 21, 21);
                this.DisplayName = "MetaGenerator String";
            }
        }


        [Name(MetaGeneratorClassificationTypes.Type), Export]
        internal ClassificationTypeDefinition MetaGeneratorTypeClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.Type)]
        [Name("MetaGeneratorTypeFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorTypeClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorTypeClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(43, 145, 175);
                this.DisplayName = "MetaGenerator Type";
            }
        }

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

        [Name(MetaGeneratorClassificationTypes.Comment), Export]
        internal ClassificationTypeDefinition MetaGeneratorCommentClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaGeneratorClassificationTypes.Comment)]
        [Name("MetaGeneratorCommentFormatDefinition")]
        [Order]
        internal sealed class MetaGeneratorCommentClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaGeneratorCommentClassificationFormat()
            {
                ForegroundColor = Colors.Green;
                this.DisplayName = "MetaGenerator Comment";
            }
        }


    }
}
