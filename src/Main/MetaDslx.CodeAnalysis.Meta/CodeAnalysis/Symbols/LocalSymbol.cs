using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract partial class LocalSymbol : DeclaredSymbol
    {
        public override bool IsStatic => false;

        /// <summary>
        /// Gets the nearest enclosing member for this local symbol.
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
