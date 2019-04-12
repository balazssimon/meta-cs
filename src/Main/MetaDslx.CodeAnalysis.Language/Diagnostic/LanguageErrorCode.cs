using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis
{
    public class LanguageErrorCode : ErrorCode
    {
        public const string ModelCategory = "MetaDslx.CodeAnalysis.Language";
        public const string Prefix = "ML";

        public LanguageErrorCode(int code, string title, string messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }

        public LanguageErrorCode(int code, LocalizableString title, LocalizableString messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault, LocalizableString description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }

        public static readonly LanguageErrorCode ERR_BadLanguageVersion = new LanguageErrorCode(1, "Bad language version", "Invalid language version: {0}", DiagnosticSeverity.Error);
        public static readonly LanguageErrorCode ERR_InvalidPreprocessingSymbol = new LanguageErrorCode(1, "Invalid preprocessing symbol", "Invalid preprocessing symbol: {0}", DiagnosticSeverity.Error);

    }
}
