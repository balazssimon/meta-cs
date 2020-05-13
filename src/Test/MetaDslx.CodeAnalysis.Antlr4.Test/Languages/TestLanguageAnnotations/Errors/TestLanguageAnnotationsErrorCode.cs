// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations
{
    public class TestLanguageAnnotationsErrorCode : ErrorCode
    {
        public new const string Category = "TestLanguageAnnotations";
        public new const string MessagePrefix = "TLA";

        public static readonly TestLanguageAnnotationsErrorCode ERR_GeneralError = new TestLanguageAnnotationsErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly TestLanguageAnnotationsErrorCode WRN_GeneralWarning = new TestLanguageAnnotationsErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly TestLanguageAnnotationsErrorCode INF_GeneralInfo = new TestLanguageAnnotationsErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly TestLanguageAnnotationsErrorCode ERR_BadLanguageVersion = new TestLanguageAnnotationsErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad TestLanguageAnnotations language version: {0}");
        public static readonly TestLanguageAnnotationsErrorCode ERR_FeatureNotAvailableInVersion1 = new TestLanguageAnnotationsErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in TestLanguageAnnotations version 1: {0}");

        private TestLanguageAnnotationsErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

