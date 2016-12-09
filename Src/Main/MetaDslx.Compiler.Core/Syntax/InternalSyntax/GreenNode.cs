using MetaDslx.Compiler.Core.Diagnostics;
using MetaDslx.Compiler.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Core.Syntax.InternalSyntax
{
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract class GreenNode
    {
        private string GetDebuggerDisplay()
        {
            return this.GetType().Name + " " + this.KindText + " " + this.ToString();
        }

        private readonly int _kind;
        private NodeFlags flags;
        private byte _slotCount;
        private int _fullWidth;

        private static readonly ConditionalWeakTable<GreenNode, DiagnosticInfo[]> s_diagnosticsTable =
            new ConditionalWeakTable<GreenNode, DiagnosticInfo[]>();

        private static readonly ConditionalWeakTable<GreenNode, SyntaxAnnotation[]> s_annotationsTable =
            new ConditionalWeakTable<GreenNode, SyntaxAnnotation[]>();

        private static readonly DiagnosticInfo[] s_noDiagnostics = new DiagnosticInfo[0];
        private static readonly SyntaxAnnotation[] s_noAnnotations = new SyntaxAnnotation[0];
        private static readonly IEnumerable<SyntaxAnnotation> s_noAnnotationsEnumerable = ImmutableArray<SyntaxAnnotation>.Empty;

        protected GreenNode(int kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
        {
            _kind = kind;
            _fullWidth = fullWidth;
            if (diagnostics?.Length > 0)
            {
                this.flags |= NodeFlags.ContainsDiagnostics;
                s_diagnosticsTable.Add(this, diagnostics);
            }
            if (annotations?.Length > 0)
            {
                foreach (var annotation in annotations)
                {
                    if (annotation == null) throw new ArgumentException(paramName: nameof(annotations), message: "" /*CSharpResources.ElementsCannotBeNull*/);
                }

                this.flags |= NodeFlags.ContainsAnnotations;
                s_annotationsTable.Add(this, annotations);
            }
        }

        protected void AdjustFlagsAndWidth(GreenNode node)
        {
            Debug.Assert(node != null, "PERF: caller must ensure that node!=null, we do not want to re-check that here.");
            this.flags |= (node.flags & NodeFlags.InheritMask);
            _fullWidth += node._fullWidth;
        }

        public abstract Language Language { get; }

        public int RawKind
        {
            get { return _kind; }
        }

        public string KindText
        {
            get { return this.Language.SyntaxFacts.GetKindText(_kind); }
        }
        public virtual bool IsStructuredTrivia { get { return false; } }
        public virtual bool IsDirective { get { return false; } }
        public virtual bool IsToken { get { return false; } }
        public virtual bool IsNode { get { return false; } }
        public virtual bool IsTrivia { get { return false; } }
        public virtual bool IsList { get { return false; } }

        public int SlotCount
        {
            get
            {
                int count = _slotCount;
                if (count == byte.MaxValue)
                {
                    count = GetSlotCount();
                }

                return count;
            }

            protected set
            {
                _slotCount = (byte)value;
            }
        }

        public abstract GreenNode GetSlot(int index);

        // for slot counts >= byte.MaxValue
        public virtual int GetSlotCount()
        {
            return _slotCount;
        }

        public virtual int GetSlotOffset(int index)
        {
            // This implementation should not support arbitrary
            // length lists since the implementation is O(n).
            // Should be overriden in syntax lists with a more
            // efficient implementation.

            int offset = 0;
            for (int i = 0; i < index; i++)
            {
                var child = this.GetSlot(i);
                if (child != null)
                {
                    offset += child.FullWidth;
                }
            }

            return offset;
        }

        /// <summary>
        /// Find the slot that contains the given offset.
        /// </summary>
        /// <param name="offset">The target offset. Must be between 0 and <see cref="FullWidth"/>.</param>
        /// <returns>The slot index of the slot containing the given offset.</returns>
        /// <remarks>
        /// The base implementation is a linear search. This should be overridden
        /// if a derived class can implement it more efficiently.
        /// </remarks>
        public virtual int FindSlotIndexContainingOffset(int offset)
        {
            Debug.Assert(0 <= offset && offset < FullWidth);

            int i;
            int accumulatedWidth = 0;
            for (i = 0; ; i++)
            {
                Debug.Assert(i < SlotCount);
                var child = GetSlot(i);
                if (child != null)
                {
                    accumulatedWidth += child.FullWidth;
                    if (offset < accumulatedWidth)
                    {
                        break;
                    }
                }
            }

            return i;
        }

        [Flags]
        internal protected enum NodeFlags : byte
        {
            None = 0,
            ContainsDiagnostics = 1 << 0,
            ContainsStructuredTrivia = 1 << 1,
            ContainsDirectives = 1 << 2,
            ContainsSkippedText = 1 << 3,
            ContainsAnnotations = 1 << 4,
            IsMissing = 1 << 5,

            InheritMask = byte.MaxValue,
        }

        internal NodeFlags Flags
        {
            get { return this.flags; }
        }

        internal void SetFlags(NodeFlags flags)
        {
            this.flags |= flags;
        }

        internal void ClearFlags(NodeFlags flags)
        {
            this.flags &= ~flags;
        }

        public bool IsMissing
        {
            get
            {
                return (this.flags & NodeFlags.IsMissing) != 0;
            }
        }

        public bool ContainsSkippedText
        {
            get
            {
                return (this.flags & NodeFlags.ContainsSkippedText) != 0;
            }
        }

        public bool ContainsStructuredTrivia
        {
            get
            {
                return (this.flags & NodeFlags.ContainsStructuredTrivia) != 0;
            }
        }

        public bool ContainsDirectives
        {
            get
            {
                return (this.flags & NodeFlags.ContainsDirectives) != 0;
            }
        }

        public bool ContainsDiagnostics
        {
            get
            {
                return (this.flags & NodeFlags.ContainsDiagnostics) != 0;
            }
        }

        public bool ContainsAnnotations
        {
            get
            {
                return (this.flags & NodeFlags.ContainsAnnotations) != 0;
            }
        }

        public int FullWidth
        {
            get
            {
                return _fullWidth;
            }

            protected set
            {
                _fullWidth = value;
            }
        }

        public virtual int Width
        {
            get
            {
                return _fullWidth - this.GetLeadingTriviaWidth() - this.GetTrailingTriviaWidth();
            }
        }

        public virtual int GetLeadingTriviaWidth()
        {
            return this.FullWidth != 0 ?
                this.GetFirstTerminal().GetLeadingTriviaWidth() :
                0;
        }

        public virtual int GetTrailingTriviaWidth()
        {
            return this.FullWidth != 0 ?
                this.GetLastTerminal().GetTrailingTriviaWidth() :
                0;
        }

        public bool HasLeadingTrivia
        {
            get
            {
                return this.GetLeadingTriviaWidth() != 0;
            }
        }

        public bool HasTrailingTrivia
        {
            get
            {
                return this.GetTrailingTriviaWidth() != 0;
            }
        }

        public bool HasAnnotations(string annotationKind)
        {
            var annotations = this.GetAnnotations();
            if (annotations == s_noAnnotations)
            {
                return false;
            }

            foreach (var a in annotations)
            {
                if (a.Kind == annotationKind)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasAnnotations(IEnumerable<string> annotationKinds)
        {
            var annotations = this.GetAnnotations();
            if (annotations == s_noAnnotations)
            {
                return false;
            }

            foreach (var a in annotations)
            {
                if (annotationKinds.Contains(a.Kind))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasAnnotation(SyntaxAnnotation annotation)
        {
            var annotations = this.GetAnnotations();
            if (annotations == s_noAnnotations)
            {
                return false;
            }

            foreach (var a in annotations)
            {
                if (a == annotation)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<SyntaxAnnotation> GetAnnotations(string annotationKind)
        {
            if (string.IsNullOrWhiteSpace(annotationKind))
            {
                throw new ArgumentNullException(nameof(annotationKind));
            }

            var annotations = this.GetAnnotations();

            if (annotations == s_noAnnotations)
            {
                return s_noAnnotationsEnumerable;
            }

            return GetAnnotationsSlow(annotations, annotationKind);
        }

        private static IEnumerable<SyntaxAnnotation> GetAnnotationsSlow(SyntaxAnnotation[] annotations, string annotationKind)
        {
            foreach (var annotation in annotations)
            {
                if (annotation.Kind == annotationKind)
                {
                    yield return annotation;
                }
            }
        }

        public IEnumerable<SyntaxAnnotation> GetAnnotations(IEnumerable<string> annotationKinds)
        {
            if (annotationKinds == null)
            {
                throw new ArgumentNullException(nameof(annotationKinds));
            }

            var annotations = this.GetAnnotations();

            if (annotations == s_noAnnotations)
            {
                return s_noAnnotationsEnumerable;
            }

            return GetAnnotationsSlow(annotations, annotationKinds);
        }

        private static IEnumerable<SyntaxAnnotation> GetAnnotationsSlow(SyntaxAnnotation[] annotations, IEnumerable<string> annotationKinds)
        {
            foreach (var annotation in annotations)
            {
                if (annotationKinds.Contains(annotation.Kind))
                {
                    yield return annotation;
                }
            }
        }

        public SyntaxAnnotation[] GetAnnotations()
        {
            if (this.ContainsAnnotations)
            {
                SyntaxAnnotation[] annotations;
                if (s_annotationsTable.TryGetValue(this, out annotations))
                {
                    System.Diagnostics.Debug.Assert(annotations.Length != 0, "we should return nonempty annotations or NoAnnotations");
                    return annotations;
                }
            }

            return s_noAnnotations;
        }

        public abstract GreenNode SetAnnotations(SyntaxAnnotation[] annotations);

        public DiagnosticInfo[] GetDiagnostics()
        {
            if (this.ContainsDiagnostics)
            {
                DiagnosticInfo[] diags;
                if (s_diagnosticsTable.TryGetValue(this, out diags))
                {
                    return diags;
                }
            }

            return s_noDiagnostics;
        }

        public abstract GreenNode SetDiagnostics(DiagnosticInfo[] diagnostics);

        public override string ToString()
        {
            var sb = PooledStringBuilder.GetInstance();
            var writer = new System.IO.StringWriter(sb.Builder, System.Globalization.CultureInfo.InvariantCulture);
            this.WriteTo(writer, leading: false, trailing: false);
            return sb.ToStringAndFree();
        }

        public virtual string ToFullString()
        {
            var sb = PooledStringBuilder.GetInstance();
            var writer = new System.IO.StringWriter(sb.Builder, System.Globalization.CultureInfo.InvariantCulture);
            this.WriteTo(writer, leading: true, trailing: true);
            return sb.ToStringAndFree();
        }

        public virtual void WriteTo(System.IO.TextWriter writer)
        {
            this.WriteTo(writer, true, true);
        }

        protected internal virtual void WriteTo(System.IO.TextWriter writer, bool leading, bool trailing)
        {
            bool first = true;
            int n = this.SlotCount;
            int lastIndex = n - 1;
            for (; lastIndex >= 0; lastIndex--)
            {
                var child = this.GetSlot(lastIndex);
                if (child != null)
                {
                    break;
                }
            }

            for (var i = 0; i <= lastIndex; i++)
            {
                var child = this.GetSlot(i);
                if (child != null)
                {
                    child.WriteTo(writer, leading | !first, trailing | (i < lastIndex));
                    first = false;
                }
            }
        }

        internal GreenNode GetFirstTerminal()
        {
            GreenNode node = this;

            do
            {
                GreenNode firstChild = null;
                for (int i = 0, n = node.SlotCount; i < n; i++)
                {
                    var child = node.GetSlot(i);
                    if (child != null)
                    {
                        firstChild = child;
                        break;
                    }
                }
                node = firstChild;
            } while (node?._slotCount > 0);

            return node;
        }

        internal GreenNode GetLastTerminal()
        {
            GreenNode node = this;

            do
            {
                GreenNode lastChild = null;
                for (int i = node.SlotCount - 1; i >= 0; i--)
                {
                    var child = node.GetSlot(i);
                    if (child != null)
                    {
                        lastChild = child;
                        break;
                    }
                }
                node = lastChild;
            } while (node?._slotCount > 0);

            return node;
        }

        internal GreenNode GetLastNonmissingTerminal()
        {
            GreenNode node = this;

            do
            {
                GreenNode nonmissingChild = null;
                for (int i = node.SlotCount - 1; i >= 0; i--)
                {
                    var child = node.GetSlot(i);
                    if (child != null && !child.IsMissing)
                    {
                        nonmissingChild = child;
                        break;
                    }
                }
                node = nonmissingChild;
            }
            while (node?._slotCount > 0);

            return node;
        }

        public virtual bool IsEquivalentTo(GreenNode other)
        {
            if (this == other)
            {
                return true;
            }

            if (other == null)
            {
                return false;
            }

            return EquivalentToInternal(this, other);
        }

        private static bool EquivalentToInternal(GreenNode node1, GreenNode node2)
        {
            if (node1.RawKind != node2.RawKind)
            {
                // A single-element list is usually represented as just a single node,
                // but can be represented as a List node with one child. Move to that
                // child if necessary.
                if (node1.IsList && node1.SlotCount == 1)
                {
                    node1 = node1.GetSlot(0);
                }

                if (node2.IsList && node2.SlotCount == 1)
                {
                    node2 = node2.GetSlot(0);
                }

                if (node1.RawKind != node2.RawKind)
                {
                    return false;
                }
            }

            if (node1._fullWidth != node2._fullWidth)
            {
                return false;
            }

            var n = node1.SlotCount;
            if (n != node2.SlotCount)
            {
                return false;
            }

            for (int i = 0; i < n; i++)
            {
                var node1Child = node1.GetSlot(i);
                var node2Child = node2.GetSlot(i);
                if (node1Child != null && node2Child != null && !node1Child.IsEquivalentTo(node2Child))
                {
                    return false;
                }
            }

            return true;
        }

        public RedNode CreateRed()
        {
            return CreateRed(null, 0);
        }

        public abstract RedNode CreateRed(SyntaxNode parent, int position);

        internal const int MaxCachedChildNum = 3;

        internal bool IsCacheable
        {
            get
            {
                return this.flags == NodeFlags.None && this.SlotCount <= GreenNode.MaxCachedChildNum;
            }
        }

        internal int GetCacheHash()
        {
            Debug.Assert(this.IsCacheable);

            int code = (int)(this.flags) ^ this.RawKind;
            int cnt = this.SlotCount;
            for (int i = 0; i < cnt; i++)
            {
                var child = GetSlot(i);
                if (child != null)
                {
                    code = Hash.Combine(RuntimeHelpers.GetHashCode(child), code);
                }
            }

            return code & Int32.MaxValue;
        }

        internal bool IsCacheEquivalent(int kind, NodeFlags flags, GreenNode child1)
        {
            Debug.Assert(this.IsCacheable);

            return this.RawKind == kind &&
                this.flags == flags &&
                this.GetSlot(0) == child1;
        }

        internal bool IsCacheEquivalent(int kind, NodeFlags flags, GreenNode child1, GreenNode child2)
        {
            Debug.Assert(this.IsCacheable);

            return this.RawKind == kind &&
                this.flags == flags &&
                this.GetSlot(0) == child1 &&
                this.GetSlot(1) == child2;
        }

        internal bool IsCacheEquivalent(int kind, NodeFlags flags, GreenNode child1, GreenNode child2, GreenNode child3)
        {
            Debug.Assert(this.IsCacheable);

            return this.RawKind == kind &&
                this.flags == flags &&
                this.GetSlot(0) == child1 &&
                this.GetSlot(1) == child2 &&
                this.GetSlot(2) == child3;
        }
    }
}
