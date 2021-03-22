using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis;
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

        public override void RemoveObject(object modelObject)
        {
            throw new NotImplementedException();
        }
    }
}
