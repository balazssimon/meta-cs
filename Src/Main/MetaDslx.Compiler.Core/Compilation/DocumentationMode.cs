using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Specifies the different documentation comment processing modes.
    /// </summary>
    /// <remarks>
    /// Order matters: least processing to most processing.
    /// </remarks>
    public enum DocumentationMode : byte
    {
        /// <summary>
        /// Treats documentation comments as regular comments.
        /// </summary>
        None = 0,

        /// <summary>
        /// Parses documentation comments as structured trivia, but do not report any diagnostics.
        /// </summary>
        Parse = 1,

        /// <summary>
        /// Parses documentation comments as structured trivia and report diagnostics.
        /// </summary>
        Diagnose = 2,
    }

    public static partial class DocumentationModeEnumBounds
    {
        public static bool IsValid(this DocumentationMode value)
        {
            return value >= DocumentationMode.None && value <= DocumentationMode.Diagnose;
        }
    }
}
