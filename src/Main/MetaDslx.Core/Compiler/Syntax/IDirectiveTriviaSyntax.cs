using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Syntax
{
    public interface IDirectiveTriviaSyntax
    {
        SyntaxToken EndOfDirectiveToken { get; }

        IList<IDirectiveTriviaSyntax> GetRelatedDirectives();
    }
}
