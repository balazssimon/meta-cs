// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MetaDslx.Compiler.ErrorReporting;
using MetaDslx.Compiler.Operations;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.FlowAnalysis
{
    /// <summary>
    /// Control flow graph representation for a given executable code block <see cref="OriginalOperation"/>.
    /// This graph contains a set of <see cref="BasicBlock"/>s, with an entry block, zero
    /// or more intermediate basic blocks and an exit block.
    /// Each basic block contains zero or more <see cref="BasicBlock.Operations"/> and
    /// explicit <see cref="ControlFlowBranch"/>(s) to other basic block(s).
    /// </summary>
    public sealed partial class ControlFlowGraph
    {
        private readonly ControlFlowGraphBuilder.CaptureIdDispenser _captureIdDispenser;
        private readonly ImmutableDictionary<IMethodSymbol, (ControlFlowRegion region, ILocalFunctionOperation operation, int ordinal)> _localFunctionsMap;
        private ControlFlowGraph[] _lazyLocalFunctionsGraphs;
        private readonly ImmutableDictionary<IFlowAnonymousFunctionOperation, (ControlFlowRegion region, int ordinal)> _anonymousFunctionsMap;
        private ControlFlowGraph[] _lazyAnonymousFunctionsGraphs;

        internal ControlFlowGraph(IOperation originalOperation,
                                  ControlFlowGraph parent)
        {
            Debug.Assert(parent != null == (originalOperation.Kind == OperationKind.LocalFunction || originalOperation.Kind == OperationKind.AnonymousFunction));

            OriginalOperation = originalOperation;
            Parent = parent;
        }

#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters
        /// <summary>
        /// Creates a <see cref="ControlFlowGraph"/> for the given executable code block root <paramref name="node"/>.
        /// </summary>
        /// <param name="node">Root syntax node for an executable code block.</param>
        /// <param name="semanticModel">Semantic model for the syntax tree containing the <paramref name="node"/>.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>
        /// Returns null if <see cref="SemanticModel.GetOperation(SyntaxNode, CancellationToken)"/> returns null for the given <paramref name="node"/> and <paramref name="semanticModel"/>.
        /// Otherwise, returns a <see cref="ControlFlowGraph"/> for the executable code block.
        /// </returns>
        public static ControlFlowGraph Create(SyntaxNode node, SemanticModel semanticModel, CancellationToken cancellationToken = default)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (semanticModel == null)
            {
                throw new ArgumentNullException(nameof(semanticModel));
            }

            IOperation operation = semanticModel.GetOperation(node, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            return operation == null ? null : CreateCore(operation, nameof(operation), cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="ControlFlowGraph"/> for the given executable code block <paramref name="body"/>.
        /// </summary>
        /// <param name="body">Root operation block, which must have a null parent.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public static ControlFlowGraph Create(Operations.IBlockOperation body, CancellationToken cancellationToken = default)
        {
            return CreateCore(body, nameof(body), cancellationToken);
        }

#pragma warning restore RS0026 // Do not add multiple public overloads with optional parameters

        internal static ControlFlowGraph CreateCore(IOperation operation, string argumentNameForException, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (operation == null)
            {
                throw new ArgumentNullException(argumentNameForException);
            }

            if (operation.Parent != null)
            {
                throw new ArgumentException(CompilerResources.NotARootOperation, argumentNameForException);
            }

            try
            {
                ControlFlowGraph controlFlowGraph = ControlFlowGraphBuilder.Create(operation);
                Debug.Assert(controlFlowGraph.OriginalOperation == operation);
                return controlFlowGraph;
            }
            catch (Exception e) when (FatalError.ReportWithoutCrashUnlessCanceled(e))
            {
                // Log a Non-fatal-watson and then ignore the crash in the attempt of getting flow graph.
                Debug.Assert(false, "\n" + e.ToString());
            }

            return default;
        }

        /// <summary>
        /// Original operation, representing an executable code block, from which this control flow graph was generated.
        /// Note that <see cref="BasicBlock.Operations"/> in the control flow graph are not in the same operation tree as
        /// the original operation.
        /// </summary>
        public IOperation OriginalOperation { get; }

        /// <summary>
        /// Optional parent control flow graph for this graph.
        /// Non-null for a control flow graph generated for a local function or a lambda.
        /// Null otherwise.
        /// </summary>
        public ControlFlowGraph Parent { get; }

        /// <summary>
        /// Basic blocks for the control flow graph.
        /// </summary>
        public ImmutableArray<BasicBlock> Blocks { get; }

        /// <summary>
        /// Root (<see cref="ControlFlowRegionKind.Root"/>) region for the graph.
        /// </summary>
        public ControlFlowRegion Root { get; }

        /// <summary>
        /// Local functions declared within <see cref="OriginalOperation"/>.
        /// </summary>
        public ImmutableArray<IMethodSymbol> LocalFunctions { get; }

    }
}
