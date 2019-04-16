using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp
{
    public sealed class CSharpErrorCode : ErrorCode
    {
        private static ImmutableDictionary<int, CSharpErrorCode> s_errorCodeToDescriptorMap = ImmutableDictionary<int, CSharpErrorCode>.Empty;

        public const string ModelCategory = "MetaDslx.CodeAnalysis.CSharp";
        public const string Prefix = "MM";

        private CSharpErrorCode(int code, string title, string messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            CSharpErrorCode old = ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
            Debug.Assert(old == null);
        }

        private CSharpErrorCode(int code, LocalizableString title, LocalizableString messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault, LocalizableString description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            CSharpErrorCode old = ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
            Debug.Assert(old == null);
        }

        static CSharpErrorCode()
        {
            ObjectBinder.RegisterTypeReader(typeof(CSharpErrorCode), r => ResolveErrorCode(r));
        }

        private static CSharpErrorCode ResolveErrorCode(ObjectReader reader)
        {
            int errorCode = reader.ReadInt32();
            s_errorCodeToDescriptorMap.TryGetValue(errorCode, out CSharpErrorCode result);
            return result ?? ERR_InvalidErrorCode;
        }

        public static readonly CSharpErrorCode ERR_InvalidErrorCode = new CSharpErrorCode(0, "Invalid error code", "Invalid error code. This should not happen. There is an error in the compiler.", DiagnosticSeverity.Error, false);
        public static readonly CSharpErrorCode ERR_InvalidPreprocessingSymbol = new CSharpErrorCode(1, "Invalid preprocessor symbol", "Invalid preprocessor symbol: {0}", DiagnosticSeverity.Error);
        public static readonly CSharpErrorCode ERR_BindToBogus = new CSharpErrorCode(2, "Symbol not supported", "'{0}' is not supported by the language", DiagnosticSeverity.Error);
        public static readonly CSharpErrorCode ERR_BogusType = new CSharpErrorCode(3, "Type not supported", "'{0}' is a type not supported by the language", DiagnosticSeverity.Error);
        public static readonly CSharpErrorCode ERR_HighestPrioriry = new CSharpErrorCode(int.MaxValue, "", "", DiagnosticSeverity.Error);

        public static readonly CSharpErrorCode ERR_IllegalUnsafe = null;
        internal static readonly CSharpErrorCode ERR_ForwardedTypeConflictsWithDeclaration;
        internal static readonly CSharpErrorCode ERR_PredefinedValueTupleTypeMustBeStruct;

        public static CSharpErrorCode WRN_ReferencedAssemblyDoesNotHaveStrongName { get; internal set; }
        public static CSharpErrorCode WRN_RefCultureMismatch { get; internal set; }
        public static CSharpErrorCode WRN_ConflictingMachineAssembly { get; internal set; }
        public static CSharpErrorCode ERR_ExportedTypeConflictsWithDeclaration { get; internal set; }
        public static CSharpErrorCode ERR_ExportedTypesConflict { get; internal set; }
        public static CSharpErrorCode ERR_ForwardedTypeConflictsWithExportedType { get; internal set; }
        public static CSharpErrorCode ERR_ForwardedTypesConflict { get; internal set; }
        //ERR_CycleInTypeForwarder
        //ERR_TypeForwardedToMultipleAssemblies
    }
}
