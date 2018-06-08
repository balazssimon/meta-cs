using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class IdentifierBinder : SymbolBinder
    {
        public IdentifierBinder(Binder next) : base(next)
        {
        }

        public override bool GetQualifier(LookupResult<Qualifier> result)
        {
            string identifier = this.GetNodeIdentifier(this.RedNode);
            result.MergeEqual(LookupResult<Qualifier>.Good(new Qualifier(identifier)));
            return true;
        }

        public override bool GetIdentifier(LookupResult<string> result)
        {
            string identifier = this.GetNodeIdentifier(this.RedNode);
            result.MergeEqual(LookupResult<string>.Good(identifier));
            return true;
        }

        protected virtual string GetNodeIdentifier(RedNode node)
        {
            return this.Compilation.SymbolResolution.GetName(node);
        }
    }
}

//public override bool AddNameBinder(ArrayBuilder<ISymbolBinder> result)
//{
//    return true;
//}

//public override bool AddPropertyBinder(ArrayBuilder<ISymbolBinder> result)
//{
//    return true;
//}

//public override bool AddValueBinder(ArrayBuilder<ISymbolBinder> result)
//{
//    result.Add(this);
//    return true;
//}

//public override bool AddIdentifierBinder(ArrayBuilder<ISymbolBinder> result)
//{
//    result.Add(this);
//    return true;
//}
