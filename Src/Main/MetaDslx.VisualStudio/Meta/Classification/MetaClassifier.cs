using Antlr4.Runtime;
using MetaDslx.Languages.Meta.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Meta.Classification
{
    internal class MetaClassifier : IClassifier
    {
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        private IClassificationTypeRegistryService classificationRegistryService;
        private ITextBuffer textBuffer;

        internal MetaClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
        {
            this.textBuffer = textBuffer;
            this.classificationRegistryService = classificationRegistryService;
        }

        IList<ClassificationSpan> IClassifier.GetClassificationSpans(SnapshotSpan span)
        {
            var classifications = new List<ClassificationSpan>();

            //using (var systemState = new SystemState())
            {
                int startIndex, endIndex;

                // Execute the Meta lexer
                var lexer = new MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetaLexer(CharStreams.fromstring(span.GetText()));

                IToken token = lexer.NextToken();

                // Iterate the tokens
                while (token != null/* && token.Type != MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetaLexer.Eof*/)
                {
                    // Determine the bounds of the classfication span
                    startIndex = span.Span.Start + token.StartIndex;
                    endIndex = span.Span.Start + token.StopIndex+1;

                    if (endIndex > span.Snapshot.GetText().Length)
                        endIndex = span.Snapshot.GetText().Length;

                    if (endIndex > startIndex && !span.Snapshot.TextBuffer.IsReadOnly(new Span(startIndex, endIndex - startIndex)))
                    {
                        // Add the classfication span
                        int tokenKind = (int)MetaSyntaxFacts.Instance.GetTokenKind(token.Type);
                        if (tokenKind == 0)
                        {
                            tokenKind = (int)MetaSyntaxFacts.Instance.GetModeTokenKind(lexer.CurrentMode);
                        }
                        classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, startIndex, endIndex - startIndex), GetClassificationType(tokenKind)));
                    }
                    
                    if (token.Type == MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetaLexer.Eof)
                    {
                        break;
                    }

                    // Get next token
                    token = lexer.NextToken();
                }
            }

            foreach (var region in span.Snapshot.TextBuffer.GetReadOnlyExtents(span))
            {
                // Add classfication for read only regions
                classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, region), classificationRegistryService.GetClassificationType(MetaClassificationTypes.None)));
            }

            return classifications;
        }

        private IClassificationType GetClassificationType(int tokenKind)
        {

            switch ((MetaTokenKind)tokenKind)
            {
                case MetaTokenKind.Comment:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Comment);
                case MetaTokenKind.Identifier:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Identifier);
                case MetaTokenKind.Keyword:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Keyword);
                case MetaTokenKind.Number:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Number);
                case MetaTokenKind.String:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.String);
                default:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.None);
            }

        }

    }
}
