// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace MetaDslx.CodeAnalysis.Declarations
{
    internal sealed partial class SyntaxAndDeclarationManager : CommonSyntaxAndDeclarationManager
    {
        internal sealed class State
        {
            internal readonly ImmutableArray<LanguageSyntaxTree> SyntaxTrees; // In ordinal order.
            internal readonly ImmutableDictionary<LanguageSyntaxTree, int> OrdinalMap; // Inverse of syntaxTrees array (i.e. maps tree to index)
            internal readonly ImmutableDictionary<LanguageSyntaxTree, ImmutableArray<DeclarationLoadDirective>> LoadDirectiveMap;
            internal readonly ImmutableDictionary<string, LanguageSyntaxTree> LoadedSyntaxTreeMap;
            internal readonly ImmutableDictionary<LanguageSyntaxTree, Lazy<RootSingleDeclaration>> RootNamespaces;
            internal readonly DeclarationTable DeclarationTable;

            internal State(
                ImmutableArray<LanguageSyntaxTree> syntaxTrees,
                ImmutableDictionary<LanguageSyntaxTree, int> syntaxTreeOrdinalMap,
                ImmutableDictionary<LanguageSyntaxTree, ImmutableArray<DeclarationLoadDirective>> loadDirectiveMap,
                ImmutableDictionary<string, LanguageSyntaxTree> loadedSyntaxTreeMap,
                ImmutableDictionary<LanguageSyntaxTree, Lazy<RootSingleDeclaration>> rootNamespaces,
                DeclarationTable declarationTable)
            {
                Debug.Assert(syntaxTrees.All(tree => syntaxTrees[syntaxTreeOrdinalMap[tree]] == tree));
                Debug.Assert(syntaxTrees.SetEquals(rootNamespaces.Keys.AsImmutable(), EqualityComparer<LanguageSyntaxTree>.Default));

                this.SyntaxTrees = syntaxTrees;
                this.OrdinalMap = syntaxTreeOrdinalMap;
                this.LoadDirectiveMap = loadDirectiveMap;
                this.LoadedSyntaxTreeMap = loadedSyntaxTreeMap;
                this.RootNamespaces = rootNamespaces;
                this.DeclarationTable = declarationTable;
            }
        }
    }
}
