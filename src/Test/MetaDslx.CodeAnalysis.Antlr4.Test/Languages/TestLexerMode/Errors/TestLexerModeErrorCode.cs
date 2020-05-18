// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode
{
    public class TestLexerModeErrorCode : ErrorCode
    {
        public new const string Category = "TestLexerMode";
        public new const string MessagePrefix = "TLM";

        public static readonly TestLexerModeErrorCode ERR_GeneralError = new TestLexerModeErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly TestLexerModeErrorCode WRN_GeneralWarning = new TestLexerModeErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly TestLexerModeErrorCode INF_GeneralInfo = new TestLexerModeErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly TestLexerModeErrorCode ERR_BadLanguageVersion = new TestLexerModeErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad TestLexerMode language version: {0}");
        public static readonly TestLexerModeErrorCode ERR_FeatureNotAvailableInVersion1 = new TestLexerModeErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in TestLexerMode version 1: {0}");

        private TestLexerModeErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

