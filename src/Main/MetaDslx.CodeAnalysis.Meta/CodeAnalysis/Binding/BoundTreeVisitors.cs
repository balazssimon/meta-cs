// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using Microsoft.CodeAnalysis.Text;
using System;
using Roslyn.Utilities;
using System.Linq;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BoundTreeVisitor<A, R>
    {
        protected BoundTreeVisitor()
        {
        }

        public virtual R Visit(BoundNode node, A arg)
        {
            if (node == null)
            {
                return default(R);
            }

            return DefaultVisit(node, arg);
        }

        public virtual R DefaultVisit(BoundNode node, A arg)
        {
            return default(R);
        }
    }

    public abstract class BoundTreeVisitor
    {
        protected BoundTreeVisitor()
        {
        }

        [DebuggerHidden]
        public virtual BoundNode Visit(BoundNode node)
        {
            if (node != null)
            {
                return node.Accept(this);
            }

            return null;
        }

        [DebuggerHidden]
        public virtual BoundNode DefaultVisit(BoundNode node)
        {
            return null;
        }

        public class CancelledByStackGuardException : Exception
        {
            public readonly BoundNode Node;

            public CancelledByStackGuardException(Exception inner, BoundNode node)
                : base(inner.Message, inner)
            {
                Node = node;
            }

            public void AddAnError(DiagnosticBag diagnostics)
            {
                diagnostics.Add(InternalErrorCode.ERR_InsufficientStack, GetTooLongOrComplexNodeErrorLocation(Node));
            }

            public static Location GetTooLongOrComplexNodeErrorLocation(BoundNode node)
            {
                SyntaxNode syntax = node.Syntax;
                return syntax.GetFirstToken().GetLocation();
            }
        }

        /// <summary>
        /// Consumers must provide implementation for <see cref="VisitExpressionWithoutStackGuard"/>.
        /// </summary>
        protected BoundExpression VisitExpressionWithStackGuard(ref int recursionDepth, BoundExpression node)
        {
            BoundExpression result;
            recursionDepth++;
#if DEBUG
            int saveRecursionDepth = recursionDepth;
#endif

            if (recursionDepth > 1 || !ConvertInsufficientExecutionStackExceptionToCancelledByStackGuardException())
            {
                StackGuard.EnsureSufficientExecutionStack(recursionDepth);

                result = VisitExpressionWithoutStackGuard(node);
            }
            else
            {
                result = VisitExpressionWithStackGuard(node);
            }

#if DEBUG
            Debug.Assert(saveRecursionDepth == recursionDepth);
#endif
            recursionDepth--;
            return result;
        }

        protected virtual bool ConvertInsufficientExecutionStackExceptionToCancelledByStackGuardException()
        {
            return true;
        }

        private BoundExpression VisitExpressionWithStackGuard(BoundExpression node)
        {
            try
            {
                return VisitExpressionWithoutStackGuard(node);
            }
            catch (InsufficientExecutionStackException ex)
            {
                throw new CancelledByStackGuardException(ex, node);
            }
        }

        /// <summary>
        /// We should be intentional about behavior of derived classes regarding guarding against stack overflow.
        /// </summary>
        protected abstract BoundExpression VisitExpressionWithoutStackGuard(BoundExpression node);
    }
}
