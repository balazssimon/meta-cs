// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp.Emit
{
    /// <summary>
    /// Represents a reference to a generic type instantiation that is not nested.
    /// e.g. MyNamespace.A{int}
    /// </summary>
    internal sealed class GenericNamespaceTypeInstanceReference : GenericTypeInstanceReference
    {
        public GenericNamespaceTypeInstanceReference(NamedTypeSymbol underlyingNamedType)
            : base(underlyingNamedType)
        {
        }

        public override MetaDslx.Cci.IGenericTypeInstanceReference AsGenericTypeInstanceReference
        {
            get { return this; }
        }

        public override MetaDslx.Cci.INamespaceTypeReference AsNamespaceTypeReference
        {
            get { return null; }
        }

        public override MetaDslx.Cci.INestedTypeReference AsNestedTypeReference
        {
            get { return null; }
        }

        public override MetaDslx.Cci.ISpecializedNestedTypeReference AsSpecializedNestedTypeReference
        {
            get { return null; }
        }
    }
}
