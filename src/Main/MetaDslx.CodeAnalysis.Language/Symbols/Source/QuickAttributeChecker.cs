// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// The QuickAttributeChecker applies a simple fast heuristic for determining probable
    /// attributes of certain kinds without binding attribute types, just by looking at the final syntax of an
    /// attribute usage.
    /// </summary>
    /// <remarks>
    /// It works by maintaining a dictionary of all possible simple names that might map to the given
    /// attribute.
    /// </remarks>
    internal sealed class QuickAttributeChecker
    {
        private readonly Dictionary<string, QuickAttributes> _nameToAttributeMap;
        private static QuickAttributeChecker _lazyPredefinedQuickAttributeChecker;

#if DEBUG
        private bool _sealed;
#endif

        internal static QuickAttributeChecker Predefined
        {
            get
            {
                if (_lazyPredefinedQuickAttributeChecker is null)
                {
                    Interlocked.CompareExchange(ref _lazyPredefinedQuickAttributeChecker, CreatePredefinedQuickAttributeChecker(), null);
                }

                return _lazyPredefinedQuickAttributeChecker;
            }
        }

        private static QuickAttributeChecker CreatePredefinedQuickAttributeChecker()
        {
            var result = new QuickAttributeChecker();
            result.AddName(AttributeDescription.TypeIdentifierAttribute.Name, QuickAttributes.TypeIdentifier);
            result.AddName(AttributeDescription.TypeForwardedToAttribute.Name, QuickAttributes.TypeForwardedTo);

#if DEBUG
            result._sealed = true;
#endif
            return result;
        }

        private QuickAttributeChecker()
        {
            _nameToAttributeMap = new Dictionary<string, QuickAttributes>(StringComparer.Ordinal);
            // NOTE: caller must seal
        }

        private QuickAttributeChecker(QuickAttributeChecker previous)
        {
            _nameToAttributeMap = new Dictionary<string, QuickAttributes>(previous._nameToAttributeMap, StringComparer.Ordinal);
            // NOTE: caller must seal
        }

        private void AddName(string name, QuickAttributes newAttributes)
        {
#if DEBUG
            Debug.Assert(!_sealed);
#endif
            var currentValue = QuickAttributes.None;
            _nameToAttributeMap.TryGetValue(name, out currentValue);

            QuickAttributes newValue = newAttributes | currentValue;
            _nameToAttributeMap[name] = newValue;
        }

        internal QuickAttributeChecker AddAliasesIfAny(SyntaxList<CSharpSyntaxNode> usingsSyntax)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public bool IsPossibleMatch(CSharpSyntaxNode attr, QuickAttributes pattern)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }
    }

    [Flags]
    internal enum QuickAttributes : byte
    {
        None = 0,
        TypeIdentifier = 1 << 0,
        TypeForwardedTo = 2 << 0
    }
}
