using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BinderFactoryVisitor
    {
        public abstract Binder Visit(SyntaxNode node);
        internal protected abstract void Initialize(int position, LanguageSyntaxNode memberDeclarationOpt, ISymbol memberOpt);
    }
}
