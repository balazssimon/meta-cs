using MetaDslx.CodeAnalysis.Symbols;
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
                if (current is SymbolDefBinder symbolDefBinder)
                {
                    var result = symbolDefBinder.DefinedSymbol as NamespaceOrTypeSymbol;
                    if (result != null) return result;
                    else break;
                }
                current = current.Next;
            }
            return (NamespaceOrTypeSymbol)binder.Compilation.CreateErrorNamespaceSymbol(binder.Compilation.GlobalNamespace, string.Empty);
        }
    }
}
