using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.Soal.Classification
{
    internal class SoalClassificationDefinitions
    {
        [Name(SoalClassificationTypes.None), Export]
        internal ClassificationTypeDefinition SoalNoneClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SoalClassificationTypes.None)]
        [Name("SoalNoneFormatDefinition")]
        [Order]
        internal sealed class SoalNoneClassificationFormat : ClassificationFormatDefinition
        {
            internal SoalNoneClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Soal None";
            }
        }


        [Name(SoalClassificationTypes.Whitespace), Export]
        internal ClassificationTypeDefinition SoalWhitespaceClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SoalClassificationTypes.Whitespace)]
        [Name("SoalWhitespaceFormatDefinition")]
        [Order]
        internal sealed class SoalWhitespaceClassificationFormat : ClassificationFormatDefinition
        {
            internal SoalWhitespaceClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Soal Whitespace";
            }
        }


        [Name(SoalClassificationTypes.Identifier), Export]
        internal ClassificationTypeDefinition SoalIdentifierClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SoalClassificationTypes.Identifier)]
        [Name("SoalIdentifierFormatDefinition")]
        [Order]
        internal sealed class SoalIdentifierClassificationFormat : ClassificationFormatDefinition
        {
            internal SoalIdentifierClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Soal Identifier";
            }
        }


        [Name(SoalClassificationTypes.Keyword), Export]
        internal ClassificationTypeDefinition SoalKeywordClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SoalClassificationTypes.Keyword)]
        [Name("SoalKeywordFormatDefinition")]
        [Order]
        internal sealed class SoalKeywordClassificationFormat : ClassificationFormatDefinition
        {
            internal SoalKeywordClassificationFormat()
            {
                ForegroundColor = Colors.Blue;
                this.DisplayName = "Soal Keyword";
            }
        }


        [Name(SoalClassificationTypes.Number), Export]
        internal ClassificationTypeDefinition SoalNumberClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SoalClassificationTypes.Number)]
        [Name("SoalNumberFormatDefinition")]
        [Order]
        internal sealed class SoalNumberClassificationFormat : ClassificationFormatDefinition
        {
            internal SoalNumberClassificationFormat()
            {
                ForegroundColor = Colors.Purple;
                this.DisplayName = "Soal Number";
            }
        }


        [Name(SoalClassificationTypes.String), Export]
        internal ClassificationTypeDefinition SoalStringClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SoalClassificationTypes.String)]
        [Name("SoalStringFormatDefinition")]
        [Order]
        internal sealed class SoalStringClassificationFormat : ClassificationFormatDefinition
        {
            internal SoalStringClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(163, 21, 21);
                this.DisplayName = "Soal String";
            }
        }


        [Name(SoalClassificationTypes.Type), Export]
        internal ClassificationTypeDefinition SoalTypeClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SoalClassificationTypes.Type)]
        [Name("SoalTypeFormatDefinition")]
        [Order]
        internal sealed class SoalTypeClassificationFormat : ClassificationFormatDefinition
        {
            internal SoalTypeClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(43, 145, 175);
                this.DisplayName = "Soal Type";
            }
        }

        [Name(SoalClassificationTypes.Comment), Export]
        internal ClassificationTypeDefinition SoalCommentClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SoalClassificationTypes.Comment)]
        [Name("SoalCommentFormatDefinition")]
        [Order]
        internal sealed class SoalCommentClassificationFormat : ClassificationFormatDefinition
        {
            internal SoalCommentClassificationFormat()
            {
                ForegroundColor = Colors.Green;
                this.DisplayName = "Soal Comment";
            }
        }


    }
}
