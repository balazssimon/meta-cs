// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ReferenceDirective = MetaDslx.CodeAnalysis.Syntax.ReferenceDirective;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public partial class DeclarationTable
    {
        // The structure of the DeclarationTable provides us with a set of 'old' declarations that
        // stay relatively unchanged and a 'new' declaration that is repeatedly added and removed.
        // This mimics the expected usage pattern of a user repeatedly typing in a single file.
        // Because of this usage pattern, we can cache information about these 'old' declarations
        // and keep that around as long as they do not change.  For example, we keep a single 'merged
        // declaration' for all those root declarations as well as sets of interesting information
        // (like the type names in those decls). 
        private class Cache
        {
            // The merged root declaration for all the 'old' declarations.
            internal readonly Lazy<MergedDeclaration> MergedRoot;

            // All the simple type names for all the types in the 'old' declarations.
            internal readonly Lazy<ISet<string>> TypeNames;
            internal readonly Lazy<ISet<string>> NamespaceNames;
            internal readonly Lazy<ImmutableArray<Syntax.ReferenceDirective>> ReferenceDirectives;

            public Cache(DeclarationTable table)
            {
                this.MergedRoot = new Lazy<MergedDeclaration>(
                    () => MergedDeclaration.Create(table._allOlderRootDeclarations.InInsertionOrder.AsImmutable<SingleDeclaration>()));

                this.TypeNames = new Lazy<ISet<string>>(
                    () => GetTypeNames(this.MergedRoot.Value));

                this.NamespaceNames = new Lazy<ISet<string>>(
                    () => GetNamespaceNames(this.MergedRoot.Value));

                this.ReferenceDirectives = new Lazy<ImmutableArray<Syntax.ReferenceDirective>>(
                    () => MergedRoot.Value.Declarations.OfType<RootSingleDeclaration>().SelectMany(r => r.ReferenceDirectives).AsImmutable());
            }
        }
    }
}
