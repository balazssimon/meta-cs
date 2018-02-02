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

    /*internal struct TrackedBlock
    {
        public ITrackingSpan Tracking;
        public ITextVersion Version;
    }*/

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
            this.ReclassifySpan(span);
            if (ClassificationChanged != null)
                ClassificationChanged(this, new ClassificationChangedEventArgs(span));
        }

        private void ReclassifySpan(SnapshotSpan span)
        {
            this.GetClassificationSpans(span);
        }

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>();
            List<LexerState> newLexerStates = null;

            int startPosition;
            if (this.InvalidateMultiLineTokens(span, result, out startPosition)) return result;
            string currentText = span.Snapshot.GetText(startPosition, span.End.Position - startPosition);

            int currentLexerStateIndex = this.FindLexerStateIndex(startPosition, span, false);
            if (currentLexerStateIndex >= this.lexerStates.Count)
            {
                currentLexerStateIndex = this.lexerStates.Count - 1;
            }
            LexerState currentLexerState = currentLexerStateIndex >= 0 ? this.lexerStates[currentLexerStateIndex] : new LexerState();
            int modeStartPosition = startPosition;
            if (currentLexerState.Tracking != null)
            {
                SnapshotSpan startLexerStateSpan = currentLexerState.Tracking.GetSpan(span.Snapshot);
                modeStartPosition = startLexerStateSpan.Start.Position;
            }

            int currentMode = currentLexerState.Mode;
            this.lexer.SetInputStream(CharStreams.fromstring(currentText));
            this.lexer.CurrentMode = currentMode;

            IToken token = null;
            int tokenType = -1;
            do
            {
                int endPosition = startPosition;
                token = lexer.NextToken();

                if (token != null)
                {
                    tokenType = token.Type;
                    if (tokenType < 0)
                    {
                        endPosition = span.End.Position;
                    }
                    else
                    {
                        endPosition += token.StopIndex - token.StartIndex + 1;
                    }

                    while (token != null && token.Type < 0 && endPosition < span.Snapshot.Length)
                    {
                        int textLength = Math.Min(span.Snapshot.Length - endPosition, 1024);
                        if (textLength > 0)
                        {
                            currentText = span.Snapshot.GetText(endPosition, textLength);

                            int mode = this.lexer.CurrentMode;
                            this.lexer.SetInputStream(CharStreams.fromstring(currentText));
                            this.lexer.CurrentMode = mode;
                            token = lexer.NextToken();

                            if (lexer.HitEOF)
                            {
                                endPosition += textLength;
                                token = null;
                                tokenType = -1;
                            }
                            else if (token != null)
                            {
                                tokenType = token.Type;
                                endPosition += token.StopIndex - token.StartIndex + 1;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                var classification = this.GetClassificationType(tokenType, this.lexer.CurrentMode);
                var tokenSpan = new SnapshotSpan(span.Snapshot, startPosition, (endPosition - startPosition));
                result.Add(new ClassificationSpan(tokenSpan, classification));

                int startLine = span.Snapshot.GetLineFromPosition(startPosition).LineNumber;
                int endLine = span.Snapshot.GetLineFromPosition(endPosition-1).LineNumber;
                bool isMultiLineToken = startLine != endLine;

                if (isMultiLineToken)
                {
                    MultiLineToken multiLineToken = 
                        new MultiLineToken()
                        {
                            ClassificationType = classification,
                            Version = span.Snapshot.Version,
                            Tracking = span.Snapshot.CreateTrackingSpan(tokenSpan.Span, SpanTrackingMode.EdgeExclusive)
                        };
                    if (this.InsertMultiLineToken(multiLineToken, tokenSpan, span))
                    {
                        if (tokenSpan.End > span.End)
                            Invalidate(new SnapshotSpan(span.End + 1, tokenSpan.End));
                        if (tokenSpan.Start < span.Start)
                            Invalidate(new SnapshotSpan(tokenSpan.Start, span.Start - 1));
                    }
                }

                if (this.lexer.CurrentMode != currentMode)
                {
                    int modeEndPosition = endPosition;
                    if (modeStartPosition < modeEndPosition)
                    {
                        SnapshotSpan modeSpan = new SnapshotSpan(span.Snapshot, modeStartPosition, modeEndPosition - modeStartPosition);
                        if (currentLexerState.Tracking == null || currentLexerState.Version == null ||
                            currentLexerState.Mode != currentMode ||
                            currentLexerState.Tracking.GetSpan(span.Snapshot) != modeSpan ||
                            currentLexerState.Version != span.Snapshot.Version)
                        {
                            LexerState newLexerState = new LexerState()
                            {
                                Mode = currentMode,
                                Tracking = span.Snapshot.CreateTrackingSpan(modeSpan, SpanTrackingMode.EdgeExclusive),
                                Version = span.Snapshot.Version
                            };
                            if (newLexerStates == null) newLexerStates = new List<LexerState>();
                            newLexerStates.Add(newLexerState);
                        }
                    }
                    while (currentLexerStateIndex < this.lexerStates.Count - 1)
                    {
                        ++currentLexerStateIndex;
                        currentLexerState = this.lexerStates[currentLexerStateIndex];
                        if (currentLexerState.Tracking.GetSpan(span.Snapshot).Contains(modeEndPosition))
                        {
                            break;
                        }
                    }
                    modeStartPosition = modeEndPosition;
                    currentMode = this.lexer.CurrentMode;
                }

                startPosition = endPosition;
            }
            while (token != null && startPosition < span.End.Position);

            this.InsertNewLexerStates(newLexerStates, span);
            return result;
        }

        private bool InvalidateMultiLineTokens(SnapshotSpan span, List<ClassificationSpan> classifications, out int startPosition)
        {
            bool result = false;
            startPosition = span.Start.Position;

            ValueTuple<int, int> range = this.FindMultiLineTokenRange(span);
            int startIndex = range.Item1;
            int endIndex = range.Item2;
            if(endIndex >= this.multiLineTokens.Count)
            {
                endIndex = this.multiLineTokens.Count - 1;
            }

            for (var i = endIndex; i >= startIndex; i--)
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
                        if (span.Snapshot.Version != multiLineTokens[i].Version)
                        {
                            multiLineTokens.RemoveAt(i);
                            Invalidate(multiLineTokenSpan);
                            //this.RemoveLexerStates(multiLineTokenSpan);
                            if (multiLineTokenSpan.Start.Position < span.Start.Position)
                            {
                                startPosition = multiLineTokenSpan.Start.Position;
                            }
                        }
                        else
                        {
                            if (multiLineTokenSpan.Contains(span)) result = true;
                            if (multiLineTokenSpan.Contains(startPosition))
                            {
                                startPosition = multiLineTokenSpan.End.Position;
                            }
                            classifications.Add(new ClassificationSpan(multiLineTokenSpan, multiLineTokens[i].ClassificationType));
                        }
                    }
                }
            }
            return result;
        }

        private bool InsertMultiLineToken(MultiLineToken token, SnapshotSpan tokenSpan, SnapshotSpan span)
        {
            ValueTuple<int, int> range = this.FindMultiLineTokenRange(span);
            int startIndex = range.Item1;
            int endIndex = range.Item2;

            if (startIndex < endIndex)
            {
                if (endIndex < this.multiLineTokens.Count)
                {
                    /*SnapshotSpan endMultiLineTokenSpan = multiLineTokens[endIndex].Tracking.GetSpan(span.Snapshot);
                    if (endMultiLineTokenSpan.End > tokenSpan.End)
                    {
                        Invalidate(new SnapshotSpan(tokenSpan.End + 1, endMultiLineTokenSpan.End));
                    }*/
                    multiLineTokens.RemoveRange(startIndex, endIndex - startIndex + 1);
                }
                else
                {
                    multiLineTokens.RemoveRange(startIndex, endIndex - startIndex);
                }
            }
            else if (startIndex == endIndex && endIndex < this.multiLineTokens.Count)
            {
                MultiLineToken multiLineToken = multiLineTokens[startIndex];
                if (multiLineToken.Version != token.Version)
                {
                    multiLineTokens.RemoveAt(startIndex);
                }
                else
                {
                    SnapshotSpan multiLineTokenSpan = multiLineToken.Tracking.GetSpan(span.Snapshot);
                    if (multiLineTokenSpan != tokenSpan)
                    {
                        multiLineTokens.RemoveAt(startIndex);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            multiLineTokens.Insert(startIndex, token);
            return true;
        }

        private ValueTuple<int,int> FindMultiLineTokenRange(SnapshotSpan span)
        {
            int startIndex = this.FindMultiLineTokenIndex(span.Start, span, false);
            int endIndex = this.FindMultiLineTokenIndex(span.End, span, false);
            return new ValueTuple<int, int>(startIndex, endIndex);
        }

        private ValueTuple<int, int> FindLexerStateRange(SnapshotSpan span)
        {
            int startIndex = this.FindLexerStateIndex(span.Start, span, false);
            int endIndex = this.FindLexerStateIndex(span.End, span, false);
            return new ValueTuple<int, int>(startIndex, endIndex);
        }

        private void InsertNewLexerStates(List<LexerState> newLexerStates, SnapshotSpan span)
        {
            if (newLexerStates == null || newLexerStates.Count == 0) return;

            int startPoint = newLexerStates[0].Tracking.GetStartPoint(span.Snapshot);
            int endPoint = newLexerStates[newLexerStates.Count - 1].Tracking.GetEndPoint(span.Snapshot);
            SnapshotSpan fullSpan = new SnapshotSpan(span.Snapshot, startPoint, endPoint - startPoint - 1);

            int index = this.RemoveLexerStates(fullSpan);
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

        private int RemoveLexerStates(SnapshotSpan span)
        {
            ValueTuple<int, int> range = this.FindLexerStateRange(span);
            int startIndex = range.Item1;
            int endIndex = range.Item2;

            if (startIndex < 0) startIndex = 0;
            if (startIndex <= endIndex)
            {
                if (endIndex >= this.lexerStates.Count) endIndex = this.lexerStates.Count - 1;
                /*for (int i = endIndex; i >= startIndex; --i)
                {
                    SnapshotSpan lexerStateSpan = lexerStates[endIndex].Tracking.GetSpan(span.Snapshot);
                    if (!span.Contains(lexerStateSpan))
                    {
                        if (span.End.Position < lexerStateSpan.End.Position && span.End.Position+1 < span.Snapshot.Length)
                        {
                            Invalidate(new SnapshotSpan(span.Snapshot, span.End.Position + 1, lexerStateSpan.End.Position - span.End.Position - 1));
                        }
                    }
                }*/
                lexerStates.RemoveRange(startIndex, endIndex - startIndex + 1);
            }
            return startIndex;
        }

        private int FindMultiLineTokenIndex(int position, SnapshotSpan span, bool inside)
        {
            int firstIndex = 0;
            int lastIndex = this.multiLineTokens.Count - 1;
            while (firstIndex <= lastIndex)
            {
                int currentIndex = (firstIndex + lastIndex) / 2;
                SnapshotSpan multiLineTokenSpan = this.multiLineTokens[currentIndex].Tracking.GetSpan(span.Snapshot);
                if (multiLineTokenSpan.Contains(position))
                {
                    return currentIndex;
                }
                else if (position < multiLineTokenSpan.Start)
                {
                    lastIndex = currentIndex - 1;
                }
                else if (position >= multiLineTokenSpan.End)
                {
                    firstIndex = currentIndex + 1;
                }
            }
            if (inside) return -1;
            else return firstIndex;
        }

        private int FindLexerStateIndex(int position, SnapshotSpan span, bool inside)
        {
            int firstIndex = 0;
            int lastIndex = this.lexerStates.Count - 1;
            while (firstIndex <= lastIndex)
            {
                int currentIndex = (firstIndex + lastIndex) / 2;
                SnapshotSpan lexerStateSpan = this.lexerStates[currentIndex].Tracking.GetSpan(span.Snapshot);
                if (lexerStateSpan.Contains(position))
                {
                    return currentIndex;
                }
                else if (position < lexerStateSpan.Start)
                {
                    lastIndex = currentIndex - 1;
                }
                else if (position >= lexerStateSpan.End)
                {
                    firstIndex = currentIndex + 1;
                }
            }
            if (inside) return -1;
            else return firstIndex;
        }

        protected abstract IClassificationType GetClassificationType(int tokenType, int mode);
    }
}
