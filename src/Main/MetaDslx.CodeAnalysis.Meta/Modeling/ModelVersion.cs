using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public struct ModelVersion : IEquatable<ModelVersion>, IComparable<ModelVersion>
    {
        private readonly ushort _major;
        private readonly ushort _minor;

        public ModelVersion(ushort major, ushort minor)
        {
            _major = major;
            _minor = minor;
        }

        public int Major
        {
            get { return _major; }
        }

        public int Minor
        {
            get { return _minor; }
        }

        private ulong ToInteger()
        {
            return ((ulong)_major << 16) | _minor;
        }

        public int CompareTo(ModelVersion other)
        {
            var left = ToInteger();
            var right = other.ToInteger();
            return (left == right) ? 0 : (left < right) ? -1 : +1;
        }

        public bool Equals(ModelVersion other)
        {
            return ToInteger() == other.ToInteger();
        }

        public override bool Equals(object obj)
        {
            return obj is ModelVersion && Equals((ModelVersion)obj);
        }

        public override int GetHashCode()
        {
            return ((_major & 0x00ff) << 12) | (_minor & 0x0fff);
        }

        public static bool operator ==(ModelVersion left, ModelVersion right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ModelVersion left, ModelVersion right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(ModelVersion left, ModelVersion right)
        {
            return left.ToInteger() < right.ToInteger();
        }

        public static bool operator <=(ModelVersion left, ModelVersion right)
        {
            return left.ToInteger() <= right.ToInteger();
        }

        public static bool operator >(ModelVersion left, ModelVersion right)
        {
            return left.ToInteger() > right.ToInteger();
        }

        public static bool operator >=(ModelVersion left, ModelVersion right)
        {
            return left.ToInteger() >= right.ToInteger();
        }

        /// <summary>
        /// Converts <see cref="Version"/> to <see cref="ModelVersion"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Major, minor, build or revision number are less than 0 or greater than 0xFFFF.</exception>
        public static explicit operator ModelVersion(Version version)
        {
            return new ModelVersion((ushort)version.Major, (ushort)version.Minor);
        }

        public static explicit operator Version(ModelVersion version)
        {
            return new Version(version.Major, version.Minor);
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", _major, _minor);
        }
    }

}
