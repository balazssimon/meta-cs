using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class FindBindableNodeVisitor : DetailedSyntaxVisitor
    {
        public FindBindableNodeVisitor() 
            : base(false, false)
        {
        }
    }
}
