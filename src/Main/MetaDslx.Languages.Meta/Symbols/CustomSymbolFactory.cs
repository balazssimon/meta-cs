using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Symbols
{
    public class CustomSymbolFactory : SymbolFactory
    {
        public CustomSymbolFactory(ModuleSymbol module)
            : base(module)
        {
        }

        protected override Symbol CreateSourceSymbol(Symbol container, Type symbolType, object modelObject, MergedDeclaration declaration)
        {
            if (symbolType == typeof(AssociationSymbol)) return new AssociationSymbol(container, declaration);
            return base.CreateSourceSymbol(container, symbolType, modelObject, declaration);
        }
    }
}
