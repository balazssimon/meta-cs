// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp.Symbols
{
    internal sealed class ConstructedMethodSymbol : SubstitutedMethodSymbol
    {
        private readonly ImmutableArray<TypeWithAnnotations> _typeArgumentsWithAnnotations;

        internal ConstructedMethodSymbol(MethodSymbol constructedFrom, ImmutableArray<TypeWithAnnotations> typeArgumentsWithAnnotations)
            : base(containingSymbol: constructedFrom.ContainingType,
                   map: new TypeMap(constructedFrom.ContainingType, ((MethodSymbol)constructedFrom.OriginalDefinition).TypeParameters, typeArgumentsWithAnnotations),
                   originalDefinition: (MethodSymbol)constructedFrom.OriginalDefinition,
                   constructedFrom: constructedFrom)
        {
            _typeArgumentsWithAnnotations = typeArgumentsWithAnnotations;
        }

        public override ImmutableArray<TypeWithAnnotations> TypeArgumentsWithAnnotations
        {
            get
            {
                return _typeArgumentsWithAnnotations;
            }
        }

        public override bool IsTupleMethod
        {
            get
            {
                return ConstructedFrom.IsTupleMethod;
            }
        }

        public override MethodSymbol TupleUnderlyingMethod
        {
            get
            {
                return ConstructedFrom.TupleUnderlyingMethod?.Construct(_typeArgumentsWithAnnotations);
            }
        }
    }
}
