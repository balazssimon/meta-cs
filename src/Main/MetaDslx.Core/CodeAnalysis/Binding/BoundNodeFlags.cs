using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class BoundNodeFlags : FlagsObject
    {
        public const string None = nameof(None);

        protected BoundNodeFlags(string name) : base(name)
        {
        }

        protected BoundNodeFlags(FlagsObject flags) : base(flags)
        {
        }

        static BoundNodeFlags()
        {
            RegisterDefault<BoundNodeFlags>(None);
            FlagsObject.AutoInit<BoundNodeFlags>();
        }

        public static implicit operator BoundNodeFlags(string name)
        {
            return FromString<BoundNodeFlags>(name);
        }

        public static explicit operator BoundNodeFlags(int value)
        {
            return FromIntUnsafe<BoundNodeFlags>(value);
        }

        public static BoundNodeFlags operator &(BoundNodeFlags left, FlagsObject right)
        {
            return right?.IntersectWith(left) ?? GetDefault<BoundNodeFlags>();
        }

        public static BoundNodeFlags operator |(BoundNodeFlags left, FlagsObject right)
        {
            return right?.UnionWith(left) ?? left;
        }
    }
}
