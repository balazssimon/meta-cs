using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract partial class NonDeclaredSymbol : Symbol
    {

        /// <summary>
        /// Gets the nearest enclosing behavioral member for this non-declared symbol.
        /// </summary>
        public virtual MethodLikeSymbol? ContainingMember
        {
            get
            {
                Symbol container = this.ContainingSymbol;
                while (container is not null)
                {
                    if (container is MethodLikeSymbol result)
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
