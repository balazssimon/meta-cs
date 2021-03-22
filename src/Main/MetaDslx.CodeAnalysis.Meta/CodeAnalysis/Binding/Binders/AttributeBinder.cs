using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class AttributeBinder : SymbolUseBinder
    {
        public AttributeBinder(Binder next, SyntaxNodeOrToken syntax, ImmutableArray<Type> types) 
            : base(next, syntax, types)
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
