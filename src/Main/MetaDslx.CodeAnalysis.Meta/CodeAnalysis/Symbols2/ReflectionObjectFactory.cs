using MetaDslx.CodeAnalysis.Symbols.Metadata;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class ReflectionObjectFactory : ObjectFactory
    {
        public ReflectionObjectFactory(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        public override object CreateModel()
        {
            throw new NotImplementedException();
        }

        public override object CreateObject(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
