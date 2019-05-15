using Microsoft.CodeAnalysis;
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
        public static InternalErrorCode ERR_VariableUsedBeforeDeclaration { get; internal set; }
        public static InternalErrorCode ERR_SourceFileReferencesNotSupported { get; internal set; }
        public static InternalErrorCode ERR_NoSourceFile { get; internal set; }
        public static InternalErrorCode ERR_FileReadError { get; internal set; }
        public static InternalErrorCode ERR_DebugEntryPointNotSourceMethodDefinition { get; internal set; }
        public static InternalErrorCode ERR_MainClassNotFound { get; internal set; }
        public static InternalErrorCode ERR_MainClassNotClass { get; internal set; }
        public static InternalErrorCode WRN_MainIgnored { get; internal set; }
        public static InternalErrorCode WRN_InvalidMainSig { get; internal set; }
        public static InternalErrorCode WRN_MainCantBeGeneric { get; internal set; }
        public static InternalErrorCode ERR_NonTaskMainCantBeAsync { get; internal set; }
        public static InternalErrorCode ERR_NoEntryPoint { get; internal set; }
        public static InternalErrorCode ERR_NoMainInClass { get; internal set; }
        public static InternalErrorCode ERR_MultipleEntryPoints { get; internal set; }
        public static InternalErrorCode ERR_NoTypeDef { get; internal set; }
        public static InternalErrorCode ERR_GlobalSingleTypeNameNotFound { get; internal set; }
        public static InternalErrorCode HDN_UnusedExternAlias { get; internal set; }
        public static InternalErrorCode HDN_UnusedUsingDirective { get; internal set; }
        public static InternalErrorCode ERR_AssemblySpecifiedForLinkAndRef { get; internal set; }
        public static InternalErrorCode ERR_BadExternAlias { get; internal set; }
        public static InternalErrorCode ERR_PartialModifierConflict { get; internal set; }
        public static InternalErrorCode ERR_AbstractSealedStatic { get; internal set; }
        public static InternalErrorCode ERR_SealedStaticClass { get; internal set; }
        public static InternalErrorCode ERR_DuplicateNameInNS { get; internal set; }
        public static InternalErrorCode ERR_PartialTypeKindConflict { get; internal set; }
        public static InternalErrorCode ERR_DuplicateNameInClass { get; internal set; }
        public static InternalErrorCode ERR_MemberNameSameAsType { get; internal set; }
        public static InternalErrorCode ERR_PartialMethodOnlyOneActual { get; internal set; }
        public static InternalErrorCode ERR_PartialMethodOnlyOneLatent { get; internal set; }
        public static InternalErrorCode ERR_PartialMethodMustHaveLatent { get; internal set; }
        public static InternalErrorCode ERR_NoTypeDefFromModule { get; internal set; }
        public static InternalErrorCode ERR_MissingTypeInSource { get; internal set; }
        public static InternalErrorCode ERR_MissingTypeInAssembly { get; internal set; }
        public static InternalErrorCode ERR_PredefinedTypeNotFound { get; internal set; }
        public static InternalErrorCode WRN_UnifyReferenceBldRev { get; internal set; }
        public static InternalErrorCode WRN_UnifyReferenceMajMin { get; internal set; }
        public static InternalErrorCode ERR_AssemblyMatchBadVersion { get; internal set; }
        public static InternalErrorCode ERR_CycleInTypeForwarder { get; internal set; }
        public static InternalErrorCode ERR_TypeForwardedToMultipleAssemblies { get; internal set; }
        public static InternalErrorCode WRN_MultiplePredefTypes { get; internal set; }
        public static InternalErrorCode ERR_ImportedCircularBase { get; internal set; }
        public static InternalErrorCode ERR_ProtectedInStruct { get; internal set; }
        public static InternalErrorCode WRN_ProtectedInSealed { get; internal set; }
        public static InternalErrorCode ERR_CycleInInterfaceInheritance { get; internal set; }
        public static InternalErrorCode ERR_NetModuleNameMismatch { get; internal set; }
        public static InternalErrorCode ERR_NetModuleNameMustBeUnique { get; internal set; }
        public static InternalErrorCode ERR_MissingNetModuleReference { get; internal set; }
        public static InternalErrorCode ERR_BadSKknown { get; internal set; }
        public static InternalErrorCode ERR_InsufficientStack { get; internal set; }
        public static InternalErrorCode ERR_NoMainOnDLL { get; internal set; }
        public static InternalErrorCode ERR_BadCompilationOptionValue { get; internal set; }
        public static InternalErrorCode ERR_BadPlatformType { get; internal set; }
        public static InternalErrorCode ERR_BadModuleName { get; internal set; }
        public static InternalErrorCode ERR_BadPrefer32OnLib { get; internal set; }
    }
}
