// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp
{
    internal sealed partial class LocalRewriter
    {
        public override BoundNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node)
        {
            ArrayBuilder<BoundStatement> inits = null;

            foreach (var decl in node.LocalDeclarations)
            {
                var init = VisitLocalDeclaration(decl);

                if (init != null)
                {
                    if (inits == null)
                    {
                        inits = ArrayBuilder<BoundStatement>.GetInstance();
                    }

                    inits.Add((BoundStatement)init);
                }
            }

            if (inits != null)
            {
                return BoundStatementList.Synthesized(node.Syntax, node.HasErrors, inits.ToImmutableAndFree());
            }
            else
            {
                // no initializers
                return null; // TODO: but what if hasErrors?  Have we lost that?
            }
        }

        public override BoundNode VisitUsingLocalDeclarations(BoundUsingLocalDeclarations node)
        {
            return VisitMultipleLocalDeclarations(node);
        }
    }
}
