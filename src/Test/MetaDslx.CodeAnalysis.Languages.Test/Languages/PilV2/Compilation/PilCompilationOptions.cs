// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace PilV2
{
    public class PilCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public PilCompilationOptions(
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
            : base(PilLanguage.Instance, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings,
                   optimizationLevel, checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, 
                   generalDiagnosticOption, warningLevel, specificDiagnosticOptions,
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer,
                   strongNameProvider, publicSign, metadataImportOptions, referencesSupersedeLowerVersions, topLevelBinderFlags)
        {
        }
        protected override LanguageCompilationOptions Clone()
        {
            return new PilCompilationOptions(
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
        public new PilCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (PilCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new PilCompilationOptions WithOutputKind(OutputKind kind) => (PilCompilationOptions)base.WithOutputKind(kind);
        public new PilCompilationOptions WithModuleName(string moduleName) => (PilCompilationOptions)base.WithModuleName(moduleName);
        public new PilCompilationOptions WithScriptClassName(string name) => (PilCompilationOptions)base.WithScriptClassName(name);
        public new PilCompilationOptions WithMainTypeName(string name) => (PilCompilationOptions)base.WithMainTypeName(name);
        public new PilCompilationOptions WithCryptoKeyContainer(string name) => (PilCompilationOptions)base.WithCryptoKeyContainer(name);
        public new PilCompilationOptions WithCryptoKeyFile(string path) => (PilCompilationOptions)base.WithCryptoKeyFile(path);
        public new PilCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (PilCompilationOptions)base.WithCryptoPublicKey(value);
        public new PilCompilationOptions WithDelaySign(bool? value) => (PilCompilationOptions)base.WithDelaySign(value);
        public new PilCompilationOptions WithUsings(ImmutableArray<string> usings) => (PilCompilationOptions)base.WithUsings(usings);
        public new PilCompilationOptions WithUsings(IEnumerable<string> usings) => (PilCompilationOptions)base.WithUsings(usings);
        public new PilCompilationOptions WithUsings(params string[] usings) => (PilCompilationOptions)base.WithUsings(usings);
        public new PilCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (PilCompilationOptions)base.WithOptimizationLevel(value);
        public new PilCompilationOptions WithOverflowChecks(bool enabled) => (PilCompilationOptions)base.WithOverflowChecks(enabled);
        public new PilCompilationOptions WithAllowUnsafe(bool enabled) => (PilCompilationOptions)base.WithAllowUnsafe(enabled);
        public new PilCompilationOptions WithPlatform(Platform platform) => (PilCompilationOptions)base.WithPlatform(platform);
        public new PilCompilationOptions WithPublicSign(bool publicSign) => (PilCompilationOptions)base.WithPublicSign(publicSign);
        public new PilCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (PilCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new PilCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (PilCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new PilCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (PilCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new PilCompilationOptions WithWarningLevel(int warningLevel) => (PilCompilationOptions)base.WithWarningLevel(warningLevel);
        public new PilCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (PilCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new PilCompilationOptions WithDeterministic(bool deterministic) => (PilCompilationOptions)base.WithDeterministic(deterministic);
        public new PilCompilationOptions WithCurrentLocalTime(DateTime value) => (PilCompilationOptions)base.WithCurrentLocalTime(value);
        public new PilCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (PilCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new PilCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (PilCompilationOptions)base.WithMetadataImportOptions(value);
        public new PilCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (PilCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new PilCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (PilCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new PilCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (PilCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new PilCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (PilCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new PilCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (PilCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new PilCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (PilCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is PilCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(PilCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as PilCompilationOptions);
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

