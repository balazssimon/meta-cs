using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BinaryOperators
    {
        private readonly LanguageCompilation _compilation;

        public BinaryOperators(LanguageCompilation compilation)
        {
            _compilation = compilation;
        }

        public LanguageCompilation Compilation => _compilation;

        public abstract BinaryOperatorSignature ClassifyOperatorByType(BinaryOperatorKind kind, TypeSymbol left, TypeSymbol right);
    }
}
