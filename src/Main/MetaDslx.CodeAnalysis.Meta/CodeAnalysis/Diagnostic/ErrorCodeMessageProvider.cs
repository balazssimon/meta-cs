﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public class ErrorCodeMessageProvider : CommonMessageProvider
    {
        private string _codePrefix;
        private Type _errorCodeType;
        private Dictionary<int, ErrorCode> _errorCodes;

        public ErrorCodeMessageProvider(string codePrefix, Type errorCodeType)
        {
            if (string.IsNullOrWhiteSpace(codePrefix))
            {
                throw new ArgumentException(CodeAnalysisResources.DiagnosticIdCantBeNullOrWhitespace, nameof(codePrefix));
            }
            _codePrefix = codePrefix;
            _errorCodeType = errorCodeType;
            _errorCodes = new Dictionary<int, ErrorCode>();
        }

        public override string CodePrefix => _codePrefix;

        public override Type ErrorCodeType => _errorCodeType;

        public override int ERR_FailedToCreateTempFile => throw new NotImplementedException();

        public override int ERR_MultipleAnalyzerConfigsInSameDir => throw new NotImplementedException();

        public override int ERR_ExpectedSingleScript => throw new NotImplementedException();

        public override int ERR_OpenResponseFile => throw new NotImplementedException();

        public override int ERR_InvalidPathMap => throw new NotImplementedException();

        public override int FTL_InvalidInputFileName => throw new NotImplementedException();

        public override int ERR_FileNotFound => throw new NotImplementedException();

        public override int ERR_NoSourceFile => throw new NotImplementedException();

        public override int ERR_CantOpenFileWrite => throw new NotImplementedException();

        public override int ERR_OutputWriteFailed => throw new NotImplementedException();

        public override int WRN_NoConfigNotOnCommandLine => throw new NotImplementedException();

        public override int ERR_BinaryFile => throw new NotImplementedException();

        public override int WRN_UnableToLoadAnalyzer => throw new NotImplementedException();

        public override int INF_UnableToLoadSomeTypesInAnalyzer => throw new NotImplementedException();

        public override int WRN_AnalyzerCannotBeCreated => throw new NotImplementedException();

        public override int WRN_NoAnalyzerInAssembly => throw new NotImplementedException();

        public override int WRN_AnalyzerReferencesFramework => throw new NotImplementedException();

        public override int ERR_CantReadRulesetFile => throw new NotImplementedException();

        public override int ERR_CompileCancelled => throw new NotImplementedException();

        public override int ERR_BadSourceCodeKind => throw new NotImplementedException();

        public override int ERR_BadDocumentationMode => throw new NotImplementedException();

        public override int ERR_BadCompilationOptionValue => throw new NotImplementedException();

        public override int ERR_MutuallyExclusiveOptions => throw new NotImplementedException();

        public override int ERR_InvalidDebugInformationFormat => throw new NotImplementedException();

        public override int ERR_InvalidFileAlignment => throw new NotImplementedException();

        public override int ERR_InvalidSubsystemVersion => throw new NotImplementedException();

        public override int ERR_InvalidOutputName => throw new NotImplementedException();

        public override int ERR_InvalidInstrumentationKind => throw new NotImplementedException();

        public override int ERR_InvalidHashAlgorithmName => throw new NotImplementedException();

        public override int ERR_MetadataFileNotAssembly => throw new NotImplementedException();

        public override int ERR_MetadataFileNotModule => throw new NotImplementedException();

        public override int ERR_InvalidAssemblyMetadata => throw new NotImplementedException();

        public override int ERR_InvalidModuleMetadata => throw new NotImplementedException();

        public override int ERR_ErrorOpeningAssemblyFile => throw new NotImplementedException();

        public override int ERR_ErrorOpeningModuleFile => throw new NotImplementedException();

        public override int ERR_MetadataFileNotFound => throw new NotImplementedException();

        public override int ERR_MetadataReferencesNotSupported => throw new NotImplementedException();

        public override int ERR_LinkedNetmoduleMetadataMustProvideFullPEImage => throw new NotImplementedException();

        public override int ERR_PublicKeyFileFailure => throw new NotImplementedException();

        public override int ERR_PublicKeyContainerFailure => throw new NotImplementedException();

        public override int ERR_OptionMustBeAbsolutePath => throw new NotImplementedException();

        public override int ERR_CantReadResource => throw new NotImplementedException();

        public override int ERR_CantOpenWin32Resource => throw new NotImplementedException();

        public override int ERR_CantOpenWin32Manifest => throw new NotImplementedException();

        public override int ERR_CantOpenWin32Icon => throw new NotImplementedException();

        public override int ERR_BadWin32Resource => throw new NotImplementedException();

        public override int ERR_ErrorBuildingWin32Resource => throw new NotImplementedException();

        public override int ERR_ResourceNotUnique => throw new NotImplementedException();

        public override int ERR_ResourceFileNameNotUnique => throw new NotImplementedException();

        public override int ERR_ResourceInModule => throw new NotImplementedException();

        public override int ERR_PermissionSetAttributeFileReadError => throw new NotImplementedException();

        public override int ERR_EncodinglessSyntaxTree => throw new NotImplementedException();

        public override int WRN_PdbUsingNameTooLong => throw new NotImplementedException();

        public override int WRN_PdbLocalNameTooLong => throw new NotImplementedException();

        public override int ERR_PdbWritingFailed => throw new NotImplementedException();

        public override int ERR_MetadataNameTooLong => throw new NotImplementedException();

        public override int ERR_EncReferenceToAddedMember => throw new NotImplementedException();

        public override int ERR_TooManyUserStrings => throw new NotImplementedException();

        public override int ERR_PeWritingFailure => throw new NotImplementedException();

        public override int ERR_ModuleEmitFailure => throw new NotImplementedException();

        public override int ERR_EncUpdateFailedMissingAttribute => throw new NotImplementedException();

        public override int ERR_InvalidDebugInfo => throw new NotImplementedException();

        public override int WRN_GeneratorFailedDuringInitialization => throw new NotImplementedException();

        public override int WRN_GeneratorFailedDuringGeneration => throw new NotImplementedException();

        public override int ERR_BadAssemblyName => throw new NotImplementedException();

        public void Add(ErrorCode errorCode)
        {
            _errorCodes.Add(errorCode.Code, errorCode);
        }

        public ErrorCode GetErrorCode(int code)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode;
            else return null;
        }

        public override Microsoft.CodeAnalysis.Diagnostic CreateDiagnostic(DiagnosticInfo info)
        {
            throw new NotImplementedException();
        }

        public override Microsoft.CodeAnalysis.Diagnostic CreateDiagnostic(int code, Location location, params object[] args)
        {
            throw new NotImplementedException();
        }

        public override string GetCategory(int code)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode.Category;
            else return null;
        }

        public override LocalizableString GetDescription(int code)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode.Description;
            else return null;
        }

        public override ReportDiagnostic GetDiagnosticReport(DiagnosticInfo diagnosticInfo, CompilationOptions options)
        {
            throw new NotImplementedException();
        }

        public override string GetErrorDisplayString(ISymbol symbol)
        {
            throw new NotImplementedException();
        }

        public override string GetHelpLink(int code)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode.HelpLinkUri;
            else return null;
        }

        public override LocalizableString GetMessageFormat(int code)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode.MessageFormat;
            else return null;
        }

        public override string GetMessagePrefix(string id, DiagnosticSeverity severity, bool isWarningAsError, CultureInfo? culture)
        {
            throw new NotImplementedException();
        }

        public override DiagnosticSeverity GetSeverity(int code)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode.DefaultSeverity;
            else return DiagnosticSeverity.Error;
        }

        public override LocalizableString GetTitle(int code)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode.Title;
            else return null;
        }

        public override int GetWarningLevel(int code)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode.DefaultSeverity == DiagnosticSeverity.Error ? 0 : 1;
            else return 0;
        }

        public override string LoadMessage(int code, CultureInfo? language)
        {
            if (_errorCodes.TryGetValue(code, out var errorCode)) return errorCode.MessageFormat.ToString();
            else return null;
        }

        public override void ReportAttributeParameterRequired(DiagnosticBag diagnostics, SyntaxNode attributeSyntax, string parameterName)
        {
            throw new NotImplementedException();
        }

        public override void ReportAttributeParameterRequired(DiagnosticBag diagnostics, SyntaxNode attributeSyntax, string parameterName1, string parameterName2)
        {
            throw new NotImplementedException();
        }

        public override void ReportDuplicateMetadataReferenceStrong(DiagnosticBag diagnostics, Location location, MetadataReference reference, AssemblyIdentity identity, MetadataReference equivalentReference, AssemblyIdentity equivalentIdentity)
        {
            throw new NotImplementedException();
        }

        public override void ReportDuplicateMetadataReferenceWeak(DiagnosticBag diagnostics, Location location, MetadataReference reference, AssemblyIdentity identity, MetadataReference equivalentReference, AssemblyIdentity equivalentIdentity)
        {
            throw new NotImplementedException();
        }

        public override void ReportInvalidAttributeArgument(DiagnosticBag diagnostics, SyntaxNode attributeSyntax, int parameterIndex, AttributeData attribute)
        {
            throw new NotImplementedException();
        }

        public override void ReportInvalidNamedArgument(DiagnosticBag diagnostics, SyntaxNode attributeSyntax, int namedArgumentIndex, ITypeSymbol attributeClass, string parameterName)
        {
            throw new NotImplementedException();
        }

        public override void ReportMarshalUnmanagedTypeNotValidForFields(DiagnosticBag diagnostics, SyntaxNode attributeSyntax, int parameterIndex, string unmanagedTypeName, AttributeData attribute)
        {
            throw new NotImplementedException();
        }

        public override void ReportMarshalUnmanagedTypeOnlyValidForFields(DiagnosticBag diagnostics, SyntaxNode attributeSyntax, int parameterIndex, string unmanagedTypeName, AttributeData attribute)
        {
            throw new NotImplementedException();
        }

        public override void ReportParameterNotValidForType(DiagnosticBag diagnostics, SyntaxNode attributeSyntax, int namedArgumentIndex)
        {
            throw new NotImplementedException();
        }
    }
}
