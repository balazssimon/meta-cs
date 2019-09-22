// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace WebSequenceDiagramsModel
{
    public class SequenceCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public SequenceCompilationOptions(
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
            return new SequenceCompilationOptions(
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
        public new SequenceCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (SequenceCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new SequenceCompilationOptions WithOutputKind(OutputKind kind) => (SequenceCompilationOptions)base.WithOutputKind(kind);
        public new SequenceCompilationOptions WithModuleName(string moduleName) => (SequenceCompilationOptions)base.WithModuleName(moduleName);
        public new SequenceCompilationOptions WithScriptClassName(string name) => (SequenceCompilationOptions)base.WithScriptClassName(name);
        public new SequenceCompilationOptions WithMainTypeName(string name) => (SequenceCompilationOptions)base.WithMainTypeName(name);
        public new SequenceCompilationOptions WithCryptoKeyContainer(string name) => (SequenceCompilationOptions)base.WithCryptoKeyContainer(name);
        public new SequenceCompilationOptions WithCryptoKeyFile(string path) => (SequenceCompilationOptions)base.WithCryptoKeyFile(path);
        public new SequenceCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (SequenceCompilationOptions)base.WithCryptoPublicKey(value);
        public new SequenceCompilationOptions WithDelaySign(bool? value) => (SequenceCompilationOptions)base.WithDelaySign(value);
        public new SequenceCompilationOptions WithUsings(ImmutableArray<string> usings) => (SequenceCompilationOptions)base.WithUsings(usings);
        public new SequenceCompilationOptions WithUsings(IEnumerable<string> usings) => (SequenceCompilationOptions)base.WithUsings(usings);
        public new SequenceCompilationOptions WithUsings(params string[] usings) => (SequenceCompilationOptions)base.WithUsings(usings);
        public new SequenceCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (SequenceCompilationOptions)base.WithOptimizationLevel(value);
        public new SequenceCompilationOptions WithOverflowChecks(bool enabled) => (SequenceCompilationOptions)base.WithOverflowChecks(enabled);
        public new SequenceCompilationOptions WithAllowUnsafe(bool enabled) => (SequenceCompilationOptions)base.WithAllowUnsafe(enabled);
        public new SequenceCompilationOptions WithPlatform(Platform platform) => (SequenceCompilationOptions)base.WithPlatform(platform);
        public new SequenceCompilationOptions WithPublicSign(bool publicSign) => (SequenceCompilationOptions)base.WithPublicSign(publicSign);
        public new SequenceCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (SequenceCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new SequenceCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (SequenceCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new SequenceCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (SequenceCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new SequenceCompilationOptions WithWarningLevel(int warningLevel) => (SequenceCompilationOptions)base.WithWarningLevel(warningLevel);
        public new SequenceCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (SequenceCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new SequenceCompilationOptions WithDeterministic(bool deterministic) => (SequenceCompilationOptions)base.WithDeterministic(deterministic);
        public new SequenceCompilationOptions WithCurrentLocalTime(DateTime value) => (SequenceCompilationOptions)base.WithCurrentLocalTime(value);
        public new SequenceCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (SequenceCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new SequenceCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (SequenceCompilationOptions)base.WithMetadataImportOptions(value);
        public new SequenceCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (SequenceCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new SequenceCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (SequenceCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new SequenceCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (SequenceCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new SequenceCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (SequenceCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new SequenceCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (SequenceCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new SequenceCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (SequenceCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is SequenceCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(SequenceCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as SequenceCompilationOptions);
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

