using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public struct CompletionItem
    {
        private readonly object _value;
        private readonly string _name;

        public CompletionItem(SyntaxKind tokenKind, string name)
        {
            _value = tokenKind;
            _name = name;
        }

        public CompletionItem(Symbol symbol)
        {
            _value = symbol;
            _name = symbol.Name;
        }

        public SyntaxKind? TokenKind => _value as SyntaxKind;

        public Symbol? Symbol => _value as Symbol;

        public string Name => _name;

        public override bool Equals(object obj)
        {
            if (obj is CompletionItem other)
            {
                return _value.Equals(other._value);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
