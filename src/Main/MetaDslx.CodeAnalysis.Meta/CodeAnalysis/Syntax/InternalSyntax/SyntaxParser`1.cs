using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class SyntaxParser<T> : SyntaxParser
    {
        private SlidingBuffer<T> _customTokens;

        protected SyntaxParser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default) 
            : base(language, text, options, oldTree, changes, cancellationToken)
        {
            _customTokens = new SlidingBuffer<T>(this, default);
        }

        public T CurrentCustomToken => _customTokens.CurrentItem;

        public override void Dispose()
        {
            var customTokens = _customTokens;
            if (customTokens != null)
            {
                _customTokens = null;
                customTokens.Dispose();
            }
            base.Dispose();
        }

        protected override void SlidingBuffer_Reset()
        {
            _customTokens.Reset();
            base.SlidingBuffer_Reset();
        }

        protected override void SlidingBuffer_ResetTo(int position)
        {
            _customTokens.ResetTo(position);
            base.SlidingBuffer_ResetTo(position);
        }

        protected override bool SlidingBuffer_ReadNewToken()
        {
            if (base.SlidingBuffer_ReadNewToken())
            {
                var token = LastCreatedToken;
                _customTokens.AddItem(CreateCustomToken(token));
                return true;
            }
            return false;
        }

        protected override void SlidingBuffer_EatItem()
        {
            _customTokens.EatItem();
            base.SlidingBuffer_EatItem();
        }

        protected override void SlidingBuffer_ForgetFollowingTokens()
        {
            _customTokens.ForgetFollowingTokens();
            base.SlidingBuffer_ForgetFollowingTokens();
        }

        protected override void SlidingBuffer_InsertNode(in BlendedNode node)
        {
            if (node.Token != null)
            {
                _customTokens.InsertItem(CreateCustomToken(node.Token));
            }
            else if (node.Node != null)
            {
                var lastToken = node.Node.GetLastToken();
                _customTokens.InsertItem(CreateCustomToken((InternalSyntaxToken)lastToken.Node));
            }
            base.SlidingBuffer_InsertNode(node);
        }
        /*
        protected override InternalSyntaxToken SlidingBuffer_InsertItem(InternalSyntaxToken token)
        {
            _customTokens.InsertItem(CreateCustomToken(token));
            return base.SlidingBuffer_InsertItem(token);
        }*/

        protected override void SlidingBuffer_MarkResetPoint()
        {
            _customTokens.MarkResetPoint();
            base.SlidingBuffer_MarkResetPoint();
        }

        protected T PeekCustomToken(int n)
        {
            RegisterLookahead(n);
            return _customTokens.PeekItem(n);
        }

        protected abstract T CreateCustomToken(InternalSyntaxToken token);
    }
}
