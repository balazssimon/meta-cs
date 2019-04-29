// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    // This is a type symbol associated with a type definition in source code.
    // That is, for a generic type C<T> this is the instance type C<T>.  
    public class SourceNamedTypeSymbol : SourceMemberContainerTypeSymbol
    {
        public SourceNamedTypeSymbol(NamespaceOrTypeSymbol containingSymbol, MergedDeclaration declaration, DiagnosticBag diagnostics)
            : base(containingSymbol, declaration, diagnostics)
        {

        }

        public override TypeKind TypeKind => TypeKind.Unknown;

        public override NamedTypeSymbol BaseTypeNoUseSiteDiagnostics => null;

        protected override void CheckBase(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException();
        }

        protected override void CheckInterfaces(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException();
        }

        internal override AttributeUsageInfo GetAttributeUsageInfo()
        {
            throw new System.NotImplementedException();
        }

        internal override NamedTypeSymbol GetDeclaredBaseType(ConsList<TypeSymbol> basesBeingResolved)
        {
            throw new System.NotImplementedException();
        }

        internal override ImmutableArray<NamedTypeSymbol> GetDeclaredInterfaces(ConsList<TypeSymbol> basesBeingResolved)
        {
            throw new System.NotImplementedException();
        }

        internal override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new System.NotImplementedException();
        }

        internal override ImmutableArray<NamedTypeSymbol> InterfacesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
