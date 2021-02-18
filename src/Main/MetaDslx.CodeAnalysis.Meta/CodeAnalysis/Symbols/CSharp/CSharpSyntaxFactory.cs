using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpSyntaxFactory : SyntaxFactory
    {
        public CSharpSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory) 
            : base(internalSyntaxFactory)
        {
        }

        public override LanguageParseOptions DefaultParseOptions => throw new NotImplementedException();

        protected override Language LanguageCore => CSharpLanguage.Instance;

        public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
        {
            throw new NotImplementedException();
        }

        protected override LanguageSyntaxTree ParseSyntaxTreeCore(SourceText text, ParseOptions options = null, string path = "", CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
