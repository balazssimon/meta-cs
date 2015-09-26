using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class AnnotatedAntlr4LanguageConfig : AnnotatedAntlr4LanguageConfigBase
    {
        public const string AnnotatedAntlr4LanguageGeneratorServiceGuid = "604FED65-A175-4908-A8AD-EC3A5AD0B481";
        public const string AnnotatedAntlr4LanguageServiceGuid = "6DF75AF7-1A22-4905-8315-94DB5CEB368A";
        public const string LanguageName = "Annotated ANTLR4";
        public const string LanguageServiceName = "Annotated ANTLR4 Language Service";
        public const string FilterList = "Annotated ANTLR4 Files (*.ag4)\n*.ag4";
        public const string FileExtension = ".ag4";

        public AnnotatedAntlr4LanguageConfig()
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
            CreateColor("Actions", COLORINDEX.CI_LIGHTGRAY, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Options", COLORINDEX.CI_LIGHTGRAY, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Tokens", COLORINDEX.CI_GREEN, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Annotation", COLORINDEX.CI_LIGHTGRAY, COLORINDEX.CI_USERTEXT_BK);
        }
    }
}
