// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode
{
    public class TestLexerModeCompilationOptions : LanguageCompilationOptions, IEquatable<LanguageCompilationOptions>
    {
        public TestLexerModeCompilationOptions(
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
            : base(TestLexerModeLanguage.Instance, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, usings,
                   optimizationLevel, checkOverflow, allowUnsafe, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform, 
                   generalDiagnosticOption, warningLevel, specificDiagnosticOptions,
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer,
                   strongNameProvider, publicSign, metadataImportOptions, referencesSupersedeLowerVersions, topLevelBinderFlags)
        {
        }
        protected override LanguageCompilationOptions Clone()
        {
            return new TestLexerModeCompilationOptions(
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
        public new TestLexerModeCompilationOptions WithTopLevelBinderFlags(BinderFlags flags) => (TestLexerModeCompilationOptions)base.WithTopLevelBinderFlags(flags);
        public new TestLexerModeCompilationOptions WithOutputKind(OutputKind kind) => (TestLexerModeCompilationOptions)base.WithOutputKind(kind);
        public new TestLexerModeCompilationOptions WithModuleName(string moduleName) => (TestLexerModeCompilationOptions)base.WithModuleName(moduleName);
        public new TestLexerModeCompilationOptions WithScriptClassName(string name) => (TestLexerModeCompilationOptions)base.WithScriptClassName(name);
        public new TestLexerModeCompilationOptions WithMainTypeName(string name) => (TestLexerModeCompilationOptions)base.WithMainTypeName(name);
        public new TestLexerModeCompilationOptions WithCryptoKeyContainer(string name) => (TestLexerModeCompilationOptions)base.WithCryptoKeyContainer(name);
        public new TestLexerModeCompilationOptions WithCryptoKeyFile(string path) => (TestLexerModeCompilationOptions)base.WithCryptoKeyFile(path);
        public new TestLexerModeCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value) => (TestLexerModeCompilationOptions)base.WithCryptoPublicKey(value);
        public new TestLexerModeCompilationOptions WithDelaySign(bool? value) => (TestLexerModeCompilationOptions)base.WithDelaySign(value);
        public new TestLexerModeCompilationOptions WithUsings(ImmutableArray<string> usings) => (TestLexerModeCompilationOptions)base.WithUsings(usings);
        public new TestLexerModeCompilationOptions WithUsings(IEnumerable<string> usings) => (TestLexerModeCompilationOptions)base.WithUsings(usings);
        public new TestLexerModeCompilationOptions WithUsings(params string[] usings) => (TestLexerModeCompilationOptions)base.WithUsings(usings);
        public new TestLexerModeCompilationOptions WithOptimizationLevel(OptimizationLevel value) => (TestLexerModeCompilationOptions)base.WithOptimizationLevel(value);
        public new TestLexerModeCompilationOptions WithOverflowChecks(bool enabled) => (TestLexerModeCompilationOptions)base.WithOverflowChecks(enabled);
        public new TestLexerModeCompilationOptions WithAllowUnsafe(bool enabled) => (TestLexerModeCompilationOptions)base.WithAllowUnsafe(enabled);
        public new TestLexerModeCompilationOptions WithPlatform(Platform platform) => (TestLexerModeCompilationOptions)base.WithPlatform(platform);
        public new TestLexerModeCompilationOptions WithPublicSign(bool publicSign) => (TestLexerModeCompilationOptions)base.WithPublicSign(publicSign);
        public new TestLexerModeCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value) => (TestLexerModeCompilationOptions)base.WithGeneralDiagnosticOption(value);
        public new TestLexerModeCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values) => (TestLexerModeCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new TestLexerModeCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) => (TestLexerModeCompilationOptions)base.WithSpecificDiagnosticOptions(values);
        public new TestLexerModeCompilationOptions WithWarningLevel(int warningLevel) => (TestLexerModeCompilationOptions)base.WithWarningLevel(warningLevel);
        public new TestLexerModeCompilationOptions WithConcurrentBuild(bool concurrentBuild) => (TestLexerModeCompilationOptions)base.WithConcurrentBuild(concurrentBuild);
        public new TestLexerModeCompilationOptions WithDeterministic(bool deterministic) => (TestLexerModeCompilationOptions)base.WithDeterministic(deterministic);
        public new TestLexerModeCompilationOptions WithCurrentLocalTime(DateTime value) => (TestLexerModeCompilationOptions)base.WithCurrentLocalTime(value);
        public new TestLexerModeCompilationOptions WithDebugPlusMode(bool debugPlusMode) => (TestLexerModeCompilationOptions)base.WithDebugPlusMode(debugPlusMode);
        public new TestLexerModeCompilationOptions WithMetadataImportOptions(MetadataImportOptions value) => (TestLexerModeCompilationOptions)base.WithMetadataImportOptions(value);
        public new TestLexerModeCompilationOptions WithReferencesSupersedeLowerVersions(bool value) => (TestLexerModeCompilationOptions)base.WithReferencesSupersedeLowerVersions(value);
        public new TestLexerModeCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver) => (TestLexerModeCompilationOptions)base.WithXmlReferenceResolver(resolver);
        public new TestLexerModeCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver) => (TestLexerModeCompilationOptions)base.WithSourceReferenceResolver(resolver);
        public new TestLexerModeCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver) => (TestLexerModeCompilationOptions)base.WithMetadataReferenceResolver(resolver);
        public new TestLexerModeCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) => (TestLexerModeCompilationOptions)base.WithAssemblyIdentityComparer(comparer);
        public new TestLexerModeCompilationOptions WithStrongNameProvider(StrongNameProvider provider) => (TestLexerModeCompilationOptions)base.WithStrongNameProvider(provider);
        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
        }
        public override bool Equals(LanguageCompilationOptions other)
        {
            if (other is TestLexerModeCompilationOptions typedOptions) return this.Equals(typedOptions);
            else return base.Equals(other);
        }
        public bool Equals(TestLexerModeCompilationOptions other)
        {
            return base.Equals(other);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as TestLexerModeCompilationOptions);
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

