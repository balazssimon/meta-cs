// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.CodeAnalysis.CSharp
{
    /// <summary>
    /// This is a special binder used for decoding some special well-known attributes very early in the attribute binding phase.
    /// It only binds those attribute argument syntax which can produce valid attribute arguments, but doesn't report any diagnostics.
    /// Subsequent binding phase will rebind such erroneous attributes and generate appropriate diagnostics.
    /// </summary>
    internal sealed class EarlyWellKnownAttributeBinder : Binder
    {
        internal EarlyWellKnownAttributeBinder(Binder enclosing)
            : base(enclosing, enclosing.Flags | BinderFlags.EarlyAttributeBinding)
        {
        }

        internal CSharpAttributeData GetAttribute(CSharpSyntaxNode node, NamedTypeSymbol boundAttributeType, out bool generatedDiagnostics)
        {
            var dummyDiagnosticBag = DiagnosticBag.GetInstance();
            var boundAttribute = base.GetAttribute(node, boundAttributeType, dummyDiagnosticBag);
            generatedDiagnostics = !dummyDiagnosticBag.IsEmptyWithoutResolution;
            dummyDiagnosticBag.Free();
            return boundAttribute;
        }

        /// <remarks>
        /// Since this method is expected to be called on every nested expression of the argument, it doesn't
        /// need to recurse (directly).
        /// </remarks>
        internal static bool CanBeValidAttributeArgument(CSharpSyntaxNode node, Binder typeBinder)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }
    }
}
