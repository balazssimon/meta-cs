// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;

namespace MetaDslx.Languages.Compiler
{
    public class CompilerCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public CompilerCompilationOptions(OutputKind outputKind, bool reportSuppressedDiagnostics = false, string? moduleName = null, string? mainTypeName = null, string? scriptClassName = null, IEnumerable<string>? usings = null, OptimizationLevel optimizationLevel = OptimizationLevel.Debug, bool checkOverflow = false, bool allowUnsafe = false, string? cryptoKeyContainer = null, string? cryptoKeyFile = null, ImmutableArray<byte> cryptoPublicKey = default, bool? delaySign = null, Platform platform = Platform.AnyCpu, ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default, int warningLevel = 4, IEnumerable<KeyValuePair<string, ReportDiagnostic>>? specificDiagnosticOptions = null, bool concurrentBuild = true, bool deterministic = false, XmlReferenceResolver? xmlReferenceResolver = null, SourceReferenceResolver? sourceReferenceResolver = null, MetadataReferenceResolver? metadataReferenceResolver = null, AssemblyIdentityComparer? assemblyIdentityComparer = null, StrongNameProvider? strongNameProvider = null, bool publicSign = false, MetadataImportOptions metadataImportOptions = MetadataImportOptions.Public, NullableContextOptions nullableContextOptions = NullableContextOptions.Disable) 
            : base(CompilerLanguage.Instance, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings, optimizationLevel, 
                  checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, generalDiagnosticOption, warningLevel,
                  specificDiagnosticOptions, concurrentBuild, deterministic, xmlReferenceResolver, sourceReferenceResolver, metadataReferenceResolver, 
                  assemblyIdentityComparer, strongNameProvider, publicSign, metadataImportOptions, nullableContextOptions)
        {
        }
        protected CompilerCompilationOptions(CompilerCompilationOptions other)
            : base(other)
        {
        }
        protected override Language LanguageCore => CompilerLanguage.Instance;
        protected override LanguageCompilationOptions Clone()
        {
            return new CompilerCompilationOptions(this);
        }
        public new CompilerCompilationOptions WithOutputKind(OutputKind kind) => (CompilerCompilationOptions)base.WithOutputKind(kind);
        public new CompilerCompilationOptions WithReportSuppressedDiagnostics(bool value) => (CompilerCompilationOptions)base.WithReportSuppressedDiagnostics(value);
        public new CompilerCompilationOptions WithModuleName(string moduleName) => (CompilerCompilationOptions)base.WithModuleName(moduleName);
        public new CompilerCompilationOptions WithMainTypeName(string name) => (CompilerCompilationOptions)base.WithMainTypeName(name);
        public new CompilerCompilationOptions WithScriptClassName(string name) => (CompilerCompilationOptions)base.WithScriptClassName(name);
        public new CompilerCompilationOptions WithUsings(ImmutableArray<string> usings) => (CompilerCompilationOptions)base.WithUsings(usings);
        public new CompilerCompilationOptions WithUsings(IEnumerable<string> usings) => (CompilerCompilationOptions)base.WithUsings(usings);
        public new CompilerCompilationOptions WithUsings(params string[] usings) => (CompilerCompilationOptions)base.WithUsings(usings);
        public new CompilerCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (CompilerCompilationOptions)base.WithOptimizationLevel(value);
        public new CompilerCompilationOptions WithOverflowChecks(bool enabled) => (CompilerCompilationOptions)base.WithOverflowChecks(enabled);
        public new CompilerCompilationOptions WithAllowUnsafe(bool enabled) => (CompilerCompilationOptions)base.WithAllowUnsafe(enabled);
        public new CompilerCompilationOptions WithCryptoKeyContainer(string name) => (CompilerCompilationOptions)base.WithCryptoKeyContainer(name);
        public new CompilerCompilationOptions WithCryptoKeyFile(string path) => (CompilerCompilationOptions)base.WithCryptoKeyFile(path);
        public new CompilerCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (CompilerCompilationOptions)base.WithCryptoPublicKey(value);
        public new CompilerCompilationOptions WithDelaySign(bool? value) => (CompilerCompilationOptions)base.WithDelaySign(value);
        public new CompilerCompilationOptions WithPlatform(Platform platform) => (CompilerCompilationOptions)base.WithPlatform(platform);
        public new CompilerCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (CompilerCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new CompilerCompilationOptions WithWarningLevel(int warningLevel) => (CompilerCompilationOptions)base.WithWarningLevel(warningLevel);
        public new CompilerCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (CompilerCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new CompilerCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (CompilerCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new CompilerCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (CompilerCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new CompilerCompilationOptions WithDeterministic(bool deterministic) => (CompilerCompilationOptions)base.WithDeterministic(deterministic);
        public new CompilerCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (CompilerCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new CompilerCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (CompilerCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new CompilerCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (CompilerCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new CompilerCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (CompilerCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new CompilerCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (CompilerCompilationOptions)base.WithStrongNameProvider(provider);
        public new CompilerCompilationOptions WithPublicSign(bool publicSign) => (CompilerCompilationOptions)base.WithPublicSign(publicSign);
        public new CompilerCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (CompilerCompilationOptions)base.WithMetadataImportOptions(value);
        public new CompilerCompilationOptions WithNullableContextOptions(NullableContextOptions value) => (CompilerCompilationOptions)base.WithNullableContextOptions(value);
        public new CompilerCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (CompilerCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new CompilerCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (CompilerCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
    }
}

