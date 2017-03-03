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
    public class Antlr4LanguageConfig : Antlr4LanguageConfigBase
    {
        public const string Antlr4GeneratorServiceGuid = "EA3EABA4-7E33-422F-AE18-BA811A2B659F";
        public const string Antlr4LanguageServiceGuid = "A450060D-3E87-408F-9A45-EA89BD430AFA";
        public const string GeneratorName = "Antlr4Generator";
        public const string LanguageName = "ANTLR4";
        public const string GeneratorServiceName = "ANTLR4";
        public const string LanguageServiceName = "ANTLR4 Language Service";
        public const string FilterList = "ANTLR4 Files (*.g4)\n*.g4";
        public const string FileExtension = ".g4";

        public Antlr4LanguageConfig()
        {
            CreateColor("None", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("ANTLR4 action", TokenType.Text, COLORINDEX.CI_DARKGRAY);
            CreateColor("ANTLR4 options", TokenType.Text, COLORINDEX.CI_DARKGRAY);
            CreateColor("ANTLR4 rule", TokenType.Text, Color.FromArgb(64, 64, 255));
            CreateColor("ANTLR4 token", TokenType.Text, Color.FromArgb(0, 0, 127));
            CreateColor("Comment", TokenType.Comment, COLORINDEX.CI_DARKGREEN);
            CreateColor("DocComment", TokenType.Comment, COLORINDEX.CI_DARKGREEN);
            CreateColor("Identifier", TokenType.Identifier, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Keyword", TokenType.Keyword, COLORINDEX.CI_BLUE);
            CreateColor("Number", TokenType.Literal, COLORINDEX.CI_MAGENTA);
            CreateColor("Operator", TokenType.Operator, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("String", TokenType.String, COLORINDEX.CI_MAROON);
        }
    }
}
