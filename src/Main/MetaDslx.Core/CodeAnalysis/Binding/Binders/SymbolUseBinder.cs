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

        public SymbolUseBinder(Binder next, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes)
            : base(next)
        {
            _symbolTypes = symbolTypes;
            _nestingSymbolTypes = nestingSymbolTypes;
        }

    }
}
