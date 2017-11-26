using Antlr4.Runtime;
using MetaDslx.Compiler.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    internal struct MultiLineToken
    {
        public ITrackingSpan Tracking;
        public ITextVersion Version;
        public IClassificationType ClassificationType;
    }

    internal struct LexerState
    {
        public ITrackingSpan Tracking;
        public ITextVersion Version;
        public int Mode;
        //public int[] ModeStack; // TODO: if Antlr4.Runtime is corrected for .NET standard 2.0
    }

    internal abstract class Antlr4LexerClassifier : IClassifier
    {
        internal static readonly ICharStream EmptyCharStream = CharStreams.fromstring("");

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        protected ITextBuffer textBuffer;
        protected IClassificationTypeRegistryService classificationRegistryService;
        protected Lexer lexer;
        protected List<MultiLineToken> multiLineTokens = new List<MultiLineToken>();
        protected List<LexerState> lexerStates = new List<LexerState>();

        internal Antlr4LexerClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService, Lexer lexer)
        {
            this.textBuffer = textBuffer;
            this.classificationRegistryService = classificationRegistryService;
            this.lexer = lexer;
            this.InitialClassification();
        }

        private void InitialClassification()
        {
            SnapshotSpan span = new SnapshotSpan(textBuffer.CurrentSnapshot, 0, textBuffer.CurrentSnapshot.Length);
            this.GetClassificationSpans(span);
        }

        //Invoke ClassificationChanged that cause editor to re-classify specified span 
        protected void Invalidate(SnapshotSpan span)
        {
            if (ClassificationChanged != null)
                ClassificationChanged(this, new ClassificationChangedEventArgs(span));
        }

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>();

            bool isInsideMultiLineToken = false;
            for (var i = multiLineTokens.Count - 1; i >= 0; i--)
            {
                var multiLineTokenSpan = multiLineTokens[i].Tracking.GetSpan(span.Snapshot);
                if (multiLineTokenSpan.Length == 0)
                {
                    multiLineTokens.RemoveAt(i);
                }
                else
                {
                    if (span.IntersectsWith(multiLineTokenSpan))
                    {
                        isInsideMultiLineToken = true;
                        if (span.Snapshot.Version != multiLineTokens[i].Version)
                        {
                            multiLineTokens.RemoveAt(i);
                            Invalidate(multiLineTokenSpan);
                        }
                        else
                        {
                            result.Add(new ClassificationSpan(multiLineTokenSpan, multiLineTokens[i].ClassificationType));
                        }
                    }
                }
            }
            if (isInsideMultiLineToken) return result;

            List<LexerState> newLexerStates = new List<LexerState>();

            int startPosition = span.Start.Position;
            int endPosition;
            int currentOffset = 0;
            string currentText = span.GetText();

            int startLexerStateIndex = this.lexerStates.FindIndex(ls => ls.Tracking.GetSpan(span.Snapshot).Contains(startPosition));
            int endLexerStateIndex = this.lexerStates.FindIndex(ls => ls.Tracking.GetSpan(span.Snapshot).Contains(startPosition + currentText.Length));
            LexerState startLexerState = new LexerState();
            if (startLexerStateIndex >= 0)
            {
                startLexerState = this.lexerStates[startLexerStateIndex];
            }
            LexerState endLexerState = startLexerState;
            if (endLexerStateIndex >= 0)
            {
                endLexerState = this.lexerStates[endLexerStateIndex];
            }

            LexerState currentLexerState = startLexerState;
            int modeStartPosition = startPosition;
            int modeEndPosition;
            int currentMode = startLexerState.Mode;

            this.lexer.SetInputStream(CharStreams.fromstring(currentText));
            this.lexer.CurrentMode = currentMode;

            IToken token = null;
            do
            {
                startPosition = span.Start.Position + currentOffset;
                endPosition = startPosition;

                token = lexer.NextToken();

                if (token != null)
                {
                    endPosition += token.StopIndex - token.StartIndex + 1;

                    while (token.Type < 0 && endPosition < span.Snapshot.Length)
                    {
                        int textLength = Math.Min(span.Snapshot.Length - endPosition, 1024);
                        if (textLength > 0)
                        {
                            currentText = span.Snapshot.GetText(endPosition, textLength);

                            int mode = this.lexer.CurrentMode;
                            this.lexer.SetInputStream(CharStreams.fromstring(currentText));
                            this.lexer.CurrentMode = mode;
                            token = lexer.NextToken();

                            if (token != null)
                                endPosition += token.StopIndex - token.StartIndex + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                var classification = this.GetClassificationType(token.Type, this.lexer.CurrentMode);
                var tokenSpan = new SnapshotSpan(span.Snapshot, startPosition, (endPosition - startPosition));
                result.Add(new ClassificationSpan(tokenSpan, classification));

                int startLine = span.Snapshot.GetLineFromPosition(startPosition).LineNumber;
                int endLine = span.Snapshot.GetLineFromPosition(endPosition-1).LineNumber;
                bool multiLineToken = startLine != endLine;

                if (multiLineToken)
                {
                    this.InsertMultiLineToken(new MultiLineToken()
                    {
                        ClassificationType = classification,
                        Version = span.Snapshot.Version,
                        Tracking = span.Snapshot.CreateTrackingSpan(tokenSpan.Span, SpanTrackingMode.EdgeExclusive)
                    }, tokenSpan, span);

                    if (tokenSpan.End > span.End)
                        Invalidate(new SnapshotSpan(span.End + 1, tokenSpan.End));
                }

                if (this.lexer.CurrentMode != currentMode)
                {
                    modeEndPosition = endPosition;
                    SnapshotSpan modeSpan = new SnapshotSpan(span.Snapshot, modeStartPosition, modeEndPosition - modeStartPosition);
                    newLexerStates.Add(new LexerState()
                    {
                        Mode = currentMode,
                        Tracking = span.Snapshot.CreateTrackingSpan(modeSpan, SpanTrackingMode.EdgeExclusive),
                        Version = span.Snapshot.Version
                    });
                    modeStartPosition = modeEndPosition;
                    currentMode = this.lexer.CurrentMode;
                }

                currentOffset += endPosition - startPosition;
            }
            while (token != null && currentOffset < currentText.Length);

            if (newLexerStates.Count > 0)
            {
                int startPoint = newLexerStates[0].Tracking.GetStartPoint(span.Snapshot);
                int endPoint = newLexerStates[newLexerStates.Count - 1].Tracking.GetEndPoint(span.Snapshot);
                SnapshotSpan fullSpan = new SnapshotSpan(span.Snapshot, startPoint, endPoint - startPoint);
                bool indexSet = false;
                int index = lexerStates.Count;
                for (int i = lexerStates.Count - 1; i >= 0; --i)
                {
                    SnapshotSpan lexerStateSpan = lexerStates[i].Tracking.GetSpan(span.Snapshot);
                    if (lexerStateSpan.End < fullSpan.Start && lexerStateSpan.Start > fullSpan.End)
                    {
                        if (lexerStateSpan.End > fullSpan.End)
                        {
                            Invalidate(new SnapshotSpan(fullSpan.End + 1, lexerStateSpan.End));
                        }
                        lexerStates.RemoveAt(i);
                        index = i;
                        indexSet = true;
                    }
                    else if (lexerStateSpan.Start >= fullSpan.End)
                    {
                        index = i;
                        indexSet = true;
                    }
                    else if (!indexSet && lexerStateSpan.End <= fullSpan.Start)
                    {
                        index = i + 1;
                        indexSet = true;
                    }
                }
                lexerStates.InsertRange(index, newLexerStates);
                bool ordered = true;
                for (int i = 0; i < lexerStates.Count - 1; ++i)
                {
                    if (lexerStates[i].Tracking.GetSpan(span.Snapshot).Start > lexerStates[i + 1].Tracking.GetSpan(span.Snapshot).End)
                    {
                        ordered = false;
                    }
                }
                Console.WriteLine(ordered);
            }

            return result;
        }

        private void InsertMultiLineToken(MultiLineToken token, SnapshotSpan tokenSpan, SnapshotSpan span)
        {
            bool indexSet = false;
            int index = multiLineTokens.Count;
            for (int i = multiLineTokens.Count - 1; i >= 0; --i)
            {
                SnapshotSpan multiLineTokenSpan = multiLineTokens[i].Tracking.GetSpan(span.Snapshot);
                if (multiLineTokenSpan.IntersectsWith(tokenSpan))
                {
                    if (multiLineTokenSpan.End > tokenSpan.End)
                    {
                        Invalidate(new SnapshotSpan(tokenSpan.End + 1, multiLineTokenSpan.End));
                    }
                    multiLineTokens.RemoveAt(i);
                    index = i;
                    indexSet = true;
                }
                else if (multiLineTokenSpan.Start >= tokenSpan.End)
                {
                    index = i;
                    indexSet = true;
                }
                else if (!indexSet && multiLineTokenSpan.End <= tokenSpan.Start)
                {
                    index = i + 1;
                    indexSet = true;
                }
            }
            multiLineTokens.Insert(index, token);
        }

        protected abstract IClassificationType GetClassificationType(int tokenType, int mode);
    }
}
