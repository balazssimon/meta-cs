// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Declarations;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// The compilation object is an immutable representation of a single invocation of the
    /// compiler. Although immutable, a compilation is also on-demand, and will realize and cache
    /// data as necessary. A compilation can produce a new compilation from existing compilation
    /// with the application of small deltas. In many cases, it is more efficient than creating a
    /// new compilation from scratch, as the new compilation can reuse information from the old
    /// compilation.
    /// </summary>
    public abstract partial class Compilation
    {
        public string AssemblyName { get; private set; }
        public CompilationOptions Options { get; private set; }

        private readonly SyntaxAndDeclarationManager _syntaxAndDeclarations;

        internal DeclarationTable Declarations
        {
            get
            {
                return _syntaxAndDeclarations.GetLazyState().DeclarationTable;
            }
        }

        internal MergedDeclaration MergedRootDeclaration
        {
            get
            {
                return Declarations.GetMergedRoot(this);
            }
        }

        internal int GetSyntaxTreeOrdinal(SyntaxTree tree)
        {
            throw new NotImplementedException();
        }

        internal int CompareSourceLocations(SyntaxReference syntaxReference1, SyntaxReference syntaxReference2)
        {
            throw new NotImplementedException();
        }

        internal int CompareSourceLocations(Location location1, Location location2)
        {
            throw new NotImplementedException();
        }
    }
}
