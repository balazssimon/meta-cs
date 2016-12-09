using MetaDslx.Compiler.Core.Diagnostics;
using MetaDslx.Compiler.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Core.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxList : GreenNode
    {
        private readonly int[] _childOffsets;
        private readonly GreenNode[] children;

        protected InternalSyntaxList(int kind, GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations) 
            : base(kind, 0, diagnostics, annotations)
        {
            this.children = children;
            this.InitializeChildren();
            _childOffsets = CalculateOffsets(children);
        }

        public override bool IsList
        {
            get { return true; }
        }

        private void InitializeChildren()
        {
            int n = children.Length;
            if (n < byte.MaxValue)
            {
                this.SlotCount = (byte)n;
            }
            else
            {
                this.SlotCount = byte.MaxValue;
            }

            for (int i = 0; i < children.Length; i++)
            {
                this.AdjustFlagsAndWidth(children[i]);
            }
        }

        public override int GetSlotCount()
        {
            return children.Length;
        }

        public override GreenNode GetSlot(int index)
        {
            return this.children[index];
        }

        public override int GetSlotOffset(int index)
        {
            return _childOffsets[index];
        }

        /// <summary>
        /// Find the slot that contains the given offset.
        /// </summary>
        /// <param name="offset">The target offset. Must be between 0 and <see cref="GreenNodeBase.FullWidth"/>.</param>
        /// <returns>The slot index of the slot containing the given offset.</returns>
        /// <remarks>
        /// This implementation uses a binary search to find the first slot that contains
        /// the given offset.
        /// </remarks>
        public override int FindSlotIndexContainingOffset(int offset)
        {
            Debug.Assert(offset >= 0 && offset < FullWidth);
            return CollectionUtilities.BinarySearchUpperBound(_childOffsets, offset) - 1;
        }

        private static int[] CalculateOffsets(GreenNode[] children)
        {
            int n = children.Length;
            var childOffsets = new int[n];
            int offset = 0;
            for (int i = 0; i < n; i++)
            {
                childOffsets[i] = offset;
                offset += children[i].FullWidth;
            }
            return childOffsets;
        }
    }
}
