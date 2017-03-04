// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Meta
{
    public enum MetaFeature
    {
        None
    }

    public static partial class MetaFeatureExtensions
    {
        internal static string RequiredFeature(this MetaFeature feature)
        {
            switch (feature)
            {
                default:
                    return null;
            }
        }

        internal static LanguageVersion RequiredVersion(this MetaFeature feature)
        {
            switch (feature)
            {
                case MetaFeature.None:
                    return LanguageVersion.Meta1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(feature), "Unexpected value: "+feature);
            }
        }
    }

}

