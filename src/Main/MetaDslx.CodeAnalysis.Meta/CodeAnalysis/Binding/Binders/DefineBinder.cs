using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class DefineBinder : SymbolBinder
    {
        public DefineBinder(Binder next, SyntaxNodeOrToken syntax, Type modelObjectType, bool forCompletion) 
            : base(next, syntax, null, modelObjectType, forCompletion)
        {
        }

        public override string ToString()
        {
            return $"Define: {ModelObjectType.Name}";
        }

    }
}
