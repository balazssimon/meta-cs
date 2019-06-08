using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolUseBinder : Binder
    {
        private readonly ImmutableArray<Type> _symbolTypes;
        private readonly ImmutableArray<Type> _nestingSymbolTypes;

        public SymbolUseBinder(Binder next, SyntaxNodeOrToken syntax, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes)
            : base(next, syntax)
        {
            _symbolTypes = symbolTypes;
            _nestingSymbolTypes = nestingSymbolTypes;
        }

    }
}
