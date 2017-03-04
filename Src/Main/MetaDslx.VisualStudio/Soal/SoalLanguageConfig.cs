using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Soal.VisualStudio
{
    public class SoalLanguageConfig : SoalLanguageConfigBase
    {
        public const string SoalGeneratorServiceGuid = "0A244D53-B4B7-4438-AE87-E6CFD08202A7";
        public const string SoalLanguageServiceGuid = "B248ACFD-3553-49A6-A8A8-7B8834DD0FF6";
        public const string GeneratorName = "SoalGenerator";
        public const string LanguageName = "SOAL";
        public const string GeneratorServiceName = "Code Generator for SOAL";
        public const string LanguageServiceName = "SOAL Language Service";
        public const string FilterList = "SOAL Files (*.soal)\n*.soal";
        public const string FileExtension = ".soal";

        public SoalLanguageConfig()
        {
            CreateColor("None", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Comment", TokenType.Comment, COLORINDEX.CI_DARKGREEN);
            CreateColor("Identifier", TokenType.Identifier, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Keyword", TokenType.Keyword, COLORINDEX.CI_BLUE);
            CreateColor("Number", TokenType.Literal, COLORINDEX.CI_MAGENTA);
            CreateColor("String", TokenType.String, COLORINDEX.CI_MAROON);
            CreateColor("Whitespace", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG);
            CreateColor("Text", TokenType.Text, COLORINDEX.CI_SYSPLAINTEXT_FG);
        }
    }
}
