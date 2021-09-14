// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;

namespace MetaDslx.Languages.Core
{
    public class CoreCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public CoreCompilationOptions(OutputKind outputKind, bool reportSuppressedDiagnostics = false, string? moduleName = null, string? mainTypeName = null, string? scriptClassName = null, IEnumerable<string>? usings = null, OptimizationLevel optimizationLevel = OptimizationLevel.Debug, bool checkOverflow = false, bool allowUnsafe = false, string? cryptoKeyContainer = null, string? cryptoKeyFile = null, ImmutableArray<byte> cryptoPublicKey = default, bool? delaySign = null, Platform platform = Platform.AnyCpu, ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default, int warningLevel = 4, IEnumerable<KeyValuePair<string, ReportDiagnostic>>? specificDiagnosticOptions = null, bool concurrentBuild = true, bool deterministic = false, XmlReferenceResolver? xmlReferenceResolver = null, SourceReferenceResolver? sourceReferenceResolver = null, MetadataReferenceResolver? metadataReferenceResolver = null, AssemblyIdentityComparer? assemblyIdentityComparer = null, StrongNameProvider? strongNameProvider = null, bool publicSign = false, MetadataImportOptions metadataImportOptions = MetadataImportOptions.Public, NullableContextOptions nullableContextOptions = NullableContextOptions.Disable) 
            : base(CoreLanguage.Instance, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings, optimizationLevel, 
                  checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, generalDiagnosticOption, warningLevel,
                  specificDiagnosticOptions, concurrentBuild, deterministic, xmlReferenceResolver, sourceReferenceResolver, metadataReferenceResolver, 
                  assemblyIdentityComparer, strongNameProvider, publicSign, metadataImportOptions, nullableContextOptions)
        {
        }
        protected CoreCompilationOptions(CoreCompilationOptions other)
            : base(other)
        {
        }
        protected override Language LanguageCore => CoreLanguage.Instance;
        protected override LanguageCompilationOptions Clone()
        {
            return new CoreCompilationOptions(this);
        }
        public new CoreCompilationOptions WithOutputKind(OutputKind kind) => (CoreCompilationOptions)base.WithOutputKind(kind);
        public new CoreCompilationOptions WithReportSuppressedDiagnostics(bool value) => (CoreCompilationOptions)base.WithReportSuppressedDiagnostics(value);
        public new CoreCompilationOptions WithModuleName(string moduleName) => (CoreCompilationOptions)base.WithModuleName(moduleName);
        public new CoreCompilationOptions WithMainTypeName(string name) => (CoreCompilationOptions)base.WithMainTypeName(name);
        public new CoreCompilationOptions WithScriptClassName(string name) => (CoreCompilationOptions)base.WithScriptClassName(name);
        public new CoreCompilationOptions WithUsings(ImmutableArray<string> usings) => (CoreCompilationOptions)base.WithUsings(usings);
        public new CoreCompilationOptions WithUsings(IEnumerable<string> usings) => (CoreCompilationOptions)base.WithUsings(usings);
        public new CoreCompilationOptions WithUsings(params string[] usings) => (CoreCompilationOptions)base.WithUsings(usings);
        public new CoreCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (CoreCompilationOptions)base.WithOptimizationLevel(value);
        public new CoreCompilationOptions WithOverflowChecks(bool enabled) => (CoreCompilationOptions)base.WithOverflowChecks(enabled);
        public new CoreCompilationOptions WithAllowUnsafe(bool enabled) => (CoreCompilationOptions)base.WithAllowUnsafe(enabled);
        public new CoreCompilationOptions WithCryptoKeyContainer(string name) => (CoreCompilationOptions)base.WithCryptoKeyContainer(name);
        public new CoreCompilationOptions WithCryptoKeyFile(string path) => (CoreCompilationOptions)base.WithCryptoKeyFile(path);
        public new CoreCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (CoreCompilationOptions)base.WithCryptoPublicKey(value);
        public new CoreCompilationOptions WithDelaySign(bool? value) => (CoreCompilationOptions)base.WithDelaySign(value);
        public new CoreCompilationOptions WithPlatform(Platform platform) => (CoreCompilationOptions)base.WithPlatform(platform);
        public new CoreCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (CoreCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new CoreCompilationOptions WithWarningLevel(int warningLevel) => (CoreCompilationOptions)base.WithWarningLevel(warningLevel);
        public new CoreCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (CoreCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new CoreCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (CoreCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new CoreCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (CoreCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new CoreCompilationOptions WithDeterministic(bool deterministic) => (CoreCompilationOptions)base.WithDeterministic(deterministic);
        public new CoreCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (CoreCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new CoreCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (CoreCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new CoreCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (CoreCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new CoreCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (CoreCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new CoreCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (CoreCompilationOptions)base.WithStrongNameProvider(provider);
        public new CoreCompilationOptions WithPublicSign(bool publicSign) => (CoreCompilationOptions)base.WithPublicSign(publicSign);
        public new CoreCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (CoreCompilationOptions)base.WithMetadataImportOptions(value);
        public new CoreCompilationOptions WithNullableContextOptions(NullableContextOptions value) => (CoreCompilationOptions)base.WithNullableContextOptions(value);
        public new CoreCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (CoreCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new CoreCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (CoreCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
    }
}

