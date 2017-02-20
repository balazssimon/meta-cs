using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Specifies the source code kind.
    /// </summary>
    public enum SourceCodeKind
    {
        /// <summary>
        /// No scripting. Used for source file parsing.
        /// </summary>
        Regular = 0,

        /// <summary>
        /// Allows top-level statements, declarations, and optional trailing expression. 
        /// Used for parsing scripts and interactive submissions.
        /// </summary>
        Script = 1
    }

    public static partial class SourceCodeKindExtensions
    {
        public static bool IsValid(this SourceCodeKind value)
        {
            return value >= SourceCodeKind.Regular && value <= SourceCodeKind.Script;
        }
    }
}
