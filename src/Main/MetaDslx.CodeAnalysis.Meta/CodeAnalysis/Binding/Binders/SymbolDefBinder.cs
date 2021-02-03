using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : Binder
    {
        private readonly Type _type;
        private readonly Type _nestingType;
        private ImmutableArray<DeclaredSymbol> _declaredSymbols;
        private readonly LanguageSyntaxNode _syntax;

        public SymbolDefBinder(Binder next, LanguageSyntaxNode syntax, Type type, Type nestingType) 
            : base(next)
        {
            _type = type;
            _nestingType = nestingType;
            _syntax = syntax;
            _declaredSymbols = default;
        }

        public override DeclaredSymbol GetDeclarationSymbol()
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }
    }
}
