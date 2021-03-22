// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;

namespace MetaDslx.CodeAnalysis.CSharp
{
    internal sealed class SynthesizedClosureEnvironmentConstructor : SynthesizedInstanceConstructor, ISynthesizedMethodBodyImplementationSymbol
    {
        internal SynthesizedClosureEnvironmentConstructor(SynthesizedClosureEnvironment frame)
            : base(frame)
        {
        }

        IMethodSymbol ISynthesizedMethodBodyImplementationSymbol.Method
        {
            get { return ((ISynthesizedMethodBodyImplementationSymbol)this.ContainingSymbol).Method; }
        }

        bool ISynthesizedMethodBodyImplementationSymbol.HasMethodBodyDependency
        {
            get { return false; }
        }
    }
}
