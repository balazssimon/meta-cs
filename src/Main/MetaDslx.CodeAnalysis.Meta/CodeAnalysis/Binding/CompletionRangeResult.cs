using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class CompletionRangeResult
    {
        private readonly TextSpan _textSpan;
        private readonly ImmutableArray<CompletionItem> _items;

        public CompletionRangeResult(TextSpan textSpan, ImmutableArray<CompletionItem> items)
        {
            _textSpan = textSpan;
            _items = items;
        }

        public TextSpan TextSpan => _textSpan;

        public ImmutableArray<CompletionItem> Items => _items;
    }
}
