using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.MetaModel
{
    public sealed class MetaModelLanguage : Language
    {
        public static readonly MetaModelLanguage Instance = new MetaModelLanguage();

        public override string Name => throw new NotImplementedException();

        public override SyntaxFacts SyntaxFacts => throw new NotImplementedException();
    }
}
