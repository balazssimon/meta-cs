using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.MetaModel
{
    public sealed class MetaModelErrorCode : ErrorCode
    {
        private static ImmutableDictionary<int, MetaModelErrorCode> s_errorCodeToDescriptorMap = ImmutableDictionary<int, MetaModelErrorCode>.Empty;

        public const string ModelCategory = "MetaModel";
        public const string Prefix = "MM";

        public MetaModelErrorCode(int code, string title, string messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            MetaModelErrorCode old = ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
            Debug.Assert(old == null);
        }

        public MetaModelErrorCode(int code, LocalizableString title, LocalizableString messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault, LocalizableString description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            MetaModelErrorCode old = ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
            Debug.Assert(old == null);
        }

        static MetaModelErrorCode()
        {
            ObjectBinder.RegisterTypeReader(typeof(MetaModelErrorCode), r => ResolveErrorCode(r));
        }

        private static MetaModelErrorCode ResolveErrorCode(ObjectReader reader)
        {
            int errorCode = reader.ReadInt32();
            s_errorCodeToDescriptorMap.TryGetValue(errorCode, out MetaModelErrorCode result);
            return result ?? ERR_InvalidErrorCode;
        }

        public static readonly MetaModelErrorCode ERR_InvalidErrorCode = new MetaModelErrorCode(0, "Invalid error code", "Invalid error code. This should not happen. There is an error in the compiler.", DiagnosticSeverity.Error, false);
        public static readonly MetaModelErrorCode ERR_BadLanguageVersion = new MetaModelErrorCode(1, "Bad language version", "Invalid language version: {0}.", DiagnosticSeverity.Error);
        public static readonly MetaModelErrorCode ERR_FeatureNotAvailableInVersion1 = new MetaModelErrorCode(2, "Feature not available", "Feature not available in MetaModel language version 1.", DiagnosticSeverity.Error);
    }
}
