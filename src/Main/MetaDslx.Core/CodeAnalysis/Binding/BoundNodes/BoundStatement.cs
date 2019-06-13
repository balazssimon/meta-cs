using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundStatement : BoundNode
    {
        private readonly IOperation _statement;

        protected BoundStatement(BoundKind kind, BoundTree boundTree, BoundNodeFlags nodeFlags, IOperation statement, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, nodeFlags, syntax, hasErrors)
        {
            _statement = statement;
        }

        public IOperation Statement => _statement;
    }
}
