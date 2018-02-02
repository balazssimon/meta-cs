using Antlr4.Runtime;
using MetaDslx.Compiler.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    internal struct TrackedBlock
    {
        public ITrackingSpan Block;
        public ITextVersion Version;
        public LexerState StartState;
        public LexerState EndState;
    }

    internal class LexerState : IEquatable<LexerState>
    {
        public LexerState(Lexer lexer)
        {
            this.Mode = lexer.CurrentMode;
            this.ModeStack = lexer.ModeStack.Count > 0 ? lexer.ModeStack.ToArray() : null;
        }
        public int Mode { get; private set; }
        public int[] ModeStack { get; private set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as LexerState);
        }

        public virtual bool Equals(LexerState other)
        {
            if (other == null)
            {
                return this.Mode == 0 && (this.ModeStack == null || this.ModeStack.Length == 0);
            }
            if (this.Mode != other.Mode) return false;
            if ((this.ModeStack == null || this.ModeStack.Length == 0) && (other.ModeStack == null || other.ModeStack.Length == 0)) return true;
            if (this.ModeStack == null || other.ModeStack == null) return false;
            if (this.ModeStack.Length != other.ModeStack.Length) return false;
            for (int i = 0; i < this.ModeStack.Length; i++)
            {
                if (this.ModeStack[i] != other.ModeStack[i]) return false;
            }
            return true;
        }

        public virtual void Restore(Lexer lexer)
        {
            lexer.CurrentMode = this.Mode;
            if (this.ModeStack != null && this.ModeStack.Length > 0)
            {
                foreach (var ms in this.ModeStack)
                {
                    lexer.ModeStack.Push(ms);
                }
            }
        }

    }

    internal abstract class Antlr4LexerClassifier : IClassifier
    {
        private const int BlockSize = 512;
        internal static readonly ICharStream EmptyCharStream = CharStreams.fromstring("");

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        protected ITextBuffer textBuffer;
        protected IClassificationTypeRegistryService classificationRegistryService;
        protected Lexer lexer;
        private List<MultiLineToken> multiLineTokens = new List<MultiLineToken>();
        private List<TrackedBlock> trackedBlocks = new List<TrackedBlock>();
        private Cache cache = new Cache();

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

        private bool RestoreLexerState(SnapshotSpan span, List<ClassificationSpan> classifications, out int startPosition, out int endPosition, out ITextVersion blockVersion, out bool cacheClassifications, out TrackedBlock prevBlock)
        {
            blockVersion = null;
            cacheClassifications = true;
            prevBlock = default(TrackedBlock);
            if (this.InvalidateMultiLineTokens(span, classifications, out startPosition, out endPosition))
            {
                return true;
            }
            bool updateCache = true;
            if (this.cache.Version == span.Snapshot.Version)
            {
                blockVersion = this.cache.Version;
                if (span.Start.Position == this.cache.Position)
                {
                    startPosition = span.Start.Position;
                    endPosition = span.End.Position;
                    string spanText = span.Snapshot.GetText(span);
                    this.lexer.SetInputStream(CharStreams.fromstring(spanText));
                    this.lexer.CurrentMode = this.cache.Mode;
                    if (this.cache.ModeStack != null && this.cache.ModeStack.Length > 0)
                    {
                        foreach (var ms in this.cache.ModeStack)
                        {
                            this.lexer.ModeStack.Push(ms);
                        }
                    }
                    cacheClassifications = false;
                    return false;
                }
                else if (this.cache.Range != null)
                {
                    SnapshotSpan cacheSpan = this.cache.Range.GetSpan(span.Snapshot);
                    if (cacheSpan.Contains(span) && span.Start.Position < cacheSpan.Start.Position + BlockSize)
                    {
                        startPosition = cacheSpan.Start.Position;
                        endPosition = span.End.Position;
                        blockVersion = this.cache.Version;
                        prevBlock = this.cache.PrevBlock;
                        updateCache = false;
                        cacheClassifications = false;
                    }
                }
            }

            if (updateCache)
            {
                SnapshotSpan spanWithMultiLineTokens = new SnapshotSpan(span.Snapshot, Span.FromBounds(startPosition, endPosition));
                prevBlock = this.InvalidateTrackedBlocks(spanWithMultiLineTokens, out startPosition, out endPosition, out blockVersion);
                this.cache.PrevBlock = prevBlock;
                this.cache.Version = span.Snapshot.Version;
                this.cache.Range = span.Snapshot.CreateTrackingSpan(Span.FromBounds(startPosition, endPosition), SpanTrackingMode.EdgeExclusive);
            }

            string text = span.Snapshot.GetText(Span.FromBounds(startPosition, endPosition));
            this.lexer.SetInputStream(CharStreams.fromstring(text));
            if (prevBlock.EndState != null)
            {
                prevBlock.EndState.Restore(this.lexer);
            }
            return false;
        }

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>();
            var newTrackedBlocks = new List<TrackedBlock>();

            int spanStartPosition;
            int spanEndPosition;
            ITextVersion blockVersion;
            bool cacheClassifications;
            TrackedBlock prevBlock;
            if (this.RestoreLexerState(span, result, out spanStartPosition, out spanEndPosition, out blockVersion, out cacheClassifications, out prevBlock))
            {
                return result;
            }

            if (cacheClassifications)
            {
                this.cache.ClassificationIndex = 0;
                this.cache.Classifications.Clear();
            }
            else if (this.cache.ClassificationSpan.Contains(span.Span))
            {
                int delta = 0;
                int index = this.cache.ClassificationIndex;
                if (index < 0 || index >= this.cache.Classifications.Count) index = 0;
                ClassificationSpan cs = null;
                if (index >= 0 && index < this.cache.Classifications.Count)
                {
                    cs = this.cache.Classifications[index];
                    if (span.Span.Start == cs.Span.End)
                    {
                        ++index;
                        delta = 1;
                    }
                    if (delta == 0)
                    {
                        if (span.Span.Start < cs.Span.Start)
                        {
                            while (index >= 0)
                            {
                                cs = this.cache.Classifications[index];
                                if (span.Span.Start == cs.Span.Start)
                                {
                                    delta = 1;
                                    break;
                                }
                                --index;
                            }
                        }
                        else if (span.Span.Start > cs.Span.Start)
                        {
                            while (index < this.cache.Classifications.Count)
                            {
                                cs = this.cache.Classifications[index];
                                if (span.Span.Start == cs.Span.Start)
                                {
                                    delta = 1;
                                    break;
                                }
                                ++index;
                            }
                        }
                    }
                }
                if (delta != 0)
                {
                    while (index >= 0 && index < this.cache.Classifications.Count)
                    {
                        cs = this.cache.Classifications[index];
                        if (cs.Span.Start >= span.Span.Start && cs.Span.End <= span.Span.End)
                        {
                            result.Add(cs);
                            this.cache.ClassificationIndex = index;
                        }
                        index += delta;
                    }
                    return result;
                }
            }

            int cacheStartPosition = spanStartPosition;
            int cacheEndPosition = spanStartPosition;

            int startPosition = spanStartPosition;
            int endPosition = spanEndPosition;
            int blockStartPosition = startPosition;

            LexerState startState = prevBlock.EndState;

            IToken token = null;
            int tokenType = -1;
            do
            {
                endPosition = startPosition;
                token = lexer.NextToken();

                if (token != null)
                {
                    tokenType = token.Type;
                    endPosition += token.StopIndex - token.StartIndex + 1;
                }
                if (token == null || tokenType < 0)
                {
                    endPosition = spanEndPosition;
                    tokenType = -1;
                    while (tokenType < 0 && endPosition < span.Snapshot.Length)
                    {
                        int textLength = Math.Min(span.Snapshot.Length - endPosition, 1024);
                        string text = span.Snapshot.GetText(endPosition, textLength);

                        LexerState state = this.SaveLexerState();
                        this.lexer.SetInputStream(CharStreams.fromstring(text));
                        state.Restore(this.lexer);

                        token = lexer.NextToken();

                        if (lexer.HitEOF)
                        {
                            endPosition += textLength;
                        }
                        else if (token != null)
                        {
                            tokenType = token.Type;
                            endPosition += token.StopIndex - token.StartIndex + 1;
                        }
                    }
                }

                if (span.OverlapsWith(Span.FromBounds(startPosition, endPosition)))
                {
                    var classification = this.GetClassificationType(tokenType, this.lexer.CurrentMode);
                    var tokenSpan = new SnapshotSpan(span.Snapshot, startPosition, (endPosition - startPosition));
                    var classificationSpan = new ClassificationSpan(tokenSpan, classification);
                    result.Add(classificationSpan);

                    if (cacheClassifications && startPosition < spanStartPosition + BlockSize)
                    {
                        this.cache.Classifications.Add(classificationSpan);
                        cacheEndPosition = endPosition;
                    }

                    int startLine = span.Snapshot.GetLineFromPosition(startPosition).LineNumber;
                    int endLine = span.Snapshot.GetLineFromPosition(endPosition - 1).LineNumber;
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
                            if (tokenSpan.Start < span.Start)
                            {
                                Invalidate(new SnapshotSpan(tokenSpan.Start, span.Start));
                            }
                            if (tokenSpan.End > span.End)
                            {
                                Invalidate(new SnapshotSpan(span.End, tokenSpan.End));
                            }
                        }
                    }
                }
                else if (cacheClassifications && startPosition < spanStartPosition + BlockSize)
                {
                    var classification = this.GetClassificationType(tokenType, this.lexer.CurrentMode);
                    var tokenSpan = new SnapshotSpan(span.Snapshot, startPosition, (endPosition - startPosition));
                    var classificationSpan = new ClassificationSpan(tokenSpan, classification);
                    this.cache.Classifications.Add(classificationSpan);
                    cacheEndPosition = endPosition;
                }
                if (endPosition > blockStartPosition + BlockSize || endPosition >= spanEndPosition)
                {
                    if (span.Snapshot.Version != blockVersion)
                    {
                        TrackedBlock block = new TrackedBlock();
                        block.Block = span.Snapshot.CreateTrackingSpan(Span.FromBounds(blockStartPosition, endPosition), SpanTrackingMode.EdgeExclusive);
                        block.Version = span.Snapshot.Version;
                        block.StartState = startState;
                        block.EndState = this.SaveLexerState();

                        newTrackedBlocks.Add(block);

                        startState = block.EndState;
                        blockStartPosition = endPosition;
                    }
                }

                startPosition = endPosition;
            }
            while (token != null && startPosition < spanEndPosition);

            if (span.Snapshot.Version != blockVersion)
            {
                SnapshotSpan fullSpan = new SnapshotSpan(span.Snapshot, Span.FromBounds(spanStartPosition, spanEndPosition));
                this.InsertNewTrackedBlocks(newTrackedBlocks, fullSpan);
            }

            this.cache.Position = endPosition;
            this.cache.Mode = this.lexer.CurrentMode;
            this.cache.ModeStack = this.lexer.ModeStack.Count > 0 ? this.lexer.ModeStack.ToArray() : null;

            if (cacheClassifications)
            {
                this.cache.ClassificationSpan = Span.FromBounds(cacheStartPosition, cacheEndPosition);
            }

            return result;
        }

        protected virtual LexerState SaveLexerState()
        {
            if (this.lexer.CurrentMode == 0 && this.lexer.ModeStack.Count == 0) return null;
            LexerState state = new LexerState(this.lexer);
            return state;
        }

        private SnapshotSpan Union(ITextSnapshot textSnapshot, Span span1, Span span2)
        {
            return new SnapshotSpan(
                textSnapshot,
                Span.FromBounds(
                    span1.Start < span2.Start ? span1.Start : span2.Start,
                    span1.End > span2.End ? span1.End : span2.End));
        }

        private bool InvalidateMultiLineTokens(SnapshotSpan span, List<ClassificationSpan> classifications, out int startPosition, out int endPosition)
        {
            bool result = false;
            startPosition = span.Start.Position;
            endPosition = span.End.Position;

            ValueTuple<int, int> range = this.FindMultiLineTokenRange(span);
            int startIndex = range.Item1;
            int endIndex = range.Item2;
            if(endIndex >= this.multiLineTokens.Count)
            {
                endIndex = this.multiLineTokens.Count - 1;
            }

            bool invalidate = false;
            SnapshotSpan spanToInvalidate = span;

            for (var i = endIndex; i >= startIndex; i--)
            {
                var multiLineTokenSpan = multiLineTokens[i].Tracking.GetSpan(span.Snapshot);
                if (multiLineTokenSpan.Length == 0)
                {
                    multiLineTokens.RemoveAt(i);
                }
                else
                {
                    if (span.OverlapsWith(multiLineTokenSpan) && !span.Contains(multiLineTokenSpan))
                    {
                        if (span.Snapshot.Version != multiLineTokens[i].Version)
                        {
                            multiLineTokens.RemoveAt(i);
                            invalidate = true;
                            spanToInvalidate = this.Union(span.Snapshot, spanToInvalidate, multiLineTokenSpan);
                        }
                        else
                        {
                            classifications.Add(new ClassificationSpan(multiLineTokenSpan, multiLineTokens[i].ClassificationType));
                            if (multiLineTokenSpan.Contains(span))
                            {
                                return true;
                            }
                            else
                            {
                                if (startPosition < multiLineTokenSpan.End.Position && endPosition > multiLineTokenSpan.End.Position)
                                {
                                    startPosition = multiLineTokenSpan.End.Position;
                                }
                                if (startPosition < multiLineTokenSpan.Start.Position && endPosition > multiLineTokenSpan.Start.Position)
                                {
                                    endPosition = multiLineTokenSpan.Start.Position;
                                }
                            }
                        }
                    }
                }
            }
            if (invalidate)
            {
                startPosition = spanToInvalidate.Start;
                endPosition = spanToInvalidate.End;
                Invalidate(spanToInvalidate);
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

        private bool BlocksMatch(TrackedBlock first, TrackedBlock second)
        {
            return (first.EndState == null && second.StartState == null) ||
                (first.EndState != null && first.EndState.Equals(second.StartState));
        }

        private void InsertNewTrackedBlocks(List<TrackedBlock> newTrackedBlocks, SnapshotSpan span)
        {
            if (newTrackedBlocks == null || newTrackedBlocks.Count == 0) return;

            TrackedBlock lastBlock = newTrackedBlocks[newTrackedBlocks.Count - 1];

            int startPoint = newTrackedBlocks[0].Block.GetStartPoint(span.Snapshot);
            int endPoint = lastBlock.Block.GetEndPoint(span.Snapshot);
            SnapshotSpan fullSpan = new SnapshotSpan(span.Snapshot, startPoint, endPoint - startPoint - 1);

            ValueTuple<int, int> range = this.FindTrackedBlockRange(fullSpan);
            int startIndex = range.Item1;
            int endIndex = range.Item2;
            if (endIndex >= this.trackedBlocks.Count)
            {
                endIndex = this.trackedBlocks.Count - 1;
            }

            bool insert = false;
            if (endIndex >= startIndex)
            {
                for (int i = endIndex; i >= startIndex; i--)
                {
                    if (this.trackedBlocks[i].Version != span.Snapshot.Version)
                    {
                        insert = true;
                        break;
                    }
                }
                if (insert)
                {
                    this.trackedBlocks.RemoveRange(startIndex, endIndex - startIndex + 1);
                    this.trackedBlocks.InsertRange(startIndex, newTrackedBlocks);
                    if (endIndex+1 < this.trackedBlocks.Count)
                    {
                        TrackedBlock nextBlock = trackedBlocks[endIndex + 1];
                        int nextBlockStart = nextBlock.Block.GetStartPoint(span.Snapshot);
                        int nextBlockEnd = nextBlock.Block.GetEndPoint(span.Snapshot);
                        if (nextBlockStart > endPoint || !this.BlocksMatch(lastBlock, nextBlock))
                        {
                            SnapshotSpan invalidateSpan = new SnapshotSpan(span.Snapshot, Span.FromBounds(endPoint, nextBlockEnd));
                            Invalidate(invalidateSpan);
                        }
                    }
                }
            }
            else
            {
                this.trackedBlocks.InsertRange(startIndex, newTrackedBlocks);
            }
        }

        private TrackedBlock InvalidateTrackedBlocks(SnapshotSpan span, out int startPosition, out int endPosition, out ITextVersion blockVersion)
        {
            startPosition = span.Start.Position;
            endPosition = span.End.Position;

            ValueTuple<int, int> range = this.FindTrackedBlockRange(span);
            int startIndex = range.Item1;
            int endIndex = range.Item2;
            if (endIndex >= this.trackedBlocks.Count)
            {
                endIndex = this.trackedBlocks.Count - 1;
            }

            blockVersion = null;
            ITextVersion version = null;
            for (var i = endIndex; i >= startIndex; i--)
            {
                var trackedBlock = this.trackedBlocks[i];
                var trackedBlockSpan = trackedBlock.Block.GetSpan(span.Snapshot);
                if (span.OverlapsWith(trackedBlockSpan))
                {
                    if (trackedBlockSpan.Start.Position < startPosition) startPosition = trackedBlockSpan.Start.Position;
                    if (trackedBlockSpan.End.Position > endPosition) endPosition = trackedBlockSpan.End.Position;
                    if (version == null)
                    {
                        version = trackedBlock.Version;
                        blockVersion = version;
                    }
                    else if (trackedBlock.Version != version)
                    {
                        blockVersion = null;
                    }
                }
            }
            if (startIndex-1 >= 0 && startIndex-1 < this.trackedBlocks.Count)
            {
                return this.trackedBlocks[startIndex-1];
            }
            else
            {
                return default(TrackedBlock);
            }
        }

        private ValueTuple<int, int> FindTrackedBlockRange(SnapshotSpan span)
        {
            int startIndex = this.FindTrackedBlockIndex(span.Start, span, false);
            //int endIndex = this.FindTrackedBlockIndex(span.End, span, false);
            int endPosition = span.End.Position;
            int endIndex = startIndex;
            while (endIndex < this.trackedBlocks.Count)
            {
                SnapshotSpan trackedBlockSpan = this.trackedBlocks[endIndex].Block.GetSpan(span.Snapshot);
                if (trackedBlockSpan.Contains(endPosition))
                {
                    break;
                }
                ++endIndex;
            }
            return new ValueTuple<int, int>(startIndex, endIndex);
        }

        private int FindTrackedBlockIndex(int position, SnapshotSpan span, bool inside)
        {
            int firstIndex = 0;
            int lastIndex = this.trackedBlocks.Count - 1;
            while (firstIndex <= lastIndex)
            {
                int currentIndex = (firstIndex + lastIndex) / 2;
                SnapshotSpan trackedBlockSpan = this.trackedBlocks[currentIndex].Block.GetSpan(span.Snapshot);
                if (trackedBlockSpan.Contains(position))
                {
                    return currentIndex;
                }
                else if (position < trackedBlockSpan.Start)
                {
                    lastIndex = currentIndex - 1;
                }
                else if (position >= trackedBlockSpan.End)
                {
                    firstIndex = currentIndex + 1;
                }
            }
            if (inside) return -1;
            else return firstIndex;
        }

        protected abstract IClassificationType GetClassificationType(int tokenType, int mode);

        private class Cache
        {
            public ITextVersion Version;
            public TrackedBlock PrevBlock;
            public ITrackingSpan Range;
            public int Position;
            public int Mode;
            public int[] ModeStack;
            public int ClassificationIndex;
            public Span ClassificationSpan;
            public List<ClassificationSpan> Classifications = new List<ClassificationSpan>();
        }
    }
}
