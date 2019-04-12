using System;
using System.Collections.Generic;
using System.Text;

namespace Roslyn.Utilities
{
    internal static class EmptyArray<T>
    {
        public static readonly T[] Instance = new T[0];
    }
}
