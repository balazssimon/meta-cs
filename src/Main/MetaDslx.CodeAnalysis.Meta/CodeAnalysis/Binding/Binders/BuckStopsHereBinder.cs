﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    /// <summary>
    /// A binder that knows no symbols and will not delegate further.
    /// </summary>
    public class BuckStopsHereBinder : Binder
    {
        public BuckStopsHereBinder(LanguageCompilation compilation)
            : base(compilation)
        {
        }

        public override ImportChain ImportChain
        {
            get
            {
                return null;
            }
        }

        public override Imports GetImports(ConsList<TypeSymbol> basesBeingResolved)
        {
            return Imports.Empty;
        }

        public override bool IsAccessibleHelper(Symbol symbol, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol> basesBeingResolved)
        {
            failedThroughTypeCheck = false;
            return IsSymbolAccessibleConditional(symbol, Compilation.Assembly, ref useSiteDiagnostics);
        }

        public override NamespaceOrTypeSymbol ContainingSymbol => this.GetDeclarationSymbol() as NamespaceOrTypeSymbol;

        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        protected override bool InExecutableBinder => false;

        public override Binder GetBinder(SyntaxNode node)
        {
            return Compilation.GetBinder((LanguageSyntaxNode)node);
        }

        public override DeclaredSymbol GetDeclarationSymbol()
        {
            if (Compilation.IsSubmission)
            {
                return Compilation.ScriptClass;
            }
            else
            {
                return Compilation.GlobalNamespace;
            }
        }

        public override void InitializeQualifierSymbol(BoundQualifier qualifier)
        {
            
        }

    }
}
