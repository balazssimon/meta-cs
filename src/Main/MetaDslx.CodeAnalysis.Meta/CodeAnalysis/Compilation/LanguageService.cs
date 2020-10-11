using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public abstract class LanguageService
    {
        public Language Language => this.LanguageCore;
        protected abstract Language LanguageCore { get; }
    }
}
