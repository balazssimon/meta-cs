// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;

namespace MetaDslx.CodeAnalysis
{
    using MessageProvider = Microsoft.CodeAnalysis.CSharp.MessageProvider;

    /// <summary>
    /// Represents various options that affect compilation, such as 
    /// whether to emit an executable or a library, whether to optimize
    /// generated code, and so on.
    /// </summary>
    public abstract class LanguageCompilationOptions : CompilationOptionsAdapter, IEquatable<LanguageCompilationOptions>
    {
        private readonly Language _language;

        /// <summary>
        /// Allow unsafe regions (i.e. unsafe modifiers on members and unsafe blocks).
        /// </summary>
        public bool AllowUnsafe { get; protected set; }

        /// <summary>
        /// Global namespace usings.
        /// </summary>
        public ImmutableArray<string> Usings { get; protected set; }

        /// <summary>
        /// Flags applied to the top-level binder created for each syntax tree in the compilation 
        /// as well as for the binder of global imports.
        /// </summary>
        public BinderFlags TopLevelBinderFlags { get; protected set; }

        // Defaults correspond to the compiler's defaults or indicate that the user did not specify when that is significant.
        // That's significant when one option depends on another's setting. SubsystemVersion depends on Platform and Target.
        public LanguageCompilationOptions(
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
            ImmutableArray<byte> cryptoPublicKey = default(ImmutableArray<byte>),
            bool? delaySign = null,
            Platform platform = Platform.AnyCpu,
            ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default,
            int warningLevel = 4,
            IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions = null,
            bool concurrentBuild = true,
            bool deterministic = false,
            DateTime currentLocalTime = default(DateTime),
            bool debugPlusMode = false,
            XmlReferenceResolver xmlReferenceResolver = null,
            SourceReferenceResolver sourceReferenceResolver = null,
            MetadataReferenceResolver metadataReferenceResolver = null,
            AssemblyIdentityComparer assemblyIdentityComparer = null,
            StrongNameProvider strongNameProvider = null,
            bool publicSign = false,
            MetadataImportOptions metadataImportOptions = MetadataImportOptions.Public,
            bool referencesSupersedeLowerVersions = false,
            BinderFlags topLevelBinderFlags = BinderFlags.None)
            : base(outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName,
                   cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, publicSign, optimizationLevel, checkOverflow,
                   platform, generalDiagnosticOption, warningLevel, specificDiagnosticOptions.ToImmutableDictionaryOrEmpty(),
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer,
                   strongNameProvider, metadataImportOptions, referencesSupersedeLowerVersions)
        {
            _language = language;
            this.Usings = usings.AsImmutableOrEmpty();
            this.AllowUnsafe = allowUnsafe;
            this.TopLevelBinderFlags = topLevelBinderFlags;
        }

        public Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions ToCSharp()
        {
            return new Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions(
                outputKind: this.OutputKind,
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
                metadataImportOptions: this.MetadataImportOptions,
                referencesSupersedeLowerVersions: this.ReferencesSupersedeLowerVersions,
                reportSuppressedDiagnostics: this.ReportSuppressedDiagnostics,
                publicSign: this.PublicSign,
                topLevelBinderFlags: Microsoft.CodeAnalysis.CSharp.BinderFlags.None,
                nullableContextOptions: Microsoft.CodeAnalysis.CSharp.NullableContextOptions.Disable);
        }

        public new Language Language => this.LanguageCore;

        protected override Language LanguageCore => _language;

        protected abstract LanguageCompilationOptions Clone();

        public LanguageCompilationOptions WithTopLevelBinderFlags(BinderFlags flags)
        {
            if (flags == TopLevelBinderFlags) return this;
            var clone = this.Clone();
            clone.TopLevelBinderFlags = flags;
            return clone;
        }

        public new LanguageCompilationOptions WithOutputKind(OutputKind kind)
        {
            if (kind == this.OutputKind) return this;
            var clone = this.Clone();
            clone.OutputKind = kind;
            return clone;
        }

        public new LanguageCompilationOptions WithModuleName(string moduleName)
        {
            if (moduleName == this.ModuleName) return this;
            var clone = this.Clone();
            clone.ModuleName = moduleName;
            return clone;
        }

        public new LanguageCompilationOptions WithScriptClassName(string name)
        {
            if (name == this.ScriptClassName) return this;
            var clone = this.Clone();
            clone.ScriptClassName = name;
            return clone;
        }

