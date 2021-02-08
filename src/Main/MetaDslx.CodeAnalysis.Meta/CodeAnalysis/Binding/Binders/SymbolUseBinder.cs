using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolUseBinder : Binder
    {
        private readonly ImmutableArray<Type> _types;

        public SymbolUseBinder(SyntaxNodeOrToken syntax, Binder next, ImmutableArray<Type> types)
            : base(syntax, next)
        {
            _types = types;
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            LookupConstraints result = constraints;
            if (!_types.IsEmpty)
            {
                result = result.WithTypes(_types);
            }
            return result;
        }

        protected override LookupConstraints AdjustConstraintsFor(SyntaxNodeOrToken lookupSyntax, LookupConstraints constraints)
        {
            return this.AdjustConstraints(constraints);
        }
    }
}
