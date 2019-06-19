﻿using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class ScopeBinder : InContainerBinder
    {
        public ScopeBinder(Binder next, LanguageSyntaxNode syntax)
            : base(GetContainerSymbol(next), next, syntax, false)
        {
        }

        private static NamespaceOrTypeSymbol GetContainerSymbol(Binder binder)
        {
            var current = binder;
            while (current != null)
            {
                if (binder is SymbolDefBinder symbolDefBinder)
                {
                    var definedSymbols = symbolDefBinder.DefinedSymbols;
                    if (definedSymbols.Length == 1)
                    {
                        return definedSymbols[0] as NamespaceOrTypeSymbol;
                    }
                    else
                    {
                        return null;
                    }
                }
                current = current.Next;
            }
            return null;
        }
    }
}
