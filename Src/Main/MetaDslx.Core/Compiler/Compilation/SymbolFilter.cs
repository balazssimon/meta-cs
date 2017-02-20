using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Indicate what kinds of declaration symbols will be included
    /// </summary>
    [Flags]
    public enum SymbolFilter
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// include namespace symbols
        /// </summary>
        Namespace = 0x01,

        /// <summary>
        /// include type symbols
        /// </summary>
        Type = 0x02,

        /// <summary>
        /// include member symbols such as method, event, property, field
        /// </summary>
        Member = 0x04,

        /// <summary>
        /// include type and member
        /// </summary>
        TypeAndMember = Type | Member,

        /// <summary>
        /// include all namespace, type and member
        /// </summary>
        All = Namespace | Type | Member
    }
}
