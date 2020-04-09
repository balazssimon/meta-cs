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
        [Name(Antlr4RoslynClassificationTypes.Action), Export]
        internal ClassificationTypeDefinition Antlr4RoslynActionClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = Antlr4RoslynClassificationTypes.Action)]
        [Name("Antlr4Roslyn/ActionFormatDefinition")]
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
        [Name("Antlr4Roslyn/OptionsFormatDefinition")]
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
        [Name("Antlr4Roslyn/RuleFormatDefinition")]
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
        [Name("Antlr4Roslyn/TokenFormatDefinition")]
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
        [Name("Antlr4Roslyn/AnnotationFormatDefinition")]
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
