// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract partial class BoundTreeWalker : BoundTreeVisitor
    {
        protected BoundTreeWalker()
        {
        }

        public void VisitList<T>(ImmutableArray<T> list) where T : BoundNode
        {
            if (!list.IsDefault)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    this.Visit(list[i]);
                }
            }
        }
    }

    /// <summary>
    /// Note: do not use a static/singleton instance of this type, as it holds state.
    /// </summary>
    public abstract class BoundTreeWalkerWithStackGuard : BoundTreeWalker
    {
        private int _recursionDepth;

        protected BoundTreeWalkerWithStackGuard()
        { }

        protected BoundTreeWalkerWithStackGuard(int recursionDepth)
        {
            _recursionDepth = recursionDepth;
        }

        protected int RecursionDepth => _recursionDepth;

        public override BoundNode Visit(BoundNode node)
        {
            var expression = node as BoundExpression;
            if (expression != null)
            {
                return VisitExpressionWithStackGuard(ref _recursionDepth, expression);
            }

            return base.Visit(node);
        }

        protected BoundExpression VisitExpressionWithStackGuard(BoundExpression node)
        {
            return VisitExpressionWithStackGuard(ref _recursionDepth, node);
        }

        protected sealed override BoundExpression VisitExpressionWithoutStackGuard(BoundExpression node)
        {
            return (BoundExpression)base.Visit(node);
        }
    }

}
