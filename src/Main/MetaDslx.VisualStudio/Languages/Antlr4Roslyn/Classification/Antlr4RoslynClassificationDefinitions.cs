using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.Languages.Antlr4Roslyn.Classification
{
    internal class Antlr4RoslynClassificationDefinitions
    {
        [Name(Antlr4RoslynClassificationTypes.None), Export]
        internal ClassificationTypeDefinition Antlr4RoslynNoneClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.None)]
        [Name("Antlr4RoslynNoneFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynNoneClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynNoneClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Antlr4Roslyn None";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Whitespace), Export]
        internal ClassificationTypeDefinition Antlr4RoslynWhitespaceClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Whitespace)]
        [Name("Antlr4RoslynWhitespaceFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynWhitespaceClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynWhitespaceClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Antlr4Roslyn Whitespace";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Identifier), Export]
        internal ClassificationTypeDefinition Antlr4RoslynIdentifierClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Identifier)]
        [Name("Antlr4RoslynIdentifierFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynIdentifierClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynIdentifierClassificationFormat()
            {
                ForegroundColor = Colors.Black;
                this.DisplayName = "Antlr4Roslyn Identifier";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Keyword), Export]
        internal ClassificationTypeDefinition Antlr4RoslynKeywordClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Keyword)]
        [Name("Antlr4RoslynKeywordFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynKeywordClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynKeywordClassificationFormat()
            {
                ForegroundColor = Colors.Blue;
                this.DisplayName = "Antlr4Roslyn Keyword";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Number), Export]
        internal ClassificationTypeDefinition Antlr4RoslynNumberClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Number)]
        [Name("Antlr4RoslynNumberFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynNumberClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynNumberClassificationFormat()
            {
                ForegroundColor = Colors.Purple;
                this.DisplayName = "Antlr4Roslyn Number";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.String), Export]
        internal ClassificationTypeDefinition Antlr4RoslynStringClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.String)]
        [Name("Antlr4RoslynStringFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynStringClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynStringClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(163, 21, 21);
                this.DisplayName = "Antlr4Roslyn String";
            }
        }

        [Name(Antlr4RoslynClassificationTypes.Comment), Export]
        internal ClassificationTypeDefinition Antlr4RoslynCommentClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Comment)]
        [Name("Antlr4RoslynCommentFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynCommentClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynCommentClassificationFormat()
            {
                ForegroundColor = Colors.Green;
                this.DisplayName = "Antlr4Roslyn Comment";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Action), Export]
        internal ClassificationTypeDefinition Antlr4RoslynActionClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Action)]
        [Name("Antlr4RoslynActionFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynActionClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynActionClassificationFormat()
            {
                ForegroundColor = Colors.DarkGray;
                this.DisplayName = "Antlr4Roslyn Action";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Options), Export]
        internal ClassificationTypeDefinition Antlr4RoslynOptionsClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Options)]
        [Name("Antlr4RoslynOptionsFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynOptionsClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynOptionsClassificationFormat()
            {
                ForegroundColor = Colors.DarkGray;
                this.DisplayName = "Antlr4Roslyn Options";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Rule), Export]
        internal ClassificationTypeDefinition Antlr4RoslynRuleClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Rule)]
        [Name("Antlr4RoslynRuleFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynRuleClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynRuleClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(64, 64, 255);
                this.DisplayName = "Antlr4Roslyn Rule";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Token), Export]
        internal ClassificationTypeDefinition Antlr4RoslynTokenClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Token)]
        [Name("Antlr4RoslynTokenFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynTokenClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynTokenClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(0, 0, 127);
                this.DisplayName = "Antlr4Roslyn Token";
            }
        }


        [Name(Antlr4RoslynClassificationTypes.Annotation), Export]
        internal ClassificationTypeDefinition Antlr4RoslynAnnotationClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Annotation)]
        [Name("Antlr4RoslynAnnotationFormatDefinition")]
        [Order]
        internal sealed class Antlr4RoslynAnnotationClassificationFormat : ClassificationFormatDefinition
        {
            internal Antlr4RoslynAnnotationClassificationFormat()
            {
                ForegroundColor = Color.FromRgb(43, 145, 175);
                this.DisplayName = "Antlr4Roslyn Annotation";
            }
        }
    }
}
