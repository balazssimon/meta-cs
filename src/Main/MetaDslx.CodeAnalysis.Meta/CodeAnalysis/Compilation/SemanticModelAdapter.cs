using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public abstract class SemanticModelAdapter : SemanticModel
    {
        public override string Language => LanguageCore.Name;

        protected abstract Language LanguageCore { get; }
    }
}
