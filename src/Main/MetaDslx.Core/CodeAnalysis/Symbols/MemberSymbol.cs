using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class MemberSymbol : Symbol
    {
        /// <summary>
        /// Returns data decoded from Obsolete attribute or null if there is no Obsolete attribute.
        /// This property returns ObsoleteAttributeData.Uninitialized if attribute arguments haven't been decoded yet.
        /// </summary>
        public override ObsoleteAttributeData ObsoleteAttributeData
        {
            get { return null; }
        }

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.DefaultVisit(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.DefaultVisit(this);
        }
    }
}
