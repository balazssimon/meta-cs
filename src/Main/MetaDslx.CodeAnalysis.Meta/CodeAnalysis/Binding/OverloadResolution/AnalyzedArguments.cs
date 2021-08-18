// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System.Collections.Immutable;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    // Note: instances of this object are pooled
    internal sealed class AnalyzedArguments
    {
        public readonly ArrayBuilder<ArgumentSymbol> Arguments;
        public bool IsExtensionMethodInvocation;
        private ThreeState _lazyHasDynamicArgument;

        internal AnalyzedArguments()
        {
            this.Arguments = new ArrayBuilder<ArgumentSymbol>(32);
        }

        public void Clear()
        {
            this.Arguments.Clear();
            this.IsExtensionMethodInvocation = false;
            _lazyHasDynamicArgument = ThreeState.Unknown;
        }

        public ArgumentSymbol Argument(int i)
        {
            return Arguments[i];
        }

        public string Name(int i)
        {
            if (Arguments.Count == 0)
            {
                return null;
            }

            return Arguments[i].Name;
        }

        public ImmutableArray<string> GetNames()
        {
            int count = this.Arguments.Count;

            if (count == 0)
            {
                return default;
            }

            var builder = ArrayBuilder<string>.GetInstance(this.Arguments.Count);
            for (int i = 0; i < this.Arguments.Count; ++i)
            {
                builder.Add(Name(i));
            }

            return builder.ToImmutableAndFree();
        }

        public RefKind RefKind(int i)
        {
            return Arguments.Count > 0 ? Arguments[i].RefKind : Microsoft.CodeAnalysis.RefKind.None;
        }

        public bool IsExtensionMethodThisArgument(int i)
        {
            return (i == 0) && this.IsExtensionMethodInvocation;
        }

        public bool HasDynamicArgument
        {
            get
            {
                if (_lazyHasDynamicArgument.HasValue())
                {
                    return _lazyHasDynamicArgument.Value();
                }

                for (int i = 0; i < Arguments.Count; i++)
                {
                    var argument = Arguments[i];
                    var argumentType = argument.Value.Type;
                    // By-ref dynamic arguments don't make the invocation dynamic.
                    if (argumentType is not null && argumentType.Equals(AssemblySymbol.DynamicType) && (argument.RefKind == Microsoft.CodeAnalysis.RefKind.None))
                    {
                        _lazyHasDynamicArgument = ThreeState.True;
                        return true;
                    }
                }

                _lazyHasDynamicArgument = ThreeState.False;
                return false;
            }
        }

        public bool HasErrors
        {
            get
            {
                foreach (var argument in this.Arguments)
                {
                    if (argument.HasAnyErrors)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #region "Poolable"

        public static AnalyzedArguments GetInstance()
        {
            return Pool.Allocate();
        }

        public static AnalyzedArguments GetInstance(AnalyzedArguments original)
        {
            var instance = GetInstance();
            instance.Arguments.AddRange(original.Arguments);
            instance.IsExtensionMethodInvocation = original.IsExtensionMethodInvocation;
            instance._lazyHasDynamicArgument = original._lazyHasDynamicArgument;
            return instance;
        }

        public static AnalyzedArguments GetInstance(ImmutableArray<ArgumentSymbol> arguments)
        {
            var instance = GetInstance();
            instance.Arguments.AddRange(arguments);
            return instance;
        }

        public void Free()
        {
            this.Clear();
            Pool.Free(this);
        }

        //2) Expose the pool or the way to create a pool or the way to get an instance.
        //       for now we will expose both and figure which way works better
        public static readonly ObjectPool<AnalyzedArguments> Pool = CreatePool();

        private static ObjectPool<AnalyzedArguments> CreatePool()
        {
            ObjectPool<AnalyzedArguments> pool = null;
            pool = new ObjectPool<AnalyzedArguments>(() => new AnalyzedArguments(), 10);
            return pool;
        }

        #endregion
    }
}
