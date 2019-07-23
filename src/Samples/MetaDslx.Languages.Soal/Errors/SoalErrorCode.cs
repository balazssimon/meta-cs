// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace MetaDslx.Languages.Soal
{
    public class SoalErrorCode : ErrorCode
    {
        public new const string Category = "Soal";
        public new const string MessagePrefix = "S";

        public static readonly SoalErrorCode ERR_GeneralError = new SoalErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly SoalErrorCode WRN_GeneralWarning = new SoalErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly SoalErrorCode INF_GeneralInfo = new SoalErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly SoalErrorCode ERR_BadLanguageVersion = new SoalErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad Soal language version: {0}");
        public static readonly SoalErrorCode ERR_FeatureNotAvailableInVersion1 = new SoalErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in Soal version 1: {0}");

        private SoalErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

