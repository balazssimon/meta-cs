﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Symbols;
using System.Collections.Immutable;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Provides information about how data flows into and out of a region. This information is
    /// returned from a call to
    /// <see cref="SemanticModel.AnalyzeDataFlow(SyntaxNode, SyntaxNode)" />, or one of its language-specific overloads,
    /// where you pass the first and last statements of the region as parameters.
    /// "Inside" means those statements or ones between them. "Outside" are any other statements of the same method.
    /// </summary>
    public abstract class DataFlowAnalysis
    {
        /// <summary>
        /// The set of local variables that are declared within a region. Note
        /// that the region must be bounded by a method's body or a field's initializer, so
        /// parameter symbols are never included in the result.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> VariablesDeclared { get; }

        /// <summary>
        /// The set of local variables which are assigned a value outside a region
        /// that may be used inside the region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> DataFlowsIn { get; }

        /// <summary>
        /// The set of local variables which are assigned a value inside a region
        /// that may be used outside the region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> DataFlowsOut { get; }

        /// <summary>
        /// The set of local variables for which a value is always assigned inside
        /// a region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> AlwaysAssigned { get; }

        /// <summary>
        /// The set of local variables that are read inside a region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> ReadInside { get; }

        /// <summary>
        /// The set of local variables that are written inside a region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> WrittenInside { get; }

        /// <summary>
        /// The set of the local variables that are read outside a region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> ReadOutside { get; }

        /// <summary>
        /// The set of local variables that are written outside a region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> WrittenOutside { get; }

        /// <summary>
        /// The set of the local variables that have been referenced in anonymous
        /// functions within a region and therefore must be moved to a field of a frame class.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> Captured { get; }

        /// <summary>
        /// The set of variables that are captured inside a region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> CapturedInside { get; }

        /// <summary>
        /// The set of variables that are captured outside a region.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> CapturedOutside { get; }

        /// <summary>
        /// The set of non-constant local variables and parameters that have had their
        /// address (or the address of one of their fields) taken.
        /// </summary>
        public abstract ImmutableArray<ISymbol0> UnsafeAddressTaken { get; }

        /// <summary>
        /// Returns true iff analysis was successful.  Analysis can fail if the region does not
        /// properly span a single expression, a single statement, or a contiguous series of
        /// statements within the enclosing block.
        /// </summary>
        public abstract bool Succeeded { get; }
    }
}
