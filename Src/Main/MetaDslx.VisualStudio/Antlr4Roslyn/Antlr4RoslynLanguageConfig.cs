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
    public class Antlr4RoslynLanguageConfig : Antlr4RoslynLanguageConfigBase
    {
        public const string Antlr4RoslynGeneratorServiceGuid = "18628611-B967-4541-A071-80AA1329CAD9";
        public const string Antlr4RoslynLanguageServiceGuid = "4C2BB7CE-569B-4E12-A9EE-20D55B786E7A";
        public const string GeneratorName = "Antlr4RoslynGenerator";
        public const string LanguageName = "Annotated ANTLR4";
        public const string GeneratorServiceName = "Roslyn Compiler Generator for MetaDslx Annotated ANTLR4";
        public const string LanguageServiceName = "Annotated ANTLR4 Language Service";
        public const string FilterList = "Annotated ANTLR4 Files (*.ag4)\n*.ag4";
        public const string FileExtension = ".ag4";

        public Antlr4RoslynLanguageConfig()
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
