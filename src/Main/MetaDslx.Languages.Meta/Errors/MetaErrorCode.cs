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

namespace MetaDslx.Languages.Meta
{
    public partial class MetaErrorCode : ErrorCode
    {
        public new const string Category = "Meta";
        public new const string MessagePrefix = "M";

        private static readonly ErrorCodeMessageProvider s_messages = new ErrorCodeMessageProvider(MessagePrefix, typeof(MetaErrorCode));

        public static readonly MetaErrorCode ERR_GeneralError = new MetaErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly MetaErrorCode WRN_GeneralWarning = new MetaErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly MetaErrorCode INF_GeneralInfo = new MetaErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly MetaErrorCode ERR_BadLanguageVersion = new MetaErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad Meta language version: {0}");
        public static readonly MetaErrorCode ERR_FeatureNotAvailableInVersion1 = new MetaErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in Meta version 1: {0}");

        private MetaErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(s_messages, code, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

