// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using MetaDslx.CodeAnalysis.CSharp.Symbols;

namespace MetaDslx.CodeAnalysis.CSharp
{
    // Note: this code has a copy-and-paste sibling in AbstractRegionDataFlowPass. Any fix to
    // one should be applied to the other.
    internal abstract class AbstractRegionControlFlowPass : ControlFlowPass
    {
        internal AbstractRegionControlFlowPass(
            CSharpCompilation compilation,
            Symbol member,
            BoundNode node,
            BoundNode firstInRegion,
            BoundNode lastInRegion)
            : base(compilation, member, node, firstInRegion, lastInRegion)
        {
        }

        public override BoundNode Visit(BoundNode node)
        {
            VisitAlways(node);
            return null;
        }

        // Control flow analysis does not normally scan the body of a lambda, but region analysis does.
        public override BoundNode VisitLambda(BoundLambda node)
        {
            return VisitLocalFunctionOrLambda(node.Body);
        }

        public override BoundNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node)
        {
            return VisitLocalFunctionOrLambda(node.Body);
        }

        private BoundNode VisitLocalFunctionOrLambda(BoundBlock body)
        {
            var oldPending = SavePending(); // We do not support branches *into* a lambda.
            LocalState finalState = this.State;
            this.State = TopState();
            var oldPending2 = SavePending();
            VisitAlways(body);
            RestorePending(oldPending2); // process any forward branches within the lambda body
            ImmutableArray<PendingBranch> pendingReturns = RemoveReturns();
            RestorePending(oldPending);
            Join(ref finalState, ref this.State);
            foreach (PendingBranch returnBranch in pendingReturns)
            {
                this.State = returnBranch.State;
                Join(ref finalState, ref this.State);
            }

            this.State = finalState;
            return null;
        }
    }
}
