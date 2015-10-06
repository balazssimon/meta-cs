using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class AnnotatedAntlr4LanguageConfig : AnnotatedAntlr4LanguageConfigBase
    {
        public const string AnnotatedAntlr4GeneratorServiceGuid = "604FED65-A175-4908-A8AD-EC3A5AD0B481";
        public const string AnnotatedAntlr4LanguageServiceGuid = "6DF75AF7-1A22-4905-8315-94DB5CEB368A";
        public const string GeneratorName = "AnnotatedAntlr4Generator";
        public const string LanguageName = "Annotated ANTLR4";
        public const string GeneratorServiceName = "C# Code Generator for MetaDslx Annotated Antlr4";
        public const string LanguageServiceName = "Annotated ANTLR4 Language Service";
        public const string FilterList = "Annotated ANTLR4 Files (*.ag4)\n*.ag4";
        public const string FileExtension = ".ag4";

        public AnnotatedAntlr4LanguageConfig()
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
            CreateColor("Annotated ANTLR4 action", TokenType.Text, COLORINDEX.CI_DARKGRAY);
            CreateColor("Annotated ANTLR4 options", TokenType.Text, COLORINDEX.CI_DARKGRAY);
            CreateColor("Annotated ANTLR4 token", TokenType.Text, Color.FromArgb(0, 0, 127));
            CreateColor("Annotated ANTLR4 rule", TokenType.Text, Color.FromArgb(64, 64, 255));
            CreateColor("Annotated ANTLR4 annotation", TokenType.Text, COLORINDEX.CI_DARKGRAY);
        }
    }
}
