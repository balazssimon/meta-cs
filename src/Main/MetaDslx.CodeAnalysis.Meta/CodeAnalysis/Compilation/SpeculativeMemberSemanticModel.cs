// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using Roslyn.Utilities;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Binding;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Allows asking semantic questions about a TypeSyntax (or its descendants) within a member, that did not appear in the original source code.
    /// Typically, an instance is obtained by a call to SemanticModel.TryGetSpeculativeSemanticModel. 
    /// </summary>
    internal sealed class SpeculativeMemberSemanticModel : MemberSemanticModel
    {
        /// <summary>
        /// Creates a speculative SemanticModel for a TypeSyntax node at a position within an existing MemberSemanticModel.
        /// </summary>
        public SpeculativeMemberSemanticModel(SyntaxTreeSemanticModel parentSemanticModel, Symbol owner, LanguageSyntaxNode root, Binder rootBinder, int position)
            : base(root, owner, rootBinder, containingSemanticModelOpt: null, parentSemanticModelOpt: parentSemanticModel, speculatedPosition: position)
        {
        }

    }
}
