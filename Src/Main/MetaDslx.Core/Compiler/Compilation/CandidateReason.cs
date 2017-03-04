using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Indicates the reasons why a candidate (or set of candidate) symbols were not considered
    /// correct in SemanticInfo. Higher values take precedence over lower values, so if, for
    /// example, there a symbol with a given name that was inaccessible, and other with the wrong
    /// arity, only the inaccessible one would be reported in the SemanticInfo.
    /// </summary>
    public enum CandidateReason
    {
        /// <summary>
        /// No CandidateSymbols.
        /// </summary>
        None = 0,

        /// <summary>
        /// Only a type or namespace was valid in the given location, but the candidate symbols was
        /// of the wrong kind.
        /// </summary>
        Wrong = 1,

        /// <summary>
        /// Multiple ambiguous symbols were available with the same name. This can occur if "using"
        /// statements bring multiple namespaces into scope, and the same type is available in
        /// multiple. This can also occur if multiple properties of the same name are available in a
        /// multiple interface inheritance situation.
        /// </summary>
        Ambiguous = 2,
    }

}
