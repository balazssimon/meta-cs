using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class MemberSymbol : Symbol, IMetaMemberSymbol
    {
        public virtual bool IsImplementableMember => !this.IsStatic;

        internal DiagnosticInfo CalculateUseSiteDiagnostic()
        {
            // TODO:MetaDslx
            return null;
        }

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitMember(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitMember(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitMember(this, argument);
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return default;
        }
    }
}
