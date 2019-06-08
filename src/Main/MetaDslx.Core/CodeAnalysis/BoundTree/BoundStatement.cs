using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.BoundTree
{
    public class BoundStatement : BoundNode
    {
        private readonly IOperation _statement;

        protected BoundStatement(BoundKind kind, LanguageSyntaxNode syntax, IOperation statement, bool hasErrors = false)
            : base(kind, syntax)
        {
            _statement = statement;
        }

        public IOperation Statement => _statement;
    }
}
