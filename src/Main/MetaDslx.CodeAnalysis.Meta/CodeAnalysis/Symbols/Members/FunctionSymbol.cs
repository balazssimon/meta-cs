using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a global function.
    /// </summary>
    [Symbol]
    public abstract partial class FunctionSymbol : MethodLikeSymbol
    {
        public sealed override bool IsStatic => true;
        public sealed override bool IsSealed => true;
        public sealed override bool IsAbstract => false;
        public sealed override bool IsOverride => false;
        public sealed override bool IsVirtual => false;
    }
}
