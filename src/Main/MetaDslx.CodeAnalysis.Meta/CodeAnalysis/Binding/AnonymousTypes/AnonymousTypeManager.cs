// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// Manages anonymous types created in owning compilation. All requests for 
    /// anonymous type symbols go via the instance of this class.
    /// </summary>
    internal sealed partial class AnonymousTypeManager : CommonAnonymousTypeManager
    {
        internal AnonymousTypeManager(LanguageCompilation compilation)
        {
            Debug.Assert(compilation != null);
            this.Compilation = compilation;
        }

        /// <summary> 
        /// Current compilation
        /// </summary>
        public LanguageCompilation Compilation { get; }

    }
}
