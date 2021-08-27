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


        public virtual Binder CreateSymbolSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new SymbolSymbolBinder(parentBinder, syntax, forCompletion);
        }

        public virtual Binder CreateExpressionSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new ExpressionSymbolBinder(parentBinder, syntax, forCompletion);
        }

        public virtual Binder CreateStatementSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new StatementSymbolBinder(parentBinder, syntax, forCompletion);
        }

        public virtual Binder CreateTypeSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new TypeSymbolBinder(parentBinder, syntax, forCompletion);
        }

        public virtual Binder CreateSymbolPropertyBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new SymbolPropertyBinder(parentBinder, syntax, forCompletion);
        }
    }
}

