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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations
{
    public class TestLanguageAnnotationsCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public TestLanguageAnnotationsCompilationOptions(
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
            : base(TestLanguageAnnotationsLanguage.Instance, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings,
                   optimizationLevel, checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, 
                   generalDiagnosticOption, warningLevel, specificDiagnosticOptions,
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer,
                   strongNameProvider, publicSign, metadataImportOptions, referencesSupersedeLowerVersions, topLevelBinderFlags)
        {
        }
        protected override LanguageCompilationOptions Clone()
        {
            return new TestLanguageAnnotationsCompilationOptions(
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
        public new TestLanguageAnnotationsCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (TestLanguageAnnotationsCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new TestLanguageAnnotationsCompilationOptions WithOutputKind(OutputKind kind) => (TestLanguageAnnotationsCompilationOptions)base.WithOutputKind(kind);
        public new TestLanguageAnnotationsCompilationOptions WithModuleName(string moduleName) => (TestLanguageAnnotationsCompilationOptions)base.WithModuleName(moduleName);
        public new TestLanguageAnnotationsCompilationOptions WithScriptClassName(string name) => (TestLanguageAnnotationsCompilationOptions)base.WithScriptClassName(name);
        public new TestLanguageAnnotationsCompilationOptions WithMainTypeName(string name) => (TestLanguageAnnotationsCompilationOptions)base.WithMainTypeName(name);
        public new TestLanguageAnnotationsCompilationOptions WithCryptoKeyContainer(string name) => (TestLanguageAnnotationsCompilationOptions)base.WithCryptoKeyContainer(name);
        public new TestLanguageAnnotationsCompilationOptions WithCryptoKeyFile(string path) => (TestLanguageAnnotationsCompilationOptions)base.WithCryptoKeyFile(path);
        public new TestLanguageAnnotationsCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (TestLanguageAnnotationsCompilationOptions)base.WithCryptoPublicKey(value);
        public new TestLanguageAnnotationsCompilationOptions WithDelaySign(bool? value) => (TestLanguageAnnotationsCompilationOptions)base.WithDelaySign(value);
        public new TestLanguageAnnotationsCompilationOptions WithUsings(ImmutableArray<string> usings) => (TestLanguageAnnotationsCompilationOptions)base.WithUsings(usings);
        public new TestLanguageAnnotationsCompilationOptions WithUsings(IEnumerable<string> usings) => (TestLanguageAnnotationsCompilationOptions)base.WithUsings(usings);
        public new TestLanguageAnnotationsCompilationOptions WithUsings(params string[] usings) => (TestLanguageAnnotationsCompilationOptions)base.WithUsings(usings);
        public new TestLanguageAnnotationsCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (TestLanguageAnnotationsCompilationOptions)base.WithOptimizationLevel(value);
        public new TestLanguageAnnotationsCompilationOptions WithOverflowChecks(bool enabled) => (TestLanguageAnnotationsCompilationOptions)base.WithOverflowChecks(enabled);
        public new TestLanguageAnnotationsCompilationOptions WithAllowUnsafe(bool enabled) => (TestLanguageAnnotationsCompilationOptions)base.WithAllowUnsafe(enabled);
        public new TestLanguageAnnotationsCompilationOptions WithPlatform(Platform platform) => (TestLanguageAnnotationsCompilationOptions)base.WithPlatform(platform);
        public new TestLanguageAnnotationsCompilationOptions WithPublicSign(bool publicSign) => (TestLanguageAnnotationsCompilationOptions)base.WithPublicSign(publicSign);
        public new TestLanguageAnnotationsCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (TestLanguageAnnotationsCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new TestLanguageAnnotationsCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (TestLanguageAnnotationsCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new TestLanguageAnnotationsCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (TestLanguageAnnotationsCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new TestLanguageAnnotationsCompilationOptions WithWarningLevel(int warningLevel) => (TestLanguageAnnotationsCompilationOptions)base.WithWarningLevel(warningLevel);
        public new TestLanguageAnnotationsCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (TestLanguageAnnotationsCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new TestLanguageAnnotationsCompilationOptions WithDeterministic(bool deterministic) => (TestLanguageAnnotationsCompilationOptions)base.WithDeterministic(deterministic);
        public new TestLanguageAnnotationsCompilationOptions WithCurrentLocalTime(DateTime value) => (TestLanguageAnnotationsCompilationOptions)base.WithCurrentLocalTime(value);
        public new TestLanguageAnnotationsCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (TestLanguageAnnotationsCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new TestLanguageAnnotationsCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (TestLanguageAnnotationsCompilationOptions)base.WithMetadataImportOptions(value);
        public new TestLanguageAnnotationsCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (TestLanguageAnnotationsCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new TestLanguageAnnotationsCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (TestLanguageAnnotationsCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new TestLanguageAnnotationsCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (TestLanguageAnnotationsCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new TestLanguageAnnotationsCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (TestLanguageAnnotationsCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new TestLanguageAnnotationsCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (TestLanguageAnnotationsCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new TestLanguageAnnotationsCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (TestLanguageAnnotationsCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is TestLanguageAnnotationsCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(TestLanguageAnnotationsCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as TestLanguageAnnotationsCompilationOptions);
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

