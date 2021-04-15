using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    using ErrorFacts = Microsoft.CodeAnalysis.CSharp.ErrorFacts;

    internal sealed class InternalErrorCode : ErrorCode
    {
        private static ErrorCodeMessageProvider s_messageProvider = new ErrorCodeMessageProvider("MM", typeof(InternalErrorCode));

        public const string ModelCategory = "MetaDslx.Core";
        public const string Prefix = "MM";

        private InternalErrorCode(int code, DiagnosticSeverity defaultSeverity, params string[] customTags)
            : base(s_messageProvider, code, GetTitle(code), GetMessageFormat(code), GetCategory(code), defaultSeverity, true, GetDescription(code), GetHelpLink(code), customTags)
        {
            s_messageProvider.Add(this);
        }

        private InternalErrorCode()
            : base(s_messageProvider, 0, "Invalid error code", "Invalid error code. This should not happen. There is an error in the compiler.", ModelCategory, DiagnosticSeverity.Error, true, "Invalid error code. This should not happen. There is an error in the compiler.", null)
        {
            s_messageProvider.Add(this);
        }

        static InternalErrorCode()
        {
            ObjectBinder.RegisterTypeReader(typeof(InternalErrorCode), r => ResolveErrorCode(r));
        }

        private static LocalizableString GetTitle(int code)
        {
            return Microsoft.CodeAnalysis.CSharp.ErrorFacts.GetTitle((Microsoft.CodeAnalysis.CSharp.ErrorCode)code);
        }

        private static LocalizableString GetMessageFormat(int code)
        {
            return Microsoft.CodeAnalysis.CSharp.ErrorFacts.GetMessageFormat((Microsoft.CodeAnalysis.CSharp.ErrorCode)code);
        }

        private static string GetCategory(int code)
        {
            return Microsoft.CodeAnalysis.CSharp.ErrorFacts.GetCategory((Microsoft.CodeAnalysis.CSharp.ErrorCode)code);
        }

        private static LocalizableString GetDescription(int code)
        {
            return Microsoft.CodeAnalysis.CSharp.ErrorFacts.GetDescription((Microsoft.CodeAnalysis.CSharp.ErrorCode)code);
        }

        private static string GetHelpLink(int code)
        {
            return Microsoft.CodeAnalysis.CSharp.ErrorFacts.GetHelpLink((Microsoft.CodeAnalysis.CSharp.ErrorCode)code);
        }

        private static InternalErrorCode ResolveErrorCode(ObjectReader reader)
        {
            int errorCode = reader.ReadInt32();
            var result = (InternalErrorCode)s_messageProvider.GetErrorCode(errorCode);
            return result ?? ERR_InvalidErrorCode;
        }

        public static readonly InternalErrorCode ERR_InvalidErrorCode = new InternalErrorCode();

        /// <summary>
        /// The code has yet to be determined.
        /// </summary>
        public static readonly InternalErrorCode Unknown = new InternalErrorCode(Microsoft.CodeAnalysis.InternalErrorCode.Unknown, (DiagnosticSeverity)Microsoft.CodeAnalysis.InternalErrorCode.Unknown);

        /// <summary>
        /// The error info is empty.
        /// </summary>
        public static readonly InternalErrorCode EmptyError = new InternalErrorCode(0, DiagnosticSeverity.Error);

        /// <summary>
        /// The code was lazily determined and does not need to be reported.
        /// </summary>
        public static readonly InternalErrorCode Void = new InternalErrorCode(Microsoft.CodeAnalysis.InternalErrorCode.Void, (DiagnosticSeverity)Microsoft.CodeAnalysis.InternalErrorCode.Void);

        public static readonly InternalErrorCode ERR_InternalError = new InternalErrorCode(-9999, (DiagnosticSeverity)(-9999));
        
        #region diagnostics introduced in C# 4 and earlier
        //public static readonly InternalErrorCode FTL_InternalError = new InternalErrorCode(1, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_FailedToLoadResource = new InternalErrorCode(2, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_NoMemory = new InternalErrorCode(3, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_WarningAsError = new InternalErrorCode(4, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_MissingOptionArg = new InternalErrorCode(5, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoMetadataFile = new InternalErrorCode(6, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_ComPlusInit = new InternalErrorCode(7, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_MetadataImportFailure = new InternalErrorCode(8, DiagnosticSeverity.Error);    no longer used in Roslyn.
        public static readonly InternalErrorCode FTL_MetadataCantOpenFile = new InternalErrorCode(9, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_FatalError = new InternalErrorCode(10, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_CantImportBase = new InternalErrorCode(11, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoTypeDef = new InternalErrorCode(12, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_MetadataEmitFailure = new InternalErrorCode(13, DiagnosticSeverity.Error);     Roslyn does not catch stream writing exceptions. Those are propagated to the caller.
        //public static readonly InternalErrorCode FTL_RequiredFileNotFound = new InternalErrorCode(14, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ClassNameTooLong = new InternalErrorCode(15, DiagnosticSeverity.Error);    Deprecated in favor of ERR_MetadataNameTooLong.
        public static readonly InternalErrorCode ERR_OutputWriteFailed = new InternalErrorCode(16, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MultipleEntryPoints = new InternalErrorCode(17, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_UnimplementedOp = new InternalErrorCode(18, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadBinaryOps = new InternalErrorCode(19, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IntDivByZero = new InternalErrorCode(20, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadIndexLHS = new InternalErrorCode(21, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadIndexCount = new InternalErrorCode(22, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadUnaryOp = new InternalErrorCode(23, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoStdLib = new InternalErrorCode(25, DiagnosticSeverity.Error);        not used in Roslyn
        public static readonly InternalErrorCode ERR_ThisInStaticMeth = new InternalErrorCode(26, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ThisInBadContext = new InternalErrorCode(27, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_InvalidMainSig = new InternalErrorCode(28, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_NoImplicitConv = new InternalErrorCode(29, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_NoExplicitConv = new InternalErrorCode(30, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_ConstOutOfRange = new InternalErrorCode(31, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigBinaryOps = new InternalErrorCode(34, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigUnaryOp = new InternalErrorCode(35, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InAttrOnOutParam = new InternalErrorCode(36, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ValueCantBeNull = new InternalErrorCode(37, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_WrongNestedThis = new InternalErrorCode(38, DiagnosticSeverity.Error);     No longer given in Roslyn. Less specific ERR_ObjectRequired "An object reference is required for the non-static..."
        public static readonly InternalErrorCode ERR_NoExplicitBuiltinConv = new InternalErrorCode(39, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
                                                                                                                                  //public static readonly InternalErrorCode FTL_DebugInit = new InternalErrorCode(40, DiagnosticSeverity.Error);           Not used in Roslyn. Roslyn gives FTL_DebugEmitFailure with specific error code info.
        public static readonly InternalErrorCode FTL_DebugEmitFailure = new InternalErrorCode(41, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_DebugInitFile = new InternalErrorCode(42, DiagnosticSeverity.Error);       Not used in Roslyn. Roslyn gives ERR_CantOpenFileWrite with specific error info.
        //public static readonly InternalErrorCode FTL_BadPDBFormat = new InternalErrorCode(43, DiagnosticSeverity.Error);        Not used in Roslyn. Roslyn gives FTL_DebugEmitFailure with specific error code info.
        public static readonly InternalErrorCode ERR_BadVisReturnType = new InternalErrorCode(50, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisParamType = new InternalErrorCode(51, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisFieldType = new InternalErrorCode(52, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisPropertyType = new InternalErrorCode(53, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisIndexerReturn = new InternalErrorCode(54, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisIndexerParam = new InternalErrorCode(55, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisOpReturn = new InternalErrorCode(56, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisOpParam = new InternalErrorCode(57, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisDelegateReturn = new InternalErrorCode(58, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisDelegateParam = new InternalErrorCode(59, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisBaseClass = new InternalErrorCode(60, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisBaseInterface = new InternalErrorCode(61, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EventNeedsBothAccessors = new InternalErrorCode(65, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EventNotDelegate = new InternalErrorCode(66, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnreferencedEvent = new InternalErrorCode(67, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_InterfaceEventInitializer = new InternalErrorCode(68, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_EventPropertyInInterface = new InternalErrorCode(69, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadEventUsage = new InternalErrorCode(70, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitEventFieldImpl = new InternalErrorCode(71, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantOverrideNonEvent = new InternalErrorCode(72, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AddRemoveMustHaveBody = new InternalErrorCode(73, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AbstractEventInitializer = new InternalErrorCode(74, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PossibleBadNegCast = new InternalErrorCode(75, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReservedEnumerator = new InternalErrorCode(76, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AsMustHaveReferenceType = new InternalErrorCode(77, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_LowercaseEllSuffix = new InternalErrorCode(78, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadEventUsageNoField = new InternalErrorCode(79, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConstraintOnlyAllowedOnGenericDecl = new InternalErrorCode(80, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TypeParamMustBeIdentifier = new InternalErrorCode(81, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MemberReserved = new InternalErrorCode(82, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateParamName = new InternalErrorCode(100, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateNameInNS = new InternalErrorCode(101, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateNameInClass = new InternalErrorCode(102, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NameNotInContext = new InternalErrorCode(103, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigContext = new InternalErrorCode(104, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DuplicateUsing = new InternalErrorCode(105, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadMemberFlag = new InternalErrorCode(106, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadMemberProtection = new InternalErrorCode(107, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NewRequired = new InternalErrorCode(108, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NewNotRequired = new InternalErrorCode(109, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CircConstValue = new InternalErrorCode(110, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MemberAlreadyExists = new InternalErrorCode(111, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticNotVirtual = new InternalErrorCode(112, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OverrideNotNew = new InternalErrorCode(113, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NewOrOverrideExpected = new InternalErrorCode(114, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_OverrideNotExpected = new InternalErrorCode(115, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NamespaceUnexpected = new InternalErrorCode(116, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoSuchMember = new InternalErrorCode(117, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadSKknown = new InternalErrorCode(118, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadSKunknown = new InternalErrorCode(119, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ObjectRequired = new InternalErrorCode(120, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigCall = new InternalErrorCode(121, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAccess = new InternalErrorCode(122, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MethDelegateMismatch = new InternalErrorCode(123, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RetObjectRequired = new InternalErrorCode(126, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RetNoObjectRequired = new InternalErrorCode(127, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LocalDuplicate = new InternalErrorCode(128, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssgLvalueExpected = new InternalErrorCode(131, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticConstParam = new InternalErrorCode(132, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NotConstantExpression = new InternalErrorCode(133, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NotNullConstRefField = new InternalErrorCode(134, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_NameIllegallyOverrides = new InternalErrorCode(135, DiagnosticSeverity.Error); // Not used in Roslyn anymore due to 'Single Meaning' relaxation changes
        public static readonly InternalErrorCode ERR_LocalIllegallyOverrides = new InternalErrorCode(136, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadUsingNamespace = new InternalErrorCode(138, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoBreakOrCont = new InternalErrorCode(139, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateLabel = new InternalErrorCode(140, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConstructors = new InternalErrorCode(143, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoNewAbstract = new InternalErrorCode(144, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConstValueRequired = new InternalErrorCode(145, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CircularBase = new InternalErrorCode(146, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDelegateConstructor = new InternalErrorCode(148, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MethodNameExpected = new InternalErrorCode(149, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConstantExpected = new InternalErrorCode(150, DiagnosticSeverity.Error);
        // ERR_V6SwitchGoverningTypeValueExpected shares the same error code (CS0151) with ERR_IntegralTypeValueExpected in Dev10 compiler.
        // However ERR_IntegralTypeValueExpected is currently unused and hence being removed. If we need to generate this error in future
        // we can use error code CS0166. CS0166 was originally reserved for ERR_SwitchFallInto in Dev10, but was never used.
        public static readonly InternalErrorCode ERR_V6SwitchGoverningTypeValueExpected = new InternalErrorCode(151, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateCaseLabel = new InternalErrorCode(152, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidGotoCase = new InternalErrorCode(153, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PropertyLacksGet = new InternalErrorCode(154, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadExceptionType = new InternalErrorCode(155, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadEmptyThrow = new InternalErrorCode(156, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadFinallyLeave = new InternalErrorCode(157, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LabelShadow = new InternalErrorCode(158, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LabelNotFound = new InternalErrorCode(159, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnreachableCatch = new InternalErrorCode(160, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReturnExpected = new InternalErrorCode(161, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnreachableCode = new InternalErrorCode(162, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_SwitchFallThrough = new InternalErrorCode(163, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnreferencedLabel = new InternalErrorCode(164, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_UseDefViolation = new InternalErrorCode(165, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoInvoke = new InternalErrorCode(167, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnreferencedVar = new InternalErrorCode(168, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_UnreferencedField = new InternalErrorCode(169, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_UseDefViolationField = new InternalErrorCode(170, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnassignedThis = new InternalErrorCode(171, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigQM = new InternalErrorCode(172, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidQM = new InternalErrorCode(173, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_NoBaseClass = new InternalErrorCode(174, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BaseIllegal = new InternalErrorCode(175, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ObjectProhibited = new InternalErrorCode(176, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ParamUnassigned = new InternalErrorCode(177, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidArray = new InternalErrorCode(178, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExternHasBody = new InternalErrorCode(179, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AbstractAndExtern = new InternalErrorCode(180, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAttributeParamType = new InternalErrorCode(181, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAttributeArgument = new InternalErrorCode(182, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_IsAlwaysTrue = new InternalErrorCode(183, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_IsAlwaysFalse = new InternalErrorCode(184, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_LockNeedsReference = new InternalErrorCode(185, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NullNotValid = new InternalErrorCode(186, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UseDefViolationThis = new InternalErrorCode(188, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArgsInvalid = new InternalErrorCode(190, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssgReadonly = new InternalErrorCode(191, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReadonly = new InternalErrorCode(192, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PtrExpected = new InternalErrorCode(193, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PtrIndexSingle = new InternalErrorCode(196, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_ByRefNonAgileField = new InternalErrorCode(197, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_AssgReadonlyStatic = new InternalErrorCode(198, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReadonlyStatic = new InternalErrorCode(199, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssgReadonlyProp = new InternalErrorCode(200, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalStatement = new InternalErrorCode(201, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadGetEnumerator = new InternalErrorCode(202, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TooManyLocals = new InternalErrorCode(204, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AbstractBaseCall = new InternalErrorCode(205, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefProperty = new InternalErrorCode(206, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_OldWarning_UnsafeProp = new InternalErrorCode(207, DiagnosticSeverity.Warning);    // This error code is unused.
        public static readonly InternalErrorCode ERR_ManagedAddr = new InternalErrorCode(208, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadFixedInitType = new InternalErrorCode(209, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedMustInit = new InternalErrorCode(210, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidAddrOp = new InternalErrorCode(211, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedNeeded = new InternalErrorCode(212, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedNotNeeded = new InternalErrorCode(213, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnsafeNeeded = new InternalErrorCode(214, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OpTFRetType = new InternalErrorCode(215, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OperatorNeedsMatch = new InternalErrorCode(216, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadBoolOp = new InternalErrorCode(217, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MustHaveOpTF = new InternalErrorCode(218, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnreferencedVarAssg = new InternalErrorCode(219, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CheckedOverflow = new InternalErrorCode(220, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConstOutOfRangeChecked = new InternalErrorCode(221, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVarargs = new InternalErrorCode(224, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ParamsMustBeArray = new InternalErrorCode(225, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalArglist = new InternalErrorCode(226, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalUnsafe = new InternalErrorCode(227, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoAccessibleMember = new InternalErrorCode(228, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigMember = new InternalErrorCode(229, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadForeachDecl = new InternalErrorCode(230, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ParamsLast = new InternalErrorCode(231, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SizeofUnsafe = new InternalErrorCode(233, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DottedTypeNameNotFoundInNS = new InternalErrorCode(234, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FieldInitRefNonstatic = new InternalErrorCode(236, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SealedNonOverride = new InternalErrorCode(238, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantOverrideSealed = new InternalErrorCode(239, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoDefaultArgs = new InternalErrorCode(241, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VoidError = new InternalErrorCode(242, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConditionalOnOverride = new InternalErrorCode(243, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PointerInAsOrIs = new InternalErrorCode(244, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CallingFinalizeDeprecated = new InternalErrorCode(245, DiagnosticSeverity.Error); //Dev10: ERR_CallingFinalizeDepracated
        public static readonly InternalErrorCode ERR_SingleTypeNameNotFound = new InternalErrorCode(246, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NegativeStackAllocSize = new InternalErrorCode(247, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NegativeArraySize = new InternalErrorCode(248, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OverrideFinalizeDeprecated = new InternalErrorCode(249, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CallingBaseFinalizeDeprecated = new InternalErrorCode(250, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NegativeArrayIndex = new InternalErrorCode(251, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_BadRefCompareLeft = new InternalErrorCode(252, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_BadRefCompareRight = new InternalErrorCode(253, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadCastInFixed = new InternalErrorCode(254, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StackallocInCatchFinally = new InternalErrorCode(255, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VarargsLast = new InternalErrorCode(257, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingPartial = new InternalErrorCode(260, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialTypeKindConflict = new InternalErrorCode(261, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialModifierConflict = new InternalErrorCode(262, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMultipleBases = new InternalErrorCode(263, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialWrongTypeParams = new InternalErrorCode(264, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialWrongConstraints = new InternalErrorCode(265, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoImplicitConvCast = new InternalErrorCode(266, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_PartialMisplaced = new InternalErrorCode(267, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ImportedCircularBase = new InternalErrorCode(268, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UseDefViolationOut = new InternalErrorCode(269, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArraySizeInDeclaration = new InternalErrorCode(270, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InaccessibleGetter = new InternalErrorCode(271, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InaccessibleSetter = new InternalErrorCode(272, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidPropertyAccessMod = new InternalErrorCode(273, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicatePropertyAccessMods = new InternalErrorCode(274, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_PropertyAccessModInInterface = new InternalErrorCode(275, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AccessModMissingAccessor = new InternalErrorCode(276, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnimplementedInterfaceAccessor = new InternalErrorCode(277, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_PatternIsAmbiguous = new InternalErrorCode(278, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_PatternStaticOrInaccessible = new InternalErrorCode(279, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_PatternBadSignature = new InternalErrorCode(280, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_FriendRefNotEqualToThis = new InternalErrorCode(281, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_SequentialOnPartialClass = new InternalErrorCode(282, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadConstType = new InternalErrorCode(283, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoNewTyvar = new InternalErrorCode(304, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadArity = new InternalErrorCode(305, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadTypeArgument = new InternalErrorCode(306, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TypeArgsNotAllowed = new InternalErrorCode(307, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_HasNoTypeVars = new InternalErrorCode(308, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NewConstraintNotSatisfied = new InternalErrorCode(310, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GenericConstraintNotSatisfiedRefType = new InternalErrorCode(311, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_GenericConstraintNotSatisfiedNullableEnum = new InternalErrorCode(312, DiagnosticSeverity.Error); // Uses (but doesn't require) SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_GenericConstraintNotSatisfiedNullableInterface = new InternalErrorCode(313, DiagnosticSeverity.Error); // Uses (but doesn't require) SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_GenericConstraintNotSatisfiedTyVar = new InternalErrorCode(314, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_GenericConstraintNotSatisfiedValType = new InternalErrorCode(315, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_DuplicateGeneratedName = new InternalErrorCode(316, DiagnosticSeverity.Error);
        // unused 317-399
        public static readonly InternalErrorCode ERR_GlobalSingleTypeNameNotFound = new InternalErrorCode(400, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NewBoundMustBeLast = new InternalErrorCode(401, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_MainCantBeGeneric = new InternalErrorCode(402, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_TypeVarCantBeNull = new InternalErrorCode(403, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributeCantBeGeneric = new InternalErrorCode(404, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateBound = new InternalErrorCode(405, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ClassBoundNotFirst = new InternalErrorCode(406, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadRetType = new InternalErrorCode(407, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateConstraintClause = new InternalErrorCode(409, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_WrongSignature = new InternalErrorCode(410, DiagnosticSeverity.Error);     unused in Roslyn
        public static readonly InternalErrorCode ERR_CantInferMethTypeArgs = new InternalErrorCode(411, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LocalSameNameAsTypeParam = new InternalErrorCode(412, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AsWithTypeVar = new InternalErrorCode(413, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnreferencedFieldAssg = new InternalErrorCode(414, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadIndexerNameAttr = new InternalErrorCode(415, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttrArgWithTypeVars = new InternalErrorCode(416, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NewTyvarWithArgs = new InternalErrorCode(417, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AbstractSealedStatic = new InternalErrorCode(418, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AmbiguousXMLReference = new InternalErrorCode(419, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_VolatileByRef = new InternalErrorCode(420, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_IncrSwitchObsolete = new InternalErrorCode(422, DiagnosticSeverity.Warning);    // This error code is unused.
        public static readonly InternalErrorCode ERR_ComImportWithImpl = new InternalErrorCode(423, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ComImportWithBase = new InternalErrorCode(424, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ImplBadConstraints = new InternalErrorCode(425, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DottedTypeNameNotFoundInAgg = new InternalErrorCode(426, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MethGrpToNonDel = new InternalErrorCode(428, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_UnreachableExpr = new InternalErrorCode(429, DiagnosticSeverity.Warning);       // This error code is unused.
        public static readonly InternalErrorCode ERR_BadExternAlias = new InternalErrorCode(430, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ColColWithTypeAlias = new InternalErrorCode(431, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AliasNotFound = new InternalErrorCode(432, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SameFullNameAggAgg = new InternalErrorCode(433, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SameFullNameNsAgg = new InternalErrorCode(434, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_SameFullNameThisNsAgg = new InternalErrorCode(435, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_SameFullNameThisAggAgg = new InternalErrorCode(436, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_SameFullNameThisAggNs = new InternalErrorCode(437, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_SameFullNameThisAggThisNs = new InternalErrorCode(438, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExternAfterElements = new InternalErrorCode(439, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_GlobalAliasDefn = new InternalErrorCode(440, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_SealedStaticClass = new InternalErrorCode(441, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PrivateAbstractAccessor = new InternalErrorCode(442, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ValueExpected = new InternalErrorCode(443, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_UnexpectedPredefTypeLoc = new InternalErrorCode(444, DiagnosticSeverity.Warning);  // This error code is unused.
        public static readonly InternalErrorCode ERR_UnboxNotLValue = new InternalErrorCode(445, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnonMethGrpInForEach = new InternalErrorCode(446, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_AttrOnTypeArg = new InternalErrorCode(447, DiagnosticSeverity.Error);      unused in Roslyn. The scenario for which this error exists should, and does generate a parse error.
        public static readonly InternalErrorCode ERR_BadIncDecRetType = new InternalErrorCode(448, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefValBoundMustBeFirst = new InternalErrorCode(449, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefValBoundWithClass = new InternalErrorCode(450, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NewBoundWithVal = new InternalErrorCode(451, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefConstraintNotSatisfied = new InternalErrorCode(452, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ValConstraintNotSatisfied = new InternalErrorCode(453, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CircularConstraint = new InternalErrorCode(454, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BaseConstraintConflict = new InternalErrorCode(455, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConWithValCon = new InternalErrorCode(456, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigUDConv = new InternalErrorCode(457, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AlwaysNull = new InternalErrorCode(458, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode ERR_AddrOnReadOnlyLocal = new InternalErrorCode(459, DiagnosticSeverity.Error); // no longer an error
        public static readonly InternalErrorCode ERR_OverrideWithConstraints = new InternalErrorCode(460, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigOverride = new InternalErrorCode(462, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DecConstError = new InternalErrorCode(463, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_CmpAlwaysFalse = new InternalErrorCode(464, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_FinalizeMethod = new InternalErrorCode(465, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ExplicitImplParams = new InternalErrorCode(466, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_AmbigLookupMeth = new InternalErrorCode(467, DiagnosticSeverity.Warning);      //no longer issued in Roslyn
        //public static readonly InternalErrorCode ERR_SameFullNameThisAggThisAgg = new InternalErrorCode(468, DiagnosticSeverity.Error); no longer used in Roslyn
        public static readonly InternalErrorCode WRN_GotoCaseShouldConvert = new InternalErrorCode(469, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_MethodImplementingAccessor = new InternalErrorCode(470, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_TypeArgsNotAllowedAmbig = new InternalErrorCode(471, DiagnosticSeverity.Error);    no longer issued in Roslyn
        public static readonly InternalErrorCode WRN_NubExprIsConstBool = new InternalErrorCode(472, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_ExplicitImplCollision = new InternalErrorCode(473, DiagnosticSeverity.Warning);
        // unused 474-499
        public static readonly InternalErrorCode ERR_AbstractHasBody = new InternalErrorCode(500, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConcreteMissingBody = new InternalErrorCode(501, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AbstractAndSealed = new InternalErrorCode(502, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AbstractNotVirtual = new InternalErrorCode(503, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticConstant = new InternalErrorCode(504, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantOverrideNonFunction = new InternalErrorCode(505, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantOverrideNonVirtual = new InternalErrorCode(506, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantChangeAccessOnOverride = new InternalErrorCode(507, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantChangeReturnTypeOnOverride = new InternalErrorCode(508, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantDeriveFromSealedType = new InternalErrorCode(509, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AbstractInConcreteClass = new InternalErrorCode(513, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticConstructorWithExplicitConstructorCall = new InternalErrorCode(514, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticConstructorWithAccessModifiers = new InternalErrorCode(515, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RecursiveConstructorCall = new InternalErrorCode(516, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ObjectCallingBaseConstructor = new InternalErrorCode(517, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PredefinedTypeNotFound = new InternalErrorCode(518, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_PredefinedTypeBadType = new InternalErrorCode(520, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StructWithBaseConstructorCall = new InternalErrorCode(522, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StructLayoutCycle = new InternalErrorCode(523, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_InterfacesCannotContainTypes = new InternalErrorCode(524, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InterfacesCantContainFields = new InternalErrorCode(525, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InterfacesCantContainConstructors = new InternalErrorCode(526, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NonInterfaceInInterfaceList = new InternalErrorCode(527, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateInterfaceInBaseList = new InternalErrorCode(528, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CycleInInterfaceInheritance = new InternalErrorCode(529, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_InterfaceMemberHasBody = new InternalErrorCode(531, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_HidingAbstractMethod = new InternalErrorCode(533, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnimplementedAbstractMethod = new InternalErrorCode(534, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnimplementedInterfaceMember = new InternalErrorCode(535, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ObjectCantHaveBases = new InternalErrorCode(537, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitInterfaceImplementationNotInterface = new InternalErrorCode(538, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InterfaceMemberNotFound = new InternalErrorCode(539, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ClassDoesntImplementInterface = new InternalErrorCode(540, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitInterfaceImplementationInNonClassOrStruct = new InternalErrorCode(541, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MemberNameSameAsType = new InternalErrorCode(542, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EnumeratorOverflow = new InternalErrorCode(543, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantOverrideNonProperty = new InternalErrorCode(544, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoGetToOverride = new InternalErrorCode(545, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoSetToOverride = new InternalErrorCode(546, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PropertyCantHaveVoidType = new InternalErrorCode(547, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PropertyWithNoAccessors = new InternalErrorCode(548, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NewVirtualInSealed = new InternalErrorCode(549, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitPropertyAddingAccessor = new InternalErrorCode(550, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitPropertyMissingAccessor = new InternalErrorCode(551, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConversionWithInterface = new InternalErrorCode(552, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConversionWithBase = new InternalErrorCode(553, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConversionWithDerived = new InternalErrorCode(554, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IdentityConversion = new InternalErrorCode(555, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConversionNotInvolvingContainedType = new InternalErrorCode(556, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateConversionInClass = new InternalErrorCode(557, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OperatorsMustBeStatic = new InternalErrorCode(558, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadIncDecSignature = new InternalErrorCode(559, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadUnaryOperatorSignature = new InternalErrorCode(562, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadBinaryOperatorSignature = new InternalErrorCode(563, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadShiftOperatorSignature = new InternalErrorCode(564, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InterfacesCantContainConversionOrEqualityOperators = new InternalErrorCode(567, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StructsCantContainDefaultConstructor = new InternalErrorCode(568, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantOverrideBogusMethod = new InternalErrorCode(569, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BindToBogus = new InternalErrorCode(570, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantCallSpecialMethod = new InternalErrorCode(571, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadTypeReference = new InternalErrorCode(572, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FieldInitializerInStruct = new InternalErrorCode(573, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDestructorName = new InternalErrorCode(574, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OnlyClassesCanContainDestructors = new InternalErrorCode(575, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConflictAliasAndMember = new InternalErrorCode(576, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConditionalOnSpecialMethod = new InternalErrorCode(577, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConditionalMustReturnVoid = new InternalErrorCode(578, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateAttribute = new InternalErrorCode(579, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConditionalOnInterfaceMethod = new InternalErrorCode(582, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ICE_Culprit = new InternalErrorCode(583, DiagnosticSeverity.Error);            No ICE in Roslyn. All of these are unused
        //public static readonly InternalErrorCode ERR_ICE_Symbol = new InternalErrorCode(584, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ICE_Node = new InternalErrorCode(585, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ICE_File = new InternalErrorCode(586, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ICE_Stage = new InternalErrorCode(587, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ICE_Lexer = new InternalErrorCode(588, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ICE_Parser = new InternalErrorCode(589, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OperatorCantReturnVoid = new InternalErrorCode(590, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidAttributeArgument = new InternalErrorCode(591, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributeOnBadSymbolType = new InternalErrorCode(592, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FloatOverflow = new InternalErrorCode(594, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidReal = new InternalErrorCode(595, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ComImportWithoutUuidAttribute = new InternalErrorCode(596, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidNamedArgument = new InternalErrorCode(599, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DllImportOnInvalidMethod = new InternalErrorCode(601, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_FeatureDeprecated = new InternalErrorCode(602, DiagnosticSeverity.Warning);    // This error code is unused.
        // public static readonly InternalErrorCode ERR_NameAttributeOnOverride = new InternalErrorCode(609, DiagnosticSeverity.Error); // removed in Roslyn
        public static readonly InternalErrorCode ERR_FieldCantBeRefAny = new InternalErrorCode(610, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArrayElementCantBeRefAny = new InternalErrorCode(611, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DeprecatedSymbol = new InternalErrorCode(612, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_NotAnAttributeClass = new InternalErrorCode(616, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadNamedAttributeArgument = new InternalErrorCode(617, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DeprecatedSymbolStr = new InternalErrorCode(618, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DeprecatedSymbolStr = new InternalErrorCode(619, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IndexerCantHaveVoidType = new InternalErrorCode(620, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VirtualPrivate = new InternalErrorCode(621, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArrayInitToNonArrayType = new InternalErrorCode(622, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArrayInitInBadPlace = new InternalErrorCode(623, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingStructOffset = new InternalErrorCode(625, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_ExternMethodNoImplementation = new InternalErrorCode(626, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_ProtectedInSealed = new InternalErrorCode(628, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_InterfaceImplementedByConditional = new InternalErrorCode(629, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InterfaceImplementedImplicitlyByVariadic = new InternalErrorCode(630, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalRefParam = new InternalErrorCode(631, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadArgumentToAttribute = new InternalErrorCode(633, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_MissingComTypeOrMarshaller = new InternalErrorCode(635, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StructOffsetOnBadStruct = new InternalErrorCode(636, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StructOffsetOnBadField = new InternalErrorCode(637, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributeUsageOnNonAttributeClass = new InternalErrorCode(641, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_PossibleMistakenNullStatement = new InternalErrorCode(642, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DuplicateNamedAttributeArgument = new InternalErrorCode(643, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeriveFromEnumOrValueType = new InternalErrorCode(644, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_IdentifierTooLong = new InternalErrorCode(645, DiagnosticSeverity.Error);    //not used in Roslyn. See ERR_MetadataNameTooLong
        public static readonly InternalErrorCode ERR_DefaultMemberOnIndexedType = new InternalErrorCode(646, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_CustomAttributeError = new InternalErrorCode(647, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BogusType = new InternalErrorCode(648, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnassignedInternalField = new InternalErrorCode(649, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CStyleArray = new InternalErrorCode(650, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_VacuousIntegralComp = new InternalErrorCode(652, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_AbstractAttributeClass = new InternalErrorCode(653, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadNamedAttributeArgumentType = new InternalErrorCode(655, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingPredefinedMember = new InternalErrorCode(656, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AttributeLocationOnBadDeclaration = new InternalErrorCode(657, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_InvalidAttributeLocation = new InternalErrorCode(658, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_EqualsWithoutGetHashCode = new InternalErrorCode(659, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_EqualityOpWithoutEquals = new InternalErrorCode(660, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_EqualityOpWithoutGetHashCode = new InternalErrorCode(661, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_OutAttrOnRefParam = new InternalErrorCode(662, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OverloadRefKind = new InternalErrorCode(663, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LiteralDoubleCast = new InternalErrorCode(664, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_IncorrectBooleanAssg = new InternalErrorCode(665, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ProtectedInStruct = new InternalErrorCode(666, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_FeatureDeprecated = new InternalErrorCode(667, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InconsistentIndexerNames = new InternalErrorCode(668, DiagnosticSeverity.Error); // Named 'ERR_InconsistantIndexerNames' in native compiler
        public static readonly InternalErrorCode ERR_ComImportWithUserCtor = new InternalErrorCode(669, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FieldCantHaveVoidType = new InternalErrorCode(670, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NonObsoleteOverridingObsolete = new InternalErrorCode(672, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_SystemVoid = new InternalErrorCode(673, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitParamArray = new InternalErrorCode(674, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_BitwiseOrSignExtend = new InternalErrorCode(675, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_VolatileStruct = new InternalErrorCode(677, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VolatileAndReadonly = new InternalErrorCode(678, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_OldWarning_ProtectedInternal = new InternalErrorCode(679, DiagnosticSeverity.Warning);    // This error code is unused.
        // public static readonly InternalErrorCode WRN_OldWarning_AccessibleReadonly = new InternalErrorCode(680, DiagnosticSeverity.Warning);    // This error code is unused.
        public static readonly InternalErrorCode ERR_AbstractField = new InternalErrorCode(681, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BogusExplicitImpl = new InternalErrorCode(682, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitMethodImplAccessor = new InternalErrorCode(683, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_CoClassWithoutComImport = new InternalErrorCode(684, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ConditionalWithOutParam = new InternalErrorCode(685, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AccessorImplementingMethod = new InternalErrorCode(686, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AliasQualAsExpression = new InternalErrorCode(687, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DerivingFromATyVar = new InternalErrorCode(689, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_MalformedMetadata = new InternalErrorCode(690, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateTypeParameter = new InternalErrorCode(692, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_TypeParameterSameAsOuterTypeParameter = new InternalErrorCode(693, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_TypeVariableSameAsParent = new InternalErrorCode(694, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnifyingInterfaceInstantiations = new InternalErrorCode(695, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GenericDerivingFromAttribute = new InternalErrorCode(698, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TyVarNotFoundInConstraint = new InternalErrorCode(699, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadBoundType = new InternalErrorCode(701, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SpecialTypeAsBound = new InternalErrorCode(702, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisBound = new InternalErrorCode(703, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LookupInTypeVariable = new InternalErrorCode(704, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadConstraintType = new InternalErrorCode(706, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InstanceMemberInStaticClass = new InternalErrorCode(708, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticBaseClass = new InternalErrorCode(709, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConstructorInStaticClass = new InternalErrorCode(710, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DestructorInStaticClass = new InternalErrorCode(711, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InstantiatingStaticClass = new InternalErrorCode(712, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticDerivedFromNonObject = new InternalErrorCode(713, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticClassInterfaceImpl = new InternalErrorCode(714, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OperatorInStaticClass = new InternalErrorCode(715, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConvertToStaticClass = new InternalErrorCode(716, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConstraintIsStaticClass = new InternalErrorCode(717, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GenericArgIsStaticClass = new InternalErrorCode(718, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArrayOfStaticClass = new InternalErrorCode(719, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IndexerInStaticClass = new InternalErrorCode(720, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ParameterIsStaticClass = new InternalErrorCode(721, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReturnTypeIsStaticClass = new InternalErrorCode(722, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VarDeclIsStaticClass = new InternalErrorCode(723, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadEmptyThrowInFinally = new InternalErrorCode(724, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_InvalidDecl = new InternalErrorCode(725, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidSpecifier = new InternalErrorCode(726, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_InvalidSpecifierUnk = new InternalErrorCode(727, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AssignmentToLockOrDispose = new InternalErrorCode(728, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ForwardedTypeInThisAssembly = new InternalErrorCode(729, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ForwardedTypeIsNested = new InternalErrorCode(730, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CycleInTypeForwarder = new InternalErrorCode(731, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_FwdedGeneric = new InternalErrorCode(733, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssemblyNameOnNonModule = new InternalErrorCode(734, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidFwdType = new InternalErrorCode(735, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CloseUnimplementedInterfaceMemberStatic = new InternalErrorCode(736, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CloseUnimplementedInterfaceMemberNotPublic = new InternalErrorCode(737, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CloseUnimplementedInterfaceMemberWrongReturnType = new InternalErrorCode(738, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateTypeForwarder = new InternalErrorCode(739, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpectedSelectOrGroup = new InternalErrorCode(742, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpectedContextualKeywordOn = new InternalErrorCode(743, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpectedContextualKeywordEquals = new InternalErrorCode(744, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpectedContextualKeywordBy = new InternalErrorCode(745, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidAnonymousTypeMemberDeclarator = new InternalErrorCode(746, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidInitializerElementInitializer = new InternalErrorCode(747, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InconsistentLambdaParameterUsage = new InternalErrorCode(748, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodInvalidModifier = new InternalErrorCode(750, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodOnlyInPartialClass = new InternalErrorCode(751, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodCannotHaveOutParameters = new InternalErrorCode(752, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_PartialMethodOnlyMethods = new InternalErrorCode(753, DiagnosticSeverity.Error); Removed as it is subsumed by ERR_PartialMisplaced
        public static readonly InternalErrorCode ERR_PartialMethodNotExplicit = new InternalErrorCode(754, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodExtensionDifference = new InternalErrorCode(755, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodOnlyOneLatent = new InternalErrorCode(756, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodOnlyOneActual = new InternalErrorCode(757, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodParamsDifference = new InternalErrorCode(758, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodMustHaveLatent = new InternalErrorCode(759, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodInconsistentConstraints = new InternalErrorCode(761, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodToDelegate = new InternalErrorCode(762, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodStaticDifference = new InternalErrorCode(763, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodUnsafeDifference = new InternalErrorCode(764, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodInExpressionTree = new InternalErrorCode(765, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodMustReturnVoid = new InternalErrorCode(766, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitImplCollisionOnRefOut = new InternalErrorCode(767, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IndirectRecursiveConstructorCall = new InternalErrorCode(768, DiagnosticSeverity.Error);

        // unused 769-799
        //public static readonly InternalErrorCode ERR_NoEmptyArrayRanges = new InternalErrorCode(800, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_IntegerSpecifierOnOneDimArrays = new InternalErrorCode(801, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_IntegerSpecifierMustBePositive = new InternalErrorCode(802, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ArrayRangeDimensionsMustMatch = new InternalErrorCode(803, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ArrayRangeDimensionsWrong = new InternalErrorCode(804, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_IntegerSpecifierValidOnlyOnArrays = new InternalErrorCode(805, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ArrayRangeSpecifierValidOnlyOnArrays = new InternalErrorCode(806, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_UseAdditionalSquareBrackets = new InternalErrorCode(807, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_DotDotNotAssociative = new InternalErrorCode(808, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_ObsoleteOverridingNonObsolete = new InternalErrorCode(809, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_DebugFullNameTooLong = new InternalErrorCode(811, DiagnosticSeverity.Warning);                                 // Dev11 name: ERR_DebugFullNameTooLong
        public static readonly InternalErrorCode ERR_ImplicitlyTypedVariableAssignedBadValue = new InternalErrorCode(815, DiagnosticSeverity.Error);              // Dev10 name: ERR_ImplicitlyTypedLocalAssignedBadValue
        public static readonly InternalErrorCode ERR_ImplicitlyTypedVariableWithNoInitializer = new InternalErrorCode(818, DiagnosticSeverity.Error);             // Dev10 name: ERR_ImplicitlyTypedLocalWithNoInitializer
        public static readonly InternalErrorCode ERR_ImplicitlyTypedVariableMultipleDeclarator = new InternalErrorCode(819, DiagnosticSeverity.Error);            // Dev10 name: ERR_ImplicitlyTypedLocalMultipleDeclarator
        public static readonly InternalErrorCode ERR_ImplicitlyTypedVariableAssignedArrayInitializer = new InternalErrorCode(820, DiagnosticSeverity.Error);      // Dev10 name: ERR_ImplicitlyTypedLocalAssignedArrayInitializer
        public static readonly InternalErrorCode ERR_ImplicitlyTypedLocalCannotBeFixed = new InternalErrorCode(821, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ImplicitlyTypedVariableCannotBeConst = new InternalErrorCode(822, DiagnosticSeverity.Error);                 // Dev10 name: ERR_ImplicitlyTypedLocalCannotBeConst
        public static readonly InternalErrorCode WRN_ExternCtorNoImplementation = new InternalErrorCode(824, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_TypeVarNotFound = new InternalErrorCode(825, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ImplicitlyTypedArrayNoBestType = new InternalErrorCode(826, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnonymousTypePropertyAssignedBadValue = new InternalErrorCode(828, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsBaseAccess = new InternalErrorCode(831, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsAssignment = new InternalErrorCode(832, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnonymousTypeDuplicatePropertyName = new InternalErrorCode(833, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StatementLambdaToExpressionTree = new InternalErrorCode(834, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeMustHaveDelegate = new InternalErrorCode(835, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnonymousTypeNotAvailable = new InternalErrorCode(836, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LambdaInIsAs = new InternalErrorCode(837, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsMultiDimensionalArrayInitializer = new InternalErrorCode(838, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingArgument = new InternalErrorCode(839, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_AutoPropertiesMustHaveBothAccessors = new InternalErrorCode(840, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VariableUsedBeforeDeclaration = new InternalErrorCode(841, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ExplicitLayoutAndAutoImplementedProperty = new InternalErrorCode(842, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnassignedThisAutoProperty = new InternalErrorCode(843, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VariableUsedBeforeDeclarationAndHidesField = new InternalErrorCode(844, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsBadCoalesce = new InternalErrorCode(845, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArrayInitializerExpected = new InternalErrorCode(846, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArrayInitializerIncorrectLength = new InternalErrorCode(847, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_OverloadRefOutCtor = new InternalErrorCode(851, DiagnosticSeverity.Error);                                Replaced By ERR_OverloadRefKind
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsNamedArgument = new InternalErrorCode(853, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsOptionalArgument = new InternalErrorCode(854, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsIndexedProperty = new InternalErrorCode(855, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IndexedPropertyRequiresParams = new InternalErrorCode(856, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IndexedPropertyMustHaveAllOptionalParams = new InternalErrorCode(857, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_FusionConfigFileNameTooLong = new InternalErrorCode(858, DiagnosticSeverity.Error);    unused in Roslyn. We give ERR_CantReadConfigFile now.
        // unused 859-1000
        public static readonly InternalErrorCode ERR_IdentifierExpected = new InternalErrorCode(1001, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SemicolonExpected = new InternalErrorCode(1002, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SyntaxError = new InternalErrorCode(1003, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateModifier = new InternalErrorCode(1004, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateAccessor = new InternalErrorCode(1007, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IntegralTypeExpected = new InternalErrorCode(1008, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalEscape = new InternalErrorCode(1009, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NewlineInConst = new InternalErrorCode(1010, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EmptyCharConst = new InternalErrorCode(1011, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TooManyCharsInConst = new InternalErrorCode(1012, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidNumber = new InternalErrorCode(1013, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GetOrSetExpected = new InternalErrorCode(1014, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ClassTypeExpected = new InternalErrorCode(1015, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NamedArgumentExpected = new InternalErrorCode(1016, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TooManyCatches = new InternalErrorCode(1017, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ThisOrBaseExpected = new InternalErrorCode(1018, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OvlUnaryOperatorExpected = new InternalErrorCode(1019, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OvlBinaryOperatorExpected = new InternalErrorCode(1020, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IntOverflow = new InternalErrorCode(1021, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EOFExpected = new InternalErrorCode(1022, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadEmbeddedStmt = new InternalErrorCode(1023, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PPDirectiveExpected = new InternalErrorCode(1024, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EndOfPPLineExpected = new InternalErrorCode(1025, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CloseParenExpected = new InternalErrorCode(1026, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EndifDirectiveExpected = new InternalErrorCode(1027, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnexpectedDirective = new InternalErrorCode(1028, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ErrorDirective = new InternalErrorCode(1029, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_WarningDirective = new InternalErrorCode(1030, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_TypeExpected = new InternalErrorCode(1031, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PPDefFollowsToken = new InternalErrorCode(1032, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_TooManyLines = new InternalErrorCode(1033, DiagnosticSeverity.Error);      unused in Roslyn.
        //public static readonly InternalErrorCode ERR_LineTooLong = new InternalErrorCode(1034, DiagnosticSeverity.Error);       unused in Roslyn.
        public static readonly InternalErrorCode ERR_OpenEndedComment = new InternalErrorCode(1035, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OvlOperatorExpected = new InternalErrorCode(1037, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EndRegionDirectiveExpected = new InternalErrorCode(1038, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnterminatedStringLit = new InternalErrorCode(1039, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDirectivePlacement = new InternalErrorCode(1040, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IdentifierExpectedKW = new InternalErrorCode(1041, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SemiOrLBraceExpected = new InternalErrorCode(1043, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MultiTypeInDeclaration = new InternalErrorCode(1044, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AddOrRemoveExpected = new InternalErrorCode(1055, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnexpectedCharacter = new InternalErrorCode(1056, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ProtectedInStatic = new InternalErrorCode(1057, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnreachableGeneralCatch = new InternalErrorCode(1058, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_IncrementLvalueExpected = new InternalErrorCode(1059, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_UninitializedField = new InternalErrorCode(1060, DiagnosticSeverity.Warning);  // unused in Roslyn.
        public static readonly InternalErrorCode ERR_NoSuchMemberOrExtension = new InternalErrorCode(1061, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DeprecatedCollectionInitAddStr = new InternalErrorCode(1062, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DeprecatedCollectionInitAddStr = new InternalErrorCode(1063, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DeprecatedCollectionInitAdd = new InternalErrorCode(1064, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DefaultValueNotAllowed = new InternalErrorCode(1065, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DefaultValueForUnconsumedLocation = new InternalErrorCode(1066, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_PartialWrongTypeParamsVariance = new InternalErrorCode(1067, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GlobalSingleTypeNameNotFoundFwd = new InternalErrorCode(1068, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DottedTypeNameNotFoundInNSFwd = new InternalErrorCode(1069, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SingleTypeNameNotFoundFwd = new InternalErrorCode(1070, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoSuchMemberOnNoPIAType = new InternalErrorCode(1071, DiagnosticSeverity.Error);   //EE
        public static readonly InternalErrorCode WRN_IdentifierOrNumericLiteralExpected = new InternalErrorCode(1072, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_UnexpectedToken = new InternalErrorCode(1073, DiagnosticSeverity.Error);
        // unused 1074-1098
        // public static readonly InternalErrorCode ERR_EOLExpected = new InternalErrorCode(1099, DiagnosticSeverity.Error); // EE
        // public static readonly InternalErrorCode ERR_NotSupportedinEE = new InternalErrorCode(1100, DiagnosticSeverity.Error); // EE
        public static readonly InternalErrorCode ERR_BadThisParam = new InternalErrorCode(1100, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_BadRefWithThis = new InternalErrorCode(1101, DiagnosticSeverity.Error); replaced by ERR_BadParameterModifiers
        // public static readonly InternalErrorCode ERR_BadOutWithThis = new InternalErrorCode(1102, DiagnosticSeverity.Error); replaced by ERR_BadParameterModifiers
        public static readonly InternalErrorCode ERR_BadTypeforThis = new InternalErrorCode(1103, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadParamModThis = new InternalErrorCode(1104, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadExtensionMeth = new InternalErrorCode(1105, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadExtensionAgg = new InternalErrorCode(1106, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DupParamMod = new InternalErrorCode(1107, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_MultiParamMod = new InternalErrorCode(1108, DiagnosticSeverity.Error); replaced by ERR_BadParameterModifiers
        public static readonly InternalErrorCode ERR_ExtensionMethodsDecl = new InternalErrorCode(1109, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExtensionAttrNotFound = new InternalErrorCode(1110, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ExtensionTypeParam = new InternalErrorCode(1111, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitExtension = new InternalErrorCode(1112, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ValueTypeExtDelegate = new InternalErrorCode(1113, DiagnosticSeverity.Error);
        // unused 1114-1199
        // Below five error codes are unused.
        // public static readonly InternalErrorCode WRN_FeatureDeprecated2 = new InternalErrorCode(1200, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_FeatureDeprecated3 = new InternalErrorCode(1201, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_FeatureDeprecated4 = new InternalErrorCode(1202, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_FeatureDeprecated5 = new InternalErrorCode(1203, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_OldWarning_FeatureDefaultDeprecated = new InternalErrorCode(1204, DiagnosticSeverity.Warning);
        // unused 1205-1500
        public static readonly InternalErrorCode ERR_BadArgCount = new InternalErrorCode(1501, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_BadArgTypes = new InternalErrorCode(1502, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadArgType = new InternalErrorCode(1503, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoSourceFile = new InternalErrorCode(1504, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantRefResource = new InternalErrorCode(1507, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ResourceNotUnique = new InternalErrorCode(1508, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ImportNonAssembly = new InternalErrorCode(1509, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefLvalueExpected = new InternalErrorCode(1510, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BaseInStaticMeth = new InternalErrorCode(1511, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BaseInBadContext = new InternalErrorCode(1512, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RbraceExpected = new InternalErrorCode(1513, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LbraceExpected = new InternalErrorCode(1514, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InExpected = new InternalErrorCode(1515, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidPreprocExpr = new InternalErrorCode(1517, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_BadTokenInType = new InternalErrorCode(1518, DiagnosticSeverity.Error);    unused in Roslyn
        public static readonly InternalErrorCode ERR_InvalidMemberDecl = new InternalErrorCode(1519, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MemberNeedsType = new InternalErrorCode(1520, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadBaseType = new InternalErrorCode(1521, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_EmptySwitch = new InternalErrorCode(1522, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ExpectedEndTry = new InternalErrorCode(1524, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidExprTerm = new InternalErrorCode(1525, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadNewExpr = new InternalErrorCode(1526, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoNamespacePrivate = new InternalErrorCode(1527, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVarDecl = new InternalErrorCode(1528, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UsingAfterElements = new InternalErrorCode(1529, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoNewOnNamespaceElement = new InternalErrorCode(1530, DiagnosticSeverity.Error); EDMAURER we now give BadMemberFlag which is only a little less specific than this.
        //public static readonly InternalErrorCode ERR_DontUseInvoke = new InternalErrorCode(1533, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadBinOpArgs = new InternalErrorCode(1534, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadUnOpArgs = new InternalErrorCode(1535, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoVoidParameter = new InternalErrorCode(1536, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateAlias = new InternalErrorCode(1537, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadProtectedAccess = new InternalErrorCode(1540, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_CantIncludeDirectory = new InternalErrorCode(1541, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AddModuleAssembly = new InternalErrorCode(1542, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BindToBogusProp2 = new InternalErrorCode(1545, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BindToBogusProp1 = new InternalErrorCode(1546, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoVoidHere = new InternalErrorCode(1547, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_CryptoFailed = new InternalErrorCode(1548, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_CryptoNotFound = new InternalErrorCode(1549, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IndexerNeedsParam = new InternalErrorCode(1551, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadArraySyntax = new InternalErrorCode(1552, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadOperatorSyntax = new InternalErrorCode(1553, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_BadOperatorSyntax2 = new InternalErrorCode(1554, DiagnosticSeverity.Error);    Not used in Roslyn.
        public static readonly InternalErrorCode ERR_MainClassNotFound = new InternalErrorCode(1555, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MainClassNotClass = new InternalErrorCode(1556, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_MainClassWrongFile = new InternalErrorCode(1557, DiagnosticSeverity.Error);    Not used in Roslyn. This was used only when compiling and producing two outputs.
        public static readonly InternalErrorCode ERR_NoMainInClass = new InternalErrorCode(1558, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_MainClassIsImport = new InternalErrorCode(1559, DiagnosticSeverity.Error);     Not used in Roslyn. Scenario occurs so infrequently that it is not worth re-implementing.
        //public static readonly InternalErrorCode ERR_FileNameTooLong = new InternalErrorCode(1560, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_OutputFileNameTooLong = new InternalErrorCode(1561, DiagnosticSeverity.Error); Not used in Roslyn. We report a more generic error that doesn't mention "output file" but is fine.
        public static readonly InternalErrorCode ERR_OutputNeedsName = new InternalErrorCode(1562, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_OutputNeedsInput = new InternalErrorCode(1563, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantHaveWin32ResAndManifest = new InternalErrorCode(1564, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantHaveWin32ResAndIcon = new InternalErrorCode(1565, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantReadResource = new InternalErrorCode(1566, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_AutoResGen = new InternalErrorCode(1567, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DocFileGen = new InternalErrorCode(1569, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_XMLParseError = new InternalErrorCode(1570, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_DuplicateParamTag = new InternalErrorCode(1571, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_UnmatchedParamTag = new InternalErrorCode(1572, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_MissingParamTag = new InternalErrorCode(1573, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_BadXMLRef = new InternalErrorCode(1574, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadStackAllocExpr = new InternalErrorCode(1575, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidLineNumber = new InternalErrorCode(1576, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ALinkFailed = new InternalErrorCode(1577, DiagnosticSeverity.Error);               No alink usage in Roslyn
        public static readonly InternalErrorCode ERR_MissingPPFile = new InternalErrorCode(1578, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ForEachMissingMember = new InternalErrorCode(1579, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_BadXMLRefParamType = new InternalErrorCode(1580, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_BadXMLRefReturnType = new InternalErrorCode(1581, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadWin32Res = new InternalErrorCode(1583, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_BadXMLRefSyntax = new InternalErrorCode(1584, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadModifierLocation = new InternalErrorCode(1585, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingArraySize = new InternalErrorCode(1586, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnprocessedXMLComment = new InternalErrorCode(1587, DiagnosticSeverity.Warning);
        //public static readonly InternalErrorCode ERR_CantGetCORSystemDir = new InternalErrorCode(1588, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_FailedInclude = new InternalErrorCode(1589, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_InvalidInclude = new InternalErrorCode(1590, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_MissingXMLComment = new InternalErrorCode(1591, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_XMLParseIncludeError = new InternalErrorCode(1592, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadDelArgCount = new InternalErrorCode(1593, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_BadDelArgTypes = new InternalErrorCode(1594, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_OldWarning_MultipleTypeDefs = new InternalErrorCode(1595, DiagnosticSeverity.Warning);    // This error code is unused.
        // public static readonly InternalErrorCode WRN_OldWarning_DocFileGenAndIncr = new InternalErrorCode(1596, DiagnosticSeverity.Warning);    // This error code is unused.
        public static readonly InternalErrorCode ERR_UnexpectedSemicolon = new InternalErrorCode(1597, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_XMLParserNotFound = new InternalErrorCode(1598, DiagnosticSeverity.Warning); // No longer used (though, conceivably, we could report it if Linq to Xml is missing at compile time).
        public static readonly InternalErrorCode ERR_MethodReturnCantBeRefAny = new InternalErrorCode(1599, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CompileCancelled = new InternalErrorCode(1600, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MethodArgCantBeRefAny = new InternalErrorCode(1601, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssgReadonlyLocal = new InternalErrorCode(1604, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReadonlyLocal = new InternalErrorCode(1605, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ALinkCloseFailed = new InternalErrorCode(1606, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_ALinkWarn = new InternalErrorCode(1607, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CantUseRequiredAttribute = new InternalErrorCode(1608, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoModifiersOnAccessor = new InternalErrorCode(1609, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_DeleteAutoResFailed = new InternalErrorCode(1610, DiagnosticSeverity.Warning); // Unused.
        public static readonly InternalErrorCode ERR_ParamsCantBeWithModifier = new InternalErrorCode(1611, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReturnNotLValue = new InternalErrorCode(1612, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingCoClass = new InternalErrorCode(1613, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbiguousAttribute = new InternalErrorCode(1614, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadArgExtraRef = new InternalErrorCode(1615, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_CmdOptionConflictsSource = new InternalErrorCode(1616, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_BadCompatMode = new InternalErrorCode(1617, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DelegateOnConditional = new InternalErrorCode(1618, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantMakeTempFile = new InternalErrorCode(1619, DiagnosticSeverity.Error);    //changed to now accept only one argument
        public static readonly InternalErrorCode ERR_BadArgRef = new InternalErrorCode(1620, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_YieldInAnonMeth = new InternalErrorCode(1621, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReturnInIterator = new InternalErrorCode(1622, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadIteratorArgType = new InternalErrorCode(1623, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadIteratorReturn = new InternalErrorCode(1624, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadYieldInFinally = new InternalErrorCode(1625, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadYieldInTryOfCatch = new InternalErrorCode(1626, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EmptyYield = new InternalErrorCode(1627, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnonDelegateCantUse = new InternalErrorCode(1628, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalInnerUnsafe = new InternalErrorCode(1629, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_BadWatsonMode = new InternalErrorCode(1630, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadYieldInCatch = new InternalErrorCode(1631, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDelegateLeave = new InternalErrorCode(1632, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_IllegalPragma = new InternalErrorCode(1633, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_IllegalPPWarning = new InternalErrorCode(1634, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_BadRestoreNumber = new InternalErrorCode(1635, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_VarargsIterator = new InternalErrorCode(1636, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnsafeIteratorArgType = new InternalErrorCode(1637, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ReservedIdentifier = new InternalErrorCode(1638, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadCoClassSig = new InternalErrorCode(1639, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MultipleIEnumOfT = new InternalErrorCode(1640, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedDimsRequired = new InternalErrorCode(1641, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedNotInStruct = new InternalErrorCode(1642, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnonymousReturnExpected = new InternalErrorCode(1643, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NonECMAFeature = new InternalErrorCode(1644, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NonECMAFeature = new InternalErrorCode(1645, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ExpectedVerbatimLiteral = new InternalErrorCode(1646, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_StackOverflow = new InternalErrorCode(1647, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssgReadonly2 = new InternalErrorCode(1648, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReadonly2 = new InternalErrorCode(1649, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssgReadonlyStatic2 = new InternalErrorCode(1650, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReadonlyStatic2 = new InternalErrorCode(1651, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssgReadonlyLocal2Cause = new InternalErrorCode(1654, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReadonlyLocal2Cause = new InternalErrorCode(1655, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssgReadonlyLocalCause = new InternalErrorCode(1656, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReadonlyLocalCause = new InternalErrorCode(1657, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_ErrorOverride = new InternalErrorCode(1658, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_OldWarning_ReservedIdentifier = new InternalErrorCode(1659, DiagnosticSeverity.Warning);    // This error code is unused.
        public static readonly InternalErrorCode ERR_AnonMethToNonDel = new InternalErrorCode(1660, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantConvAnonMethParams = new InternalErrorCode(1661, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantConvAnonMethReturns = new InternalErrorCode(1662, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalFixedType = new InternalErrorCode(1663, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedOverflow = new InternalErrorCode(1664, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidFixedArraySize = new InternalErrorCode(1665, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedBufferNotFixed = new InternalErrorCode(1666, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributeNotOnAccessor = new InternalErrorCode(1667, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_InvalidSearchPathDir = new InternalErrorCode(1668, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_IllegalVarArgs = new InternalErrorCode(1669, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalParams = new InternalErrorCode(1670, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadModifiersOnNamespace = new InternalErrorCode(1671, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadPlatformType = new InternalErrorCode(1672, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ThisStructNotInAnonMeth = new InternalErrorCode(1673, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConvToIDisp = new InternalErrorCode(1674, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_InvalidGenericEnum = new InternalErrorCode(1675, DiagnosticSeverity.Error);    replaced with 7002
        public static readonly InternalErrorCode ERR_BadParamRef = new InternalErrorCode(1676, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadParamExtraRef = new InternalErrorCode(1677, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadParamType = new InternalErrorCode(1678, DiagnosticSeverity.Error); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode ERR_BadExternIdentifier = new InternalErrorCode(1679, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AliasMissingFile = new InternalErrorCode(1680, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GlobalExternAlias = new InternalErrorCode(1681, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_MissingTypeNested = new InternalErrorCode(1682, DiagnosticSeverity.Warning);   // unused in Roslyn.
        // In Roslyn, we generate errors ERR_MissingTypeInSource and ERR_MissingTypeInAssembly instead of warnings WRN_MissingTypeInSource and WRN_MissingTypeInAssembly respectively.
        // public static readonly InternalErrorCode WRN_MissingTypeInSource = new InternalErrorCode(1683, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_MissingTypeInAssembly = new InternalErrorCode(1684, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_MultiplePredefTypes = new InternalErrorCode(1685, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_LocalCantBeFixedAndHoisted = new InternalErrorCode(1686, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_TooManyLinesForDebugger = new InternalErrorCode(1687, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CantConvAnonMethNoParams = new InternalErrorCode(1688, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConditionalOnNonAttributeClass = new InternalErrorCode(1689, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_CallOnNonAgileField = new InternalErrorCode(1690, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_BadWarningNumber = new InternalErrorCode(1691, DiagnosticSeverity.Warning);    // we no longer generate this warning for an unrecognized warning ID specified as an argument to /nowarn or /warnaserror.
        public static readonly InternalErrorCode WRN_InvalidNumber = new InternalErrorCode(1692, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_FileNameTooLong = new InternalErrorCode(1694, DiagnosticSeverity.Warning); //unused.
        public static readonly InternalErrorCode WRN_IllegalPPChecksum = new InternalErrorCode(1695, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_EndOfPPLineExpected = new InternalErrorCode(1696, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_ConflictingChecksum = new InternalErrorCode(1697, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_AssumedMatchThis = new InternalErrorCode(1698, DiagnosticSeverity.Warning);     // This error code is unused.
        // public static readonly InternalErrorCode WRN_UseSwitchInsteadOfAttribute = new InternalErrorCode(1699, DiagnosticSeverity.Warning);     // This error code is unused.
        public static readonly InternalErrorCode WRN_InvalidAssemblyName = new InternalErrorCode(1700, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_UnifyReferenceMajMin = new InternalErrorCode(1701, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_UnifyReferenceBldRev = new InternalErrorCode(1702, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DuplicateImport = new InternalErrorCode(1703, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateImportSimple = new InternalErrorCode(1704, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssemblyMatchBadVersion = new InternalErrorCode(1705, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_AnonMethNotAllowed = new InternalErrorCode(1706, DiagnosticSeverity.Error);            Unused in Roslyn. Previously given when a lambda was supplied as an attribute argument.
        // public static readonly InternalErrorCode WRN_DelegateNewMethBind = new InternalErrorCode(1707, DiagnosticSeverity.Warning);             // This error code is unused.
        public static readonly InternalErrorCode ERR_FixedNeedsLvalue = new InternalErrorCode(1708, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_EmptyFileName = new InternalErrorCode(1709, DiagnosticSeverity.Warning);        // This error code is unused.
        public static readonly InternalErrorCode WRN_DuplicateTypeParamTag = new InternalErrorCode(1710, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_UnmatchedTypeParamTag = new InternalErrorCode(1711, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_MissingTypeParamTag = new InternalErrorCode(1712, DiagnosticSeverity.Warning);
        //public static readonly InternalErrorCode FTL_TypeNameBuilderError = new InternalErrorCode(1713, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ImportBadBase = new InternalErrorCode(1714, DiagnosticSeverity.Error);                 // This error code is unused and replaced with ERR_NoTypeDef
        public static readonly InternalErrorCode ERR_CantChangeTypeOnOverride = new InternalErrorCode(1715, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DoNotUseFixedBufferAttr = new InternalErrorCode(1716, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AssignmentToSelf = new InternalErrorCode(1717, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_ComparisonToSelf = new InternalErrorCode(1718, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CantOpenWin32Res = new InternalErrorCode(1719, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DotOnDefault = new InternalErrorCode(1720, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_NoMultipleInheritance = new InternalErrorCode(1721, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BaseClassMustBeFirst = new InternalErrorCode(1722, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_BadXMLRefTypeVar = new InternalErrorCode(1723, DiagnosticSeverity.Warning);
        //public static readonly InternalErrorCode ERR_InvalidDefaultCharSetValue = new InternalErrorCode(1724, DiagnosticSeverity.Error);    Not used in Roslyn.
        public static readonly InternalErrorCode ERR_FriendAssemblyBadArgs = new InternalErrorCode(1725, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FriendAssemblySNReq = new InternalErrorCode(1726, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_WatsonSendNotOptedIn = new InternalErrorCode(1727, DiagnosticSeverity.Error);            We're not doing any custom Watson processing in Roslyn. In modern OSs, Watson behavior is configured with machine policy settings.
        public static readonly InternalErrorCode ERR_DelegateOnNullable = new InternalErrorCode(1728, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadCtorArgCount = new InternalErrorCode(1729, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GlobalAttributesNotFirst = new InternalErrorCode(1730, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_CantConvAnonMethReturnsNoDelegate = new InternalErrorCode(1731, DiagnosticSeverity.Error);     Not used in Roslyn. When there is no delegate, we reuse the message that contains a substitution string for the delegate type.
        //public static readonly InternalErrorCode ERR_ParameterExpected = new InternalErrorCode(1732, DiagnosticSeverity.Error);             Not used in Roslyn.
        public static readonly InternalErrorCode ERR_ExpressionExpected = new InternalErrorCode(1733, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnmatchedParamRefTag = new InternalErrorCode(1734, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_UnmatchedTypeParamRefTag = new InternalErrorCode(1735, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DefaultValueMustBeConstant = new InternalErrorCode(1736, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultValueBeforeRequiredValue = new InternalErrorCode(1737, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NamedArgumentSpecificationBeforeFixedArgument = new InternalErrorCode(1738, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadNamedArgument = new InternalErrorCode(1739, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateNamedArgument = new InternalErrorCode(1740, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefOutDefaultValue = new InternalErrorCode(1741, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NamedArgumentForArray = new InternalErrorCode(1742, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultValueForExtensionParameter = new InternalErrorCode(1743, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NamedArgumentUsedInPositional = new InternalErrorCode(1744, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultValueUsedWithAttributes = new InternalErrorCode(1745, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadNamedArgumentForDelegateInvoke = new InternalErrorCode(1746, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoPIAAssemblyMissingAttribute = new InternalErrorCode(1747, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoCanonicalView = new InternalErrorCode(1748, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_TypeNotFoundForNoPIA = new InternalErrorCode(1749, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConversionForDefaultParam = new InternalErrorCode(1750, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultValueForParamsParameter = new InternalErrorCode(1751, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NewCoClassOnLink = new InternalErrorCode(1752, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoPIANestedType = new InternalErrorCode(1754, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_InvalidTypeIdentifierConstructor = new InternalErrorCode(1755, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InteropTypeMissingAttribute = new InternalErrorCode(1756, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InteropStructContainsMethods = new InternalErrorCode(1757, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InteropTypesWithSameNameAndGuid = new InternalErrorCode(1758, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoPIAAssemblyMissingAttributes = new InternalErrorCode(1759, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssemblySpecifiedForLinkAndRef = new InternalErrorCode(1760, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LocalTypeNameClash = new InternalErrorCode(1761, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_ReferencedAssemblyReferencesLinkedPIA = new InternalErrorCode(1762, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_NotNullRefDefaultParameter = new InternalErrorCode(1763, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedLocalInLambda = new InternalErrorCode(1764, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_TypeNotFoundForNoPIAWarning = new InternalErrorCode(1765, DiagnosticSeverity.Warning);  // This error code is unused.
        public static readonly InternalErrorCode ERR_MissingMethodOnSourceInterface = new InternalErrorCode(1766, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingSourceInterface = new InternalErrorCode(1767, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GenericsUsedInNoPIAType = new InternalErrorCode(1768, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GenericsUsedAcrossAssemblies = new InternalErrorCode(1769, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConversionForNubDefaultParam = new InternalErrorCode(1770, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_MemberWithGenericsUsedAcrossAssemblies = new InternalErrorCode(1771, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_GenericsUsedInBaseTypeAcrossAssemblies = new InternalErrorCode(1772, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidSubsystemVersion = new InternalErrorCode(1773, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InteropMethodWithBody = new InternalErrorCode(1774, DiagnosticSeverity.Error);
        // unused 1775-1899
        public static readonly InternalErrorCode ERR_BadWarningLevel = new InternalErrorCode(1900, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDebugType = new InternalErrorCode(1902, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_UnknownTestSwitch = new InternalErrorCode(1903, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadResourceVis = new InternalErrorCode(1906, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultValueTypeMustMatch = new InternalErrorCode(1908, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_DefaultValueBadParamType = new InternalErrorCode(1909, DiagnosticSeverity.Error); // Replaced by ERR_DefaultValueBadValueType in Roslyn.
        public static readonly InternalErrorCode ERR_DefaultValueBadValueType = new InternalErrorCode(1910, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MemberAlreadyInitialized = new InternalErrorCode(1912, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MemberCannotBeInitialized = new InternalErrorCode(1913, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticMemberInObjectInitializer = new InternalErrorCode(1914, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReadonlyValueTypeInObjectInitializer = new InternalErrorCode(1917, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ValueTypePropertyInObjectInitializer = new InternalErrorCode(1918, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnsafeTypeInObjectCreation = new InternalErrorCode(1919, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EmptyElementInitializer = new InternalErrorCode(1920, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InitializerAddHasWrongSignature = new InternalErrorCode(1921, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CollectionInitRequiresIEnumerable = new InternalErrorCode(1922, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_InvalidCollectionInitializerType = new InternalErrorCode(1925, DiagnosticSeverity.Error);  unused in Roslyn. Occurs so infrequently in real usage that it is not worth reimplementing.
        public static readonly InternalErrorCode ERR_CantOpenWin32Manifest = new InternalErrorCode(1926, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_CantHaveManifestForModule = new InternalErrorCode(1927, DiagnosticSeverity.Warning);
        //public static readonly InternalErrorCode ERR_BadExtensionArgTypes = new InternalErrorCode(1928, DiagnosticSeverity.Error); unused in Roslyn (replaced by ERR_BadInstanceArgType)
        public static readonly InternalErrorCode ERR_BadInstanceArgType = new InternalErrorCode(1929, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryDuplicateRangeVariable = new InternalErrorCode(1930, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryRangeVariableOverrides = new InternalErrorCode(1931, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryRangeVariableAssignedBadValue = new InternalErrorCode(1932, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_QueryNotAllowed = new InternalErrorCode(1933, DiagnosticSeverity.Error);       unused in Roslyn. This specific message is not necessary for correctness and adds little.
        public static readonly InternalErrorCode ERR_QueryNoProviderCastable = new InternalErrorCode(1934, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryNoProviderStandard = new InternalErrorCode(1935, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryNoProvider = new InternalErrorCode(1936, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryOuterKey = new InternalErrorCode(1937, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryInnerKey = new InternalErrorCode(1938, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryOutRefRangeVariable = new InternalErrorCode(1939, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryMultipleProviders = new InternalErrorCode(1940, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryTypeInferenceFailedMulti = new InternalErrorCode(1941, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryTypeInferenceFailed = new InternalErrorCode(1942, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryTypeInferenceFailedSelectMany = new InternalErrorCode(1943, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsPointerOp = new InternalErrorCode(1944, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsAnonymousMethod = new InternalErrorCode(1945, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnonymousMethodToExpressionTree = new InternalErrorCode(1946, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryRangeVariableReadOnly = new InternalErrorCode(1947, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_QueryRangeVariableSameAsTypeParam = new InternalErrorCode(1948, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TypeVarNotFoundRangeVariable = new InternalErrorCode(1949, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadArgTypesForCollectionAdd = new InternalErrorCode(1950, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ByRefParameterInExpressionTree = new InternalErrorCode(1951, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VarArgsInExpressionTree = new InternalErrorCode(1952, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_MemGroupInExpressionTree = new InternalErrorCode(1953, DiagnosticSeverity.Error); unused in Roslyn (replaced by ERR_LambdaInIsAs)
        public static readonly InternalErrorCode ERR_InitializerAddHasParamModifiers = new InternalErrorCode(1954, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NonInvocableMemberCalled = new InternalErrorCode(1955, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_MultipleRuntimeImplementationMatches = new InternalErrorCode(1956, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_MultipleRuntimeOverrideMatches = new InternalErrorCode(1957, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ObjectOrCollectionInitializerWithDelegateCreation = new InternalErrorCode(1958, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidConstantDeclarationType = new InternalErrorCode(1959, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IllegalVarianceSyntax = new InternalErrorCode(1960, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnexpectedVariance = new InternalErrorCode(1961, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDynamicTypeof = new InternalErrorCode(1962, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsDynamicOperation = new InternalErrorCode(1963, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDynamicConversion = new InternalErrorCode(1964, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeriveFromDynamic = new InternalErrorCode(1965, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeriveFromConstructedDynamic = new InternalErrorCode(1966, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DynamicTypeAsBound = new InternalErrorCode(1967, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConstructedDynamicTypeAsBound = new InternalErrorCode(1968, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DynamicRequiredTypesMissing = new InternalErrorCode(1969, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitDynamicAttr = new InternalErrorCode(1970, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoDynamicPhantomOnBase = new InternalErrorCode(1971, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoDynamicPhantomOnBaseIndexer = new InternalErrorCode(1972, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadArgTypeDynamicExtension = new InternalErrorCode(1973, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DynamicDispatchToConditionalMethod = new InternalErrorCode(1974, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_NoDynamicPhantomOnBaseCtor = new InternalErrorCode(1975, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDynamicMethodArgMemgrp = new InternalErrorCode(1976, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDynamicMethodArgLambda = new InternalErrorCode(1977, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDynamicMethodArg = new InternalErrorCode(1978, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDynamicQuery = new InternalErrorCode(1979, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DynamicAttributeMissing = new InternalErrorCode(1980, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_IsDynamicIsConfusing = new InternalErrorCode(1981, DiagnosticSeverity.Warning);
        //public static readonly InternalErrorCode ERR_DynamicNotAllowedInAttribute = new InternalErrorCode(1982, DiagnosticSeverity.Error);                    // Replaced by ERR_BadAttributeParamType in Roslyn.
        public static readonly InternalErrorCode ERR_BadAsyncReturn = new InternalErrorCode(1983, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitInFinally = new InternalErrorCode(1984, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitInCatch = new InternalErrorCode(1985, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitArg = new InternalErrorCode(1986, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAsyncArgType = new InternalErrorCode(1988, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAsyncExpressionTree = new InternalErrorCode(1989, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_WindowsRuntimeTypesMissing = new InternalErrorCode(1990, DiagnosticSeverity.Error); // unused in Roslyn
        public static readonly InternalErrorCode ERR_MixingWinRTEventWithRegular = new InternalErrorCode(1991, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitWithoutAsync = new InternalErrorCode(1992, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_MissingAsyncTypes = new InternalErrorCode(1993, DiagnosticSeverity.Error); // unused in Roslyn
        public static readonly InternalErrorCode ERR_BadAsyncLacksBody = new InternalErrorCode(1994, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitInQuery = new InternalErrorCode(1995, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitInLock = new InternalErrorCode(1996, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TaskRetNoObjectRequired = new InternalErrorCode(1997, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AsyncLacksAwaits = new InternalErrorCode(1998, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_FileNotFound = new InternalErrorCode(2001, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_FileAlreadyIncluded = new InternalErrorCode(2002, DiagnosticSeverity.Warning);
        //public static readonly InternalErrorCode ERR_DuplicateResponseFile = new InternalErrorCode(2003, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoFileSpec = new InternalErrorCode(2005, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SwitchNeedsString = new InternalErrorCode(2006, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadSwitch = new InternalErrorCode(2007, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NoSources = new InternalErrorCode(2008, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_OpenResponseFile = new InternalErrorCode(2011, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantOpenFileWrite = new InternalErrorCode(2012, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadBaseNumber = new InternalErrorCode(2013, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode WRN_UseNewSwitch = new InternalErrorCode(2014, DiagnosticSeverity.Warning);    //unused.
        public static readonly InternalErrorCode ERR_BinaryFile = new InternalErrorCode(2015, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode FTL_BadCodepage = new InternalErrorCode(2016, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoMainOnDLL = new InternalErrorCode(2017, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode FTL_NoMessagesDLL = new InternalErrorCode(2018, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode FTL_InvalidTarget = new InternalErrorCode(2019, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_BadTargetForSecondInputSet = new InternalErrorCode(2020, DiagnosticSeverity.Error);    Roslyn doesn't support building two binaries at once!
        public static readonly InternalErrorCode FTL_InvalidInputFileName = new InternalErrorCode(2021, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoSourcesInLastInputSet = new InternalErrorCode(2022, DiagnosticSeverity.Error);       Roslyn doesn't support building two binaries at once!
        public static readonly InternalErrorCode WRN_NoConfigNotOnCommandLine = new InternalErrorCode(2023, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_InvalidFileAlignment = new InternalErrorCode(2024, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoDebugSwitchSourceMap = new InternalErrorCode(2026, DiagnosticSeverity.Error);    no sourcemap support in Roslyn.
        //public static readonly InternalErrorCode ERR_SourceMapFileBinary = new InternalErrorCode(2027, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DefineIdentifierRequired = new InternalErrorCode(2029, DiagnosticSeverity.Warning);
        //public static readonly InternalErrorCode ERR_InvalidSourceMap = new InternalErrorCode(2030, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_NoSourceMapFile = new InternalErrorCode(2031, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_IllegalOptionChar = new InternalErrorCode(2032, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode FTL_OutputFileExists = new InternalErrorCode(2033, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OneAliasPerReference = new InternalErrorCode(2034, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SwitchNeedsNumber = new InternalErrorCode(2035, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingDebugSwitch = new InternalErrorCode(2036, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ComRefCallInExpressionTree = new InternalErrorCode(2037, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_BadUILang = new InternalErrorCode(2038, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_InvalidFormatForGuidForOption = new InternalErrorCode(2039, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingGuidForOption = new InternalErrorCode(2040, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidOutputName = new InternalErrorCode(2041, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidDebugInformationFormat = new InternalErrorCode(2042, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LegacyObjectIdSyntax = new InternalErrorCode(2043, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SourceLinkRequiresPdb = new InternalErrorCode(2044, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CannotEmbedWithoutPdb = new InternalErrorCode(2045, DiagnosticSeverity.Error);
        // unused 2046-2999
        public static readonly InternalErrorCode WRN_CLS_NoVarArgs = new InternalErrorCode(3000, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_BadArgType = new InternalErrorCode(3001, DiagnosticSeverity.Warning); // Requires SymbolDistinguisher.
        public static readonly InternalErrorCode WRN_CLS_BadReturnType = new InternalErrorCode(3002, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_BadFieldPropType = new InternalErrorCode(3003, DiagnosticSeverity.Warning);
        // public static readonly InternalErrorCode WRN_CLS_BadUnicode = new InternalErrorCode(3004, DiagnosticSeverity.Warning); //unused
        public static readonly InternalErrorCode WRN_CLS_BadIdentifierCase = new InternalErrorCode(3005, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_OverloadRefOut = new InternalErrorCode(3006, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_OverloadUnnamed = new InternalErrorCode(3007, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_BadIdentifier = new InternalErrorCode(3008, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_BadBase = new InternalErrorCode(3009, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_BadInterfaceMember = new InternalErrorCode(3010, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_NoAbstractMembers = new InternalErrorCode(3011, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_NotOnModules = new InternalErrorCode(3012, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_ModuleMissingCLS = new InternalErrorCode(3013, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_AssemblyNotCLS = new InternalErrorCode(3014, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_BadAttributeType = new InternalErrorCode(3015, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_ArrayArgumentToAttribute = new InternalErrorCode(3016, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_NotOnModules2 = new InternalErrorCode(3017, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_IllegalTrueInFalse = new InternalErrorCode(3018, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_MeaninglessOnPrivateType = new InternalErrorCode(3019, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_AssemblyNotCLS2 = new InternalErrorCode(3021, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_MeaninglessOnParam = new InternalErrorCode(3022, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_MeaninglessOnReturn = new InternalErrorCode(3023, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_BadTypeVar = new InternalErrorCode(3024, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_VolatileField = new InternalErrorCode(3026, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CLS_BadInterface = new InternalErrorCode(3027, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode FTL_BadChecksumAlgorithm = new InternalErrorCode(3028, DiagnosticSeverity.Error);
        #endregion diagnostics introduced in C# 4 and earlier

        // unused 3029-3999

        #region diagnostics introduced in C# 5
        // 4000 unused
        public static readonly InternalErrorCode ERR_BadAwaitArgIntrinsic = new InternalErrorCode(4001, DiagnosticSeverity.Error);
        // 4002 unused
        public static readonly InternalErrorCode ERR_BadAwaitAsIdentifier = new InternalErrorCode(4003, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AwaitInUnsafeContext = new InternalErrorCode(4004, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnsafeAsyncArgType = new InternalErrorCode(4005, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VarargsAsync = new InternalErrorCode(4006, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ByRefTypeAndAwait = new InternalErrorCode(4007, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitArgVoidCall = new InternalErrorCode(4008, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NonTaskMainCantBeAsync = new InternalErrorCode(4009, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantConvAsyncAnonFuncReturns = new InternalErrorCode(4010, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaiterPattern = new InternalErrorCode(4011, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadSpecialByRefLocal = new InternalErrorCode(4012, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SpecialByRefInLambda = new InternalErrorCode(4013, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnobservedAwaitableExpression = new InternalErrorCode(4014, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_SynchronizedAsyncMethod = new InternalErrorCode(4015, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAsyncReturnExpression = new InternalErrorCode(4016, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConversionForCallerLineNumberParam = new InternalErrorCode(4017, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConversionForCallerFilePathParam = new InternalErrorCode(4018, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConversionForCallerMemberNameParam = new InternalErrorCode(4019, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadCallerLineNumberParamWithoutDefaultValue = new InternalErrorCode(4020, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadCallerFilePathParamWithoutDefaultValue = new InternalErrorCode(4021, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadCallerMemberNameParamWithoutDefaultValue = new InternalErrorCode(4022, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadPrefer32OnLib = new InternalErrorCode(4023, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_CallerLineNumberParamForUnconsumedLocation = new InternalErrorCode(4024, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CallerFilePathParamForUnconsumedLocation = new InternalErrorCode(4025, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CallerMemberNameParamForUnconsumedLocation = new InternalErrorCode(4026, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DoesntImplementAwaitInterface = new InternalErrorCode(4027, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitArg_NeedSystem = new InternalErrorCode(4028, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantReturnVoid = new InternalErrorCode(4029, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SecurityCriticalOrSecuritySafeCriticalOnAsync = new InternalErrorCode(4030, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SecurityCriticalOrSecuritySafeCriticalOnAsyncInClassOrStruct = new InternalErrorCode(4031, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitWithoutAsyncMethod = new InternalErrorCode(4032, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitWithoutVoidAsyncMethod = new InternalErrorCode(4033, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitWithoutAsyncLambda = new InternalErrorCode(4034, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_BadAwaitWithoutAsyncAnonMeth = new InternalErrorCode(4035, DiagnosticSeverity.Error);         Merged with ERR_BadAwaitWithoutAsyncLambda in Roslyn
        public static readonly InternalErrorCode ERR_NoSuchMemberOrExtensionNeedUsing = new InternalErrorCode(4036, DiagnosticSeverity.Error);
        #endregion diagnostics introduced in C# 5

        // unused 4037-4999

        #region diagnostics introduced in C# 6
        // public static readonly InternalErrorCode WRN_UnknownOption = new InternalErrorCode(5000, DiagnosticSeverity.Warning);   //unused in Roslyn
        public static readonly InternalErrorCode ERR_NoEntryPoint = new InternalErrorCode(5001, DiagnosticSeverity.Error);

        // huge gap here; available 5002-6999

        public static readonly InternalErrorCode ERR_UnexpectedAliasedName = new InternalErrorCode(7000, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnexpectedGenericName = new InternalErrorCode(7002, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnexpectedUnboundGenericName = new InternalErrorCode(7003, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GlobalStatement = new InternalErrorCode(7006, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadUsingType = new InternalErrorCode(7007, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReservedAssemblyName = new InternalErrorCode(7008, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PPReferenceFollowsToken = new InternalErrorCode(7009, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpectedPPFile = new InternalErrorCode(7010, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReferenceDirectiveOnlyAllowedInScripts = new InternalErrorCode(7011, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NameNotInContextPossibleMissingReference = new InternalErrorCode(7012, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MetadataNameTooLong = new InternalErrorCode(7013, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributesNotAllowed = new InternalErrorCode(7014, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExternAliasNotAllowed = new InternalErrorCode(7015, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConflictingAliasAndDefinition = new InternalErrorCode(7016, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GlobalDefinitionOrStatementExpected = new InternalErrorCode(7017, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpectedSingleScript = new InternalErrorCode(7018, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RecursivelyTypedVariable = new InternalErrorCode(7019, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_YieldNotAllowedInScript = new InternalErrorCode(7020, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NamespaceNotAllowedInScript = new InternalErrorCode(7021, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_MainIgnored = new InternalErrorCode(7022, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_StaticInAsOrIs = new InternalErrorCode(7023, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidDelegateType = new InternalErrorCode(7024, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadVisEventType = new InternalErrorCode(7025, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GlobalAttributesNotAllowed = new InternalErrorCode(7026, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PublicKeyFileFailure = new InternalErrorCode(7027, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PublicKeyContainerFailure = new InternalErrorCode(7028, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FriendRefSigningMismatch = new InternalErrorCode(7029, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CannotPassNullForFriendAssembly = new InternalErrorCode(7030, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SignButNoPrivateKey = new InternalErrorCode(7032, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DelaySignButNoKey = new InternalErrorCode(7033, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_InvalidVersionFormat = new InternalErrorCode(7034, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_InvalidVersionFormat = new InternalErrorCode(7035, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_NoCorrespondingArgument = new InternalErrorCode(7036, DiagnosticSeverity.Error);
        // Moot: public static readonly InternalErrorCode WRN_DestructorIsNotFinalizer = new InternalErrorCode(7037, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ModuleEmitFailure = new InternalErrorCode(7038, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_NameIllegallyOverrides2 = new InternalErrorCode(7039, DiagnosticSeverity.Error); // Not used anymore due to 'Single Meaning' relaxation changes
        // public static readonly InternalErrorCode ERR_NameIllegallyOverrides3 = new InternalErrorCode(7040, DiagnosticSeverity.Error); // Not used anymore due to 'Single Meaning' relaxation changes
        public static readonly InternalErrorCode ERR_ResourceFileNameNotUnique = new InternalErrorCode(7041, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DllImportOnGenericMethod = new InternalErrorCode(7042, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EncUpdateFailedMissingAttribute = new InternalErrorCode(7043, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_ParameterNotValidForType = new InternalErrorCode(7045, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributeParameterRequired1 = new InternalErrorCode(7046, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributeParameterRequired2 = new InternalErrorCode(7047, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SecurityAttributeMissingAction = new InternalErrorCode(7048, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SecurityAttributeInvalidAction = new InternalErrorCode(7049, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SecurityAttributeInvalidActionAssembly = new InternalErrorCode(7050, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SecurityAttributeInvalidActionTypeOrMethod = new InternalErrorCode(7051, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PrincipalPermissionInvalidAction = new InternalErrorCode(7052, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FeatureNotValidInExpressionTree = new InternalErrorCode(7053, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MarshalUnmanagedTypeNotValidForFields = new InternalErrorCode(7054, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MarshalUnmanagedTypeOnlyValidForFields = new InternalErrorCode(7055, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PermissionSetAttributeInvalidFile = new InternalErrorCode(7056, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PermissionSetAttributeFileReadError = new InternalErrorCode(7057, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidVersionFormat2 = new InternalErrorCode(7058, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidAssemblyCultureForExe = new InternalErrorCode(7059, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_AsyncBeforeVersionFive = new InternalErrorCode(7060, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateAttributeInNetModule = new InternalErrorCode(7061, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode WRN_PDBConstantStringValueTooLong = new InternalErrorCode(7063, DiagnosticSeverity.Warning);     gave up on this warning
        public static readonly InternalErrorCode ERR_CantOpenIcon = new InternalErrorCode(7064, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ErrorBuildingWin32Resources = new InternalErrorCode(7065, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IteratorInInteractive = new InternalErrorCode(7066, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAttributeParamDefaultArgument = new InternalErrorCode(7067, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingTypeInSource = new InternalErrorCode(7068, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingTypeInAssembly = new InternalErrorCode(7069, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SecurityAttributeInvalidTarget = new InternalErrorCode(7070, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidAssemblyName = new InternalErrorCode(7071, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_PartialTypesBeforeVersionTwo = new InternalErrorCode(7072, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_PartialMethodsBeforeVersionThree = new InternalErrorCode(7073, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_QueryBeforeVersionThree = new InternalErrorCode(7074, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_AnonymousTypeBeforeVersionThree = new InternalErrorCode(7075, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ImplicitArrayBeforeVersionThree = new InternalErrorCode(7076, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ObjectInitializerBeforeVersionThree = new InternalErrorCode(7077, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_LambdaBeforeVersionThree = new InternalErrorCode(7078, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoTypeDefFromModule = new InternalErrorCode(7079, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_CallerFilePathPreferredOverCallerMemberName = new InternalErrorCode(7080, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CallerLineNumberPreferredOverCallerMemberName = new InternalErrorCode(7081, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_CallerLineNumberPreferredOverCallerFilePath = new InternalErrorCode(7082, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_InvalidDynamicCondition = new InternalErrorCode(7083, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_WinRtEventPassedByRef = new InternalErrorCode(7084, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ByRefReturnUnsupported = new InternalErrorCode(7085, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NetModuleNameMismatch = new InternalErrorCode(7086, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadModuleName = new InternalErrorCode(7087, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadCompilationOptionValue = new InternalErrorCode(7088, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAppConfigPath = new InternalErrorCode(7089, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AssemblyAttributeFromModuleIsOverridden = new InternalErrorCode(7090, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CmdOptionConflictsSource = new InternalErrorCode(7091, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FixedBufferTooManyDimensions = new InternalErrorCode(7092, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantReadConfigFile = new InternalErrorCode(7093, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitInCatchFilter = new InternalErrorCode(7094, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_FilterIsConstantTrue = new InternalErrorCode(7095, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_EncNoPIAReference = new InternalErrorCode(7096, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_EncNoDynamicOperation = new InternalErrorCode(7097, DiagnosticSeverity.Error);   // dynamic operations are now allowed
        public static readonly InternalErrorCode ERR_LinkedNetmoduleMetadataMustProvideFullPEImage = new InternalErrorCode(7098, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MetadataReferencesNotSupported = new InternalErrorCode(7099, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidAssemblyCulture = new InternalErrorCode(7100, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EncReferenceToAddedMember = new InternalErrorCode(7101, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MutuallyExclusiveOptions = new InternalErrorCode(7102, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidDebugInfo = new InternalErrorCode(7103, DiagnosticSeverity.Error);
        #endregion diagnostics introduced in C# 6

        // unused 7104-8000

        #region more diagnostics introduced in Roslyn (C# 6)
        public static readonly InternalErrorCode WRN_UnimplementedCommandLineSwitch = new InternalErrorCode(8001, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_ReferencedAssemblyDoesNotHaveStrongName = new InternalErrorCode(8002, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_InvalidSignaturePublicKey = new InternalErrorCode(8003, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExportedTypeConflictsWithDeclaration = new InternalErrorCode(8004, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExportedTypesConflict = new InternalErrorCode(8005, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ForwardedTypeConflictsWithDeclaration = new InternalErrorCode(8006, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ForwardedTypesConflict = new InternalErrorCode(8007, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ForwardedTypeConflictsWithExportedType = new InternalErrorCode(8008, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_RefCultureMismatch = new InternalErrorCode(8009, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_AgnosticToMachineModule = new InternalErrorCode(8010, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConflictingMachineModule = new InternalErrorCode(8011, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_ConflictingMachineAssembly = new InternalErrorCode(8012, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CryptoHashFailed = new InternalErrorCode(8013, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingNetModuleReference = new InternalErrorCode(8014, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NetModuleNameMustBeUnique = new InternalErrorCode(8015, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnsupportedTransparentIdentifierAccess = new InternalErrorCode(8016, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ParamDefaultValueDiffersFromAttribute = new InternalErrorCode(8017, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnqualifiedNestedTypeInCref = new InternalErrorCode(8018, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode HDN_UnusedUsingDirective = new InternalErrorCode(8019, DiagnosticSeverity.Hidden);
        public static readonly InternalErrorCode HDN_UnusedExternAlias = new InternalErrorCode(8020, DiagnosticSeverity.Hidden);
        public static readonly InternalErrorCode WRN_NoRuntimeMetadataVersion = new InternalErrorCode(8021, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion1 = new InternalErrorCode(8022, DiagnosticSeverity.Error);        // Note: one per version to make telemetry easier
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion2 = new InternalErrorCode(8023, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion3 = new InternalErrorCode(8024, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion4 = new InternalErrorCode(8025, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion5 = new InternalErrorCode(8026, DiagnosticSeverity.Error);
        // ERR_FeatureNotAvailableInVersion6 is below
        public static readonly InternalErrorCode ERR_FieldHasMultipleDistinctConstantValues = new InternalErrorCode(8027, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ComImportWithInitializers = new InternalErrorCode(8028, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_PdbLocalNameTooLong = new InternalErrorCode(8029, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_RetNoObjectRequiredLambda = new InternalErrorCode(8030, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TaskRetNoObjectRequiredLambda = new InternalErrorCode(8031, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AnalyzerCannotBeCreated = new InternalErrorCode(8032, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NoAnalyzerInAssembly = new InternalErrorCode(8033, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_UnableToLoadAnalyzer = new InternalErrorCode(8034, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_CantReadRulesetFile = new InternalErrorCode(8035, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadPdbData = new InternalErrorCode(8036, DiagnosticSeverity.Error);
        // available 8037-8039
        public static readonly InternalErrorCode INF_UnableToLoadSomeTypesInAnalyzer = new InternalErrorCode(8040, DiagnosticSeverity.Info);
        // available 8041-8049
        public static readonly InternalErrorCode ERR_InitializerOnNonAutoProperty = new InternalErrorCode(8050, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AutoPropertyMustHaveGetAccessor = new InternalErrorCode(8051, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AutoPropertyInitializerInInterface = new InternalErrorCode(8052, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_EnumsCantContainDefaultConstructor = new InternalErrorCode(8054, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EncodinglessSyntaxTree = new InternalErrorCode(8055, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_AccessorListAndExpressionBody = new InternalErrorCode(8056, DiagnosticSeverity.Error); Deprecated in favor of ERR_BlockBodyAndExpressionBody
        public static readonly InternalErrorCode ERR_BlockBodyAndExpressionBody = new InternalErrorCode(8057, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FeatureIsExperimental = new InternalErrorCode(8058, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion6 = new InternalErrorCode(8059, DiagnosticSeverity.Error);
        // available 8062-8069
        public static readonly InternalErrorCode ERR_SwitchFallOut = new InternalErrorCode(8070, DiagnosticSeverity.Error);
        // available = 8071,
        public static readonly InternalErrorCode ERR_NullPropagatingOpInExpressionTree = new InternalErrorCode(8072, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NubExprIsConstBool2 = new InternalErrorCode(8073, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DictionaryInitializerInExpressionTree = new InternalErrorCode(8074, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExtensionCollectionElementInitializerInExpressionTree = new InternalErrorCode(8075, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnclosedExpressionHole = new InternalErrorCode(8076, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SingleLineCommentInExpressionHole = new InternalErrorCode(8077, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InsufficientStack = new InternalErrorCode(8078, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UseDefViolationProperty = new InternalErrorCode(8079, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AutoPropertyMustOverrideSet = new InternalErrorCode(8080, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionHasNoName = new InternalErrorCode(8081, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SubexpressionNotInNameof = new InternalErrorCode(8082, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AliasQualifiedNameNotAnExpression = new InternalErrorCode(8083, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NameofMethodGroupWithTypeParameters = new InternalErrorCode(8084, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoAliasHere = new InternalErrorCode(8085, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnescapedCurly = new InternalErrorCode(8086, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EscapedCurly = new InternalErrorCode(8087, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TrailingWhitespaceInFormatSpecifier = new InternalErrorCode(8088, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EmptyFormatSpecifier = new InternalErrorCode(8089, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ErrorInReferencedAssembly = new InternalErrorCode(8090, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExternHasConstructorInitializer = new InternalErrorCode(8091, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionOrDeclarationExpected = new InternalErrorCode(8092, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NameofExtensionMethod = new InternalErrorCode(8093, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AlignmentMagnitude = new InternalErrorCode(8094, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ConstantStringTooLong = new InternalErrorCode(8095, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DebugEntryPointNotSourceMethodDefinition = new InternalErrorCode(8096, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LoadDirectiveOnlyAllowedInScripts = new InternalErrorCode(8097, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PPLoadFollowsToken = new InternalErrorCode(8098, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SourceFileReferencesNotSupported = new InternalErrorCode(8099, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAwaitInStaticVariableInitializer = new InternalErrorCode(8100, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidPathMap = new InternalErrorCode(8101, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PublicSignButNoKey = new InternalErrorCode(8102, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TooManyUserStrings = new InternalErrorCode(8103, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PeWritingFailure = new InternalErrorCode(8104, DiagnosticSeverity.Error);
        #endregion diagnostics introduced in Roslyn (C# 6)

        #region diagnostics introduced in C# 6 updates
        public static readonly InternalErrorCode WRN_AttributeIgnoredWhenPublicSigning = new InternalErrorCode(8105, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_OptionMustBeAbsolutePath = new InternalErrorCode(8106, DiagnosticSeverity.Error);
        #endregion diagnostics introduced in C# 6 updates

        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion7 = new InternalErrorCode(8107, DiagnosticSeverity.Error);

        #region diagnostics for local functions introduced in C# 7
        public static readonly InternalErrorCode ERR_DynamicLocalFunctionParamsParameter = new InternalErrorCode(8108, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsLocalFunction = new InternalErrorCode(8110, DiagnosticSeverity.Error);
        #endregion diagnostics for local functions introduced in C# 7

        #region diagnostics for instrumentation

        public static readonly InternalErrorCode ERR_InvalidInstrumentationKind = new InternalErrorCode(8111, DiagnosticSeverity.Error);

        #endregion

        public static readonly InternalErrorCode ERR_LocalFunctionMissingBody = new InternalErrorCode(8112, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidHashAlgorithmName = new InternalErrorCode(8113, DiagnosticSeverity.Error);

        // Unused 8113, 8114, 8115

        #region diagnostics for pattern-matching introduced in C# 7
        public static readonly InternalErrorCode ERR_ThrowMisplaced = new InternalErrorCode(8115, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PatternNullableType = new InternalErrorCode(8116, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadPatternExpression = new InternalErrorCode(8117, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SwitchExpressionValueExpected = new InternalErrorCode(8119, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SwitchCaseSubsumed = new InternalErrorCode(8120, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PatternWrongType = new InternalErrorCode(8121, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsIsMatch = new InternalErrorCode(8122, DiagnosticSeverity.Error);
        #endregion diagnostics for pattern-matching introduced in C# 7

        #region tuple diagnostics introduced in C# 7
        public static readonly InternalErrorCode WRN_TupleLiteralNameMismatch = new InternalErrorCode(8123, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_TupleTooFewElements = new InternalErrorCode(8124, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TupleReservedElementName = new InternalErrorCode(8125, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TupleReservedElementNameAnyPosition = new InternalErrorCode(8126, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TupleDuplicateElementName = new InternalErrorCode(8127, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PredefinedTypeMemberNotFoundInAssembly = new InternalErrorCode(8128, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingDeconstruct = new InternalErrorCode(8129, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TypeInferenceFailedForImplicitlyTypedDeconstructionVariable = new InternalErrorCode(8130, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeconstructRequiresExpression = new InternalErrorCode(8131, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeconstructWrongCardinality = new InternalErrorCode(8132, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CannotDeconstructDynamic = new InternalErrorCode(8133, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeconstructTooFewElements = new InternalErrorCode(8134, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConversionNotTupleCompatible = new InternalErrorCode(8135, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeconstructionVarFormDisallowsSpecificType = new InternalErrorCode(8136, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TupleElementNamesAttributeMissing = new InternalErrorCode(8137, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitTupleElementNamesAttribute = new InternalErrorCode(8138, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantChangeTupleNamesOnOverride = new InternalErrorCode(8139, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicateInterfaceWithTupleNamesInBaseList = new InternalErrorCode(8140, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ImplBadTupleNames = new InternalErrorCode(8141, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodInconsistentTupleNames = new InternalErrorCode(8142, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsTupleLiteral = new InternalErrorCode(8143, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsTupleConversion = new InternalErrorCode(8144, DiagnosticSeverity.Error);
        #endregion tuple diagnostics introduced in C# 7

        #region diagnostics for ref locals and ref returns introduced in C# 7
        public static readonly InternalErrorCode ERR_AutoPropertyCannotBeRefReturning = new InternalErrorCode(8145, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefPropertyMustHaveGetAccessor = new InternalErrorCode(8146, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefPropertyCannotHaveSetAccessor = new InternalErrorCode(8147, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantChangeRefReturnOnOverride = new InternalErrorCode(8148, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MustNotHaveRefReturn = new InternalErrorCode(8149, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MustHaveRefReturn = new InternalErrorCode(8150, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnMustHaveIdentityConversion = new InternalErrorCode(8151, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CloseUnimplementedInterfaceMemberWrongRefReturn = new InternalErrorCode(8152, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturningCallInExpressionTree = new InternalErrorCode(8153, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadIteratorReturnRef = new InternalErrorCode(8154, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadRefReturnExpressionTree = new InternalErrorCode(8155, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnLvalueExpected = new InternalErrorCode(8156, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnNonreturnableLocal = new InternalErrorCode(8157, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnNonreturnableLocal2 = new InternalErrorCode(8158, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnRangeVariable = new InternalErrorCode(8159, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnReadonly = new InternalErrorCode(8160, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnReadonlyStatic = new InternalErrorCode(8161, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnReadonly2 = new InternalErrorCode(8162, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnReadonlyStatic2 = new InternalErrorCode(8163, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_RefReturnCall = new InternalErrorCode(8164, DiagnosticSeverity.Error);                we use more general ERR_EscapeCall now
        // public static readonly InternalErrorCode ERR_RefReturnCall2 = new InternalErrorCode(8165, DiagnosticSeverity.Error);               we use more general ERR_EscapeCall2 now
        public static readonly InternalErrorCode ERR_RefReturnParameter = new InternalErrorCode(8166, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnParameter2 = new InternalErrorCode(8167, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnLocal = new InternalErrorCode(8168, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnLocal2 = new InternalErrorCode(8169, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnStructThis = new InternalErrorCode(8170, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InitializeByValueVariableWithReference = new InternalErrorCode(8171, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InitializeByReferenceVariableWithValue = new InternalErrorCode(8172, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefAssignmentMustHaveIdentityConversion = new InternalErrorCode(8173, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ByReferenceVariableMustBeInitialized = new InternalErrorCode(8174, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnonDelegateCantUseLocal = new InternalErrorCode(8175, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadIteratorLocalType = new InternalErrorCode(8176, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAsyncLocalType = new InternalErrorCode(8177, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturningCallAndAwait = new InternalErrorCode(8178, DiagnosticSeverity.Error);
        #endregion diagnostics for ref locals and ref returns introduced in C# 7

        #region stragglers for C# 7
        public static readonly InternalErrorCode ERR_PredefinedValueTupleTypeNotFound = new InternalErrorCode(8179, DiagnosticSeverity.Error); // We need a specific error code for ValueTuple as an IDE codefix depends on it (AddNuget)
        public static readonly InternalErrorCode ERR_SemiOrLBraceOrArrowExpected = new InternalErrorCode(8180, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NewWithTupleTypeSyntax = new InternalErrorCode(8181, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PredefinedValueTupleTypeMustBeStruct = new InternalErrorCode(8182, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DiscardTypeInferenceFailed = new InternalErrorCode(8183, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MixedDeconstructionUnsupported = new InternalErrorCode(8184, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeclarationExpressionNotPermitted = new InternalErrorCode(8185, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MustDeclareForeachIteration = new InternalErrorCode(8186, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TupleElementNamesInDeconstruction = new InternalErrorCode(8187, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsThrowExpression = new InternalErrorCode(8188, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DelegateRefMismatch = new InternalErrorCode(8189, DiagnosticSeverity.Error);
        #endregion stragglers for C# 7

        #region diagnostics for parse options
        public static readonly InternalErrorCode ERR_BadSourceCodeKind = new InternalErrorCode(8190, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDocumentationMode = new InternalErrorCode(8191, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadLanguageVersion = new InternalErrorCode(8192, DiagnosticSeverity.Error);
        #endregion

        // Unused 8193-8195

        #region diagnostics for out var
        public static readonly InternalErrorCode ERR_ImplicitlyTypedOutVariableUsedInTheSameArgumentList = new InternalErrorCode(8196, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TypeInferenceFailedForImplicitlyTypedOutVariable = new InternalErrorCode(8197, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsOutVariable = new InternalErrorCode(8198, DiagnosticSeverity.Error);
        #endregion diagnostics for out var

        #region more stragglers for C# 7
        public static readonly InternalErrorCode ERR_VarInvocationLvalueReserved = new InternalErrorCode(8199, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ExpressionVariableInConstructorOrFieldInitializer = new InternalErrorCode(8200, DiagnosticSeverity.Error);
        //public static readonly InternalErrorCode ERR_ExpressionVariableInQueryClause = new InternalErrorCode(8201, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PublicSignNetModule = new InternalErrorCode(8202, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAssemblyName = new InternalErrorCode(8203, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadAsyncMethodBuilderTaskProperty = new InternalErrorCode(8204, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributesInLocalFuncDecl = new InternalErrorCode(8205, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TypeForwardedToMultipleAssemblies = new InternalErrorCode(8206, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsDiscard = new InternalErrorCode(8207, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PatternDynamicType = new InternalErrorCode(8208, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VoidAssignment = new InternalErrorCode(8209, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VoidInTuple = new InternalErrorCode(8210, DiagnosticSeverity.Error);
        #endregion more stragglers for C# 7

        #region diagnostics introduced for C# 7.1

        public static readonly InternalErrorCode ERR_Merge_conflict_marker_encountered = new InternalErrorCode(8300, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidPreprocessingSymbol = new InternalErrorCode(8301, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion7_1 = new InternalErrorCode(8302, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LanguageVersionCannotHaveLeadingZeroes = new InternalErrorCode(8303, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CompilerAndLanguageVersion = new InternalErrorCode(8304, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_Experimental = new InternalErrorCode(8305, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_TupleInferredNamesNotAvailable = new InternalErrorCode(8306, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TypelessTupleInAs = new InternalErrorCode(8307, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_NoRefOutWhenRefOnly = new InternalErrorCode(8308, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoNetModuleOutputWhenRefOutOrRefOnly = new InternalErrorCode(8309, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadOpOnNullOrDefault = new InternalErrorCode(8310, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDynamicMethodArgDefaultLiteral = new InternalErrorCode(8311, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultLiteralNotValid = new InternalErrorCode(8312, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultInSwitch = new InternalErrorCode(8313, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PatternWrongGenericTypeInVersion = new InternalErrorCode(8314, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AmbigBinaryOpsOnDefault = new InternalErrorCode(8315, DiagnosticSeverity.Error);

        #endregion diagnostics introduced for C# 7.1

        #region diagnostics introduced for C# 7.2
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion7_2 = new InternalErrorCode(8320, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_UnreferencedLocalFunction = new InternalErrorCode(8321, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DynamicLocalFunctionTypeParameter = new InternalErrorCode(8322, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadNonTrailingNamedArgument = new InternalErrorCode(8323, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NamedArgumentSpecificationBeforeFixedArgumentInDynamicInvocation = new InternalErrorCode(8324, DiagnosticSeverity.Error);
        #endregion diagnostics introduced for C# 7.2

        #region diagnostics introduced for `ref readonly`, `ref conditional` and `ref-like` features in C# 7.2
        public static readonly InternalErrorCode ERR_RefConditionalAndAwait = new InternalErrorCode(8325, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefConditionalNeedsTwoRefs = new InternalErrorCode(8326, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefConditionalDifferentTypes = new InternalErrorCode(8327, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadParameterModifiers = new InternalErrorCode(8328, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_RefReadonlyNotField = new InternalErrorCode(8329, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReadonlyNotField2 = new InternalErrorCode(8330, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssignReadonlyNotField = new InternalErrorCode(8331, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AssignReadonlyNotField2 = new InternalErrorCode(8332, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnReadonlyNotField = new InternalErrorCode(8333, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnReadonlyNotField2 = new InternalErrorCode(8334, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExplicitReservedAttr = new InternalErrorCode(8335, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TypeReserved = new InternalErrorCode(8336, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefExtensionMustBeValueTypeOrConstrainedToOne = new InternalErrorCode(8337, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InExtensionMustBeValueType = new InternalErrorCode(8338, DiagnosticSeverity.Error);
        // public static readonly InternalErrorCode ERR_BadParameterModifiersOrder = new InternalErrorCode(8339, DiagnosticSeverity.Error); // Modifier ordering is relaxed

        public static readonly InternalErrorCode ERR_FieldsInRoStruct = new InternalErrorCode(8340, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AutoPropsInRoStruct = new InternalErrorCode(8341, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FieldlikeEventsInRoStruct = new InternalErrorCode(8342, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefStructInterfaceImpl = new InternalErrorCode(8343, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadSpecialByRefIterator = new InternalErrorCode(8344, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FieldAutoPropCantBeByRefLike = new InternalErrorCode(8345, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StackAllocConversionNotPossible = new InternalErrorCode(8346, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_EscapeCall = new InternalErrorCode(8347, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EscapeCall2 = new InternalErrorCode(8348, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EscapeOther = new InternalErrorCode(8349, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CallArgMixing = new InternalErrorCode(8350, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MismatchedRefEscapeInTernary = new InternalErrorCode(8351, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EscapeLocal = new InternalErrorCode(8352, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_EscapeStackAlloc = new InternalErrorCode(8353, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefReturnThis = new InternalErrorCode(8354, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_OutAttrOnInParam = new InternalErrorCode(8355, DiagnosticSeverity.Error);
        #endregion diagnostics introduced for `ref readonly`, `ref conditional` and `ref-like` features in C# 7.2

        public static readonly InternalErrorCode ERR_PredefinedValueTupleTypeAmbiguous3 = new InternalErrorCode(8356, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidVersionFormatDeterministic = new InternalErrorCode(8357, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributeCtorInParameter = new InternalErrorCode(8358, DiagnosticSeverity.Error);

        #region diagnostics for FilterIsConstant warning message fix
        public static readonly InternalErrorCode WRN_FilterIsConstantFalse = new InternalErrorCode(8359, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_FilterIsConstantFalseRedundantTryCatch = new InternalErrorCode(8360, DiagnosticSeverity.Warning);
        #endregion diagnostics for FilterIsConstant warning message fix

        public static readonly InternalErrorCode ERR_ConditionalInInterpolation = new InternalErrorCode(8361, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantUseVoidInArglist = new InternalErrorCode(8362, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InDynamicMethodArg = new InternalErrorCode(8364, DiagnosticSeverity.Error);

        #region diagnostics introduced for C# 7.3
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion7_3 = new InternalErrorCode(8370, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_AttributesOnBackingFieldsNotAvailable = new InternalErrorCode(8371, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DoNotUseFixedBufferAttrOnProperty = new InternalErrorCode(8372, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefLocalOrParamExpected = new InternalErrorCode(8373, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RefAssignNarrower = new InternalErrorCode(8374, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_NewBoundWithUnmanaged = new InternalErrorCode(8375, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnmanagedConstraintMustBeFirst = new InternalErrorCode(8376, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnmanagedConstraintNotSatisfied = new InternalErrorCode(8377, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_CantUseInOrOutInArglist = new InternalErrorCode(8378, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ConWithUnmanagedCon = new InternalErrorCode(8379, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UnmanagedBoundWithClass = new InternalErrorCode(8380, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_InvalidStackAllocArray = new InternalErrorCode(8381, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_ExpressionTreeContainsTupleBinOp = new InternalErrorCode(8382, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_TupleBinopLiteralNameMismatch = new InternalErrorCode(8383, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_TupleSizesMismatchForBinOps = new InternalErrorCode(8384, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExprCannotBeFixed = new InternalErrorCode(8385, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidObjectCreation = new InternalErrorCode(8386, DiagnosticSeverity.Error);
        #endregion diagnostics introduced for C# 7.3

        public static readonly InternalErrorCode WRN_TypeParameterSameAsOuterMethodTypeParameter = new InternalErrorCode(8387, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_OutVariableCannotBeByRef = new InternalErrorCode(8388, DiagnosticSeverity.Error);

        #region diagnostics introduced for C# 8.0
        public static readonly InternalErrorCode ERR_FeatureNotAvailableInVersion8 = new InternalErrorCode(8400, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AltInterpolatedVerbatimStringsNotAvailable = new InternalErrorCode(8401, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DefaultLiteralConvertedToNullIsNotIntended = new InternalErrorCode(8402, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_IteratorMustBeAsync = new InternalErrorCode(8403, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_NoConvToIAsyncDisp = new InternalErrorCode(8410, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AwaitForEachMissingMember = new InternalErrorCode(8411, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadGetAsyncEnumerator = new InternalErrorCode(8412, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MultipleIAsyncEnumOfT = new InternalErrorCode(8413, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ForEachMissingMemberWrongAsync = new InternalErrorCode(8414, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AwaitForEachMissingMemberWrongAsync = new InternalErrorCode(8415, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadDynamicAwaitForEach = new InternalErrorCode(8416, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConvToIAsyncDispWrongAsync = new InternalErrorCode(8417, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NoConvToIDispWrongAsync = new InternalErrorCode(8418, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PossibleAsyncIteratorWithoutYield = new InternalErrorCode(8419, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PossibleAsyncIteratorWithoutYieldOrAwait = new InternalErrorCode(8420, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticLocalFunctionCannotCaptureVariable = new InternalErrorCode(8421, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_StaticLocalFunctionCannotCaptureThis = new InternalErrorCode(8422, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AttributeNotOnEventAccessor = new InternalErrorCode(8423, DiagnosticSeverity.Error);
        #region diagnostics introduced for recursive patterns
        // 8501, // available
        public static readonly InternalErrorCode ERR_WrongNumberOfSubpatterns = new InternalErrorCode(8502, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PropertyPatternNameMissing = new InternalErrorCode(8503, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MissingPattern = new InternalErrorCode(8504, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultPattern = new InternalErrorCode(8505, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SwitchExpressionNoBestType = new InternalErrorCode(8506, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SingleElementPositionalPatternRequiresDisambiguation = new InternalErrorCode(8507, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_VarMayNotBindToType = new InternalErrorCode(8508, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_SwitchExpressionNotExhaustive = new InternalErrorCode(8509, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_SwitchArmSubsumed = new InternalErrorCode(8510, DiagnosticSeverity.Error);
        // 8511, // available
        public static readonly InternalErrorCode WRN_CaseConstantNamedUnderscore = new InternalErrorCode(8512, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_IsTypeNamedUnderscore = new InternalErrorCode(8513, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ExpressionTreeContainsSwitchExpression = new InternalErrorCode(8514, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_SwitchGoverningExpressionRequiresParens = new InternalErrorCode(8515, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_TupleElementNameMismatch = new InternalErrorCode(8516, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DeconstructParameterNameMismatch = new InternalErrorCode(8517, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IsPatternImpossible = new InternalErrorCode(8518, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_GivenExpressionNeverMatchesPattern = new InternalErrorCode(8519, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_GivenExpressionAlwaysMatchesConstant = new InternalErrorCode(8520, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_PointerTypeInPatternMatching = new InternalErrorCode(8521, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ArgumentNameInITuplePattern = new InternalErrorCode(8522, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DiscardPatternInSwitchStatement = new InternalErrorCode(8523, DiagnosticSeverity.Error);
        #endregion diagnostics introduced for recursive patterns

        public static readonly InternalErrorCode WRN_PossibleNull = new InternalErrorCode(8597, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_IllegalSuppression = new InternalErrorCode(8598, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_IllegalPPWarningSafeOnly = new InternalErrorCode(8599, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_ConvertingNullableToNonNullable = new InternalErrorCode(8600, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullReferenceAssignment = new InternalErrorCode(8601, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullReferenceReceiver = new InternalErrorCode(8602, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullReferenceReturn = new InternalErrorCode(8603, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullReferenceArgument = new InternalErrorCode(8604, DiagnosticSeverity.Warning);
        // Unused 8605-8607
        public static readonly InternalErrorCode WRN_NullabilityMismatchInTypeOnOverride = new InternalErrorCode(8608, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInReturnTypeOnOverride = new InternalErrorCode(8609, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInParameterTypeOnOverride = new InternalErrorCode(8610, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInParameterTypeOnPartial = new InternalErrorCode(8611, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInTypeOnImplicitImplementation = new InternalErrorCode(8612, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInReturnTypeOnImplicitImplementation = new InternalErrorCode(8613, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInParameterTypeOnImplicitImplementation = new InternalErrorCode(8614, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInTypeOnExplicitImplementation = new InternalErrorCode(8615, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInReturnTypeOnExplicitImplementation = new InternalErrorCode(8616, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInParameterTypeOnExplicitImplementation = new InternalErrorCode(8617, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_UninitializedNonNullableField = new InternalErrorCode(8618, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInAssignment = new InternalErrorCode(8619, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInArgument = new InternalErrorCode(8620, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInReturnTypeOfTargetDelegate = new InternalErrorCode(8621, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInParameterTypeOfTargetDelegate = new InternalErrorCode(8622, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_ExplicitNullableAttribute = new InternalErrorCode(8623, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInArgumentForOutput = new InternalErrorCode(8624, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullAsNonNullable = new InternalErrorCode(8625, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_AsOperatorMayReturnNull = new InternalErrorCode(8626, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_NullableUnconstrainedTypeParameter = new InternalErrorCode(8627, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AnnotationDisallowedInObjectCreation = new InternalErrorCode(8628, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NullableValueTypeMayBeNull = new InternalErrorCode(8629, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_NullableOptionNotAvailable = new InternalErrorCode(8630, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInTypeParameterConstraint = new InternalErrorCode(8631, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_MissingNonNullTypesContextForAnnotation = new InternalErrorCode(8632, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInConstraintsOnImplicitImplementation = new InternalErrorCode(8633, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInTypeParameterReferenceTypeConstraint = new InternalErrorCode(8634, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_TripleDotNotAllowed = new InternalErrorCode(8635, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_BadNullableContextOption = new InternalErrorCode(8636, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NullableDirectiveQualifierExpected = new InternalErrorCode(8637, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_ConditionalAccessMayReturnNull = new InternalErrorCode(8638, DiagnosticSeverity.Warning);
        // Unused 8639
        public static readonly InternalErrorCode ERR_ExpressionTreeCantContainRefStruct = new InternalErrorCode(8640, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ElseCannotStartStatement = new InternalErrorCode(8641, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ExpressionTreeCantContainNullCoalescingAssignment = new InternalErrorCode(8642, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInExplicitlyImplementedInterface = new InternalErrorCode(8643, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullabilityMismatchInInterfaceImplementedByBase = new InternalErrorCode(8644, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_DuplicateInterfaceWithNullabilityMismatchInBaseList = new InternalErrorCode(8645, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_DuplicateExplicitImpl = new InternalErrorCode(8646, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_UsingVarInSwitchCase = new InternalErrorCode(8647, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GoToForwardJumpOverUsingVar = new InternalErrorCode(8648, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_GoToBackwardJumpOverUsingVar = new InternalErrorCode(8649, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_IsNullableType = new InternalErrorCode(8650, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AsNullableType = new InternalErrorCode(8651, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FeatureInPreview = new InternalErrorCode(8652, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode WRN_DefaultExpressionMayIntroduceNullT = new InternalErrorCode(8653, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_NullLiteralMayIntroduceNullT = new InternalErrorCode(8654, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_SwitchExpressionNotExhaustiveForNull = new InternalErrorCode(8655, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode WRN_ImplicitCopyInReadOnlyMember = new InternalErrorCode(8656, DiagnosticSeverity.Warning);
        public static readonly InternalErrorCode ERR_StaticMemberCantBeReadOnly = new InternalErrorCode(8657, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AutoSetterCantBeReadOnly = new InternalErrorCode(8658, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_AutoPropertyWithSetterCantBeReadOnly = new InternalErrorCode(8659, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_InvalidPropertyReadOnlyMods = new InternalErrorCode(8660, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DuplicatePropertyReadOnlyMods = new InternalErrorCode(8661, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_FieldLikeEventCantBeReadOnly = new InternalErrorCode(8662, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_PartialMethodReadOnlyDifference = new InternalErrorCode(8663, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ReadOnlyModMissingAccessor = new InternalErrorCode(8664, DiagnosticSeverity.Error);


        public static readonly InternalErrorCode ERR_RuntimeDoesNotSupportDefaultInterfaceImplementation = new InternalErrorCode(8701, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_RuntimeDoesNotSupportDefaultInterfaceImplementationForMember = new InternalErrorCode(8702, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_DefaultInterfaceImplementationModifier = new InternalErrorCode(8703, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_ImplicitImplementationOfNonPublicInterfaceMember = new InternalErrorCode(8704, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_MostSpecificImplementationIsNotFound = new InternalErrorCode(8705, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_LanguageVersionDoesNotSupportDefaultInterfaceImplementationForMember = new InternalErrorCode(8706, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_RuntimeDoesNotSupportProtectedAccessForInterfaceMember = new InternalErrorCode(8707, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NotBaseOrImplementedInterface = new InternalErrorCode(8708, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NotImplementedInBase = new InternalErrorCode(8709, DiagnosticSeverity.Error);
        public static readonly InternalErrorCode ERR_NotDeclaredInBase = new InternalErrorCode(8710, DiagnosticSeverity.Error);

        public static readonly InternalErrorCode ERR_DefaultInterfaceImplementationInNoPIAType = new InternalErrorCode(8711, DiagnosticSeverity.Error);

        #endregion diagnostics introduced for C# 8.0
    }
}
