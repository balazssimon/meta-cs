using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Utilities
{
    internal static class ImmutableArrayExtensions
    {
        /// <summary>
        /// Converts a sequence to an immutable array.
        /// </summary>
        /// <typeparam name="T">Elemental type of the sequence.</typeparam>
        /// <param name="items">The sequence to convert.</param>
        /// <returns>An immutable copy of the contents of the sequence.</returns>
        /// <remarks>If the sequence is null, this will return the default (null) array.</remarks>
        public static ImmutableArray<T> AsImmutableOrNull<T>(this IEnumerable<T> items)
        {
            if (items == null)
            {
                return default(ImmutableArray<T>);
            }

            return ImmutableArray.CreateRange<T>(items);
        }

        /// <summary>
        /// Returns an empty array if the input array is null (default)
        /// </summary>
        public static ImmutableArray<T> NullToEmpty<T>(this ImmutableArray<T> array)
        {
            return array.IsDefault ? ImmutableArray<T>.Empty : array;
        }
    }
}
