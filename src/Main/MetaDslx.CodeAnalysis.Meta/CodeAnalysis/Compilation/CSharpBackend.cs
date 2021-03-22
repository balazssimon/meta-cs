using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public class CSharpBackend : CompilerBackend
    {
        private CSharpCompilation _csharpCompilation;

        protected CSharpBackend(LanguageCompilation compilation)
            : base(compilation)
        {
            _csharpCompilation = CSharpCompilation.Create(compilation.AssemblyName);
            // TODO:MetaDslx -> add generated files
        }

        internal static CSharpBackend CreateDummyBackend(LanguageCompilation compilation)
        {
            return new CSharpBackend(compilation);
        }

        public CSharpCompilation CSharpCompilation => _csharpCompilation;

        public override IAssemblySymbol AssemblySymbol => _csharpCompilation.Assembly;

        public override CommonReferenceManager GetBoundReferenceManager()
        {
            return _csharpCompilation.GetBoundReferenceManager();
        }

        protected override CompilerBackend Update(CommonReferenceManager referenceManager, bool reuseReferenceManager)
        {
            return Update(_csharpCompilation, referenceManager, reuseReferenceManager);
        }

        protected CSharpBackend Update(CSharpCompilation csharpCompilation, CommonReferenceManager referenceManager, bool reuseReferenceManager)
        {
            throw new NotImplementedException();
        }

        // TODO:MetaDslx -> Make sure that the ReferenceManager does not change! Or that the 
        // change is handled correctly.
        public override void Emit()
        {
            
        }
    }
}
