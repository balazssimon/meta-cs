using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Utilities
{
    internal static class ArrayUtilities
    {
        internal static ImmutableArray<T> ToImmutableArrayOrEmpty<T>(IEnumerable<T> items)
        {
            if (items == null)
            {
                return ImmutableArray.Create<T>();
            }

            return ImmutableArray.CreateRange<T>(items);
        }

        internal static ImmutableArray<T> ToImmutableArrayOrEmpty<T>(ImmutableArray<T> items)
        {
            if (items.IsDefault)
            {
                return ImmutableArray.Create<T>();
            }

            return items;
        }

        // same as Array.BinarySearch but the ability to pass arbitrary value to the comparer without allocation
        internal static int BinarySearch<TElement, TValue>(ImmutableArray<TElement> array, TValue value, Func<TElement, TValue, int> comparer)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int middle = low + ((high - low) >> 1);
                int comparison = comparer(array[middle], value);

                if (comparison == 0)
                {
                    return middle;
                }

                if (comparison > 0)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }

            return ~low;
        }

        // same as Array.BinarySearch, but without using IComparer to compare ints
        internal static int BinarySearch(int[] array, int value)
        {
            var low = 0;
            var high = array.Length - 1;

            while (low <= high)
            {
                var middle = low + ((high - low) >> 1);
                var midValue = array[middle];

                if (midValue == value)
                {
                    return middle;
                }
                else if (midValue > value)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }

            return ~low;
        }

        /// <summary>
        /// Search a sorted integer array for the target value in O(log N) time.
        /// </summary>
        /// <param name="array">The array of integers which must be sorted in ascending order.</param>
        /// <param name="value">The target value.</param>
        /// <returns>An index in the array pointing to the position where <paramref name="value"/> should be
        /// inserted in order to maintain the sorted order. All values to the right of this position will be
        /// strictly greater than <paramref name="value"/>. Note that this may return a position off the end
        /// of the array if all elements are less than or equal to <paramref name="value"/>.</returns>
        internal static int BinarySearchUpperBound(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int middle = low + ((high - low) >> 1);
                if (array[middle] > value)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }

            return low;
        }

    }
}
