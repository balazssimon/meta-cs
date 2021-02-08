using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class AttributeBinder : SymbolUseBinder
    {
        public AttributeBinder(SyntaxNodeOrToken syntax, Binder next, ImmutableArray<Type> types) 
            : base(syntax, next, types)
        {
            
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            LookupConstraints result = base.AdjustConstraints(constraints);
            if (!result.IsMemberLookup)
            {
                result = result.WithOptions(result.Options | LookupOptions.AttributeTypeOnly);
            }
            return result;
        }
    }
}
