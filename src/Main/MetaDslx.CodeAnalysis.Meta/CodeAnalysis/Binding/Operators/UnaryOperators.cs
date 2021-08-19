using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class UnaryOperators
    {
        private readonly LanguageCompilation _compilation;

        public UnaryOperators(LanguageCompilation compilation)
        {
            _compilation = compilation;
        }

        public LanguageCompilation Compilation => _compilation;

        public abstract UnaryOperatorSignature ClassifyOperatorByType(UnaryOperatorKind kind, TypeSymbol operand);
    }
}
