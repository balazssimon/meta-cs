// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation
{
    public partial class TestIncrementalCompilationErrorCode : ErrorCode
    {
        public new const string Category = "TestIncrementalCompilation";
        public new const string MessagePrefix = "TIC";

        public static readonly TestIncrementalCompilationErrorCode ERR_GeneralError = new TestIncrementalCompilationErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly TestIncrementalCompilationErrorCode WRN_GeneralWarning = new TestIncrementalCompilationErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly TestIncrementalCompilationErrorCode INF_GeneralInfo = new TestIncrementalCompilationErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly TestIncrementalCompilationErrorCode ERR_BadLanguageVersion = new TestIncrementalCompilationErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad TestIncrementalCompilation language version: {0}");
        public static readonly TestIncrementalCompilationErrorCode ERR_FeatureNotAvailableInVersion1 = new TestIncrementalCompilationErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in TestIncrementalCompilation version 1: {0}");

        private TestIncrementalCompilationErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

