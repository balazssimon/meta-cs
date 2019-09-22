// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace WebSequenceDiagramsModel
{
    public class SequenceErrorCode : ErrorCode
    {
        public new const string Category = "Sequence";
        public new const string MessagePrefix = "S";

        public static readonly SequenceErrorCode ERR_GeneralError = new SequenceErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly SequenceErrorCode WRN_GeneralWarning = new SequenceErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly SequenceErrorCode INF_GeneralInfo = new SequenceErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly SequenceErrorCode ERR_BadLanguageVersion = new SequenceErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad Sequence language version: {0}");
        public static readonly SequenceErrorCode ERR_FeatureNotAvailableInVersion1 = new SequenceErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in Sequence version 1: {0}");

        private SequenceErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

