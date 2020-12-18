using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IPartialMemberSymbol
    {
        /// <summary>
        /// If this is a partial implementation part returns the definition part and vice versa.
        /// </summary>
        IPartialMemberSymbol OtherPartOfPartial { get; }

        /// <summary>
        /// Returns true if this symbol represents a partial method definition (the part that specifies a signature but no body).
        /// </summary>
        bool IsPartialDefinition { get; }

        /// <summary>
        /// Returns true if this symbol represents a partial method implementation (the part that specifies both signature and body).
        /// </summary>
        bool IsPartialImplementation { get; }
    }
}
