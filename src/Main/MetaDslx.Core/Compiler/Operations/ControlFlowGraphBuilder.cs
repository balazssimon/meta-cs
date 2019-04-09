// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using MetaDslx.Compiler.Operations;
using MetaDslx.Compiler.PooledObjects;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.FlowAnalysis
{
    internal sealed partial class ControlFlowGraphBuilder : OperationVisitor<int?, IOperation>
    {
        private readonly Compilation _compilation;
        private readonly BasicBlockBuilder _entry = new BasicBlockBuilder(BasicBlockKind.Entry);
        private readonly BasicBlockBuilder _exit = new BasicBlockBuilder(BasicBlockKind.Exit);

        private ArrayBuilder<BasicBlockBuilder> _blocks;
        private BasicBlockBuilder _currentBasicBlock;

        private readonly CaptureIdDispenser _captureIdDispenser;

        private ControlFlowGraphBuilder(Compilation compilation, CaptureIdDispenser captureIdDispenser)
        {
            Debug.Assert(compilation != null);
            _compilation = compilation;
            _captureIdDispenser = captureIdDispenser ?? new CaptureIdDispenser();
        }

        public static ControlFlowGraph Create(IOperation body, ControlFlowGraph parent = null)
        {
            Debug.Assert(body != null);
            return new ControlFlowGraph(body, parent);
        }

    }
}
