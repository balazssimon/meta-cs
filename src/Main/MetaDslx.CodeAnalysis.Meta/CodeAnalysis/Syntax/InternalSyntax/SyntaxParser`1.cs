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
        protected SyntaxParser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode? oldTree, ParseData? oldParseData, IEnumerable<TextChangeRange>? changes, CancellationToken cancellationToken = default) 
            : base(language, text, options, oldTree, oldParseData, changes, cancellationToken)
        {
        }

        public new T GetCurrentCustomToken() => (T)base.GetCurrentCustomToken();

        protected new T PeekCustomToken(int n)
        {
            return (T)base.PeekCustomToken(n);
        }

        internal protected override object CreateCustomTokenCore(InternalSyntaxToken token, int position)
        {
            return this.CreateCustomToken(token, position);
        }

        protected abstract T CreateCustomToken(InternalSyntaxToken token, int position);
    }
}
