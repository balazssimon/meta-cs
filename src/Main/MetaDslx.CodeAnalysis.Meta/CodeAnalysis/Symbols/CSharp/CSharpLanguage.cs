using Microsoft.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpLanguage : Language
    {
        public static readonly CSharpLanguage Instance = new CSharpLanguage();

        private CSharpLanguage()
        {
        }

        public override string Name => "C#";

        protected override LanguageServices CreateLanguageServices()
        {
            return new CSharpLanguageServices();
        }
    }

}
