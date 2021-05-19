using Microsoft.CodeAnalysis;
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

        public AbstractParser(Language language)
        {
            Language = language;
            _errors = new List<SyntaxDiagnosticInfo>();
        }

        internal protected abstract int TokenIndex { get; }
        internal protected abstract int TokenCount { get; }
        protected abstract InternalSyntaxToken CurrentToken { get; }
        protected abstract GreenNode PrevTokenTrailingTrivia { get; }

        protected GreenNode WithCurrentSyntaxErrors(GreenNode green, int offset)
        {
            if (_errors.Count > 0)
            {
                /*var start = position;
                var end = position + width;
                var currentErrors = _errors.Where(err => err.Offset >= start && err.Offset + err.Width <= end).Select(err => err.WithOffset(err.Offset - start)).ToArray();
                if (currentErrors.Length > 0)
                {
                    return WithAdditionalDiagnostics(green, currentErrors);
                }*/
                if (offset > 0)
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
                }
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

        /*protected void AddError(int position, int width, ErrorCode code, params object[] args)
        {
            //Debug.Assert(position <= _position);
            this.AddSyntaxError(MakeError(position, width, code, args));
        }

        protected void AddError(int position, int width, ErrorCode code)
        {
            this.AddSyntaxError(MakeError(position, width, code));
        }

        protected void AddError(int position, int width, ErrorCode code, params object[] args)
        {
            this.AddSyntaxError(MakeError(position, width, code, args));
        }
        */
        /*
        protected void AddErrorToCurrentToken(int position, int width, ErrorCode code)
        {
            this.AddErrorToCurrentToken(MakeError(position, width, code));
        }

        protected void AddErrorToCurrentToken(int position, int width, ErrorCode code, params object[] args)
        {
            this.AddErrorToCurrentToken(MakeError(position, width, code, args));
        }
        
        protected void AddErrorToCurrentToken(ErrorCode code)
        {
            this.AddErrorToCurrentToken(MakeError(CurrentToken, code));
        }
        */

        protected void AddErrorToCurrentToken(ErrorCode code, params object[] args)
        {
            this.AddSyntaxError(MakeError(CurrentToken, code, args));
        }

        /*protected void AddErrorToPreviousTokenEnd(ErrorCode code, params object[] args)
        {
            this.AddSyntaxError(MakeError(_prevTokenTrailingTrivia != null ? -_prevTokenTrailingTrivia.FullWidth : 0, 1, code, args));
        }
        */
        protected void AddSyntaxError(SyntaxDiagnosticInfo error)
        {
            if (error != null)
            {
                if (_errors.Any(err => error.Equals(err) && err.ErrorCode == error.ErrorCode && err.Offset == error.Offset && err.Width == error.Width)) return;
                _errors.Add(error);
            }
        }

        protected TNode AddError<TNode>(TNode node, ErrorCode code) where TNode : GreenNode
        {
            return AddError(node, code, Array.Empty<object>());
        }

        protected TNode AddError<TNode>(TNode node, ErrorCode code, params object[] args) where TNode : GreenNode
        {
            if (!node.IsMissing)
            {
                return WithAdditionalDiagnostics(node, MakeError(node, code, args));
            }

            int offset, width;

            InternalSyntaxToken token = node as InternalSyntaxToken;
            if (token != null && token.ContainsSkippedText)
            {
                // This code exists to clean up an anti-pattern:
                //   1) an undesirable token is parsed,
                //   2) a desirable missing token is created and the parsed token is appended as skipped text,
                //   3) an error is attached to the missing token describing the problem.
                // If this occurs, then this.previousTokenTrailingTrivia is still populated with the trivia 
                // of the undesirable token (now skipped text).  Since the trivia no longer precedes the
                // node to which the error is to be attached, the computed offset will be incorrect.

                offset = token.GetLeadingTriviaWidth(); // Should always be zero, but at least we'll do something sensible if it's not.
                Debug.Assert(offset == 0, "Why are we producing a missing token that has both skipped text and leading trivia?");

                width = 0;
                bool seenSkipped = false;
                foreach (var trivia in token.TrailingTrivia)
                {
                    if (trivia.Kind == SyntaxKind.SkippedTokensTrivia)
                    {
                        seenSkipped = true;
                        width += trivia.Width;
                    }
                    else if (seenSkipped)
                    {
                        break;
                    }
                    else
                    {
                        offset += trivia.Width;
                    }
                }
            }
            else
            {
                this.GetDiagnosticSpanForMissingToken(out offset, out width);
            }

            return WithAdditionalDiagnostics(node, MakeError(offset, width, code, args));
        }

        protected TNode AddError<TNode>(TNode node, int offset, int length, ErrorCode code, params object[] args) where TNode : InternalSyntaxNode
        {
            return WithAdditionalDiagnostics(node, MakeError(offset, length, code, args));
        }

        protected TNode AddError<TNode>(TNode node, InternalSyntaxNode location, ErrorCode code, params object[] args) where TNode : InternalSyntaxNode
        {
            // assumes non-terminals will at most appear once in sub-tree
            int offset;
            FindOffset(node, location, out offset);
            return WithAdditionalDiagnostics(node, MakeError(offset, location.Width, code, args));
        }

        protected TNode AddErrorToFirstToken<TNode>(TNode node, ErrorCode code) where TNode : InternalSyntaxNode
        {
            var firstToken = node.GetFirstToken();
            return WithAdditionalDiagnostics(node, MakeError(firstToken.GetLeadingTriviaWidth(), firstToken.Width, code));
        }

        protected TNode AddErrorToFirstToken<TNode>(TNode node, ErrorCode code, params object[] args) where TNode : InternalSyntaxNode
        {
            var firstToken = node.GetFirstToken();
            return WithAdditionalDiagnostics(node, MakeError(firstToken.GetLeadingTriviaWidth(), firstToken.Width, code, args));
        }

        protected TNode AddErrorToLastToken<TNode>(TNode node, ErrorCode code) where TNode : InternalSyntaxNode
        {
            int offset;
            int width;
            GetOffsetAndWidthForLastToken(node, out offset, out width);
            return WithAdditionalDiagnostics(node, MakeError(offset, width, code));
        }

        protected TNode AddErrorToLastToken<TNode>(TNode node, ErrorCode code, params object[] args) where TNode : InternalSyntaxNode
        {
            int offset;
            int width;
            GetOffsetAndWidthForLastToken(node, out offset, out width);
            return WithAdditionalDiagnostics(node, MakeError(offset, width, code, args));
        }

        private static void GetOffsetAndWidthForLastToken<TNode>(TNode node, out int offset, out int width) where TNode : InternalSyntaxNode
        {
            var lastToken = node.GetLastNonmissingToken();
            offset = node.FullWidth; //advance to end of entire node
            width = 0;
            if (lastToken != null) //will be null if all tokens are missing
            {
                offset -= lastToken.FullWidth; //rewind past last token
                offset += lastToken.GetLeadingTriviaWidth(); //advance past last token leading trivia - now at start of last token
                width += lastToken.Width;
            }
        }

        protected static SyntaxDiagnosticInfo MakeError(int offset, int width, ErrorCode code)
        {
            return new SyntaxDiagnosticInfo(offset, width, code);
        }

        protected static SyntaxDiagnosticInfo MakeError(int offset, int width, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(offset, width, code, args);
        }

        protected static SyntaxDiagnosticInfo MakeError(GreenNode node, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(node.GetLeadingTriviaWidth(), node.Width, code, args);
        }

        protected static SyntaxDiagnosticInfo MakeError(ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(code, args);
        }

        protected TNode AddLeadingSkippedSyntax<TNode>(TNode node, GreenNode skippedSyntax) where TNode : InternalSyntaxNode
        {
            var oldToken = node as InternalSyntaxToken ?? node.GetFirstToken();
            var newToken = AddSkippedSyntax(oldToken, skippedSyntax, trailing: false);
            return SyntaxFirstTokenReplacer.Replace(node, oldToken, newToken, skippedSyntax.FullWidth);
        }

        protected void AddTrailingSkippedSyntax(SyntaxListBuilder list, GreenNode skippedSyntax)
        {
            list[list.Count - 1] = AddTrailingSkippedSyntax((InternalSyntaxNode)list[list.Count - 1], skippedSyntax);
        }

        protected void AddTrailingSkippedSyntax<TNode>(SyntaxListBuilder<TNode> list, GreenNode skippedSyntax) where TNode : InternalSyntaxNode
        {
            list[list.Count - 1] = AddTrailingSkippedSyntax(list[list.Count - 1], skippedSyntax);
        }

        protected TNode AddTrailingSkippedSyntax<TNode>(TNode node, GreenNode skippedSyntax) where TNode : InternalSyntaxNode
        {
            var token = node as InternalSyntaxToken;
            if (token != null)
            {
                return (TNode)(object)AddSkippedSyntax(token, skippedSyntax, trailing: true);
            }
            else
            {
                var lastToken = node.GetLastToken();
                var newToken = AddSkippedSyntax(lastToken, skippedSyntax, trailing: true);
                return SyntaxLastTokenReplacer.Replace(node, newToken);
            }
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