        public new LanguageCompilationOptions WithMainTypeName(string name)
        {
            if (name == this.MainTypeName) return this;
            var clone = this.Clone();
            clone.MainTypeName = name;
            return clone;
        }

        public new LanguageCompilationOptions WithCryptoKeyContainer(string name)
        {
            if (name == this.CryptoKeyContainer) return this;
            var clone = this.Clone();
            clone.CryptoKeyContainer = name;
            return clone;
        }

        public new LanguageCompilationOptions WithCryptoKeyFile(string path)
        {
            if (string.IsNullOrEmpty(path)) path = null;
            if (path == this.CryptoKeyFile) return this;
            var clone = this.Clone();
            clone.CryptoKeyFile = path;
            return clone;
        }

        public new LanguageCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value)
        {
            if (value.IsDefault) value = ImmutableArray<byte>.Empty;
            if (value == this.CryptoPublicKey) return this;
            var clone = this.Clone();
            clone.CryptoPublicKey = value;
            return clone;
        }

        public new LanguageCompilationOptions WithDelaySign(bool? value)
        {
            if (value == this.DelaySign) return this;
            var clone = this.Clone();
            clone.DelaySign = value;
            return clone;
        }

        public LanguageCompilationOptions WithUsings(ImmutableArray<string> usings)
        {
            if (this.Usings == usings) return this;
            var clone = this.Clone();
            clone.Usings = usings;
            return clone;
        }

        public LanguageCompilationOptions WithUsings(IEnumerable<string> usings) => WithUsings(usings.AsImmutableOrEmpty());

        public LanguageCompilationOptions WithUsings(params string[] usings) => WithUsings((IEnumerable<string>)usings);

        public new LanguageCompilationOptions WithOptimizationLevel(OptimizationLevel value)
        {
            if (value == this.OptimizationLevel) return this;
            var clone = this.Clone();
            clone.OptimizationLevel = value;
            return clone;
        }

        public new LanguageCompilationOptions WithOverflowChecks(bool enabled)
        {
            if (enabled == this.CheckOverflow) return this;
            var clone = this.Clone();
            clone.CheckOverflow = enabled;
            return clone;
        }

        public LanguageCompilationOptions WithAllowUnsafe(bool enabled)
        {
            if (enabled == this.AllowUnsafe) return this;
            var clone = this.Clone();
            clone.AllowUnsafe = enabled;
            return clone;
        }

        public new LanguageCompilationOptions WithPlatform(Platform platform)
        {
            if (this.Platform == platform) return this;
            var clone = this.Clone();
            clone.Platform = platform;
            return clone;
        }

        public new LanguageCompilationOptions WithPublicSign(bool publicSign)
        {
            if (this.PublicSign == publicSign) return this;
            var clone = this.Clone();
            clone.PublicSign = publicSign;
            return clone;
        }

