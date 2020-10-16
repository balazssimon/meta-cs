// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public MetaCompilationOptions(
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
            : base(MetaLanguage.Instance, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings,
                   optimizationLevel, checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, 
                   generalDiagnosticOption, warningLevel, specificDiagnosticOptions,
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer,
                   strongNameProvider, publicSign, metadataImportOptions, referencesSupersedeLowerVersions, topLevelBinderFlags)
        {
        }
        protected override LanguageCompilationOptions Clone()
        {
            return new MetaCompilationOptions(
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
        public new MetaCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (MetaCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new MetaCompilationOptions WithOutputKind(OutputKind kind) => (MetaCompilationOptions)base.WithOutputKind(kind);
        public new MetaCompilationOptions WithModuleName(string moduleName) => (MetaCompilationOptions)base.WithModuleName(moduleName);
        public new MetaCompilationOptions WithScriptClassName(string name) => (MetaCompilationOptions)base.WithScriptClassName(name);
        public new MetaCompilationOptions WithMainTypeName(string name) => (MetaCompilationOptions)base.WithMainTypeName(name);
        public new MetaCompilationOptions WithCryptoKeyContainer(string name) => (MetaCompilationOptions)base.WithCryptoKeyContainer(name);
        public new MetaCompilationOptions WithCryptoKeyFile(string path) => (MetaCompilationOptions)base.WithCryptoKeyFile(path);
        public new MetaCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (MetaCompilationOptions)base.WithCryptoPublicKey(value);
        public new MetaCompilationOptions WithDelaySign(bool? value) => (MetaCompilationOptions)base.WithDelaySign(value);
        public new MetaCompilationOptions WithUsings(ImmutableArray<string> usings) => (MetaCompilationOptions)base.WithUsings(usings);
        public new MetaCompilationOptions WithUsings(IEnumerable<string> usings) => (MetaCompilationOptions)base.WithUsings(usings);
        public new MetaCompilationOptions WithUsings(params string[] usings) => (MetaCompilationOptions)base.WithUsings(usings);
        public new MetaCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (MetaCompilationOptions)base.WithOptimizationLevel(value);
        public new MetaCompilationOptions WithOverflowChecks(bool enabled) => (MetaCompilationOptions)base.WithOverflowChecks(enabled);
        public new MetaCompilationOptions WithAllowUnsafe(bool enabled) => (MetaCompilationOptions)base.WithAllowUnsafe(enabled);
        public new MetaCompilationOptions WithPlatform(Platform platform) => (MetaCompilationOptions)base.WithPlatform(platform);
        public new MetaCompilationOptions WithPublicSign(bool publicSign) => (MetaCompilationOptions)base.WithPublicSign(publicSign);
        public new MetaCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (MetaCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new MetaCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (MetaCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new MetaCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (MetaCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new MetaCompilationOptions WithWarningLevel(int warningLevel) => (MetaCompilationOptions)base.WithWarningLevel(warningLevel);
        public new MetaCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (MetaCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new MetaCompilationOptions WithDeterministic(bool deterministic) => (MetaCompilationOptions)base.WithDeterministic(deterministic);
        public new MetaCompilationOptions WithCurrentLocalTime(DateTime value) => (MetaCompilationOptions)base.WithCurrentLocalTime(value);
        public new MetaCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (MetaCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new MetaCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (MetaCompilationOptions)base.WithMetadataImportOptions(value);
        public new MetaCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (MetaCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new MetaCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (MetaCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new MetaCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (MetaCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new MetaCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (MetaCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new MetaCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (MetaCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new MetaCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (MetaCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is MetaCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(MetaCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as MetaCompilationOptions);
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

