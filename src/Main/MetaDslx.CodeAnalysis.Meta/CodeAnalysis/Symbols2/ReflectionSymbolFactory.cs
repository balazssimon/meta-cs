using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    // TODO
    public class ReflectionSymbolFactory : SymbolFactory
    {
        public ReflectionSymbolFactory(ObjectFactory objectFactory) 
            : base(objectFactory)
        {
        }

        public override LanguageSymbolKind GetSymbolKind(Type modelObjectType)
        {
            throw new NotImplementedException();
        }

        public override string GetSymbolProperty(Type modelObjectType, object property)
        {
            throw new NotImplementedException();
        }
    }
}
