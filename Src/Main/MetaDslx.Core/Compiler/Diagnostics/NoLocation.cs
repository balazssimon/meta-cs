using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    /// <summary>
    /// A class that represents no location at all. Useful for errors in command line options, for example.
    /// </summary>
    /// <remarks></remarks>
    internal sealed class NoLocation : Location
    {
        public static readonly Location Singleton = new NoLocation();

        private NoLocation()
        {
        }

        public override LocationKind Kind
        {
            get { return LocationKind.None; }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }

        public override int GetHashCode()
        {
            // arbitrary number, since all NoLocation's are equal
            return 0x16487756;
        }
    }
}
