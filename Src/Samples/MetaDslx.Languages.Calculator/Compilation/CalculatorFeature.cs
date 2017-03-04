// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Calculator
{
    public enum CalculatorFeature
    {
        None
    }

    public static partial class CalculatorFeatureExtensions
    {
        internal static string RequiredFeature(this CalculatorFeature feature)
        {
            switch (feature)
            {
                default:
                    return null;
            }
        }

        internal static LanguageVersion RequiredVersion(this CalculatorFeature feature)
        {
            switch (feature)
            {
                case CalculatorFeature.None:
                    return LanguageVersion.Calculator1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(feature), "Unexpected value: "+feature);
            }
        }
    }

}

