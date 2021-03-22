// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp.Symbols
{
    internal static class EventSymbolExtensions
    {
        internal static MethodSymbol GetOwnOrInheritedAccessor(this EventSymbol @event, bool isAdder)
        {
            return isAdder
                ? @event.GetOwnOrInheritedAddMethod()
                : @event.GetOwnOrInheritedRemoveMethod();
        }
    }
}
