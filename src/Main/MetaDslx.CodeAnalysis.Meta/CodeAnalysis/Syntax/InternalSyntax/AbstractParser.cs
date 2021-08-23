using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class AbstractParser : IDisposable
    {
        public readonly Language Language;
        private readonly List<SyntaxDiagnosticInfo> _errors;
        private readonly List<SyntaxDiagnosticInfo> _unprocessedErrors;

        public AbstractParser(Language language)
        {
            Language = language;
            _errors = new List<SyntaxDiagnosticInfo>();
            _unprocessedErrors = new List<SyntaxDiagnosticInfo>();
        }

        internal protected abstract int TokenIndex { get; }
        internal protected abstract int TokenCount { get; }
        protected abstract InternalSyntaxToken CurrentToken { get; }
        protected abstract GreenNode PrevTokenTrailingTrivia { get; }

        protected void ResetErrorIndex(int errorIndex)
        {
            /*if (errorIndex >= 0 && errorIndex < _errors.Count)
            {
                for (int i = errorIndex; i < _errors.Count; i++)
                {
                    var error = _errors[i];
                    if (_unprocessedErrors.Any(err => error.Equals(err) && err.ErrorCode == error.ErrorCode && err.Offset == error.Offset && err.Width == error.Width)) continue;
                    _unprocessedErrors.Add(error);
                }
            }*/
        }

        protected GreenNode WithCurrentSyntaxErrors(GreenNode green, int position, int width, ref int errorIndex)
        {
            if (_unprocessedErrors.Count > 0)
            {
                var start = position;
                var end = position + width;
                var offset = position;
                SyntaxDiagnosticInfo? lastError = null;
                var currentErrors = ArrayBuilder<SyntaxDiagnosticInfo>.GetInstance();
                for (int i = 0; i < _unprocessedErrors.Count; i++)
                {
                    var err = _unprocessedErrors[i];
                    if (err.Offset >= start && err.Offset + err.Width <= end)
                    {
                        currentErrors.Add(err.WithOffset(err.Offset - offset));
                        _unprocessedErrors.RemoveAt(i);
                        lastError = err;
                    }
                }
                if (lastError is not null)
                {
                    errorIndex = _errors.IndexOf(lastError) + 1;
                }
                if (currentErrors.Count > 0)
                {
                    return WithAdditionalDiagnostics(green, currentErrors.ToArrayAndFree());
                }
                else
                {
                    currentErrors.Free();
                }
                /*if (offset > 0)
                {
                    var array = new SyntaxDiagnosticInfo[_errors.Count];
                    for (int i = 0; i < _errors.Count; i++)
                    {
                        // fixup error positioning to account for leading trivia
                        array[i] = _errors[i].WithOffset(_errors[i].Offset + offset);
                    }
                    _errors.Clear();
                    return WithAdditionalDiagnostics(green, array);
                }
                else
                {
                    var array = _errors.ToArray();
                    _errors.Clear();
                    return WithAdditionalDiagnostics(green, array);
                }*/
            }
            return green;
        }

        protected virtual SyntaxDiagnosticInfo GetExpectedTokenError(SyntaxKind expected, SyntaxKind actual, int offset, int width)
        {
            var code = GetExpectedTokenErrorCode(expected, actual);
            if (code == InternalErrorCode.ERR_SyntaxError || code == InternalErrorCode.ERR_IdentifierExpectedKW)
            {
                return new SyntaxDiagnosticInfo(offset, width, code, Language.SyntaxFacts.GetText(expected), Language.SyntaxFacts.GetText(actual));
            }
            else
            {
                return new SyntaxDiagnosticInfo(offset, width, code);
            }
        }

        protected virtual SyntaxDiagnosticInfo GetExpectedTokenError(SyntaxKind expected, SyntaxKind actual)
        {
            int offset, width;
            this.GetDiagnosticSpanForMissingToken(out offset, out width);

            return this.GetExpectedTokenError(expected, actual, offset, width);
        }

        private ErrorCode GetExpectedTokenErrorCode(SyntaxKind expected, SyntaxKind actual)
        {
            if (Language.SyntaxFacts.IsIdentifier(expected))
            {
                if (Language.SyntaxFacts.IsReservedKeyword(actual))
                {
                    return InternalErrorCode.ERR_IdentifierExpectedKW;   // A keyword -- use special message.
                }
                else
                {
                    return InternalErrorCode.ERR_IdentifierExpected;
                }
            }
            else
            {
                return InternalErrorCode.ERR_SyntaxError;
            }
        }

        protected void GetDiagnosticSpanForMissingToken(out int offset, out int width)
        {
            // If the previous token has a trailing EndOfLineTrivia,
            // the missing token diagnostic position is moved to the
            // end of line containing the previous token and
            // its width is set to zero.
            // Otherwise the diagnostic offset and width is set
            // to the corresponding values of the current token

            var trivia = this.PrevTokenTrailingTrivia;
            if (trivia != null)
            {
                var triviaList = new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxNode>(trivia);
                bool prevTokenHasEndOfLineTrivia = triviaList.Any((int)(SyntaxKind)SyntaxKind.Eof);
                if (prevTokenHasEndOfLineTrivia)
                {
                    offset = -trivia.FullWidth;
                    width = 0;
                    return;
                }
            }

            InternalSyntaxToken ct = this.CurrentToken;
            offset = ct.GetLeadingTriviaWidth();
            width = ct.Width;
        }

        protected virtual TNode WithAdditionalDiagnostics<TNode>(TNode node, params DiagnosticInfo[] diagnostics) where TNode : GreenNode
        {
            DiagnosticInfo[] existingDiags = node.GetDiagnostics();
            int existingLength = existingDiags.Length;
            if (existingLength == 0)
            {
                return node.WithDiagnosticsGreen(diagnostics);
            }
            else
            {
                DiagnosticInfo[] result = new DiagnosticInfo[existingDiags.Length + diagnostics.Length];
                existingDiags.CopyTo(result, 0);
                diagnostics.CopyTo(result, existingLength);
                return node.WithDiagnosticsGreen(result);
            }
        }

        protected void AddError(int offset, int width, ErrorCode code, params object[] args)
        {
            this.AddSyntaxError(MakeError(offset, width, code, args));
        }

        protected void AddSyntaxError(SyntaxDiagnosticInfo error)
        {
            if (error != null)
            {
                if (_errors.Any(err => error.Equals(err) && err.ErrorCode == error.ErrorCode && err.Offset == error.Offset && err.Width == error.Width)) return;
                _errors.Add(error);
                _unprocessedErrors.Add(error);
            }
        }

        protected static SyntaxDiagnosticInfo MakeError(int offset, int width, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(offset, width, code, args);
        }

        protected static SyntaxDiagnosticInfo MakeError(GreenNode node, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(node.GetLeadingTriviaWidth(), node.Width, code, args);
        }

        /// <summary>
        /// Converts skippedSyntax node into tokens and adds these as trivia on the target token.
        /// Also adds the first error (in depth-first preorder) found in the skipped syntax tree to the target token.
        /// </summary>
        internal InternalSyntaxToken AddSkippedSyntax(InternalSyntaxToken target, GreenNode skippedSyntax, bool trailing)
        {
            var builder = new SyntaxListBuilder(4);

            // the error in we'll attach to the node
            SyntaxDiagnosticInfo diagnostic = null;

            // the position of the error within the skippedSyntax node full tree
            int diagnosticOffset = 0;

            int currentOffset = 0;
            foreach (var node in skippedSyntax.EnumerateNodes())
            {
                InternalSyntaxToken token = node as InternalSyntaxToken;
                if (token != null)
                {
                    //builder.Add(token.GetLeadingTrivia());

                    if (token.Width > 0)
                    {
                        // separate trivia from the tokens
                        /*InternalSyntaxToken tk = token.TokenWithLeadingTrivia(null).TokenWithTrailingTrivia(null);

                        // adjust relative offsets of diagnostics attached to the token:
                        int leadingWidth = token.GetLeadingTriviaWidth();
                        if (leadingWidth > 0)
                        {
                            var tokenDiagnostics = tk.GetDiagnostics();
                            for (int i = 0; i < tokenDiagnostics.Length; i++)
                            {
                                var d = (SyntaxDiagnosticInfo)tokenDiagnostics[i];
                                tokenDiagnostics[i] = new SyntaxDiagnosticInfo(d.Offset - leadingWidth, d.Width, d.ErrorCode, d.Arguments);
                            }
                        }

                        builder.Add(Language.InternalSyntaxFactory.SkippedTokensTrivia(tk));
                        */
                        builder.Add(Language.InternalSyntaxFactory.SkippedTokensTrivia(token));
                    }
                    else
                    {
                        // do not create zero-width structured trivia, GetStructure doesn't work well for them
                        var existing = (SyntaxDiagnosticInfo)token.GetDiagnostics().FirstOrDefault();
                        if (existing != null)
                        {
                            diagnostic = existing;
                            diagnosticOffset = currentOffset;
                        }
                    }
                    //builder.Add(token.GetTrailingTrivia());

                    currentOffset += token.FullWidth;
                }
                else if (node.ContainsDiagnostics && diagnostic == null)
                {
                    // only propagate the first error to reduce noise:
                    var existing = (SyntaxDiagnosticInfo)node.GetDiagnostics().FirstOrDefault();
                    if (existing != null)
                    {
                        diagnostic = existing;
                        diagnosticOffset = currentOffset;
                    }
                }
            }

            int triviaWidth = currentOffset;
            var trivia = builder.ToListNode();

            // total width of everything preceding the added trivia
            int triviaOffset;
            if (trailing)
            {
                var trailingTrivia = target.GetTrailingTrivia();
                triviaOffset = target.FullWidth; //added trivia is full width (before addition)
                target = target.TokenWithTrailingTrivia(SyntaxList.Concat(trailingTrivia, trivia));
            }
            else
            {
                // Since we're adding triviaWidth before the token, we have to add that much to
                // the offset of each of its diagnostics.
                if (triviaWidth > 0)
                {
                    var targetDiagnostics = target.GetDiagnostics();
                    for (int i = 0; i < targetDiagnostics.Length; i++)
                    {
                        var d = (SyntaxDiagnosticInfo)targetDiagnostics[i];
                        targetDiagnostics[i] = new SyntaxDiagnosticInfo(d.Offset + triviaWidth, d.Width, d.ErrorCode, d.Arguments);
                    }
                }

                var leadingTrivia = target.GetLeadingTrivia();
                target = target.TokenWithLeadingTrivia(SyntaxList.Concat(trivia, leadingTrivia));
                triviaOffset = 0; //added trivia is first, so offset is zero
            }

            if (diagnostic != null)
            {
                int newOffset = triviaOffset + diagnosticOffset + diagnostic.Offset;

                target = WithAdditionalDiagnostics(target,
                    new SyntaxDiagnosticInfo(newOffset, diagnostic.Width, diagnostic.ErrorCode, diagnostic.Arguments)
                );
            }

            return target;
        }

        /// <summary>
        /// This function searches for the given location node within the subtree rooted at root node. 
        /// If it finds it, the function computes the offset span of that child node within the root and returns true, 
        /// otherwise it returns false.
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="location">Node to search in the subtree rooted at root node</param>
        /// <param name="offset">Offset of the location node within the subtree rooted at child</param>
        /// <returns></returns>
        private bool FindOffset(GreenNode root, InternalSyntaxNode location, out int offset)
        {
            int currentOffset = 0;
            offset = 0;
            if (root != null)
            {
                for (int i = 0, n = root.SlotCount; i < n; i++)
                {
                    var child = root.GetSlot(i);
                    if (child == null)
                    {
                        // ignore null slots
                        continue;
                    }

                    // check if the child node is the location node
                    if (child == location)
                    {
                        // Found the location node in the subtree
                        // Initialize offset with the offset of the location node within its parent
                        // and walk up the stack of recursive calls adding the offset of each node
                        // within its parent
                        offset = currentOffset;
                        return true;
                    }

                    // search for the location node in the subtree rooted at child node
                    if (this.FindOffset(child, location, out offset))
                    {
                        // Found the location node in child's subtree
                        // Add the offset of child node within its parent to offset
                        // and continue walking up the stack
                        offset += child.GetLeadingTriviaWidth() + currentOffset;
                        return true;
                    }

                    // We didn't find the location node in the subtree rooted at child
                    // Move on to the next child
                    currentOffset += child.FullWidth;
                }
            }

            // We didn't find the location node within the subtree rooted at root node
            return false;
        }

        protected InternalSyntaxToken ConvertToKeyword(InternalSyntaxToken token)
        {
            if (token.GetKind() != token.ContextualKind)
            {
                var kw = token.IsMissing
                        ? Language.InternalSyntaxFactory.MissingToken(token.LeadingTrivia.Node, token.ContextualKind, token.TrailingTrivia.Node)
                        : Language.InternalSyntaxFactory.Token(token.LeadingTrivia.Node, token.ContextualKind, token.TrailingTrivia.Node);
                var d = token.GetDiagnostics();
                if (d != null && d.Length > 0)
                {
                    kw = kw.WithDiagnosticsGreen(d);
                }

                return kw;
            }

            return token;
        }

        /// <summary>
        /// Whenever parsing in a <c>while (true)</c> loop and a bug could prevent the loop from making progress,
        /// this method can prevent the parsing from hanging.
        /// Use as:
        ///     int tokenProgress = -1;
        ///     while (IsMakingProgress(ref tokenProgress))
        /// It should be used as a guardrail, not as a crutch, so it asserts if no progress was made.
        /// </summary>
        protected bool IsMakingProgress(ref int lastTokenIndex)
        {
            var index = TokenIndex;
            if (index > lastTokenIndex)
            {
                lastTokenIndex = index;
                return true;
            }

            Debug.Assert(false);
            return false;
        }

        public virtual void Dispose()
        {
        }
    }
}
