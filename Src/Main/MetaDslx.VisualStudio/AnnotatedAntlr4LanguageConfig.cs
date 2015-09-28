using Microsoft.VisualStudio.Package;
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
            CreateColor("Annotated ANTLR4 action", TokenType.Text, COLORINDEX.CI_DARKGRAY, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Annotated ANTLR4 options", TokenType.Text, COLORINDEX.CI_DARKGRAY, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Annotated ANTLR4 tokens", TokenType.Text, COLORINDEX.CI_GREEN, COLORINDEX.CI_USERTEXT_BK);
            CreateColor("Annotated ANTLR4 annotation", TokenType.Text, COLORINDEX.CI_DARKGRAY, COLORINDEX.CI_USERTEXT_BK);
        }
    }
}
