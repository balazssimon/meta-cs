using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Utilities
{
    public static class EmptyArray<T>
    {
        public static readonly T[] Instance = new T[0];
    }
}
