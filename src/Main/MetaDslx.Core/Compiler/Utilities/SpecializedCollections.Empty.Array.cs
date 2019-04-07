using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Utilities
{
    internal static partial class SpecializedCollections
    {
        private static partial class Empty
        {
            internal static class Array<T> 
            {
                public static readonly T[] Instance = new T[0];
            }
        }
    }
}
