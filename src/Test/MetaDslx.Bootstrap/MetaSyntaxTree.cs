using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.Bootstrap
{
    public class MetaSyntaxTree : LanguageSyntaxTree
    {
        public override Language Language => throw new NotImplementedException();

        public override string FilePath => throw new NotImplementedException();

        public override bool HasCompilationUnitRoot => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        public override Encoding Encoding => throw new NotImplementedException();

        protected override ParseOptions OptionsCore => throw new NotImplementedException();

        public override SyntaxReference GetReference(SyntaxNode node)
        {
            throw new NotImplementedException();
        }

        public override SourceText GetText(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetText(out SourceText text)
        {
            throw new NotImplementedException();
        }

        public override SyntaxTree WithChangedText(SourceText newText)
        {
            throw new NotImplementedException();
        }

        public override SyntaxTree WithFilePath(string path)
        {
            throw new NotImplementedException();
        }

        public override SyntaxTree WithRootAndOptions(SyntaxNode root, ParseOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
