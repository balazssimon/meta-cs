// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne
{
    public class TestLangOneErrorCode : ErrorCode
    {
        public new const string Category = "TestLangOne";
        public new const string MessagePrefix = "TLO";

        public static readonly TestLangOneErrorCode ERR_GeneralError = new TestLangOneErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly TestLangOneErrorCode WRN_GeneralWarning = new TestLangOneErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly TestLangOneErrorCode INF_GeneralInfo = new TestLangOneErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly TestLangOneErrorCode ERR_BadLanguageVersion = new TestLangOneErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad TestLangOne language version: {0}");
        public static readonly TestLangOneErrorCode ERR_FeatureNotAvailableInVersion1 = new TestLangOneErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in TestLangOne version 1: {0}");

        private TestLangOneErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

