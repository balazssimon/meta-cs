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
    public enum MetaModelFeature
    {
        None
    }

    public static partial class MetaModelFeatureExtensions
    {
        internal static string RequiredFeature(this MetaModelFeature feature)
        {
            switch (feature)
            {
                default:
                    return null;
            }
        }

        internal static LanguageVersion RequiredVersion(this MetaModelFeature feature)
        {
            switch (feature)
            {
                case MetaModelFeature.None:
                    return LanguageVersion.MetaModel1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(feature), "Unexpected value: "+feature);
            }
        }
    }

}

