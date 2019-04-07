// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Allows asking semantic questions about a tree of syntax nodes in a Compilation. Typically,
    /// an instance is obtained by a call to GetBinding on a Compilation or Compilation.
    /// </summary>
    /// <remarks>
    /// <para>An instance of SemanticModel caches local symbols and semantic information. Thus, it
    /// is much more efficient to use a single instance of SemanticModel when asking multiple
    /// questions about a syntax tree, because information from the first question may be reused.
    /// This also means that holding onto an instance of SemanticModel for a long time may keep a
    /// significant amount of memory from being garbage collected.
    /// </para>
    /// <para>
    /// When an answer is a named symbol that is reachable by traversing from the root of the symbol
    /// table, (that is, from an AssemblySymbol of the Compilation), that symbol will be returned
    /// (i.e. the returned value will be reference-equal to one reachable from the root of the
    /// symbol table). Symbols representing entities without names (e.g. array-of-int) may or may
    /// not exhibit reference equality. However, some named symbols (such as local variables) are
    /// not reachable from the root. These symbols are visible as answers to semantic questions.
    /// When the same SemanticModel object is used, the answers exhibit reference-equality.
    /// </para>
    /// </remarks>
    public abstract class SemanticModel
    {
        public Compilation Compilation { get; private set; }
        public SyntaxTree SyntaxTree { get; private set; }
    }
}
