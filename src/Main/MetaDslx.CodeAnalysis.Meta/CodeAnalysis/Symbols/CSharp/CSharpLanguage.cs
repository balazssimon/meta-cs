using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.Extensions.DependencyInjection;
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
