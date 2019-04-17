﻿using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    internal sealed class InternalErrorCode : ErrorCode
    {
        private static ImmutableDictionary<int, InternalErrorCode> s_errorCodeToDescriptorMap = ImmutableDictionary<int, InternalErrorCode>.Empty;

        public const string ModelCategory = "MetaDslx.Core";
        public const string Prefix = "MM";

        private InternalErrorCode(int code, string title, string messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            InternalErrorCode old = ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
            Debug.Assert(old == null);
        }

        private InternalErrorCode(int code, LocalizableString title, LocalizableString messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault, LocalizableString description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            InternalErrorCode old = ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
            Debug.Assert(old == null);
        }

        static InternalErrorCode()
        {
            ObjectBinder.RegisterTypeReader(typeof(InternalErrorCode), r => ResolveErrorCode(r));
        }

        private static InternalErrorCode ResolveErrorCode(ObjectReader reader)
        {
            int errorCode = reader.ReadInt32();
            s_errorCodeToDescriptorMap.TryGetValue(errorCode, out InternalErrorCode result);
            return result ?? ERR_InvalidErrorCode;
        }

        public static readonly InternalErrorCode ERR_InvalidErrorCode = new InternalErrorCode(0, "Invalid error code", "Invalid error code. This should not happen. There is an error in the compiler.", DiagnosticSeverity.Error, false);
        public static readonly InternalErrorCode ERR_InvalidPreprocessingSymbol = new InternalErrorCode(1, "Invalid preprocessor symbol", "Invalid preprocessor symbol: {0}", DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BindToBogus = new InternalErrorCode(2, "Symbol not supported", "'{0}' is not supported by the language", DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BogusType = new InternalErrorCode(3, "Type not supported", "'{0}' is a type not supported by the language", DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_HighestPrioriry = new InternalErrorCode(int.MaxValue, "", "", DiagnosticSeverity.Error);
    }
}
