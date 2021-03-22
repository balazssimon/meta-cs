// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis;

namespace MetaDslx.Languages.MetaCompiler
{
    public partial class MetaCompilerErrorCode : ErrorCode
    {
        public new const string Category = "MetaCompiler";
        public new const string MessagePrefix = "MC";

        public static readonly MetaCompilerErrorCode ERR_GeneralError = new MetaCompilerErrorCode(1, DiagnosticSeverity.Error, "Error", "Error: {0}");
        public static readonly MetaCompilerErrorCode WRN_GeneralWarning = new MetaCompilerErrorCode(2, DiagnosticSeverity.Warning, "Warning", "Warning: {0}");
        public static readonly MetaCompilerErrorCode INF_GeneralInfo = new MetaCompilerErrorCode(3, DiagnosticSeverity.Info, "Info", "Info: {0}");
        public static readonly MetaCompilerErrorCode ERR_BadLanguageVersion = new MetaCompilerErrorCode(4, DiagnosticSeverity.Error, "Bad language version", "Bad MetaCompiler language version: {0}");
        public static readonly MetaCompilerErrorCode ERR_FeatureNotAvailableInVersion1 = new MetaCompilerErrorCode(5, DiagnosticSeverity.Error, "Feature not available", "Feature not available in MetaCompiler version 1: {0}");

        private MetaCompilerErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}

