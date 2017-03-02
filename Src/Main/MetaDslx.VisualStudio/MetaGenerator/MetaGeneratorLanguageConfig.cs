using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class MetaGeneratorLanguageConfig : MetaGeneratorLanguageConfigBase
    {
        public const string MetaGeneratorGeneratorServiceGuid = "46F65E7B-4C31-43B1-B69C-E4FE342075DF";
        public const string MetaGeneratorLanguageServiceGuid = "AA7BBD61-A873-4DE6-8CDC-7D7B7A5B23AE";
        public const string GeneratorName = "MetaGenerator";
        public const string LanguageName = "MetaDslx Generator";
        public const string GeneratorServiceName = "C# Code Generator for MetaDslx Generator";
        public const string LanguageServiceName = "MetaDslx Generator Language Service";
        public const string FilterList = "MetaDslx Generator Files (*.mgen)\n*.mgen";
        public const string FileExtension = ".mgen";

        public MetaGeneratorLanguageConfig()
        {
            CreateColor("None", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Comment", TokenType.Comment, COLORINDEX.CI_DARKGREEN);
            CreateColor("Identifier", TokenType.Identifier, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Keyword", TokenType.Keyword, COLORINDEX.CI_BLUE);
            CreateColor("Number", TokenType.Literal, COLORINDEX.CI_MAGENTA);
            CreateColor("Operator", TokenType.Operator, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("String", TokenType.String, COLORINDEX.CI_MAROON);
            CreateColor("MetaGenerator template control", TokenType.Text, COLORINDEX.CI_DARKGREEN);
            CreateColor("MetaGenerator template output", TokenType.Text, COLORINDEX.CI_DARKGRAY);
        }
    }

}
