// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Represents a <see cref="CSharpSyntaxNode"/> visitor that visits only the single CSharpSyntaxNode
    /// passed into its Visit method and produces 
    /// a value of the type specified by the <typeparamref name="TResult"/> parameter.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the return value this visitor's Visit method.
    /// </typeparam>
    public abstract partial class SyntaxVisitor<TNode, TResult>
        where TNode: SyntaxNode
    {
        public virtual TResult Visit(TNode node)
        {
            if (node != null)
            {
                return ((LanguageSyntaxNode)(SyntaxNode)node).Accept(this);
            }

            // should not come here too often so we will put this at the end of the method.
            return default;
        }

        public virtual TResult DefaultVisit(TNode node)
        {
            return default;
        }
    }

    /// <summary>
    /// Represents a <see cref="CSharpSyntaxNode"/> visitor that visits only the single CSharpSyntaxNode
    /// passed into its Visit method.
    /// </summary>
    public abstract partial class SyntaxVisitor<TNode>
        where TNode : SyntaxNode
    {
        public virtual void Visit(TNode node)
        {
            if (node != null)
            {
                ((LanguageSyntaxNode)(SyntaxNode)node).Accept(this);
            }
        }

        public virtual void DefaultVisit(TNode node)
        {
        }
    }
}
