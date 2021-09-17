using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class NameBinder : Binder, IValueBoundary
    {
        public NameBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion) 
            : base(next, syntax, forCompletion)
        {
        }

        public override bool IsValidCompletionBinder
        {
            get
            {
                var binder = this.Next;
                while (binder != null)
                {
                    if ((binder is ISymbolBoundary) && binder.IsCompletionBinder) return false;
                    binder = binder.Next;
                }
                return true;
            }
        }

    }
}
