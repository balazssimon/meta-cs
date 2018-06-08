using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class EnumValueBinder : SymbolBinder
    {
        private Type _enumType;

        public EnumValueBinder(Binder next, Type enumType) : base(next)
        {
            _enumType = enumType;
        }

        public override bool GetValue(LookupResult<object> result)
        {
            object value = this.GetNodeValue(this.RedNode);
            result.MergeEqual(LookupResult<object>.Good(value));
            return true;
        }

        protected virtual object GetNodeValue(RedNode node)
        {
            return this.Compilation.SymbolResolution.GetEnumLiteral(node, _enumType);
        }
    }
}