        protected override CompilationOptions CommonWithGeneralDiagnosticOption(ReportDiagnostic value) => 
            WithGeneralDiagnosticOption(value);

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions) =>
            WithSpecificDiagnosticOptions(specificDiagnosticOptions);

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions) =>
            WithSpecificDiagnosticOptions(specificDiagnosticOptions);

        protected override CompilationOptions CommonWithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics) =>
            WithReportSuppressedDiagnostics(reportSuppressedDiagnostics);

        public new LanguageCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value)
        {
            if (this.GeneralDiagnosticOption == value) return this;
            var clone = this.Clone();
            clone.GeneralDiagnosticOption = value;
            return clone;
        }

        public new LanguageCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values)
        {
            if (values == null) values = ImmutableDictionary<string, ReportDiagnostic>.Empty;
            if (this.SpecificDiagnosticOptions == values) return this;
            var clone = this.Clone();
            clone.SpecificDiagnosticOptions = values;
            return clone;
        }

        public new LanguageCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) =>
            WithSpecificDiagnosticOptions(values.ToImmutableDictionaryOrEmpty());

        public new LanguageCompilationOptions WithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics)
        {
            if (reportSuppressedDiagnostics == this.ReportSuppressedDiagnostics) return this;
            var clone = this.Clone();
            clone.ReportSuppressedDiagnostics = reportSuppressedDiagnostics;
            return clone;
        }

        public LanguageCompilationOptions WithWarningLevel(int warningLevel)
        {
            if (warningLevel == this.WarningLevel) return this;
            var clone = this.Clone();
            clone.WarningLevel = warningLevel;
            return clone;
        }

        public new LanguageCompilationOptions WithConcurrentBuild(bool concurrentBuild)
        {
            if (concurrentBuild == this.ConcurrentBuild) return this;
            var clone = this.Clone();
            clone.ConcurrentBuild = concurrentBuild;
            return clone;
        }

        public new LanguageCompilationOptions WithDeterministic(bool deterministic)
        {
            if (deterministic == this.Deterministic) return this;
            var clone = this.Clone();
            clone.Deterministic = deterministic;
            return clone;
        }

        public LanguageCompilationOptions WithCurrentLocalTime(DateTime value)
        {
            if (value == this.CurrentLocalTime) return this;
            var clone = this.Clone();
            clone.CurrentLocalTime = value;
            return clone;
        }

        public LanguageCompilationOptions WithDebugPlusMode(bool debugPlusMode)
        {
            if (debugPlusMode == this.DebugPlusMode) return this;
            var clone = this.Clone();
            clone.DebugPlusMode = debugPlusMode;
            return clone;
        }

        public new LanguageCompilationOptions WithMetadataImportOptions(MetadataImportOptions value)
        {
            if (value == this.MetadataImportOptions) return this;
            var clone = this.Clone();
            clone.MetadataImportOptions = value;
            return clone;
        }

        public LanguageCompilationOptions WithReferencesSupersedeLowerVersions(bool value)
        {
            if (value == this.ReferencesSupersedeLowerVersions) return this;
            var clone = this.Clone();
            clone.ReferencesSupersedeLowerVersions = value;
            return clone;
        }

        public new LanguageCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver)
        {
            if (ReferenceEquals(resolver, this.XmlReferenceResolver)) return this;
            var clone = this.Clone();
            clone.XmlReferenceResolver = resolver;
            return clone;
        }

        public new LanguageCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver)
        {
            if (ReferenceEquals(resolver, this.SourceReferenceResolver)) return this;
            var clone = this.Clone();
            clone.SourceReferenceResolver = resolver;
            return clone;
        }

        public new LanguageCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver)
        {
            if (ReferenceEquals(resolver, this.MetadataReferenceResolver)) return this;
            var clone = this.Clone();
            clone.MetadataReferenceResolver = resolver;
            return clone;
        }

        public new LanguageCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer)
        {
            comparer = comparer ?? AssemblyIdentityComparer.Default;
            if (ReferenceEquals(comparer, this.AssemblyIdentityComparer)) return this;
            var clone = this.Clone();
            clone.AssemblyIdentityComparer = comparer;
            return clone;
        }

        public new LanguageCompilationOptions WithStrongNameProvider(StrongNameProvider provider)
        {
            if (ReferenceEquals(provider, this.StrongNameProvider)) return this;
            var clone = this.Clone();
            clone.StrongNameProvider = provider;
            return clone;
        }

        protected override CompilationOptions CommonWithConcurrentBuild(bool concurrent) => WithConcurrentBuild(concurrent);
        protected override CompilationOptions CommonWithDeterministic(bool deterministic) => WithDeterministic(deterministic);

        protected override CompilationOptions CommonWithOutputKind(OutputKind kind) => WithOutputKind(kind);

        protected override CompilationOptions CommonWithPlatform(Platform platform) => WithPlatform(platform);

        protected override CompilationOptions CommonWithPublicSign(bool publicSign) => WithPublicSign(publicSign);

        protected override CompilationOptions CommonWithOptimizationLevel(OptimizationLevel value) => WithOptimizationLevel(value);

        protected override CompilationOptions CommonWithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) =>
            WithAssemblyIdentityComparer(comparer);

        protected override CompilationOptions CommonWithXmlReferenceResolver(XmlReferenceResolver resolver) =>
            WithXmlReferenceResolver(resolver);

        protected override CompilationOptions CommonWithSourceReferenceResolver(SourceReferenceResolver resolver) =>
            WithSourceReferenceResolver(resolver);

        protected override CompilationOptions CommonWithMetadataReferenceResolver(MetadataReferenceResolver resolver) =>
            WithMetadataReferenceResolver(resolver);

        protected override CompilationOptions CommonWithStrongNameProvider(StrongNameProvider provider) =>
            WithStrongNameProvider(provider);

        protected override CompilationOptions CommonWithMetadataImportOptions(MetadataImportOptions value) =>
            WithMetadataImportOptions(value);

        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            ValidateOptions(builder, MessageProvider.Instance);

            //  /main & /target:{library|netmodule|winmdobj}
            if (this.MainTypeName != null)
            {
                if (this.OutputKind.IsValid() && !this.OutputKind.IsApplication())
                {
                    builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_NoMainOnDLL));
                }

                if (!MainTypeName.IsValidClrTypeName())
                {
                    builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(MainTypeName), MainTypeName));
                }
            }

            if (!Platform.IsValid())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadPlatformType, Platform.ToString()));
            }

            if (ModuleName != null)
            {
                MetadataHelpers.CheckAssemblyOrModuleName(ModuleName, MessageProvider.Instance, InternalErrorCode.ERR_BadModuleName.Code, builder);
            }

            if (!OutputKind.IsValid())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(OutputKind), OutputKind.ToString()));
            }

            if (!OptimizationLevel.IsValid())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(OptimizationLevel), OptimizationLevel.ToString()));
            }

            if (ScriptClassName == null || !ScriptClassName.IsValidClrTypeName())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(ScriptClassName), ScriptClassName ?? "null"));
            }

            if (WarningLevel < 0 || WarningLevel > 4)
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(WarningLevel), WarningLevel));
            }

            if (Usings != null && Usings.Any(u => !u.IsValidClrNamespaceName()))
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(Usings), Usings.Where(u => !u.IsValidClrNamespaceName()).First() ?? "null"));
            }

            if (Platform == Platform.AnyCpu32BitPreferred && OutputKind.IsValid() && !(OutputKind == OutputKind.ConsoleApplication || OutputKind == OutputKind.WindowsApplication || OutputKind == OutputKind.WindowsRuntimeApplication))
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadPrefer32OnLib));
            }

            if (!MetadataImportOptions.IsValid())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(MetadataImportOptions), MetadataImportOptions.ToString()));
            }

            // TODO: add check for 
            //          (kind == 'arm' || kind == 'appcontainer' || kind == 'winmdobj') &&
            //          (version >= "6.2")
        }

        public virtual bool Equals(LanguageCompilationOptions other)
        {
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (!base.EqualsHelper(other))
            {
                return false;
            }

            return this.AllowUnsafe == other.AllowUnsafe &&
                   this.TopLevelBinderFlags == other.TopLevelBinderFlags &&
                   (this.Usings == null ? other.Usings == null : this.Usings.SequenceEqual(other.Usings, StringComparer.Ordinal));
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as LanguageCompilationOptions);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(base.GetHashCodeHelper(),
                   Hash.Combine(this.AllowUnsafe,
                   Hash.Combine(Hash.CombineValues(this.Usings, StringComparer.Ordinal), TopLevelBinderFlags.GetHashCode())));
        }

        public override Diagnostic FilterDiagnostic(Diagnostic diagnostic)
        {
            return LanguageDiagnosticFilter.Filter(diagnostic, WarningLevel, GeneralDiagnosticOption, SpecificDiagnosticOptions);
        }

        protected override CompilationOptions CommonWithModuleName(string moduleName)
        {
            return WithModuleName(moduleName);
        }

        protected override CompilationOptions CommonWithMainTypeName(string mainTypeName)
        {
            return WithMainTypeName(mainTypeName);
        }

        protected override CompilationOptions CommonWithScriptClassName(string scriptClassName)
        {
            return WithScriptClassName(scriptClassName);
        }

        protected override CompilationOptions CommonWithCryptoKeyContainer(string cryptoKeyContainer)
        {
            return WithCryptoKeyContainer(cryptoKeyContainer);
        }

        protected override CompilationOptions CommonWithCryptoKeyFile(string cryptoKeyFile)
        {
            return WithCryptoKeyFile(cryptoKeyFile);
        }

        protected override CompilationOptions CommonWithCryptoPublicKey(ImmutableArray<byte> cryptoPublicKey)
        {
            return WithCryptoPublicKey(cryptoPublicKey);
        }

        protected override CompilationOptions CommonWithDelaySign(bool? delaySign)
        {
            return WithDelaySign(delaySign);
        }

        protected override CompilationOptions CommonWithCheckOverflow(bool checkOverflow)
        {
            return WithOverflowChecks(checkOverflow);
        }
    }
}
