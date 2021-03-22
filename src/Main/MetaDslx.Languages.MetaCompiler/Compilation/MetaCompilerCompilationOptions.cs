// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;

namespace MetaDslx.Languages.MetaCompiler
{
    public class MetaCompilerCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public MetaCompilerCompilationOptions(
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
            : base(MetaCompilerLanguage.Instance, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings,
                   optimizationLevel, checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, 
                   generalDiagnosticOption, warningLevel, specificDiagnosticOptions,
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer,
                   strongNameProvider, publicSign, metadataImportOptions, referencesSupersedeLowerVersions, topLevelBinderFlags)
        {
        }
        protected override LanguageCompilationOptions Clone()
        {
            return new MetaCompilerCompilationOptions(
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
        public new MetaCompilerCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (MetaCompilerCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new MetaCompilerCompilationOptions WithOutputKind(OutputKind kind) => (MetaCompilerCompilationOptions)base.WithOutputKind(kind);
        public new MetaCompilerCompilationOptions WithModuleName(string moduleName) => (MetaCompilerCompilationOptions)base.WithModuleName(moduleName);
        public new MetaCompilerCompilationOptions WithScriptClassName(string name) => (MetaCompilerCompilationOptions)base.WithScriptClassName(name);
        public new MetaCompilerCompilationOptions WithMainTypeName(string name) => (MetaCompilerCompilationOptions)base.WithMainTypeName(name);
        public new MetaCompilerCompilationOptions WithCryptoKeyContainer(string name) => (MetaCompilerCompilationOptions)base.WithCryptoKeyContainer(name);
        public new MetaCompilerCompilationOptions WithCryptoKeyFile(string path) => (MetaCompilerCompilationOptions)base.WithCryptoKeyFile(path);
        public new MetaCompilerCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (MetaCompilerCompilationOptions)base.WithCryptoPublicKey(value);
        public new MetaCompilerCompilationOptions WithDelaySign(bool? value) => (MetaCompilerCompilationOptions)base.WithDelaySign(value);
        public new MetaCompilerCompilationOptions WithUsings(ImmutableArray<string> usings) => (MetaCompilerCompilationOptions)base.WithUsings(usings);
        public new MetaCompilerCompilationOptions WithUsings(IEnumerable<string> usings) => (MetaCompilerCompilationOptions)base.WithUsings(usings);
        public new MetaCompilerCompilationOptions WithUsings(params string[] usings) => (MetaCompilerCompilationOptions)base.WithUsings(usings);
        public new MetaCompilerCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (MetaCompilerCompilationOptions)base.WithOptimizationLevel(value);
        public new MetaCompilerCompilationOptions WithOverflowChecks(bool enabled) => (MetaCompilerCompilationOptions)base.WithOverflowChecks(enabled);
        public new MetaCompilerCompilationOptions WithAllowUnsafe(bool enabled) => (MetaCompilerCompilationOptions)base.WithAllowUnsafe(enabled);
        public new MetaCompilerCompilationOptions WithPlatform(Platform platform) => (MetaCompilerCompilationOptions)base.WithPlatform(platform);
        public new MetaCompilerCompilationOptions WithPublicSign(bool publicSign) => (MetaCompilerCompilationOptions)base.WithPublicSign(publicSign);
        public new MetaCompilerCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (MetaCompilerCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new MetaCompilerCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (MetaCompilerCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new MetaCompilerCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (MetaCompilerCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new MetaCompilerCompilationOptions WithWarningLevel(int warningLevel) => (MetaCompilerCompilationOptions)base.WithWarningLevel(warningLevel);
        public new MetaCompilerCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (MetaCompilerCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new MetaCompilerCompilationOptions WithDeterministic(bool deterministic) => (MetaCompilerCompilationOptions)base.WithDeterministic(deterministic);
        public new MetaCompilerCompilationOptions WithCurrentLocalTime(DateTime value) => (MetaCompilerCompilationOptions)base.WithCurrentLocalTime(value);
        public new MetaCompilerCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (MetaCompilerCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new MetaCompilerCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (MetaCompilerCompilationOptions)base.WithMetadataImportOptions(value);
        public new MetaCompilerCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (MetaCompilerCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new MetaCompilerCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (MetaCompilerCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new MetaCompilerCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (MetaCompilerCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new MetaCompilerCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (MetaCompilerCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new MetaCompilerCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (MetaCompilerCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new MetaCompilerCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (MetaCompilerCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is MetaCompilerCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(MetaCompilerCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as MetaCompilerCompilationOptions);
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

