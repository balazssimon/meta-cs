using MetaDslx.CodeAnalysis.Symbols.Source;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class SymbolVisitor<TResult>
    {
        public virtual TResult Visit(Symbol symbol)
        {
            return (object)symbol == null
                ? default(TResult)
                : symbol.Accept(this);
        }

        public virtual TResult DefaultVisit(Symbol symbol)
        {
            return default(TResult);
        }

        public virtual TResult VisitAlias(AliasSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitAssembly(AssemblySymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitDynamicType(DynamicTypeSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitDiscard(DiscardExpressionSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitMember(MemberSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitMethod(MethodSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitModule(ModuleSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitNamedType(NamedTypeSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitNamespace(NamespaceSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitLocal(LocalSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitStatement(StatementSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        public virtual TResult VisitExpression(ExpressionSymbol symbol)
        {
            return DefaultVisit(symbol);
        }
    }
}
