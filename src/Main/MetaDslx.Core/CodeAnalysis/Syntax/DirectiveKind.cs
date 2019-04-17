using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public enum DirectiveKind : ushort
    {
        None = 0,
        Custom,
        If,
        Elif,
        Else,
        EndIf,
        Region,
        EndRegion,
        Define,
        Undef,
        Error,
        Warning,
        Line,
        PragmaWarning,
        PragmaChecksum,
        Reference,
        Bad,
        Using,
        ExternAlias,
        Shebang,
        Load,
        Nullable
    }
}
