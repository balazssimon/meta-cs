using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class IncrementalAntlr4Parser : MetaDslx.CodeAnalysis.Syntax.InternalSyntax.IncrementalParser, ITokenStream//, IParseTreeListener
    {
        private readonly IncrementalAntlr4Lexer _lexer;

        public IncrementalAntlr4Parser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default) 
            : base(language, text, options, oldTree, changes, cancellationToken)
        {
            _lexer = (IncrementalAntlr4Lexer)language.InternalSyntaxFactory.CreateLexer(text, options, changes);
        }

        ITokenSource ITokenStream.TokenSource => ((ITokenStream)_lexer).TokenSource;

        int IIntStream.Index => this.TokenOffset;

        int IIntStream.Size => this.TokenCount;

        string IIntStream.SourceName => ((ITokenStream)_lexer).SourceName;

        void IIntStream.Consume()
        {
            this.EatToken();
        }

        IToken ITokenStream.Get(int i)
        {
            throw new NotImplementedException();
        }

        string ITokenStream.GetText(Interval interval)
        {
            throw new NotImplementedException();
        }

        string ITokenStream.GetText()
        {
            throw new NotImplementedException();
        }

        string ITokenStream.GetText(RuleContext ctx)
        {
            throw new NotImplementedException();
        }

        string ITokenStream.GetText(IToken start, IToken stop)
        {
            throw new NotImplementedException();
        }

        int IIntStream.La(int i)
        {
            throw new NotImplementedException();
        }

        IToken ITokenStream.Lt(int k)
        {
            throw new NotImplementedException();
        }

        int IIntStream.Mark()
        {
            throw new NotImplementedException();
        }

        void IIntStream.Release(int marker)
        {
            throw new NotImplementedException();
        }

        void IIntStream.Seek(int index)
        {
            throw new NotImplementedException();
        }
    }
}
