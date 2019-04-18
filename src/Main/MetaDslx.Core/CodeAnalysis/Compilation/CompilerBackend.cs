using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public abstract class CompilerBackend
    {
        private LanguageCompilation _compilation;

        protected CompilerBackend(LanguageCompilation compilation)
        {

        }

        public LanguageCompilation Compilation => _compilation;

        public abstract IAssemblySymbol AssemblySymbol { get; }

        public abstract CommonReferenceManager GetBoundReferenceManager();

        public abstract void Emit();
    }
}
