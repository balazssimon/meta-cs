using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MetaDslx.Languages.Soal
{
    public enum SoalFeature
    {
        None
    }
    public static partial class SoalFeatureExtensions
    {
        internal static string RequiredFeature(this SoalFeature feature)
        {
            switch (feature)
            {
                default:
                    return null;
            }
        }
        internal static LanguageVersion RequiredVersion(this SoalFeature feature)
        {
            switch (feature)
            {
                case SoalFeature.None:
                    return LanguageVersion.Soal1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(feature), "Unexpected value: "+feature);
            }
        }
    }
}

