using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal class TypeMap
    {
        private readonly SmallDictionary<TypeParameterSymbol, TypeWithAnnotations> Mapping;

        internal TypeMap(NamedTypeSymbol containingType, ImmutableArray<TypeParameterSymbol> typeParameters, ImmutableArray<TypeWithAnnotations> typeArguments)
        {
            for (int i = 0; i < typeParameters.Length; i++)
            {
                TypeParameterSymbol tp = typeParameters[i];
                TypeWithAnnotations ta = typeArguments[i];
                if (!ta.Is(tp))
                {
                    Mapping.Add(tp, ta);
                }
            }
        }

        // Only when the caller passes allowAlpha=true do we tolerate substituted (alpha-renamed) type parameters as keys
        internal TypeMap(ImmutableArray<TypeParameterSymbol> from, ImmutableArray<TypeWithAnnotations> to, bool allowAlpha = false)
        {
            // mapping contents are read-only hereafter
        }

        // Only when the caller passes allowAlpha=true do we tolerate substituted (alpha-renamed) type parameters as keys
        internal TypeMap(ImmutableArray<TypeParameterSymbol> from, ImmutableArray<TypeParameterSymbol> to, bool allowAlpha = false)
        {
            // mapping contents are read-only hereafter
        }

        internal ImmutableArray<TypeWithAnnotations> SubstituteTypes(ImmutableArray<TypeWithAnnotations> parameterTypes)
        {
            throw new NotImplementedException();
        }

        internal static ImmutableArray<TypeWithAnnotations> TypeParametersAsTypeSymbolsWithAnnotations(ImmutableArray<TypeParameterSymbol> typeParameters)
        {
            throw new NotImplementedException();
        }
    }
}
