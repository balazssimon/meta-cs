using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Utilities
{
    internal static class ISetExtensions
    {
        public static bool AddAll<T>(this ISet<T> set, IEnumerable<T> values)
        {
            var result = false;
            foreach (var v in values)
            {
                result |= set.Add(v);
            }

            return result;
        }

        public static bool RemoveAll<T>(this ISet<T> set, IEnumerable<T> values)
        {
            var result = false;
            foreach (var v in values)
            {
                result |= set.Remove(v);
            }

            return result;
        }
    }
}
