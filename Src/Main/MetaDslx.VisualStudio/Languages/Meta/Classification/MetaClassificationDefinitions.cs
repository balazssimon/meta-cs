using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.Languages.Meta.Classification
{
    internal class MetaClassificationDefinitions
    {
        [Name(MetaClassificationTypes.None), Export]
        internal ClassificationTypeDefinition MetaNoneClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaClassificationTypes.None)]
        [Name("MetaNoneFormatDefinition")]
        [Order]
        internal sealed class MetaNoneClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaNoneClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Meta None";
            }
        }


        [Name(MetaClassificationTypes.Whitespace), Export]
        internal ClassificationTypeDefinition MetaWhitespaceClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaClassificationTypes.Whitespace)]
        [Name("MetaWhitespaceFormatDefinition")]
        [Order]
        internal sealed class MetaWhitespaceClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaWhitespaceClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Meta Whitespace";
            }
        }


        [Name(MetaClassificationTypes.Identifier), Export]
        internal ClassificationTypeDefinition MetaIdentifierClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaClassificationTypes.Identifier)]
        [Name("MetaIdentifierFormatDefinition")]
        [Order]
        internal sealed class MetaIdentifierClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaIdentifierClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Meta Identifier";
            }
        }


        [Name(MetaClassificationTypes.Keyword), Export]
        internal ClassificationTypeDefinition MetaKeywordClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaClassificationTypes.Keyword)]
        [Name("MetaKeywordFormatDefinition")]
        [Order]
        internal sealed class MetaKeywordClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaKeywordClassificationFormat()
            {
                ForegroundColor = Colors.Blue;
                this.DisplayName = "Meta Keyword";
            }
        }


        [Name(MetaClassificationTypes.Number), Export]
        internal ClassificationTypeDefinition MetaNumberClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaClassificationTypes.Number)]
        [Name("MetaNumberFormatDefinition")]
        [Order]
        internal sealed class MetaNumberClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaNumberClassificationFormat()
            {
                ForegroundColor = Colors.Purple;
                this.DisplayName = "Meta Number";
            }
        }


        [Name(MetaClassificationTypes.String), Export]
        internal ClassificationTypeDefinition MetaStringClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaClassificationTypes.String)]
        [Name("MetaStringFormatDefinition")]
        [Order]
        internal sealed class MetaStringClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaStringClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(163, 21, 21);
                this.DisplayName = "Meta String";
            }
        }


        [Name(MetaClassificationTypes.Type), Export]
        internal ClassificationTypeDefinition MetaTypeClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaClassificationTypes.Type)]
        [Name("MetaTypeFormatDefinition")]
        [Order]
        internal sealed class MetaTypeClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaTypeClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(43, 145, 175);
                this.DisplayName = "Meta Type";
            }
        }

        [Name(MetaClassificationTypes.Comment), Export]
        internal ClassificationTypeDefinition MetaCommentClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = MetaClassificationTypes.Comment)]
        [Name("MetaCommentFormatDefinition")]
        [Order]
        internal sealed class MetaCommentClassificationFormat : ClassificationFormatDefinition
        {
            internal MetaCommentClassificationFormat()
            {
                ForegroundColor = Colors.Green;
                this.DisplayName = "Meta Comment";
            }
        }


    }
}
