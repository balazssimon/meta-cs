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
        public const string MetaGeneratorLanguageGeneratorServiceGuid = "46F65E7B-4C31-43B1-B69C-E4FE342075DF";
        public const string MetaGeneratorLanguageServiceGuid = "AA7BBD61-A873-4DE6-8CDC-7D7B7A5B23AE";
        public const string LanguageName = "MetaDslx Generator";
        public const string LanguageServiceName = "MetaDslx Generator Language Service";
        public const string FilterList = "MetaDslx Generator Files (*.mgen)\n*.mgen";
        public const string FileExtension = ".mgen";

        public MetaGeneratorLanguageConfig()
        {
            //CreateColor("Unknown", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Text", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Keyword", TokenType.Keyword, COLORINDEX.CI_BLUE, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Identifier", TokenType.Identifier, COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("String", TokenType.String, COLORINDEX.CI_MAROON, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Literal", TokenType.Literal, COLORINDEX.CI_MAGENTA, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Operator", TokenType.Operator, COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Delimiter", TokenType.Delimiter, COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("WhiteSpace", TokenType.WhiteSpace, COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("LineComment", TokenType.LineComment, COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Comment", TokenType.Comment, COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("DocComment", TokenType.Comment, COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Number", TokenType.Literal, COLORINDEX.CI_MAGENTA, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("MetaGenerator template output", TokenType.Text, COLORINDEX.CI_DARKGRAY, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("MetaGenerator template control", TokenType.Text, COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK);
        }
    }

}
