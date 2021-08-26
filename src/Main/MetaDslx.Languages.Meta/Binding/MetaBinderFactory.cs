using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

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
            return this.CreateSymbolSymbolBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateSymbolSymbolBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new SymbolSymbolBinder(parentBinder, syntax);
        }

        public virtual Binder CreateExpressionSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateExpressionSymbolBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateExpressionSymbolBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new ExpressionSymbolBinder(parentBinder, syntax);
        }

        public virtual Binder CreateStatementSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateStatementSymbolBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateStatementSymbolBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new StatementSymbolBinder(parentBinder, syntax);
        }

        public virtual Binder CreateTypeSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateTypeSymbolBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateTypeSymbolBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new TypeSymbolBinder(parentBinder, syntax);
        }

        public virtual Binder CreateSymbolPropertyBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateSymbolPropertyBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateSymbolPropertyBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new SymbolPropertyBinder(parentBinder, syntax);
        }

    }
}
