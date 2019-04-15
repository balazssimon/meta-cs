using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax
{
    public class MetaModelSyntaxFacts : SyntaxFacts
    {
        public override string GetKindText(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override string GetText(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsAnyToken(int rawKind)
        {
            throw new NotImplementedException();
        }

        public bool IsAnyToken(SyntaxKind kind)
        {
            return this.IsAnyToken((int)kind);
        }

        public override bool IsDocumentationCommentTrivia(int rawKind)
        {
            throw new NotImplementedException();
        }

        public bool IsIdentifier(SyntaxKind kind)
        {
            return this.IsIdentifier((int)kind);
        }

        public override bool IsIdentifier(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsTriviaWithEndOfLine(int rawKind)
        {
            throw new NotImplementedException();
        }
    }
}
