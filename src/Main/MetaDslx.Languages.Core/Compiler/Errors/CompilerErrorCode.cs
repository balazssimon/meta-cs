// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;

namespace MetaDslx.Languages.Compiler
{
    public partial class CompilerErrorCode : ErrorCode
    {
        public new const string Category = "Compiler";
        public new const string MessagePrefix = "C";

        private static readonly ErrorCodeMessageProvider s_messages = new ErrorCodeMessageProvider(MessagePrefix, typeof(CompilerErrorCode));

        public static readonly CompilerErrorCode ERR_GeneralError = new CompilerErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly CompilerErrorCode WRN_GeneralWarning = new CompilerErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly CompilerErrorCode INF_GeneralInfo = new CompilerErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly CompilerErrorCode ERR_BadLanguageVersion = new CompilerErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad Compiler language version: {0}");
        public static readonly CompilerErrorCode ERR_FeatureNotAvailableInVersion1 = new CompilerErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in Compiler version 1: {0}");

        private CompilerErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(s_messages, code, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

