// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne
{
    public class TestLangOneCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public TestLangOneCompilationOptions(
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
            return new TestLangOneCompilationOptions(
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
        public new TestLangOneCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (TestLangOneCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new TestLangOneCompilationOptions WithOutputKind(OutputKind kind) => (TestLangOneCompilationOptions)base.WithOutputKind(kind);
        public new TestLangOneCompilationOptions WithModuleName(string moduleName) => (TestLangOneCompilationOptions)base.WithModuleName(moduleName);
        public new TestLangOneCompilationOptions WithScriptClassName(string name) => (TestLangOneCompilationOptions)base.WithScriptClassName(name);
        public new TestLangOneCompilationOptions WithMainTypeName(string name) => (TestLangOneCompilationOptions)base.WithMainTypeName(name);
        public new TestLangOneCompilationOptions WithCryptoKeyContainer(string name) => (TestLangOneCompilationOptions)base.WithCryptoKeyContainer(name);
        public new TestLangOneCompilationOptions WithCryptoKeyFile(string path) => (TestLangOneCompilationOptions)base.WithCryptoKeyFile(path);
        public new TestLangOneCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (TestLangOneCompilationOptions)base.WithCryptoPublicKey(value);
        public new TestLangOneCompilationOptions WithDelaySign(bool? value) => (TestLangOneCompilationOptions)base.WithDelaySign(value);
        public new TestLangOneCompilationOptions WithUsings(ImmutableArray<string> usings) => (TestLangOneCompilationOptions)base.WithUsings(usings);
        public new TestLangOneCompilationOptions WithUsings(IEnumerable<string> usings) => (TestLangOneCompilationOptions)base.WithUsings(usings);
        public new TestLangOneCompilationOptions WithUsings(params string[] usings) => (TestLangOneCompilationOptions)base.WithUsings(usings);
        public new TestLangOneCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (TestLangOneCompilationOptions)base.WithOptimizationLevel(value);
        public new TestLangOneCompilationOptions WithOverflowChecks(bool enabled) => (TestLangOneCompilationOptions)base.WithOverflowChecks(enabled);
        public new TestLangOneCompilationOptions WithAllowUnsafe(bool enabled) => (TestLangOneCompilationOptions)base.WithAllowUnsafe(enabled);
        public new TestLangOneCompilationOptions WithPlatform(Platform platform) => (TestLangOneCompilationOptions)base.WithPlatform(platform);
        public new TestLangOneCompilationOptions WithPublicSign(bool publicSign) => (TestLangOneCompilationOptions)base.WithPublicSign(publicSign);
        public new TestLangOneCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (TestLangOneCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new TestLangOneCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (TestLangOneCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new TestLangOneCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (TestLangOneCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new TestLangOneCompilationOptions WithWarningLevel(int warningLevel) => (TestLangOneCompilationOptions)base.WithWarningLevel(warningLevel);
        public new TestLangOneCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (TestLangOneCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new TestLangOneCompilationOptions WithDeterministic(bool deterministic) => (TestLangOneCompilationOptions)base.WithDeterministic(deterministic);
        public new TestLangOneCompilationOptions WithCurrentLocalTime(DateTime value) => (TestLangOneCompilationOptions)base.WithCurrentLocalTime(value);
        public new TestLangOneCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (TestLangOneCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new TestLangOneCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (TestLangOneCompilationOptions)base.WithMetadataImportOptions(value);
        public new TestLangOneCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (TestLangOneCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new TestLangOneCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (TestLangOneCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new TestLangOneCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (TestLangOneCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new TestLangOneCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (TestLangOneCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new TestLangOneCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (TestLangOneCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new TestLangOneCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (TestLangOneCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is TestLangOneCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(TestLangOneCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as TestLangOneCompilationOptions);
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

