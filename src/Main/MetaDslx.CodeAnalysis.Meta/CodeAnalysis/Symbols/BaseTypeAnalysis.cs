// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal static class BaseTypeAnalysis
    {
        internal static bool TypeDependsOn(NamedTypeSymbol depends, NamedTypeSymbol on)
        {
            Debug.Assert((object)depends != null);
            Debug.Assert((object)on != null);
            Debug.Assert(on.IsDefinition);

            var hs = PooledHashSet<Symbol>.GetInstance();
            TypeDependsClosure(depends, hs);

            var result = hs.Contains(on);
            hs.Free();

            return result;
        }

        private static void TypeDependsClosure(NamedTypeSymbol type, HashSet<Symbol> partialClosure)
        {
            type = type.OriginalDefinition;
            if (partialClosure.Add(type))
            {
                foreach (var bt in type.GetDeclaredBaseTypes(null))
                {
                    TypeDependsClosure(bt, partialClosure);
                    // containment is not interesting for interfaces as they cannot nest in C#
                }
            }
        }
    }
}
