// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.Cci;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.CSharp.Binding;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{

    internal sealed class SynthesizedEmbeddedNullableAttributeSymbol : SynthesizedEmbeddedAttributeSymbolBase
    {
        private readonly ImmutableArray<FieldSymbol> _fields;

        private readonly ImmutableArray<MethodSymbol> _constructors;

        private readonly TypeSymbol _byteTypeSymbol;

        private const string NullableFlagsFieldName = "NullableFlags";

        public SynthesizedEmbeddedNullableAttributeSymbol(
          CSharpCompilation compilation,
          DiagnosticBag diagnostics)
            : base(AttributeDescription.NullableAttribute, compilation, diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override IEnumerable<FieldSymbol> GetFieldsToEmit() => _fields;

        public override ImmutableArray<MethodSymbol> Constructors => _constructors;

        private void GenerateByteArrayConstructorBody(SyntheticBoundNodeFactory factory, ArrayBuilder<BoundStatement> statements, ImmutableArray<ParameterSymbol> parameters)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void GenerateSingleByteConstructorBody(SyntheticBoundNodeFactory factory, ArrayBuilder<BoundStatement> statements, ImmutableArray<ParameterSymbol> parameters)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private sealed class SynthesizedEmbeddedAttributeConstructorWithBodySymbol : SynthesizedInstanceConstructor
        {
            private readonly ImmutableArray<ParameterSymbol> _parameters;

            private readonly Action<SyntheticBoundNodeFactory, ArrayBuilder<BoundStatement>, ImmutableArray<ParameterSymbol>> _getConstructorBody;

            internal SynthesizedEmbeddedAttributeConstructorWithBodySymbol(
                NamedTypeSymbol containingType,
                Func<MethodSymbol, ImmutableArray<ParameterSymbol>> getParameters,
                Action<SyntheticBoundNodeFactory, ArrayBuilder<BoundStatement>, ImmutableArray<ParameterSymbol>> getConstructorBody) :
                base(containingType)
            {
                _parameters = getParameters(this);
                _getConstructorBody = getConstructorBody;
            }

            public override ImmutableArray<ParameterSymbol> Parameters => _parameters;

            internal override void GenerateMethodBody(TypeCompilationState compilationState, DiagnosticBag diagnostics)
            {
                GenerateMethodBodyCore(compilationState, diagnostics);
            }

            protected override void GenerateMethodBodyStatements(SyntheticBoundNodeFactory factory, ArrayBuilder<BoundStatement> statements, DiagnosticBag diagnostics) => _getConstructorBody(factory, statements, _parameters);
        }


    }
}

