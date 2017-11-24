using Antlr4.Runtime;
using MetaDslx.Compiler.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    internal struct MultiLineToken
    {
        //Classification used teh token
        public IClassificationType Classification;
        //Tracked span of token
        public ITrackingSpan Tracking;
        //Version of text when Tracking was created
        public ITextVersion Version;
    }

    internal abstract class Antlr4LexerClassifier : IClassifier
    {
        internal static readonly ICharStream EmptyCharStream = CharStreams.fromstring("");

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        protected ITextBuffer textBuffer;
        protected IClassificationTypeRegistryService classificationRegistryService;
        protected Lexer lexer;
        protected List<MultiLineToken> multiLineTokens;

        internal Antlr4LexerClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService, Lexer lexer)
        {
            this.textBuffer = textBuffer;
            this.classificationRegistryService = classificationRegistryService;
            this.lexer = lexer;
            this.multiLineTokens = new List<MultiLineToken>();
        }

        //Invoke ClassificationChanged that cause editor to re-classify specified span 
        protected void Invalidate(SnapshotSpan span)
        {
            if (ClassificationChanged != null)
                ClassificationChanged(this, new ClassificationChangedEventArgs(span));
        }

        IList<ClassificationSpan> IClassifier.GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>();

            bool isInsideMultiLine = false;

            //Scan for all know multi-line tokens, checking for current span intersection 
            for (var i = multiLineTokens.Count - 1; i >= 0; i--)
            {
                var multiSpan = multiLineTokens[i].Tracking.GetSpan(span.Snapshot);

                //Check if the span of the multi-line token is collapsed (zero length), and if true
                //remove it from the list
                if (multiSpan.Length == 0)
                {
                    multiLineTokens.RemoveAt(i);
                }
                else
                {
                    if (span.IntersectsWith(multiSpan))
                    {
                        isInsideMultiLine = true;

                        //check if multi-line token is changed by comparing version of current 
                        //span with version on which token is found 
                        if (span.Snapshot.Version != multiLineTokens[i].Version)
                        {
                            //if text inside multi-line token is changed, force the re-classication 
                            //of the whole multi-line token span and remove it from the list
                            multiLineTokens.RemoveAt(i);
                            Invalidate(multiSpan);
                        }
                        else
                        {
                            //if no change, re-classify whole span with using current classification 
                            //(counterwise we loose actuale classification)
                            result.Add(new ClassificationSpan(multiSpan, multiLineTokens[i].Classification));
                        }
                    }
                }
            }

            if (!isInsideMultiLine)
            {
                //Start / end position (absolute) of current token 
                int startPosition;
                int endPosition;
                //Offset relative to the current span
                int currentOffset = 0;
                //Current span text
                string currentText = span.GetText();

                this.lexer.SetInputStream(CharStreams.fromstring(currentText));

                //Scan the current span for all tokens.
                IToken token = null;
                do
                {
                    startPosition = span.Start.Position + currentOffset;
                    endPosition = startPosition;

                    token = lexer.NextToken();

                    if (token != null)
                    {
                        //Calculate end absolute position
                        endPosition += token.StopIndex - token.StartIndex + 1;

                        //if this.lexer.CurrentMode != 0, that means that token is not ending in current span,
                        //so we need to continue read text until the token is fully read
                        while (token != null && this.lexer.CurrentMode != 0 && endPosition < span.Snapshot.Length)
                        {
                            //Get 1024 text block size (or less, if the reaming text is shorter)
                            int textSize = Math.Min(span.Snapshot.Length - endPosition, 1024);
                            currentText = span.Snapshot.GetText(endPosition, textSize);
                            //Scan for next token, starting from previous Scan State
                            //this.lexer.Text = currentText;
                            int mode = this.lexer.CurrentMode;
                            this.lexer.SetInputStream(CharStreams.fromstring(currentText));
                            this.lexer.CurrentMode = mode;
                            token = lexer.NextToken();
                            if (token != null)
                                endPosition += token.StopIndex - token.StartIndex + 1;
                        }
                    }

                    var classification = this.GetClassificationType(token.Type, this.lexer.CurrentMode);
                    //Create and append cliassification span
                    var tokenSpan = new SnapshotSpan(span.Snapshot, startPosition, (endPosition - startPosition));
                    result.Add(new ClassificationSpan(tokenSpan, classification));

                    int startLine = span.Snapshot.GetLineFromPosition(startPosition).LineNumber;
                    int endLine = span.Snapshot.GetLineFromPosition(endPosition-1).LineNumber;
                    bool multiLineToken = startLine != endLine;
                    //All multi-line tokens will be saved in a list and tracked. This will automatically
                    //update the start / end position of token when text buffer is changed.
                    if (multiLineToken)
                    {
                        //Ensure that do not already exists into the list
                        if (!multiLineTokens.Any(a => a.Tracking.GetSpan(span.Snapshot).Span == tokenSpan.Span))
                        {
                            multiLineTokens.Add(new MultiLineToken()
                            {
                                Classification = classification,
                                Version = span.Snapshot.Version,
                                Tracking = span.Snapshot.CreateTrackingSpan(tokenSpan.Span, SpanTrackingMode.EdgeExclusive)
                            });

                            //If token length exeed current span length, we need to invalidate and re-classify 
                            //the reaming text
                            if (tokenSpan.End > span.End)
                                Invalidate(new SnapshotSpan(span.End + 1, tokenSpan.End));
                        }
                    }

                    currentOffset += endPosition - startPosition;
                }
                //Continue the loop until all span is tokenized, or no more token are found.
                while (token != null && currentOffset < currentText.Length);
            }

            return result;
        }

        protected abstract IClassificationType GetClassificationType(int tokenType, int mode);
    }
}
