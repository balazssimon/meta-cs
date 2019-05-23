using MetaDslx.CodeAnalysis.Symbols.Source;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class SymbolVisitor
    {
        public virtual void Visit(Symbol symbol)
        {
            if ((object)symbol != null)
            {
                symbol.Accept(this);
            }
        }

        public virtual void DefaultVisit(Symbol symbol)
        {
        }

        public virtual void VisitAlias(AliasSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        public virtual void VisitAssembly(AssemblySymbol symbol)
        {
            DefaultVisit(symbol);
        }

        public virtual void VisitDynamicType(DynamicTypeSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        public virtual void VisitDiscard(DiscardSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        public virtual void VisitMember(MemberSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        public virtual void VisitMethod(MethodSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        public virtual void VisitModule(ModuleSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        public virtual void VisitNamedType(NamedTypeSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        public virtual void VisitNamespace(NamespaceSymbol symbol)
        {
            DefaultVisit(symbol);
        }

    }
}
