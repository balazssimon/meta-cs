// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    /// <summary>
    /// A binder that knows no symbols and will not delegate further.
    /// </summary>
    public class BuckStopsHereBinder : Binder
    {

        public BuckStopsHereBinder(LanguageCompilation compilation)
            : base(compilation)
        {
        }



        public override ImportChain ImportChain
        {
            get
            {
                return null;
            }
        }

        public override Imports GetImports(LookupConstraints recursionConstraints = null)
        {
            return Imports.Empty;
        }

        public override Binder GetBinder(SyntaxNodeOrToken node)
        {
            return Compilation.GetBinder(node);
        }

        public virtual Symbol GetDefinedSymbol()
        {
            if (Compilation.IsSubmission)
            {
                return Compilation.ScriptClass;
            }
            else
            {
                return Compilation.GlobalNamespace;
            }
        }


    }
}
