// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Operations
{
    internal sealed class LanguageOperationFactory
    {
        private readonly ConcurrentDictionary<BoundNode, IOperation> _nodeMap =
            new ConcurrentDictionary<BoundNode, IOperation>(concurrencyLevel: 2, capacity: 10);

        private readonly Func<BoundNode, IOperation> _cachedCreateInternal;

        private readonly SemanticModel _semanticModel;

        public LanguageOperationFactory(SemanticModel semanticModel)
        {
            _semanticModel = semanticModel;
            _cachedCreateInternal = CreateInternal;
        }

        public IOperation Create(BoundNode boundNode)
        {
            if (boundNode == null)
            {
                return null;
            }
            return _nodeMap.GetOrAdd(boundNode, _cachedCreateInternal);
        }

        internal IOperation CreateInternal(BoundNode boundNode)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

    }
}
