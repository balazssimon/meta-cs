// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Class to represent a synthesized attribute
    /// </summary>
    internal sealed class SynthesizedAttributeData : SourceAttributeData
    {
        internal SynthesizedAttributeData(MethodSymbol wellKnownMember, ImmutableArray<TypedConstant> arguments, ImmutableArray<KeyValuePair<String, TypedConstant>> namedArguments)
            : base(
            applicationNode: null,
            attributeClass: wellKnownMember.ContainingType,
            attributeConstructor: wellKnownMember,
            constructorArguments: arguments,
            constructorArgumentsSourceIndices: default(ImmutableArray<int>),
            namedArguments: namedArguments,
            hasErrors: false,
            isConditionallyOmitted: false)
        {
            Debug.Assert((object)wellKnownMember != null);
            Debug.Assert(!arguments.IsDefault);
            Debug.Assert(!namedArguments.IsDefault); // Frequently empty though.
        }
    }
}
