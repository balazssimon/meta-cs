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
            //CreateColor("Unknown", COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Text", COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Keyword", COLORINDEX.CI_BLUE, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Identifier", COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("String", COLORINDEX.CI_MAROON, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Literal", COLORINDEX.CI_MAGENTA, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Operator", COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Delimiter", COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("WhiteSpace", COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("LineComment", COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Comment", COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("DocComment", COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Number", COLORINDEX.CI_MAGENTA, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("TemplateOutput", COLORINDEX.CI_LIGHTGRAY, COLORINDEX.CI_USERTEXT_BK);
        }
    }
}
