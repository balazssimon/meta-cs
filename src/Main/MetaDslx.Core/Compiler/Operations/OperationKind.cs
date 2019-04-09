// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using MetaDslx.Compiler.FlowAnalysis;
using MetaDslx.Compiler.Operations;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// All of the kinds of operations, including statements and expressions.
    /// </summary>
    public enum OperationKind
    {
        /// <summary>Indicates an <see cref="IOperation"/> for a construct that is not implemented yet.</summary>
        None = 0x0,
        /// <summary>Indicates an <see cref="IInvalidOperation"/>.</summary>
        Invalid = 0x1,
        /// <summary>Indicates an <see cref="ILocalFunctionOperation"/></summary>
        LocalFunction = 0x10,
        /// <summary>Indicates an <see cref="IAnonymousFunctionOperation"/>.</summary>
        AnonymousFunction = 0x23,
    }
}
