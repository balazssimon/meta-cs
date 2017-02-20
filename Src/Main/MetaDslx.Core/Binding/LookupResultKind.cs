using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// Classifies the different ways in which a found symbol might be incorrect.
    /// Higher values are considered "better" than lower values. These values are used
    /// in a few different places:
    ///    1) Inside a LookupResult to indicate the quality of a symbol from lookup.
    ///    2) Inside a bound node (for example, BoundBadExpression), to indicate
    ///       the "binding quality" of the symbols referenced by that bound node.
    ///    3) Inside an error type symbol, to indicate the reason that the candidate symbols
    ///       in the error type symbols were not good.
    ///       
    /// While most of the values can occur in all places, some of the problems are not
    /// detected at lookup time (e.g., NotAVariable), so only occur in bound nodes.
    /// </summary>
    /// <remarks>
    /// This enumeration is parallel to and almost the same as the CandidateReason enumeration.
    /// Changes to one should usually result in changes to the other.
    /// 
    /// There are two enumerations because:
    ///   1) CandidateReason in language-independent, while this enum is language specific.
    ///   2) The name "CandidateReason" didn't make much sense in the way LookupResultKind is used internally.
    ///   3) Viable isn't used in CandidateReason, but we need it in LookupResultKind, and there isn't a 
    ///      a way to have internal enumeration values.
    /// </remarks>
    public enum LookupResultKind : byte
    {
        Empty,
        NonViable,
        Inaccessible,
        Viable,
    }
}
