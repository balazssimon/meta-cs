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

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : ValueBinder
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

        public Symbol DefinedSymbol
        {
            get
            {
                if (_definedSymbol == null)
                {
                    var container = this.ContainingDeclaration as IModelSourceSymbol;
                    var symbol = container.GetChildSymbol(this.Syntax.GetReference());
                    Interlocked.CompareExchange(ref _definedSymbol, symbol, null);
                }
                return _definedSymbol;
            }
        }

        public override ImmutableArray<object> Values
        {
            get
            {
                if (DefinedSymbol != null) return ImmutableArray.Create<object>(DefinedSymbol);
                else return ImmutableArray<object>.Empty; 
            }

        }

        public override Symbol GetDefinedSymbol()
        {
            return this.DefinedSymbol;
        }

    }
}
