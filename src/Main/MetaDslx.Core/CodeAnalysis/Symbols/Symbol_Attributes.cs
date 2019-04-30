// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public partial class Symbol
    {
        /// <summary>
        /// Gets the attributes for this symbol. Returns an empty <see cref="ImmutableArray&lt;AttributeData&gt;"/> if
        /// there are no attributes.
        /// </summary>
        public virtual ImmutableArray<AttributeData> GetAttributes()
        {
            // TODO:MetaDslx
            // Debug.Assert(!(this is IAttributeTargetSymbol)); //such types must override

            // Return an empty array by default.
            // Sub-classes that can have custom attributes must
            // override this method
            return ImmutableArray<AttributeData>.Empty;
        }

        /// <summary>
        /// Gets the attribute target kind corresponding to the symbol kind
        /// If attributes cannot be applied to this symbol kind, returns
        /// an invalid AttributeTargets value of 0
        /// </summary>
        /// <returns>AttributeTargets or 0</returns>
        internal virtual AttributeTargets GetAttributeTarget()
        {
            switch (this.Kind)
            {
                case SymbolKind.Assembly:
                    return AttributeTargets.Assembly;

                case SymbolKind.Field:
                    return AttributeTargets.Field;

                case SymbolKind.Method: // TODO:MetaDslx
                    /*var method = (MethodSymbol)this;
                    switch (method.MethodKind)
                    {
                        case MethodKind.Constructor:
                        case MethodKind.StaticConstructor:
                            return AttributeTargets.Constructor;

                        default:
                            return AttributeTargets.Method;
                    }*/
                    return AttributeTargets.Method;

                case SymbolKind.NamedType:
                    var namedType = (NamedTypeSymbol)this;
                    switch (namedType.TypeKind)
                    {
                        case TypeKind.Class:
                            return AttributeTargets.Class;

                        case TypeKind.Delegate:
                            return AttributeTargets.Delegate;

                        case TypeKind.Enum:
                            return AttributeTargets.Enum;

                        case TypeKind.Interface:
                            return AttributeTargets.Interface;

                        case TypeKind.Struct:
                            return AttributeTargets.Struct;

                        case TypeKind.TypeParameter:
                            return AttributeTargets.GenericParameter;

                        case TypeKind.Submission:
                            // attributes can't be applied on a submission type:
                            throw ExceptionUtilities.UnexpectedValue(namedType.TypeKind);
                    }
                    break;

                case SymbolKind.NetModule:
                    return AttributeTargets.Module;

                case SymbolKind.Parameter:
                    return AttributeTargets.Parameter;

                case SymbolKind.Property:
                    return AttributeTargets.Property;

                case SymbolKind.Event:
                    return AttributeTargets.Event;

                case SymbolKind.TypeParameter:
                    return AttributeTargets.GenericParameter;
            }

            return 0;
        }

    }
}
