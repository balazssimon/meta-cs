// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaBinderFactory : BinderFactory
    {
        public MetaBinderFactory(BinderCache cache) 
            : base(cache)
        {
        }


        public virtual Binder CreateSymbolSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new SymbolSymbolBinder(parentBinder, syntax);
        }

        public virtual Binder CreateExpressionSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new ExpressionSymbolBinder(parentBinder, syntax);
        }

        public virtual Binder CreateStatementSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new StatementSymbolBinder(parentBinder, syntax);
        }

        public virtual Binder CreateTypeSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new TypeSymbolBinder(parentBinder, syntax);
        }

        public virtual Binder CreateSymbolPropertyBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new SymbolPropertyBinder(parentBinder, syntax);
        }
    }
}

