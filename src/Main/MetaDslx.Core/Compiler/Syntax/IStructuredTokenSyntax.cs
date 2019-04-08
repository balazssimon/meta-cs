using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Syntax
{
    /// <summary>
    /// Represents the root node of a structured token tree. 
    /// From this root node you can traverse back up to the containing
    /// token in the outer tree that contains it.
    /// </summary>
    public interface IStructuredTokenSyntax
    {
        /// <summary>
        /// Returns the parent token syntax for this structured token syntax.
        /// </summary>
        /// <returns>The parent token syntax for this structured token syntax.</returns>
        SyntaxToken ParentToken { get; }
    }
}
