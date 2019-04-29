using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public class LanguageVersion
    {
        public static readonly LanguageVersion Default = new LanguageVersion();

        public virtual LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            return this;
        }
    }
}
