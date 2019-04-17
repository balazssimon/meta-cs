// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaModel.Syntax
{
    /// <summary>
    /// This class contains a variety of helper methods for determining whether a
    /// position is within the scope (and not just the span) of a node.  In general,
    /// general, the scope extends from the first token up to, but not including,
    /// the last token. For example, the open brace of a block is within the scope
    /// of the block, but the close brace is not.
    /// </summary>
    public class MetaModelLookupPosition : LookupPosition
    {
        /// <summary>
        /// A position is considered to be inside a block if it is on or after
        /// the open brace and strictly before the close brace.
        /// </summary>
        public bool IsInBlock(int position, MetaModelSyntaxNode blockOpt)
        {
            return blockOpt != null && IsBeforeToken(position, blockOpt, blockOpt.GetLastToken());
        }
    }
}
