// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.SymbolDisplay;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp
{
    public partial class SymbolDisplayVisitor : AbstractSymbolDisplayVisitor
    {
        private readonly bool _escapeKeywordIdentifiers;
        private IDictionary<INamespaceOrTypeSymbol, IAliasSymbol> _lazyAliasMap;

        public SymbolDisplayVisitor(
            ArrayBuilder<SymbolDisplayPart> builder,
            SymbolDisplayFormat format,
            SemanticModel semanticModelOpt,
            int positionOpt)
            : base(builder, format, true, semanticModelOpt, positionOpt)
        {
            _escapeKeywordIdentifiers = format.MiscellaneousOptions.IncludesOption(SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers);
        }

        private SymbolDisplayVisitor(
            ArrayBuilder<SymbolDisplayPart> builder,
            SymbolDisplayFormat format,
            SemanticModel semanticModelOpt,
            int positionOpt,
            bool escapeKeywordIdentifiers,
            IDictionary<INamespaceOrTypeSymbol, IAliasSymbol> aliasMap,
            bool isFirstSymbolVisited,
            bool inNamespaceOrType = false)
            : base(builder, format, isFirstSymbolVisited, semanticModelOpt, positionOpt, inNamespaceOrType)
        {
            _escapeKeywordIdentifiers = escapeKeywordIdentifiers;
            _lazyAliasMap = aliasMap;
        }

        public Language Language { get; }

        protected override AbstractSymbolDisplayVisitor MakeNotFirstVisitor(bool inNamespaceOrType = false)
        {
            return new SymbolDisplayVisitor(
                this.builder,
                this.format,
                this.semanticModelOpt,
                this.positionOpt,
                _escapeKeywordIdentifiers,
                _lazyAliasMap,
                isFirstSymbolVisited: false,
                inNamespaceOrType: inNamespaceOrType);
        }

        internal SymbolDisplayPart CreatePart(SymbolDisplayPartKind kind, ISymbol symbol, string text)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
            /*
            text = (text == null) ? "?" :
                   (_escapeKeywordIdentifiers && IsEscapable(kind)) ? EscapeIdentifier(((Symbol)symbol).Language, text) : text;
                   
            return new SymbolDisplayPart(kind, symbol, text);*/
        }

        protected virtual bool IsEscapable(SymbolDisplayPartKind kind)
        {
            return true;
        }

        protected virtual string EscapeIdentifier(Language language, string identifier)
        {
            var kind = language.SyntaxFacts.GetKeywordKind(identifier);
            return kind == Syntax.SyntaxKind.None
                ? identifier
                : $"@{identifier}";
        }

    }
}
