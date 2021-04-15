using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class SyntaxParser<T> : SyntaxParser
    {
        protected SyntaxParser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default) 
            : base(language, text, options, oldTree, changes, cancellationToken)
        {
        }

        public new T GetCurrentCustomToken() => (T)base.GetCurrentCustomToken();

        protected new T PeekCustomToken(int n)
        {
            return (T)base.PeekCustomToken(n);
        }

        internal protected override object CreateCustomTokenCore(InternalSyntaxToken token)
        {
            return this.CreateCustomToken(token);
        }

        protected abstract T CreateCustomToken(InternalSyntaxToken token);
    }
}
