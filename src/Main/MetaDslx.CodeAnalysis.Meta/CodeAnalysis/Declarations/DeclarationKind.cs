using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public enum DeclarationKind : byte
    {
        None,
        Namespace,
        Type,
        Script,
        Submission,
        Implicit
    }
}
