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

namespace MetaDslx.Languages.Core
{
    public partial class CoreErrorCode : ErrorCode
    {
        public new const string Category = "Core";
        public new const string MessagePrefix = "C";

        private static readonly ErrorCodeMessageProvider s_messages = new ErrorCodeMessageProvider(MessagePrefix, typeof(CoreErrorCode));

        public static readonly CoreErrorCode ERR_GeneralError = new CoreErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly CoreErrorCode WRN_GeneralWarning = new CoreErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly CoreErrorCode INF_GeneralInfo = new CoreErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly CoreErrorCode ERR_BadLanguageVersion = new CoreErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad Core language version: {0}");
        public static readonly CoreErrorCode ERR_FeatureNotAvailableInVersion1 = new CoreErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in Core version 1: {0}");

        private CoreErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(s_messages, code, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

