using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public struct SlidingBufferResetPoint
    {
        public readonly int ResetCount;
        public readonly int Position;

        internal SlidingBufferResetPoint(int resetCount, int position)
        {
            this.ResetCount = resetCount;
            this.Position = position;
        }
    }
}
