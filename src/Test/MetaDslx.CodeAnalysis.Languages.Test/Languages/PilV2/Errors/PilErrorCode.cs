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

namespace PilV2
{
    public partial class PilErrorCode : ErrorCode
    {
        public new const string Category = "Pil";
        public new const string MessagePrefix = "P";

        public static readonly PilErrorCode ERR_GeneralError = new PilErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly PilErrorCode WRN_GeneralWarning = new PilErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly PilErrorCode INF_GeneralInfo = new PilErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly PilErrorCode ERR_BadLanguageVersion = new PilErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad Pil language version: {0}");
        public static readonly PilErrorCode ERR_FeatureNotAvailableInVersion1 = new PilErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in Pil version 1: {0}");

        private PilErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

