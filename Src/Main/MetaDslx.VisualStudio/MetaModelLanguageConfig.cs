using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class MetaModelLanguageConfig : MetaModelLanguageConfigBase
    {
        public const string MetaModelGeneratorServiceGuid = "8A0D4F37-718F-4361-AB2A-8E340236932F";
        public const string MetaModelLanguageServiceGuid = "A70928D1-FD5C-4B59-9363-EB539618BF59";
        public const string GeneratorName = "MetaModelGenerator";
        public const string LanguageName = "MetaDslx MetaModel";
        public const string GeneratorServiceName = "C# Code Generator for MetaDslx Metamodel";
        public const string LanguageServiceName = "MetaDslx MetaModel Language Service";
        public const string FilterList = "MetaDslx MetaModel Files (*.mm)\n*.mm";
        public const string FileExtension = ".mm";

        public MetaModelLanguageConfig()
        {
            //CreateColor("Unknown", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Text", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Keyword", TokenType.Keyword, COLORINDEX.CI_BLUE);
            CreateColor("Identifier", TokenType.Identifier, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("String", TokenType.String, COLORINDEX.CI_MAROON);
            CreateColor("Literal", TokenType.Literal, COLORINDEX.CI_MAGENTA);
            CreateColor("Operator", TokenType.Operator, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Delimiter", TokenType.Delimiter, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("WhiteSpace", TokenType.WhiteSpace, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("LineComment", TokenType.LineComment, COLORINDEX.CI_DARKGREEN);
            CreateColor("Comment", TokenType.Comment, COLORINDEX.CI_DARKGREEN);
            CreateColor("DocComment", TokenType.Comment, COLORINDEX.CI_DARKGREEN);
            CreateColor("Number", TokenType.Literal, COLORINDEX.CI_MAGENTA);
        }
    }
}
