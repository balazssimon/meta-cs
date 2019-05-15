using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public class LanguageVersion
    {
        /// <summary>
        /// The latest major supported version.
        /// </summary>
        public static readonly LanguageVersion LatestMajor = new LanguageVersion();

        /// <summary>
        /// Preview of the next language version.
        /// </summary>
        public static readonly LanguageVersion Preview = new LanguageVersion();

        /// <summary>
        /// The latest supported version of the language.
        /// </summary>
        public static readonly LanguageVersion Latest = new LanguageVersion();

        /// <summary>
        /// The default language version, which is the latest supported version.
        /// </summary>
        public static readonly LanguageVersion Default = new LanguageVersion();

        public virtual LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            // TODO:MetaDslx
            return this;
        }

        public virtual bool IsValid()
        {
            // TODO:MetaDslx
            return true;
        }
    }
}
