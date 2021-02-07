﻿using MetaDslx.CodeAnalysis.Symbols;
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
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : ValueBinder, IPropertyBoundary

    {
        private readonly Type _type;
        private Symbol _definedSymbol;

        public SymbolDefBinder(SyntaxNodeOrToken syntax, Binder next, Type type) 
            : base(syntax, next)
        {
            _type = type;
            _definedSymbol = null;
        }

        public Type ModelObjectType => _type;

        protected override BoundNode CreateBoundNode()
        {
            var symbol = SourceSymbol.GetInnermostNestedDeclaredSymbol(this.Syntax, this.ContainingDeclaration);
            return new BoundSymbol(this.Syntax, this.ContainingBoundNode, ImmutableArray.Create<Symbol>(symbol), CandidateReason.None);
        }

        public ImmutableArray<Symbol> DefinedSymbols => ((BoundSymbol)this.BoundNode).Symbols;

        public Symbol DefinedSymbol => DefinedSymbols.FirstOrDefault();

        public override ImmutableArray<object> Values => DefinedSymbols.Cast<Symbol, object>();

        public override Symbol GetDefinedSymbol()
        {
            return this.DefinedSymbol;
        }

    }
}
