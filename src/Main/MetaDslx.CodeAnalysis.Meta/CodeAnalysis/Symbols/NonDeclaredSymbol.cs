using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class NonDeclaredSymbol : Symbol
    {

        /// <summary>
        /// Gets the nearest enclosing behavioral member for this non-declared symbol.
        /// </summary>
        public virtual BehavioralMemberSymbol? ContainingMember
        {
            get
            {
                Symbol container = this.ContainingSymbol;
                while (container is not null)
                {
                    if (container is BehavioralMemberSymbol result)
                    {
                        return result;
                    }
                    container = container.ContainingSymbol;
                }
                return null;
            }
        }
    }
}
