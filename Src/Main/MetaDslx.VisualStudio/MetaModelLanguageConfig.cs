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
        public const string MetaModelLanguageGeneratorServiceGuid = "8A0D4F37-718F-4361-AB2A-8E340236932F";
        public const string MetaModelLanguageServiceGuid = "A70928D1-FD5C-4B59-9363-EB539618BF59";
        public const string LanguageName = "MetaDslx MetaModel";
        public const string LanguageServiceName = "MetaDslx MetaModel Language Service";
        public const string FilterList = "MetaDslx MetaModel Files (*.mm)\n*.mm";
        public const string FileExtension = ".mm";

        public MetaModelLanguageConfig()
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
        }
    }
}
