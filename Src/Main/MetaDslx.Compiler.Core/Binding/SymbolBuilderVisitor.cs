using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public interface ISymbolBuilderVisitor
    {
        MutableSymbol Symbol { get; set; }
        MergedDeclaration Declaration { get; set; }
        void Visit(SyntaxNode node);
    }
}
