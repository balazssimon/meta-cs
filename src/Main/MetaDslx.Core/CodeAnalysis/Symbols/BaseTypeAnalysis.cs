// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal static class BaseTypeAnalysis
    {
        internal static bool ClassDependsOn(NamedTypeSymbol depends, NamedTypeSymbol on)
        {
            Debug.Assert((object)depends != null);
            Debug.Assert((object)on != null);
            Debug.Assert(on.IsDefinition);

            var hs = PooledHashSet<Symbol>.GetInstance();
            ClassDependsClosure(depends, depends.DeclaringCompilation, hs);

            var result = hs.Contains(on);
            hs.Free();

            return result;
        }

        private static void ClassDependsClosure(NamedTypeSymbol type, LanguageCompilation currentCompilation, HashSet<Symbol> partialClosure)
        {
            if ((object)type == null)
            {
                return;
            }

            type = type.OriginalDefinition;
            if (partialClosure.Add(type))
            {
                ClassDependsClosure(type.GetDeclaredBaseType(null), currentCompilation, partialClosure);

                // containment is interesting only for the current compilation
                if (currentCompilation != null && type.IsFromCompilation(currentCompilation))
                {
                    ClassDependsClosure(type.ContainingType, currentCompilation, partialClosure);
                }
            }
        }

        /// <summary>
        /// IsManagedType is simple for most named types:
        ///     enums are not managed;
        ///     non-enum, non-struct named types are managed;
        ///     type parameters are managed unless an 'unmanaged' constraint is present;
        ///     all special types have spec'd values (basically, (non-string) primitives) are not managed;
        /// 
        /// Only structs are complicated, because the definition is recursive.  A struct type is managed
        /// if one of its instance fields is managed.  Unfortunately, this can result in infinite recursion.
        /// If the closure is finite, and we don't find anything definitely managed, then we return true.
        /// If the closure is infinite, we disregard all but a representative of any expanding cycle.
        /// 
        /// Intuitively, this will only return true if there's a specific type we can point to that is would
        /// be managed even if it had no fields.  e.g. struct S { S s; } is not managed, but struct S { S s; object o; }
        /// is because we can point to object.
        /// </summary>
        internal static ManagedKind GetManagedKind(NamedTypeSymbol type)
        {
            return ManagedKind.Managed;
        }

        internal static bool InterfaceDependsOn(NamedTypeSymbol depends, NamedTypeSymbol on)
        {
            Debug.Assert((object)depends != null);
            Debug.Assert((object)on != null);
            Debug.Assert(on.IsDefinition);

            var hs = PooledHashSet<Symbol>.GetInstance();
            InterfaceDependsClosure(depends, hs);

            var result = hs.Contains(on);
            hs.Free();

            return result;
        }

        private static void InterfaceDependsClosure(NamedTypeSymbol type, HashSet<Symbol> partialClosure)
        {
            type = type.OriginalDefinition;
            if (partialClosure.Add(type))
            {
                foreach (var bt in type.GetDeclaredInterfaces(null))
                {
                    InterfaceDependsClosure(bt, partialClosure);
                    // containment is not interesting for interfaces as they cannot nest in C#
                }
            }
        }
    }
}
