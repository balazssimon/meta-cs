// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// #define COLLECT_STATS

using System;
using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Text;
using Roslyn.Utilities;
using System.Text;
using MetaDslx.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal class LexerCache
    {
        private readonly TextKeyedCache<InternalSyntaxTrivia> _triviaMap;
        private readonly TextKeyedCache<InternalSyntaxToken> _tokenMap;
        private readonly CachingIdentityFactory<string, SyntaxKind> _keywordKindMap;
        internal const int MaxKeywordLength = 10;

        internal LexerCache(Language language)
        {
            _triviaMap = TextKeyedCache<InternalSyntaxTrivia>.GetInstance();
            _tokenMap = TextKeyedCache<InternalSyntaxToken>.GetInstance();
            _keywordKindMap = language.InternalSyntaxFactory.KeywordKindPool.Allocate();
        }

        internal void Free()
        {
            _keywordKindMap.Free();
            _triviaMap.Free();
            _tokenMap.Free();
        }

        internal bool TryGetKeywordKind(string key, out SyntaxKind kind)
        {
            if (key.Length > MaxKeywordLength)
            {
                kind = SyntaxKind.None;
                return false;
            }

            kind = _keywordKindMap.GetOrMakeValue(key);
            return kind != SyntaxKind.None;
        }

        internal InternalSyntaxTrivia LookupTrivia(
            char[] textBuffer,
            int keyStart,
            int keyLength,
            int hashCode,
            Func<InternalSyntaxTrivia> createTriviaFunction)
        {
            var value = _triviaMap.FindItem(textBuffer, keyStart, keyLength, hashCode);

            if (value == null)
            {
                value = createTriviaFunction();
                _triviaMap.AddItem(textBuffer, keyStart, keyLength, hashCode, value);
            }

            return value;
        }

        // TODO: remove this when done tweaking this cache.
#if COLLECT_STATS
        private static int hits = 0;
        private static int misses = 0;

        private static void Hit()
        {
            var h = System.Threading.Interlocked.Increment(ref hits);

            if (h % 10000 == 0)
            {
                Console.WriteLine(h * 100 / (h + misses));
            }
        }

        private static void Miss()
        {
            System.Threading.Interlocked.Increment(ref misses);
        }
#endif


        internal InternalSyntaxToken LookupToken(
            char[] textBuffer,
            int keyStart,
            int keyLength,
            int hashCode,
            Func<InternalSyntaxToken> createTokenFunction)
        {
            var value = _tokenMap.FindItem(textBuffer, keyStart, keyLength, hashCode);

            if (value == null)
            {
#if COLLECT_STATS
                    Miss();
#endif
                value = createTokenFunction();
                _tokenMap.AddItem(textBuffer, keyStart, keyLength, hashCode, value);
            }
            else
            {
#if COLLECT_STATS
                    Hit();
#endif
            }

            return value;
        }
    }
}
