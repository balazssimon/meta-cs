// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public SoalCompilationOptions(
            Language language,
            OutputKind outputKind,
            bool reportSuppressedDiagnostics = false,
            string moduleName = null,
            string mainTypeName = null,
            string scriptClassName = null,
            IEnumerable<string> usings = null,
            OptimizationLevel optimizationLevel = OptimizationLevel.Debug,
            bool checkOverflow = false,
            bool allowUnsafe = false,
            string cryptoKeyContainer = null,
            string cryptoKeyFile = null,
            ImmutableArray<byte> cryptoPublicKey = default,
            bool? delaySign = null,
            Platform platform = Platform.AnyCpu,
            ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default,
            int warningLevel = 4,
            IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions = null,
            bool concurrentBuild = true,
            bool deterministic = false,
            DateTime currentLocalTime = default,
            bool debugPlusMode = false,
            XmlReferenceResolver xmlReferenceResolver = null,
            SourceReferenceResolver sourceReferenceResolver = null,
            MetadataReferenceResolver metadataReferenceResolver = null,
            AssemblyIdentityComparer assemblyIdentityComparer = null,
            StrongNameProvider strongNameProvider = null,
            bool publicSign = false,
            MetadataImportOptions metadataImportOptions = MetadataImportOptions.Public,
            bool referencesSupersedeLowerVersions = false,
            BinderFlags topLevelBinderFlags = null)
            : base(language, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings,
                   optimizationLevel, checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, 
                   generalDiagnosticOption, warningLevel, specificDiagnosticOptions,
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer,
                   strongNameProvider, publicSign, metadataImportOptions, referencesSupersedeLowerVersions, topLevelBinderFlags)
        {
        }
        protected override LanguageCompilationOptions Clone()
        {
            return new SoalCompilationOptions(
                language: this.Language,
                outputKind: this.OutputKind,
                reportSuppressedDiagnostics: this.ReportSuppressedDiagnostics,
                moduleName: this.ModuleName,
                mainTypeName: this.MainTypeName,
                scriptClassName: this.ScriptClassName,
                usings: this.Usings,
                optimizationLevel: this.OptimizationLevel,
                checkOverflow: this.CheckOverflow,
                allowUnsafe: this.AllowUnsafe,
                cryptoKeyContainer: this.CryptoKeyContainer,
                cryptoKeyFile: this.CryptoKeyFile,
                cryptoPublicKey: this.CryptoPublicKey,
                delaySign: this.DelaySign,
                platform: this.Platform,
                generalDiagnosticOption: this.GeneralDiagnosticOption,
                warningLevel: this.WarningLevel,
                specificDiagnosticOptions: this.SpecificDiagnosticOptions,
                concurrentBuild: this.ConcurrentBuild,
                deterministic: this.Deterministic,
                currentLocalTime: this.CurrentLocalTime,
                debugPlusMode: this.DebugPlusMode,
                xmlReferenceResolver: this.XmlReferenceResolver,
                sourceReferenceResolver: this.SourceReferenceResolver,
                metadataReferenceResolver: this.MetadataReferenceResolver,
                assemblyIdentityComparer: this.AssemblyIdentityComparer,
                strongNameProvider: this.StrongNameProvider,
                publicSign: this.PublicSign,
                metadataImportOptions: this.MetadataImportOptions,
                referencesSupersedeLowerVersions: this.ReferencesSupersedeLowerVersions,
                topLevelBinderFlags: this.TopLevelBinderFlags);
        }
        public new SoalCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (SoalCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new SoalCompilationOptions WithOutputKind(OutputKind kind) => (SoalCompilationOptions)base.WithOutputKind(kind);
        public new SoalCompilationOptions WithModuleName(string moduleName) => (SoalCompilationOptions)base.WithModuleName(moduleName);
        public new SoalCompilationOptions WithScriptClassName(string name) => (SoalCompilationOptions)base.WithScriptClassName(name);
        public new SoalCompilationOptions WithMainTypeName(string name) => (SoalCompilationOptions)base.WithMainTypeName(name);
        public new SoalCompilationOptions WithCryptoKeyContainer(string name) => (SoalCompilationOptions)base.WithCryptoKeyContainer(name);
        public new SoalCompilationOptions WithCryptoKeyFile(string path) => (SoalCompilationOptions)base.WithCryptoKeyFile(path);
        public new SoalCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (SoalCompilationOptions)base.WithCryptoPublicKey(value);
        public new SoalCompilationOptions WithDelaySign(bool? value) => (SoalCompilationOptions)base.WithDelaySign(value);
        public new SoalCompilationOptions WithUsings(ImmutableArray<string> usings) => (SoalCompilationOptions)base.WithUsings(usings);
        public new SoalCompilationOptions WithUsings(IEnumerable<string> usings) => (SoalCompilationOptions)base.WithUsings(usings);
        public new SoalCompilationOptions WithUsings(params string[] usings) => (SoalCompilationOptions)base.WithUsings(usings);
        public new SoalCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (SoalCompilationOptions)base.WithOptimizationLevel(value);
        public new SoalCompilationOptions WithOverflowChecks(bool enabled) => (SoalCompilationOptions)base.WithOverflowChecks(enabled);
        public new SoalCompilationOptions WithAllowUnsafe(bool enabled) => (SoalCompilationOptions)base.WithAllowUnsafe(enabled);
        public new SoalCompilationOptions WithPlatform(Platform platform) => (SoalCompilationOptions)base.WithPlatform(platform);
        public new SoalCompilationOptions WithPublicSign(bool publicSign) => (SoalCompilationOptions)base.WithPublicSign(publicSign);
        public new SoalCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (SoalCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new SoalCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (SoalCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new SoalCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (SoalCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new SoalCompilationOptions WithWarningLevel(int warningLevel) => (SoalCompilationOptions)base.WithWarningLevel(warningLevel);
        public new SoalCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (SoalCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new SoalCompilationOptions WithDeterministic(bool deterministic) => (SoalCompilationOptions)base.WithDeterministic(deterministic);
        public new SoalCompilationOptions WithCurrentLocalTime(DateTime value) => (SoalCompilationOptions)base.WithCurrentLocalTime(value);
        public new SoalCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (SoalCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new SoalCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (SoalCompilationOptions)base.WithMetadataImportOptions(value);
        public new SoalCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (SoalCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new SoalCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (SoalCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new SoalCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (SoalCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new SoalCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (SoalCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new SoalCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (SoalCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new SoalCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (SoalCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is SoalCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(SoalCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as SoalCompilationOptions);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override Diagnostic FilterDiagnostic(Diagnostic diagnostic)
        {
            return base.FilterDiagnostic(diagnostic);
        }
    }
}

