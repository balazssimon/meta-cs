// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal class SyntaxFirstTokenReplacer : InternalSyntaxRewriter
    {
        private readonly InternalSyntaxToken _oldToken;
        private readonly InternalSyntaxToken _newToken;
        private readonly int _diagnosticOffsetDelta;
        private bool _foundOldToken;

        private SyntaxFirstTokenReplacer(InternalSyntaxToken oldToken, InternalSyntaxToken newToken, int diagnosticOffsetDelta)
        {
            _oldToken = oldToken;
            _newToken = newToken;
            _diagnosticOffsetDelta = diagnosticOffsetDelta;
            _foundOldToken = false;
        }

        internal static TRoot Replace<TRoot>(TRoot root, InternalSyntaxToken oldToken, InternalSyntaxToken newToken, int diagnosticOffsetDelta)
            where TRoot : InternalSyntaxNode
        {
            var replacer = new SyntaxFirstTokenReplacer(oldToken, newToken, diagnosticOffsetDelta);
            var newRoot = (TRoot)replacer.Visit(root);
            Debug.Assert(replacer._foundOldToken);
            return newRoot;
        }

        public override InternalSyntaxNode Visit(InternalSyntaxNode node)
        {
            if (node != null)
            {
                if (!_foundOldToken)
                {
                    var token = node as InternalSyntaxToken;
                    if (token != null)
                    {
                        Debug.Assert(token == _oldToken);
                        _foundOldToken = true;
                        return _newToken; // NB: diagnostic offsets have already been updated (by SyntaxParser.AddSkippedSyntax)
                    }

                    return UpdateDiagnosticOffset(base.Visit(node), _diagnosticOffsetDelta);
                }
            }

            return node;
        }

        private static TSyntax UpdateDiagnosticOffset<TSyntax>(TSyntax node, int diagnosticOffsetDelta) where TSyntax : InternalSyntaxNode
        {
            DiagnosticInfo[] oldDiagnostics = node.GetDiagnostics();
            if (oldDiagnostics == null || oldDiagnostics.Length == 0)
            {
                return node;
            }

            var numDiagnostics = oldDiagnostics.Length;
            DiagnosticInfo[] newDiagnostics = new DiagnosticInfo[numDiagnostics];
            for (int i = 0; i < numDiagnostics; i++)
            {
                DiagnosticInfo oldDiagnostic = oldDiagnostics[i];
                SyntaxDiagnosticInfo oldSyntaxDiagnostic = oldDiagnostic as SyntaxDiagnosticInfo;
                newDiagnostics[i] = oldSyntaxDiagnostic == null ?
                    oldDiagnostic :
                    new SyntaxDiagnosticInfo(
                        oldSyntaxDiagnostic.Offset + diagnosticOffsetDelta,
                        oldSyntaxDiagnostic.Width,
                        oldSyntaxDiagnostic.ErrorCode,
                        oldSyntaxDiagnostic.Arguments);
            }
            return node.WithDiagnosticsGreen(newDiagnostics);
        }
    }
}
