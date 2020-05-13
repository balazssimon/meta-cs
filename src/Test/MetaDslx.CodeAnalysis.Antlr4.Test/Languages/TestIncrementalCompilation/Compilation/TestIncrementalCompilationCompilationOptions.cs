// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation
{
    public class TestIncrementalCompilationCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public TestIncrementalCompilationCompilationOptions(
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
            return new TestIncrementalCompilationCompilationOptions(
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
        public new TestIncrementalCompilationCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (TestIncrementalCompilationCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new TestIncrementalCompilationCompilationOptions WithOutputKind(OutputKind kind) => (TestIncrementalCompilationCompilationOptions)base.WithOutputKind(kind);
        public new TestIncrementalCompilationCompilationOptions WithModuleName(string moduleName) => (TestIncrementalCompilationCompilationOptions)base.WithModuleName(moduleName);
        public new TestIncrementalCompilationCompilationOptions WithScriptClassName(string name) => (TestIncrementalCompilationCompilationOptions)base.WithScriptClassName(name);
        public new TestIncrementalCompilationCompilationOptions WithMainTypeName(string name) => (TestIncrementalCompilationCompilationOptions)base.WithMainTypeName(name);
        public new TestIncrementalCompilationCompilationOptions WithCryptoKeyContainer(string name) => (TestIncrementalCompilationCompilationOptions)base.WithCryptoKeyContainer(name);
        public new TestIncrementalCompilationCompilationOptions WithCryptoKeyFile(string path) => (TestIncrementalCompilationCompilationOptions)base.WithCryptoKeyFile(path);
        public new TestIncrementalCompilationCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (TestIncrementalCompilationCompilationOptions)base.WithCryptoPublicKey(value);
        public new TestIncrementalCompilationCompilationOptions WithDelaySign(bool? value) => (TestIncrementalCompilationCompilationOptions)base.WithDelaySign(value);
        public new TestIncrementalCompilationCompilationOptions WithUsings(ImmutableArray<string> usings) => (TestIncrementalCompilationCompilationOptions)base.WithUsings(usings);
        public new TestIncrementalCompilationCompilationOptions WithUsings(IEnumerable<string> usings) => (TestIncrementalCompilationCompilationOptions)base.WithUsings(usings);
        public new TestIncrementalCompilationCompilationOptions WithUsings(params string[] usings) => (TestIncrementalCompilationCompilationOptions)base.WithUsings(usings);
        public new TestIncrementalCompilationCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (TestIncrementalCompilationCompilationOptions)base.WithOptimizationLevel(value);
        public new TestIncrementalCompilationCompilationOptions WithOverflowChecks(bool enabled) => (TestIncrementalCompilationCompilationOptions)base.WithOverflowChecks(enabled);
        public new TestIncrementalCompilationCompilationOptions WithAllowUnsafe(bool enabled) => (TestIncrementalCompilationCompilationOptions)base.WithAllowUnsafe(enabled);
        public new TestIncrementalCompilationCompilationOptions WithPlatform(Platform platform) => (TestIncrementalCompilationCompilationOptions)base.WithPlatform(platform);
        public new TestIncrementalCompilationCompilationOptions WithPublicSign(bool publicSign) => (TestIncrementalCompilationCompilationOptions)base.WithPublicSign(publicSign);
        public new TestIncrementalCompilationCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (TestIncrementalCompilationCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new TestIncrementalCompilationCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (TestIncrementalCompilationCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new TestIncrementalCompilationCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (TestIncrementalCompilationCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new TestIncrementalCompilationCompilationOptions WithWarningLevel(int warningLevel) => (TestIncrementalCompilationCompilationOptions)base.WithWarningLevel(warningLevel);
        public new TestIncrementalCompilationCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (TestIncrementalCompilationCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new TestIncrementalCompilationCompilationOptions WithDeterministic(bool deterministic) => (TestIncrementalCompilationCompilationOptions)base.WithDeterministic(deterministic);
        public new TestIncrementalCompilationCompilationOptions WithCurrentLocalTime(DateTime value) => (TestIncrementalCompilationCompilationOptions)base.WithCurrentLocalTime(value);
        public new TestIncrementalCompilationCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (TestIncrementalCompilationCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new TestIncrementalCompilationCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (TestIncrementalCompilationCompilationOptions)base.WithMetadataImportOptions(value);
        public new TestIncrementalCompilationCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (TestIncrementalCompilationCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new TestIncrementalCompilationCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (TestIncrementalCompilationCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new TestIncrementalCompilationCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (TestIncrementalCompilationCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new TestIncrementalCompilationCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (TestIncrementalCompilationCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new TestIncrementalCompilationCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (TestIncrementalCompilationCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new TestIncrementalCompilationCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (TestIncrementalCompilationCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is TestIncrementalCompilationCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(TestIncrementalCompilationCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as TestIncrementalCompilationCompilationOptions);
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

