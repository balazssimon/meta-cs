// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace MetaDslx.Languages.Meta
{
    public class MetaErrorCode : ErrorCode
    {
        public new const string Category = "Meta";
        public new const string MessagePrefix = "M";

        public static readonly MetaErrorCode ERR_GeneralError = new MetaErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly MetaErrorCode WRN_GeneralWarning = new MetaErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly MetaErrorCode INF_GeneralInfo = new MetaErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly MetaErrorCode ERR_BadLanguageVersion = new MetaErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad Meta language version: {0}");
        public static readonly MetaErrorCode ERR_FeatureNotAvailableInVersion1 = new MetaErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in Meta version 1: {0}");

        private MetaErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

