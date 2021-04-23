// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public MetaCompilationOptions(OutputKind outputKind, bool reportSuppressedDiagnostics = false, string? moduleName = null, string? mainTypeName = null, string? scriptClassName = null, IEnumerable<string>? usings = null, OptimizationLevel optimizationLevel = OptimizationLevel.Debug, bool checkOverflow = false, bool allowUnsafe = false, string? cryptoKeyContainer = null, string? cryptoKeyFile = null, ImmutableArray<byte> cryptoPublicKey = default, bool? delaySign = null, Platform platform = Platform.AnyCpu, ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default, int warningLevel = 4, IEnumerable<KeyValuePair<string, ReportDiagnostic>>? specificDiagnosticOptions = null, bool concurrentBuild = true, bool deterministic = false, XmlReferenceResolver? xmlReferenceResolver = null, SourceReferenceResolver? sourceReferenceResolver = null, MetadataReferenceResolver? metadataReferenceResolver = null, AssemblyIdentityComparer? assemblyIdentityComparer = null, StrongNameProvider? strongNameProvider = null, bool publicSign = false, MetadataImportOptions metadataImportOptions = MetadataImportOptions.Public, NullableContextOptions nullableContextOptions = NullableContextOptions.Disable) 
            : base(MetaLanguage.Instance, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings, optimizationLevel, 
                  checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, generalDiagnosticOption, warningLevel,
                  specificDiagnosticOptions, concurrentBuild, deterministic, xmlReferenceResolver, sourceReferenceResolver, metadataReferenceResolver, 
                  assemblyIdentityComparer, strongNameProvider, publicSign, metadataImportOptions, nullableContextOptions)
        {
        }

        protected MetaCompilationOptions(MetaCompilationOptions other)
            : base(other)
        {

        }

        protected override Language LanguageCore => MetaLanguage.Instance;

        protected override LanguageCompilationOptions Clone()
        {
            return new MetaCompilationOptions(this);
        }

        public new MetaCompilationOptions WithOutputKind(OutputKind kind) => (MetaCompilationOptions)base.WithOutputKind(kind);
        public new MetaCompilationOptions WithReportSuppressedDiagnostics(bool value) => (MetaCompilationOptions)base.WithReportSuppressedDiagnostics(value);
        public new MetaCompilationOptions WithModuleName(string moduleName) => (MetaCompilationOptions)base.WithModuleName(moduleName);
        public new MetaCompilationOptions WithMainTypeName(string name) => (MetaCompilationOptions)base.WithMainTypeName(name);
        public new MetaCompilationOptions WithScriptClassName(string name) => (MetaCompilationOptions)base.WithScriptClassName(name);
        public new MetaCompilationOptions WithUsings(ImmutableArray<string> usings) => (MetaCompilationOptions)base.WithUsings(usings);
        public new MetaCompilationOptions WithUsings(IEnumerable<string> usings) => (MetaCompilationOptions)base.WithUsings(usings);
        public new MetaCompilationOptions WithUsings(params string[] usings) => (MetaCompilationOptions)base.WithUsings(usings);
        public new MetaCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (MetaCompilationOptions)base.WithOptimizationLevel(value);
        public new MetaCompilationOptions WithOverflowChecks(bool enabled) => (MetaCompilationOptions)base.WithOverflowChecks(enabled);
        public new MetaCompilationOptions WithAllowUnsafe(bool enabled) => (MetaCompilationOptions)base.WithAllowUnsafe(enabled);
        public new MetaCompilationOptions WithCryptoKeyContainer(string name) => (MetaCompilationOptions)base.WithCryptoKeyContainer(name);
        public new MetaCompilationOptions WithCryptoKeyFile(string path) => (MetaCompilationOptions)base.WithCryptoKeyFile(path);
        public new MetaCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (MetaCompilationOptions)base.WithCryptoPublicKey(value);
        public new MetaCompilationOptions WithDelaySign(bool? value) => (MetaCompilationOptions)base.WithDelaySign(value);
        public new MetaCompilationOptions WithPlatform(Platform platform) => (MetaCompilationOptions)base.WithPlatform(platform);
        public new MetaCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (MetaCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new MetaCompilationOptions WithWarningLevel(int warningLevel) => (MetaCompilationOptions)base.WithWarningLevel(warningLevel);
        public new MetaCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (MetaCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new MetaCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (MetaCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new MetaCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (MetaCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new MetaCompilationOptions WithDeterministic(bool deterministic) => (MetaCompilationOptions)base.WithDeterministic(deterministic);
        public new MetaCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (MetaCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new MetaCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (MetaCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new MetaCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (MetaCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new MetaCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (MetaCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new MetaCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (MetaCompilationOptions)base.WithStrongNameProvider(provider);
        public new MetaCompilationOptions WithPublicSign(bool publicSign) => (MetaCompilationOptions)base.WithPublicSign(publicSign);
        public new MetaCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (MetaCompilationOptions)base.WithMetadataImportOptions(value);
        public new MetaCompilationOptions WithNullableContextOptions(NullableContextOptions value) => (MetaCompilationOptions)base.WithNullableContextOptions(value);

        public new MetaCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (MetaCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new MetaCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (MetaCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);

    }
}

