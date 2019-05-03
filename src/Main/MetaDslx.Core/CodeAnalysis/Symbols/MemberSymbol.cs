using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class MemberSymbol : Symbol, IMetaMemberSymbol
    {
        public virtual bool IsImplementableMember => !this.IsStatic;
    }
}
