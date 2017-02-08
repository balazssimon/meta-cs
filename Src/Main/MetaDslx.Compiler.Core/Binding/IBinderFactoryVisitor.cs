using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public interface IBinderFactoryVisitor 
    {
        int Position { get; set; }

        Binder Visit(SyntaxNode node);
    }
}
