using Antlr4.Runtime;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class TrackedBlock
    {
        public ITrackingSpan Block;
        public ITextVersion Version;
        public LexerState StartState;
        public LexerState EndState;
        public List<ClassificationSpan> CachedClassifications = new List<ClassificationSpan>();

        public void ClearCache()
        {
            this.CachedClassifications.Clear();
        }

        public void CacheClassification(ClassificationSpan classification)
        {
            this.CachedClassifications.Add(classification);
        }
    }

    internal class LexerState : IEquatable<LexerState>
    {
        public LexerState(Lexer lexer)
        {
            this.Mode = lexer._mode;
            if (lexer._modeStack != null)
            {
                this.ModeStack = lexer._modeStack.Count > 0 ? new List<int>(lexer._modeStack) : null;
            }
        }
        public int Mode { get; private set; }
        public List<int> ModeStack { get; private set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as LexerState);
        }

        public virtual bool Equals(LexerState other)
        {
            if (other == null)
            {
                return this.Mode == 0 && (this.ModeStack == null || this.ModeStack.Count == 0);
            }
            if (this.Mode != other.Mode) return false;
            if ((this.ModeStack == null || this.ModeStack.Count == 0) && (other.ModeStack == null || other.ModeStack.Count == 0)) return true;
            if (this.ModeStack == null || other.ModeStack == null) return false;
            if (this.ModeStack.Count != other.ModeStack.Count) return false;
            for (int i = 0; i < this.ModeStack.Count; i++)
            {
                if (this.ModeStack[i] != other.ModeStack[i]) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Mode, this.ModeStack.GetHashCode());
        }

        public virtual void Restore(Lexer lexer)
        {
            lexer._mode = this.Mode;
            lexer._modeStack.Clear();
            if (this.ModeStack != null && this.ModeStack.Count > 0)
            {
                lexer._modeStack.AddRange(this.ModeStack);
            }
        }

    }

    internal abstract class Antlr4LexerClassifier : IClassifier
    {
        private const int BlockSize = 256;
        public static readonly ICharStream EmptyCharStream = new AntlrInputStream();

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        protected ITextBuffer textBuffer;
        protected IClassificationTypeRegistryService classificationRegistryService;
        protected Lexer lexer;
        private List<TrackedBlock> trackedBlocks = new List<TrackedBlock>();
        private List<TrackedBlock> cachedBlocks = new List<TrackedBlock>();

        internal Antlr4LexerClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService, Lexer lexer)
        {
            this.textBuffer = textBuffer;
            this.classificationRegistryService = classificationRegistryService;
            this.lexer = lexer;
            this.UpdateBlocks(new SnapshotSpan(this.textBuffer.CurrentSnapshot, 0, this.textBuffer.CurrentSnapshot.Length), false);
        }

        //Invoke ClassificationChanged that cause editor to re-classify specified span 
        protected void Invalidate(SnapshotSpan span)
        {
            if (ClassificationChanged != null)
                ClassificationChanged(this, new ClassificationChangedEventArgs(span));
        }

        protected virtual LexerState SaveLexerState()
        {
            LexerState state = new LexerState(this.lexer);
            return state;
        }

        protected abstract IClassificationType GetClassificationType(int tokenType, int mode);

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            List<ClassificationSpan> result = new List<ClassificationSpan>();
            this.UpdateBlocks(span, true);
            int position = span.Start.Position;
            int index = this.FindBlockIndex(span, span.Start.Position, false);
            while (index < this.trackedBlocks.Count)
            {
                TrackedBlock block = this.trackedBlocks[index];
                this.CacheBlock(span, block);
                int classificationStartPosition = block.Block.GetStartPoint(span.Snapshot);
                int classificationIndex = 0;
                while(classificationIndex < block.CachedClassifications.Count && position < span.End.Position)
                {
                    ClassificationSpan classification = block.CachedClassifications[classificationIndex];
                    int classificationEndPosition = classificationStartPosition + classification.Span.Length;
                    if (span.OverlapsWith(Span.FromBounds(classificationStartPosition, classificationEndPosition)))
                    {
                        result.Add(classification);
                    }
                    ++classificationIndex;
                    classificationStartPosition = classificationEndPosition;
                    if (classificationEndPosition >= span.End.Position) return result;
                }
                ++index;
            }
            return result;
        }

        private void UpdateBlocks(SnapshotSpan span, bool cache)
        {
            int index = this.FindBlockIndex(span, span.Start.Position, false);
            while (index < this.trackedBlocks.Count)
            {
                TrackedBlock block = this.trackedBlocks[index];
                Span blockSpan = block.Block.GetSpan(span.Snapshot);
                if (blockSpan.Length == 0)
                {
                    this.trackedBlocks.RemoveAt(index);
                }
                else
                {
                    if (blockSpan.Start >= span.End.Position)
                    {
                        return;
                    }
                    if (block.Version != span.Snapshot.Version || (cache && block.CachedClassifications.Count == 0 && blockSpan.Length > 0))
                    {
                        this.UpdateBlock(span, ref index, cache);
                    }
                    ++index;
                }
            }
            this.AddBlocksToEnd(span, cache);
        }

        private void AddBlocksToEnd(SnapshotSpan span, bool cache)
        {
            TrackedBlock prevBlock = null;
            int prevBlockEnd = 0;
            if (this.trackedBlocks.Count > 0)
            {
                prevBlock = this.trackedBlocks[this.trackedBlocks.Count - 1];
                prevBlockEnd = prevBlock.Block.GetEndPoint(span.Snapshot);
                if (prevBlockEnd >= span.End.Position)
                {
                    return;
                }
            }
            int nextBlockEnd = Math.Min(prevBlockEnd + BlockSize, span.Snapshot.Length);
            if (nextBlockEnd > prevBlockEnd)
            {
                TrackedBlock nextBlock = new TrackedBlock();
                nextBlock.Block = span.Snapshot.CreateTrackingSpan(Span.FromBounds(prevBlockEnd, nextBlockEnd), SpanTrackingMode.EdgeExclusive);
                nextBlock.StartState = prevBlock?.EndState;
                this.trackedBlocks.Add(nextBlock);
                int index = this.trackedBlocks.Count - 1;
                this.UpdateBlock(span, ref index, cache);
            }
        }

        private void UpdateBlock(SnapshotSpan span, ref int index, bool cache)
        {
            bool invalidate = false;
            TrackedBlock block = this.trackedBlocks[index];
            while (block != null)
            {
                Span blockSpan = block.Block.GetSpan(span.Snapshot);
                this.LexBlock(span, block, cache && (blockSpan.Start < span.End.Position));
                blockSpan = block.Block.GetSpan(span.Snapshot);
                if (invalidate) this.InvalidateBlock(span, block);

                TrackedBlock nextBlock = null;
                ++index;
                if (index < this.trackedBlocks.Count)
                {
                    while (index < this.trackedBlocks.Count)
                    {
                        nextBlock = this.trackedBlocks[index];
                        Span nextBlockSpan = nextBlock.Block.GetSpan(span.Snapshot);
                        if (nextBlockSpan.End <= blockSpan.End)
                        {
                            this.trackedBlocks.RemoveAt(index);
                        }
                        else if (nextBlockSpan.Start > blockSpan.End)
                        {
                            int nextBlockEnd = Math.Min(blockSpan.End + BlockSize, nextBlockSpan.Start);
                            nextBlock = new TrackedBlock();
                            nextBlock.Block = span.Snapshot.CreateTrackingSpan(Span.FromBounds(blockSpan.End, nextBlockEnd), SpanTrackingMode.EdgeExclusive);
                            nextBlock.StartState = block.EndState;
                            this.trackedBlocks.Insert(index, nextBlock);
                            break;
                        }
                        else
                        {
                            if (nextBlockSpan.Start == blockSpan.End && nextBlock.StartState.Equals(block.EndState))
                            {
                                return;
                            }
                            else
                            {
                                nextBlock.Block = span.Snapshot.CreateTrackingSpan(Span.FromBounds(blockSpan.End, nextBlockSpan.End), SpanTrackingMode.EdgeExclusive);
                                nextBlock.StartState = block.EndState;
                                break;
                            }
                        }
                    }
                }
                else if (blockSpan.End < span.End.Position)
                {
                    int nextBlockEnd = Math.Min(blockSpan.End + BlockSize, span.Snapshot.Length);
                    nextBlock = new TrackedBlock();
                    nextBlock.Block = span.Snapshot.CreateTrackingSpan(Span.FromBounds(blockSpan.End, nextBlockEnd), SpanTrackingMode.EdgeExclusive);
                    nextBlock.StartState = block.EndState;
                    this.trackedBlocks.Add(nextBlock);
                }
                block = nextBlock;
                invalidate = true;
            }
        }

        private void InvalidateBlockEdge(SnapshotSpan span, TrackedBlock block)
        {
            Span blockSpan = block.Block.GetSpan(span.Snapshot);
            if (span.Contains(blockSpan)) return;
            int startIndex = -1;
            int endIndex = -1;
            for (int i = 0; i < block.CachedClassifications.Count; i++)
            {
                Span classificationSpan = block.CachedClassifications[i].Span.Span;
                if (classificationSpan.Contains(span.Start.Position))
                {
                    startIndex = i;
                }
                if (classificationSpan.Contains(span.End.Position))
                {
                    endIndex = i;
                    break;
                }
            }
            if (startIndex >= 0)
            {
                Span classificationSpan = block.CachedClassifications[startIndex].Span.Span;
                if (classificationSpan.Start < span.Start.Position)
                {
                    this.Invalidate(this.CreateSnapshotSpan(span, classificationSpan.Start, span.Start.Position));
                }
            }
            if (span.End.Position > blockSpan.Start && span.End.Position < blockSpan.End)
            {
                this.Invalidate(this.CreateSnapshotSpan(span, span.End.Position, blockSpan.End));
            }
        }

        private void InvalidateBlock(SnapshotSpan span, TrackedBlock block)
        {
            Span blockSpan = block.Block.GetSpan(span.Snapshot);
            if (span.Contains(blockSpan)) return;
            if (span.Start.Position > blockSpan.Start && span.Start.Position < blockSpan.End)
            {
                this.Invalidate(this.CreateSnapshotSpan(span, blockSpan.Start, span.Start.Position));
            }
            if (span.End.Position > blockSpan.Start && span.End.Position < blockSpan.End)
            {
                this.Invalidate(this.CreateSnapshotSpan(span, span.End.Position, blockSpan.End));
            }
            if (span.Start.Position >= blockSpan.End || span.End.Position <= blockSpan.Start)
            {
                this.Invalidate(this.CreateSnapshotSpan(span, blockSpan.Start, blockSpan.End));
            }
        }

        private void CacheBlock(SnapshotSpan span, TrackedBlock block)
        {
            if (block.CachedClassifications.Count == 0)
            {
                this.LexBlock(span, block, true);
            }
        }

        private void LexBlock(SnapshotSpan span, TrackedBlock block, bool cache)
        {
            this.InvalidateBlockEdge(span, block);
            block.ClearCache();
            block.Version = span.Snapshot.Version;

            Span textSpan = block.Block.GetSpan(span.Snapshot);
            string text = span.Snapshot.GetText(textSpan);
            this.lexer.Reset();
            this.lexer.SetInputStream(new AntlrInputStream(text));
            if (block.StartState == null)
            {
                block.StartState = this.SaveLexerState();
            }
            else
            {
                block.StartState.Restore(this.lexer);
            }

            IToken token = null;
            int tokenType = -1;
            int startPosition = textSpan.Start;
            int endPosition = startPosition;
            int blockEnd = startPosition + BlockSize;
            do
            {
                LexerState state = this.SaveLexerState();
                token = lexer.NextToken();

                if (lexer._hitEOF)
                {
                    tokenType = -1;
                    endPosition = textSpan.End;
                }
                else if(token != null)
                {
                    tokenType = token.Type;
                    endPosition += token.StopIndex - token.StartIndex + 1;
                }
                if (token == null || tokenType < 0)
                {
                    int textLength = endPosition - startPosition;
                    int delta = 0;
                    tokenType = -1;
                    while (tokenType < 0 && startPosition + textLength < span.Snapshot.Length)
                    {
                        delta += 1024;
                        textLength += Math.Min(span.Snapshot.Length - startPosition - textLength, delta);
                        string currentText = span.Snapshot.GetText(startPosition, textLength);
                        textLength = currentText.Length;

                        this.lexer.Reset();
                        this.lexer.SetInputStream(new AntlrInputStream(currentText));
                        state.Restore(this.lexer);

                        token = lexer.NextToken();

                        if (lexer._hitEOF)
                        {
                            endPosition = startPosition + textLength;
                        }
                        else if (token != null)
                        {
                            tokenType = token.Type;
                            endPosition = startPosition + token.StopIndex - token.StartIndex + 1;
                        }
                        else
                        {
                            endPosition = startPosition + textLength;
                        }
                    }
                }

                if (cache)
                {
                    var classification = this.GetClassificationType(tokenType, this.lexer._mode);
                    var tokenSpan = this.CreateSnapshotSpan(span, startPosition, endPosition);
                    var classificationSpan = new ClassificationSpan(tokenSpan, classification);
                    block.CacheClassification(classificationSpan);
                }

                startPosition = endPosition;
            }
            while (token != null && startPosition < textSpan.End && startPosition < blockEnd);

            Span blockSpan = Span.FromBounds(textSpan.Start, endPosition);
            block.Block = span.Snapshot.CreateTrackingSpan(blockSpan, textSpan.Start == 0 ? SpanTrackingMode.EdgeInclusive : SpanTrackingMode.EdgePositive);
            block.EndState = this.SaveLexerState();
            this.InvalidateBlockEdge(span, block);
        }

        private SnapshotSpan CreateSnapshotSpan(SnapshotSpan span, int startPosition, int endPosition)
        {
            if (startPosition < 0) startPosition = 0;
            if (endPosition > span.Snapshot.Length) endPosition = span.Snapshot.Length;
            if (startPosition < endPosition)
            {
                return new SnapshotSpan(span.Snapshot, Span.FromBounds(startPosition, endPosition));
            }
            else
            {
                return new SnapshotSpan(span.Snapshot, Span.FromBounds(startPosition, startPosition));
            }
        }

        private int FindBlockIndex(SnapshotSpan span, int position, bool inside)
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

        private ValueTuple<int,int> FindBlockRange(SnapshotSpan span, Span range)
        {
            ValueTuple<int, int> result = new ValueTuple<int, int>();
            int firstIndex = this.FindBlockIndex(span, range.Start, false);
            result.Item1 = firstIndex;
            int lastIndex = this.trackedBlocks.Count - 1;
            int position = range.End;
            while (firstIndex <= lastIndex)
            {
                int currentIndex = (firstIndex + lastIndex) / 2;
                SnapshotSpan trackedBlockSpan = this.trackedBlocks[currentIndex].Block.GetSpan(span.Snapshot);
                if (trackedBlockSpan.Contains(position))
                {
                    result.Item2 = currentIndex;
                    return result;
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
            if (firstIndex >= this.trackedBlocks.Count)
            {
                firstIndex = this.trackedBlocks.Count - 1;
            }
            result.Item2 = firstIndex;
            return result;
        }
    }
}
